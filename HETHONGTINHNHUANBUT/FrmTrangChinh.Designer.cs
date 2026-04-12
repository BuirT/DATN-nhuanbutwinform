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
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoCongNo = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCaoChiTiet = new Guna.UI2.WinForms.Guna2Button();
            this.btnBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhieuChi = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhapNhuanBut = new Guna.UI2.WinForms.Guna2Button();
            this.btnTacGia = new Guna.UI2.WinForms.Guna2Button();
            this.btnSoBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnTongQuan = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu (Sidebar bên trái)
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.pnlMenu.Controls.Add(this.btnBaoCaoCongNo);
            this.pnlMenu.Controls.Add(this.btnBaoCaoChiTiet);
            this.pnlMenu.Controls.Add(this.btnBaoCao);
            this.pnlMenu.Controls.Add(this.btnPhieuChi);
            this.pnlMenu.Controls.Add(this.btnNhapNhuanBut);
            this.pnlMenu.Controls.Add(this.btnTacGia);
            this.pnlMenu.Controls.Add(this.btnSoBao);
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
            // btnDangXuat (Màu đỏ đặc trưng ở đáy)
            // 
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDangXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 690);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(280, 60);
            this.btnDangXuat.TabIndex = 10;
            this.btnDangXuat.Text = "ĐĂNG XUẤT";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnTaiKhoan (PHẦN RIÊNG: Nằm trên Đăng xuất)
            // 
            this.btnTaiKhoan.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTaiKhoan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTaiKhoan.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTaiKhoan.FillColor = System.Drawing.Color.Transparent;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTaiKhoan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(88)))));
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 630);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(280, 60);
            this.btnTaiKhoan.TabIndex = 9;
            this.btnTaiKhoan.Text = "QUẢN LÝ TÀI KHOẢN";
            this.btnTaiKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaiKhoan.TextOffset = new System.Drawing.Point(30, 0);
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // --- NHÓM NÚT NGHIỆP VỤ (ĐỒNG NHẤT 100%, DOCK=TOP) ---
            // 
            // btnBaoCaoCongNo
            this.btnBaoCaoCongNo.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBaoCaoCongNo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnBaoCaoCongNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoCongNo.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCaoCongNo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoCongNo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaoCaoCongNo.Location = new System.Drawing.Point(0, 450);
            this.btnBaoCaoCongNo.Name = "btnBaoCaoCongNo";
            this.btnBaoCaoCongNo.Size = new System.Drawing.Size(280, 50);
            this.btnBaoCaoCongNo.Text = "BÁO CÁO CÔNG NỢ";
            this.btnBaoCaoCongNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoCongNo.TextOffset = new System.Drawing.Point(30, 0);
            this.btnBaoCaoCongNo.Click += new System.EventHandler(this.btnBaoCaoCongNo_Click);
            // 
            // btnBaoCaoChiTiet
            this.btnBaoCaoChiTiet.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBaoCaoChiTiet.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnBaoCaoChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCaoChiTiet.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCaoChiTiet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCaoChiTiet.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaoCaoChiTiet.Location = new System.Drawing.Point(0, 400);
            this.btnBaoCaoChiTiet.Name = "btnBaoCaoChiTiet";
            this.btnBaoCaoChiTiet.Size = new System.Drawing.Size(280, 50);
            this.btnBaoCaoChiTiet.Text = "BÁO CÁO CHI TIẾT";
            this.btnBaoCaoChiTiet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCaoChiTiet.TextOffset = new System.Drawing.Point(30, 0);
            this.btnBaoCaoChiTiet.Click += new System.EventHandler(this.btnBaoCaoChiTiet_Click);
            // 
            // btnBaoCao
            this.btnBaoCao.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBaoCao.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBaoCao.FillColor = System.Drawing.Color.Transparent;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnBaoCao.Location = new System.Drawing.Point(0, 350);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(280, 50);
            this.btnBaoCao.Text = "BÁO CÁO TỔNG HỢP";
            this.btnBaoCao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBaoCao.TextOffset = new System.Drawing.Point(30, 0);
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnPhieuChi
            this.btnPhieuChi.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnPhieuChi.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnPhieuChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhieuChi.FillColor = System.Drawing.Color.Transparent;
            this.btnPhieuChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPhieuChi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPhieuChi.Location = new System.Drawing.Point(0, 300);
            this.btnPhieuChi.Name = "btnPhieuChi";
            this.btnPhieuChi.Size = new System.Drawing.Size(280, 50);
            this.btnPhieuChi.Text = "LẬP PHIẾU CHI";
            this.btnPhieuChi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhieuChi.TextOffset = new System.Drawing.Point(30, 0);
            this.btnPhieuChi.Click += new System.EventHandler(this.btnPhieuChi_Click);
            // 
            // btnNhapNhuanBut
            this.btnNhapNhuanBut.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNhapNhuanBut.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnNhapNhuanBut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNhapNhuanBut.FillColor = System.Drawing.Color.Transparent;
            this.btnNhapNhuanBut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNhapNhuanBut.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnNhapNhuanBut.Location = new System.Drawing.Point(0, 250);
            this.btnNhapNhuanBut.Name = "btnNhapNhuanBut";
            this.btnNhapNhuanBut.Size = new System.Drawing.Size(280, 50);
            this.btnNhapNhuanBut.Text = "NHẬP NHUẬN BÚT";
            this.btnNhapNhuanBut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhapNhuanBut.TextOffset = new System.Drawing.Point(30, 0);
            this.btnNhapNhuanBut.Click += new System.EventHandler(this.btnNhapNhuanBut_Click);
            // 
            // btnTacGia
            this.btnTacGia.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTacGia.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTacGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTacGia.FillColor = System.Drawing.Color.Transparent;
            this.btnTacGia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTacGia.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTacGia.Location = new System.Drawing.Point(0, 200);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(280, 50);
            this.btnTacGia.Text = "QUẢN LÝ TÁC GIẢ";
            this.btnTacGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTacGia.TextOffset = new System.Drawing.Point(30, 0);
            this.btnTacGia.Click += new System.EventHandler(this.btnTacGia_Click);
            // 
            // btnSoBao
            this.btnSoBao.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSoBao.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSoBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSoBao.FillColor = System.Drawing.Color.Transparent;
            this.btnSoBao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSoBao.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSoBao.Location = new System.Drawing.Point(0, 150);
            this.btnSoBao.Name = "btnSoBao";
            this.btnSoBao.Size = new System.Drawing.Size(280, 50);
            this.btnSoBao.Text = "QUẢN LÝ SỐ BÁO";
            this.btnSoBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSoBao.TextOffset = new System.Drawing.Point(30, 0);
            this.btnSoBao.Click += new System.EventHandler(this.btnSoBao_Click);
            // 
            // btnTongQuan
            // 
            this.btnTongQuan.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTongQuan.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTongQuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTongQuan.FillColor = System.Drawing.Color.Transparent;
            this.btnTongQuan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTongQuan.ForeColor = System.Drawing.Color.White;
            this.btnTongQuan.Location = new System.Drawing.Point(0, 100);
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Size = new System.Drawing.Size(280, 50);
            this.btnTongQuan.Text = "DASHBOARD HỆ THỐNG";
            this.btnTongQuan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTongQuan.TextOffset = new System.Drawing.Point(30, 0);
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(55)))));
            this.pnlLogo.Controls.Add(this.lblTitle);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(280, 100);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 100);
            this.lblTitle.Text = "NHUẬN BÚT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain (Vùng nội dung tự co giãn)
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(280, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(920, 750);
            this.pnlMain.TabIndex = 1;
            // 
            // FrmTrangChinh (TỔNG THỂ FORM)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmTrangChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Nhuận bút";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized; // BUNG FULL MÀN HÌNH
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
        private Guna.UI2.WinForms.Guna2Button btnTaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btnNhapNhuanBut;
        private Guna.UI2.WinForms.Guna2Button btnPhieuChi;
        private Guna.UI2.WinForms.Guna2Button btnBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnBaoCaoChiTiet;
        private Guna.UI2.WinForms.Guna2Button btnBaoCaoCongNo;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
    }
}