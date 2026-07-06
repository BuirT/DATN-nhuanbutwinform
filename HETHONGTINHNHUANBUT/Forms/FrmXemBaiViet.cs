using System;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmXemBaiViet : Form
    {
        public FrmXemBaiViet(string tieuDe, string noiDung, string danhGiaAI,
            string diemAI, string phongVien, string tienNB, string loaiCanhBao, string noiDungCanhBao)
        {
            InitializeComponent();

            lblTieuDe.Text = tieuDe;
            txtNoiDung.Text = noiDung;
            txtDanhGiaAI.Text = !string.IsNullOrEmpty(danhGiaAI) ? danhGiaAI : "Chưa có đánh giá AI";
            lblPhongVien.Text = phongVien;
            lblTienNB.Text = tienNB;
            lblDiemAI.Text = diemAI;
            lblLoaiCanhBao.Text = loaiCanhBao;
            txtNoiDungCanhBao.Text = noiDungCanhBao;

            this.Load += (s, e) =>
            {
                txtNoiDung.SelectionStart = 0;
                txtNoiDung.SelectionLength = 0;
                txtDanhGiaAI.SelectionStart = 0;
                txtDanhGiaAI.SelectionLength = 0;
                txtNoiDungCanhBao.SelectionStart = 0;
                txtNoiDungCanhBao.SelectionLength = 0;
            };
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
