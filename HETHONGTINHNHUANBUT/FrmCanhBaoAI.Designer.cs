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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCanhBao
            // 
            this.dgvCanhBao.AllowUserToAddRows = false;
            this.dgvCanhBao.AllowUserToDeleteRows = false;
            this.dgvCanhBao.AllowUserToResizeColumns = false;
            this.dgvCanhBao.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCanhBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCanhBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCanhBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCanhBao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCanhBao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCanhBao.Location = new System.Drawing.Point(20, 100);
            this.dgvCanhBao.Name = "dgvCanhBao";
            this.dgvCanhBao.ReadOnly = true;
            this.dgvCanhBao.RowHeadersVisible = false;
            this.dgvCanhBao.Size = new System.Drawing.Size(1100, 500);
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
            this.dgvCanhBao.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvCanhBao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCanhBao.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCanhBao.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvCanhBao.ThemeStyle.ReadOnly = true;
            this.dgvCanhBao.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCanhBao.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCanhBao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvCanhBao.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCanhBao.ThemeStyle.RowsStyle.Height = 38;
            this.dgvCanhBao.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCanhBao.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCanhBao.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCanhBao_CellFormatting);
            // 
            // btnMarkProcessed
            // 
            this.btnMarkProcessed.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnMarkProcessed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMarkProcessed.ForeColor = System.Drawing.Color.White;
            this.btnMarkProcessed.Location = new System.Drawing.Point(290, 55);
            this.btnMarkProcessed.Name = "btnMarkProcessed";
            this.btnMarkProcessed.Size = new System.Drawing.Size(150, 32);
            this.btnMarkProcessed.TabIndex = 3;
            this.btnMarkProcessed.Text = "✓ Đánh dấu đã xử lý";
            // 
            // btnXoaDaXuLy
            // 
            this.btnXoaDaXuLy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoaDaXuLy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoaDaXuLy.ForeColor = System.Drawing.Color.White;
            this.btnXoaDaXuLy.Location = new System.Drawing.Point(450, 55);
            this.btnXoaDaXuLy.Name = "btnXoaDaXuLy";
            this.btnXoaDaXuLy.Size = new System.Drawing.Size(150, 32);
            this.btnXoaDaXuLy.TabIndex = 4;
            this.btnXoaDaXuLy.Text = "🗑 Xoá đã xử lý";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(20, 55);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 32);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Làm mới";
            // 
            // btnRunAudit
            // 
            this.btnRunAudit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnRunAudit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRunAudit.ForeColor = System.Drawing.Color.White;
            this.btnRunAudit.Location = new System.Drawing.Point(140, 55);
            this.btnRunAudit.Name = "btnRunAudit";
            this.btnRunAudit.Size = new System.Drawing.Size(140, 32);
            this.btnRunAudit.TabIndex = 2;
            this.btnRunAudit.Text = "🔍 Kiểm toán toàn bộ";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCount.Location = new System.Drawing.Point(460, 58);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(300, 25);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "Tổng: 0 cảnh báo";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CẢNH BÁO AI & KIỂM TOÁN NHUẬN BÚT";
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
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRunAudit);
            this.Controls.Add(this.btnMarkProcessed);
            this.Controls.Add(this.btnXoaDaXuLy);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvCanhBao);
            this.Name = "FrmCanhBaoAI";
            this.Text = "Cảnh Báo AI";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
