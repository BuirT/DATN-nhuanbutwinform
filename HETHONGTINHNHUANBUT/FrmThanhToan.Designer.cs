namespace HETHONGTINHNHUANBUT
{
    partial class FrmThanhToan
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.groupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label1 = new System.Windows.Forms.Label(); this.txtMaso = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label(); this.txtTenGoi = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label(); this.dtpNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label(); this.dtpTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label(); this.dtpDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label(); this.cboLoaiBao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label(); this.cboVung = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label8 = new System.Windows.Forms.Label(); this.cboLoaiTT = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label(); this.cboHinhThuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label(); this.txtSoTien = new Guna.UI2.WinForms.Guna2TextBox();

            this.btnThem = new Guna.UI2.WinForms.Guna2Button(); this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button(); this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.dgvThanhToan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.groupBox1.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).BeginInit(); this.SuspendLayout();

            // GroupBox
            this.groupBox1.Controls.Add(this.txtSoTien); this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboHinhThuc); this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboLoaiTT); this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboVung); this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboLoaiBao); this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpDenNgay); this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpTuNgay); this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpNgay); this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenGoi); this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaso); this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(25, 20); this.groupBox1.Name = "groupBox1"; this.groupBox1.Size = new System.Drawing.Size(1000, 260); this.groupBox1.Text = "THÔNG TIN ĐỢT CHI TRẢ NHUẬN BÚT";

            // Row 1
            this.label1.AutoSize = true; this.label1.BackColor = System.Drawing.Color.White; this.label1.Location = new System.Drawing.Point(30, 65); this.label1.Name = "label1"; this.label1.Text = "Mã đợt:";
            this.txtMaso.BorderRadius = 5; this.txtMaso.ReadOnly = true; this.txtMaso.Location = new System.Drawing.Point(120, 57); this.txtMaso.Name = "txtMaso"; this.txtMaso.Size = new System.Drawing.Size(120, 36);

            this.label2.AutoSize = true; this.label2.BackColor = System.Drawing.Color.White; this.label2.Location = new System.Drawing.Point(260, 65); this.label2.Name = "label2"; this.label2.Text = "Tên gọi:";
            this.txtTenGoi.BorderRadius = 5; this.txtTenGoi.Font = new System.Drawing.Font("VNI-Times", 10.2F); this.txtTenGoi.Location = new System.Drawing.Point(340, 57); this.txtTenGoi.Name = "txtTenGoi"; this.txtTenGoi.Size = new System.Drawing.Size(350, 36);

            this.label3.AutoSize = true; this.label3.BackColor = System.Drawing.Color.White; this.label3.Location = new System.Drawing.Point(710, 65); this.label3.Name = "label3"; this.label3.Text = "Ngày lập:";
            this.dtpNgay.BorderRadius = 5; this.dtpNgay.FillColor = System.Drawing.Color.White; this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpNgay.Location = new System.Drawing.Point(800, 57); this.dtpNgay.Name = "dtpNgay"; this.dtpNgay.Size = new System.Drawing.Size(160, 36);

            // Row 2
            this.label4.AutoSize = true; this.label4.BackColor = System.Drawing.Color.White; this.label4.Location = new System.Drawing.Point(30, 125); this.label4.Name = "label4"; this.label4.Text = "Từ ngày:";
            this.dtpTuNgay.BorderRadius = 5; this.dtpTuNgay.FillColor = System.Drawing.Color.White; this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpTuNgay.Location = new System.Drawing.Point(120, 117); this.dtpTuNgay.Name = "dtpTuNgay"; this.dtpTuNgay.Size = new System.Drawing.Size(160, 36);

            this.label5.AutoSize = true; this.label5.BackColor = System.Drawing.Color.White; this.label5.Location = new System.Drawing.Point(300, 125); this.label5.Name = "label5"; this.label5.Text = "Đến ngày:";
            this.dtpDenNgay.BorderRadius = 5; this.dtpDenNgay.FillColor = System.Drawing.Color.White; this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpDenNgay.Location = new System.Drawing.Point(400, 117); this.dtpDenNgay.Name = "dtpDenNgay"; this.dtpDenNgay.Size = new System.Drawing.Size(160, 36);

            this.label10.AutoSize = true; this.label10.BackColor = System.Drawing.Color.White; this.label10.Location = new System.Drawing.Point(600, 125); this.label10.Name = "label10"; this.label10.Text = "Tổng tiền:";
            this.txtSoTien.BorderRadius = 5; this.txtSoTien.ForeColor = System.Drawing.Color.Red; this.txtSoTien.Location = new System.Drawing.Point(700, 117); this.txtSoTien.Name = "txtSoTien"; this.txtSoTien.Size = new System.Drawing.Size(260, 36);

            // Row 3
            this.label6.AutoSize = true; this.label6.BackColor = System.Drawing.Color.White; this.label6.Location = new System.Drawing.Point(30, 185); this.label6.Name = "label6"; this.label6.Text = "Loại báo:";
            this.cboLoaiBao.BorderRadius = 5; this.cboLoaiBao.Location = new System.Drawing.Point(120, 177); this.cboLoaiBao.Name = "cboLoaiBao"; this.cboLoaiBao.Size = new System.Drawing.Size(120, 36);

            this.label7.AutoSize = true; this.label7.BackColor = System.Drawing.Color.White; this.label7.Location = new System.Drawing.Point(260, 185); this.label7.Name = "label7"; this.label7.Text = "Vùng:";
            this.cboVung.BorderRadius = 5; this.cboVung.Location = new System.Drawing.Point(330, 177); this.cboVung.Name = "cboVung"; this.cboVung.Size = new System.Drawing.Size(120, 36);

            this.label8.AutoSize = true; this.label8.BackColor = System.Drawing.Color.White; this.label8.Location = new System.Drawing.Point(480, 185); this.label8.Name = "label8"; this.label8.Text = "Loại TT:";
            this.cboLoaiTT.BorderRadius = 5; this.cboLoaiTT.Location = new System.Drawing.Point(560, 177); this.cboLoaiTT.Name = "cboLoaiTT"; this.cboLoaiTT.Size = new System.Drawing.Size(120, 36);

            this.label9.AutoSize = true; this.label9.BackColor = System.Drawing.Color.White; this.label9.Location = new System.Drawing.Point(710, 185); this.label9.Name = "label9"; this.label9.Text = "Hình thức:";
            this.cboHinhThuc.BorderRadius = 5; this.cboHinhThuc.Location = new System.Drawing.Point(810, 177); this.cboHinhThuc.Name = "cboHinhThuc"; this.cboHinhThuc.Size = new System.Drawing.Size(150, 36);

            // Buttons
            this.btnThem.BorderRadius = 5; this.btnThem.FillColor = System.Drawing.Color.MediumSeaGreen; this.btnThem.Location = new System.Drawing.Point(25, 300); this.btnThem.Name = "btnThem"; this.btnThem.Size = new System.Drawing.Size(110, 45); this.btnThem.Text = "Thêm"; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.BorderRadius = 5; this.btnSua.FillColor = System.Drawing.Color.Gold; this.btnSua.ForeColor = System.Drawing.Color.Black; this.btnSua.Location = new System.Drawing.Point(155, 300); this.btnSua.Name = "btnSua"; this.btnSua.Size = new System.Drawing.Size(110, 45); this.btnSua.Text = "Sửa"; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnLuu.BorderRadius = 5; this.btnLuu.FillColor = System.Drawing.Color.DodgerBlue; this.btnLuu.Location = new System.Drawing.Point(285, 300); this.btnLuu.Name = "btnLuu"; this.btnLuu.Size = new System.Drawing.Size(110, 45); this.btnLuu.Text = "Lưu"; this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnXoa.BorderRadius = 5; this.btnXoa.FillColor = System.Drawing.Color.DarkOrange; this.btnXoa.Location = new System.Drawing.Point(415, 300); this.btnXoa.Name = "btnXoa"; this.btnXoa.Size = new System.Drawing.Size(110, 45); this.btnXoa.Text = "Xóa"; this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnHuy.BorderRadius = 5; this.btnHuy.FillColor = System.Drawing.Color.DimGray; this.btnHuy.Location = new System.Drawing.Point(545, 300); this.btnHuy.Name = "btnHuy"; this.btnHuy.Size = new System.Drawing.Size(110, 45); this.btnHuy.Text = "Hủy"; this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // DataGridView
            this.dgvThanhToan.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255); this.dgvThanhToan.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThanhToan.Location = new System.Drawing.Point(25, 360); this.dgvThanhToan.Name = "dgvThanhToan"; this.dgvThanhToan.Size = new System.Drawing.Size(1000, 250); this.dgvThanhToan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThanhToan_CellClick);

            // FrmThanhToan
            this.ClientSize = new System.Drawing.Size(1050, 640); this.Font = new System.Drawing.Font("Segoe UI", 10.2F); this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.dgvThanhToan); this.Controls.Add(this.btnHuy); this.Controls.Add(this.btnXoa); this.Controls.Add(this.btnLuu); this.Controls.Add(this.btnSua); this.Controls.Add(this.btnThem); this.Controls.Add(this.groupBox1);
            this.Name = "FrmThanhToan"; this.Text = "Tổng hợp Chi trả Nhuận bút"; this.Load += new System.EventHandler(this.FrmThanhToan_Load);
            this.groupBox1.ResumeLayout(false); this.groupBox1.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).EndInit(); this.ResumeLayout(false);
        }
        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox groupBox1;
        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6, label7, label8, label9, label10;
        private Guna.UI2.WinForms.Guna2TextBox txtMaso, txtTenGoi, txtSoTien;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgay, dtpTuNgay, dtpDenNgay;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiBao, cboVung, cboLoaiTT, cboHinhThuc;
        private Guna.UI2.WinForms.Guna2Button btnThem, btnSua, btnLuu, btnXoa, btnHuy;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThanhToan;
    }
}