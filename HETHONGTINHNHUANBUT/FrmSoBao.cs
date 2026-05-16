using System;
using System.Data;
using System.Data.SqlClient; // SỬ DỤNG THƯ VIỆN SQL SERVER
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmSoBao : Form
    {
        // --- CHUỖI KẾT NỐI SQL SERVER CHUẨN MÁY ĐỒNG CHÍ ---
        private readonly string sqlConnectionString = @"Server=LAPTOP-5O9OTMIJ\SQLEXPRESS;Database=TN;Trusted_Connection=True;";

        private string _tenNguoiDung;
        private string _selectedMaso = ""; // Lưu mã số đang chọn thay vì ID Mongo

        // =======================================================
        // BIẾN QUAN TRỌNG ĐỂ HỨNG QUYỀN TỪ FORM TRANG CHÍNH TRUYỀN SANG
        public string QuyenHienTai { get; set; }
        // =======================================================

        public FrmSoBao(string tenNguoiDung = "Admin")
        {
            InitializeComponent();
            _tenNguoiDung = tenNguoiDung;
        }

        private async void FrmSoBao_Load(object sender, EventArgs e)
        {
            if (this.Controls.Find("lblXinChao", true).FirstOrDefault() is Label lblXinChao)
            {
                lblXinChao.Text = $"Xin chào, {_tenNguoiDung} 👋";
            }

            if (cboLoaiBao.Items.Count > 0) cboLoaiBao.SelectedIndex = 0;

            // Làm đẹp giao diện bảng
            FormatGiaoDienBang();

            // Load dữ liệu từ SQL
            await LoadDataSQLAsync();

            // Phân quyền
            PhanQuyenThaoTac();
        }

        private void FormatGiaoDienBang()
        {
            dgvSoBao.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvSoBao.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSoBao.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSoBao.EnableHeadersVisualStyles = false;
            dgvSoBao.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 245, 250);
            dgvSoBao.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvSoBao.DefaultCellStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvSoBao.RowTemplate.Height = 40;
        }

        private void PhanQuyenThaoTac()
        {
            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            bool coQuyen = (role == "thư ký" || role == "admin" || role == "quản trị viên");

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = coQuyen;

            if (this.Controls.Find("btnKhoaSo", true).FirstOrDefault() is Guna.UI2.WinForms.Guna2Button btnKhoaSo)
            {
                btnKhoaSo.Enabled = coQuyen;
            }
        }

        // =======================================================
        // 1. LOAD DANH SÁCH SỐ BÁO TỪ SQL SERVER
        // =======================================================
        private async Task LoadDataSQLAsync(string keyword = "")
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT Maso, Tenbao, Ngayra, Sobao, Sobo, Loaibao, 
                                            CASE WHEN DaDuyet = 'Y' THEN N'🔒 Đã khóa sổ' ELSE N'Đang mở' END AS TinhTrang 
                                     FROM Bao";

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query += " WHERE Maso LIKE @kw OR Tenbao LIKE @kw OR Sobao LIKE @kw";
                    }
                    query += " ORDER BY Ngayra DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync()) { dt.Load(reader); }
                    }
                }

                dgvSoBao.DataSource = dt;

                if (dgvSoBao.Columns.Count > 0)
                {
                    dgvSoBao.Columns["Maso"].HeaderText = "MÃ SỐ";
                    dgvSoBao.Columns["Tenbao"].HeaderText = "TÊN KỲ BÁO";
                    dgvSoBao.Columns["Tenbao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvSoBao.Columns["Ngayra"].HeaderText = "NGÀY RA";
                    dgvSoBao.Columns["Ngayra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvSoBao.Columns["Sobao"].HeaderText = "SỐ BÁO";
                    dgvSoBao.Columns["Sobo"].HeaderText = "SỐ BỘ";
                    dgvSoBao.Columns["Loaibao"].HeaderText = "LOẠI BÁO";
                    dgvSoBao.Columns["TinhTrang"].HeaderText = "TÌNH TRẠNG SỔ";
                }
                dgvSoBao.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu SQL: " + ex.Message); }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataSQLAsync(txtTimKiem.Text);
        }

        // =======================================================
        // 2. THÊM SỐ BÁO MỚI (SQL)
        // =======================================================
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaso.Text) || string.IsNullOrWhiteSpace(txtTenBao.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã số và Tên báo!"); return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    // Kiểm tra trùng mã
                    string checkSql = "SELECT COUNT(*) FROM Bao WHERE Maso = @ma";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ma", txtMaso.Text.Trim());
                        if ((int)await checkCmd.ExecuteScalarAsync() > 0)
                        {
                            MessageBox.Show("Mã số báo này đã tồn tại trong SQL!"); return;
                        }
                    }

                    string sql = @"INSERT INTO Bao (Maso, Tenbao, Ngayra, Sobao, Sobo, Loaibao, DaDuyet) 
                                   VALUES (@ma, @ten, @ngay, @so, @bo, @loai, 'N')";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", txtMaso.Text.Trim());
                        cmd.Parameters.AddWithValue("@ten", txtTenBao.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngay", dtpNgayRa.Value);
                        cmd.Parameters.AddWithValue("@so", txtSoBao.Text.Trim());
                        cmd.Parameters.AddWithValue("@bo", txtSoBo.Text.Trim());
                        cmd.Parameters.AddWithValue("@loai", cboLoaiBao.Text);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Thêm kỳ báo vào SQL thành công!");
                await LoadDataSQLAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // =======================================================
        // 3. CẬP NHẬT THÔNG TIN (SQL)
        // =======================================================
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso)) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"UPDATE Bao SET Tenbao=@ten, Ngayra=@ngay, Sobao=@so, Sobo=@bo, Loaibao=@loai 
                                   WHERE Maso=@ma";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                        cmd.Parameters.AddWithValue("@ten", txtTenBao.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngay", dtpNgayRa.Value);
                        cmd.Parameters.AddWithValue("@so", txtSoBao.Text.Trim());
                        cmd.Parameters.AddWithValue("@bo", txtSoBo.Text.Trim());
                        cmd.Parameters.AddWithValue("@loai", cboLoaiBao.Text);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Cập nhật SQL thành công!");
                await LoadDataSQLAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
        }

        // =======================================================
        // 4. XÓA KỲ BÁO (SQL)
        // =======================================================
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso)) return;
            if (MessageBox.Show("Xác nhận xóa kỳ báo này khỏi SQL Server?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Bao WHERE Maso=@ma", conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await LoadDataSQLAsync();
                    btnLamMoi_Click(null, null);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        // =======================================================
        // 5. KHÓA / MỞ KHÓA SỔ BÁO (SQL)
        // =======================================================
        private async void btnKhoaSo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso))
            {
                MessageBox.Show("Chọn 1 kỳ báo để Khóa/Mở sổ!"); return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    // Lấy trạng thái hiện tại
                    string currentStatus = "N";
                    using (SqlCommand cmdGet = new SqlCommand("SELECT DaDuyet FROM Bao WHERE Maso=@ma", conn))
                    {
                        cmdGet.Parameters.AddWithValue("@ma", _selectedMaso);
                        currentStatus = cmdGet.ExecuteScalar()?.ToString() ?? "N";
                    }

                    string nextStatus = currentStatus == "Y" ? "N" : "Y";
                    string msg = nextStatus == "Y" ? "KHÓA SỔ" : "MỞ KHÓA SỔ";

                    using (SqlCommand cmdUpdate = new SqlCommand("UPDATE Bao SET DaDuyet=@st WHERE Maso=@ma", conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@st", nextStatus);
                        cmdUpdate.Parameters.AddWithValue("@ma", _selectedMaso);
                        await cmdUpdate.ExecuteNonQueryAsync();
                    }

                    MessageBox.Show($"Đã {msg} kỳ báo thành công!");
                    await LoadDataSQLAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khóa sổ: " + ex.Message); }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _selectedMaso = "";
            txtMaso.Clear(); txtTenBao.Clear(); txtSoBao.Clear(); txtSoBo.Clear();
            dtpNgayRa.Value = DateTime.Now;
            if (cboLoaiBao.Items.Count > 0) cboLoaiBao.SelectedIndex = 0;
            txtMaso.Focus();
        }

        private void dgvSoBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSoBao.Rows[e.RowIndex];
                _selectedMaso = row.Cells["Maso"].Value?.ToString();

                txtMaso.Text = _selectedMaso;
                txtTenBao.Text = row.Cells["Tenbao"].Value?.ToString();
                txtSoBao.Text = row.Cells["Sobao"].Value?.ToString();
                txtSoBo.Text = row.Cells["Sobo"].Value?.ToString();
                cboLoaiBao.Text = row.Cells["Loaibao"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["Ngayra"].Value?.ToString(), out DateTime dt)) dtpNgayRa.Value = dt;

                if (this.Controls.Find("btnKhoaSo", true).FirstOrDefault() is Guna.UI2.WinForms.Guna2Button btnKhoaSo)
                {
                    string trangThai = row.Cells["TinhTrang"].Value?.ToString();
                    if (trangThai == "🔒 Đã khóa sổ")
                    {
                        btnKhoaSo.Text = "MỞ KHÓA LẠI";
                        btnKhoaSo.FillColor = Color.FromArgb(239, 68, 68); // Đỏ
                    }
                    else
                    {
                        btnKhoaSo.Text = "🔒 KHÓA SỔ BÁO";
                        btnKhoaSo.FillColor = Color.FromArgb(16, 185, 129); // Xanh lá
                    }
                }
            }
        }
    }
}