using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace HETHONGTINHNHUANBUT
{
    public class FrmBaoCaoLanhDao : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlSummary;
        private Guna.UI2.WinForms.Guna2Panel pnlDetail;
        private Label lblTitle;
        private Label lblThang;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpThang;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2Button btnExcel;
        private Label lblSummaryTitle;
        private Label lblDetailTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSummary;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDetail;

        private Label lblTongBai;
        private Label lblTongTien;
        private Label lblDaChi;
        private Label lblChuaChi;

        public FrmBaoCaoLanhDao()
        {
            InitializeControls();
            Load += FrmBaoCaoLanhDao_Load;
        }

        private void InitializeControls()
        {
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(244, 247, 254);
            ClientSize = new Size(1500, 750);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10F);
            Name = "FrmBaoCaoLanhDao";
            Padding = new Padding(20, 15, 20, 20);
            Text = "Báo cáo lãnh đạo";

            pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.Transparent;
            pnlTop.BorderRadius = 16;
            pnlTop.FillColor = Color.White;
            pnlTop.ShadowDecoration.Color = Color.FromArgb(226, 232, 240);
            pnlTop.ShadowDecoration.Depth = 8;
            pnlTop.ShadowDecoration.Enabled = true;
            pnlTop.Size = new Size(1460, 120);
            pnlTop.Location = new Point(0, 0);

            lblTitle = new Label();
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(25, 18);
            lblTitle.Text = "BÁO CÁO LÃNH ĐẠO";

            lblThang = new Label();
            lblThang.AutoSize = true;
            lblThang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblThang.ForeColor = Color.FromArgb(100, 116, 139);
            lblThang.Location = new Point(25, 72);
            lblThang.Text = "Chọn tháng";

            dtpThang = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dtpThang.BorderColor = Color.FromArgb(226, 232, 240);
            dtpThang.BorderRadius = 8;
            dtpThang.Checked = true;
            dtpThang.CustomFormat = "MM/yyyy";
            dtpThang.FillColor = Color.FromArgb(248, 250, 252);
            dtpThang.Font = new Font("Segoe UI", 10F);
            dtpThang.ForeColor = Color.Black;
            dtpThang.Format = DateTimePickerFormat.Custom;
            dtpThang.Location = new Point(128, 66);
            dtpThang.MaxDate = new DateTime(9998, 12, 31);
            dtpThang.MinDate = new DateTime(2020, 1, 1);
            dtpThang.Size = new Size(160, 36);
            dtpThang.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            btnXem = new Guna.UI2.WinForms.Guna2Button();
            btnXem.Animated = true;
            btnXem.BorderRadius = 8;
            btnXem.FillColor = Color.FromArgb(16, 185, 129);
            btnXem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(310, 62);
            btnXem.Size = new Size(150, 40);
            btnXem.Text = "XEM BÁO CÁO";
            btnXem.Click += btnXem_Click;

            btnExcel = new Guna.UI2.WinForms.Guna2Button();
            btnExcel.Animated = true;
            btnExcel.BorderRadius = 8;
            btnExcel.FillColor = Color.FromArgb(245, 158, 11);
            btnExcel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExcel.ForeColor = Color.White;
            btnExcel.Location = new Point(475, 62);
            btnExcel.Size = new Size(150, 40);
            btnExcel.Text = "XUẤT EXCEL";
            btnExcel.Click += btnExcel_Click;

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblThang);
            pnlTop.Controls.Add(dtpThang);
            pnlTop.Controls.Add(btnXem);
            pnlTop.Controls.Add(btnExcel);

            // Summary panel
            pnlSummary = new Guna.UI2.WinForms.Guna2Panel();
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSummary.BackColor = Color.Transparent;
            pnlSummary.BorderRadius = 16;
            pnlSummary.FillColor = Color.White;
            pnlSummary.ShadowDecoration.Color = Color.FromArgb(226, 232, 240);
            pnlSummary.ShadowDecoration.Depth = 8;
            pnlSummary.ShadowDecoration.Enabled = true;
            pnlSummary.Size = new Size(1460, 260);
            pnlSummary.Location = new Point(0, 135);

            lblSummaryTitle = new Label();
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblSummaryTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblSummaryTitle.Location = new Point(25, 18);
            lblSummaryTitle.Text = "TỔNG HỢP THEO TÁC GIẢ";

            dgvSummary = CreateGrid();
            dgvSummary.Location = new Point(25, 55);
            dgvSummary.Size = new Size(1410, 190);

            pnlSummary.Controls.Add(lblSummaryTitle);
            pnlSummary.Controls.Add(dgvSummary);

            // Detail panel
            pnlDetail = new Guna.UI2.WinForms.Guna2Panel();
            pnlDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDetail.BackColor = Color.Transparent;
            pnlDetail.BorderRadius = 16;
            pnlDetail.FillColor = Color.White;
            pnlDetail.ShadowDecoration.Color = Color.FromArgb(226, 232, 240);
            pnlDetail.ShadowDecoration.Depth = 8;
            pnlDetail.ShadowDecoration.Enabled = true;
            pnlDetail.Size = new Size(1460, 320);
            pnlDetail.Location = new Point(0, 410);

            lblDetailTitle = new Label();
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblDetailTitle.Location = new Point(25, 18);
            lblDetailTitle.Text = "CHI TIẾT NHUẬN BÚT TRONG THÁNG";

            dgvDetail = CreateGrid();
            dgvDetail.Location = new Point(25, 55);
            dgvDetail.Size = new Size(1410, 250);

            // Footer labels
            lblTongBai = new Label();
            lblTongBai.AutoSize = true;
            lblTongBai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongBai.ForeColor = Color.FromArgb(15, 23, 42);
            lblTongBai.Location = new Point(25, 5);
            lblTongBai.Text = "Tổng số bài: 0";

            lblTongTien = new Label();
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(15, 23, 42);
            lblTongTien.Location = new Point(200, 5);
            lblTongTien.Text = "Tổng nhuận bút: 0 VNĐ";

            lblDaChi = new Label();
            lblDaChi.AutoSize = true;
            lblDaChi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDaChi.ForeColor = Color.FromArgb(16, 185, 129);
            lblDaChi.Location = new Point(450, 5);
            lblDaChi.Text = "Đã chi: 0 VNĐ";

            lblChuaChi = new Label();
            lblChuaChi.AutoSize = true;
            lblChuaChi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChuaChi.ForeColor = Color.Crimson;
            lblChuaChi.Location = new Point(650, 5);
            lblChuaChi.Text = "Chưa chi: 0 VNĐ";

            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(dgvDetail);
            pnlDetail.Controls.Add(lblTongBai);
            pnlDetail.Controls.Add(lblTongTien);
            pnlDetail.Controls.Add(lblDaChi);
            pnlDetail.Controls.Add(lblChuaChi);

            Controls.Add(pnlTop);
            Controls.Add(pnlSummary);
            Controls.Add(pnlDetail);
        }

        private Guna.UI2.WinForms.Guna2DataGridView CreateGrid()
        {
            var g = new Guna.UI2.WinForms.Guna2DataGridView();
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeColumns = false;
            g.AllowUserToResizeRows = false;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            g.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            g.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            g.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(71, 85, 105);
            g.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            g.ColumnHeadersHeight = 40;
            g.DefaultCellStyle.BackColor = Color.White;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            g.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
            g.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            g.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            g.GridColor = Color.FromArgb(241, 245, 249);
            g.RowHeadersVisible = false;
            g.RowTemplate.Height = 38;
            g.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            g.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            g.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            g.ThemeStyle.HeaderStyle.Height = 40;
            g.ThemeStyle.ReadOnly = false;
            g.ThemeStyle.RowsStyle.BackColor = Color.White;
            g.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            g.ThemeStyle.RowsStyle.Height = 38;
            g.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            g.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            return g;
        }

        private void FrmBaoCaoLanhDao_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvSummary);
            UIHelper.FormatGiaoDienBang(dgvDetail);
        }

        private async void btnXem_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            DateTime selected = dtpThang.Value;
            int month = selected.Month;
            int year = selected.Year;

            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    string query = @"
                        SELECT 
                            nb.Maso, nb.Tenbai, nb.TienNhuanbut, nb.TrangThaiDuyet,
                            nb.Butdanh, nb.ngaychuyen,
                            ct.SauThanhToan, ct.Sotien,
                            tg.Hoten AS TacGia
                        FROM Nhuanbut nb
                        LEFT JOIN NhuanbutCT ct ON nb.Maso = ct.MsNhuanbut
                        LEFT JOIN TacGia tg ON ct.MsTacgia = tg.Maso
                        WHERE MONTH(nb.ngaychuyen) = @m AND YEAR(nb.ngaychuyen) = @y
                        ORDER BY nb.ngaychuyen DESC, tg.Hoten";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@m", month);
                        cmd.Parameters.AddWithValue("@y", year);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            await Task.Run(() => da.Fill(dt));
                        }
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    dgvSummary.DataSource = null;
                    dgvDetail.DataSource = null;
                    lblTongBai.Text = "Tổng số bài: 0";
                    lblTongTien.Text = "Tổng nhuận bút: 0 VNĐ";
                    lblDaChi.Text = "Đã chi: 0 VNĐ";
                    lblChuaChi.Text = "Chưa chi: 0 VNĐ";
                    MessageBox.Show("Không có dữ liệu trong tháng này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Detail grid
                var detailView = dt.AsEnumerable().Select(r => new
                {
                    Maso = r.Field<int>("Maso"),
                    Tenbai = r.Field<string>("Tenbai"),
                    Butdanh = r.Field<string>("Butdanh"),
                    TacGia = r.Field<string>("TacGia") ?? "",
                    TienNhuanbut = Convert.ToDecimal(r["TienNhuanbut"]),
                    ThanhToan = (r["SauThanhToan"] != DBNull.Value && r["SauThanhToan"].ToString() == "Y") ? "Đã chi" : "Chưa chi",
                    NgayDang = r.Field<DateTime?>("ngaychuyen")?.ToString("dd/MM/yyyy") ?? ""
                }).ToList();

                dgvDetail.DataSource = detailView;
                if (dgvDetail.Columns.Count > 0)
                {
                    dgvDetail.Columns["Maso"].HeaderText = "Mã số";
                    dgvDetail.Columns["Maso"].Width = 80;
                    dgvDetail.Columns["Tenbai"].HeaderText = "Tên bài";
                    dgvDetail.Columns["Tenbai"].Width = 300;
                    dgvDetail.Columns["Butdanh"].Width = 120;
                    dgvDetail.Columns["Butdanh"].HeaderText = "Bút danh";
                    dgvDetail.Columns["TacGia"].Width = 150;
                    dgvDetail.Columns["TacGia"].HeaderText = "Tác giả";
                    dgvDetail.Columns["TienNhuanbut"].HeaderText = "Nhuận bút (VNĐ)";
                    dgvDetail.Columns["TienNhuanbut"].DefaultCellStyle.Format = "N0";
                    dgvDetail.Columns["TienNhuanbut"].Width = 150;
                    dgvDetail.Columns["ThanhToan"].HeaderText = "Trạng thái";
                    dgvDetail.Columns["ThanhToan"].Width = 100;
                    dgvDetail.Columns["NgayDang"].HeaderText = "Ngày đăng";
                    dgvDetail.Columns["NgayDang"].Width = 100;
                }

                // Summary by author
                var summaryView = dt.AsEnumerable()
                    .GroupBy(r => r.Field<string>("TacGia") ?? "(Không có)")
                    .Select(g => new
                    {
                        TacGia = g.Key,
                        SoBai = g.Select(r => r.Field<int>("Maso")).Distinct().Count(),
                        TongNB = g.Sum(r => Convert.ToDecimal(r["TienNhuanbut"])),
                        DaChi = g.Where(r => r["SauThanhToan"] != DBNull.Value && r["SauThanhToan"].ToString() == "Y")
                                 .Sum(r => Convert.ToDecimal(r["TienNhuanbut"])),
                        ChuaChi = g.Where(r => r["SauThanhToan"] == DBNull.Value || r["SauThanhToan"].ToString() != "Y")
                                   .Sum(r => Convert.ToDecimal(r["TienNhuanbut"]))
                    })
                    .OrderByDescending(x => x.TongNB)
                    .ToList();

                dgvSummary.DataSource = summaryView;
                if (dgvSummary.Columns.Count > 0)
                {
                    dgvSummary.Columns["TacGia"].HeaderText = "Tác giả";
                    dgvSummary.Columns["TacGia"].Width = 200;
                    dgvSummary.Columns["SoBai"].HeaderText = "Số bài";
                    dgvSummary.Columns["SoBai"].Width = 80;
                    dgvSummary.Columns["TongNB"].HeaderText = "Tổng NB (VNĐ)";
                    dgvSummary.Columns["TongNB"].DefaultCellStyle.Format = "N0";
                    dgvSummary.Columns["TongNB"].Width = 180;
                    dgvSummary.Columns["DaChi"].HeaderText = "Đã chi (VNĐ)";
                    dgvSummary.Columns["DaChi"].DefaultCellStyle.Format = "N0";
                    dgvSummary.Columns["DaChi"].Width = 180;
                    dgvSummary.Columns["ChuaChi"].HeaderText = "Chưa chi (VNĐ)";
                    dgvSummary.Columns["ChuaChi"].DefaultCellStyle.Format = "N0";
                    dgvSummary.Columns["ChuaChi"].Width = 180;
                }

                // Footer totals
                decimal tongTien = summaryView.Sum(x => x.TongNB);
                decimal daChi = summaryView.Sum(x => x.DaChi);
                decimal chuaChi = summaryView.Sum(x => x.ChuaChi);
                int tongBai = dt.AsEnumerable().Select(r => r.Field<int>("Maso")).Distinct().Count();

                lblTongBai.Text = $"Tổng số bài: {tongBai}";
                lblTongTien.Text = $"Tổng nhuận bút: {tongTien:N0} VNĐ";
                lblDaChi.Text = $"Đã chi: {daChi:N0} VNĐ";
                lblChuaChi.Text = $"Chưa chi: {chuaChi:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count == 0 && dgvSummary.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files|*.xlsx";
            sfd.FileName = $"BaoCaoLanhDao_{dtpThang.Value:MMyyyy}.xlsx";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    // Sheet 1: Tổng hợp
                    var ws1 = workbook.Worksheets.Add("Tổng hợp tác giả");
                    var sumTable = new DataTable();
                    sumTable.Columns.Add("Tác giả");
                    sumTable.Columns.Add("Số bài");
                    sumTable.Columns.Add("Tổng NB");
                    sumTable.Columns.Add("Đã chi");
                    sumTable.Columns.Add("Chưa chi");

                    foreach (DataGridViewRow row in dgvSummary.Rows)
                    {
                        if (row.IsNewRow) continue;
                        sumTable.Rows.Add(
                            row.Cells["TacGia"]?.Value?.ToString(),
                            row.Cells["SoBai"]?.Value?.ToString(),
                            row.Cells["TongNB"]?.Value?.ToString(),
                            row.Cells["DaChi"]?.Value?.ToString(),
                            row.Cells["ChuaChi"]?.Value?.ToString()
                        );
                    }
                    ws1.Cell(1, 1).InsertTable(sumTable);
                    ws1.Columns().AdjustToContents();

                    // Sheet 2: Chi tiết
                    var ws2 = workbook.Worksheets.Add("Chi tiết nhuận bút");
                    var dt2 = new DataTable();
                    foreach (DataGridViewColumn col in dgvDetail.Columns)
                        dt2.Columns.Add(col.HeaderText);

                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var dr = dt2.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                            dr[cell.ColumnIndex] = cell.Value?.ToString() ?? "";
                        dt2.Rows.Add(dr);
                    }
                    ws2.Cell(1, 1).InsertTable(dt2);
                    ws2.Columns().AdjustToContents();

                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Xuất Excel thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
