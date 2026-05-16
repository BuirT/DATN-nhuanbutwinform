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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnBaoCaoCongNo = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoChiTiet = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnDuyetChi = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhieuChi = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhapNhuanBut = new Guna.UI2.WinForms.Guna2Button();
            this.btnSoBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnButDanh = new Guna.UI2.WinForms.Guna2Button();
            this.btnTacGia = new Guna.UI2.WinForms.Guna2Button();
            this.btnTongQuan = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlMenu (Sidebar bên trái)
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlMenu.BorderThickness = 1;
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(14, 0, 14, 20);

            // HIỆU ỨNG ĐỔ BÓNG SIDEBAR: Đã bỏ dòng BlurRadius bị lỗi, giữ lại Depth để tự động nhòe mịn
            this.pnlMenu.ShadowDecoration.Enabled = true;
            this.pnlMenu.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.pnlMenu.ShadowDecoration.Depth = 12;
            this.pnlMenu.ShadowDecoration.Parent = this.pnlMenu;

            this.pnlMenu.Controls.Add(this.btnBaoCaoCongNo);
            this.pnlMenu.Controls.Add(this.btnBaoCaoChiTiet);
            this.pnlMenu.Controls.Add(this.btnBaoCao);
            this.pnlMenu.Controls.Add(this.btnDuyetChi);
            this.pnlMenu.Controls.Add(this.btnPhieuChi);
            this.pnlMenu.Controls.Add(this.btnNhapNhuanBut);
            this.pnlMenu.Controls.Add(this.btnSoBao);
            this.pnlMenu.Controls.Add(this.btnButDanh);
            this.pnlMenu.Controls.Add(this.btnTacGia);
            this.pnlMenu.Controls.Add(this.btnTongQuan);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Controls.Add(this.btnTaiKhoan);
            this.pnlMenu.Controls.Add(this.btnDangXuat);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(280, 750);
            this.pnlMenu.TabIndex = 0;

            // 
            // btnBaoCaoCongNo
            // 
            this.btnBaoCaoCongNo.Animated = true;
            this.btnBaoCaoCongNo.BorderRadius = 12;
            this.btnBaoCaoCongNo.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBaoCaoCongNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoCongNo.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCaoCongNo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoCongNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnBaoCaoCongNo.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnBaoCaoCongNo.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnBaoCaoCongNo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnBaoCaoCongNo.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnBaoCaoCongNo.Location = new System.Drawing.Point(14, 550);
            this.btnBaoCaoCongNo.Name = "btnBaoCaoCongNo";
            this.btnBaoCaoCongNo.Size = new System.Drawing.Size(252, 50);
            this.btnBaoCaoCongNo.TabIndex = 0;
            this.btnBaoCaoCongNo.Text = "BÁO CÁO CÔNG NỢ";
            this.btnBaoCaoCongNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoCongNo.TextOffset = new System.Drawing.Point(20, 0);
            this.btnBaoCaoCongNo.Click += new System.EventHandler(this.btnBaoCaoCongNo_Click);

            // 
            // btnBaoCaoChiTiet
            // 
            this.btnBaoCaoChiTiet.Animated = true;
            this.btnBaoCaoChiTiet.BorderRadius = 12;
            this.btnBaoCaoChiTiet.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBaoCaoChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoChiTiet.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCaoChiTiet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnBaoCaoChiTiet.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnBaoCaoChiTiet.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnBaoCaoChiTiet.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnBaoCaoChiTiet.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnBaoCaoChiTiet.Location = new System.Drawing.Point(14, 500);
            this.btnBaoCaoChiTiet.Name = "btnBaoCaoChiTiet";
            this.btnBaoCaoChiTiet.Size = new System.Drawing.Size(252, 50);
            this.btnBaoCaoChiTiet.TabIndex = 1;
            this.btnBaoCaoChiTiet.Text = "BÁO CÁO CHI TIẾT";
            this.btnBaoCaoChiTiet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoChiTiet.TextOffset = new System.Drawing.Point(20, 0);
            this.btnBaoCaoChiTiet.Click += new System.EventHandler(this.btnBaoCaoChiTiet_Click);

            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Animated = true;
            this.btnBaoCao.BorderRadius = 12;
            this.btnBaoCao.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnBaoCao.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnBaoCao.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnBaoCao.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnBaoCao.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnBaoCao.Location = new System.Drawing.Point(14, 450);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(252, 50);
            this.btnBaoCao.TabIndex = 2;
            this.btnBaoCao.Text = "BÁO CÁO TỔNG HỢP";
            this.btnBaoCao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCao.TextOffset = new System.Drawing.Point(20, 0);
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);

            // 
            // btnDuyetChi
            // 
            this.btnDuyetChi.Animated = true;
            this.btnDuyetChi.BorderRadius = 12;
            this.btnDuyetChi.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDuyetChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDuyetChi.FillColor = System.Drawing.Color.Transparent;
            this.btnDuyetChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDuyetChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnDuyetChi.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnDuyetChi.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnDuyetChi.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnDuyetChi.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnDuyetChi.Location = new System.Drawing.Point(14, 400);
            this.btnDuyetChi.Name = "btnDuyetChi";
            this.btnDuyetChi.Size = new System.Drawing.Size(252, 50);
            this.btnDuyetChi.TabIndex = 12;
            this.btnDuyetChi.Text = "LÃNH ĐẠO DUYỆT CHI";
            this.btnDuyetChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDuyetChi.TextOffset = new System.Drawing.Point(20, 0);
            this.btnDuyetChi.Click += new System.EventHandler(this.btnDuyetChi_Click);

            // 
            // btnPhieuChi
            // 
            this.btnPhieuChi.Animated = true;
            this.btnPhieuChi.BorderRadius = 12;
            this.btnPhieuChi.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnPhieuChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieuChi.FillColor = System.Drawing.Color.Transparent;
            this.btnPhieuChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPhieuChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnPhieuChi.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPhieuChi.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnPhieuChi.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnPhieuChi.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnPhieuChi.Location = new System.Drawing.Point(14, 350);
            this.btnPhieuChi.Name = "btnPhieuChi";
            this.btnPhieuChi.Size = new System.Drawing.Size(252, 50);
            this.btnPhieuChi.TabIndex = 3;
            this.btnPhieuChi.Text = "LẬP PHIẾU CHI";
            this.btnPhieuChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhieuChi.TextOffset = new System.Drawing.Point(20, 0);
            this.btnPhieuChi.Click += new System.EventHandler(this.btnPhieuChi_Click);

            // 
            // btnNhapNhuanBut
            // 
            this.btnNhapNhuanBut.Animated = true;
            this.btnNhapNhuanBut.BorderRadius = 12;
            this.btnNhapNhuanBut.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNhapNhuanBut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapNhuanBut.FillColor = System.Drawing.Color.Transparent;
            this.btnNhapNhuanBut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNhapNhuanBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnNhapNhuanBut.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnNhapNhuanBut.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnNhapNhuanBut.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnNhapNhuanBut.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnNhapNhuanBut.Location = new System.Drawing.Point(14, 300);
            this.btnNhapNhuanBut.Name = "btnNhapNhuanBut";
            this.btnNhapNhuanBut.Size = new System.Drawing.Size(252, 50);
            this.btnNhapNhuanBut.TabIndex = 4;
            this.btnNhapNhuanBut.Text = "QUẢN LÝ NHUẬN BÚT";
            this.btnNhapNhuanBut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhapNhuanBut.TextOffset = new System.Drawing.Point(20, 0);
            this.btnNhapNhuanBut.Click += new System.EventHandler(this.btnNhapNhuanBut_Click);

            // 
            // btnSoBao
            // 
            this.btnSoBao.Animated = true;
            this.btnSoBao.BorderRadius = 12;
            this.btnSoBao.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSoBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSoBao.FillColor = System.Drawing.Color.Transparent;
            this.btnSoBao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSoBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnSoBao.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnSoBao.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnSoBao.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnSoBao.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnSoBao.Location = new System.Drawing.Point(14, 250);
            this.btnSoBao.Name = "btnSoBao";
            this.btnSoBao.Size = new System.Drawing.Size(252, 50);
            this.btnSoBao.TabIndex = 5;
            this.btnSoBao.Text = "QUẢN LÝ SỐ BÁO";
            this.btnSoBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSoBao.TextOffset = new System.Drawing.Point(20, 0);
            this.btnSoBao.Click += new System.EventHandler(this.btnSoBao_Click);

            // 
            // btnButDanh
            // 
            this.btnButDanh.Animated = true;
            this.btnButDanh.BorderRadius = 12;
            this.btnButDanh.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnButDanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnButDanh.FillColor = System.Drawing.Color.Transparent;
            this.btnButDanh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnButDanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnButDanh.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnButDanh.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnButDanh.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnButDanh.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnButDanh.Location = new System.Drawing.Point(14, 200);
            this.btnButDanh.Name = "btnButDanh";
            this.btnButDanh.Size = new System.Drawing.Size(252, 50);
            this.btnButDanh.TabIndex = 11;
            this.btnButDanh.Text = "QUẢN LÝ BÚT DANH";
            this.btnButDanh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnButDanh.TextOffset = new System.Drawing.Point(20, 0);
            this.btnButDanh.Click += new System.EventHandler(this.btnButDanh_Click);

            // 
            // btnTacGia
            // 
            this.btnTacGia.Animated = true;
            this.btnTacGia.BorderRadius = 12;
            this.btnTacGia.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTacGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTacGia.FillColor = System.Drawing.Color.Transparent;
            this.btnTacGia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTacGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTacGia.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTacGia.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnTacGia.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnTacGia.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnTacGia.Location = new System.Drawing.Point(14, 150);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(252, 50);
            this.btnTacGia.TabIndex = 6;
            this.btnTacGia.Text = "QUẢN LÝ TÁC GIẢ";
            this.btnTacGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTacGia.TextOffset = new System.Drawing.Point(20, 0);
            this.btnTacGia.Click += new System.EventHandler(this.btnTacGia_Click);

            // 
            // btnTongQuan
            // 
            this.btnTongQuan.Animated = true;
            this.btnTongQuan.BorderRadius = 12;
            this.btnTongQuan.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTongQuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTongQuan.FillColor = System.Drawing.Color.Transparent;
            this.btnTongQuan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTongQuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTongQuan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTongQuan.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnTongQuan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnTongQuan.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnTongQuan.Location = new System.Drawing.Point(14, 100);
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Size = new System.Drawing.Size(252, 50);
            this.btnTongQuan.TabIndex = 7;
            this.btnTongQuan.Text = "DASHBOARD HỆ THỐNG";
            this.btnTongQuan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTongQuan.TextOffset = new System.Drawing.Point(20, 0);
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);

            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogo.Controls.Add(this.lblTitle);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(12, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(256, 100);
            this.pnlLogo.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(256, 100);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NEWSPAY";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);

            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Animated = true;
            this.btnTaiKhoan.BorderRadius = 12;
            this.btnTaiKhoan.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTaiKhoan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.btnTaiKhoan.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(100)))), ((int)(((byte)(242)))));
            this.btnTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTaiKhoan.FillColor = System.Drawing.Color.Transparent;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnTaiKhoan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTaiKhoan.Location = new System.Drawing.Point(12, 635);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(256, 50);
            this.btnTaiKhoan.TabIndex = 9;
            this.btnTaiKhoan.Text = "QUẢN LÝ TÀI KHOẢN";
            this.btnTaiKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaiKhoan.TextOffset = new System.Drawing.Point(20, 0);
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);

            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Animated = true;
            this.btnDangXuat.BorderRadius = 12;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDangXuat.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnDangXuat.Location = new System.Drawing.Point(12, 685);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(256, 50);
            this.btnDangXuat.TabIndex = 10;
            this.btnDangXuat.Text = "ĐĂNG XUẤT";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);

            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(280, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(920, 750);
            this.pnlMain.TabIndex = 1;

            // HIỆU ỨNG ĐỔ BÓNG MAIN PANEL: Đã lược bỏ dòng BlurRadius gây lỗi
            this.pnlMain.ShadowDecoration.Enabled = true;
            this.pnlMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlMain.ShadowDecoration.Depth = 10;
            this.pnlMain.ShadowDecoration.Parent = this.pnlMain;

            // 
            // FrmTrangChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
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
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
        private Guna.UI2.WinForms.Guna2Panel pnlLogo;
        private Guna.UI2.WinForms.Guna2Button btnTongQuan;
        private Guna.UI2.WinForms.Guna2Button btnSoBao;
        private Guna.UI2.WinForms.Guna2Button btnTacGia;
        private Guna.UI2.WinForms.Guna2Button btnButDanh;
        private Guna.UI2.WinForms.Guna2Button btnTaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btnNhapNhuanBut;
        private Guna.UI2.WinForms.Guna2Button btnPhieuChi;
        private Guna.UI2.WinForms.Guna2Button btnDuyetChi;
        private Guna.UI2.WinForms.Guna2Button btnBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnBaoCaoChiTiet;
        private Guna.UI2.WinForms.Guna2Button btnBaoCaoCongNo;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
    }
}