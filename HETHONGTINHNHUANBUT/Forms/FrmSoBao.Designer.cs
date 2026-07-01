namespace HETHONGTINHNHUANBUT
{
    partial class FrmSoBao
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
            this.lblMaso = new System.Windows.Forms.Label();
            this.txtMaso = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTenBao = new System.Windows.Forms.Label();
            this.txtTenBao = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSoBao = new System.Windows.Forms.Label();
            this.txtSoBao = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSoBo = new System.Windows.Forms.Label();
            this.txtSoBo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLoaiBao = new System.Windows.Forms.Label();
            this.cboLoaiBao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNgayRa = new System.Windows.Forms.Label();
            this.dtpNgayRa = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnKhoaSo = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvSoBao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoBao)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblMaso);
            this.pnlTop.Controls.Add(this.txtMaso);
            this.pnlTop.Controls.Add(this.lblTenBao);
            this.pnlTop.Controls.Add(this.txtTenBao);
            this.pnlTop.Controls.Add(this.lblSoBao);
            this.pnlTop.Controls.Add(this.txtSoBao);
            this.pnlTop.Controls.Add(this.lblSoBo);
            this.pnlTop.Controls.Add(this.txtSoBo);
            this.pnlTop.Controls.Add(this.lblLoaiBao);
            this.pnlTop.Controls.Add(this.cboLoaiBao);
            this.pnlTop.Controls.Add(this.lblNgayRa);
            this.pnlTop.Controls.Add(this.dtpNgayRa);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnXoa);
            this.pnlTop.Controls.Add(this.btnLamMoi);
            this.pnlTop.Controls.Add(this.btnKhoaSo);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.ShadowDecoration.Enabled = false;
            this.pnlTop.Size = new System.Drawing.Size(1160, 223);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(263, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN KỲ XUẤT BẢN";
            // 
            // lblMaso
            // 
            this.lblMaso.AutoSize = true;
            this.lblMaso.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMaso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMaso.Location = new System.Drawing.Point(25, 65);
            this.lblMaso.Name = "lblMaso";
            this.lblMaso.Size = new System.Drawing.Size(45, 17);
            this.lblMaso.TabIndex = 1;
            this.lblMaso.Text = "Mã số";
            // 
            // txtMaso
            // 
            this.txtMaso.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtMaso.BorderRadius = 8;
            this.txtMaso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaso.DefaultText = "";
            this.txtMaso.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtMaso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtMaso.Location = new System.Drawing.Point(25, 87);
            this.txtMaso.Name = "txtMaso";
            this.txtMaso.PlaceholderText = "";
            this.txtMaso.SelectedText = "";
            this.txtMaso.Size = new System.Drawing.Size(150, 36);
            this.txtMaso.TabIndex = 8;
            // 
            // lblTenBao
            // 
            this.lblTenBao.AutoSize = true;
            this.lblTenBao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTenBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTenBao.Location = new System.Drawing.Point(195, 65);
            this.lblTenBao.Name = "lblTenBao";
            this.lblTenBao.Size = new System.Drawing.Size(75, 17);
            this.lblTenBao.TabIndex = 9;
            this.lblTenBao.Text = "Tên kỳ báo";
            // 
            // txtTenBao
            // 
            this.txtTenBao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtTenBao.BorderRadius = 8;
            this.txtTenBao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBao.DefaultText = "";
            this.txtTenBao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtTenBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtTenBao.Location = new System.Drawing.Point(195, 87);
            this.txtTenBao.Name = "txtTenBao";
            this.txtTenBao.PlaceholderText = "";
            this.txtTenBao.SelectedText = "";
            this.txtTenBao.Size = new System.Drawing.Size(350, 36);
            this.txtTenBao.TabIndex = 10;
            // 
            // lblSoBao
            // 
            this.lblSoBao.AutoSize = true;
            this.lblSoBao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSoBao.Location = new System.Drawing.Point(565, 65);
            this.lblSoBao.Name = "lblSoBao";
            this.lblSoBao.Size = new System.Drawing.Size(50, 17);
            this.lblSoBao.TabIndex = 11;
            this.lblSoBao.Text = "Số báo";
            // 
            // txtSoBao
            // 
            this.txtSoBao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtSoBao.BorderRadius = 8;
            this.txtSoBao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoBao.DefaultText = "";
            this.txtSoBao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtSoBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtSoBao.Location = new System.Drawing.Point(565, 87);
            this.txtSoBao.Name = "txtSoBao";
            this.txtSoBao.PlaceholderText = "";
            this.txtSoBao.SelectedText = "";
            this.txtSoBao.Size = new System.Drawing.Size(120, 36);
            this.txtSoBao.TabIndex = 12;
            // 
            // lblSoBo
            // 
            this.lblSoBo.AutoSize = true;
            this.lblSoBo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSoBo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSoBo.Location = new System.Drawing.Point(705, 65);
            this.lblSoBo.Name = "lblSoBo";
            this.lblSoBo.Size = new System.Drawing.Size(43, 17);
            this.lblSoBo.TabIndex = 13;
            this.lblSoBo.Text = "Số bộ";
            // 
            // txtSoBo
            // 
            this.txtSoBo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtSoBo.BorderRadius = 8;
            this.txtSoBo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoBo.DefaultText = "";
            this.txtSoBo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtSoBo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoBo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtSoBo.Location = new System.Drawing.Point(705, 87);
            this.txtSoBo.Name = "txtSoBo";
            this.txtSoBo.PlaceholderText = "";
            this.txtSoBo.SelectedText = "";
            this.txtSoBo.Size = new System.Drawing.Size(120, 36);
            this.txtSoBo.TabIndex = 14;
            // 
            // lblLoaiBao
            // 
            this.lblLoaiBao.AutoSize = true;
            this.lblLoaiBao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLoaiBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLoaiBao.Location = new System.Drawing.Point(845, 65);
            this.lblLoaiBao.Name = "lblLoaiBao";
            this.lblLoaiBao.Size = new System.Drawing.Size(61, 17);
            this.lblLoaiBao.TabIndex = 15;
            this.lblLoaiBao.Text = "Loại báo";
            // 
            // cboLoaiBao
            // 
            this.cboLoaiBao.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiBao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboLoaiBao.BorderRadius = 8;
            this.cboLoaiBao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBao.FocusedColor = System.Drawing.Color.Empty;
            this.cboLoaiBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cboLoaiBao.ItemHeight = 30;
            this.cboLoaiBao.Location = new System.Drawing.Point(845, 87);
            this.cboLoaiBao.Name = "cboLoaiBao";
            this.cboLoaiBao.Size = new System.Drawing.Size(150, 36);
            this.cboLoaiBao.TabIndex = 16;
            // 
            // lblNgayRa
            // 
            this.lblNgayRa.AutoSize = true;
            this.lblNgayRa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayRa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNgayRa.Location = new System.Drawing.Point(1015, 65);
            this.lblNgayRa.Name = "lblNgayRa";
            this.lblNgayRa.Size = new System.Drawing.Size(56, 17);
            this.lblNgayRa.TabIndex = 17;
            this.lblNgayRa.Text = "Ngày ra";
            // 
            // dtpNgayRa
            // 
            this.dtpNgayRa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dtpNgayRa.BorderRadius = 8;
            this.dtpNgayRa.BorderThickness = 1;
            this.dtpNgayRa.Checked = true;
            this.dtpNgayRa.FillColor = System.Drawing.Color.White;
            this.dtpNgayRa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayRa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dtpNgayRa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayRa.Location = new System.Drawing.Point(1015, 87);
            this.dtpNgayRa.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayRa.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayRa.Name = "dtpNgayRa";
            this.dtpNgayRa.Size = new System.Drawing.Size(120, 36);
            this.dtpNgayRa.TabIndex = 18;
            this.dtpNgayRa.Value = new System.DateTime(2026, 5, 25, 22, 35, 47, 238);
            // 
            // btnThem
            // 
            this.btnThem.Animated = false;
            this.btnThem.BorderRadius = 8;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 155);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.TabIndex = 19;
            this.btnThem.Text = "THÊM MỚI";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Animated = false;
            this.btnSua.BorderRadius = 8;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(175, 155);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "CẬP NHẬT";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Animated = false;
            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnXoa.BorderRadius = 8;
            this.btnXoa.BorderThickness = 1;
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnXoa.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnXoa.Location = new System.Drawing.Point(325, 155);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 40);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "XÓA BỎ";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Animated = false;
            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLamMoi.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Location = new System.Drawing.Point(475, 155);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 40);
            this.btnLamMoi.TabIndex = 22;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnKhoaSo
            // 
            this.btnKhoaSo.Animated = false;
            this.btnKhoaSo.BorderRadius = 8;
            this.btnKhoaSo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnKhoaSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKhoaSo.ForeColor = System.Drawing.Color.White;
            this.btnKhoaSo.Location = new System.Drawing.Point(625, 155);
            this.btnKhoaSo.Name = "btnKhoaSo";
            this.btnKhoaSo.Size = new System.Drawing.Size(180, 40);
            this.btnKhoaSo.TabIndex = 23;
            this.btnKhoaSo.Text = "🔒 KHÓA SỔ BÁO";
            this.btnKhoaSo.Click += new System.EventHandler(this.btnKhoaSo_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.BorderRadius = 16;
            this.pnlBottom.Controls.Add(this.lblDataTitle);
            this.pnlBottom.Controls.Add(this.txtTimKiem);
            this.pnlBottom.Controls.Add(this.dgvSoBao);
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(20, 253);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlBottom.ShadowDecoration.Depth = 8;
            this.pnlBottom.ShadowDecoration.Enabled = false;
            this.pnlBottom.Size = new System.Drawing.Size(1160, 517);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblDataTitle
            // 
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDataTitle.Location = new System.Drawing.Point(25, 18);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(194, 25);
            this.lblDataTitle.TabIndex = 0;
            this.lblDataTitle.Text = "DANH SÁCH DỮ LIỆU";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(855, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "🔍 Nhập mã số hoặc tên báo...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 36);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // dgvSoBao
            // 
            this.dgvSoBao.AllowUserToAddRows = false;
            this.dgvSoBao.AllowUserToDeleteRows = false;
            this.dgvSoBao.AllowUserToResizeColumns = false;
            this.dgvSoBao.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSoBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSoBao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSoBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSoBao.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSoBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSoBao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvSoBao.Location = new System.Drawing.Point(25, 65);
            this.dgvSoBao.MultiSelect = false;
            this.dgvSoBao.Name = "dgvSoBao";
            this.dgvSoBao.ReadOnly = true;
            this.dgvSoBao.RowHeadersVisible = false;
            this.dgvSoBao.RowTemplate.Height = 38;
            this.dgvSoBao.Size = new System.Drawing.Size(1110, 427);
            this.dgvSoBao.TabIndex = 0;
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSoBao.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvSoBao.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvSoBao.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSoBao.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSoBao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvSoBao.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSoBao.ThemeStyle.HeaderStyle.Height = 42;
            this.dgvSoBao.ThemeStyle.ReadOnly = true;
            this.dgvSoBao.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSoBao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSoBao.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvSoBao.ThemeStyle.RowsStyle.Height = 38;
            this.dgvSoBao.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSoBao.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSoBao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSoBao_CellClick);
            // 
            // FrmSoBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmSoBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Kỳ Báo";
            this.Load += new System.EventHandler(this.FrmSoBao_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoBao)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaso;
        private Guna.UI2.WinForms.Guna2TextBox txtMaso;
        private System.Windows.Forms.Label lblTenBao;
        private Guna.UI2.WinForms.Guna2TextBox txtTenBao;
        private System.Windows.Forms.Label lblSoBao;
        private Guna.UI2.WinForms.Guna2TextBox txtSoBao;
        private System.Windows.Forms.Label lblSoBo;
        private Guna.UI2.WinForms.Guna2TextBox txtSoBo;
        private System.Windows.Forms.Label lblLoaiBao;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiBao;
        private System.Windows.Forms.Label lblNgayRa;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayRa;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnKhoaSo;
        private System.Windows.Forms.Label lblDataTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSoBao;
    }
}