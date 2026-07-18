using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.Models;

namespace HETHONGTINHNHUANBUT
{
    public partial class FormLogin : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        private bool _isPasswordHidden = true;
        private static bool _dbFixed = false;

        public FormLogin()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(this, true, null);
        }

        private void TaoBangUsersNeuChuaCo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                        CREATE TABLE Users (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            TenDangNhap NVARCHAR(100) UNIQUE NOT NULL,
                            MatKhau NVARCHAR(500) NOT NULL,
                            Salt NVARCHAR(100),
                            HoTen NVARCHAR(200),
                            Quyen NVARCHAR(50),
                            HoatDong BIT DEFAULT 1,
                            MaTacGiaGoc NVARCHAR(50)
                        );
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CauHinhThue' AND xtype='U')
                        BEGIN
                            CREATE TABLE CauHinhThue (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                MucChiuThue MONEY NOT NULL,
                                PhanTramThue REAL NOT NULL
                            );
                            INSERT INTO CauHinhThue (MucChiuThue, PhanTramThue) VALUES (2000000, 10);
                        END
                        ";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        private async void FormLogin_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();

            if (!_dbFixed) 
            { 
                await Task.Run(() => TaoBangUsersNeuChuaCo()); 
                await DatabaseMigrator.AutoFixDatabaseColumnsAsync();
                _dbFixed = true; 
            }

            txtUsername.Focus();
            this.ResumeLayout();
        }

        

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnlogin_Click(sender, e);
            }
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            _isPasswordHidden = !_isPasswordHidden;
            txtPassword.PasswordChar = _isPasswordHidden ? '●' : '\0';
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User user = null;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM Users WHERE TenDangNhap = @tdn";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tdn", tenDangNhap);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                user = new User
                                {
                                    Id = reader["Id"].ToString(),
                                    TenDangNhap = reader["TenDangNhap"].ToString(),
                                    MatKhau = reader["MatKhau"].ToString(),
                                    Salt = reader["Salt"]?.ToString(),
                                    HoTen = reader["HoTen"]?.ToString(),
                                    Quyen = reader["Quyen"]?.ToString(),
                                    HoatDong = Convert.ToBoolean(reader["HoatDong"]),
                                    MaTacGiaGoc = reader["MaTacGiaGoc"]?.ToString()
                                };
                            }
                        }
                    }
                }

                if (user == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại trên hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!user.HoatDong)
                {
                    MessageBox.Show("Tài khoản này đã bị khóa!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                bool loginSuccess = false;
                bool needUpgrade = false;

                if (!string.IsNullOrEmpty(user.Salt))
                {
                    string hashedInput = HashHelper.ComputeSha256(matKhau, user.Salt);
                    loginSuccess = string.Equals(user.MatKhau, hashedInput, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    string hashedOld = HashHelper.ComputeSha256(matKhau, "");
                    if (user.MatKhau == matKhau || user.MatKhau == hashedOld)
                    {
                        loginSuccess = true;
                        needUpgrade = true;
                    }
                }

                if (loginSuccess)
                {
                    if (needUpgrade)
                    {
                        string newSalt = HashHelper.GenerateSalt();
                        string newHashedPassword = HashHelper.ComputeSha256(matKhau, newSalt);
                        using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                        {
                            await conn.OpenAsync();
                            string updateSql = "UPDATE Users SET MatKhau = @mk, Salt = @salt WHERE Id = @id";
                            using (SqlCommand cmd = new SqlCommand(updateSql, conn))
                            {
                                cmd.Parameters.AddWithValue("@mk", newHashedPassword);
                                cmd.Parameters.AddWithValue("@salt", newSalt);
                                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(user.Id));
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                    }

                    this.Hide();
                    FrmTrangChinh frm = new FrmTrangChinh();
                    frm.currentUserName = !string.IsNullOrEmpty(user.HoTen) ? user.HoTen : user.TenDangNhap;
                    frm.currentPrivilege = user.Quyen;
                    frm.currentMaTacGia = user.MaTacGiaGoc;
                    frm.FormClosed += (s, args) => this.Close();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
