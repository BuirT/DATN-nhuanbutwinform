using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTrangChinh : Form
    {
        private Guna.UI2.WinForms.Guna2Panel pnlDesktopInner;

        public string currentUserName { get; set; }
        public string currentPrivilege { get; set; }
        public string currentMaTacGia { get; set; }

        private Form activeForm = null;
        private Guna2Button currentActiveButton = null;

        private Guna2Button btnLichSuThanhToan;

        public FrmTrangChinh()
        {
            InitializeComponent();
            InitDynamicUI();
            BuildModernUI();
        }

        private void InitDynamicUI()
        {
            this.btnLichSuThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnLichSuThanhToan.BorderRadius = 10;
            this.btnLichSuThanhToan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLichSuThanhToan.FillColor = System.Drawing.Color.Transparent;
            this.btnLichSuThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLichSuThanhToan.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnLichSuThanhToan.Height = 44;
            this.btnLichSuThanhToan.Text = "LỊCH SỬ GIAO DỊCH";
            this.btnLichSuThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLichSuThanhToan.TextOffset = new System.Drawing.Point(20, 0);
            this.btnLichSuThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLichSuThanhToan.HoverState.FillColor = System.Drawing.Color.FromArgb(238, 242, 255);
            this.btnLichSuThanhToan.HoverState.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnLichSuThanhToan.Image = btnPhieuChi.Image; 
            this.btnLichSuThanhToan.ImageSize = new System.Drawing.Size(24, 24);
            this.btnLichSuThanhToan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLichSuThanhToan.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnLichSuThanhToan.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            this.btnLichSuThanhToan.Click += new System.EventHandler(this.btnLichSuThanhToan_Click);
        }

        private void btnLichSuThanhToan_Click(object sender, EventArgs e)
        {
            FrmLichSuThanhToan frm = new FrmLichSuThanhToan();
            OpenChildForm(frm, sender as Guna2Button);
        }

        private async void FrmTrangChinh_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlMenuScroll.SuspendLayout();

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

            // LoadButtonIcons(); removed, now in Designer
            pnlMenuScroll.ResumeLayout();
            pnlMenu.ResumeLayout();
            this.ResumeLayout();
        }

        public void BtnSidebar_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn)
            {
                btn.TextOffset = new Point(btn.TextOffset.X + 8, btn.TextOffset.Y);
                if (btn.Image != null)
                    btn.ImageOffset = new Point(btn.ImageOffset.X + 8, btn.ImageOffset.Y);
            }
        }

        public void BtnSidebar_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Guna2Button btn)
            {
                btn.TextOffset = new Point(btn.TextOffset.X - 8, btn.TextOffset.Y);
                if (btn.Image != null)
                    btn.ImageOffset = new Point(btn.ImageOffset.X - 8, btn.ImageOffset.Y);
            }
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
                currentActiveButton.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 0);
            }

            currentActiveButton = clickedButton;
            currentActiveButton.FillColor = System.Drawing.Color.FromArgb(254, 226, 226); // Xanh nhạt
            currentActiveButton.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38); // Primary color
            currentActiveButton.CustomBorderColor = System.Drawing.Color.FromArgb(220, 38, 38);
            currentActiveButton.CustomBorderThickness = new System.Windows.Forms.Padding(4, 0, 0, 0);
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
                    btnNhapNhuanBut, btnTraCuuCaNhan, btnThongKeCaNhan,
                    btnKiemDuyet, btnPhieuChi, btnDuyetChi, btnLichSuThanhToan,
                    btnDotThanhToan, btnTaiKhoan,
                    btnTacGia, btnQuanLyBao, btnBaoCao);
            }
            else if (role == "phóng viên" || role == "cộng tác viên" || role == "khách mời")
            {
                SetButtonVisible(true, btnNhapNhuanBut, btnTraCuuCaNhan, btnThongKeCaNhan);
            }
            else if (role == "thư ký")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard);
            }
            else if (role == "kế toán")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnPhieuChi, btnDuyetChi, btnLichSuThanhToan,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard,
                    btnTroLyAI, btnBaoCaoAI,
                    btnDotThanhToan);
            }
            else if (role == "lãnh đạo")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet, btnDuyetChi, btnLichSuThanhToan,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard,
                    btnTroLyAI, btnBaoCaoAI,
                    btnDotThanhToan, btnTaiKhoan);
            }
            else if (role == "kiểm tra viên")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard);
            }
            else if (role == "tổng thư ký")
            {
                SetButtonVisible(true,
                    btnNhapNhuanBut, btnTraCuuCaNhan,
                    btnKiemDuyet,
                    btnBaoCaoThongKe, btnCanhBaoAI, btnDashboard);
            }

            // Hide empty group labels dynamically
            System.Windows.Forms.Label currentGroupLabel = null;
            bool hasVisibleButtonInGroup = false;

            for (int i = pnlMenuScroll.Controls.Count - 1; i >= 0; i--)
            {
                Control c = pnlMenuScroll.Controls[i];
                if (c is System.Windows.Forms.Label && c.Tag != null && c.Tag.ToString() == "GROUP")
                {
                    if (currentGroupLabel != null)
                    {
                        currentGroupLabel.Visible = hasVisibleButtonInGroup;
                    }
                    currentGroupLabel = (System.Windows.Forms.Label)c;
                    hasVisibleButtonInGroup = false;
                }
                else if (c is Guna.UI2.WinForms.Guna2Button && c.Visible)
                {
                    hasVisibleButtonInGroup = true;
                }
            }
            if (currentGroupLabel != null)
            {
                currentGroupLabel.Visible = hasVisibleButtonInGroup;
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
            pnlDesktopInner.Controls.Clear();
            pnlDesktopInner.Controls.Add(childForm);
            pnlDesktopInner.Tag = childForm;
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

        private void btnSubSoBao_Click(object sender, EventArgs e) { OpenChildForm(new FrmSoBao(), sender as Guna2Button); }
        private void btnSubLoaiBao_Click(object sender, EventArgs e) { OpenChildForm(new FrmLoaiBao(), sender as Guna2Button); }
        private void btnTraCuuCaNhan_Click(object sender, EventArgs e)
        {
            FrmTraCuuNhuanBut frm = new FrmTraCuuNhuanBut();
            frm.NguoiDangNhap = this.currentUserName;
            OpenChildForm(frm, sender as Guna2Button);
        }
        private void btnThongKeCaNhan_Click(object sender, EventArgs e)
        {
            FrmThongkePhongvien frm = new FrmThongkePhongvien();
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
        private void btnSubTacGiaHoSo_Click(object sender, EventArgs e) { OpenChildForm(new FrmTacGia(), sender as Guna2Button); }
        private void btnButDanh_Click(object sender, EventArgs e) { OpenChildForm(new FrmButDanh(), sender as Guna2Button); }
        private void btnTaiKhoan_Click(object sender, EventArgs e) { OpenChildForm(new FrmTaiKhoan(), sender as Guna2Button); }

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
        private void btnSubBaoCaoTH_Click(object sender, EventArgs e) { OpenChildForm(new FrmBaoCaoTongHop(), sender as Guna2Button); }
        private void btnSubBaoCaoCN_Click(object sender, EventArgs e) { OpenChildForm(new FrmBaoCaoCongNo(), sender as Guna2Button); }
        private void btnSubBaoCaoLD_Click(object sender, EventArgs e) { OpenChildForm(new FrmBaoCaoLanhDao(), sender as Guna2Button); }

        private void btnDotThanhToan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmThanhToan(), sender as Guna2Button);
        }

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
    
        private void BuildModernUI()
        {
            pnlMenu.Width = 220;
            pnlMain.Controls.Clear();
            pnlMain.BackColor = System.Drawing.Color.FromArgb(244, 247, 254);
            
            Guna.UI2.WinForms.Guna2Panel pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Height = 60;
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.BackColor = System.Drawing.Color.White;
            pnlHeader.ShadowDecoration.Enabled = true;
            pnlHeader.ShadowDecoration.Depth = 10;
            
            System.Windows.Forms.Label lblNgay = new System.Windows.Forms.Label();
            lblNgay.Name = "lblNgay";
            lblNgay.Text = "Hôm nay: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lblNgay.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            lblNgay.ForeColor = System.Drawing.Color.DimGray;
            lblNgay.AutoSize = true;
            lblNgay.Location = new System.Drawing.Point(20, 20);
            pnlHeader.Controls.Add(lblNgay);

            System.Windows.Forms.Timer tmrClock = new System.Windows.Forms.Timer();
            tmrClock.Interval = 1000;
            tmrClock.Tick += (s, e) => { lblNgay.Text = "Hôm nay: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); };
            tmrClock.Start();
            
            System.Windows.Forms.Label lblUser = new System.Windows.Forms.Label();
            lblUser.Text = "Xin chào, " + (string.IsNullOrEmpty(this.currentUserName) ? "Admin" : this.currentUserName);
            lblUser.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            lblUser.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            lblUser.AutoSize = true;
            lblUser.Location = new System.Drawing.Point(pnlMain.Width - 300, 20);
            lblUser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pnlHeader.Controls.Add(lblUser);
            
            Guna.UI2.WinForms.Guna2Panel pnlDesktopContainer = new Guna.UI2.WinForms.Guna2Panel();
            pnlDesktopContainer.Name = "pnlDesktopContainer";
            pnlDesktopContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlDesktopContainer.Padding = new System.Windows.Forms.Padding(20);
            
            pnlDesktopInner = new Guna.UI2.WinForms.Guna2Panel();
            pnlDesktopInner.Name = "pnlDesktopInner";
            pnlDesktopInner.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlDesktopInner.BackColor = System.Drawing.Color.White;
            pnlDesktopInner.BorderRadius = 12;
            pnlDesktopInner.ShadowDecoration.Enabled = true;
            pnlDesktopInner.ShadowDecoration.Depth = 10;
            
            pnlDesktopContainer.Controls.Add(pnlDesktopInner);
            
            pnlMain.Controls.Add(pnlDesktopContainer);
            pnlMain.Controls.Add(pnlHeader);
            pnlDesktopContainer.BringToFront();
            
            // pnlLogo is kept intact with its designer-added picLogo
            pnlMenuScroll.Controls.Clear();
            
            Action<string> AddGroup = (title) => {
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Text = title;
                lbl.Tag = "GROUP";
                lbl.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = System.Drawing.Color.Gray;
                lbl.Dock = System.Windows.Forms.DockStyle.Top;
                lbl.Height = 35;
                lbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                lbl.Padding = new System.Windows.Forms.Padding(15, 0, 0, 5);
                pnlMenuScroll.Controls.Add(lbl);
                lbl.BringToFront();
            };
            
            Action<Guna.UI2.WinForms.Guna2Button, string> AddBtn = (btn, text) => {
                if (btn == null) return;
                btn.Text = text;
                btn.Dock = System.Windows.Forms.DockStyle.Top;
                btn.Height = 45;
                btn.TextOffset = new System.Drawing.Point(10, 0);
                btn.Visible = true;
                btn.CustomBorderThickness = new System.Windows.Forms.Padding(0,0,0,0);
                pnlMenuScroll.Controls.Add(btn);
                btn.BringToFront();
            };

            AddBtn(btnDashboard, "Dashboard");

            AddGroup("DANH MỤC");
            AddBtn(btnTacGia, "QUẢN LÝ TÁC GIẢ  ▲");
            AddBtn(btnSubTacGiaHoSo, "Hồ sơ tác giả");
            AddBtn(btnSubButDanh, "Bút danh");
            AddBtn(btnQuanLyBao, "QUẢN LÝ BÁO  ▲");
            AddBtn(btnSubLoaiBao, "Loại báo");
            AddBtn(btnSubSoBao, "Số báo");
            
            AddGroup("NGHIỆP VỤ");
            AddBtn(btnNhapNhuanBut, "Nhập nhuận bút");
            AddBtn(btnKiemDuyet, "Kiểm duyệt");
            AddBtn(btnTraCuuCaNhan, "Tra cứu nhuận bút");
            if (btnThongKeCaNhan != null) AddBtn(btnThongKeCaNhan, "Thống kê cá nhân");
            AddBtn(btnPhieuChi, "Phiếu chi");
            AddBtn(btnDuyetChi, "Duyệt phiếu chi");
            AddBtn(btnLichSuThanhToan, "Lịch sử giao dịch");
            AddBtn(btnDotThanhToan, "Thanh toán");

            AddGroup("AI HỖ TRỢ");
            AddBtn(btnBaoCaoAI, "Kiểm định AI");
            AddBtn(btnTroLyAI, "Trợ lý AI");
            AddBtn(btnCanhBaoAI, "Cảnh báo AI");

            AddGroup("BÁO CÁO");
            if (btnBaoCaoThongKe != null) AddBtn(btnBaoCaoThongKe, "Báo cáo tổng hợp");
            else if (btnBaoCao != null) AddBtn(btnBaoCao, "Báo cáo tổng hợp");
            AddBtn(btnSubBaoCaoCN, "Báo cáo công nợ");
        }
}
}
