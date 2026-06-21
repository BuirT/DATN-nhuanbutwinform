namespace HETHONGTINHNHUANBUT
{
    partial class FrmCanhBaoAI
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2DataGridView dgvCanhBao;
        private Guna.UI2.WinForms.Guna2Button btnMarkProcessed;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnRunAudit;
        private Guna.UI2.WinForms.Guna2Button btnXoaDaXuLy;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlBot;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCanhBao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnMarkProcessed = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnRunAudit = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoaDaXuLy = new Guna.UI2.WinForms.Guna2Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBot = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlTop.SuspendLayout();
            this.pnlBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnRunAudit);
            this.pnlTop.Controls.Add(this.btnMarkProcessed);
            this.pnlTop.Controls.Add(this.btnXoaDaXuLy);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.ShadowDecoration.Enabled = false;
            this.pnlTop.Size = new System.Drawing.Size(1100, 120);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CẢNH BÁO AI & KIỂM TOÁN NHUẬN BÚT";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Animated = false;
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(25, 68);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Làm mới";
            // 
            // btnRunAudit
            // 
            this.btnRunAudit.Animated = false;
            this.btnRunAudit.BorderRadius = 8;
            this.btnRunAudit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnRunAudit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRunAudit.ForeColor = System.Drawing.Color.White;
            this.btnRunAudit.Location = new System.Drawing.Point(145, 68);
            this.btnRunAudit.Name = "btnRunAudit";
            this.btnRunAudit.Size = new System.Drawing.Size(140, 36);
            this.btnRunAudit.TabIndex = 2;
            this.btnRunAudit.Text = "🔍 Kiểm toán toàn bộ";
            // 
            // btnMarkProcessed
            // 
            this.btnMarkProcessed.Animated = false;
            this.btnMarkProcessed.BorderRadius = 8;
            this.btnMarkProcessed.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnMarkProcessed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMarkProcessed.ForeColor = System.Drawing.Color.White;
            this.btnMarkProcessed.Location = new System.Drawing.Point(295, 68);
            this.btnMarkProcessed.Name = "btnMarkProcessed";
            this.btnMarkProcessed.Size = new System.Drawing.Size(150, 36);
            this.btnMarkProcessed.TabIndex = 3;
            this.btnMarkProcessed.Text = "✓ Đánh dấu đã xử lý";
            // 
            // btnXoaDaXuLy
            // 
            this.btnXoaDaXuLy.Animated = false;
            this.btnXoaDaXuLy.BorderRadius = 8;
            this.btnXoaDaXuLy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoaDaXuLy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoaDaXuLy.ForeColor = System.Drawing.Color.White;
            this.btnXoaDaXuLy.Location = new System.Drawing.Point(455, 68);
            this.btnXoaDaXuLy.Name = "btnXoaDaXuLy";
            this.btnXoaDaXuLy.Size = new System.Drawing.Size(140, 36);
            this.btnXoaDaXuLy.TabIndex = 4;
            this.btnXoaDaXuLy.Text = "🗑 Xoá đã xử lý";
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblCount.Location = new System.Drawing.Point(600, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(475, 20);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "Tổng: 0 cảnh báo";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBot
            // 
            this.pnlBot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBot.BackColor = System.Drawing.Color.Transparent;
            this.pnlBot.BorderRadius = 16;
            this.pnlBot.Controls.Add(this.txtTimKiem);
            this.pnlBot.Controls.Add(this.dgvCanhBao);
            this.pnlBot.FillColor = System.Drawing.Color.White;
            this.pnlBot.Location = new System.Drawing.Point(20, 150);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlBot.ShadowDecoration.Depth = 8;
            this.pnlBot.ShadowDecoration.Enabled = false;
            this.pnlBot.Size = new System.Drawing.Size(1100, 450);
            this.pnlBot.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.Location = new System.Drawing.Point(845, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Tìm kiếm...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(230, 36);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // dgvCanhBao
            // 
            this.dgvCanhBao.AllowUserToAddRows = false;
            this.dgvCanhBao.AllowUserToDeleteRows = false;
            this.dgvCanhBao.AllowUserToResizeColumns = false;
            this.dgvCanhBao.AllowUserToResizeRows = false;
            this.dgvCanhBao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCanhBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCanhBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCanhBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCanhBao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCanhBao.Location = new System.Drawing.Point(25, 60);
            this.dgvCanhBao.Name = "dgvCanhBao";
            this.dgvCanhBao.ReadOnly = true;
            this.dgvCanhBao.RowHeadersVisible = false;
            this.dgvCanhBao.Size = new System.Drawing.Size(1050, 370);
            this.dgvCanhBao.TabIndex = 5;
            this.dgvCanhBao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCanhBao.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCanhBao.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCanhBao.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCanhBao.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCanhBao.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCanhBao.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCanhBao.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCanhBao.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCanhBao.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvCanhBao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCanhBao.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCanhBao.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvCanhBao.ThemeStyle.ReadOnly = true;
            this.dgvCanhBao.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCanhBao.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCanhBao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvCanhBao.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCanhBao.ThemeStyle.RowsStyle.Height = 38;
            this.dgvCanhBao.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCanhBao.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCanhBao.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCanhBao_CellFormatting);
            // 
            // FrmCanhBaoAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1140, 620);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmCanhBaoAI";
            this.Text = "Cảnh báo AI & Kiểm toán nhuận bút";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
