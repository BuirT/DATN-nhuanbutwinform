using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Guna.UI2.WinForms;
using ClosedXML.Excel;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmLichSuThanhToan : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        public string QuyenHienTai { get; set; }
        public string MaTacGiaCuaToi { get; set; }

        private Guna2DateTimePicker dtpTuNgay;
        private Guna2DateTimePicker dtpDenNgay;
        private Guna2ComboBox cboTrangThaiChi;
        private Guna2Button btnXuatExcel;
        
        // Summary panels
        private Guna2Panel pnlSumDaChi;
        private Label lblSumDaChi;
        private Guna2Panel pnlSumChoChi;
        private Label lblSumChoChi;

        public FrmLichSuThanhToan()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvPhieuChi, true, null);
        }

        private async void FrmLichSuThanhToan_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvPhieuChi);
            await DatabaseMigrator.AutoFixDatabaseColumnsAsync();
            
            SetupCustomUI();
            await LoadDataAsync();
        }

        private void SetupCustomUI()
        {
            // 1. Hide Duyệt/Từ chối/Xóa (đã xóa trong Designer)
            
            // Hide old detail labels
            lblChiTietSoPhieu.Visible = false;
            lblChiTietTacGia.Visible = false;
            lblChiTietTien.Visible = false;
            lblThucLinh.Visible = false; // Hide "Tiền thực lĩnh:" label
            
            lblTitle.Text = "LỊCH SỬ GIAO DỊCH";
            lblTitle.AutoSize = true;
            cboTrangThai.Left = lblTitle.Right + 20; // Move combo box to avoid overlapping title
            
            // 2. Setup ComboBox Trạng Thái Duyệt
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Tất cả trạng thái duyệt", "Chờ duyệt", "Đã duyệt", "Bị từ chối" });
            cboTrangThai.SelectedIndex = 0;
            cboTrangThai.SelectedIndexChanged += async (s, ev) => await LoadDataAsync();

            // 3. Setup ComboBox Trạng Thái Chi
            cboTrangThaiChi = new Guna2ComboBox
            {
                BorderRadius = 8,
                Font = new Font("Segoe UI", 10F),
                Size = new Size(200, 36),
                Location = new Point(cboTrangThai.Right + 15, cboTrangThai.Top)
            };
            cboTrangThaiChi.Items.AddRange(new object[] { "Tất cả thanh toán", "Chưa chi tiền", "Đã chi tiền" });
            cboTrangThaiChi.SelectedIndex = 0;
            cboTrangThaiChi.SelectedIndexChanged += async (s, ev) => await LoadDataAsync();
            pnlTop.Controls.Add(cboTrangThaiChi);

            // 4. DatePickers
            Label lblTu = new Label { Text = "Từ:", AutoSize = true, Location = new Point(cboTrangThaiChi.Right + 15, cboTrangThai.Top + 10), Font = new Font("Segoe UI", 10F) };
            pnlTop.Controls.Add(lblTu);

            dtpTuNgay = new Guna2DateTimePicker
            {
                BorderRadius = 8,
                Format = DateTimePickerFormat.Short,
                Size = new Size(130, 36),
                Location = new Point(lblTu.Right + 5, cboTrangThai.Top),
                Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            };
            dtpTuNgay.ValueChanged += async (s, ev) => await LoadDataAsync();
            pnlTop.Controls.Add(dtpTuNgay);

            Label lblDen = new Label { Text = "Đến:", AutoSize = true, Location = new Point(dtpTuNgay.Right + 10, cboTrangThai.Top + 10), Font = new Font("Segoe UI", 10F) };
            pnlTop.Controls.Add(lblDen);

            dtpDenNgay = new Guna2DateTimePicker
            {
                BorderRadius = 8,
                Format = DateTimePickerFormat.Short,
                Size = new Size(130, 36),
                Location = new Point(lblDen.Right + 5, cboTrangThai.Top),
                Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
            };
            dtpDenNgay.ValueChanged += async (s, ev) => await LoadDataAsync();
            pnlTop.Controls.Add(dtpDenNgay);

            // 5. Nút Xuất Excel
            btnXuatExcel = new Guna2Button
            {
                BorderRadius = 8,
                Text = "XUẤT EXCEL",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Size = new Size(130, 36),
                Location = new Point(pnlTop.Width - 150, cboTrangThai.Top),
                FillColor = Color.FromArgb(16, 185, 129),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnXuatExcel.Click += btnXuatExcel_Click;
            pnlTop.Controls.Add(btnXuatExcel);

            // 6. Summary Panels (Đã chi, Chờ chi)
            pnlSumDaChi = CreateSummaryPanel("Tổng ĐÃ CHI (VNĐ)", Color.FromArgb(16, 185, 129), new Point(30, lblChiTietSoPhieu.Top));
            lblSumDaChi = (Label)pnlSumDaChi.Controls[1];
            pnlBottom.Controls.Add(pnlSumDaChi);

            pnlSumChoChi = CreateSummaryPanel("Tổng CHỜ CHI (VNĐ)", Color.FromArgb(245, 158, 11), new Point(pnlSumDaChi.Right + 20, lblChiTietSoPhieu.Top));
            lblSumChoChi = (Label)pnlSumChoChi.Controls[1];
            pnlBottom.Controls.Add(pnlSumChoChi);
            
            // Hide detail labels since we use summary panels instead
            lblChiTietSoPhieu.Visible = false;
            lblChiTietTacGia.Visible = false;
            lblChiTietTien.Visible = false;
        }

        private Guna2Panel CreateSummaryPanel(string title, Color color, Point loc)
        {
            Guna2Panel pnl = new Guna2Panel
            {
                Size = new Size(220, 80),
                Location = loc,
                BorderRadius = 12,
                FillColor = color
            };
            Label lblT = new Label
            {
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            Label lblV = new Label
            {
                Text = "0",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Location = new Point(10, 35),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            pnl.Controls.Add(lblT);
            pnl.Controls.Add(lblV);
            return pnl;
        }

        private async Task LoadDataAsync()
        {
            try
            {
                string role = QuyenHienTai?.Trim().ToLower() ?? "";
                bool laPhongVien = (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời");

                string keyword = txtTimKiem.Text.Trim();

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT Sophieu, Ngaylap, Tacgia, Lydo, Sotien, Conlai, TrangThaiDuyet, Dathutien, loaiTT, Nguoinhan
                                     FROM Phieuchi WHERE CAST(Ngaylap AS DATE) >= @tu AND CAST(Ngaylap AS DATE) <= @den";

                    if (laPhongVien && !string.IsNullOrEmpty(MaTacGiaCuaToi))
                    {
                        // Lọc theo Phiếu chi có chứa bài viết của Tác giả này
                        query = @"SELECT DISTINCT p.Sophieu, p.Ngaylap, p.Tacgia, p.Lydo, p.Sotien, p.Conlai, p.TrangThaiDuyet, p.Dathutien, p.loaiTT, p.Nguoinhan
                                  FROM Phieuchi p
                                  INNER JOIN NhuanbutCT ct ON p.Sophieu = ct.SoPC
                                  INNER JOIN Nhuanbut nb ON ct.MsNhuanbut = nb.Maso
                                  WHERE CAST(p.Ngaylap AS DATE) >= @tu AND CAST(p.Ngaylap AS DATE) <= @den
                                  AND nb.MsTacgia = @matacgia";
                    }

                    if (cboTrangThai.SelectedIndex == 1) query += " AND TrangThaiDuyet = 0";
                    else if (cboTrangThai.SelectedIndex == 2) query += " AND TrangThaiDuyet = 1";
                    else if (cboTrangThai.SelectedIndex == 3) query += " AND TrangThaiDuyet = -1";

                    if (cboTrangThaiChi.SelectedIndex == 1) query += " AND Dathutien = 'N'";
                    else if (cboTrangThaiChi.SelectedIndex == 2) query += " AND Dathutien = 'Y'";

                    if (!string.IsNullOrEmpty(keyword))
                        query += " AND (Sophieu LIKE @kw OR Tacgia LIKE @kw)";

                    query += " ORDER BY Ngaylap DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tu", dtpTuNgay.Value.Date);
                        cmd.Parameters.AddWithValue("@den", dtpDenNgay.Value.Date);
                        if (laPhongVien) cmd.Parameters.AddWithValue("@matacgia", MaTacGiaCuaToi);
                        if (!string.IsNullOrEmpty(keyword)) cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                        DataTable dt = new DataTable();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }

                        // Tính tổng
                        decimal sumDaChi = 0;
                        decimal sumChoChi = 0;

                        dt.Columns.Add("TrangThai", typeof(string));
                        dt.Columns.Add("TinhTrang", typeof(string));
                        
                        foreach (DataRow r in dt.Rows)
                        {
                            int tt = Convert.ToInt32(r["TrangThaiDuyet"]);
                            r["TrangThai"] = tt == 1 ? "Đã duyệt" : (tt == -1 ? "Từ chối" : "Chờ duyệt");
                            
                            string daThu = r["Dathutien"].ToString();
                            r["TinhTrang"] = (daThu == "Y" || daThu == "y") ? "Đã chi" : "Chưa chi";

                            decimal thucLinh = r["Conlai"] != DBNull.Value ? Convert.ToDecimal(r["Conlai"]) : 0;
                            if (daThu == "Y" || daThu == "y") sumDaChi += thucLinh;
                            if (tt == 1 && (daThu == "N" || daThu == "n")) sumChoChi += thucLinh;
                        }

                        lblSumDaChi.Text = sumDaChi.ToString("N0");
                        lblSumChoChi.Text = sumChoChi.ToString("N0");

                        dgvPhieuChi.DataSource = dt;
                    }
                }

                if (dgvPhieuChi.Columns.Count > 0)
                {
                    if (dgvPhieuChi.Columns["Ngaylap"] != null) dgvPhieuChi.Columns["Ngaylap"].Visible = false;
                    if (dgvPhieuChi.Columns["Sotien"] != null) dgvPhieuChi.Columns["Sotien"].Visible = false;
                    if (dgvPhieuChi.Columns["TrangThaiDuyet"] != null) dgvPhieuChi.Columns["TrangThaiDuyet"].Visible = false;
                    if (dgvPhieuChi.Columns["Dathutien"] != null) dgvPhieuChi.Columns["Dathutien"].Visible = false;
                    if (dgvPhieuChi.Columns["Nguoinhan"] != null) dgvPhieuChi.Columns["Nguoinhan"].Visible = false;
                    if (dgvPhieuChi.Columns["loaiTT"] != null) dgvPhieuChi.Columns["loaiTT"].Visible = false;

                    UIHelper.ConfigureColumns(dgvPhieuChi,
                        ("Sophieu", "Số phiếu", false, false),
                        ("Tacgia", "Tác giả", false, false),
                        ("Lydo", "Lý do", false, false),
                        ("Conlai", "Thực lĩnh (VNĐ)", true, false),
                        ("TrangThai", "Duyệt", false, false),
                        ("TinhTrang", "Chi tiền", false, false)
                    );
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private async void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvPhieuChi.Rows.Count == 0) return;
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("GiaoDich");
                    worksheet.Cell(1, 1).Value = "LỊCH SỬ GIAO DỊCH TỪ " + dtpTuNgay.Value.ToString("dd/MM/yyyy") + " ĐẾN " + dtpDenNgay.Value.ToString("dd/MM/yyyy");
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 14;
                    worksheet.Range(1, 1, 1, 6).Merge();

                    // Headers
                    worksheet.Cell(3, 1).Value = "Số phiếu";
                    worksheet.Cell(3, 2).Value = "Tác giả";
                    worksheet.Cell(3, 3).Value = "Lý do";
                    worksheet.Cell(3, 4).Value = "Thực lĩnh";
                    worksheet.Cell(3, 5).Value = "Duyệt";
                    worksheet.Cell(3, 6).Value = "Chi tiền";
                    var headerRange = worksheet.Range(3, 1, 3, 6);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    int row = 4;
                    foreach (DataGridViewRow r in dgvPhieuChi.Rows)
                    {
                        if (r.IsNewRow) continue;
                        worksheet.Cell(row, 1).Value = r.Cells["Sophieu"].Value?.ToString();
                        worksheet.Cell(row, 2).Value = r.Cells["Tacgia"].Value?.ToString();
                        worksheet.Cell(row, 3).Value = r.Cells["Lydo"].Value?.ToString();
                        worksheet.Cell(row, 4).Value = Convert.ToDecimal(r.Cells["Conlai"].Value);
                        worksheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0";
                        worksheet.Cell(row, 5).Value = r.Cells["TrangThai"].Value?.ToString();
                        worksheet.Cell(row, 6).Value = r.Cells["TinhTrang"].Value?.ToString();
                        
                        worksheet.Range(row, 1, row, 6).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Range(row, 1, row, 6).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        
                        row++;
                    }
                    worksheet.Columns().AdjustToContents();

                    string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "LichSuGiaoDich_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
                    workbook.SaveAs(tempPath);
                    System.Diagnostics.Process.Start(tempPath);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất Excel: " + ex.Message); }
        }
        
        // Disable original button handlers
        private void btnDuyet_Click(object sender, EventArgs e) {}
        private void btnTuChoi_Click(object sender, EventArgs e) {}
        private void btnXoa_Click(object sender, EventArgs e) {}
        private void dgvPhieuChi_CellClick(object sender, DataGridViewCellEventArgs e) {}
        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e) {}
    }
}
