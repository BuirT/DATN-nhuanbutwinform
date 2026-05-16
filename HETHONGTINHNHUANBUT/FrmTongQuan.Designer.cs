using System.Drawing;
using System.Windows.Forms;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.cardRed = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoBaoCho = new System.Windows.Forms.Label();
            this.cardOrange = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.cardGreen = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSoTacGia = new System.Windows.Forms.Label();
            this.cardBlue = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSoBaiViet = new System.Windows.Forms.Label();
            this.tlpCharts = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBoxPie = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlChartPie = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlBoxMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlChartMain = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlTableBox = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvHoatDong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpCards.SuspendLayout();
            this.cardRed.SuspendLayout();
            this.cardOrange.SuspendLayout();
            this.cardGreen.SuspendLayout();
            this.cardBlue.SuspendLayout();
            this.tlpCharts.SuspendLayout();
            this.pnlBoxPie.SuspendLayout();
            this.pnlBoxMain.SuspendLayout();
            this.pnlTableBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoatDong)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblUpdate);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(30, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1124, 60);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblUpdate.Location = new System.Drawing.Point(824, 20);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(300, 30);
            this.lblUpdate.TabIndex = 1;
            this.lblUpdate.Text = "Cập nhật: Hôm nay";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblWelcome.Location = new System.Drawing.Point(-5, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(342, 41);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Tổng Quan Hệ Thống";

            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpCards, 0, 0);
            this.tlpMain.Controls.Add(this.tlpCharts, 0, 1);
            this.tlpMain.Controls.Add(this.pnlTableBox, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(30, 80);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1124, 781);
            this.tlpMain.TabIndex = 1;

            // 
            // tlpCards
            // 
            this.tlpCards.ColumnCount = 4;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCards.Controls.Add(this.cardRed, 3, 0);
            this.tlpCards.Controls.Add(this.cardOrange, 2, 0);
            this.tlpCards.Controls.Add(this.cardGreen, 1, 0);
            this.tlpCards.Controls.Add(this.cardBlue, 0, 0);
            this.tlpCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCards.Location = new System.Drawing.Point(0, 0);
            this.tlpCards.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCards.Size = new System.Drawing.Size(1124, 140);
            this.tlpCards.TabIndex = 0;

            // 
            // cardRed
            // 
            this.cardRed.BorderRadius = 16;
            this.cardRed.Controls.Add(this.label4);
            this.cardRed.Controls.Add(this.lblSoBaoCho);
            this.cardRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardRed.FillColor = System.Drawing.Color.White;
            this.cardRed.FillColor2 = System.Drawing.Color.White;
            this.cardRed.Location = new System.Drawing.Point(853, 5);
            this.cardRed.Margin = new System.Windows.Forms.Padding(10, 5, 0, 15);
            this.cardRed.Name = "cardRed";
            this.cardRed.Padding = new System.Windows.Forms.Padding(18);
            this.cardRed.ShadowDecoration.Enabled = true;
            this.cardRed.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardRed.ShadowDecoration.Depth = 8;
            this.cardRed.Size = new System.Drawing.Size(271, 120);
            this.cardRed.TabIndex = 3;

            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.label4.Location = new System.Drawing.Point(18, 15);
            this.label4.Text = "Phiếu đang chờ duyệt";

            this.lblSoBaoCho.AutoSize = true;
            this.lblSoBaoCho.BackColor = System.Drawing.Color.Transparent;
            this.lblSoBaoCho.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoBaoCho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSoBaoCho.Location = new System.Drawing.Point(12, 45);
            this.lblSoBaoCho.Text = "0";

            // 
            // cardOrange
            // 
            this.cardOrange.BorderRadius = 16;
            this.cardOrange.Controls.Add(this.label3);
            this.cardOrange.Controls.Add(this.lblTongTien);
            this.cardOrange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardOrange.FillColor = System.Drawing.Color.White;
            this.cardOrange.FillColor2 = System.Drawing.Color.White;
            this.cardOrange.Location = new System.Drawing.Point(572, 5);
            this.cardOrange.Margin = new System.Windows.Forms.Padding(10, 5, 10, 15);
            this.cardOrange.Name = "cardOrange";
            this.cardOrange.Padding = new System.Windows.Forms.Padding(18);
            this.cardOrange.ShadowDecoration.Enabled = true;
            this.cardOrange.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardOrange.ShadowDecoration.Depth = 8;
            this.cardOrange.Size = new System.Drawing.Size(261, 120);
            this.cardOrange.TabIndex = 2;

            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Text = "Tổng tiền đã chi (VNĐ)";

            this.lblTongTien.AutoSize = true;
            this.lblTongTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTongTien.Location = new System.Drawing.Point(12, 45);
            this.lblTongTien.Text = "0";

            // 
            // cardGreen
            // 
            this.cardGreen.BorderRadius = 16;
            this.cardGreen.Controls.Add(this.label2);
            this.cardGreen.Controls.Add(this.lblSoTacGia);
            this.cardGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardGreen.FillColor = System.Drawing.Color.White;
            this.cardGreen.FillColor2 = System.Drawing.Color.White;
            this.cardGreen.Location = new System.Drawing.Point(291, 5);
            this.cardGreen.Margin = new System.Windows.Forms.Padding(10, 5, 10, 15);
            this.cardGreen.Name = "cardGreen";
            this.cardGreen.Padding = new System.Windows.Forms.Padding(18);
            this.cardGreen.ShadowDecoration.Enabled = true;
            this.cardGreen.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardGreen.ShadowDecoration.Depth = 8;
            this.cardGreen.Size = new System.Drawing.Size(261, 120);
            this.cardGreen.TabIndex = 1;

            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Text = "Tác giả hoạt động";

            this.lblSoTacGia.AutoSize = true;
            this.lblSoTacGia.BackColor = System.Drawing.Color.Transparent;
            this.lblSoTacGia.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoTacGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSoTacGia.Location = new System.Drawing.Point(12, 45);
            this.lblSoTacGia.Text = "0";

            // 
            // cardBlue
            // 
            this.cardBlue.BorderRadius = 16;
            this.cardBlue.Controls.Add(this.label1);
            this.cardBlue.Controls.Add(this.lblSoBaiViet);
            this.cardBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardBlue.FillColor = System.Drawing.Color.White;
            this.cardBlue.FillColor2 = System.Drawing.Color.White;
            this.cardBlue.Location = new System.Drawing.Point(0, 5);
            this.cardBlue.Margin = new System.Windows.Forms.Padding(0, 5, 10, 15);
            this.cardBlue.Name = "cardBlue";
            this.cardBlue.Padding = new System.Windows.Forms.Padding(18);
            this.cardBlue.ShadowDecoration.Enabled = true;
            this.cardBlue.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardBlue.ShadowDecoration.Depth = 8;
            this.cardBlue.Size = new System.Drawing.Size(271, 120);
            this.cardBlue.TabIndex = 0;

            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Text = "Bài viết xuất bản (Tháng)";

            this.lblSoBaiViet.AutoSize = true;
            this.lblSoBaiViet.BackColor = System.Drawing.Color.Transparent;
            this.lblSoBaiViet.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSoBaiViet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSoBaiViet.Location = new System.Drawing.Point(12, 45);
            this.lblSoBaiViet.Text = "0";

            // 
            // tlpCharts
            // 
            this.tlpCharts.ColumnCount = 2;
            this.tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpCharts.Controls.Add(this.pnlBoxPie, 1, 0);
            this.tlpCharts.Controls.Add(this.pnlBoxMain, 0, 0);
            this.tlpCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCharts.Location = new System.Drawing.Point(0, 150);
            this.tlpCharts.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCharts.Name = "tlpCharts";
            this.tlpCharts.RowCount = 1;
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCharts.Size = new System.Drawing.Size(1124, 380);
            this.tlpCharts.TabIndex = 1;

            // 
            // pnlBoxPie
            // 
            this.pnlBoxPie.BackColor = System.Drawing.Color.Transparent;
            this.pnlBoxPie.BorderRadius = 16;
            this.pnlBoxPie.Controls.Add(this.pnlChartPie);
            this.pnlBoxPie.Controls.Add(this.label6);
            this.pnlBoxPie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBoxPie.FillColor = System.Drawing.Color.White;
            this.pnlBoxPie.Location = new System.Drawing.Point(740, 10);
            this.pnlBoxPie.Margin = new System.Windows.Forms.Padding(10, 10, 0, 20);
            this.pnlBoxPie.Name = "pnlBoxPie";
            this.pnlBoxPie.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBoxPie.ShadowDecoration.Enabled = true;
            this.pnlBoxPie.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlBoxPie.ShadowDecoration.Depth = 10;
            this.pnlBoxPie.Size = new System.Drawing.Size(384, 350);
            this.pnlBoxPie.TabIndex = 1;

            this.pnlChartPie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartPie.Location = new System.Drawing.Point(20, 50);
            this.pnlChartPie.Size = new System.Drawing.Size(344, 280);
            this.pnlChartPie.TabIndex = 3;

            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label6.Location = new System.Drawing.Point(20, 20);
            this.label6.Size = new System.Drawing.Size(344, 30);
            this.label6.Text = "CƠ CẤU BÀI VIẾT THEO LOẠI BÁO";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlBoxMain
            // 
            this.pnlBoxMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlBoxMain.BorderRadius = 16;
            this.pnlBoxMain.Controls.Add(this.pnlChartMain);
            this.pnlBoxMain.Controls.Add(this.label5);
            this.pnlBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBoxMain.FillColor = System.Drawing.Color.White;
            this.pnlBoxMain.Location = new System.Drawing.Point(0, 10);
            this.pnlBoxMain.Margin = new System.Windows.Forms.Padding(0, 10, 10, 20);
            this.pnlBoxMain.Name = "pnlBoxMain";
            this.pnlBoxMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBoxMain.ShadowDecoration.Enabled = true;
            this.pnlBoxMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlBoxMain.ShadowDecoration.Depth = 10;
            this.pnlBoxMain.Size = new System.Drawing.Size(720, 350);
            this.pnlBoxMain.TabIndex = 0;

            this.pnlChartMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartMain.Location = new System.Drawing.Point(20, 50);
            this.pnlChartMain.Size = new System.Drawing.Size(680, 280);
            this.pnlChartMain.TabIndex = 3;

            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label5.Location = new System.Drawing.Point(20, 20);
            this.label5.Size = new System.Drawing.Size(680, 30);
            this.label5.Text = "BIẾN ĐỘNG CHI TRẢ NHUẬN BÚT (6 THÁNG QUA)";

            // 
            // pnlTableBox
            // 
            this.pnlTableBox.BackColor = System.Drawing.Color.Transparent;
            this.pnlTableBox.BorderRadius = 16;
            this.pnlTableBox.Controls.Add(this.dgvHoatDong);
            this.pnlTableBox.Controls.Add(this.label7);
            this.pnlTableBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableBox.FillColor = System.Drawing.Color.White;
            this.pnlTableBox.Location = new System.Drawing.Point(0, 530);
            this.pnlTableBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnlTableBox.Name = "pnlTableBox";
            this.pnlTableBox.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTableBox.ShadowDecoration.Enabled = true;
            this.pnlTableBox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlTableBox.ShadowDecoration.Depth = 10;
            this.pnlTableBox.Size = new System.Drawing.Size(1124, 231);
            this.pnlTableBox.TabIndex = 2;

            // 
            // dgvHoatDong
            // 
            this.dgvHoatDong.AllowUserToAddRows = false;
            this.dgvHoatDong.AllowUserToDeleteRows = false;

            // TRẢ LẠI AUTO-FILL TO TOÀN MÀN HÌNH CHUẨN ĐẸP
            this.dgvHoatDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Khóa cứng kích thước để tối ưu hóa hiệu năng, giảm tải tính toán
            this.dgvHoatDong.AllowUserToResizeColumns = false;
            this.dgvHoatDong.AllowUserToResizeRows = false;
            this.dgvHoatDong.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;

            // ĐỒNG BỘ MẪU HỆ THỐNG: Xóa bỏ dòng gán Theme cũ, để dgv dùng style gốc bên dưới
            this.dgvHoatDong.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;

            // DÒNG XEN KẼ: Khóa cứng màu được chọn trùng khớp màu nền gốc (Xám xanh nhạt dịu mắt)
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHoatDong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;

            this.dgvHoatDong.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoatDong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHoatDong.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoatDong.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            // Cấu hình thanh tiêu đề cột (Header)
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoatDong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoatDong.ColumnHeadersHeight = 40;

            // DÒNG THƯỜNG: Khóa cứng màu được chọn trùng khớp màu nền gốc (Trắng tinh khiết)
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoatDong.DefaultCellStyle = dataGridViewCellStyle3;

            this.dgvHoatDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoatDong.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvHoatDong.Location = new System.Drawing.Point(20, 50);
            this.dgvHoatDong.Name = "dgvHoatDong";
            this.dgvHoatDong.ReadOnly = true;
            this.dgvHoatDong.RowHeadersVisible = false;
            this.dgvHoatDong.RowTemplate.Height = 38;
            this.dgvHoatDong.Size = new System.Drawing.Size(1084, 161);
            this.dgvHoatDong.TabIndex = 4;

            // ĐỒNG BỘ TUYỆT ĐỐI VÀO THEMESTYLE TRONG LÕI CỦA GUNA
            this.dgvHoatDong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHoatDong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvHoatDong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));

            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvHoatDong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));

            this.dgvHoatDong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvHoatDong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));

            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label7.Location = new System.Drawing.Point(20, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1084, 30);
            this.label7.Text = "TOP PHIẾU CHI MỚI NHẤT CẦN XỬ LÝ";

            // 
            // FrmTongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1184, 881);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.pnlHeader);

            this.DoubleBuffered = true; // Đệm kép cấp Form

            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmTongQuan";
            this.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.Text = "Dashboard Quản Lý";
            this.Load += new System.EventHandler(this.FrmTongQuan_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpCards.ResumeLayout(false);
            this.cardRed.ResumeLayout(false);
            this.cardRed.PerformLayout();
            this.cardOrange.ResumeLayout(false);
            this.cardOrange.PerformLayout();
            this.cardGreen.ResumeLayout(false);
            this.cardGreen.PerformLayout();
            this.cardBlue.ResumeLayout(false);
            this.cardBlue.PerformLayout();
            this.tlpCharts.ResumeLayout(false);
            this.pnlBoxPie.ResumeLayout(false);
            this.pnlBoxMain.ResumeLayout(false);
            this.pnlTableBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoatDong)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private Guna.UI2.WinForms.Guna2GradientPanel cardBlue;
        private Guna.UI2.WinForms.Guna2GradientPanel cardRed;
        private Guna.UI2.WinForms.Guna2GradientPanel cardOrange;
        private Guna.UI2.WinForms.Guna2GradientPanel cardGreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSoBaiViet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSoBaoCho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSoTacGia;
        private System.Windows.Forms.TableLayoutPanel tlpCharts;
        private Guna.UI2.WinForms.Guna2Panel pnlBoxMain;
        private Guna.UI2.WinForms.Guna2Panel pnlBoxPie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Panel pnlTableBox;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHoatDong;
        private System.Windows.Forms.Panel pnlChartPie;
        private System.Windows.Forms.Panel pnlChartMain;
    }
}