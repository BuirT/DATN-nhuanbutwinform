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

        public string NguoiDangNhap { get; set; }
        public string QuyenHienTai { get; set; }

        public FrmNhapBaiPhongVien()
        {
            InitializeComponent();
            UIHelper.FormatGiaoDienBang(dgvBaiCuaToi);
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

                    string sql = @"INSERT INTO Nhuanbut (Maso, Tenbai, Trang, Muc, TienNhuanbut, Butdanh, MsBao, Vung, VungChuyenDen, addby, ngaychuyen, NguoiNhap, TrangThaiDuyet) 
                                   VALUES (@ma, @ten, @trang, @muc, 0, @bd, @msBao, @vung, @vungCD, @user, GETDATE(), @nguoiNhap, 0)";
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

                if (!string.IsNullOrEmpty(canhBaoLaSan)) { warning += $"⚠️ {canhBaoLaSan}\n"; coCanhBao = true; }
                if (!string.IsNullOrEmpty(ketQua.CanhBaoTheLoai)) { warning += $"🚨 {ketQua.CanhBaoTheLoai}\n"; coCanhBao = true; }
                if (!string.IsNullOrEmpty(ketQua.CanhBaoTrungBai)) { warning += $"⚠️ {ketQua.CanhBaoTrungBai}\n"; coCanhBao = true; }

                if (coCanhBao)
                {
                    lblWarning.Text = warning.TrimEnd('\n');
                    lblWarning.ForeColor = Color.FromArgb(220, 38, 38);
                    lblWarning.Visible = true;
                    MessageBox.Show($"AI Kiểm Toán phát hiện vấn đề:\n\n{warning}\n\nĐồng chí vui lòng kiểm tra lại!",
                        "AI Kiểm Toán - Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblWarning.Text = $"✅ {ketQua.TomTat}";
                    lblWarning.ForeColor = Color.FromArgb(16, 185, 129);
                    lblWarning.Visible = true;
                    MessageBox.Show($"✅ AI Kiểm Toán: {ketQua.TomTat}",
                        "AI Kiểm Toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Phát hiện bất thường
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
                lblWarning.Text = $"❌ Lỗi AI: {ex.Message}";
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
                            return $"Bút danh '{butDanh}' thường viết mục: {mucThuongViet}. Bài này thuộc mục '{mucHienTai}' - đồng chí có chắc không?";
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
            cboVung.SelectedIndex = -1;
            cboVungChuyenDen.SelectedIndex = -1;
            lblWarning.Visible = false;
            txtTenBai.Focus();
        }
    }
}
