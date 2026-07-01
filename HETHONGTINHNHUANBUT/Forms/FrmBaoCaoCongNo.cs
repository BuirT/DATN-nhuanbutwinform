using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoCongNo : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmBaoCaoCongNo()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoCongNo_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvCongNo);
            dtpDenThang.Value = DateTime.Now;
            CreateChart();
            btnTimKiem_Click(null, null);
        }

        private Chart chartCongNo;

        private void CreateChart()
        {
            Label lblChartTitle = new Label();
            lblChartTitle.Text = "📊 BIỂU ĐỒ CÔNG NỢ";
            lblChartTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblChartTitle.Location = new Point(12, 8);
            lblChartTitle.AutoSize = true;
            pnlChart.Controls.Add(lblChartTitle);

            chartCongNo = new Chart();
            chartCongNo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartCongNo.Location = new Point(0, 35);
            chartCongNo.Size = new Size(pnlChart.Width, pnlChart.Height - 35);
            chartCongNo.BackColor = Color.FromArgb(249, 250, 251);
            chartCongNo.BorderlineColor = Color.Transparent;

            ChartArea area = new ChartArea();
            area.BackColor = Color.Transparent;
            area.AxisX.Enabled = AxisEnabled.False;
            area.AxisY.Enabled = AxisEnabled.False;
            chartCongNo.ChartAreas.Add(area);

            pnlChart.Controls.Add(chartCongNo);
        }

        private void PopulateChart(decimal tongNo, decimal daTra)
        {
            chartCongNo.Series.Clear();
            chartCongNo.Titles.Clear();

            decimal conNo = tongNo - daTra;

            if (tongNo == 0)
            {
                chartCongNo.Titles.Add(new Title("Chưa có dữ liệu công nợ", Docking.Top,
                    new Font("Segoe UI", 12, FontStyle.Italic), Color.FromArgb(156, 163, 175)));
                return;
            }

            ChartArea area = chartCongNo.ChartAreas[0];
            area.AxisX.Enabled = AxisEnabled.True;
            area.AxisY.Enabled = AxisEnabled.True;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(229, 231, 235);
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            area.AxisY.LabelStyle.Format = "N0";
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);

            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            series.BorderColor = Color.White;
            series.BorderWidth = 1;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.White;
            series.LabelFormat = "N0";

            series.Points.AddXY("Tổng nợ", (double)tongNo);
            series.Points[0].Color = Color.FromArgb(59, 130, 246);
            series.Points[0].LabelBackColor = Color.FromArgb(59, 130, 246);

            series.Points.AddXY("Đã thanh toán", (double)daTra);
            series.Points[1].Color = Color.FromArgb(16, 185, 129);
            series.Points[1].LabelBackColor = Color.FromArgb(16, 185, 129);

            series.Points.AddXY("Còn nợ", (double)conNo);
            series.Points[2].Color = conNo > 0 ? Color.FromArgb(239, 68, 68) : Color.FromArgb(16, 185, 129);
            series.Points[2].LabelBackColor = conNo > 0 ? Color.FromArgb(239, 68, 68) : Color.FromArgb(16, 185, 129);

            chartCongNo.Series.Add(series);
            chartCongNo.Invalidate();
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTong = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                        SELECT tg.Maso, tg.Hoten,
                               ISNULL(SUM(ct.Sotien), 0) AS Sotien,
                               ISNULL(SUM(CASE WHEN pc.TrangThaiDuyet = 1 THEN ct.Sotien ELSE 0 END), 0) AS DaTT,
                               ISNULL(SUM(ct.Sotien), 0) - ISNULL(SUM(CASE WHEN pc.TrangThaiDuyet = 1 THEN ct.Sotien ELSE 0 END), 0) AS Conlai
                        FROM TacGia tg
                        LEFT JOIN NhuanbutCT ct ON tg.Maso = ct.MsTacgia
                        LEFT JOIN (
                            SELECT Sophieu, MAX(TrangThaiDuyet) AS TrangThaiDuyet
                            FROM Phieuchi
                            GROUP BY Sophieu
                        ) pc ON ct.SoPC = pc.Sophieu
                        GROUP BY tg.Maso, tg.Hoten
                        HAVING ISNULL(SUM(ct.Sotien), 0) > 0
                        ORDER BY Conlai DESC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.CommandTimeout = 120;
                    await Task.Run(() => da.Fill(dtTong));
                }

                dgvCongNo.DataSource = dtTong;
                if (dgvCongNo.Columns.Count > 0)
                {
                    dgvCongNo.Columns["Maso"].HeaderText = "Mã số";
                    dgvCongNo.Columns["Maso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvCongNo.Columns["Hoten"].HeaderText = "Tác giả";
                    dgvCongNo.Columns["Hoten"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvCongNo.Columns["Sotien"].HeaderText = "Tổng nợ (VNĐ)";
                    dgvCongNo.Columns["Sotien"].DefaultCellStyle.Format = "N0";
                    dgvCongNo.Columns["Sotien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvCongNo.Columns["DaTT"].HeaderText = "Đã thanh toán (VNĐ)";
                    dgvCongNo.Columns["DaTT"].DefaultCellStyle.Format = "N0";
                    dgvCongNo.Columns["DaTT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvCongNo.Columns["Conlai"].HeaderText = "Còn nợ (VNĐ)";
                    dgvCongNo.Columns["Conlai"].DefaultCellStyle.Format = "N0";
                    dgvCongNo.Columns["Conlai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                // Tính tổng các cột
                decimal tongNo = 0;
                decimal daTra = 0;
                foreach (DataRow row in dtTong.Rows)
                {
                    if (row["Sotien"] != DBNull.Value) tongNo += Convert.ToDecimal(row["Sotien"]);
                    if (row["DaTT"] != DBNull.Value) daTra += Convert.ToDecimal(row["DaTT"]);
                }
                decimal conNo = tongNo - daTra;

                // ==============================================================
                // HIỂN THỊ DỮ LIỆU LÊN CÁC LABEL (THEO THIẾT KẾ CARD HIỆN ĐẠI)
                // Dùng \n để tách dòng: Tiêu đề ở trên, Số tiền in to ở dưới
                // ==============================================================
                lblTongNo.Text = $"TỔNG NỢ\n{tongNo:N0} VNĐ";
                lblDaThanhToan.Text = $"ĐÃ THANH TOÁN\n{daTra:N0} VNĐ";
                lblConNo.Text = $"CÒN NỢ\n{conNo:N0} VNĐ";

                // Đổi màu thông minh cho label Còn nợ
                // Nếu vẫn còn nợ (lớn hơn 0) thì in màu Đỏ (Crimson)
                // Nếu đã trả hết (bằng 0) thì in màu Xanh lá cây
                lblConNo.ForeColor = (conNo > 0) ? System.Drawing.Color.Crimson : System.Drawing.Color.FromArgb(16, 185, 129);

                PopulateChart(tongNo, daTra);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvCongNo.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất!"); return; }
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "BaoCaoCongNo_" + DateTime.Now.ToString("MM_yyyy") + ".xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("CongNo");
                    for (int i = 0; i < dgvCongNo.Columns.Count; i++)
                    {
                        ws.Cell(1, i + 1).Value = dgvCongNo.Columns[i].HeaderText;
                        ws.Cell(1, i + 1).Style.Font.Bold = true;
                    }
                    for (int i = 0; i < dgvCongNo.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvCongNo.Columns.Count; j++)
                        {
                            ws.Cell(i + 2, j + 1).Value = dgvCongNo.Rows[i].Cells[j].Value?.ToString();
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