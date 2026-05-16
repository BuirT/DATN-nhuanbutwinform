using System;
using System.Collections.Generic;
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
    public partial class FrmNhapNhuanBut : Form
    {
        // --- CHUỖI KẾT NỐI SQL SERVER CHUẨN MÁY ĐỒNG CHÍ ---
        private readonly string sqlConnectionString = @"Server=LAPTOP-5O9OTMIJ\SQLEXPRESS;Database=TN;Trusted_Connection=True;";

        private string _selectedMaso = null; // Lưu Maso của bài viết đang chọn (SQL dùng Maso thay vì Id)
        public string NguoiDangNhap { get; set; }
        public string QuyenHienTai { get; set; }

        public FrmNhapNhuanBut()
        {
            InitializeComponent();
        }

        private async void FrmNhapNhuanBut_Load(object sender, EventArgs e)
        {
            // Định dạng giao diện bảng chuyên nghiệp
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
        }

        // =======================================================
        // 1. LOAD DANH MỤC TỪ SQL (KỲ BÁO & BÚT DANH)
        // =======================================================
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

        // =======================================================
        // 2. HIỂN THỊ DANH SÁCH BÀI VIẾT THEO KỲ BÁO (SQL)
        // =======================================================
        private async Task LoadDataGridSQLAsync(string maSoBao)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT Maso, STT, Tenbai, Trang, Muc, Butdanh, Vung, VungChuyenDen, TienNhuanbut 
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

                    dgvNhuanBut.Columns["STT"].HeaderText = "STT";
                    dgvNhuanBut.Columns["Tenbai"].HeaderText = "TÊN BÀI VIẾT";
                    dgvNhuanBut.Columns["Tenbai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvNhuanBut.Columns["Butdanh"].HeaderText = "BÚT DANH";
                    dgvNhuanBut.Columns["TienNhuanbut"].HeaderText = "SỐ TIỀN (VNĐ)";
                    dgvNhuanBut.Columns["TienNhuanbut"].DefaultCellStyle.Format = "N0";
                }

                // Tính tổng tiền
                decimal tong = 0;
                foreach (DataRow r in dt.Rows) tong += Convert.ToDecimal(r["TienNhuanbut"]);
                lblTongTien.Text = "TỔNG TIỀN ĐÃ CHẤM: " + tong.ToString("N0") + " VNĐ";
                dgvNhuanBut.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lưới SQL: " + ex.Message); }
        }

        // =======================================================
        // 3. THÊM / CẬP NHẬT NHUẬN BÚT (SQL)
        // =======================================================
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null || string.IsNullOrWhiteSpace(txtTenBai.Text))
            {
                MessageBox.Show("Vui lòng chọn kỳ báo và nhập tên bài!"); return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    decimal tien = decimal.TryParse(txtTienNhuanBut.Text, out decimal t) ? t : 0;

                    if (string.IsNullOrEmpty(_selectedMaso)) // THÊM MỚI
                    {
                        string insertSql = @"INSERT INTO Nhuanbut (Maso, Tenbai, Trang, Muc, TienNhuanbut, Butdanh, MsBao, Vung, VungChuyenDen, addby, ngaychuyen, STT) 
                                             VALUES (@ma, @ten, @trang, @muc, @tien, @bd, @msBao, @vung, @vungCD, @user, GETDATE(), @stt)";

                        using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", "NB" + DateTime.Now.ToString("HHmmss"));
                            cmd.Parameters.AddWithValue("@ten", txtTenBai.Text.Trim());
                            cmd.Parameters.AddWithValue("@trang", txtTrang.Text.Trim());
                            cmd.Parameters.AddWithValue("@muc", txtMuc.Text.Trim());
                            cmd.Parameters.AddWithValue("@tien", tien);
                            cmd.Parameters.AddWithValue("@bd", cboButDanh.Text);
                            cmd.Parameters.AddWithValue("@msBao", cboSoBao.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@vung", cboVung.Text);
                            cmd.Parameters.AddWithValue("@vungCD", cboVungChuyenDen.Text);
                            cmd.Parameters.AddWithValue("@user", NguoiDangNhap ?? "Admin");
                            cmd.Parameters.AddWithValue("@stt", dgvNhuanBut.Rows.Count + 1);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    else // CẬP NHẬT
                    {
                        string updateSql = @"UPDATE Nhuanbut SET Tenbai=@ten, Trang=@trang, Muc=@muc, TienNhuanbut=@tien, 
                                             Butdanh=@bd, Vung=@vung, VungChuyenDen=@vungCD, addby=@user, ngaychuyen=GETDATE() 
                                             WHERE Maso=@ma";
                        using (SqlCommand cmd = new SqlCommand(updateSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                            cmd.Parameters.AddWithValue("@ten", txtTenBai.Text.Trim());
                            cmd.Parameters.AddWithValue("@trang", txtTrang.Text.Trim());
                            cmd.Parameters.AddWithValue("@muc", txtMuc.Text.Trim());
                            cmd.Parameters.AddWithValue("@tien", tien);
                            cmd.Parameters.AddWithValue("@bd", cboButDanh.Text);
                            cmd.Parameters.AddWithValue("@vung", cboVung.Text);
                            cmd.Parameters.AddWithValue("@vungCD", cboVungChuyenDen.Text);
                            cmd.Parameters.AddWithValue("@user", NguoiDangNhap ?? "Admin");
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }
                MessageBox.Show("Lưu nhuận bút vào SQL thành công!");
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
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearInputs();

        private void ClearInputs()
        {
            _selectedMaso = null;
            txtTenBai.Clear(); txtTrang.Clear(); txtMuc.Clear(); txtTienNhuanBut.Clear();
            cboVung.SelectedIndex = -1; cboVungChuyenDen.SelectedIndex = -1;
            txtTenBai.Focus();
        }
    }
}