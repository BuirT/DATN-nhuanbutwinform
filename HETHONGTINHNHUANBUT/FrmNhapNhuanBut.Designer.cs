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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();

            this.label1 = new System.Windows.Forms.Label();
            this.cboSoBao = new Guna.UI2.WinForms.Guna2ComboBox();

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

            // --- THÊM 2 TRƯỜNG VÙNG ---
            this.lblVung = new System.Windows.Forms.Label();
            this.cboVung = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblVungChuyenDen = new System.Windows.Forms.Label();
            this.cboVungChuyenDen = new Guna.UI2.WinForms.Guna2ComboBox();

            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();

            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvNhuanBut = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblDataTitle = new System.Windows.Forms.Label();

            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhuanBut)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblTongTien);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.cboSoBao);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.txtTenBai);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.txtTrang);
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.txtMuc);
            this.pnlTop.Controls.Add(this.label5);
            this.pnlTop.Controls.Add(this.cboButDanh);
            this.pnlTop.Controls.Add(this.label6);
            this.pnlTop.Controls.Add(this.txtTienNhuanBut);

            // Add UI Vùng
            this.pnlTop.Controls.Add(this.lblVung);
            this.pnlTop.Controls.Add(this.cboVung);
            this.pnlTop.Controls.Add(this.lblVungChuyenDen);
            this.pnlTop.Controls.Add(this.cboVungChuyenDen);

            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnXoa);
            this.pnlTop.Controls.Add(this.btnLamMoi);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 310);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "NHẬP NHUẬN BÚT";

            // lblTongTien
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Crimson;
            this.lblTongTien.Location = new System.Drawing.Point(850, 15);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(320, 30);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "TỔNG TIỀN ĐÃ CHẤM: 0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // DÒNG 1: Chọn Số Báo
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(30, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "CHỌN SỐ BÁO ĐỂ NHẬP";

            this.cboSoBao.BorderRadius = 5;
            this.cboSoBao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSoBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSoBao.ItemHeight = 30;
            this.cboSoBao.Location = new System.Drawing.Point(30, 80);
            this.cboSoBao.Name = "cboSoBao";
            this.cboSoBao.Size = new System.Drawing.Size(500, 36);
            this.cboSoBao.TabIndex = 4;

            // --- ĐÃ CHỈNH SỬA LẠI TỌA ĐỘ DÒNG 2 ĐỂ KHÔNG BỊ MẤT CHỮ ---
            // Tên bài (Mở rộng ra một chút)
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(30, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên bài";

            this.txtTenBai.BorderRadius = 5;
            this.txtTenBai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenBai.Location = new System.Drawing.Point(30, 150);
            this.txtTenBai.Name = "txtTenBai";
            this.txtTenBai.Size = new System.Drawing.Size(350, 36);
            this.txtTenBai.TabIndex = 6;

            // Trang (Đẩy X ra xa Tên bài một chút, nới rộng Size)
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(400, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trang";

            this.txtTrang.BorderRadius = 5;
            this.txtTrang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTrang.Location = new System.Drawing.Point(400, 150);
            this.txtTrang.Name = "txtTrang";
            this.txtTrang.Size = new System.Drawing.Size(80, 36);
            this.txtTrang.TabIndex = 8;

            // Mục (Đẩy X ra xa Trang, nới rộng Size)
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(500, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mục";

            this.txtMuc.BorderRadius = 5;
            this.txtMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMuc.Location = new System.Drawing.Point(500, 150);
            this.txtMuc.Name = "txtMuc";
            this.txtMuc.Size = new System.Drawing.Size(80, 36);
            this.txtMuc.TabIndex = 10;

            // Bút danh (Đẩy X ra xa Mục)
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(600, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Bút danh";

            this.cboButDanh.BorderRadius = 5;
            this.cboButDanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboButDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboButDanh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboButDanh.ItemHeight = 30;
            this.cboButDanh.Location = new System.Drawing.Point(600, 150);
            this.cboButDanh.Name = "cboButDanh";
            this.cboButDanh.Size = new System.Drawing.Size(220, 36);
            this.cboButDanh.TabIndex = 12;

            // Tiền nhuận bút (Đẩy X ra góc phải)
            this.label6.ForeColor = System.Drawing.Color.Crimson;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(840, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tiền nhuận bút";

            this.txtTienNhuanBut.BorderRadius = 5;
            this.txtTienNhuanBut.ForeColor = System.Drawing.Color.Crimson;
            this.txtTienNhuanBut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTienNhuanBut.Location = new System.Drawing.Point(840, 150);
            this.txtTienNhuanBut.Name = "txtTienNhuanBut";
            this.txtTienNhuanBut.Size = new System.Drawing.Size(180, 36);
            this.txtTienNhuanBut.TabIndex = 14;

            // --- DÒNG 3: VÙNG ---
            this.lblVung.ForeColor = System.Drawing.Color.Gray;
            this.lblVung.Location = new System.Drawing.Point(30, 200);
            this.lblVung.Name = "lblVung";
            this.lblVung.Size = new System.Drawing.Size(150, 20);
            this.lblVung.TabIndex = 15;
            this.lblVung.Text = "Vùng phát hành";

            this.cboVung.BorderRadius = 5;
            this.cboVung.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboVung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVung.ItemHeight = 30;
            this.cboVung.Items.AddRange(new object[] { "HNI", "HCM", "DNG" });
            this.cboVung.Location = new System.Drawing.Point(30, 220);
            this.cboVung.Name = "cboVung";
            this.cboVung.Size = new System.Drawing.Size(150, 36);
            this.cboVung.TabIndex = 16;

            this.lblVungChuyenDen.ForeColor = System.Drawing.Color.Gray;
            this.lblVungChuyenDen.Location = new System.Drawing.Point(200, 200);
            this.lblVungChuyenDen.Name = "lblVungChuyenDen";
            this.lblVungChuyenDen.Size = new System.Drawing.Size(180, 20);
            this.lblVungChuyenDen.TabIndex = 17;
            this.lblVungChuyenDen.Text = "Vùng chuyển đến (Tái bản)";

            this.cboVungChuyenDen.BorderRadius = 5;
            this.cboVungChuyenDen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboVungChuyenDen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVungChuyenDen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVungChuyenDen.ItemHeight = 30;
            this.cboVungChuyenDen.Items.AddRange(new object[] { "Không có", "HNI", "HCM", "DNG" });
            this.cboVungChuyenDen.Location = new System.Drawing.Point(200, 220);
            this.cboVungChuyenDen.Name = "cboVungChuyenDen";
            this.cboVungChuyenDen.Size = new System.Drawing.Size(180, 36);
            this.cboVungChuyenDen.TabIndex = 18;

            // NÚT BẤM (HÀNG DƯỚI CÙNG PNL TOP)
            this.btnThem.BorderRadius = 5;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(30, 270);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 35);
            this.btnThem.TabIndex = 19;
            this.btnThem.Text = "LƯU DỮ LIỆU";

            this.btnSua.BorderRadius = 5;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(170, 270);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 35);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "CẬP NHẬT";
            this.btnSua.Visible = false;

            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.BorderThickness = 1;
            this.btnXoa.FillColor = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.Location = new System.Drawing.Point(170, 270);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 35);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "XÓA BÀI";

            this.btnLamMoi.BorderRadius = 5;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLamMoi.Location = new System.Drawing.Point(310, 270);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 35);
            this.btnLamMoi.TabIndex = 22;
            this.btnLamMoi.Text = "LÀM MỚI";

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.Controls.Add(this.lblDataTitle);
            this.pnlBottom.Controls.Add(this.dgvNhuanBut);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 310);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1200, 440);
            this.pnlBottom.TabIndex = 23;

            // lblDataTitle
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.Location = new System.Drawing.Point(20, 15);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(262, 30);
            this.lblDataTitle.TabIndex = 0;
            this.lblDataTitle.Text = "DANH SÁCH BÀI ĐÃ NHẬP";

            // dgvNhuanBut
            this.dgvNhuanBut.AllowUserToAddRows = false;
            this.dgvNhuanBut.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvNhuanBut.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhuanBut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(58)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhuanBut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNhuanBut.ColumnHeadersHeight = 45;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNhuanBut.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNhuanBut.Location = new System.Drawing.Point(30, 60);
            this.dgvNhuanBut.Name = "dgvNhuanBut";
            this.dgvNhuanBut.ReadOnly = true;
            this.dgvNhuanBut.RowHeadersVisible = false;
            this.dgvNhuanBut.RowTemplate.Height = 40;
            this.dgvNhuanBut.Size = new System.Drawing.Size(1130, 350);
            this.dgvNhuanBut.TabIndex = 2;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvNhuanBut.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanBut.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(58)))), ((int)(((byte)(90)))));
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.Height = 45;
            this.dgvNhuanBut.ThemeStyle.ReadOnly = true;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvNhuanBut.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNhuanBut.ThemeStyle.RowsStyle.Height = 40;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhuanBut.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));

            // Events
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.dgvNhuanBut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhuanBut_CellClick);

            // FrmNhapNhuanBut
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmNhapNhuanBut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập Nhuận Bút Tòa Soạn";
            this.Load += new System.EventHandler(this.FrmNhapNhuanBut_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhuanBut)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboSoBao;
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

        private System.Windows.Forms.Label lblVung;
        private Guna.UI2.WinForms.Guna2ComboBox cboVung;
        private System.Windows.Forms.Label lblVungChuyenDen;
        private Guna.UI2.WinForms.Guna2ComboBox cboVungChuyenDen;

        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private System.Windows.Forms.Label lblDataTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNhuanBut;
    }
}