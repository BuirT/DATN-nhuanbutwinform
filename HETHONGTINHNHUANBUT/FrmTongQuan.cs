using Guna.Charts.WinForms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTongQuan : Form
    {
        private Timer timerClock;

        public FrmTongQuan()
        {
            InitializeComponent();
            timerClock = new Timer();
            timerClock.Interval = 1000;
            timerClock.Tick += TimerClock_Tick;
        }

        private void FrmTongQuan_Load(object sender, EventArgs e)
        {
            timerClock.Start();
            ThongKe4The();
            LoadTopSoBao();
            VeBieuDoGunaChart();
        }

        private void TimerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = "Hôm nay: " + DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss");
        }

        void ThongKe4The()
        {
            try
            {
                var tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
                var nhuanButColl = MongoProvider.Instance.GetCollection<PhieuChi>("PhieuChi");

                lblSoTacGia.Text = tacGiaColl.CountDocuments(_ => true).ToString();
                lblSoBaiViet.Text = nhuanButColl.CountDocuments(_ => true).ToString();

                var listPhieu = nhuanButColl.Find(_ => true).ToList();
                decimal tongTien = listPhieu.Sum(x => (decimal?)x.Sotien) ?? 0;

                lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            }
            catch
            {
                lblSoTacGia.Text = "0";
                lblSoBaiViet.Text = "0";
                lblTongTien.Text = "0 VNĐ";
            }
        }

        void LoadTopSoBao()
        {
            try
            {
                string sql = "SELECT TOP 10 Tenbao AS [Tên Báo], Sobao AS [Số], Ngayra AS [Ngày XB] FROM Bao ORDER BY Ngayra DESC";
                dgvHoatDong.DataSource = MongoProvider.Instance.ExecuteQuery(sql);

                Font vniFont = new Font("VNI-Times", 11F);
                dgvHoatDong.DefaultCellStyle.Font = vniFont;
                dgvHoatDong.RowsDefaultCellStyle.Font = vniFont;
                dgvHoatDong.AlternatingRowsDefaultCellStyle.Font = vniFont;
                dgvHoatDong.ThemeStyle.RowsStyle.Font = vniFont;
                dgvHoatDong.ThemeStyle.AlternatingRowsStyle.Font = vniFont;
            }
            catch { }
        }

        void VeBieuDoGunaChart()
        {
            try
            {
                pnlBieuDo.Controls.Clear();
                GunaChart gunaChart = new GunaChart();
                gunaChart.Dock = DockStyle.Fill;
                gunaChart.BackColor = Color.White;

                gunaChart.Title.Text = "THỐNG KÊ QUỸ TIỀN THEO SỐ BÁO";
                gunaChart.Title.Font = new ChartFont { FontName = "Segoe UI", Size = 13, Style = ChartFontStyle.Bold };

                try
                {
                    gunaChart.Tooltips.TitleFont = new ChartFont { FontName = "VNI-Times", Size = 11, Style = ChartFontStyle.Bold };
                    gunaChart.Tooltips.BodyFont = new ChartFont { FontName = "VNI-Times", Size = 11, Style = ChartFontStyle.Normal };
                }
                catch { }

                gunaChart.Legend.LabelFont = new ChartFont { FontName = "Segoe UI", Size = 10, Style = ChartFontStyle.Normal };
                gunaChart.XAxes.GridLines.Display = false;
                gunaChart.YAxes.GridLines.Display = false;

                gunaChart.XAxes.Ticks.Font = new ChartFont { FontName = "VNI-Times", Size = 10, Style = ChartFontStyle.Normal };
                gunaChart.YAxes.Ticks.Font = new ChartFont { FontName = "Segoe UI", Size = 9, Style = ChartFontStyle.Normal };

                GunaBarDataset dataset = new GunaBarDataset();
                dataset.Label = "Tổng Tiền (VNĐ)";
                dataset.FillColors.Add(Color.FromArgb(162, 110, 255));

                string sql = @"SELECT TOP 6 b.Tenbao, SUM(n.TienNhuanbut) as TongTien 
                               FROM Bao b JOIN Nhuanbut n ON b.Maso = n.MsBao 
                               GROUP BY b.Tenbao, b.Ngayra 
                               ORDER BY b.Ngayra DESC";
                DataTable dt = MongoProvider.Instance.ExecuteQuery(sql);

                foreach (DataRow row in dt.Rows)
                {
                    string tenBao = row["Tenbao"].ToString();
                    double tongTien = row["TongTien"] != DBNull.Value ? Convert.ToDouble(row["TongTien"]) : 0;
                    dataset.DataPoints.Add(tenBao, tongTien);
                }

                gunaChart.Datasets.Add(dataset);
                gunaChart.Update();
                pnlBieuDo.Controls.Add(gunaChart);
            }
            catch (Exception) { }
        }
    }
}