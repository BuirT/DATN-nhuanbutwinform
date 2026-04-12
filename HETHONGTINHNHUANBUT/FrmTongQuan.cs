using Guna.Charts.WinForms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTongQuan : Form
    {
        private Timer timerClock;
        private readonly IMongoCollection<TacGia> _tacGiaColl;
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;
        private readonly IMongoCollection<Bao> _baoColl;

        public FrmTongQuan()
        {
            InitializeComponent();

            // Khởi tạo các Collection
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
            _baoColl = MongoProvider.Instance.GetCollection<Bao>("Bao");

            timerClock = new Timer();
            timerClock.Interval = 1000;
            timerClock.Tick += TimerClock_Tick;
        }

        private async void FrmTongQuan_Load(object sender, EventArgs e)
        {
            timerClock.Start();

            // Chạy các tác vụ bất đồng bộ để tránh treo Form lúc Load
            await ThongKe4TheAsync();
            await LoadTopSoBaoAsync();
            await VeBieuDoGunaChartAsync();
        }

        private void TimerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = "Hôm nay: " + DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss");
        }

        // 1. Thống kê các con số tổng quát (Cards)
        async Task ThongKe4TheAsync()
        {
            try
            {
                // Đếm số tác giả
                long soTacGia = await _tacGiaColl.CountDocumentsAsync(_ => true);
                lblSoTacGia.Text = soTacGia.ToString();

                // Đếm số bài viết (tổng số record trong NhuanBut)
                long soBaiViet = await _nhuanButColl.CountDocumentsAsync(_ => true);
                lblSoBaiViet.Text = soBaiViet.ToString();

                // Tính tổng tiền nhuận bút (Dùng LINQ MongoDB)
                var listNhuanBut = await _nhuanButColl.Find(_ => true).ToListAsync();
                decimal tongTien = listNhuanBut.Sum(x => x.TienNhuanBut);

                lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                lblSoTacGia.Text = "0";
                lblSoBaiViet.Text = "0";
                lblTongTien.Text = "0 VNĐ";
                Console.WriteLine("Lỗi thống kê: " + ex.Message);
            }
        }

        // 2. Load danh sách 10 số báo mới nhất lên Grid
        async Task LoadTopSoBaoAsync()
        {
            try
            {
                // Lấy 10 số báo mới nhất theo Ngày ra
                var listBao = await _baoColl.Find(_ => true)
                                            .SortByDescending(b => b.Ngayra)
                                            .Limit(10)
                                            .ToListAsync();

                dgvHoatDong.DataSource = listBao.Select(b => new {
                    TenBao = b.Tenbao,
                    SoBao = b.Sobao,
                    NgayRa = b.Ngayra.ToString("dd/MM/yyyy"),
                    Loai = b.Loaibao
                }).ToList();

                // Đổi tiêu đề cột
                dgvHoatDong.Columns[0].HeaderText = "Tên Báo";
                dgvHoatDong.Columns[1].HeaderText = "Số";
                dgvHoatDong.Columns[2].HeaderText = "Ngày XB";
                dgvHoatDong.Columns[3].HeaderText = "Loại Hình";

                // Định dạng Font chữ
                Font vniFont = new Font("Segoe UI", 10F); // Thay VNI-Times bằng Segoe UI cho hiện đại
                dgvHoatDong.DefaultCellStyle.Font = vniFont;
                dgvHoatDong.ThemeStyle.RowsStyle.Font = vniFont;
            }
            catch (Exception ex) { Console.WriteLine("Lỗi load số báo: " + ex.Message); }
        }

        // 3. Vẽ biểu đồ thống kê nhuận bút theo Số Báo (Guna Chart)
        async Task VeBieuDoGunaChartAsync()
        {
            try
            {
                pnlBieuDo.Controls.Clear();
                GunaChart gunaChart = new GunaChart();
                gunaChart.Dock = DockStyle.Fill;
                gunaChart.BackColor = Color.White;

                gunaChart.Title.Text = "TOP 6 SỐ BÁO CÓ QUỸ NHUẬN BÚT CAO NHẤT";
                gunaChart.Title.Font = new ChartFont { FontName = "Segoe UI", Size = 13, Style = ChartFontStyle.Bold };

                // Cấu hình hiển thị
                gunaChart.Legend.LabelFont = new ChartFont { FontName = "Segoe UI", Size = 10 };
                gunaChart.XAxes.GridLines.Display = false;
                gunaChart.YAxes.GridLines.Display = false;

                // Dataset dạng cột
                GunaBarDataset dataset = new GunaBarDataset();
                dataset.Label = "Tiền Nhuận Bút (VNĐ)";
                dataset.FillColors.Add(Color.FromArgb(162, 110, 255)); // Màu tím Guna

                // LOGIC TRUY VẤN MONGODB THAY THẾ SQL JOIN
                // Bước 1: Lấy tất cả nhuận bút
                var allNhuanBut = await _nhuanButColl.Find(_ => true).ToListAsync();

                // Bước 2: Group by theo TenSoBao và Sum tiền
                var reportData = allNhuanBut
                    .GroupBy(n => n.TenSoBao)
                    .Select(g => new {
                        TenBao = g.Key,
                        TongTien = g.Sum(x => x.TienNhuanBut)
                    })
                    .OrderByDescending(x => x.TongTien)
                    .Take(6) // Lấy top 6
                    .ToList();

                // Đổ dữ liệu vào biểu đồ
                foreach (var item in reportData)
                {
                    dataset.DataPoints.Add(item.TenBao, (double)item.TongTien);
                }

                gunaChart.Datasets.Add(dataset);
                gunaChart.Update();
                pnlBieuDo.Controls.Add(gunaChart);
            }
            catch (Exception ex) { Console.WriteLine("Lỗi vẽ biểu đồ: " + ex.Message); }
        }
    }
}