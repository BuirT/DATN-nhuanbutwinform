using Guna.Charts.WinForms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTongQuan : Form
    {
        private Timer timerClock;
        private readonly IMongoCollection<PhieuChi> _phieuChiColl;
        private readonly IMongoCollection<Bao> _baoColl;
        private readonly string sqlConnectionString = @"Server=LAPTOP-K8EKOOUM\SQLEXPRESS;Database=TN;Trusted_Connection=True;";

        public FrmTongQuan()
        {
            InitializeComponent();
            _phieuChiColl = MongoProvider.Instance.GetCollection<PhieuChi>("PhieuChi");
            _baoColl = MongoProvider.Instance.GetCollection<Bao>("Bao");

            timerClock = new Timer();
            timerClock.Interval = 1000;
            timerClock.Tick += TimerClock_Tick;
        }

        private async void FrmTongQuan_Load(object sender, EventArgs e)
        {
            timerClock.Start();
            label5.Text = "BIẾN ĐỘNG CHI TRẢ NHUẬN BÚT TOÀN THỜI GIAN";

            // 1. Chỉnh sửa chi tiết màu sắc bảng
            FixMauSacBangHoatDong();

            // 2. Load dữ liệu
            await Task.WhenAll(
                LoadThongKe4TheSuperHybridAsync(),
                LoadHoatDongGanDayCombinedAsync(),
                VeBieuDoDuongSuperHybridAsync(),
                VeBieuDoTronAllTimeAsync()
            );
        }

        private void TimerClock_Tick(object sender, EventArgs e)
        {
            lblUpdate.Text = "Thời gian thực: " + DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss");
        }

        private void FixMauSacBangHoatDong()
        {
            // Thiết lập màu nền và font chữ cho Header
            dgvHoatDong.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215); // Màu xanh đậm chuyên nghiệp
            dgvHoatDong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHoatDong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvHoatDong.ColumnHeadersHeight = 45;

            // Màu dòng chẵn và dòng lẻ
            dgvHoatDong.DefaultCellStyle.BackColor = Color.White;
            dgvHoatDong.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 245, 250); // Xám nhạt

            // Màu khi người dùng click chọn dòng
            dgvHoatDong.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvHoatDong.DefaultCellStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);

            // Bỏ các đường kẻ dọc để bảng trông thoáng hơn
            dgvHoatDong.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHoatDong.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvHoatDong.EnableHeadersVisualStyles = false;
        }

        async Task LoadThongKe4TheSuperHybridAsync()
        {
            try
            {
                decimal sqlTongTien = 0;
                int sqlTongBai = 0, sqlTongTG = 0;

                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sqlQuery = @"SELECT (SELECT COUNT(*) FROM Nhuanbut) AS TongBai, 
                                               (SELECT COUNT(*) FROM TacGia) AS TongTG,
                                               (SELECT SUM(Sotien) FROM Phieuchi) AS TongTienChi";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        if (await r.ReadAsync())
                        {
                            sqlTongBai = Convert.ToInt32(r["TongBai"]);
                            sqlTongTG = Convert.ToInt32(r["TongTG"]);
                            sqlTongTien = r["TongTienChi"] != DBNull.Value ? Convert.ToDecimal(r["TongTienChi"]) : 0;
                        }
                    }
                }

                var listPhieuMongo = await _phieuChiColl.Find(p => p.TrangThaiDuyet == 1).ToListAsync();
                decimal mongoTongTien = listPhieuMongo.Sum(x => (decimal)x.TongTien);
                var soPhieuChoMongo = await _phieuChiColl.CountDocumentsAsync(p => p.TrangThaiDuyet == 0);

                lblSoBaiViet.Text = sqlTongBai.ToString("N0");
                lblSoTacGia.Text = sqlTongTG.ToString("N0");
                lblTongTien.Text = (sqlTongTien + mongoTongTien).ToString("N0");
                lblSoBaoCho.Text = soPhieuChoMongo.ToString("N0");
            }
            catch { }
        }

        async Task VeBieuDoDuongSuperHybridAsync()
        {
            try
            {
                pnlChartMain.Controls.Clear();
                GunaChart chartLine = new GunaChart { Dock = DockStyle.Fill, BackColor = Color.White };

                // Cấu hình trục tọa độ để hiển thị dải thời gian dài (từ 2004)
                chartLine.XAxes.GridLines.Display = false;
                chartLine.YAxes.GridLines.Display = true;

                GunaLineDataset dataset = new GunaLineDataset { Label = "Nhuận bút (VNĐ)" };
                dataset.BorderColor = Color.FromArgb(46, 109, 228);
                dataset.FillColor = Color.FromArgb(50, 46, 109, 228);
                dataset.BorderWidth = 2;
                dataset.PointRadius = 0; // Tắt điểm để biểu đồ mượt hơn khi có quá nhiều dữ liệu

                var dataPoints = new Dictionary<int, double>();

                // 1. Lấy toàn bộ từ SQL
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT MONTH(Ngaylap) as M, YEAR(Ngaylap) as Y, SUM(Sotien) as T FROM Phieuchi WHERE Sotien > 0 GROUP BY YEAR(Ngaylap), MONTH(Ngaylap)";
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

                // 2. Lấy từ Mongo và cộng dồn
                var listPhieuMongo = await _phieuChiColl.Find(p => p.TrangThaiDuyet == 1).ToListAsync();
                foreach (var p in listPhieuMongo)
                {
                    int key = p.NgayLap.Year * 100 + p.NgayLap.Month;
                    if (dataPoints.ContainsKey(key)) dataPoints[key] += (double)p.TongTien;
                    else dataPoints[key] = (double)p.TongTien;
                }

                // 3. Sắp xếp và đưa lên biểu đồ
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

        async Task LoadHoatDongGanDayCombinedAsync()
        {
            try
            {
                var combinedList = new List<dynamic>();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = "SELECT TOP 5 Sophieu, Ngaylap, Nguoinhan, Sotien FROM Phieuchi ORDER BY Ngaylap DESC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            combinedList.Add(new
                            {
                                SoPhieu = r["Sophieu"].ToString(),
                                Ngay = Convert.ToDateTime(r["Ngaylap"]),
                                Nhan = r["Nguoinhan"].ToString(),
                                Tien = Convert.ToDecimal(r["Sotien"]).ToString("N0"),
                                TT = "Đã duyệt"
                            });
                        }
                    }
                }

                var mongoList = await _phieuChiColl.Find(_ => true).SortByDescending(p => p.NgayLap).Limit(5).ToListAsync();
                foreach (var p in mongoList)
                {
                    combinedList.Add(new { SoPhieu = p.SoPhieu, Ngay = p.NgayLap, Nhan = p.NguoiNhan, Tien = p.TongTien.ToString("N0"), TT = p.TrangThaiDuyet == 1 ? "Đã duyệt" : "Đang chờ" });
                }

                dgvHoatDong.DataSource = combinedList.OrderByDescending(x => x.Ngay).Take(10).ToList();
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

        async Task VeBieuDoTronAllTimeAsync()
        {
            try
            {
                pnlChartPie.Controls.Clear();
                GunaChart chartPie = new GunaChart { Dock = DockStyle.Fill, BackColor = Color.White };
                GunaDoughnutDataset dataset = new GunaDoughnutDataset();
                dataset.FillColors.Add(Color.FromArgb(59, 130, 246));
                dataset.FillColors.Add(Color.FromArgb(16, 185, 129));

                var listBao = await _baoColl.Find(_ => true).ToListAsync();
                var dataPie = listBao.GroupBy(b => b.Loaibao)
                                     .Select(g => new { Loai = string.IsNullOrEmpty(g.Key) ? "Khác" : g.Key, Count = g.Count() })
                                     .ToList();

                foreach (var item in dataPie) dataset.DataPoints.Add(item.Loai, item.Count);
                chartPie.Datasets.Add(dataset);
                chartPie.Update();
                pnlChartPie.Controls.Add(chartPie);
            }
            catch { }
        }
    }
}