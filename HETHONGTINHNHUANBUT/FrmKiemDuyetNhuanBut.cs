using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmKiemDuyetNhuanBut : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        private string _selectedMaso = "";
        private int _trangThaiHienTai = 0;

        public string QuyenHienTai { get; set; }
        public string NguoiDangNhap { get; set; }

        public FrmKiemDuyetNhuanBut()
        {
            InitializeComponent();

            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvNhuanBut, true, null);
        }

        private async void FrmKiemDuyetNhuanBut_Load(object sender, EventArgs e)
        {
            string role = QuyenHienTai?.Trim().ToLower() ?? "";

            if (role == "thư ký" || role == "admin" || role == "quản trị viên")
            {
                _trangThaiHienTai = 0;
                lblRoleInfo.Text = "👤 Thư ký: Duyệt nội dung bài viết";
                lblRoleInfo.ForeColor = Color.FromArgb(245, 158, 11);
                btnXacNhan.Text = "✅ DUYỆT NỘI DUNG";
                btnXacNhan.FillColor = Color.FromArgb(16, 185, 129);
                btnTuChoi.Visible = true;
                lblTien.Visible = false;
                txtTienNhuanBut.Visible = false;
            }
            else if (role == "kế toán")
            {
                _trangThaiHienTai = 1;
                lblRoleInfo.Text = "👤 Kế toán: Tính tiền nhuận bút";
                lblRoleInfo.ForeColor = Color.FromArgb(59, 130, 246);
                btnXacNhan.Text = "✅ XÁC NHẬN TIỀN";
                btnXacNhan.FillColor = Color.FromArgb(59, 130, 246);
                btnTuChoi.Visible = true;
                btnTuChoi.Text = "❌ TRẢ VỀ THƯ KÝ";
                lblTien.Visible = true;
                txtTienNhuanBut.Visible = true;
            }
            else if (role == "lãnh đạo")
            {
                _trangThaiHienTai = 2;
                lblRoleInfo.Text = "👤 Lãnh đạo: Ký duyệt xuất bản";
                lblRoleInfo.ForeColor = Color.FromArgb(79, 70, 229);
                btnXacNhan.Text = "✅ KÝ DUYỆT XUẤT BẢN";
                btnXacNhan.FillColor = Color.FromArgb(79, 70, 229);
                btnTuChoi.Visible = true;
                btnTuChoi.Text = "❌ TRẢ VỀ KẾ TOÁN";
                lblTien.Visible = false;
                txtTienNhuanBut.Visible = false;
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Đặt lại anchor cho các nút
            btnXacNhan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTuChoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            await LoadDataAsync("");
        }

        private async Task LoadDataAsync(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                        SELECT n.Maso, n.Tenbai, n.Trang, n.Muc, n.Butdanh, 
                       n.TienNhuanbut,
                                n.NguoiNhap, n.NguoiKiemTra, n.NguoiKeToan,
                               b.Tenbao AS TenSoBao
                        FROM Nhuanbut n
                        LEFT JOIN Bao b ON n.MsBao = b.Maso
                        WHERE n.TrangThaiDuyet = @tt";

                    if (!string.IsNullOrWhiteSpace(keyword))
                        query += " AND (n.Tenbai LIKE @kw OR n.Butdanh LIKE @kw OR n.NguoiNhap LIKE @kw)";

                    query += " ORDER BY n.ngaychuyen DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tt", _trangThaiHienTai);
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                        dgvNhuanBut.DataSource = dt;

                        if (dgvNhuanBut.Columns.Count > 0)
                        {
                            if (dgvNhuanBut.Columns["Maso"] != null) dgvNhuanBut.Columns["Maso"].Visible = false;
                            if (dgvNhuanBut.Columns["Tenbai"] != null) { dgvNhuanBut.Columns["Tenbai"].HeaderText = "Tên Bài"; dgvNhuanBut.Columns["Tenbai"].FillWeight = 3; dgvNhuanBut.Columns["Tenbai"].MinimumWidth = 200; }
                            if (dgvNhuanBut.Columns["Trang"] != null) { dgvNhuanBut.Columns["Trang"].HeaderText = "Trang"; dgvNhuanBut.Columns["Trang"].FillWeight = 1; dgvNhuanBut.Columns["Trang"].MinimumWidth = 60; }
                            if (dgvNhuanBut.Columns["Muc"] != null) { dgvNhuanBut.Columns["Muc"].HeaderText = "Mục"; dgvNhuanBut.Columns["Muc"].FillWeight = 1; dgvNhuanBut.Columns["Muc"].MinimumWidth = 60; }
                            if (dgvNhuanBut.Columns["Butdanh"] != null) { dgvNhuanBut.Columns["Butdanh"].HeaderText = "Bút Danh"; dgvNhuanBut.Columns["Butdanh"].FillWeight = 1; dgvNhuanBut.Columns["Butdanh"].MinimumWidth = 80; }
                            if (dgvNhuanBut.Columns["TienNhuanbut"] != null) { dgvNhuanBut.Columns["TienNhuanbut"].HeaderText = "Tiền NB"; dgvNhuanBut.Columns["TienNhuanbut"].DefaultCellStyle.Format = "N0"; dgvNhuanBut.Columns["TienNhuanbut"].FillWeight = 1; dgvNhuanBut.Columns["TienNhuanbut"].MinimumWidth = 80; }

                            if (dgvNhuanBut.Columns["NguoiNhap"] != null) { dgvNhuanBut.Columns["NguoiNhap"].Visible = false; }
                            if (dgvNhuanBut.Columns["NguoiKiemTra"] != null) { dgvNhuanBut.Columns["NguoiKiemTra"].Visible = false; }
                            if (dgvNhuanBut.Columns["NguoiKeToan"] != null) { dgvNhuanBut.Columns["NguoiKeToan"].Visible = false; }
                            if (dgvNhuanBut.Columns["TenSoBao"] != null) { dgvNhuanBut.Columns["TenSoBao"].HeaderText = "Số Báo"; dgvNhuanBut.Columns["TenSoBao"].FillWeight = 2; dgvNhuanBut.Columns["TenSoBao"].MinimumWidth = 120; }
                        }
                        lblCount.Text = $"📋 Tổng số: {dt.Rows.Count} bài chờ duyệt";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataAsync(txtTimKiem.Text.Trim());
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso))
            {
                MessageBox.Show("Vui lòng chọn một bài viết để duyệt!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            string action = "";
            int trangThaiMoi = 0;

            if (role == "thư ký" || role == "admin" || role == "quản trị viên")
            {
                action = "duyệt nội dung";
                trangThaiMoi = 1;
            }
            else if (role == "kế toán")
            {
                action = "xác nhận tiền";
                trangThaiMoi = 2;
            }
            else if (role == "lãnh đạo")
            {
                action = "ký duyệt";
                trangThaiMoi = 3;
            }

            string msg = $"Xác nhận {action} cho bài viết này?";

            // AI phát hiện bất thường trước khi duyệt
            if (dgvNhuanBut.CurrentRow != null)
            {
                string tenBai = dgvNhuanBut.CurrentRow.Cells["Tenbai"].Value?.ToString() ?? "";
                string butDanh = dgvNhuanBut.CurrentRow.Cells["Butdanh"].Value?.ToString() ?? "";
                string muc = dgvNhuanBut.CurrentRow.Cells["Muc"].Value?.ToString() ?? "";
                decimal tien = 0;
                if (dgvNhuanBut.CurrentRow.Cells["TienNhuanbut"].Value != null)
                    decimal.TryParse(dgvNhuanBut.CurrentRow.Cells["TienNhuanbut"].Value.ToString(), out tien);

                var batThuong = await AnomalyDetector.KiemTraAsync(tenBai, butDanh, muc, tien, "", "", _selectedMaso);

                if (batThuong.CoBatThuong)
                {
                    string canhBaoText = string.Join("\n", batThuong.CanhBao);
                    if (batThuong.MucDo == AnomalyDetector.MucDo.NghiemTrong)
                    {
                        var xacNhan = MessageBox.Show(
                            "🚨 PHÁT HIỆN BẤT THƯỜNG NGHIÊM TRỌNG:\n" + canhBaoText +
                            "\n\nVẫn tiếp tục duyệt?", "Cảnh báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (xacNhan == DialogResult.No) return;
                    }
                    else
                    {
                        msg += "\n\n⚠️ Cảnh báo:\n" + canhBaoText;
                    }
                }
            }

            if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();

                        if (role == "thư ký" || role == "admin" || role == "quản trị viên")
                        {
                            string sql = @"UPDATE Nhuanbut SET 
                                           TrangThaiDuyet = @tt, 
                                           NguoiKiemTra = @nguoi 
                                           WHERE Maso = @ma";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@tt", trangThaiMoi);
                                cmd.Parameters.AddWithValue("@nguoi", NguoiDangNhap ?? "Thư ký");
                                cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                        else if (role == "kế toán")
                        {
                            decimal tienNB = decimal.TryParse(txtTienNhuanBut.Text, out decimal t) ? t : 0;
                            string sql = @"UPDATE Nhuanbut SET 
                                           TrangThaiDuyet = @tt, 
                                           TienNhuanbut = @tien,
                                           NguoiKeToan = @nguoi 
                                           WHERE Maso = @ma";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@tt", trangThaiMoi);
                                cmd.Parameters.AddWithValue("@tien", tienNB);
                                cmd.Parameters.AddWithValue("@nguoi", NguoiDangNhap ?? "Kế toán");
                                cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                        else if (role == "lãnh đạo")
                        {
                            string sql = @"UPDATE Nhuanbut SET 
                                           TrangThaiDuyet = @tt, 
                                           TongThuKy = @nguoi 
                                           WHERE Maso = @ma";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@tt", trangThaiMoi);
                                cmd.Parameters.AddWithValue("@nguoi", NguoiDangNhap ?? "Lãnh đạo");
                                cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                    }

                    MessageBox.Show($"Đã {action} thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _selectedMaso = "";
                    txtTienNhuanBut.Text = "0";
                    await LoadDataAsync(txtTimKiem.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private async void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedMaso))
            {
                MessageBox.Show("Vui lòng chọn bài viết cần trả về!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            string msg = "";
            int trangThaiVe = 0;
            string action = "";

            if (role == "thư ký" || role == "admin" || role == "quản trị viên")
            {
                msg = "Trả bài này về cho Phóng viên sửa?";
                trangThaiVe = 0;
                action = "trả về Phóng viên";
            }
            else if (role == "kế toán")
            {
                msg = "Trả bài này về cho Thư ký?";
                trangThaiVe = 0;
                action = "trả về Thư ký";
            }
            else if (role == "lãnh đạo")
            {
                msg = "Trả bài này về cho Kế toán tính lại tiền?";
                trangThaiVe = 1;
                action = "trả về Kế toán";
            }

            if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();
                        string sql = "UPDATE Nhuanbut SET TrangThaiDuyet = @tt WHERE Maso = @ma";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@tt", trangThaiVe);
                            cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    MessageBox.Show($"Đã {action}!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _selectedMaso = "";
                    await LoadDataAsync(txtTimKiem.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void dgvNhuanBut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNhuanBut.CurrentRow != null)
            {
                _selectedMaso = dgvNhuanBut.Rows[e.RowIndex].Cells["Maso"].Value?.ToString();
                string role = QuyenHienTai?.Trim().ToLower() ?? "";
                if (role == "kế toán" && dgvNhuanBut.Rows[e.RowIndex].Cells["TienNhuanbut"].Value != null)
                {
                    txtTienNhuanBut.Text = Convert.ToDecimal(dgvNhuanBut.Rows[e.RowIndex].Cells["TienNhuanbut"].Value).ToString("0");
                }
            }
        }

        private void txtTienNhuanBut_TextChanged(object sender, EventArgs e)
        {
            // Không cần xử lý
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTien_Click(object sender, EventArgs e)
        {

        }
    }
}