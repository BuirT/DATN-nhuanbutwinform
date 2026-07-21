using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTraCuuNhuanBut : Form
    {
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
        public string MaTacGiaCuaToi { get; set; }
        public string NguoiDangNhap { get; set; }
        public string QuyenHienTai { get; set; }

        private bool LaAdmin => string.Equals(QuyenHienTai?.Trim(), "admin", StringComparison.OrdinalIgnoreCase)
                             || string.Equals(QuyenHienTai?.Trim(), "quản trị viên", StringComparison.OrdinalIgnoreCase);
        private bool LaPhongVien => string.Equals(QuyenHienTai?.Trim(), "phóng viên", StringComparison.OrdinalIgnoreCase);

        public FrmTraCuuNhuanBut()
        {
            InitializeComponent();
        }

        private async void FrmTraCuuNhuanBut_Load(object sender, EventArgs e)
        {
            if (!LaAdmin && !LaPhongVien)
            {
                this.Visible = false;
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            UIHelper.FormatGiaoDienBang(dgvTraCuu);

            if (string.IsNullOrEmpty(MaTacGiaCuaToi))
            {
                if (LaAdmin)
                {
                    lblMaSo.Text = "📋 Toàn bộ dữ liệu (admin)";
                    lblMaSo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
                }
                else
                {
                    lblMaSo.Text = "Hiển thị bài do bạn nhập";
                    lblMaSo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
                }
            }
            else
            {
                lblMaSo.Text = "Mã hồ sơ: " + MaTacGiaCuaToi;
                lblMaSo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            }
            await LoadDataTraCuuAsync();
        }

        private async Task LoadDataTraCuuAsync()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();

                    string query;
                    if (!string.IsNullOrEmpty(MaTacGiaCuaToi))
                    {
                        query = @"
                            SELECT nb.Butdanh, nb.Tenbai, nb.TienNhuanbut, nb.TrangThaiDuyet,
                                   b.Tenbao AS TenSoBao
                            FROM Nhuanbut nb
                            LEFT JOIN Bao b ON nb.MsBao = b.Maso
                            WHERE nb.Butdanh IN (
                                SELECT Butdanh FROM ButDanh WHERE MsTacgia = @ms
                            )
                            ORDER BY nb.ngaychuyen DESC";
                    }
                    else if (LaAdmin)
                    {
                        query = @"
                            SELECT nb.Butdanh, nb.Tenbai, nb.TienNhuanbut, nb.TrangThaiDuyet,
                                   b.Tenbao AS TenSoBao
                            FROM Nhuanbut nb
                            LEFT JOIN Bao b ON nb.MsBao = b.Maso
                            ORDER BY nb.ngaychuyen DESC";
                    }
                    else
                    {
                        query = @"
                            SELECT nb.Butdanh, nb.Tenbai, nb.TienNhuanbut, nb.TrangThaiDuyet,
                                   b.Tenbao AS TenSoBao
                            FROM Nhuanbut nb
                            LEFT JOIN Bao b ON nb.MsBao = b.Maso
                            WHERE nb.NguoiNhap = @nguoi
                            ORDER BY nb.ngaychuyen DESC";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(MaTacGiaCuaToi))
                            cmd.Parameters.AddWithValue("@ms", MaTacGiaCuaToi);
                        if (string.IsNullOrEmpty(MaTacGiaCuaToi) && !LaAdmin)
                            cmd.Parameters.AddWithValue("@nguoi", NguoiDangNhap ?? "");
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            await Task.Run(() => da.Fill(dt));
                        }
                    }
                }

                if (dt.Rows.Count == 0) return;

                dgvTraCuu.DataSource = dt.AsEnumerable().Select(n => new {
                    SoBao = n.Field<string>("TenSoBao") ?? "",
                    TenBai = n.Field<string>("Tenbai"),
                    ButDanh = n.Field<string>("Butdanh"),
                    TienNB = n.Field<decimal?>("TienNhuanbut") ?? 0,
                    TrangThai = GetStatusText(n.Field<int?>("TrangThaiDuyet") ?? 0, n.Field<decimal?>("TienNhuanbut") ?? 0)
                }).OrderByDescending(x => x.SoBao).ToList();

                if (dgvTraCuu.Columns["SoBao"] != null)
                    dgvTraCuu.Columns["SoBao"].HeaderText = "Số Báo";
                if (dgvTraCuu.Columns["TenBai"] != null)
                    dgvTraCuu.Columns["TenBai"].HeaderText = "Tên Bài";
                if (dgvTraCuu.Columns["ButDanh"] != null)
                    dgvTraCuu.Columns["ButDanh"].HeaderText = "Bút Danh";
                if (dgvTraCuu.Columns["TienNB"] != null)
                {
                    dgvTraCuu.Columns["TienNB"].HeaderText = "Tiền NB";
                    dgvTraCuu.Columns["TienNB"].DefaultCellStyle.Format = "N0";
                }
                if (dgvTraCuu.Columns["TrangThai"] != null)
                    dgvTraCuu.Columns["TrangThai"].HeaderText = "Trạng Thái";

                decimal daDuyet = dt.AsEnumerable().Where(n => (n.Field<int?>("TrangThaiDuyet") ?? 0) >= 4).Sum(n => n.Field<decimal?>("TienNhuanbut") ?? 0);
                lblTongTien.Text = daDuyet.ToString("N0") + " VNĐ";

                decimal dangCho = dt.AsEnumerable().Where(n => (n.Field<int?>("TrangThaiDuyet") ?? 0) < 4).Sum(n => n.Field<decimal?>("TienNhuanbut") ?? 0);
                lblDangCho.Text = dangCho.ToString("N0") + " VNĐ";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private string GetStatusText(int trangThai, decimal tien)
        {
            if (trangThai == 0) return "⏳ Chờ chấm tiền";
            if (trangThai == 1) return "💰 Đã chấm (chờ nhập liệu)";
            if (trangThai == 2) return "📝 Đã nhập liệu (chờ kiểm tra)";
            if (trangThai == 3) return "🔍 Đã kiểm tra (chờ ký duyệt)";
            if (trangThai == 4) return "✅ Đã ký duyệt";
            return "⏳ Chờ xử lý";
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataTraCuuAsync();
        }
    }
}
