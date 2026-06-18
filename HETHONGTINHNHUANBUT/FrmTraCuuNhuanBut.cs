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

        public FrmTraCuuNhuanBut()
        {
            InitializeComponent();
        }

        private async void FrmTraCuuNhuanBut_Load(object sender, EventArgs e)
        {
            UIHelper.FormatGiaoDienBang(dgvTraCuu);
            var frmMain = Application.OpenForms.OfType<FrmTrangChinh>().FirstOrDefault();
            if (frmMain != null)
            {
                var sidebar = frmMain.Controls.Find("pnlMenu", true).FirstOrDefault()
                           ?? frmMain.Controls.Find("pnlSidebar", true).FirstOrDefault();
                if (sidebar != null) sidebar.Visible = false;
            }

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
                        SELECT nb.Butdanh, nb.Tenbai, nb.TienNhuanbut, nb.DaThanhToan, nb.TenSoBao
                        FROM Nhuanbut nb
                        WHERE nb.Butdanh IN (
                            SELECT Butdanh FROM ButDanh WHERE MsTacgia = @ms
                        )
                        ORDER BY nb.TenSoBao DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ms", MaTacGiaCuaToi);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                if (dt.Rows.Count == 0) return;

                dgvTraCuu.DataSource = dt.AsEnumerable().Select(n => new {
                    Kỳ_Báo = n.Field<string>("TenSoBao"),
                    Tên_Bài = n.Field<string>("Tenbai"),
                    Bút_Danh = n.Field<string>("Butdanh"),
                    Số_Tiền = n.Field<decimal>("TienNhuanbut"),
                    Trạng_Thái = Convert.ToBoolean(n["DaThanhToan"]) ? "✅ Đã nhận" : "⏳ Chờ chi"
                }).OrderByDescending(x => x.Kỳ_Báo).ToList();

                if (dgvTraCuu.Columns["Số_Tiền"] != null)
                    dgvTraCuu.Columns["Số_Tiền"].DefaultCellStyle.Format = "N0";

                decimal daNhan = dt.AsEnumerable().Where(n => Convert.ToBoolean(n["DaThanhToan"])).Sum(n => Convert.ToDecimal(n["TienNhuanbut"]));
                lblTongTien.Text = daNhan.ToString("N0") + " VNĐ";

                decimal dangCho = dt.AsEnumerable().Where(n => !Convert.ToBoolean(n["DaThanhToan"])).Sum(n => Convert.ToDecimal(n["TienNhuanbut"]));
                lblDangCho.Text = dangCho.ToString("N0") + " VNĐ";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Có chắc muốn đăng xuất không?",
                                               "Xác nhận thoát",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                var frmMain = Application.OpenForms.OfType<FrmTrangChinh>().FirstOrDefault();
                if (frmMain != null)
                {
                    frmMain.Hide();
                    FormLogin login = new FormLogin();
                    login.Show();
                }
                this.Close();
            }
        }
    }
}
