namespace HETHONGTINHNHUANBUT
{
    partial class FrmCanhBaoAI
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2DataGridView dgvCanhBao;
        private Guna.UI2.WinForms.Guna2Button btnMarkProcessed;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnRunAudit;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCanhBao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnMarkProcessed = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnRunAudit = new Guna.UI2.WinForms.Guna2Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Text = "CẢNH BÁO AI & KIỂM TOÁN NHUẬN BÚT";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(500, 30);

            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(20, 55);
            this.btnRefresh.Size = new System.Drawing.Size(110, 32);

            this.btnRunAudit.Text = "🔍 Kiểm toán toàn bộ";
            this.btnRunAudit.FillColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.btnRunAudit.ForeColor = System.Drawing.Color.White;
            this.btnRunAudit.Location = new System.Drawing.Point(140, 55);
            this.btnRunAudit.Size = new System.Drawing.Size(140, 32);

            this.btnMarkProcessed.Text = "✓ Đánh dấu đã xử lý";
            this.btnMarkProcessed.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnMarkProcessed.ForeColor = System.Drawing.Color.White;
            this.btnMarkProcessed.Location = new System.Drawing.Point(290, 55);
            this.btnMarkProcessed.Size = new System.Drawing.Size(150, 32);

            this.lblCount.Text = "Tổng: 0 cảnh báo";
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCount.Location = new System.Drawing.Point(460, 58);
            this.lblCount.Size = new System.Drawing.Size(300, 25);
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.dgvCanhBao.Location = new System.Drawing.Point(20, 100);
            this.dgvCanhBao.Size = new System.Drawing.Size(1100, 500);
            this.dgvCanhBao.ReadOnly = true;
            this.dgvCanhBao.AllowUserToAddRows = false;
            this.dgvCanhBao.AllowUserToDeleteRows = false;
            this.dgvCanhBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCanhBao.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCanhBao_CellFormatting);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRunAudit);
            this.Controls.Add(this.btnMarkProcessed);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvCanhBao);
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 254);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmCanhBaoAI";
            this.Text = "Cảnh Báo AI";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
