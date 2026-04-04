using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using ClosedXML.Excel;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoCongNo : Form
    {
        public FrmBaoCaoCongNo()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoCongNo_Load(object sender, EventArgs e)
        {
            // Thiết lập font VNI cho bảng hiển thị
            dgvCongNo.DefaultCellStyle.Font = new Font("VNI-Times", 11F);
            dgvCongNo.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Mặc định từ ngày đầu tháng đến hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string sql = @"
                SELECT n.Butdanh AS [Tác giả/Bút danh], 
                       SUM(n.TienNhuanbut) AS [Tổng Nhuận Bút],
                       SUM(n.TienNhuanbut) * 0.1 AS [Thuế TNCN (10%)],
                       SUM(n.TienNhuanbut) * 0.9 AS [Thực Nhận]
                FROM Nhuanbut n
                JOIN Bao b ON n.MsBao = b.Maso
                WHERE b.Ngayra BETWEEN @tu AND @den
                GROUP BY n.Butdanh
                ORDER BY SUM(n.TienNhuanbut) DESC";

            DataTable dt = MongoProvider.Instance.ExecuteQuery(sql, new object[] { dtpTuNgay.Value, dtpDenNgay.Value });
            dgvCongNo.DataSource = dt;

            if (dgvCongNo.Columns.Count > 1)
            {
                dgvCongNo.Columns[1].DefaultCellStyle.Format = "N0";
                dgvCongNo.Columns[2].DefaultCellStyle.Format = "N0";
                dgvCongNo.Columns[3].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvCongNo.Rows.Count == 0) return;

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "BaoCaoCongNo" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("CongNo");
                            ws.Cell("A1").Value = "BÁO CÁO CÔNG NỢ NHUẬN BÚT PHÓNG VIÊN - TÁC GIẢ";
                            ws.Range("A1:D1").Merge().Style.Font.SetBold().Font.SetFontSize(14).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                            for (int i = 0; i < dgvCongNo.Columns.Count; i++)
                            {
                                ws.Cell(4, i + 1).Value = dgvCongNo.Columns[i].HeaderText;
                                ws.Cell(4, i + 1).Style.Fill.BackgroundColor = XLColor.LightBlue;
                                ws.Cell(4, i + 1).Style.Font.SetBold();
                            }

                            for (int r = 0; r < dgvCongNo.Rows.Count; r++)
                            {
                                for (int c = 0; c < dgvCongNo.Columns.Count; c++)
                                {
                                    ws.Cell(r + 5, c + 1).Value = dgvCongNo.Rows[r].Cells[c].Value?.ToString();
                                }
                            }

                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất báo cáo Excel thành công!", "Thông báo");
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                }
            }
        }
    }
}