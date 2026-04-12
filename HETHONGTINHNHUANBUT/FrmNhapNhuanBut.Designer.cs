namespace HETHONGTINHNHUANBUT
{
    partial class FrmNhapNhuanBut
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
            this.grpChonBao = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.cboSoBao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpNhapLieu = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenBai = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrang = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMuc = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboButDanh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTienNhuanBut = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.dgvNhuanBut = new Guna.UI2.WinForms.Guna2DataGridView();
            this.grpChonBao.SuspendLayout();
            this.grpNhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhuanBut)).BeginInit();
            this.SuspendLayout();
            // 
            // grpChonBao
            // 
            this.grpChonBao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChonBao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grpChonBao.BorderRadius = 8;
            this.grpChonBao.Controls.Add(this.lblTongTien);
            this.grpChonBao.Controls.Add(this.cboSoBao);
            this.grpChonBao.Controls.Add(this.label1);
            this.grpChonBao.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grpChonBao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpChonBao.ForeColor = System.Drawing.Color.White;
            this.grpChonBao.Location = new System.Drawing.Point(30, 20);
            this.grpChonBao.Name = "grpChonBao";
            this.grpChonBao.Size = new System.Drawing.Size(920, 100);
            this.grpChonBao.TabIndex = 0;
            this.grpChonBao.Text = "CHỌN SỐ BÁO ĐỂ NHẬP";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.BackColor = System.Drawing.Color.White;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Crimson;
            this.lblTongTien.Location = new System.Drawing.Point(624, 55);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(276, 25);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "TỔNG TIỀN ĐÃ CHẤM: 0 VNĐ";
            // 
            // cboSoBao
            // 
            this.cboSoBao.BackColor = System.Drawing.Color.Transparent;
            this.cboSoBao.BorderRadius = 5;
            this.cboSoBao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSoBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoBao.FocusedColor = System.Drawing.Color.Empty;
            this.cboSoBao.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cboSoBao.ForeColor = System.Drawing.Color.Black;
            this.cboSoBao.ItemHeight = 30;
            this.cboSoBao.Location = new System.Drawing.Point(130, 50);
            this.cboSoBao.Name = "cboSoBao";
            this.cboSoBao.Size = new System.Drawing.Size(488, 36);
            this.cboSoBao.TabIndex = 1;
            this.cboSoBao.SelectedIndexChanged += new System.EventHandler(this.cboSoBao_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kỳ xuất bản:";
            // 
            // grpNhapLieu
            // 
            this.grpNhapLieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNhapLieu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grpNhapLieu.BorderRadius = 8;
            this.grpNhapLieu.Controls.Add(this.label2);
            this.grpNhapLieu.Controls.Add(this.txtTenBai);
            this.grpNhapLieu.Controls.Add(this.label3);
            this.grpNhapLieu.Controls.Add(this.txtTrang);
            this.grpNhapLieu.Controls.Add(this.label4);
            this.grpNhapLieu.Controls.Add(this.txtMuc);
            this.grpNhapLieu.Controls.Add(this.label5);
            this.grpNhapLieu.Controls.Add(this.cboButDanh);
            this.grpNhapLieu.Controls.Add(this.label6);
            this.grpNhapLieu.Controls.Add(this.txtTienNhuanBut);
            this.grpNhapLieu.CustomBorderColor = System.Drawing.Color.MediumSeaGreen;
            this.grpNhapLieu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpNhapLieu.ForeColor = System.Drawing.Color.White;
            this.grpNhapLieu.Location = new System.Drawing.Point(30, 140);
            this.grpNhapLieu.Name = "grpNhapLieu";
            this.grpNhapLieu.Size = new System.Drawing.Size(920, 160);
            this.grpNhapLieu.TabIndex = 3;
            this.grpNhapLieu.Text = "THÔNG TIN CHI TIẾT BÀI VIẾT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên bài:";
            // 
            // txtTenBai
            // 
            this.txtTenBai.BorderRadius = 5;
            this.txtTenBai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBai.DefaultText = "";
            this.txtTenBai.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtTenBai.ForeColor = System.Drawing.Color.Black;
            this.txtTenBai.Location = new System.Drawing.Point(100, 55);
            this.txtTenBai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenBai.Name = "txtTenBai";
            this.txtTenBai.PlaceholderText = "";
            this.txtTenBai.SelectedText = "";
            this.txtTenBai.Size = new System.Drawing.Size(490, 36);
            this.txtTenBai.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(610, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trang:";
            // 
            // txtTrang
            // 
            this.txtTrang.BorderRadius = 5;
            this.txtTrang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTrang.DefaultText = "";
            this.txtTrang.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtTrang.ForeColor = System.Drawing.Color.Black;
            this.txtTrang.Location = new System.Drawing.Point(680, 55);
            this.txtTrang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrang.Name = "txtTrang";
            this.txtTrang.PlaceholderText = "";
            this.txtTrang.SelectedText = "";
            this.txtTrang.Size = new System.Drawing.Size(70, 36);
            this.txtTrang.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(765, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mục:";
            // 
            // txtMuc
            // 
            this.txtMuc.BorderRadius = 5;
            this.txtMuc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMuc.DefaultText = "";
            this.txtMuc.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtMuc.ForeColor = System.Drawing.Color.Black;
            this.txtMuc.Location = new System.Drawing.Point(820, 55);
            this.txtMuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMuc.Name = "txtMuc";
            this.txtMuc.PlaceholderText = "";
            this.txtMuc.SelectedText = "";
            this.txtMuc.Size = new System.Drawing.Size(80, 36);
            this.txtMuc.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bút danh:";
            // 
            // cboButDanh
            // 
            this.cboButDanh.BackColor = System.Drawing.Color.Transparent;
            this.cboButDanh.BorderRadius = 5;
            this.cboButDanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboButDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboButDanh.FocusedColor = System.Drawing.Color.Empty;
            this.cboButDanh.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cboButDanh.ForeColor = System.Drawing.Color.Black;
            this.cboButDanh.ItemHeight = 30;
            this.cboButDanh.Location = new System.Drawing.Point(110, 105);
            this.cboButDanh.Name = "cboButDanh";
            this.cboButDanh.Size = new System.Drawing.Size(250, 36);
            this.cboButDanh.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(380, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tiền nhuận bút:";
            // 
            // txtTienNhuanBut
            // 
            this.txtTienNhuanBut.BorderRadius = 5;
            this.txtTienNhuanBut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTienNhuanBut.DefaultText = "";
            this.txtTienNhuanBut.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtTienNhuanBut.ForeColor = System.Drawing.Color.Crimson;
            this.txtTienNhuanBut.Location = new System.Drawing.Point(520, 105);
            this.txtTienNhuanBut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTienNhuanBut.Name = "txtTienNhuanBut";
            this.txtTienNhuanBut.PlaceholderText = "";
            this.txtTienNhuanBut.SelectedText = "";
            this.txtTienNhuanBut.Size = new System.Drawing.Size(200, 36);
            this.txtTienNhuanBut.TabIndex = 9;
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 5;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(30, 320);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(140, 42);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm bài viết";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(190, 320);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(140, 42);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa bài viết";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 5;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FillColor = System.Drawing.Color.SlateGray;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(350, 320);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(140, 42);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "Làm mới";
            // 
            // dgvNhuanBut
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvNhuanBut.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNhuanBut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhuanBut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNhuanBut.ColumnHeadersHeight = 35;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhuanBut.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvNhuanBut.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhuanBut.Location = new System.Drawing.Point(30, 380);
            this.dgvNhuanBut.Name = "dgvNhuanBut";
            this.dgvNhuanBut.RowHeadersVisible = false;
            this.dgvNhuanBut.RowTemplate.Height = 30;
            this.dgvNhuanBut.Size = new System.Drawing.Size(920, 250);
            this.dgvNhuanBut.TabIndex = 13;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvNhuanBut.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanBut.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvNhuanBut.ThemeStyle.ReadOnly = false;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNhuanBut.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNhuanBut.ThemeStyle.RowsStyle.Height = 30;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhuanBut.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FrmNhapNhuanBut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(980, 660);
            this.Controls.Add(this.dgvNhuanBut);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpNhapLieu);
            this.Controls.Add(this.grpChonBao);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Name = "FrmNhapNhuanBut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập Nhuận Bút Tòa Soạn";
            this.Load += new System.EventHandler(this.FrmNhapNhuanBut_Load);
            this.grpChonBao.ResumeLayout(false);
            this.grpChonBao.PerformLayout();
            this.grpNhapLieu.ResumeLayout(false);
            this.grpNhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhuanBut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox grpChonBao;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboSoBao;
        private System.Windows.Forms.Label lblTongTien;
        private Guna.UI2.WinForms.Guna2GroupBox grpNhapLieu;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtTenBai;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtTrang;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtMuc;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cboButDanh;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtTienNhuanBut;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNhuanBut;
    }
}