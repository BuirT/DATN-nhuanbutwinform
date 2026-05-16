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
            // Đảm bảo chỉ nạp đúng 3 nhóm đối tượng được quyền tự đăng ký tài khoản
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
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(maXacThuc))
            {
                MessageBox.Show("Vui lòng nhập Mã Tác giả hoặc CCCD để xác thực hồ sơ!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try
            {
                // 1. Kiểm tra tài khoản trùng lặp
                var existUser = await _UserColl.Find(t => t.TenDangNhap == userId).FirstOrDefaultAsync();
                if (existUser != null)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại trên hệ thống!", "Lỗi tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Xác thực chéo thông tin với danh sách bảng TacGia SQL/Mongo
                var author = await _TacGiaColl.Find(t => t.Maso == maXacThuc || t.MsTG == maXacThuc).FirstOrDefaultAsync();

                if (author == null)
                {
                    MessageBox.Show("Mã xác thực không đúng hoặc chưa có hồ sơ tác giả trên hệ thống!", "Từ chối đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                // 3. Tiến hành băm mật khẩu bảo mật an toàn với chuỗi Salt ngẫu nhiên
                string userSalt = HashHelper.GenerateSalt();
                string hashedPassword = HashHelper.ComputeSha256(password, userSalt);

                // 4. Lưu thực thể người dùng mới vào cơ sở dữ liệu
                var newUser = new User
                {
                    TenDangNhap = userId,
                    MatKhau = hashedPassword,
                    Salt = userSalt,
                    HoTen = author.Hoten,     // Kế thừa tên thật trực tiếp từ hồ sơ tác giả
                    Quyen = selectedRole,
                    HoatDong = true,
                    MaTacGiaGoc = author.Maso // Đồng bộ khóa ngoại để tra cứu thông tin nhuận bút
                };

                await _UserColl.InsertOneAsync(newUser);
                MessageBox.Show($"Đăng ký thành công! Chào mừng đồng chí {author.Hoten} gia nhập hệ thống.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowLoginAndClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi vận hành", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e) => ShowLoginAndClose();

        private void ShowLoginAndClose()
        {
            var loginForm = Application.OpenForms.OfType<FormLogin>().FirstOrDefault();
            if (loginForm != null)
            {
                loginForm.Show();
                loginForm.BringToFront();
            }
            else
            {
                new FormLogin().Show();
            }
            this.Close();
        }
    }
}