using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmBaoCaoChiTiet : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmBaoCaoChiTiet()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoChiTiet_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvChiTiet);
            dtpThang.Value = DateTime.Now;
            LoadAuthors();
        }

        private void LoadAuthors()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    conn.Open();
                    // Thêm mục "Tất cả" vào đầu danh sách
                    string query = "SELECT '--- Tất cả tác giả ---' as Butdanh UNION SELECT DISTINCT Butdanh FROM tmpCongNoTacGia ORDER BY Butdanh";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboTacGia.DisplayMember = "Butdanh";
                    cboTacGia.ValueMember = "Butdanh";
                    cboTacGia.DataSource = dt;
                    cboTacGia.DropDownHeight = 200;
                    cboTacGia.IntegralHeight = true;
                    cboTacGia.MaxDropDownItems = 15;
                    cboTacGia.SelectedIndex = 0; // Chọn "Tất cả" mặc định
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải tác giả: " + ex.Message); }
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    DateTime startOfMonth = new DateTime(dtpThang.Value.Year, dtpThang.Value.Month, 1);
                    DateTime endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

                    string query = @"SELECT * FROM tmpCongNoTacGia 
                                     WHERE Ngayra >= @tuNgay AND Ngayra <= @denNgay";

                    if (cboTacGia.SelectedIndex > 0)
                        query += " AND Butdanh = @butDanh";

                    query += " ORDER BY Ngayra DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tuNgay", startOfMonth);
                        cmd.Parameters.AddWithValue("@denNgay", endOfMonth);
                        if (cboTacGia.SelectedIndex > 0)
                            cmd.Parameters.AddWithValue("@butDanh", cboTacGia.Text);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    dgvChiTiet.DataSource = null;
                    MessageBox.Show("Không có dữ liệu cho tháng này!");
                    return;
                }
                dgvChiTiet.DataSource = dt;
                FormatGridColumns();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void FormatGridColumns()
        {
            if (dgvChiTiet.Columns.Count > 0)
            {
                dgvChiTiet.Columns["id"].Visible = false;
                dgvChiTiet.Columns["STT"].HeaderText = "STT";
                dgvChiTiet.Columns["Ngayra"].HeaderText = "Ngày ra";
                dgvChiTiet.Columns["Tenbai"].HeaderText = "Tên bài viết";
                dgvChiTiet.Columns["Butdanh"].HeaderText = "Bút danh";
                dgvChiTiet.Columns["Loaibao"].HeaderText = "Loại báo";
                dgvChiTiet.Columns["Sotien"].HeaderText = "Số tiền (VNĐ)";
                dgvChiTiet.Columns["SoPC"].HeaderText = "Số phiếu chi";
                dgvChiTiet.Columns["Conlai"].HeaderText = "Còn lại";
                dgvChiTiet.Columns["email"].HeaderText = "Email";
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất!"); return; }
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = "BaoCaoChiTiet_" + dtpThang.Value.ToString("MM_yyyy") + ".xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("ChiTiet");
                    for (int i = 0; i < dgvChiTiet.Columns.Count; i++)
                    {
                        ws.Cell(1, i + 1).Value = dgvChiTiet.Columns[i].HeaderText;
                        ws.Cell(1, i + 1).Style.Font.Bold = true;
                    }
                    for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvChiTiet.Columns.Count; j++)
                        {
                            ws.Cell(i + 2, j + 1).Value = dgvChiTiet.Rows[i].Cells[j].Value?.ToString();
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