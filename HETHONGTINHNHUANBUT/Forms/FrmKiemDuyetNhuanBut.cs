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

        
        
        
        private Guna.UI2.WinForms.Guna2Panel pnlNguoiKy;
        private Guna.UI2.WinForms.Guna2TextBox txtNguoiKy;
        private Label lblNguoiKy;

        public string QuyenHienTai { get; set; }
        public string NguoiDangNhap { get; set; }

        public FrmKiemDuyetNhuanBut()
        {
            InitializeComponent();

            UIHelper.FormatGiaoDienBang(dgvNhuanBut);
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvNhuanBut, true, null);
        }

        private async void FrmKiemDuyetNhuanBut_Load(object sender, EventArgs e)
        {
            // Tạo trường nhập tên người ký cho Tổng thư ký
            pnlNguoiKy = new Guna.UI2.WinForms.Guna2Panel();
            pnlNguoiKy.BackColor = Color.Transparent;
            pnlNguoiKy.Location = new Point(980, 15);
            pnlNguoiKy.Size = new Size(180, 50);
            pnlNguoiKy.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            lblNguoiKy = new Label();
            lblNguoiKy.Text = "✍ Tên người ký:";
            lblNguoiKy.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblNguoiKy.ForeColor = Color.FromArgb(79, 70, 229);
            lblNguoiKy.Location = new Point(0, 0);
            lblNguoiKy.AutoSize = true;

            txtNguoiKy = new Guna.UI2.WinForms.Guna2TextBox();
            txtNguoiKy.BorderRadius = 5;
            txtNguoiKy.Font = new Font("Segoe UI", 9);
            txtNguoiKy.Location = new Point(0, 20);
            txtNguoiKy.Size = new Size(180, 26);
            txtNguoiKy.PlaceholderText = "Nhập tên ký...";

            pnlNguoiKy.Controls.Add(lblNguoiKy);
            pnlNguoiKy.Controls.Add(txtNguoiKy);
            pnlTop.Controls.Add(pnlNguoiKy);
            pnlNguoiKy.Visible = false;
            
            SetupRoleUI();

            if (string.IsNullOrEmpty(QuyenHienTai?.Trim()))
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

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
            if (pnlNguoiKy != null) pnlNguoiKy.Visible = false;

            switch (role)
            {
                case "biên tập":
                case "biên tập viên":
                case "thư kí":
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
                    if (pnlNguoiKy != null) pnlNguoiKy.Visible = true;
                    txtNguoiKy.Text = NguoiDangNhap ?? "";
                    break;

                case "lãnh đạo":
                    _trangThaiHienTai = -1;
                    lblRoleInfo.Text = "👤 Lãnh đạo: Xem tất cả bài (chỉ xem)";
                    lblRoleInfo.ForeColor = Color.FromArgb(100, 116, 139);
                    btnXacNhan.Visible = false;
                    btnTuChoi.Visible = false;
                    break;

                case "admin":
                case "quản trị viên":
                    _trangThaiHienTai = -1;
                    lblRoleInfo.Text = "👤 Admin: Xem tất cả bài — duyệt nhanh toàn bộ quy trình";
                    lblRoleInfo.ForeColor = Color.FromArgb(239, 68, 68);
                    btnXacNhan.Text = "✅ DUYỆT (TIẾP THEO)";
                    btnXacNhan.FillColor = Color.FromArgb(239, 68, 68);
                    btnTuChoi.Visible = true;
                    btnTuChoi.Text = "🔄 VỀ CHỜ CHẤM TIỀN";
                    if (pnlNguoiKy != null) pnlNguoiKy.Visible = true;
                    txtNguoiKy.Visible = true;
                    lblNguoiKy.Visible = true;
                    txtNguoiKy.Text = NguoiDangNhap ?? "";
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
                if (IsDisposed) return;
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    if (IsDisposed) return;
                    string query = @"
                        SELECT n.Maso, n.Tenbai, n.Trang, n.Muc, n.Butdanh, 
                               n.TienNhuanbut,
                               n.NoiDungBaiViet,
                               n.DiemChatLuongAI,
                               n.NguoiNhap, n.NguoiChamTien, n.NguoiKeToan, n.NguoiKiemTra, n.TongThuKy,
                               n.LyDoBaoSai,
                               n.ngaychuyen AS NgayNhap,
                               n.NgayChamTien, n.NgayNhapLieu, n.NgayKiemTra, n.NgayKy,
                               b.Tenbao AS TenSoBao,
                                n.TrangThaiDuyet,
                                 n.DanhGiaAI
                        FROM Nhuanbut n
                        LEFT JOIN Bao b ON n.MsBao = b.Maso";

                    bool isAdmin = _trangThaiHienTai == -1;
                    if (!isAdmin)
                        query += " WHERE n.TrangThaiDuyet = @tt";

                    if (!string.IsNullOrWhiteSpace(keyword))
                        query += (isAdmin ? " WHERE" : " AND") + " (n.Tenbai LIKE @kw OR n.Butdanh LIKE @kw OR n.NguoiNhap LIKE @kw)";

                    query += " ORDER BY n.ngaychuyen DESC";

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!isAdmin)
                            cmd.Parameters.AddWithValue("@tt", _trangThaiHienTai);
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            await Task.Run(() => da.Fill(dt));
                        }
                    }
                    if (IsDisposed) return;
                    dgvNhuanBut.DataSource = dt;

                    foreach (DataRow row in dt.Rows)
                    {
                        string trangVal = row["Trang"]?.ToString() ?? "";
                        row["Trang"] = System.Text.RegularExpressions.Regex.Replace(trangVal, @"^\D+", "");
                    }

                    if (dgvNhuanBut.Columns.Count > 0)
                    {
                        if (dgvNhuanBut.Columns["Maso"] != null) dgvNhuanBut.Columns["Maso"].Visible = false;
                        if (dgvNhuanBut.Columns["TrangThaiDuyet"] != null) dgvNhuanBut.Columns["TrangThaiDuyet"].Visible = false;
                        foreach (string col in new[] { "NguoiNhap", "NguoiChamTien", "NguoiKeToan", "NguoiKiemTra", "TongThuKy", "NgayChamTien", "NgayNhapLieu", "NgayKiemTra", "NgayKy" })
                            if (dgvNhuanBut.Columns[col] != null) dgvNhuanBut.Columns[col].Visible = false;

                        if (dgvNhuanBut.Columns["DanhGiaAI"] != null) dgvNhuanBut.Columns["DanhGiaAI"].Visible = false;
                        if (dgvNhuanBut.Columns["DiemChatLuongAI"] != null) dgvNhuanBut.Columns["DiemChatLuongAI"].Visible = false;
                        if (dgvNhuanBut.Columns["NoiDungBaiViet"] != null) dgvNhuanBut.Columns["NoiDungBaiViet"].Visible = false;

                        UIHelper.ConfigureColumns(dgvNhuanBut,
                            ("Tenbai", "TÊN BÀI", false, false),
                            ("Trang", "Trang", false, false),
                            ("Muc", "Mục", false, false),
                            ("Butdanh", "BÚT DANH", false, false),
                            ("TienNhuanbut", "TIỀN NB (VNĐ)", true, false),
                            ("LyDoBaoSai", "Lý do báo sai", false, false),
                            ("NgayNhap", "Ngày nhập", false, false),
                            ("TenSoBao", "SỐ BÁO", false, false)
                        );
                    }

                    string role = QuyenHienTai?.Trim().ToLower() ?? "";
                    string trangThaiLabel = "chờ xử lý";
                    if (role == "thư ký" || role == "thư kí" || role == "biên tập" || role == "biên tập viên") trangThaiLabel = "chờ chấm tiền";
                    else if (role == "kế toán") trangThaiLabel = "đã chấm tiền";
                    else if (role == "kiểm tra viên") trangThaiLabel = "đã nhập liệu";
                    else if (role == "tổng thư ký") trangThaiLabel = "đã kiểm tra";
                    if (IsDisposed) return;
                    lblCount.Text = string.Format("📋 Tổng số: {0} bài {1}", dt.Rows.Count, trangThaiLabel);

                    // Calculate stats
                    lblStat1Value.Text = dt.Rows.Count.ToString();
                    decimal totalMoney = 0;
                    int aiWarns = 0;
                    int approvedToday = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        if (r["TienNhuanbut"] != DBNull.Value) totalMoney += Convert.ToDecimal(r["TienNhuanbut"]);
                        if (r["DanhGiaAI"] != DBNull.Value && r["DanhGiaAI"].ToString().Contains("Cảnh báo")) aiWarns++;
                        if (r["NgayKy"] != DBNull.Value && Convert.ToDateTime(r["NgayKy"]).Date == DateTime.Today) approvedToday++;
                    }
                    lblStat2Value.Text = totalMoney.ToString("N0") + " đ";
                    lblStat3Value.Text = aiWarns.ToString();
                    lblStat4Value.Text = approvedToday.ToString();
                }
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                    MessageBox.Show("Lỗi: " + ex.Message);
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
                case "biên tập":
                case "biên tập viên":
                case "thư kí":
                case "thư ký":
                    action = "chấm tiền";
                    trangThaiMoi = 1;
                    sql = @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            TienNhuanbut = @tien,
                            NguoiChamTien = @nguoi,
                            NgayChamTien = GETDATE(),
                            LyDoBaoSai = NULL,
                            NgayBaoSai = NULL
                            WHERE Maso = @ma";
                    break;

                case "kế toán":
                    action = "xác nhận nhập liệu";
                    trangThaiMoi = 2;
                    sql = @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            NguoiKeToan = @nguoi,
                            NgayNhapLieu = GETDATE()
                            WHERE Maso = @ma";
                    break;

                case "kiểm tra viên":
                    action = "xác nhận kiểm tra";
                    trangThaiMoi = 3;
                    sql = @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            NguoiKiemTra = @nguoi,
                            NgayKiemTra = GETDATE()
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
                    {
                        int currentStatus = 0;
                        if (dgvNhuanBut.CurrentRow?.Cells["TrangThaiDuyet"].Value != null)
                            int.TryParse(dgvNhuanBut.CurrentRow.Cells["TrangThaiDuyet"].Value.ToString(), out currentStatus);

                        if (currentStatus >= 4)
                        {
                            MessageBox.Show("Bài này đã ký duyệt hoàn tất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        action = "duyệt nhanh";
                        trangThaiMoi = currentStatus + 1;
                        string[] statusNames = { "", "chấm tiền", "nhập liệu", "kiểm tra", "ký duyệt" };
                        action = string.Format("duyệt ({0})", statusNames[trangThaiMoi]);
                        sql = @"UPDATE Nhuanbut SET TrangThaiDuyet = @tt WHERE Maso = @ma";
                    }
                    break;

                default:
                    hasError = true;
                    break;
            }

            if (hasError) return;

            string msg = string.Format("Xác nhận {0} cho bài viết này?", action);

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

                            if (role == "thư ký" || role == "thư kí" || role == "biên tập" || role == "biên tập viên" || role == "admin" || role == "quản trị viên")
                            {
                                if (role == "thư ký" || role == "thư kí" || role == "biên tập" || role == "biên tập viên")
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

                    MessageBox.Show(string.Format("Đã {0} thành công!", action), "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                case "biên tập":
                case "biên tập viên":
                case "thư kí":
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
                    if (MessageBox.Show(string.Format("Xác nhận báo sai sót: \"{0}\"?\nBài sẽ được gửi trả về Thư ký sửa.", lyDo), "Xác nhận",
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

                case "admin":
                case "quản trị viên":
                    msg = "Đưa bài này về trạng thái chờ chấm tiền (Thư ký)?";
                    trangThaiVe = 0;
                    action = "đưa về chờ chấm tiền";
                    sql = "UPDATE Nhuanbut SET TrangThaiDuyet = @tt, TienNhuanbut = 0, NguoiChamTien = NULL, NgayChamTien = NULL, NguoiKeToan = NULL, NgayNhapLieu = NULL, NguoiKiemTra = NULL, NgayKiemTra = NULL, TongThuKy = NULL, NgayKy = NULL, LyDoBaoSai = NULL, NgayBaoSai = NULL WHERE Maso = @ma";
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
                    MessageBox.Show(string.Format("Đã {0}!", action), "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                if ((role == "thư ký" || role == "thư kí" || role == "biên tập" || role == "biên tập viên") && row.Cells["TienNhuanbut"].Value != null)
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

                // Load nội dung bài viết
                if (dgvNhuanBut.Columns["NoiDungBaiViet"] != null)
                {
                    string noiDung = row.Cells["NoiDungBaiViet"].Value?.ToString() ?? "";
                    txtNoiDungBaiViet.Text = noiDung;
                }

                // Hiển thị AI score + evaluation (dùng controls riêng, không ghi đè lblRoleInfo)
                if (dgvNhuanBut.Columns["DiemChatLuongAI"] != null)
                {
                    int diemAI = 0;
                    var diemVal = row.Cells["DiemChatLuongAI"].Value;
                    if (diemVal != null && diemVal != DBNull.Value)
                        int.TryParse(diemVal.ToString(), out diemAI);

                    string danhGiaAI = "";
                    if (dgvNhuanBut.Columns["DanhGiaAI"] != null)
                        danhGiaAI = row.Cells["DanhGiaAI"].Value?.ToString() ?? "";

                    if (diemAI > 0 || !string.IsNullOrEmpty(danhGiaAI))
                    {
                        lblDiemAI.Text = diemAI > 0 ? string.Format("🤖 Điểm AI: {0}/100", diemAI) : "";
                        lblDiemAI.Visible = true;
                        txtDanhGiaAI.Text = danhGiaAI ?? "";
                    }
                    else
                    {
                        lblDiemAI.Visible = false;
                        txtDanhGiaAI.Text = "";
                    }
                }
            }
        }

        // =====================================================================
        // SIGNATURE PANEL (NATIVE)
        // =====================================================================
        private void LoadSignaturePanel(DataGridViewRow row)
        {
            try
            {
                Func<string, string> GetVal = delegate (string col) {
                    if (row.Cells[col] != null && row.Cells[col].Value != null && row.Cells[col].Value != DBNull.Value)
                        return row.Cells[col].Value.ToString();
                    return "—";
                };

                Func<string, string> GetDate = delegate (string col) {
                    if (row.Cells[col] == null || row.Cells[col].Value == null || row.Cells[col].Value == DBNull.Value) return "";
                    if (row.Cells[col].Value is DateTime)
                        return ((DateTime)row.Cells[col].Value).ToString(" dd/MM/yyyy HH:mm");
                    return "";
                };

                string pvName = GetVal("NguoiNhap");
                if (pvName == "—" || string.IsNullOrWhiteSpace(pvName)) pvName = GetVal("Butdanh");
                if (pvName == "—" || string.IsNullOrWhiteSpace(pvName)) pvName = "";
                else if (!pvName.StartsWith("PV", StringComparison.OrdinalIgnoreCase))
                    pvName = "PV " + pvName;

                if (lblWF1Value != null) lblWF1Value.Text = pvName + GetDate("Ngaynhap");
                if (lblWF2Value != null) lblWF2Value.Text = GetVal("NguoiChamTien") + GetDate("NgayChamTien");
                if (lblWF3Value != null) lblWF3Value.Text = GetVal("NguoiKeToan") + GetDate("NgayNhapLieu");
                if (lblWF4Value != null) lblWF4Value.Text = GetVal("NguoiKiemTra") + GetDate("NgayKiemTra");
                if (lblWF5Value != null) lblWF5Value.Text = GetVal("TongThuKy") + GetDate("NgayKy");
            }
            catch (Exception)
            {
                // handle error
            }
        }
    }
}
