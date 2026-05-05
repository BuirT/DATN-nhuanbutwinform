using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HETHONGTINHNHUANBUT.DAL;
using HETHONGTINHNHUANBUT.Models;
using MongoDB.Driver;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTraCuuNhuanBut : Form
    {
        private readonly IMongoCollection<NhuanBut> _nhuanButColl;
        private readonly IMongoCollection<ButDanh> _butDanhColl;
        public string MaTacGiaCuaToi { get; set; }

        public FrmTraCuuNhuanBut()
        {
            InitializeComponent();
            _nhuanButColl = MongoProvider.Instance.GetCollection<NhuanBut>("NhuanBut");
            _butDanhColl = MongoProvider.Instance.GetCollection<ButDanh>("Butdanh");
        }

        private async void FrmTraCuuNhuanBut_Load(object sender, EventArgs e)
        {
            // 1. ẨN SIDEBAR CỦA FORM CHÍNH ĐỂ CHIẾM TOÀN MÀN HÌNH
            var frmMain = Application.OpenForms.OfType<FrmTrangChinh>().FirstOrDefault();
            if (frmMain != null)
            {
                // Kiểm tra cả 2 tên pnlMenu hoặc pnlSidebar cho chắc
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
                var listButDanh = await _butDanhColl.Find(b => b.MsTacgia == MaTacGiaCuaToi).ToListAsync();
                var dsTenButDanh = listButDanh.Select(b => b.Butdanh).ToList();

                if (dsTenButDanh.Count == 0) return;

                var filter = Builders<NhuanBut>.Filter.In(n => n.Butdanh, dsTenButDanh);
                var listBaiViet = await _nhuanButColl.Find(filter).ToListAsync();

                dgvTraCuu.DataSource = listBaiViet.Select(n => new {
                    Kỳ_Báo = n.TenSoBao,
                    Tên_Bài = n.Tenbai,
                    Bút_Danh = n.Butdanh,
                    Số_Tiền = n.TienNhuanbut,
                    Trạng_Thái = n.DaThanhToan ? "✅ Đã nhận" : "⏳ Chờ chi"
                }).OrderByDescending(x => x.Kỳ_Báo).ToList();

                if (dgvTraCuu.Columns["Số_Tiền"] != null)
                    dgvTraCuu.Columns["Số_Tiền"].DefaultCellStyle.Format = "N0";

                decimal daNhan = listBaiViet.Where(n => n.DaThanhToan).Sum(n => n.TienNhuanbut);
                lblTongTien.Text = daNhan.ToString("N0") + " VNĐ";

                decimal dangCho = listBaiViet.Where(n => !n.DaThanhToan).Sum(n => n.TienNhuanbut);
                lblDangCho.Text = dangCho.ToString("N0") + " VNĐ";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Vừa thấy lương xong là đòi chạy luôn, đúng là bản chất "tác giả"!
            DialogResult dr = MessageBox.Show("Có chắc muốn đăng xuất không?",
                                              "Xác nhận thoát",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // 1. Tìm cái Form chính đang chứa form tra cứu này
                var frmMain = Application.OpenForms.OfType<FrmTrangChinh>().FirstOrDefault();

                if (frmMain != null)
                {
                    // 2. Ẩn cái trang chính đi cho khuất mắt
                    frmMain.Hide();

                    // 3. Hiện lại cái Form Login để người khác (hoặc ông) đăng nhập lại
                    FormLogin login = new FormLogin();
                    login.Show();
                }

                // 4. Đóng luôn cái form tra cứu này lại cho sạch bộ nhớ
                this.Close();
            }
        }
    }
}