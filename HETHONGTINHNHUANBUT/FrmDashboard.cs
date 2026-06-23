using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
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
        private Timer timerClock;
        private Timer timerAnimation;
        private double animTick = 0;

        public FrmDashboard()
        {
            InitializeComponent();
            lblKPIValues = new Label[6] { lblBaiVietValue, lblPhongVienValue, lblNhuanButValue, lblBaiChuaDuyetValue, lblPhieuChiValue, lblCanhBaoValue };
            timerClock = new Timer();
            timerClock.Interval = 1000;
            timerClock.Tick += new EventHandler(timerClock_Tick);

            timerAnimation = new Timer();
            timerAnimation.Interval = 50;
            timerAnimation.Tick += TimerAnimation_Tick;
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            if (lblUpdate != null && !lblUpdate.IsDisposed)
                lblUpdate.Text = DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss");
        }

        private void pnlHeader_Resize(object sender, EventArgs e)
        {
            this.lblUpdate.Left = this.pnlHeader.Width - this.lblUpdate.Width - 12;
        }

        private void dgvHoatDong_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvHoatDong.ClearSelection();
        }

        private void TimerAnimation_Tick(object sender, EventArgs e)
        {
            animTick += 0.2;
            int offset = (int)(Math.Sin(animTick) * 4);
            
            lblIcon1.Top = 10 + offset;
            lblIcon2.Top = 10 + (int)(Math.Sin(animTick + 1) * 4);
            lblIcon3.Top = 10 + (int)(Math.Sin(animTick + 2) * 4);
            lblIcon4.Top = 10 + (int)(Math.Sin(animTick + 3) * 4);
            lblIcon5.Top = 10 + (int)(Math.Sin(animTick + 4) * 4);
            lblIcon6.Top = 10 + (int)(Math.Sin(animTick + 5) * 4);
        }

        private Color LightenColor(Color color, float amount)
        {
            int r = (int)(color.R + (255 - color.R) * amount);
            int g = (int)(color.G + (255 - color.G) * amount);
            int b = (int)(color.B + (255 - color.B) * amount);
            return Color.FromArgb(color.A, Math.Min(255, r), Math.Min(255, g), Math.Min(255, b));
        }

        private void SetupUIStyles()
        {
            var cards = new[] { card1, card2, card3, card4, card5, card6 };
            var colorPairs = new (Color c1, Color c2)[]
            {
                (Color.FromArgb(14, 165, 233), Color.FromArgb(56, 189, 248)), // Bright Cerulean -> Light Sky Blue
                (Color.FromArgb(139, 92, 246), Color.FromArgb(167, 139, 250)), // Bright Violet -> Light Violet
                (Color.FromArgb(16, 185, 129), Color.FromArgb(52, 211, 153)), // Bright Emerald -> Mint
                (Color.FromArgb(245, 158, 11), Color.FromArgb(251, 191, 36)), // Bright Amber -> Yellow
                (Color.FromArgb(244, 63, 94), Color.FromArgb(251, 113, 133)), // Bright Rose -> Pink
                (Color.FromArgb(239, 68, 68), Color.FromArgb(248, 113, 113))  // Bright Red -> Light Red
            };

            for (int i = 0; i < cards.Length; i++)
            {
                int captureIndex = i;
                EventHandler onEnter = (s, e) => {
                    cards[captureIndex].FillColor = LightenColor(colorPairs[captureIndex].c1, 0.2f);
                    cards[captureIndex].FillColor2 = LightenColor(colorPairs[captureIndex].c2, 0.2f);
                    cards[captureIndex].ShadowDecoration.Depth = 15;
                    cards[captureIndex].ShadowDecoration.Shadow = new Padding(0, 0, 10, 10);
                };
                EventHandler onLeave = (s, e) => {
                    if (cards[captureIndex].ClientRectangle.Contains(cards[captureIndex].PointToClient(Cursor.Position)))
                        return;
                    cards[captureIndex].FillColor = colorPairs[captureIndex].c1;
                    cards[captureIndex].FillColor2 = colorPairs[captureIndex].c2;
                    cards[captureIndex].ShadowDecoration.Depth = 8;
                    cards[captureIndex].ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
                };

                cards[i].MouseEnter += onEnter;
                cards[i].MouseLeave += onLeave;

                foreach (Control c in cards[i].Controls)
                {
                    c.MouseEnter += onEnter;
                    c.MouseLeave += onLeave;
                    c.Cursor = Cursors.Hand;
                }
            }
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            SetupUIStyles();
            timerClock.Start();
            timerAnimation.Start();
            _ = TaiDuLieuAsync();
        }

        // ================================================================
        // DỮ LIỆU
        // ================================================================

        private async Task TaiDuLieuAsync()
        {
            try
            {
                var kpiTasks = new Task<object>[]
                {
                    ExecuteScalarAsync("SELECT COUNT(*) FROM Nhuanbut"),
                    ExecuteScalarAsync("SELECT COUNT(DISTINCT Butdanh) FROM Nhuanbut"),
                    ExecuteScalarAsync("SELECT ISNULL(SUM(TienNhuanbut), 0) FROM Nhuanbut WHERE TrangThaiDuyet >= 0"),
                    ExecuteScalarAsync("SELECT COUNT(*) FROM Nhuanbut WHERE TrangThaiDuyet = 0"),
                    ExecuteScalarAsync("SELECT COUNT(*) FROM PhieuChi"),
                    ExecuteScalarAsync("SELECT COUNT(*) FROM AICanhBao WHERE DaXuLy = 0")
                };
                object[] kpiResults = await Task.WhenAll(kpiTasks);

                lblKPIValues[0].Text = Convert.ToInt32(kpiResults[0]).ToString("N0");
                lblKPIValues[1].Text = Convert.ToInt32(kpiResults[1]).ToString("N0");
                lblKPIValues[2].Text = Convert.ToDecimal(kpiResults[2]).ToString("N0");
                lblKPIValues[3].Text = Convert.ToInt32(kpiResults[3]).ToString("N0");
                lblKPIValues[4].Text = Convert.ToInt32(kpiResults[4]).ToString("N0");
                lblKPIValues[5].Text = Convert.ToInt32(kpiResults[5]).ToString("N0");

                await Task.WhenAll(
                    LoadChartNBThangAsync(),
                    LoadChartTopPVAsync(),
                    LoadChartBaiTheoCMAsync(),
                    LoadChartDiemAIAsync(),
                    LoadHoatDongGanDayAsync()
                );
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Dashboard: " + ex.Message);
            }
        }

        private async Task<object> ExecuteScalarAsync(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object result = await cmd.ExecuteScalarAsync();
                    return result ?? 0;
                }
            }
        }

        private async Task LoadChartNBThangAsync()
        {
            try
            {
                GunaSplineDataset ds = new GunaSplineDataset { Label = "Nhuận bút (VNĐ)" };
                ds.BorderColor = Color.FromArgb(79, 70, 229);
                ds.FillColor = Color.FromArgb(50, 79, 70, 229);
                ds.BorderWidth = 2;
                ds.PointRadius = 3;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT TOP 6
                            YEAR(ngaychuyen) AS Nam, MONTH(ngaychuyen) AS Thang,
                            ISNULL(SUM(TienNhuanbut), 0) AS Tong
                        FROM Nhuanbut WHERE TrangThaiDuyet >= 0
                        GROUP BY YEAR(ngaychuyen), MONTH(ngaychuyen)
                        ORDER BY Nam DESC, Thang DESC", conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            int t = Convert.ToInt32(r["Thang"]);
                            int n = Convert.ToInt32(r["Nam"]);
                            ds.DataPoints.Add($"T{t}/{n}", Convert.ToDouble(r["Tong"]));
                        }
                    }
                }

                chartNBThang.Datasets.Clear();
                chartNBThang.Datasets.Add(ds);
                chartNBThang.Legend.Display = false;
                chartNBThang.Update();
            }
            catch { }
        }

        private async Task LoadChartTopPVAsync()
        {
            try
            {
                GunaHorizontalBarDataset ds = new GunaHorizontalBarDataset { Label = "Tổng NB (VNĐ)" };
                ds.FillColors.Add(Color.FromArgb(16, 185, 129));
                ds.BorderColors.Add(Color.FromArgb(16, 185, 129));

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT TOP 10 Butdanh, ISNULL(SUM(TienNhuanbut), 0) AS Tong
                        FROM Nhuanbut WHERE TrangThaiDuyet >= 0
                        GROUP BY Butdanh ORDER BY Tong DESC", conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            string bd = r["Butdanh"]?.ToString() ?? "";
                            ds.DataPoints.Add(bd, Convert.ToDouble(r["Tong"]));
                        }
                    }
                }

                chartTopPV.Datasets.Clear();
                chartTopPV.Datasets.Add(ds);
                chartTopPV.Legend.Display = false;
                chartTopPV.Update();
            }
            catch { }
        }

        private async Task LoadChartBaiTheoCMAsync()
        {
            try
            {
                GunaDoughnutDataset ds = new GunaDoughnutDataset();
                Color[] sliceColors = new Color[8] {
                    Color.FromArgb(79, 70, 229), Color.FromArgb(16, 185, 129),
                    Color.FromArgb(245, 158, 11), Color.FromArgb(239, 68, 68),
                    Color.FromArgb(59, 130, 246), Color.FromArgb(168, 85, 247),
                    Color.FromArgb(236, 72, 153), Color.FromArgb(20, 184, 166)
                };
                foreach (var c in sliceColors)
                {
                    ds.FillColors.Add(c);
                    ds.BorderColors.Add(c);
                }

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT Muc, COUNT(*) AS SoBai
                        FROM Nhuanbut WHERE TrangThaiDuyet >= 0
                        GROUP BY Muc ORDER BY SoBai DESC", conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            string muc = r["Muc"]?.ToString() ?? "";
                            ds.DataPoints.Add(muc, Convert.ToInt32(r["SoBai"]));
                        }
                    }
                }

                chartBaiTheoCM.Datasets.Clear();
                chartBaiTheoCM.Datasets.Add(ds);
                chartBaiTheoCM.Legend.Position = LegendPosition.Bottom;
                chartBaiTheoCM.Update();
            }
            catch { }
        }

        private async Task LoadChartDiemAIAsync()
        {
            try
            {
                GunaBarDataset ds = new GunaBarDataset { Label = "Điểm TB" };
                ds.FillColors.Add(Color.FromArgb(59, 130, 246));
                ds.BorderColors.Add(Color.FromArgb(59, 130, 246));

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT Muc, AVG(DiemChatLuongAI) AS DiemTB
                        FROM Nhuanbut
                        WHERE DiemChatLuongAI IS NOT NULL AND TrangThaiDuyet >= 0
                        GROUP BY Muc
                        HAVING AVG(DiemChatLuongAI) > 0
                        ORDER BY DiemTB DESC", conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            string muc = r["Muc"]?.ToString() ?? "";
                            ds.DataPoints.Add(muc, Convert.ToDouble(r["DiemTB"]));
                        }
                    }
                }

                chartDiemAI.Datasets.Clear();
                chartDiemAI.Datasets.Add(ds);
                chartDiemAI.Legend.Display = false;
                chartDiemAI.Update();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi LoadChartDiemAI: " + ex.Message);
            }
        }

        private async Task LoadHoatDongGanDayAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    string sql = @"
                        SELECT TOP 10 Sophieu, Ngaylap, Nguoinhan, Sotien,
                               CASE WHEN TrangThaiDuyet = 1 THEN N'Đã duyệt' ELSE N'Đang chờ' END AS TT
                        FROM PhieuChi
                        ORDER BY Ngaylap DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        var items = new List<dynamic>();
                        while (await r.ReadAsync())
                        {
                            items.Add(new
                            {
                                SoPhieu = r["Sophieu"].ToString(),
                                Ngay = Convert.ToDateTime(r["Ngaylap"]),
                                Nhan = r["Nguoinhan"].ToString(),
                                Tien = Convert.ToDecimal(r["Sotien"]).ToString("N0"),
                                TT = r["TT"].ToString()
                            });
                        }
                        dgvHoatDong.DataSource = items;
                    }
                }

                if (dgvHoatDong.Columns["SoPhieu"] != null)
                {
                    dgvHoatDong.Columns["SoPhieu"].HeaderText = "SỐ PHIẾU";
                    dgvHoatDong.Columns["Ngay"].HeaderText = "NGÀY LẬP";
                    dgvHoatDong.Columns["Nhan"].HeaderText = "NGƯỜI NHẬN";
                    dgvHoatDong.Columns["Tien"].HeaderText = "TIỀN CHI (VNĐ)";
                    dgvHoatDong.Columns["TT"].HeaderText = "TRẠNG THÁI";
                    dgvHoatDong.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                dgvHoatDong.ClearSelection();
            }
            catch { }
        }

    }
}
