using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmCanhBaoAI : Form
    {
        private readonly string connStr =
            System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        private DataTable dtCanhBao;

        public FrmCanhBaoAI()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            UIHelper.FormatGiaoDienBang(dgvCanhBao);
            this.Load += FrmCanhBaoAI_Load;
            this.btnRefresh.Click += btnRefresh_Click;
            this.btnRunAudit.Click += btnRunAudit_Click;
            this.btnMarkProcessed.Click += btnMarkProcessed_Click;
            this.btnXoaDaXuLy.Click += btnXoaDaXuLy_Click;
        }

        private async void FrmCanhBaoAI_Load(object sender, EventArgs e)
        {
            await TaiDuLieuAsync();
        }

        private async Task TaiDuLieuAsync()
        {
            try
            {
                dtCanhBao = new DataTable();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT
                            a.Id,
                            a.NgayCanhBao,
                            a.LoaiCanhBao,
                            a.MucDo,
                            a.MaBaiViet,
                            a.MaPhongVien,
                            a.NoiDung,
                            a.DaXuLy,
                            n.Tenbai AS TenBai,
                            n.Butdanh
                        FROM AICanhBao a
                        LEFT JOIN Nhuanbut n ON a.MaBaiViet = n.Maso
                        ORDER BY a.NgayCanhBao DESC", conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dtCanhBao));
                    }
                }

                dgvCanhBao.DataSource = dtCanhBao;

                if (dgvCanhBao.Columns["Id"] != null) dgvCanhBao.Columns["Id"].Visible = false;
                if (dgvCanhBao.Columns["MaBaiViet"] != null) dgvCanhBao.Columns["MaBaiViet"].Visible = false;
                if (dgvCanhBao.Columns["MaPhongVien"] != null) dgvCanhBao.Columns["MaPhongVien"].Visible = false;

                if (dgvCanhBao.Columns["NgayCanhBao"] != null)
                {
                    dgvCanhBao.Columns["NgayCanhBao"].HeaderText = "NGÀY";
                    dgvCanhBao.Columns["NgayCanhBao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvCanhBao.Columns["LoaiCanhBao"] != null)
                    dgvCanhBao.Columns["LoaiCanhBao"].HeaderText = "LOẠI CẢNH BÁO";
                if (dgvCanhBao.Columns["MucDo"] != null)
                {
                    dgvCanhBao.Columns["MucDo"].HeaderText = "MỨC ĐỘ";
                    dgvCanhBao.Columns["MucDo"].Visible = false;
                }
                if (dgvCanhBao.Columns["TenBai"] != null)
                    dgvCanhBao.Columns["TenBai"].HeaderText = "BÀI VIẾT";
                if (dgvCanhBao.Columns["Butdanh"] != null)
                    dgvCanhBao.Columns["Butdanh"].HeaderText = "PV";
                if (dgvCanhBao.Columns["NoiDung"] != null)
                    dgvCanhBao.Columns["NoiDung"].HeaderText = "NỘI DUNG";
                if (dgvCanhBao.Columns["DaXuLy"] != null)
                {
                    dgvCanhBao.Columns["DaXuLy"].HeaderText = "ĐÃ XỬ LÝ";
                }

                int count = dtCanhBao.AsEnumerable().Count(r => !Convert.ToBoolean(r["DaXuLy"]));
                lblCount.Text = string.Format("Tổng: {0} cảnh báo (chưa xử lý: {1})",
                    dtCanhBao.Rows.Count, count);
            }
            catch { }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await TaiDuLieuAsync();
        }

        private async void btnRunAudit_Click(object sender, EventArgs e)
        {
            btnRunAudit.Enabled = false;
            btnRunAudit.Text = "🔄 Đang kiểm toán...";

            try
            {
                int count = (await AIAuditService.KiemToanHetAsync()).Count;
                MessageBox.Show(string.Format("Hoàn tất kiểm toán! Phát hiện {0} bất thường.", count),
                    "Kết quả kiểm toán", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await TaiDuLieuAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm toán: " + ex.Message);
            }
            finally
            {
                btnRunAudit.Enabled = true;
                btnRunAudit.Text = "🔍 Kiểm toán toàn bộ";
            }
        }

        private async void btnXoaDaXuLy_Click(object sender, EventArgs e)
        {
            var processed = dtCanhBao?.AsEnumerable().Where(r => Convert.ToBoolean(r["DaXuLy"])).ToList();
            if (processed == null || processed.Count == 0)
            {
                MessageBox.Show("Không có cảnh báo đã xử lý nào để xoá.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(string.Format(
                "Xoá {0} cảnh báo đã xử lý?", processed.Count),
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM AICanhBao WHERE DaXuLy = 1", conn))
                    {
                        int deleted = await cmd.ExecuteNonQueryAsync();
                        MessageBox.Show(string.Format("Đã xoá {0} cảnh báo.", deleted),
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                await TaiDuLieuAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xoá: " + ex.Message);
            }
        }

        private async void btnMarkProcessed_Click(object sender, EventArgs e)
        {
            if (dgvCanhBao.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvCanhBao.CurrentRow.Cells["Id"].Value);
            await AIAuditService.DanhDauDaXuLyAsync(id);
            await TaiDuLieuAsync();
        }

        private void dgvCanhBao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewRow row = dgvCanhBao.Rows[e.RowIndex];

            if (dgvCanhBao.Columns[e.ColumnIndex].Name == "MucDo" && e.Value != null)
            {
                int mucDo = Convert.ToInt32(e.Value);
                e.Value = mucDo == 1 ? "Thấp" : mucDo == 2 ? "TB" : mucDo == 3 ? "Cao" : "Rất cao";
                e.FormattingApplied = true;
            }

            int mucDoRow = 0;
            if (row.Cells["MucDo"].Value != null)
                int.TryParse(row.Cells["MucDo"].Value.ToString(), out mucDoRow);

            bool daXuLy = row.Cells["DaXuLy"].Value != null &&
                          Convert.ToBoolean(row.Cells["DaXuLy"].Value);

            if (daXuLy)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244);
                row.DefaultCellStyle.ForeColor = Color.Gray;
            }
            else
            {
                switch (mucDoRow)
                {
                    case 3:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                        break;
                    case 2:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(254, 249, 195);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(161, 98, 7);
                        break;
                }
            }
        }
    }
}
