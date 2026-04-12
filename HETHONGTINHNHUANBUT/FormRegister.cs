using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FormRegister : Form
    {
        // Khai báo kết nối đến bảng TaiKhoan
        private readonly IMongoCollection<TaiKhoan> _taiKhoanColl;

        public FormRegister()
        {
            InitializeComponent();
            _taiKhoanColl = MongoProvider.Instance.GetCollection<TaiKhoan>("TaiKhoan");
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ShowLoginAndClose();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            ShowLoginAndClose();
        }

        // Thêm async để dùng await chọc lên MongoDB
        private async void btnregister_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text.Trim();
            string password = textBox2.Text;
            string confirm = textBox3.Text;

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Kiểm tra user đã tồn tại trong MongoDB chưa (Thay thế cho SELECT COUNT cũ)
                var existUser = await _taiKhoanColl.Find(t => t.TenDangNhap == userId).FirstOrDefaultAsync();

                if (existUser != null)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. Xử lý mã hóa mật khẩu (Anh vẫn giữ HashHelper của đồng chí nhé)
                string hashedPassword = password;
                try
                {
                    hashedPassword = HashHelper.ComputeSha256(password);
                }
                catch
                {
                    // Đề phòng trường hợp đồng chí đã xóa HashHelper thì lưu tạm text thường
                    hashedPassword = password;
                }

                // 3. Tạo Object Tài Khoản mới (Thay thế cho lệnh INSERT INTO cũ)
                var tkMoi = new TaiKhoan
                {
                    TenDangNhap = userId,
                    MatKhau = hashedPassword,
                    HoTen = userId, // Tạm lấy tên đăng nhập làm họ tên
                    Quyen = "Biên tập viên", // Cấp quyền cơ bản mặc định
                    HoatDong = true
                };

                // 4. Lưu xuống Database
                await _taiKhoanColl.InsertOneAsync(tkMoi);

                MessageBox.Show("Đăng ký thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowLoginAndClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoginAndClose()
        {
            try
            {
                var loginForm = Application.OpenForms.OfType<FormLogin>().FirstOrDefault();
                if (loginForm != null)
                {
                    loginForm.Show();
                    loginForm.BringToFront();
                    if (loginForm.WindowState == FormWindowState.Minimized)
                    {
                        loginForm.WindowState = FormWindowState.Normal;
                    }
                }
                else
                {
                    var frmLogin = new FormLogin();
                    frmLogin.Show();
                }
            }
            catch
            {
            }
            finally
            {
                this.Close();
            }
        }
    }
}