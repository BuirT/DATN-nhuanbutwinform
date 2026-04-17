namespace HETHONGTINHNHUANBUT
{
    partial class FrmTacGia
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
            this.pnlLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnChonAnh = new Guna.UI2.WinForms.Guna2Button();

            // Các Label và TextBox
            this.lblMaHT = new System.Windows.Forms.Label();
            this.txtMaHT = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.txtMaThe = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblButDanh = new System.Windows.Forms.Label();
            this.txtButDanh = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblPhanLoai = new System.Windows.Forms.Label();
            this.cboPhanLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new Guna.UI2.WinForms.Guna2TextBox();

            // Cụm PDF
            this.btnChonPDF = new Guna.UI2.WinForms.Guna2Button();
            this.btnXemPDF = new Guna.UI2.WinForms.Guna2Button();
            this.lblFilePDF = new System.Windows.Forms.Label();

            // Nút chức năng
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();

            // Lưới dữ liệu bên phải
            this.pnlRight = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvTacGia = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblDataTitle = new System.Windows.Forms.Label();

            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacGia)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlLeft (Rộng 450px để chứa đủ 2 cột)
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.picAvatar);
            this.pnlLeft.Controls.Add(this.btnChonAnh);
            this.pnlLeft.Controls.Add(this.lblMaHT); this.pnlLeft.Controls.Add(this.txtMaHT);
            this.pnlLeft.Controls.Add(this.lblMaThe); this.pnlLeft.Controls.Add(this.txtMaThe);
            this.pnlLeft.Controls.Add(this.lblHoTen); this.pnlLeft.Controls.Add(this.txtHoTen);
            this.pnlLeft.Controls.Add(this.lblButDanh); this.pnlLeft.Controls.Add(this.txtButDanh);
            this.pnlLeft.Controls.Add(this.lblDienThoai); this.pnlLeft.Controls.Add(this.txtDienThoai);
            this.pnlLeft.Controls.Add(this.lblEmail); this.pnlLeft.Controls.Add(this.txtEmail);
            this.pnlLeft.Controls.Add(this.lblNgaySinh); this.pnlLeft.Controls.Add(this.dtpNgaySinh);
            this.pnlLeft.Controls.Add(this.lblPhanLoai); this.pnlLeft.Controls.Add(this.cboPhanLoai);
            this.pnlLeft.Controls.Add(this.lblDiaChi); this.pnlLeft.Controls.Add(this.txtDiaChi);
            this.pnlLeft.Controls.Add(this.btnChonPDF); this.pnlLeft.Controls.Add(this.btnXemPDF); this.pnlLeft.Controls.Add(this.lblFilePDF);
            this.pnlLeft.Controls.Add(this.btnThem); this.pnlLeft.Controls.Add(this.btnSua);
            this.pnlLeft.Controls.Add(this.btnXoa); this.pnlLeft.Controls.Add(this.btnLamMoi);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(450, 750);

            // 
            // picAvatar
            // 
            this.picAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(165, 20);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(120, 120);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;

            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BorderRadius = 15;
            this.btnChonAnh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChonAnh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnChonAnh.Location = new System.Drawing.Point(175, 150);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(100, 30);
            this.btnChonAnh.Text = "Đổi Ảnh";
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            // HÀNG 1 (Y=200)
            this.lblMaHT.Location = new System.Drawing.Point(20, 190); this.lblMaHT.Text = "Mã hệ thống"; this.lblMaHT.ForeColor = System.Drawing.Color.Gray;
            this.txtMaHT.Location = new System.Drawing.Point(20, 210); this.txtMaHT.Size = new System.Drawing.Size(195, 36); this.txtMaHT.BorderRadius = 5;

            this.lblMaThe.Location = new System.Drawing.Point(235, 190); this.lblMaThe.Text = "Mã TG/Thẻ"; this.lblMaThe.ForeColor = System.Drawing.Color.Gray;
            this.txtMaThe.Location = new System.Drawing.Point(235, 210); this.txtMaThe.Size = new System.Drawing.Size(195, 36); this.txtMaThe.BorderRadius = 5;

            // HÀNG 2 (Y=260)
            this.lblHoTen.Location = new System.Drawing.Point(20, 250); this.lblHoTen.Text = "Họ và tên"; this.lblHoTen.ForeColor = System.Drawing.Color.Gray;
            this.txtHoTen.Location = new System.Drawing.Point(20, 270); this.txtHoTen.Size = new System.Drawing.Size(195, 36); this.txtHoTen.BorderRadius = 5;

            this.lblButDanh.Location = new System.Drawing.Point(235, 250); this.lblButDanh.Text = "Bút danh"; this.lblButDanh.ForeColor = System.Drawing.Color.Gray;
            this.txtButDanh.Location = new System.Drawing.Point(235, 270); this.txtButDanh.Size = new System.Drawing.Size(195, 36); this.txtButDanh.BorderRadius = 5;

            // HÀNG 3 (Y=320)
            this.lblDienThoai.Location = new System.Drawing.Point(20, 310); this.lblDienThoai.Text = "Điện thoại"; this.lblDienThoai.ForeColor = System.Drawing.Color.Gray;
            this.txtDienThoai.Location = new System.Drawing.Point(20, 330); this.txtDienThoai.Size = new System.Drawing.Size(195, 36); this.txtDienThoai.BorderRadius = 5;

            this.lblEmail.Location = new System.Drawing.Point(235, 310); this.lblEmail.Text = "Email"; this.lblEmail.ForeColor = System.Drawing.Color.Gray;
            this.txtEmail.Location = new System.Drawing.Point(235, 330); this.txtEmail.Size = new System.Drawing.Size(195, 36); this.txtEmail.BorderRadius = 5;

            // HÀNG 4 (Y=380)
            this.lblNgaySinh.Location = new System.Drawing.Point(20, 370); this.lblNgaySinh.Text = "Ngày sinh"; this.lblNgaySinh.ForeColor = System.Drawing.Color.Gray;
            this.dtpNgaySinh.Location = new System.Drawing.Point(20, 390); this.dtpNgaySinh.Size = new System.Drawing.Size(195, 36); this.dtpNgaySinh.BorderRadius = 5; this.dtpNgaySinh.FillColor = System.Drawing.Color.FromArgb(241, 245, 249);

            this.lblPhanLoai.Location = new System.Drawing.Point(235, 370); this.lblPhanLoai.Text = "Phân loại"; this.lblPhanLoai.ForeColor = System.Drawing.Color.Gray;
            this.cboPhanLoai.Location = new System.Drawing.Point(235, 390); this.cboPhanLoai.Size = new System.Drawing.Size(195, 36); this.cboPhanLoai.BorderRadius = 5;
            this.cboPhanLoai.Items.AddRange(new object[] { "Phóng viên", "Cộng tác viên", "Khách mời" });

            // HÀNG 5 (Y=440) - Full Width
            this.lblDiaChi.Location = new System.Drawing.Point(20, 430); this.lblDiaChi.Text = "Địa chỉ"; this.lblDiaChi.ForeColor = System.Drawing.Color.Gray;
            this.txtDiaChi.Location = new System.Drawing.Point(20, 450); this.txtDiaChi.Size = new System.Drawing.Size(410, 36); this.txtDiaChi.BorderRadius = 5;

            // KHU VỰC PDF (Y=500)
            this.btnChonPDF.Location = new System.Drawing.Point(20, 500); this.btnChonPDF.Size = new System.Drawing.Size(150, 36); this.btnChonPDF.BorderRadius = 5;
            this.btnChonPDF.FillColor = System.Drawing.Color.FromArgb(239, 68, 68); this.btnChonPDF.Text = "📎 Đính kèm CV (PDF)"; this.btnChonPDF.Click += new System.EventHandler(this.btnChonPDF_Click);

            this.btnXemPDF.Location = new System.Drawing.Point(180, 500); this.btnXemPDF.Size = new System.Drawing.Size(100, 36); this.btnXemPDF.BorderRadius = 5;
            this.btnXemPDF.FillColor = System.Drawing.Color.FromArgb(16, 185, 129); this.btnXemPDF.Text = "👁 Xem File"; this.btnXemPDF.Click += new System.EventHandler(this.btnXemPDF_Click); this.btnXemPDF.Enabled = false;

            this.lblFilePDF.Location = new System.Drawing.Point(290, 510); this.lblFilePDF.Text = "Chưa có file..."; this.lblFilePDF.ForeColor = System.Drawing.Color.Gray; this.lblFilePDF.AutoSize = true;

            // NÚT CHỨC NĂNG (Y=570)
            this.btnThem.Location = new System.Drawing.Point(20, 570); this.btnThem.Size = new System.Drawing.Size(195, 45); this.btnThem.BorderRadius = 5; this.btnThem.FillColor = System.Drawing.Color.FromArgb(37, 99, 235); this.btnThem.Text = "THÊM MỚI";
            this.btnSua.Location = new System.Drawing.Point(235, 570); this.btnSua.Size = new System.Drawing.Size(195, 45); this.btnSua.BorderRadius = 5; this.btnSua.FillColor = System.Drawing.Color.FromArgb(245, 158, 11); this.btnSua.Text = "CẬP NHẬT";

            this.btnXoa.Location = new System.Drawing.Point(20, 625); this.btnXoa.Size = new System.Drawing.Size(195, 45); this.btnXoa.BorderRadius = 5; this.btnXoa.BorderThickness = 1; this.btnXoa.FillColor = System.Drawing.Color.White; this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(239, 68, 68); this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68); this.btnXoa.Text = "XÓA HỒ SƠ";
            this.btnLamMoi.Location = new System.Drawing.Point(235, 625); this.btnLamMoi.Size = new System.Drawing.Size(195, 45); this.btnLamMoi.BorderRadius = 5; this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(226, 232, 240); this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105); this.btnLamMoi.Text = "LÀM MỚI";

            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.lblDataTitle);
            this.pnlRight.Controls.Add(this.txtTimKiem);
            this.pnlRight.Controls.Add(this.dgvTacGia);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(450, 0);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(20);
            this.pnlRight.Size = new System.Drawing.Size(750, 750);

            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.Location = new System.Drawing.Point(20, 20);
            this.lblDataTitle.Text = "DANH SÁCH TÁC GIẢ";

            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Location = new System.Drawing.Point(450, 20);
            this.txtTimKiem.Size = new System.Drawing.Size(280, 36);
            this.txtTimKiem.BorderRadius = 5;
            this.txtTimKiem.PlaceholderText = "🔍 Nhập tên hoặc mã...";

            // Lưới Dữ liệu (Thiết lập màu trắng/xanh navy như form trước)
            this.dgvTacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTacGia.Location = new System.Drawing.Point(20, 80);
            this.dgvTacGia.Size = new System.Drawing.Size(710, 650);
            this.dgvTacGia.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(40, 58, 90);
            this.dgvTacGia.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTacGia.ThemeStyle.HeaderStyle.Height = 45;
            this.dgvTacGia.RowTemplate.Height = 40;
            this.dgvTacGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTacGia_CellClick);

            // 
            // FrmTacGia
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FrmTacGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Tác Giả";

            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacGia)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Khai báo biến giao diện
        private Guna.UI2.WinForms.Guna2Panel pnlLeft;
        private Guna.UI2.WinForms.Guna2Panel pnlRight;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2Button btnChonAnh;
        private System.Windows.Forms.Label lblMaHT, lblMaThe, lblHoTen, lblButDanh, lblDienThoai, lblEmail, lblNgaySinh, lblPhanLoai, lblDiaChi, lblFilePDF, lblDataTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtMaHT, txtMaThe, txtHoTen, txtButDanh, txtDienThoai, txtEmail, txtDiaChi, txtTimKiem;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgaySinh;
        private Guna.UI2.WinForms.Guna2ComboBox cboPhanLoai;
        private Guna.UI2.WinForms.Guna2Button btnChonPDF, btnXemPDF, btnThem, btnSua, btnXoa, btnLamMoi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTacGia;
    }
}