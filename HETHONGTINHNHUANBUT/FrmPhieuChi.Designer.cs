namespace HETHONGTINHNHUANBUT
{
    partial class FrmPhieuChi
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

            this.lblTitle1 = new System.Windows.Forms.Label();
            this.txtLyDo = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelLyDo = new System.Windows.Forms.Label();
            this.txtMST = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelMST = new System.Windows.Forms.Label();
            this.txtDienThoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelSDT = new System.Windows.Forms.Label();
            this.txtCMND = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelCMND = new System.Windows.Forms.Label();
            this.txtNguoiNhan = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoPhieu = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTacGia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();

            this.dgvChuaThanhToan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();

            this.lblTitle2 = new System.Windows.Forms.Label();
            this.txtTienThue = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelThue = new System.Windows.Forms.Label();
            this.cboHinhThuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtThucLinh = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThueSuat = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();

            this.btnLapPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvChuaThanhToan)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(36)))), ((int)(((byte)(62)))));
            this.lblTitle1.Location = new System.Drawing.Point(30, 20);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(262, 30);
            this.lblTitle1.TabIndex = 0;
            this.lblTitle1.Text = "THÔNG TIN PHIẾU CHI";

            // 
            // cboTacGia (Bút danh)
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(36, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Bút danh:";

            this.cboTacGia.BorderRadius = 4;
            this.cboTacGia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTacGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTacGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTacGia.ItemHeight = 30;
            this.cboTacGia.Location = new System.Drawing.Point(36, 100);
            this.cboTacGia.Name = "cboTacGia";
            this.cboTacGia.Size = new System.Drawing.Size(250, 36);
            this.cboTacGia.TabIndex = 1;
            this.cboTacGia.SelectedIndexChanged += new System.EventHandler(this.cboTacGia_SelectedIndexChanged);

            // 
            // txtNguoiNhan
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(310, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tên người nhận (Được ủy quyền):";

            this.txtNguoiNhan.BorderRadius = 4;
            this.txtNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNguoiNhan.Location = new System.Drawing.Point(310, 100);
            this.txtNguoiNhan.Name = "txtNguoiNhan";
            this.txtNguoiNhan.Size = new System.Drawing.Size(280, 38);
            this.txtNguoiNhan.TabIndex = 5;

            // 
            // txtSoPhieu
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(620, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số phiếu:";

            this.txtSoPhieu.BorderRadius = 4;
            this.txtSoPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtSoPhieu.Location = new System.Drawing.Point(620, 100);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.ReadOnly = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(200, 38);
            this.txtSoPhieu.TabIndex = 3;

            // 
            // txtCMND
            // 
            this.labelCMND.AutoSize = true;
            this.labelCMND.ForeColor = System.Drawing.Color.Gray;
            this.labelCMND.Location = new System.Drawing.Point(36, 150);
            this.labelCMND.Name = "labelCMND";
            this.labelCMND.Size = new System.Drawing.Size(99, 19);
            this.labelCMND.TabIndex = 6;
            this.labelCMND.Text = "CMND/CCCD:";

            this.txtCMND.BorderRadius = 4;
            this.txtCMND.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCMND.Location = new System.Drawing.Point(36, 175);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(200, 38);
            this.txtCMND.TabIndex = 7;

            // 
            // txtDienThoai
            // 
            this.labelSDT.AutoSize = true;
            this.labelSDT.ForeColor = System.Drawing.Color.Gray;
            this.labelSDT.Location = new System.Drawing.Point(260, 150);
            this.labelSDT.Name = "labelSDT";
            this.labelSDT.Size = new System.Drawing.Size(81, 19);
            this.labelSDT.TabIndex = 8;
            this.labelSDT.Text = "Điện thoại:";

            this.txtDienThoai.BorderRadius = 4;
            this.txtDienThoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDienThoai.Location = new System.Drawing.Point(260, 175);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(200, 38);
            this.txtDienThoai.TabIndex = 9;

            // 
            // txtMST
            // 
            this.labelMST.AutoSize = true;
            this.labelMST.ForeColor = System.Drawing.Color.Gray;
            this.labelMST.Location = new System.Drawing.Point(480, 150);
            this.labelMST.Name = "labelMST";
            this.labelMST.Size = new System.Drawing.Size(89, 19);
            this.labelMST.TabIndex = 10;
            this.labelMST.Text = "Mã số thuế:";

            this.txtMST.BorderRadius = 4;
            this.txtMST.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMST.Location = new System.Drawing.Point(480, 175);
            this.txtMST.Name = "txtMST";
            this.txtMST.Size = new System.Drawing.Size(200, 38);
            this.txtMST.TabIndex = 11;

            // 
            // txtLyDo
            // 
            this.labelLyDo.AutoSize = true;
            this.labelLyDo.ForeColor = System.Drawing.Color.Gray;
            this.labelLyDo.Location = new System.Drawing.Point(700, 150);
            this.labelLyDo.Name = "labelLyDo";
            this.labelLyDo.Size = new System.Drawing.Size(49, 19);
            this.labelLyDo.TabIndex = 12;
            this.labelLyDo.Text = "Lý do:";

            this.txtLyDo.BorderRadius = 4;
            this.txtLyDo.DefaultText = "Chi trả nhuận bút";
            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLyDo.Location = new System.Drawing.Point(700, 175);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(240, 38);
            this.txtLyDo.TabIndex = 13;

            // 
            // dgvChuaThanhToan
            // 
            this.dgvChuaThanhToan.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvChuaThanhToan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChuaThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChuaThanhToan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChuaThanhToan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChuaThanhToan.ColumnHeadersHeight = 40;
            this.dgvChuaThanhToan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChuaThanhToan.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChuaThanhToan.Location = new System.Drawing.Point(36, 240);
            this.dgvChuaThanhToan.Name = "dgvChuaThanhToan";
            this.dgvChuaThanhToan.RowHeadersVisible = false;
            this.dgvChuaThanhToan.Size = new System.Drawing.Size(910, 310);
            this.dgvChuaThanhToan.TabIndex = 1;
            this.dgvChuaThanhToan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChuaThanhToan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.dgvChuaThanhToan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvChuaThanhToan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChuaThanhToan_CellValueChanged);
            this.dgvChuaThanhToan.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvChuaThanhToan_CurrentCellDirtyStateChanged);

            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "Chọn";
            this.colCheck.MinimumWidth = 6;
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 60;

            // 
            // lblTitle2
            // 
            this.lblTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(36)))), ((int)(((byte)(62)))));
            this.lblTitle2.Location = new System.Drawing.Point(30, 560);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(262, 30);
            this.lblTitle2.TabIndex = 14;
            this.lblTitle2.Text = "TÍNH TOÁN THANH TOÁN";

            // 
            // cboHinhThuc
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(36, 600);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Hình thức:";

            this.cboHinhThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboHinhThuc.BorderRadius = 4;
            this.cboHinhThuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboHinhThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHinhThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboHinhThuc.ItemHeight = 30;
            this.cboHinhThuc.Items.AddRange(new object[] { "Chuyển khoản (CK)", "Tiền mặt (TM)" });
            this.cboHinhThuc.Location = new System.Drawing.Point(36, 625);
            this.cboHinhThuc.Name = "cboHinhThuc";
            this.cboHinhThuc.Size = new System.Drawing.Size(200, 36);
            this.cboHinhThuc.TabIndex = 7;

            // 
            // txtTongTien
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(260, 600);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng tiền:";

            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTongTien.BorderRadius = 4;
            this.txtTongTien.DefaultText = "0";
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTongTien.Location = new System.Drawing.Point(260, 625);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(150, 38);
            this.txtTongTien.TabIndex = 1;

            // 
            // txtThueSuat
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(430, 600);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thuế %:";

            this.txtThueSuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtThueSuat.BorderRadius = 4;
            this.txtThueSuat.DefaultText = "10";
            this.txtThueSuat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtThueSuat.Location = new System.Drawing.Point(430, 625);
            this.txtThueSuat.Name = "txtThueSuat";
            this.txtThueSuat.Size = new System.Drawing.Size(80, 38);
            this.txtThueSuat.TabIndex = 3;
            this.txtThueSuat.TextChanged += new System.EventHandler(this.txtThueSuat_TextChanged);

            // 
            // txtTienThue
            // 
            this.labelThue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelThue.AutoSize = true;
            this.labelThue.ForeColor = System.Drawing.Color.Gray;
            this.labelThue.Location = new System.Drawing.Point(530, 600);
            this.labelThue.Name = "labelThue";
            this.labelThue.Size = new System.Drawing.Size(76, 19);
            this.labelThue.TabIndex = 8;
            this.labelThue.Text = "Tiền thuế:";

            this.txtTienThue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTienThue.BorderRadius = 4;
            this.txtTienThue.DefaultText = "0";
            this.txtTienThue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTienThue.Location = new System.Drawing.Point(530, 625);
            this.txtTienThue.Name = "txtTienThue";
            this.txtTienThue.ReadOnly = true;
            this.txtTienThue.Size = new System.Drawing.Size(150, 38);
            this.txtTienThue.TabIndex = 9;

            // 
            // txtThucLinh
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(700, 600);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thực lĩnh:";

            this.txtThucLinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtThucLinh.BorderRadius = 4;
            this.txtThucLinh.DefaultText = "0";
            this.txtThucLinh.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtThucLinh.ForeColor = System.Drawing.Color.Crimson;
            this.txtThucLinh.Location = new System.Drawing.Point(700, 625);
            this.txtThucLinh.Name = "txtThucLinh";
            this.txtThucLinh.ReadOnly = true;
            this.txtThucLinh.Size = new System.Drawing.Size(240, 38);
            this.txtThucLinh.TabIndex = 5;

            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLapPhieu.BorderRadius = 4;
            this.btnLapPhieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(109)))), ((int)(((byte)(228)))));
            this.btnLapPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieu.ForeColor = System.Drawing.Color.White;
            this.btnLapPhieu.Location = new System.Drawing.Point(36, 690);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(180, 42);
            this.btnLapPhieu.TabIndex = 3;
            this.btnLapPhieu.Text = "LẬP PHIẾU CHI";
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);

            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHuy.BorderRadius = 4;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(230)))), ((int)(((byte)(234)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnHuy.Location = new System.Drawing.Point(236, 690);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 42);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "HỦY BỎ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // 
            // FrmPhieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLapPhieu);
            this.Controls.Add(this.txtTienThue);
            this.Controls.Add(this.labelThue);
            this.Controls.Add(this.cboHinhThuc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtThucLinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtThueSuat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTitle2);
            this.Controls.Add(this.dgvChuaThanhToan);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.labelLyDo);
            this.Controls.Add(this.txtMST);
            this.Controls.Add(this.labelMST);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.labelSDT);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.labelCMND);
            this.Controls.Add(this.txtNguoiNhan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSoPhieu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTacGia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmPhieuChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lập Phiếu Chi Nhuận Bút";
            this.Load += new System.EventHandler(this.FrmPhieuChi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuaThanhToan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboTacGia;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtSoPhieu;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtNguoiNhan;
        private System.Windows.Forms.Label labelCMND;
        private Guna.UI2.WinForms.Guna2TextBox txtCMND;
        private System.Windows.Forms.Label labelSDT;
        private Guna.UI2.WinForms.Guna2TextBox txtDienThoai;
        private System.Windows.Forms.Label labelMST;
        private Guna.UI2.WinForms.Guna2TextBox txtMST;
        private System.Windows.Forms.Label labelLyDo;
        private Guna.UI2.WinForms.Guna2TextBox txtLyDo;

        private Guna.UI2.WinForms.Guna2DataGridView dgvChuaThanhToan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;

        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtTongTien;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtThueSuat;
        private System.Windows.Forms.Label labelThue;
        private Guna.UI2.WinForms.Guna2TextBox txtTienThue;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtThucLinh;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cboHinhThuc;

        private Guna.UI2.WinForms.Guna2Button btnLapPhieu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}