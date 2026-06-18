using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTongQuan : Form
    {
        private Timer timerClock;
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmTongQuan()
        {
            InitializeComponent();

            timerClock = new Timer();
            timerClock.Interval = 1000;
            timerClock.Tick += TimerClock_Tick;

            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(dgvHoatDong, true, null);

            dgvHoatDong.SelectionChanged += DgvHoatDong_SelectionChanged;
        }

        private async void FrmTongQuan_Load(object sender, EventArgs e)
        {
            timerClock.Start();
            label5.Text = "BIẾN ĐỘNG CHI TRẢ NHUẬN BÚT TOÀN THỜI GIAN";
            UIHelper.FormatGiaoDienBang(dgvHoatDong);

            await Task.WhenAll(
                LoadThongKe4TheAsync(),
                LoadHoatDongGanDayAsync(),
                VeBieuDoDuongAsync(),
                VeBieuDoTronAsync()
            );
        }

        private void TimerClock_Tick(object sender, EventArgs e)
        {
            lblUpdate.Text = "Thời gian thực: " + DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss");
        }

        private void DgvHoatDong_SelectionChanged(object sender, EventArgs e)
        {
            dgvHoatDong.ClearSelection();
        }

        async Task LoadThongKe4TheAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sqlQuery = @"
                        SELECT
                            (SELECT COUNT(*) FROM Nhuanbut) AS TongBai,
                            (SELECT COUNT(*) FROM TacGia) AS TongTG,
                            (SELECT ISNULL(SUM(Sotien), 0) FROM Phieuchi WHERE TrangThaiDuyet = 1) AS TongTienChi,
                            (SELECT COUNT(*) FROM Phieuchi WHERE TrangThaiDuyet = 0) AS SoPhieuCho";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        if (await r.ReadAsync())
                        {
                            lblSoBaiViet.Text = Convert.ToInt32(r["TongBai"]).ToString("N0");
                            lblSoTacGia.Text = Convert.ToInt32(r["TongTG"]).ToString("N0");
                            lblTongTien.Text = Convert.ToDecimal(r["TongTienChi"]).ToString("N0");
                            lblSoBaoCho.Text = Convert.ToInt32(r["SoPhieuCho"]).ToString("N0");
                        }
                    }
                }
            }
            catch { }
        }

        async Task VeBieuDoDuongAsync()
        {
            try
            {
                pnlChartMain.Controls.Clear();
                GunaChart chartLine = new GunaChart { Dock = DockStyle.Fill, BackColor = Color.White };

                chartLine.XAxes.GridLines.Display = false;
                chartLine.YAxes.GridLines.Display = true;

                GunaSplineDataset dataset = new GunaSplineDataset { Label = "Nhuận bút (VNĐ)" };
                dataset.BorderColor = Color.FromArgb(46, 109, 228);
                dataset.FillColor = Color.FromArgb(50, 46, 109, 228);
                dataset.BorderWidth = 2;
                dataset.PointRadius = 3;

                var dataPoints = new Dictionary<int, double>();

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                        SELECT MONTH(Ngaylap) as M, YEAR(Ngaylap) as Y, SUM(Sotien) as T
                        FROM Phieuchi
                        WHERE Sotien > 0 AND TrangThaiDuyet = 1
                        GROUP BY YEAR(Ngaylap), MONTH(Ngaylap)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            int key = Convert.ToInt32(r["Y"]) * 100 + Convert.ToInt32(r["M"]);
                            dataPoints[key] = Convert.ToDouble(r["T"]);
                        }
                    }
                }

                var sortedData = dataPoints.OrderBy(x => x.Key).ToList();
                foreach (var item in sortedData)
                {
                    string label = (item.Key % 100).ToString() + "/" + (item.Key / 100).ToString();
                    dataset.DataPoints.Add(label, item.Value);
                }

                chartLine.Datasets.Add(dataset);
                chartLine.Update();
                pnlChartMain.Controls.Add(chartLine);
            }
            catch (Exception ex) { Console.WriteLine("Lỗi biểu đồ: " + ex.Message); }
        }

        async Task LoadHoatDongGanDayAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"
                        SELECT TOP 10 Sophieu, Ngaylap, Nguoinhan, Sotien,
                               CASE WHEN TrangThaiDuyet = 1 THEN N'Đã duyệt' ELSE N'Đang chờ' END AS TT
                        FROM Phieuchi
                        ORDER BY Ngaylap DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(r);

                        dgvHoatDong.DataSource = dt.AsEnumerable().Select(row => new
                        {
                            SoPhieu = row["Sophieu"].ToString(),
                            Ngay = Convert.ToDateTime(row["Ngaylap"]),
                            Nhan = row["Nguoinhan"].ToString(),
                            Tien = Convert.ToDecimal(row["Sotien"]).ToString("N0"),
                            TT = row["TT"].ToString()
                        }).ToList();
                    }
                }

                if (dgvHoatDong.Columns["Ngay"] != null)
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

        async Task VeBieuDoTronAsync()
        {
            try
            {
                pnlChartPie.Controls.Clear();
                GunaChart chartPie = new GunaChart { Dock = DockStyle.Fill, BackColor = Color.White };
                GunaDoughnutDataset dataset = new GunaDoughnutDataset();
                Color[] palette = new Color[] {
                    Color.FromArgb(59, 130, 246),   // xanh lam
                    Color.FromArgb(16, 185, 129),   // xanh la
                    Color.FromArgb(239, 68, 68),    // do
                    Color.FromArgb(245, 158, 11),   // cam
                    Color.FromArgb(139, 92, 246),   // tim
                    Color.FromArgb(236, 72, 153),   // hong
                    Color.FromArgb(14, 165, 233),   // xanh duong
                    Color.FromArgb(168, 85, 247),   // tim nhat
                    Color.FromArgb(249, 115, 22),   // cam dam
                    Color.FromArgb(34, 197, 94),    // xanh la dam
                    Color.FromArgb(100, 116, 139),  // xam
                    Color.FromArgb(244, 63, 94)     // do hong
                };
                foreach (var c in palette)
                    dataset.FillColors.Add(c);

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT Loaibao, COUNT(*) as SoLuong FROM Bao GROUP BY Loaibao";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            string loai = r["Loaibao"]?.ToString();
                            if (string.IsNullOrEmpty(loai)) loai = "Khác";
                            int count = Convert.ToInt32(r["SoLuong"]);
                            dataset.DataPoints.Add(loai, count);
                        }
                    }
                }

                chartPie.Datasets.Add(dataset);
                chartPie.Update();
                pnlChartPie.Controls.Add(chartPie);
            }
            catch { }
        }
    }
}
