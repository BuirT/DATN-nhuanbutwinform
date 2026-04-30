using System;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models; // Bắt buộc phải có để xài model TaiKhoan
using MongoDB.Driver;
using System.Linq;

namespace HETHONGTINHNHUANBUT
{
    public partial class FormLogin : Form
    {
        // ĐÃ SỬA: Đổi từ User sang TaiKhoan cho đồng bộ với hệ thống mới
        private readonly IMongoCollection<User> _UserColl;

        public FormLogin()
        {
            InitializeComponent();
            // ĐÃ SỬA: Trỏ về đúng bảng "TaiKhoan" mà FrmTaiKhoan đang lưu
            _UserColl = MongoProvider.Instance.GetCollection<User>("User");
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnexit_Click(object sender, EventArgs e) => Application.Exit();

        private void btnlogin_Click(object sender, EventArgs e)
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
                // ĐÃ SỬA: Tìm theo TenDangNhap trong bảng TaiKhoan
                var user = _UserColl.Find(u => u.TenDangNhap == tenDangNhap).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại trên hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // TÍNH NĂNG MỚI: Check xem tài khoản có đang bị khóa không (Checkbox HoatDong bên FrmTaiKhoan)
                if (!user.HoatDong)
                {
                    MessageBox.Show("Tài khoản này đã bị khóa. Vui lòng liên hệ Admin!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                string hashedInput = HashHelper.ComputeSha256(matKhau);
                bool loginSuccess = false;

                // Kiểm tra mật khẩu (hỗ trợ cả pass chưa hash và pass đã hash)
                if (HashHelper.IsSha256Hash(user.MatKhau))
                {
                    loginSuccess = string.Equals(user.MatKhau, hashedInput, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    loginSuccess = (user.MatKhau == matKhau);
                }

                if (loginSuccess)
                {
                    this.Hide();
                    FrmTrangChinh frm = new FrmTrangChinh();

                    // ĐÃ SỬA: Map dữ liệu theo biến mới HoTen và Quyen của model TaiKhoan
                    frm.currentUserName = !string.IsNullOrEmpty(user.HoTen) ? user.HoTen : user.TenDangNhap;
                    frm.currentPrivilege = user.Quyen;

                    MongoProvider.Instance.GhiNhatKy(tenDangNhap, "Đăng nhập hệ thống thành công");

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
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister frmReg = new FormRegister();

            // Hiện lại form đăng nhập khi người dùng đóng form đăng ký
            frmReg.FormClosed += (s, args) => this.Show();
            frmReg.Show();
        }
    }
}