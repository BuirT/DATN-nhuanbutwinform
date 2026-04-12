using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using ClosedXML.Excel;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoCongNo : Form
    {
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;

        public FrmBaoCaoCongNo()
        {
            InitializeComponent();
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
        }

        private void FrmBaoCaoCongNo_Load(object sender, EventArgs e)
        {
            dgvCongNo.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpDenThang.Value = DateTime.Now;
        }

        private async void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ngày cuối cùng của tháng được chọn
                DateTime selectedDate = dtpDenThang.Value;
                DateTime endOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1).AddMonths(1).AddTicks(-1);

                // Lọc TẤT CẢ các bài viết CHƯA THANH TOÁN tính đến thời điểm endOfMonth
                var builder = Builders<NhuanBut>.Filter;
                var filter = builder.Eq(n => n.DaThanhToan, false) & builder.Lte(n => n.NgayNhap, endOfMonth);

                var danhSachNo = await _nhuanButColl.Find(filter).ToListAsync();

                if (danhSachNo.Count == 0)
                {
                    dgvCongNo.DataSource = null;
                    lblTongNo.Text = "TỔNG NỢ: 0 VNĐ";
                    MessageBox.Show("Tuyệt vời! Tòa soạn không còn nợ nhuận bút tính đến tháng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gom nhóm theo Bút danh để xem nợ ai bao nhiêu
                var congNoData = danhSachNo
                    .GroupBy(n => n.ButDanh)
                    .Select(g => new
                    {
                        ButDanh = g.Key,
                        SoBaiChuaTra = g.Count(),
                        TongTienNo = g.Sum(x => x.TienNhuanBut)
                    })
                    .OrderByDescending(x => x.TongTienNo) // Ai bị nợ nhiều nhất lên đầu
                    .ToList();

                // Hiển thị tổng nợ toàn tòa soạn
                decimal tongNoToanCuc = congNoData.Sum(x => x.TongTienNo);
                lblTongNo.Text = $"TỔNG NỢ: {tongNoToanCuc.ToString("N0")} VNĐ";

                // Format lại để đẩy lên Grid
                var displayList = congNoData.Select(c => new
                {
                    c.ButDanh,
                    c.SoBaiChuaTra,
                    TongTienNo = c.TongTienNo.ToString("N0") + " VNĐ"
                }).ToList();

                dgvCongNo.DataSource = displayList;

                if (dgvCongNo.Columns.Count > 0)
                {
                    dgvCongNo.Columns["ButDanh"].HeaderText = "Tác Giả / Bút Danh";
                    dgvCongNo.Columns["SoBaiChuaTra"].HeaderText = "Số Bài Đang Nợ";
                    dgvCongNo.Columns["TongTienNo"].HeaderText = "Tổng Tiền Nợ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu công nợ: " + ex.Message, "Lỗi Hệ Thống");
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvCongNo.Rows.Count == 0 || dgvCongNo.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    FileName = "CongNoNhuanBut_DenThang_" + dtpDenThang.Value.ToString("MM_yyyy") + ".xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("CongNo");

                        for (int i = 0; i < dgvCongNo.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvCongNo.Columns[i].HeaderText;
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                            worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.Firebrick;
                            worksheet.Cell(1, i + 1).Style.Font.FontColor = XLColor.White;
                        }

                        for (int i = 0; i < dgvCongNo.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvCongNo.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dgvCongNo.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        // Thêm dòng tổng cộng ở cuối Excel
                        int lastRow = dgvCongNo.Rows.Count + 2;
                        worksheet.Cell(lastRow, 1).Value = "TỔNG CỘNG";
                        worksheet.Cell(lastRow, 1).Style.Font.Bold = true;
                        worksheet.Cell(lastRow, 3).Value = lblTongNo.Text.Replace("TỔNG NỢ: ", "");
                        worksheet.Cell(lastRow, 3).Style.Font.Bold = true;
                        worksheet.Cell(lastRow, 3).Style.Font.FontColor = XLColor.Red;

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Đã xuất báo cáo công nợ ra Excel thành công!", "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi");
            }
        }

        private void dtpDenThang_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}