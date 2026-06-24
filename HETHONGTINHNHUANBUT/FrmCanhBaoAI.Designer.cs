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
        private Guna.UI2.WinForms.Guna2Button btnXemBaiViet;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;

        private System.Windows.Forms.Label lblKpiTotal;
        private System.Windows.Forms.Label lblKpiCao;
        private System.Windows.Forms.Label lblKpiChuaXuLy;
        private System.Windows.Forms.Label lblKpiTopPV;

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
            this.btnXemBaiViet = new Guna.UI2.WinForms.Guna2Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiTopPV = new System.Windows.Forms.Label();
            this.lblKpiChuaXuLy = new System.Windows.Forms.Label();
            this.lblKpiCao = new System.Windows.Forms.Label();
            this.lblKpiTotal = new System.Windows.Forms.Label();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
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
            this.dgvCanhBao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCanhBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCanhBao.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCanhBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCanhBao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCanhBao.Location = new System.Drawing.Point(25, 65);
            this.dgvCanhBao.Name = "dgvCanhBao";
            this.dgvCanhBao.ReadOnly = true;
            this.dgvCanhBao.RowHeadersVisible = false;
            this.dgvCanhBao.RowTemplate.Height = 38;
            this.dgvCanhBao.Size = new System.Drawing.Size(830, 390);
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
            this.btnMarkProcessed.BorderRadius = 8;
            this.btnMarkProcessed.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnMarkProcessed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMarkProcessed.ForeColor = System.Drawing.Color.White;
            this.btnMarkProcessed.Location = new System.Drawing.Point(445, 80);
            this.btnMarkProcessed.Name = "btnMarkProcessed";
            this.btnMarkProcessed.Size = new System.Drawing.Size(150, 40);
            this.btnMarkProcessed.TabIndex = 3;
            this.btnMarkProcessed.Text = "✓ Đã xử lý";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(185, 80);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Làm mới";
            // 
            // btnRunAudit
            // 
            this.btnRunAudit.BorderRadius = 8;
            this.btnRunAudit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnRunAudit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRunAudit.ForeColor = System.Drawing.Color.White;
            this.btnRunAudit.Location = new System.Drawing.Point(25, 80);
            this.btnRunAudit.Name = "btnRunAudit";
            this.btnRunAudit.Size = new System.Drawing.Size(150, 40);
            this.btnRunAudit.TabIndex = 2;
            this.btnRunAudit.Text = "🔍 Kiểm toán";
            // 
            // btnXoaDaXuLy
            // 
            this.btnXoaDaXuLy.BorderRadius = 8;
            this.btnXoaDaXuLy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoaDaXuLy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaDaXuLy.ForeColor = System.Drawing.Color.White;
            this.btnXoaDaXuLy.Location = new System.Drawing.Point(605, 80);
            this.btnXoaDaXuLy.Name = "btnXoaDaXuLy";
            this.btnXoaDaXuLy.Size = new System.Drawing.Size(140, 40);
            this.btnXoaDaXuLy.TabIndex = 4;
            this.btnXoaDaXuLy.Text = "🗑 Xoá đã xử lý";
            // 
            // btnXemBaiViet
            // 
            this.btnXemBaiViet.BorderRadius = 8;
            this.btnXemBaiViet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnXemBaiViet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemBaiViet.ForeColor = System.Drawing.Color.White;
            this.btnXemBaiViet.Location = new System.Drawing.Point(305, 80);
            this.btnXemBaiViet.Name = "btnXemBaiViet";
            this.btnXemBaiViet.Size = new System.Drawing.Size(130, 40);
            this.btnXemBaiViet.TabIndex = 5;
            this.btnXemBaiViet.Text = "📄 Xem bài viết";
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCount.Location = new System.Drawing.Point(545, 25);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(315, 23);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "Tổng: 0 cảnh báo";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(283, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CẢNH BÁO AI && KIỂM TOÁN";
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblKpiTopPV);
            this.pnlTop.Controls.Add(this.lblKpiChuaXuLy);
            this.pnlTop.Controls.Add(this.lblKpiCao);
            this.pnlTop.Controls.Add(this.lblKpiTotal);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnXoaDaXuLy);
            this.pnlTop.Controls.Add(this.btnMarkProcessed);
            this.pnlTop.Controls.Add(this.btnXemBaiViet);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnRunAudit);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 20);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(880, 140);
            this.pnlTop.TabIndex = 0;
            // 
            // lblKpiTopPV
            // 
            this.lblKpiTopPV.AutoSize = true;
            this.lblKpiTopPV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKpiTopPV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblKpiTopPV.Location = new System.Drawing.Point(452, 58);
            this.lblKpiTopPV.Name = "lblKpiTopPV";
            this.lblKpiTopPV.Size = new System.Drawing.Size(179, 19);
            this.lblKpiTopPV.TabIndex = 13;
            this.lblKpiTopPV.Text = "PV cảnh báo nhiều nhất: -";
            // 
            // lblKpiChuaXuLy
            // 
            this.lblKpiChuaXuLy.AutoSize = true;
            this.lblKpiChuaXuLy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKpiChuaXuLy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.lblKpiChuaXuLy.Location = new System.Drawing.Point(305, 55);
            this.lblKpiChuaXuLy.Name = "lblKpiChuaXuLy";
            this.lblKpiChuaXuLy.Size = new System.Drawing.Size(96, 19);
            this.lblKpiChuaXuLy.TabIndex = 12;
            this.lblKpiChuaXuLy.Text = "Chưa xử lý: 0";
            // 
            // lblKpiCao
            // 
            this.lblKpiCao.AutoSize = true;
            this.lblKpiCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKpiCao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblKpiCao.Location = new System.Drawing.Point(185, 55);
            this.lblKpiCao.Name = "lblKpiCao";
            this.lblKpiCao.Size = new System.Drawing.Size(82, 19);
            this.lblKpiCao.TabIndex = 11;
            this.lblKpiCao.Text = "Mức cao: 0";
            // 
            // lblKpiTotal
            // 
            this.lblKpiTotal.AutoSize = true;
            this.lblKpiTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblKpiTotal.Location = new System.Drawing.Point(25, 55);
            this.lblKpiTotal.Name = "lblKpiTotal";
            this.lblKpiTotal.Size = new System.Drawing.Size(124, 19);
            this.lblKpiTotal.TabIndex = 10;
            this.lblKpiTotal.Text = "Tổng cảnh báo: 0";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.BorderRadius = 16;
            this.pnlBottom.Controls.Add(this.txtTimKiem);
            this.pnlBottom.Controls.Add(this.dgvCanhBao);
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(20, 180);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(880, 480);
            this.pnlBottom.TabIndex = 1;
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
            this.txtTimKiem.Location = new System.Drawing.Point(620, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Tìm kiếm...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(235, 36);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // FrmCanhBaoAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(920, 680);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "FrmCanhBaoAI";
            this.Text = "Cảnh báo AI & Kiểm toán nhuận bút";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
