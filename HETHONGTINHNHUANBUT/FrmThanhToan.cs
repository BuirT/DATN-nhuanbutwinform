using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmThanhToan : Form
    {
        bool isAddNew = false;
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmThanhToan()
        {
            InitializeComponent();
        }

        private async void FrmThanhToan_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvThanhToan);
            cboLoaiBao.Items.AddRange(new string[] { "NG", "KH" });
            cboVung.Items.AddRange(new string[] { "HCM", "HN", "DN" });
            cboLoaiTT.Items.AddRange(new string[] { "CT", "LE" });
            cboHinhThuc.Items.AddRange(new string[] { "TM", "CK" });
            foreach (var cbo in new Guna.UI2.WinForms.Guna2ComboBox[] { cboLoaiBao, cboVung, cboLoaiTT, cboHinhThuc })
            {
                cbo.DropDownHeight = 200;
                cbo.IntegralHeight = true;
                cbo.MaxDropDownItems = 15;
            }

            btnLuu.Enabled = false;
            btnDuyet.Enabled = false;

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT * FROM ThanhToan ORDER BY Maso DESC";
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            await Task.Run(() => da.Fill(dt));
                        }
                    }
                    dgvThanhToan.DataSource = dt;
                }

                if (dgvThanhToan.Columns.Count > 0)
                {
                    dgvThanhToan.Columns["Maso"].HeaderText = "Mã đợt";
                    dgvThanhToan.Columns["Maso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvThanhToan.Columns["Tengoi"].HeaderText = "Tên đợt thanh toán";
                    dgvThanhToan.Columns["Tengoi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvThanhToan.Columns["Ngay"].HeaderText = "Ngày lập";
                    dgvThanhToan.Columns["Ngay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvThanhToan.Columns["Tungay"].HeaderText = "Từ ngày";
                    dgvThanhToan.Columns["Tungay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvThanhToan.Columns["Denngay"].HeaderText = "Đến ngày";
                    dgvThanhToan.Columns["Denngay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvThanhToan.Columns["Sotien"].HeaderText = "Tổng tiền (VNĐ)";
                    dgvThanhToan.Columns["Sotien"].DefaultCellStyle.Format = "N0";
                    dgvThanhToan.Columns["Sotien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvThanhToan.Columns["Khoaso"].HeaderText = "Đã duyệt";
                    dgvThanhToan.Columns["Khoaso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddNew = true;
            btnLuu.Enabled = true;
            btnDuyet.Enabled = false;

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
                MessageBox.Show("Vui lòng chọn đợt chi trả cần sửa từ bảng!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAddNew = false;
            btnLuu.Enabled = true;
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenGoi.Text))
            {
                MessageBox.Show("Đồng chí quên nhập tên đợt thanh toán rồi kìa!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal sotien = string.IsNullOrEmpty(txtSoTien.Text) ? 0 : Convert.ToDecimal(txtSoTien.Text);

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    if (isAddNew)
                    {
                        int newMaso = 1001;
                        string sqlGetMax = "SELECT ISNULL(MAX(Maso), 1000) + 1 FROM ThanhToan";
                        using (SqlCommand cmdMax = new SqlCommand(sqlGetMax, conn))
                        {
                            newMaso = Convert.ToInt32(await cmdMax.ExecuteScalarAsync());
                        }

                        string sqlInsert = @"INSERT INTO ThanhToan (Maso, Tengoi, Ngay, Tungay, Denngay, Loaibao, Sotien, Vung, LoaiTT, hinhthucTT, Khoaso) 
                                             VALUES (@ma, @ten, @ngay, @tu, @den, @loaibao, @tien, @vung, @loaitt, @ht, 'N')";
                        using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", newMaso);
                            cmd.Parameters.AddWithValue("@ten", txtTenGoi.Text.Trim());
                            cmd.Parameters.AddWithValue("@ngay", dtpNgay.Value);
                            cmd.Parameters.AddWithValue("@tu", dtpTuNgay.Value);
                            cmd.Parameters.AddWithValue("@den", dtpDenNgay.Value);
                            cmd.Parameters.AddWithValue("@loaibao", cboLoaiBao.Text);
                            cmd.Parameters.AddWithValue("@tien", sotien);
                            cmd.Parameters.AddWithValue("@vung", cboVung.Text);
                            cmd.Parameters.AddWithValue("@loaitt", cboLoaiTT.Text);
                            cmd.Parameters.AddWithValue("@ht", cboHinhThuc.Text);
                            await cmd.ExecuteNonQueryAsync();
                        }
                        MessageBox.Show("Khởi tạo đợt chi trả thành công!", "Hoàn tất");
                    }
                    else
                    {
                        string sqlUpdate = @"UPDATE ThanhToan SET 
                                             Tengoi = @ten, Ngay = @ngay, Tungay = @tu, Denngay = @den, 
                                             Loaibao = @loaibao, Sotien = @tien, Vung = @vung, 
                                             LoaiTT = @loaitt, hinhthucTT = @ht 
                                             WHERE Maso = @ma";
                        using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", Convert.ToInt32(txtMaso.Text));
                            cmd.Parameters.AddWithValue("@ten", txtTenGoi.Text.Trim());
                            cmd.Parameters.AddWithValue("@ngay", dtpNgay.Value);
                            cmd.Parameters.AddWithValue("@tu", dtpTuNgay.Value);
                            cmd.Parameters.AddWithValue("@den", dtpDenNgay.Value);
                            cmd.Parameters.AddWithValue("@loaibao", cboLoaiBao.Text);
                            cmd.Parameters.AddWithValue("@tien", sotien);
                            cmd.Parameters.AddWithValue("@vung", cboVung.Text);
                            cmd.Parameters.AddWithValue("@loaitt", cboLoaiTT.Text);
                            cmd.Parameters.AddWithValue("@ht", cboHinhThuc.Text);
                            await cmd.ExecuteNonQueryAsync();
                        }
                        MessageBox.Show("Cập nhật đợt chi trả thành công!", "Hoàn tất");
                    }
                }

                await LoadDataAsync();
                btnHuy_Click(sender, e);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi SQL"); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text)) return;

            if (MessageBox.Show("Đồng chí có chắc muốn xóa đợt chi trả này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();
                        string sqlDelete = "DELETE FROM ThanhToan WHERE Maso = @ma";
                        using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", Convert.ToInt32(txtMaso.Text));
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await LoadDataAsync();
                    btnHuy_Click(sender, e);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message); }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaso.Clear(); txtTenGoi.Clear(); txtSoTien.Text = "0";
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

            string trangThaiKhoa = row.Cells["Khoaso"].Value?.ToString() ?? "N";
            if (trangThaiKhoa.Trim().ToUpper() == "Y")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnDuyet.Enabled = false;
                MessageBox.Show("Đợt chi trả này đã được KÝ DUYỆT nên không thể chỉnh sửa nữa nhé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnDuyet.Enabled = true;
            }
        }

        private async void btnDuyet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaso.Text))
            {
                MessageBox.Show("Vui lòng chọn đợt chi trả cần ký duyệt!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Đồng chí có chắc chắn muốn KÝ DUYỆT đợt chi trả này?\n\nSau khi Ký duyệt, dữ liệu sẽ chốt cứng và KHÔNG THỂ CHỈNH SỬA!",
                "Xác nhận Ký Duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();
                        string sqlDuyet = "UPDATE ThanhToan SET Khoaso = 'Y' WHERE Maso = @ma";
                        using (SqlCommand cmd = new SqlCommand(sqlDuyet, conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", Convert.ToInt32(txtMaso.Text));
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    MessageBox.Show("Đã Ký Duyệt thành công! Đợt chi trả đã được chốt sổ.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await LoadDataAsync();
                    btnHuy_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi ký duyệt: " + ex.Message, "Lỗi SQL");
                }
            }
        }
    }
}