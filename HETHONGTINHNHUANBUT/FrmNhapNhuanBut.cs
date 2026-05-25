using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmNhapNhuanBut : Form
    {
        // --- CHUỖI KẾT NỐI SQL SERVER ---
        private readonly string sqlConnectionString = @"Server=LAPTOP-K8EKOOUM\SQLEXPRESS;Database=TN;Trusted_Connection=True;";

        private string _selectedMaso = null;
        public string NguoiDangNhap { get; set; }
        public string QuyenHienTai { get; set; }

        // --- CÁC BIẾN LƯU TRỮ KẾT QUẢ AI TẠM THỜI CHỜ LƯU ---
        private double _diemAI = 0;
        private string _tyLeDaoVan = "";
        private string _nhanXetAI = "";

        public FrmNhapNhuanBut()
        {
            InitializeComponent();
        }

        private async void FrmNhapNhuanBut_Load(object sender, EventArgs e)
        {
            FormatGiaoDienDashboard();

            cboSoBao.SelectedIndexChanged -= cboSoBao_SelectedIndexChanged;
            await LoadComboboxDataSQLAsync();
            cboSoBao.SelectedIndexChanged += cboSoBao_SelectedIndexChanged;

            if (cboSoBao.SelectedValue != null)
                await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString());

            PhanQuyenThaoTac();
        }

        private void FormatGiaoDienDashboard()
        {
            dgvNhuanBut.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvNhuanBut.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNhuanBut.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvNhuanBut.EnableHeadersVisualStyles = false;
            dgvNhuanBut.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 245, 250);
            dgvNhuanBut.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvNhuanBut.DefaultCellStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvNhuanBut.RowTemplate.Height = 40;
        }

        private void PhanQuyenThaoTac()
        {
            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            bool coQuyen = !(role == "kế toán" || role == "lãnh đạo");

            btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = coQuyen;
            txtTenBai.ReadOnly = txtTrang.ReadOnly = txtMuc.ReadOnly = txtTienNhuanBut.ReadOnly = !coQuyen;
            cboButDanh.Enabled = cboVung.Enabled = cboVungChuyenDen.Enabled = coQuyen;

            // Mở khóa nút AI nếu có quyền thêm/sửa
            if (this.Controls.Find("btnQuetBaiAI", true).FirstOrDefault() is Control btnAI)
                btnAI.Enabled = coQuyen;
        }

        private async Task LoadComboboxDataSQLAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    // Load Kỳ Báo chưa khóa
                    DataTable dtBao = new DataTable();
                    string sqlBao = "SELECT Maso, Tenbao + ' (' + CONVERT(VARCHAR, Ngayra, 103) + ')' as HienThi FROM Bao WHERE DaDuyet = 'N' ORDER BY Ngayra DESC";
                    using (SqlCommand cmd = new SqlCommand(sqlBao, conn))
                    {
                        using (SqlDataReader r = await cmd.ExecuteReaderAsync()) { dtBao.Load(r); }
                    }
                    cboSoBao.DataSource = dtBao;
                    cboSoBao.DisplayMember = "HienThi";
                    cboSoBao.ValueMember = "Maso";

                    // Load Bút danh
                    DataTable dtBD = new DataTable();
                    string sqlBD = "SELECT DISTINCT Butdanh FROM Butdanh ORDER BY Butdanh";
                    using (SqlCommand cmd = new SqlCommand(sqlBD, conn))
                    {
                        using (SqlDataReader r = await cmd.ExecuteReaderAsync()) { dtBD.Load(r); }
                    }
                    cboButDanh.DataSource = dtBD;
                    cboButDanh.DisplayMember = "Butdanh";
                    cboButDanh.ValueMember = "Butdanh";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh mục SQL: " + ex.Message); }
        }

        private async void cboSoBao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue != null)
                await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString());
        }

        private async Task LoadDataGridSQLAsync(string maSoBao)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    // Đã thêm các trường LuotXem, LuotThich, DiemAI vào câu truy vấn
                    string query = @"SELECT Maso, STT, Tenbai, Trang, Muc, Butdanh, Vung, VungChuyenDen, 
                                            TienNhuanbut, LuotXem, LuotThich, DiemAI, TyLeDaoVan, NhanXetAI 
                                     FROM Nhuanbut WHERE MsBao = @maBao ORDER BY STT ASC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maBao", maSoBao);
                        using (SqlDataReader r = await cmd.ExecuteReaderAsync()) { dt.Load(r); }
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
                foreach (DataRow r in dt.Rows) tong += Convert.ToDecimal(r["TienNhuanbut"]);
                lblTongTien.Text = "TỔNG TIỀN ĐÃ CHẤM: " + tong.ToString("N0") + " VNĐ";
                dgvNhuanBut.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lưới SQL: " + ex.Message); }
        }

        // =======================================================
        // TÍNH NĂNG MỚI: MỞ TRẠM KIỂM ĐỊNH AI CHẤM ĐIỂM BÀI VIẾT
        // =======================================================
        private void btnQuetBaiAI_Click(object sender, EventArgs e)
        {
            using (FrmKiemDinhAI frmAI = new FrmKiemDinhAI())
            {
                if (frmAI.ShowDialog() == DialogResult.OK)
                {
                    AIResult ketQua = frmAI.KetQuaAI;
                    if (ketQua != null)
                    {
                        // 1. Lưu tạm vào biến để chờ nút LƯU
                        _diemAI = ketQua.DiemChatLuong;
                        _tyLeDaoVan = ketQua.TyLeDaoVan;
                        _nhanXetAI = ketQua.NhanXet;

                        // 2. CẬP NHẬT GIAO DIỆN NGAY LẬP TỨC (Đây là chỗ anh cần để thấy dữ liệu)
                        // Giả sử anh có các label này trên form, nếu chưa có thì thêm vào:
                        // lblStatusAI.Text = "Đã quét: " + _diemAI + " điểm";

                        // Hoặc đơn giản là báo cho người dùng biết dữ liệu đã sẵn sàng để lưu
                        MessageBox.Show($"Dữ liệu đã sẵn sàng! \nĐiểm AI: {_diemAI}\nĐạo văn: {_tyLeDaoVan}\nNhấn 'LƯU DỮ LIỆU' để hoàn tất.",
                                        "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (cboSoBao.SelectedValue == null) { MessageBox.Show("Vui lòng chọn số báo!"); return; }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    // Tính toán KPI
                    int luotXem = int.TryParse(txtLuotXem.Text, out int v) ? v : 0;
                    int luotThich = int.TryParse(txtLuotThich.Text, out int l) ? l : 0;
                    decimal tienCung = decimal.TryParse(txtTienNhuanBut.Text, out decimal t) ? t : 0;
                    decimal tongTien = tienCung + (luotXem * 50) + (luotThich * 100) + ((_diemAI >= 8.0) ? 200000 : 0);

                    string sql = string.IsNullOrEmpty(_selectedMaso)
                        ? @"INSERT INTO Nhuanbut (Maso, Tenbai, Trang, Muc, TienNhuanbut, Butdanh, MsBao, Vung, VungChuyenDen, addby, ngaychuyen, STT, LuotXem, LuotThich, DiemAI, TyLeDaoVan, NhanXetAI) 
                    VALUES (@ma, @ten, @trang, @muc, @tien, @bd, @msBao, @vung, @vungCD, @user, GETDATE(), @stt, @luotXem, @luotThich, @diemAI, @daoVan, @nhanXet)"
                        : @"UPDATE Nhuanbut SET Tenbai=@ten, Trang=@trang, Muc=@muc, TienNhuanbut=@tien, Butdanh=@bd, Vung=@vung, VungChuyenDen=@vungCD, 
                    LuotXem=@luotXem, LuotThich=@luotThich, DiemAI=@diemAI, TyLeDaoVan=@daoVan, NhanXetAI=@nhanXet 
                    WHERE Maso=@ma";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Truyền tham số chuẩn
                        cmd.Parameters.AddWithValue("@ma", string.IsNullOrEmpty(_selectedMaso) ? "NB" + DateTime.Now.ToString("HHmmss") : _selectedMaso);
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

                        // Các tham số AI và KPI
                        cmd.Parameters.AddWithValue("@luotXem", luotXem);
                        cmd.Parameters.AddWithValue("@luotThich", luotThich);
                        cmd.Parameters.AddWithValue("@diemAI", _diemAI);
                        cmd.Parameters.AddWithValue("@daoVan", _tyLeDaoVan ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@nhanXet", _nhanXetAI ?? (object)DBNull.Value);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Lưu dữ liệu thành công!");
                await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString());
                ClearInputs();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu SQL: " + ex.Message); }
        }
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso)) return;
            if (MessageBox.Show("Xóa dòng chấm nhuận bút này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    await LoadDataGridSQLAsync(cboSoBao.SelectedValue.ToString());
                    ClearInputs();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        private void dgvNhuanBut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvNhuanBut.CurrentRow == null) return;

            var row = dgvNhuanBut.Rows[e.RowIndex];
            _selectedMaso = row.Cells["Maso"].Value?.ToString();

            txtTenBai.Text = row.Cells["Tenbai"].Value?.ToString();
            txtTrang.Text = row.Cells["Trang"].Value?.ToString();
            txtMuc.Text = row.Cells["Muc"].Value?.ToString();
            cboButDanh.Text = row.Cells["Butdanh"].Value?.ToString();
            txtTienNhuanBut.Text = Convert.ToDecimal(row.Cells["TienNhuanbut"].Value).ToString("0");
            cboVung.Text = row.Cells["Vung"].Value?.ToString();
            cboVungChuyenDen.Text = row.Cells["VungChuyenDen"].Value?.ToString();

            // Lấy lại dữ liệu AI và KPI đang có
            _diemAI = row.Cells["DiemAI"].Value != DBNull.Value ? Convert.ToDouble(row.Cells["DiemAI"].Value) : 0;
            _tyLeDaoVan = row.Cells["TyLeDaoVan"].Value?.ToString();
            _nhanXetAI = row.Cells["NhanXetAI"].Value?.ToString();

            if (this.Controls.Find("txtLuotXem", true).FirstOrDefault() is TextBox tbView) tbView.Text = row.Cells["LuotXem"].Value?.ToString();
            if (this.Controls.Find("txtLuotThich", true).FirstOrDefault() is TextBox tbLike) tbLike.Text = row.Cells["LuotThich"].Value?.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearInputs();

        private void ClearInputs()
        {
            _selectedMaso = null;
            txtTenBai.Clear(); txtTrang.Clear(); txtMuc.Clear(); txtTienNhuanBut.Clear();
            cboVung.SelectedIndex = -1; cboVungChuyenDen.SelectedIndex = -1;

            // Reset biến AI và Textbox KPI
            _diemAI = 0; _tyLeDaoVan = ""; _nhanXetAI = "";
            if (this.Controls.Find("txtLuotXem", true).FirstOrDefault() is TextBox tbView) tbView.Clear();
            if (this.Controls.Find("txtLuotThich", true).FirstOrDefault() is TextBox tbLike) tbLike.Clear();

            txtTenBai.Focus();
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}