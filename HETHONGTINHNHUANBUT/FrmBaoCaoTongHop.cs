using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoTongHop : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmBaoCaoTongHop()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoTongHop_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvTongHop);
            dtpThang.Value = DateTime.Now;
            btnTimKiem_Click(null, null);
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    // 1. Lấy dữ liệu xu hướng theo tháng để vẽ biểu đồ
                    DataTable dtThang = new DataTable();
                    SqlDataAdapter daThang = new SqlDataAdapter(@"
                        WITH ThongKeThang AS (
                            SELECT FORMAT(Ngayra, 'MM/yyyy') AS Thang, YEAR(Ngayra) AS Y, MONTH(Ngayra) AS M,
                                   ISNULL(SUM(nb.TienNhuanbut), 0) AS TongNhuanbut
                            FROM Bao b LEFT JOIN Nhuanbut nb ON b.Maso = nb.MsBao
                            GROUP BY YEAR(Ngayra), MONTH(Ngayra), FORMAT(Ngayra, 'MM/yyyy')
                        ),
                        ChiTraThang AS (
                            SELECT FORMAT(Ngaylap, 'MM/yyyy') AS Thang, YEAR(Ngaylap) AS Y, MONTH(Ngaylap) AS M,
                                   ISNULL(SUM(Sotien), 0) AS DaChi
                            FROM Phieuchi WHERE TrangThaiDuyet = 1
                            GROUP BY YEAR(Ngaylap), MONTH(Ngaylap), FORMAT(Ngaylap, 'MM/yyyy')
                        )
                        SELECT ROW_NUMBER() OVER (ORDER BY t.Y, t.M) AS STT, t.Thang, t.TongNhuanbut,
                               ISNULL(c.DaChi, 0) AS DaChiTra,
                               t.TongNhuanbut - ISNULL(c.DaChi, 0) AS ConNo, 0 AS ChiBoSung
                        FROM ThongKeThang t LEFT JOIN ChiTraThang c ON t.Thang = c.Thang
                        ORDER BY t.Y, t.M", conn);
                    await Task.Run(() => daThang.Fill(dtThang));

                    // 2. Lấy dữ liệu tổng hợp theo tác giả
                    DataTable dtTong = new DataTable();
                    SqlDataAdapter daTong = new SqlDataAdapter(@"
                        SELECT ROW_NUMBER() OVER (ORDER BY Conlai DESC) AS STT,
                               Maso, Hoten, Sotien, DaTT, Conlai
                        FROM (
                            SELECT tg.Maso, tg.Hoten,
                                   ISNULL(SUM(ct.Sotien), 0) AS Sotien,
                                   ISNULL(SUM(CASE WHEN pc.TrangThaiDuyet = 1 THEN ct.Sotien ELSE 0 END), 0) AS DaTT,
                                   ISNULL(SUM(ct.Sotien), 0) - ISNULL(SUM(CASE WHEN pc.TrangThaiDuyet = 1 THEN ct.Sotien ELSE 0 END), 0) AS Conlai
                            FROM TacGia tg
                            LEFT JOIN NhuanbutCT ct ON tg.Maso = ct.MsTacgia
                            LEFT JOIN Phieuchi pc ON ct.SoPC = pc.Sophieu
                            GROUP BY tg.Maso, tg.Hoten
                            HAVING ISNULL(SUM(ct.Sotien), 0) > 0
                        ) AS sub
                        ORDER BY Conlai DESC", conn);
                    await Task.Run(() => daTong.Fill(dtTong));

                    // 4. Vẽ biểu đồ (đã xử lý DBNull)
                    chartMain.Series.Clear();
                    chartMain.Titles.Clear();
                    chartMain.ChartAreas.Clear();

                    ChartArea chartArea = new ChartArea();
                    chartMain.ChartAreas.Add(chartArea);
                    chartArea.BackColor = Color.White;
                    chartArea.AxisX.LineColor = Color.FromArgb(226, 232, 240);
                    chartArea.AxisX.MajorGrid.Enabled = false;
                    chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
                    chartArea.AxisX.LabelStyle.ForeColor = Color.FromArgb(100, 116, 139);
                    chartArea.AxisY.LineColor = Color.FromArgb(226, 232, 240);
                    chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(241, 245, 249);
                    chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                    chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
                    chartArea.AxisY.LabelStyle.ForeColor = Color.FromArgb(100, 116, 139);
                    chartArea.AxisY.LabelStyle.Format = "N0";

                    chartArea.AxisX.Interval = 1;

                    if (dtThang.Rows.Count > 0)
                    {
                        Series series = new Series("Công nợ (VNĐ)");
                        series.ChartType = SeriesChartType.Spline;
                        series.BorderWidth = 3;
                        series.BorderColor = Color.FromArgb(59, 130, 246);
                        series.MarkerStyle = MarkerStyle.Circle;
                        series.MarkerSize = 8;
                        series.MarkerColor = Color.FromArgb(59, 130, 246);
                        series.MarkerBorderColor = Color.White;
                        series.MarkerBorderWidth = 2;
                        chartMain.Series.Add(series);

                        foreach (DataRow row in dtThang.Rows)
                        {
                            object conNoObj = row["ConNo"];
                            decimal conNoValue = (conNoObj != DBNull.Value) ? Convert.ToDecimal(conNoObj) : 0;
                            int idx = series.Points.AddXY(row["Thang"], conNoValue);
                            series.Points[idx].Label = conNoValue.ToString("N0");
                            series.Points[idx].Font = new Font("Segoe UI", 8F);
                        }
                    }
                    else
                    {
                        Title noData = new Title();
                        noData.Text = "Không có dữ liệu cho tháng này";
                        noData.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
                        noData.ForeColor = Color.FromArgb(148, 163, 184);
                        chartMain.Titles.Add(noData);
                    }

                    // 4. Hiển thị bảng tổng hợp theo tác giả
                    dgvTongHop.DataSource = dtTong;
                    if (dgvTongHop.Columns.Count > 0)
                    {
                        if (dgvTongHop.Columns["Maso"] != null) dgvTongHop.Columns["Maso"].Visible = false;
                        UIHelper.ConfigureColumns(dgvTongHop,
                            ("STT", "STT", false, false),
                            ("Hoten", "Tác giả", false, false),
                            ("Sotien", "Tổng nợ (VNĐ)", true, false),
                            ("DaTT", "Đã thanh toán (VNĐ)", true, false),
                            ("Conlai", "Còn nợ (VNĐ)", true, false)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvTongHop.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất!"); return; }
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "BaoCaoTongHop_" + dtpThang.Value.ToString("MM_yyyy") + ".xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("TongHop");
                    for (int i = 0; i < dgvTongHop.Columns.Count; i++)
                    {
                        ws.Cell(1, i + 1).Value = dgvTongHop.Columns[i].HeaderText;
                        ws.Cell(1, i + 1).Style.Font.Bold = true;
                    }
                    for (int i = 0; i < dgvTongHop.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvTongHop.Columns.Count; j++)
                        {
                            ws.Cell(i + 2, j + 1).Value = dgvTongHop.Rows[i].Cells[j].Value?.ToString();
                        }
                    }
                    ws.Columns().AdjustToContents();
                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất Excel thành công!");
                }
            }
        }
    }
}