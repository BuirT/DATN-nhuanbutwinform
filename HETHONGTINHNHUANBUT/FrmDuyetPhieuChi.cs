using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmDuyetPhieuChi : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        private string _selectedId = "";

        public string NguoiDuyet { get; set; } = "Ban Giám Đốc";
        public string QuyenHienTai { get; set; }

        public FrmDuyetPhieuChi()
        {
            InitializeComponent();

            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvPhieuChi, true, null);
        }

        private async void FrmDuyetPhieuChi_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvPhieuChi);
            await AutoFixDatabaseColumns(); // Tự động vá Database
            cboTrangThai.DropDownHeight = 200;
            cboTrangThai.IntegralHeight = true;
            cboTrangThai.MaxDropDownItems = 15;
            cboTrangThai.SelectedIndex = 0;
            await LoadDataAsync();
            PhanQuyenThaoTac();
        }

        // Tự động thêm các cột quản lý Duyệt Chi vào bảng Phieuchi trong SQL
        private async Task AutoFixDatabaseColumns()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string fixSql = @"
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TrangThaiDuyet' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD TrangThaiDuyet INT DEFAULT 0;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiDuyet' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD NguoiDuyet NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayDuyet' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD NgayDuyet DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LyDoTuChoi' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD LyDoTuChoi NVARCHAR(MAX);
                    ";
                    using (SqlCommand cmd = new SqlCommand(fixSql, conn))
                        await cmd.ExecuteNonQueryAsync();

                    // Cập nhật các phiếu cũ thành trạng thái 'Đang chờ duyệt'
                    string updateNulls = "UPDATE Phieuchi SET TrangThaiDuyet = 0 WHERE TrangThaiDuyet IS NULL;";
                    using (SqlCommand cmd2 = new SqlCommand(updateNulls, conn))
                        await cmd2.ExecuteNonQueryAsync();
                }
            }
            catch { }
        }

        private void PhanQuyenThaoTac()
        {
            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            if (role == "kế toán" || role == "thư ký")
            {
                btnDuyet.Enabled = false;
                btnTuChoi.Enabled = false;
                btnXoa.Enabled = false;
                txtLyDoTuChoi.ReadOnly = true;
            }
            else
            {
                btnDuyet.Enabled = true;
                btnTuChoi.Enabled = true;
                btnXoa.Enabled = true;
                txtLyDoTuChoi.ReadOnly = false;
            }
        }

        private async Task LoadDataAsync()
        {
            try
            {
                int trangThai = 0;
                if (cboTrangThai.SelectedIndex == 1) trangThai = 1;
                else if (cboTrangThai.SelectedIndex == 2) trangThai = -1;

                string keyword = txtTimKiem.Text.Trim();

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT Sophieu as Id, Sophieu, Ngaylap, Tacgia as TenTacGia, Nguoinhan, Lydo, Sotien as TongTien, Conlai as ThucLinh, LyDoTuChoi
                                     FROM Phieuchi WHERE TrangThaiDuyet = @tt";

                    if (!string.IsNullOrEmpty(keyword))
                        query += " AND (Sophieu LIKE @kw OR Tacgia LIKE @kw OR Nguoinhan LIKE @kw)";

                    query += " ORDER BY Ngaylap DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                        cmd.Parameters.AddWithValue("@tt", trangThai);
                        if (!string.IsNullOrEmpty(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }

                        dt.Columns.Add("NgayLapStr", typeof(string));
                        foreach (DataRow r in dt.Rows)
                        {
                            if (r["Ngaylap"] != DBNull.Value)
                                r["NgayLapStr"] = Convert.ToDateTime(r["Ngaylap"]).ToString("dd/MM/yyyy HH:mm");
                        }

                        dgvPhieuChi.DataSource = dt;
                    }
                }

                if (dgvPhieuChi.Columns.Count > 0)
                {
                    if (dgvPhieuChi.Columns["Id"] != null) dgvPhieuChi.Columns["Id"].Visible = false;
                    if (dgvPhieuChi.Columns["Ngaylap"] != null) dgvPhieuChi.Columns["Ngaylap"].Visible = false;
                    if (dgvPhieuChi.Columns["LyDoTuChoi"] != null) dgvPhieuChi.Columns["LyDoTuChoi"].Visible = false;

                    if (dgvPhieuChi.Columns["Sophieu"] != null) dgvPhieuChi.Columns["Sophieu"].HeaderText = "Số phiếu";
                    if (dgvPhieuChi.Columns["NgayLapStr"] != null) dgvPhieuChi.Columns["NgayLapStr"].HeaderText = "Ngày lập";
                    if (dgvPhieuChi.Columns["TenTacGia"] != null) dgvPhieuChi.Columns["TenTacGia"].HeaderText = "Tên tác giả";
                    if (dgvPhieuChi.Columns["Nguoinhan"] != null) dgvPhieuChi.Columns["Nguoinhan"].HeaderText = "Người nhận";
                    if (dgvPhieuChi.Columns["Lydo"] != null) dgvPhieuChi.Columns["Lydo"].HeaderText = "Lý do";
                    if (dgvPhieuChi.Columns["TongTien"] != null)
                    {
                        dgvPhieuChi.Columns["TongTien"].HeaderText = "Tổng tiền";
                        dgvPhieuChi.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    }
                    if (dgvPhieuChi.Columns["ThucLinh"] != null)
                    {
                        dgvPhieuChi.Columns["ThucLinh"].HeaderText = "Thực lĩnh";
                        dgvPhieuChi.Columns["ThucLinh"].DefaultCellStyle.Format = "N0";
                    }
                }
                ClearDetails();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private async void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDataAsync();

            bool isChoDuyet = cboTrangThai.SelectedIndex == 0;
            btnDuyet.Visible = isChoDuyet;
            btnTuChoi.Visible = isChoDuyet;
            txtLyDoTuChoi.Visible = isChoDuyet || cboTrangThai.SelectedIndex == 2;
            lblLyDoTuChoi.Visible = isChoDuyet || cboTrangThai.SelectedIndex == 2;
        }

        private void dgvPhieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPhieuChi.Rows[e.RowIndex];
                _selectedId = row.Cells["Id"].Value?.ToString();

                lblChiTietSoPhieu.Text = "Số phiếu: " + row.Cells["Sophieu"].Value?.ToString();
                lblChiTietTacGia.Text = "Thanh toán cho: " + row.Cells["TenTacGia"].Value?.ToString();
                var thucLinh = row.Cells["ThucLinh"].Value;
                lblChiTietTien.Text = (thucLinh != null && thucLinh != DBNull.Value ? Convert.ToDecimal(thucLinh) : 0).ToString("N0") + " VNĐ";

                if (cboTrangThai.SelectedIndex == 2)
                    txtLyDoTuChoi.Text = row.Cells["LyDoTuChoi"].Value?.ToString();
                else if (cboTrangThai.SelectedIndex == 0)
                    txtLyDoTuChoi.Text = row.Cells["Lydo"].Value?.ToString();
                else
                    txtLyDoTuChoi.Clear();
            }
        }

        private void ClearDetails()
        {
            _selectedId = "";
            lblChiTietSoPhieu.Text = "Số phiếu: ---";
            lblChiTietTacGia.Text = "Thanh toán cho: ---";
            lblChiTietTien.Text = "0 VNĐ";
            txtLyDoTuChoi.Clear();
        }

        private async void btnDuyet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId)) { MessageBox.Show("Vui lòng chọn phiếu cần duyệt!"); return; }
            if (MessageBox.Show("Xác nhận DUYỆT phiếu chi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();
                        string sql = "UPDATE Phieuchi SET TrangThaiDuyet = 1, NguoiDuyet = @nguoi, NgayDuyet = GETDATE() WHERE Sophieu = @id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@nguoi", this.NguoiDuyet ?? "Admin");
                            cmd.Parameters.AddWithValue("@id", _selectedId);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    MessageBox.Show("Đã duyệt phiếu chi thành công! Kế toán có thể xuất tiền.");
                    await LoadDataAsync();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi duyệt: " + ex.Message); }
            }
        }

        private async void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId)) { MessageBox.Show("Vui lòng chọn phiếu cần từ chối!"); return; }
            if (string.IsNullOrWhiteSpace(txtLyDoTuChoi.Text)) { MessageBox.Show("Vui lòng nhập lý do từ chối để Kế toán biết đường sửa!"); txtLyDoTuChoi.Focus(); return; }

            if (MessageBox.Show("Xác nhận TỪ CHỐI phiếu chi này? Các bài viết trong phiếu sẽ được mở khóa để Kế toán làm lại.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();
                        // 1. Cập nhật trạng thái phiếu
                        string sqlPhieu = "UPDATE Phieuchi SET TrangThaiDuyet = -1, LyDoTuChoi = @lydo, NguoiDuyet = @nguoi, NgayDuyet = GETDATE() WHERE Sophieu = @id";
                        using (SqlCommand cmd = new SqlCommand(sqlPhieu, conn))
                        {
                            cmd.Parameters.AddWithValue("@lydo", txtLyDoTuChoi.Text.Trim());
                            cmd.Parameters.AddWithValue("@nguoi", this.NguoiDuyet ?? "Admin");
                            cmd.Parameters.AddWithValue("@id", _selectedId);
                            await cmd.ExecuteNonQueryAsync();
                        }

                        // 2. Giải phóng các bài viết trong NhuanbutCT
                        string sqlGiaiPhong = "DELETE FROM NhuanbutCT WHERE SoPC = @id";
                        using (SqlCommand cmd = new SqlCommand(sqlGiaiPhong, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", _selectedId);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    MessageBox.Show("Đã từ chối phiếu chi! Hệ thống đã nhả các bài viết ra để làm lại.");
                    await LoadDataAsync();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi từ chối: " + ex.Message); }
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId)) { MessageBox.Show("Vui lòng chọn phiếu cần xóa!"); return; }

            if (MessageBox.Show("Xác nhận XÓA VĨNH VIỄN phiếu chi này? Các bài viết trong phiếu sẽ được mở khóa.", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();
                        // Xóa chi tiết trước (nhả bài viết)
                        string sqlCT = "DELETE FROM NhuanbutCT WHERE SoPC = @id";
                        using (SqlCommand cmd = new SqlCommand(sqlCT, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", _selectedId);
                            await cmd.ExecuteNonQueryAsync();
                        }

                        // Xóa phiếu chính
                        string sqlPhieu = "DELETE FROM Phieuchi WHERE Sophieu = @id";
                        using (SqlCommand cmd = new SqlCommand(sqlPhieu, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", _selectedId);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    MessageBox.Show("Đã xóa phiếu chi thành công! Hệ thống đã nhả các bài viết ra.");
                    await LoadDataAsync();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
