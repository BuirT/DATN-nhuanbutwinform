namespace HETHONGTINHNHUANBUT
{
    partial class FrmBaoCaoTongHop
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlTongQuy = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongQuy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDaChi = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDaChi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlChoChi = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChoChi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTopPV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlTongQuy.SuspendLayout(); this.pnlDaChi.SuspendLayout(); this.pnlChoChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopPV)).BeginInit();
            this.SuspendLayout();

            // Card 1: Tổng Quỹ (Màu Xanh Dương)
            this.pnlTongQuy.BorderRadius = 15; this.pnlTongQuy.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.pnlTongQuy.Location = new System.Drawing.Point(40, 30); this.pnlTongQuy.Size = new System.Drawing.Size(320, 130);
            this.pnlTongQuy.Controls.Add(this.lblTongQuy); this.pnlTongQuy.Controls.Add(this.label1);
            this.label1.AutoSize = true; this.label1.BackColor = System.Drawing.Color.Transparent; this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold); this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 15); this.label1.Text = "TỔNG QUỸ NHUẬN BÚT";
            this.lblTongQuy.AutoSize = true; this.lblTongQuy.BackColor = System.Drawing.Color.Transparent; this.lblTongQuy.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold); this.lblTongQuy.ForeColor = System.Drawing.Color.White;
            this.lblTongQuy.Location = new System.Drawing.Point(15, 55); this.lblTongQuy.Text = "0 đ";

            // Card 2: Đã Chi (Màu Xanh Lá)
            this.pnlDaChi.BorderRadius = 15; this.pnlDaChi.FillColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.pnlDaChi.Location = new System.Drawing.Point(390, 30); this.pnlDaChi.Size = new System.Drawing.Size(320, 130);
            this.pnlDaChi.Controls.Add(this.lblDaChi); this.pnlDaChi.Controls.Add(this.label3);
            this.label3.AutoSize = true; this.label3.BackColor = System.Drawing.Color.Transparent; this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold); this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 15); this.label3.Text = "TIỀN ĐÃ CHI TRẢ";
            this.lblDaChi.AutoSize = true; this.lblDaChi.BackColor = System.Drawing.Color.Transparent; this.lblDaChi.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold); this.lblDaChi.ForeColor = System.Drawing.Color.White;
            this.lblDaChi.Location = new System.Drawing.Point(15, 55); this.lblDaChi.Text = "0 đ";

            // Card 3: Chờ Chi (Màu Cam)
            this.pnlChoChi.BorderRadius = 15; this.pnlChoChi.FillColor = System.Drawing.Color.FromArgb(255, 159, 67);
            this.pnlChoChi.Location = new System.Drawing.Point(740, 30); this.pnlChoChi.Size = new System.Drawing.Size(320, 130);
            this.pnlChoChi.Controls.Add(this.lblChoChi); this.pnlChoChi.Controls.Add(this.label5);
            this.label5.AutoSize = true; this.label5.BackColor = System.Drawing.Color.Transparent; this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold); this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 15); this.label5.Text = "TIỀN CHỜ CHI TRẢ";
            this.lblChoChi.AutoSize = true; this.lblChoChi.BackColor = System.Drawing.Color.Transparent; this.lblChoChi.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold); this.lblChoChi.ForeColor = System.Drawing.Color.White;
            this.lblChoChi.Location = new System.Drawing.Point(15, 55); this.lblChoChi.Text = "0 đ";

            // Bảng xếp hạng
            this.label7.AutoSize = true; this.label7.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.label7.Location = new System.Drawing.Point(40, 190); this.label7.Text = "🔥 TOP 10 PHÓNG VIÊN NHẬN NHUẬN BÚT CAO NHẤT";

            this.dgvTopPV.Location = new System.Drawing.Point(40, 240);
            this.dgvTopPV.Size = new System.Drawing.Size(1020, 420);
            this.dgvTopPV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(162, 110, 255);
            this.dgvTopPV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;

            // FrmBaoCaoTongHop
            this.BackColor = System.Drawing.Color.FromArgb(242, 245, 250);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvTopPV);
            this.Controls.Add(this.pnlChoChi);
            this.Controls.Add(this.pnlDaChi);
            this.Controls.Add(this.pnlTongQuy);
            this.Name = "FrmBaoCaoTongHop";
            this.Text = "Báo cáo Tổng hợp toàn Tòa soạn";
            this.Load += new System.EventHandler(this.FrmBaoCaoTongHop_Load);
            this.pnlTongQuy.ResumeLayout(false); this.pnlTongQuy.PerformLayout();
            this.pnlDaChi.ResumeLayout(false); this.pnlDaChi.PerformLayout();
            this.pnlChoChi.ResumeLayout(false); this.pnlChoChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopPV)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }
        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTongQuy, pnlDaChi, pnlChoChi;
        private System.Windows.Forms.Label lblTongQuy, lblDaChi, lblChoChi, label1, label3, label5, label7;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTopPV;
    }
}