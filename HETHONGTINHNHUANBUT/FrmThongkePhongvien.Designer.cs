namespace HETHONGTINHNHUANBUT
{
    partial class FrmThongkePhongvien
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSummary1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongBai = new System.Windows.Forms.Label();
            this.lblTongBaiTieuDe = new System.Windows.Forms.Label();
            this.pnlSummary2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTongTienTieuDe = new System.Windows.Forms.Label();
            this.pnlSummary3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDaDuyet = new System.Windows.Forms.Label();
            this.lblDaDuyetTieuDe = new System.Windows.Forms.Label();
            this.pnlSummary4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTienThangNay = new System.Windows.Forms.Label();
            this.lblTienThangNayTieuDe = new System.Windows.Forms.Label();
            this.pnlSummary5 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTienNamNay = new System.Windows.Forms.Label();
            this.lblTienNamNayTieuDe = new System.Windows.Forms.Label();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvTraCuu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cboButDanh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblLocButDanh = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlSummary1.SuspendLayout();
            this.pnlSummary2.SuspendLayout();
            this.pnlSummary3.SuspendLayout();
            this.pnlSummary4.SuspendLayout();
            this.pnlSummary5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraCuu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.pnlSummary1);
            this.pnlTop.Controls.Add(this.pnlSummary2);
            this.pnlTop.Controls.Add(this.pnlSummary3);
            this.pnlTop.Controls.Add(this.pnlSummary4);
            this.pnlTop.Controls.Add(this.pnlSummary5);
            this.pnlTop.Controls.Add(this.cboButDanh);
            this.pnlTop.Controls.Add(this.lblLocButDanh);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(30, 20);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1375, 160);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THỐNG KÊ CÁ NHÂN";
            // 
            // pnlSummary1
            // 
            this.pnlSummary1.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary1.BorderRadius = 10;
            this.pnlSummary1.Controls.Add(this.lblTongBai);
            this.pnlSummary1.Controls.Add(this.lblTongBaiTieuDe);
            this.pnlSummary1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlSummary1.Location = new System.Drawing.Point(25, 60);
            this.pnlSummary1.Name = "pnlSummary1";
            this.pnlSummary1.Size = new System.Drawing.Size(250, 80);
            this.pnlSummary1.TabIndex = 1;
            // 
            // lblTongBai
            // 
            this.lblTongBai.AutoSize = true;
            this.lblTongBai.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongBai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTongBai.Location = new System.Drawing.Point(14, 38);
            this.lblTongBai.Name = "lblTongBai";
            this.lblTongBai.Size = new System.Drawing.Size(26, 30);
            this.lblTongBai.TabIndex = 1;
            this.lblTongBai.Text = "0";
            // 
            // lblTongBaiTieuDe
            // 
            this.lblTongBaiTieuDe.AutoSize = true;
            this.lblTongBaiTieuDe.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongBaiTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTongBaiTieuDe.Location = new System.Drawing.Point(15, 15);
            this.lblTongBaiTieuDe.Name = "lblTongBaiTieuDe";
            this.lblTongBaiTieuDe.Size = new System.Drawing.Size(80, 19);
            this.lblTongBaiTieuDe.TabIndex = 0;
            this.lblTongBaiTieuDe.Text = "Tổng số bài";
            // 
            // pnlSummary2
            // 
            this.pnlSummary2.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary2.BorderRadius = 10;
            this.pnlSummary2.Controls.Add(this.lblTongTien);
            this.pnlSummary2.Controls.Add(this.lblTongTienTieuDe);
            this.pnlSummary2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlSummary2.Location = new System.Drawing.Point(295, 60);
            this.pnlSummary2.Name = "pnlSummary2";
            this.pnlSummary2.Size = new System.Drawing.Size(250, 80);
            this.pnlSummary2.TabIndex = 2;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTongTien.Location = new System.Drawing.Point(14, 38);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(80, 30);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "0 VNĐ";
            // 
            // lblTongTienTieuDe
            // 
            this.lblTongTienTieuDe.AutoSize = true;
            this.lblTongTienTieuDe.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTongTienTieuDe.Location = new System.Drawing.Point(15, 15);
            this.lblTongTienTieuDe.Name = "lblTongTienTieuDe";
            this.lblTongTienTieuDe.Size = new System.Drawing.Size(108, 19);
            this.lblTongTienTieuDe.TabIndex = 0;
            this.lblTongTienTieuDe.Text = "Tổng nhuận bút";
            // 
            // pnlSummary3
            // 
            this.pnlSummary3.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary3.BorderRadius = 10;
            this.pnlSummary3.Controls.Add(this.lblDaDuyet);
            this.pnlSummary3.Controls.Add(this.lblDaDuyetTieuDe);
            this.pnlSummary3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlSummary3.Location = new System.Drawing.Point(565, 60);
            this.pnlSummary3.Name = "pnlSummary3";
            this.pnlSummary3.Size = new System.Drawing.Size(250, 80);
            this.pnlSummary3.TabIndex = 3;
            // 
            // lblDaDuyet
            // 
            this.lblDaDuyet.AutoSize = true;
            this.lblDaDuyet.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaDuyet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblDaDuyet.Location = new System.Drawing.Point(14, 38);
            this.lblDaDuyet.Name = "lblDaDuyet";
            this.lblDaDuyet.Size = new System.Drawing.Size(26, 30);
            this.lblDaDuyet.TabIndex = 1;
            this.lblDaDuyet.Text = "0";
            // 
            // lblDaDuyetTieuDe
            // 
            this.lblDaDuyetTieuDe.AutoSize = true;
            this.lblDaDuyetTieuDe.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaDuyetTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDaDuyetTieuDe.Location = new System.Drawing.Point(15, 15);
            this.lblDaDuyetTieuDe.Name = "lblDaDuyetTieuDe";
            this.lblDaDuyetTieuDe.Size = new System.Drawing.Size(85, 19);
            this.lblDaDuyetTieuDe.TabIndex = 0;
            this.lblDaDuyetTieuDe.Text = "Bài đã duyệt";
            // 
            // pnlSummary4
            // 
            this.pnlSummary4.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary4.BorderRadius = 10;
            this.pnlSummary4.Controls.Add(this.lblTienThangNay);
            this.pnlSummary4.Controls.Add(this.lblTienThangNayTieuDe);
            this.pnlSummary4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlSummary4.Location = new System.Drawing.Point(835, 60);
            this.pnlSummary4.Name = "pnlSummary4";
            this.pnlSummary4.Size = new System.Drawing.Size(250, 80);
            this.pnlSummary4.TabIndex = 6;
            // 
            // lblTienThangNay
            // 
            this.lblTienThangNay.AutoSize = true;
            this.lblTienThangNay.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienThangNay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTienThangNay.Location = new System.Drawing.Point(14, 38);
            this.lblTienThangNay.Name = "lblTienThangNay";
            this.lblTienThangNay.Size = new System.Drawing.Size(80, 30);
            this.lblTienThangNay.TabIndex = 1;
            this.lblTienThangNay.Text = "0 VNĐ";
            // 
            // lblTienThangNayTieuDe
            // 
            this.lblTienThangNayTieuDe.AutoSize = true;
            this.lblTienThangNayTieuDe.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienThangNayTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTienThangNayTieuDe.Location = new System.Drawing.Point(15, 15);
            this.lblTienThangNayTieuDe.Name = "lblTienThangNayTieuDe";
            this.lblTienThangNayTieuDe.Size = new System.Drawing.Size(108, 19);
            this.lblTienThangNayTieuDe.TabIndex = 0;
            this.lblTienThangNayTieuDe.Text = "Tháng này";
            // 
            // pnlSummary5
            // 
            this.pnlSummary5.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary5.BorderRadius = 10;
            this.pnlSummary5.Controls.Add(this.lblTienNamNay);
            this.pnlSummary5.Controls.Add(this.lblTienNamNayTieuDe);
            this.pnlSummary5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlSummary5.Location = new System.Drawing.Point(1105, 60);
            this.pnlSummary5.Name = "pnlSummary5";
            this.pnlSummary5.Size = new System.Drawing.Size(250, 80);
            this.pnlSummary5.TabIndex = 7;
            // 
            // lblTienNamNay
            // 
            this.lblTienNamNay.AutoSize = true;
            this.lblTienNamNay.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNamNay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.lblTienNamNay.Location = new System.Drawing.Point(14, 38);
            this.lblTienNamNay.Name = "lblTienNamNay";
            this.lblTienNamNay.Size = new System.Drawing.Size(80, 30);
            this.lblTienNamNay.TabIndex = 1;
            this.lblTienNamNay.Text = "0 VNĐ";
            // 
            // lblTienNamNayTieuDe
            // 
            this.lblTienNamNayTieuDe.AutoSize = true;
            this.lblTienNamNayTieuDe.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienNamNayTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTienNamNayTieuDe.Location = new System.Drawing.Point(15, 15);
            this.lblTienNamNayTieuDe.Name = "lblTienNamNayTieuDe";
            this.lblTienNamNayTieuDe.Size = new System.Drawing.Size(108, 19);
            this.lblTienNamNayTieuDe.TabIndex = 0;
            this.lblTienNamNayTieuDe.Text = "Năm nay";
            // 
            // lblLocButDanh
            // 
            this.lblLocButDanh.AutoSize = true;
            this.lblLocButDanh.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocButDanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLocButDanh.Location = new System.Drawing.Point(850, 20);
            this.lblLocButDanh.Name = "lblLocButDanh";
            this.lblLocButDanh.Size = new System.Drawing.Size(127, 19);
            this.lblLocButDanh.TabIndex = 4;
            this.lblLocButDanh.Text = "Lọc theo Bút danh:";
            // 
            // cboButDanh
            // 
            this.cboButDanh.BackColor = System.Drawing.Color.Transparent;
            this.cboButDanh.BorderRadius = 8;
            this.cboButDanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboButDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboButDanh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboButDanh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboButDanh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboButDanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboButDanh.ItemHeight = 30;
            this.cboButDanh.Location = new System.Drawing.Point(985, 12);
            this.cboButDanh.Name = "cboButDanh";
            this.cboButDanh.Size = new System.Drawing.Size(250, 36);
            this.cboButDanh.TabIndex = 5;
            this.cboButDanh.SelectedIndexChanged += new System.EventHandler(this.cboButDanh_SelectedIndexChanged);
            // 
            // chartPie
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPie.Legends.Add(legend1);
            this.chartPie.Location = new System.Drawing.Point(30, 200);
            this.chartPie.Name = "chartPie";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPie.Series.Add(series1);
            this.chartPie.Size = new System.Drawing.Size(699, 250);
            this.chartPie.TabIndex = 1;
            this.chartPie.Text = "Trạng thái bài viết";
            // 
            // chartBar
            // 
            chartArea2.Name = "ChartArea1";
            this.chartBar.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartBar.Legends.Add(legend2);
            this.chartBar.Location = new System.Drawing.Point(775, 200);
            this.chartBar.Name = "chartBar";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartBar.Series.Add(series2);
            this.chartBar.Size = new System.Drawing.Size(630, 250);
            this.chartBar.TabIndex = 2;
            this.chartBar.Text = "Thu nhập 6 tháng gần nhất";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.BorderRadius = 16;
            this.pnlBottom.Controls.Add(this.dgvTraCuu);
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(30, 470);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBottom.Size = new System.Drawing.Size(1375, 310);
            this.pnlBottom.TabIndex = 3;
            // 
            // dgvTraCuu
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTraCuu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTraCuu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTraCuu.ColumnHeadersHeight = 40;
            this.dgvTraCuu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTraCuu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTraCuu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraCuu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTraCuu.Location = new System.Drawing.Point(15, 15);
            this.dgvTraCuu.Name = "dgvTraCuu";
            this.dgvTraCuu.ReadOnly = true;
            this.dgvTraCuu.RowHeadersVisible = false;
            this.dgvTraCuu.Size = new System.Drawing.Size(1345, 280);
            this.dgvTraCuu.TabIndex = 0;
            this.dgvTraCuu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTraCuu.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTraCuu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTraCuu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTraCuu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTraCuu.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTraCuu.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTraCuu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTraCuu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTraCuu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTraCuu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTraCuu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTraCuu.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvTraCuu.ThemeStyle.ReadOnly = true;
            this.dgvTraCuu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTraCuu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTraCuu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTraCuu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTraCuu.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTraCuu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTraCuu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FrmThongkePhongvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1435, 800);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.chartBar);
            this.Controls.Add(this.chartPie);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmThongkePhongvien";
            this.Text = "Thống kê phóng viên";
            this.Load += new System.EventHandler(this.FrmThongkePhongvien_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSummary1.ResumeLayout(false);
            this.pnlSummary1.PerformLayout();
            this.pnlSummary2.ResumeLayout(false);
            this.pnlSummary2.PerformLayout();
            this.pnlSummary3.ResumeLayout(false);
            this.pnlSummary3.PerformLayout();
            this.pnlSummary4.ResumeLayout(false);
            this.pnlSummary4.PerformLayout();
            this.pnlSummary5.ResumeLayout(false);
            this.pnlSummary5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraCuu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlSummary1;
        private System.Windows.Forms.Label lblTongBaiTieuDe;
        private System.Windows.Forms.Label lblTongBai;
        private Guna.UI2.WinForms.Guna2Panel pnlSummary2;
        private System.Windows.Forms.Label lblTongTienTieuDe;
        private System.Windows.Forms.Label lblTongTien;
        private Guna.UI2.WinForms.Guna2Panel pnlSummary3;
        private System.Windows.Forms.Label lblDaDuyetTieuDe;
        private System.Windows.Forms.Label lblDaDuyet;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBar;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTraCuu;
        private Guna.UI2.WinForms.Guna2ComboBox cboButDanh;
        private System.Windows.Forms.Label lblLocButDanh;
        private Guna.UI2.WinForms.Guna2Panel pnlSummary4;
        private System.Windows.Forms.Label lblTienThangNayTieuDe;
        private System.Windows.Forms.Label lblTienThangNay;
        private Guna.UI2.WinForms.Guna2Panel pnlSummary5;
        private System.Windows.Forms.Label lblTienNamNayTieuDe;
        private System.Windows.Forms.Label lblTienNamNay;
    }
}
