using System;
using System.Data;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;

namespace HETHONGTINHNHUANBUT
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Đồng chí nhập thiếu tài khoản hoặc mật khẩu rồi kìa!", "Nhắc nhở nhẹ");
                return;
            }

            try
            {
                string query = "SELECT UserId, Password, fullname, GroupID, privelege FROM dbo.gUser WHERE UserId = @UserId";
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDangNhap });

                if (data.Rows.Count == 0)
                {
                    ShowLoginFailed();
                    return;
                }

                DataRow row = data.Rows[0];
                string dbPassword = row["Password"] == DBNull.Value ? string.Empty : row["Password"].ToString().Trim();
                string inputPassword = matKhau.Trim();
                string hashedInput = HashHelper.ComputeSha256(inputPassword);

                bool loginSuccess = false;
                bool shouldUpgradePassword = false;

                if (HashHelper.IsSha256Hash(dbPassword))
                {
                    loginSuccess = string.Equals(dbPassword, hashedInput, StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    loginSuccess = string.Equals(dbPassword, inputPassword, StringComparison.Ordinal)
                                   || string.Equals(dbPassword, inputPassword, StringComparison.OrdinalIgnoreCase);
                    shouldUpgradePassword = loginSuccess;
                }

                if (!loginSuccess)
                {
                    ShowLoginFailed();
                    return;
                }

                if (shouldUpgradePassword)
                {
                    string updatePasswordQuery = "UPDATE dbo.gUser SET Password = @Password WHERE UserId = @UserId";
                    DataProvider.Instance.ExecuteNonQuery(updatePasswordQuery, new object[] { hashedInput, tenDangNhap });
                }

                string hoTen = row["fullname"] == DBNull.Value ? string.Empty : row["fullname"].ToString().Trim();
                string groupID = row["GroupID"] == DBNull.Value ? string.Empty : row["GroupID"].ToString().Trim();
                string privilege = row["privelege"] == DBNull.Value ? string.Empty : row["privelege"].ToString().Trim();

                if (string.IsNullOrWhiteSpace(hoTen))
                {
                    hoTen = tenDangNhap;
                }

                this.Hide();

                FrmTrangChinh frm = new FrmTrangChinh();
                frm.currentUserName = hoTen;
                frm.currentGroupID = groupID;
                frm.currentPrivilege = privilege;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoginFailed()
        {
            MessageBox.Show("Ủa, tài khoản hoặc mật khẩu không đúng rồi nha! Đồng chí kiểm tra lại xem.",
                "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister frmDK = new FormRegister();
            frmDK.Show();
        }

        private void txtusername_Click(object sender, EventArgs e)
        {
        }
    }
}
