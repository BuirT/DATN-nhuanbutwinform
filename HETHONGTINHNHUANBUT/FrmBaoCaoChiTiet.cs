using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using ClosedXML.Excel; // Thư viện chính để làm việc với Excel
using System.IO;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoChiTiet : Form
    {
        public FrmBaoCaoChiTiet()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoChiTiet_Load(object sender, EventArgs e)
        {
            LoadSoBao();
            // ÉP FONT VNI CHO BẢNG LƯỚI ĐỂ HIỆN TIẾNG VIỆT ĐẸP
            Font vniFont = new Font("VNI-Times", 11F);
            dgvReport.DefaultCellStyle.Font = vniFont;
            dgvReport.ThemeStyle.RowsStyle.Font = vniFont;
            cboSoBao.Font = vniFont;
        }

        void LoadSoBao()
        {
            try
            {
                string sql = "SELECT Maso, Tenbao + ' (Số: ' + LTRIM(RTRIM(Sobao)) + ')' as Display FROM Bao ORDER BY Ngayra DESC";
                DataTable dt = MongoProvider.Instance.ExecuteQuery(sql);
                cboSoBao.DataSource = dt;
                cboSoBao.DisplayMember = "Display";
                cboSoBao.ValueMember = "Maso";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách số báo: " + ex.Message); }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cboSoBao.SelectedValue == null) return;

            string sql = @"SELECT Tenbai AS [Tên Bài Viết], Trang AS [Trang], Muc AS [Mục], 
                           Butdanh AS [Bút Danh], TienNhuanbut AS [Số Tiền] 
                           FROM Nhuanbut WHERE MsBao = @msbao ORDER BY Trang ASC";

            DataTable dt = MongoProvider.Instance.ExecuteQuery(sql, new object[] { cboSoBao.SelectedValue });
            dgvReport.DataSource = dt;

            decimal tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                tong += Convert.ToDecimal(row["Số Tiền"]);
            }
            lblTongTien.Text = $"Tổng tiền nhuận bút của số báo: {tong:N0} VNĐ";
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng bấm Xem báo cáo để lấy dữ liệu trước khi xuất!", "Thông báo");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "BangKeNhuanBut_" + DateTime.Now.ToString("yyyyMMdd") })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // SỬ DỤNG THƯ VIỆN CLOSEDXML
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("BangKeChiTiet");

                            // 1. Tạo tiêu đề báo cáo
                            ws.Cell("A1").Value = "BẢNG KÊ NHUẬN BÚT CHI TIẾT";
                            ws.Cell("A2").Value = "Số báo: " + cboSoBao.Text;

                            var rangeHeader = ws.Range("A1:E1");
                            rangeHeader.Merge().Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Range("A2:E2").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Font.SetItalic();

                            // 2. Tạo Header cho bảng
                            for (int i = 0; i < dgvReport.Columns.Count; i++)
                            {
                                var cell = ws.Cell(4, i + 1);
                                cell.Value = dgvReport.Columns[i].HeaderText;
                                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#4F81BD"); // Màu xanh chuyên nghiệp
                                cell.Style.Font.FontColor = XLColor.White;
                                cell.Style.Font.SetBold();
                                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            }

                            // 3. Đổ dữ liệu từ Grid vào
                            for (int r = 0; r < dgvReport.Rows.Count; r++)
                            {
                                for (int c = 0; c < dgvReport.Columns.Count; c++)
                                {
                                    var cell = ws.Cell(r + 5, c + 1);
                                    cell.Value = dgvReport.Rows[r].Cells[c].Value?.ToString();
                                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                }
                            }

                            // 4. Dòng tổng cộng cuối bảng
                            int lastRow = dgvReport.Rows.Count + 5;
                            ws.Cell(lastRow, 4).Value = "TỔNG CỘNG:";
                            ws.Cell(lastRow, 4).Style.Font.SetBold();
                            ws.Cell(lastRow, 5).Value = lblTongTien.Text.Split(':')[1].Trim();
                            ws.Cell(lastRow, 5).Style.Font.SetBold().Font.SetFontColor(XLColor.Red);

                            // 5. Căn chỉnh lại độ rộng cột tự động
                            ws.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}