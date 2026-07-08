using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblWelcome;
        private Guna.UI2.WinForms.Guna2Button btnAIPhanTich;
        private TableLayoutPanel tlpKPI;
        private TableLayoutPanel tlpCharts;
        private Guna2Panel pnlGridBox;
        private Label lblGridTitle;
        private Label lblBaiVietValue;
        private Label lblPhongVienValue;
        private Label lblNhuanButValue;
        private Label lblBaiChuaDuyetValue;
        private Label lblPhieuChiValue;
        private Label lblCanhBaoValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.Charts.WinForms.ChartFont chartFont65 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont66 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont67 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont68 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid25 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick25 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont69 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid26 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick26 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont70 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid27 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel9 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont71 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick27 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont72 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont73 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont74 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont75 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont76 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid28 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick28 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont77 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid29 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick29 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont78 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid30 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel10 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont79 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick30 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont80 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont81 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont82 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont83 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont84 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid31 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick31 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont85 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid32 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick32 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont86 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid33 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel11 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont87 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick33 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont88 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont89 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont90 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont91 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont92 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid34 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick34 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont93 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid35 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick35 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont94 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid36 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel12 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont95 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick36 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont96 = new Guna.Charts.WinForms.ChartFont();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartPanel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.chartNBThang = new Guna.Charts.WinForms.GunaChart();
            this.lblChartTitle1 = new System.Windows.Forms.Label();
            this.chartPanel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.chartTopPV = new Guna.Charts.WinForms.GunaChart();
            this.lblChartTitle2 = new System.Windows.Forms.Label();
            this.chartPanel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.chartBaiTheoCM = new Guna.Charts.WinForms.GunaChart();
            this.lblChartTitle3 = new System.Windows.Forms.Label();
            this.chartPanel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.chartDiemAI = new Guna.Charts.WinForms.GunaChart();
            this.lblChartTitle4 = new System.Windows.Forms.Label();
            this.pnlGridBox = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvHoatDong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.tlpKPI = new System.Windows.Forms.TableLayoutPanel();
            this.card1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblIcon1 = new System.Windows.Forms.Label();
            this.lblBaiVietValue = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.card2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblIcon2 = new System.Windows.Forms.Label();
            this.lblPhongVienValue = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.card3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblIcon3 = new System.Windows.Forms.Label();
            this.lblNhuanButValue = new System.Windows.Forms.Label();
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.card4 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblIcon4 = new System.Windows.Forms.Label();
            this.lblBaiChuaDuyetValue = new System.Windows.Forms.Label();
            this.lblTitle4 = new System.Windows.Forms.Label();
            this.card5 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblIcon5 = new System.Windows.Forms.Label();
            this.lblPhieuChiValue = new System.Windows.Forms.Label();
            this.lblTitle5 = new System.Windows.Forms.Label();
            this.card6 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblIcon6 = new System.Windows.Forms.Label();
            this.lblCanhBaoValue = new System.Windows.Forms.Label();
            this.lblTitle6 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnAIPhanTich = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            this.tlpCharts.SuspendLayout();
            this.chartPanel1.SuspendLayout();
            this.chartPanel2.SuspendLayout();
            this.chartPanel3.SuspendLayout();
            this.chartPanel4.SuspendLayout();
            this.pnlGridBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoatDong)).BeginInit();
            this.tlpKPI.SuspendLayout();
            this.card1.SuspendLayout();
            this.card2.SuspendLayout();
            this.card3.SuspendLayout();
            this.card4.SuspendLayout();
            this.card5.SuspendLayout();
            this.card6.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.tlpCharts);
            this.pnlMain.Controls.Add(this.pnlGridBox);
            this.pnlMain.Controls.Add(this.tlpKPI);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(20, 15);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1228, 545);
            this.pnlMain.TabIndex = 1;
            // 
            // tlpCharts
            // 
            this.tlpCharts.ColumnCount = 2;
            this.tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.Controls.Add(this.chartPanel1, 0, 0);
            this.tlpCharts.Controls.Add(this.chartPanel2, 1, 0);
            this.tlpCharts.Controls.Add(this.chartPanel3, 0, 1);
            this.tlpCharts.Controls.Add(this.chartPanel4, 1, 1);
            this.tlpCharts.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpCharts.Location = new System.Drawing.Point(0, 641);
            this.tlpCharts.Name = "tlpCharts";
            this.tlpCharts.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.tlpCharts.RowCount = 2;
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.Size = new System.Drawing.Size(1211, 720);
            this.tlpCharts.TabIndex = 3;
            // 
            // chartPanel1
            // 
            this.chartPanel1.BackColor = System.Drawing.Color.Transparent;
            this.chartPanel1.BorderRadius = 12;
            this.chartPanel1.Controls.Add(this.chartNBThang);
            this.chartPanel1.Controls.Add(this.lblChartTitle1);
            this.chartPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel1.FillColor = System.Drawing.Color.White;
            this.chartPanel1.Location = new System.Drawing.Point(0, 12);
            this.chartPanel1.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.chartPanel1.Name = "chartPanel1";
            this.chartPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.chartPanel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chartPanel1.ShadowDecoration.Depth = 6;
            this.chartPanel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.chartPanel1.Size = new System.Drawing.Size(599, 342);
            this.chartPanel1.TabIndex = 0;
            // 
            // chartNBThang
            // 
            this.chartNBThang.Dock = System.Windows.Forms.DockStyle.Fill;
            chartFont65.FontName = "Arial";
            this.chartNBThang.Legend.LabelFont = chartFont65;
            this.chartNBThang.Location = new System.Drawing.Point(15, 50);
            this.chartNBThang.Name = "chartNBThang";
            this.chartNBThang.Size = new System.Drawing.Size(569, 277);
            this.chartNBThang.TabIndex = 1;
            chartFont66.FontName = "Arial";
            chartFont66.Size = 12;
            chartFont66.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chartNBThang.Title.Font = chartFont66;
            chartFont67.FontName = "Arial";
            this.chartNBThang.Tooltips.BodyFont = chartFont67;
            chartFont68.FontName = "Arial";
            chartFont68.Size = 9;
            chartFont68.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chartNBThang.Tooltips.TitleFont = chartFont68;
            grid25.Display = false;
            this.chartNBThang.XAxes.GridLines = grid25;
            chartFont69.FontName = "Arial";
            tick25.Font = chartFont69;
            this.chartNBThang.XAxes.Ticks = tick25;
            this.chartNBThang.YAxes.GridLines = grid26;
            chartFont70.FontName = "Arial";
            tick26.Font = chartFont70;
            this.chartNBThang.YAxes.Ticks = tick26;
            this.chartNBThang.ZAxes.GridLines = grid27;
            chartFont71.FontName = "Arial";
            pointLabel9.Font = chartFont71;
            this.chartNBThang.ZAxes.PointLabels = pointLabel9;
            chartFont72.FontName = "Arial";
            tick27.Font = chartFont72;
            this.chartNBThang.ZAxes.Ticks = tick27;
            // 
            // lblChartTitle1
            // 
            this.lblChartTitle1.BackColor = System.Drawing.Color.Transparent;
            this.lblChartTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartTitle1.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle1.Name = "lblChartTitle1";
            this.lblChartTitle1.Size = new System.Drawing.Size(569, 35);
            this.lblChartTitle1.TabIndex = 0;
            this.lblChartTitle1.Text = "NHUẬN BÚT THEO THÁNG";
            this.lblChartTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartPanel2
            // 
            this.chartPanel2.BackColor = System.Drawing.Color.Transparent;
            this.chartPanel2.BorderRadius = 12;
            this.chartPanel2.Controls.Add(this.chartTopPV);
            this.chartPanel2.Controls.Add(this.lblChartTitle2);
            this.chartPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel2.FillColor = System.Drawing.Color.White;
            this.chartPanel2.Location = new System.Drawing.Point(611, 12);
            this.chartPanel2.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.chartPanel2.Name = "chartPanel2";
            this.chartPanel2.Padding = new System.Windows.Forms.Padding(15);
            this.chartPanel2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chartPanel2.ShadowDecoration.Depth = 6;
            this.chartPanel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.chartPanel2.Size = new System.Drawing.Size(600, 342);
            this.chartPanel2.TabIndex = 1;
            // 
            // chartTopPV
            // 
            this.chartTopPV.Dock = System.Windows.Forms.DockStyle.Fill;
            chartFont73.FontName = "Arial";
            this.chartTopPV.Legend.LabelFont = chartFont73;
            this.chartTopPV.Location = new System.Drawing.Point(15, 50);
            this.chartTopPV.Name = "chartTopPV";
            this.chartTopPV.Size = new System.Drawing.Size(570, 277);
            this.chartTopPV.TabIndex = 1;
            chartFont74.FontName = "Arial";
            chartFont74.Size = 12;
            chartFont74.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chartTopPV.Title.Font = chartFont74;
            chartFont75.FontName = "Arial";
            this.chartTopPV.Tooltips.BodyFont = chartFont75;
            chartFont76.FontName = "Arial";
            chartFont76.Size = 9;
            chartFont76.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chartTopPV.Tooltips.TitleFont = chartFont76;
            this.chartTopPV.XAxes.GridLines = grid28;
            chartFont77.FontName = "Arial";
            tick28.Font = chartFont77;
            this.chartTopPV.XAxes.Ticks = tick28;
            grid29.Display = false;
            this.chartTopPV.YAxes.GridLines = grid29;
            chartFont78.FontName = "Arial";
            tick29.Font = chartFont78;
            this.chartTopPV.YAxes.Ticks = tick29;
            this.chartTopPV.ZAxes.GridLines = grid30;
            chartFont79.FontName = "Arial";
            pointLabel10.Font = chartFont79;
            this.chartTopPV.ZAxes.PointLabels = pointLabel10;
            chartFont80.FontName = "Arial";
            tick30.Font = chartFont80;
            this.chartTopPV.ZAxes.Ticks = tick30;
            // 
            // lblChartTitle2
            // 
            this.lblChartTitle2.BackColor = System.Drawing.Color.Transparent;
            this.lblChartTitle2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartTitle2.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle2.Name = "lblChartTitle2";
            this.lblChartTitle2.Size = new System.Drawing.Size(570, 35);
            this.lblChartTitle2.TabIndex = 0;
            this.lblChartTitle2.Text = "TOP 10 PV NHẬN NHUẬN BÚT";
            this.lblChartTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartPanel3
            // 
            this.chartPanel3.BackColor = System.Drawing.Color.Transparent;
            this.chartPanel3.BorderRadius = 12;
            this.chartPanel3.Controls.Add(this.chartBaiTheoCM);
            this.chartPanel3.Controls.Add(this.lblChartTitle3);
            this.chartPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel3.FillColor = System.Drawing.Color.White;
            this.chartPanel3.Location = new System.Drawing.Point(0, 366);
            this.chartPanel3.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.chartPanel3.Name = "chartPanel3";
            this.chartPanel3.Padding = new System.Windows.Forms.Padding(15);
            this.chartPanel3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chartPanel3.ShadowDecoration.Depth = 6;
            this.chartPanel3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.chartPanel3.Size = new System.Drawing.Size(599, 342);
            this.chartPanel3.TabIndex = 2;
            // 
            // chartBaiTheoCM
            // 
            this.chartBaiTheoCM.Dock = System.Windows.Forms.DockStyle.Fill;
            chartFont81.FontName = "Arial";
            this.chartBaiTheoCM.Legend.LabelFont = chartFont81;
            this.chartBaiTheoCM.Location = new System.Drawing.Point(15, 50);
            this.chartBaiTheoCM.Name = "chartBaiTheoCM";
            this.chartBaiTheoCM.Size = new System.Drawing.Size(569, 277);
            this.chartBaiTheoCM.TabIndex = 1;
            chartFont82.FontName = "Arial";
            chartFont82.Size = 12;
            chartFont82.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chartBaiTheoCM.Title.Font = chartFont82;
            chartFont83.FontName = "Arial";
            this.chartBaiTheoCM.Tooltips.BodyFont = chartFont83;
            chartFont84.FontName = "Arial";
            chartFont84.Size = 9;
            chartFont84.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chartBaiTheoCM.Tooltips.TitleFont = chartFont84;
            this.chartBaiTheoCM.XAxes.GridLines = grid31;
            chartFont85.FontName = "Arial";
            tick31.Font = chartFont85;
            this.chartBaiTheoCM.XAxes.Ticks = tick31;
            this.chartBaiTheoCM.YAxes.GridLines = grid32;
            chartFont86.FontName = "Arial";
            tick32.Font = chartFont86;
            this.chartBaiTheoCM.YAxes.Ticks = tick32;
            this.chartBaiTheoCM.ZAxes.GridLines = grid33;
            chartFont87.FontName = "Arial";
            pointLabel11.Font = chartFont87;
            this.chartBaiTheoCM.ZAxes.PointLabels = pointLabel11;
            chartFont88.FontName = "Arial";
            tick33.Font = chartFont88;
            this.chartBaiTheoCM.ZAxes.Ticks = tick33;
            // 
            // lblChartTitle3
            // 
            this.lblChartTitle3.BackColor = System.Drawing.Color.Transparent;
            this.lblChartTitle3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartTitle3.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle3.Name = "lblChartTitle3";
            this.lblChartTitle3.Size = new System.Drawing.Size(569, 35);
            this.lblChartTitle3.TabIndex = 0;
            this.lblChartTitle3.Text = "TỈ LỆ BÀI VIẾT THEO CHUYÊN MỤC";
            this.lblChartTitle3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartPanel4
            // 
            this.chartPanel4.BackColor = System.Drawing.Color.Transparent;
            this.chartPanel4.BorderRadius = 12;
            this.chartPanel4.Controls.Add(this.chartDiemAI);
            this.chartPanel4.Controls.Add(this.lblChartTitle4);
            this.chartPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel4.FillColor = System.Drawing.Color.White;
            this.chartPanel4.Location = new System.Drawing.Point(611, 366);
            this.chartPanel4.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.chartPanel4.Name = "chartPanel4";
            this.chartPanel4.Padding = new System.Windows.Forms.Padding(15);
            this.chartPanel4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chartPanel4.ShadowDecoration.Depth = 6;
            this.chartPanel4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.chartPanel4.Size = new System.Drawing.Size(600, 342);
            this.chartPanel4.TabIndex = 3;
            // 
            // chartDiemAI
            // 
            this.chartDiemAI.Dock = System.Windows.Forms.DockStyle.Fill;
            chartFont89.FontName = "Arial";
            this.chartDiemAI.Legend.LabelFont = chartFont89;
            this.chartDiemAI.Location = new System.Drawing.Point(15, 50);
            this.chartDiemAI.Name = "chartDiemAI";
            this.chartDiemAI.Size = new System.Drawing.Size(570, 277);
            this.chartDiemAI.TabIndex = 1;
            chartFont90.FontName = "Arial";
            chartFont90.Size = 12;
            chartFont90.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chartDiemAI.Title.Font = chartFont90;
            chartFont91.FontName = "Arial";
            this.chartDiemAI.Tooltips.BodyFont = chartFont91;
            chartFont92.FontName = "Arial";
            chartFont92.Size = 9;
            chartFont92.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.chartDiemAI.Tooltips.TitleFont = chartFont92;
            this.chartDiemAI.XAxes.GridLines = grid34;
            chartFont93.FontName = "Arial";
            tick34.Font = chartFont93;
            this.chartDiemAI.XAxes.Ticks = tick34;
            grid35.Display = false;
            this.chartDiemAI.YAxes.GridLines = grid35;
            chartFont94.FontName = "Arial";
            tick35.Font = chartFont94;
            this.chartDiemAI.YAxes.Ticks = tick35;
            this.chartDiemAI.ZAxes.GridLines = grid36;
            chartFont95.FontName = "Arial";
            pointLabel12.Font = chartFont95;
            this.chartDiemAI.ZAxes.PointLabels = pointLabel12;
            chartFont96.FontName = "Arial";
            tick36.Font = chartFont96;
            this.chartDiemAI.ZAxes.Ticks = tick36;
            // 
            // lblChartTitle4
            // 
            this.lblChartTitle4.BackColor = System.Drawing.Color.Transparent;
            this.lblChartTitle4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartTitle4.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle4.Name = "lblChartTitle4";
            this.lblChartTitle4.Size = new System.Drawing.Size(570, 35);
            this.lblChartTitle4.TabIndex = 0;
            this.lblChartTitle4.Text = "ĐIỂM AI ĐÁNH GIÁ TRUNG BÌNH";
            this.lblChartTitle4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlGridBox
            // 
            this.pnlGridBox.BackColor = System.Drawing.Color.Transparent;
            this.pnlGridBox.BorderRadius = 12;
            this.pnlGridBox.Controls.Add(this.dgvHoatDong);
            this.pnlGridBox.Controls.Add(this.lblGridTitle);
            this.pnlGridBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridBox.FillColor = System.Drawing.Color.White;
            this.pnlGridBox.Location = new System.Drawing.Point(0, 299);
            this.pnlGridBox.Name = "pnlGridBox";
            this.pnlGridBox.Padding = new System.Windows.Forms.Padding(15);
            this.pnlGridBox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlGridBox.ShadowDecoration.Depth = 6;
            this.pnlGridBox.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.pnlGridBox.Size = new System.Drawing.Size(1211, 342);
            this.pnlGridBox.TabIndex = 2;
            // 
            // dgvHoatDong
            // 
            this.dgvHoatDong.AllowUserToAddRows = false;
            this.dgvHoatDong.AllowUserToDeleteRows = false;
            this.dgvHoatDong.AllowUserToResizeColumns = false;
            this.dgvHoatDong.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHoatDong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoatDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHoatDong.ColumnHeadersHeight = 36;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoatDong.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvHoatDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoatDong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvHoatDong.Location = new System.Drawing.Point(15, 50);
            this.dgvHoatDong.Name = "dgvHoatDong";
            this.dgvHoatDong.ReadOnly = true;
            this.dgvHoatDong.RowHeadersVisible = false;
            this.dgvHoatDong.RowTemplate.Height = 34;
            this.dgvHoatDong.Size = new System.Drawing.Size(1181, 277);
            this.dgvHoatDong.TabIndex = 1;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHoatDong.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHoatDong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoatDong.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvHoatDong.ThemeStyle.ReadOnly = true;
            this.dgvHoatDong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoatDong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvHoatDong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHoatDong.ThemeStyle.RowsStyle.Height = 34;
            this.dgvHoatDong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHoatDong.SelectionChanged += new System.EventHandler(this.dgvHoatDong_SelectionChanged);
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblGridTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblGridTitle.Location = new System.Drawing.Point(15, 15);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(1181, 35);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "PHIẾU CHI MỚI NHẤT";
            // 
            // tlpKPI
            // 
            this.tlpKPI.AutoSize = true;
            this.tlpKPI.ColumnCount = 3;
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpKPI.Controls.Add(this.card1, 0, 0);
            this.tlpKPI.Controls.Add(this.card2, 1, 0);
            this.tlpKPI.Controls.Add(this.card3, 2, 0);
            this.tlpKPI.Controls.Add(this.card4, 0, 1);
            this.tlpKPI.Controls.Add(this.card5, 1, 1);
            this.tlpKPI.Controls.Add(this.card6, 2, 1);
            this.tlpKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKPI.Location = new System.Drawing.Point(0, 55);
            this.tlpKPI.Name = "tlpKPI";
            this.tlpKPI.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            this.tlpKPI.RowCount = 2;
            this.tlpKPI.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpKPI.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpKPI.Size = new System.Drawing.Size(1211, 244);
            this.tlpKPI.TabIndex = 1;
            // 
            // card1
            // 
            this.card1.BackColor = System.Drawing.Color.Transparent;
            this.card1.BorderRadius = 14;
            this.card1.Controls.Add(this.lblIcon1);
            this.card1.Controls.Add(this.lblBaiVietValue);
            this.card1.Controls.Add(this.lblTitle1);
            this.card1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card1.FillColor = System.Drawing.Color.FromArgb(14, 165, 233);
            this.card1.FillColor2 = System.Drawing.Color.FromArgb(56, 189, 248);
            this.card1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.card1.ShadowDecoration.Enabled = true;
            this.card1.ShadowDecoration.Depth = 8;
            this.card1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.card1.BorderRadius = 16;
            this.card1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.card1.Location = new System.Drawing.Point(15, 12);
            this.card1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card1.Name = "card1";
            this.card1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card1.ShadowDecoration.Depth = 6;
            this.card1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card1.Size = new System.Drawing.Size(386, 100);
            this.card1.TabIndex = 0;
            // 
            // lblIcon1
            // 
            this.lblIcon1.AutoSize = true;
            this.lblIcon1.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon1.Font = new System.Drawing.Font("Segoe UI Emoji", 26F);
            this.lblIcon1.Location = new System.Drawing.Point(14, 10);
            this.lblIcon1.Name = "lblIcon1";
            this.lblIcon1.Size = new System.Drawing.Size(47, 32);
            this.lblIcon1.TabIndex = 0;
            this.lblIcon1.Text = "📰";
            // 
            // lblBaiVietValue
            // 
            this.lblBaiVietValue.AutoSize = true;
            this.lblBaiVietValue.BackColor = System.Drawing.Color.Transparent;
            this.lblBaiVietValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBaiVietValue.ForeColor = System.Drawing.Color.White;
            this.lblBaiVietValue.Location = new System.Drawing.Point(89, 4);
            this.lblBaiVietValue.Name = "lblBaiVietValue";
            this.lblBaiVietValue.Size = new System.Drawing.Size(35, 41);
            this.lblBaiVietValue.TabIndex = 1;
            this.lblBaiVietValue.Text = "0";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitle1.ForeColor = System.Drawing.Color.White;
            this.lblTitle1.Location = new System.Drawing.Point(14, 70);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(87, 15);
            this.lblTitle1.TabIndex = 2;
            this.lblTitle1.Text = "TỔNG BÀI VIẾT";
            // 
            // card2
            // 
            this.card2.BackColor = System.Drawing.Color.Transparent;
            this.card2.BorderRadius = 14;
            this.card2.Controls.Add(this.lblIcon2);
            this.card2.Controls.Add(this.lblPhongVienValue);
            this.card2.Controls.Add(this.lblTitle2);
            this.card2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card2.FillColor = System.Drawing.Color.FromArgb(139, 92, 246);
            this.card2.FillColor2 = System.Drawing.Color.FromArgb(167, 139, 250);
            this.card2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.card2.ShadowDecoration.Enabled = true;
            this.card2.ShadowDecoration.Depth = 8;
            this.card2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.card2.BorderRadius = 16;
            this.card2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.card2.Location = new System.Drawing.Point(411, 12);
            this.card2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card2.Name = "card2";
            this.card2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card2.ShadowDecoration.Depth = 6;
            this.card2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card2.Size = new System.Drawing.Size(386, 100);
            this.card2.TabIndex = 1;
            // 
            // lblIcon2
            // 
            this.lblIcon2.AutoSize = true;
            this.lblIcon2.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon2.Font = new System.Drawing.Font("Segoe UI Emoji", 26F);
            this.lblIcon2.Location = new System.Drawing.Point(14, 10);
            this.lblIcon2.Name = "lblIcon2";
            this.lblIcon2.Size = new System.Drawing.Size(47, 32);
            this.lblIcon2.TabIndex = 0;
            this.lblIcon2.Text = "🖋️";
            // 
            // lblPhongVienValue
            // 
            this.lblPhongVienValue.AutoSize = true;
            this.lblPhongVienValue.BackColor = System.Drawing.Color.Transparent;
            this.lblPhongVienValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPhongVienValue.ForeColor = System.Drawing.Color.White;
            this.lblPhongVienValue.Location = new System.Drawing.Point(80, 8);
            this.lblPhongVienValue.Name = "lblPhongVienValue";
            this.lblPhongVienValue.Size = new System.Drawing.Size(35, 41);
            this.lblPhongVienValue.TabIndex = 1;
            this.lblPhongVienValue.Text = "0";
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitle2.ForeColor = System.Drawing.Color.White;
            this.lblTitle2.Location = new System.Drawing.Point(14, 70);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(113, 15);
            this.lblTitle2.TabIndex = 2;
            this.lblTitle2.Text = "TỔNG PHÓNG VIÊN";
            // 
            // card3
            // 
            this.card3.BackColor = System.Drawing.Color.Transparent;
            this.card3.BorderRadius = 14;
            this.card3.Controls.Add(this.lblIcon3);
            this.card3.Controls.Add(this.lblNhuanButValue);
            this.card3.Controls.Add(this.lblTitle3);
            this.card3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card3.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.card3.FillColor2 = System.Drawing.Color.FromArgb(52, 211, 153);
            this.card3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.card3.ShadowDecoration.Enabled = true;
            this.card3.ShadowDecoration.Depth = 8;
            this.card3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.card3.BorderRadius = 16;
            this.card3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.card3.Location = new System.Drawing.Point(807, 12);
            this.card3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card3.Name = "card3";
            this.card3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card3.ShadowDecoration.Depth = 6;
            this.card3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card3.Size = new System.Drawing.Size(389, 100);
            this.card3.TabIndex = 2;
            // 
            // lblIcon3
            // 
            this.lblIcon3.AutoSize = true;
            this.lblIcon3.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon3.Font = new System.Drawing.Font("Segoe UI Emoji", 26F);
            this.lblIcon3.Location = new System.Drawing.Point(14, 10);
            this.lblIcon3.Name = "lblIcon3";
            this.lblIcon3.Size = new System.Drawing.Size(47, 32);
            this.lblIcon3.TabIndex = 0;
            this.lblIcon3.Text = "💼";
            // 
            // lblNhuanButValue
            // 
            this.lblNhuanButValue.AutoSize = true;
            this.lblNhuanButValue.BackColor = System.Drawing.Color.Transparent;
            this.lblNhuanButValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblNhuanButValue.ForeColor = System.Drawing.Color.White;
            this.lblNhuanButValue.Location = new System.Drawing.Point(87, 8);
            this.lblNhuanButValue.Name = "lblNhuanButValue";
            this.lblNhuanButValue.Size = new System.Drawing.Size(35, 41);
            this.lblNhuanButValue.TabIndex = 1;
            this.lblNhuanButValue.Text = "0";
            // 
            // lblTitle3
            // 
            this.lblTitle3.AutoSize = true;
            this.lblTitle3.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitle3.ForeColor = System.Drawing.Color.White;
            this.lblTitle3.Location = new System.Drawing.Point(14, 70);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(117, 15);
            this.lblTitle3.TabIndex = 2;
            this.lblTitle3.Text = "NHUẬN BÚT ĐÃ CHI";
            // 
            // card4
            // 
            this.card4.BackColor = System.Drawing.Color.Transparent;
            this.card4.BorderRadius = 14;
            this.card4.Controls.Add(this.lblIcon4);
            this.card4.Controls.Add(this.lblBaiChuaDuyetValue);
            this.card4.Controls.Add(this.lblTitle4);
            this.card4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card4.FillColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.card4.FillColor2 = System.Drawing.Color.FromArgb(251, 191, 36);
            this.card4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.card4.ShadowDecoration.Enabled = true;
            this.card4.ShadowDecoration.Depth = 8;
            this.card4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.card4.BorderRadius = 16;
            this.card4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.card4.Location = new System.Drawing.Point(15, 122);
            this.card4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card4.Name = "card4";
            this.card4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card4.ShadowDecoration.Depth = 6;
            this.card4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card4.Size = new System.Drawing.Size(386, 100);
            this.card4.TabIndex = 3;
            // 
            // lblIcon4
            // 
            this.lblIcon4.AutoSize = true;
            this.lblIcon4.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon4.Font = new System.Drawing.Font("Segoe UI Emoji", 26F);
            this.lblIcon4.Location = new System.Drawing.Point(14, 10);
            this.lblIcon4.Name = "lblIcon4";
            this.lblIcon4.Size = new System.Drawing.Size(47, 32);
            this.lblIcon4.TabIndex = 0;
            this.lblIcon4.Text = "📥";
            // 
            // lblBaiChuaDuyetValue
            // 
            this.lblBaiChuaDuyetValue.AutoSize = true;
            this.lblBaiChuaDuyetValue.BackColor = System.Drawing.Color.Transparent;
            this.lblBaiChuaDuyetValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBaiChuaDuyetValue.ForeColor = System.Drawing.Color.White;
            this.lblBaiChuaDuyetValue.Location = new System.Drawing.Point(89, 4);
            this.lblBaiChuaDuyetValue.Name = "lblBaiChuaDuyetValue";
            this.lblBaiChuaDuyetValue.Size = new System.Drawing.Size(35, 41);
            this.lblBaiChuaDuyetValue.TabIndex = 1;
            this.lblBaiChuaDuyetValue.Text = "0";
            // 
            // lblTitle4
            // 
            this.lblTitle4.AutoSize = true;
            this.lblTitle4.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitle4.ForeColor = System.Drawing.Color.White;
            this.lblTitle4.Location = new System.Drawing.Point(14, 70);
            this.lblTitle4.Name = "lblTitle4";
            this.lblTitle4.Size = new System.Drawing.Size(100, 15);
            this.lblTitle4.TabIndex = 2;
            this.lblTitle4.Text = "BÀI CHƯA DUYỆT";
            // 
            // card5
            // 
            this.card5.BackColor = System.Drawing.Color.Transparent;
            this.card5.BorderRadius = 14;
            this.card5.Controls.Add(this.lblIcon5);
            this.card5.Controls.Add(this.lblPhieuChiValue);
            this.card5.Controls.Add(this.lblTitle5);
            this.card5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card5.FillColor = System.Drawing.Color.FromArgb(244, 63, 94);
            this.card5.FillColor2 = System.Drawing.Color.FromArgb(251, 113, 133);
            this.card5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.card5.ShadowDecoration.Enabled = true;
            this.card5.ShadowDecoration.Depth = 8;
            this.card5.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.card5.BorderRadius = 16;
            this.card5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card5.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.card5.Location = new System.Drawing.Point(411, 122);
            this.card5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card5.Name = "card5";
            this.card5.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card5.ShadowDecoration.Depth = 6;
            this.card5.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card5.Size = new System.Drawing.Size(386, 100);
            this.card5.TabIndex = 4;
            // 
            // lblIcon5
            // 
            this.lblIcon5.AutoSize = true;
            this.lblIcon5.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon5.Font = new System.Drawing.Font("Segoe UI Emoji", 26F);
            this.lblIcon5.Location = new System.Drawing.Point(14, 10);
            this.lblIcon5.Name = "lblIcon5";
            this.lblIcon5.Size = new System.Drawing.Size(47, 32);
            this.lblIcon5.TabIndex = 0;
            this.lblIcon5.Text = "🧾";
            // 
            // lblPhieuChiValue
            // 
            this.lblPhieuChiValue.AutoSize = true;
            this.lblPhieuChiValue.BackColor = System.Drawing.Color.Transparent;
            this.lblPhieuChiValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPhieuChiValue.ForeColor = System.Drawing.Color.White;
            this.lblPhieuChiValue.Location = new System.Drawing.Point(80, 4);
            this.lblPhieuChiValue.Name = "lblPhieuChiValue";
            this.lblPhieuChiValue.Size = new System.Drawing.Size(35, 41);
            this.lblPhieuChiValue.TabIndex = 1;
            this.lblPhieuChiValue.Text = "0";
            // 
            // lblTitle5
            // 
            this.lblTitle5.AutoSize = true;
            this.lblTitle5.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitle5.ForeColor = System.Drawing.Color.White;
            this.lblTitle5.Location = new System.Drawing.Point(14, 70);
            this.lblTitle5.Name = "lblTitle5";
            this.lblTitle5.Size = new System.Drawing.Size(81, 15);
            this.lblTitle5.TabIndex = 2;
            this.lblTitle5.Text = "SỐ PHIẾU CHI";
            // 
            // card6
            // 
            this.card6.BackColor = System.Drawing.Color.Transparent;
            this.card6.BorderRadius = 14;
            this.card6.Controls.Add(this.lblIcon6);
            this.card6.Controls.Add(this.lblCanhBaoValue);
            this.card6.Controls.Add(this.lblTitle6);
            this.card6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.card6.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.card6.FillColor2 = System.Drawing.Color.FromArgb(248, 113, 113);
            this.card6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.card6.ShadowDecoration.Enabled = true;
            this.card6.ShadowDecoration.Depth = 8;
            this.card6.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.card6.BorderRadius = 16;
            this.card6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.card6.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.card6.Location = new System.Drawing.Point(807, 122);
            this.card6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card6.Name = "card6";
            this.card6.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card6.ShadowDecoration.Depth = 6;
            this.card6.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card6.Size = new System.Drawing.Size(389, 100);
            this.card6.TabIndex = 5;
            // 
            // lblIcon6
            // 
            this.lblIcon6.AutoSize = true;
            this.lblIcon6.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon6.Font = new System.Drawing.Font("Segoe UI Emoji", 26F);
            this.lblIcon6.Location = new System.Drawing.Point(14, 10);
            this.lblIcon6.Name = "lblIcon6";
            this.lblIcon6.Size = new System.Drawing.Size(47, 32);
            this.lblIcon6.TabIndex = 0;
            this.lblIcon6.Text = "🔍";
            // 
            // lblCanhBaoValue
            // 
            this.lblCanhBaoValue.AutoSize = true;
            this.lblCanhBaoValue.BackColor = System.Drawing.Color.Transparent;
            this.lblCanhBaoValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCanhBaoValue.ForeColor = System.Drawing.Color.White;
            this.lblCanhBaoValue.Location = new System.Drawing.Point(87, 4);
            this.lblCanhBaoValue.Name = "lblCanhBaoValue";
            this.lblCanhBaoValue.Size = new System.Drawing.Size(35, 41);
            this.lblCanhBaoValue.TabIndex = 1;
            this.lblCanhBaoValue.Text = "0";
            // 
            // lblTitle6
            // 
            this.lblTitle6.AutoSize = true;
            this.lblTitle6.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitle6.ForeColor = System.Drawing.Color.White;
            this.lblTitle6.Location = new System.Drawing.Point(14, 70);
            this.lblTitle6.Name = "lblTitle6";
            this.lblTitle6.Size = new System.Drawing.Size(82, 15);
            this.lblTitle6.TabIndex = 2;
            this.lblTitle6.Text = "CẢNH BÁO AI";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnAIPhanTich);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1211, 55);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnAIPhanTich
            // 
            this.btnAIPhanTich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAIPhanTich.BorderRadius = 6;
            this.btnAIPhanTich.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnAIPhanTich.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAIPhanTich.ForeColor = System.Drawing.Color.White;
            this.btnAIPhanTich.Location = new System.Drawing.Point(970, 10);
            this.btnAIPhanTich.Name = "btnAIPhanTich";
            this.btnAIPhanTich.Size = new System.Drawing.Size(220, 35);
            this.btnAIPhanTich.TabIndex = 1;
            this.btnAIPhanTich.Text = "🤖 AI Phân tích Dashboard";
            this.btnAIPhanTich.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAIPhanTich.Click += new System.EventHandler(this.btnAIPhanTich_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblWelcome.Location = new System.Drawing.Point(12, 8);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(325, 37);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "TỔNG QUAN HỆ THỐNG";
            // 
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1268, 580);
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmDashboard";
            this.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tlpCharts.ResumeLayout(false);
            this.chartPanel1.ResumeLayout(false);
            this.chartPanel2.ResumeLayout(false);
            this.chartPanel3.ResumeLayout(false);
            this.chartPanel4.ResumeLayout(false);
            this.pnlGridBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoatDong)).EndInit();
            this.tlpKPI.ResumeLayout(false);
            this.card1.ResumeLayout(false);
            this.card1.PerformLayout();
            this.card2.ResumeLayout(false);
            this.card2.PerformLayout();
            this.card3.ResumeLayout(false);
            this.card3.PerformLayout();
            this.card4.ResumeLayout(false);
            this.card4.PerformLayout();
            this.card5.ResumeLayout(false);
            this.card5.PerformLayout();
            this.card6.ResumeLayout(false);
            this.card6.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2GradientPanel card1;
        private Label lblIcon1;
        private Label lblTitle1;
        private Guna.UI2.WinForms.Guna2GradientPanel card2;
        private Label lblIcon2;
        private Label lblTitle2;
        private Guna.UI2.WinForms.Guna2GradientPanel card3;
        private Label lblIcon3;
        private Label lblTitle3;
        private Guna.UI2.WinForms.Guna2GradientPanel card4;
        private Label lblIcon4;
        private Label lblTitle4;
        private Guna.UI2.WinForms.Guna2GradientPanel card5;
        private Label lblIcon5;
        private Label lblTitle5;
        private Guna.UI2.WinForms.Guna2GradientPanel card6;
        private Label lblIcon6;
        private Label lblTitle6;
        private GunaChart chartNBThang;
        private GunaChart chartTopPV;
        private GunaChart chartBaiTheoCM;
        private GunaChart chartDiemAI;
        private Guna2DataGridView dgvHoatDong;
        private Guna2Panel chartPanel1;
        private Label lblChartTitle1;
        private Guna2Panel chartPanel2;
        private Label lblChartTitle2;
        private Guna2Panel chartPanel3;
        private Label lblChartTitle3;
        private Guna2Panel chartPanel4;
        private Label lblChartTitle4;
    }
}