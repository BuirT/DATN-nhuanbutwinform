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
            UIHelper.FormatGiaoDienBang(dgvCanhBao);
            this.Load += FrmCanhBaoAI_Load;
            this.dgvCanhBao.DataError += dgvCanhBao_DataError;
            this.dgvCanhBao.CellClick += dgvCanhBao_CellClick;
            this.btnRefresh.Click += btnRefresh_Click;
            this.btnRunAudit.Click += btnRunAudit_Click;
            this.btnMarkProcessed.Click += btnMarkProcessed_Click;
            this.btnXoaDaXuLy.Click += btnXoaDaXuLy_Click;
            this.btnXemBaiViet.Click += btnXemBaiViet_Click;
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
                            a.GiaTriPhatHien,
                            n.Maso AS MaBai,
                            n.Tenbai AS TieuDe,
                            n.TienNhuanbut,
                            n.Muc,
                            n.Butdanh,
                            n.NoiDungBaiViet,
                            n.DanhGiaAI,
                            n.DiemChatLuongAI,
                            n.Butdanh AS TenPhongVien
                        FROM AICanhBao a
                        LEFT JOIN Nhuanbut n ON a.MaBaiViet = n.Maso
                        ORDER BY a.NgayCanhBao DESC", conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dtCanhBao));
                    }
                }

                dgvCanhBao.DataSource = dtCanhBao;
                CauHinhGrid();
                CapNhatKPI();
            }
            catch { }
        }

        private void CauHinhGrid()
        {
            if (dgvCanhBao.Columns["Id"] != null) dgvCanhBao.Columns["Id"].Visible = false;
            if (dgvCanhBao.Columns["MaBaiViet"] != null) dgvCanhBao.Columns["MaBaiViet"].Visible = false;
            if (dgvCanhBao.Columns["MaPhongVien"] != null) dgvCanhBao.Columns["MaPhongVien"].Visible = false;
            if (dgvCanhBao.Columns["NoiDung"] != null) dgvCanhBao.Columns["NoiDung"].Visible = false;
            if (dgvCanhBao.Columns["GiaTriPhatHien"] != null) dgvCanhBao.Columns["GiaTriPhatHien"].Visible = false;
            if (dgvCanhBao.Columns["Muc"] != null) dgvCanhBao.Columns["Muc"].Visible = false;
            if (dgvCanhBao.Columns["Butdanh"] != null) dgvCanhBao.Columns["Butdanh"].Visible = false;
            if (dgvCanhBao.Columns["NoiDungBaiViet"] != null) dgvCanhBao.Columns["NoiDungBaiViet"].Visible = false;
            if (dgvCanhBao.Columns["DanhGiaAI"] != null) dgvCanhBao.Columns["DanhGiaAI"].Visible = false;
            if (dgvCanhBao.Columns["DiemChatLuongAI"] != null) dgvCanhBao.Columns["DiemChatLuongAI"].Visible = false;

            if (dgvCanhBao.Columns["MaBai"] != null)
            {
                dgvCanhBao.Columns["MaBai"].HeaderText = "MÃ BÀI";
                dgvCanhBao.Columns["MaBai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvCanhBao.Columns["TieuDe"] != null)
            {
                dgvCanhBao.Columns["TieuDe"].HeaderText = "TIÊU ĐỀ";
                dgvCanhBao.Columns["TieuDe"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            if (dgvCanhBao.Columns["TenPhongVien"] != null)
                dgvCanhBao.Columns["TenPhongVien"].HeaderText = "PHÓNG VIÊN";
            if (dgvCanhBao.Columns["TienNhuanbut"] != null)
            {
                dgvCanhBao.Columns["TienNhuanbut"].HeaderText = "TIỀN NB";
                dgvCanhBao.Columns["TienNhuanbut"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvCanhBao.Columns["LoaiCanhBao"] != null)
                dgvCanhBao.Columns["LoaiCanhBao"].HeaderText = "LOẠI CẢNH BÁO";
            if (dgvCanhBao.Columns["MucDo"] != null)
            {
                dgvCanhBao.Columns["MucDo"].HeaderText = "MỨC ĐỘ";
                dgvCanhBao.Columns["MucDo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvCanhBao.Columns["NgayCanhBao"] != null)
            {
                dgvCanhBao.Columns["NgayCanhBao"].HeaderText = "NGÀY";
                dgvCanhBao.Columns["NgayCanhBao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvCanhBao.Columns["NgayCanhBao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvCanhBao.Columns["DaXuLy"] != null)
            {
                dgvCanhBao.Columns["DaXuLy"].HeaderText = "TRẠNG THÁI";
                dgvCanhBao.Columns["DaXuLy"].ReadOnly = false;
                dgvCanhBao.Columns["DaXuLy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvCanhBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn c in dgvCanhBao.Columns)
            {
                if (c.Visible)
                {
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (c.DefaultCellStyle.Alignment != DataGridViewContentAlignment.NotSet)
                    {
                        c.HeaderCell.Style.Alignment = c.DefaultCellStyle.Alignment;
                    }
                }
            }
        }

        private void CapNhatKPI()
        {
            if (dtCanhBao == null) return;

            int total = dtCanhBao.Rows.Count;
            int cao = dtCanhBao.AsEnumerable().Count(r =>
            {
                int md = 0; int.TryParse(r["MucDo"]?.ToString(), out md);
                return md >= 3;
            });
            int chuaXuLy = dtCanhBao.AsEnumerable().Count(r =>
            {
                bool dx = false; bool.TryParse(r["DaXuLy"]?.ToString(), out dx);
                return !dx;
            });

            lblKpiTotal.Text = string.Format("Tổng cảnh báo: {0}", total);
            lblKpiCao.Text = string.Format("Mức cao: {0}", cao);
            lblKpiChuaXuLy.Text = string.Format("Chưa xử lý: {0}", chuaXuLy);

            var topPV = dtCanhBao.AsEnumerable()
                .Where(r => r["TenPhongVien"] != null && !string.IsNullOrEmpty(r["TenPhongVien"].ToString()))
                .GroupBy(r => r["TenPhongVien"].ToString())
                .Select(g => new { Ten = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault();

            lblKpiTopPV.Text = "PV cảnh báo nhiều nhất: " + (topPV != null
                ? string.Format("{0} ({1} cảnh báo)", topPV.Ten, topPV.Count)
                : "-");

            lblCount.Text = string.Format("Tổng: {0} cảnh báo (chưa xử lý: {1})", total, chuaXuLy);
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

        private async void btnMarkProcessed_Click(object sender, EventArgs e)
        {
            if (dgvCanhBao.CurrentRow == null) return;
            if (!CoGiaTri(dgvCanhBao.CurrentRow.Cells["Id"].Value)) return;

            int id = ToIntSafe(dgvCanhBao.CurrentRow.Cells["Id"].Value);
            await AIAuditService.DanhDauDaXuLyAsync(id);
            await TaiDuLieuAsync();
        }

        private async void dgvCanhBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvCanhBao.Columns[e.ColumnIndex].Name != "DaXuLy") return;

            DataGridViewRow row = dgvCanhBao.Rows[e.RowIndex];
            if (!CoGiaTri(row.Cells["Id"].Value)) return;

            int id = ToIntSafe(row.Cells["Id"].Value);
            bool daXuLyHienTai = CoGiaTri(row.Cells["DaXuLy"].Value) && Convert.ToBoolean(row.Cells["DaXuLy"].Value);

            await AIAuditService.CapNhatTrangThaiXuLyAsync(id, !daXuLyHienTai);
            await TaiDuLieuAsync();
        }

        private async void btnXoaDaXuLy_Click(object sender, EventArgs e)
        {
            var processed = dtCanhBao?.AsEnumerable().Where(r =>
            {
                bool dx = false; bool.TryParse(r["DaXuLy"]?.ToString(), out dx);
                return dx;
            }).ToList();
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

        private static bool CoGiaTri(object val) => val != null && val != DBNull.Value;

        private static decimal ToDecimalSafe(object val)
        {
            if (!CoGiaTri(val)) return 0;
            try { return Convert.ToDecimal(val); }
            catch { return 0; }
        }

        private static int ToIntSafe(object val)
        {
            if (!CoGiaTri(val)) return 0;
            try { return Convert.ToInt32(val); }
            catch { return 0; }
        }

        private static string TienNBSafe(object val)
        {
            decimal d = ToDecimalSafe(val);
            return d > 0 ? d.ToString("N0") + "đ" : "-";
        }

        private void btnXemBaiViet_Click(object sender, EventArgs e)
        {
            if (dgvCanhBao.CurrentRow == null) return;

            DataGridViewRow row = dgvCanhBao.CurrentRow;

            string tieuDe = row.Cells["TieuDe"]?.Value?.ToString() ?? "";
            string noiDung = row.Cells["NoiDungBaiViet"]?.Value?.ToString() ?? "";
            string danhGiaAI = row.Cells["DanhGiaAI"]?.Value?.ToString() ?? "";
            string diemAI = ToDecimalSafe(row.Cells["DiemChatLuongAI"]?.Value) > 0
                ? ((int)ToDecimalSafe(row.Cells["DiemChatLuongAI"]?.Value)).ToString("0") + "/100"
                : "Chưa có điểm";
            string phongVien = row.Cells["TenPhongVien"]?.Value?.ToString() ?? "";
            string tienNB = TienNBSafe(row.Cells["TienNhuanbut"]?.Value);
            string loaiCanhBao = row.Cells["LoaiCanhBao"]?.Value?.ToString() ?? "";
            string noiDungCanhBao = row.Cells["NoiDung"]?.Value?.ToString() ?? "";

            var frm = new FrmXemBaiViet(tieuDe, noiDung, danhGiaAI, diemAI, phongVien, tienNB, loaiCanhBao, noiDungCanhBao);
            frm.ShowDialog();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dtCanhBao == null) return;
            string keyword = txtTimKiem.Text.Trim().ToLower();
            DataView dv = new DataView(dtCanhBao);
            if (!string.IsNullOrEmpty(keyword))
                dv.RowFilter = string.Format(
                    "CONVERT(TieuDe, 'System.String') LIKE '%{0}%' OR " +
                    "CONVERT(TenPhongVien, 'System.String') LIKE '%{0}%' OR " +
                    "CONVERT(LoaiCanhBao, 'System.String') LIKE '%{0}%' OR " +
                    "CONVERT(NoiDung, 'System.String') LIKE '%{0}%'",
                    keyword.Replace("'", "''"));
            else
                dv.RowFilter = "";
            dgvCanhBao.DataSource = dv;
        }

        private void dgvCanhBao_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dgvCanhBao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            try
            {
                DataGridViewRow row = dgvCanhBao.Rows[e.RowIndex];

                int colIndex = e.ColumnIndex;
                string colName = dgvCanhBao.Columns[colIndex].Name;

                if (colName == "MucDo")
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        int mucDo = Convert.ToInt32(e.Value);
                        e.Value = mucDo == 1 ? "Thấp" : mucDo == 2 ? "TB" : mucDo == 3 ? "Cao" : "Rất cao";
                        e.FormattingApplied = true;
                    }
                    return;
                }

                if (colName == "DaXuLy")
                {
                    return;
                }

                if (colName == "TienNhuanbut")
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        decimal val = Convert.ToDecimal(e.Value);
                        e.Value = val.ToString("N0") + "đ";
                        e.FormattingApplied = true;
                    }
                    return;
                }

                int mucDoRow = 0;
                if (row.Cells["MucDo"].Value != null && row.Cells["MucDo"].Value != DBNull.Value)
                    int.TryParse(row.Cells["MucDo"].Value.ToString(), out mucDoRow);

                bool daXuLy = row.Cells["DaXuLy"].Value != null && row.Cells["DaXuLy"].Value != DBNull.Value
                    ? Convert.ToBoolean(row.Cells["DaXuLy"].Value)
                    : false;

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
                        case 1:
                            row.DefaultCellStyle.BackColor = Color.FromArgb(219, 234, 254);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(29, 78, 216);
                            break;
                    }
                }
            }
            catch { }
        }
    }
}
