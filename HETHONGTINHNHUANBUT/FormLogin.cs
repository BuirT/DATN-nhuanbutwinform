using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FormLogin : Form
    {
        private IMongoCollection<User> _UserColl;

        public FormLogin()
        {
            InitializeComponent();

            // Bọc try-catch để tránh văng ứng dụng nếu chưa kết nối được DB ngay từ đầu
            try
            {
                _UserColl = MongoProvider.Instance.GetCollection<User>("User");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa kết nối được Cơ sở dữ liệu: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnexit_Click(object sender, EventArgs e) => Application.Exit();

        // Sự kiện ấn Enter ở ô mật khẩu để đăng nhập nhanh
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Tắt âm thanh "bíp" của Windows
                btnlogin_Click(sender, e);
            }
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

            if (_UserColl == null)
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu bị gián đoạn. Vui lòng kiểm tra lại cấu hình!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Dùng FirstOrDefaultAsync thay vì FirstOrDefault để form không bị đơ khi chờ mạng
                var user = await _UserColl.Find(u => u.TenDangNhap == tenDangNhap).FirstOrDefaultAsync();

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

                // 1. KIỂM TRA MẬT KHẨU CÓ SALT (Chuẩn mới)
                if (!string.IsNullOrEmpty(user.Salt))
                {
                    string hashedInput = HashHelper.ComputeSha256(matKhau, user.Salt);
                    loginSuccess = string.Equals(user.MatKhau, hashedInput, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    // 2. KIỂM TRA CHUẨN CŨ (Để nâng cấp tài khoản cũ)
                    string hashedOld = HashHelper.ComputeSha256(matKhau, "");
                    if (user.MatKhau == matKhau || user.MatKhau == hashedOld)
                    {
                        loginSuccess = true;
                        needUpgrade = true;
                    }
                }

                if (loginSuccess)
                {
                    // Nâng cấp bảo mật nếu cần
                    if (needUpgrade)
                    {
                        string newSalt = HashHelper.GenerateSalt();
                        string newHashedPassword = HashHelper.ComputeSha256(matKhau, newSalt);
                        var update = Builders<User>.Update
                            .Set(u => u.Salt, newSalt)
                            .Set(u => u.MatKhau, newHashedPassword);
                        await _UserColl.UpdateOneAsync(u => u.Id == user.Id, update);
                    }

                    // --- CHUYỂN HƯỚNG VÀ TRUYỀN DỮ LIỆU SANG FORM CHÍNH ---
                    this.Hide();
                    FrmTrangChinh frm = new FrmTrangChinh();

                    frm.currentUserName = !string.IsNullOrEmpty(user.HoTen) ? user.HoTen : user.TenDangNhap;
                    frm.currentPrivilege = user.Quyen;
                    frm.currentMaTacGia = user.MaTacGiaGoc; // Quan trọng cho việc tra cứu

                    MongoProvider.Instance.GhiNhatKy(tenDangNhap, needUpgrade ? "Nâng cấp bảo mật & Đăng nhập thành công" : "Đăng nhập thành công");

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

        private void txtPassword_TextChanged(object sender, EventArgs e) { }
    }
}