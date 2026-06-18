using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoCongNo : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmBaoCaoCongNo()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoCongNo_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvCongNo);
            dtpDenThang.Value = DateTime.Now;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTong = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT tg.Maso, tg.Hoten,
                               ISNULL(SUM(ct.Sotien), 0) AS Sotien,
                               ISNULL(SUM(CASE WHEN pc.TrangThaiDuyet = 1 THEN ct.Sotien ELSE 0 END), 0) AS DaTT,
                               ISNULL(SUM(ct.Sotien), 0) - ISNULL(SUM(CASE WHEN pc.TrangThaiDuyet = 1 THEN ct.Sotien ELSE 0 END), 0) AS Conlai
                        FROM TacGia tg
                        LEFT JOIN NhuanbutCT ct ON tg.Maso = ct.MsTacgia
                        LEFT JOIN (
                            SELECT Sophieu, MAX(TrangThaiDuyet) AS TrangThaiDuyet
                            FROM Phieuchi
                            GROUP BY Sophieu
                        ) pc ON ct.SoPC = pc.Sophieu
                        GROUP BY tg.Maso, tg.Hoten
                        HAVING ISNULL(SUM(ct.Sotien), 0) > 0
                        ORDER BY Conlai DESC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.CommandTimeout = 120;
                    da.Fill(dtTong);
                }

                dgvCongNo.DataSource = dtTong;
                if (dgvCongNo.Columns.Count > 0)
                {
                    dgvCongNo.Columns["Maso"].HeaderText = "Mã số";
                    dgvCongNo.Columns["Maso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvCongNo.Columns["Hoten"].HeaderText = "Tác giả";
                    dgvCongNo.Columns["Hoten"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvCongNo.Columns["Sotien"].HeaderText = "Tổng nợ (VNĐ)";
                    dgvCongNo.Columns["Sotien"].DefaultCellStyle.Format = "N0";
                    dgvCongNo.Columns["Sotien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvCongNo.Columns["DaTT"].HeaderText = "Đã thanh toán (VNĐ)";
                    dgvCongNo.Columns["DaTT"].DefaultCellStyle.Format = "N0";
                    dgvCongNo.Columns["DaTT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvCongNo.Columns["Conlai"].HeaderText = "Còn nợ (VNĐ)";
                    dgvCongNo.Columns["Conlai"].DefaultCellStyle.Format = "N0";
                    dgvCongNo.Columns["Conlai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                // Tính tổng nợ (Đã xử lý DBNull)
                decimal tongNo = 0;
                decimal daTra = 0;
                foreach (DataRow row in dtTong.Rows)
                {
                    if (row["Sotien"] != DBNull.Value) tongNo += Convert.ToDecimal(row["Sotien"]);
                    if (row["DaTT"] != DBNull.Value) daTra += Convert.ToDecimal(row["DaTT"]);
                }
                lblTongNo.Text = $"TỔNG NỢ: {tongNo:N0} VNĐ";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvCongNo.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất!"); return; }
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "BaoCaoCongNo_" + DateTime.Now.ToString("MM_yyyy") + ".xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("CongNo");
                    for (int i = 0; i < dgvCongNo.Columns.Count; i++)
                    {
                        ws.Cell(1, i + 1).Value = dgvCongNo.Columns[i].HeaderText;
                        ws.Cell(1, i + 1).Style.Font.Bold = true;
                    }
                    for (int i = 0; i < dgvCongNo.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvCongNo.Columns.Count; j++)
                        {
                            ws.Cell(i + 2, j + 1).Value = dgvCongNo.Rows[i].Cells[j].Value?.ToString();
                        }
                    }
                    ws.Columns().AdjustToContents();
                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất Excel thành công!");
                }
            }
        }
    }
}

