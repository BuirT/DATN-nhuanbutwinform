namespace HETHONGTINHNHUANBUT
{
    partial class FrmTongQuan
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picIcon = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTacGia = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblSoTacGia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBaiViet = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblSoBaiViet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSoBao = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblSoBaoCho = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTien = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlBieuDo = new Guna.UI2.WinForms.Guna2Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvHoatDong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpCards.SuspendLayout();
            this.pnlTacGia.SuspendLayout();
            this.pnlBaiViet.SuspendLayout();
            this.pnlSoBao.SuspendLayout();
            this.pnlTien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoatDong)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragStartTransparencyValue = 1D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.White;
            this.pnlTitleBar.Controls.Add(this.btnClose);
            this.pnlTitleBar.Controls.Add(this.btnMinimize);
            this.pnlTitleBar.Controls.Add(this.lblTitle);
            this.pnlTitleBar.Controls.Add(this.picIcon);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1100, 45);
            this.pnlTitleBar.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 10;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(1043, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BorderRadius = 10;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnMinimize.Location = new System.Drawing.Point(988, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(45, 35);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "—";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitle.Location = new System.Drawing.Point(55, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(301, 25);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "TỔNG QUAN TÒA SOẠN - BÁO X";
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.picIcon.ImageRotate = 0F;
            this.picIcon.Location = new System.Drawing.Point(10, 5);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(35, 35);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblClock);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 45);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 90);
            this.pnlHeader.TabIndex = 4;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblWelcome.Location = new System.Drawing.Point(20, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(393, 37);
            this.lblWelcome.TabIndex = 28;
            this.lblWelcome.Text = "Chào mừng trở lại, Admin 👋";
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblClock.ForeColor = System.Drawing.Color.Gray;
            this.lblClock.Location = new System.Drawing.Point(25, 55);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(185, 21);
            this.lblClock.TabIndex = 27;
            this.lblClock.Text = "Đang cập nhật thời gian...";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpCards, 0, 0);
            this.tlpMain.Controls.Add(this.splitContainer1, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 135);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1100, 665);
            this.tlpMain.TabIndex = 1;
            // 
            // tlpCards
            // 
            this.tlpCards.ColumnCount = 4;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.Controls.Add(this.pnlTacGia, 0, 0);
            this.tlpCards.Controls.Add(this.pnlBaiViet, 1, 0);
            this.tlpCards.Controls.Add(this.pnlSoBao, 2, 0);
            this.tlpCards.Controls.Add(this.pnlTien, 3, 0);
            this.tlpCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCards.Location = new System.Drawing.Point(13, 3);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCards.Size = new System.Drawing.Size(1074, 174);
            this.tlpCards.TabIndex = 0;
            // 
            // pnlTacGia
            // 
            this.pnlTacGia.BackColor = System.Drawing.Color.Transparent;
            this.pnlTacGia.BorderRadius = 20;
            this.pnlTacGia.Controls.Add(this.lblSoTacGia);
            this.pnlTacGia.Controls.Add(this.label2);
            this.pnlTacGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTacGia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pnlTacGia.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.pnlTacGia.Location = new System.Drawing.Point(3, 3);
            this.pnlTacGia.Name = "pnlTacGia";
            this.pnlTacGia.Padding = new System.Windows.Forms.Padding(15);
            this.pnlTacGia.ShadowDecoration.Enabled = false;
            this.pnlTacGia.Size = new System.Drawing.Size(262, 168);
            this.pnlTacGia.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = false;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "👥 Tác giả";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoTacGia
            // 
            this.lblSoTacGia.AutoSize = false;
            this.lblSoTacGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoTacGia.BackColor = System.Drawing.Color.Transparent;
            this.lblSoTacGia.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblSoTacGia.ForeColor = System.Drawing.Color.White;
            this.lblSoTacGia.Location = new System.Drawing.Point(15, 50);
            this.lblSoTacGia.Name = "lblSoTacGia";
            this.lblSoTacGia.Size = new System.Drawing.Size(232, 103);
            this.lblSoTacGia.TabIndex = 0;
            this.lblSoTacGia.Text = "0";
            this.lblSoTacGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBaiViet
            // 
            this.pnlBaiViet.BackColor = System.Drawing.Color.Transparent;
            this.pnlBaiViet.BorderRadius = 20;
            this.pnlBaiViet.Controls.Add(this.lblSoBaiViet);
            this.pnlBaiViet.Controls.Add(this.label3);
            this.pnlBaiViet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBaiViet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.pnlBaiViet.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(43)))), ((int)(((byte)(226)))));
            this.pnlBaiViet.Location = new System.Drawing.Point(271, 3);
            this.pnlBaiViet.Name = "pnlBaiViet";
            this.pnlBaiViet.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBaiViet.ShadowDecoration.Enabled = false;
            this.pnlBaiViet.Size = new System.Drawing.Size(262, 168);
            this.pnlBaiViet.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 35);
            this.label3.TabIndex = 1;
            this.label3.Text = "📝 Bài viết";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoBaiViet
            // 
            this.lblSoBaiViet.AutoSize = false;
            this.lblSoBaiViet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoBaiViet.BackColor = System.Drawing.Color.Transparent;
            this.lblSoBaiViet.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblSoBaiViet.ForeColor = System.Drawing.Color.White;
            this.lblSoBaiViet.Location = new System.Drawing.Point(15, 50);
            this.lblSoBaiViet.Name = "lblSoBaiViet";
            this.lblSoBaiViet.Size = new System.Drawing.Size(232, 103);
            this.lblSoBaiViet.TabIndex = 0;
            this.lblSoBaiViet.Text = "0";
            this.lblSoBaiViet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSoBao
            // 
            this.pnlSoBao.BackColor = System.Drawing.Color.Transparent;
            this.pnlSoBao.BorderRadius = 20;
            this.pnlSoBao.Controls.Add(this.lblSoBaoCho);
            this.pnlSoBao.Controls.Add(this.label4);
            this.pnlSoBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSoBao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnlSoBao.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.pnlSoBao.Location = new System.Drawing.Point(539, 3);
            this.pnlSoBao.Name = "pnlSoBao";
            this.pnlSoBao.Padding = new System.Windows.Forms.Padding(15);
            this.pnlSoBao.ShadowDecoration.Enabled = false;
            this.pnlSoBao.Size = new System.Drawing.Size(262, 168);
            this.pnlSoBao.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = false;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 35);
            this.label4.TabIndex = 1;
            this.label4.Text = "📅 Số báo chờ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoBaoCho
            // 
            this.lblSoBaoCho.AutoSize = false;
            this.lblSoBaoCho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoBaoCho.BackColor = System.Drawing.Color.Transparent;
            this.lblSoBaoCho.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblSoBaoCho.ForeColor = System.Drawing.Color.White;
            this.lblSoBaoCho.Location = new System.Drawing.Point(15, 50);
            this.lblSoBaoCho.Name = "lblSoBaoCho";
            this.lblSoBaoCho.Size = new System.Drawing.Size(232, 103);
            this.lblSoBaoCho.TabIndex = 0;
            this.lblSoBaoCho.Text = "0";
            this.lblSoBaoCho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTien
            // 
            this.pnlTien.BackColor = System.Drawing.Color.Transparent;
            this.pnlTien.BorderRadius = 20;
            this.pnlTien.Controls.Add(this.lblTongTien);
            this.pnlTien.Controls.Add(this.label6);
            this.pnlTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlTien.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.pnlTien.Location = new System.Drawing.Point(807, 3);
            this.pnlTien.Name = "pnlTien";
            this.pnlTien.Padding = new System.Windows.Forms.Padding(15);
            this.pnlTien.ShadowDecoration.Enabled = false;
            this.pnlTien.Size = new System.Drawing.Size(264, 168);
            this.pnlTien.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = false;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 35);
            this.label6.TabIndex = 1;
            this.label6.Text = "💰 Quỹ nhuận bút";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = false;
            this.lblTongTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongTien.BackColor = System.Drawing.Color.Transparent;
            // Đổi Font Size xuống 18F để tiền trăm tỷ không bị tràn thẻ
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.White;
            this.lblTongTien.Location = new System.Drawing.Point(15, 50);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(234, 103);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "0 ₫";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(13, 183);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlBieuDo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelRight);
            this.splitContainer1.Size = new System.Drawing.Size(1074, 469);
            this.splitContainer1.SplitterDistance = 700;
            this.splitContainer1.TabIndex = 1;
            // 
            // pnlBieuDo
            // 
            this.pnlBieuDo.BackColor = System.Drawing.Color.Transparent;
            this.pnlBieuDo.BorderRadius = 20;
            this.pnlBieuDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBieuDo.FillColor = System.Drawing.Color.White;
            this.pnlBieuDo.Location = new System.Drawing.Point(0, 0);
            this.pnlBieuDo.Name = "pnlBieuDo";
            this.pnlBieuDo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBieuDo.ShadowDecoration.Enabled = false;
            this.pnlBieuDo.Size = new System.Drawing.Size(700, 469);
            this.pnlBieuDo.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dgvHoatDong);
            this.panelRight.Controls.Add(this.label7);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.panelRight.Size = new System.Drawing.Size(370, 469);
            this.panelRight.TabIndex = 0;
            // 
            // dgvHoatDong
            // 
            this.dgvHoatDong.AllowUserToAddRows = false;
            this.dgvHoatDong.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(110)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoatDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoatDong.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoatDong.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoatDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoatDong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHoatDong.Location = new System.Drawing.Point(0, 55);
            this.dgvHoatDong.Name = "dgvHoatDong";
            this.dgvHoatDong.ReadOnly = true;
            this.dgvHoatDong.RowHeadersVisible = false;
            this.dgvHoatDong.Size = new System.Drawing.Size(370, 414);
            this.dgvHoatDong.TabIndex = 1;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHoatDong.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHoatDong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoatDong.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvHoatDong.ThemeStyle.ReadOnly = true;
            this.dgvHoatDong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoatDong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoatDong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHoatDong.ThemeStyle.RowsStyle.Height = 22;
            this.dgvHoatDong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHoatDong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(0, 20);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.label7.Size = new System.Drawing.Size(260, 35);
            this.label7.TabIndex = 0;
            this.label7.Text = "📋 Hoạt động gần đây";
            // 
            // FrmTongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlTitleBar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTongQuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng quan tòa soạn";
            this.Load += new System.EventHandler(this.FrmTongQuan_Load);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpCards.ResumeLayout(false);
            this.pnlTacGia.ResumeLayout(false);
            this.pnlTacGia.PerformLayout();
            this.pnlBaiViet.ResumeLayout(false);
            this.pnlBaiViet.PerformLayout();
            this.pnlSoBao.ResumeLayout(false);
            this.pnlSoBao.PerformLayout();
            this.pnlTien.ResumeLayout(false);
            this.pnlTien.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoatDong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlTitleBar;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picIcon;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlTacGia;
        private System.Windows.Forms.Label lblSoTacGia;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlBaiViet;
        private System.Windows.Forms.Label lblSoBaiViet;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlSoBao;
        private System.Windows.Forms.Label lblSoBaoCho;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Guna.UI2.WinForms.Guna2Panel pnlBieuDo;
        private System.Windows.Forms.Panel panelRight;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHoatDong;
        private System.Windows.Forms.Label label7;
    }
}