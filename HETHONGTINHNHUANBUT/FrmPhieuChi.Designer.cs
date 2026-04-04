namespace HETHONGTINHNHUANBUT
{
    partial class FrmPhieuChi
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label(); this.label2 = new System.Windows.Forms.Label(); this.label3 = new System.Windows.Forms.Label(); this.label4 = new System.Windows.Forms.Label(); this.label5 = new System.Windows.Forms.Label(); this.label6 = new System.Windows.Forms.Label(); this.label7 = new System.Windows.Forms.Label(); this.label8 = new System.Windows.Forms.Label();
            this.txtSoPhieu = new Guna.UI2.WinForms.Guna2TextBox(); this.dtpNgayLap = new Guna.UI2.WinForms.Guna2DateTimePicker(); this.txtNguoiNhan = new Guna.UI2.WinForms.Guna2TextBox(); this.txtLyDo = new Guna.UI2.WinForms.Guna2TextBox(); this.txtSoTien = new Guna.UI2.WinForms.Guna2TextBox(); this.txtThueSuat = new Guna.UI2.WinForms.Guna2TextBox(); this.txtThue = new Guna.UI2.WinForms.Guna2TextBox(); this.txtConLai = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button(); this.btnSua = new Guna.UI2.WinForms.Guna2Button(); this.btnLuu = new Guna.UI2.WinForms.Guna2Button(); this.btnXoa = new Guna.UI2.WinForms.Guna2Button(); this.btnHuy = new Guna.UI2.WinForms.Guna2Button();

            // 🌟 2 NÚT GỬI EMAIL:
            this.btnGuiEmail = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuiHangLoat = new Guna.UI2.WinForms.Guna2Button(); // Nút mới!

            this.dgvPhieuChi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.groupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChi)).BeginInit(); this.groupBox1.SuspendLayout(); this.SuspendLayout();

            // Labels & Inputs (Giữ nguyên như cũ)
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(30, 55); this.label1.Name = "label1"; this.label1.Text = "Số phiếu:"; this.label1.BackColor = System.Drawing.Color.White;
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(330, 55); this.label2.Name = "label2"; this.label2.Text = "Ngày lập:"; this.label2.BackColor = System.Drawing.Color.White;
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(30, 105); this.label3.Name = "label3"; this.label3.Text = "Người nhận:"; this.label3.BackColor = System.Drawing.Color.White;
            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(400, 105); this.label4.Name = "label4"; this.label4.Text = "Lý do chi:"; this.label4.BackColor = System.Drawing.Color.White;
            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(30, 155); this.label5.Name = "label5"; this.label5.Text = "Tổng tiền:"; this.label5.BackColor = System.Drawing.Color.White;
            this.label6.AutoSize = true; this.label6.Location = new System.Drawing.Point(260, 155); this.label6.Name = "label6"; this.label6.Text = "Thuế suất (%):"; this.label6.BackColor = System.Drawing.Color.White;
            this.label7.AutoSize = true; this.label7.Location = new System.Drawing.Point(470, 155); this.label7.Name = "label7"; this.label7.Text = "Tiền thuế:"; this.label7.BackColor = System.Drawing.Color.White;
            this.label8.AutoSize = true; this.label8.Location = new System.Drawing.Point(680, 155); this.label8.Name = "label8"; this.label8.Text = "Thực nhận:"; this.label8.BackColor = System.Drawing.Color.White;

            this.txtSoPhieu.BorderRadius = 5; this.txtSoPhieu.Location = new System.Drawing.Point(120, 47); this.txtSoPhieu.Name = "txtSoPhieu"; this.txtSoPhieu.Size = new System.Drawing.Size(180, 36);
            this.dtpNgayLap.BorderRadius = 5; this.dtpNgayLap.FillColor = System.Drawing.Color.White; this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpNgayLap.Location = new System.Drawing.Point(420, 47); this.dtpNgayLap.Name = "dtpNgayLap"; this.dtpNgayLap.Size = new System.Drawing.Size(180, 36);
            this.txtNguoiNhan.BorderRadius = 5; this.txtNguoiNhan.Font = new System.Drawing.Font("VNI-Times", 10.2F); this.txtNguoiNhan.Location = new System.Drawing.Point(140, 97); this.txtNguoiNhan.Name = "txtNguoiNhan"; this.txtNguoiNhan.Size = new System.Drawing.Size(230, 36);
            this.txtLyDo.BorderRadius = 5; this.txtLyDo.Font = new System.Drawing.Font("VNI-Times", 10.2F); this.txtLyDo.Location = new System.Drawing.Point(490, 97); this.txtLyDo.Name = "txtLyDo"; this.txtLyDo.Size = new System.Drawing.Size(430, 36);
            this.txtSoTien.BorderRadius = 5; this.txtSoTien.Location = new System.Drawing.Point(120, 147); this.txtSoTien.Name = "txtSoTien"; this.txtSoTien.Size = new System.Drawing.Size(130, 36); this.txtSoTien.TextChanged += new System.EventHandler(this.TinhTien_TextChanged);
            this.txtThueSuat.BorderRadius = 5; this.txtThueSuat.Location = new System.Drawing.Point(380, 147); this.txtThueSuat.Name = "txtThueSuat"; this.txtThueSuat.Size = new System.Drawing.Size(80, 36); this.txtThueSuat.Text = "10"; this.txtThueSuat.TextChanged += new System.EventHandler(this.TinhTien_TextChanged);
            this.txtThue.BorderRadius = 5; this.txtThue.ReadOnly = true; this.txtThue.Location = new System.Drawing.Point(560, 147); this.txtThue.Name = "txtThue"; this.txtThue.Size = new System.Drawing.Size(110, 36);
            this.txtConLai.BorderRadius = 5; this.txtConLai.ReadOnly = true; this.txtConLai.ForeColor = System.Drawing.Color.Red; this.txtConLai.Location = new System.Drawing.Point(780, 147); this.txtConLai.Name = "txtConLai"; this.txtConLai.Size = new System.Drawing.Size(140, 36);

            this.groupBox1.Controls.Add(this.txtConLai); this.groupBox1.Controls.Add(this.label8); this.groupBox1.Controls.Add(this.txtThue); this.groupBox1.Controls.Add(this.label7); this.groupBox1.Controls.Add(this.txtThueSuat); this.groupBox1.Controls.Add(this.label6); this.groupBox1.Controls.Add(this.txtSoTien); this.groupBox1.Controls.Add(this.label5); this.groupBox1.Controls.Add(this.txtLyDo); this.groupBox1.Controls.Add(this.label4); this.groupBox1.Controls.Add(this.txtNguoiNhan); this.groupBox1.Controls.Add(this.label3); this.groupBox1.Controls.Add(this.dtpNgayLap); this.groupBox1.Controls.Add(this.label2); this.groupBox1.Controls.Add(this.txtSoPhieu); this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold); this.groupBox1.Location = new System.Drawing.Point(25, 20); this.groupBox1.Name = "groupBox1"; this.groupBox1.Size = new System.Drawing.Size(950, 210); this.groupBox1.Text = "THÔNG TIN PHIẾU CHI NHUẬN BÚT";

            // Các nút cơ bản
            this.btnThem.BorderRadius = 5; this.btnThem.FillColor = System.Drawing.Color.MediumSeaGreen; this.btnThem.Location = new System.Drawing.Point(25, 250); this.btnThem.Name = "btnThem"; this.btnThem.Size = new System.Drawing.Size(90, 45); this.btnThem.Text = "Thêm"; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.BorderRadius = 5; this.btnSua.FillColor = System.Drawing.Color.Gold; this.btnSua.ForeColor = System.Drawing.Color.Black; this.btnSua.Location = new System.Drawing.Point(125, 250); this.btnSua.Name = "btnSua"; this.btnSua.Size = new System.Drawing.Size(90, 45); this.btnSua.Text = "Sửa"; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnLuu.BorderRadius = 5; this.btnLuu.FillColor = System.Drawing.Color.DodgerBlue; this.btnLuu.Location = new System.Drawing.Point(225, 250); this.btnLuu.Name = "btnLuu"; this.btnLuu.Size = new System.Drawing.Size(90, 45); this.btnLuu.Text = "Lưu"; this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnXoa.BorderRadius = 5; this.btnXoa.FillColor = System.Drawing.Color.DarkOrange; this.btnXoa.Location = new System.Drawing.Point(325, 250); this.btnXoa.Name = "btnXoa"; this.btnXoa.Size = new System.Drawing.Size(90, 45); this.btnXoa.Text = "Xóa"; this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnHuy.BorderRadius = 5; this.btnHuy.FillColor = System.Drawing.Color.DimGray; this.btnHuy.Location = new System.Drawing.Point(425, 250); this.btnHuy.Name = "btnHuy"; this.btnHuy.Size = new System.Drawing.Size(90, 45); this.btnHuy.Text = "Hủy"; this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // 🌟 NÚT GỬI 1 MAIL
            this.btnGuiEmail.BorderRadius = 5;
            this.btnGuiEmail.FillColor = System.Drawing.Color.MediumPurple;
            this.btnGuiEmail.Location = new System.Drawing.Point(545, 250);
            this.btnGuiEmail.Name = "btnGuiEmail";
            this.btnGuiEmail.Size = new System.Drawing.Size(180, 45);
            this.btnGuiEmail.Text = "📧 Gửi 1 Mail";
            this.btnGuiEmail.Click += new System.EventHandler(this.btnGuiEmail_Click);

            // 🌟 NÚT GỬI HÀNG LOẠT (MÀU ĐỎ CAM)
            this.btnGuiHangLoat.BorderRadius = 5;
            this.btnGuiHangLoat.FillColor = System.Drawing.Color.Tomato;
            this.btnGuiHangLoat.Location = new System.Drawing.Point(735, 250);
            this.btnGuiHangLoat.Name = "btnGuiHangLoat";
            this.btnGuiHangLoat.Size = new System.Drawing.Size(180, 45);
            this.btnGuiHangLoat.Text = "📨 GỬI HÀNG LOẠT";
            this.btnGuiHangLoat.Click += new System.EventHandler(this.btnGuiHangLoat_Click);

            // DataGridView
            this.dgvPhieuChi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255); this.dgvPhieuChi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPhieuChi.Location = new System.Drawing.Point(25, 310); this.dgvPhieuChi.Name = "dgvPhieuChi"; this.dgvPhieuChi.Size = new System.Drawing.Size(950, 270); this.dgvPhieuChi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuChi_CellClick);

            // FrmPhieuChi
            this.ClientSize = new System.Drawing.Size(1000, 600); this.Font = new System.Drawing.Font("Segoe UI", 10.2F); this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnGuiHangLoat);
            this.Controls.Add(this.btnGuiEmail);
            this.Controls.Add(this.dgvPhieuChi); this.Controls.Add(this.btnHuy); this.Controls.Add(this.btnXoa); this.Controls.Add(this.btnLuu); this.Controls.Add(this.btnSua); this.Controls.Add(this.btnThem); this.Controls.Add(this.groupBox1);
            this.Name = "FrmPhieuChi"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; this.Text = "Lập Phiếu Chi Nhuận Bút"; this.Load += new System.EventHandler(this.FrmPhieuChi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChi)).EndInit(); this.groupBox1.ResumeLayout(false); this.groupBox1.PerformLayout(); this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6, label7, label8;
        private Guna.UI2.WinForms.Guna2TextBox txtSoPhieu, txtNguoiNhan, txtLyDo, txtSoTien, txtThueSuat, txtThue, txtConLai;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayLap;
        private Guna.UI2.WinForms.Guna2Button btnThem, btnSua, btnLuu, btnXoa, btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnGuiEmail;
        private Guna.UI2.WinForms.Guna2Button btnGuiHangLoat; // Khai báo nút mới
        private Guna.UI2.WinForms.Guna2DataGridView dgvPhieuChi;
        private Guna.UI2.WinForms.Guna2GroupBox groupBox1;
    }
}