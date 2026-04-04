using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using ClosedXML.Excel;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTongHopThang : Form
    {
        public FrmTongHopThang() { InitializeComponent(); }

        private void FrmTongHopThang_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 12; i++) cboThang.Items.Add(i.ToString());

            int yearHienTai = DateTime.Now.Year;
            for (int i = 2016; i <= yearHienTai + 2; i++)
            {
                cboNam.Items.Add(i.ToString());
            }

            cboThang.Text = DateTime.Now.Month.ToString();
            cboNam.Text = yearHienTai.ToString();

            // SỰ THẬT ĐÃ SÁNG TỎ: KẾT HỢP CẢ 2 LOẠI FONT
            // 1. Tiêu đề cột dùng Segoe UI (Vì mình gõ Unicode trong SQL Alias)
            dgvThang.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            // 2. Dữ liệu bên dưới dùng VNI-Times (Vì Database lưu mã VNI)
            dgvThang.DefaultCellStyle.Font = new Font("VNI-Times", 12F, FontStyle.Regular);

            dgvThang.RowTemplate.Height = 35;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                // Chống đơ giao diện khi load nhiều dữ liệu
                dgvThang.SuspendLayout();

                // Giữ nguyên tiêu đề Unicode để cột hiện đẹp với Segoe UI
                string sql = @"SELECT b.Tenbao AS [Tên Báo], 
                                      b.Sobao AS [Số Báo], 
                                      CONVERT(VARCHAR(10), b.Ngayra, 103) AS [Ngày Xuất Bản], 
                                      SUM(n.TienNhuanbut) AS [Tổng Nhuận Bút]
                               FROM Bao b 
                               JOIN Nhuanbut n ON b.Maso = n.MsBao
                               WHERE MONTH(b.Ngayra) = @m AND YEAR(b.Ngayra) = @y
                               GROUP BY b.Tenbao, b.Sobao, b.Ngayra
                               ORDER BY b.Ngayra ASC";

                DataTable dt = MongoProvider.Instance.ExecuteQuery(sql, new object[] { cboThang.Text, cboNam.Text });
                dgvThang.DataSource = dt;

                if (dgvThang.Columns.Count > 3)
                {
                    dgvThang.Columns[3].DefaultCellStyle.Format = "N0";
                    dgvThang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvThang.ResumeLayout();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvThang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = $"TongHop_Thang{cboThang.Text}_{cboNam.Text}" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Hiện con trỏ chuột quay quay để báo hiệu đang xử lý
                        Cursor.Current = Cursors.WaitCursor;

                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("TongHop");

                            // 1. Tiêu đề Excel
                            var titleRange = ws.Range("A1:D1");
                            titleRange.Merge().Value = $"BẢNG TỔNG HỢP NHUẬN BÚT THÁNG {cboThang.Text}/{cboNam.Text}";
                            titleRange.Style.Font.Bold = true;
                            titleRange.Style.Font.FontSize = 16;
                            titleRange.Style.Font.FontName = "Segoe UI";
                            titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // 2. Đổ dữ liệu Tiêu đề cột
                            for (int i = 0; i < dgvThang.Columns.Count; i++)
                            {
                                ws.Cell(3, i + 1).Value = dgvThang.Columns[i].HeaderText;
                            }
                            // Quét 1 lần cho nguyên hàng Header
                            var headerRange = ws.Range(3, 1, 3, dgvThang.Columns.Count);
                            headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Font.FontName = "Segoe UI";
                            headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                            // 3. Đổ dữ liệu thô cực nhanh (Không format trong vòng lặp)
                            for (int r = 0; r < dgvThang.Rows.Count; r++)
                            {
                                for (int c = 0; c < dgvThang.Columns.Count; c++)
                                {
                                    ws.Cell(r + 4, c + 1).Value = dgvThang.Rows[r].Cells[c].Value?.ToString();
                                }
                            }

                            // 4. TUYỆT CHIÊU: Gom toàn bộ vùng dữ liệu để ép Font VNI 1 LẦN DUY NHẤT
                            var dataRange = ws.Range(4, 1, dgvThang.Rows.Count + 3, dgvThang.Columns.Count);
                            dataRange.Style.Font.FontName = "VNI-Times";
                            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                            // 5. Căn chỉnh và Lưu
                            ws.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);

                            // Trả lại chuột bình thường
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Xuất file Excel thành công!", "Hoàn tất");
                        }
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
                    }
                }
            }
        }

        private void dgvThang_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}