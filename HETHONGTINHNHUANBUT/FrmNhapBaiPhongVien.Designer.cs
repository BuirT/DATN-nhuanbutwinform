namespace HETHONGTINHNHUANBUT
{
    partial class FrmNhapBaiPhongVien
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
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
            this.lblVung = new System.Windows.Forms.Label();
            this.cboVung = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblVungChuyenDen = new System.Windows.Forms.Label();
            this.cboVungChuyenDen = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnNopBai = new Guna.UI2.WinForms.Guna2Button();
            this.btnKiemToanAI = new Guna.UI2.WinForms.Guna2Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.dgvBaiCuaToi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiCuaToi)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
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
            this.pnlTop.Controls.Add(this.lblVung);
            this.pnlTop.Controls.Add(this.cboVung);
            this.pnlTop.Controls.Add(this.lblVungChuyenDen);
            this.pnlTop.Controls.Add(this.cboVungChuyenDen);
            this.pnlTop.Controls.Add(this.btnNopBai);
            this.pnlTop.Controls.Add(this.btnKiemToanAI);
            this.pnlTop.Controls.Add(this.lblWarning);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.ShadowDecoration.Enabled = false;
            this.pnlTop.Size = new System.Drawing.Size(1160, 520);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 28);
            this.lblTitle.Text = "NHẬP BÀI MỚI";

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label1.Location = new System.Drawing.Point(25, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.Text = "CHỌN SỐ BÁO";

            // cboSoBao
            this.cboSoBao.BackColor = System.Drawing.Color.Transparent;
            this.cboSoBao.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.cboSoBao.BorderRadius = 8;
            this.cboSoBao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSoBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoBao.FocusedColor = System.Drawing.Color.Empty;
            this.cboSoBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSoBao.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cboSoBao.ItemHeight = 30;
            this.cboSoBao.Location = new System.Drawing.Point(25, 87);
            this.cboSoBao.Name = "cboSoBao";
            this.cboSoBao.Size = new System.Drawing.Size(550, 36);
            this.cboSoBao.TabIndex = 0;

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label2.Location = new System.Drawing.Point(25, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.Text = "Tên bài";

            // txtTenBai
            this.txtTenBai.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtTenBai.BorderRadius = 8;
            this.txtTenBai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBai.DefaultText = "";
            this.txtTenBai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(24, 119, 242);
            this.txtTenBai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenBai.Location = new System.Drawing.Point(25, 167);
            this.txtTenBai.Name = "txtTenBai";
            this.txtTenBai.Size = new System.Drawing.Size(350, 36);
            this.txtTenBai.TabIndex = 1;

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label3.Location = new System.Drawing.Point(395, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.Text = "Trang";

            // txtTrang
            this.txtTrang.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtTrang.BorderRadius = 8;
            this.txtTrang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTrang.DefaultText = "";
            this.txtTrang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(24, 119, 242);
            this.txtTrang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTrang.Location = new System.Drawing.Point(395, 167);
            this.txtTrang.Name = "txtTrang";
            this.txtTrang.Size = new System.Drawing.Size(80, 36);
            this.txtTrang.TabIndex = 2;

            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label4.Location = new System.Drawing.Point(495, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.Text = "Mục";

            // txtMuc
            this.txtMuc.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtMuc.BorderRadius = 8;
            this.txtMuc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMuc.DefaultText = "";
            this.txtMuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(24, 119, 242);
            this.txtMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMuc.Location = new System.Drawing.Point(495, 167);
            this.txtMuc.Name = "txtMuc";
            this.txtMuc.Size = new System.Drawing.Size(80, 36);
            this.txtMuc.TabIndex = 3;

            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label5.Location = new System.Drawing.Point(595, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.Text = "Bút danh";

            // cboButDanh
            this.cboButDanh.BackColor = System.Drawing.Color.Transparent;
            this.cboButDanh.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.cboButDanh.BorderRadius = 8;
            this.cboButDanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboButDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboButDanh.FocusedColor = System.Drawing.Color.Empty;
            this.cboButDanh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboButDanh.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cboButDanh.ItemHeight = 30;
            this.cboButDanh.Location = new System.Drawing.Point(595, 167);
            this.cboButDanh.Name = "cboButDanh";
            this.cboButDanh.Size = new System.Drawing.Size(200, 36);
            this.cboButDanh.TabIndex = 4;

            // lblVung
            this.lblVung.AutoSize = true;
            this.lblVung.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVung.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblVung.Location = new System.Drawing.Point(815, 145);
            this.lblVung.Name = "lblVung";
            this.lblVung.Size = new System.Drawing.Size(108, 17);
            this.lblVung.Text = "Vùng phát hành";

            // cboVung
            this.cboVung.BackColor = System.Drawing.Color.Transparent;
            this.cboVung.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.cboVung.BorderRadius = 8;
            this.cboVung.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboVung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVung.FocusedColor = System.Drawing.Color.Empty;
            this.cboVung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVung.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cboVung.ItemHeight = 30;
            this.cboVung.Items.AddRange(new object[] { "HNI", "HCM", "DNG" });
            this.cboVung.Location = new System.Drawing.Point(815, 167);
            this.cboVung.Name = "cboVung";
            this.cboVung.Size = new System.Drawing.Size(150, 36);
            this.cboVung.TabIndex = 5;

            // lblVungChuyenDen
            this.lblVungChuyenDen.AutoSize = true;
            this.lblVungChuyenDen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVungChuyenDen.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblVungChuyenDen.Location = new System.Drawing.Point(985, 145);
            this.lblVungChuyenDen.Name = "lblVungChuyenDen";
            this.lblVungChuyenDen.Size = new System.Drawing.Size(148, 17);
            this.lblVungChuyenDen.Text = "Vùng chuyển (Tái bản)";

            // cboVungChuyenDen
            this.cboVungChuyenDen.BackColor = System.Drawing.Color.Transparent;
            this.cboVungChuyenDen.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.cboVungChuyenDen.BorderRadius = 8;
            this.cboVungChuyenDen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboVungChuyenDen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVungChuyenDen.FocusedColor = System.Drawing.Color.Empty;
            this.cboVungChuyenDen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVungChuyenDen.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cboVungChuyenDen.ItemHeight = 30;
            this.cboVungChuyenDen.Items.AddRange(new object[] { "Không có", "HNI", "HCM", "DNG" });
            this.cboVungChuyenDen.Location = new System.Drawing.Point(985, 167);
            this.cboVungChuyenDen.Name = "cboVungChuyenDen";
            this.cboVungChuyenDen.Size = new System.Drawing.Size(150, 36);
            this.cboVungChuyenDen.TabIndex = 6;

            // btnNopBai
            this.btnNopBai.Animated = false;
            this.btnNopBai.BorderRadius = 8;
            this.btnNopBai.FillColor = System.Drawing.Color.FromArgb(24, 119, 242);
            this.btnNopBai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNopBai.ForeColor = System.Drawing.Color.White;
            this.btnNopBai.Location = new System.Drawing.Point(25, 210);
            this.btnNopBai.Name = "btnNopBai";
            this.btnNopBai.Size = new System.Drawing.Size(140, 38);
            this.btnNopBai.TabIndex = 7;
            this.btnNopBai.Text = "📤 NỘP BÀI";
            this.btnNopBai.Click += new System.EventHandler(this.btnNopBai_Click);

            // btnKiemToanAI
            this.btnKiemToanAI.Animated = false;
            this.btnKiemToanAI.BorderRadius = 8;
            this.btnKiemToanAI.FillColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.btnKiemToanAI.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKiemToanAI.ForeColor = System.Drawing.Color.White;
            this.btnKiemToanAI.Location = new System.Drawing.Point(180, 210);
            this.btnKiemToanAI.Name = "btnKiemToanAI";
            this.btnKiemToanAI.Size = new System.Drawing.Size(150, 38);
            this.btnKiemToanAI.TabIndex = 8;
            this.btnKiemToanAI.Text = "📋 AI KIỂM TOÁN";
            this.btnKiemToanAI.Click += new System.EventHandler(this.btnKiemToanAI_Click);

            // lblWarning
            this.lblWarning.AutoSize = false;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblWarning.Location = new System.Drawing.Point(25, 460);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(1110, 50);
            this.lblWarning.Text = "";
            this.lblWarning.Visible = false;

            // pnlBottom
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.BorderRadius = 16;
            this.pnlBottom.Controls.Add(this.lblDataTitle);
            this.pnlBottom.Controls.Add(this.dgvBaiCuaToi);
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(20, 555);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlBottom.ShadowDecoration.Depth = 8;
            this.pnlBottom.ShadowDecoration.Enabled = false;
            this.pnlBottom.Size = new System.Drawing.Size(1160, 185);
            this.pnlBottom.TabIndex = 1;

            // lblDataTitle
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDataTitle.Location = new System.Drawing.Point(25, 18);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(195, 25);
            this.lblDataTitle.Text = "DANH SÁCH BÀI CỦA TÔI";

            // dgvBaiCuaToi
            this.dgvBaiCuaToi.AllowUserToAddRows = false;
            this.dgvBaiCuaToi.AllowUserToDeleteRows = false;
            this.dgvBaiCuaToi.AllowUserToResizeColumns = false;
            this.dgvBaiCuaToi.AllowUserToResizeRows = false;
            this.dgvBaiCuaToi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaiCuaToi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaiCuaToi.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaiCuaToi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBaiCuaToi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBaiCuaToi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            System.Windows.Forms.DataGridViewCellStyle dgvAlt = new System.Windows.Forms.DataGridViewCellStyle();
            dgvAlt.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dgvAlt.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgvAlt.SelectionBackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dgvAlt.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvBaiCuaToi.AlternatingRowsDefaultCellStyle = dgvAlt;
            System.Windows.Forms.DataGridViewCellStyle dgvHeader = new System.Windows.Forms.DataGridViewCellStyle();
            dgvHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeader.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvHeader.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            dgvHeader.SelectionBackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvHeader.SelectionForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            dgvHeader.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaiCuaToi.ColumnHeadersDefaultCellStyle = dgvHeader;
            this.dgvBaiCuaToi.ColumnHeadersHeight = 40;
            System.Windows.Forms.DataGridViewCellStyle dgvCell = new System.Windows.Forms.DataGridViewCellStyle();
            dgvCell.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCell.BackColor = System.Drawing.Color.White;
            dgvCell.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvCell.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgvCell.SelectionBackColor = System.Drawing.Color.FromArgb(232, 240, 254);
            dgvCell.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgvCell.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaiCuaToi.DefaultCellStyle = dgvCell;
            this.dgvBaiCuaToi.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvBaiCuaToi.Location = new System.Drawing.Point(25, 55);
            this.dgvBaiCuaToi.Name = "dgvBaiCuaToi";
            this.dgvBaiCuaToi.ReadOnly = true;
            this.dgvBaiCuaToi.RowHeadersVisible = false;
            this.dgvBaiCuaToi.RowTemplate.Height = 38;
            this.dgvBaiCuaToi.Size = new System.Drawing.Size(1110, 340);
            this.dgvBaiCuaToi.TabIndex = 0;

            // FrmNhapBaiPhongVien
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 254);
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmNhapBaiPhongVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập bài - Phóng viên";
            this.Load += new System.EventHandler(this.FrmNhapBaiPhongVien_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiCuaToi)).EndInit();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
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
        private System.Windows.Forms.Label lblVung;
        private Guna.UI2.WinForms.Guna2ComboBox cboVung;
        private System.Windows.Forms.Label lblVungChuyenDen;
        private Guna.UI2.WinForms.Guna2ComboBox cboVungChuyenDen;
        private Guna.UI2.WinForms.Guna2Button btnNopBai;
        private Guna.UI2.WinForms.Guna2Button btnKiemToanAI;
        private System.Windows.Forms.Label lblWarning;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblDataTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBaiCuaToi;
    }
}
