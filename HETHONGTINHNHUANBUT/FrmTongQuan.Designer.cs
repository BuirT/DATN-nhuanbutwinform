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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlLeftContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBieuDo = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTacGia = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSoTacGia = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBaiViet = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSoBaiViet = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSoBao = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSoBaoCho = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTien = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlRightSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvHoatDong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlClockWidget = new Guna.UI2.WinForms.Guna2Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlLeftContent.SuspendLayout();
            this.tlpCards.SuspendLayout();
            this.pnlTacGia.SuspendLayout();
            this.pnlBaiViet.SuspendLayout();
            this.pnlSoBao.SuspendLayout();
            this.pnlTien.SuspendLayout();
            this.pnlRightSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoatDong)).BeginInit();
            this.pnlClockWidget.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 70);
            this.pnlHeader.TabIndex = 4;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblWelcome.Location = new System.Drawing.Point(12, 13);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(343, 45);
            this.lblWelcome.TabIndex = 28;
            this.lblWelcome.Text = "Tổng Quan Hệ Thống";
            // 
            // pnlLeftContent
            // 
            this.pnlLeftContent.Controls.Add(this.pnlBieuDo);
            this.pnlLeftContent.Controls.Add(this.tlpCards);
            this.pnlLeftContent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftContent.Location = new System.Drawing.Point(0, 70);
            this.pnlLeftContent.Name = "pnlLeftContent";
            this.pnlLeftContent.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.pnlLeftContent.Size = new System.Drawing.Size(840, 730);
            this.pnlLeftContent.TabIndex = 5;
            // 
            // pnlBieuDo
            // 
            this.pnlBieuDo.BackColor = System.Drawing.Color.Transparent;
            this.pnlBieuDo.BorderRadius = 20;
            this.pnlBieuDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBieuDo.FillColor = System.Drawing.Color.White;
            this.pnlBieuDo.Location = new System.Drawing.Point(10, 150);
            this.pnlBieuDo.Name = "pnlBieuDo";
            this.pnlBieuDo.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBieuDo.ShadowDecoration.BorderRadius = 20;
            this.pnlBieuDo.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(229)))), ((int)(((byte)(236)))));
            this.pnlBieuDo.ShadowDecoration.Enabled = true;
            this.pnlBieuDo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 15, 15);
            this.pnlBieuDo.Size = new System.Drawing.Size(820, 570);
            this.pnlBieuDo.TabIndex = 1;
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
            this.tlpCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpCards.Location = new System.Drawing.Point(10, 0);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCards.Size = new System.Drawing.Size(820, 150);
            this.tlpCards.TabIndex = 0;
            // 
            // pnlTacGia
            // 
            this.pnlTacGia.BackColor = System.Drawing.Color.Transparent;
            this.pnlTacGia.BorderRadius = 15;
            this.pnlTacGia.Controls.Add(this.lblSoTacGia);
            this.pnlTacGia.Controls.Add(this.label2);
            this.pnlTacGia.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.pnlTacGia.CustomBorderThickness = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlTacGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTacGia.FillColor = System.Drawing.Color.White;
            this.pnlTacGia.Location = new System.Drawing.Point(5, 10);
            this.pnlTacGia.Margin = new System.Windows.Forms.Padding(5, 10, 5, 20);
            this.pnlTacGia.Name = "pnlTacGia";
            this.pnlTacGia.Padding = new System.Windows.Forms.Padding(15, 10, 10, 10);
            this.pnlTacGia.ShadowDecoration.BorderRadius = 15;
            this.pnlTacGia.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(229)))), ((int)(((byte)(236)))));
            this.pnlTacGia.ShadowDecoration.Enabled = true;
            this.pnlTacGia.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 15, 15);
            this.pnlTacGia.Size = new System.Drawing.Size(195, 120);
            this.pnlTacGia.TabIndex = 0;
            // 
            // lblSoTacGia
            // 
            this.lblSoTacGia.BackColor = System.Drawing.Color.Transparent;
            this.lblSoTacGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoTacGia.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoTacGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblSoTacGia.Location = new System.Drawing.Point(15, 38);
            this.lblSoTacGia.Name = "lblSoTacGia";
            this.lblSoTacGia.Size = new System.Drawing.Size(170, 72);
            this.lblSoTacGia.TabIndex = 0;
            this.lblSoTacGia.Text = "0";
            this.lblSoTacGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(186)))));
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "TÁC GIẢ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBaiViet
            // 
            this.pnlBaiViet.BackColor = System.Drawing.Color.Transparent;
            this.pnlBaiViet.BorderRadius = 15;
            this.pnlBaiViet.Controls.Add(this.lblSoBaiViet);
            this.pnlBaiViet.Controls.Add(this.label3);
            this.pnlBaiViet.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.pnlBaiViet.CustomBorderThickness = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlBaiViet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBaiViet.FillColor = System.Drawing.Color.White;
            this.pnlBaiViet.Location = new System.Drawing.Point(210, 10);
            this.pnlBaiViet.Margin = new System.Windows.Forms.Padding(5, 10, 5, 20);
            this.pnlBaiViet.Name = "pnlBaiViet";
            this.pnlBaiViet.Padding = new System.Windows.Forms.Padding(15, 10, 10, 10);
            this.pnlBaiViet.ShadowDecoration.BorderRadius = 15;
            this.pnlBaiViet.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(229)))), ((int)(((byte)(236)))));
            this.pnlBaiViet.ShadowDecoration.Enabled = true;
            this.pnlBaiViet.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 15, 15);
            this.pnlBaiViet.Size = new System.Drawing.Size(195, 120);
            this.pnlBaiViet.TabIndex = 1;
            // 
            // lblSoBaiViet
            // 
            this.lblSoBaiViet.BackColor = System.Drawing.Color.Transparent;
            this.lblSoBaiViet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoBaiViet.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoBaiViet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblSoBaiViet.Location = new System.Drawing.Point(15, 38);
            this.lblSoBaiViet.Name = "lblSoBaiViet";
            this.lblSoBaiViet.Size = new System.Drawing.Size(170, 72);
            this.lblSoBaiViet.TabIndex = 0;
            this.lblSoBaiViet.Text = "0";
            this.lblSoBaiViet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(186)))));
            this.label3.Location = new System.Drawing.Point(15, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "BÀI VIẾT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSoBao
            // 
            this.pnlSoBao.BackColor = System.Drawing.Color.Transparent;
            this.pnlSoBao.BorderRadius = 15;
            this.pnlSoBao.Controls.Add(this.lblSoBaoCho);
            this.pnlSoBao.Controls.Add(this.label4);
            this.pnlSoBao.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.pnlSoBao.CustomBorderThickness = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlSoBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSoBao.FillColor = System.Drawing.Color.White;
            this.pnlSoBao.Location = new System.Drawing.Point(415, 10);
            this.pnlSoBao.Margin = new System.Windows.Forms.Padding(5, 10, 5, 20);
            this.pnlSoBao.Name = "pnlSoBao";
            this.pnlSoBao.Padding = new System.Windows.Forms.Padding(15, 10, 10, 10);
            this.pnlSoBao.ShadowDecoration.BorderRadius = 15;
            this.pnlSoBao.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(229)))), ((int)(((byte)(236)))));
            this.pnlSoBao.ShadowDecoration.Enabled = true;
            this.pnlSoBao.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 15, 15);
            this.pnlSoBao.Size = new System.Drawing.Size(195, 120);
            this.pnlSoBao.TabIndex = 2;
            // 
            // lblSoBaoCho
            // 
            this.lblSoBaoCho.BackColor = System.Drawing.Color.Transparent;
            this.lblSoBaoCho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoBaoCho.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoBaoCho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblSoBaoCho.Location = new System.Drawing.Point(15, 38);
            this.lblSoBaoCho.Name = "lblSoBaoCho";
            this.lblSoBaoCho.Size = new System.Drawing.Size(170, 72);
            this.lblSoBaoCho.TabIndex = 0;
            this.lblSoBaoCho.Text = "0";
            this.lblSoBaoCho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(186)))));
            this.label4.Location = new System.Drawing.Point(15, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "CHỜ DUYỆT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTien
            // 
            this.pnlTien.BackColor = System.Drawing.Color.Transparent;
            this.pnlTien.BorderRadius = 15;
            this.pnlTien.Controls.Add(this.lblTongTien);
            this.pnlTien.Controls.Add(this.label6);
            this.pnlTien.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.pnlTien.CustomBorderThickness = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pnlTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTien.FillColor = System.Drawing.Color.White;
            this.pnlTien.Location = new System.Drawing.Point(620, 10);
            this.pnlTien.Margin = new System.Windows.Forms.Padding(5, 10, 5, 20);
            this.pnlTien.Name = "pnlTien";
            this.pnlTien.Padding = new System.Windows.Forms.Padding(15, 10, 10, 10);
            this.pnlTien.ShadowDecoration.BorderRadius = 15;
            this.pnlTien.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(229)))), ((int)(((byte)(236)))));
            this.pnlTien.ShadowDecoration.Enabled = true;
            this.pnlTien.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 15, 15);
            this.pnlTien.Size = new System.Drawing.Size(195, 120);
            this.pnlTien.TabIndex = 3;
            // 
            // lblTongTien
            // 
            this.lblTongTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTongTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.lblTongTien.Location = new System.Drawing.Point(15, 38);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(170, 72);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "0 ₫";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(186)))));
            this.label6.Location = new System.Drawing.Point(15, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "QUỸ NHUẬN BÚT";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRightSidebar
            // 
            this.pnlRightSidebar.Controls.Add(this.dgvHoatDong);
            this.pnlRightSidebar.Controls.Add(this.pnlClockWidget);
            this.pnlRightSidebar.Controls.Add(this.label7);
            this.pnlRightSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightSidebar.Location = new System.Drawing.Point(840, 70);
            this.pnlRightSidebar.Name = "pnlRightSidebar";
            this.pnlRightSidebar.Padding = new System.Windows.Forms.Padding(10, 0, 15, 10);
            this.pnlRightSidebar.Size = new System.Drawing.Size(360, 730);
            this.pnlRightSidebar.TabIndex = 6;
            // 
            // dgvHoatDong
            // 
            this.dgvHoatDong.AllowUserToAddRows = false;
            this.dgvHoatDong.AllowUserToDeleteRows = false;
            this.dgvHoatDong.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.dgvHoatDong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoatDong.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoatDong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHoatDong.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoatDong.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoatDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoatDong.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoatDong.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoatDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoatDong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.dgvHoatDong.Location = new System.Drawing.Point(10, 110);
            this.dgvHoatDong.Name = "dgvHoatDong";
            this.dgvHoatDong.ReadOnly = true;
            this.dgvHoatDong.RowHeadersVisible = false;
            this.dgvHoatDong.RowTemplate.Height = 35;
            this.dgvHoatDong.Size = new System.Drawing.Size(335, 610);
            this.dgvHoatDong.TabIndex = 1;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.dgvHoatDong.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHoatDong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(186)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoatDong.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvHoatDong.ThemeStyle.ReadOnly = true;
            this.dgvHoatDong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoatDong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dgvHoatDong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.dgvHoatDong.ThemeStyle.RowsStyle.Height = 35;
            this.dgvHoatDong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvHoatDong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            // 
            // pnlClockWidget
            // 
            this.pnlClockWidget.BackColor = System.Drawing.Color.Transparent;
            this.pnlClockWidget.BorderRadius = 15;
            this.pnlClockWidget.Controls.Add(this.lblClock);
            this.pnlClockWidget.Controls.Add(this.label1);
            this.pnlClockWidget.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClockWidget.FillColor = System.Drawing.Color.White;
            this.pnlClockWidget.Location = new System.Drawing.Point(10, 0);
            this.pnlClockWidget.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.pnlClockWidget.Name = "pnlClockWidget";
            this.pnlClockWidget.Padding = new System.Windows.Forms.Padding(15);
            this.pnlClockWidget.ShadowDecoration.BorderRadius = 15;
            this.pnlClockWidget.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(229)))), ((int)(((byte)(236)))));
            this.pnlClockWidget.ShadowDecoration.Enabled = true;
            this.pnlClockWidget.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 15, 15);
            this.pnlClockWidget.Size = new System.Drawing.Size(335, 110);
            this.pnlClockWidget.TabIndex = 2;
            // 
            // lblClock
            // 
            this.lblClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(97)))), ((int)(((byte)(238)))));
            this.lblClock.Location = new System.Drawing.Point(15, 45);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(305, 50);
            this.lblClock.TabIndex = 27;
            this.lblClock.Text = "00:00:00";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(155)))), ((int)(((byte)(186)))));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "THỜI GIAN HỆ THỐNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(66)))));
            this.label7.Location = new System.Drawing.Point(10, 120);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label7.Size = new System.Drawing.Size(161, 31);
            this.label7.TabIndex = 0;
            this.label7.Text = "Hoạt Động Gần Đây";
            // 
            // FrmTongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlRightSidebar);
            this.Controls.Add(this.pnlLeftContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmTongQuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng quan tòa soạn";
            this.Load += new System.EventHandler(this.FrmTongQuan_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeftContent.ResumeLayout(false);
            this.tlpCards.ResumeLayout(false);
            this.pnlTacGia.ResumeLayout(false);
            this.pnlBaiViet.ResumeLayout(false);
            this.pnlSoBao.ResumeLayout(false);
            this.pnlTien.ResumeLayout(false);
            this.pnlRightSidebar.ResumeLayout(false);
            this.pnlRightSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoatDong)).EndInit();
            this.pnlClockWidget.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private Guna.UI2.WinForms.Guna2Panel pnlLeftContent;
        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private Guna.UI2.WinForms.Guna2Panel pnlTacGia;
        private System.Windows.Forms.Label lblSoTacGia;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel pnlBaiViet;
        private System.Windows.Forms.Label lblSoBaiViet;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel pnlSoBao;
        private System.Windows.Forms.Label lblSoBaoCho;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel pnlTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Panel pnlBieuDo;
        private Guna.UI2.WinForms.Guna2Panel pnlRightSidebar;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHoatDong;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Panel pnlClockWidget;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label label1;
    }
}