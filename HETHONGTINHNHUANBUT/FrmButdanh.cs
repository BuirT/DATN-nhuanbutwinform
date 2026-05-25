using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection; // ĐÃ THÊM: Để kích hoạt đệm kép phần cứng chống lag
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmButDanh : Form
    {
        // --- CHUỖI KẾT NỐI SQL SERVER CHUẨN MÁY ĐỒNG CHÍ ---
        private readonly string sqlConnectionString = @"Server=LAPTOP-5O9OTMIJ\SQLEXPRESS;Database=TN;Trusted_Connection=True;";

        public string QuyenHienTai { get; set; }

        public FrmButDanh()
        {
            InitializeComponent();

            // ĐÃ THÊM: Ép xung bộ đệm kép đồ họa cho bảng lưới để scroll chuột mượt mà 100%, không bị giật lag khi data lớn
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvButDanh, true, null);
        }

        private async void FrmButDanh_Load(object sender, EventArgs e)
        {
            // Làm đẹp giao diện bảng tĩnh
            FormatGiaoDienBang();

            // Load dữ liệu
            await LoadComboBoxTacGiaSQL();
            await LoadDataSQLAsync();

            // Phân quyền tác vụ
            PhanQuyenThaoTac();
        }

        private void FormatGiaoDienBang()
        {
            // Định dạng thanh tiêu đề cột nhã nhặn, chuẩn light-theme phẳng của Flowty
            dgvButDanh.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvButDanh.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvButDanh.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvButDanh.EnableHeadersVisualStyles = false;

            // Định dạng màu nền tĩnh chẵn lẻ cho các dòng bảng dữ liệu
            dgvButDanh.DefaultCellStyle.BackColor = Color.White;
            dgvButDanh.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvButDanh.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvButDanh.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);

            // CẤU HÌNH MÀU CHỌN DÒNG PASTEL CAO CẤP: Phản hồi xanh dương nhạt dịu mắt, chữ tối đen Slate rõ nét
            Color selectedBg = Color.FromArgb(232, 240, 254);
            Color selectedFg = Color.FromArgb(15, 23, 42);

            dgvButDanh.DefaultCellStyle.SelectionBackColor = selectedBg;
            dgvButDanh.DefaultCellStyle.SelectionForeColor = selectedFg;
            dgvButDanh.AlternatingRowsDefaultCellStyle.SelectionBackColor = selectedBg;
            dgvButDanh.AlternatingRowsDefaultCellStyle.SelectionForeColor = selectedFg;

            // Đồng bộ trực tiếp vào bộ nhớ render Style nội bộ của Guna UI2 tránh lỗi ghi đè màu runtime
            dgvButDanh.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvButDanh.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvButDanh.ThemeStyle.RowsStyle.SelectionBackColor = selectedBg;
            dgvButDanh.ThemeStyle.RowsStyle.SelectionForeColor = selectedFg;

            dgvButDanh.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvButDanh.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvButDanh.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = selectedBg;
            dgvButDanh.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = selectedFg;

            dgvButDanh.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvButDanh.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(71, 85, 105);

            dgvButDanh.RowTemplate.Height = 38;
        }

        // =======================================================
        // 1. LOAD DANH SÁCH TÁC GIẢ VÀO COMBOBOX (SQL)
        // =======================================================
        private async Task LoadComboBoxTacGiaSQL()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT Maso, Hoten FROM TacGia ORDER BY Hoten";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync()) { dt.Load(reader); }
                    }
                }
                cboTacGia.DataSource = dt;
                cboTacGia.DisplayMember = "Hoten";
                cboTacGia.ValueMember = "Maso";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách tác giả SQL: " + ex.Message); }
        }

        // =======================================================
        // 2. LOAD DANH SÁCH BÚT DANH (SQL)
        // =======================================================
        private async Task LoadDataSQLAsync()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT b.Maso, b.Butdanh, b.MsTacgia, t.Hoten 
                                     FROM Butdanh b 
                                     LEFT JOIN TacGia t ON b.MsTacgia = t.Maso 
                                     ORDER BY b.Maso DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync()) { dt.Load(reader); }
                    }
                }
                dgvButDanh.DataSource = dt;

                if (dgvButDanh.Columns.Count > 0)
                {
                    dgvButDanh.Columns["Maso"].HeaderText = "MÃ SỐ";
                    dgvButDanh.Columns["Butdanh"].HeaderText = "BÚT DANH HIỂN THỊ";
                    dgvButDanh.Columns["MsTacgia"].HeaderText = "MÃ TÁC GIẢ";
                    dgvButDanh.Columns["Hoten"].HeaderText = "TÊN TÁC GIẢ CHỦ QUẢN";
                }

                // CHỐT CHẶN BẤT TỬ: Quét qua toàn bộ đống cột vừa được tự động sinh ra khi gán dữ liệu động để khóa màu chọn pastel
                // Triệt tiêu hoàn toàn 100% lỗi nhảy màu xanh Windows thô kệch khi click chuột
                foreach (DataGridViewColumn col in dgvButDanh.Columns)
                {
                    col.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
                    col.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
                }

                dgvButDanh.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu Bút danh SQL: " + ex.Message); }
        }

        // =======================================================
        // 3. THÊM MỚI BÚT DANH (SQL)
        // =======================================================
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaso.Text) || string.IsNullOrWhiteSpace(txtButDanh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã số và Tên bút danh nhé!"); return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    string checkQuery = "SELECT COUNT(*) FROM Butdanh WHERE Maso = @ma OR Butdanh = @ten";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ma", txtMaso.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@ten", txtButDanh.Text.Trim());
                        if ((int)await checkCmd.ExecuteScalarAsync() > 0)
                        {
                            MessageBox.Show("Mã số hoặc Tên bút danh này đã tồn tại trong hệ thống!"); return;
                        }
                    }

                    string insertQuery = "INSERT INTO Butdanh (Maso, Butdanh, MsTacgia) VALUES (@ma, @ten, @msTG)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", txtMaso.Text.Trim());
                        cmd.Parameters.AddWithValue("@ten", txtButDanh.Text.Trim());
                        cmd.Parameters.AddWithValue("@msTG", cboTacGia.SelectedValue.ToString());
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Thêm Bút danh thành công!");
                await LoadDataSQLAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        // =======================================================
        // 4. CẬP NHẬT BÚT DANH (SQL)
        // =======================================================
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvButDanh.CurrentRow == null) { MessageBox.Show("Vui lòng chọn một bút danh dưới bảng lưới!"); return; }
            string maCu = dgvButDanh.CurrentRow.Cells["Maso"].Value.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string updateQuery = "UPDATE Butdanh SET Butdanh = @ten, MsTacgia = @msTG WHERE Maso = @ma";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maCu);
                        cmd.Parameters.AddWithValue("@ten", txtButDanh.Text.Trim());
                        cmd.Parameters.AddWithValue("@msTG", cboTacGia.SelectedValue.ToString());
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Cập nhật thông tin bút danh thành công!");
                await LoadDataSQLAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa: " + ex.Message); }
        }

        // =======================================================
        // 5. XÓA BÚT DANH (SQL)
        // =======================================================
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvButDanh.CurrentRow == null) { MessageBox.Show("Vui lòng chọn bút danh cần xóa!"); return; }
            if (MessageBox.Show("Xác nhận xóa bút danh này khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();
                        string deleteQuery = "DELETE FROM Butdanh WHERE Maso = @ma";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", dgvButDanh.CurrentRow.Cells["Maso"].Value.ToString());
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    await LoadDataSQLAsync();
                    btnLamMoi_Click(null, null);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaso.Clear();
            txtButDanh.Clear();
            if (cboTacGia.Items.Count > 0) cboTacGia.SelectedIndex = 0;
            txtMaso.Focus();
        }

        private void dgvButDanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvButDanh.Rows[e.RowIndex];
                txtMaso.Text = row.Cells["Maso"].Value?.ToString();
                txtButDanh.Text = row.Cells["Butdanh"].Value?.ToString();

                string maTacGia = row.Cells["MsTacgia"].Value?.ToString();
                if (!string.IsNullOrEmpty(maTacGia)) cboTacGia.SelectedValue = maTacGia;
            }
        }

        private void PhanQuyenThaoTac()
        {
            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            bool coQuyen = !(role == "lãnh đạo" || role == "kế toán");
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = coQuyen;
        }
    }
}