using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmNhapNhuanBut : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        private string _selectedMaso = null;
        private string _searchKeyword = "";

        public string NguoiDangNhap { get; set; }
        public string QuyenHienTai { get; set; }

        public FrmNhapNhuanBut()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvNhuanBut, true, null);
        }

        private async void FrmNhapNhuanBut_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            UIHelper.FormatGiaoDienBang(dgvNhuanBut);
            PhanQuyenThaoTac();
            this.ResumeLayout();

            await Task.Delay(50);

            await AutoFixDatabaseColumns();
            await LoadComboboxDataSQLAsync();
            cboVung.DropDownHeight = 200;
            cboVung.IntegralHeight = true;
            cboVung.MaxDropDownItems = 15;
            cboVungChuyenDen.DropDownHeight = 200;
            cboVungChuyenDen.IntegralHeight = true;
            cboVungChuyenDen.MaxDropDownItems = 15;

            txtTienNhuanBut.Leave += txtTienNhuanBut_Leave;

            cboSoBao.SelectedIndexChanged += cboSoBao_SelectedIndexChanged;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            if (cboSoBao.SelectedValue != null)
                await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString(), "");
        }

        private async Task AutoFixDatabaseColumns()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string fixSql = @"
                        -- Các cột cho quy trình duyệt (Kiểm duyệt nhuận bút)
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TrangThaiDuyet' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD TrangThaiDuyet INT DEFAULT 0;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiNhap' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiNhap NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiKiemTra' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiKiemTra NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiKeToan' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiKeToan NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TongThuKy' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD TongThuKy NVARCHAR(100);
                        -- Chuyển TrangThaiDuyet từ 2 (cũ) lên 3 (mới: đã ký duyệt)
                        IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'TrangThaiDuyet' AND Object_ID = Object_ID(N'Nhuanbut'))
                            UPDATE Nhuanbut SET TrangThaiDuyet = 3 WHERE TrangThaiDuyet = 2;

                        -- Tạo bảng định mức (nếu chưa có)
                        IF NOT EXISTS(SELECT * FROM sys.tables WHERE Name = N'DinhMuc')
                        BEGIN
                            CREATE TABLE DinhMuc (
                                MaDinhMuc INT IDENTITY(1,1) PRIMARY KEY,
                                Muc NVARCHAR(100) NOT NULL,
                                MucToiDa DECIMAL(18,0) NOT NULL DEFAULT 2000000,
                                NgayTao DATETIME DEFAULT GETDATE()
                            );

                            INSERT INTO DinhMuc (Muc, MucToiDa) VALUES
                                (N'Tin vắn', 500000),
                                (N'Phân tích', 3000000),
                                (N'Phỏng vấn', 2500000),
                                (N'Bài đinh', 4000000),
                                (N'Xã luận', 5000000),
                                (N'Phóng sự', 3000000),
                                (N'Góc nhìn', 2000000),
                                (N'Văn hóa', 2000000),
                                (N'Công nghệ', 2000000),
                                (N'Thể thao', 2000000),
                                (N'Kinh tế', 2500000),
                                (N'Chính trị', 3000000);
                        END
                    ";
                    using (SqlCommand cmd = new SqlCommand(fixSql, conn))
                        await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi DB: " + ex.Message);
            }
        }

        private void PhanQuyenThaoTac()
        {
            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            bool laAdmin = (role == "admin" || role == "quản trị viên");
            bool laPhoiVien = (role == "phóng viên");
            bool biKhoa = (role == "kế toán" || role == "lãnh đạo");

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnKiemToanAI.Enabled = !biKhoa;
            txtTenBai.ReadOnly = txtTrang.ReadOnly = txtMuc.ReadOnly = biKhoa;
            cboButDanh.Enabled = cboVung.Enabled = cboVungChuyenDen.Enabled = !biKhoa;

            // Phóng viên chỉ nhập tên bài, mục, bút danh - KHÔNG nhập tiền
            txtTienNhuanBut.ReadOnly = laPhoiVien || biKhoa;
        }

        private async Task LoadComboboxDataSQLAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    DataTable dtBao = new DataTable();
                    string sqlBao = "SELECT Maso, Tenbao + ' (' + CONVERT(VARCHAR, Ngayra, 103) + ')' as HienThi FROM Bao WHERE DaDuyet = 'N' ORDER BY Ngayra DESC";
                    using (SqlCommand cmd = new SqlCommand(sqlBao, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dtBao));
                    }
                    cboSoBao.DisplayMember = "HienThi";
                    cboSoBao.ValueMember = "Maso";
                    cboSoBao.DataSource = dtBao;
                    cboSoBao.DropDownHeight = 200;
                    cboSoBao.IntegralHeight = true;
                    cboSoBao.MaxDropDownItems = 15;

                    string sqlBD = "SELECT DISTINCT Butdanh FROM Butdanh ORDER BY Butdanh";
                    using (SqlCommand cmd = new SqlCommand(sqlBD, conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        cboButDanh.Items.Clear();
                        while (await r.ReadAsync())
                            cboButDanh.Items.Add(r["Butdanh"].ToString());
                    }
                    cboButDanh.DropDownHeight = 200;
                    cboButDanh.IntegralHeight = true;
                    cboButDanh.MaxDropDownItems = 15;
                    cboButDanh.DropDown += (s, e) =>
                    {
                        cboButDanh.DroppedDown = false;
                        cboButDanh.BeginInvoke(new Action(() => cboButDanh.DroppedDown = true));
                    };
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh mục: " + ex.Message); }
        }

        private async void cboSoBao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue != null)
                await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString(), _searchKeyword);
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            _searchKeyword = txtTimKiem.Text;
            if (cboSoBao.SelectedValue != null)
                await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString(), _searchKeyword);
        }

        private async Task LoadDataGridSQLAsync(string maSoBao, string keyword = "")
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT Maso, Tenbai, Trang, Muc, Butdanh, Vung, VungChuyenDen, 
                                            TienNhuanbut,
                                            DanhGiaAI
                                     FROM Nhuanbut WHERE MsBao = @maBao";
                    if (!string.IsNullOrWhiteSpace(keyword))
                        query += " AND (Tenbai LIKE @kw OR Butdanh LIKE @kw)";
                    query += " ORDER BY STT ASC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maBao", maSoBao);
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            await Task.Run(() => da.Fill(dt));
                        }
                    }
                }
                dgvNhuanBut.DataSource = dt;
                if (dgvNhuanBut.Columns.Count > 0)
                {
                    foreach (string col in new[] { "Maso", "Vung", "VungChuyenDen", "MsBao", "addby", "ngaychuyen",
                        "NguoiNhap", "NguoiChamTien", "NguoiKiemTra", "NguoiKeToan", "TongThuKy",
                        "TrangThaiDuyet", "DaThanhToan", "LoaiBao" })
                        if (dgvNhuanBut.Columns[col] != null) dgvNhuanBut.Columns[col].Visible = false;

                    if (dgvNhuanBut.Columns["DanhGiaAI"] != null) dgvNhuanBut.Columns["DanhGiaAI"].Visible = false;

                    UIHelper.ConfigureColumns(dgvNhuanBut,
                        ("Tenbai", "TÊN BÀI VIẾT", false, false),
                        ("Trang", "Trang", false, false),
                        ("Muc", "Mục", false, false),
                        ("Butdanh", "BÚT DANH", false, false),
                        ("TienNhuanbut", "TỔNG TIỀN (VNĐ)", true, false)
                    );
                }
                decimal tong = 0;
                foreach (DataRow row in dt.Rows) tong += Convert.ToDecimal(row["TienNhuanbut"]);
                lblTongTien.Text = "TỔNG TIỀN ĐÃ CHẤM: " + tong.ToString("N0") + " VNĐ";
                dgvNhuanBut.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // =========================================================================
        // Đã xóa btnQuetBaiAI_Click (QUÉT BÀI AI) — không cần thiết vì không có nội dung bài

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null) { MessageBox.Show("Vui lòng chọn số báo!"); return; }
            if (string.IsNullOrWhiteSpace(txtTenBai.Text)) { MessageBox.Show("Vui lòng nhập tên bài!"); return; }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    decimal tienGoc = decimal.TryParse(txtTienNhuanBut.Text, out decimal t) ? t : 0;
                    decimal tongTien = tienGoc;
                    int newMa = 1;
                    string sqlMax = "SELECT ISNULL(MAX(Maso), 0) + 1 FROM Nhuanbut";
                    using (SqlCommand cmdMax = new SqlCommand(sqlMax, conn))
                    {
                        object result = await cmdMax.ExecuteScalarAsync();
                        newMa = Convert.ToInt32(result);
                    }
                    string sql = @"INSERT INTO Nhuanbut (Maso, Tenbai, Trang, Muc, TienNhuanbut, Butdanh, MsBao, Vung, VungChuyenDen, addby, ngaychuyen, STT, NguoiNhap, TrangThaiDuyet) 
                                    VALUES (@ma, @ten, @trang, @muc, @tien, @bd, @msBao, @vung, @vungCD, @user, GETDATE(), @stt, @nguoiNhap, 0)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                        cmd.Parameters.AddWithValue("@ma", newMa);
                        cmd.Parameters.AddWithValue("@ten", txtTenBai.Text);
                        cmd.Parameters.AddWithValue("@trang", txtTrang.Text);
                        cmd.Parameters.AddWithValue("@muc", txtMuc.Text);
                        cmd.Parameters.AddWithValue("@tien", tongTien);
                        cmd.Parameters.AddWithValue("@bd", cboButDanh.Text);
                        cmd.Parameters.AddWithValue("@msBao", cboSoBao.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@vung", cboVung.Text ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@vungCD", cboVungChuyenDen.Text ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@user", NguoiDangNhap ?? "Admin");
                        cmd.Parameters.AddWithValue("@nguoiNhap", NguoiDangNhap ?? "Admin");
                        cmd.Parameters.AddWithValue("@stt", dgvNhuanBut.Rows.Count + 1);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Thêm mới thành công!");
                await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString(), _searchKeyword);
                ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm mới: " + ex.Message); }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso))
            {
                MessageBox.Show("Vui lòng chọn bài viết cần cập nhật!");
                return;
            }
            await CapNhatBaiViet();
        }

        private async Task CapNhatBaiViet()
        {
            if (cboSoBao.SelectedValue == null) { MessageBox.Show("Vui lòng chọn số báo!"); return; }
            if (string.IsNullOrWhiteSpace(txtTenBai.Text)) { MessageBox.Show("Vui lòng nhập tên bài!"); return; }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    decimal tienGoc = decimal.TryParse(txtTienNhuanBut.Text, out decimal t) ? t : 0;
                    decimal tongTien = tienGoc;

                    string sql = @"UPDATE Nhuanbut SET Tenbai=@ten, Trang=@trang, Muc=@muc, TienNhuanbut=@tien, Butdanh=@bd, Vung=@vung, VungChuyenDen=@vungCD
                                    WHERE Maso=@ma";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                        cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                        cmd.Parameters.AddWithValue("@ten", txtTenBai.Text);
                        cmd.Parameters.AddWithValue("@trang", txtTrang.Text);
                        cmd.Parameters.AddWithValue("@muc", txtMuc.Text);
                        cmd.Parameters.AddWithValue("@tien", tongTien);
                        cmd.Parameters.AddWithValue("@bd", cboButDanh.Text);
                        cmd.Parameters.AddWithValue("@vung", cboVung.Text ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@vungCD", cboVungChuyenDen.Text ?? (object)DBNull.Value);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString(), _searchKeyword);
                ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi cập nhật: " + ex.Message); }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso)) { MessageBox.Show("Vui lòng chọn bài viết cần xóa!"); return; }
            if (MessageBox.Show("Bạn có chắc chắn xóa bài viết này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Nhuanbut WHERE Maso=@ma", conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString(), _searchKeyword);
                    ClearInputs();
                    MessageBox.Show("Xóa thành công!");
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtTimKiem.Text = "";
            _searchKeyword = "";
            if (cboSoBao.SelectedValue != null)
                await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString(), "");
        }

        private void ClearInputs()
        {
            _selectedMaso = null;
            txtTenBai.Clear();
            txtTrang.Clear();
            txtMuc.Clear();
            txtTienNhuanBut.Clear();
            cboVung.SelectedIndex = -1;
            cboVungChuyenDen.SelectedIndex = -1;
            cboButDanh.SelectedIndex = -1;
            lblWarning.Visible = false;
            txtTenBai.Focus();
        }

        // =====================================================================
        // KIỂM TRA ĐỊNH MỨC (Code C# thuần - KHÔNG dùng AI)
        // =====================================================================
        private async void txtTienNhuanBut_Leave(object sender, EventArgs e)
        {
            await KiemTraDinhMucAsync();
        }

        private async Task KiemTraDinhMucAsync()
        {
            lblWarning.Visible = false;

            string muc = txtMuc.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(muc)) return;

            decimal tienNhap = decimal.TryParse(txtTienNhuanBut.Text, out decimal t) ? t : 0;
            if (tienNhap <= 0) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = "SELECT MucToiDa FROM DinhMuc WHERE Muc = @muc";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@muc", muc);
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null)
                        {
                            decimal mucToiDa = Convert.ToDecimal(result);
                            if (tienNhap > mucToiDa)
                            {
                                lblWarning.Text = $"🚨 VƯỢT ĐỊNH MỨC! Mục '{muc}' tối đa {mucToiDa:N0} VNĐ. Đồng chí đã nhập {tienNhap:N0} VNĐ.";
                                lblWarning.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
                                lblWarning.Visible = true;
                            }
                        }
                        else
                        {
                            // Mục chưa có định mức, cho qua nhưng nhắc nhẹ
                            lblWarning.Text = $"ℹ️ Mục '{muc}' chưa được thiết lập định mức. Vui lòng kiểm tra lại.";
                            lblWarning.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
                            lblWarning.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi check định mức: " + ex.Message);
            }
        }

        // =====================================================================
        // AI KIỂM TOÁN (Rà soát logic metadata)
        // =====================================================================
        private async void btnKiemToanAI_Click(object sender, EventArgs e)
        {
            string tenBai = txtTenBai.Text?.Trim() ?? "";
            string muc = txtMuc.Text?.Trim() ?? "";
            string butDanh = cboButDanh.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(tenBai) || string.IsNullOrEmpty(muc) || string.IsNullOrEmpty(butDanh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: Tên bài, Mục (Thể loại) và Bút danh trước khi dùng AI Kiểm Toán.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnKiemToanAI.Enabled = false;
            btnKiemToanAI.Text = "🔄 AI ĐANG KIỂM TOÁN...";

            try
            {
                // Bước 1: Kiểm tra bút danh lạ sân (SQL - không cần AI)
                string canhBaoLaSan = await KiemTraButDanhLaSanAsync(butDanh, muc);

                // Bước 2: Lấy danh sách bài hôm nay của cùng tác giả (để AI check trùng)
                string[] baiHomNay = await LayDanhSachBaiHomNayAsync(butDanh);

                // Bước 3: Gọi AI kiểm tra metadata
                AIKiemToanResult ketQua = await AIHelper.KiemTraMetadataNhapLieuAsync(
                    tenBai, muc, butDanh, baiHomNay);

                // Bước 4: Tổng hợp kết quả
                string warning = "";
                bool coCanhBao = false;

                if (!string.IsNullOrEmpty(canhBaoLaSan))
                {
                    warning += $"⚠️ {canhBaoLaSan}\n";
                    coCanhBao = true;
                }

                if (!string.IsNullOrEmpty(ketQua.CanhBaoTheLoai))
                {
                    warning += $"🚨 {ketQua.CanhBaoTheLoai}\n";
                    coCanhBao = true;
                }

                if (!string.IsNullOrEmpty(ketQua.CanhBaoTrungBai))
                {
                    warning += $"⚠️ {ketQua.CanhBaoTrungBai}\n";
                    coCanhBao = true;
                }

                if (coCanhBao)
                {
                    lblWarning.Text = warning.TrimEnd('\n');
                    lblWarning.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
                    lblWarning.Visible = true;
                    MessageBox.Show($"AI Kiểm Toán phát hiện vấn đề:\n\n{warning}\n\nĐồng chí vui lòng kiểm tra lại!",
                        "AI Kiểm Toán - Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblWarning.Text = $"✅ {ketQua.TomTat}";
                    lblWarning.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
                    lblWarning.Visible = true;
                    MessageBox.Show($"✅ AI Kiểm Toán: {ketQua.TomTat}",
                        "AI Kiểm Toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = $"❌ Lỗi AI: {ex.Message}";
                lblWarning.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
                lblWarning.Visible = true;
                MessageBox.Show("Lỗi kết nối AI Kiểm Toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnKiemToanAI.Enabled = true;
                btnKiemToanAI.Text = "📋 AI KIỂM TOÁN";
            }
        }

        // Kiểm tra bút danh có lạ sân không (SQL, không cần AI)
        private async Task<string> KiemTraButDanhLaSanAsync(string butDanh, string mucHienTai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    // Lấy top 5 mục tác giả này thường viết
                    string sql = @"SELECT TOP 5 Muc, COUNT(*) as SoLan
                                   FROM Nhuanbut
                                   WHERE Butdanh = @bd AND Muc IS NOT NULL AND Muc <> ''
                                   GROUP BY Muc
                                   ORDER BY COUNT(*) DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@bd", butDanh);
                        List<string> cacMucThuongViet = new List<string>();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                                cacMucThuongViet.Add(reader["Muc"].ToString());
                        }

                        if (cacMucThuongViet.Count > 0 && !cacMucThuongViet.Contains(mucHienTai, StringComparer.OrdinalIgnoreCase))
                        {
                            string mucThuongViet = string.Join(", ", cacMucThuongViet.Take(3));
                            return $"Bút danh '{butDanh}' thường viết mục: {mucThuongViet}. Bài này thuộc mục '{mucHienTai}' - đồng chí có chắc không?";
                        }
                    }
                }
            }
            catch { /* im lặng nếu lỗi */ }
            return "";
        }

        // Lấy danh sách bài hôm nay của cùng tác giả (cho AI check trùng)
        private async Task<string[]> LayDanhSachBaiHomNayAsync(string butDanh)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"SELECT Tenbai FROM Nhuanbut
                                   WHERE Butdanh = @bd
                                   AND CAST(ngaychuyen AS DATE) = CAST(GETDATE() AS DATE)
                                   ORDER BY ngaychuyen DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@bd", butDanh);
                        List<string> ds = new List<string>();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                                ds.Add(reader["Tenbai"].ToString());
                        }
                        return ds.ToArray();
                    }
                }
            }
            catch { return Array.Empty<string>(); }
        }

        private void dgvNhuanBut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvNhuanBut.CurrentRow == null) return;
            DataGridViewRow row = dgvNhuanBut.Rows[e.RowIndex];
            _selectedMaso = row.Cells["Maso"].Value?.ToString();
            txtTenBai.Text = row.Cells["Tenbai"].Value?.ToString();
            txtTrang.Text = row.Cells["Trang"].Value?.ToString();
            txtMuc.Text = row.Cells["Muc"].Value?.ToString();
            cboButDanh.Text = row.Cells["Butdanh"].Value?.ToString();
            txtTienNhuanBut.Text = Convert.ToDecimal(row.Cells["TienNhuanbut"].Value).ToString("0");
            cboVung.Text = row.Cells["Vung"].Value?.ToString();
            cboVungChuyenDen.Text = row.Cells["VungChuyenDen"].Value?.ToString();

            // Hiển thị AI evaluation nếu có
            if (dgvNhuanBut.Columns["DanhGiaAI"] != null)
            {
                string danhGiaAI = row.Cells["DanhGiaAI"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(danhGiaAI))
                {
                    lblWarning.Text = "🤖 " + danhGiaAI;
                    lblWarning.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
                    lblWarning.Visible = true;
                }
            }
        }
    }
}
