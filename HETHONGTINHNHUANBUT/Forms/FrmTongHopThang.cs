using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTongHopThang : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmTongHopThang()
        {
            InitializeComponent();
        }

        private void FrmTongHopThang_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvBaoCao);
            dtpThang.Value = DateTime.Now;
        }

        private async void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = dtpThang.Value;
                DateTime startOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    string query = @"
                        SELECT Butdanh, Tenbai, TienNhuanbut, DaThanhToan
                        FROM Nhuanbut
                        WHERE NgayNhap >= @start AND NgayNhap <= @end";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@start", startOfMonth);
                        cmd.Parameters.AddWithValue("@end", endOfMonth);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            await Task.Run(() => da.Fill(dt));
                        }
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    dgvBaoCao.DataSource = null;
                    MessageBox.Show("Không có dữ liệu nhuận bút nào được nhập trong tháng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var reportData = dt.AsEnumerable()
                    .GroupBy(r => r.Field<string>("Butdanh"))
                    .Select(g => new
                    {
                        ButDanh = g.Key,
                        SoLuongBai = g.Count(),
                        TongNhuanBut = g.Sum(x => Convert.ToDecimal(x["TienNhuanbut"])),
                        DaChiTra = g.Where(x => Convert.ToBoolean(x["DaThanhToan"])).Sum(x => Convert.ToDecimal(x["TienNhuanbut"])),
                        ConNo = g.Where(x => !Convert.ToBoolean(x["DaThanhToan"])).Sum(x => Convert.ToDecimal(x["TienNhuanbut"]))
                    })
                    .OrderByDescending(x => x.TongNhuanBut)
                    .ToList();

                var displayList = reportData.Select(r => new
                {
                    r.ButDanh,
                    r.SoLuongBai,
                    TongNhuanBut = r.TongNhuanBut.ToString("N0") + " VNĐ",
                    DaChiTra = r.DaChiTra.ToString("N0") + " VNĐ",
                    ConNo = r.ConNo.ToString("N0") + " VNĐ"
                }).ToList();

                dgvBaoCao.DataSource = displayList;

                if (dgvBaoCao.Columns.Count > 0)
                {
                    dgvBaoCao.Columns["ButDanh"].HeaderText = "Tác Giả / Bút Danh";
                    dgvBaoCao.Columns["SoLuongBai"].HeaderText = "Số Lượng Bài";
                    dgvBaoCao.Columns["TongNhuanBut"].HeaderText = "Tổng Nhuận Bút";
                    dgvBaoCao.Columns["DaChiTra"].HeaderText = "Đã Chi Trả (CK/TM)";
                    dgvBaoCao.Columns["ConNo"].HeaderText = "Còn Nợ Kỳ Sau";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lập báo cáo: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.Rows.Count == 0 || dgvBaoCao.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất! Đồng chí vui lòng nhấn 'Xem báo cáo' trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("BaoCaoTongHop");

                    for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dgvBaoCao.Columns[i].HeaderText;
                        worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                        worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.MediumSeaGreen;
                        worksheet.Cell(1, i + 1).Style.Font.FontColor = XLColor.White;
                        worksheet.Cell(1, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }

                    for (int i = 0; i < dgvBaoCao.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvBaoCao.Columns.Count; j++)
                        {
                            string cellValue = dgvBaoCao.Rows[i].Cells[j].Value?.ToString();
                            worksheet.Cell(i + 2, j + 1).Value = cellValue;
                        }
                    }

                    worksheet.Columns().AdjustToContents();

                    string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "BaoCaoNhuanBut_Thang_" + dtpThang.Value.ToString("MM_yyyy_HHmmss") + ".xlsx");
                    workbook.SaveAs(tempPath);
                    System.Diagnostics.Process.Start(tempPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
