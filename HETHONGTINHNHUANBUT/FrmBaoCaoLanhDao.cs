using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Guna.Charts.WinForms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoLanhDao : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmBaoCaoLanhDao()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoLanhDao_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvSummary);
            UIHelper.FormatGiaoDienBang(dgvDetail);
            LayoutPanels();
        }

        private void FrmBaoCaoLanhDao_Resize(object sender, EventArgs e)
        {
            LayoutPanels();
        }

        private void LayoutPanels()
        {
            if (pnlSummary == null || pnlDetail == null || pnlChart == null) return;
            int padL = this.Padding.Left;
            int padR = this.Padding.Right;
            int startX = padL;
            int startY = pnlTop.Bottom;
            int contentW = ClientSize.Width - padL - padR;
            int availH = ClientSize.Height - startY - this.Padding.Bottom;
            int chartH = Math.Min(280, (int)(availH * 0.35));
            int sumH = (int)((availH - chartH) * 0.35);
            int detailH = availH - chartH - sumH;
            int margin = 25;
            pnlChart.Location = new Point(startX, startY);
            pnlChart.Size = new Size(contentW, chartH);
            pnlSummary.Location = new Point(startX, startY + chartH);
            pnlSummary.Size = new Size(contentW, sumH);
            pnlDetail.Location = new Point(startX, startY + chartH + sumH);
            pnlDetail.Size = new Size(contentW, detailH);
            dgvSummary.Location = new Point(margin, 50);
            dgvSummary.Width = pnlSummary.Width - margin * 2;
            dgvSummary.Height = pnlSummary.Height - 80;
            dgvDetail.Location = new Point(margin, 50);
            dgvDetail.Width = pnlDetail.Width - margin * 2;
            dgvDetail.Height = pnlDetail.Height - 95;
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
                    pnlChart.Controls.Clear();
                    lblTongBai.Text = "Tổng số bài: 0";
                    lblTongTien.Text = "Tổng nhuận bút: 0 VNĐ";
                    lblDaChi.Text = "Đã chi: 0 VNĐ";
                    lblChuaChi.Text = "Chưa chi: 0 VNĐ";
                    MessageBox.Show("Không có dữ liệu trong tháng này!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

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

                decimal tongTien = summaryView.Sum(x => x.TongNB);
                decimal daChi = summaryView.Sum(x => x.DaChi);
                decimal chuaChi = summaryView.Sum(x => x.ChuaChi);
                int tongBai = dt.AsEnumerable().Select(r => r.Field<int>("Maso")).Distinct().Count();

                lblTongBai.Text = $"Tổng số bài: {tongBai}";
                lblTongTien.Text = $"Tổng nhuận bút: {tongTien:N0} VNĐ";
                lblDaChi.Text = $"Đã chi: {daChi:N0} VNĐ";
                lblChuaChi.Text = $"Chưa chi: {chuaChi:N0} VNĐ";

                DrawCharts(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawCharts(DataTable dt)
        {
            pnlChart.Controls.Clear();
            decimal daChi = dt.AsEnumerable()
                .Where(r => r["SauThanhToan"] != DBNull.Value && r["SauThanhToan"].ToString() == "Y")
                .Sum(r => Convert.ToDecimal(r["TienNhuanbut"]));
            decimal chuaChi = dt.AsEnumerable()
                .Where(r => r["SauThanhToan"] == DBNull.Value || r["SauThanhToan"].ToString() != "Y")
                .Sum(r => Convert.ToDecimal(r["TienNhuanbut"]));
            var topTacGia = dt.AsEnumerable()
                .GroupBy(r => r.Field<string>("TacGia") ?? "(Không có)")
                .Select(g => new { Name = g.Key, Total = g.Sum(r => Convert.ToDecimal(r["TienNhuanbut"])) })
                .OrderByDescending(x => x.Total)
                .Take(8)
                .ToList();
            int pieW = (int)(pnlChart.Width * 0.35);
            Panel pnlPie = new Panel { Dock = DockStyle.Left, Width = pieW, BackColor = Color.White };
            Panel pnlBar = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            pnlChart.Controls.Add(pnlBar);
            pnlChart.Controls.Add(pnlPie);
            GunaChart chartPie = new GunaChart { Dock = DockStyle.Fill, BackColor = Color.White };
            chartPie.Legend.Position = LegendPosition.Bottom;
            GunaDoughnutDataset dsPie = new GunaDoughnutDataset();
            Color[] palette = new Color[] {
                Color.FromArgb(16, 185, 129),
                Color.FromArgb(239, 68, 68)
            };
            foreach (var c in palette) dsPie.FillColors.Add(c);
            dsPie.DataPoints.Add("Đã chi", (double)daChi);
            dsPie.DataPoints.Add("Chưa chi", (double)chuaChi);
            chartPie.Datasets.Add(dsPie);
            pnlPie.Controls.Add(chartPie);
            chartPie.Update();
            GunaChart chartBar = new GunaChart { Dock = DockStyle.Fill, BackColor = Color.White };
            chartBar.Legend.Position = LegendPosition.Bottom;
            chartBar.XAxes.GridLines.Display = false;
            GunaHorizontalBarDataset dsBar = new GunaHorizontalBarDataset();
            foreach (var tg in topTacGia)
                dsBar.DataPoints.Add(tg.Name, (double)tg.Total);
            chartBar.Datasets.Add(dsBar);
            pnlBar.Controls.Add(chartBar);
            chartBar.Update();
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
