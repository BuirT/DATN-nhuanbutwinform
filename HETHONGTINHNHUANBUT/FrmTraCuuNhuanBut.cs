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

        public FrmTraCuuNhuanBut()
        {
            InitializeComponent();
        }

        private async void FrmTraCuuNhuanBut_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvTraCuu);

            if (string.IsNullOrEmpty(MaTacGiaCuaToi))
            {
                lblMaSo.Text = "⚠️ Lỗi: Không xác định được tác giả!";
                lblMaSo.ForeColor = Color.Red;
                return;
            }

            lblMaSo.Text = "Mã hồ sơ: " + MaTacGiaCuaToi;
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

                    string query = @"
                        SELECT nb.Butdanh, nb.Tenbai, nb.TienNhuanbut, nb.TrangThaiDuyet,
                               b.Tenbao AS TenSoBao
                        FROM Nhuanbut nb
                        LEFT JOIN Bao b ON nb.MsBao = b.Maso
                        WHERE (@ms <> '' AND nb.Butdanh IN (
                            SELECT Butdanh FROM ButDanh WHERE MsTacgia = @ms
                        ))
                        OR (@ms = '' AND nb.NguoiNhap = @nguoi)
                        ORDER BY nb.ngaychuyen DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ms", MaTacGiaCuaToi ?? "");
                        cmd.Parameters.AddWithValue("@nguoi", NguoiDangNhap ?? "");
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                if (dt.Rows.Count == 0) return;

                dgvTraCuu.DataSource = dt.AsEnumerable().Select(n => new {
                    Số_Báo = n.Field<string>("TenSoBao") ?? "",
                    Tên_Bài = n.Field<string>("Tenbai"),
                    Bút_Danh = n.Field<string>("Butdanh"),
                    Tiền_NB = n.Field<decimal?>("TienNhuanbut") ?? 0,
                    Trạng_Thái = GetStatusText(n.Field<int?>("TrangThaiDuyet") ?? 0, n.Field<decimal?>("TienNhuanbut") ?? 0)
                }).OrderByDescending(x => x.Số_Báo).ToList();

                if (dgvTraCuu.Columns["Tiền_NB"] != null)
                    dgvTraCuu.Columns["Tiền_NB"].DefaultCellStyle.Format = "N0";

                decimal daDuyet = dt.AsEnumerable().Where(n => (n.Field<int?>("TrangThaiDuyet") ?? 0) >= 2).Sum(n => n.Field<decimal?>("TienNhuanbut") ?? 0);
                lblTongTien.Text = daDuyet.ToString("N0") + " VNĐ";

                decimal dangCho = dt.AsEnumerable().Where(n => (n.Field<int?>("TrangThaiDuyet") ?? 0) < 2).Sum(n => n.Field<decimal?>("TienNhuanbut") ?? 0);
                lblDangCho.Text = dangCho.ToString("N0") + " VNĐ";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private string GetStatusText(int trangThai, decimal tien)
        {
            if (trangThai == 0) return "⏳ Chờ Thư ký";
            if (trangThai == 1) return tien > 0 ? "💰 Chờ Lãnh đạo ký" : "💰 Chờ Kế toán nhập tiền";
            if (trangThai == 2) return "✅ Đã duyệt";
            if (trangThai == 3) return "✅ Đã nhận";
            return "⏳ Chờ xử lý";
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataTraCuuAsync();
        }
    }
}
