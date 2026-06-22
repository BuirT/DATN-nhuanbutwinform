using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
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

        private async void FrmTrangChinh_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlMenuScroll.SuspendLayout();

            await DatabaseMigrator.AutoFixDatabaseColumnsAsync();

            AdjustMenuForScreen();
            ApplyPermissions();

            string role = currentPrivilege?.Trim().ToLower() ?? "";
            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                btnNhapNhuanBut_Click(null, null);
                SetActiveButton(this.btnNhapNhuanBut);
            }
            else
            {
                btnDashboard_Click(null, null);
                SetActiveButton(btnDashboard);
            }

            pnlMenuScroll.ResumeLayout();
            pnlMenu.ResumeLayout();
            this.ResumeLayout();
        }

        private void AdjustMenuForScreen()
        {
            int availableH = Math.Min(Screen.FromControl(this).WorkingArea.Height, this.ClientSize.Height);
            bool compact = availableH < 860;

            int mainH = compact ? 40 : 44;
            int subH = compact ? 34 : 40;
            float mainFont = compact ? 9.75f : 10.5f;
            float subFont = compact ? 9f : 10f;
            int logoH = compact ? 56 : 64;

            pnlLogo.Height = logoH;

            foreach (Control c in pnlMenuScroll.Controls)
            {
                if (c is Guna2Button btn)
                {
                    bool isSub = btn.Name.StartsWith("btnSub");
                    btn.Height = isSub ? subH : mainH;
                    btn.Font = new Font("Segoe UI", isSub ? subFont : mainFont, FontStyle.Bold);
                }
            }

            btnTaiKhoan.Height = compact ? 40 : 44;
            btnDangXuat.Height = compact ? 40 : 44;
            btnTaiKhoan.Font = new Font("Segoe UI", compact ? 9.75f : 10.5f, FontStyle.Bold);
            btnDangXuat.Font = new Font("Segoe UI", compact ? 9.75f : 10.5f, FontStyle.Bold);
            pnlMenuFooter.Height = (btnTaiKhoan.Height + btnDangXuat.Height) + 16;
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmDashboard(), sender as Guna2Button);
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBaoCaoThongKe(), sender as Guna2Button);
        }

        private void btnCanhBaoAI_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCanhBaoAI(), sender as Guna2Button);
        }

        private void ApplyPermissions()
        {
            string role = currentPrivilege?.Trim().ToLower() ?? "";

            btnTaiKhoan.Visible = false;
            foreach (Control c in pnlMenuScroll.Controls)
            {
                if (c is Guna2Button btn)
                    btn.Visible = false;
            }

            if (role == "admin" || role == "quản trị viên")
            {
                SetButtonVisible(true,
                    btnDashboard, btnTroLyAI, btnBaoCaoAI,
                    btnBaoCaoThongKe, btnCanhBaoAI,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet, btnPhieuChi, btnDuyetChi,
                    btnDotThanhToan, btnTaiKhoan,
                    btnTacGia, btnQuanLyBao, btnBaoCao);
                return;
            }

            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                SetButtonVisible(true, btnNhapNhuanBut, btnTraCuuCaNhan);
                return;
            }

            if (role == "thư ký")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard);
                return;
            }

            if (role == "kế toán")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnPhieuChi, btnDuyetChi,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard,
                    btnTroLyAI, btnBaoCaoAI,
                    btnDotThanhToan);
                return;
            }

            if (role == "lãnh đạo")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet, btnDuyetChi,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard,
                    btnTroLyAI, btnBaoCaoAI,
                    btnDotThanhToan, btnTaiKhoan);
                return;
            }

            if (role == "kiểm tra viên")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard);
                return;
            }

            if (role == "tổng thư ký")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard);
            }
        }

        private void SetButtonVisible(bool visible, params Guna.UI2.WinForms.Guna2Button[] buttons)
        {
            foreach (var btn in buttons)
                btn.Visible = visible;
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
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // ==========================================================
        // CÁC SỰ KIỆN MỞ FORM CON
        // ==========================================================
        private void btnBaoCaoAI_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBaoCaoAI(), sender as Guna2Button);
        }

        private void btnTroLyAI_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTroLyAI(), sender as Guna2Button);
        }

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

        private void btnSubSoBao_Click(object sender, EventArgs e) => OpenChildForm(new FrmSoBao(), sender as Guna2Button);
        private void btnSubLoaiBao_Click(object sender, EventArgs e) => OpenChildForm(new FrmLoaiBao(), sender as Guna2Button);
        private void btnTraCuuCaNhan_Click(object sender, EventArgs e)
        {
            FrmTraCuuNhuanBut frm = new FrmTraCuuNhuanBut();
            frm.NguoiDangNhap = this.currentUserName;
            OpenChildForm(frm, sender as Guna2Button);
        }
        private void btnTacGia_Click(object sender, EventArgs e)
        {
            bool isExpanded = btnSubTacGiaHoSo.Visible;
            btnSubTacGiaHoSo.Visible = !isExpanded;
            btnSubButDanh.Visible = !isExpanded;
            btnTacGia.Text = isExpanded ? "QUẢN LÝ TÁC GIẢ  ▼" : "QUẢN LÝ TÁC GIẢ  ▲";
        }
        private void btnSubTacGiaHoSo_Click(object sender, EventArgs e) => OpenChildForm(new FrmTacGia(), sender as Guna2Button);
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

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            bool isExpanded = btnSubBaoCaoTH.Visible;
            btnSubBaoCaoTH.Visible = !isExpanded;
            btnSubBaoCaoCN.Visible = !isExpanded;
            btnSubBaoCaoLD.Visible = !isExpanded;
            btnBaoCao.Text = isExpanded ? "BÁO CÁO  ▼" : "BÁO CÁO  ▲";
        }
        private void btnSubBaoCaoTH_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoTongHop(), sender as Guna2Button);
        private void btnSubBaoCaoCN_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoCongNo(), sender as Guna2Button);
        private void btnSubBaoCaoLD_Click(object sender, EventArgs e) => OpenChildForm(new FrmBaoCaoLanhDao(), sender as Guna2Button);

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                new FormLogin().Show();
            }
        }

        private void FrmTrangChinh_Resize(object sender, EventArgs e)
        {
            if (!IsHandleCreated) return;
            AdjustMenuForScreen();
        }

        private void FrmTrangChinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}