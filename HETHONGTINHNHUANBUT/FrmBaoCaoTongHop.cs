using System;
using System.Data;
using System.Data.SqlClient;
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
            dtpThang.Value = DateTime.Now;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    conn.Open();

                    // 1. Lấy dữ liệu xu hướng theo tháng để vẽ biểu đồ
                    DataTable dtThang = new DataTable();
                    string queryThang = "SELECT * FROM tmpCongNoThang ORDER BY Thang DESC";
                    SqlDataAdapter daThang = new SqlDataAdapter(queryThang, conn);
                    daThang.Fill(dtThang);

                    // 2. Lấy dữ liệu tổng hợp theo tác giả
                    DataTable dtTong = new DataTable();
                    string queryTong = "SELECT * FROM tmpCongNoTong ORDER BY Conlai DESC";
                    SqlDataAdapter daTong = new SqlDataAdapter(queryTong, conn);
                    daTong.Fill(dtTong);

                    // 3. Vẽ biểu đồ (đã xử lý DBNull)
                    chartMain.Series.Clear();
                    if (dtThang.Rows.Count > 0)
                    {
                        Series series = new Series("Xu hướng nợ");
                        series.ChartType = SeriesChartType.Line;
                        chartMain.Series.Add(series);

                        foreach (DataRow row in dtThang.Rows)
                        {
                            // Xử lý DBNull cho cột ConNo
                            object conNoObj = row["ConNo"];
                            decimal conNoValue = (conNoObj != DBNull.Value) ? Convert.ToDecimal(conNoObj) : 0;

                            series.Points.AddXY(row["Thang"], conNoValue);
                        }
                    }
                    else
                    {
                        // Nếu không có dữ liệu, thêm thông báo vào biểu đồ
                        chartMain.Titles.Clear();
                        chartMain.Titles.Add("Không có dữ liệu cho tháng này");
                    }

                    // 4. Hiển thị bảng tổng hợp theo tác giả
                    dgvTongHop.DataSource = dtTong;
                    if (dgvTongHop.Columns.Count > 0)
                    {
                        dgvTongHop.Columns["Maso"].HeaderText = "Mã số";
                        dgvTongHop.Columns["Hoten"].HeaderText = "Tác giả";
                        dgvTongHop.Columns["Sotien"].HeaderText = "Tổng nợ (VNĐ)";
                        dgvTongHop.Columns["DaTT"].HeaderText = "Đã thanh toán";
                        dgvTongHop.Columns["Conlai"].HeaderText = "Còn nợ";
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