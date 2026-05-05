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
        private readonly IMongoCollection<User> _UserColl;
        private readonly IMongoCollection<TacGia> _TacGiaColl;

        public FormRegister()
        {
            InitializeComponent();
            _UserColl = MongoProvider.Instance.GetCollection<User>("User");
            _TacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            // CHỈ ĐỂ LẠI 3 NHÓM TÁC GIẢ ĐƯỢC TỰ ĐĂNG KÝ
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new object[] {
                "Phóng viên",
                "Cộng tác viên",
                "Khách mời"
            });

            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 0;
        }

        private async void btnregister_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text.Trim();
            string password = textBox2.Text;
            string confirm = textBox3.Text;
            string selectedRole = cboRole.Text;
            string maXacThuc = txtMaTacGia.Text.Trim();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Nhắc nhở");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Cảnh báo");
                return;
            }

            if (string.IsNullOrEmpty(maXacThuc))
            {
                MessageBox.Show("Vui lòng nhập Mã Tác giả hoặc CCCD để xác thực hồ sơ!", "Yêu cầu");
                return;
            }

            try
            {
                // 1. Kiểm tra tài khoản tồn tại
                var existUser = await _UserColl.Find(t => t.TenDangNhap == userId).FirstOrDefaultAsync();
                if (existUser != null)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại trên hệ thống!");
                    return;
                }

                // 2. Xác thực với bảng TacGia (Bắt buộc vì chỉ có 3 role tác giả)
                var author = await _TacGiaColl.Find(t => t.Maso == maXacThuc || t.MsTG == maXacThuc).FirstOrDefaultAsync();

                if (author == null)
                {
                    MessageBox.Show("Mã xác thực không đúng hoặc chưa có hồ sơ trên hệ thống!", "Từ chối");
                    return;
                }

                // 3. Hash mật khẩu (Giữ nguyên logic Salt của ông)
                string userSalt = HashHelper.GenerateSalt();
                string hashedPassword = HashHelper.ComputeSha256(password, userSalt);

                // 4. Lưu User mới
                var newUser = new User
                {
                    TenDangNhap = userId,
                    MatKhau = hashedPassword,
                    Salt = userSalt,
                    HoTen = author.Hoten,     // Lấy tên thật từ hồ sơ
                    Quyen = selectedRole,
                    HoatDong = true,
                    MaTacGiaGoc = author.Maso // Liên kết để tra cứu nhuận bút
                };

                await _UserColl.InsertOneAsync(newUser);
                MessageBox.Show($"Đăng ký thành công! Chào mừng {author.Hoten} gia nhập hệ thống.");
                ShowLoginAndClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e) => ShowLoginAndClose();

        private void ShowLoginAndClose()
        {
            var loginForm = Application.OpenForms.OfType<FormLogin>().FirstOrDefault();
            if (loginForm != null) { loginForm.Show(); loginForm.BringToFront(); }
            else { new FormLogin().Show(); }
            this.Close();
        }
    }
}