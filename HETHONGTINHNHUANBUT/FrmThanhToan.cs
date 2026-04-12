using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmThanhToan : Form
    {
        bool isAddNew = false;
        private readonly IMongoCollection<ThanhToan> _thanhToanColl;

        public FrmThanhToan()
        {
            InitializeComponent();
            _thanhToanColl = MongoProvider.Instance.GetCollection<ThanhToan>("ThanhToan");
        }

        private async void FrmThanhToan_Load(object sender, EventArgs e)
        {
            cboLoaiBao.Items.AddRange(new string[] { "NG", "KH" });
            cboVung.Items.AddRange(new string[] { "HCM", "HN", "DN" });
            cboLoaiTT.Items.AddRange(new string[] { "CT", "LE" });
            cboHinhThuc.Items.AddRange(new string[] { "TM", "CK" });

            btnLuu.Enabled = false;

            // Nếu đồng chí chưa tạo nút btnDuyet trên giao diện thì tạm comment dòng dưới lại nhé
            btnDuyet.Enabled = false;

            // Fix Font VNI theo đúng ý đồng chí
            Font vniFont = new Font("VNI-Times", 10.2F);
            dgvThanhToan.DefaultCellStyle.Font = vniFont;
            dgvThanhToan.RowsDefaultCellStyle.Font = vniFont;
            dgvThanhToan.AlternatingRowsDefaultCellStyle.Font = vniFont;
            dgvThanhToan.ThemeStyle.RowsStyle.Font = vniFont;
            dgvThanhToan.ThemeStyle.AlternatingRowsStyle.Font = vniFont;

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                // Lấy dữ liệu và sắp xếp theo Mã số giảm dần
                var list = await _thanhToanColl.Find(_ => true).SortByDescending(t => t.Maso).ToListAsync();
                dgvThanhToan.DataSource = list;

                // Ẩn cột Id của MongoDB đi cho đẹp lưới
                if (dgvThanhToan.Columns["Id"] != null)
                {
                    dgvThanhToan.Columns["Id"].Visible = false;
                }
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

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                decimal sotien = string.IsNullOrEmpty(txtSoTien.Text) ? 0 : Convert.ToDecimal(txtSoTien.Text);

                if (isAddNew)
                {
                    // Tìm Mã số lớn nhất hiện tại để tự động tăng (thay thế cho SELECT MAX trong SQL)
                    var maxDoc = await _thanhToanColl.Find(_ => true).SortByDescending(t => t.Maso).FirstOrDefaultAsync();
                    int newMaso = (maxDoc != null) ? maxDoc.Maso + 1 : 1001; // Bắt đầu từ 1001 nếu chưa có gì

                    var ttMoi = new ThanhToan
                    {
                        Maso = newMaso,
                        Tengoi = txtTenGoi.Text.Trim(),
                        Ngay = dtpNgay.Value,
                        Tungay = dtpTuNgay.Value,
                        Denngay = dtpDenNgay.Value,
                        Loaibao = cboLoaiBao.Text,
                        Sotien = sotien,
                        Vung = cboVung.Text,
                        LoaiTT = cboLoaiTT.Text,
                        Khoaso = "N", // Mặc định là chưa khóa
                        hinhthucTT = cboHinhThuc.Text
                    };

                    await _thanhToanColl.InsertOneAsync(ttMoi);
                    MessageBox.Show("Khởi tạo đợt chi trả thành công!", "Thông báo");
                }
                else
                {
                    // Cập nhật dữ liệu
                    int maSo = Convert.ToInt32(txtMaso.Text);
                    var filter = Builders<ThanhToan>.Filter.Eq(t => t.Maso, maSo);

                    var updateDef = Builders<ThanhToan>.Update
                        .Set(t => t.Tengoi, txtTenGoi.Text.Trim())
                        .Set(t => t.Ngay, dtpNgay.Value)
                        .Set(t => t.Tungay, dtpTuNgay.Value)
                        .Set(t => t.Denngay, dtpDenNgay.Value)
                        .Set(t => t.Loaibao, cboLoaiBao.Text)
                        .Set(t => t.Sotien, sotien)
                        .Set(t => t.Vung, cboVung.Text)
                        .Set(t => t.LoaiTT, cboLoaiTT.Text)
                        .Set(t => t.hinhthucTT, cboHinhThuc.Text);

                    await _thanhToanColl.UpdateOneAsync(filter, updateDef);
                    MessageBox.Show("Cập nhật đợt chi trả thành công!", "Thông báo");
                }

                await LoadDataAsync();
                btnHuy_Click(sender, e);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi Database"); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa đợt chi trả này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int maSo = Convert.ToInt32(txtMaso.Text);
                await _thanhToanColl.DeleteOneAsync(t => t.Maso == maSo);

                await LoadDataAsync();
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

        private async void btnDuyet_Click(object sender, EventArgs e)
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
                    int maSo = Convert.ToInt32(txtMaso.Text);
                    var filter = Builders<ThanhToan>.Filter.Eq(t => t.Maso, maSo);
                    var updateDef = Builders<ThanhToan>.Update.Set(t => t.Khoaso, "Y"); // Chốt sổ

                    await _thanhToanColl.UpdateOneAsync(filter, updateDef);

                    MessageBox.Show("Đã Ký Duyệt thành công! Đợt chi trả đã được chốt sổ.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await LoadDataAsync();
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