using System;
using System.Linq;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTrangChinh : Form
    {
        public string currentUserName { get; set; }
        public string currentPrivilege { get; set; }
        public string currentMaTacGia { get; set; }

        private Form activeForm = null;

        public FrmTrangChinh()
        {
            InitializeComponent();
        }

        private void FrmTrangChinh_Load(object sender, EventArgs e)
        {
            ApplyPermissions();

            string role = currentPrivilege?.Trim().ToLower() ?? "";
            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                btnTraCuuCaNhan_Click(null, null);
            }
            else
            {
                btnTongQuan_Click(null, null);
            }
        }

        private void ApplyPermissions()
        {
            // Tắt mặc định
            btnDuyetChi.Visible = false;
            btnPhieuChi.Visible = false;
            btnTaiKhoan.Visible = false;

            if (this.Controls.Find("btnTraCuuCaNhan", true).FirstOrDefault() is Control btnTraCuu)
                btnTraCuu.Visible = false;

            string role = currentPrivilege?.Trim().ToLower() ?? "";

            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                // Giấu hết menu quản trị
                btnTongQuan.Visible = false;

                // Giấu cụm Quản lý báo mới
                btnQuanLyBao.Visible = false;
                btnSubSoBao.Visible = false;
                btnSubLoaiBao.Visible = false;

                btnTacGia.Visible = false;
                btnButDanh.Visible = false;
                btnNhapNhuanBut.Visible = false;
                btnBaoCao.Visible = false;
                btnBaoCaoChiTiet.Visible = false;
                btnBaoCaoCongNo.Visible = false;

                if (this.Controls.Find("btnTraCuuCaNhan", true).FirstOrDefault() is Control btnTraCuuVisible)
                    btnTraCuuVisible.Visible = true;
            }
            else if (role == "lãnh đạo")
            {
                btnDuyetChi.Visible = true;
                btnTaiKhoan.Visible = true;
            }
            else if (role == "kế toán")
            {
                btnPhieuChi.Visible = true;
            }
            else if (role == "admin" || role == "quản trị viên")
            {
                btnDuyetChi.Visible = true;
                btnPhieuChi.Visible = true;
                btnTaiKhoan.Visible = true;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;

            var propQuyen = childForm.GetType().GetProperty("QuyenHienTai");
            if (propQuyen != null) propQuyen.SetValue(childForm, currentPrivilege);

            var propMaGoc = childForm.GetType().GetProperty("MaTacGiaCuaToi");
            if (propMaGoc != null) propMaGoc.SetValue(childForm, currentMaTacGia);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // ==========================================================
        // TÍNH NĂNG MỚI: ĐÓNG/MỞ MENU QUẢN LÝ BÁO (ACCORDION EFFECT)
        // ==========================================================
        private void btnQuanLyBao_Click(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái hiện tại của nút con
            bool isExpanded = btnSubSoBao.Visible;

            // Đảo ngược trạng thái (Đang mở thì Đóng, Đang đóng thì Mở)
            btnSubSoBao.Visible = !isExpanded;
            btnSubLoaiBao.Visible = !isExpanded;

            // Đổi text mũi tên cho sinh động
            if (!isExpanded)
                btnQuanLyBao.Text = "QUẢN LÝ BÁO  ▲";
            else
                btnQuanLyBao.Text = "QUẢN LÝ BÁO  ▼";
        }

        // Click vào nút con "Số báo" -> Mở FrmSoBao
        private void btnSubSoBao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSoBao());
        }

        // Click vào nút con "Loại báo" -> Mở FrmLoaiBao (Nếu chưa tạo Form này thì tạm thời khoan bấm nhé)
        private void btnSubLoaiBao_Click(object sender, EventArgs e)
        {
            // Nếu đồng chí Tí chưa thiết kế FrmLoaiBao thì gọi dòng này sẽ báo lỗi
            // Hãy chắc chắn đã tạo form FrmLoaiBao như tôi hướng dẫn ở tin nhắn trước nhé!
            OpenChildForm(new FrmLoaiBao());
        }

        private void btnTraCuuCaNhan_Click(object sender, EventArgs e) => OpenChildForm(new FrmTraCuuNhuanBut());
        private void btnTongQuan_Click(object sender, EventArgs e) => OpenChildForm(new FrmTongQuan());
        private void btnTacGia_Click(object sender, EventArgs e) => OpenChildForm(new FrmTacGia());
        private void btnButDanh_Click(object sender, EventArgs e) => OpenChildForm(new FrmButDanh());
        private void btnTaiKhoan_Click(object sender, EventArgs e) => OpenChildForm(new FrmTaiKhoan());

        private void btnNhapNhuanBut_Click(object sender, EventArgs e)
        {
            FrmNhapNhuanBut frmNhap = new FrmNhapNhuanBut();
            frmNhap.NguoiDangNhap = this.currentUserName;
            OpenChildForm(frmNhap);
        }

        private void btnPhieuChi_Click(object sender, EventArgs e)
        {
            FrmPhieuChi frmChi = new FrmPhieuChi();
            frmChi.NguoiLapPhieu = this.currentUserName;
            OpenChildForm(frmChi);
        }

        private void btnDuyetChi_Click(object sender, EventArgs e)
        {
            FrmDuyetPhieuChi frmDuyet = new FrmDuyetPhieuChi();
            frmDuyet.NguoiDuyet = string.IsNullOrEmpty(this.currentUserName) ? "Ban Giám Đốc" : this.currentUserName;
            OpenChildForm(frmDuyet);
        }

        private void btnBaoCao_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoTongHop());
        private void btnBaoCaoChiTiet_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoChiTiet());
        private void btnBaoCaoCongNo_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoCongNo());

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                new FormLogin().Show();
            }
        }

        private void FrmTrangChinh_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
        private void lblTitle_Click(object sender, EventArgs e) { }
    }
}