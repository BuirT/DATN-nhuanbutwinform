using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Guna.UI2.WinForms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmThongkePhongvien : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        
        public string MaTacGiaCuaToi { get; set; }
        public string NguoiDangNhap { get; set; }
        public string QuyenHienTai { get; set; }
        
        private bool _dbLoaded = false;

        public FrmThongkePhongvien()
        {
            InitializeComponent();
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.SetValue(this, true, null);
        }

        private async void FrmThongkePhongvien_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvTraCuu);
            
            if (!_dbLoaded)
            {
                await LoadThongKeAsync();
                _dbLoaded = true;
            }
        }

        private async Task LoadThongKeAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    // 1. Thống kê tổng quan
                    string qTongQuan = @"
                        SELECT 
                            COUNT(nb.Maso) AS TongBai,
                            ISNULL(SUM(nb.TienNhuanbut), 0) AS TongTien,
                            SUM(CASE WHEN nb.TrangThaiDuyet >= 4 THEN 1 ELSE 0 END) AS DaDuyet
                        FROM Nhuanbut nb
                        WHERE (@ms IS NOT NULL AND nb.Butdanh IN (SELECT Butdanh FROM ButDanh WHERE MsTacgia = @ms))
                           OR (@ms IS NULL AND nb.NguoiNhap = @nguoi)";

                    using (SqlCommand cmd = new SqlCommand(qTongQuan, conn))
                    {
                        cmd.Parameters.AddWithValue("@ms", string.IsNullOrEmpty(MaTacGiaCuaToi) ? DBNull.Value : (object)MaTacGiaCuaToi);
                        cmd.Parameters.AddWithValue("@nguoi", string.IsNullOrEmpty(NguoiDangNhap) ? DBNull.Value : (object)NguoiDangNhap);
                        
                        using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                        {
                            if (r.Read())
                            {
                                int tongBai = r["TongBai"] != DBNull.Value ? Convert.ToInt32(r["TongBai"]) : 0;
                                decimal tongTien = r["TongTien"] != DBNull.Value ? Convert.ToDecimal(r["TongTien"]) : 0;
                                int daDuyet = r["DaDuyet"] != DBNull.Value ? Convert.ToInt32(r["DaDuyet"]) : 0;

                                lblTongBai.Text = tongBai.ToString("N0");
                                lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
                                lblDaDuyet.Text = daDuyet.ToString("N0") + " bài";
                            }
                        }
                    }

                    // 2. Tỉ trọng trạng thái (Pie chart)
                    string qTrangThai = @"
                        SELECT TrangThaiDuyet, COUNT(*) AS SL 
                        FROM Nhuanbut nb
                        WHERE (@ms IS NOT NULL AND nb.Butdanh IN (SELECT Butdanh FROM ButDanh WHERE MsTacgia = @ms))
                           OR (@ms IS NULL AND nb.NguoiNhap = @nguoi)
                        GROUP BY TrangThaiDuyet";

                    using (SqlCommand cmd = new SqlCommand(qTrangThai, conn))
                    {
                        cmd.Parameters.AddWithValue("@ms", string.IsNullOrEmpty(MaTacGiaCuaToi) ? DBNull.Value : (object)MaTacGiaCuaToi);
                        cmd.Parameters.AddWithValue("@nguoi", string.IsNullOrEmpty(NguoiDangNhap) ? DBNull.Value : (object)NguoiDangNhap);
                        
                        chartPie.Series.Clear();
                        Series sPie = new Series("TrangThai");
                        sPie.ChartType = SeriesChartType.Doughnut;
                        sPie.IsValueShownAsLabel = true;
                        
                        using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                        {
                            while (r.Read())
                            {
                                int tt = Convert.ToInt32(r["TrangThaiDuyet"]);
                                string tenTt = tt == 0 ? "Chờ chấm" : tt == 1 ? "Chờ nhập" : tt == 2 ? "Chờ kiểm tra" : tt == 3 ? "Chờ duyệt" : "Đã duyệt";
                                sPie.Points.AddXY(tenTt, Convert.ToInt32(r["SL"]));
                            }
                        }
                        chartPie.Series.Add(sPie);
                    }

                    // 3. Thu nhập theo tháng (Bar chart) 6 tháng gần nhất
                    string qThuNhap = @"
                        SELECT TOP 6 
                            MONTH(ngaychuyen) AS Thang, YEAR(ngaychuyen) AS Nam, 
                            ISNULL(SUM(TienNhuanbut), 0) AS TongTien
                        FROM Nhuanbut nb
                        WHERE (@ms IS NOT NULL AND nb.Butdanh IN (SELECT Butdanh FROM ButDanh WHERE MsTacgia = @ms))
                           OR (@ms IS NULL AND nb.NguoiNhap = @nguoi)
                        GROUP BY YEAR(ngaychuyen), MONTH(ngaychuyen)
                        ORDER BY YEAR(ngaychuyen) DESC, MONTH(ngaychuyen) DESC";

                    using (SqlCommand cmd = new SqlCommand(qThuNhap, conn))
                    {
                        cmd.Parameters.AddWithValue("@ms", string.IsNullOrEmpty(MaTacGiaCuaToi) ? DBNull.Value : (object)MaTacGiaCuaToi);
                        cmd.Parameters.AddWithValue("@nguoi", string.IsNullOrEmpty(NguoiDangNhap) ? DBNull.Value : (object)NguoiDangNhap);
                        
                        chartBar.Series.Clear();
                        Series sBar = new Series("ThuNhap");
                        sBar.ChartType = SeriesChartType.Column;
                        sBar.Color = Color.FromArgb(79, 70, 229);
                        sBar.IsValueShownAsLabel = true;
                        sBar.LabelFormat = "N0";

                        DataTable dtThuNhap = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtThuNhap);
                        }
                        
                        // Đảo ngược để vẽ từ cũ đến mới
                        for (int i = dtThuNhap.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow row = dtThuNhap.Rows[i];
                            string label = $"T{row["Thang"]}/{row["Nam"]}";
                            sBar.Points.AddXY(label, Convert.ToDecimal(row["TongTien"]));
                        }
                        chartBar.Series.Add(sBar);
                    }

                    // 4. Danh sách bài viết
                    string qList = @"
                        SELECT TOP 50 nb.Tenbai AS N'Tên bài', nb.Butdanh AS N'Bút danh', 
                               b.Tenbao AS N'Báo', nb.TienNhuanbut AS N'Tiền nhuận bút', 
                               nb.TrangThaiDuyet AS N'Trạng thái', nb.ngaychuyen AS N'Ngày nhận'
                        FROM Nhuanbut nb
                        LEFT JOIN Bao b ON nb.MsBao = b.Maso
                        WHERE (@ms IS NOT NULL AND nb.Butdanh IN (SELECT Butdanh FROM ButDanh WHERE MsTacgia = @ms))
                           OR (@ms IS NULL AND nb.NguoiNhap = @nguoi)
                        ORDER BY nb.ngaychuyen DESC";

                    using (SqlCommand cmd = new SqlCommand(qList, conn))
                    {
                        cmd.Parameters.AddWithValue("@ms", string.IsNullOrEmpty(MaTacGiaCuaToi) ? DBNull.Value : (object)MaTacGiaCuaToi);
                        cmd.Parameters.AddWithValue("@nguoi", string.IsNullOrEmpty(NguoiDangNhap) ? DBNull.Value : (object)NguoiDangNhap);
                        
                        DataTable dtList = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            await Task.Run(() => da.Fill(dtList));
                        }
                        
                        dgvTraCuu.DataSource = dtList;
                        UIHelper.ConfigureColumns(dgvTraCuu,
                            ("Tên bài", "Tên bài", false, false),
                            ("Bút danh", "Bút danh", false, false),
                            ("Báo", "Số báo", false, false),
                            ("Tiền nhuận bút", "Nhuận bút", true, false),
                            ("Trạng thái", "Trạng thái", false, true),
                            ("Ngày nhận", "Ngày chuyển", false, true)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
