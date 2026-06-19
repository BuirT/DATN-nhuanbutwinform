namespace HETHONGTINHNHUANBUT
{
    partial class FrmBaoCaoLanhDao
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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.dtpThang = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.btnExcel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlChart = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSummary = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.dgvSummary = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlDetail = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.dgvDetail = new Guna.UI2.WinForms.Guna2DataGridView();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.lblTongBai = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblDaChi = new System.Windows.Forms.Label();
            this.lblChuaChi = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblThang);
            this.pnlTop.Controls.Add(this.dtpThang);
            this.pnlTop.Controls.Add(this.btnXem);
            this.pnlTop.Controls.Add(this.btnExcel);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.ShadowDecoration.Enabled = true;
            this.pnlTop.Size = new System.Drawing.Size(1460, 120);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO LÃNH ĐẠO";
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblThang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblThang.Location = new System.Drawing.Point(25, 72);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(81, 17);
            this.lblThang.TabIndex = 1;
            this.lblThang.Text = "Chọn tháng";
            // 
            // dtpThang
            // 
            this.dtpThang.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dtpThang.BorderRadius = 8;
            this.dtpThang.Checked = true;
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dtpThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpThang.ForeColor = System.Drawing.Color.Black;
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThang.Location = new System.Drawing.Point(128, 66);
            this.dtpThang.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpThang.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(160, 36);
            this.dtpThang.TabIndex = 2;
            this.dtpThang.Value = new System.DateTime(2026, 6, 19, 0, 0, 0, 0);
            // 
            // btnXem
            // 
            this.btnXem.Animated = true;
            this.btnXem.BorderRadius = 8;
            this.btnXem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(310, 62);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(150, 40);
            this.btnXem.TabIndex = 3;
            this.btnXem.Text = "XEM BÁO CÁO";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Animated = true;
            this.btnExcel.BorderRadius = 8;
            this.btnExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(475, 62);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(150, 40);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "XUẤT EXCEL";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlChart
            // 
            this.pnlChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChart.BackColor = System.Drawing.Color.Transparent;
            this.pnlChart.BorderRadius = 16;
            this.pnlChart.FillColor = System.Drawing.Color.White;
            this.pnlChart.Location = new System.Drawing.Point(20, 145);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlChart.ShadowDecoration.Depth = 8;
            this.pnlChart.ShadowDecoration.Enabled = true;
            this.pnlChart.Size = new System.Drawing.Size(1460, 180);
            this.pnlChart.TabIndex = 1;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary.BorderRadius = 16;
            this.pnlSummary.Controls.Add(this.lblSummaryTitle);
            this.pnlSummary.Controls.Add(this.dgvSummary);
            this.pnlSummary.FillColor = System.Drawing.Color.White;
            this.pnlSummary.Location = new System.Drawing.Point(20, 335);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlSummary.ShadowDecoration.Depth = 8;
            this.pnlSummary.ShadowDecoration.Enabled = true;
            this.pnlSummary.Size = new System.Drawing.Size(1460, 250);
            this.pnlSummary.TabIndex = 2;
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSummaryTitle.Location = new System.Drawing.Point(25, 18);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(239, 25);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "TỔNG HỢP THEO TÁC GIẢ";
            // 
            // dgvSummary
            // 
            this.dgvSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSummary.AllowUserToAddRows = false;
            this.dgvSummary.AllowUserToDeleteRows = false;
            this.dgvSummary.AllowUserToResizeColumns = false;
            this.dgvSummary.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSummary.BackgroundColor = System.Drawing.Color.White;
            this.dgvSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSummary.ColumnHeadersHeight = 40;
            this.dgvSummary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvSummary.Location = new System.Drawing.Point(25, 55);
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.RowHeadersVisible = false;
            this.dgvSummary.RowTemplate.Height = 38;
            this.dgvSummary.Size = new System.Drawing.Size(1410, 185);
            this.dgvSummary.TabIndex = 1;
            this.dgvSummary.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSummary.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSummary.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSummary.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSummary.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSummary.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvSummary.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvSummary.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSummary.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSummary.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvSummary.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSummary.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSummary.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvSummary.ThemeStyle.ReadOnly = false;
            this.dgvSummary.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSummary.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSummary.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvSummary.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvSummary.ThemeStyle.RowsStyle.Height = 38;
            this.dgvSummary.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSummary.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // pnlDetail
            // 
            this.pnlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetail.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetail.BorderRadius = 16;
            this.pnlDetail.Controls.Add(this.lblDetailTitle);
            this.pnlDetail.Controls.Add(this.dgvDetail);
            this.pnlDetail.Controls.Add(this.footerPanel);
            this.pnlDetail.FillColor = System.Drawing.Color.White;
            this.pnlDetail.Location = new System.Drawing.Point(20, 595);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlDetail.ShadowDecoration.Depth = 8;
            this.pnlDetail.ShadowDecoration.Enabled = true;
            this.pnlDetail.Size = new System.Drawing.Size(1460, 135);
            this.pnlDetail.TabIndex = 3;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(25, 18);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(341, 25);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "CHI TIẾT NHUẬN BÚT TRONG THÁNG";
            // 
            // dgvDetail
            // 
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersHeight = 40;
            this.dgvDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvDetail.Location = new System.Drawing.Point(25, 55);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.RowTemplate.Height = 38;
            this.dgvDetail.Size = new System.Drawing.Size(1410, 40);
            this.dgvDetail.TabIndex = 1;
            this.dgvDetail.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetail.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDetail.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDetail.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDetail.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDetail.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetail.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvDetail.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDetail.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetail.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDetail.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetail.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetail.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvDetail.ThemeStyle.ReadOnly = false;
            this.dgvDetail.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDetail.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetail.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDetail.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDetail.ThemeStyle.RowsStyle.Height = 38;
            this.dgvDetail.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetail.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.Transparent;
            this.footerPanel.Controls.Add(this.lblTongBai);
            this.footerPanel.Controls.Add(this.lblTongTien);
            this.footerPanel.Controls.Add(this.lblDaChi);
            this.footerPanel.Controls.Add(this.lblChuaChi);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 160);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1460, 40);
            this.footerPanel.TabIndex = 2;
            // 
            // lblTongBai
            // 
            this.lblTongBai.AutoSize = true;
            this.lblTongBai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongBai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTongBai.Location = new System.Drawing.Point(25, 6);
            this.lblTongBai.Name = "lblTongBai";
            this.lblTongBai.Size = new System.Drawing.Size(100, 19);
            this.lblTongBai.TabIndex = 0;
            this.lblTongBai.Text = "Tổng số bài: 0";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTongTien.Location = new System.Drawing.Point(200, 6);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(161, 19);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "Tổng nhuận bút: 0 VNĐ";
            // 
            // lblDaChi
            // 
            this.lblDaChi.AutoSize = true;
            this.lblDaChi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblDaChi.Location = new System.Drawing.Point(450, 6);
            this.lblDaChi.Name = "lblDaChi";
            this.lblDaChi.Size = new System.Drawing.Size(101, 19);
            this.lblDaChi.TabIndex = 2;
            this.lblDaChi.Text = "Đã chi: 0 VNĐ";
            // 
            // lblChuaChi
            // 
            this.lblChuaChi.AutoSize = true;
            this.lblChuaChi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChuaChi.ForeColor = System.Drawing.Color.Crimson;
            this.lblChuaChi.Location = new System.Drawing.Point(650, 6);
            this.lblChuaChi.Name = "lblChuaChi";
            this.lblChuaChi.Size = new System.Drawing.Size(120, 19);
            this.lblChuaChi.TabIndex = 3;
            this.lblChuaChi.Text = "Chưa chi: 0 VNĐ";
            // 
            // FrmBaoCaoLanhDao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1500, 750);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmBaoCaoLanhDao";
            this.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.Text = "Báo cáo lãnh đạo";
            this.Load += new System.EventHandler(this.FrmBaoCaoLanhDao_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlChart;
        private Guna.UI2.WinForms.Guna2Panel pnlSummary;
        private Guna.UI2.WinForms.Guna2Panel pnlDetail;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblThang;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpThang;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2Button btnExcel;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblDetailTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSummary;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDetail;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label lblTongBai;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblDaChi;
        private System.Windows.Forms.Label lblChuaChi;
    }
}