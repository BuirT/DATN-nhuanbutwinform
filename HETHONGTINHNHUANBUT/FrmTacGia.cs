using DocumentFormat.OpenXml.Office2010.Drawing;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTacGia : Form
    {
        // --- CHUỖI KẾT NỐI: Tự động nhận diện SQLEXPRESS trên máy sếp ---
        private readonly string sqlConnectionString = @"Server=LAPTOP-K8EKOOUM\SQLEXPRESS;Database=TN;Trusted_Connection=True;";

        private string currentImagePath = "";
        private string currentPdfPath = "";

        // =======================================================
        // BIẾN LƯU QUYỀN ĐƯỢC FrmTrangChinh TRUYỀN SANG (KHÔNG ĐƯỢC XÓA)
        public string QuyenHienTai { get; set; }
        // =======================================================

        public FrmTacGia()
        {
            InitializeComponent();
            // Gán sự kiện chặn nhập chữ ngay từ lúc khởi tạo
            txtDienThoai.KeyPress += txtDienThoai_KeyPress;
        }

        // Kiểm tra định dạng 10 chữ số
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return true;
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        // Chặn nhập ký tự không phải là số
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
        }

        private async void FrmTacGia_Load(object sender, EventArgs e)
        {
            if (cboPhanLoai.Items.Count > 0) cboPhanLoai.SelectedIndex = 0;

            // 1. Tự động sửa lỗi và nâng cấp cấu trúc SQL (Nới rộng cột, thêm cột thiếu)
            await TuDongFixDatabaseSQL();

            // 2. Làm đẹp bảng dữ liệu
            FormatGiaoDienBangTacGia();

            // 3. Load dữ liệu từ SQL (Sạch bóng MongoDB)
            await LoadDataSQLAsync();

            // 4. Khóa nút theo quyền
            PhanQuyenThaoTac();
        }

        private void FormatGiaoDienBangTacGia()
        {
            // Màu sắc Header chuyên nghiệp như Dashboard
            dgvTacGia.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvTacGia.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTacGia.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTacGia.EnableHeadersVisualStyles = false;

            // Màu dòng và hiệu ứng chọn
            dgvTacGia.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 245, 250);
            dgvTacGia.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvTacGia.DefaultCellStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvTacGia.RowTemplate.Height = 40;
        }

        // =======================================================
        // TỰ ĐỘNG NÂNG CẤP SQL SERVER (TRỊ DỨT ĐIỂM LỖI CỘT)
        // =======================================================
        private async Task TuDongFixDatabaseSQL()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    // Nới rộng cột Phân loại (chống lỗi Truncated) và thêm các cột bị thiếu trong SQL gốc
                    string sqlUpgrade = @"
                        -- 1. Nới rộng cột Phân loại để lưu được chữ 'Phóng viên'
                        ALTER TABLE TacGia ALTER COLUMN LoaiTacgia NVARCHAR(100);

                        -- 2. Thêm các cột phục vụ tính năng mới nếu chưa có
                        IF COL_LENGTH('TacGia', 'NganHang') IS NULL ALTER TABLE TacGia ADD NganHang NVARCHAR(200);
                        IF COL_LENGTH('TacGia', 'PhongBan') IS NULL ALTER TABLE TacGia ADD PhongBan NVARCHAR(200);
                        IF COL_LENGTH('TacGia', 'SoTaiKhoan') IS NULL ALTER TABLE TacGia ADD SoTaiKhoan NVARCHAR(50);
                        IF COL_LENGTH('TacGia', 'AvatarPath') IS NULL ALTER TABLE TacGia ADD AvatarPath NVARCHAR(MAX);
                        IF COL_LENGTH('TacGia', 'PdfPath') IS NULL ALTER TABLE TacGia ADD PdfPath NVARCHAR(MAX);
                        
                        -- 3. Chuyển dữ liệu cũ sang nhà mới cho chuẩn hóa
                        UPDATE TacGia SET NganHang = Diachi WHERE (NganHang IS NULL OR NganHang = '') AND Diachi IS NOT NULL;
                        UPDATE TacGia SET SoTaiKhoan = Ddong WHERE (SoTaiKhoan IS NULL OR SoTaiKhoan = '') AND Ddong IS NOT NULL;
                    ";

                    using (SqlCommand cmd = new SqlCommand(sqlUpgrade, conn)) { await cmd.ExecuteNonQueryAsync(); }
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi Fix DB: " + ex.Message); }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PhanQuyenThaoTac()
        {
            bool coQuyen = !(QuyenHienTai == "Lãnh đạo" || QuyenHienTai == "Kế toán");
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnChonAnh.Enabled = btnChonPDF.Enabled = coQuyen;
        }

        // =======================================================
        // LOAD DỮ LIỆU TỪ SQL SERVER (HIỆN PV1000, PV1001...)
        // =======================================================
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

                // Ẩn các cột chứa đường dẫn kỹ thuật
                string[] hideCols = { "AvatarPath", "PdfPath", "NganHang" };
                foreach (var col in hideCols) if (dgvTacGia.Columns[col] != null) dgvTacGia.Columns[col].Visible = false;

                if (dgvTacGia.Columns.Count > 0)
                {
                    dgvTacGia.Columns["MaHT"].HeaderText = "MÃ HT";
                    dgvTacGia.Columns["HoTen"].HeaderText = "HỌ VÀ TÊN";
                    dgvTacGia.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvTacGia.Columns["NgaySinh"].HeaderText = "NGÀY SINH";
                    dgvTacGia.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvTacGia.Columns["MaThe"].HeaderText = "CCCD/CMND";
                    dgvTacGia.Columns["SoTaiKhoan"].HeaderText = "SỐ TÀI KHOẢN";
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
        private void btnXemPDF_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentPdfPath) && File.Exists(currentPdfPath))
                Process.Start(new ProcessStartInfo(currentPdfPath) { UseShellExecute = true });
            else
                MessageBox.Show("Không tìm thấy file PDF!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHT.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Mã hệ thống và Họ tên không được trống!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                var tg = new TacGia
                {
                    Maso = maHT,
                    MsTG = maThe,
                    Hoten = txtHoTen.Text.Trim(),
                    Ngaysinh = dtpNgaySinh.Value,
                    LoaiTacgia = cboPhanLoai.Text,
                    Email = email,
                    DienThoai = sdt,
                    SoTaiKhoan = txtSoTaiKhoan.Text.Trim(),
                    PhongBan = txtPhongBan.Text.Trim(),
                    NganHang = txtNganHang.Text.Trim(),
                    AvatarPath = currentImagePath,
                    PdfPath = currentPdfPath
                };

                await _tacGiaColl.InsertOneAsync(tg);
                MessageBox.Show("Thêm hồ sơ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow == null) return;
            string maHT = dgvTacGia.CurrentRow.Cells["MaHT"].Value.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))

            try
            {
                string id = dgvTacGia.CurrentRow.Cells["Id"].Value.ToString();
                string maHT = txtMaHT.Text.Trim();
                string maThe = txtMaThe.Text.Trim();
                string sdt = txtDienThoai.Text.Trim();
                string email = txtEmail.Text.Trim();

                var builder = Builders<TacGia>.Filter;
                var filterCheck = builder.Eq(t => t.Maso, maHT);

                if (!string.IsNullOrEmpty(maThe)) filterCheck |= builder.Eq(t => t.MsTG, maThe);
                if (!string.IsNullOrEmpty(sdt)) filterCheck |= builder.Eq(t => t.DienThoai, sdt);
                if (!string.IsNullOrEmpty(email)) filterCheck |= builder.Eq(t => t.Email, email);

                var finalFilter = builder.And(builder.Ne(t => t.Id, id), filterCheck);

                var exist = await _tacGiaColl.Find(finalFilter).FirstOrDefaultAsync();

                if (exist != null)
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

                var update = Builders<TacGia>.Update
                    .Set(t => t.Maso, maHT)
                    .Set(t => t.MsTG, maThe)
                    .Set(t => t.Hoten, txtHoTen.Text.Trim())
                    .Set(t => t.Ngaysinh, dtpNgaySinh.Value)
                    .Set(t => t.LoaiTacgia, cboPhanLoai.Text)
                    .Set(t => t.Email, email)
                    .Set(t => t.DienThoai, sdt)
                    .Set(t => t.SoTaiKhoan, txtSoTaiKhoan.Text.Trim())
                    .Set(t => t.PhongBan, txtPhongBan.Text.Trim())
                    .Set(t => t.NganHang, txtNganHang.Text.Trim())
                    .Set(t => t.AvatarPath, currentImagePath)
                    .Set(t => t.PdfPath, currentPdfPath);

                await _tacGiaColl.UpdateOneAsync(t => t.Id == id, update);
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTacGia.CurrentRow == null) return;
            if (MessageBox.Show("Xác nhận xóa hồ sơ này khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)

            if (MessageBox.Show("Chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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