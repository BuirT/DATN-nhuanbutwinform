using System.Drawing;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    partial class FrmTrangChinh
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrangChinh));
            this.pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenuScroll = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenuFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnDotThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubBaoCaoTH = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubBaoCaoCN = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubBaoCaoLD = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnDuyetChi = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhieuChi = new Guna.UI2.WinForms.Guna2Button();
            this.btnCanhBaoAI = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.btnKiemDuyet = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoAI = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhapNhuanBut = new Guna.UI2.WinForms.Guna2Button();
            this.btnTraCuuCaNhan = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongKeCaNhan = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubLoaiBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubSoBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuanLyBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubButDanh = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubTacGiaHoSo = new Guna.UI2.WinForms.Guna2Button();
            this.btnTacGia = new Guna.UI2.WinForms.Guna2Button();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnTroLyAI = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLichSuThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNgay = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlDesktopContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDesktopInner = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGroupDanhMuc = new System.Windows.Forms.Label();
            this.lblGroupNghiepVu = new System.Windows.Forms.Label();
            this.lblGroupAI = new System.Windows.Forms.Label();
            this.lblGroupBaoCao = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.pnlMenuFooter.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlMenu.BorderThickness = 1;
            this.pnlMenu.Controls.Add(this.pnlMenuScroll);
            this.pnlMenu.Controls.Add(this.pnlMenuFooter);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.MinimumSize = new System.Drawing.Size(280, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.pnlMenu.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.pnlMenu.ShadowDecoration.Depth = 12;
            this.pnlMenu.Size = new System.Drawing.Size(280, 750);
            this.pnlMenu.TabIndex = 0;
            // 
            // pnlMenuScroll
            // 
            this.pnlMenuScroll.AutoScroll = true;
            this.pnlMenuScroll.BackColor = System.Drawing.Color.White;
            this.pnlMenuScroll.Controls.Add(this.btnSubBaoCaoLD);
            this.pnlMenuScroll.Controls.Add(this.btnSubBaoCaoCN);
            this.pnlMenuScroll.Controls.Add(this.btnSubBaoCaoTH);
            this.pnlMenuScroll.Controls.Add(this.btnBaoCaoThongKe);
            this.pnlMenuScroll.Controls.Add(this.lblGroupBaoCao);
            this.pnlMenuScroll.Controls.Add(this.btnCanhBaoAI);
            this.pnlMenuScroll.Controls.Add(this.btnTroLyAI);
            this.pnlMenuScroll.Controls.Add(this.btnBaoCaoAI);
            this.pnlMenuScroll.Controls.Add(this.lblGroupAI);
            this.pnlMenuScroll.Controls.Add(this.btnDotThanhToan);
            this.pnlMenuScroll.Controls.Add(this.btnLichSuThanhToan);
            this.pnlMenuScroll.Controls.Add(this.btnDuyetChi);
            this.pnlMenuScroll.Controls.Add(this.btnPhieuChi);
            this.pnlMenuScroll.Controls.Add(this.btnThongKeCaNhan);
            this.pnlMenuScroll.Controls.Add(this.btnTraCuuCaNhan);
            this.pnlMenuScroll.Controls.Add(this.btnKiemDuyet);
            this.pnlMenuScroll.Controls.Add(this.btnNhapNhuanBut);
            this.pnlMenuScroll.Controls.Add(this.lblGroupNghiepVu);
            this.pnlMenuScroll.Controls.Add(this.btnSubSoBao);
            this.pnlMenuScroll.Controls.Add(this.btnSubLoaiBao);
            this.pnlMenuScroll.Controls.Add(this.btnQuanLyBao);
            this.pnlMenuScroll.Controls.Add(this.btnSubButDanh);
            this.pnlMenuScroll.Controls.Add(this.btnSubTacGiaHoSo);
            this.pnlMenuScroll.Controls.Add(this.btnTacGia);
            this.pnlMenuScroll.Controls.Add(this.lblGroupDanhMuc);
            this.pnlMenuScroll.Controls.Add(this.btnDashboard);
            this.pnlMenuScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuScroll.Location = new System.Drawing.Point(14, 64);
            this.pnlMenuScroll.Name = "pnlMenuScroll";
            this.pnlMenuScroll.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.pnlMenuScroll.Size = new System.Drawing.Size(252, 586);
            this.pnlMenuScroll.TabIndex = 2;
            // 
            // pnlMenuFooter
            // 
            this.pnlMenuFooter.BackColor = System.Drawing.Color.White;
            this.pnlMenuFooter.Controls.Add(this.btnTaiKhoan);
            this.pnlMenuFooter.Controls.Add(this.btnDangXuat);
            this.pnlMenuFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenuFooter.Location = new System.Drawing.Point(14, 650);
            this.pnlMenuFooter.Name = "pnlMenuFooter";
            this.pnlMenuFooter.Padding = new System.Windows.Forms.Padding(0, 4, 0, 12);
            this.pnlMenuFooter.Size = new System.Drawing.Size(252, 100);
            this.pnlMenuFooter.TabIndex = 1;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BorderRadius = 10;
            this.btnTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTaiKhoan.FillColor = System.Drawing.Color.Transparent;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTaiKhoan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnTaiKhoan.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiKhoan.Image")));
            this.btnTaiKhoan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaiKhoan.ImageSize = new System.Drawing.Size(24, 24);
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, -2);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(252, 45);
            this.btnTaiKhoan.TabIndex = 9;
            this.btnTaiKhoan.Text = "QUẢN LÝ TÀI KHOẢN";
            this.btnTaiKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaiKhoan.TextOffset = new System.Drawing.Point(10, 0);
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            this.btnTaiKhoan.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnTaiKhoan.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BorderRadius = 10;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDangXuat.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnDangXuat.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.Image")));
            this.btnDangXuat.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDangXuat.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDangXuat.Location = new System.Drawing.Point(0, 43);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(252, 45);
            this.btnDangXuat.TabIndex = 10;
            this.btnDangXuat.Text = "ĐĂNG XUẤT";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            this.btnDangXuat.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnDangXuat.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogo.Controls.Add(this.picLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(14, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Padding = new System.Windows.Forms.Padding(10, 8, 10, 5);
            this.pnlLogo.Size = new System.Drawing.Size(252, 64);
            this.pnlLogo.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = global::HETHONGTINHNHUANBUT.Properties.Resources.logonewspay;
            this.picLogo.Location = new System.Drawing.Point(10, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(232, 51);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // btnDotThanhToan
            // 
            this.btnDotThanhToan.BorderRadius = 10;
            this.btnDotThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDotThanhToan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDotThanhToan.FillColor = System.Drawing.Color.Transparent;
            this.btnDotThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDotThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDotThanhToan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnDotThanhToan.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnDotThanhToan.Image = ((System.Drawing.Image)(resources.GetObject("btnDotThanhToan.Image")));
            this.btnDotThanhToan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDotThanhToan.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDotThanhToan.Location = new System.Drawing.Point(14, 935);
            this.btnDotThanhToan.Name = "btnDotThanhToan";
            this.btnDotThanhToan.Size = new System.Drawing.Size(232, 45);
            this.btnDotThanhToan.TabIndex = 15;
            this.btnDotThanhToan.Text = "QUẢN LÝ ĐỢT CHI";
            this.btnDotThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDotThanhToan.TextOffset = new System.Drawing.Point(10, 0);
            this.btnDotThanhToan.Click += new System.EventHandler(this.btnDotThanhToan_Click);
            this.btnDotThanhToan.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnDotThanhToan.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnSubBaoCaoTH
            // 
            this.btnSubBaoCaoTH.BorderRadius = 10;
            this.btnSubBaoCaoTH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubBaoCaoTH.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubBaoCaoTH.FillColor = System.Drawing.Color.Transparent;
            this.btnSubBaoCaoTH.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubBaoCaoTH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnSubBaoCaoTH.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnSubBaoCaoTH.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubBaoCaoTH.Image = ((System.Drawing.Image)(resources.GetObject("btnSubBaoCaoTH.Image")));
            this.btnSubBaoCaoTH.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubBaoCaoTH.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSubBaoCaoTH.Location = new System.Drawing.Point(14, 890);
            this.btnSubBaoCaoTH.Name = "btnSubBaoCaoTH";
            this.btnSubBaoCaoTH.Size = new System.Drawing.Size(232, 45);
            this.btnSubBaoCaoTH.TabIndex = 17;
            this.btnSubBaoCaoTH.Text = "BÃO CÁO TỔNG HỢP";
            this.btnSubBaoCaoTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubBaoCaoTH.TextOffset = new System.Drawing.Point(10, 0);
            this.btnSubBaoCaoTH.Click += new System.EventHandler(this.btnSubBaoCaoTH_Click);
            this.btnSubBaoCaoTH.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnSubBaoCaoTH.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnSubBaoCaoCN
            // 
            this.btnSubBaoCaoCN.BorderRadius = 10;
            this.btnSubBaoCaoCN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubBaoCaoCN.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubBaoCaoCN.FillColor = System.Drawing.Color.Transparent;
            this.btnSubBaoCaoCN.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubBaoCaoCN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnSubBaoCaoCN.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnSubBaoCaoCN.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubBaoCaoCN.Image = ((System.Drawing.Image)(resources.GetObject("btnSubBaoCaoCN.Image")));
            this.btnSubBaoCaoCN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubBaoCaoCN.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSubBaoCaoCN.Location = new System.Drawing.Point(14, 845);
            this.btnSubBaoCaoCN.Name = "btnSubBaoCaoCN";
            this.btnSubBaoCaoCN.Size = new System.Drawing.Size(232, 45);
            this.btnSubBaoCaoCN.TabIndex = 8;
            this.btnSubBaoCaoCN.Text = "BÁO CÁO CÔNG NỢ";
            this.btnSubBaoCaoCN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubBaoCaoCN.TextOffset = new System.Drawing.Point(10, 0);
            this.btnSubBaoCaoCN.Click += new System.EventHandler(this.btnSubBaoCaoCN_Click);
            this.btnSubBaoCaoCN.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnSubBaoCaoCN.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnSubBaoCaoLD
            // 
            this.btnSubBaoCaoLD.BorderRadius = 10;
            this.btnSubBaoCaoLD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubBaoCaoLD.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubBaoCaoLD.FillColor = System.Drawing.Color.Transparent;
            this.btnSubBaoCaoLD.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubBaoCaoLD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnSubBaoCaoLD.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnSubBaoCaoLD.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubBaoCaoLD.Image = ((System.Drawing.Image)(resources.GetObject("btnSubBaoCaoLD.Image")));
            this.btnSubBaoCaoLD.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubBaoCaoLD.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSubBaoCaoLD.Location = new System.Drawing.Point(14, 800);
            this.btnSubBaoCaoLD.Name = "btnSubBaoCaoLD";
            this.btnSubBaoCaoLD.Size = new System.Drawing.Size(232, 45);
            this.btnSubBaoCaoLD.TabIndex = 18;
            this.btnSubBaoCaoLD.Text = "BÁO CÁO LÃNH ĐẠO";
            this.btnSubBaoCaoLD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubBaoCaoLD.TextOffset = new System.Drawing.Point(10, 0);
            this.btnSubBaoCaoLD.Click += new System.EventHandler(this.btnSubBaoCaoLD_Click);
            this.btnSubBaoCaoLD.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnSubBaoCaoLD.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.BorderRadius = 10;
            this.btnBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnBaoCao.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnBaoCao.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("btnBaoCao.Image")));
            this.btnBaoCao.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCao.ImageSize = new System.Drawing.Size(24, 24);
            this.btnBaoCao.Location = new System.Drawing.Point(14, 750);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(232, 45);
            this.btnBaoCao.TabIndex = 6;
            this.btnBaoCao.Text = "BÁO CÁO ▼";
            this.btnBaoCao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCao.TextOffset = new System.Drawing.Point(10, 0);
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            this.btnBaoCao.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnBaoCao.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnDuyetChi
            // 
            this.btnDuyetChi.BorderRadius = 10;
            this.btnDuyetChi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuyetChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDuyetChi.FillColor = System.Drawing.Color.Transparent;
            this.btnDuyetChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDuyetChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDuyetChi.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnDuyetChi.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnDuyetChi.Image = ((System.Drawing.Image)(resources.GetObject("btnDuyetChi.Image")));
            this.btnDuyetChi.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDuyetChi.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDuyetChi.Location = new System.Drawing.Point(14, 700);
            this.btnDuyetChi.Name = "btnDuyetChi";
            this.btnDuyetChi.Size = new System.Drawing.Size(232, 45);
            this.btnDuyetChi.TabIndex = 5;
            this.btnDuyetChi.Text = "LÃNH ĐẠO DUYỆT CHI";
            this.btnDuyetChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDuyetChi.TextOffset = new System.Drawing.Point(10, 0);
            this.btnDuyetChi.Click += new System.EventHandler(this.btnDuyetChi_Click);
            this.btnDuyetChi.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnDuyetChi.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnPhieuChi
            // 
            this.btnPhieuChi.BorderRadius = 10;
            this.btnPhieuChi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhieuChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieuChi.FillColor = System.Drawing.Color.Transparent;
            this.btnPhieuChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPhieuChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnPhieuChi.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnPhieuChi.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPhieuChi.Image = ((System.Drawing.Image)(resources.GetObject("btnPhieuChi.Image")));
            this.btnPhieuChi.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhieuChi.ImageSize = new System.Drawing.Size(24, 24);
            this.btnPhieuChi.Location = new System.Drawing.Point(14, 650);
            this.btnPhieuChi.Name = "btnPhieuChi";
            this.btnPhieuChi.Size = new System.Drawing.Size(232, 45);
            this.btnPhieuChi.TabIndex = 4;
            this.btnPhieuChi.Text = "LẬP PHIẾU CHI";
            this.btnPhieuChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhieuChi.TextOffset = new System.Drawing.Point(10, 0);
            this.btnPhieuChi.Click += new System.EventHandler(this.btnPhieuChi_Click);
            this.btnPhieuChi.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnPhieuChi.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnCanhBaoAI
            // 
            this.btnCanhBaoAI.BorderRadius = 10;
            this.btnCanhBaoAI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCanhBaoAI.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCanhBaoAI.FillColor = System.Drawing.Color.Transparent;
            this.btnCanhBaoAI.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCanhBaoAI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnCanhBaoAI.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnCanhBaoAI.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCanhBaoAI.Image = ((System.Drawing.Image)(resources.GetObject("btnCanhBaoAI.Image")));
            this.btnCanhBaoAI.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCanhBaoAI.ImageSize = new System.Drawing.Size(24, 24);
            this.btnCanhBaoAI.Location = new System.Drawing.Point(14, 550);
            this.btnCanhBaoAI.Name = "btnCanhBaoAI";
            this.btnCanhBaoAI.Size = new System.Drawing.Size(232, 45);
            this.btnCanhBaoAI.TabIndex = 20;
            this.btnCanhBaoAI.Text = "CẢNH BÁO AI";
            this.btnCanhBaoAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCanhBaoAI.TextOffset = new System.Drawing.Point(10, 0);
            this.btnCanhBaoAI.Click += new System.EventHandler(this.btnCanhBaoAI_Click);
            this.btnCanhBaoAI.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnCanhBaoAI.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnBaoCaoThongKe
            // 
            this.btnBaoCaoThongKe.BorderRadius = 10;
            this.btnBaoCaoThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCaoThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoThongKe.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCaoThongKe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnBaoCaoThongKe.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnBaoCaoThongKe.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnBaoCaoThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnBaoCaoThongKe.Image")));
            this.btnBaoCaoThongKe.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoThongKe.ImageSize = new System.Drawing.Size(24, 24);
            this.btnBaoCaoThongKe.Location = new System.Drawing.Point(14, 550);
            this.btnBaoCaoThongKe.Name = "btnBaoCaoThongKe";
            this.btnBaoCaoThongKe.Size = new System.Drawing.Size(232, 45);
            this.btnBaoCaoThongKe.TabIndex = 21;
            this.btnBaoCaoThongKe.Text = "BÁO CÁO THỐNG KÊ";
            this.btnBaoCaoThongKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoThongKe.TextOffset = new System.Drawing.Point(10, 0);
            this.btnBaoCaoThongKe.Click += new System.EventHandler(this.btnBaoCaoThongKe_Click);
            this.btnBaoCaoThongKe.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnBaoCaoThongKe.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnKiemDuyet
            // 
            this.btnKiemDuyet.BorderRadius = 10;
            this.btnKiemDuyet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKiemDuyet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKiemDuyet.FillColor = System.Drawing.Color.Transparent;
            this.btnKiemDuyet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnKiemDuyet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnKiemDuyet.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnKiemDuyet.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnKiemDuyet.Image = ((System.Drawing.Image)(resources.GetObject("btnKiemDuyet.Image")));
            this.btnKiemDuyet.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKiemDuyet.ImageSize = new System.Drawing.Size(24, 24);
            this.btnKiemDuyet.Location = new System.Drawing.Point(14, 600);
            this.btnKiemDuyet.Name = "btnKiemDuyet";
            this.btnKiemDuyet.Size = new System.Drawing.Size(232, 45);
            this.btnKiemDuyet.TabIndex = 5;
            this.btnKiemDuyet.Text = "KIỂM DUYỆT NHUẬN BÚT";
            this.btnKiemDuyet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKiemDuyet.TextOffset = new System.Drawing.Point(10, 0);
            this.btnKiemDuyet.Click += new System.EventHandler(this.btnKiemDuyet_Click);
            this.btnKiemDuyet.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnKiemDuyet.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnBaoCaoAI
            // 
            this.btnBaoCaoAI.BorderRadius = 10;
            this.btnBaoCaoAI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCaoAI.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoAI.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCaoAI.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoAI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnBaoCaoAI.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnBaoCaoAI.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnBaoCaoAI.Image = ((System.Drawing.Image)(resources.GetObject("btnBaoCaoAI.Image")));
            this.btnBaoCaoAI.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoAI.ImageSize = new System.Drawing.Size(24, 24);
            this.btnBaoCaoAI.Location = new System.Drawing.Point(14, 550);
            this.btnBaoCaoAI.Name = "btnBaoCaoAI";
            this.btnBaoCaoAI.Size = new System.Drawing.Size(232, 45);
            this.btnBaoCaoAI.TabIndex = 15;
            this.btnBaoCaoAI.Text = "BÁO CÁO TỔNG KẾT AI";
            this.btnBaoCaoAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoAI.TextOffset = new System.Drawing.Point(10, 0);
            this.btnBaoCaoAI.Click += new System.EventHandler(this.btnBaoCaoAI_Click);
            this.btnBaoCaoAI.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnBaoCaoAI.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnNhapNhuanBut
            // 
            this.btnNhapNhuanBut.BorderRadius = 10;
            this.btnNhapNhuanBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhapNhuanBut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapNhuanBut.FillColor = System.Drawing.Color.Transparent;
            this.btnNhapNhuanBut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNhapNhuanBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnNhapNhuanBut.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnNhapNhuanBut.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnNhapNhuanBut.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapNhuanBut.Image")));
            this.btnNhapNhuanBut.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhapNhuanBut.ImageSize = new System.Drawing.Size(24, 24);
            this.btnNhapNhuanBut.Location = new System.Drawing.Point(14, 450);
            this.btnNhapNhuanBut.Name = "btnNhapNhuanBut";
            this.btnNhapNhuanBut.Size = new System.Drawing.Size(232, 45);
            this.btnNhapNhuanBut.TabIndex = 3;
            this.btnNhapNhuanBut.Text = "QUẢN LÝ NHUẬN BÚT";
            this.btnNhapNhuanBut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhapNhuanBut.TextOffset = new System.Drawing.Point(10, 0);
            this.btnNhapNhuanBut.Click += new System.EventHandler(this.btnNhapNhuanBut_Click);
            this.btnNhapNhuanBut.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnNhapNhuanBut.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnTraCuuCaNhan
            // 
            this.btnTraCuuCaNhan.BorderRadius = 10;
            this.btnTraCuuCaNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraCuuCaNhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTraCuuCaNhan.FillColor = System.Drawing.Color.Transparent;
            this.btnTraCuuCaNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTraCuuCaNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTraCuuCaNhan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnTraCuuCaNhan.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTraCuuCaNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnTraCuuCaNhan.Image")));
            this.btnTraCuuCaNhan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTraCuuCaNhan.ImageSize = new System.Drawing.Size(24, 24);
            this.btnTraCuuCaNhan.Location = new System.Drawing.Point(14, 500);
            this.btnTraCuuCaNhan.Name = "btnTraCuuCaNhan";
            this.btnTraCuuCaNhan.Size = new System.Drawing.Size(232, 45);
            this.btnTraCuuCaNhan.TabIndex = 16;
            this.btnTraCuuCaNhan.Text = "TRA CỨU CÁ NHÂN";
            this.btnTraCuuCaNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTraCuuCaNhan.TextOffset = new System.Drawing.Point(10, 0);
            this.btnTraCuuCaNhan.Visible = false;
            this.btnTraCuuCaNhan.Click += new System.EventHandler(this.btnTraCuuCaNhan_Click);
            this.btnTraCuuCaNhan.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnTraCuuCaNhan.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnThongKeCaNhan
            // 
            this.btnThongKeCaNhan.BorderRadius = 10;
            this.btnThongKeCaNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKeCaNhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKeCaNhan.FillColor = System.Drawing.Color.Transparent;
            this.btnThongKeCaNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThongKeCaNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnThongKeCaNhan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnThongKeCaNhan.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnThongKeCaNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKeCaNhan.Image")));
            this.btnThongKeCaNhan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKeCaNhan.ImageSize = new System.Drawing.Size(24, 24);
            this.btnThongKeCaNhan.Location = new System.Drawing.Point(14, 544);
            this.btnThongKeCaNhan.Name = "btnThongKeCaNhan";
            this.btnThongKeCaNhan.Size = new System.Drawing.Size(232, 45);
            this.btnThongKeCaNhan.TabIndex = 17;
            this.btnThongKeCaNhan.Text = "THỐNG KÊ CÁ NHÂN";
            this.btnThongKeCaNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKeCaNhan.TextOffset = new System.Drawing.Point(10, 0);
            this.btnThongKeCaNhan.Visible = false;
            this.btnThongKeCaNhan.Click += new System.EventHandler(this.btnThongKeCaNhan_Click);
            this.btnThongKeCaNhan.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnThongKeCaNhan.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnSubLoaiBao
            // 
            this.btnSubLoaiBao.BorderRadius = 10;
            this.btnSubLoaiBao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubLoaiBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubLoaiBao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubLoaiBao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubLoaiBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubLoaiBao.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnSubLoaiBao.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubLoaiBao.Image = ((System.Drawing.Image)(resources.GetObject("btnSubLoaiBao.Image")));
            this.btnSubLoaiBao.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubLoaiBao.ImageSize = new System.Drawing.Size(18, 18);
            this.btnSubLoaiBao.Location = new System.Drawing.Point(14, 405);
            this.btnSubLoaiBao.Name = "btnSubLoaiBao";
            this.btnSubLoaiBao.Size = new System.Drawing.Size(232, 45);
            this.btnSubLoaiBao.TabIndex = 13;
            this.btnSubLoaiBao.Text = "• Loại báo";
            this.btnSubLoaiBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubLoaiBao.TextOffset = new System.Drawing.Point(10, 0);
            this.btnSubLoaiBao.Visible = false;
            this.btnSubLoaiBao.Click += new System.EventHandler(this.btnSubLoaiBao_Click);
            this.btnSubLoaiBao.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnSubLoaiBao.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnSubSoBao
            // 
            this.btnSubSoBao.BorderRadius = 10;
            this.btnSubSoBao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubSoBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubSoBao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubSoBao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubSoBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubSoBao.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnSubSoBao.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubSoBao.Image = ((System.Drawing.Image)(resources.GetObject("btnSubSoBao.Image")));
            this.btnSubSoBao.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubSoBao.ImageSize = new System.Drawing.Size(18, 18);
            this.btnSubSoBao.Location = new System.Drawing.Point(14, 360);
            this.btnSubSoBao.Name = "btnSubSoBao";
            this.btnSubSoBao.Size = new System.Drawing.Size(232, 45);
            this.btnSubSoBao.TabIndex = 12;
            this.btnSubSoBao.Text = "• Số báo";
            this.btnSubSoBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubSoBao.TextOffset = new System.Drawing.Point(10, 0);
            this.btnSubSoBao.Visible = false;
            this.btnSubSoBao.Click += new System.EventHandler(this.btnSubSoBao_Click);
            this.btnSubSoBao.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnSubSoBao.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnQuanLyBao
            // 
            this.btnQuanLyBao.BorderRadius = 10;
            this.btnQuanLyBao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyBao.FillColor = System.Drawing.Color.Transparent;
            this.btnQuanLyBao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuanLyBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnQuanLyBao.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnQuanLyBao.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnQuanLyBao.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyBao.Image")));
            this.btnQuanLyBao.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuanLyBao.ImageSize = new System.Drawing.Size(24, 24);
            this.btnQuanLyBao.Location = new System.Drawing.Point(14, 310);
            this.btnQuanLyBao.Name = "btnQuanLyBao";
            this.btnQuanLyBao.Size = new System.Drawing.Size(232, 45);
            this.btnQuanLyBao.TabIndex = 11;
            this.btnQuanLyBao.Text = "QUẢN LÝ BÁO ▼";
            this.btnQuanLyBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuanLyBao.TextOffset = new System.Drawing.Point(10, 0);
            this.btnQuanLyBao.Click += new System.EventHandler(this.btnQuanLyBao_Click);
            this.btnQuanLyBao.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnQuanLyBao.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnSubButDanh
            // 
            this.btnSubButDanh.BorderRadius = 10;
            this.btnSubButDanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubButDanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubButDanh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubButDanh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubButDanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubButDanh.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnSubButDanh.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubButDanh.Image = ((System.Drawing.Image)(resources.GetObject("btnSubButDanh.Image")));
            this.btnSubButDanh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubButDanh.ImageSize = new System.Drawing.Size(18, 18);
            this.btnSubButDanh.Location = new System.Drawing.Point(14, 265);
            this.btnSubButDanh.Name = "btnSubButDanh";
            this.btnSubButDanh.Size = new System.Drawing.Size(232, 45);
            this.btnSubButDanh.TabIndex = 2;
            this.btnSubButDanh.Text = "• Bút danh";
            this.btnSubButDanh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubButDanh.TextOffset = new System.Drawing.Point(10, 0);
            this.btnSubButDanh.Visible = false;
            this.btnSubButDanh.Click += new System.EventHandler(this.btnButDanh_Click);
            this.btnSubButDanh.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnSubButDanh.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnSubTacGiaHoSo
            // 
            this.btnSubTacGiaHoSo.BorderRadius = 10;
            this.btnSubTacGiaHoSo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubTacGiaHoSo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubTacGiaHoSo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubTacGiaHoSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubTacGiaHoSo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubTacGiaHoSo.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnSubTacGiaHoSo.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubTacGiaHoSo.Image = ((System.Drawing.Image)(resources.GetObject("btnSubTacGiaHoSo.Image")));
            this.btnSubTacGiaHoSo.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubTacGiaHoSo.ImageSize = new System.Drawing.Size(18, 18);
            this.btnSubTacGiaHoSo.Location = new System.Drawing.Point(14, 220);
            this.btnSubTacGiaHoSo.Name = "btnSubTacGiaHoSo";
            this.btnSubTacGiaHoSo.Size = new System.Drawing.Size(232, 45);
            this.btnSubTacGiaHoSo.TabIndex = 18;
            this.btnSubTacGiaHoSo.Text = "• Hồ sơ tác giả";
            this.btnSubTacGiaHoSo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubTacGiaHoSo.TextOffset = new System.Drawing.Point(10, 0);
            this.btnSubTacGiaHoSo.Visible = false;
            this.btnSubTacGiaHoSo.Click += new System.EventHandler(this.btnSubTacGiaHoSo_Click);
            this.btnSubTacGiaHoSo.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnSubTacGiaHoSo.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnTacGia
            // 
            this.btnTacGia.BorderRadius = 10;
            this.btnTacGia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTacGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTacGia.FillColor = System.Drawing.Color.Transparent;
            this.btnTacGia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTacGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTacGia.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnTacGia.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTacGia.Image = ((System.Drawing.Image)(resources.GetObject("btnTacGia.Image")));
            this.btnTacGia.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTacGia.ImageSize = new System.Drawing.Size(24, 24);
            this.btnTacGia.Location = new System.Drawing.Point(14, 170);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(232, 45);
            this.btnTacGia.TabIndex = 1;
            this.btnTacGia.Text = "QUẢN LÝ TÁC GIẢ ▼";
            this.btnTacGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTacGia.TextOffset = new System.Drawing.Point(10, 0);
            this.btnTacGia.Click += new System.EventHandler(this.btnTacGia_Click);
            this.btnTacGia.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnTacGia.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BorderRadius = 10;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FillColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnDashboard.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDashboard.Location = new System.Drawing.Point(14, 120);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(232, 45);
            this.btnDashboard.TabIndex = 19;
            this.btnDashboard.Text = "DASHBOARD";
            this.btnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.TextOffset = new System.Drawing.Point(10, 0);
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            this.btnDashboard.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnDashboard.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // btnTroLyAI
            // 
            this.btnTroLyAI.BorderRadius = 10;
            this.btnTroLyAI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTroLyAI.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTroLyAI.FillColor = System.Drawing.Color.Transparent;
            this.btnTroLyAI.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTroLyAI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTroLyAI.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnTroLyAI.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTroLyAI.Image = ((System.Drawing.Image)(resources.GetObject("btnTroLyAI.Image")));
            this.btnTroLyAI.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTroLyAI.ImageSize = new System.Drawing.Size(24, 24);
            this.btnTroLyAI.Location = new System.Drawing.Point(14, 120);
            this.btnTroLyAI.Name = "btnTroLyAI";
            this.btnTroLyAI.Size = new System.Drawing.Size(232, 45);
            this.btnTroLyAI.TabIndex = 14;
            this.btnTroLyAI.Text = "TRỢ LÝ AI KẾ TOÁN";
            this.btnTroLyAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTroLyAI.TextOffset = new System.Drawing.Point(10, 0);
            this.btnTroLyAI.Click += new System.EventHandler(this.btnTroLyAI_Click);
            this.btnTroLyAI.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnTroLyAI.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.pnlMain.Controls.Add(this.pnlDesktopContainer);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(280, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlMain.ShadowDecoration.Depth = 10;
            this.pnlMain.Size = new System.Drawing.Size(920, 750);
            this.pnlMain.TabIndex = 1;
            // 
            // btnLichSuThanhToan
            // 
            this.btnLichSuThanhToan.BorderRadius = 10;
            this.btnLichSuThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLichSuThanhToan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLichSuThanhToan.FillColor = System.Drawing.Color.Transparent;
            this.btnLichSuThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLichSuThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnLichSuThanhToan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnLichSuThanhToan.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLichSuThanhToan.Image = ((System.Drawing.Image)(resources.GetObject("btnDuyetChi.Image")));
            this.btnLichSuThanhToan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLichSuThanhToan.ImageSize = new System.Drawing.Size(24, 24);
            this.btnLichSuThanhToan.Name = "btnLichSuThanhToan";
            this.btnLichSuThanhToan.Size = new System.Drawing.Size(252, 45);
            this.btnLichSuThanhToan.TabIndex = 22;
            this.btnLichSuThanhToan.Text = "LỊCH SỬ GIAO DỊCH";
            this.btnLichSuThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLichSuThanhToan.TextOffset = new System.Drawing.Point(10, 0);
            this.btnLichSuThanhToan.Click += new System.EventHandler(this.btnLichSuThanhToan_Click);
            this.btnLichSuThanhToan.MouseEnter += new System.EventHandler(this.BtnSidebar_MouseEnter);
            this.btnLichSuThanhToan.MouseLeave += new System.EventHandler(this.BtnSidebar_MouseLeave);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.lblNgay);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(960, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNgay.ForeColor = System.Drawing.Color.DimGray;
            this.lblNgay.Location = new System.Drawing.Point(20, 20);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(90, 20);
            this.lblNgay.TabIndex = 0;
            this.lblNgay.Text = "Hôm nay: ";
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 1000;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblUser.Location = new System.Drawing.Point(640, 20);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(80, 20);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Xin chào";
            // 
            // pnlDesktopContainer
            // 
            this.pnlDesktopContainer.Controls.Add(this.pnlDesktopInner);
            this.pnlDesktopContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktopContainer.Name = "pnlDesktopContainer";
            this.pnlDesktopContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDesktopContainer.Size = new System.Drawing.Size(960, 690);
            this.pnlDesktopContainer.TabIndex = 1;
            // 
            // pnlDesktopInner
            // 
            this.pnlDesktopInner.BackColor = System.Drawing.Color.White;
            this.pnlDesktopInner.BorderRadius = 12;
            this.pnlDesktopInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktopInner.Name = "pnlDesktopInner";
            this.pnlDesktopInner.ShadowDecoration.Depth = 10;
            this.pnlDesktopInner.ShadowDecoration.Enabled = true;
            this.pnlDesktopInner.Size = new System.Drawing.Size(920, 650);
            this.pnlDesktopInner.TabIndex = 0;
            // 
            // lblGroupDanhMuc
            // 
            this.lblGroupDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupDanhMuc.ForeColor = System.Drawing.Color.Gray;
            this.lblGroupDanhMuc.Name = "lblGroupDanhMuc";
            this.lblGroupDanhMuc.Padding = new System.Windows.Forms.Padding(15, 0, 0, 5);
            this.lblGroupDanhMuc.Size = new System.Drawing.Size(212, 35);
            this.lblGroupDanhMuc.TabIndex = 23;
            this.lblGroupDanhMuc.Tag = "GROUP";
            this.lblGroupDanhMuc.Text = "DANH MỤC";
            this.lblGroupDanhMuc.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblGroupNghiepVu
            // 
            this.lblGroupNghiepVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupNghiepVu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupNghiepVu.ForeColor = System.Drawing.Color.Gray;
            this.lblGroupNghiepVu.Name = "lblGroupNghiepVu";
            this.lblGroupNghiepVu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 5);
            this.lblGroupNghiepVu.Size = new System.Drawing.Size(212, 35);
            this.lblGroupNghiepVu.TabIndex = 24;
            this.lblGroupNghiepVu.Tag = "GROUP";
            this.lblGroupNghiepVu.Text = "NGHIỆP VỤ";
            this.lblGroupNghiepVu.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblGroupAI
            // 
            this.lblGroupAI.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupAI.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupAI.ForeColor = System.Drawing.Color.Gray;
            this.lblGroupAI.Name = "lblGroupAI";
            this.lblGroupAI.Padding = new System.Windows.Forms.Padding(15, 0, 0, 5);
            this.lblGroupAI.Size = new System.Drawing.Size(212, 35);
            this.lblGroupAI.TabIndex = 25;
            this.lblGroupAI.Tag = "GROUP";
            this.lblGroupAI.Text = "AI HỖ TRỢ";
            this.lblGroupAI.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblGroupBaoCao
            // 
            this.lblGroupBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupBaoCao.ForeColor = System.Drawing.Color.Gray;
            this.lblGroupBaoCao.Name = "lblGroupBaoCao";
            this.lblGroupBaoCao.Padding = new System.Windows.Forms.Padding(15, 0, 0, 5);
            this.lblGroupBaoCao.Size = new System.Drawing.Size(212, 35);
            this.lblGroupBaoCao.TabIndex = 26;
            this.lblGroupBaoCao.Tag = "GROUP";
            this.lblGroupBaoCao.Text = "BÁO CÁO";
            this.lblGroupBaoCao.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FrmTrangChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTrangChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Nhuận bút";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTrangChinh_FormClosed);
            this.Load += new System.EventHandler(this.FrmTrangChinh_Load);
            this.Resize += new System.EventHandler(this.FrmTrangChinh_Resize);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenuFooter.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlDesktopContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuFooter;
        private Guna.UI2.WinForms.Guna2Panel pnlLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private Guna.UI2.WinForms.Guna2Button btnBaoCaoAI;
        private Guna.UI2.WinForms.Guna2Button btnBaoCaoThongKe;
        private Guna.UI2.WinForms.Guna2Button btnCanhBaoAI;
        private Guna.UI2.WinForms.Guna2Button btnTroLyAI;
        private Guna.UI2.WinForms.Guna2Button btnTacGia;
        private Guna.UI2.WinForms.Guna2Button btnSubTacGiaHoSo;
        private Guna.UI2.WinForms.Guna2Button btnSubButDanh;
        private Guna.UI2.WinForms.Guna2Button btnQuanLyBao;
        private Guna.UI2.WinForms.Guna2Button btnSubSoBao;
        private Guna.UI2.WinForms.Guna2Button btnSubLoaiBao;
        private Guna.UI2.WinForms.Guna2Button btnNhapNhuanBut;
        private Guna.UI2.WinForms.Guna2Button btnTraCuuCaNhan;
        private Guna.UI2.WinForms.Guna2Button btnThongKeCaNhan;
        private Guna.UI2.WinForms.Guna2Button btnKiemDuyet;
        private Guna.UI2.WinForms.Guna2Button btnPhieuChi;
        private Guna.UI2.WinForms.Guna2Button btnDuyetChi;
        private Guna.UI2.WinForms.Guna2Button btnBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnSubBaoCaoCN;
        private Guna.UI2.WinForms.Guna2Button btnSubBaoCaoTH;
        private Guna.UI2.WinForms.Guna2Button btnSubBaoCaoLD;
        private Guna.UI2.WinForms.Guna2Button btnDotThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnTaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        public Guna.UI2.WinForms.Guna2Panel pnlDesktopInner;
        public Guna.UI2.WinForms.Guna2Button btnLichSuThanhToan;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.Label lblUser;
        private Guna.UI2.WinForms.Guna2Panel pnlDesktopContainer;
        private System.Windows.Forms.Label lblGroupDanhMuc;
        private System.Windows.Forms.Label lblGroupNghiepVu;
        private System.Windows.Forms.Label lblGroupAI;
        private System.Windows.Forms.Label lblGroupBaoCao;
    }
}

