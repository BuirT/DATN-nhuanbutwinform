using System;

namespace HETHONGTINHNHUANBUT
{
    partial class FrmBaoCaoThongKe
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
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
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboChuyenMuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboPhongVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnXuatExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnIn = new Guna.UI2.WinForms.Guna2Button();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvBaoCao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.Text = "BÁO CÁO THỐNG KÊ NHUẬN BÚT";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(400, 30);

            this.pnlFilter.FillColor = System.Drawing.Color.White;
            this.pnlFilter.BorderRadius = 12;
            this.pnlFilter.ShadowDecoration.Enabled = true;
            this.pnlFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.pnlFilter.Location = new System.Drawing.Point(20, 55);
            this.pnlFilter.Size = new System.Drawing.Size(1100, 60);

            System.Windows.Forms.Label lblTuNgay = new System.Windows.Forms.Label();
            lblTuNgay.Text = "Từ ngày:"; lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 9);
            lblTuNgay.Location = new System.Drawing.Point(15, 20); lblTuNgay.Size = new System.Drawing.Size(55, 20);

            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Value = new DateTime(DateTime.Now.Year, 1, 1);
            this.dtpTuNgay.Location = new System.Drawing.Point(70, 15); this.dtpTuNgay.Size = new System.Drawing.Size(130, 30);

            System.Windows.Forms.Label lblDenNgay = new System.Windows.Forms.Label();
            lblDenNgay.Text = "Đến ngày:"; lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9);
            lblDenNgay.Location = new System.Drawing.Point(215, 20); lblDenNgay.Size = new System.Drawing.Size(60, 20);

            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Value = DateTime.Now;
            this.dtpDenNgay.Location = new System.Drawing.Point(275, 15); this.dtpDenNgay.Size = new System.Drawing.Size(130, 30);

            System.Windows.Forms.Label lblCM = new System.Windows.Forms.Label();
            lblCM.Text = "Chuyên mục:"; lblCM.Font = new System.Drawing.Font("Segoe UI", 9);
            lblCM.Location = new System.Drawing.Point(425, 20); lblCM.Size = new System.Drawing.Size(75, 20);

            this.cboChuyenMuc.Location = new System.Drawing.Point(500, 15); this.cboChuyenMuc.Size = new System.Drawing.Size(140, 30);

            System.Windows.Forms.Label lblPV = new System.Windows.Forms.Label();
            lblPV.Text = "PV/Bút danh:"; lblPV.Font = new System.Drawing.Font("Segoe UI", 9);
            lblPV.Location = new System.Drawing.Point(655, 20); lblPV.Size = new System.Drawing.Size(80, 20);

            this.cboPhongVien.Location = new System.Drawing.Point(735, 15); this.cboPhongVien.Size = new System.Drawing.Size(140, 30);

            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.FillColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(895, 12); this.btnLoc.Size = new System.Drawing.Size(90, 35);

            this.btnXuatExcel.Text = "📊 Excel";
            this.btnXuatExcel.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(995, 12); this.btnXuatExcel.Size = new System.Drawing.Size(90, 35);

            this.pnlFilter.Controls.Add(lblTuNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(lblDenNgay);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(lblCM);
            this.pnlFilter.Controls.Add(this.cboChuyenMuc);
            this.pnlFilter.Controls.Add(lblPV);
            this.pnlFilter.Controls.Add(this.cboPhongVien);
            this.pnlFilter.Controls.Add(this.btnLoc);
            this.pnlFilter.Controls.Add(this.btnXuatExcel);

            this.dgvBaoCao.Location = new System.Drawing.Point(20, 130);
            this.dgvBaoCao.Size = new System.Drawing.Size(1100, 450);
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.lblTongCong.Text = "Tổng cộng: 0 VNĐ";
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTongCong.Location = new System.Drawing.Point(20, 590);
            this.lblTongCong.Size = new System.Drawing.Size(400, 25);

            this.btnIn.Text = "🖨 In";
            this.btnIn.FillColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.Location = new System.Drawing.Point(1030, 587); this.btnIn.Size = new System.Drawing.Size(90, 35);

            this.ClientSize = new System.Drawing.Size(1140, 640);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.lblTongCong);
            this.Controls.Add(this.btnIn);
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.Name = "FrmBaoCaoThongKe";
            this.Text = "Báo Cáo Thống Kê";
            this.pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
