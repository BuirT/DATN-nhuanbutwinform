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

            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnChonAnh = new Guna.UI2.WinForms.Guna2Button();

            // Hàng 1
            this.lblMaHT = new System.Windows.Forms.Label();
            this.txtMaHT = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.txtMaThe = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSoTaiKhoan = new System.Windows.Forms.Label();
            this.txtSoTaiKhoan = new Guna.UI2.WinForms.Guna2TextBox();

            // Hàng 2
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new Guna.UI2.WinForms.Guna2DateTimePicker();

            // --- MỚI THÊM: ĐIỆN THOẠI ---
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new Guna.UI2.WinForms.Guna2TextBox();

            this.lblPhanLoai = new System.Windows.Forms.Label();
            this.cboPhanLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.txtPhongBan = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();

            // Hàng 3
            this.lblNganHang = new System.Windows.Forms.Label();
            this.txtNganHang = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnChonPDF = new Guna.UI2.WinForms.Guna2Button();
            this.btnXemPDF = new Guna.UI2.WinForms.Guna2Button();
            this.lblFilePDF = new System.Windows.Forms.Label();

            // Nút bấm
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();

            // Dưới
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvTacGia = new Guna.UI2.WinForms.Guna2DataGridView();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacGia)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.picAvatar);
            this.pnlTop.Controls.Add(this.btnChonAnh);

            this.pnlTop.Controls.Add(this.lblMaHT);
            this.pnlTop.Controls.Add(this.txtMaHT);
            this.pnlTop.Controls.Add(this.lblMaThe);
            this.pnlTop.Controls.Add(this.txtMaThe);
            this.pnlTop.Controls.Add(this.lblHoTen);
            this.pnlTop.Controls.Add(this.txtHoTen);
            this.pnlTop.Controls.Add(this.lblSoTaiKhoan);
            this.pnlTop.Controls.Add(this.txtSoTaiKhoan);

            this.pnlTop.Controls.Add(this.lblNgaySinh);
            this.pnlTop.Controls.Add(this.dtpNgaySinh);

            // Thêm Control Điện Thoại
            this.pnlTop.Controls.Add(this.lblDienThoai);
            this.pnlTop.Controls.Add(this.txtDienThoai);

            this.pnlTop.Controls.Add(this.lblPhanLoai);
            this.pnlTop.Controls.Add(this.cboPhanLoai);
            this.pnlTop.Controls.Add(this.lblPhongBan);
            this.pnlTop.Controls.Add(this.txtPhongBan);
            this.pnlTop.Controls.Add(this.lblEmail);
            this.pnlTop.Controls.Add(this.txtEmail);

            this.pnlTop.Controls.Add(this.lblNganHang);
            this.pnlTop.Controls.Add(this.txtNganHang);
            this.pnlTop.Controls.Add(this.btnChonPDF);
            this.pnlTop.Controls.Add(this.btnXemPDF);
            this.pnlTop.Controls.Add(this.lblFilePDF);

            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnXoa);
            this.pnlTop.Controls.Add(this.btnLamMoi);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            // Kéo dài Panel Top ra một chút để đủ chỗ
            this.pnlTop.Size = new System.Drawing.Size(1200, 360);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "HỒ SƠ TÁC GIẢ";

            // picAvatar
            this.picAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(30, 70);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(120, 120);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 2;
            this.picAvatar.TabStop = false;

            // btnChonAnh
            this.btnChonAnh.BorderRadius = 15;
            this.btnChonAnh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChonAnh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnChonAnh.Location = new System.Drawing.Point(40, 210);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(100, 30);
            this.btnChonAnh.TabIndex = 3;
            this.btnChonAnh.Text = "Đổi Ảnh";

            // --- HÀNG 1 ---
            this.lblMaHT.ForeColor = System.Drawing.Color.Gray;
            this.lblMaHT.Location = new System.Drawing.Point(180, 50);
            this.lblMaHT.Name = "lblMaHT";
            this.lblMaHT.Size = new System.Drawing.Size(100, 20);
            this.lblMaHT.TabIndex = 4;
            this.lblMaHT.Text = "Mã HT";

            this.txtMaHT.BorderRadius = 5;
            this.txtMaHT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaHT.Location = new System.Drawing.Point(180, 70);
            this.txtMaHT.Name = "txtMaHT";
            this.txtMaHT.Size = new System.Drawing.Size(120, 36);
            this.txtMaHT.TabIndex = 5;

            this.lblMaThe.ForeColor = System.Drawing.Color.Gray;
            this.lblMaThe.Location = new System.Drawing.Point(320, 50);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size = new System.Drawing.Size(100, 20);
            this.lblMaThe.TabIndex = 6;
            this.lblMaThe.Text = "Mã thẻ";

            this.txtMaThe.BorderRadius = 5;
            this.txtMaThe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaThe.Location = new System.Drawing.Point(320, 70);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(120, 36);
            this.txtMaThe.TabIndex = 7;

            this.lblHoTen.ForeColor = System.Drawing.Color.Gray;
            this.lblHoTen.Location = new System.Drawing.Point(460, 50);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(100, 20);
            this.lblHoTen.TabIndex = 8;
            this.lblHoTen.Text = "Họ và tên";

            this.txtHoTen.BorderRadius = 5;
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHoTen.Location = new System.Drawing.Point(460, 70);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(250, 36);
            this.txtHoTen.TabIndex = 9;

            this.lblSoTaiKhoan.ForeColor = System.Drawing.Color.Gray;
            this.lblSoTaiKhoan.Location = new System.Drawing.Point(730, 50);
            this.lblSoTaiKhoan.Name = "lblSoTaiKhoan";
            this.lblSoTaiKhoan.Size = new System.Drawing.Size(100, 20);
            this.lblSoTaiKhoan.TabIndex = 10;
            this.lblSoTaiKhoan.Text = "Số tài khoản";

            this.txtSoTaiKhoan.BorderRadius = 5;
            this.txtSoTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoTaiKhoan.Location = new System.Drawing.Point(730, 70);
            this.txtSoTaiKhoan.Name = "txtSoTaiKhoan";
            this.txtSoTaiKhoan.Size = new System.Drawing.Size(200, 36);
            this.txtSoTaiKhoan.TabIndex = 11;

            // --- HÀNG 2 ---
            this.lblNgaySinh.ForeColor = System.Drawing.Color.Gray;
            this.lblNgaySinh.Location = new System.Drawing.Point(180, 120);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(100, 20);
            this.lblNgaySinh.TabIndex = 12;
            this.lblNgaySinh.Text = "Ngày sinh";

            this.dtpNgaySinh.BorderRadius = 5;
            this.dtpNgaySinh.Checked = true;
            this.dtpNgaySinh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(180, 140);
            this.dtpNgaySinh.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgaySinh.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(120, 36);
            this.dtpNgaySinh.TabIndex = 13;
            this.dtpNgaySinh.Value = new System.DateTime(2026, 5, 1, 0, 0, 0, 0);

            // MỚI: ĐIỆN THOẠI
            this.lblDienThoai.ForeColor = System.Drawing.Color.Gray;
            this.lblDienThoai.Location = new System.Drawing.Point(320, 120);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(100, 20);
            this.lblDienThoai.TabIndex = 90;
            this.lblDienThoai.Text = "Số điện thoại";

            this.txtDienThoai.BorderRadius = 5;
            this.txtDienThoai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDienThoai.Location = new System.Drawing.Point(320, 140);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(140, 36);
            this.txtDienThoai.TabIndex = 91;

            this.lblPhanLoai.ForeColor = System.Drawing.Color.Gray;
            this.lblPhanLoai.Location = new System.Drawing.Point(480, 120);
            this.lblPhanLoai.Name = "lblPhanLoai";
            this.lblPhanLoai.Size = new System.Drawing.Size(100, 20);
            this.lblPhanLoai.TabIndex = 14;
            this.lblPhanLoai.Text = "Phân loại";

            this.cboPhanLoai.BackColor = System.Drawing.Color.Transparent;
            this.cboPhanLoai.BorderRadius = 5;
            this.cboPhanLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPhanLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhanLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhanLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboPhanLoai.ItemHeight = 30;
            this.cboPhanLoai.Items.AddRange(new object[] {
            "Phóng viên",
            "Cộng tác viên",
            "Khách mời"});
            this.cboPhanLoai.Location = new System.Drawing.Point(480, 140);
            this.cboPhanLoai.Name = "cboPhanLoai";
            this.cboPhanLoai.Size = new System.Drawing.Size(140, 36);
            this.cboPhanLoai.TabIndex = 15;

            this.lblPhongBan.ForeColor = System.Drawing.Color.Gray;
            this.lblPhongBan.Location = new System.Drawing.Point(640, 120);
            this.lblPhongBan.Name = "lblPhongBan";
            this.lblPhongBan.Size = new System.Drawing.Size(150, 20);
            this.lblPhongBan.TabIndex = 16;
            this.lblPhongBan.Text = "Phòng ban";

            this.txtPhongBan.BorderRadius = 5;
            this.txtPhongBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhongBan.Location = new System.Drawing.Point(640, 140);
            this.txtPhongBan.Name = "txtPhongBan";
            this.txtPhongBan.Size = new System.Drawing.Size(150, 36);
            this.txtPhongBan.TabIndex = 17;

            this.lblEmail.ForeColor = System.Drawing.Color.Gray;
            this.lblEmail.Location = new System.Drawing.Point(810, 120);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 20);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";

            this.txtEmail.BorderRadius = 5;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(810, 140);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 36);
            this.txtEmail.TabIndex = 19;

            // --- HÀNG 3 ---
            this.lblNganHang.ForeColor = System.Drawing.Color.Gray;
            this.lblNganHang.Location = new System.Drawing.Point(180, 190);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(200, 20);
            this.lblNganHang.TabIndex = 20;
            this.lblNganHang.Text = "Ngân hàng giao dịch";

            this.txtNganHang.BorderRadius = 5;
            this.txtNganHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNganHang.Location = new System.Drawing.Point(180, 210);
            this.txtNganHang.Name = "txtNganHang";
            this.txtNganHang.Size = new System.Drawing.Size(440, 36);
            this.txtNganHang.TabIndex = 21;

            this.btnChonPDF.BorderRadius = 5;
            this.btnChonPDF.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnChonPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChonPDF.ForeColor = System.Drawing.Color.White;
            this.btnChonPDF.Location = new System.Drawing.Point(640, 210);
            this.btnChonPDF.Name = "btnChonPDF";
            this.btnChonPDF.Size = new System.Drawing.Size(150, 36);
            this.btnChonPDF.TabIndex = 22;
            this.btnChonPDF.Text = "Đính kèm CV (PDF)";

            this.btnXemPDF.BorderRadius = 5;
            this.btnXemPDF.Enabled = false;
            this.btnXemPDF.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnXemPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemPDF.ForeColor = System.Drawing.Color.White;
            this.btnXemPDF.Location = new System.Drawing.Point(810, 210);
            this.btnXemPDF.Name = "btnXemPDF";
            this.btnXemPDF.Size = new System.Drawing.Size(100, 36);
            this.btnXemPDF.TabIndex = 23;
            this.btnXemPDF.Text = "Xem File";

            this.lblFilePDF.AutoSize = true;
            this.lblFilePDF.ForeColor = System.Drawing.Color.Gray;
            this.lblFilePDF.Location = new System.Drawing.Point(640, 255);
            this.lblFilePDF.Name = "lblFilePDF";
            this.lblFilePDF.Size = new System.Drawing.Size(91, 19);
            this.lblFilePDF.TabIndex = 24;
            this.lblFilePDF.Text = "Chưa có file...";

            // --- HÀNG 4 (Nút Bấm) ---
            this.btnThem.BorderRadius = 5;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(180, 290);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.TabIndex = 25;
            this.btnThem.Text = "THÊM MỚI";

            this.btnSua.BorderRadius = 5;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(325, 290);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.TabIndex = 26;
            this.btnSua.Text = "CẬP NHẬT";

            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.BorderThickness = 1;
            this.btnXoa.FillColor = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.Location = new System.Drawing.Point(470, 290);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 40);
            this.btnXoa.TabIndex = 27;
            this.btnXoa.Text = "XÓA HỒ SƠ";

            this.btnLamMoi.BorderRadius = 5;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLamMoi.Location = new System.Drawing.Point(615, 290);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 40);
            this.btnLamMoi.TabIndex = 28;
            this.btnLamMoi.Text = "LÀM MỚI";

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Controls.Add(this.lblDataTitle);
            this.pnlBottom.Controls.Add(this.txtTimKiem);
            this.pnlBottom.Controls.Add(this.dgvTacGia);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            // Chỉnh lại tọa độ Y vì panel trên đã kéo dài
            this.pnlBottom.Location = new System.Drawing.Point(0, 360);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1200, 390);
            this.pnlBottom.TabIndex = 1;

            // lblDataTitle
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.Location = new System.Drawing.Point(20, 15);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(232, 30);
            this.lblDataTitle.TabIndex = 0;
            this.lblDataTitle.Text = "DANH SÁCH TÁC GIẢ";

            // txtTimKiem
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderRadius = 5;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.Location = new System.Drawing.Point(890, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "🔍 Nhập tên, mã thẻ, SĐT...";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 36);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            // dgvTacGia
            this.dgvTacGia.AllowUserToAddRows = false;
            this.dgvTacGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTacGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(58)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTacGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTacGia.ColumnHeadersHeight = 45;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTacGia.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTacGia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTacGia.Location = new System.Drawing.Point(20, 70);
            this.dgvTacGia.Name = "dgvTacGia";
            this.dgvTacGia.ReadOnly = true;
            this.dgvTacGia.RowHeadersVisible = false;
            this.dgvTacGia.RowTemplate.Height = 40;
            this.dgvTacGia.Size = new System.Drawing.Size(1150, 300);
            this.dgvTacGia.TabIndex = 2;
            this.dgvTacGia.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTacGia.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTacGia.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTacGia.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTacGia.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTacGia.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTacGia.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTacGia.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(58)))), ((int)(((byte)(90)))));
            this.dgvTacGia.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTacGia.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvTacGia.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTacGia.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTacGia.ThemeStyle.HeaderStyle.Height = 45;
            this.dgvTacGia.ThemeStyle.ReadOnly = true;
            this.dgvTacGia.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTacGia.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTacGia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvTacGia.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTacGia.ThemeStyle.RowsStyle.Height = 40;
            this.dgvTacGia.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTacGia.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));

            // Events
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            this.btnChonPDF.Click += new System.EventHandler(this.btnChonPDF_Click);
            this.btnXemPDF.Click += new System.EventHandler(this.btnXemPDF_Click);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.dgvTacGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTacGia_CellClick);

            // FrmTacGia
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmTacGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Tác Giả";
            this.Load += new System.EventHandler(this.FrmTacGia_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacGia)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2Button btnChonAnh;
        private System.Windows.Forms.Label lblMaHT;
        private Guna.UI2.WinForms.Guna2TextBox txtMaHT;
        private System.Windows.Forms.Label lblMaThe;
        private Guna.UI2.WinForms.Guna2TextBox txtMaThe;
        private System.Windows.Forms.Label lblHoTen;
        private Guna.UI2.WinForms.Guna2TextBox txtHoTen;
        private System.Windows.Forms.Label lblSoTaiKhoan;
        private Guna.UI2.WinForms.Guna2TextBox txtSoTaiKhoan;

        private System.Windows.Forms.Label lblNgaySinh;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgaySinh;

        // MỚI
        private System.Windows.Forms.Label lblDienThoai;
        private Guna.UI2.WinForms.Guna2TextBox txtDienThoai;

        private System.Windows.Forms.Label lblPhanLoai;
        private Guna.UI2.WinForms.Guna2ComboBox cboPhanLoai;
        private System.Windows.Forms.Label lblPhongBan;
        private Guna.UI2.WinForms.Guna2TextBox txtPhongBan;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblNganHang;
        private Guna.UI2.WinForms.Guna2TextBox txtNganHang;

        private Guna.UI2.WinForms.Guna2Button btnChonPDF;
        private Guna.UI2.WinForms.Guna2Button btnXemPDF;
        private System.Windows.Forms.Label lblFilePDF;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private System.Windows.Forms.Label lblDataTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTacGia;
    }
}