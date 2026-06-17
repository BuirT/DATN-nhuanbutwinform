using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using ClosedXML.Excel; // Đảm bảo đồng chí đã cài NuGet Package ClosedXML nhé

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTongHopThang : Form
    {
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;

        public FrmTongHopThang()
        {
            InitializeComponent();
            // Kết nối thẳng tới bảng NhuanBut trên Atlas
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
        }

        private void FrmTongHopThang_Load(object sender, EventArgs e)
        {
            // Format font chữ cho DataGridView khi form vừa load lên
            dgvBaoCao.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvBaoCao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Mặc định chọn tháng hiện tại cho tiện
            dtpThang.Value = DateTime.Now;
        }

        // Sự kiện khi bấm nút XEM BÁO CÁO
        private async void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy ra mốc thời gian: Ngày đầu tháng và Ngày cuối tháng
                DateTime selectedDate = dtpThang.Value;
                DateTime startOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                // Lấy ngày cuối cùng của tháng (bằng cách sang đầu tháng sau rồi trừ đi 1 tick)
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

                // 2. Truy vấn dữ liệu từ MongoDB trong khoảng thời gian này
                var builder = Builders<NhuanBut>.Filter;
                var filter = builder.Gte(n => n.NgayNhap, startOfMonth) & builder.Lte(n => n.NgayNhap, endOfMonth);

                var danhSachTrongThang = await _nhuanButColl.Find(filter).ToListAsync();

                // 3. Kiểm tra xem có dữ liệu không
                if (danhSachTrongThang.Count == 0)
                {
                    dgvBaoCao.DataSource = null;
                    MessageBox.Show("Không có dữ liệu nhuận bút nào được nhập trong tháng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 4. DÙNG LINQ ĐỂ GOM NHÓM (GROUP BY) THEO BÚT DANH (Logic cốt lõi của báo cáo)
                var reportData = danhSachTrongThang
                    .GroupBy(n => n.ButDanh)
                    .Select(g => new
                    {
                        ButDanh = g.Key,
                        SoLuongBai = g.Count(),
                        TongNhuanBut = g.Sum(x => x.TienNhuanBut),
                        DaChiTra = g.Where(x => x.DaThanhToan).Sum(x => x.TienNhuanBut),
                        ConNo = g.Where(x => !x.DaThanhToan).Sum(x => x.TienNhuanBut)
                    })
                    .OrderByDescending(x => x.TongNhuanBut) // Sắp xếp ai được nhiều tiền nhất lên đầu
                    .ToList();

                // 5. Định dạng lại thành chuỗi VNĐ cho đẹp mắt trên lưới
                var displayList = reportData.Select(r => new
                {
                    r.ButDanh,
                    r.SoLuongBai,
                    TongNhuanBut = r.TongNhuanBut.ToString("N0") + " VNĐ",
                    DaChiTra = r.DaChiTra.ToString("N0") + " VNĐ",
                    ConNo = r.ConNo.ToString("N0") + " VNĐ"
                }).ToList();

                // 6. Đổ dữ liệu lên DataGridView
                dgvBaoCao.DataSource = displayList;

                // 7. Đặt lại tiêu đề cột cho chuyên nghiệp
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

        // Sự kiện khi bấm nút XUẤT EXCEL
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem DataGridView có dữ liệu để xuất không
            if (dgvBaoCao.Rows.Count == 0 || dgvBaoCao.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất! Đồng chí vui lòng nhấn 'Xem báo cáo' trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Mở hộp thoại chọn nơi lưu file cho người dùng
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    FileName = "BaoCaoNhuanBut_Thang_" + dtpThang.Value.ToString("MM_yyyy") + ".xlsx",
                    Title = "Lưu báo cáo Excel"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Khởi tạo file Excel bằng thư viện ClosedXML
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("BaoCaoTongHop");

                        // 1. Tạo dòng Tiêu đề (Header) từ tên cột của DataGridView
                        for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvBaoCao.Columns[i].HeaderText;

                            // Style cho dòng Header: in đậm, nền xanh lá, chữ trắng
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                            worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.MediumSeaGreen;
                            worksheet.Cell(1, i + 1).Style.Font.FontColor = XLColor.White;
                            worksheet.Cell(1, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }

                        // 2. Đổ dữ liệu từ các dòng của DataGridView xuống Excel
                        for (int i = 0; i < dgvBaoCao.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvBaoCao.Columns.Count; j++)
                            {
                                // Lấy giá trị từng ô và gán vào cell tương ứng trong Excel (dòng bắt đầu từ 2)
                                string cellValue = dgvBaoCao.Rows[i].Cells[j].Value?.ToString();
                                worksheet.Cell(i + 2, j + 1).Value = cellValue;
                            }
                        }

                        // 3. Tự động căn chỉnh độ rộng cột cho vừa với nội dung chữ
                        worksheet.Columns().AdjustToContents();

                        // Lưu file ra ổ cứng
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