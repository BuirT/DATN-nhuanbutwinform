using System;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using System.Linq;

namespace HETHONGTINHNHUANBUT
{
    public partial class FormLogin : Form
    {
        // Sử dụng MongoProvider mà nhóm đã cấu hình sẵn
        private readonly IMongoCollection<User> _userColl;

        public FormLogin()
        {
            InitializeComponent();
            // Khởi tạo kết nối ngay khi mở form
            _userColl = MongoProvider.Instance.GetCollection<User>("gUser");
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Tự động focus vào ô nhập tài khoản cho tiện
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
                // Sử dụng cú pháp Lambda trực tiếp để tìm User (nhờ Model đã map chuẩn)
                var user = _userColl.Find(u => u.UserId == tenDangNhap).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại trên hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedInput = HashHelper.ComputeSha256(matKhau);
                bool loginSuccess = false;

                // Kiểm tra mật khẩu (Hỗ trợ cả pass cũ và pass đã hash)
                if (HashHelper.IsSha256Hash(user.Password))
                {
                    loginSuccess = string.Equals(user.Password, hashedInput, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    loginSuccess = (user.Password == matKhau);
                }

                if (loginSuccess)
                {
                    this.Hide();
                    FrmTrangChinh frm = new FrmTrangChinh();

                    // Xử lý chuỗi an toàn, phòng trường hợp null
                    frm.currentUserName = !string.IsNullOrEmpty(user.FullName) ? user.FullName : user.UserId;
                    frm.currentPrivilege = user.Privilege;

                    // Ghi nhật ký hệ thống
                    MongoProvider.Instance.GhiNhatKy(tenDangNhap, "Đăng nhập hệ thống thành công");

                    // Rất quan trọng: Khi tắt Form chính thì phải tắt luôn toàn bộ Application
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