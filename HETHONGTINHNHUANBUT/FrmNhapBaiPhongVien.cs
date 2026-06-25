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



        public FrmNhapBaiPhongVien()
        {
            InitializeComponent();
            UIHelper.FormatGiaoDienBang(dgvBaiCuaToi);
            dgvBaiCuaToi.CellClick += dgvBaiCuaToi_CellClick;
        }

       

        private async void FrmNhapBaiPhongVien_Load(object sender, EventArgs e)
        {
            await LoadComboboxDataSQLAsync();
            await LoadBaiCuaToiAsync();
            UpdatePanelLayout();
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

                    string sqlMuc = "SELECT DISTINCT Muc FROM DinhMuc ORDER BY Muc";
                    using (SqlCommand cmd = new SqlCommand(sqlMuc, conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        cboMuc.Items.Clear();
                        while (await r.ReadAsync())
                            cboMuc.Items.Add(r["Muc"].ToString());
                    }
                    cboMuc.DropDownWidth = 300;
                    cboMuc.DropDownHeight = 200;
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
                                          DanhGiaAI,
                                          DiemChatLuongAI,
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
                    if (dgvBaiCuaToi.Columns["DanhGiaAI"] != null) dgvBaiCuaToi.Columns["DanhGiaAI"].Visible = false;
                    if (dgvBaiCuaToi.Columns["DiemChatLuongAI"] != null) dgvBaiCuaToi.Columns["DiemChatLuongAI"].Visible = false;
                    if (dgvBaiCuaToi.Columns["NgayDanhGiaAI"] != null) dgvBaiCuaToi.Columns["NgayDanhGiaAI"].Visible = false;
                    if (dgvBaiCuaToi.Columns["Tenbai"] != null) { dgvBaiCuaToi.Columns["Tenbai"].HeaderText = "TÊN BÀI"; dgvBaiCuaToi.Columns["Tenbai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
                    if (dgvBaiCuaToi.Columns["Trang"] != null) dgvBaiCuaToi.Columns["Trang"].HeaderText = "TRANG";
                    if (dgvBaiCuaToi.Columns["Muc"] != null) dgvBaiCuaToi.Columns["Muc"].HeaderText = "MỤC";
                    if (dgvBaiCuaToi.Columns["Butdanh"] != null) dgvBaiCuaToi.Columns["Butdanh"].HeaderText = "BÚT DANH";
                    if (dgvBaiCuaToi.Columns["TienNhuanbut"] != null) { dgvBaiCuaToi.Columns["TienNhuanbut"].HeaderText = "TIỀN"; dgvBaiCuaToi.Columns["TienNhuanbut"].DefaultCellStyle.Format = "N0"; }
                    if (dgvBaiCuaToi.Columns["TrangThaiDuyet"] != null) dgvBaiCuaToi.Columns["TrangThaiDuyet"].HeaderText = "TRẠNG THÁI";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Loi LoadBaiCuaToiAsync: " + ex.Message);
            }
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
                    string sql = @"SELECT NoiDungBaiViet, DanhGiaAI, DiemChatLuongAI
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

                                int diemAI = 0;
                                if (reader["DiemChatLuongAI"] != DBNull.Value)
                                    int.TryParse(reader["DiemChatLuongAI"].ToString(), out diemAI);

                                string danhGia = reader["DanhGiaAI"]?.ToString() ?? "";

                                if (diemAI > 0 || !string.IsNullOrEmpty(danhGia))
                                {
                                    lblDiemAI.Text = diemAI > 0 ? $"🤖 Điểm AI: {diemAI}/100" : "";
                                    lblDiemAI.Visible = true;
                                    txtDanhGiaAI.Text = danhGia ?? "";
                                }
                                else
                                {
                                    lblDiemAI.Visible = false;
                                    txtDanhGiaAI.Text = "";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblDiemAI.Text = "❌ " + "Lỗi tại đánh giá AI: " + ex.Message;
                lblDiemAI.Visible = true;
                lblDiemAI.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        private async void btnNopBai_Click(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null) { MessageBox.Show("Vui lòng chọn số báo!"); return; }
            if (string.IsNullOrWhiteSpace(txtTenBai.Text)) { MessageBox.Show("Vui lòng nhập tên bài!"); return; }

            try
            {
                int newMa = 1;
                string noiDungBaiViet = txtNoiDungBaiViet.Text?.Trim() ?? "";

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sqlMax = "SELECT ISNULL(MAX(Maso), 0) + 1 FROM Nhuanbut";
                    using (SqlCommand cmdMax = new SqlCommand(sqlMax, conn))
                    {
                        object result = await cmdMax.ExecuteScalarAsync();
                        newMa = Convert.ToInt32(result);
                    }

                    string sql = @"INSERT INTO Nhuanbut (Maso, Tenbai, Trang, Muc, TienNhuanbut, Butdanh, MsBao, Vung, VungChuyenDen, addby, ngaychuyen, NguoiNhap, TrangThaiDuyet, NoiDungBaiViet) 
                                   VALUES (@ma, @ten, @trang, @muc, 0, @bd, @msBao, @vung, @vungCD, @user, GETDATE(), @nguoiNhap, 0, @noiDung)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", newMa);
                        cmd.Parameters.AddWithValue("@ten", txtTenBai.Text.Trim());
                        cmd.Parameters.AddWithValue("@trang", txtTrang.Text.Trim());
                        cmd.Parameters.AddWithValue("@muc", cboMuc.Text.Trim());
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
                MessageBox.Show("Nộp bài thành công! Đang chạy phân tích AI...", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await PhanTichAISauKhiNop(newMa, noiDungBaiViet);

                ClearInputs();
                await LoadBaiCuaToiAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lá»—i: " + ex.Message);
            }
        }

        private async void btnPhanTichAI_Click(object sender, EventArgs e)
        {
            string tenBai = txtTenBai.Text?.Trim() ?? "";
            string muc = cboMuc.Text?.Trim() ?? "";
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
            btnPhanTichAI.Text = "🤖 AI ĐANG PHÂN TÍCH...";
            lblDiemAI.Visible = false;
            txtDanhGiaAI.Text = "";

            try
            {
                BaiVietDanhGiaResult result = await BaiVietAIHelper.DanhGiaBaiVietAsync(tenBai, muc, noiDung, butDanh);

                lblDiemAI.Text = result.DiemChatLuongAI > 0
                    ? $"🤖 Điểm AI: {result.DiemChatLuongAI}/100"
                    : "🤖 Điểm AI: Đang chấm...";
                lblDiemAI.Visible = true;
                txtDanhGiaAI.Text = string.Format(
                    "{0}\n\n{1}",
                    result.ChiTietDanhGia, result.DanhGia);

                string msg = string.Format(
                    "🤖 KẾT QUẢ PHÂN TÍCH AI\n\nĐiểm: {0}/100\n\n{1}\n\n{2}\n\nLưu ý: Đây chỉ là nhận xét tham khảo từ AI.",
                    result.DiemChatLuongAI, result.ChiTietDanhGia, result.DanhGia);

                MessageBox.Show(msg, "AI Đánh giá chất lượng bài viết",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!string.IsNullOrEmpty(_selectedMaso))
                {
                    await LuuKetQuaAIVaoDb(_selectedMaso, result);
                }
            }
            catch (Exception ex)
            {
                lblDiemAI.Visible = true;
                lblDiemAI.Text = "❌ Lỗi kết nối AI: " + ex.Message;
                lblDiemAI.ForeColor = Color.FromArgb(220, 38, 38);
                MessageBox.Show("Lỗi kết nối AI Đánh Giá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnPhanTichAI.Enabled = true;
                btnPhanTichAI.Text = "🤖 PHÂN TÍCH AI";
                UpdatePanelLayout();
            }
        }

        private async Task PhanTichAISauKhiNop(int maso, string noiDung)
        {
            string tenBai = txtTenBai.Text?.Trim() ?? "";
            string muc = cboMuc.Text?.Trim() ?? "";
            string butDanh = cboButDanh.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(tenBai) || string.IsNullOrEmpty(muc) || string.IsNullOrEmpty(butDanh) || string.IsNullOrEmpty(noiDung))
                return;

            try
            {
                BaiVietDanhGiaResult result = await BaiVietAIHelper.DanhGiaBaiVietAsync(tenBai, muc, noiDung, butDanh);
                await LuuKetQuaAIVaoDb(maso.ToString(), result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phan tich AI sau khi nop that bai: " + ex.Message + "\n\nBai viet da nop thanh cong nhung chua co danh gia AI. Dong chi co the bam nut PHAN TICH AI de thu lai.", "Loi AI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                    DanhGiaAI = @danhGia,
                                    DiemChatLuongAI = @diem,
                                    NgayDanhGiaAI = GETDATE()
                                   WHERE Maso = @ma";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@danhGia", string.Format("{0}\n{1}", result.ChiTietDanhGia, result.DanhGia));
                        cmd.Parameters.AddWithValue("@diem", result.DiemChatLuongAI);
                        cmd.Parameters.AddWithValue("@ma", maso);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Luu ket qua AI that bai: " + ex.Message);
            }
        }

        private async void btnKiemToanAI_Click(object sender, EventArgs e)
        {
            string tenBai = txtTenBai.Text?.Trim() ?? "";
            string muc = cboMuc.Text?.Trim() ?? "";
            string butDanh = cboButDanh.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(tenBai) || string.IsNullOrEmpty(muc) || string.IsNullOrEmpty(butDanh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: Tên bài, Mục và Bút danh trước khi dùng AI Kiểm Toán.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnKiemToanAI.Enabled = false;
            btnKiemToanAI.Text = "🤖 AI ĐANG KIỂM TOÁN...";

            try
            {
                string canhBaoLaSan = await KiemTraButDanhLaSanAsync(butDanh, muc);
                string[] baiHomNay = await LayDanhSachBaiHomNayAsync(butDanh);
                AIKiemToanResult ketQua = await AIHelper.KiemTraMetadataNhapLieuAsync(tenBai, muc, butDanh, baiHomNay);

                string warning = "";
                bool coCanhBao = false;

                if (!string.IsNullOrEmpty(canhBaoLaSan)) { warning += string.Format("⚠️ {0}\n", canhBaoLaSan); coCanhBao = true; }
                if (!string.IsNullOrEmpty(ketQua.CanhBaoTheLoai)) { warning += string.Format("⚠️ {0}\n", ketQua.CanhBaoTheLoai); coCanhBao = true; }
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
                    lblWarning.Text = string.Format("✔️ {0}", ketQua.TomTat);
                    lblWarning.ForeColor = Color.FromArgb(16, 185, 129);
                    lblWarning.Visible = true;
                    MessageBox.Show(string.Format("✔️ AI Kiểm Toán: {0}", ketQua.TomTat),
                        "AI Kiểm Toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                var batThuong = await AnomalyDetector.KiemTraAsync(
                    tenBai, butDanh, muc, 0,
                    "", NguoiDangNhap ?? "");

                if (batThuong.CoBatThuong)
                {
                    string noiDung = string.Join("\n", batThuong.CanhBao);
                    string tieuDe = batThuong.MucDo == AnomalyDetector.MucDo.NghiemTrong
                        ? "⚠️ CẢNH BÁO NGHIÊM TRỌNG"
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
                UpdatePanelLayout();
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

        private void txtTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void ClearInputs()
        {
            txtTenBai.Clear();
            txtTrang.Clear();
            cboMuc.SelectedIndex = -1;
            txtNoiDungBaiViet.Clear();
            cboVung.SelectedIndex = -1;
            cboVungChuyenDen.SelectedIndex = -1;
            lblWarning.Visible = false;
            lblDiemAI.Visible = false;
            txtDanhGiaAI.Text = "";
            _selectedMaso = "";
            txtTenBai.Focus();
            UpdatePanelLayout();
        }

        private void UpdatePanelLayout()
        {
            int baseHeight = 460;
            if (lblDiemAI.Visible || lblWarning.Visible)
            {
                int maxBottom = baseHeight;
                if (lblDiemAI.Visible)
                    maxBottom = Math.Max(maxBottom, txtDanhGiaAI.Bottom + 10);
                if (lblWarning.Visible)
                    maxBottom = Math.Max(maxBottom, lblWarning.Bottom + 10);
                pnlTop.Height = maxBottom;
            }
            else
            {
                pnlTop.Height = baseHeight;
            }
            pnlBottom.Location = new Point(20, pnlTop.Bottom + 15);
            pnlBottom.Height = ClientSize.Height - pnlBottom.Top - 15;
        }

    }
}
