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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboSoBao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnChotSo = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtSoTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboButDanh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMuc = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTrang = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenBai = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaBai = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.dgvNhuanButCT = new Guna.UI2.WinForms.Guna2DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhuanButCT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Chọn Số Báo (Chưa chốt):";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(20, 75);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(122, 19);
            this.lblTongTien.TabIndex = 8;
            this.lblTongTien.Text = "Tổng quỹ: 0 VNĐ";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblTrangThai.Location = new System.Drawing.Point(680, 65);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(183, 19);
            this.lblTrangThai.TabIndex = 12;
            this.lblTrangThai.Text = "Trạng thái: ĐANG NHẬP LIỆU";
            // 
            // cboSoBao
            // 
            this.cboSoBao.BackColor = System.Drawing.Color.Transparent;
            this.cboSoBao.BorderRadius = 5;
            this.cboSoBao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSoBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoBao.FocusedColor = System.Drawing.Color.Empty;
            this.cboSoBao.Font = new System.Drawing.Font("VNI-Times", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSoBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSoBao.ItemHeight = 30;
            this.cboSoBao.Location = new System.Drawing.Point(260, 17);
            this.cboSoBao.Name = "cboSoBao";
            this.cboSoBao.Size = new System.Drawing.Size(400, 36);
            this.cboSoBao.TabIndex = 9;
            this.cboSoBao.SelectedIndexChanged += new System.EventHandler(this.cboSoBao_SelectedIndexChanged);
            // 
            // btnChotSo
            // 
            this.btnChotSo.BorderRadius = 5;
            this.btnChotSo.FillColor = System.Drawing.Color.Crimson;
            this.btnChotSo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChotSo.ForeColor = System.Drawing.Color.White;
            this.btnChotSo.Location = new System.Drawing.Point(680, 15);
            this.btnChotSo.Name = "btnChotSo";
            this.btnChotSo.Size = new System.Drawing.Size(200, 40);
            this.btnChotSo.TabIndex = 7;
            this.btnChotSo.Text = "🔒 KHÓA / CHỐT SỔ";
            this.btnChotSo.Click += new System.EventHandler(this.btnChotSo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSoTien);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboButDanh);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMuc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTrang);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenBai);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaBai);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.groupBox1.Location = new System.Drawing.Point(25, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 190);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.Text = "THÔNG TIN BÀI VIẾT";
            // 
            // txtSoTien
            // 
            this.txtSoTien.BorderRadius = 5;
            this.txtSoTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoTien.DefaultText = "";
            this.txtSoTien.Font = new System.Drawing.Font("VNI-Times", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTien.Location = new System.Drawing.Point(100, 147);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.PlaceholderText = "";
            this.txtSoTien.SelectedText = "";
            this.txtSoTien.Size = new System.Drawing.Size(200, 36);
            this.txtSoTien.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(20, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Số tiền:";
            // 
            // cboButDanh
            // 
            this.cboButDanh.BackColor = System.Drawing.Color.Transparent;
            this.cboButDanh.BorderRadius = 5;
            this.cboButDanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboButDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboButDanh.FocusedColor = System.Drawing.Color.Empty;
            this.cboButDanh.Font = new System.Drawing.Font("VNI-Times", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboButDanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboButDanh.ItemHeight = 30;
            this.cboButDanh.Location = new System.Drawing.Point(620, 97);
            this.cboButDanh.Name = "cboButDanh";
            this.cboButDanh.Size = new System.Drawing.Size(310, 36);
            this.cboButDanh.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(520, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Bút danh:";
            // 
            // txtMuc
            // 
            this.txtMuc.BorderRadius = 5;
            this.txtMuc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMuc.DefaultText = "";
            this.txtMuc.Font = new System.Drawing.Font("VNI-Times", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMuc.Location = new System.Drawing.Point(300, 97);
            this.txtMuc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMuc.Name = "txtMuc";
            this.txtMuc.PlaceholderText = "";
            this.txtMuc.SelectedText = "";
            this.txtMuc.Size = new System.Drawing.Size(200, 36);
            this.txtMuc.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(220, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mục:";
            // 
            // txtTrang
            // 
            this.txtTrang.BorderRadius = 5;
            this.txtTrang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTrang.DefaultText = "";
            this.txtTrang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTrang.Location = new System.Drawing.Point(100, 97);
            this.txtTrang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrang.Name = "txtTrang";
            this.txtTrang.PlaceholderText = "";
            this.txtTrang.SelectedText = "";
            this.txtTrang.Size = new System.Drawing.Size(100, 36);
            this.txtTrang.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trang:";
            // 
            // txtTenBai
            // 
            this.txtTenBai.BorderRadius = 5;
            this.txtTenBai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBai.DefaultText = "";
            this.txtTenBai.Font = new System.Drawing.Font("VNI-Times", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBai.Location = new System.Drawing.Point(300, 47);
            this.txtTenBai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenBai.Name = "txtTenBai";
            this.txtTenBai.PlaceholderText = "";
            this.txtTenBai.SelectedText = "";
            this.txtTenBai.Size = new System.Drawing.Size(630, 36);
            this.txtTenBai.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(220, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tên bài:";
            // 
            // txtMaBai
            // 
            this.txtMaBai.BorderRadius = 5;
            this.txtMaBai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaBai.DefaultText = "";
            this.txtMaBai.Font = new System.Drawing.Font("VNI-Times", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaBai.Location = new System.Drawing.Point(100, 47);
            this.txtMaBai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaBai.Name = "txtMaBai";
            this.txtMaBai.PlaceholderText = "";
            this.txtMaBai.ReadOnly = true;
            this.txtMaBai.SelectedText = "";
            this.txtMaBai.Size = new System.Drawing.Size(100, 36);
            this.txtMaBai.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mã bài:";
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 5;
            this.btnThem.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 320);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 45);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 5;
            this.btnSua.FillColor = System.Drawing.Color.Gold;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(145, 320);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 45);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 5;
            this.btnLuu.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(265, 320);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 45);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.FillColor = System.Drawing.Color.DarkOrange;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(385, 320);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 45);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 5;
            this.btnHuy.FillColor = System.Drawing.Color.DimGray;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(505, 320);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 45);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // dgvNhuanButCT
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvNhuanButCT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhuanButCT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNhuanButCT.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhuanButCT.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNhuanButCT.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhuanButCT.Location = new System.Drawing.Point(25, 380);
            this.dgvNhuanButCT.Name = "dgvNhuanButCT";
            this.dgvNhuanButCT.RowHeadersVisible = false;
            this.dgvNhuanButCT.RowHeadersWidth = 51;
            this.dgvNhuanButCT.Size = new System.Drawing.Size(950, 240);
            this.dgvNhuanButCT.TabIndex = 0;
            this.dgvNhuanButCT.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanButCT.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvNhuanButCT.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvNhuanButCT.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvNhuanButCT.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvNhuanButCT.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanButCT.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhuanButCT.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvNhuanButCT.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNhuanButCT.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.dgvNhuanButCT.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNhuanButCT.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNhuanButCT.ThemeStyle.HeaderStyle.Height = 29;
            this.dgvNhuanButCT.ThemeStyle.ReadOnly = false;
            this.dgvNhuanButCT.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanButCT.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNhuanButCT.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.dgvNhuanButCT.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNhuanButCT.ThemeStyle.RowsStyle.Height = 22;
            this.dgvNhuanButCT.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNhuanButCT.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNhuanButCT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhuanButCT_CellClick);
            // 
            // FrmNhapNhuanBut
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.dgvNhuanButCT);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnChotSo);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.cboSoBao);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.Name = "FrmNhapNhuanBut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập Nhuận Bút Bài Viết";
            this.Load += new System.EventHandler(this.FrmNhapNhuanBut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhuanButCT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2ComboBox cboSoBao;
        private Guna.UI2.WinForms.Guna2Button btnChotSo;
        private Guna.UI2.WinForms.Guna2GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtSoTien;
        private Guna.UI2.WinForms.Guna2ComboBox cboButDanh;
        private Guna.UI2.WinForms.Guna2TextBox txtMuc;
        private Guna.UI2.WinForms.Guna2TextBox txtTrang;
        private Guna.UI2.WinForms.Guna2TextBox txtTenBai;
        private Guna.UI2.WinForms.Guna2TextBox txtMaBai;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNhuanButCT;
    }
}