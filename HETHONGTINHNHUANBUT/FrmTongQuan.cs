using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using Guna.Charts.WinForms;

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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                lblSoTacGia.Text = DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM TacGia")?.ToString() ?? "0";
                lblSoBaiViet.Text = DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM Nhuanbut")?.ToString() ?? "0";
                lblSoBaoCho.Text = DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM Bao WHERE DaDuyet = 'N'")?.ToString() ?? "0";

                object kqTien = DataProvider.Instance.ExecuteScalar("SELECT SUM(TienNhuanbut) FROM Nhuanbut");
                if (kqTien != DBNull.Value && kqTien.ToString() != "")
                    lblTongTien.Text = $"{Convert.ToDecimal(kqTien):N0} VNĐ";
            }
            catch { }
        }

        void LoadTopSoBao()
        {
            try
            {
                string sql = "SELECT TOP 10 Tenbao AS [Tên Báo], Sobao AS [Số], Ngayra AS [Ngày XB] FROM Bao ORDER BY Ngayra DESC";
                dgvHoatDong.DataSource = DataProvider.Instance.ExecuteQuery(sql);

                Font vniFont = new Font("VNI-Times", 11F);
                dgvHoatDong.DefaultCellStyle.Font = vniFont;
                dgvHoatDong.RowsDefaultCellStyle.Font = vniFont;
                dgvHoatDong.AlternatingRowsDefaultCellStyle.Font = vniFont;
                dgvHoatDong.ThemeStyle.RowsStyle.Font = vniFont;
                dgvHoatDong.ThemeStyle.AlternatingRowsStyle.Font = vniFont;
            }
            catch { }
        }

        // Tinh hoa hội tụ: Bản vá lỗi Font Tooltip & Legend cho mọi phiên bản Guna Chart
        void VeBieuDoGunaChart()
        {
            try
            {
                pnlBieuDo.Controls.Clear();
                GunaChart gunaChart = new GunaChart();
                gunaChart.Dock = DockStyle.Fill;
                gunaChart.BackColor = Color.White;

                // 1. Cấu hình Tiêu đề
                gunaChart.Title.Text = "THỐNG KÊ QUỸ TIỀN THEO SỐ BÁO";
                gunaChart.Title.Font = new ChartFont { FontName = "Segoe UI", Size = 13, Style = ChartFontStyle.Bold };

                // 2. FIX LỖI FONT TOOLTIP (DÙNG ĐÚNG CHUẨN CHARTFONT CỦA GUNA)
                try
                {
                    gunaChart.Tooltips.TitleFont = new ChartFont { FontName = "VNI-Times", Size = 11, Style = ChartFontStyle.Bold };
                    gunaChart.Tooltips.BodyFont = new ChartFont { FontName = "VNI-Times", Size = 11, Style = ChartFontStyle.Normal };
                }
                catch
                {
                    // Bỏ qua nếu phiên bản Guna cũ không hỗ trợ
                }

                // 3. Cấu hình Chú thích
                gunaChart.Legend.LabelFont = new ChartFont { FontName = "Segoe UI", Size = 10, Style = ChartFontStyle.Normal };

                // 4. Cấu hình Trục
                gunaChart.XAxes.GridLines.Display = false;
                gunaChart.YAxes.GridLines.Display = false;

                // Font trục X để đọc được tiếng Việt mã VNI (Tên các số báo)
                gunaChart.XAxes.Ticks.Font = new ChartFont { FontName = "VNI-Times", Size = 10, Style = ChartFontStyle.Normal };
                gunaChart.YAxes.Ticks.Font = new ChartFont { FontName = "Segoe UI", Size = 9, Style = ChartFontStyle.Normal };

                // 5. Khởi tạo dữ liệu
                GunaBarDataset dataset = new GunaBarDataset();
                dataset.Label = "Tổng Tiền (VNĐ)";
                dataset.FillColors.Add(Color.FromArgb(162, 110, 255));

                // Lấy dữ liệu (Top 6 số báo mới nhất)
                string sql = @"SELECT TOP 6 b.Tenbao, SUM(n.TienNhuanbut) as TongTien 
                               FROM Bao b JOIN Nhuanbut n ON b.Maso = n.MsBao 
                               GROUP BY b.Tenbao, b.Ngayra 
                               ORDER BY b.Ngayra DESC";
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql);

                foreach (DataRow row in dt.Rows)
                {
                    string tenBao = row["Tenbao"].ToString();
                    double tongTien = row["TongTien"] != DBNull.Value ? Convert.ToDouble(row["TongTien"]) : 0;
                    dataset.DataPoints.Add(tenBao, tongTien);
                }

                // 6. Hoàn tất
                gunaChart.Datasets.Add(dataset);
                gunaChart.Update();
                pnlBieuDo.Controls.Add(gunaChart);
            }
            catch (Exception) { }
        }
    }
}