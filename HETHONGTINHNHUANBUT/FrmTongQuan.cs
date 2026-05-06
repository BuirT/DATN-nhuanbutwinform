using Guna.Charts.WinForms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTongQuan : Form
    {
        private Timer timerClock;
        private readonly IMongoCollection<TacGia> _tacGiaColl;
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;
        private readonly IMongoCollection<PhieuChi> _phieuChiColl;
        private readonly IMongoCollection<Bao> _baoColl;

        public FrmTongQuan()
        {
            InitializeComponent();

            // Khởi tạo kết nối MongoDB
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
            _phieuChiColl = MongoProvider.Instance.GetCollection<PhieuChi>("PhieuChi");
            _baoColl = MongoProvider.Instance.GetCollection<Bao>("Bao");

            // Cấu hình đồng hồ chạy mỗi 1 giây
            timerClock = new Timer();
            timerClock.Interval = 1000;
            timerClock.Tick += TimerClock_Tick;
        }

        private async void FrmTongQuan_Load(object sender, EventArgs e)
        {
            timerClock.Start();

            FormatGiaoDienBang();

            await ThongKe4TheAsync();
            await LoadTopPhieuChiAsync();
            await VeBieuDoDuongAsync();
            await VeBieuDoTronAsync();
        }

        private void TimerClock_Tick(object sender, EventArgs e)
        {
            lblUpdate.Text = "Thời gian thực: " + DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss");
        }

        // ==========================================
        // HÀM FORMAT GIAO DIỆN BẢNG DỮ LIỆU
        // ==========================================
        private void FormatGiaoDienBang()
        {
            // Màu Tiêu đề Cột
            dgvHoatDong.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvHoatDong.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            dgvHoatDong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvHoatDong.ColumnHeadersHeight = 45;

            // Ép màu chọn của Tiêu đề (Chống xanh lè)
            dgvHoatDong.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dgvHoatDong.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(100, 116, 139);

            // Màu Dòng chẵn lẻ
            dgvHoatDong.DefaultCellStyle.BackColor = Color.White;
            dgvHoatDong.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            // Màu Chữ và Selection (khi click vào dòng)
            dgvHoatDong.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvHoatDong.DefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
            dgvHoatDong.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvHoatDong.RowTemplate.Height = 40;
            dgvHoatDong.EnableHeadersVisualStyles = false;
        }

        // ==========================================
        // 1. THỐNG KÊ 4 THẺ TỔNG QUAN
        // ==========================================
        async Task ThongKe4TheAsync()
        {
            try
            {
                long soTacGia = await _tacGiaColl.CountDocumentsAsync(_ => true);
                lblSoTacGia.Text = soTacGia.ToString("N0");

                long soBaiViet = await _nhuanButColl.CountDocumentsAsync(_ => true);
                lblSoBaiViet.Text = soBaiViet.ToString("N0");

                var listPhieuDuyet = await _phieuChiColl.Find(p => p.TrangThaiDuyet == 1).ToListAsync();
                decimal tongTien = listPhieuDuyet.Sum(x => x.TongTien);
                lblTongTien.Text = tongTien.ToString("N0");

                long soPhieuCho = await _phieuChiColl.CountDocumentsAsync(p => p.TrangThaiDuyet == 0);
                lblSoBaoCho.Text = soPhieuCho.ToString("N0");
            }
            catch (Exception ex) { Console.WriteLine("Lỗi thống kê: " + ex.Message); }
        }

        // ==========================================
        // 2. LOAD BẢNG TOP 5 PHIẾU CHI
        // ==========================================
        async Task LoadTopPhieuChiAsync()
        {
            try
            {
                var listPhieu = await _phieuChiColl.Find(_ => true)
                                            .SortByDescending(p => p.NgayLap)
                                            .Limit(5)
                                            .ToListAsync();

                dgvHoatDong.DataSource = listPhieu.Select(p => new {
                    SoPhieu = p.SoPhieu,
                    NgayLap = p.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                    NguoiNhan = p.NguoiNhan,
                    TongTien = p.TongTien.ToString("N0"),
                    TrangThai = p.TrangThaiDuyet == 1 ? "Đã duyệt" : (p.TrangThaiDuyet == -1 ? "Từ chối" : "Đang chờ")
                }).ToList();

                if (dgvHoatDong.Columns.Count > 0)
                {
                    dgvHoatDong.Columns[0].HeaderText = "SỐ PHIẾU";
                    dgvHoatDong.Columns[1].HeaderText = "NGÀY LẬP";
                    dgvHoatDong.Columns[2].HeaderText = "TÁC GIẢ / NGƯỜI NHẬN";
                    dgvHoatDong.Columns[3].HeaderText = "TỔNG TIỀN (VNĐ)";
                    dgvHoatDong.Columns[4].HeaderText = "TRẠNG THÁI";
                }

                // Chống chọn mặc định gây lỗi màu dòng 1
                dgvHoatDong.ClearSelection();
            }
            catch (Exception ex) { Console.WriteLine("Lỗi load phiếu chi: " + ex.Message); }
        }

        // ==========================================
        // 3. VẼ BIỂU ĐỒ ĐƯỜNG (SPLINE CHART)
        // ==========================================
        async Task VeBieuDoDuongAsync()
        {
            try
            {
                GunaChart chartLine = new GunaChart { Dock = DockStyle.Fill, BackColor = Color.White };
                chartLine.YAxes.GridLines.Display = true;
                chartLine.XAxes.GridLines.Display = false;
                chartLine.Legend.Display = false;

                GunaSplineDataset dataset = new GunaSplineDataset();
                dataset.BorderColor = Color.FromArgb(59, 130, 246);
                dataset.FillColor = Color.FromArgb(219, 234, 254);
                dataset.BorderWidth = 3;
                dataset.PointRadius = 4;
                dataset.PointFillColors.Add(Color.White);

                var listPhieu = await _phieuChiColl.Find(p => p.TrangThaiDuyet == 1).ToListAsync();

                var data = listPhieu.GroupBy(p => p.NgayLap.Month)
                                    .Select(g => new { Thang = "Tháng " + g.Key, Tien = g.Sum(x => x.TongTien) })
                                    .OrderBy(x => x.Thang).ToList();

                foreach (var item in data)
                {
                    dataset.DataPoints.Add(item.Thang, (double)item.Tien);
                }

                chartLine.Datasets.Add(dataset);
                chartLine.Update();
                pnlChartMain.Controls.Add(chartLine);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        // ==========================================
        // 4. VẼ BIỂU ĐỒ TRÒN (DOUGHNUT CHART)
        // ==========================================
        async Task VeBieuDoTronAsync()
        {
            try
            {
                GunaChart chartPie = new GunaChart { Dock = DockStyle.Fill, BackColor = Color.White };
                chartPie.Legend.Position = LegendPosition.Bottom;
                chartPie.Legend.LabelFont = new ChartFont { FontName = "Segoe UI", Size = 10, Style = ChartFontStyle.Bold };

                GunaDoughnutDataset dataset = new GunaDoughnutDataset();
                dataset.FillColors.Add(Color.FromArgb(59, 130, 246));
                dataset.FillColors.Add(Color.FromArgb(16, 185, 129));
                dataset.FillColors.Add(Color.FromArgb(245, 158, 11));

                var listBao = await _baoColl.Find(_ => true).ToListAsync();
                var dataPie = listBao.GroupBy(b => b.Loaibao)
                                     .Select(g => new { Loai = string.IsNullOrEmpty(g.Key) ? "Khác" : g.Key, Count = g.Count() })
                                     .ToList();

                foreach (var item in dataPie)
                {
                    dataset.DataPoints.Add(item.Loai, item.Count);
                }

                chartPie.Datasets.Add(dataset);
                chartPie.Update();
                pnlChartPie.Controls.Add(chartPie);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}