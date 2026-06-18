using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmSoBao : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        private string _tenNguoiDung;
        private string _selectedMaso = "";
        public string QuyenHienTai { get; set; }

        public FrmSoBao(string tenNguoiDung = "Admin")
        {
            InitializeComponent();
            _tenNguoiDung = tenNguoiDung;
        }

        private async void FrmSoBao_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvSoBao);
            // 1. Tải danh sách loại báo từ bảng Bao (không phụ thuộc bảng LoaiBao)
            await LoadLoaiBaoAsync();

            // 2. Chọn mục đầu tiên làm mặc định nếu có dữ liệu
            if (cboLoaiBao.Items.Count > 0) cboLoaiBao.SelectedIndex = 0;

            // 3. Tải dữ liệu bảng Bao
            await LoadDataSQLAsync();

            // 4. Phân quyền
            PhanQuyenThaoTac();
        }

        // Hàm tải danh sách Loại Báo từ bảng Bao (Dùng DISTINCT để lấy các giá trị duy nhất)
        private async Task LoadLoaiBaoAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT DISTINCT Loaibao FROM Bao WHERE Loaibao IS NOT NULL AND Loaibao != '' ORDER BY Loaibao";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        cboLoaiBao.Items.Clear();
                        while (await reader.ReadAsync())
                        {
                            string loai = reader["Loaibao"].ToString();
                            if (!string.IsNullOrWhiteSpace(loai))
                            {
                                cboLoaiBao.Items.Add(loai);
                            }
                        }
                    }
                }
                cboLoaiBao.DropDownHeight = 200;
                cboLoaiBao.IntegralHeight = true;
                cboLoaiBao.MaxDropDownItems = 15;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách loại báo: " + ex.Message);
            }
        }

        private void PhanQuyenThaoTac()
        {
            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            bool coQuyen = (role == "thư ký" || role == "admin" || role == "quản trị viên");
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnKhoaSo.Enabled = coQuyen;
        }

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
                        query += " WHERE Maso LIKE @kw OR Tenbao LIKE @kw OR Sobao LIKE @kw";

                    query += " ORDER BY Ngayra DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                            dt.Load(reader);
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu SQL: " + ex.Message);
            }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataSQLAsync(txtTimKiem.Text);
        }

        // Hàm lấy độ dài tối đa của cột từ SQL
        private async Task<int?> GetMaxLengthAsync(string columnName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                        SELECT CHARACTER_MAXIMUM_LENGTH 
                        FROM INFORMATION_SCHEMA.COLUMNS 
                        WHERE TABLE_NAME = 'Bao' AND COLUMN_NAME = @col";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                        cmd.Parameters.AddWithValue("@col", columnName);
                        object result = await cmd.ExecuteScalarAsync();
                        if (result != DBNull.Value && result != null)
                            return Convert.ToInt32(result);
                        else
                            return null;
                    }
                }
            }
            catch { return null; }
        }

        private async Task<string> TrimToColumnLengthAsync(string value, string columnName)
        {
            if (string.IsNullOrEmpty(value)) return value;
            int? maxLen = await GetMaxLengthAsync(columnName);
            if (maxLen.HasValue && maxLen.Value > 0 && value.Length > maxLen.Value)
            {
                string trimmed = value.Substring(0, maxLen.Value);
                MessageBox.Show($"Dữ liệu ở cột '{columnName}' bị cắt từ {value.Length} xuống {maxLen.Value} ký tự.\nGiá trị sau cắt: {trimmed}",
                                "Cảnh báo cắt dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return trimmed;
            }
            return value;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaso.Text) || string.IsNullOrWhiteSpace(txtTenBao.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã số và Tên báo!");
                return;
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
                            MessageBox.Show("Mã số báo này đã tồn tại!");
                            return;
                        }
                    }

                    // Tự động cắt dữ liệu theo độ dài cột
                    string maSo = await TrimToColumnLengthAsync(txtMaso.Text.Trim(), "Maso");
                    string tenBao = await TrimToColumnLengthAsync(txtTenBao.Text.Trim(), "Tenbao");
                    string soBao = await TrimToColumnLengthAsync(txtSoBao.Text.Trim(), "Sobao");
                    string soBo = await TrimToColumnLengthAsync(txtSoBo.Text.Trim(), "Sobo");
                    string loaiBao = cboLoaiBao.Text;

                    // Chỉ lưu vào bảng Bao, không lưu vào bảng LoaiBao (tránh lỗi)
                    string sql = @"INSERT INTO Bao (Maso, Tenbao, Ngayra, Sobao, Sobo, Loaibao, DaDuyet) 
                                   VALUES (@ma, @ten, @ngay, @so, @bo, @loai, 'N')";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                        cmd.Parameters.AddWithValue("@ma", maSo);
                        cmd.Parameters.AddWithValue("@ten", tenBao);
                        cmd.Parameters.AddWithValue("@ngay", dtpNgayRa.Value);
                        cmd.Parameters.AddWithValue("@so", soBao);
                        cmd.Parameters.AddWithValue("@bo", soBo);
                        cmd.Parameters.AddWithValue("@loai", loaiBao);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Thêm kỳ báo thành công!");

                // Load lại dữ liệu cho ComboBox và DataGridView để đồng bộ
                await LoadLoaiBaoAsync();
                await LoadDataSQLAsync();
                btnLamMoi_Click(null, null);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("String or binary data would be truncated"))
                    MessageBox.Show("Lỗi: Dữ liệu nhập vào vẫn quá dài. Hãy kiểm tra lại cột 'Sobao' và 'Sobo' trong CSDL.");
                else
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso))
            {
                MessageBox.Show("Vui lòng chọn kỳ báo cần sửa!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string tenBao = await TrimToColumnLengthAsync(txtTenBao.Text.Trim(), "Tenbao");
                    string soBao = await TrimToColumnLengthAsync(txtSoBao.Text.Trim(), "Sobao");
                    string soBo = await TrimToColumnLengthAsync(txtSoBo.Text.Trim(), "Sobo");
                    string loaiBao = cboLoaiBao.Text;

                    string sql = @"UPDATE Bao SET Tenbao=@ten, Ngayra=@ngay, Sobao=@so, Sobo=@bo, Loaibao=@loai 
                                   WHERE Maso=@ma";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                        cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                        cmd.Parameters.AddWithValue("@ten", tenBao);
                        cmd.Parameters.AddWithValue("@ngay", dtpNgayRa.Value);
                        cmd.Parameters.AddWithValue("@so", soBao);
                        cmd.Parameters.AddWithValue("@bo", soBo);
                        cmd.Parameters.AddWithValue("@loai", loaiBao);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("Cập nhật thành công!");
                await LoadLoaiBaoAsync(); // Cập nhật ComboBox
                await LoadDataSQLAsync();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("String or binary data would be truncated"))
                    MessageBox.Show("Lỗi cập nhật: Dữ liệu vượt quá độ dài cột. Hãy rút ngắn Số báo hoặc Số bộ.");
                else
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso))
            {
                MessageBox.Show("Vui lòng chọn kỳ báo cần xóa!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa kỳ báo này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private async void btnKhoaSo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso))
            {
                MessageBox.Show("Chọn 1 kỳ báo để Khóa/Mở sổ!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khóa sổ: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _selectedMaso = "";
            txtMaso.Clear();
            txtTenBao.Clear();
            txtSoBao.Clear();
            txtSoBo.Clear();
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

                // Gán trực tiếp giá trị từ database để ComboBox hiển thị đúng
                cboLoaiBao.Text = row.Cells["Loaibao"].Value?.ToString() ?? "";

                if (DateTime.TryParse(row.Cells["Ngayra"].Value?.ToString(), out DateTime dt))
                    dtpNgayRa.Value = dt;

                string trangThai = row.Cells["TinhTrang"].Value?.ToString();
                if (trangThai == "🔒 Đã khóa sổ")
                {
                    btnKhoaSo.Text = "🔓 MỞ KHÓA SỔ";
                    btnKhoaSo.FillColor = Color.FromArgb(239, 68, 68);
                }
                else
                {
                    btnKhoaSo.Text = "🔒 KHÓA SỔ BÁO";
                    btnKhoaSo.FillColor = Color.FromArgb(16, 185, 129);
                }
            }
        }
    }
}
