using Guna.Charts.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmDashboard : Form
    {
        private readonly string connStr =
            System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        private Label[] lblKPIValues;
        private GunaChart chartNBThang;
        private GunaChart chartTopPV;
        private GunaChart chartBaiTheoCM;
        private GunaChart chartDiemAI;

        public FrmDashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private async void FrmDashboard_Load(object sender, EventArgs e)
        {
            TaoGiaoDien();
            await TaiDuLieuAsync();
        }

        private void TaoGiaoDien()
        {
            pnlMain.Controls.Clear();
            pnlMain.AutoScroll = true;
            pnlMain.Padding = new Padding(20);

            FlowLayoutPanel flpKPI = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 120,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(0, 0, 0, 10)
            };

            string[] kpiTitles = { "TỔNG BÀI VIẾT", "TỔNG PV", "NB ĐÃ CHI", "BÀI CHƯA DUYỆT", "PHIẾU CHI", "CẢNH BÁO AI" };
            string[] kpiIcons = { "📰", "✍️", "💰", "⏳", "📋", "⚠️" };
            Color[] kpiColors = {
                Color.FromArgb(79, 70, 229),
                Color.FromArgb(16, 185, 129),
                Color.FromArgb(245, 158, 11),
                Color.FromArgb(239, 68, 68),
                Color.FromArgb(59, 130, 246),
                Color.FromArgb(168, 85, 247)
            };

            lblKPIValues = new Label[6];

            for (int i = 0; i < 6; i++)
            {
                Guna2Panel card = new Guna2Panel
                {
                    Size = new Size(190, 100),
                    FillColor = Color.White,
                    BorderRadius = 12,
                    ShadowDecoration = { Enabled = true, Shadow = new Padding(0, 0, 4, 4) },
                    Margin = new Padding(8, 0, 8, 0)
                };

                Label lblIcon = new Label
                {
                    Text = kpiIcons[i],
                    Font = new Font("Segoe UI", 18),
                    Location = new Point(14, 10),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                Label lblValue = new Label
                {
                    Text = "...",
                    Font = new Font("Segoe UI", 22, FontStyle.Bold),
                    ForeColor = kpiColors[i],
                    Location = new Point(14, 36),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                lblKPIValues[i] = lblValue;

                Label lblTitle = new Label
                {
                    Text = kpiTitles[i],
                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                    ForeColor = Color.FromArgb(100, 116, 139),
                    Location = new Point(14, 66),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                card.Controls.Add(lblIcon);
                card.Controls.Add(lblValue);
                card.Controls.Add(lblTitle);
                flpKPI.Controls.Add(card);
            }

            pnlMain.Controls.Add(flpKPI);

            TableLayoutPanel tlpCharts = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                Padding = new Padding(0, 10, 0, 0)
            };
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tlpCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tlpCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            tlpCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

            chartNBThang = TaoChart("Nhuận bút theo tháng");
            chartTopPV = TaoChart("Top 10 PV nhận NB cao nhất");
            chartBaiTheoCM = TaoChart("Bài viết theo chuyên mục");
            chartDiemAI = TaoChart("Điểm AI TB theo chuyên mục");

            tlpCharts.Controls.Add(BocChart(chartNBThang, "Nhuận bút theo tháng"), 0, 0);
            tlpCharts.Controls.Add(BocChart(chartTopPV, "Top 10 PV nhận NB cao nhất"), 1, 0);
            tlpCharts.Controls.Add(BocChart(chartBaiTheoCM, "Bài viết theo chuyên mục"), 0, 1);
            tlpCharts.Controls.Add(BocChart(chartDiemAI, "Điểm AI TB theo chuyên mục"), 1, 1);

            pnlMain.Controls.Add(tlpCharts);
        }

        private GunaChart TaoChart(string title)
        {
            GunaChart chart = new GunaChart
            {
                Width = 580,
                Height = 230,
                Location = new Point(0, 28)
            };

            chart.XAxes.Display = true;
            chart.YAxes.Display = true;
            chart.YAxes.GridLines.Display = false;

            return chart;
        }

        private Guna2Panel BocChart(GunaChart chart, string title)
        {
            Guna2Panel panel = new Guna2Panel
            {
                Size = new Size(590, 280),
                FillColor = Color.White,
                BorderRadius = 12,
                Margin = new Padding(8),
                ShadowDecoration = { Enabled = true, Shadow = new Padding(0, 0, 4, 4) }
            };

            Label lbl = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(12, 8),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            chart.Parent = panel;
            chart.Size = new Size(panel.Width - 20, panel.Height - 38);
            chart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel.Controls.Add(lbl);
            panel.Controls.Add(chart);
            return panel;
        }

        private async Task TaiDuLieuAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();

                    lblKPIValues[0].Text = Convert.ToInt32(await ExecuteScalarAsync(conn,
                        "SELECT COUNT(*) FROM Nhuanbut")).ToString("N0");

                    lblKPIValues[1].Text = Convert.ToInt32(await ExecuteScalarAsync(conn,
                        "SELECT COUNT(DISTINCT Butdanh) FROM Nhuanbut")).ToString("N0");

                    decimal tongChi = Convert.ToDecimal(await ExecuteScalarAsync(conn,
                        "SELECT ISNULL(SUM(TienNhuanbut), 0) FROM Nhuanbut WHERE TrangThaiDuyet >= 0"));
                    lblKPIValues[2].Text = tongChi.ToString("N0");

                    lblKPIValues[3].Text = Convert.ToInt32(await ExecuteScalarAsync(conn,
                        "SELECT COUNT(*) FROM Nhuanbut WHERE TrangThaiDuyet = 0")).ToString("N0");

                    lblKPIValues[4].Text = Convert.ToInt32(await ExecuteScalarAsync(conn,
                        "SELECT COUNT(*) FROM PhieuChi")).ToString("N0");

                    lblKPIValues[5].Text = Convert.ToInt32(await ExecuteScalarAsync(conn,
                        "SELECT COUNT(*) FROM AICanhBao WHERE DaXuLy = 0")).ToString("N0");

                    await LoadChartNBThang(conn);
                    await LoadChartTopPV(conn);
                    await LoadChartBaiTheoCM(conn);
                    await LoadChartDiemAI(conn);
                }
            }
            catch { }
        }

        private async Task LoadChartNBThang(SqlConnection conn)
        {
            GunaSplineDataset ds = new GunaSplineDataset();
            ds.BorderColor = Color.FromArgb(79, 70, 229);
            ds.FillColor = Color.FromArgb(50, 79, 70, 229);
            ds.BorderWidth = 2;
            ds.PointRadius = 3;

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT TOP 6
                    YEAR(ngaychuyen) AS Nam,
                    MONTH(ngaychuyen) AS Thang,
                    ISNULL(SUM(TienNhuanbut), 0) AS Tong
                FROM Nhuanbut
                WHERE TrangThaiDuyet >= 0
                GROUP BY YEAR(ngaychuyen), MONTH(ngaychuyen)
                ORDER BY Nam DESC, Thang DESC", conn))
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    int thang = Convert.ToInt32(reader["Thang"]);
                    int nam = Convert.ToInt32(reader["Nam"]);
                    decimal tong = Convert.ToDecimal(reader["Tong"]);
                    ds.DataPoints.Add(string.Format("T{0}/{1}", thang, nam), (double)tong);
                }
            }

            chartNBThang.Datasets.Clear();
            chartNBThang.Datasets.Add(ds);
            chartNBThang.Update();
        }

        private async Task LoadChartTopPV(SqlConnection conn)
        {
            GunaHorizontalBarDataset ds = new GunaHorizontalBarDataset();
            ds.FillColors.Add(Color.FromArgb(16, 185, 129));
            ds.BorderColors.Add(Color.FromArgb(16, 185, 129));

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT TOP 10 Butdanh, ISNULL(SUM(TienNhuanbut), 0) AS Tong
                FROM Nhuanbut WHERE TrangThaiDuyet >= 0
                GROUP BY Butdanh ORDER BY Tong DESC", conn))
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    string butDanh = reader["Butdanh"]?.ToString() ?? "";
                    decimal tong = Convert.ToDecimal(reader["Tong"]);
                    ds.DataPoints.Add(butDanh, (double)tong);
                }
            }

            chartTopPV.Datasets.Clear();
            chartTopPV.Datasets.Add(ds);
            chartTopPV.Update();
        }

        private async Task LoadChartBaiTheoCM(SqlConnection conn)
        {
            GunaDoughnutDataset ds = new GunaDoughnutDataset();
            Color[] sliceColors = {
                Color.FromArgb(79, 70, 229),
                Color.FromArgb(16, 185, 129),
                Color.FromArgb(245, 158, 11),
                Color.FromArgb(239, 68, 68),
                Color.FromArgb(59, 130, 246),
                Color.FromArgb(168, 85, 247),
                Color.FromArgb(236, 72, 153),
                Color.FromArgb(20, 184, 166)
            };
            foreach (var c in sliceColors)
            {
                ds.FillColors.Add(c);
                ds.BorderColors.Add(c);
            }

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT Muc, COUNT(*) AS SoBai
                FROM Nhuanbut WHERE TrangThaiDuyet >= 0
                GROUP BY Muc ORDER BY SoBai DESC", conn))
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    string muc = reader["Muc"]?.ToString() ?? "";
                    int soBai = Convert.ToInt32(reader["SoBai"]);
                    ds.DataPoints.Add(muc, soBai);
                }
            }

            chartBaiTheoCM.Datasets.Clear();
            chartBaiTheoCM.Datasets.Add(ds);
            chartBaiTheoCM.Update();
        }

        private async Task LoadChartDiemAI(SqlConnection conn)
        {
            GunaBarDataset ds = new GunaBarDataset();
            ds.FillColors.Add(Color.FromArgb(59, 130, 246));
            ds.BorderColors.Add(Color.FromArgb(59, 130, 246));

            using (SqlCommand cmd = new SqlCommand(@"
                SELECT Muc, AVG(DiemChatLuongAI) AS DiemTB
                FROM Nhuanbut
                WHERE DiemChatLuongAI IS NOT NULL AND TrangThaiDuyet >= 0
                GROUP BY Muc
                HAVING AVG(DiemChatLuongAI) > 0
                ORDER BY DiemTB DESC", conn))
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    string muc = reader["Muc"]?.ToString() ?? "";
                    double diem = Convert.ToDouble(reader["DiemTB"]);
                    ds.DataPoints.Add(muc, diem);
                }
            }

            chartDiemAI.Datasets.Clear();
            chartDiemAI.Datasets.Add(ds);
            chartDiemAI.Update();
        }

        private async Task<object> ExecuteScalarAsync(SqlConnection conn, string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                object result = await cmd.ExecuteScalarAsync();
                return result ?? 0;
            }
        }
    }
}
