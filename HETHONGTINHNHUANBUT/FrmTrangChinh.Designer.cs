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
            this.pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnDotThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubBaoCaoTH = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubBaoCaoCN = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubBaoCaoLD = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnDuyetChi = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhieuChi = new Guna.UI2.WinForms.Guna2Button();
            this.btnKiemDuyet = new Guna.UI2.WinForms.Guna2Button();
            this.btnCanhBaoAI = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoAI = new Guna.UI2.WinForms.Guna2Button();
            this.btnTraCuuCaNhan = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhapNhuanBut = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubLoaiBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubSoBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuanLyBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubButDanh = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubTacGiaHoSo = new Guna.UI2.WinForms.Guna2Button();
            this.btnTacGia = new Guna.UI2.WinForms.Guna2Button();
            this.btnTroLyAI = new Guna.UI2.WinForms.Guna2Button();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlMenu.BorderThickness = 1;
            this.pnlMenu.Controls.Add(this.btnTaiKhoan);
            this.pnlMenu.Controls.Add(this.btnDangXuat);
            this.pnlMenu.Controls.Add(this.btnDotThanhToan);
            this.pnlMenu.Controls.Add(this.btnSubBaoCaoTH);
            this.pnlMenu.Controls.Add(this.btnSubBaoCaoCN);
            this.pnlMenu.Controls.Add(this.btnSubBaoCaoLD);
            this.pnlMenu.Controls.Add(this.btnBaoCao);
            this.pnlMenu.Controls.Add(this.btnDuyetChi);
            this.pnlMenu.Controls.Add(this.btnPhieuChi);
            this.pnlMenu.Controls.Add(this.btnKiemDuyet);
            this.pnlMenu.Controls.Add(this.btnCanhBaoAI);
            this.pnlMenu.Controls.Add(this.btnBaoCaoThongKe);
            this.pnlMenu.Controls.Add(this.btnBaoCaoAI);
            this.pnlMenu.Controls.Add(this.btnTraCuuCaNhan);
            this.pnlMenu.Controls.Add(this.btnNhapNhuanBut);
            this.pnlMenu.Controls.Add(this.btnSubLoaiBao);
            this.pnlMenu.Controls.Add(this.btnSubSoBao);
            this.pnlMenu.Controls.Add(this.btnQuanLyBao);
            this.pnlMenu.Controls.Add(this.btnSubButDanh);
            this.pnlMenu.Controls.Add(this.btnSubTacGiaHoSo);
            this.pnlMenu.Controls.Add(this.btnTacGia);
            this.pnlMenu.Controls.Add(this.btnTroLyAI);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(14, 0, 14, 20);
            this.pnlMenu.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.pnlMenu.ShadowDecoration.Depth = 12;
            this.pnlMenu.ShadowDecoration.Enabled = true;
            this.pnlMenu.Size = new System.Drawing.Size(280, 831);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTaiKhoan.FillColor = System.Drawing.Color.Transparent;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTaiKhoan.Location = new System.Drawing.Point(14, 1115);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(235, 50);
            this.btnTaiKhoan.TabIndex = 9;
            this.btnTaiKhoan.Text = "QUẢN LÝ TÀI KHOẢN";
            this.btnTaiKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaiKhoan.TextOffset = new System.Drawing.Point(20, 0);
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDangXuat.Location = new System.Drawing.Point(14, 1165);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(235, 50);
            this.btnDangXuat.TabIndex = 10;
            this.btnDangXuat.Text = "ĐĂNG XUẤT";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnDotThanhToan
            // 
            this.btnDotThanhToan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDotThanhToan.FillColor = System.Drawing.Color.Transparent;
            this.btnDotThanhToan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDotThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDotThanhToan.Location = new System.Drawing.Point(14, 1085);
            this.btnDotThanhToan.Name = "btnDotThanhToan";
            this.btnDotThanhToan.Size = new System.Drawing.Size(235, 50);
            this.btnDotThanhToan.TabIndex = 15;
            this.btnDotThanhToan.Text = "QUẢN LÝ ĐỢT CHI";
            this.btnDotThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDotThanhToan.TextOffset = new System.Drawing.Point(20, 0);
            this.btnDotThanhToan.Click += new System.EventHandler(this.btnDotThanhToan_Click);
            // 
            // btnSubBaoCaoTH
            // 
            this.btnSubBaoCaoTH.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubBaoCaoTH.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubBaoCaoTH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubBaoCaoTH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubBaoCaoTH.Location = new System.Drawing.Point(14, 1040);
            this.btnSubBaoCaoTH.Name = "btnSubBaoCaoTH";
            this.btnSubBaoCaoTH.Size = new System.Drawing.Size(235, 45);
            this.btnSubBaoCaoTH.TabIndex = 17;
            this.btnSubBaoCaoTH.Text = "• Tổng hợp";
            this.btnSubBaoCaoTH.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubBaoCaoTH.TextOffset = new System.Drawing.Point(40, 0);
            this.btnSubBaoCaoTH.Visible = false;
            this.btnSubBaoCaoTH.Click += new System.EventHandler(this.btnSubBaoCaoTH_Click);
            // 
            // btnSubBaoCaoCN
            // 
            this.btnSubBaoCaoCN.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubBaoCaoCN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubBaoCaoCN.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubBaoCaoCN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubBaoCaoCN.Location = new System.Drawing.Point(14, 995);
            this.btnSubBaoCaoCN.Name = "btnSubBaoCaoCN";
            this.btnSubBaoCaoCN.Size = new System.Drawing.Size(235, 45);
            this.btnSubBaoCaoCN.TabIndex = 8;
            this.btnSubBaoCaoCN.Text = "• Công nợ";
            this.btnSubBaoCaoCN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubBaoCaoCN.TextOffset = new System.Drawing.Point(40, 0);
            this.btnSubBaoCaoCN.Visible = false;
            this.btnSubBaoCaoCN.Click += new System.EventHandler(this.btnSubBaoCaoCN_Click);
            // 
            // btnSubBaoCaoLD
            // 
            this.btnSubBaoCaoLD.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubBaoCaoLD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubBaoCaoLD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubBaoCaoLD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubBaoCaoLD.Location = new System.Drawing.Point(14, 950);
            this.btnSubBaoCaoLD.Name = "btnSubBaoCaoLD";
            this.btnSubBaoCaoLD.Size = new System.Drawing.Size(235, 45);
            this.btnSubBaoCaoLD.TabIndex = 18;
            this.btnSubBaoCaoLD.Text = "• Lãnh đạo";
            this.btnSubBaoCaoLD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubBaoCaoLD.TextOffset = new System.Drawing.Point(40, 0);
            this.btnSubBaoCaoLD.Visible = false;
            this.btnSubBaoCaoLD.Click += new System.EventHandler(this.btnSubBaoCaoLD_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnBaoCao.Location = new System.Drawing.Point(14, 900);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(235, 50);
            this.btnBaoCao.TabIndex = 6;
            this.btnBaoCao.Text = "BÁO CÁO  ▼";
            this.btnBaoCao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCao.TextOffset = new System.Drawing.Point(20, 0);
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnDuyetChi
            // 
            this.btnDuyetChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDuyetChi.FillColor = System.Drawing.Color.Transparent;
            this.btnDuyetChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDuyetChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDuyetChi.Location = new System.Drawing.Point(14, 850);
            this.btnDuyetChi.Name = "btnDuyetChi";
            this.btnDuyetChi.Size = new System.Drawing.Size(235, 50);
            this.btnDuyetChi.TabIndex = 5;
            this.btnDuyetChi.Text = "LÃNH ĐẠO DUYỆT CHI";
            this.btnDuyetChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDuyetChi.TextOffset = new System.Drawing.Point(20, 0);
            this.btnDuyetChi.Click += new System.EventHandler(this.btnDuyetChi_Click);
            // 
            // btnPhieuChi
            // 
            this.btnPhieuChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieuChi.FillColor = System.Drawing.Color.Transparent;
            this.btnPhieuChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPhieuChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnPhieuChi.Location = new System.Drawing.Point(14, 800);
            this.btnPhieuChi.Name = "btnPhieuChi";
            this.btnPhieuChi.Size = new System.Drawing.Size(235, 50);
            this.btnPhieuChi.TabIndex = 4;
            this.btnPhieuChi.Text = "LẬP PHIẾU CHI";
            this.btnPhieuChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhieuChi.TextOffset = new System.Drawing.Point(20, 0);
            this.btnPhieuChi.Click += new System.EventHandler(this.btnPhieuChi_Click);
            // 
            // btnKiemDuyet
            // 
            this.btnKiemDuyet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKiemDuyet.FillColor = System.Drawing.Color.Transparent;
            this.btnKiemDuyet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnKiemDuyet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnKiemDuyet.Location = new System.Drawing.Point(14, 750);
            this.btnKiemDuyet.Name = "btnKiemDuyet";
            this.btnKiemDuyet.Size = new System.Drawing.Size(235, 50);
            this.btnKiemDuyet.TabIndex = 5;
            this.btnKiemDuyet.Text = "KIỂM DUYỆT NHUẬN BÚT";
            this.btnKiemDuyet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKiemDuyet.TextOffset = new System.Drawing.Point(20, 0);
            this.btnKiemDuyet.Click += new System.EventHandler(this.btnKiemDuyet_Click);
            // 
            // btnCanhBaoAI
            // 
            this.btnCanhBaoAI.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCanhBaoAI.FillColor = System.Drawing.Color.Transparent;
            this.btnCanhBaoAI.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCanhBaoAI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnCanhBaoAI.Location = new System.Drawing.Point(14, 700);
            this.btnCanhBaoAI.Name = "btnCanhBaoAI";
            this.btnCanhBaoAI.Size = new System.Drawing.Size(235, 50);
            this.btnCanhBaoAI.TabIndex = 20;
            this.btnCanhBaoAI.Text = "⚠️ CẢNH BÁO AI";
            this.btnCanhBaoAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCanhBaoAI.TextOffset = new System.Drawing.Point(20, 0);
            this.btnCanhBaoAI.Click += new System.EventHandler(this.btnCanhBaoAI_Click);
            // 
            // btnBaoCaoThongKe
            // 
            this.btnBaoCaoThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoThongKe.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCaoThongKe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnBaoCaoThongKe.Location = new System.Drawing.Point(14, 650);
            this.btnBaoCaoThongKe.Name = "btnBaoCaoThongKe";
            this.btnBaoCaoThongKe.Size = new System.Drawing.Size(235, 50);
            this.btnBaoCaoThongKe.TabIndex = 21;
            this.btnBaoCaoThongKe.Text = "📈 BÁO CÁO THỐNG KÊ";
            this.btnBaoCaoThongKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoThongKe.TextOffset = new System.Drawing.Point(20, 0);
            this.btnBaoCaoThongKe.Click += new System.EventHandler(this.btnBaoCaoThongKe_Click);
            // 
            // btnBaoCaoAI
            // 
            this.btnBaoCaoAI.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoAI.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCaoAI.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoAI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnBaoCaoAI.Location = new System.Drawing.Point(14, 600);
            this.btnBaoCaoAI.Name = "btnBaoCaoAI";
            this.btnBaoCaoAI.Size = new System.Drawing.Size(235, 50);
            this.btnBaoCaoAI.TabIndex = 15;
            this.btnBaoCaoAI.Text = "BÁO CÁO TỔNG KẾT AI";
            this.btnBaoCaoAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoAI.TextOffset = new System.Drawing.Point(20, 0);
            this.btnBaoCaoAI.Click += new System.EventHandler(this.btnBaoCaoAI_Click);
            // 
            // btnTraCuuCaNhan
            // 
            this.btnTraCuuCaNhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTraCuuCaNhan.FillColor = System.Drawing.Color.Transparent;
            this.btnTraCuuCaNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTraCuuCaNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTraCuuCaNhan.Location = new System.Drawing.Point(14, 550);
            this.btnTraCuuCaNhan.Name = "btnTraCuuCaNhan";
            this.btnTraCuuCaNhan.Size = new System.Drawing.Size(235, 50);
            this.btnTraCuuCaNhan.TabIndex = 16;
            this.btnTraCuuCaNhan.Text = "TRA CỨU CÁ NHÂN";
            this.btnTraCuuCaNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTraCuuCaNhan.TextOffset = new System.Drawing.Point(20, 0);
            this.btnTraCuuCaNhan.Visible = false;
            this.btnTraCuuCaNhan.Click += new System.EventHandler(this.btnTraCuuCaNhan_Click);
            // 
            // btnNhapNhuanBut
            // 
            this.btnNhapNhuanBut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapNhuanBut.FillColor = System.Drawing.Color.Transparent;
            this.btnNhapNhuanBut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNhapNhuanBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnNhapNhuanBut.Location = new System.Drawing.Point(14, 500);
            this.btnNhapNhuanBut.Name = "btnNhapNhuanBut";
            this.btnNhapNhuanBut.Size = new System.Drawing.Size(235, 50);
            this.btnNhapNhuanBut.TabIndex = 3;
            this.btnNhapNhuanBut.Text = "QUẢN LÝ NHUẬN BÚT";
            this.btnNhapNhuanBut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhapNhuanBut.TextOffset = new System.Drawing.Point(20, 0);
            this.btnNhapNhuanBut.Click += new System.EventHandler(this.btnNhapNhuanBut_Click);
            // 
            // btnSubLoaiBao
            // 
            this.btnSubLoaiBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubLoaiBao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubLoaiBao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubLoaiBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubLoaiBao.Location = new System.Drawing.Point(14, 455);
            this.btnSubLoaiBao.Name = "btnSubLoaiBao";
            this.btnSubLoaiBao.Size = new System.Drawing.Size(235, 45);
            this.btnSubLoaiBao.TabIndex = 13;
            this.btnSubLoaiBao.Text = "• Loại báo";
            this.btnSubLoaiBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubLoaiBao.TextOffset = new System.Drawing.Point(40, 0);
            this.btnSubLoaiBao.Visible = false;
            this.btnSubLoaiBao.Click += new System.EventHandler(this.btnSubLoaiBao_Click);
            // 
            // btnSubSoBao
            // 
            this.btnSubSoBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubSoBao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubSoBao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubSoBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubSoBao.Location = new System.Drawing.Point(14, 410);
            this.btnSubSoBao.Name = "btnSubSoBao";
            this.btnSubSoBao.Size = new System.Drawing.Size(235, 45);
            this.btnSubSoBao.TabIndex = 12;
            this.btnSubSoBao.Text = "• Số báo";
            this.btnSubSoBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubSoBao.TextOffset = new System.Drawing.Point(40, 0);
            this.btnSubSoBao.Visible = false;
            this.btnSubSoBao.Click += new System.EventHandler(this.btnSubSoBao_Click);
            // 
            // btnQuanLyBao
            // 
            this.btnQuanLyBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyBao.FillColor = System.Drawing.Color.Transparent;
            this.btnQuanLyBao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuanLyBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnQuanLyBao.Location = new System.Drawing.Point(14, 360);
            this.btnQuanLyBao.Name = "btnQuanLyBao";
            this.btnQuanLyBao.Size = new System.Drawing.Size(235, 50);
            this.btnQuanLyBao.TabIndex = 11;
            this.btnQuanLyBao.Text = "QUẢN LÝ BÁO  ▼";
            this.btnQuanLyBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuanLyBao.TextOffset = new System.Drawing.Point(20, 0);
            this.btnQuanLyBao.Click += new System.EventHandler(this.btnQuanLyBao_Click);
            // 
            // btnSubButDanh
            // 
            this.btnSubButDanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubButDanh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubButDanh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubButDanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubButDanh.Location = new System.Drawing.Point(14, 315);
            this.btnSubButDanh.Name = "btnSubButDanh";
            this.btnSubButDanh.Size = new System.Drawing.Size(235, 45);
            this.btnSubButDanh.TabIndex = 2;
            this.btnSubButDanh.Text = "• Bút danh";
            this.btnSubButDanh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubButDanh.TextOffset = new System.Drawing.Point(40, 0);
            this.btnSubButDanh.Visible = false;
            this.btnSubButDanh.Click += new System.EventHandler(this.btnButDanh_Click);
            // 
            // btnSubTacGiaHoSo
            // 
            this.btnSubTacGiaHoSo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubTacGiaHoSo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubTacGiaHoSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubTacGiaHoSo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubTacGiaHoSo.Location = new System.Drawing.Point(14, 270);
            this.btnSubTacGiaHoSo.Name = "btnSubTacGiaHoSo";
            this.btnSubTacGiaHoSo.Size = new System.Drawing.Size(235, 45);
            this.btnSubTacGiaHoSo.TabIndex = 18;
            this.btnSubTacGiaHoSo.Text = "• Hồ sơ tác giả";
            this.btnSubTacGiaHoSo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubTacGiaHoSo.TextOffset = new System.Drawing.Point(40, 0);
            this.btnSubTacGiaHoSo.Visible = false;
            this.btnSubTacGiaHoSo.Click += new System.EventHandler(this.btnSubTacGiaHoSo_Click);
            // 
            // btnTacGia
            // 
            this.btnTacGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTacGia.FillColor = System.Drawing.Color.Transparent;
            this.btnTacGia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTacGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTacGia.Location = new System.Drawing.Point(14, 220);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(235, 50);
            this.btnTacGia.TabIndex = 1;
            this.btnTacGia.Text = "QUẢN LÝ TÁC GIẢ  ▼";
            this.btnTacGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTacGia.TextOffset = new System.Drawing.Point(20, 0);
            this.btnTacGia.Click += new System.EventHandler(this.btnTacGia_Click);
            // 
            // btnTroLyAI
            // 
            this.btnTroLyAI.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTroLyAI.FillColor = System.Drawing.Color.Transparent;
            this.btnTroLyAI.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTroLyAI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTroLyAI.Location = new System.Drawing.Point(14, 170);
            this.btnTroLyAI.Name = "btnTroLyAI";
            this.btnTroLyAI.Size = new System.Drawing.Size(235, 50);
            this.btnTroLyAI.TabIndex = 14;
            this.btnTroLyAI.Text = "🤖 TRỢ LÝ AI KẾ TOÁN";
            this.btnTroLyAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTroLyAI.TextOffset = new System.Drawing.Point(20, 0);
            this.btnTroLyAI.Click += new System.EventHandler(this.btnTroLyAI_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FillColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDashboard.Location = new System.Drawing.Point(14, 120);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(235, 50);
            this.btnDashboard.TabIndex = 19;
            this.btnDashboard.Text = "📊 DASHBOARD";
            this.btnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.TextOffset = new System.Drawing.Point(20, 0);
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogo.Controls.Add(this.picLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(14, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Padding = new System.Windows.Forms.Padding(10, 8, 10, 5);
            this.pnlLogo.Size = new System.Drawing.Size(235, 70);
            this.pnlLogo.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = global::HETHONGTINHNHUANBUT.Properties.Resources.logonewspay;
            this.picLogo.Location = new System.Drawing.Point(10, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(215, 57);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(280, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlMain.ShadowDecoration.Depth = 10;
            this.pnlMain.ShadowDecoration.Enabled = true;
            this.pnlMain.Size = new System.Drawing.Size(920, 831);
            this.pnlMain.TabIndex = 1;
            // 
            // FrmTrangChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 831);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTrangChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Nhuận bút";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTrangChinh_FormClosed);
            this.Load += new System.EventHandler(this.FrmTrangChinh_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
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
    }
}