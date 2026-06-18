namespace HETHONGTINHNHUANBUT
{
    partial class FrmTraCuuNhuanBut
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
            this.lblMaSo = new System.Windows.Forms.Label();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.pnlDaNhan = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlChoChi = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDangCho = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvTraCuu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlDaNhan.SuspendLayout();
            this.pnlChoChi.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraCuu)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblMaSo);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.pnlDaNhan);
            this.pnlTop.Controls.Add(this.pnlChoChi);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.ShadowDecoration.Enabled = true;
            this.pnlTop.Size = new System.Drawing.Size(1160, 225);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TRUNG TÂM THU NHẬP";

            // lblMaSo
            this.lblMaSo.AutoSize = true;
            this.lblMaSo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaSo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblMaSo.Location = new System.Drawing.Point(25, 62);
            this.lblMaSo.Name = "lblMaSo";
            this.lblMaSo.Size = new System.Drawing.Size(0, 20);
            this.lblMaSo.TabIndex = 1;
            this.lblMaSo.Text = "";

            // btnRefresh
            this.btnRefresh.Animated = true;
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnRefresh.Location = new System.Drawing.Point(1010, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 LÀM MỚI";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlDaNhan
            this.pnlDaNhan.BackColor = System.Drawing.Color.Transparent;
            this.pnlDaNhan.BorderRadius = 15;
            this.pnlDaNhan.Controls.Add(this.lblTongTien);
            this.pnlDaNhan.Controls.Add(this.label1);
            this.pnlDaNhan.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.pnlDaNhan.Location = new System.Drawing.Point(25, 95);
            this.pnlDaNhan.Name = "pnlDaNhan";
            this.pnlDaNhan.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlDaNhan.ShadowDecoration.Depth = 8;
            this.pnlDaNhan.ShadowDecoration.Enabled = true;
            this.pnlDaNhan.Size = new System.Drawing.Size(380, 110);
            this.pnlDaNhan.TabIndex = 3;

            // lblTongTien
            this.lblTongTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.White;
            this.lblTongTien.Location = new System.Drawing.Point(15, 45);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(350, 50);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // label1
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐÃ QUYẾT TOÁN";

            // pnlChoChi
            this.pnlChoChi.BackColor = System.Drawing.Color.Transparent;
            this.pnlChoChi.BorderRadius = 15;
            this.pnlChoChi.Controls.Add(this.lblDangCho);
            this.pnlChoChi.Controls.Add(this.label2);
            this.pnlChoChi.FillColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.pnlChoChi.Location = new System.Drawing.Point(430, 95);
            this.pnlChoChi.Name = "pnlChoChi";
            this.pnlChoChi.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlChoChi.ShadowDecoration.Depth = 8;
            this.pnlChoChi.ShadowDecoration.Enabled = true;
            this.pnlChoChi.Size = new System.Drawing.Size(380, 110);
            this.pnlChoChi.TabIndex = 4;

            // lblDangCho
            this.lblDangCho.BackColor = System.Drawing.Color.Transparent;
            this.lblDangCho.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblDangCho.ForeColor = System.Drawing.Color.White;
            this.lblDangCho.Location = new System.Drawing.Point(15, 45);
            this.lblDangCho.Name = "lblDangCho";
            this.lblDangCho.Size = new System.Drawing.Size(350, 50);
            this.lblDangCho.TabIndex = 0;
            this.lblDangCho.Text = "0 VNĐ";
            this.lblDangCho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // label2
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ĐANG CHỜ XỬ LÝ";

            // pnlBottom
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.BorderRadius = 16;
            this.pnlBottom.Controls.Add(this.dgvTraCuu);
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(20, 255);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlBottom.ShadowDecoration.Depth = 8;
            this.pnlBottom.ShadowDecoration.Enabled = true;
            this.pnlBottom.Size = new System.Drawing.Size(1160, 475);

            // dgvTraCuu
            this.dgvTraCuu.AllowUserToAddRows = false;
            this.dgvTraCuu.AllowUserToDeleteRows = false;
            this.dgvTraCuu.AllowUserToResizeColumns = false;
            this.dgvTraCuu.AllowUserToResizeRows = false;
            this.dgvTraCuu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTraCuu.BackgroundColor = System.Drawing.Color.White;
            this.dgvTraCuu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTraCuu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTraCuu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTraCuu.ColumnHeadersHeight = 42;
            this.dgvTraCuu.Location = new System.Drawing.Point(25, 65);
            this.dgvTraCuu.Name = "dgvTraCuu";
            this.dgvTraCuu.ReadOnly = true;
            this.dgvTraCuu.RowHeadersVisible = false;
            this.dgvTraCuu.RowTemplate.Height = 38;
            this.dgvTraCuu.Size = new System.Drawing.Size(1110, 390);
            this.dgvTraCuu.TabIndex = 0;

            // FrmTraCuuNhuanBut
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 254);
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmTraCuuNhuanBut";
            this.Text = "Trung tâm thu nhập";
            this.Load += new System.EventHandler(this.FrmTraCuuNhuanBut_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlDaNhan.ResumeLayout(false);
            this.pnlChoChi.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraCuu)).EndInit();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaSo;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Panel pnlDaNhan;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel pnlChoChi;
        private System.Windows.Forms.Label lblDangCho;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTraCuu;
    }
}
