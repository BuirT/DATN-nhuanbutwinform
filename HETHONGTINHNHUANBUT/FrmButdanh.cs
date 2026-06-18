using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.Models;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmButDanh : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public string QuyenHienTai { get; set; }

        public FrmButDanh()
        {
            InitializeComponent();

            // Ép xung bộ đệm kép đồ họa cho bảng lưới để scroll chuột mượt mà 100%
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvButDanh, true, null);
        }

        private async void FrmButDanh_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvButDanh);
            await LoadComboBoxTacGiaSQL();
            await LoadDataSQLAsync();
            PhanQuyenThaoTac();
        }

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
                cboTacGia.DisplayMember = "Hoten";
                cboTacGia.ValueMember = "Maso";
                cboTacGia.DataSource = dt;
                cboTacGia.DropDownHeight = 200;
                cboTacGia.IntegralHeight = true;
                cboTacGia.MaxDropDownItems = 15;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách tác giả SQL: " + ex.Message); }
        }

        // ĐÃ THÊM: Tính năng load dữ liệu có kèm từ khóa tìm kiếm
        private async Task LoadDataSQLAsync(string keyword = "")
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT b.Maso, b.Butdanh, b.MsTacgia, t.Hoten 
                                     FROM Butdanh b 
                                     LEFT JOIN TacGia t ON b.MsTacgia = t.Maso ";

                    // Mở rộng câu query nếu có từ khóa tìm kiếm
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query += " WHERE b.Maso LIKE @kw OR b.Butdanh LIKE @kw OR t.Hoten LIKE @kw ";
                    }

                    query += " ORDER BY b.Maso DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");

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

                foreach (DataGridViewColumn col in dgvButDanh.Columns)
                {
                    col.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
                    col.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
                }

                dgvButDanh.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu Bút danh SQL: " + ex.Message); }
        }

        // ĐÃ THÊM: Bắt sự kiện người dùng gõ vào ô tìm kiếm
        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataSQLAsync(txtTimKiem.Text);
        }

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
            txtTimKiem.Clear(); // Xóa luôn khung tìm kiếm
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