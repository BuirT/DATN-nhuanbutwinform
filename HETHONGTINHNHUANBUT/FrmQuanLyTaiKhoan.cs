using HETHONGTINHNHUANBUT.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmQuanLyTaiKhoan : Form
    {
        bool isAddNew = false;

        public FrmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void FrmQuanLyTaiKhoan_Load_1(object sender, EventArgs e)
        {
            cboLoaiTK.Items.Clear();
            cboLoaiTK.Items.AddRange(new string[] { "Admin", "Thuong", "User" });

            clbPrivileges.Items.Clear();
            clbPrivileges.Items.AddRange(new string[] { "Nhuanbut", "Phieuchi" });

            LoadTaiKhoan();
            btnLuu.Enabled = false;
            txtUsername.ReadOnly = true;

            dgvTaiKhoan.DefaultCellStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);
            dgvTaiKhoan.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);
        }

        void LoadTaiKhoan()
        {
            try
            {
                string query = "SELECT UserId, fullname, GroupID, privelege FROM gUser";
                dgvTaiKhoan.DataSource = DataProvider.Instance.ExecuteQuery(query);

                if (dgvTaiKhoan.Columns["UserId"] != null) dgvTaiKhoan.Columns["UserId"].HeaderText = "Tên đăng nhập";
                if (dgvTaiKhoan.Columns["fullname"] != null) dgvTaiKhoan.Columns["fullname"].HeaderText = "Họ tên";
                if (dgvTaiKhoan.Columns["GroupID"] != null) dgvTaiKhoan.Columns["GroupID"].HeaderText = "Nhóm";
                if (dgvTaiKhoan.Columns["privelege"] != null) dgvTaiKhoan.Columns["privelege"].HeaderText = "Quyền";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTaiKhoan.CurrentRow != null)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["UserId"].Value?.ToString() ?? "";
                txtMatKhau.Clear();
                txtHoTen.Text = row.Cells["fullname"].Value?.ToString() ?? "";
                cboLoaiTK.Text = row.Cells["GroupID"].Value?.ToString() ?? "";

                string privs = row.Cells["privelege"].Value?.ToString() ?? "";
                for (int i = 0; i < clbPrivileges.Items.Count; i++)
                {
                    clbPrivileges.SetItemChecked(i, privs.Contains(clbPrivileges.Items[i].ToString()));
                }

                btnLuu.Enabled = false;
                txtUsername.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddNew = true;
            btnLuu.Enabled = true;
            txtUsername.ReadOnly = false;

            ClearInput();
            txtUsername.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng chọn Tài khoản cần sửa từ danh sách bên dưới!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAddNew = false;
            btnLuu.Enabled = true;
            txtUsername.ReadOnly = true;
            txtMatKhau.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(cboLoaiTK.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ Tên đăng nhập và Chọn Nhóm quyền!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isAddNew && string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cho tài khoản mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string privs = GetCheckedPrivileges();

                if (isAddNew)
                {
                    string query = "INSERT INTO gUser (UserId, Password, GroupID, privelege, fullname) VALUES (@id, @pass, @grp, @priv, @name)";
                    object[] para = new object[]
                    {
                        txtUsername.Text.Trim(),
                        HashHelper.ComputeSha256(txtMatKhau.Text.Trim()),
                        cboLoaiTK.Text,
                        privs,
                        txtHoTen.Text.Trim()
                    };
                    DataProvider.Instance.ExecuteNonQuery(query, para);
                    MessageBox.Show("Thêm mới Tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    {
                        string query = "UPDATE gUser SET GroupID=@grp, privelege=@priv, fullname=@name WHERE UserId=@id";
                        object[] para = new object[] { cboLoaiTK.Text, privs, txtHoTen.Text.Trim(), txtUsername.Text.Trim() };
                        DataProvider.Instance.ExecuteNonQuery(query, para);
                    }
                    else
                    {
                        string query = "UPDATE gUser SET Password=@pass, GroupID=@grp, privelege=@priv, fullname=@name WHERE UserId=@id";
                        object[] para = new object[]
                        {
                            HashHelper.ComputeSha256(txtMatKhau.Text.Trim()),
                            cboLoaiTK.Text,
                            privs,
                            txtHoTen.Text.Trim(),
                            txtUsername.Text.Trim()
                        };
                        DataProvider.Instance.ExecuteNonQuery(query, para);
                    }
                    MessageBox.Show("Cập nhật Tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadTaiKhoan();
                btnHuy_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tên đăng nhập này có thể đã tồn tại hoặc có lỗi:\n" + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text)) return;

            if (MessageBox.Show($"Đồng chí có chắc chắn muốn xóa tài khoản '{txtUsername.Text}' vĩnh viễn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM gUser WHERE UserId = @id";
                    DataProvider.Instance.ExecuteNonQuery(query, new object[] { txtUsername.Text.Trim() });
                    MessageBox.Show("Đã xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadTaiKhoan();
                    btnHuy_Click(sender, e);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message); }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInput();
            isAddNew = false;
            btnLuu.Enabled = false;
            txtUsername.ReadOnly = true;
        }

        string GetCheckedPrivileges()
        {
            string s = "";
            foreach (var item in clbPrivileges.CheckedItems) s += item.ToString() + ", ";
            return s.TrimEnd(' ', ',');
        }

        void ClearInput()
        {
            txtUsername.Clear(); txtMatKhau.Clear(); txtHoTen.Clear(); cboLoaiTK.SelectedIndex = -1;
            for (int i = 0; i < clbPrivileges.Items.Count; i++) clbPrivileges.SetItemChecked(i, false);
        }
    }
}
