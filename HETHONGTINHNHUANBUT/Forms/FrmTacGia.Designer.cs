using System.Drawing;
using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnChonAnh = new Guna.UI2.WinForms.Guna2Button();
            this.lblMaHT = new System.Windows.Forms.Label();
            this.txtMaHT = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.txtMaThe = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSoTaiKhoan = new System.Windows.Forms.Label();
            this.txtSoTaiKhoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhanLoai = new System.Windows.Forms.Label();
            this.cboPhanLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.txtPhongBan = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.txtNganHang = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnChonPDF = new Guna.UI2.WinForms.Guna2Button();
            this.btnXemPDF = new Guna.UI2.WinForms.Guna2Button();
            this.lblFilePDF = new System.Windows.Forms.Label();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvTacGia = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacGia)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1160, 355);
            this.pnlTop.TabIndex = 0;
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

            this.pnlTop.ShadowDecoration.Enabled = false;
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlTop.ShadowDecoration.Depth = 8;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Size = new System.Drawing.Size(162, 28);
            this.lblTitle.Text = "HỒ SƠ TÁC GIẢ";

            // 
            // picAvatar
            // 
            this.picAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.picAvatar.Location = new System.Drawing.Point(30, 65);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(130, 130);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.TabStop = false;

            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Animated = false;
            this.btnChonAnh.BorderRadius = 8;
            this.btnChonAnh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChonAnh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnChonAnh.Location = new System.Drawing.Point(30, 208);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(130, 35);
            this.btnChonAnh.Text = "Đổi Ảnh";
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            // Cấu hình các ô nhập liệu
            Font labelFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            Color labelColor = Color.FromArgb(100, 116, 139);
            Color borderCol = Color.FromArgb(226, 232, 240);
            Color focusCol = Color.FromArgb(24, 119, 242);

            this.lblMaHT.Font = labelFont; this.lblMaHT.ForeColor = labelColor;
            this.lblMaHT.Location = new System.Drawing.Point(190, 50); this.lblMaHT.Text = "Mã hệ thống";
            this.txtMaHT.BorderRadius = 8; this.txtMaHT.BorderColor = borderCol; this.txtMaHT.FocusedState.BorderColor = focusCol;
            this.txtMaHT.Location = new System.Drawing.Point(190, 72); this.txtMaHT.Size = new System.Drawing.Size(150, 36);

            this.lblMaThe.Font = labelFont; this.lblMaThe.ForeColor = labelColor;
            this.lblMaThe.Location = new System.Drawing.Point(360, 50); this.lblMaThe.Text = "Mã số thẻ (CCCD)";
            this.txtMaThe.BorderRadius = 8; this.txtMaThe.BorderColor = borderCol; this.txtMaThe.FocusedState.BorderColor = focusCol;
            this.txtMaThe.Location = new System.Drawing.Point(360, 72); this.txtMaThe.Size = new System.Drawing.Size(150, 36);

            this.lblHoTen.Font = labelFont; this.lblHoTen.ForeColor = labelColor;
            this.lblHoTen.Location = new System.Drawing.Point(530, 50); this.lblHoTen.Text = "Họ và tên tác giả";
            this.txtHoTen.BorderRadius = 8; this.txtHoTen.BorderColor = borderCol; this.txtHoTen.FocusedState.BorderColor = focusCol;
            this.txtHoTen.Location = new System.Drawing.Point(530, 72); this.txtHoTen.Size = new System.Drawing.Size(300, 36);

            this.lblSoTaiKhoan.Font = labelFont; this.lblSoTaiKhoan.ForeColor = labelColor;
            this.lblSoTaiKhoan.Location = new System.Drawing.Point(850, 50); this.lblSoTaiKhoan.Text = "Số tài khoản ngân hàng";
            this.txtSoTaiKhoan.BorderRadius = 8; this.txtSoTaiKhoan.BorderColor = borderCol; this.txtSoTaiKhoan.FocusedState.BorderColor = focusCol;
            this.txtSoTaiKhoan.Location = new System.Drawing.Point(850, 72); this.txtSoTaiKhoan.Size = new System.Drawing.Size(260, 36);

            this.lblNgaySinh.Font = labelFont; this.lblNgaySinh.ForeColor = labelColor;
            this.lblNgaySinh.Location = new System.Drawing.Point(190, 122); this.lblNgaySinh.Text = "Ngày sinh";
            this.dtpNgaySinh.BorderRadius = 8; this.dtpNgaySinh.BorderThickness = 1; this.dtpNgaySinh.BorderColor = borderCol;
            this.dtpNgaySinh.FillColor = System.Drawing.Color.White;
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(190, 144); this.dtpNgaySinh.Size = new System.Drawing.Size(150, 36);

            this.lblDienThoai.Font = labelFont; this.lblDienThoai.ForeColor = labelColor;
            this.lblDienThoai.Location = new System.Drawing.Point(360, 122); this.lblDienThoai.Text = "Số điện thoại";
            this.txtDienThoai.BorderRadius = 8; this.txtDienThoai.BorderColor = borderCol; this.txtDienThoai.FocusedState.BorderColor = focusCol;
            this.txtDienThoai.Location = new System.Drawing.Point(360, 144); this.txtDienThoai.Size = new System.Drawing.Size(150, 36);

            this.lblPhanLoai.Font = labelFont; this.lblPhanLoai.ForeColor = labelColor;
            this.lblPhanLoai.Location = new System.Drawing.Point(530, 122); this.lblPhanLoai.Text = "Phân loại nhóm";
            this.cboPhanLoai.BorderRadius = 8; this.cboPhanLoai.BorderColor = borderCol;
            this.cboPhanLoai.Location = new System.Drawing.Point(530, 144); this.cboPhanLoai.Size = new System.Drawing.Size(150, 36);

            this.lblPhongBan.Font = labelFont; this.lblPhongBan.ForeColor = labelColor;
            this.lblPhongBan.Location = new System.Drawing.Point(700, 122); this.lblPhongBan.Text = "Phòng ban";
            this.txtPhongBan.BorderRadius = 8; this.txtPhongBan.BorderColor = borderCol; this.txtPhongBan.FocusedState.BorderColor = focusCol;
            this.txtPhongBan.Location = new System.Drawing.Point(700, 144); this.txtPhongBan.Size = new System.Drawing.Size(150, 36);

            this.lblEmail.Font = labelFont; this.lblEmail.ForeColor = labelColor;
            this.lblEmail.Location = new System.Drawing.Point(870, 122); this.lblEmail.Text = "Email";
            this.txtEmail.BorderRadius = 8; this.txtEmail.BorderColor = borderCol; this.txtEmail.FocusedState.BorderColor = focusCol;
            this.txtEmail.Location = new System.Drawing.Point(870, 144); this.txtEmail.Size = new System.Drawing.Size(240, 36);

            this.lblNganHang.Font = labelFont; this.lblNganHang.ForeColor = labelColor;
            this.lblNganHang.Location = new System.Drawing.Point(190, 195); this.lblNganHang.Text = "Ngân hàng giao dịch và chi nhánh";
            this.txtNganHang.BorderRadius = 8; this.txtNganHang.BorderColor = borderCol; this.txtNganHang.FocusedState.BorderColor = focusCol;
            this.txtNganHang.Location = new System.Drawing.Point(190, 217); this.txtNganHang.Size = new System.Drawing.Size(500, 36);

            this.btnChonPDF.Animated = false; this.btnChonPDF.BorderRadius = 8;
            this.btnChonPDF.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnChonPDF.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnChonPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnChonPDF.Location = new System.Drawing.Point(710, 217);
            this.btnChonPDF.Size = new System.Drawing.Size(160, 36);
            this.btnChonPDF.Text = "Đính kèm CV (PDF)";
            this.btnChonPDF.Click += new System.EventHandler(this.btnChonPDF_Click);

            this.btnXemPDF.Animated = false; this.btnXemPDF.BorderRadius = 8;
            this.btnXemPDF.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.btnXemPDF.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXemPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnXemPDF.Location = new System.Drawing.Point(880, 217);
            this.btnXemPDF.Size = new System.Drawing.Size(100, 36);
            this.btnXemPDF.Text = "Xem File";
            this.btnXemPDF.Click += new System.EventHandler(this.btnXemPDF_Click);

            this.lblFilePDF.AutoSize = true;
            this.lblFilePDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblFilePDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblFilePDF.Location = new System.Drawing.Point(710, 258);
            this.lblFilePDF.Text = "Chưa có file...";

            // Nút tác vụ CRUD
            this.btnThem.Animated = false; this.btnThem.BorderRadius = 8;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(180, 295);
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.Text = "THÊM MỚI";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Animated = false; this.btnSua.BorderRadius = 8;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(335, 295);
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.Text = "CẬP NHẬT";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Animated = false; this.btnXoa.BorderRadius = 8;
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnXoa.BorderThickness = 1;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnXoa.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnXoa.Location = new System.Drawing.Point(480, 295);
            this.btnXoa.Size = new System.Drawing.Size(130, 40);
            this.btnXoa.Text = "XÓA HỒ SƠ";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Animated = false; this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLamMoi.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Location = new System.Drawing.Point(625, 295);
            this.btnLamMoi.Size = new System.Drawing.Size(130, 40);
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // pnlBottom (Khối hiển thị bảng danh sách)
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.BorderRadius = 16;
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.Location = new System.Drawing.Point(20, 385);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1160, 350);
            this.pnlBottom.TabIndex = 1;
            this.pnlBottom.Controls.Add(this.lblDataTitle);
            this.pnlBottom.Controls.Add(this.txtTimKiem);
            this.pnlBottom.Controls.Add(this.dgvTacGia);

            this.pnlBottom.ShadowDecoration.Enabled = false;
            this.pnlBottom.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlBottom.ShadowDecoration.Depth = 8;

            // 
            // lblDataTitle
            // 
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDataTitle.Location = new System.Drawing.Point(20, 18);
            this.lblDataTitle.Text = "DANH SÁCH TÁC GIẢ THÀNH VIÊN";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.BorderColor = borderCol;
            this.txtTimKiem.FocusedState.BorderColor = focusCol;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(860, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "🔍 Nhập tên, mã thẻ, SĐT...";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 36);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            // 
            // dgvTacGia
            // 
            this.dgvTacGia.AllowUserToAddRows = false;
            this.dgvTacGia.AllowUserToDeleteRows = false;
            this.dgvTacGia.AllowUserToResizeColumns = false;
            this.dgvTacGia.AllowUserToResizeRows = false;
            this.dgvTacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTacGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTacGia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvTacGia.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;

            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvTacGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;

            this.dgvTacGia.BackgroundColor = System.Drawing.Color.White;
            this.dgvTacGia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTacGia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTacGia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvTacGia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvTacGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTacGia.ColumnHeadersHeight = 42;

            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTacGia.DefaultCellStyle = dataGridViewCellStyle6;

            this.dgvTacGia.Location = new System.Drawing.Point(20, 65);
            this.dgvTacGia.Name = "dgvTacGia";
            this.dgvTacGia.ReadOnly = true;
            this.dgvTacGia.RowHeadersVisible = false;
            this.dgvTacGia.RowTemplate.Height = 38;
            this.dgvTacGia.Size = new System.Drawing.Size(1120, 260);
            this.dgvTacGia.TabIndex = 2;
            this.dgvTacGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTacGia_CellClick);

            // 
            // FrmTacGia (Form chính diện)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmTacGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Hồ sơ Tác giả";
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