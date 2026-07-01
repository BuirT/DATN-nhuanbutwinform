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

        private Guna.Charts.WinForms.GunaChart chartPie;
        private Guna.Charts.WinForms.GunaChart chartBar;
        private Guna.Charts.WinForms.GunaDoughnutDataset dsPie;
        private Guna.Charts.WinForms.GunaHorizontalBarDataset dsBar;
        private Panel pnlPie, pnlBar;

        public FrmBaoCaoLanhDao()
        {
            InitializeComponent();
        }

        private async void FrmBaoCaoLanhDao_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvSummary);
            UIHelper.FormatGiaoDienBang(dgvDetail);
            CreateCharts();
            await LoadDataAsync();
        }

        private void CreateCharts()
        {
            int pieW = (int)(pnlChart.Width * 0.35);
            pnlPie = new Panel { Dock = DockStyle.Left, Width = pieW, BackColor = Color.White };
            pnlBar = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };

            chartPie = new Guna.Charts.WinForms.GunaChart { Dock = DockStyle.Fill, BackColor = Color.White };
            chartPie.Legend.Position = LegendPosition.Bottom;
            dsPie = new Guna.Charts.WinForms.GunaDoughnutDataset();
            Color[] palette = new Color[] {
                Color.FromArgb(16, 185, 129),
                Color.FromArgb(239, 68, 68)
            };
            foreach (var c in palette) dsPie.FillColors.Add(c);
            dsPie.DataPoints.Add("Đã chi", 0);
            dsPie.DataPoints.Add("Chưa chi", 0);
            chartPie.Datasets.Add(dsPie);
            pnlPie.Controls.Add(chartPie);

            chartBar = new Guna.Charts.WinForms.GunaChart { Dock = DockStyle.Fill, BackColor = Color.White };
            chartBar.Legend.Position = LegendPosition.Bottom;
            chartBar.XAxes.GridLines.Display = false;
            dsBar = new Guna.Charts.WinForms.GunaHorizontalBarDataset();
            chartBar.Datasets.Add(dsBar);
            pnlBar.Controls.Add(chartBar);

            pnlChart.Controls.Add(pnlBar);
            pnlChart.Controls.Add(pnlPie);
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
                    dsPie.DataPoints.Clear();
                    dsPie.DataPoints.Add("Đã chi", 0);
                    dsPie.DataPoints.Add("Chưa chi", 0);
                    chartPie.Update();
                    dsBar.DataPoints.Clear();
                    chartBar.Update();
                    lblTongBai.Text = "Tổng số bài: 0";
                    lblTongTien.Text = "Tổng nhuận bút: 0 VNĐ";
                    lblDaChi.Text = "Đã chi: 0 VNĐ";
                    lblChuaChi.Text = "Chưa chi: 0 VNĐ";
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

                dgvDetail.SuspendLayout();
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
                dgvDetail.ResumeLayout();

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

                dgvSummary.SuspendLayout();
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
                dgvSummary.ResumeLayout();

                decimal tongTien = summaryView.Sum(x => x.TongNB);
                decimal daChi = summaryView.Sum(x => x.DaChi);
                decimal chuaChi = summaryView.Sum(x => x.ChuaChi);
                int tongBai = summaryView.Sum(x => x.SoBai);

                lblTongBai.Text = $"Tổng số bài: {tongBai}";
                lblTongTien.Text = $"Tổng nhuận bút: {tongTien:N0} VNĐ";
                lblDaChi.Text = $"Đã chi: {daChi:N0} VNĐ";
                lblChuaChi.Text = $"Chưa chi: {chuaChi:N0} VNĐ";

                var topTacGia = summaryView
                    .OrderByDescending(x => x.TongNB)
                    .Take(8)
                    .Select(x => new { x.TacGia, x.TongNB })
                    .ToList();

                UpdateCharts(daChi, chuaChi, topTacGia);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCharts(decimal daChi, decimal chuaChi, dynamic topTacGia)
        {
            dsPie.DataPoints.Clear();
            dsPie.DataPoints.Add("Đã chi", (double)daChi);
            dsPie.DataPoints.Add("Chưa chi", (double)chuaChi);
            chartPie.Update();

            dsBar.DataPoints.Clear();
            foreach (var tg in topTacGia)
            {
                string name = tg.TacGia;
                double val = (double)(decimal)tg.TongNB;
                dsBar.DataPoints.Add(name, val);
            }
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
