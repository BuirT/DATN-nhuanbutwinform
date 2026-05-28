using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmLoaiBao : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmLoaiBao()
        {
            InitializeComponent();
        }

        private void FrmLoaiBao_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData() 
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Maso, Tenloai FROM LoaiBao ORDER BY Maso";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLoaiBao.DataSource = dt;

                    if (dgvLoaiBao.Columns.Count > 0)
                    {
                        dgvLoaiBao.Columns["Maso"].HeaderText = "Mã loại báo";
                        dgvLoaiBao.Columns["Tenloai"].HeaderText = "Tên loại báo";
                        dgvLoaiBao.Columns["Maso"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvLoaiBao.Columns["Tenloai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaso.Text) || string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã loại báo và Tên loại báo!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    conn.Open();

                    // Kiểm tra trùng mã
                    string checkSql = "SELECT COUNT(*) FROM LoaiBao WHERE Maso = @ma";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ma", txtMaso.Text.Trim());
                        if ((int)checkCmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Mã loại báo này đã tồn tại!");
                            return;
                        }
                    }

                    // Thêm mới
                    string sql = "INSERT INTO LoaiBao (Maso, Tenloai) VALUES (@ma, @ten)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", txtMaso.Text.Trim());
                        cmd.Parameters.AddWithValue("@ten", txtTenLoai.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm loại báo thành công!");
                LoadData();
                txtMaso.Clear();
                txtTenLoai.Clear();
                txtMaso.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLoaiBao.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một loại báo để sửa!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mới!");
                return;
            }

            try
            {
                string maSoCu = dgvLoaiBao.SelectedRows[0].Cells["Maso"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    conn.Open();

                    // Kiểm tra trùng mã nếu người dùng đổi mã
                    if (txtMaso.Text.Trim() != maSoCu)
                    {
                        string checkSql = "SELECT COUNT(*) FROM LoaiBao WHERE Maso = @ma";
                        using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@ma", txtMaso.Text.Trim());
                            if ((int)checkCmd.ExecuteScalar() > 0)
                            {
                                MessageBox.Show("Mã loại báo mới đã tồn tại!");
                                return;
                            }
                        }
                    }

                    string sql = "UPDATE LoaiBao SET Maso = @maMoi, Tenloai = @ten WHERE Maso = @maCu";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@maMoi", txtMaso.Text.Trim());
                        cmd.Parameters.AddWithValue("@ten", txtTenLoai.Text.Trim());
                        cmd.Parameters.AddWithValue("@maCu", maSoCu);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật thành công!");
                LoadData();
                txtMaso.Clear();
                txtTenLoai.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoaiBao.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một loại báo để xóa!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa loại báo này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string maSo = dgvLoaiBao.SelectedRows[0].Cells["Maso"].Value.ToString();

                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        conn.Open();

                        // Kiểm tra xem loại báo có đang được dùng trong bảng Bao không
                        string checkUsage = "SELECT COUNT(*) FROM Bao WHERE Loaibao = @ma";
                        using (SqlCommand checkCmd = new SqlCommand(checkUsage, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@ma", maSo);
                            if ((int)checkCmd.ExecuteScalar() > 0)
                            {
                                MessageBox.Show("Không thể xóa! Loại báo này đang được sử dụng trong bảng Bao.");
                                return;
                            }
                        }

                        string sql = "DELETE FROM LoaiBao WHERE Maso = @ma";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@ma", maSo);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    txtMaso.Clear();
                    txtTenLoai.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaso.Clear();
            txtTenLoai.Clear();
            LoadData();
        }

        private void dgvLoaiBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaso.Text = dgvLoaiBao.Rows[e.RowIndex].Cells["Maso"].Value?.ToString();
                txtTenLoai.Text = dgvLoaiBao.Rows[e.RowIndex].Cells["Tenloai"].Value?.ToString();
            }
        }
    }
}