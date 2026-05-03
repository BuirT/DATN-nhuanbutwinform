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
            this.lblXinChao = new System.Windows.Forms.Label();
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

            // NÚT KHÓA SỔ
            this.btnKhoaSo = new Guna.UI2.WinForms.Guna2Button();

            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvSoBao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoBao)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblXinChao);
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
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1084, 230);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(285, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "THÔNG TIN KỲ XUẤT BẢN";
            // 
            // lblXinChao
            // 
            this.lblXinChao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblXinChao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblXinChao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblXinChao.Location = new System.Drawing.Point(780, 25);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(280, 25);
            this.lblXinChao.TabIndex = 6;
            this.lblXinChao.Text = "Xin chào, Admin 👋";
            this.lblXinChao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaso
            // 
            this.lblMaso.AutoSize = true;
            this.lblMaso.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMaso.ForeColor = System.Drawing.Color.Gray;
            this.lblMaso.Location = new System.Drawing.Point(27, 70);
            this.lblMaso.Name = "lblMaso";
            this.lblMaso.Size = new System.Drawing.Size(45, 17);
            this.lblMaso.TabIndex = 7;
            this.lblMaso.Text = "Mã số";
            // 
            // txtMaso
            // 
            this.txtMaso.BorderRadius = 5;
            this.txtMaso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaso.DefaultText = "";
            this.txtMaso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaso.Location = new System.Drawing.Point(30, 90);
            this.txtMaso.Name = "txtMaso";
            this.txtMaso.PlaceholderText = "";
            this.txtMaso.SelectedText = "";
            this.txtMaso.Size = new System.Drawing.Size(120, 41);
            this.txtMaso.TabIndex = 8;
            // 
            // lblTenBao
            // 
            this.lblTenBao.AutoSize = true;
            this.lblTenBao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTenBao.ForeColor = System.Drawing.Color.Gray;
            this.lblTenBao.Location = new System.Drawing.Point(167, 70);
            this.lblTenBao.Name = "lblTenBao";
            this.lblTenBao.Size = new System.Drawing.Size(74, 17);
            this.lblTenBao.TabIndex = 9;
            this.lblTenBao.Text = "Tên kỳ báo";
            // 
            // txtTenBao
            // 
            this.txtTenBao.BorderRadius = 5;
            this.txtTenBao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBao.DefaultText = "";
            this.txtTenBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenBao.Location = new System.Drawing.Point(170, 90);
            this.txtTenBao.Name = "txtTenBao";
            this.txtTenBao.PlaceholderText = "";
            this.txtTenBao.SelectedText = "";
            this.txtTenBao.Size = new System.Drawing.Size(320, 41);
            this.txtTenBao.TabIndex = 10;
            // 
            // lblSoBao
            // 
            this.lblSoBao.AutoSize = true;
            this.lblSoBao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSoBao.ForeColor = System.Drawing.Color.Gray;
            this.lblSoBao.Location = new System.Drawing.Point(507, 70);
            this.lblSoBao.Name = "lblSoBao";
            this.lblSoBao.Size = new System.Drawing.Size(50, 17);
            this.lblSoBao.TabIndex = 11;
            this.lblSoBao.Text = "Số báo";
            // 
            // txtSoBao
            // 
            this.txtSoBao.BorderRadius = 5;
            this.txtSoBao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoBao.DefaultText = "";
            this.txtSoBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoBao.Location = new System.Drawing.Point(510, 90);
            this.txtSoBao.Name = "txtSoBao";
            this.txtSoBao.PlaceholderText = "";
            this.txtSoBao.SelectedText = "";
            this.txtSoBao.Size = new System.Drawing.Size(140, 41);
            this.txtSoBao.TabIndex = 12;
            // 
            // lblSoBo
            // 
            this.lblSoBo.AutoSize = true;
            this.lblSoBo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSoBo.ForeColor = System.Drawing.Color.Gray;
            this.lblSoBo.Location = new System.Drawing.Point(667, 70);
            this.lblSoBo.Name = "lblSoBo";
            this.lblSoBo.Size = new System.Drawing.Size(43, 17);
            this.lblSoBo.TabIndex = 13;
            this.lblSoBo.Text = "Số bộ";
            // 
            // txtSoBo
            // 
            this.txtSoBo.BorderRadius = 5;
            this.txtSoBo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoBo.DefaultText = "";
            this.txtSoBo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoBo.Location = new System.Drawing.Point(670, 90);
            this.txtSoBo.Name = "txtSoBo";
            this.txtSoBo.PlaceholderText = "";
            this.txtSoBo.SelectedText = "";
            this.txtSoBo.Size = new System.Drawing.Size(140, 41);
            this.txtSoBo.TabIndex = 14;
            // 
            // lblLoaiBao
            // 
            this.lblLoaiBao.AutoSize = true;
            this.lblLoaiBao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLoaiBao.ForeColor = System.Drawing.Color.Gray;
            this.lblLoaiBao.Location = new System.Drawing.Point(827, 70);
            this.lblLoaiBao.Name = "lblLoaiBao";
            this.lblLoaiBao.Size = new System.Drawing.Size(59, 17);
            this.lblLoaiBao.TabIndex = 15;
            this.lblLoaiBao.Text = "Loại báo";
            // 
            // cboLoaiBao
            // 
            this.cboLoaiBao.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiBao.BorderRadius = 5;
            this.cboLoaiBao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBao.FocusedColor = System.Drawing.Color.Empty;
            this.cboLoaiBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLoaiBao.ItemHeight = 30;
            this.cboLoaiBao.Items.AddRange(new object[] {
            "Báo in",
            "Báo điện tử",
            "Tạp chí"});
            this.cboLoaiBao.Location = new System.Drawing.Point(830, 90);
            this.cboLoaiBao.Name = "cboLoaiBao";
            this.cboLoaiBao.Size = new System.Drawing.Size(200, 36);
            this.cboLoaiBao.TabIndex = 16;
            // 
            // lblNgayRa
            // 
            this.lblNgayRa.AutoSize = true;
            this.lblNgayRa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNgayRa.ForeColor = System.Drawing.Color.Gray;
            this.lblNgayRa.Location = new System.Drawing.Point(27, 140);
            this.lblNgayRa.Name = "lblNgayRa";
            this.lblNgayRa.Size = new System.Drawing.Size(56, 17);
            this.lblNgayRa.TabIndex = 17;
            this.lblNgayRa.Text = "Ngày ra";
            // 
            // dtpNgayRa
            // 
            this.dtpNgayRa.BorderRadius = 5;
            this.dtpNgayRa.Checked = true;
            this.dtpNgayRa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dtpNgayRa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayRa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayRa.Location = new System.Drawing.Point(30, 160);
            this.dtpNgayRa.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayRa.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayRa.Name = "dtpNgayRa";
            this.dtpNgayRa.Size = new System.Drawing.Size(200, 36);
            this.dtpNgayRa.TabIndex = 18;
            this.dtpNgayRa.Value = new System.DateTime(2026, 5, 1, 2, 24, 44, 682);
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 5;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(250, 155);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 42);
            this.btnThem.TabIndex = 19;
            this.btnThem.Text = "THÊM MỚI";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 5;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(380, 155);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 42);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "CẬP NHẬT";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.BorderThickness = 1;
            this.btnXoa.FillColor = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.Location = new System.Drawing.Point(510, 155);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 42);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "XÓA BỎ";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 5;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLamMoi.Location = new System.Drawing.Point(640, 155);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 42);
            this.btnLamMoi.TabIndex = 22;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // NÚT KHÓA SỔ
            this.btnKhoaSo.BorderRadius = 5;
            this.btnKhoaSo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnKhoaSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKhoaSo.ForeColor = System.Drawing.Color.White;
            this.btnKhoaSo.Location = new System.Drawing.Point(770, 155);
            this.btnKhoaSo.Name = "btnKhoaSo";
            this.btnKhoaSo.Size = new System.Drawing.Size(150, 42);
            this.btnKhoaSo.TabIndex = 23;
            this.btnKhoaSo.Text = "🔒 KHÓA SỔ BÁO";
            this.btnKhoaSo.Click += new System.EventHandler(this.btnKhoaSo_Click);

            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Controls.Add(this.dgvSoBao);
            this.pnlBottom.Controls.Add(this.txtTimKiem);
            this.pnlBottom.Controls.Add(this.lblDataTitle);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 230);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1084, 451);
            this.pnlBottom.TabIndex = 1;
            // 
            // dgvSoBao
            // 
            this.dgvSoBao.AllowUserToAddRows = false;
            this.dgvSoBao.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSoBao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSoBao.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(58)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSoBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSoBao.ColumnHeadersHeight = 45;
            this.dgvSoBao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSoBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSoBao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSoBao.Location = new System.Drawing.Point(30, 70);
            this.dgvSoBao.Name = "dgvSoBao";
            this.dgvSoBao.ReadOnly = true;
            this.dgvSoBao.RowHeadersVisible = false;
            this.dgvSoBao.RowTemplate.Height = 40;
            this.dgvSoBao.Size = new System.Drawing.Size(1010, 350);
            this.dgvSoBao.TabIndex = 0;
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSoBao.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(58)))), ((int)(((byte)(90)))));
            this.dgvSoBao.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSoBao.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSoBao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSoBao.ThemeStyle.HeaderStyle.Height = 45;
            this.dgvSoBao.ThemeStyle.ReadOnly = true;
            this.dgvSoBao.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSoBao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSoBao.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSoBao.ThemeStyle.RowsStyle.Height = 40;
            this.dgvSoBao.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSoBao.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSoBao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSoBao_CellClick);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderRadius = 5;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(720, 17);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "🔍 Nhập mã số hoặc tên báo...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(320, 41);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblDataTitle
            // 
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDataTitle.Location = new System.Drawing.Point(25, 15);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(233, 30);
            this.lblDataTitle.TabIndex = 2;
            this.lblDataTitle.Text = "DANH SÁCH DỮ LIỆU";
            // 
            // FrmSoBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1084, 681);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
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
        private System.Windows.Forms.Label lblDataTitle;
        private System.Windows.Forms.Label lblXinChao;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSoBao;

        // Nút Khóa Sổ
        private Guna.UI2.WinForms.Guna2Button btnKhoaSo;
    }
}