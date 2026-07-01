using System;

namespace HETHONGTINHNHUANBUT
{
    partial class FrmBaoCaoThongKe
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlBot;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTuNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDenNgay;
        private Guna.UI2.WinForms.Guna2ComboBox cboChuyenMuc;
        private Guna.UI2.WinForms.Guna2ComboBox cboPhongVien;
        private Guna.UI2.WinForms.Guna2Button btnLoc;
        private Guna.UI2.WinForms.Guna2Button btnXuatExcel;
        private Guna.UI2.WinForms.Guna2Button btnIn;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBaoCao;
        private System.Windows.Forms.Label lblTongCong;
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
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dtpTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboChuyenMuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboPhongVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnXuatExcel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBot = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvBaoCao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.btnIn = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTop.SuspendLayout();
            this.pnlBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.dtpTuNgay);
            this.pnlTop.Controls.Add(this.dtpDenNgay);
            this.pnlTop.Controls.Add(this.cboChuyenMuc);
            this.pnlTop.Controls.Add(this.cboPhongVien);
            this.pnlTop.Controls.Add(this.btnLoc);
            this.pnlTop.Controls.Add(this.btnXuatExcel);
            //
            // filter labels
            //
            System.Windows.Forms.Label lblTuNgay = new System.Windows.Forms.Label();
            lblTuNgay.Text = "Từ ngày:"; lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            lblTuNgay.Location = new System.Drawing.Point(25, 80); lblTuNgay.Size = new System.Drawing.Size(50, 20);
            this.pnlTop.Controls.Add(lblTuNgay);

            System.Windows.Forms.Label lblDenNgay = new System.Windows.Forms.Label();
            lblDenNgay.Text = "Đến ngày:"; lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            lblDenNgay.Location = new System.Drawing.Point(225, 80); lblDenNgay.Size = new System.Drawing.Size(55, 20);
            this.pnlTop.Controls.Add(lblDenNgay);

            System.Windows.Forms.Label lblCM = new System.Windows.Forms.Label();
            lblCM.Text = "Chuyên mục:"; lblCM.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblCM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            lblCM.Location = new System.Drawing.Point(435, 80); lblCM.Size = new System.Drawing.Size(70, 20);
            this.pnlTop.Controls.Add(lblCM);

            System.Windows.Forms.Label lblPV = new System.Windows.Forms.Label();
            lblPV.Text = "PV/Bút danh:"; lblPV.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            lblPV.Location = new System.Drawing.Point(665, 80); lblPV.Size = new System.Drawing.Size(70, 20);
            this.pnlTop.Controls.Add(lblPV);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.ShadowDecoration.Enabled = false;
            this.pnlTop.Size = new System.Drawing.Size(1100, 140);
            this.pnlTop.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO THỐNG KÊ NHUẬN BÚT";
            //
            // dtpTuNgay
            //
            this.dtpTuNgay.Checked = true;
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(80, 75);
            this.dtpTuNgay.MaxDate = new DateTime(9998, 12, 31);
            this.dtpTuNgay.MinDate = new DateTime(1753, 1, 1);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 30);
            this.dtpTuNgay.TabIndex = 1;
            this.dtpTuNgay.Value = new DateTime(DateTime.Now.Year, 1, 1);
            //
            // dtpDenNgay
            //
            this.dtpDenNgay.Checked = true;
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(285, 75);
            this.dtpDenNgay.MaxDate = new DateTime(9998, 12, 31);
            this.dtpDenNgay.MinDate = new DateTime(1753, 1, 1);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 30);
            this.dtpDenNgay.TabIndex = 2;
            this.dtpDenNgay.Value = DateTime.Now;
            //
            // cboChuyenMuc
            //
            this.cboChuyenMuc.BackColor = System.Drawing.Color.Transparent;
            this.cboChuyenMuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboChuyenMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenMuc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.cboChuyenMuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.cboChuyenMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboChuyenMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboChuyenMuc.ItemHeight = 30;
            this.cboChuyenMuc.Location = new System.Drawing.Point(510, 73);
            this.cboChuyenMuc.Name = "cboChuyenMuc";
            this.cboChuyenMuc.Size = new System.Drawing.Size(140, 36);
            this.cboChuyenMuc.TabIndex = 3;
            //
            // cboPhongVien
            //
            this.cboPhongVien.BackColor = System.Drawing.Color.Transparent;
            this.cboPhongVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPhongVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongVien.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.cboPhongVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.cboPhongVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhongVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboPhongVien.ItemHeight = 30;
            this.cboPhongVien.Location = new System.Drawing.Point(740, 73);
            this.cboPhongVien.Name = "cboPhongVien";
            this.cboPhongVien.Size = new System.Drawing.Size(140, 36);
            this.cboPhongVien.TabIndex = 4;
            //
            // btnLoc
            //
            this.btnLoc.Animated = false;
            this.btnLoc.BorderRadius = 8;
            this.btnLoc.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(910, 73);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(85, 36);
            this.btnLoc.TabIndex = 5;
            this.btnLoc.Text = "🔍 Lọc";
            //
            // btnXuatExcel
            //
            this.btnXuatExcel.Animated = false;
            this.btnXuatExcel.BorderRadius = 8;
            this.btnXuatExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(1005, 73);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(70, 36);
            this.btnXuatExcel.TabIndex = 6;
            this.btnXuatExcel.Text = "📊 Excel";
            //
            // pnlBot
            //
            this.pnlBot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBot.BackColor = System.Drawing.Color.Transparent;
            this.pnlBot.BorderRadius = 16;
            this.pnlBot.Controls.Add(this.dgvBaoCao);
            this.pnlBot.FillColor = System.Drawing.Color.White;
            this.pnlBot.Location = new System.Drawing.Point(20, 170);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlBot.ShadowDecoration.Depth = 8;
            this.pnlBot.ShadowDecoration.Enabled = false;
            this.pnlBot.Size = new System.Drawing.Size(1100, 490);
            this.pnlBot.TabIndex = 1;
            //
            // dgvBaoCao
            //
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.AllowUserToResizeColumns = false;
            this.dgvBaoCao.AllowUserToResizeRows = false;
            this.dgvBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBaoCao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBaoCao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBaoCao.Location = new System.Drawing.Point(25, 20);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersVisible = false;
            this.dgvBaoCao.Size = new System.Drawing.Size(1050, 450);
            this.dgvBaoCao.TabIndex = 0;
            this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBaoCao.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaoCao.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBaoCao.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBaoCao.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBaoCao.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvBaoCao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBaoCao.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBaoCao.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvBaoCao.ThemeStyle.ReadOnly = true;
            this.dgvBaoCao.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaoCao.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBaoCao.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvBaoCao.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBaoCao.ThemeStyle.RowsStyle.Height = 38;
            this.dgvBaoCao.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBaoCao.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            //
            // lblTongCong
            //
            this.lblTongCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTongCong.Location = new System.Drawing.Point(20, 675);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(500, 25);
            this.lblTongCong.TabIndex = 2;
            this.lblTongCong.Text = "Tổng cộng: 0 VNĐ";
            //
            // btnIn
            //
            this.btnIn.Animated = false;
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.BorderRadius = 8;
            this.btnIn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.Location = new System.Drawing.Point(1030, 670);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(90, 36);
            this.btnIn.TabIndex = 3;
            this.btnIn.Text = "🖨 In";
            //
            // FrmBaoCaoThongKe
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1140, 715);
            this.DoubleBuffered = true;
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.lblTongCong);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FrmBaoCaoThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Thống Kê";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
