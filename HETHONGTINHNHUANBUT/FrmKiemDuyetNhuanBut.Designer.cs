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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRoleInfo = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.btnTuChoi = new Guna.UI2.WinForms.Guna2Button();
            this.lblTien = new System.Windows.Forms.Label();
            this.txtTienNhuanBut = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvNhuanBut = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhuanBut)).BeginInit();
            this.SuspendLayout();

            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
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

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 28);
            this.lblTitle.Text = "KIỂM DUYỆT NHUẬN BÚT";

            this.lblRoleInfo.AutoSize = true;
            this.lblRoleInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoleInfo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblRoleInfo.Location = new System.Drawing.Point(25, 55);
            this.lblRoleInfo.Name = "lblRoleInfo";
            this.lblRoleInfo.Size = new System.Drawing.Size(180, 20);

            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblCount.Location = new System.Drawing.Point(25, 85);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(80, 20);

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

            // lblTien + txtTienNhuanBut (cho Kế toán nhập tiền)
            this.lblTien.AutoSize = true;
            this.lblTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTien.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTien.Location = new System.Drawing.Point(25, 100);
            this.lblTien.Name = "lblTien";
            this.lblTien.Size = new System.Drawing.Size(99, 17);
            this.lblTien.Text = "Tiền nhuận bút";

            this.txtTienNhuanBut.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtTienNhuanBut.BorderRadius = 8;
            this.txtTienNhuanBut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTienNhuanBut.DefaultText = "0";
            this.txtTienNhuanBut.FocusedState.BorderColor = System.Drawing.Color.FromArgb(24, 119, 242);
            this.txtTienNhuanBut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTienNhuanBut.ForeColor = System.Drawing.Color.Crimson;
            this.txtTienNhuanBut.Location = new System.Drawing.Point(25, 122);
            this.txtTienNhuanBut.Name = "txtTienNhuanBut";
            this.txtTienNhuanBut.Size = new System.Drawing.Size(180, 36);
            this.txtTienNhuanBut.TabIndex = 2;
            this.txtTienNhuanBut.Visible = false;
            this.lblTien.Visible = false;

            this.dgvNhuanBut.AllowUserToAddRows = false;
            this.dgvNhuanBut.AllowUserToDeleteRows = false;
            this.dgvNhuanBut.AllowUserToResizeColumns = false;
            this.dgvNhuanBut.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.dgvNhuanBut.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhuanBut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhuanBut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNhuanBut.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhuanBut.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNhuanBut.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvNhuanBut.Location = new System.Drawing.Point(20, 180);
            this.dgvNhuanBut.MultiSelect = false;
            this.dgvNhuanBut.Name = "dgvNhuanBut";
            this.dgvNhuanBut.ReadOnly = true;
            this.dgvNhuanBut.RowHeadersVisible = false;
            this.dgvNhuanBut.RowTemplate.Height = 38;
            this.dgvNhuanBut.Size = new System.Drawing.Size(1160, 600);
            this.dgvNhuanBut.TabIndex = 2;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvNhuanBut.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.dgvNhuanBut.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanBut.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNhuanBut.ThemeStyle.HeaderStyle.Height = 42;
            this.dgvNhuanBut.ThemeStyle.ReadOnly = true;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvNhuanBut.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvNhuanBut.ThemeStyle.RowsStyle.Height = 38;
            this.dgvNhuanBut.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvNhuanBut.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.dgvNhuanBut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhuanBut_CellClick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 254);
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.dgvNhuanBut);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmKiemDuyetNhuanBut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kiểm duyệt nhuận bút";
            this.Load += new System.EventHandler(this.FrmKiemDuyetNhuanBut_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
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
        private Guna.UI2.WinForms.Guna2DataGridView dgvNhuanBut;
    }
}
