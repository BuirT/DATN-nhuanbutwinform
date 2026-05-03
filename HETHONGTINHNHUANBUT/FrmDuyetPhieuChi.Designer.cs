namespace HETHONGTINHNHUANBUT
{
    partial class FrmDuyetPhieuChi
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
            this.cboTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();

            this.dgvPhieuChi = new Guna.UI2.WinForms.Guna2DataGridView();

            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChiTietSoPhieu = new System.Windows.Forms.Label();
            this.lblChiTietTacGia = new System.Windows.Forms.Label();
            this.lblThucLinh = new System.Windows.Forms.Label();
            this.lblChiTietTien = new System.Windows.Forms.Label();

            this.lblLyDoTuChoi = new System.Windows.Forms.Label();
            this.txtLyDoTuChoi = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDuyet = new Guna.UI2.WinForms.Guna2Button();
            this.btnTuChoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChi)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.cboTrangThai);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 80);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(325, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LÃNH ĐẠO DUYỆT PHIẾU CHI";

            // cboTrangThai
            this.cboTrangThai.BorderRadius = 5;
            this.cboTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cboTrangThai.ItemHeight = 30;
            this.cboTrangThai.Items.AddRange(new object[] { "ĐANG CHỜ DUYỆT", "ĐÃ DUYỆT", "BỊ TỪ CHỐI" });
            this.cboTrangThai.Location = new System.Drawing.Point(400, 20);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(220, 36);
            this.cboTrangThai.TabIndex = 1;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);

            // txtTimKiem
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderRadius = 5;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(850, 20);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "🔍 Tìm kiếm số phiếu, tác giả...";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 36);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            // dgvPhieuChi
            this.dgvPhieuChi.AllowUserToAddRows = false;
            this.dgvPhieuChi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPhieuChi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhieuChi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhieuChi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(36)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuChi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhieuChi.ColumnHeadersHeight = 45;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPhieuChi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhieuChi.Location = new System.Drawing.Point(20, 100);
            this.dgvPhieuChi.Name = "dgvPhieuChi";
            this.dgvPhieuChi.ReadOnly = true;
            this.dgvPhieuChi.RowHeadersVisible = false;
            this.dgvPhieuChi.RowTemplate.Height = 40;
            this.dgvPhieuChi.Size = new System.Drawing.Size(1130, 460);
            this.dgvPhieuChi.TabIndex = 1;
            this.dgvPhieuChi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPhieuChi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(36)))), ((int)(((byte)(62)))));
            this.dgvPhieuChi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPhieuChi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuChi_CellClick);

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.lblChiTietSoPhieu);
            this.pnlBottom.Controls.Add(this.lblChiTietTacGia);
            this.pnlBottom.Controls.Add(this.lblThucLinh);
            this.pnlBottom.Controls.Add(this.lblChiTietTien);
            this.pnlBottom.Controls.Add(this.lblLyDoTuChoi);
            this.pnlBottom.Controls.Add(this.txtLyDoTuChoi);
            this.pnlBottom.Controls.Add(this.btnXoa);
            this.pnlBottom.Controls.Add(this.btnDuyet);
            this.pnlBottom.Controls.Add(this.btnTuChoi);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 580);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1200, 170);
            this.pnlBottom.TabIndex = 2;

            // lblChiTietSoPhieu
            this.lblChiTietSoPhieu.AutoSize = true;
            this.lblChiTietSoPhieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChiTietSoPhieu.Location = new System.Drawing.Point(30, 20);
            this.lblChiTietSoPhieu.Name = "lblChiTietSoPhieu";
            this.lblChiTietSoPhieu.Size = new System.Drawing.Size(111, 21);
            this.lblChiTietSoPhieu.TabIndex = 0;
            this.lblChiTietSoPhieu.Text = "Số phiếu: ---";

            // lblChiTietTacGia
            this.lblChiTietTacGia.AutoSize = true;
            this.lblChiTietTacGia.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblChiTietTacGia.Location = new System.Drawing.Point(30, 55);
            this.lblChiTietTacGia.Name = "lblChiTietTacGia";
            this.lblChiTietTacGia.Size = new System.Drawing.Size(155, 21);
            this.lblChiTietTacGia.TabIndex = 1;
            this.lblChiTietTacGia.Text = "Thanh toán cho: ---";

            // lblThucLinh
            this.lblThucLinh.AutoSize = true;
            this.lblThucLinh.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblThucLinh.Location = new System.Drawing.Point(30, 90);
            this.lblThucLinh.Name = "lblThucLinh";
            this.lblThucLinh.Size = new System.Drawing.Size(116, 21);
            this.lblThucLinh.TabIndex = 2;
            this.lblThucLinh.Text = "Tiền Thực lĩnh:";

            // lblChiTietTien
            this.lblChiTietTien.AutoSize = true;
            this.lblChiTietTien.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblChiTietTien.ForeColor = System.Drawing.Color.Crimson;
            this.lblChiTietTien.Location = new System.Drawing.Point(30, 115);
            this.lblChiTietTien.Name = "lblChiTietTien";
            this.lblChiTietTien.Size = new System.Drawing.Size(95, 37);
            this.lblChiTietTien.TabIndex = 3;
            this.lblChiTietTien.Text = "0 VNĐ";

            // lblLyDoTuChoi
            this.lblLyDoTuChoi.AutoSize = true;
            this.lblLyDoTuChoi.ForeColor = System.Drawing.Color.Gray;
            this.lblLyDoTuChoi.Location = new System.Drawing.Point(350, 20);
            this.lblLyDoTuChoi.Name = "lblLyDoTuChoi";
            this.lblLyDoTuChoi.Size = new System.Drawing.Size(193, 19);
            this.lblLyDoTuChoi.TabIndex = 4;
            this.lblLyDoTuChoi.Text = "Lý do phiếu / Lý do từ chối:";

            // txtLyDoTuChoi
            this.txtLyDoTuChoi.BorderRadius = 5;
            this.txtLyDoTuChoi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLyDoTuChoi.DefaultText = "";
            this.txtLyDoTuChoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLyDoTuChoi.Location = new System.Drawing.Point(350, 45);
            this.txtLyDoTuChoi.Multiline = true;
            this.txtLyDoTuChoi.Name = "txtLyDoTuChoi";
            this.txtLyDoTuChoi.Size = new System.Drawing.Size(350, 100);
            this.txtLyDoTuChoi.TabIndex = 5;

            // btnXoa - ĐÃ CĂN CHỈNH CAO BẰNG CÁC NÚT KHÁC
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.FillColor = System.Drawing.Color.White;
            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68))))); // Đỏ
            this.btnXoa.BorderThickness = 1;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.Location = new System.Drawing.Point(720, 45);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 100);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "XÓA\nPHIẾU";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnDuyet
            this.btnDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuyet.BorderRadius = 5;
            this.btnDuyet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.Location = new System.Drawing.Point(850, 45);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(140, 100);
            this.btnDuyet.TabIndex = 6;
            this.btnDuyet.Text = "ĐỒNG Ý\r\nDUYỆT CHI";
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);

            // btnTuChoi
            this.btnTuChoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTuChoi.BorderRadius = 5;
            this.btnTuChoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Location = new System.Drawing.Point(1010, 45);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(140, 100);
            this.btnTuChoi.TabIndex = 7;
            this.btnTuChoi.Text = "TỪ CHỐI\r\n(TRẢ LẠI)";
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);

            // FrmDuyetPhieuChi
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.dgvPhieuChi);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmDuyetPhieuChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lãnh Đạo Duyệt Phiếu Chi";
            this.Load += new System.EventHandler(this.FrmDuyetPhieuChi_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChi)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangThai;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPhieuChi;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblChiTietSoPhieu;
        private System.Windows.Forms.Label lblChiTietTacGia;
        private System.Windows.Forms.Label lblThucLinh;
        private System.Windows.Forms.Label lblChiTietTien;
        private System.Windows.Forms.Label lblLyDoTuChoi;
        private Guna.UI2.WinForms.Guna2TextBox txtLyDoTuChoi;
        private Guna.UI2.WinForms.Guna2Button btnDuyet;
        private Guna.UI2.WinForms.Guna2Button btnTuChoi;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
    }
}