using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // DÙNG SQL SERVER
using System.Drawing;
using System.Linq;
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
        }

        private async void FrmButDanh_Load(object sender, EventArgs e)
        {
            // Làm đẹp giao diện bảng
            FormatGiaoDienBang();

            // Load dữ liệu
            await LoadComboBoxTacGiaSQL();
            await LoadDataSQLAsync();

            // Phân quyền
            PhanQuyenThaoTac();
        }

        private void FormatGiaoDienBang()
        {
            dgvButDanh.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvButDanh.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvButDanh.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvButDanh.EnableHeadersVisualStyles = false;
            dgvButDanh.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 245, 250);
            dgvButDanh.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvButDanh.DefaultCellStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvButDanh.RowTemplate.Height = 40;
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
                    // Join với bảng TacGia để hiện tên tác giả cho dễ nhìn
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
                    dgvButDanh.Columns["Butdanh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvButDanh.Columns["MsTacgia"].HeaderText = "MÃ TÁC GIẢ";
                    dgvButDanh.Columns["Hoten"].HeaderText = "TÊN TÁC GIẢ CHỦ QUẢN";
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
                MessageBox.Show("Nhập đủ Mã số và Bút danh giúp Thanh nhé!"); return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    // Kiểm tra trùng mã hoặc trùng tên bút danh
                    string checkQuery = "SELECT COUNT(*) FROM Butdanh WHERE Maso = @ma OR Butdanh = @ten";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ma", txtMaso.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@ten", txtButDanh.Text.Trim());
                        if ((int)await checkCmd.ExecuteScalarAsync() > 0)
                        {
                            MessageBox.Show("Mã số hoặc Tên bút danh này đã tồn tại trong SQL!"); return;
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
                MessageBox.Show("Thêm Bút danh vào SQL thành công!");
                await LoadDataSQLAsync();
                btnLamMoi_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm SQL: " + ex.Message); }
        }

        // =======================================================
        // 4. CẬP NHẬT BÚT DANH (SQL)
        // =======================================================
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvButDanh.CurrentRow == null) return;
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
                MessageBox.Show("Cập nhật SQL thành công!");
                await LoadDataSQLAsync();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi sửa SQL: " + ex.Message); }
        }

        // =======================================================
        // 5. XÓA BÚT DANH (SQL)
        // =======================================================
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvButDanh.CurrentRow == null) return;
            if (MessageBox.Show("Xóa bút danh này khỏi SQL Server?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                catch (Exception ex) { MessageBox.Show("Lỗi xóa SQL: " + ex.Message); }
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