using HETHONGTINHNHUANBUT.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmButdanh : Form
    {
        public FrmButdanh()
        {
            InitializeComponent();
        }

        private void FrmButdanh_Load(object sender, EventArgs e)
        {
            LoadDanhSachTacGia();
            LoadData();

            // FIX LỖI FONT VNI CHO GUNA DATAGRIDVIEW
            dgvButDanh.DefaultCellStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);
            dgvButDanh.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);
        }

        // --- NẠP TÁC GIẢ VÀO COMBOBOX ---
        private void LoadDanhSachTacGia()
        {
            try
            {
                string sql = "SELECT Maso, Hoten FROM TacGia";
                DataTable dt = MongoProvider.Instance.ExecuteQuery(sql);
                cboTacGia.DataSource = dt;
                cboTacGia.DisplayMember = "Hoten"; // Hiển thị tên cho dễ nhìn
                cboTacGia.ValueMember = "Maso";    // Nhưng ngầm hiểu lưu giá trị là Mã
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Tác giả: " + ex.Message);
            }
        }

        // --- TẢI BẢNG BÚT DANH (KẾT HỢP LẤY TÊN TÁC GIẢ) ---
        private void LoadData()
        {
            try
            {
                string sql = @"
                    SELECT b.Maso, b.Butdanh, t.Hoten AS TenTacGia, b.MsTacgia 
                    FROM Butdanh b 
                    LEFT JOIN TacGia t ON b.MsTacgia = t.Maso";
                dgvButDanh.DataSource = MongoProvider.Instance.ExecuteQuery(sql);

                // Ẩn cột mã tác giả đi cho bảng nó gọn đẹp
                if (dgvButDanh.Columns["MsTacgia"] != null)
                {
                    dgvButDanh.Columns["MsTacgia"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaButDanh.Clear(); // Mã tự tăng nên mình để trống
            txtTenButDanh.Clear();
            txtTenButDanh.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenButDanh.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên bút danh!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Cột Maso là IDENTITY nên KHÔNG ĐƯỢC INSERT vào
                string query = "INSERT INTO Butdanh (Butdanh, MsTacgia) VALUES (@butdanh, @mstacgia)";

                object[] para = new object[] {
                    txtTenButDanh.Text,
                    cboTacGia.SelectedValue.ToString() // Lấy mã tác giả đang được chọn
                };

                if (MongoProvider.Instance.ExecuteNonQuery(query, para) > 0)
                {
                    MessageBox.Show("Thêm Bút danh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaButDanh.Text))
            {
                MessageBox.Show("Vui lòng chọn Bút danh cần sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "UPDATE Butdanh SET Butdanh = @butdanh, MsTacgia = @mstacgia WHERE Maso = @maso";

                object[] para = new object[] {
                    txtTenButDanh.Text,
                    cboTacGia.SelectedValue.ToString(),
                    Convert.ToInt32(txtMaButDanh.Text)
                };

                if (MongoProvider.Instance.ExecuteNonQuery(query, para) > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật:\n" + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaButDanh.Text)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Bút danh này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Butdanh WHERE Maso = @maso";
                    if (MongoProvider.Instance.ExecuteNonQuery(query, new object[] { Convert.ToInt32(txtMaButDanh.Text) }) > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThem_Click(sender, e);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        private void dgvButDanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvButDanh.CurrentRow == null || e.RowIndex < 0) return;

            int i = dgvButDanh.CurrentRow.Index;

            txtMaButDanh.Text = dgvButDanh.Rows[i].Cells["Maso"].Value?.ToString() ?? "";
            txtTenButDanh.Text = dgvButDanh.Rows[i].Cells["Butdanh"].Value?.ToString() ?? "";

            // Ép ComboBox chọn đúng tác giả của bút danh này
            string msTacGia = dgvButDanh.Rows[i].Cells["MsTacgia"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(msTacGia))
            {
                cboTacGia.SelectedValue = msTacGia;
            }
        }

        private void txtTenButDanh_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboTacGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}