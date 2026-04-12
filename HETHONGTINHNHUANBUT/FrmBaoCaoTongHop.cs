using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using ClosedXML.Excel;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoTongHop : Form
    {
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;

        public FrmBaoCaoTongHop()
        {
            InitializeComponent();
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
        }

        private void FrmTongHopThang_Load(object sender, EventArgs e)
        {
            // Format font chữ cho DataGridView
            dgvBaoCao.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            if (dgvBaoCao.RowTemplate != null)
            {
                dgvBaoCao.RowTemplate.Height = 35;
            }

            // Mặc định chọn tháng hiện tại
            dtpThang.Value = DateTime.Now;
        }

        // --- XỬ LÝ SỰ KIỆN NÚT TÌM KIẾM / XEM BÁO CÁO ---
        private async void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Xác định mốc thời gian (Đầu tháng đến Cuối tháng)
                DateTime selectedDate = dtpThang.Value;
                DateTime startOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

                // 2. Kéo dữ liệu từ MongoDB (chỉ lấy các bài viết trong tháng được chọn)
                var builder = Builders<NhuanBut>.Filter;
                var filter = builder.Gte(n => n.NgayNhap, startOfMonth) & builder.Lte(n => n.NgayNhap, endOfMonth);

                var danhSachTrongThang = await _nhuanButColl.Find(filter).ToListAsync();

                // 3. Xử lý trường hợp không có dữ liệu
                if (danhSachTrongThang.Count == 0)
                {
                    dgvBaoCao.DataSource = null;
                    MessageBox.Show("Không có dữ liệu nhuận bút nào trong tháng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 4. SỨC MẠNH CỦA LINQ: Gom nhóm theo tác giả (Bút danh) và tính toán tổng tiền
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
                    .OrderByDescending(x => x.TongNhuanBut) // Ai nhuận bút cao nhất thì xếp lên đầu
                    .ToList();

                // 5. Thêm chữ VNĐ cho hiển thị chuyên nghiệp
                var displayList = reportData.Select(r => new
                {
                    r.ButDanh,
                    r.SoLuongBai,
                    TongNhuanBut = r.TongNhuanBut.ToString("N0") + " VNĐ",
                    DaChiTra = r.DaChiTra.ToString("N0") + " VNĐ",
                    ConNo = r.ConNo.ToString("N0") + " VNĐ"
                }).ToList();

                // 6. Gắn dữ liệu vào GridView
                dgvBaoCao.DataSource = displayList;

                // 7. Sửa lại tiêu đề cột
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

        // --- XỬ LÝ SỰ KIỆN XUẤT EXCEL ---
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
                    FileName = "BaoCaoTongHop_Thang_" + dtpThang.Value.ToString("MM_yyyy") + ".xlsx",
                    Title = "Lưu báo cáo Excel"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("BaoCaoTongHop");

                        // Tạo Header
                        for (int i = 0; i < dgvBaoCao.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvBaoCao.Columns[i].HeaderText;
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                            worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.MediumSeaGreen;
                            worksheet.Cell(1, i + 1).Style.Font.FontColor = XLColor.White;
                            worksheet.Cell(1, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }

                        // Đổ Data
                        for (int i = 0; i < dgvBaoCao.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvBaoCao.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dgvBaoCao.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        // Căn chỉnh cột tự động
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