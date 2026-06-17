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
            dgvBaoCao.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvBaoCao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
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
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
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
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    FileName = "BaoCaoNhuanBut_Thang_" + dtpThang.Value.ToString("MM_yyyy") + ".xlsx",
                    Title = "Lưu báo cáo Excel"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
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
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Đã xuất báo cáo Excel thành công!", "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
