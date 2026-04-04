namespace HETHONGTINHNHUANBUT
{
    partial class FrmBaoCaoCongNo
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
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.dtpDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCongNo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongNo)).BeginInit();
            this.SuspendLayout();

            // pnlFilter
            this.pnlFilter.Controls.Add(this.btnExcel);
            this.pnlFilter.Controls.Add(this.btnXem);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.FillColor = System.Drawing.Color.White;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1100, 100);

            // label1 & dtpTuNgay
            this.label1.AutoSize = true; this.label1.BackColor = System.Drawing.Color.Transparent; this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 40); this.label1.Text = "TỪ NGÀY:";
            this.dtpTuNgay.BorderRadius = 5; this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(120, 32); this.dtpTuNgay.Size = new System.Drawing.Size(180, 36);

            // label2 & dtpDenNgay
            this.label2.AutoSize = true; this.label2.BackColor = System.Drawing.Color.Transparent; this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(320, 40); this.label2.Text = "ĐẾN NGÀY:";
            this.dtpDenNgay.BorderRadius = 5; this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(420, 32); this.dtpDenNgay.Size = new System.Drawing.Size(180, 36);

            // btnXem
            this.btnXem.BorderRadius = 5; this.btnXem.FillColor = System.Drawing.Color.DodgerBlue; this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXem.Location = new System.Drawing.Point(620, 32); this.btnXem.Size = new System.Drawing.Size(130, 36); this.btnXem.Text = "TỔNG HỢP";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);

            // btnExcel
            this.btnExcel.BorderRadius = 5; this.btnExcel.FillColor = System.Drawing.Color.SeaGreen; this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExcel.Location = new System.Drawing.Point(760, 32); this.btnExcel.Size = new System.Drawing.Size(150, 36); this.btnExcel.Text = "XUẤT BÁO CÁO";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);

            // dgvCongNo
            this.dgvCongNo.Location = new System.Drawing.Point(25, 120);
            this.dgvCongNo.Name = "dgvCongNo";
            this.dgvCongNo.Size = new System.Drawing.Size(1050, 520);
            this.dgvCongNo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            this.dgvCongNo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;

            // FrmBaoCaoCongNo
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.dgvCongNo);
            this.Controls.Add(this.pnlFilter);
            this.Name = "FrmBaoCaoCongNo";
            this.Text = "Báo cáo Công nợ Phóng viên - Tác giả";
            this.Load += new System.EventHandler(this.FrmBaoCaoCongNo_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongNo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // ĐÂY LÀ PHẦN QUAN TRỌNG NHẤT ĐỂ XÓA LỖI
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDenNgay;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2Button btnExcel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCongNo;
    }
}