using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;
using ClosedXML.Excel; // Nhớ cài thư viện ClosedXML qua NuGet nhé đồng chí

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoChiTiet : Form
    {
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;
        private readonly IMongoCollection<TacGia> _tacGiaColl;

        public FrmBaoCaoChiTiet()
        {
            InitializeComponent();
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
            _tacGiaColl = MongoProvider.Instance.GetCollection<TacGia>("TacGia");
        }

        private async void FrmBaoCaoChiTiet_Load(object sender, EventArgs e)
        {
            // Định dạng Font chữ cho GridView
            dgvChiTiet.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvChiTiet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            dtpThang.Value = DateTime.Now;

            await LoadAuthorsAsync();
        }

        // Tải danh sách Bút danh vào ComboBox để lọc
        private async Task LoadAuthorsAsync()
        {
            try
            {
                var listTacGia = await _tacGiaColl.Find(_ => true).ToListAsync();
                List<string> tatCaButDanh = new List<string>();

                // Thêm mục "Tất cả" lên đầu danh sách để dễ lọc
                tatCaButDanh.Add("--- Tất cả tác giả ---");

                foreach (var tg in listTacGia)
                {
                    // ĐÃ SỬA: Dùng tg.ButDanh thay vì tg.Ddong
                    if (!string.IsNullOrWhiteSpace(tg.ButDanh))
                    {
                        tatCaButDanh.Add(tg.ButDanh.Trim());
                    }
                    // ĐÃ SỬA: Dùng tg.HoTen thay vì tg.Hoten (chữ T viết hoa)
                    else if (!string.IsNullOrWhiteSpace(tg.HoTen))
                    {
                        // Nếu không có bút danh thì lấy tạm Họ tên
                        tatCaButDanh.Add(tg.HoTen.Trim());
                    }
                }

                cboTacGia.DataSource = tatCaButDanh.Distinct().ToList();
                cboTacGia.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                // Bỏ qua nếu lỗi kết nối lúc load form
                Console.WriteLine(ex.Message);
            }
        }
        // Xử lý sự kiện bấm nút XEM BÁO CÁO (TÌM KIẾM)
        private async void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mốc thời gian từ đầu tháng đến cuối tháng
                DateTime startOfMonth = new DateTime(dtpThang.Value.Year, dtpThang.Value.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

                var builder = Builders<NhuanBut>.Filter;

                // Điều kiện 1: Lọc theo thời gian nhập trong tháng
                var filter = builder.Gte(n => n.NgayNhap, startOfMonth) & builder.Lte(n => n.NgayNhap, endOfMonth);

                // Điều kiện 2: Nếu người dùng chọn một bút danh cụ thể (không phải "Tất cả")
                if (cboTacGia.SelectedIndex > 0)
                {
                    filter &= builder.Eq(n => n.ButDanh, cboTacGia.Text);
                }

                // Thực thi truy vấn lên MongoDB
                var list = await _nhuanButColl.Find(filter).ToListAsync();

                if (list.Count == 0)
                {
                    dgvChiTiet.DataSource = null;
                    MessageBox.Show("Không tìm thấy bài viết nào thỏa mãn điều kiện lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Format lại dữ liệu để hiển thị lên GridView
                var displayList = list.Select(n => new
                {
                    ButDanh = n.ButDanh,
                    TenBai = n.TenBai,
                    TenSoBao = n.TenSoBao,
                    Muc = n.Muc,
                    TienNhuanBut = n.TienNhuanBut.ToString("N0") + " VNĐ",
                    TrangThai = n.DaThanhToan ? $"Đã chi ({n.MaPhieuChi})" : "Chưa thanh toán",
                    NgayNhap = n.NgayNhap.ToString("dd/MM/yyyy")
                }).OrderBy(x => x.ButDanh).ThenBy(x => x.NgayNhap).ToList();

                dgvChiTiet.DataSource = displayList;

                // Cập nhật lại tiêu đề cột cho đẹp mắt
                if (dgvChiTiet.Columns.Count > 0)
                {
                    dgvChiTiet.Columns["ButDanh"].HeaderText = "Bút Danh";
                    dgvChiTiet.Columns["TenBai"].HeaderText = "Tên Bài Viết";
                    dgvChiTiet.Columns["TenSoBao"].HeaderText = "Đăng Trên Số Báo";
                    dgvChiTiet.Columns["Muc"].HeaderText = "Mục/Thể Loại";
                    dgvChiTiet.Columns["TienNhuanBut"].HeaderText = "Tiền Nhuận Bút";
                    dgvChiTiet.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    dgvChiTiet.Columns["NgayNhap"].HeaderText = "Ngày Chấm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện bấm nút XUẤT EXCEL
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.Rows.Count == 0 || dgvChiTiet.DataSource == null)
            {
                MessageBox.Show("Chưa có dữ liệu để xuất! Vui lòng bấm Tìm Kiếm trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    FileName = $"ChiTietNhuanBut_{dtpThang.Value.ToString("MM_yyyy")}.xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("ChiTiet_Thang_" + dtpThang.Value.ToString("MM"));

                        // Header (Tiêu đề các cột)
                        for (int i = 0; i < dgvChiTiet.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvChiTiet.Columns[i].HeaderText;
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                            worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.MediumSeaGreen;
                            worksheet.Cell(1, i + 1).Style.Font.FontColor = XLColor.White;
                            worksheet.Cell(1, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }

                        // Data (Dữ liệu từng dòng)
                        for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvChiTiet.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dgvChiTiet.Rows[i].Cells[j].Value?.ToString();
                            }
                        }

                        // Tự động kéo giãn cột cho vừa chữ
                        worksheet.Columns().AdjustToContents();

                        // Lưu file
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Đã xuất Excel thành công!", "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}