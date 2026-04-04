namespace HETHONGTINHNHUANBUT
{
    partial class FrmBaoCaoChiTiet
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSoBao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.btnXuatExcel = new Guna.UI2.WinForms.Guna2Button();
            this.dgvReport = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();

            // pnlTop - Khung điều khiển phía trên
            this.pnlTop.Controls.Add(this.btnXuatExcel);
            this.pnlTop.Controls.Add(this.btnXem);
            this.pnlTop.Controls.Add(this.cboSoBao);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 100);

            this.label1.AutoSize = true; this.label1.BackColor = System.Drawing.Color.Transparent; this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 38); this.label1.Text = "CHỌN SỐ BÁO:";

            this.cboSoBao.BorderRadius = 5; this.cboSoBao.Location = new System.Drawing.Point(180, 32); this.cboSoBao.Size = new System.Drawing.Size(400, 36);

            this.btnXem.BorderRadius = 5; this.btnXem.FillColor = System.Drawing.Color.DodgerBlue; this.btnXem.Location = new System.Drawing.Point(600, 30);
            this.btnXem.Size = new System.Drawing.Size(120, 40); this.btnXem.Text = "XEM BÁO CÁO";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);

            this.btnXuatExcel.BorderRadius = 5; this.btnXuatExcel.FillColor = System.Drawing.Color.SeaGreen; this.btnXuatExcel.Location = new System.Drawing.Point(735, 30);
            this.btnXuatExcel.Size = new System.Drawing.Size(150, 40); this.btnXuatExcel.Text = "XUẤT EXCEL";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);

            // dgvReport - Bảng hiển thị dữ liệu
            this.dgvReport.Location = new System.Drawing.Point(25, 120);
            this.dgvReport.Size = new System.Drawing.Size(1050, 500);
            this.dgvReport.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);

            // lblTongTien
            this.lblTongTien.AutoSize = true; this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Crimson; this.lblTongTien.Location = new System.Drawing.Point(30, 640); this.lblTongTien.Text = "Tổng tiền nhuận bút của số báo: 0 VNĐ";

            // FrmBaoCaoChiTiet
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmBaoCaoChiTiet";
            this.Text = "Bảng kê Nhuận bút chi tiết";
            this.Load += new System.EventHandler(this.FrmBaoCaoChiTiet_Load);
            this.pnlTop.ResumeLayout(false); this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false); this.PerformLayout();
        }
        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop; private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboSoBao; private Guna.UI2.WinForms.Guna2Button btnXem; private Guna.UI2.WinForms.Guna2Button btnXuatExcel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReport; private System.Windows.Forms.Label lblTongTien;
    }
}