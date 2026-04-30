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
        private readonly IMongoCollection<User> _UserColl;

        public FormRegister()
        {
            InitializeComponent();
            _UserColl = MongoProvider.Instance.GetCollection<User>("User");
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            // Thêm các quyền cho phép đăng ký (KHÔNG CÓ ADMIN nhé đồng chí)
            cboRole.Items.Add("Phóng viên");
            cboRole.Items.Add("Biên tập viên");
            cboRole.Items.Add("Kế toán");

            // Đặt mặc định là Biên tập viên cho tiện
            cboRole.SelectedIndex = 1;
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
            string selectedRole = cboRole.Text;

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Kiểm tra user đã tồn tại trong MongoDB chưa
                var existUser = await _UserColl.Find(t => t.TenDangNhap == userId).FirstOrDefaultAsync();

                if (existUser != null)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Đồng chí vui lòng chọn tên khác nhé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. Xử lý mã hóa mật khẩu
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

                // 3. Tạo Object Tài Khoản mới (gán quyền từ ComboBox)
                var tkMoi = new User
                {
                    TenDangNhap = userId,
                    MatKhau = hashedPassword,
                    HoTen = userId, // Tạm lấy tên đăng nhập làm họ tên
                    Quyen = selectedRole, // Cấp quyền người dùng chọn
                    HoatDong = true
                };

                // 4. Lưu xuống Database
                await _UserColl.InsertOneAsync(tkMoi);

                MessageBox.Show($"Đăng ký thành công tài khoản {selectedRole}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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