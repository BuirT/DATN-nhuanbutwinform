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
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoCongNo = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoChiTiet = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnDuyetChi = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhieuChi = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhapNhuanBut = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubLoaiBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubSoBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuanLyBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnButDanh = new Guna.UI2.WinForms.Guna2Button();
            this.btnTacGia = new Guna.UI2.WinForms.Guna2Button();
            this.btnTongQuan = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlMenu (bỏ shadow, dùng viền phải)
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlMenu.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.FillColor = System.Drawing.Color.White;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(12, 0, 12, 20);
            this.pnlMenu.Size = new System.Drawing.Size(280, 750);
            this.pnlMenu.TabIndex = 0;

            // Sắp xếp thứ tự controls để "Quản lý tài khoản" ở trên "Đăng xuất"
            // Thêm btnDangXuat trước, btnTaiKhoan sau (do dock bottom, control thêm sau sẽ nằm trên)
            this.pnlMenu.Controls.Add(this.btnTaiKhoan);
            this.pnlMenu.Controls.Add(this.btnDangXuat);
            this.pnlMenu.Controls.Add(this.btnBaoCaoCongNo);
            this.pnlMenu.Controls.Add(this.btnBaoCaoChiTiet);
            this.pnlMenu.Controls.Add(this.btnBaoCao);
            this.pnlMenu.Controls.Add(this.btnDuyetChi);
            this.pnlMenu.Controls.Add(this.btnPhieuChi);
            this.pnlMenu.Controls.Add(this.btnNhapNhuanBut);
            this.pnlMenu.Controls.Add(this.btnSubLoaiBao);
            this.pnlMenu.Controls.Add(this.btnSubSoBao);
            this.pnlMenu.Controls.Add(this.btnQuanLyBao);
            this.pnlMenu.Controls.Add(this.btnButDanh);
            this.pnlMenu.Controls.Add(this.btnTacGia);
            this.pnlMenu.Controls.Add(this.btnTongQuan);
            this.pnlMenu.Controls.Add(this.pnlLogo);

            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BorderRadius = 8;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDangXuat.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnDangXuat.Location = new System.Drawing.Point(12, 680);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(0);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(256, 50);
            this.btnDangXuat.TabIndex = 15;
            this.btnDangXuat.Text = "ĐĂNG XUẤT";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);

            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BorderRadius = 8;
            this.btnTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTaiKhoan.FillColor = System.Drawing.Color.Transparent;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnTaiKhoan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTaiKhoan.Location = new System.Drawing.Point(12, 630);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(0);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(256, 50);
            this.btnTaiKhoan.TabIndex = 14;
            this.btnTaiKhoan.Text = "QUẢN LÝ TÀI KHOẢN";
            this.btnTaiKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaiKhoan.TextOffset = new System.Drawing.Point(20, 0);
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);

            // Các nút còn lại giữ nguyên (không thay đổi)
            this.btnBaoCaoCongNo.BorderRadius = 8;
            this.btnBaoCaoCongNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCaoCongNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoCongNo.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCaoCongNo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoCongNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnBaoCaoCongNo.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnBaoCaoCongNo.Location = new System.Drawing.Point(12, 480);
            this.btnBaoCaoCongNo.Margin = new System.Windows.Forms.Padding(0);
            this.btnBaoCaoCongNo.Name = "btnBaoCaoCongNo";
            this.btnBaoCaoCongNo.Size = new System.Drawing.Size(256, 50);
            this.btnBaoCaoCongNo.TabIndex = 13;
            this.btnBaoCaoCongNo.Text = "BÁO CÁO CÔNG NỢ";
            this.btnBaoCaoCongNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoCongNo.TextOffset = new System.Drawing.Point(20, 0);
            this.btnBaoCaoCongNo.Click += new System.EventHandler(this.btnBaoCaoCongNo_Click);

            this.btnBaoCaoChiTiet.BorderRadius = 8;
            this.btnBaoCaoChiTiet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCaoChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoChiTiet.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCaoChiTiet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnBaoCaoChiTiet.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnBaoCaoChiTiet.Location = new System.Drawing.Point(12, 430);
            this.btnBaoCaoChiTiet.Margin = new System.Windows.Forms.Padding(0);
            this.btnBaoCaoChiTiet.Name = "btnBaoCaoChiTiet";
            this.btnBaoCaoChiTiet.Size = new System.Drawing.Size(256, 50);
            this.btnBaoCaoChiTiet.TabIndex = 12;
            this.btnBaoCaoChiTiet.Text = "BÁO CÁO CHI TIẾT";
            this.btnBaoCaoChiTiet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoChiTiet.TextOffset = new System.Drawing.Point(20, 0);
            this.btnBaoCaoChiTiet.Click += new System.EventHandler(this.btnBaoCaoChiTiet_Click);

            this.btnBaoCao.BorderRadius = 8;
            this.btnBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnBaoCao.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnBaoCao.Location = new System.Drawing.Point(12, 380);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(0);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(256, 50);
            this.btnBaoCao.TabIndex = 11;
            this.btnBaoCao.Text = "BÁO CÁO TỔNG HỢP";
            this.btnBaoCao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCao.TextOffset = new System.Drawing.Point(20, 0);
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);

            this.btnDuyetChi.BorderRadius = 8;
            this.btnDuyetChi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuyetChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDuyetChi.FillColor = System.Drawing.Color.Transparent;
            this.btnDuyetChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDuyetChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnDuyetChi.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnDuyetChi.Location = new System.Drawing.Point(12, 330);
            this.btnDuyetChi.Margin = new System.Windows.Forms.Padding(0);
            this.btnDuyetChi.Name = "btnDuyetChi";
            this.btnDuyetChi.Size = new System.Drawing.Size(256, 50);
            this.btnDuyetChi.TabIndex = 10;
            this.btnDuyetChi.Text = "LÃNH ĐẠO DUYỆT CHI";
            this.btnDuyetChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDuyetChi.TextOffset = new System.Drawing.Point(20, 0);
            this.btnDuyetChi.Click += new System.EventHandler(this.btnDuyetChi_Click);

            this.btnPhieuChi.BorderRadius = 8;
            this.btnPhieuChi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhieuChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieuChi.FillColor = System.Drawing.Color.Transparent;
            this.btnPhieuChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPhieuChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnPhieuChi.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnPhieuChi.Location = new System.Drawing.Point(12, 280);
            this.btnPhieuChi.Margin = new System.Windows.Forms.Padding(0);
            this.btnPhieuChi.Name = "btnPhieuChi";
            this.btnPhieuChi.Size = new System.Drawing.Size(256, 50);
            this.btnPhieuChi.TabIndex = 9;
            this.btnPhieuChi.Text = "LẬP PHIẾU CHI";
            this.btnPhieuChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhieuChi.TextOffset = new System.Drawing.Point(20, 0);
            this.btnPhieuChi.Click += new System.EventHandler(this.btnPhieuChi_Click);

            this.btnNhapNhuanBut.BorderRadius = 8;
            this.btnNhapNhuanBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhapNhuanBut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapNhuanBut.FillColor = System.Drawing.Color.Transparent;
            this.btnNhapNhuanBut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNhapNhuanBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnNhapNhuanBut.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnNhapNhuanBut.Location = new System.Drawing.Point(12, 230);
            this.btnNhapNhuanBut.Margin = new System.Windows.Forms.Padding(0);
            this.btnNhapNhuanBut.Name = "btnNhapNhuanBut";
            this.btnNhapNhuanBut.Size = new System.Drawing.Size(256, 50);
            this.btnNhapNhuanBut.TabIndex = 8;
            this.btnNhapNhuanBut.Text = "QUẢN LÝ NHUẬN BÚT";
            this.btnNhapNhuanBut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhapNhuanBut.TextOffset = new System.Drawing.Point(20, 0);
            this.btnNhapNhuanBut.Click += new System.EventHandler(this.btnNhapNhuanBut_Click);

            this.btnSubLoaiBao.BorderRadius = 6;
            this.btnSubLoaiBao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubLoaiBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubLoaiBao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubLoaiBao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubLoaiBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubLoaiBao.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnSubLoaiBao.Location = new System.Drawing.Point(12, 190);
            this.btnSubLoaiBao.Margin = new System.Windows.Forms.Padding(0);
            this.btnSubLoaiBao.Name = "btnSubLoaiBao";
            this.btnSubLoaiBao.Size = new System.Drawing.Size(256, 40);
            this.btnSubLoaiBao.TabIndex = 7;
            this.btnSubLoaiBao.Text = "• Loại báo";
            this.btnSubLoaiBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubLoaiBao.TextOffset = new System.Drawing.Point(40, 0);
            this.btnSubLoaiBao.Visible = false;
            this.btnSubLoaiBao.Click += new System.EventHandler(this.btnSubLoaiBao_Click);

            this.btnSubSoBao.BorderRadius = 6;
            this.btnSubSoBao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubSoBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubSoBao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnSubSoBao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubSoBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSubSoBao.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnSubSoBao.Location = new System.Drawing.Point(12, 150);
            this.btnSubSoBao.Margin = new System.Windows.Forms.Padding(0);
            this.btnSubSoBao.Name = "btnSubSoBao";
            this.btnSubSoBao.Size = new System.Drawing.Size(256, 40);
            this.btnSubSoBao.TabIndex = 6;
            this.btnSubSoBao.Text = "• Số báo";
            this.btnSubSoBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSubSoBao.TextOffset = new System.Drawing.Point(40, 0);
            this.btnSubSoBao.Visible = false;
            this.btnSubSoBao.Click += new System.EventHandler(this.btnSubSoBao_Click);

            this.btnQuanLyBao.BorderRadius = 8;
            this.btnQuanLyBao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyBao.FillColor = System.Drawing.Color.Transparent;
            this.btnQuanLyBao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuanLyBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnQuanLyBao.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnQuanLyBao.Location = new System.Drawing.Point(12, 100);
            this.btnQuanLyBao.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuanLyBao.Name = "btnQuanLyBao";
            this.btnQuanLyBao.Size = new System.Drawing.Size(256, 50);
            this.btnQuanLyBao.TabIndex = 5;
            this.btnQuanLyBao.Text = "QUẢN LÝ BÁO  ▼";
            this.btnQuanLyBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuanLyBao.TextOffset = new System.Drawing.Point(20, 0);
            this.btnQuanLyBao.Click += new System.EventHandler(this.btnQuanLyBao_Click);

            this.btnButDanh.BorderRadius = 8;
            this.btnButDanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnButDanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnButDanh.FillColor = System.Drawing.Color.Transparent;
            this.btnButDanh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnButDanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnButDanh.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnButDanh.Location = new System.Drawing.Point(12, 50);
            this.btnButDanh.Margin = new System.Windows.Forms.Padding(0);
            this.btnButDanh.Name = "btnButDanh";
            this.btnButDanh.Size = new System.Drawing.Size(256, 50);
            this.btnButDanh.TabIndex = 4;
            this.btnButDanh.Text = "QUẢN LÝ BÚT DANH";
            this.btnButDanh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnButDanh.TextOffset = new System.Drawing.Point(20, 0);
            this.btnButDanh.Click += new System.EventHandler(this.btnButDanh_Click);

            this.btnTacGia.BorderRadius = 8;
            this.btnTacGia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTacGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTacGia.FillColor = System.Drawing.Color.Transparent;
            this.btnTacGia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTacGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnTacGia.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTacGia.Location = new System.Drawing.Point(12, 0);
            this.btnTacGia.Margin = new System.Windows.Forms.Padding(0);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(256, 50);
            this.btnTacGia.TabIndex = 3;
            this.btnTacGia.Text = "QUẢN LÝ TÁC GIẢ";
            this.btnTacGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTacGia.TextOffset = new System.Drawing.Point(20, 0);
            this.btnTacGia.Click += new System.EventHandler(this.btnTacGia_Click);

            this.btnTongQuan.BorderRadius = 8;
            this.btnTongQuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTongQuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTongQuan.FillColor = System.Drawing.Color.Transparent;
            this.btnTongQuan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTongQuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnTongQuan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTongQuan.Location = new System.Drawing.Point(12, -50);
            this.btnTongQuan.Margin = new System.Windows.Forms.Padding(0);
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Size = new System.Drawing.Size(256, 50);
            this.btnTongQuan.TabIndex = 2;
            this.btnTongQuan.Text = "DASHBOARD HỆ THỐNG";
            this.btnTongQuan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTongQuan.TextOffset = new System.Drawing.Point(20, 0);
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);

            // pnlLogo
            this.pnlLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogo.Controls.Add(this.lblTitle);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.FillColor = System.Drawing.Color.White;
            this.pnlLogo.Location = new System.Drawing.Point(12, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(256, 100);
            this.pnlLogo.TabIndex = 1;

            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(256, 100);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NEWSPAY";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlMain (bỏ shadow)
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(280, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(920, 750);
            this.pnlMain.TabIndex = 1;

            // FrmTrangChinh
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
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
            this.pnlMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
        private Guna.UI2.WinForms.Guna2Panel pnlLogo;
        private Guna.UI2.WinForms.Guna2Button btnTongQuan;
        private Guna.UI2.WinForms.Guna2Button btnQuanLyBao;
        private Guna.UI2.WinForms.Guna2Button btnSubSoBao;
        private Guna.UI2.WinForms.Guna2Button btnSubLoaiBao;
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