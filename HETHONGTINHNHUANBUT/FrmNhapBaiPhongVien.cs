using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmNhapBaiPhongVien : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        private string _selectedMaso = "";

        public string NguoiDangNhap { get; set; }
        public string QuyenHienTai { get; set; }

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtNoiDungBaiViet;
        private Guna.UI2.WinForms.Guna2Button btnPhanTichAI;
        private System.Windows.Forms.Label lblAIResult;

        public FrmNhapBaiPhongVien()
        {
            InitializeComponent();
            InitializeAIComponents();
            UIHelper.FormatGiaoDienBang(dgvBaiCuaToi);
            dgvBaiCuaToi.CellClick += dgvBaiCuaToi_CellClick;
        }

        private void InitializeAIComponents()
        {
            // btnPhanTichAI
            btnPhanTichAI = new Guna.UI2.WinForms.Guna2Button();
            btnPhanTichAI.Animated = true;
            btnPhanTichAI.BorderRadius = 8;
            btnPhanTichAI.FillColor = Color.FromArgb(16, 185, 129);
            btnPhanTichAI.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPhanTichAI.ForeColor = Color.White;
            btnPhanTichAI.Location = new Point(345, 210);
            btnPhanTichAI.Name = "btnPhanTichAI";
            btnPhanTichAI.Size = new Size(170, 38);
            btnPhanTichAI.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnPhanTichAI.TabIndex = 10;
            btnPhanTichAI.Text = "🤖 PHÂN TÍCH AI";
            btnPhanTichAI.Click += btnPhanTichAI_Click;
            pnlTop.Controls.Add(btnPhanTichAI);

            // label7 - NỘI DUNG BÀI VIẾT
            label7 = new Label();
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(100, 116, 139);
            label7.Location = new Point(25, 265);
            label7.Name = "label7";
            label7.Size = new Size(130, 17);
            label7.Text = "NỘI DUNG BÀI VIẾT";
            pnlTop.Controls.Add(label7);

            // txtNoiDungBaiViet
            txtNoiDungBaiViet = new RichTextBox();
            txtNoiDungBaiViet.BorderStyle = BorderStyle.FixedSingle;
            txtNoiDungBaiViet.BackColor = Color.White;
            txtNoiDungBaiViet.Font = new Font("Segoe UI", 10F);
            txtNoiDungBaiViet.ForeColor = Color.FromArgb(15, 23, 42);
            txtNoiDungBaiViet.Location = new Point(25, 288);
            txtNoiDungBaiViet.Name = "txtNoiDungBaiViet";
            txtNoiDungBaiViet.Size = new Size(1110, 150);
            txtNoiDungBaiViet.TabIndex = 9;
            txtNoiDungBaiViet.Text = "";
            txtNoiDungBaiViet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.Controls.Add(txtNoiDungBaiViet);

            // lblAIResult
            lblAIResult = new Label();
            lblAIResult.AutoSize = false;
            lblAIResult.Font = new Font("Segoe UI", 9.5F);
            lblAIResult.ForeColor = Color.FromArgb(15, 23, 42);
            lblAIResult.Location = new Point(25, 448);
            lblAIResult.Name = "lblAIResult";
            lblAIResult.Size = new Size(1110, 60);
            lblAIResult.Text = "";
            lblAIResult.Visible = false;
            lblAIResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.Controls.Add(lblAIResult);
        }

        private async void FrmNhapBaiPhongVien_Load(object sender, EventArgs e)
        {
            await LoadComboboxDataSQLAsync();
            await LoadBaiCuaToiAsync();
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

                    DataTable dtButDanh = new DataTable();
                    string sqlButDanh = "SELECT Maso, Butdanh FROM ButDanh ORDER BY Butdanh";
                    using (SqlCommand cmd = new SqlCommand(sqlButDanh, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dtButDanh));
                    }
                    cboButDanh.DisplayMember = "Butdanh";
                    cboButDanh.ValueMember = "Maso";
                    cboButDanh.DataSource = dtButDanh;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async Task LoadBaiCuaToiAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"SELECT Maso, Tenbai, Trang, Muc, Butdanh, 
                                          TienNhuanbut, 
                                          NoiDungBaiViet,
                                          DiemChatLuongAI,
                                          DanhGiaAI,
                                          NgayDanhGiaAI,
                                            CASE TrangThaiDuyet 
                                                WHEN 0 THEN N'Chờ chấm tiền'
                                                WHEN 1 THEN N'Đã chấm tiền'
                                                WHEN 2 THEN N'Đã nhập liệu'
                                                WHEN 3 THEN N'Đã kiểm tra'
                                                WHEN 4 THEN N'Đã ký duyệt'
                                                ELSE N'Không rõ'
                                            END AS TrangThaiDuyet
                                   FROM Nhuanbut 
                                   WHERE NguoiNhap = @user
                                   ORDER BY ngaychuyen DESC";
                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", NguoiDangNhap ?? "");
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            await Task.Run(() => da.Fill(dt));
                        }
                    }
                    dgvBaiCuaToi.DataSource = dt;
                    if (dgvBaiCuaToi.Columns["Maso"] != null) dgvBaiCuaToi.Columns["Maso"].Visible = false;
                    if (dgvBaiCuaToi.Columns["NoiDungBaiViet"] != null) dgvBaiCuaToi.Columns["NoiDungBaiViet"].Visible = false;
                    if (dgvBaiCuaToi.Columns["DiemChatLuongAI"] != null) { dgvBaiCuaToi.Columns["DiemChatLuongAI"].HeaderText = "AI ĐIỂM"; dgvBaiCuaToi.Columns["DiemChatLuongAI"].DefaultCellStyle.Format = "N1"; }
                    if (dgvBaiCuaToi.Columns["DanhGiaAI"] != null) dgvBaiCuaToi.Columns["DanhGiaAI"].Visible = false;
                    if (dgvBaiCuaToi.Columns["NgayDanhGiaAI"] != null) dgvBaiCuaToi.Columns["NgayDanhGiaAI"].Visible = false;
                    if (dgvBaiCuaToi.Columns["Tenbai"] != null) { dgvBaiCuaToi.Columns["Tenbai"].HeaderText = "TÊN BÀI"; dgvBaiCuaToi.Columns["Tenbai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
                    if (dgvBaiCuaToi.Columns["Trang"] != null) dgvBaiCuaToi.Columns["Trang"].HeaderText = "TRANG";
                    if (dgvBaiCuaToi.Columns["Muc"] != null) dgvBaiCuaToi.Columns["Muc"].HeaderText = "MỤC";
                    if (dgvBaiCuaToi.Columns["Butdanh"] != null) dgvBaiCuaToi.Columns["Butdanh"].HeaderText = "BÚT DANH";
                    if (dgvBaiCuaToi.Columns["TienNhuanbut"] != null) { dgvBaiCuaToi.Columns["TienNhuanbut"].HeaderText = "TIỀN"; dgvBaiCuaToi.Columns["TienNhuanbut"].DefaultCellStyle.Format = "N0"; }
                    if (dgvBaiCuaToi.Columns["TrangThaiDuyet"] != null) dgvBaiCuaToi.Columns["TrangThaiDuyet"].HeaderText = "TRẠNG THÁI";
                }
            }
            catch { }
        }

        private async void dgvBaiCuaToi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                string maso = dgvBaiCuaToi.Rows[e.RowIndex].Cells["Maso"]?.Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(maso)) return;

                _selectedMaso = maso;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"SELECT NoiDungBaiViet, DiemChatLuongAI, DanhGiaAI, NgayDanhGiaAI
                                   FROM Nhuanbut WHERE Maso = @ma";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maso);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string noiDung = reader["NoiDungBaiViet"]?.ToString() ?? "";
                                txtNoiDungBaiViet.Text = noiDung;

                                double diemAI = 0;
                                if (reader["DiemChatLuongAI"] != null && reader["DiemChatLuongAI"] != DBNull.Value)
                                    double.TryParse(reader["DiemChatLuongAI"].ToString(), out diemAI);

                                string danhGia = reader["DanhGiaAI"]?.ToString() ?? "";

                                if (diemAI > 0)
                                {
                                    lblAIResult.Visible = true;
                                    lblAIResult.Text = string.Format(
                                        "🤖 AI: {0}/100 điểm\n{1}",
                                        diemAI, danhGia);
                                    lblAIResult.ForeColor = Color.FromArgb(16, 185, 129);
                                }
                                else
                                {
                                    lblAIResult.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private async void btnNopBai_Click(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null) { MessageBox.Show("Vui lòng chọn số báo!"); return; }
            if (string.IsNullOrWhiteSpace(txtTenBai.Text)) { MessageBox.Show("Vui lòng nhập tên bài!"); return; }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    int newMa = 1;
                    string sqlMax = "SELECT ISNULL(MAX(Maso), 0) + 1 FROM Nhuanbut";
                    using (SqlCommand cmdMax = new SqlCommand(sqlMax, conn))
                    {
                        object result = await cmdMax.ExecuteScalarAsync();
                        newMa = Convert.ToInt32(result);
                    }

                    string noiDungBaiViet = txtNoiDungBaiViet.Text?.Trim() ?? "";

                    string sql = @"INSERT INTO Nhuanbut (Maso, Tenbai, Trang, Muc, TienNhuanbut, Butdanh, MsBao, Vung, VungChuyenDen, addby, ngaychuyen, NguoiNhap, TrangThaiDuyet, NoiDungBaiViet) 
                                   VALUES (@ma, @ten, @trang, @muc, 0, @bd, @msBao, @vung, @vungCD, @user, GETDATE(), @nguoiNhap, 0, @noiDung)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", newMa);
                        cmd.Parameters.AddWithValue("@ten", txtTenBai.Text.Trim());
                        cmd.Parameters.AddWithValue("@trang", txtTrang.Text.Trim());
                        cmd.Parameters.AddWithValue("@muc", txtMuc.Text.Trim());
                        cmd.Parameters.AddWithValue("@bd", cboButDanh.Text);
                        cmd.Parameters.AddWithValue("@msBao", cboSoBao.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@vung", cboVung.Text ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@vungCD", cboVungChuyenDen.Text ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@user", NguoiDangNhap ?? "Admin");
                        cmd.Parameters.AddWithValue("@nguoiNhap", NguoiDangNhap ?? "Admin");
                        cmd.Parameters.AddWithValue("@noiDung", string.IsNullOrEmpty(noiDungBaiViet) ? (object)DBNull.Value : (object)noiDungBaiViet);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Nộp bài thành công! Bài viết đang chờ kiểm duyệt.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                await LoadBaiCuaToiAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void btnPhanTichAI_Click(object sender, EventArgs e)
        {
            string tenBai = txtTenBai.Text?.Trim() ?? "";
            string muc = txtMuc.Text?.Trim() ?? "";
            string butDanh = cboButDanh.Text?.Trim() ?? "";
            string noiDung = txtNoiDungBaiViet.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(tenBai) || string.IsNullOrEmpty(muc) || string.IsNullOrEmpty(butDanh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: Tên bài, Mục và Bút danh trước khi phân tích AI.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung bài viết để phân tích AI.",
                    "Thiếu nội dung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnPhanTichAI.Enabled = false;
            btnPhanTichAI.Text = "🔄 AI ĐANG PHÂN TÍCH...";
            lblAIResult.Visible = false;

            try
            {
                BaiVietDanhGiaResult result = await BaiVietAIHelper.DanhGiaBaiVietAsync(tenBai, muc, noiDung, butDanh);

                lblAIResult.Visible = true;
                lblAIResult.Text = string.Format(
                    "🤖 Điểm chất lượng: {0:N1}/100\n{1}\n{2}",
                    result.DiemChatLuong, result.ChiTietDanhGia, result.DanhGia);
                lblAIResult.ForeColor = Color.FromArgb(16, 185, 129);

                string msg = string.Format(
                    "🤖 KẾT QUẢ PHÂN TÍCH AI\n\nĐiểm chất lượng: {0:N1}/100\n\n{1}\n\n{2}\n\nLưu ý: Đây chỉ là điểm tham khảo. Biên tập viên quyết định tiền nhuận bút cuối cùng.",
                    result.DiemChatLuong, result.ChiTietDanhGia, result.DanhGia);

                MessageBox.Show(msg, "AI Đánh giá chất lượng bài viết",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!string.IsNullOrEmpty(_selectedMaso))
                {
                    await LuuKetQuaAIVaoDb(_selectedMaso, result);
                }
            }
            catch (Exception ex)
            {
                lblAIResult.Visible = true;
                lblAIResult.Text = "❌ Lỗi kết nối AI: " + ex.Message;
                lblAIResult.ForeColor = Color.FromArgb(220, 38, 38);
                MessageBox.Show("Lỗi kết nối AI Đánh Giá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnPhanTichAI.Enabled = true;
                btnPhanTichAI.Text = "🤖 PHÂN TÍCH AI";
            }
        }

        private async Task LuuKetQuaAIVaoDb(string maso, BaiVietDanhGiaResult result)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"UPDATE Nhuanbut SET 
                                    DiemChatLuongAI = @diem,
                                    DanhGiaAI = @danhGia,
                                    NgayDanhGiaAI = GETDATE()
                                   WHERE Maso = @ma";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@diem", result.DiemChatLuong);
                        cmd.Parameters.AddWithValue("@danhGia", string.Format("{0}\n{1}", result.ChiTietDanhGia, result.DanhGia));
                        cmd.Parameters.AddWithValue("@ma", maso);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch { }
        }

        private async void btnKiemToanAI_Click(object sender, EventArgs e)
        {
            string tenBai = txtTenBai.Text?.Trim() ?? "";
            string muc = txtMuc.Text?.Trim() ?? "";
            string butDanh = cboButDanh.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(tenBai) || string.IsNullOrEmpty(muc) || string.IsNullOrEmpty(butDanh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: Tên bài, Mục và Bút danh trước khi dùng AI Kiểm Toán.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnKiemToanAI.Enabled = false;
            btnKiemToanAI.Text = "🔄 AI ĐANG KIỂM TOÁN...";

            try
            {
                string canhBaoLaSan = await KiemTraButDanhLaSanAsync(butDanh, muc);
                string[] baiHomNay = await LayDanhSachBaiHomNayAsync(butDanh);
                AIKiemToanResult ketQua = await AIHelper.KiemTraMetadataNhapLieuAsync(tenBai, muc, butDanh, baiHomNay);

                string warning = "";
                bool coCanhBao = false;

                if (!string.IsNullOrEmpty(canhBaoLaSan)) { warning += string.Format("⚠️ {0}\n", canhBaoLaSan); coCanhBao = true; }
                if (!string.IsNullOrEmpty(ketQua.CanhBaoTheLoai)) { warning += string.Format("🚨 {0}\n", ketQua.CanhBaoTheLoai); coCanhBao = true; }
                if (!string.IsNullOrEmpty(ketQua.CanhBaoTrungBai)) { warning += string.Format("⚠️ {0}\n", ketQua.CanhBaoTrungBai); coCanhBao = true; }

                if (coCanhBao)
                {
                    lblWarning.Text = warning.TrimEnd('\n');
                    lblWarning.ForeColor = Color.FromArgb(220, 38, 38);
                    lblWarning.Visible = true;
                    MessageBox.Show(string.Format("AI Kiểm Toán phát hiện vấn đề:\n\n{0}\n\nĐồng chí vui lòng kiểm tra lại!", warning),
                        "AI Kiểm Toán - Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblWarning.Text = string.Format("✅ {0}", ketQua.TomTat);
                    lblWarning.ForeColor = Color.FromArgb(16, 185, 129);
                    lblWarning.Visible = true;
                    MessageBox.Show(string.Format("✅ AI Kiểm Toán: {0}", ketQua.TomTat),
                        "AI Kiểm Toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                var batThuong = await AnomalyDetector.KiemTraAsync(
                    tenBai, butDanh, muc, 0,
                    "", NguoiDangNhap ?? "");

                if (batThuong.CoBatThuong)
                {
                    string noiDung = string.Join("\n", batThuong.CanhBao);
                    string tieuDe = batThuong.MucDo == AnomalyDetector.MucDo.NghiemTrong
                        ? "🚨 CẢNH BÁO NGHIÊM TRỌNG"
                        : "⚠️ PHÁT HIỆN BẤT THƯỜNG";
                    warning += "\n" + noiDung;
                    lblWarning.Text = warning.TrimEnd('\n');
                    lblWarning.ForeColor = Color.FromArgb(220, 38, 38);
                    lblWarning.Visible = true;
                    MessageBox.Show(noiDung, tieuDe,
                        MessageBoxButtons.OK,
                        batThuong.MucDo == AnomalyDetector.MucDo.NghiemTrong
                            ? MessageBoxIcon.Error : MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                lblWarning.Text = string.Format("❌ Lỗi AI: {0}", ex.Message);
                lblWarning.ForeColor = Color.FromArgb(220, 38, 38);
                lblWarning.Visible = true;
                MessageBox.Show("Lỗi kết nối AI Kiểm Toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnKiemToanAI.Enabled = true;
                btnKiemToanAI.Text = "📋 AI KIỂM TOÁN";
            }
        }

        private async Task<string> KiemTraButDanhLaSanAsync(string butDanh, string mucHienTai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"SELECT TOP 5 Muc, COUNT(*) as SoLan
                                   FROM Nhuanbut
                                   WHERE Butdanh = @bd AND Muc IS NOT NULL AND Muc <> ''
                                   GROUP BY Muc
                                   ORDER BY COUNT(*) DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@bd", butDanh);
                        System.Collections.Generic.List<string> cacMucThuongViet = new System.Collections.Generic.List<string>();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                                cacMucThuongViet.Add(reader["Muc"].ToString());
                        }

                        if (cacMucThuongViet.Count > 0 && !cacMucThuongViet.Contains(mucHienTai, StringComparer.OrdinalIgnoreCase))
                        {
                            string mucThuongViet = string.Join(", ", cacMucThuongViet);
                            return string.Format("Bút danh '{0}' thường viết mục: {1}. Bài này thuộc mục '{2}' - đồng chí có chắc không?", butDanh, mucThuongViet, mucHienTai);
                        }
                    }
                }
            }
            catch { }
            return "";
        }

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
                        var ds = new System.Collections.Generic.List<string>();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                                ds.Add(reader["Tenbai"].ToString());
                        }
                        return ds.ToArray();
                    }
                }
            }
            catch { return System.Array.Empty<string>(); }
        }

        private void ClearInputs()
        {
            txtTenBai.Clear();
            txtTrang.Clear();
            txtMuc.Clear();
            txtNoiDungBaiViet.Clear();
            cboVung.SelectedIndex = -1;
            cboVungChuyenDen.SelectedIndex = -1;
            lblWarning.Visible = false;
            lblAIResult.Visible = false;
            _selectedMaso = "";
            txtTenBai.Focus();
        }
    }
}
