using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTaiKhoan : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        public string QuyenHienTai { get; set; }

        public FrmTaiKhoan()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(dgvTaiKhoan, true, null);
        }

        private async void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvTaiKhoan);
            cboQuyen.Items.Clear();
            string currentRole = QuyenHienTai?.Trim().ToLower() ?? "";

            if (currentRole == "admin" || currentRole == "quản trị viên")
                cboQuyen.Items.AddRange(new object[] { "Phóng viên", "Lãnh đạo", "Thư ký", "Kế toán", "Quản trị viên" });
            else
                cboQuyen.Items.AddRange(new object[] { "Phóng viên", "Lãnh đạo", "Thư ký", "Kế toán" });

            cboQuyen.DropDownHeight = 200;
            cboQuyen.IntegralHeight = true;
            cboQuyen.MaxDropDownItems = 15;
            if (cboQuyen.Items.Count > 0) cboQuyen.SelectedIndex = 0;

            await LoadDataAsync();
        }

        private async Task LoadDataAsync(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM Users";
                    if (!string.IsNullOrWhiteSpace(keyword))
                        query += " WHERE TenDangNhap LIKE @kw OR HoTen LIKE @kw";
                    query += " ORDER BY TenDangNhap";

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            await Task.Run(() => da.Fill(dt));
                        }
                    }

                    dgvTaiKhoan.DataSource = dt.AsEnumerable().Select(row => new {
                            Id = row["Id"],
                            TenDangNhap = row["TenDangNhap"].ToString(),
                            MatKhau = "********",
                            HoTen = row["HoTen"]?.ToString(),
                            Quyen = row["Quyen"]?.ToString(),
                            TrangThai = Convert.ToBoolean(row["HoatDong"]) ? "Đang hoạt động" : "Bị khóa"
                        }).ToList();
                }

                if (dgvTaiKhoan.Columns["Id"] != null) dgvTaiKhoan.Columns["Id"].Visible = false;
                if (dgvTaiKhoan.Columns.Count > 0)
                {
                    dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                    dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật khẩu";
                    dgvTaiKhoan.Columns["HoTen"].HeaderText = "Họ và Tên";
                    dgvTaiKhoan.Columns["Quyen"].HeaderText = "Vai trò";
                    dgvTaiKhoan.Columns["TrangThai"].HeaderText = "Trạng thái";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Tên đăng nhập và Mật khẩu!", "Nhắc nhở");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE TenDangNhap = @tdn";
                    using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@tdn", txtTenDangNhap.Text.Trim());
                        int exists = (int)await cmd.ExecuteScalarAsync();
                        if (exists > 0)
                        {
                            MessageBox.Show("Tên đăng nhập đã tồn tại!", "Cảnh báo");
                            return;
                        }
                    }

                    string newSalt = HashHelper.GenerateSalt();
                    string hashedPw = HashHelper.ComputeSha256(txtMatKhau.Text.Trim(), newSalt);
                    string insertQuery = "INSERT INTO Users (TenDangNhap, MatKhau, Salt, HoTen, Quyen, HoatDong) VALUES (@tdn, @mk, @salt, @ht, @q, @hd)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@tdn", txtTenDangNhap.Text.Trim());
                        cmd.Parameters.AddWithValue("@mk", hashedPw);
                        cmd.Parameters.AddWithValue("@salt", newSalt);
                        cmd.Parameters.AddWithValue("@ht", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@q", cboQuyen.Text);
                        cmd.Parameters.AddWithValue("@hd", chkHoatDong.Checked ? 1 : 0);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                MessageBox.Show("Thêm tài khoản thành công!");
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;

            string vaiTroCuaAccDangChon = dgvTaiKhoan.CurrentRow.Cells["Quyen"].Value?.ToString() ?? "";
            string currentRole = QuyenHienTai?.Trim().ToLower() ?? "";

            if ((vaiTroCuaAccDangChon.ToLower() == "admin" || vaiTroCuaAccDangChon.ToLower() == "quản trị viên") &&
                (currentRole != "admin" && currentRole != "quản trị viên"))
            {
                MessageBox.Show("Tài khoản này là Quản trị viên, bạn không có quyền thay đổi thông tin!", "Cấm vượt quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string id = dgvTaiKhoan.CurrentRow.Cells["Id"].Value.ToString();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string updateQuery = "UPDATE Users SET HoTen = @ht, Quyen = @q, HoatDong = @hd";
                    if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        updateQuery += ", MatKhau = @mk, Salt = @salt";
                    updateQuery += " WHERE Id = @id";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ht", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@q", cboQuyen.Text);
                        cmd.Parameters.AddWithValue("@hd", chkHoatDong.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                        if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        {
                            string newSalt = HashHelper.GenerateSalt();
                            cmd.Parameters.AddWithValue("@mk", HashHelper.ComputeSha256(txtMatKhau.Text.Trim(), newSalt));
                            cmd.Parameters.AddWithValue("@salt", newSalt);
                        }
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;
            string user = dgvTaiKhoan.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            string vaiTroCuaAccDangChon = dgvTaiKhoan.CurrentRow.Cells["Quyen"].Value?.ToString() ?? "";
            string currentRole = QuyenHienTai?.Trim().ToLower() ?? "";

            if ((vaiTroCuaAccDangChon.ToLower() == "admin" || vaiTroCuaAccDangChon.ToLower() == "quản trị viên") &&
                (currentRole != "admin" && currentRole != "quản trị viên"))
            {
                MessageBox.Show("Bảo vệ hệ thống: Bạn không thể xóa tài khoản Quản trị viên!", "Cấm vượt quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.ToLower() == "admin") { MessageBox.Show("Không thể xóa Admin hệ thống!"); return; }

            if (MessageBox.Show($"Xác nhận xóa tài khoản {user}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string id = dgvTaiKhoan.CurrentRow.Cells["Id"].Value.ToString();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string deleteQuery = "DELETE FROM Users WHERE Id = @id";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear(); txtMatKhau.Clear(); txtHoTen.Clear();
            cboQuyen.SelectedIndex = 0; chkHoatDong.Checked = true;
            txtTenDangNhap.ReadOnly = false; txtTenDangNhap.Focus();
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
                txtTenDangNhap.ReadOnly = true;
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();

                string vaiTro = row.Cells["Quyen"].Value?.ToString();
                if (cboQuyen.Items.Contains(vaiTro))
                    cboQuyen.Text = vaiTro;
                else
                    cboQuyen.SelectedIndex = -1;

                chkHoatDong.Checked = row.Cells["TrangThai"].Value?.ToString() == "Đang hoạt động";
            }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataAsync(txtTimKiem.Text);
        }
    }
}
