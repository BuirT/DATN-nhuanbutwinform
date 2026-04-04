using System;
using System.Linq;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;

namespace HETHONGTINHNHUANBUT
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
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

        private void btnregister_Click(object sender, EventArgs e)
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
                string checkQuery = "SELECT COUNT(*) FROM dbo.gUser WHERE UserId = @UserId";
                object existObj = MongoProvider.Instance.ExecuteScalar(checkQuery, new object[] { userId });
                int existCount = 0;
                if (existObj != null && int.TryParse(existObj.ToString(), out int tmp)) existCount = tmp;

                if (existCount > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string insertQuery = "INSERT INTO dbo.gUser ( UserId , Password , fullname , GroupID , privelege ) VALUES ( @UserId , @Password , @Fullname , @GroupID , @Privelege )";

                string fullname = userId;
                string groupID = "Thuong";
                string privelege = "";
                string hashedPassword = HashHelper.ComputeSha256(password);

                int rows = MongoProvider.Instance.ExecuteNonQuery(insertQuery, new object[] { userId, hashedPassword, fullname, groupID, privelege });

                if (rows > 0)
                {
                    MessageBox.Show("Đăng ký thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowLoginAndClose();
                }
                else
                {
                    MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
