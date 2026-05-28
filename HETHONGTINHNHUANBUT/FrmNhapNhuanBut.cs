using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmNhapNhuanBut : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        private string _selectedMaso = null;
        private string _searchKeyword = "";
        private double _diemAI = 0;
        private string _tyLeDaoVan = "";
        private string _nhanXetAI = "";

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
            // 1. Dừng vẽ để setup màu sắc lưới cho nhanh
            this.SuspendLayout();
            FormatDataGridView();
            PhanQuyenThaoTac();
            this.ResumeLayout();

            // 2. Cho giao diện "thở" một nhịp rồi mới chui vào Database hút dữ liệu
            await Task.Delay(50);

            await AutoFixDatabaseColumns();
            await LoadComboboxDataSQLAsync();

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
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LuotXem' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD LuotXem INT DEFAULT 0;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LuotThich' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD LuotThich INT DEFAULT 0;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DiemAI' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD DiemAI FLOAT DEFAULT 0;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TyLeDaoVan' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD TyLeDaoVan NVARCHAR(50);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NhanXetAI' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NhanXetAI NVARCHAR(MAX);
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

        private void FormatDataGridView()
        {
            dgvNhuanBut.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvNhuanBut.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvNhuanBut.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvNhuanBut.EnableHeadersVisualStyles = false;
            dgvNhuanBut.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvNhuanBut.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvNhuanBut.DefaultCellStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvNhuanBut.RowTemplate.Height = 38;
        }

        private void PhanQuyenThaoTac()
        {
            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            bool coQuyen = !(role == "kế toán" || role == "lãnh đạo");
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnQuetBaiAI.Enabled = coQuyen;
            txtTenBai.ReadOnly = txtTrang.ReadOnly = txtMuc.ReadOnly = txtTienNhuanBut.ReadOnly = !coQuyen;
            txtLuotXem.ReadOnly = txtLuotThich.ReadOnly = !coQuyen;
            cboButDanh.Enabled = cboVung.Enabled = cboVungChuyenDen.Enabled = coQuyen;
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
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                        dtBao.Load(r);
                    cboSoBao.DataSource = dtBao;
                    cboSoBao.DisplayMember = "HienThi";
                    cboSoBao.ValueMember = "Maso";

                    DataTable dtBD = new DataTable();
                    string sqlBD = "SELECT DISTINCT Butdanh FROM Butdanh ORDER BY Butdanh";
                    using (SqlCommand cmd = new SqlCommand(sqlBD, conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                        dtBD.Load(r);
                    cboButDanh.DataSource = dtBD;
                    cboButDanh.DisplayMember = "Butdanh";
                    cboButDanh.ValueMember = "Butdanh";
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
                    string query = @"SELECT Maso, STT, Tenbai, Trang, Muc, Butdanh, Vung, VungChuyenDen, 
                                            TienNhuanbut, LuotXem, LuotThich, DiemAI, TyLeDaoVan, NhanXetAI 
                                     FROM Nhuanbut WHERE MsBao = @maBao";
                    if (!string.IsNullOrWhiteSpace(keyword))
                        query += " AND (Tenbai LIKE @kw OR Butdanh LIKE @kw)";
                    query += " ORDER BY STT ASC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maBao", maSoBao);
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");
                        using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                            dt.Load(r);
                    }
                }
                dgvNhuanBut.DataSource = dt;
                if (dgvNhuanBut.Columns.Count > 0)
                {
                    dgvNhuanBut.Columns["Maso"].Visible = false;
                    dgvNhuanBut.Columns["Vung"].Visible = false;
                    dgvNhuanBut.Columns["VungChuyenDen"].Visible = false;
                    dgvNhuanBut.Columns["TyLeDaoVan"].Visible = false;
                    dgvNhuanBut.Columns["NhanXetAI"].Visible = false;
                    dgvNhuanBut.Columns["STT"].HeaderText = "STT";
                    dgvNhuanBut.Columns["Tenbai"].HeaderText = "TÊN BÀI VIẾT";
                    dgvNhuanBut.Columns["Tenbai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvNhuanBut.Columns["Butdanh"].HeaderText = "BÚT DANH";
                    dgvNhuanBut.Columns["LuotXem"].HeaderText = "VIEWS";
                    dgvNhuanBut.Columns["LuotThich"].HeaderText = "LIKES";
                    dgvNhuanBut.Columns["DiemAI"].HeaderText = "ĐIỂM AI";
                    dgvNhuanBut.Columns["TienNhuanbut"].HeaderText = "TỔNG TIỀN (VNĐ)";
                    dgvNhuanBut.Columns["TienNhuanbut"].DefaultCellStyle.Format = "N0";
                }
                decimal tong = 0;
                foreach (DataRow row in dt.Rows) tong += Convert.ToDecimal(row["TienNhuanbut"]);
                lblTongTien.Text = "TỔNG TIỀN ĐÃ CHẤM: " + tong.ToString("N0") + " VNĐ";
                dgvNhuanBut.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void btnQuetBaiAI_Click(object sender, EventArgs e)
        {
            using (FrmKiemDinhAI frmAI = new FrmKiemDinhAI())
            {
                if (frmAI.ShowDialog() == DialogResult.OK)
                {
                    var ketQua = frmAI.KetQuaAI;
                    if (ketQua != null)
                    {
                        _diemAI = ketQua.DiemChatLuong;
                        _tyLeDaoVan = ketQua.TyLeDaoVan;
                        _nhanXetAI = ketQua.NhanXet;
                        MessageBox.Show($"Dữ liệu AI sẵn sàng!\nĐiểm: {_diemAI}\nĐạo văn: {_tyLeDaoVan}\nNhấn 'LƯU DỮ LIỆU' để hoàn tất.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null) { MessageBox.Show("Vui lòng chọn số báo!"); return; }
            if (string.IsNullOrWhiteSpace(txtTenBai.Text)) { MessageBox.Show("Vui lòng nhập tên bài!"); return; }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    int luotXem = int.TryParse(txtLuotXem.Text, out int v) ? v : 0;
                    int luotThich = int.TryParse(txtLuotThich.Text, out int l) ? l : 0;
                    decimal tienGoc = decimal.TryParse(txtTienNhuanBut.Text, out decimal t) ? t : 0;
                    decimal tongTien = tienGoc + (luotXem * 50) + (luotThich * 100) + (_diemAI >= 8.0 ? 200000 : 0);
                    string newMa = "NB" + DateTime.Now.ToString("HHmmss");
                    string sql = @"INSERT INTO Nhuanbut (Maso, Tenbai, Trang, Muc, TienNhuanbut, Butdanh, MsBao, Vung, VungChuyenDen, addby, ngaychuyen, STT, LuotXem, LuotThich, DiemAI, TyLeDaoVan, NhanXetAI) 
                                    VALUES (@ma, @ten, @trang, @muc, @tien, @bd, @msBao, @vung, @vungCD, @user, GETDATE(), @stt, @luotXem, @luotThich, @diemAI, @daoVan, @nhanXet)";
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
                        cmd.Parameters.AddWithValue("@stt", dgvNhuanBut.Rows.Count + 1);
                        cmd.Parameters.AddWithValue("@luotXem", luotXem);
                        cmd.Parameters.AddWithValue("@luotThich", luotThich);
                        cmd.Parameters.AddWithValue("@diemAI", _diemAI);
                        cmd.Parameters.AddWithValue("@daoVan", string.IsNullOrEmpty(_tyLeDaoVan) ? (object)DBNull.Value : _tyLeDaoVan);
                        cmd.Parameters.AddWithValue("@nhanXet", string.IsNullOrEmpty(_nhanXetAI) ? (object)DBNull.Value : _nhanXetAI);
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
                    int luotXem = int.TryParse(txtLuotXem.Text, out int v) ? v : 0;
                    int luotThich = int.TryParse(txtLuotThich.Text, out int l) ? l : 0;
                    decimal tienGoc = decimal.TryParse(txtTienNhuanBut.Text, out decimal t) ? t : 0;
                    decimal tongTien = tienGoc + (luotXem * 50) + (luotThich * 100) + (_diemAI >= 8.0 ? 200000 : 0);

                    string sql = @"UPDATE Nhuanbut SET Tenbai=@ten, Trang=@trang, Muc=@muc, TienNhuanbut=@tien, Butdanh=@bd, Vung=@vung, VungChuyenDen=@vungCD, 
                                    LuotXem=@luotXem, LuotThich=@luotThich, DiemAI=@diemAI, TyLeDaoVan=@daoVan, NhanXetAI=@nhanXet 
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
                        cmd.Parameters.AddWithValue("@luotXem", luotXem);
                        cmd.Parameters.AddWithValue("@luotThich", luotThich);
                        cmd.Parameters.AddWithValue("@diemAI", _diemAI);
                        cmd.Parameters.AddWithValue("@daoVan", string.IsNullOrEmpty(_tyLeDaoVan) ? (object)DBNull.Value : _tyLeDaoVan);
                        cmd.Parameters.AddWithValue("@nhanXet", string.IsNullOrEmpty(_nhanXetAI) ? (object)DBNull.Value : _nhanXetAI);
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtTimKiem.Text = "";
            _searchKeyword = "";
            if (cboSoBao.SelectedValue != null)
                LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString(), "").ConfigureAwait(false);
        }

        private void ClearInputs()
        {
            _selectedMaso = null;
            txtTenBai.Clear();
            txtTrang.Clear();
            txtMuc.Clear();
            txtTienNhuanBut.Clear();
            txtLuotXem.Text = "0";
            txtLuotThich.Text = "0";
            cboVung.SelectedIndex = -1;
            cboVungChuyenDen.SelectedIndex = -1;
            cboButDanh.SelectedIndex = -1;
            _diemAI = 0;
            _tyLeDaoVan = "";
            _nhanXetAI = "";
            txtTenBai.Focus();
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
            txtLuotXem.Text = row.Cells["LuotXem"].Value?.ToString();
            txtLuotThich.Text = row.Cells["LuotThich"].Value?.ToString();
            _diemAI = row.Cells["DiemAI"].Value != DBNull.Value ? Convert.ToDouble(row.Cells["DiemAI"].Value) : 0;
            _tyLeDaoVan = row.Cells["TyLeDaoVan"].Value?.ToString();
            _nhanXetAI = row.Cells["NhanXetAI"].Value?.ToString();
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e) { }
        private void pnlTop_Paint_1(object sender, PaintEventArgs e) { }
    }
}