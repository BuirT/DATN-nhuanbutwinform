using System;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTrangChinh : Form
    {
        public string currentUserName { get; set; }
        public string currentPrivilege { get; set; }
        public string currentMaTacGia { get; set; }

        private Form activeForm = null;
        private Guna2Button currentActiveButton = null;

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
                btnNhapNhuanBut_Click(null, null);
                SetActiveButton(this.btnNhapNhuanBut);
            }
            else
            {
                btnTongQuan_Click(null, null);
                SetActiveButton(btnTongQuan);
            }
        }

        private void SetActiveButton(Guna2Button clickedButton)
        {
            if (clickedButton == null) return;

            if (currentActiveButton != null)
            {
                currentActiveButton.FillColor = System.Drawing.Color.Transparent;
                currentActiveButton.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            }

            currentActiveButton = clickedButton;
            currentActiveButton.FillColor = System.Drawing.Color.FromArgb(238, 242, 255);
            currentActiveButton.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
        }

        private void ApplyPermissions()
        {
            btnDuyetChi.Visible = false;
            btnKiemDuyet.Visible = false;
            btnPhieuChi.Visible = false;
            btnTaiKhoan.Visible = false;

            if (this.Controls.Find("btnTraCuuCaNhan", true).FirstOrDefault() is Control btnTraCuu)
                btnTraCuu.Visible = false;

            string role = currentPrivilege?.Trim().ToLower() ?? "";

            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                btnTongQuan.Visible = false;
                btnQuanLyBao.Visible = false;
                btnSubSoBao.Visible = false;
                btnSubLoaiBao.Visible = false;
                btnTacGia.Visible = false;
                btnButDanh.Visible = false;
                btnBaoCao.Visible = false;
                btnBaoCaoChiTiet.Visible = false;
                btnBaoCaoCongNo.Visible = false;
                btnTroLyAI.Visible = false; // Phóng viên không cần AI kế toán

                // Ẩn nút Quản lý đợt chi trả đối với phóng viên
                if (this.Controls.Find("btnDotThanhToan", true).FirstOrDefault() is Control btnDot)
                    btnDot.Visible = false;

                if (this.Controls.Find("btnTraCuuCaNhan", true).FirstOrDefault() is Control btnTraCuuVisible)
                    btnTraCuuVisible.Visible = true;
            }
            else if (role == "thư ký")
            {
                btnKiemDuyet.Visible = true;
            }
            else if (role == "lãnh đạo")
            {
                btnKiemDuyet.Visible = true;
                btnDuyetChi.Visible = true;
                btnTaiKhoan.Visible = true;
            }
            else if (role == "kế toán")
            {
                btnKiemDuyet.Visible = true;
                btnPhieuChi.Visible = true;
            }
            else if (role == "admin" || role == "quản trị viên")
            {
                btnKiemDuyet.Visible = true;
                btnDuyetChi.Visible = true;
                btnPhieuChi.Visible = true;
                btnTaiKhoan.Visible = true;
            }
        }

        private void OpenChildForm(Form childForm, Guna2Button clickedButton = null)
        {
            if (clickedButton != null) SetActiveButton(clickedButton);

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
        // CÁC SỰ KIỆN MỞ FORM CON
        // ==========================================================
        private void btnTroLyAI_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTroLyAI(), sender as Guna2Button);
        }

        // 🌟 ĐÂY LÀ HÀM MỚI ĐỂ MỞ FORM QUẢN LÝ ĐỢT THANH TOÁN
        private void btnDotThanhToan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmThanhToan(), sender as Guna2Button);
        }

        private void btnQuanLyBao_Click(object sender, EventArgs e)
        {
            bool isExpanded = btnSubSoBao.Visible;
            btnSubSoBao.Visible = !isExpanded;
            btnSubLoaiBao.Visible = !isExpanded;

            if (!isExpanded)
                btnQuanLyBao.Text = "QUẢN LÝ BÁO  ▲";
            else
                btnQuanLyBao.Text = "QUẢN LÝ BÁO  ▼";
        }

        private void btnSubSoBao_Click(object sender, EventArgs e) => OpenChildForm(new FrmSoBao());
        private void btnSubLoaiBao_Click(object sender, EventArgs e) => OpenChildForm(new FrmLoaiBao());
        private void btnTraCuuCaNhan_Click(object sender, EventArgs e) => OpenChildForm(new FrmTraCuuNhuanBut(), sender as Guna2Button);
        private void btnTongQuan_Click(object sender, EventArgs e) => OpenChildForm(new FrmTongQuan(), sender as Guna2Button);
        private void btnTacGia_Click(object sender, EventArgs e) => OpenChildForm(new FrmTacGia(), sender as Guna2Button);
        private void btnButDanh_Click(object sender, EventArgs e) => OpenChildForm(new FrmButDanh(), sender as Guna2Button);
        private void btnTaiKhoan_Click(object sender, EventArgs e) => OpenChildForm(new FrmTaiKhoan(), sender as Guna2Button);

        private void btnNhapNhuanBut_Click(object sender, EventArgs e)
        {
            string role = currentPrivilege?.Trim().ToLower() ?? "";
            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                FrmNhapBaiPhongVien frmNhap = new FrmNhapBaiPhongVien();
                frmNhap.NguoiDangNhap = this.currentUserName;
                OpenChildForm(frmNhap, sender as Guna2Button);
            }
            else
            {
                FrmNhapNhuanBut frmNhap = new FrmNhapNhuanBut();
                frmNhap.NguoiDangNhap = this.currentUserName;
                OpenChildForm(frmNhap, sender as Guna2Button);
            }
        }

        private void btnKiemDuyet_Click(object sender, EventArgs e)
        {
            FrmKiemDuyetNhuanBut frm = new FrmKiemDuyetNhuanBut();
            frm.NguoiDangNhap = this.currentUserName;
            OpenChildForm(frm, sender as Guna2Button);
        }

        private void btnPhieuChi_Click(object sender, EventArgs e)
        {
            FrmPhieuChi frmChi = new FrmPhieuChi();
            frmChi.NguoiLapPhieu = this.currentUserName;
            OpenChildForm(frmChi, sender as Guna2Button);
        }

        private void btnDuyetChi_Click(object sender, EventArgs e)
        {
            FrmDuyetPhieuChi frmDuyet = new FrmDuyetPhieuChi();
            frmDuyet.NguoiDuyet = string.IsNullOrEmpty(this.currentUserName) ? "Ban Giám Đốc" : this.currentUserName;
            OpenChildForm(frmDuyet, sender as Guna2Button);
        }

        private void btnBaoCao_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoTongHop(), sender as Guna2Button);
        private void btnBaoCaoChiTiet_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoChiTiet(), sender as Guna2Button);
        private void btnBaoCaoCongNo_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoCongNo(), sender as Guna2Button);

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                new FormLogin().Show();
            }
        }

        private void FrmTrangChinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Ép tắt mọi luồng ngầm khi đóng form
            Environment.Exit(0);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}

