namespace HETHONGTINHNHUANBUT
{
    partial class FrmTaiKhoan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMK = new System.Windows.Forms.Label();
            this.txtMatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblHT = new System.Windows.Forms.Label();
            this.txtHoTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblQ = new System.Windows.Forms.Label();
            this.cboQuyen = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chkHoatDong = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.dgvTaiKhoan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblTen);
            this.pnlTop.Controls.Add(this.txtTenDangNhap);
            this.pnlTop.Controls.Add(this.lblMK);
            this.pnlTop.Controls.Add(this.txtMatKhau);
            this.pnlTop.Controls.Add(this.lblHT);
            this.pnlTop.Controls.Add(this.txtHoTen);
            this.pnlTop.Controls.Add(this.lblQ);
            this.pnlTop.Controls.Add(this.cboQuyen);
            this.pnlTop.Controls.Add(this.chkHoatDong);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnXoa);
            this.pnlTop.Controls.Add(this.btnLamMoi);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 260);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "HỒ SƠ TÀI KHOẢN";
            // 
            // Căn chỉnh các ô nhập liệu theo phong cách FrmTacGia
            // 
            this.lblTen.ForeColor = System.Drawing.Color.Gray;
            this.lblTen.Location = new System.Drawing.Point(250, 50);
            this.lblTen.Text = "Tên đăng nhập";
            this.txtTenDangNhap.BorderRadius = 5;
            this.txtTenDangNhap.Location = new System.Drawing.Point(250, 70);
            this.txtTenDangNhap.Size = new System.Drawing.Size(200, 36);
            // 
            this.lblMK.ForeColor = System.Drawing.Color.Gray;
            this.lblMK.Location = new System.Drawing.Point(470, 50);
            this.lblMK.Text = "Mật khẩu";
            this.txtMatKhau.BorderRadius = 5;
            this.txtMatKhau.Location = new System.Drawing.Point(470, 70);
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Size = new System.Drawing.Size(200, 36);
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            this.chkHoatDong.AutoSize = true;
            this.chkHoatDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkHoatDong.Location = new System.Drawing.Point(690, 75);
            this.chkHoatDong.Text = "Đang hoạt động";
            this.chkHoatDong.Checked = true;
            // 
            this.lblHT.ForeColor = System.Drawing.Color.Gray;
            this.lblHT.Location = new System.Drawing.Point(250, 115);
            this.lblHT.Text = "Họ và tên";
            this.txtHoTen.BorderRadius = 5;
            this.txtHoTen.Location = new System.Drawing.Point(250, 135);
            this.txtHoTen.Size = new System.Drawing.Size(200, 36);
            // 
            this.lblQ.ForeColor = System.Drawing.Color.Gray;
            this.lblQ.Location = new System.Drawing.Point(470, 115);
            this.lblQ.Text = "Vai trò (Quyền)";
            this.cboQuyen.BorderRadius = 5;
            this.cboQuyen.Location = new System.Drawing.Point(470, 135);
            this.cboQuyen.Size = new System.Drawing.Size(200, 36);
            // 
            // --- CÁC NÚT BẤM (ĐÃ THIẾT KẾ LẠI NÚT XÓA) ---
            // 
            this.btnThem.BorderRadius = 5;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(250, 195);
            this.btnThem.Size = new System.Drawing.Size(120, 42);
            this.btnThem.Text = "THÊM MỚI";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            this.btnSua.BorderRadius = 5;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(385, 195);
            this.btnSua.Size = new System.Drawing.Size(120, 42);
            this.btnSua.Text = "CẬP NHẬT";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // Nút Xóa bây giờ là màu Đỏ Solid, Chữ trắng, không bị cắt chữ
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(520, 195);
            this.btnXoa.Size = new System.Drawing.Size(140, 42);
            this.btnXoa.Text = "XÓA TÀI KHOẢN";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            this.btnLamMoi.BorderRadius = 5;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLamMoi.Location = new System.Drawing.Point(675, 195);
            this.btnLamMoi.Size = new System.Drawing.Size(120, 42);
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Controls.Add(this.lblDataTitle);
            this.pnlBottom.Controls.Add(this.txtTimKiem);
            this.pnlBottom.Controls.Add(this.dgvTaiKhoan);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 260);
            this.pnlBottom.Size = new System.Drawing.Size(1200, 490);
            // 
            // lblDataTitle
            // 
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.Location = new System.Drawing.Point(20, 15);
            this.lblDataTitle.Text = "DANH SÁCH TÀI KHOẢN";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderRadius = 5;
            this.txtTimKiem.Location = new System.Drawing.Point(880, 15);
            this.txtTimKiem.PlaceholderText = "🔍 Tìm kiếm tài khoản...";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 36);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // dgvTaiKhoan (QUAN TRỌNG: Sửa lỗi Grid trắng bên phải)
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Tự động lấp đầy width
            this.dgvTaiKhoan.ColumnHeadersHeight = 45;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(20, 65);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(1160, 400);
            this.dgvTaiKhoan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59))))); // Header xanh đen
            this.dgvTaiKhoan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiKhoan_CellClick);
            // 
            // FrmTaiKhoan
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Tài Khoản";
            this.Load += new System.EventHandler(this.FrmTaiKhoan_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTen;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMK;
        private Guna.UI2.WinForms.Guna2TextBox txtMatKhau;
        private System.Windows.Forms.Label lblHT;
        private Guna.UI2.WinForms.Guna2TextBox txtHoTen;
        private System.Windows.Forms.Label lblQ;
        private Guna.UI2.WinForms.Guna2ComboBox cboQuyen;
        private Guna.UI2.WinForms.Guna2CheckBox chkHoatDong;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private System.Windows.Forms.Label lblDataTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTaiKhoan;
    }
}