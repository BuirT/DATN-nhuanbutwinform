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
            this.DoubleBuffered = true;
            UIHelper.FormatGiaoDienBang(dgvBaoCao);
            this.Load += FrmBaoCaoThongKe_Load;
            this.btnLoc.Click += btnLoc_Click;
            this.btnXuatExcel.Click += btnXuatExcel_Click;
            this.btnIn.Click += btnIn_Click;
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
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = string.Format("BaoCao_NhuanBut_{0:yyyyMMdd}.xlsx", DateTime.Now)
                };

                if (sfd.ShowDialog() == DialogResult.OK)
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

                        var ws = wb.Worksheets.Add(dtExport, "Báo cáo NB");
                        ws.Columns().AdjustToContents();
                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Xuất Excel thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
