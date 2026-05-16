using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTacGia : Form
    {
        private readonly string sqlConnectionString = @"Server=LAPTOP-5O9OTMIJ\SQLEXPRESS;Database=TN;Trusted_Connection=True;";

        private string currentImagePath = "";
        private string currentPdfPath = "";

        public string QuyenHienTai { get; set; }

        public FrmTacGia()
        {
            InitializeComponent();
            txtDienThoai.KeyPress += txtDienThoai_KeyPress;

            // Kích hoạt siêu đệm kép phần cứng cho riêng bảng tác giả chống lag tuyệt đối
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvTacGia, true, null);
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return true;
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private async void FrmTacGia_Load(object sender, EventArgs e)
        {
            if (cboPhanLoai.Items.Count > 0) cboPhanLoai.SelectedIndex = 0;

            await TuDongFixDatabaseSQL();
            FormatGiaoDienBangTacGia();
            await LoadDataSQLAsync();
            PhanQuyenThaoTac();
        }

        private void FormatGiaoDienBangTacGia()
        {
            // Thiết lập phong cách Header phẳng nhã nhặn như Flowty Web UI
            dgvTacGia.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvTacGia.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvTacGia.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTacGia.EnableHeadersVisualStyles = false;

            // Màu dòng mặc định tĩnh lặng
            dgvTacGia.DefaultCellStyle.BackColor = Color.White;
            dgvTacGia.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvTacGia.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvTacGia.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);

            // CẤU HÌNH MÀU CHỌN DÒNG FLOWTY: Xanh dương nhạt dịu mắt, chữ tối đen Slate rõ nét, hết nhảy màu bậy bạ
            Color selectedBg = Color.FromArgb(232, 240, 254);
            Color selectedFg = Color.FromArgb(15, 23, 42);

            dgvTacGia.DefaultCellStyle.SelectionBackColor = selectedBg;
            dgvTacGia.DefaultCellStyle.SelectionForeColor = selectedFg;
            dgvTacGia.AlternatingRowsDefaultCellStyle.SelectionBackColor = selectedBg;
            dgvTacGia.AlternatingRowsDefaultCellStyle.SelectionForeColor = selectedFg;

            dgvTacGia.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvTacGia.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvTacGia.ThemeStyle.RowsStyle.SelectionBackColor = selectedBg;
            dgvTacGia.ThemeStyle.RowsStyle.SelectionForeColor = selectedFg;

            dgvTacGia.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvTacGia.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvTacGia.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = selectedBg;
            dgvTacGia.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = selectedFg;

            dgvTacGia.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvTacGia.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(71, 85, 105);

            dgvTacGia.RowTemplate.Height = 38;
        }

        private async Task TuDongFixDatabaseSQL()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sqlUpgrade = @"
                        ALTER TABLE TacGia ALTER COLUMN LoaiTacgia NVARCHAR(100);
                        IF COL_LENGTH('TacGia', 'NganHang') IS NULL ALTER TABLE TacGia ADD NganHang NVARCHAR(200);
                        IF COL_LENGTH('TacGia', 'PhongBan') IS NULL ALTER TABLE TacGia ADD PhongBan NVARCHAR(200);
                        IF COL_LENGTH('TacGia', 'SoTaiKhoan') IS NULL ALTER TABLE TacGia ADD SoTaiKhoan NVARCHAR(50);
                        IF COL_LENGTH('TacGia', 'AvatarPath') IS NULL ALTER TABLE TacGia ADD AvatarPath NVARCHAR(MAX);
                        IF COL_LENGTH('TacGia', 'PdfPath') IS NULL ALTER TABLE TacGia ADD PdfPath NVARCHAR(MAX);
                        UPDATE TacGia SET NganHang = Diachi WHERE (NganHang IS NULL OR NganHang = '') AND Diachi IS NOT NULL;
                        UPDATE TacGia SET SoTaiKhoan = Ddong WHERE (SoTaiKhoan IS NULL OR SoTaiKhoan = '') AND Ddong IS NOT NULL;
                    ";
                    using (SqlCommand cmd = new SqlCommand(sqlUpgrade, conn)) { await cmd.ExecuteNonQueryAsync(); }
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi Fix DB: " + ex.Message); }
        }

        private void PhanQuyenThaoTac()
        {
            bool coQuyen = !(QuyenHienTai == "Lãnh đạo" || QuyenHienTai == "Kế toán");
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnChonAnh.Enabled = btnChonPDF.Enabled = coQuyen;
        }

        private async Task LoadDataSQLAsync(string keyword = "")
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT Maso AS MaHT, MsTG AS MaThe, Hoten AS HoTen, 
                                            Ngaysinh AS NgaySinh, LoaiTacgia AS PhanLoai, 
                                            Email, Dienthoai AS DienThoai, 
                                            SoTaiKhoan, PhongBan, NganHang, 
                                            AvatarPath, PdfPath FROM TacGia";

                    if (!string.IsNullOrWhiteSpace(keyword))
                        query += " WHERE Maso LIKE @kw OR Hoten LIKE @kw OR MsTG LIKE @kw OR SoTaiKhoan LIKE @kw OR Dienthoai LIKE @kw";

                    query += " ORDER BY Maso DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(keyword)) cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync()) { dt.Load(reader); }
                    }
                }
                dgvTacGia.DataSource = dt;

                string[] hideCols = { "AvatarPath", "PdfPath", "NganHang" };
                foreach (var col in hideCols) if (dgvTacGia.Columns[col] != null) dgvTacGia.Columns[col].Visible = false;

                if (dgvTacGia.Columns.Count > 0)
                {
                    dgvTacGia.Columns["MaHT"].HeaderText = "MÃ HT";
                    dgvTacGia.Columns["HoTen"].HeaderText = "HỌ VÀ TÊN";
                    dgvTacGia.Columns["NgaySinh"].HeaderText = "NGÀY SINH";
                    dgvTacGia.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvTacGia.Columns["MaThe"].HeaderText = "CCCD/CMND";
                    dgvTacGia.Columns["SoTaiKhoan"].HeaderText = "SỐ TÀI KHOẢN";
                }

                // ÉP TRỰC TIẾP MÀU CHỌN CHO CÁC CỘT RUNTIME: Giữ màu xanh nhạt pastel dịu mắt khi click chọn dòng
                foreach (DataGridViewColumn col in dgvTacGia.Columns)
                {
                    col.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
                    col.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
                }

                dgvTacGia.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lấy dữ liệu SQL: " + ex.Message); }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e) => await LoadDataSQLAsync(txtTimKiem.Text);

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHT.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text)) { MessageBox.Show("Vui lòng điền đủ Mã HT và Họ tên!"); return; }
            if (!IsValidPhone(txtDienThoai.Text.Trim())) { MessageBox.Show("Số điện thoại phải đủ 10 số!"); return; }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"INSERT INTO TacGia (Maso, MsTG, Hoten, Ngaysinh, LoaiTacgia, Email, Dienthoai, SoTaiKhoan, PhongBan, NganHang, AvatarPath, PdfPath) 
                                   VALUES (@ma, @the, @ten, @ns, @loai, @mail, @sdt, @stk, @pb, @nh, @anh, @pdf)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", txtMaHT.Text.Trim());
                        cmd.Parameters.AddWithValue("@the", txtMaThe.Text.Trim());
                        cmd.Parameters.AddWithValue("@ten", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@ns", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@loai", cboPhanLoai.Text);
                        cmd.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@sdt", txtDienThoai.Text.Trim());
                        cmd.Parameters.AddWithValue("@stk", txtSoTaiKhoan.Text.Trim());
                        cmd.Parameters.AddWithValue("@pb", txtPhongBan.Text.Trim());
                        cmd.Parameters.AddWithValue("@nh", txtNganHang.Text.Trim());
                        cmd.Parameters.AddWithValue("@anh", currentImagePath);
                        cmd.Parameters.AddWithValue("@pdf", currentPdfPath);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Thêm hồ sơ thành công vào SQL Server!");
                await LoadDataSQLAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow == null) { MessageBox.Show("Vui lòng chọn một dòng tác giả dưới bảng trước!"); return; }
            string maHT = dgvTacGia.CurrentRow.Cells["MaHT"].Value.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"UPDATE TacGia SET MsTG=@the, Hoten=@ten, Ngaysinh=@ns, LoaiTacgia=@loai, 
                                   Email=@mail, Dienthoai=@sdt, SoTaiKhoan=@stk, PhongBan=@pb, NganHang=@nh, 
                                   AvatarPath=@anh, PdfPath=@pdf WHERE Maso=@ma";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maHT);
                        cmd.Parameters.AddWithValue("@the", txtMaThe.Text.Trim());
                        cmd.Parameters.AddWithValue("@ten", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@ns", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@loai", cboPhanLoai.Text);
                        cmd.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@sdt", txtDienThoai.Text.Trim());
                        cmd.Parameters.AddWithValue("@stk", txtSoTaiKhoan.Text.Trim());
                        cmd.Parameters.AddWithValue("@pb", txtPhongBan.Text.Trim());
                        cmd.Parameters.AddWithValue("@nh", txtNganHang.Text.Trim());
                        cmd.Parameters.AddWithValue("@anh", currentImagePath);
                        cmd.Parameters.AddWithValue("@pdf", currentPdfPath);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Cập nhật thông tin thành công!");
                await LoadDataSQLAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow == null) { MessageBox.Show("Vui lòng chọn hồ sơ tác giả cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa hồ sơ này khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM TacGia WHERE Maso=@ma", conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", dgvTacGia.CurrentRow.Cells["MaHT"].Value.ToString());
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                await LoadDataSQLAsync();
                btnLamMoi_Click(null, null);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHT.Clear(); txtMaThe.Clear(); txtHoTen.Clear(); txtEmail.Clear();
            txtPhongBan.Clear(); txtSoTaiKhoan.Clear(); txtNganHang.Clear(); txtDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Now; picAvatar.Image = null;
            currentImagePath = ""; currentPdfPath = "";
            lblFilePDF.Text = "Chưa có file..."; lblFilePDF.ForeColor = Color.Gray; btnXemPDF.Enabled = false;
            txtMaHT.Focus();
        }

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTacGia.Rows[e.RowIndex];
                txtMaHT.Text = row.Cells["MaHT"].Value?.ToString();
                txtMaThe.Text = row.Cells["MaThe"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                cboPhanLoai.Text = row.Cells["PhanLoai"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString();
                txtPhongBan.Text = row.Cells["PhongBan"].Value?.ToString();
                txtSoTaiKhoan.Text = row.Cells["SoTaiKhoan"].Value?.ToString();
                txtNganHang.Text = row.Cells["NganHang"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime dt)) dtpNgaySinh.Value = dt;

                currentImagePath = row.Cells["AvatarPath"].Value?.ToString();
                currentPdfPath = row.Cells["PdfPath"].Value?.ToString();

                if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath)) picAvatar.Image = Image.FromFile(currentImagePath);
                else picAvatar.Image = null;

                if (!string.IsNullOrEmpty(currentPdfPath) && File.Exists(currentPdfPath))
                {
                    lblFilePDF.Text = "Đã đính kèm: " + Path.GetFileName(currentPdfPath);
                    lblFilePDF.ForeColor = Color.Green; btnXemPDF.Enabled = true;
                }
                else { lblFilePDF.Text = "Chưa có file..."; lblFilePDF.ForeColor = Color.Gray; btnXemPDF.Enabled = false; }
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Images|*.jpg;*.png" })
            {
                if (ofd.ShowDialog() == DialogResult.OK) { currentImagePath = ofd.FileName; picAvatar.Image = Image.FromFile(ofd.FileName); }
            }
        }

        private void btnChonPDF_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "PDF|*.pdf" })
            {
                if (ofd.ShowDialog() == DialogResult.OK) { currentPdfPath = ofd.FileName; lblFilePDF.Text = Path.GetFileName(ofd.FileName); lblFilePDF.ForeColor = Color.Green; btnXemPDF.Enabled = true; }
            }
        }

        private void btnXemPDF_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentPdfPath)) Process.Start(new ProcessStartInfo(currentPdfPath) { UseShellExecute = true });
            else MessageBox.Show("Không tìm thấy file PDF!");
        }

        private void lblMaHT_Click(object sender, EventArgs e) { }
        private void txtDienThoai_TextChanged(object sender, EventArgs e) { }
    }
}