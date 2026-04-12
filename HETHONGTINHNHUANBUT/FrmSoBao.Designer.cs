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
            this.groupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cboLoaiBao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoBo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoBao = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayRa = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenBao = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaso = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.dgvSoBao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoBao)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1 (KHUNG NHẬP LIỆU - TỰ GIÃN NGANG)
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BorderRadius = 5;
            this.groupBox1.Controls.Add(this.cboLoaiBao);
            this.groupBox1.Controls.Add(this.label6);
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
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(30, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "THÔNG TIN KỲ XUẤT BẢN";
            // 
            // cboLoaiBao
            // 
            this.cboLoaiBao.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiBao.BorderRadius = 5;
            this.cboLoaiBao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiBao.ForeColor = System.Drawing.Color.Black;
            this.cboLoaiBao.ItemHeight = 30;
            this.cboLoaiBao.Items.AddRange(new object[] {
            "Báo in",
            "Báo điện tử",
            "Tạp chí"});
            this.cboLoaiBao.Location = new System.Drawing.Point(560, 108);
            this.cboLoaiBao.Name = "cboLoaiBao";
            this.cboLoaiBao.Size = new System.Drawing.Size(200, 36);
            this.cboLoaiBao.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(470, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Loại báo:";
            // 
            // txtSoBo
            // 
            this.txtSoBo.BorderRadius = 5;
            this.txtSoBo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoBo.DefaultText = "";
            this.txtSoBo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoBo.ForeColor = System.Drawing.Color.Black;
            this.txtSoBo.Location = new System.Drawing.Point(320, 108);
            this.txtSoBo.Name = "txtSoBo";
            this.txtSoBo.Size = new System.Drawing.Size(120, 36);
            this.txtSoBo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(240, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số bộ:";
            // 
            // txtSoBao
            // 
            this.txtSoBao.BorderRadius = 5;
            this.txtSoBao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoBao.DefaultText = "";
            this.txtSoBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoBao.ForeColor = System.Drawing.Color.Black;
            this.txtSoBao.Location = new System.Drawing.Point(100, 108);
            this.txtSoBao.Name = "txtSoBao";
            this.txtSoBao.Size = new System.Drawing.Size(120, 36);
            this.txtSoBao.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số báo:";
            // 
            // dtpNgayRa
            // 
            this.dtpNgayRa.BorderRadius = 5;
            this.dtpNgayRa.Checked = true;
            this.dtpNgayRa.FillColor = System.Drawing.Color.White;
            this.dtpNgayRa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayRa.ForeColor = System.Drawing.Color.Black;
            this.dtpNgayRa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayRa.Location = new System.Drawing.Point(740, 53);
            this.dtpNgayRa.Name = "dtpNgayRa";
            this.dtpNgayRa.Size = new System.Drawing.Size(160, 36);
            this.dtpNgayRa.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(660, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày ra:";
            // 
            // txtTenBao
            // 
            this.txtTenBao.BorderRadius = 5;
            this.txtTenBao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBao.DefaultText = "";
            this.txtTenBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenBao.ForeColor = System.Drawing.Color.Black;
            this.txtTenBao.Location = new System.Drawing.Point(320, 53);
            this.txtTenBao.Name = "txtTenBao";
            this.txtTenBao.Size = new System.Drawing.Size(320, 36);
            this.txtTenBao.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(240, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên báo:";
            // 
            // txtMaso
            // 
            this.txtMaso.BorderRadius = 5;
            this.txtMaso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaso.DefaultText = "";
            this.txtMaso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaso.ForeColor = System.Drawing.Color.Black;
            this.txtMaso.Location = new System.Drawing.Point(100, 53);
            this.txtMaso.Name = "txtMaso";
            this.txtMaso.Size = new System.Drawing.Size(120, 36);
            this.txtMaso.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã số:";
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 5;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(30, 210);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 42);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "THÊM";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 5;
            this.btnSua.FillColor = System.Drawing.Color.Orange;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(165, 210);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 42);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "SỬA";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(300, 210);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 42);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 5;
            this.btnLamMoi.FillColor = System.Drawing.Color.SlateGray;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(435, 210);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 42);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvSoBao (BẢNG DỮ LIỆU - CO GIÃN 4 CHIỀU)
            // 
            this.dgvSoBao.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSoBao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSoBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSoBao.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSoBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSoBao.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSoBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSoBao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSoBao.Location = new System.Drawing.Point(30, 270);
            this.dgvSoBao.Name = "dgvSoBao";
            this.dgvSoBao.RowHeadersVisible = false;
            this.dgvSoBao.Size = new System.Drawing.Size(920, 360);
            this.dgvSoBao.TabIndex = 5;
            this.dgvSoBao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSoBao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSoBao_CellClick);
            // 
            // FrmSoBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(980, 660);
            this.Controls.Add(this.dgvSoBao);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmSoBao";
            this.Text = "Quản Lý Kỳ Báo";
            this.Load += new System.EventHandler(this.FrmSoBao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoBao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtMaso;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtTenBao;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayRa;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtSoBao;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtSoBo;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiBao;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSoBao;
    }
}