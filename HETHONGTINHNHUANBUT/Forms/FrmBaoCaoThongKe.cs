using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Guna.UI2.WinForms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoThongKe : Form
    {
        private readonly string connStr =
            System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        private DataTable dtBaoCao;

        public FrmBaoCaoThongKe()
        {
            InitializeComponent();
            UIHelper.FormatGiaoDienBang(dgvBaoCao);
            this.Load += FrmBaoCaoThongKe_Load;
            this.btnLoc.Click += btnLoc_Click;
            this.btnXuatExcel.Click += btnXuatExcel_Click;
        }

        private async void FrmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            await LoadComboboxAsync();
            await LocBaoCaoAsync();
        }

        private async Task LoadComboboxAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();

                    DataTable dtCM = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT DISTINCT Muc FROM Nhuanbut WHERE Muc IS NOT NULL ORDER BY Muc", conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            await Task.Run(() => da.Fill(dtCM));
                    }
                    cboChuyenMuc.DataSource = dtCM;
                    cboChuyenMuc.DisplayMember = "Muc";
                    cboChuyenMuc.ValueMember = "Muc";
                    cboChuyenMuc.SelectedIndex = -1;

                    DataTable dtPV = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT DISTINCT Butdanh FROM Nhuanbut WHERE Butdanh IS NOT NULL ORDER BY Butdanh", conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            await Task.Run(() => da.Fill(dtPV));
                    }
                    cboPhongVien.DataSource = dtPV;
                    cboPhongVien.DisplayMember = "Butdanh";
                    cboPhongVien.ValueMember = "Butdanh";
                    cboPhongVien.SelectedIndex = -1;
                }
            }
            catch { }
        }

        private async void btnLoc_Click(object sender, EventArgs e)
        {
            await LocBaoCaoAsync();
        }

        private async Task LocBaoCaoAsync()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value;
                DateTime denNgay = dtpDenNgay.Value.AddDays(1);
                string cm = cboChuyenMuc.SelectedValue?.ToString() ?? "";
                string pv = cboPhongVien.SelectedValue?.ToString() ?? "";

                StringBuilder sql = new StringBuilder(@"
                    SELECT n.Maso, n.Tenbai, n.Trang, n.Muc, n.Butdanh, n.TienNhuanbut,
                           n.ngaychuyen AS NgayChuyen,
                           CASE n.TrangThaiDuyet
                               WHEN 0 THEN N'Chờ chấm tiền'
                               WHEN 1 THEN N'Đã chấm tiền'
                               WHEN 2 THEN N'Đã nhập liệu'
                               WHEN 3 THEN N'Đã kiểm tra'
                               WHEN 4 THEN N'Đã ký duyệt'
                               ELSE N'Không rõ'
                           END AS TrangThai
                    FROM Nhuanbut n
                    WHERE n.ngaychuyen >= @tu AND n.ngaychuyen < @den");

                if (!string.IsNullOrEmpty(cm))
                {
                    sql.Append(" AND n.Muc = @cm");
                }
                if (!string.IsNullOrEmpty(pv))
                {
                    sql.Append(" AND n.Butdanh = @pv");
                }
                sql.Append(" ORDER BY n.ngaychuyen DESC");

                dtBaoCao = new DataTable();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
                    {
                        cmd.Parameters.AddWithValue("@tu", tuNgay);
                        cmd.Parameters.AddWithValue("@den", denNgay);
                        if (!string.IsNullOrEmpty(cm))
                            cmd.Parameters.AddWithValue("@cm", cm);
                        if (!string.IsNullOrEmpty(pv))
                            cmd.Parameters.AddWithValue("@pv", pv);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            await Task.Run(() => da.Fill(dtBaoCao));
                    }
                }

                dgvBaoCao.DataSource = dtBaoCao;
                if (dgvBaoCao.Columns["Maso"] != null) dgvBaoCao.Columns["Maso"].Visible = false;
                if (dgvBaoCao.Columns["Tenbai"] != null) dgvBaoCao.Columns["Tenbai"].HeaderText = "TÊN BÀI";
                if (dgvBaoCao.Columns["Trang"] != null) dgvBaoCao.Columns["Trang"].HeaderText = "TRANG";
                if (dgvBaoCao.Columns["Muc"] != null) dgvBaoCao.Columns["Muc"].HeaderText = "CM";
                if (dgvBaoCao.Columns["Butdanh"] != null) dgvBaoCao.Columns["Butdanh"].HeaderText = "BÚT DANH";
                if (dgvBaoCao.Columns["TienNhuanbut"] != null)
                {
                    dgvBaoCao.Columns["TienNhuanbut"].HeaderText = "TIỀN NB";
                    dgvBaoCao.Columns["TienNhuanbut"].DefaultCellStyle.Format = "N0";
                }
                if (dgvBaoCao.Columns["NgayChuyen"] != null)
                {
                    dgvBaoCao.Columns["NgayChuyen"].HeaderText = "NGÀY";
                    dgvBaoCao.Columns["NgayChuyen"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                decimal tong = dtBaoCao.AsEnumerable()
                    .Sum(r => r["TienNhuanbut"] == DBNull.Value ? 0 : Convert.ToDecimal(r["TienNhuanbut"]));
                lblTongCong.Text = string.Format("Tổng cộng: {0:N0} VNĐ ({1} bài)", tong, dtBaoCao.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message);
            }
        }

        private async void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dtBaoCao == null || dtBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    DataTable dtExport = dtBaoCao.Copy();

                    foreach (DataColumn col in dtExport.Columns)
                    {
                        if (col.ColumnName == "Maso")
                        {
                            dtExport.Columns.Remove(col.ColumnName);
                            break;
                        }
                    }

                    if (dtExport.Columns.Contains("Tenbai")) dtExport.Columns["Tenbai"].ColumnName = "Tên bài";
                    if (dtExport.Columns.Contains("Trang")) dtExport.Columns["Trang"].ColumnName = "Trang";
                    if (dtExport.Columns.Contains("Muc")) dtExport.Columns["Muc"].ColumnName = "Chuyên mục";
                    if (dtExport.Columns.Contains("Butdanh")) dtExport.Columns["Butdanh"].ColumnName = "Bút danh";
                    if (dtExport.Columns.Contains("TienNhuanbut")) dtExport.Columns["TienNhuanbut"].ColumnName = "Tiền nhuận bút";
                    if (dtExport.Columns.Contains("NgayChuyen")) dtExport.Columns["NgayChuyen"].ColumnName = "Ngày chuyển";
                    if (dtExport.Columns.Contains("TrangThai")) dtExport.Columns["TrangThai"].ColumnName = "Trạng thái";

                    var ws = wb.Worksheets.Add("Báo cáo NB");
                    string title = "BÁO CÁO THỐNG KÊ NHUẬN BÚT - " + DateTime.Now.ToString("MM/yyyy");
                    ws.Cell(1, 1).Value = title;
                    var titleRange = ws.Range(1, 1, 1, dtExport.Columns.Count);
                    titleRange.Merge().Style.Font.SetBold().Font.FontSize = 16;
                    titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    titleRange.Style.Font.FontColor = XLColor.DarkBlue;

                    int startRow = 3;
                    for (int i = 0; i < dtExport.Columns.Count; i++)
                    {
                        var cell = ws.Cell(startRow, i + 1);
                        cell.Value = dtExport.Columns[i].ColumnName;
                        cell.Style.Font.Bold = true;
                        cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }

                    int rowIndex = startRow + 1;
                    foreach (DataRow row in dtExport.Rows)
                    {
                        for (int j = 0; j < dtExport.Columns.Count; j++)
                        {
                            var cell = ws.Cell(rowIndex, j + 1);
                            var val = row[j];
                            if (val != null && decimal.TryParse(val.ToString(), out decimal numVal))
                            {
                                cell.Value = numVal;
                                cell.Style.NumberFormat.Format = "#,##0";
                            }
                            else
                            {
                                cell.Value = val?.ToString();
                            }
                            cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        }
                        rowIndex++;
                    }
                    ws.Columns().AdjustToContents();

                    string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), string.Format("BaoCao_NhuanBut_{0:yyyyMMddHHmmss}.xlsx", DateTime.Now));
                    wb.SaveAs(tempPath);
                    System.Diagnostics.Process.Start(tempPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dtBaoCao == null || dtBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in.");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                float y = 20;
                float x = 20;
                float lineHeight = 18;

                ev.Graphics.DrawString("BÁO CÁO THỐNG KÊ NHUẬN BÚT",
                    new Font("Segoe UI", 14, FontStyle.Bold),
                    Brushes.Black, x, y);
                y += 30;

                ev.Graphics.DrawString(string.Format("Từ: {0:dd/MM/yyyy} - Đến: {1:dd/MM/yyyy}",
                    dtpTuNgay.Value, dtpDenNgay.Value),
                    new Font("Segoe UI", 10), Brushes.Gray, x, y);
                y += 25;

                foreach (DataRow row in dtBaoCao.Rows)
                {
                    string line = string.Format("{0} | {1} | {2:N0}đ | {3:dd/MM/yyyy}",
                        row["Tenbai"], row["Butdanh"], row["TienNhuanbut"], row["NgayChuyen"]);

                    if (y > ev.MarginBounds.Bottom)
                    {
                        ev.HasMorePages = true;
                        return;
                    }

                    ev.Graphics.DrawString(line, new Font("Segoe UI", 9), Brushes.Black, x, y);
                    y += lineHeight;
                }

                decimal tong = dtBaoCao.AsEnumerable()
                    .Sum(r => r["TienNhuanbut"] == DBNull.Value ? 0 : Convert.ToDecimal(r["TienNhuanbut"]));
                y += 10;
                ev.Graphics.DrawString(string.Format("Tổng cộng: {0:N0} VNĐ", tong),
                    new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, x, y);
            };

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = pd };
            ppd.ShowDialog();
        }
    }
}
