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
                btnTraCuuCaNhan_Click(null, null);
                var btnTraCuu = this.Controls.Find("btnTraCuuCaNhan", true).FirstOrDefault() as Guna2Button;
                if (btnTraCuu != null) SetActiveButton(btnTraCuu);
            }
            else
            {
                btnTongQuan_Click(null, null);
                SetActiveButton(btnTongQuan);
            }
        }

        // Màu active: xanh nhạt
        private void SetActiveButton(Guna2Button activeButton)
        {
            if (currentActiveButton == activeButton) return;

            // Reset tất cả nút chính (Dock = Top)
            foreach (Control ctrl in pnlMenu.Controls)
            {
                if (ctrl is Guna2Button btn && btn.Dock == DockStyle.Top)
                {
                    btn.FillColor = System.Drawing.Color.Transparent;
                    btn.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
                }
            }

            if (activeButton != null)
            {
                activeButton.FillColor = System.Drawing.Color.FromArgb(232, 240, 254); // xanh nhạt
                activeButton.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
                currentActiveButton = activeButton;
            }
        }

        private void ApplyPermissions()
        {
            btnDuyetChi.Visible = false;
            btnPhieuChi.Visible = false;
            btnTaiKhoan.Visible = false;

            var btnTraCuu = this.Controls.Find("btnTraCuuCaNhan", true).FirstOrDefault();
            if (btnTraCuu != null) btnTraCuu.Visible = false;

            string role = currentPrivilege?.Trim().ToLower() ?? "";

            if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                btnTongQuan.Visible = false;
                btnQuanLyBao.Visible = false;
                btnSubSoBao.Visible = false;
                btnSubLoaiBao.Visible = false;
                btnTacGia.Visible = false;
                btnButDanh.Visible = false;
                btnNhapNhuanBut.Visible = false;
                btnBaoCao.Visible = false;
                btnBaoCaoChiTiet.Visible = false;
                btnBaoCaoCongNo.Visible = false;

                if (btnTraCuu != null) btnTraCuu.Visible = true;
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

        private void OpenChildForm(Form childForm, Guna2Button senderButton = null)
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

            pnlMain.SuspendLayout();
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(childForm);
            pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            pnlMain.ResumeLayout();

            if (senderButton != null) SetActiveButton(senderButton);
        }

        private void btnQuanLyBao_Click(object sender, EventArgs e)
        {
            bool isExpanded = btnSubSoBao.Visible;
            btnSubSoBao.Visible = !isExpanded;
            btnSubLoaiBao.Visible = !isExpanded;
            btnQuanLyBao.Text = !isExpanded ? "QUẢN LÝ BÁO  ▲" : "QUẢN LÝ BÁO  ▼";
        }

        private void btnSubSoBao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSoBao(), sender as Guna2Button);
        }

        private void btnSubLoaiBao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmLoaiBao(), sender as Guna2Button);
        }

        private void btnTraCuuCaNhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTraCuuNhuanBut(), sender as Guna2Button);
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTongQuan(), sender as Guna2Button);
        }

        private void btnTacGia_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTacGia(), sender as Guna2Button);
        }

        private void btnButDanh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmButDanh(), sender as Guna2Button);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmTaiKhoan(), sender as Guna2Button);
        }

        private void btnNhapNhuanBut_Click(object sender, EventArgs e)
        {
            FrmNhapNhuanBut frmNhap = new FrmNhapNhuanBut();
            frmNhap.NguoiDangNhap = this.currentUserName;
            OpenChildForm(frmNhap, sender as Guna2Button);
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
            OpenChildForm(new FrmBaoCaoTongHop(), sender as Guna2Button);
        }

        private void btnBaoCaoChiTiet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBaoCaoChiTiet(), sender as Guna2Button);
        }

        private void btnBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBaoCaoCongNo(), sender as Guna2Button);
        }

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