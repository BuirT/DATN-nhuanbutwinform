using System;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT
{
    public partial class FormLogin : Form
    {
        private readonly IMongoCollection<User> _UserColl;

        public FormLogin()
        {
            InitializeComponent();
            _UserColl = MongoProvider.Instance.GetCollection<User>("User");
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnexit_Click(object sender, EventArgs e) => Application.Exit();

        // Thêm async để có thể await khi cập nhật Database
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
                var user = _UserColl.Find(u => u.TenDangNhap == tenDangNhap).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại trên hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!user.HoatDong)
                {
                    MessageBox.Show("Tài khoản này đã bị khóa. Vui lòng liên hệ Admin!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                bool loginSuccess = false;
                bool needUpgrade = false;

                // 1. KIỂM TRA MẬT KHẨU CÓ SALT (Chuẩn mới)
                if (!string.IsNullOrEmpty(user.Salt))
                {
                    string hashedInput = HashHelper.ComputeSha256(matKhau, user.Salt);
                    loginSuccess = string.Equals(user.MatKhau, hashedInput, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    // 2. KIỂM TRA THEO CHUẨN CŨ (Không Salt)
                    // a665a459... là mã của "123" băm với salt rỗng
                    string hashedOld = HashHelper.ComputeSha256(matKhau, "");
                    if (user.MatKhau == matKhau || user.MatKhau == hashedOld)
                    {
                        loginSuccess = true;
                        needUpgrade = true; // Đánh dấu để ép buộc đổi sang mã có Salt ngẫu nhiên
                    }
                }

                if (loginSuccess)
                {
                    // --- THỰC HIỆN NÂNG CẤP BẢO MẬT ---
                    if (needUpgrade)
                    {
                        string newSalt = HashHelper.GenerateSalt(); // Tạo muối ngẫu nhiên (Vd: "abcxyz")
                        string newHashedPassword = HashHelper.ComputeSha256(matKhau, newSalt);

                        var update = Builders<User>.Update
                            .Set(u => u.Salt, newSalt)
                            .Set(u => u.MatKhau, newHashedPassword);

                        // Ép buộc cập nhật xuống MongoDB
                        var result = await _UserColl.UpdateOneAsync(u => u.Id == user.Id, update);
                    }

                    this.Hide();
                    FrmTrangChinh frm = new FrmTrangChinh();
                    frm.currentUserName = !string.IsNullOrEmpty(user.HoTen) ? user.HoTen : user.TenDangNhap;
                    frm.currentPrivilege = user.Quyen;

                    MongoProvider.Instance.GhiNhatKy(tenDangNhap, needUpgrade ? "Nâng cấp bảo mật Salt thành công" : "Đăng nhập thành công");

                    frm.FormClosed += (s, args) => this.Close();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister frmReg = new FormRegister();
            frmReg.FormClosed += (s, args) => this.Show();
            frmReg.Show();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Để trống để sửa lỗi Designer dòng 97
        }
    }
}