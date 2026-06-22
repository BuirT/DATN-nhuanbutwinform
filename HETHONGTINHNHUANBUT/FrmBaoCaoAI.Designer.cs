namespace HETHONGTINHNHUANBUT
{
    partial class FrmBaoCaoAI
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
            this.lblChonThang = new System.Windows.Forms.Label();
            this.dtpThang = new System.Windows.Forms.DateTimePicker();
            this.btnTaoBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnCopy = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBot = new Guna.UI2.WinForms.Guna2Panel();
            this.txtBaoCao = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlTop.SuspendLayout();
            this.pnlBot.SuspendLayout();
            this.SuspendLayout();

            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblChonThang);
            this.pnlTop.Controls.Add(this.dtpThang);
            this.pnlTop.Controls.Add(this.btnTaoBaoCao);
            this.pnlTop.Controls.Add(this.btnCopy);
            this.pnlTop.Controls.Add(this.btnLuu);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.ShadowDecoration.Enabled = false;
            this.pnlTop.Size = new System.Drawing.Size(1160, 120);
            this.pnlTop.TabIndex = 0;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 28);
            this.lblTitle.Text = "📊 BÁO CÁO TỔNG KẾT AI";

            this.lblChonThang.AutoSize = true;
            this.lblChonThang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChonThang.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblChonThang.Location = new System.Drawing.Point(25, 55);
            this.lblChonThang.Name = "lblChonThang";
            this.lblChonThang.Size = new System.Drawing.Size(80, 19);
            this.lblChonThang.Text = "Chọn tháng";

            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThang.Location = new System.Drawing.Point(25, 80);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(160, 25);
            this.dtpThang.TabIndex = 3;

            this.btnTaoBaoCao.Animated = false;
            this.btnTaoBaoCao.BorderRadius = 8;
            this.btnTaoBaoCao.FillColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnTaoBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaoBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnTaoBaoCao.Location = new System.Drawing.Point(210, 70);
            this.btnTaoBaoCao.Name = "btnTaoBaoCao";
            this.btnTaoBaoCao.Size = new System.Drawing.Size(220, 42);
            this.btnTaoBaoCao.TabIndex = 0;
            this.btnTaoBaoCao.Text = "🤖 TẠO BÁO CÁO AI";
            this.btnTaoBaoCao.Click += new System.EventHandler(this.btnTaoBaoCao_Click);

            this.btnCopy.Animated = false;
            this.btnCopy.BorderRadius = 8;
            this.btnCopy.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Location = new System.Drawing.Point(830, 70);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(140, 42);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "📋 COPY";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);

            this.btnLuu.Animated = false;
            this.btnLuu.BorderRadius = 8;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(985, 70);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 42);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "📥 LƯU TXT";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            this.pnlBot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBot.BackColor = System.Drawing.Color.Transparent;
            this.pnlBot.BorderRadius = 16;
            this.pnlBot.Controls.Add(this.txtBaoCao);
            this.pnlBot.FillColor = System.Drawing.Color.White;
            this.pnlBot.Location = new System.Drawing.Point(20, 150);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlBot.ShadowDecoration.Depth = 8;
            this.pnlBot.ShadowDecoration.Enabled = false;
            this.pnlBot.Size = new System.Drawing.Size(1160, 630);
            this.pnlBot.TabIndex = 1;

            this.txtBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaoCao.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtBaoCao.BorderRadius = 8;
            this.txtBaoCao.BorderThickness = 0;
            this.txtBaoCao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBaoCao.DefaultText = "Báo cáo sẽ hiển thị tại đây...";
            this.txtBaoCao.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtBaoCao.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtBaoCao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtBaoCao.Enabled = true;
            this.txtBaoCao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.txtBaoCao.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtBaoCao.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtBaoCao.HoverState.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.txtBaoCao.Location = new System.Drawing.Point(25, 20);
            this.txtBaoCao.Margin = new System.Windows.Forms.Padding(20);
            this.txtBaoCao.Multiline = true;
            this.txtBaoCao.Name = "txtBaoCao";
            this.txtBaoCao.Padding = new System.Windows.Forms.Padding(15);
            this.txtBaoCao.PasswordChar = '\0';
            this.txtBaoCao.ReadOnly = true;
            this.txtBaoCao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBaoCao.SelectedText = "";
            this.txtBaoCao.Size = new System.Drawing.Size(1110, 590);
            this.txtBaoCao.TabIndex = 0;

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 254);
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmBaoCaoAI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tổng kết AI";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBot.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblChonThang;
        private System.Windows.Forms.DateTimePicker dtpThang;
        private Guna.UI2.WinForms.Guna2Button btnTaoBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnCopy;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Panel pnlBot;
        private Guna.UI2.WinForms.Guna2TextBox txtBaoCao;
    }
}
