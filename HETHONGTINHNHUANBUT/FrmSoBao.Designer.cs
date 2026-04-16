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
            this.pnlLeft = new Guna.UI2.WinForms.Guna2Panel();
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
            this.pnlRight = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvSoBao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoBao)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.lblTitle);
            this.pnlLeft.Controls.Add(this.lblMaso);
            this.pnlLeft.Controls.Add(this.txtMaso);
            this.pnlLeft.Controls.Add(this.lblTenBao);
            this.pnlLeft.Controls.Add(this.txtTenBao);
            this.pnlLeft.Controls.Add(this.lblSoBao);
            this.pnlLeft.Controls.Add(this.txtSoBao);
            this.pnlLeft.Controls.Add(this.lblSoBo);
            this.pnlLeft.Controls.Add(this.txtSoBo);
            this.pnlLeft.Controls.Add(this.lblLoaiBao);
            this.pnlLeft.Controls.Add(this.cboLoaiBao);
            this.pnlLeft.Controls.Add(this.lblNgayRa);
            this.pnlLeft.Controls.Add(this.dtpNgayRa);
            this.pnlLeft.Controls.Add(this.btnThem);
            this.pnlLeft.Controls.Add(this.btnSua);
            this.pnlLeft.Controls.Add(this.btnXoa);
            this.pnlLeft.Controls.Add(this.btnLamMoi);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(350, 681);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN KỲ XUẤT BẢN";
            // 
            // lblMaso
            // 
            this.lblMaso.AutoSize = true;
            this.lblMaso.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMaso.ForeColor = System.Drawing.Color.Gray;
            this.lblMaso.Location = new System.Drawing.Point(22, 70);
            this.lblMaso.Name = "lblMaso";
            this.lblMaso.Size = new System.Drawing.Size(46, 17);
            this.lblMaso.TabIndex = 1;
            this.lblMaso.Text = "Mã số";
            // 
            // txtMaso
            // 
            this.txtMaso.BorderRadius = 5;
            this.txtMaso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaso.DefaultText = "";
            this.txtMaso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaso.Location = new System.Drawing.Point(25, 90);
            this.txtMaso.Name = "txtMaso";
            this.txtMaso.PlaceholderText = "Nhập mã số...";
            this.txtMaso.Size = new System.Drawing.Size(300, 36);
            this.txtMaso.TabIndex = 2;
            // 
            // lblTenBao
            // 
            this.lblTenBao.AutoSize = true;
            this.lblTenBao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTenBao.ForeColor = System.Drawing.Color.Gray;
            this.lblTenBao.Location = new System.Drawing.Point(22, 140);
            this.lblTenBao.Name = "lblTenBao";
            this.lblTenBao.Size = new System.Drawing.Size(77, 17);
            this.lblTenBao.TabIndex = 3;
            this.lblTenBao.Text = "Tên kỳ báo";
            // 
            // txtTenBao
            // 
            this.txtTenBao.BorderRadius = 5;
            this.txtTenBao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBao.DefaultText = "";
            this.txtTenBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenBao.Location = new System.Drawing.Point(25, 160);
            this.txtTenBao.Name = "txtTenBao";
            this.txtTenBao.PlaceholderText = "Nhập tên kỳ báo...";
            this.txtTenBao.Size = new System.Drawing.Size(300, 36);
            this.txtTenBao.TabIndex = 4;
            // 
            // lblSoBao
            // 
            this.lblSoBao.AutoSize = true;
            this.lblSoBao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSoBao.ForeColor = System.Drawing.Color.Gray;
            this.lblSoBao.Location = new System.Drawing.Point(22, 210);
            this.lblSoBao.Name = "lblSoBao";
            this.lblSoBao.Size = new System.Drawing.Size(51, 17);
            this.lblSoBao.TabIndex = 5;
            this.lblSoBao.Text = "Số báo";
            // 
            // txtSoBao
            // 
            this.txtSoBao.BorderRadius = 5;
            this.txtSoBao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoBao.DefaultText = "";
            this.txtSoBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoBao.Location = new System.Drawing.Point(25, 230);
            this.txtSoBao.Name = "txtSoBao";
            this.txtSoBao.PlaceholderText = "Số báo...";
            this.txtSoBao.Size = new System.Drawing.Size(140, 36);
            this.txtSoBao.TabIndex = 6;
            // 
            // lblSoBo
            // 
            this.lblSoBo.AutoSize = true;
            this.lblSoBo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSoBo.ForeColor = System.Drawing.Color.Gray;
            this.lblSoBo.Location = new System.Drawing.Point(182, 210);
            this.lblSoBo.Name = "lblSoBo";
            this.lblSoBo.Size = new System.Drawing.Size(43, 17);
            this.lblSoBo.TabIndex = 7;
            this.lblSoBo.Text = "Số bộ";
            // 
            // txtSoBo
            // 
            this.txtSoBo.BorderRadius = 5;
            this.txtSoBo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoBo.DefaultText = "";
            this.txtSoBo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoBo.Location = new System.Drawing.Point(185, 230);
            this.txtSoBo.Name = "txtSoBo";
            this.txtSoBo.PlaceholderText = "Số bộ...";
            this.txtSoBo.Size = new System.Drawing.Size(140, 36);
            this.txtSoBo.TabIndex = 8;
            // 
            // lblLoaiBao
            // 
            this.lblLoaiBao.AutoSize = true;
            this.lblLoaiBao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLoaiBao.ForeColor = System.Drawing.Color.Gray;
            this.lblLoaiBao.Location = new System.Drawing.Point(22, 280);
            this.lblLoaiBao.Name = "lblLoaiBao";
            this.lblLoaiBao.Size = new System.Drawing.Size(59, 17);
            this.lblLoaiBao.TabIndex = 9;
            this.lblLoaiBao.Text = "Loại báo";
            // 
            // cboLoaiBao
            // 
            this.cboLoaiBao.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiBao.BorderRadius = 5;
            this.cboLoaiBao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLoaiBao.ItemHeight = 30;
            this.cboLoaiBao.Items.AddRange(new object[] {
            "Báo in",
            "Báo điện tử",
            "Tạp chí"});
            this.cboLoaiBao.Location = new System.Drawing.Point(25, 300);
            this.cboLoaiBao.Name = "cboLoaiBao";
            this.cboLoaiBao.Size = new System.Drawing.Size(300, 36);
            this.cboLoaiBao.TabIndex = 10;
            // 
            // lblNgayRa
            // 
            this.lblNgayRa.AutoSize = true;
            this.lblNgayRa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNgayRa.ForeColor = System.Drawing.Color.Gray;
            this.lblNgayRa.Location = new System.Drawing.Point(22, 350);
            this.lblNgayRa.Name = "lblNgayRa";
            this.lblNgayRa.Size = new System.Drawing.Size(58, 17);
            this.lblNgayRa.TabIndex = 11;
            this.lblNgayRa.Text = "Ngày ra";
            // 
            // dtpNgayRa
            // 
            this.dtpNgayRa.BorderRadius = 5;
            this.dtpNgayRa.Checked = true;
            this.dtpNgayRa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dtpNgayRa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayRa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayRa.Location = new System.Drawing.Point(25, 370);
            this.dtpNgayRa.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayRa.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayRa.Name = "dtpNgayRa";
            this.dtpNgayRa.Size = new System.Drawing.Size(300, 36);
            this.dtpNgayRa.TabIndex = 12;
            this.dtpNgayRa.Value = new System.DateTime(2026, 4, 16, 0, 0, 0, 0);
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 5;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 440);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(140, 45);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "THÊM MỚI";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 5;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(185, 440);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(140, 45);
            this.btnSua.TabIndex = 14;
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
            this.btnXoa.Location = new System.Drawing.Point(25, 495);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(140, 45);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "XÓA BỎ";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 5;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLamMoi.Location = new System.Drawing.Point(185, 495);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 45);
            this.btnLamMoi.TabIndex = 16;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.dgvSoBao);
            this.pnlRight.Controls.Add(this.lblDataTitle);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(350, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(20);
            this.pnlRight.Size = new System.Drawing.Size(734, 681);
            this.pnlRight.TabIndex = 1;
            // 
            // lblDataTitle
            // 
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDataTitle.Location = new System.Drawing.Point(23, 20);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(243, 30);
            this.lblDataTitle.TabIndex = 0;
            this.lblDataTitle.Text = "DANH SÁCH DỮ LIỆU";
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(58)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSoBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSoBao.ColumnHeadersHeight = 45;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSoBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSoBao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSoBao.Location = new System.Drawing.Point(23, 70);
            this.dgvSoBao.Name = "dgvSoBao";
            this.dgvSoBao.ReadOnly = true;
            this.dgvSoBao.RowHeadersVisible = false;
            this.dgvSoBao.RowTemplate.Height = 40;
            this.dgvSoBao.Size = new System.Drawing.Size(688, 588);
            this.dgvSoBao.TabIndex = 1;
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSoBao.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSoBao.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(58)))), ((int)(((byte)(90)))));
            this.dgvSoBao.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSoBao.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSoBao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSoBao.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            // FrmSoBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1084, 681);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FrmSoBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Kỳ Báo";
            this.Load += new System.EventHandler(this.FrmSoBao_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoBao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlLeft;
        private Guna.UI2.WinForms.Guna2Panel pnlRight;
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
        private Guna.UI2.WinForms.Guna2DataGridView dgvSoBao;
    }
}