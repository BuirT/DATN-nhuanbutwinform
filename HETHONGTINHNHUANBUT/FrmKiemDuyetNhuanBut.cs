using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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

        private Label lblSigNguoiNhap, lblSigNguoiCham, lblSigNhapLieu, lblSigKiemTra, lblSigTongThuKy;
        private Guna.UI2.WinForms.Guna2Panel pnlSignature;
        private Guna.UI2.WinForms.Guna2Panel pnlSignatureContainer;
        private Guna.UI2.WinForms.Guna2TextBox txtNguoiKy;
        private Label lblNguoiKy;

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
            CreateSignaturePanel();
            SetupRoleUI();

            if (string.IsNullOrEmpty(QuyenHienTai?.Trim()))
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

        private void SetupRoleUI()
        {
            string role = QuyenHienTai?.Trim().ToLower() ?? "";

            // Reset visibility
            lblTien.Visible = false;
            txtTienNhuanBut.Visible = false;
            btnTuChoi.Visible = true;
            if (txtNguoiKy != null) txtNguoiKy.Visible = false;
            if (lblNguoiKy != null) lblNguoiKy.Visible = false;

            switch (role)
            {
                case "thư ký":
                    _trangThaiHienTai = 0;
                    lblRoleInfo.Text = "👤 Thư ký (Ban thư ký): Chấm tiền nhuận bút";
                    lblRoleInfo.ForeColor = Color.FromArgb(245, 158, 11);
                    btnXacNhan.Text = "✅ CHẤM TIỀN";
                    btnXacNhan.FillColor = Color.FromArgb(245, 158, 11);
                    btnTuChoi.Text = "❌ TỪ CHỐI";
                    lblTien.Visible = true;
                    txtTienNhuanBut.Visible = true;
                    break;

                case "kế toán":
                    _trangThaiHienTai = 1;
                    lblRoleInfo.Text = "👤 Kế toán (Tổ nhập liệu): Xác nhận đã nhập liệu";
                    lblRoleInfo.ForeColor = Color.FromArgb(59, 130, 246);
                    btnXacNhan.Text = "✅ XÁC NHẬN NHẬP LIỆU";
                    btnXacNhan.FillColor = Color.FromArgb(59, 130, 246);
                    btnTuChoi.Text = "📨 BÁO SAI SÓT";
                    break;

                case "kiểm tra viên":
                    _trangThaiHienTai = 2;
                    lblRoleInfo.Text = "👤 Kiểm tra viên: Kiểm tra tính chính xác";
                    lblRoleInfo.ForeColor = Color.FromArgb(16, 185, 129);
                    btnXacNhan.Text = "✅ XÁC NHẬN ĐÚNG";
                    btnXacNhan.FillColor = Color.FromArgb(16, 185, 129);
                    btnTuChoi.Text = "❌ TRẢ VỀ KẾ TOÁN";
                    break;

                case "tổng thư ký":
                    _trangThaiHienTai = 3;
                    lblRoleInfo.Text = "👤 Tổng thư ký: Ký duyệt nhuận bút";
                    lblRoleInfo.ForeColor = Color.FromArgb(79, 70, 229);
                    btnXacNhan.Text = "✅ KÝ DUYỆT";
                    btnXacNhan.FillColor = Color.FromArgb(79, 70, 229);
                    btnTuChoi.Text = "❌ TRẢ VỀ KIỂM TRA";
                    txtNguoiKy.Visible = true;
                    lblNguoiKy.Visible = true;
                    txtNguoiKy.Text = NguoiDangNhap ?? "";
                    break;

                case "admin":
                case "quản trị viên":
                    _trangThaiHienTai = 0;
                    lblRoleInfo.Text = "👤 Admin: Xem tất cả bài (chờ chấm tiền)";
                    lblRoleInfo.ForeColor = Color.FromArgb(239, 68, 68);
                    btnXacNhan.Text = "✅ DUYỆT";
                    btnXacNhan.FillColor = Color.FromArgb(239, 68, 68);
                    btnTuChoi.Visible = true;
                    btnTuChoi.Text = "❌ TỪ CHỐI";
                    break;

                default:
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
            }
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
                               n.NguoiNhap, n.NguoiChamTien, n.NguoiKeToan, n.NguoiKiemTra, n.TongThuKy,
                               n.LyDoBaoSai,
                               b.Tenbao AS TenSoBao
                        FROM Nhuanbut n
                        LEFT JOIN Bao b ON n.MsBao = b.Maso
                        WHERE n.TrangThaiDuyet = @tt";

                    if (!string.IsNullOrWhiteSpace(keyword))
                        query += " AND (n.Tenbai LIKE @kw OR n.Butdanh LIKE @kw OR n.NguoiNhap LIKE @kw)";

                    query += " ORDER BY n.ngaychuyen DESC";

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tt", _trangThaiHienTai);
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            await Task.Run(() => da.Fill(dt));
                        }
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
                            if (dgvNhuanBut.Columns["LyDoBaoSai"] != null) { dgvNhuanBut.Columns["LyDoBaoSai"].HeaderText = "Lý do báo sai"; dgvNhuanBut.Columns["LyDoBaoSai"].FillWeight = 2; dgvNhuanBut.Columns["LyDoBaoSai"].MinimumWidth = 150; }

                            foreach (string col in new[] { "NguoiNhap", "NguoiChamTien", "NguoiKeToan", "NguoiKiemTra", "TongThuKy" })
                                if (dgvNhuanBut.Columns[col] != null) dgvNhuanBut.Columns[col].Visible = false;

                            if (dgvNhuanBut.Columns["TenSoBao"] != null) { dgvNhuanBut.Columns["TenSoBao"].HeaderText = "Số Báo"; dgvNhuanBut.Columns["TenSoBao"].FillWeight = 2; dgvNhuanBut.Columns["TenSoBao"].MinimumWidth = 120; }
                        }

                        string role = QuyenHienTai?.Trim().ToLower() ?? "";
                        string trangThaiLabel = "chờ xử lý";
                        if (role == "thư ký") trangThaiLabel = "chờ chấm tiền";
                        else if (role == "kế toán") trangThaiLabel = "đã chấm tiền";
                        else if (role == "kiểm tra viên") trangThaiLabel = "đã nhập liệu";
                        else if (role == "tổng thư ký") trangThaiLabel = "đã kiểm tra";
                        lblCount.Text = $"📋 Tổng số: {dt.Rows.Count} bài {trangThaiLabel}";
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
                MessageBox.Show("Vui lòng chọn một bài viết!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            string action = "";
            int trangThaiMoi = 0;
            string sql = "";
            bool hasError = false;

            switch (role)
            {
                case "thư ký":
                    action = "chấm tiền";
                    trangThaiMoi = 1;
                    sql = @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            TienNhuanbut = @tien,
                            NguoiChamTien = @nguoi,
                            LyDoBaoSai = NULL,
                            NgayBaoSai = NULL
                            WHERE Maso = @ma";
                    break;

                case "kế toán":
                    action = "xác nhận nhập liệu";
                    trangThaiMoi = 2;
                    sql = @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            NguoiKeToan = @nguoi 
                            WHERE Maso = @ma";
                    break;

                case "kiểm tra viên":
                    action = "xác nhận kiểm tra";
                    trangThaiMoi = 3;
                    sql = @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            NguoiKiemTra = @nguoi 
                            WHERE Maso = @ma";
                    break;

                case "tổng thư ký":
                    if (txtNguoiKy != null && string.IsNullOrWhiteSpace(txtNguoiKy.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên người ký!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    action = "ký duyệt";
                    trangThaiMoi = 4;
                    sql = @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            TongThuKy = @nguoi,
                            NgayKy = GETDATE()
                            WHERE Maso = @ma";
                    break;

                case "admin":
                case "quản trị viên":
                    action = "duyệt nhanh";
                    trangThaiMoi = _trangThaiHienTai + 1;
                    sql = @"UPDATE Nhuanbut SET TrangThaiDuyet = @tt WHERE Maso = @ma";
                    break;

                default:
                    hasError = true;
                    break;
            }

            if (hasError) return;

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
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@tt", trangThaiMoi);
                            cmd.Parameters.AddWithValue("@ma", _selectedMaso);

                            if (role == "thư ký" || role == "admin" || role == "quản trị viên")
                            {
                                if (role == "thư ký")
                                {
                                    decimal tienNB = decimal.TryParse(txtTienNhuanBut.Text, out decimal t) ? t : 0;
                                    cmd.Parameters.AddWithValue("@tien", tienNB);
                                    cmd.Parameters.AddWithValue("@nguoi", NguoiDangNhap ?? "Thư ký");
                                }
                            }
                            else if (role == "kế toán")
                            {
                                cmd.Parameters.AddWithValue("@nguoi", NguoiDangNhap ?? "Kế toán");
                            }
                            else if (role == "kiểm tra viên")
                            {
                                cmd.Parameters.AddWithValue("@nguoi", NguoiDangNhap ?? "Kiểm tra viên");
                            }
                            else if (role == "tổng thư ký")
                            {
                                cmd.Parameters.AddWithValue("@nguoi", txtNguoiKy.Text.Trim());
                            }

                            await cmd.ExecuteNonQueryAsync();
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
                MessageBox.Show("Vui lòng chọn bài viết!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = QuyenHienTai?.Trim().ToLower() ?? "";
            string msg = "";
            int trangThaiVe = 0;
            string action = "";
            string sql = "";

            switch (role)
            {
                case "thư ký":
                    msg = "Từ chối bài này?";
                    trangThaiVe = 0;
                    action = "từ chối";
                    sql = "UPDATE Nhuanbut SET TrangThaiDuyet = @tt WHERE Maso = @ma";
                    break;

                case "kế toán":
                    string lyDo = "";
                    using (var inputForm = new Form())
                    {
                        inputForm.Text = "📨 BÁO SAI SÓT";
                        inputForm.Size = new Size(450, 200);
                        inputForm.StartPosition = FormStartPosition.CenterParent;
                        inputForm.ShowInTaskbar = false;

                        var lbl = new Label { Text = "Nhập lý do báo sai sót:", Location = new Point(20, 20), AutoSize = true };
                        var txt = new TextBox { Location = new Point(20, 50), Width = 390, Height = 60, Multiline = true };
                        var btn = new Button { Text = "Gửi", Location = new Point(170, 120), Size = new Size(100, 30) };
                        btn.Click += (s2, e2) => { lyDo = txt.Text; inputForm.Close(); };
                        inputForm.Controls.Add(lbl); inputForm.Controls.Add(txt); inputForm.Controls.Add(btn);
                        inputForm.ShowDialog(this);
                    }
                    if (string.IsNullOrWhiteSpace(lyDo)) return;
                    trangThaiVe = 0;
                    action = "báo sai sót về Thư ký";
                    sql = "UPDATE Nhuanbut SET TrangThaiDuyet = @tt, LyDoBaoSai = @lydo, NgayBaoSai = GETDATE() WHERE Maso = @ma";
                    if (MessageBox.Show($"Xác nhận báo sai sót: \"{lyDo}\"?\nBài sẽ được gửi trả về Thư ký sửa.", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                        {
                            await conn.OpenAsync();
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@tt", trangThaiVe);
                                cmd.Parameters.AddWithValue("@ma", _selectedMaso);
                                cmd.Parameters.AddWithValue("@lydo", lyDo);
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                        MessageBox.Show("Đã báo sai sót! Thư ký sẽ xem xét sửa lại.", "Hoàn tất",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _selectedMaso = "";
                        await LoadDataAsync(txtTimKiem.Text.Trim());
                    }
                    return;

                case "kiểm tra viên":
                    msg = "Trả bài này về Kế toán nhập lại?";
                    trangThaiVe = 2;
                    action = "trả về Kế toán";
                    sql = "UPDATE Nhuanbut SET TrangThaiDuyet = @tt WHERE Maso = @ma";
                    break;

                case "tổng thư ký":
                    msg = "Trả bài này về Kiểm tra viên xem lại?";
                    trangThaiVe = 3;
                    action = "trả về Kiểm tra viên";
                    sql = "UPDATE Nhuanbut SET TrangThaiDuyet = @tt WHERE Maso = @ma";
                    break;

                default:
                    return;
            }

            if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        await conn.OpenAsync();
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
                var row = dgvNhuanBut.Rows[e.RowIndex];
                _selectedMaso = row.Cells["Maso"].Value?.ToString();

                string role = QuyenHienTai?.Trim().ToLower() ?? "";

                if (role == "thư ký" && row.Cells["TienNhuanbut"].Value != null)
                {
                    txtTienNhuanBut.Text = Convert.ToDecimal(row.Cells["TienNhuanbut"].Value).ToString("0");
                }

                if (_trangThaiHienTai >= 4)
                {
                    btnXacNhan.Enabled = false;
                    btnTuChoi.Enabled = false;
                    btnXacNhan.Text = "✅ ĐÃ KÝ DUYỆT";
                    btnXacNhan.FillColor = Color.Gray;
                }
                else
                {   
                    btnXacNhan.Enabled = true;
                    btnTuChoi.Enabled = true;
                    SetupRoleUI();
                }

                LoadSignaturePanel(row);
            }
        }

        // =====================================================================
        // SIGNATURE PANEL
        // =====================================================================
        private void CreateSignaturePanel()
        {
            pnlSignatureContainer = new Guna.UI2.WinForms.Guna2Panel();
            pnlSignatureContainer.Dock = DockStyle.Bottom;
            pnlSignatureContainer.Height = 100;
            pnlSignatureContainer.BackColor = Color.Transparent;

            pnlSignature = new Guna.UI2.WinForms.Guna2Panel();
            pnlSignature.Dock = DockStyle.Fill;
            pnlSignature.BackColor = Color.White;
            pnlSignature.BorderRadius = 10;
            pnlSignature.BorderColor = Color.FromArgb(226, 232, 240);
            pnlSignature.BorderThickness = 1;

            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Fill;
            flp.Padding = new Padding(10);
            flp.FlowDirection = FlowDirection.LeftToRight;
            flp.WrapContents = true;

            string[] sigLabels = { "📝 Người nhập", "🖊 Người chấm", "📋 Nhập liệu", "✅ Kiểm tra", "📌 Ký duyệt" };
            string[] sigNames = { "", "", "", "", "" };
            Color[] sigColors = {
                Color.FromArgb(100, 116, 139),
                Color.FromArgb(245, 158, 11),
                Color.FromArgb(59, 130, 246),
                Color.FromArgb(16, 185, 129),
                Color.FromArgb(79, 70, 229)
            };
            Label[] sigLabelsRef = { null, null, null, null, null };
            string[] sigFields = { "NguoiNhap", "NguoiChamTien", "NguoiKeToan", "NguoiKiemTra", "TongThuKy" };

            for (int i = 0; i < 5; i++)
            {
                var panel = new Guna.UI2.WinForms.Guna2Panel();
                panel.Width = 150;
                panel.Height = 70;
                panel.BackColor = Color.Transparent;
                panel.Margin = new Padding(5);

                var lblTitle = new Label();
                lblTitle.Text = sigLabels[i];
                lblTitle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                lblTitle.ForeColor = sigColors[i];
                lblTitle.Location = new Point(2, 5);
                lblTitle.AutoSize = true;

                var lblName = new Label();
                lblName.Text = "—";
                lblName.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                lblName.ForeColor = Color.FromArgb(30, 41, 59);
                lblName.Location = new Point(2, 25);
                lblName.AutoSize = true;
                lblName.MaximumSize = new Size(140, 40);

                if (i == 0) lblSigNguoiNhap = lblName;
                else if (i == 1) lblSigNguoiCham = lblName;
                else if (i == 2) lblSigNhapLieu = lblName;
                else if (i == 3) lblSigKiemTra = lblName;
                else if (i == 4) lblSigTongThuKy = lblName;

                panel.Controls.Add(lblTitle);
                panel.Controls.Add(lblName);
                flp.Controls.Add(panel);
            }

            // Ô nhập tên cho Tổng thư ký
            var pnlNguoiKy = new Guna.UI2.WinForms.Guna2Panel();
            pnlNguoiKy.Width = 200;
            pnlNguoiKy.Height = 70;
            pnlNguoiKy.BackColor = Color.Transparent;
            pnlNguoiKy.Margin = new Padding(5);

            lblNguoiKy = new Label();
            lblNguoiKy.Text = "✍ Tên người ký:";
            lblNguoiKy.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblNguoiKy.ForeColor = Color.FromArgb(79, 70, 229);
            lblNguoiKy.Location = new Point(2, 5);
            lblNguoiKy.AutoSize = true;

            txtNguoiKy = new Guna.UI2.WinForms.Guna2TextBox();
            txtNguoiKy.BorderRadius = 5;
            txtNguoiKy.Font = new Font("Segoe UI", 9);
            txtNguoiKy.Location = new Point(2, 25);
            txtNguoiKy.Size = new Size(190, 30);
            txtNguoiKy.PlaceholderText = "Nhập tên ký...";
            txtNguoiKy.Visible = false;

            pnlNguoiKy.Controls.Add(lblNguoiKy);
            pnlNguoiKy.Controls.Add(txtNguoiKy);
            flp.Controls.Add(pnlNguoiKy);

            pnlSignature.Controls.Add(flp);
            pnlSignatureContainer.Controls.Add(pnlSignature);

            // Thêm vào form — tìm panel chứa DGV để chèn
            if (this.Controls.Contains(pnlSignature) == false)
            {
                this.Controls.Add(pnlSignatureContainer);
            }

            LayoutBottomPanel();
            pnlSignatureContainer.Resize += (s, e) => LayoutBottomPanel();
        }

        private void LayoutBottomPanel()
        {
            if (pnlSignatureContainer == null) return;
            pnlSignatureContainer.Location = new Point(0, this.ClientSize.Height - pnlSignatureContainer.Height);
            pnlSignatureContainer.Width = this.ClientSize.Width;

            // Điều chỉnh DGV không bị che
            dgvNhuanBut.Height = this.ClientSize.Height - pnlSignatureContainer.Height - dgvNhuanBut.Top - 10;
        }

        private void LoadSignaturePanel(DataGridViewRow row)
        {
            try
            {
                string GetVal(string col) => row.Cells[col]?.Value?.ToString() ?? "—";
                string GetDate(string col)
                {
                    if (row.Cells[col]?.Value == null) return "";
                    if (row.Cells[col].Value is DateTime dt)
                        return dt.ToString(" dd/MM/yy HH:mm");
                    return "";
                }

                if (lblSigNguoiNhap != null)
                    lblSigNguoiNhap.Text = GetVal("NguoiNhap") + GetDate("NgayNhap");
                if (lblSigNguoiCham != null)
                    lblSigNguoiCham.Text = GetVal("NguoiChamTien") + GetDate("NgayKiemTra");
                if (lblSigNhapLieu != null)
                    lblSigNhapLieu.Text = GetVal("NguoiKeToan") + GetDate("NgayKeToan");
                if (lblSigKiemTra != null)
                    lblSigKiemTra.Text = GetVal("NguoiKiemTra") + " (chưa có)";
                if (lblSigTongThuKy != null)
                    lblSigTongThuKy.Text = GetVal("TongThuKy") + GetDate("NgayKy");
            }
            catch { }
        }

        private void txtTienNhuanBut_TextChanged(object sender, EventArgs e) { }
        private void pnlTop_Paint(object sender, PaintEventArgs e) { }
        private void lblTien_Click(object sender, EventArgs e) { }
    }
}
