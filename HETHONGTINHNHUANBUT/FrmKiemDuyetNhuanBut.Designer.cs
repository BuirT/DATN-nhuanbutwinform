namespace HETHONGTINHNHUANBUT
{
    partial class FrmKiemDuyetNhuanBut
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
            this.lblRoleInfo = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.btnTuChoi = new Guna.UI2.WinForms.Guna2Button();
            this.lblTien = new System.Windows.Forms.Label();
            this.txtTienNhuanBut = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvNhuanBut = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhuanBut)).BeginInit();
            this.SuspendLayout();

            // ==================== pnlTop ====================
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblRoleInfo);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnXacNhan);
            this.pnlTop.Controls.Add(this.btnTuChoi);
            this.pnlTop.Controls.Add(this.lblTien);
            this.pnlTop.Controls.Add(this.txtTienNhuanBut);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.ShadowDecoration.Enabled = true;
            this.pnlTop.Size = new System.Drawing.Size(1160, 150);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 28);
            this.lblTitle.Text = "KIỂM DUYỆT NHUẬN BÚT";

            // lblRoleInfo
            this.lblRoleInfo.AutoSize = true;
            this.lblRoleInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoleInfo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblRoleInfo.Location = new System.Drawing.Point(25, 55);
            this.lblRoleInfo.Name = "lblRoleInfo";
            this.lblRoleInfo.Size = new System.Drawing.Size(180, 20);
            this.lblRoleInfo.Text = "";

            // lblCount
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblCount.Location = new System.Drawing.Point(630, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(230, 28);
            this.lblCount.Text = "";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblTien
            this.lblTien.AutoSize = true;
            this.lblTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTien.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTien.Location = new System.Drawing.Point(25, 85);
            this.lblTien.Name = "lblTien";
            this.lblTien.Size = new System.Drawing.Size(99, 17);
            this.lblTien.Text = "Tiền nhuận bút";
            this.lblTien.Visible = false;

            // txtTienNhuanBut
            this.txtTienNhuanBut.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtTienNhuanBut.BorderRadius = 8;
            this.txtTienNhuanBut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTienNhuanBut.DefaultText = "0";
            this.txtTienNhuanBut.FocusedState.BorderColor = System.Drawing.Color.FromArgb(24, 119, 242);
            this.txtTienNhuanBut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTienNhuanBut.ForeColor = System.Drawing.Color.Crimson;
            this.txtTienNhuanBut.Location = new System.Drawing.Point(25, 107);
            this.txtTienNhuanBut.Name = "txtTienNhuanBut";
            this.txtTienNhuanBut.Size = new System.Drawing.Size(180, 36);
            this.txtTienNhuanBut.TabIndex = 2;
            this.txtTienNhuanBut.Visible = false;

            // btnXacNhan
            this.btnXacNhan.Animated = true;
            this.btnXacNhan.BorderRadius = 8;
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(880, 55);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(250, 42);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "✅ XÁC NHẬN DUYỆT";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            // btnTuChoi
            this.btnTuChoi.Animated = true;
            this.btnTuChoi.BorderRadius = 8;
            this.btnTuChoi.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Location = new System.Drawing.Point(880, 100);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(250, 42);
            this.btnTuChoi.TabIndex = 1;
            this.btnTuChoi.Text = "❌ TỪ CHỐI / TRẢ VỀ";
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);

            // ==================== pnlBottom ====================
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.BorderRadius = 16;
            this.pnlBottom.Controls.Add(this.lblDataTitle);
            this.pnlBottom.Controls.Add(this.txtTimKiem);
            this.pnlBottom.Controls.Add(this.dgvNhuanBut);
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(20, 180);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlBottom.ShadowDecoration.Depth = 8;
            this.pnlBottom.ShadowDecoration.Enabled = true;
            this.pnlBottom.Size = new System.Drawing.Size(1160, 600);
            this.pnlBottom.TabIndex = 3;

            // lblDataTitle
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDataTitle.Location = new System.Drawing.Point(25, 18);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(180, 21);
            this.lblDataTitle.Text = "DANH SÁCH BÀI VIẾT";

            // txtTimKiem
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(24, 119, 242);
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.Location = new System.Drawing.Point(885, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "🔍 Tìm kiếm...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 36);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            // dgvNhuanBut
            this.dgvNhuanBut.AllowUserToAddRows = false;
            this.dgvNhuanBut.AllowUserToDeleteRows = false;
            this.dgvNhuanBut.AllowUserToResizeColumns = false;
            this.dgvNhuanBut.AllowUserToResizeRows = false;
            this.dgvNhuanBut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNhuanBut.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhuanBut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNhuanBut.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNhuanBut.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNhuanBut.Location = new System.Drawing.Point(25, 60);
            this.dgvNhuanBut.MultiSelect = false;
            this.dgvNhuanBut.Name = "dgvNhuanBut";
            this.dgvNhuanBut.ReadOnly = true;
            this.dgvNhuanBut.RowHeadersVisible = false;
            this.dgvNhuanBut.RowTemplate.Height = 40;
            this.dgvNhuanBut.Size = new System.Drawing.Size(1110, 520);
            this.dgvNhuanBut.TabIndex = 2;
            this.dgvNhuanBut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhuanBut_CellClick);

            // ==================== Form ====================
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 254);
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmKiemDuyetNhuanBut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm duyệt nhuận bút";
            this.Load += new System.EventHandler(this.FrmKiemDuyetNhuanBut_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhuanBut)).EndInit();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRoleInfo;
        private System.Windows.Forms.Label lblCount;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2Button btnTuChoi;
        private System.Windows.Forms.Label lblTien;
        private Guna.UI2.WinForms.Guna2TextBox txtTienNhuanBut;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblDataTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNhuanBut;
    }
}
