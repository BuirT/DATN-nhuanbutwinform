using System;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;     // Gọi MongoProvider
using HETHONGTINHNHUANBUT.Models;  // Gọi class User
using MongoDB.Driver;              // Thư viện Mongo
using System.Linq;

namespace HETHONGTINHNHUANBUT
{
    public partial class FormLogin : Form
    {
        // Khai báo bảng người dùng từ Cloud
        private IMongoCollection<User> userColl = MongoProvider.Instance.GetCollection<User>("gUser");

        public FormLogin()
        {
            InitializeComponent();
        }

        // Fix lỗi 'Form1_Load' không tồn tại
        private void FormLogin_Load(object sender, EventArgs e) { }

        private void btnexit_Click(object sender, EventArgs e) => Application.Exit();

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!");
                return;
            }

            try
            {
                // Tìm User bằng Filter tường minh (Fix lỗi Lambda FieldDefinition)
                var filter = Builders<User>.Filter.Eq("UserId", tenDangNhap);
                var user = userColl.Find(filter).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại trên hệ thống Cloud!");
                    return;
                }

                string hashedInput = HashHelper.ComputeSha256(matKhau);
                bool loginSuccess = false;

                // Kiểm tra mật khẩu (Hỗ trợ cả pass cũ và pass đã hash)
                if (HashHelper.IsSha256Hash(user.Password))
                    loginSuccess = string.Equals(user.Password, hashedInput, StringComparison.OrdinalIgnoreCase);
                else
                    loginSuccess = (user.Password == matKhau);

                if (loginSuccess)
                {
                    this.Hide();
                    FrmTrangChinh frm = new FrmTrangChinh();
                    frm.currentUserName = user.fullname ?? user.UserId;
                    frm.currentPrivilege = user.privelege;

                    MongoProvider.Instance.GhiNhatKy(tenDangNhap, "Đăng nhập Cloud thành công");
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối MongoDB Atlas: " + ex.Message);
            }
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormRegister().Show();
        }
    }
}