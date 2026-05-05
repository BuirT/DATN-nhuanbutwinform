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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMaSo = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.pnlCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDaNhan = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlChoChi = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDangCho = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTraCuu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlDaNhan.SuspendLayout();
            this.pnlChoChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraCuu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblMaSo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1200, 80);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Size = new System.Drawing.Size(500, 45);
            this.lblTitle.Text = "TRUNG TÂM THU NHẬP";
            // 
            // lblMaSo
            // 
            this.lblMaSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblMaSo.ForeColor = System.Drawing.Color.Gray;
            this.lblMaSo.Location = new System.Drawing.Point(26, 52);
            this.lblMaSo.Size = new System.Drawing.Size(300, 20);
            this.lblMaSo.Text = "Mã hồ sơ: ---";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BorderRadius = 10;
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1050, 18);
            this.btnBack.Size = new System.Drawing.Size(130, 45);
            this.btnBack.Text = "THOÁT XEM";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlCards
            // 
            this.pnlCards.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.pnlCards.Controls.Add(this.pnlDaNhan);
            this.pnlCards.Controls.Add(this.pnlChoChi);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 80);
            this.pnlCards.Padding = new System.Windows.Forms.Padding(20, 15, 10, 10);
            this.pnlCards.Size = new System.Drawing.Size(1200, 150);
            // 
            // pnlDaNhan
            // 
            this.pnlDaNhan.BorderRadius = 15;
            this.pnlDaNhan.Controls.Add(this.lblTongTien);
            this.pnlDaNhan.Controls.Add(this.label1);
            this.pnlDaNhan.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.pnlDaNhan.Location = new System.Drawing.Point(23, 18);
            this.pnlDaNhan.ShadowDecoration.Enabled = true;
            this.pnlDaNhan.Size = new System.Drawing.Size(380, 115);
            // 
            // lblTongTien
            // 
            this.lblTongTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.White;
            this.lblTongTien.Location = new System.Drawing.Point(10, 45);
            this.lblTongTien.Size = new System.Drawing.Size(360, 55);
            this.lblTongTien.Text = "0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.Text = "ĐÃ QUYẾT TOÁN";
            // 
            // pnlChoChi
            // 
            this.pnlChoChi.BorderRadius = 15;
            this.pnlChoChi.Controls.Add(this.lblDangCho);
            this.pnlChoChi.Controls.Add(this.label2);
            this.pnlChoChi.FillColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.pnlChoChi.Location = new System.Drawing.Point(413, 18);
            this.pnlChoChi.ShadowDecoration.Enabled = true;
            this.pnlChoChi.Size = new System.Drawing.Size(380, 115);
            // 
            // lblDangCho
            // 
            this.lblDangCho.BackColor = System.Drawing.Color.Transparent;
            this.lblDangCho.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblDangCho.ForeColor = System.Drawing.Color.White;
            this.lblDangCho.Location = new System.Drawing.Point(10, 45);
            this.lblDangCho.Size = new System.Drawing.Size(360, 55);
            this.lblDangCho.Text = "0 VNĐ";
            this.lblDangCho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.Text = "ĐANG CHỜ XỬ LÝ";
            // 
            // dgvTraCuu
            // 
            this.dgvTraCuu.AllowUserToAddRows = false;
            this.dgvTraCuu.BackgroundColor = System.Drawing.Color.White;
            this.dgvTraCuu.ColumnHeadersHeight = 45;
            this.dgvTraCuu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraCuu.Location = new System.Drawing.Point(0, 230);
            this.dgvTraCuu.Name = "dgvTraCuu";
            this.dgvTraCuu.ReadOnly = true;
            this.dgvTraCuu.RowHeadersVisible = false;
            this.dgvTraCuu.Size = new System.Drawing.Size(1200, 520);
            this.dgvTraCuu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(40, 40, 120);
            this.dgvTraCuu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            // 
            // FrmTraCuuNhuanBut
            // 
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.dgvTraCuu);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTraCuuNhuanBut";
            this.Load += new System.EventHandler(this.FrmTraCuuNhuanBut_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlCards.ResumeLayout(false);
            this.pnlDaNhan.ResumeLayout(false);
            this.pnlChoChi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraCuu)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblMaSo, label1, label2, lblTongTien, lblDangCho;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.FlowLayoutPanel pnlCards;
        private Guna.UI2.WinForms.Guna2Panel pnlDaNhan, pnlChoChi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTraCuu;
    }
}