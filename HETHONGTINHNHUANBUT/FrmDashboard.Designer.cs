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
        private Label lblUpdate;
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.tlpKPI = new System.Windows.Forms.TableLayoutPanel();
            this.card1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIcon1 = new System.Windows.Forms.Label();
            this.lblBaiVietValue = new System.Windows.Forms.Label();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.card2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIcon2 = new System.Windows.Forms.Label();
            this.lblPhongVienValue = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.card3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIcon3 = new System.Windows.Forms.Label();
            this.lblNhuanButValue = new System.Windows.Forms.Label();
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.card4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIcon4 = new System.Windows.Forms.Label();
            this.lblBaiChuaDuyetValue = new System.Windows.Forms.Label();
            this.lblTitle4 = new System.Windows.Forms.Label();
            this.card5 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIcon5 = new System.Windows.Forms.Label();
            this.lblPhieuChiValue = new System.Windows.Forms.Label();
            this.lblTitle5 = new System.Windows.Forms.Label();
            this.card6 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIcon6 = new System.Windows.Forms.Label();
            this.lblCanhBaoValue = new System.Windows.Forms.Label();
            this.lblTitle6 = new System.Windows.Forms.Label();
            this.pnlGridBox = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.tlpCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartNBThang = new Guna.Charts.WinForms.GunaChart();
            this.chartPanel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartTitle1 = new System.Windows.Forms.Label();
            this.chartTopPV = new Guna.Charts.WinForms.GunaChart();
            this.chartPanel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartTitle2 = new System.Windows.Forms.Label();
            this.chartBaiTheoCM = new Guna.Charts.WinForms.GunaChart();
            this.chartPanel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartTitle3 = new System.Windows.Forms.Label();
            this.chartDiemAI = new Guna.Charts.WinForms.GunaChart();
            this.chartPanel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartTitle4 = new System.Windows.Forms.Label();
            this.dgvHoatDong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpKPI.SuspendLayout();
            this.card1.SuspendLayout();
            this.card2.SuspendLayout();
            this.card3.SuspendLayout();
            this.card4.SuspendLayout();
            this.card5.SuspendLayout();
            this.card6.SuspendLayout();
            this.pnlGridBox.SuspendLayout();
            this.tlpCharts.SuspendLayout();
            this.chartPanel1.SuspendLayout();
            this.chartPanel2.SuspendLayout();
            this.chartPanel3.SuspendLayout();
            this.chartPanel4.SuspendLayout();
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
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblUpdate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1211, 55);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Resize += new System.EventHandler(this.pnlHeader_Resize);
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
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // lblUpdate
            // 
            this.lblUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblUpdate.Location = new System.Drawing.Point(950, 15);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(250, 30);
            this.lblUpdate.TabIndex = 1;
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.tlpKPI.Padding = new System.Windows.Forms.Padding(7, 12, 7, 12);
            this.tlpKPI.RowCount = 2;
            this.tlpKPI.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpKPI.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpKPI.Size = new System.Drawing.Size(1211, 245);
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
            this.card1.FillColor = System.Drawing.Color.White;
            this.card1.Location = new System.Drawing.Point(5, 10);
            this.card1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card1.Name = "card1";
            this.card1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card1.ShadowDecoration.Depth = 6;
            this.card1.ShadowDecoration.Enabled = true;
            this.card1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card1.Size = new System.Drawing.Size(393, 100);
            this.card1.TabIndex = 0;
            // 
            // lblIcon1
            // 
            this.lblIcon1.AutoSize = true;
            this.lblIcon1.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon1.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
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
            this.lblBaiVietValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblBaiVietValue.Location = new System.Drawing.Point(60, 8);
            this.lblBaiVietValue.Name = "lblBaiVietValue";
            this.lblBaiVietValue.Size = new System.Drawing.Size(35, 41);
            this.lblBaiVietValue.TabIndex = 1;
            this.lblBaiVietValue.Text = "0";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle1.Location = new System.Drawing.Point(14, 70);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(92, 15);
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
            this.card2.FillColor = System.Drawing.Color.White;
            this.card2.Location = new System.Drawing.Point(408, 10);
            this.card2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card2.Name = "card2";
            this.card2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card2.ShadowDecoration.Depth = 6;
            this.card2.ShadowDecoration.Enabled = true;
            this.card2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card2.Size = new System.Drawing.Size(393, 100);
            this.card2.TabIndex = 1;
            // 
            // lblIcon2
            // 
            this.lblIcon2.AutoSize = true;
            this.lblIcon2.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon2.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIcon2.Location = new System.Drawing.Point(14, 10);
            this.lblIcon2.Name = "lblIcon2";
            this.lblIcon2.Size = new System.Drawing.Size(47, 32);
            this.lblIcon2.TabIndex = 0;
            this.lblIcon2.Text = "✍️";
            // 
            // lblPhongVienValue
            // 
            this.lblPhongVienValue.AutoSize = true;
            this.lblPhongVienValue.BackColor = System.Drawing.Color.Transparent;
            this.lblPhongVienValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPhongVienValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblPhongVienValue.Location = new System.Drawing.Point(60, 8);
            this.lblPhongVienValue.Name = "lblPhongVienValue";
            this.lblPhongVienValue.Size = new System.Drawing.Size(35, 41);
            this.lblPhongVienValue.TabIndex = 1;
            this.lblPhongVienValue.Text = "0";
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle2.Location = new System.Drawing.Point(14, 70);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(117, 15);
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
            this.card3.FillColor = System.Drawing.Color.White;
            this.card3.Location = new System.Drawing.Point(811, 10);
            this.card3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card3.Name = "card3";
            this.card3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card3.ShadowDecoration.Depth = 6;
            this.card3.ShadowDecoration.Enabled = true;
            this.card3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card3.Size = new System.Drawing.Size(395, 100);
            this.card3.TabIndex = 2;
            // 
            // lblIcon3
            // 
            this.lblIcon3.AutoSize = true;
            this.lblIcon3.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon3.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIcon3.Location = new System.Drawing.Point(14, 10);
            this.lblIcon3.Name = "lblIcon3";
            this.lblIcon3.Size = new System.Drawing.Size(47, 32);
            this.lblIcon3.TabIndex = 0;
            this.lblIcon3.Text = "💰";
            // 
            // lblNhuanButValue
            // 
            this.lblNhuanButValue.AutoSize = true;
            this.lblNhuanButValue.BackColor = System.Drawing.Color.Transparent;
            this.lblNhuanButValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblNhuanButValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.lblNhuanButValue.Location = new System.Drawing.Point(60, 8);
            this.lblNhuanButValue.Name = "lblNhuanButValue";
            this.lblNhuanButValue.Size = new System.Drawing.Size(35, 41);
            this.lblNhuanButValue.TabIndex = 1;
            this.lblNhuanButValue.Text = "0";
            // 
            // lblTitle3
            // 
            this.lblTitle3.AutoSize = true;
            this.lblTitle3.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle3.Location = new System.Drawing.Point(14, 70);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(121, 15);
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
            this.card4.FillColor = System.Drawing.Color.White;
            this.card4.Location = new System.Drawing.Point(5, 120);
            this.card4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card4.Name = "card4";
            this.card4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card4.ShadowDecoration.Depth = 6;
            this.card4.ShadowDecoration.Enabled = true;
            this.card4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card4.Size = new System.Drawing.Size(393, 100);
            this.card4.TabIndex = 3;
            // 
            // lblIcon4
            // 
            this.lblIcon4.AutoSize = true;
            this.lblIcon4.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon4.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIcon4.Location = new System.Drawing.Point(14, 10);
            this.lblIcon4.Name = "lblIcon4";
            this.lblIcon4.Size = new System.Drawing.Size(47, 32);
            this.lblIcon4.TabIndex = 0;
            this.lblIcon4.Text = "⏳";
            // 
            // lblBaiChuaDuyetValue
            // 
            this.lblBaiChuaDuyetValue.AutoSize = true;
            this.lblBaiChuaDuyetValue.BackColor = System.Drawing.Color.Transparent;
            this.lblBaiChuaDuyetValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBaiChuaDuyetValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblBaiChuaDuyetValue.Location = new System.Drawing.Point(60, 8);
            this.lblBaiChuaDuyetValue.Name = "lblBaiChuaDuyetValue";
            this.lblBaiChuaDuyetValue.Size = new System.Drawing.Size(35, 41);
            this.lblBaiChuaDuyetValue.TabIndex = 1;
            this.lblBaiChuaDuyetValue.Text = "0";
            // 
            // lblTitle4
            // 
            this.lblTitle4.AutoSize = true;
            this.lblTitle4.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle4.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle4.Location = new System.Drawing.Point(14, 70);
            this.lblTitle4.Name = "lblTitle4";
            this.lblTitle4.Size = new System.Drawing.Size(104, 15);
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
            this.card5.FillColor = System.Drawing.Color.White;
            this.card5.Location = new System.Drawing.Point(408, 120);
            this.card5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card5.Name = "card5";
            this.card5.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card5.ShadowDecoration.Depth = 6;
            this.card5.ShadowDecoration.Enabled = true;
            this.card5.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card5.Size = new System.Drawing.Size(393, 100);
            this.card5.TabIndex = 4;
            // 
            // lblIcon5
            // 
            this.lblIcon5.AutoSize = true;
            this.lblIcon5.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon5.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIcon5.Location = new System.Drawing.Point(14, 10);
            this.lblIcon5.Name = "lblIcon5";
            this.lblIcon5.Size = new System.Drawing.Size(47, 32);
            this.lblIcon5.TabIndex = 0;
            this.lblIcon5.Text = "📋";
            // 
            // lblPhieuChiValue
            // 
            this.lblPhieuChiValue.AutoSize = true;
            this.lblPhieuChiValue.BackColor = System.Drawing.Color.Transparent;
            this.lblPhieuChiValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPhieuChiValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblPhieuChiValue.Location = new System.Drawing.Point(60, 8);
            this.lblPhieuChiValue.Name = "lblPhieuChiValue";
            this.lblPhieuChiValue.Size = new System.Drawing.Size(35, 41);
            this.lblPhieuChiValue.TabIndex = 1;
            this.lblPhieuChiValue.Text = "0";
            // 
            // lblTitle5
            // 
            this.lblTitle5.AutoSize = true;
            this.lblTitle5.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle5.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle5.Location = new System.Drawing.Point(14, 70);
            this.lblTitle5.Name = "lblTitle5";
            this.lblTitle5.Size = new System.Drawing.Size(84, 15);
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
            this.card6.FillColor = System.Drawing.Color.White;
            this.card6.Location = new System.Drawing.Point(811, 120);
            this.card6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 10);
            this.card6.Name = "card6";
            this.card6.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.card6.ShadowDecoration.Depth = 6;
            this.card6.ShadowDecoration.Enabled = true;
            this.card6.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.card6.Size = new System.Drawing.Size(395, 100);
            this.card6.TabIndex = 5;
            // 
            // lblIcon6
            // 
            this.lblIcon6.AutoSize = true;
            this.lblIcon6.BackColor = System.Drawing.Color.Transparent;
            this.lblIcon6.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblIcon6.Location = new System.Drawing.Point(14, 10);
            this.lblIcon6.Name = "lblIcon6";
            this.lblIcon6.Size = new System.Drawing.Size(47, 32);
            this.lblIcon6.TabIndex = 0;
            this.lblIcon6.Text = "⚠️";
            // 
            // lblCanhBaoValue
            // 
            this.lblCanhBaoValue.AutoSize = true;
            this.lblCanhBaoValue.BackColor = System.Drawing.Color.Transparent;
            this.lblCanhBaoValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCanhBaoValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(85)))), ((int)(((byte)(247)))));
            this.lblCanhBaoValue.Location = new System.Drawing.Point(60, 8);
            this.lblCanhBaoValue.Name = "lblCanhBaoValue";
            this.lblCanhBaoValue.Size = new System.Drawing.Size(35, 41);
            this.lblCanhBaoValue.TabIndex = 1;
            this.lblCanhBaoValue.Text = "0";
            // 
            // lblTitle6
            // 
            this.lblTitle6.AutoSize = true;
            this.lblTitle6.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle6.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitle6.Location = new System.Drawing.Point(14, 70);
            this.lblTitle6.Name = "lblTitle6";
            this.lblTitle6.Size = new System.Drawing.Size(83, 15);
            this.lblTitle6.TabIndex = 2;
            this.lblTitle6.Text = "CẢNH BÁO AI";
            // 
            // pnlGridBox
            // 
            this.pnlGridBox.BackColor = System.Drawing.Color.Transparent;
            this.pnlGridBox.BorderRadius = 12;
            this.pnlGridBox.Controls.Add(this.dgvHoatDong);
            this.pnlGridBox.Controls.Add(this.lblGridTitle);
            this.pnlGridBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridBox.FillColor = System.Drawing.Color.White;
            this.pnlGridBox.Location = new System.Drawing.Point(0, 300);
            this.pnlGridBox.Name = "pnlGridBox";
            this.pnlGridBox.Padding = new System.Windows.Forms.Padding(15);
            this.pnlGridBox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlGridBox.ShadowDecoration.Depth = 6;
            this.pnlGridBox.ShadowDecoration.Enabled = true;
            this.pnlGridBox.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.pnlGridBox.Size = new System.Drawing.Size(1211, 342);
            this.pnlGridBox.TabIndex = 2;
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
            this.tlpCharts.Location = new System.Drawing.Point(0, 620);
            this.tlpCharts.Name = "tlpCharts";
            this.tlpCharts.Padding = new System.Windows.Forms.Padding(6);
            this.tlpCharts.RowCount = 2;
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.Size = new System.Drawing.Size(1211, 720);
            this.tlpCharts.TabIndex = 3;
            // 
            // chartNBThang
            // 
            this.chartNBThang.BackColor = System.Drawing.Color.White;
            this.chartNBThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartNBThang.Location = new System.Drawing.Point(15, 50);
            this.chartNBThang.Name = "chartNBThang";
            this.chartNBThang.Size = new System.Drawing.Size(557, 277);
            this.chartNBThang.TabIndex = 1;
            this.chartNBThang.XAxes.Display = true;
            this.chartNBThang.XAxes.GridLines.Display = false;
            this.chartNBThang.YAxes.Display = true;
            this.chartNBThang.YAxes.GridLines.Display = true;
            // 
            // chartPanel1
            // 
            this.chartPanel1.BackColor = System.Drawing.Color.Transparent;
            this.chartPanel1.BorderRadius = 12;
            this.chartPanel1.Controls.Add(this.chartNBThang);
            this.chartPanel1.Controls.Add(this.lblChartTitle1);
            this.chartPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel1.FillColor = System.Drawing.Color.White;
            this.chartPanel1.Location = new System.Drawing.Point(12, 12);
            this.chartPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.chartPanel1.Name = "chartPanel1";
            this.chartPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.chartPanel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chartPanel1.ShadowDecoration.Depth = 6;
            this.chartPanel1.ShadowDecoration.Enabled = true;
            this.chartPanel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.chartPanel1.Size = new System.Drawing.Size(587, 342);
            this.chartPanel1.TabIndex = 0;
            // 
            // lblChartTitle1
            // 
            this.lblChartTitle1.BackColor = System.Drawing.Color.Transparent;
            this.lblChartTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartTitle1.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle1.Name = "lblChartTitle1";
            this.lblChartTitle1.Size = new System.Drawing.Size(557, 35);
            this.lblChartTitle1.TabIndex = 0;
            this.lblChartTitle1.Text = "NHUẬN BÚT THEO THÁNG";
            this.lblChartTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartTopPV
            // 
            this.chartTopPV.BackColor = System.Drawing.Color.White;
            this.chartTopPV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTopPV.Location = new System.Drawing.Point(15, 50);
            this.chartTopPV.Name = "chartTopPV";
            this.chartTopPV.Size = new System.Drawing.Size(558, 277);
            this.chartTopPV.TabIndex = 1;
            this.chartTopPV.XAxes.Display = true;
            this.chartTopPV.YAxes.Display = true;
            this.chartTopPV.YAxes.GridLines.Display = false;
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
            this.chartPanel2.Margin = new System.Windows.Forms.Padding(6);
            this.chartPanel2.Name = "chartPanel2";
            this.chartPanel2.Padding = new System.Windows.Forms.Padding(15);
            this.chartPanel2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chartPanel2.ShadowDecoration.Depth = 6;
            this.chartPanel2.ShadowDecoration.Enabled = true;
            this.chartPanel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.chartPanel2.Size = new System.Drawing.Size(588, 342);
            this.chartPanel2.TabIndex = 1;
            // 
            // lblChartTitle2
            // 
            this.lblChartTitle2.BackColor = System.Drawing.Color.Transparent;
            this.lblChartTitle2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartTitle2.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle2.Name = "lblChartTitle2";
            this.lblChartTitle2.Size = new System.Drawing.Size(558, 35);
            this.lblChartTitle2.TabIndex = 0;
            this.lblChartTitle2.Text = "TOP 10 PV NHẬN NHUẬN BÚT";
            this.lblChartTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartBaiTheoCM
            // 
            this.chartBaiTheoCM.BackColor = System.Drawing.Color.White;
            this.chartBaiTheoCM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBaiTheoCM.Location = new System.Drawing.Point(15, 50);
            this.chartBaiTheoCM.Name = "chartBaiTheoCM";
            this.chartBaiTheoCM.Size = new System.Drawing.Size(557, 277);
            this.chartBaiTheoCM.TabIndex = 1;
            this.chartBaiTheoCM.XAxes.Display = true;
            this.chartBaiTheoCM.YAxes.Display = true;
            // 
            // chartPanel3
            // 
            this.chartPanel3.BackColor = System.Drawing.Color.Transparent;
            this.chartPanel3.BorderRadius = 12;
            this.chartPanel3.Controls.Add(this.chartBaiTheoCM);
            this.chartPanel3.Controls.Add(this.lblChartTitle3);
            this.chartPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel3.FillColor = System.Drawing.Color.White;
            this.chartPanel3.Location = new System.Drawing.Point(12, 366);
            this.chartPanel3.Margin = new System.Windows.Forms.Padding(6);
            this.chartPanel3.Name = "chartPanel3";
            this.chartPanel3.Padding = new System.Windows.Forms.Padding(15);
            this.chartPanel3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chartPanel3.ShadowDecoration.Depth = 6;
            this.chartPanel3.ShadowDecoration.Enabled = true;
            this.chartPanel3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.chartPanel3.Size = new System.Drawing.Size(587, 342);
            this.chartPanel3.TabIndex = 2;
            // 
            // lblChartTitle3
            // 
            this.lblChartTitle3.BackColor = System.Drawing.Color.Transparent;
            this.lblChartTitle3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartTitle3.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle3.Name = "lblChartTitle3";
            this.lblChartTitle3.Size = new System.Drawing.Size(557, 35);
            this.lblChartTitle3.TabIndex = 0;
            this.lblChartTitle3.Text = "TỈ LỆ BÀI VIẾT THEO CHUYÊN MỤC";
            this.lblChartTitle3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartDiemAI
            // 
            this.chartDiemAI.BackColor = System.Drawing.Color.White;
            this.chartDiemAI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDiemAI.Location = new System.Drawing.Point(15, 50);
            this.chartDiemAI.Name = "chartDiemAI";
            this.chartDiemAI.Size = new System.Drawing.Size(558, 277);
            this.chartDiemAI.TabIndex = 1;
            this.chartDiemAI.XAxes.Display = true;
            this.chartDiemAI.YAxes.Display = true;
            this.chartDiemAI.YAxes.GridLines.Display = false;
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
            this.chartPanel4.Margin = new System.Windows.Forms.Padding(6);
            this.chartPanel4.Name = "chartPanel4";
            this.chartPanel4.Padding = new System.Windows.Forms.Padding(15);
            this.chartPanel4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.chartPanel4.ShadowDecoration.Depth = 6;
            this.chartPanel4.ShadowDecoration.Enabled = true;
            this.chartPanel4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.chartPanel4.Size = new System.Drawing.Size(588, 342);
            this.chartPanel4.TabIndex = 3;
            // 
            // lblChartTitle4
            // 
            this.lblChartTitle4.BackColor = System.Drawing.Color.Transparent;
            this.lblChartTitle4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTitle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartTitle4.Location = new System.Drawing.Point(15, 15);
            this.lblChartTitle4.Name = "lblChartTitle4";
            this.lblChartTitle4.Size = new System.Drawing.Size(558, 35);
            this.lblChartTitle4.TabIndex = 0;
            this.lblChartTitle4.Text = "ĐIỂM AI ĐÁNH GIÁ TRUNG BÌNH";
            this.lblChartTitle4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvHoatDong
            // 
            this.dgvHoatDong.AllowUserToAddRows = false;
            this.dgvHoatDong.AllowUserToDeleteRows = false;
            this.dgvHoatDong.AllowUserToResizeColumns = false;
            this.dgvHoatDong.AllowUserToResizeRows = false;
            this.dgvHoatDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoatDong.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvHoatDong.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoatDong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHoatDong.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoatDong.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHoatDong.ColumnHeadersHeight = 36;
            this.dgvHoatDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoatDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoatDong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvHoatDong.Location = new System.Drawing.Point(15, 50);
            this.dgvHoatDong.Name = "dgvHoatDong";
            this.dgvHoatDong.ReadOnly = true;
            this.dgvHoatDong.RowHeadersVisible = false;
            this.dgvHoatDong.RowTemplate.Height = 34;
            this.dgvHoatDong.Size = new System.Drawing.Size(1181, 277);
            this.dgvHoatDong.TabIndex = 1;
            this.dgvHoatDong.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHoatDong.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHoatDong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvHoatDong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoatDong.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvHoatDong.ThemeStyle.ReadOnly = true;
            this.dgvHoatDong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoatDong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvHoatDong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHoatDong.ThemeStyle.RowsStyle.Height = 34;
            this.dgvHoatDong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHoatDong.SelectionChanged += new System.EventHandler(this.dgvHoatDong_SelectionChanged);
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
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
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
            this.pnlGridBox.ResumeLayout(false);
            this.tlpCharts.ResumeLayout(false);
            this.chartPanel1.ResumeLayout(false);
            this.chartPanel2.ResumeLayout(false);
            this.chartPanel3.ResumeLayout(false);
            this.chartPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Guna2Panel card1;
        private Label lblIcon1;
        private Label lblTitle1;
        private Guna2Panel card2;
        private Label lblIcon2;
        private Label lblTitle2;
        private Guna2Panel card3;
        private Label lblIcon3;
        private Label lblTitle3;
        private Guna2Panel card4;
        private Label lblIcon4;
        private Label lblTitle4;
        private Guna2Panel card5;
        private Label lblIcon5;
        private Label lblTitle5;
        private Guna2Panel card6;
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