using HETHONGTINHNHUANBUT.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmNhapNhuanBut : Form
    {
        public FrmNhapNhuanBut()
        {
            InitializeComponent();
        }

        private void FrmNhapNhuanBut_Load(object sender, EventArgs e)
        {
            LoadDanhSachSoBao();
            LoadDanhSachButDanh();
            btnLuu.Enabled = false;

            // --- BẮT BUỘC ÉP FONT VNI CHO TOÀN BỘ BẢNG (DÒNG CHẴN VÀ DÒNG LẺ) ---
            System.Drawing.Font vniFont = new System.Drawing.Font("VNI-Times", 10.2F);

            dgvNhuanButCT.DefaultCellStyle.Font = vniFont;
            dgvNhuanButCT.RowsDefaultCellStyle.Font = vniFont;
            dgvNhuanButCT.AlternatingRowsDefaultCellStyle.Font = vniFont; // Ép font cho dòng lẻ

            dgvNhuanButCT.ThemeStyle.RowsStyle.Font = vniFont;
            dgvNhuanButCT.ThemeStyle.AlternatingRowsStyle.Font = vniFont;

            // Ép font cho ComboBox vì Tên Số Báo và Bút Danh đều dùng mã VNI cũ
            cboSoBao.Font = new System.Drawing.Font("VNI-Times", 10.8F);
            cboButDanh.Font = vniFont;
        }

        // ====================================================================
        // PHẦN 1: LOAD DỮ LIỆU BAN ĐẦU
        // ====================================================================
        void LoadDanhSachSoBao()
        {
            try
            {
                string query = "SELECT Maso, Tenbao + ' (Số: ' + LTRIM(RTRIM(Sobao)) + ')' as Display FROM Bao WHERE DaDuyet = 'N' ORDER BY Ngayra DESC";
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);

                cboSoBao.DataSource = dt;
                cboSoBao.DisplayMember = "Display";
                cboSoBao.ValueMember = "Maso";

                if (dt.Rows.Count == 0)
                {
                    lblTongTien.Text = "Tòa soạn chưa có Số Báo mới nào cần nhập!";
                    dgvNhuanButCT.DataSource = null;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách Số báo: " + ex.Message); }
        }

        void LoadDanhSachButDanh()
        {
            try
            {
                string query = "SELECT Butdanh FROM Butdanh ORDER BY Butdanh";
                cboButDanh.DataSource = DataProvider.Instance.ExecuteQuery(query);
                cboButDanh.DisplayMember = "Butdanh";
                cboButDanh.ValueMember = "Butdanh";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải Bút danh: " + ex.Message); }
        }

        // ====================================================================
        // PHẦN 2: CHỌN SỐ BÁO VÀ TÍNH TIỀN TỰ ĐỘNG
        // ====================================================================
        private void cboSoBao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue != null && int.TryParse(cboSoBao.SelectedValue.ToString(), out int maBao))
            {
                LoadLuoiChiTiet(maBao);
                TinhTongTien(maBao);
            }
        }

        void LoadLuoiChiTiet(int maBao)
        {
            string query = "SELECT Maso, Tenbai, Trang, Muc, TienNhuanbut, Butdanh FROM Nhuanbut WHERE MsBao = @maBao ORDER BY Maso DESC";
            dgvNhuanButCT.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { maBao });
        }

        void TinhTongTien(int maBao)
        {
            string query = "SELECT SUM(TienNhuanbut) FROM Nhuanbut WHERE MsBao = @maBao";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { maBao });

            decimal tong = (result != DBNull.Value && result.ToString() != "") ? Convert.ToDecimal(result) : 0;
            lblTongTien.Text = $"Tổng quỹ đang nhập: {tong:N0} VNĐ";
        }

        // ====================================================================
        // PHẦN 3: CÁC NÚT THAO TÁC (CRUD)
        // ====================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSoBao.Items.Count == 0)
            {
                MessageBox.Show("Chưa có Số Báo nào được mở. Vui lòng sang danh mục Số Báo tạo mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtMaBai.Clear();
            txtTenBai.Clear();
            txtTrang.Clear();
            txtMuc.Clear();
            txtSoTien.Clear();
            txtTenBai.Focus();
            btnLuu.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBai.Text))
            {
                MessageBox.Show("Vui lòng chọn bài viết từ bảng bên dưới để sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenBai.Text) || string.IsNullOrEmpty(txtSoTien.Text))
            {
                MessageBox.Show("Tên bài và Số tiền không được để trống!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maBao = Convert.ToInt32(cboSoBao.SelectedValue);
                decimal soTien = Convert.ToDecimal(txtSoTien.Text);

                if (string.IsNullOrEmpty(txtMaBai.Text))
                {
                    string query = @"
                        DECLARE @newID INT; 
                        SELECT @newID = ISNULL(MAX(Maso), 0) + 1 FROM Nhuanbut; 
                        INSERT INTO Nhuanbut (Maso, Tenbai, Trang, Muc, TienNhuanbut, Butdanh, MsBao) 
                        VALUES (@newID, @ten, @trang, @muc, @tien, @butdanh, @msbao)";

                    DataProvider.Instance.ExecuteNonQuery(query, new object[] { txtTenBai.Text, txtTrang.Text, txtMuc.Text, soTien, cboButDanh.Text, maBao });
                    MessageBox.Show("Thêm bài viết thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string query = "UPDATE Nhuanbut SET Tenbai=@ten, Trang=@trang, Muc=@muc, TienNhuanbut=@tien, Butdanh=@butdanh WHERE Maso=@mabai";
                    DataProvider.Instance.ExecuteNonQuery(query, new object[] { txtTenBai.Text, txtTrang.Text, txtMuc.Text, soTien, cboButDanh.Text, Convert.ToInt32(txtMaBai.Text) });
                    MessageBox.Show("Cập nhật bài viết thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadLuoiChiTiet(maBao);
                TinhTongTien(maBao);
                btnThem_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi định dạng dữ liệu (ví dụ: Số tiền phải là số):\n" + ex.Message, "Lỗi Nhập Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBai.Text)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bài viết này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maBao = Convert.ToInt32(cboSoBao.SelectedValue);
                string query = "DELETE FROM Nhuanbut WHERE Maso = @maso";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { Convert.ToInt32(txtMaBai.Text) });

                LoadLuoiChiTiet(maBao);
                TinhTongTien(maBao);
                btnThem_Click(sender, e);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem_Click(sender, e);
            btnLuu.Enabled = false;
        }

        private void dgvNhuanButCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhuanButCT.CurrentRow == null || e.RowIndex < 0) return;

            DataGridViewRow row = dgvNhuanButCT.Rows[e.RowIndex];
            txtMaBai.Text = row.Cells["Maso"].Value?.ToString() ?? "";
            txtTenBai.Text = row.Cells["Tenbai"].Value?.ToString() ?? "";
            txtTrang.Text = row.Cells["Trang"].Value?.ToString() ?? "";
            txtMuc.Text = row.Cells["Muc"].Value?.ToString() ?? "";

            if (decimal.TryParse(row.Cells["TienNhuanbut"].Value?.ToString(), out decimal tien))
                txtSoTien.Text = Math.Round(tien, 0).ToString();

            cboButDanh.Text = row.Cells["Butdanh"].Value?.ToString() ?? "";
            btnLuu.Enabled = false;
        }

        // ====================================================================
        // PHẦN 4: NGHIỆP VỤ DUYỆT / CHỐT SỔ TÒA SOẠN
        // ====================================================================
        private void btnChotSo_Click(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null) return;

            DialogResult dr = MessageBox.Show(
                "Xác nhận Ký duyệt Tờ Nhuận Bút này đã HOÀN CHỈNH?\n\n" +
                "Lưu ý: Sau khi bấm chốt, Số Báo này sẽ bị KHÓA MÃI MÃI, không thể sửa hay nhập thêm tiền, và được tự động chuyển sang Kế Toán lập phiếu chi.",
                "Xác nhận Duyệt Số Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dr == DialogResult.Yes)
            {
                string query = "UPDATE Bao SET DaDuyet = 'Y' WHERE Maso = @id";
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { cboSoBao.SelectedValue });

                MessageBox.Show("Đã chốt sổ thành công! Hồ sơ đã được chuyển tiếp.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachSoBao();
                btnThem_Click(sender, e);
            }
        }

    }
}