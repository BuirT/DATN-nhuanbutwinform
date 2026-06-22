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
        private Guna.UI2.WinForms.Guna2Panel pnlLeft;
        private Guna.UI2.WinForms.Guna2Panel pnlRight;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;

        private System.Windows.Forms.Label lblKpiTotal;
        private System.Windows.Forms.Label lblKpiCao;
        private System.Windows.Forms.Label lblKpiChuaXuLy;
        private System.Windows.Forms.Label lblKpiTopPV;

        private System.Windows.Forms.Label lblThongTinBaiViet;
        private System.Windows.Forms.Label lblTieuDeLabel;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblPhongVienLabel;
        private System.Windows.Forms.Label lblPhongVien;
        private System.Windows.Forms.Label lblDiemAILabel;
        private System.Windows.Forms.Label lblDiemAI;
        private System.Windows.Forms.Label lblTienNBLabel;
        private System.Windows.Forms.Label lblTienNB;

        private System.Windows.Forms.Label lblNoiDungLabel;
        private System.Windows.Forms.RichTextBox txtNoiDungBaiViet;
        private System.Windows.Forms.Label lblCanhBaoLabel;
        private System.Windows.Forms.RichTextBox txtChiTietCanhBao;
        private System.Windows.Forms.Label lblGiaiThichLabel;
        private System.Windows.Forms.RichTextBox txtGiaiThich;
        private System.Windows.Forms.RichTextBox txtDanhGiaAI;

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
            this.pnlLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRight = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();

            this.lblKpiTotal = new System.Windows.Forms.Label();
            this.lblKpiCao = new System.Windows.Forms.Label();
            this.lblKpiChuaXuLy = new System.Windows.Forms.Label();
            this.lblKpiTopPV = new System.Windows.Forms.Label();

            this.lblThongTinBaiViet = new System.Windows.Forms.Label();
            this.lblTieuDeLabel = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblPhongVienLabel = new System.Windows.Forms.Label();
            this.lblPhongVien = new System.Windows.Forms.Label();
            this.lblDiemAILabel = new System.Windows.Forms.Label();
            this.lblDiemAI = new System.Windows.Forms.Label();
            this.lblTienNBLabel = new System.Windows.Forms.Label();
            this.lblTienNB = new System.Windows.Forms.Label();

            this.lblNoiDungLabel = new System.Windows.Forms.Label();
            this.txtNoiDungBaiViet = new System.Windows.Forms.RichTextBox();
            this.lblCanhBaoLabel = new System.Windows.Forms.Label();
            this.txtChiTietCanhBao = new System.Windows.Forms.RichTextBox();
            this.lblGiaiThichLabel = new System.Windows.Forms.Label();
            this.txtGiaiThich = new System.Windows.Forms.RichTextBox();
            this.txtDanhGiaAI = new System.Windows.Forms.RichTextBox();

            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.ShadowDecoration.Enabled = false;
            this.pnlTop.Size = new System.Drawing.Size(1360, 155);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(25, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(516, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CẢNH BÁO AI & KIỂM TOÁN NHUẬN BÚT";

            // lblKpiTotal
            this.lblKpiTotal.AutoSize = true;
            this.lblKpiTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblKpiTotal.Location = new System.Drawing.Point(610, 18);
            this.lblKpiTotal.Name = "lblKpiTotal";
            this.lblKpiTotal.Size = new System.Drawing.Size(120, 15);
            this.lblKpiTotal.TabIndex = 10;
            this.lblKpiTotal.Text = "Tổng cảnh báo: 0";
            this.lblKpiTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblKpiCao
            this.lblKpiCao.AutoSize = true;
            this.lblKpiCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiCao.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblKpiCao.Location = new System.Drawing.Point(800, 18);
            this.lblKpiCao.Name = "lblKpiCao";
            this.lblKpiCao.Size = new System.Drawing.Size(130, 15);
            this.lblKpiCao.TabIndex = 11;
            this.lblKpiCao.Text = "Mức cao: 0";
            this.lblKpiCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblKpiChuaXuLy
            this.lblKpiChuaXuLy.AutoSize = true;
            this.lblKpiChuaXuLy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiChuaXuLy.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblKpiChuaXuLy.Location = new System.Drawing.Point(990, 18);
            this.lblKpiChuaXuLy.Name = "lblKpiChuaXuLy";
            this.lblKpiChuaXuLy.Size = new System.Drawing.Size(110, 15);
            this.lblKpiChuaXuLy.TabIndex = 12;
            this.lblKpiChuaXuLy.Text = "Chưa xử lý: 0";
            this.lblKpiChuaXuLy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblKpiTopPV
            this.lblKpiTopPV.AutoSize = true;
            this.lblKpiTopPV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiTopPV.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.lblKpiTopPV.Location = new System.Drawing.Point(1160, 18);
            this.lblKpiTopPV.Name = "lblKpiTopPV";
            this.lblKpiTopPV.Size = new System.Drawing.Size(160, 15);
            this.lblKpiTopPV.TabIndex = 13;
            this.lblKpiTopPV.Text = "PV cảnh báo nhiều nhất: -";
            this.lblKpiTopPV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnRunAudit
            this.btnRunAudit.Animated = false;
            this.btnRunAudit.BorderRadius = 8;
            this.btnRunAudit.FillColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.btnRunAudit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRunAudit.ForeColor = System.Drawing.Color.White;
            this.btnRunAudit.Location = new System.Drawing.Point(25, 55);
            this.btnRunAudit.Name = "btnRunAudit";
            this.btnRunAudit.Size = new System.Drawing.Size(150, 36);
            this.btnRunAudit.TabIndex = 2;
            this.btnRunAudit.Text = "🔍 Kiểm toán toàn bộ";

            // btnRefresh
            this.btnRefresh.Animated = false;
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(185, 55);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄 Làm mới";

            // btnXemBaiViet
            this.btnXemBaiViet.Animated = false;
            this.btnXemBaiViet.BorderRadius = 8;
            this.btnXemBaiViet.FillColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnXemBaiViet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXemBaiViet.ForeColor = System.Drawing.Color.White;
            this.btnXemBaiViet.Location = new System.Drawing.Point(305, 55);
            this.btnXemBaiViet.Name = "btnXemBaiViet";
            this.btnXemBaiViet.Size = new System.Drawing.Size(120, 36);
            this.btnXemBaiViet.TabIndex = 5;
            this.btnXemBaiViet.Text = "📄 Xem bài viết";

            // btnMarkProcessed
            this.btnMarkProcessed.Animated = false;
            this.btnMarkProcessed.BorderRadius = 8;
            this.btnMarkProcessed.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnMarkProcessed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMarkProcessed.ForeColor = System.Drawing.Color.White;
            this.btnMarkProcessed.Location = new System.Drawing.Point(435, 55);
            this.btnMarkProcessed.Name = "btnMarkProcessed";
            this.btnMarkProcessed.Size = new System.Drawing.Size(150, 36);
            this.btnMarkProcessed.TabIndex = 3;
            this.btnMarkProcessed.Text = "✓ Đánh dấu đã xử lý";

            // btnXoaDaXuLy
            this.btnXoaDaXuLy.Animated = false;
            this.btnXoaDaXuLy.BorderRadius = 8;
            this.btnXoaDaXuLy.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnXoaDaXuLy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoaDaXuLy.ForeColor = System.Drawing.Color.White;
            this.btnXoaDaXuLy.Location = new System.Drawing.Point(595, 55);
            this.btnXoaDaXuLy.Name = "btnXoaDaXuLy";
            this.btnXoaDaXuLy.Size = new System.Drawing.Size(140, 36);
            this.btnXoaDaXuLy.TabIndex = 4;
            this.btnXoaDaXuLy.Text = "🗑 Xoá đã xử lý";

            // lblCount
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblCount.Location = new System.Drawing.Point(750, 56);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(585, 30);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "Tổng: 0 cảnh báo";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // KPI sub-labels
            // lblKpiTotal sub-header
            var lblKpiTitle1 = new System.Windows.Forms.Label();
            lblKpiTitle1.AutoSize = true;
            lblKpiTitle1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            lblKpiTitle1.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblKpiTitle1.Location = new System.Drawing.Point(610, 36);
            lblKpiTitle1.Name = "lblKpiTitle1";
            lblKpiTitle1.Size = new System.Drawing.Size(100, 13);
            lblKpiTitle1.Text = "Tổng cảnh báo";
            this.pnlTop.Controls.Add(lblKpiTitle1);

            var lblKpiTitle2 = new System.Windows.Forms.Label();
            lblKpiTitle2.AutoSize = true;
            lblKpiTitle2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            lblKpiTitle2.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblKpiTitle2.Location = new System.Drawing.Point(800, 36);
            lblKpiTitle2.Name = "lblKpiTitle2";
            lblKpiTitle2.Size = new System.Drawing.Size(100, 13);
            lblKpiTitle2.Text = "Mức cao";
            this.pnlTop.Controls.Add(lblKpiTitle2);

            var lblKpiTitle3 = new System.Windows.Forms.Label();
            lblKpiTitle3.AutoSize = true;
            lblKpiTitle3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            lblKpiTitle3.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblKpiTitle3.Location = new System.Drawing.Point(990, 36);
            lblKpiTitle3.Name = "lblKpiTitle3";
            lblKpiTitle3.Size = new System.Drawing.Size(100, 13);
            lblKpiTitle3.Text = "Chưa xử lý";
            this.pnlTop.Controls.Add(lblKpiTitle3);

            var lblKpiTitle4 = new System.Windows.Forms.Label();
            lblKpiTitle4.AutoSize = true;
            lblKpiTitle4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            lblKpiTitle4.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblKpiTitle4.Location = new System.Drawing.Point(1160, 36);
            lblKpiTitle4.Name = "lblKpiTitle4";
            lblKpiTitle4.Size = new System.Drawing.Size(160, 13);
            lblKpiTitle4.Text = "PV cảnh báo nhiều nhất";
            this.pnlTop.Controls.Add(lblKpiTitle4);

            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblKpiTotal);
            this.pnlTop.Controls.Add(this.lblKpiCao);
            this.pnlTop.Controls.Add(this.lblKpiChuaXuLy);
            this.pnlTop.Controls.Add(this.lblKpiTopPV);
            this.pnlTop.Controls.Add(this.btnRunAudit);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnXemBaiViet);
            this.pnlTop.Controls.Add(this.btnMarkProcessed);
            this.pnlTop.Controls.Add(this.btnXoaDaXuLy);
            this.pnlTop.Controls.Add(this.lblCount);

            // pnlLeft
            this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeft.BorderRadius = 16;
            this.pnlLeft.FillColor = System.Drawing.Color.White;
            this.pnlLeft.Location = new System.Drawing.Point(20, 185);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlLeft.ShadowDecoration.Depth = 8;
            this.pnlLeft.ShadowDecoration.Enabled = false;
            this.pnlLeft.Size = new System.Drawing.Size(815, 480);
            this.pnlLeft.TabIndex = 1;

            // txtTimKiem
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(24, 119, 242);
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.Location = new System.Drawing.Point(555, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Tìm kiếm...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(235, 36);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            // dgvCanhBao
            this.dgvCanhBao.AllowUserToAddRows = false;
            this.dgvCanhBao.AllowUserToDeleteRows = false;
            this.dgvCanhBao.AllowUserToResizeColumns = false;
            this.dgvCanhBao.AllowUserToResizeRows = false;
            this.dgvCanhBao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCanhBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCanhBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCanhBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCanhBao.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvCanhBao.Location = new System.Drawing.Point(25, 60);
            this.dgvCanhBao.Name = "dgvCanhBao";
            this.dgvCanhBao.ReadOnly = true;
            this.dgvCanhBao.RowHeadersVisible = false;
            this.dgvCanhBao.Size = new System.Drawing.Size(765, 395);
            this.dgvCanhBao.TabIndex = 5;
            this.dgvCanhBao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCanhBao.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCanhBao.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCanhBao.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCanhBao.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCanhBao.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCanhBao.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvCanhBao.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            this.dgvCanhBao.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCanhBao.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 163);
            this.dgvCanhBao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCanhBao.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCanhBao.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvCanhBao.ThemeStyle.ReadOnly = true;
            this.dgvCanhBao.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCanhBao.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCanhBao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
            this.dgvCanhBao.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.dgvCanhBao.ThemeStyle.RowsStyle.Height = 38;
            this.dgvCanhBao.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.dgvCanhBao.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.dgvCanhBao.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCanhBao_CellFormatting);
            this.dgvCanhBao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCanhBao_CellClick);

            this.pnlLeft.Controls.Add(this.txtTimKiem);
            this.pnlLeft.Controls.Add(this.dgvCanhBao);

            // pnlRight
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.AutoScroll = true;
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.BorderRadius = 16;
            this.pnlRight.FillColor = System.Drawing.Color.White;
            this.pnlRight.Location = new System.Drawing.Point(850, 185);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlRight.ShadowDecoration.Depth = 8;
            this.pnlRight.ShadowDecoration.Enabled = false;
            this.pnlRight.Size = new System.Drawing.Size(530, 480);
            this.pnlRight.TabIndex = 2;

            // lblThongTinBaiViet
            this.lblThongTinBaiViet.AutoSize = true;
            this.lblThongTinBaiViet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblThongTinBaiViet.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblThongTinBaiViet.Location = new System.Drawing.Point(20, 15);
            this.lblThongTinBaiViet.Name = "lblThongTinBaiViet";
            this.lblThongTinBaiViet.Size = new System.Drawing.Size(200, 21);
            this.lblThongTinBaiViet.TabIndex = 0;
            this.lblThongTinBaiViet.Text = "THÔNG TIN BÀI VIẾT";

            // lblTieuDeLabel
            this.lblTieuDeLabel.AutoSize = true;
            this.lblTieuDeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTieuDeLabel.Location = new System.Drawing.Point(22, 45);
            this.lblTieuDeLabel.Name = "lblTieuDeLabel";
            this.lblTieuDeLabel.Size = new System.Drawing.Size(50, 15);
            this.lblTieuDeLabel.TabIndex = 1;
            this.lblTieuDeLabel.Text = "Tiêu đề:";

            // lblTieuDe
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTieuDe.Location = new System.Drawing.Point(80, 45);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(100, 15);
            this.lblTieuDe.TabIndex = 2;
            this.lblTieuDe.Text = "(Chọn cảnh báo)";
            this.lblTieuDe.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblTieuDe.AutoEllipsis = true;

            // lblPhongVienLabel
            this.lblPhongVienLabel.AutoSize = true;
            this.lblPhongVienLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhongVienLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPhongVienLabel.Location = new System.Drawing.Point(22, 68);
            this.lblPhongVienLabel.Name = "lblPhongVienLabel";
            this.lblPhongVienLabel.Size = new System.Drawing.Size(71, 15);
            this.lblPhongVienLabel.TabIndex = 3;
            this.lblPhongVienLabel.Text = "Phóng viên:";

            // lblPhongVien
            this.lblPhongVien.AutoSize = true;
            this.lblPhongVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblPhongVien.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPhongVien.Location = new System.Drawing.Point(100, 68);
            this.lblPhongVien.Name = "lblPhongVien";
            this.lblPhongVien.Size = new System.Drawing.Size(50, 15);
            this.lblPhongVien.TabIndex = 4;
            this.lblPhongVien.Text = "-";

            // lblDiemAILabel
            this.lblDiemAILabel.AutoSize = true;
            this.lblDiemAILabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiemAILabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDiemAILabel.Location = new System.Drawing.Point(22, 91);
            this.lblDiemAILabel.Name = "lblDiemAILabel";
            this.lblDiemAILabel.Size = new System.Drawing.Size(54, 15);
            this.lblDiemAILabel.TabIndex = 5;
            this.lblDiemAILabel.Text = "Đánh giá:";

            // lblDiemAI
            this.lblDiemAI.AutoSize = true;
            this.lblDiemAI.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblDiemAI.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDiemAI.Location = new System.Drawing.Point(84, 91);
            this.lblDiemAI.Name = "lblDiemAI";
            this.lblDiemAI.Size = new System.Drawing.Size(50, 15);
            this.lblDiemAI.TabIndex = 6;
            this.lblDiemAI.Text = "-";
            this.lblDiemAI.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblDiemAI.AutoEllipsis = true;

            // lblDanhGiaAITextLabel
            var lblDanhGiaAITextLabel = new System.Windows.Forms.Label();
            lblDanhGiaAITextLabel.AutoSize = true;
            lblDanhGiaAITextLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDanhGiaAITextLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblDanhGiaAITextLabel.Location = new System.Drawing.Point(22, 114);
            lblDanhGiaAITextLabel.Name = "lblDanhGiaAITextLabel";
            lblDanhGiaAITextLabel.Size = new System.Drawing.Size(91, 15);
            lblDanhGiaAITextLabel.TabIndex = 15;
            lblDanhGiaAITextLabel.Text = "Đánh giá chi tiết:";

            // txtDanhGiaAI
            this.txtDanhGiaAI.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtDanhGiaAI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDanhGiaAI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDanhGiaAI.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtDanhGiaAI.Location = new System.Drawing.Point(24, 130);
            this.txtDanhGiaAI.Name = "txtDanhGiaAI";
            this.txtDanhGiaAI.ReadOnly = true;
            this.txtDanhGiaAI.Size = new System.Drawing.Size(480, 50);
            this.txtDanhGiaAI.TabIndex = 16;
            this.txtDanhGiaAI.Text = "";

            // lblTienNBLabel
            this.lblTienNBLabel.AutoSize = true;
            this.lblTienNBLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTienNBLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTienNBLabel.Location = new System.Drawing.Point(22, 190);
            this.lblTienNBLabel.Name = "lblTienNBLabel";
            this.lblTienNBLabel.Size = new System.Drawing.Size(91, 15);
            this.lblTienNBLabel.TabIndex = 7;
            this.lblTienNBLabel.Text = "Tiền nhuận bút:";

            // lblTienNB
            this.lblTienNB.AutoSize = true;
            this.lblTienNB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblTienNB.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTienNB.Location = new System.Drawing.Point(120, 190);
            this.lblTienNB.Name = "lblTienNB";
            this.lblTienNB.Size = new System.Drawing.Size(50, 15);
            this.lblTienNB.TabIndex = 8;
            this.lblTienNB.Text = "-";

            // lblNoiDungLabel
            this.lblNoiDungLabel.AutoSize = true;
            this.lblNoiDungLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNoiDungLabel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblNoiDungLabel.Location = new System.Drawing.Point(20, 220);
            this.lblNoiDungLabel.Name = "lblNoiDungLabel";
            this.lblNoiDungLabel.Size = new System.Drawing.Size(210, 20);
            this.lblNoiDungLabel.TabIndex = 9;
            this.lblNoiDungLabel.Text = "NỘI DUNG BÀI VIẾT";

            // txtNoiDungBaiViet
            this.txtNoiDungBaiViet.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtNoiDungBaiViet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNoiDungBaiViet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNoiDungBaiViet.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtNoiDungBaiViet.Location = new System.Drawing.Point(24, 245);
            this.txtNoiDungBaiViet.Name = "txtNoiDungBaiViet";
            this.txtNoiDungBaiViet.ReadOnly = true;
            this.txtNoiDungBaiViet.Size = new System.Drawing.Size(480, 100);
            this.txtNoiDungBaiViet.TabIndex = 10;
            this.txtNoiDungBaiViet.Text = "";

            // lblCanhBaoLabel
            this.lblCanhBaoLabel.AutoSize = true;
            this.lblCanhBaoLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCanhBaoLabel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblCanhBaoLabel.Location = new System.Drawing.Point(20, 355);
            this.lblCanhBaoLabel.Name = "lblCanhBaoLabel";
            this.lblCanhBaoLabel.Size = new System.Drawing.Size(190, 20);
            this.lblCanhBaoLabel.TabIndex = 11;
            this.lblCanhBaoLabel.Text = "CHI TIẾT CẢNH BÁO";

            // txtChiTietCanhBao
            this.txtChiTietCanhBao.BackColor = System.Drawing.Color.FromArgb(254, 249, 195);
            this.txtChiTietCanhBao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChiTietCanhBao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtChiTietCanhBao.ForeColor = System.Drawing.Color.FromArgb(161, 98, 7);
            this.txtChiTietCanhBao.Location = new System.Drawing.Point(24, 380);
            this.txtChiTietCanhBao.Name = "txtChiTietCanhBao";
            this.txtChiTietCanhBao.ReadOnly = true;
            this.txtChiTietCanhBao.Size = new System.Drawing.Size(480, 65);
            this.txtChiTietCanhBao.TabIndex = 12;
            this.txtChiTietCanhBao.Text = "";

            // lblGiaiThichLabel
            this.lblGiaiThichLabel.AutoSize = true;
            this.lblGiaiThichLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGiaiThichLabel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblGiaiThichLabel.Location = new System.Drawing.Point(20, 455);
            this.lblGiaiThichLabel.Name = "lblGiaiThichLabel";
            this.lblGiaiThichLabel.Size = new System.Drawing.Size(180, 20);
            this.lblGiaiThichLabel.TabIndex = 13;
            this.lblGiaiThichLabel.Text = "GIẢI THÍCH PHÁT HIỆN";

            // txtGiaiThich
            this.txtGiaiThich.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtGiaiThich.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGiaiThich.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtGiaiThich.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.txtGiaiThich.Location = new System.Drawing.Point(24, 480);
            this.txtGiaiThich.Name = "txtGiaiThich";
            this.txtGiaiThich.ReadOnly = true;
            this.txtGiaiThich.Size = new System.Drawing.Size(480, 50);
            this.txtGiaiThich.TabIndex = 14;
            this.txtGiaiThich.Text = "";

            this.pnlRight.Controls.Add(this.lblThongTinBaiViet);
            this.pnlRight.Controls.Add(this.lblTieuDeLabel);
            this.pnlRight.Controls.Add(this.lblTieuDe);
            this.pnlRight.Controls.Add(this.lblPhongVienLabel);
            this.pnlRight.Controls.Add(this.lblPhongVien);
            this.pnlRight.Controls.Add(this.lblDiemAILabel);
            this.pnlRight.Controls.Add(this.lblDiemAI);
            this.pnlRight.Controls.Add(lblDanhGiaAITextLabel);
            this.pnlRight.Controls.Add(this.txtDanhGiaAI);
            this.pnlRight.Controls.Add(this.lblTienNBLabel);
            this.pnlRight.Controls.Add(this.lblTienNB);
            this.pnlRight.Controls.Add(this.lblNoiDungLabel);
            this.pnlRight.Controls.Add(this.txtNoiDungBaiViet);
            this.pnlRight.Controls.Add(this.lblCanhBaoLabel);
            this.pnlRight.Controls.Add(this.txtChiTietCanhBao);
            this.pnlRight.Controls.Add(this.lblGiaiThichLabel);
            this.pnlRight.Controls.Add(this.txtGiaiThich);

            // FrmCanhBaoAI
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1400, 685);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1100, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmCanhBaoAI";
            this.Text = "Cảnh báo AI & Kiểm toán nhuận bút";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
