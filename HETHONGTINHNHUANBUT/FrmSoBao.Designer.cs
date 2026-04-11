namespace HETHONGTINHNHUANBUT
{
    partial class frmSoBao
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaso = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenBao = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpNgayRa = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtSoBao = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSoBo = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.dgvSoBao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.groupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoBao)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.BorderRadius = 8;
            this.groupBox1.Controls.Add(this.txtSoBo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSoBao);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpNgayRa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenBao);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaso);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.groupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(30, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.ShadowDecoration.BorderRadius = 8;
            this.groupBox1.Size = new System.Drawing.Size(920, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "THÔNG TIN SỐ BÁO / KỲ XUẤT BẢN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Mã số:";
            // 
            // txtMaso
            // 
            this.txtMaso.BorderRadius = 5;
            this.txtMaso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaso.DefaultText = "";
            this.txtMaso.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtMaso.ForeColor = System.Drawing.Color.Black;
            this.txtMaso.Location = new System.Drawing.Point(140, 65);
            this.txtMaso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaso.Name = "txtMaso";
            this.txtMaso.Size = new System.Drawing.Size(260, 36);
            this.txtMaso.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(460, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ngày xuất bản:";
            // 
            // dtpNgayRa
            // 
            this.dtpNgayRa.BackColor = System.Drawing.Color.White;
            this.dtpNgayRa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtpNgayRa.BorderRadius = 5;
            this.dtpNgayRa.BorderThickness = 1;
            this.dtpNgayRa.Checked = true;
            this.dtpNgayRa.FillColor = System.Drawing.Color.White;
            this.dtpNgayRa.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dtpNgayRa.ForeColor = System.Drawing.Color.Black;
            this.dtpNgayRa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayRa.Location = new System.Drawing.Point(580, 65);
            this.dtpNgayRa.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayRa.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayRa.Name = "dtpNgayRa";
            this.dtpNgayRa.Size = new System.Drawing.Size(300, 36);
            this.dtpNgayRa.TabIndex = 7;
            this.dtpNgayRa.Value = new System.DateTime(2026, 3, 13, 11, 39, 23, 635);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(30, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tên báo:";
            // 
            // txtTenBao
            // 
            this.txtTenBao.BorderRadius = 5;
            this.txtTenBao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBao.DefaultText = "";
            this.txtTenBao.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtTenBao.ForeColor = System.Drawing.Color.Black;
            this.txtTenBao.Location = new System.Drawing.Point(140, 125);
            this.txtTenBao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenBao.Name = "txtTenBao";
            this.txtTenBao.Size = new System.Drawing.Size(260, 36);
            this.txtTenBao.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(460, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ký hiệu (Số):";
            // 
            // txtSoBao
            // 
            this.txtSoBao.BorderRadius = 5;
            this.txtSoBao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoBao.DefaultText = "";
            this.txtSoBao.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtSoBao.ForeColor = System.Drawing.Color.Black;
            this.txtSoBao.Location = new System.Drawing.Point(580, 125);
            this.txtSoBao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoBao.Name = "txtSoBao";
            this.txtSoBao.Size = new System.Drawing.Size(300, 36);
            this.txtSoBao.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(30, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số lượng bộ:";
            // 
            // txtSoBo
            // 
            this.txtSoBo.BorderRadius = 5;
            this.txtSoBo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoBo.DefaultText = "";
            this.txtSoBo.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtSoBo.ForeColor = System.Drawing.Color.Black;
            this.txtSoBo.Location = new System.Drawing.Point(140, 185);
            this.txtSoBo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoBo.Name = "txtSoBo";
            this.txtSoBo.Size = new System.Drawing.Size(260, 36);
            this.txtSoBo.TabIndex = 9;
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 5;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(30, 280);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 42);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 5;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.FillColor = System.Drawing.Color.Orange;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(155, 280);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 42);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 5;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(280, 280);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 42);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu lại";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(405, 280);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 42);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 5;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FillColor = System.Drawing.Color.SlateGray;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(530, 280);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 42);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy bỏ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // dgvSoBao
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSoBao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSoBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSoBao.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSoBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSoBao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSoBao.Location = new System.Drawing.Point(30, 345);
            this.dgvSoBao.Name = "dgvSoBao";
            this.dgvSoBao.RowHeadersVisible = false;
            this.dgvSoBao.RowTemplate.Height = 30;
            this.dgvSoBao.Size = new System.Drawing.Size(920, 275);
            this.dgvSoBao.TabIndex = 0;
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dgvSoBao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSoBao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSoBao_CellClick);
            // 
            // frmSoBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(980, 650);
            this.Controls.Add(this.dgvSoBao);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Name = "frmSoBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Số Báo / Kỳ Xuất Bản";
            this.Load += new System.EventHandler(this.frmSoBao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoBao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtMaso;
        private Guna.UI2.WinForms.Guna2TextBox txtTenBao;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayRa;
        private Guna.UI2.WinForms.Guna2TextBox txtSoBao;
        private Guna.UI2.WinForms.Guna2TextBox txtSoBo;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSoBao;
        private Guna.UI2.WinForms.Guna2GroupBox groupBox1;
    }
}