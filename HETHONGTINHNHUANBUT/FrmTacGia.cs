using System;
using System.Data;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTacGia : Form
    {
        private bool isEditing = false;

        public FrmTacGia()
        {
            InitializeComponent();
        }

        private void FrmTacGia_Load(object sender, EventArgs e)
        {
            LoadData();

            dgvTacGia.DefaultCellStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);
            dgvTacGia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);

            SetFormState(false);
        }

        private void LoadData()
        {
            try
            {
                string sql = "SELECT Maso, Hoten, Diachi, Dienthoai FROM TacGia";
                dgvTacGia.DataSource = DataProvider.Instance.ExecuteQuery(sql);

                if (dgvTacGia.Columns["Maso"] != null)
                    dgvTacGia.Columns["Maso"].HeaderText = "Mã tác giả";

                if (dgvTacGia.Columns["Hoten"] != null)
                    dgvTacGia.Columns["Hoten"].HeaderText = "Họ tên";

                if (dgvTacGia.Columns["Diachi"] != null)
                    dgvTacGia.Columns["Diachi"].HeaderText = "Địa chỉ";

                if (dgvTacGia.Columns["Dienthoai"] != null)
                    dgvTacGia.Columns["Dienthoai"].HeaderText = "Điện thoại";

                dgvTacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaTacGia.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tác giả.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTacGia.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenTacGia.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTacGia.Focus();
                return false;
            }

            return true;
        }

        private void ClearInput()
        {
            txtMaTacGia.Clear();
            txtTenTacGia.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
        }

        private void SetFormState(bool editing)
        {
            isEditing = editing;
            txtMaTacGia.Enabled = !editing;

            if (!editing)
            {
                ClearInput();
                txtMaTacGia.Focus();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetFormState(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                string checkSql = "SELECT COUNT(*) FROM TacGia WHERE Maso = @Maso";
                int count = Convert.ToInt32(
                    DataProvider.Instance.ExecuteScalar(checkSql, new object[] { txtMaTacGia.Text.Trim() })
                );

                if (count > 0)
                {
                    MessageBox.Show("Mã tác giả này đã tồn tại. Vui lòng dùng nút Sửa nếu muốn cập nhật.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertSql = @"
                    INSERT INTO TacGia (Maso, Hoten, Diachi, Dienthoai)
                    VALUES (@Maso, @Hoten, @Diachi, @Dienthoai)";

                int result = DataProvider.Instance.ExecuteNonQuery(
                    insertSql,
                    new object[]
                    {
                        txtMaTacGia.Text.Trim(),
                        txtTenTacGia.Text.Trim(),
                        txtDiaChi.Text.Trim(),
                        txtDienThoai.Text.Trim()
                    });

                if (result > 0)
                {
                    MessageBox.Show("Thêm tác giả thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetFormState(false);
                }
                else
                {
                    MessageBox.Show("Không thể thêm tác giả.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                string updateSql = @"
                    UPDATE TacGia
                    SET Hoten = @Hoten,
                        Diachi = @Diachi,
                        Dienthoai = @Dienthoai
                    WHERE Maso = @Maso";

                int result = DataProvider.Instance.ExecuteNonQuery(
                    updateSql,
                    new object[]
                    {
                        txtTenTacGia.Text.Trim(),
                        txtDiaChi.Text.Trim(),
                        txtDienThoai.Text.Trim(),
                        txtMaTacGia.Text.Trim()
                    });

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetFormState(false);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tác giả để cập nhật.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTacGia.Text))
            {
                MessageBox.Show("Vui lòng chọn tác giả cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tác giả này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                return;

            try
            {
                string deleteSql = "DELETE FROM TacGia WHERE Maso = @Maso";

                int result = DataProvider.Instance.ExecuteNonQuery(
                    deleteSql,
                    new object[] { txtMaTacGia.Text.Trim() });

                if (result > 0)
                {
                    MessageBox.Show("Xóa tác giả thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    SetFormState(false);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tác giả để xóa.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa tác giả vì có dữ liệu liên quan hoặc có lỗi xảy ra.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetFormState(false);
        }

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvTacGia.Rows[e.RowIndex].Cells["Maso"].Value == null)
                return;

            DataGridViewRow row = dgvTacGia.Rows[e.RowIndex];

            txtMaTacGia.Text = row.Cells["Maso"].Value?.ToString() ?? "";
            txtTenTacGia.Text = row.Cells["Hoten"].Value?.ToString() ?? "";
            txtDiaChi.Text = row.Cells["Diachi"].Value?.ToString() ?? "";
            txtDienThoai.Text = row.Cells["Dienthoai"].Value?.ToString() ?? "";

            SetFormState(true);
        }

        private void dgvTacGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTacGia_CellClick(sender, e);
        }

        private void lbDiaChi_Click(object sender, EventArgs e)
        {
        }

        private void txtMaTacGia_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
