using HETHONGTINHNHUANBUT.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmThanhToan : Form
    {
        bool isAddNew = false;

        public FrmThanhToan()
        {
            InitializeComponent();
        }

        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            cboLoaiBao.Items.AddRange(new string[] { "NG", "KH" });
            cboVung.Items.AddRange(new string[] { "HCM", "HN", "DN" });
            cboLoaiTT.Items.AddRange(new string[] { "CT", "LE" });
            cboHinhThuc.Items.AddRange(new string[] { "TM", "CK" });

            LoadData();
            btnLuu.Enabled = false;

            // Nếu đồng chí chưa tạo nút btnDuyet trên giao diện thì tạm comment dòng dưới lại nhé
            btnDuyet.Enabled = false;

            // Fix Font VNI
            Font vniFont = new Font("VNI-Times", 10.2F);
            dgvThanhToan.DefaultCellStyle.Font = vniFont;
            dgvThanhToan.RowsDefaultCellStyle.Font = vniFont;
            dgvThanhToan.AlternatingRowsDefaultCellStyle.Font = vniFont;
            dgvThanhToan.ThemeStyle.RowsStyle.Font = vniFont;
            dgvThanhToan.ThemeStyle.AlternatingRowsStyle.Font = vniFont;
        }

        void LoadData()
        {
            try
            {
                string sql = "SELECT Maso, Tengoi, Ngay, Tungay, Denngay, Loaibao, Sotien, Vung, LoaiTT, Khoaso, hinhthucTT FROM ThanhToan ORDER BY Maso DESC";
                dgvThanhToan.DataSource = MongoProvider.Instance.ExecuteQuery(sql);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddNew = true;
            btnLuu.Enabled = true;
            btnDuyet.Enabled = false; // Đang thêm mới thì không cho duyệt

            txtMaso.Clear();
            txtTenGoi.Clear();
            txtSoTien.Text = "0";

            if (cboLoaiBao.Items.Count > 0) cboLoaiBao.SelectedIndex = 0;
            if (cboVung.Items.Count > 0) cboVung.SelectedIndex = 0;
            if (cboLoaiTT.Items.Count > 0) cboLoaiTT.SelectedIndex = 0;
            if (cboHinhThuc.Items.Count > 0) cboHinhThuc.SelectedIndex = 0;

            txtTenGoi.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text))
            {
                MessageBox.Show("Vui lòng chọn đợt chi trả cần sửa từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAddNew = false;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                decimal sotien = string.IsNullOrEmpty(txtSoTien.Text) ? 0 : Convert.ToDecimal(txtSoTien.Text);

                if (isAddNew)
                {
                    string query = @"
                        DECLARE @newID INT;
                        SELECT @newID = ISNULL(MAX(Maso), 1000) + 1 FROM ThanhToan;
                        INSERT INTO ThanhToan (Maso, Tengoi, Ngay, Tungay, Denngay, Loaibao, Sotien, Vung, LoaiTT, Khoaso, hinhthucTT) 
                        VALUES (@newID, @ten, @ngay, @tu, @den, @loaibao, @tien, @vung, @loaitt, 'N', @hinhthuc)";

                    object[] para = new object[] {
                        txtTenGoi.Text, dtpNgay.Value, dtpTuNgay.Value, dtpDenNgay.Value,
                        cboLoaiBao.Text, sotien, cboVung.Text, cboLoaiTT.Text, cboHinhThuc.Text
                    };
                    MongoProvider.Instance.ExecuteNonQuery(query, para);
                    MessageBox.Show("Khởi tạo đợt chi trả thành công!", "Thông báo");
                }
                else
                {
                    string query = @"UPDATE ThanhToan SET Tengoi=@ten, Ngay=@ngay, Tungay=@tu, Denngay=@den, 
                                     Loaibao=@loaibao, Sotien=@tien, Vung=@vung, LoaiTT=@loaitt, hinhthucTT=@hinhthuc 
                                     WHERE Maso=@maso";
                    object[] para = new object[] {
                        txtTenGoi.Text, dtpNgay.Value, dtpTuNgay.Value, dtpDenNgay.Value,
                        cboLoaiBao.Text, sotien, cboVung.Text, cboLoaiTT.Text, cboHinhThuc.Text, Convert.ToInt32(txtMaso.Text)
                    };
                    MongoProvider.Instance.ExecuteNonQuery(query, para);
                    MessageBox.Show("Cập nhật đợt chi trả thành công!", "Thông báo");
                }

                LoadData();
                btnHuy_Click(sender, e);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi Database"); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa đợt chi trả này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "DELETE FROM ThanhToan WHERE Maso = @maso";
                MongoProvider.Instance.ExecuteNonQuery(sql, new object[] { Convert.ToInt32(txtMaso.Text) });
                LoadData();
                btnHuy_Click(sender, e);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaso.Clear(); txtTenGoi.Clear(); txtSoTien.Clear();
            btnLuu.Enabled = false;
            btnDuyet.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // --- CẬP NHẬT LOGIC: KIỂM TRA TRẠNG THÁI KHOASO KHI CLICK VÀO LƯỚI ---
        private void dgvThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvThanhToan.CurrentRow == null || e.RowIndex < 0) return;

            DataGridViewRow row = dgvThanhToan.Rows[e.RowIndex];
            txtMaso.Text = row.Cells["Maso"].Value?.ToString() ?? "";
            txtTenGoi.Text = row.Cells["Tengoi"].Value?.ToString() ?? "";

            if (DateTime.TryParse(row.Cells["Ngay"].Value?.ToString(), out DateTime ngay)) dtpNgay.Value = ngay;
            if (DateTime.TryParse(row.Cells["Tungay"].Value?.ToString(), out DateTime tu)) dtpTuNgay.Value = tu;
            if (DateTime.TryParse(row.Cells["Denngay"].Value?.ToString(), out DateTime den)) dtpDenNgay.Value = den;

            cboLoaiBao.Text = row.Cells["Loaibao"].Value?.ToString() ?? "";
            cboVung.Text = row.Cells["Vung"].Value?.ToString() ?? "";
            cboLoaiTT.Text = row.Cells["LoaiTT"].Value?.ToString() ?? "";
            cboHinhThuc.Text = row.Cells["hinhthucTT"].Value?.ToString() ?? "";

            if (decimal.TryParse(row.Cells["Sotien"].Value?.ToString(), out decimal sotien))
                txtSoTien.Text = Math.Round(sotien, 0).ToString();

            btnLuu.Enabled = false;

            // KIỂM TRA QUYỀN TRƯỢNG: Nếu đã duyệt (Khoaso = 'Y') thì khóa hết nút sửa/xóa
            string trangThaiKhoa = row.Cells["Khoaso"].Value?.ToString() ?? "N";
            if (trangThaiKhoa.Trim().ToUpper() == "Y")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnDuyet.Enabled = false; // Đã duyệt rồi thì ẩn/khóa luôn nút duyệt
                MessageBox.Show("Đợt chi trả này ĐÃ ĐƯỢC KÝ DUYỆT, không thể chỉnh sửa!", "Khóa số liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnDuyet.Enabled = true; // Hiện nút duyệt lên cho lãnh đạo bấm
            }
        }

        // --- HÀM MỚI DÀNH CHO LÃNH ĐẠO ---
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text))
            {
                MessageBox.Show("Vui lòng chọn đợt chi trả cần ký duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Đồng chí có chắc chắn muốn KÝ DUYỆT đợt chi trả này?\n\nLƯU Ý: Sau khi Ký duyệt, dữ liệu sẽ được chuyển sang kế toán và KHÔNG THỂ CHỈNH SỬA!",
                "Xác nhận Ký Duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    // Chuyển trường Khoaso thành 'Y'
                    string query = "UPDATE ThanhToan SET Khoaso = 'Y' WHERE Maso = @maso";
                    MongoProvider.Instance.ExecuteNonQuery(query, new object[] { Convert.ToInt32(txtMaso.Text) });

                    MessageBox.Show("Đã Ký Duyệt thành công! Đợt chi trả đã được chốt sổ.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    btnHuy_Click(sender, e); // Reset UI
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi ký duyệt: " + ex.Message, "Lỗi Database");
                }
            }
        }
    }
}