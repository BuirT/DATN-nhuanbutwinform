using HETHONGTINHNHUANBUT.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class frmSoBao : Form
    {
        public frmSoBao()
        {
            InitializeComponent();
        }

        private void frmSoBao_Load(object sender, EventArgs e)
        {
            LoadData();

            // FIX LỖI FONT VNI CHO BẢNG SỐ BÁO
            dgvSoBao.DefaultCellStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);
            dgvSoBao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("VNI-Times", 10.2F);
        }

        // --- HÀM TẢI DỮ LIỆU ---
        private void LoadData()
        {
            try
            {
                string sql = "SELECT Maso, Tenbao, Ngayra, Sobao, Sobo, Loaibao, DaDuyet FROM Bao ORDER BY Ngayra DESC";
                dgvSoBao.DataSource = DataProvider.Instance.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- NÚT THÊM MỚI (XÓA TRẮNG FORM) ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaso.Clear();
            txtTenBao.Clear();
            txtSoBao.Clear();
            txtSoBo.Clear();
            dtpNgayRa.Value = DateTime.Now;
            txtMaso.Focus();
        }

        // --- NÚT LƯU ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text) || string.IsNullOrEmpty(txtTenBao.Text))
            {
                MessageBox.Show("Đồng chí vui lòng nhập đầy đủ Mã số và Tên báo nha!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Bao (Maso, Tenbao, Ngayra, Sobao, Sobo, Loaibao, DaDuyet) VALUES (@maso, @tenbao, @ngayra, @sobao, @sobo, 'NG', 'N')";

                object[] para = new object[] {
                    Convert.ToInt32(txtMaso.Text),
                    txtTenBao.Text,
                    dtpNgayRa.Value,
                    txtSoBao.Text,
                    txtSoBo.Text
                };

                if (DataProvider.Instance.ExecuteNonQuery(query, para) > 0)
                {
                    MessageBox.Show("Thêm Số báo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã số này có thể đã tồn tại hoặc dữ liệu chưa đúng:\n" + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- NÚT SỬA ---
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text))
            {
                MessageBox.Show("Vui lòng chọn Số báo cần sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "UPDATE Bao SET Tenbao = @tenbao, Ngayra = @ngayra, Sobao = @sobao, Sobo = @sobo WHERE Maso = @maso";

                object[] para = new object[] {
                    txtTenBao.Text,
                    dtpNgayRa.Value,
                    txtSoBao.Text,
                    txtSoBo.Text,
                    Convert.ToInt32(txtMaso.Text)
                };

                if (DataProvider.Instance.ExecuteNonQuery(query, para) > 0)
                {
                    MessageBox.Show("Cập nhật Số báo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật:\n" + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- NÚT XÓA ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Số báo này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Bao WHERE Maso = @maso";
                    object[] para = new object[] { Convert.ToInt32(txtMaso.Text) };

                    if (DataProvider.Instance.ExecuteNonQuery(query, para) > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThem_Click(sender, e);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa (Số báo này đã có dữ liệu Nhuận bút):\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- NÚT HỦY ---
        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
        }

        // --- ĐẨY DỮ LIỆU LÊN TEXTBOX ---
        private void dgvSoBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSoBao.CurrentRow == null || e.RowIndex < 0) return;

            int i = dgvSoBao.CurrentRow.Index;

            txtMaso.Text = dgvSoBao.Rows[i].Cells["Maso"].Value?.ToString() ?? "";
            txtTenBao.Text = dgvSoBao.Rows[i].Cells["Tenbao"].Value?.ToString() ?? "";
            txtSoBao.Text = dgvSoBao.Rows[i].Cells["Sobao"].Value?.ToString() ?? "";
            txtSoBo.Text = dgvSoBao.Rows[i].Cells["Sobo"].Value?.ToString() ?? "";

            if (DateTime.TryParse(dgvSoBao.Rows[i].Cells["Ngayra"].Value?.ToString(), out DateTime ngayRa))
            {
                dtpNgayRa.Value = ngayRa;
            }
        }
    }
}