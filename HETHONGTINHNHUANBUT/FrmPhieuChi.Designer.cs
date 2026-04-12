using System.Drawing;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    partial class FrmPhieuChi
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
            this.grpThongTin = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtSoPhieu = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTacGia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChuaThanhToan = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpKetQua = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cboHinhThuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtThucLinh = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThue = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLapPhieu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuaThanhToan)).BeginInit();
            this.grpKetQua.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin (Neo Trên - Trái - Phải)
            // 
            this.grpThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongTin.BorderRadius = 5;
            this.grpThongTin.Controls.Add(this.txtSoPhieu);
            this.grpThongTin.Controls.Add(this.label2);
            this.grpThongTin.Controls.Add(this.cboTacGia);
            this.grpThongTin.Controls.Add(this.label1);
            this.grpThongTin.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTin.ForeColor = System.Drawing.Color.White;
            this.grpThongTin.Location = new System.Drawing.Point(30, 20);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(920, 110);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.Text = "THÔNG TIN PHIẾU CHI";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.BorderRadius = 5;
            this.txtSoPhieu.DefaultText = "";
            this.txtSoPhieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSoPhieu.ForeColor = System.Drawing.Color.Black;
            this.txtSoPhieu.Location = new System.Drawing.Point(540, 53);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(200, 36);
            this.txtSoPhieu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(450, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.Text = "Số phiếu:";
            // 
            // cboTacGia
            // 
            this.cboTacGia.BackColor = System.Drawing.Color.Transparent;
            this.cboTacGia.BorderRadius = 5;
            this.cboTacGia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTacGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTacGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTacGia.ForeColor = System.Drawing.Color.Black;
            this.cboTacGia.ItemHeight = 30;
            this.cboTacGia.Location = new System.Drawing.Point(95, 53);
            this.cboTacGia.Name = "cboTacGia";
            this.cboTacGia.Size = new System.Drawing.Size(300, 36);
            this.cboTacGia.TabIndex = 1;
            this.cboTacGia.SelectedIndexChanged += new System.EventHandler(this.cboTacGia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.Text = "Tác giả:";
            // 
            // dgvChuaThanhToan (Cái bảng - Neo 4 hướng ĐỂ CO GIÃN TOÀN DIỆN)
            // 
            this.dgvChuaThanhToan.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvChuaThanhToan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChuaThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChuaThanhToan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChuaThanhToan.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvChuaThanhToan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChuaThanhToan.ColumnHeadersHeight = 35;
            this.dgvChuaThanhToan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChuaThanhToan.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChuaThanhToan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChuaThanhToan.Location = new System.Drawing.Point(30, 150);
            this.dgvChuaThanhToan.Name = "dgvChuaThanhToan";
            this.dgvChuaThanhToan.RowHeadersVisible = false;
            this.dgvChuaThanhToan.Size = new System.Drawing.Size(920, 250);
            this.dgvChuaThanhToan.TabIndex = 1;
            this.dgvChuaThanhToan.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChuaThanhToan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChuaThanhToan_CellValueChanged);
            this.dgvChuaThanhToan.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvChuaThanhToan_CurrentCellDirtyStateChanged);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "Chọn chi";
            this.colCheck.MinimumWidth = 6;
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 80;
            // 
            // grpKetQua (Neo Dưới - Trái - Phải)
            // 
            this.grpKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKetQua.BorderRadius = 5;
            this.grpKetQua.Controls.Add(this.cboHinhThuc);
            this.grpKetQua.Controls.Add(this.label6);
            this.grpKetQua.Controls.Add(this.txtThucLinh);
            this.grpKetQua.Controls.Add(this.label5);
            this.grpKetQua.Controls.Add(this.txtThue);
            this.grpKetQua.Controls.Add(this.label4);
            this.grpKetQua.Controls.Add(this.txtTongTien);
            this.grpKetQua.Controls.Add(this.label3);
            this.grpKetQua.CustomBorderColor = System.Drawing.Color.MediumSeaGreen;
            this.grpKetQua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpKetQua.ForeColor = System.Drawing.Color.White;
            this.grpKetQua.Location = new System.Drawing.Point(30, 420);
            this.grpKetQua.Name = "grpKetQua";
            this.grpKetQua.Size = new System.Drawing.Size(920, 150);
            this.grpKetQua.TabIndex = 2;
            this.grpKetQua.Text = "TÍNH TOÁN THANH TOÁN";
            // 
            // cboHinhThuc
            // 
            this.cboHinhThuc.BackColor = System.Drawing.Color.Transparent;
            this.cboHinhThuc.BorderRadius = 5;
            this.cboHinhThuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboHinhThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHinhThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboHinhThuc.ForeColor = System.Drawing.Color.Black;
            this.cboHinhThuc.ItemHeight = 30;
            this.cboHinhThuc.Items.AddRange(new object[] {
            "Chuyển khoản (CK)",
            "Tiền mặt (TM)"});
            this.cboHinhThuc.Location = new System.Drawing.Point(115, 100);
            this.cboHinhThuc.Name = "cboHinhThuc";
            this.cboHinhThuc.Size = new System.Drawing.Size(250, 36);
            this.cboHinhThuc.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(20, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 23);
            this.label6.Text = "Hình thức:";
            // 
            // txtThucLinh
            // 
            this.txtThucLinh.BorderRadius = 5;
            this.txtThucLinh.DefaultText = "0";
            this.txtThucLinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtThucLinh.ForeColor = System.Drawing.Color.Crimson;
            this.txtThucLinh.Location = new System.Drawing.Point(615, 53);
            this.txtThucLinh.Name = "txtThucLinh";
            this.txtThucLinh.ReadOnly = true;
            this.txtThucLinh.Size = new System.Drawing.Size(250, 40);
            this.txtThucLinh.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(520, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 23);
            this.label5.Text = "Thực lĩnh:";
            // 
            // txtThue
            // 
            this.txtThue.BorderRadius = 5;
            this.txtThue.DefaultText = "10";
            this.txtThue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtThue.ForeColor = System.Drawing.Color.Black;
            this.txtThue.Location = new System.Drawing.Point(405, 53);
            this.txtThue.Name = "txtThue";
            this.txtThue.Size = new System.Drawing.Size(80, 36);
            this.txtThue.TabIndex = 3;
            this.txtThue.TextChanged += new System.EventHandler(this.txtThue_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(320, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.Text = "Thuế (%):";
            // 
            // txtTongTien
            // 
            this.txtTongTien.BorderRadius = 5;
            this.txtTongTien.DefaultText = "0";
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTongTien.ForeColor = System.Drawing.Color.Black;
            this.txtTongTien.Location = new System.Drawing.Point(115, 53);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(180, 36);
            this.txtTongTien.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.Text = "Tổng tiền:";
            // 
            // btnLapPhieu (Neo Dưới - Trái)
            // 
            this.btnLapPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLapPhieu.BorderRadius = 5;
            this.btnLapPhieu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnLapPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieu.ForeColor = System.Drawing.Color.White;
            this.btnLapPhieu.Location = new System.Drawing.Point(30, 590);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(180, 45);
            this.btnLapPhieu.TabIndex = 3;
            this.btnLapPhieu.Text = "LẬP PHIẾU CHI";
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // btnHuy (Neo Dưới - Trái)
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHuy.BorderRadius = 5;
            this.btnHuy.FillColor = System.Drawing.Color.SlateGray;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(230, 590);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 45);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "HỦY BỎ";
            // 
            // FrmPhieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(980, 660);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLapPhieu);
            this.Controls.Add(this.grpKetQua);
            this.Controls.Add(this.dgvChuaThanhToan);
            this.Controls.Add(this.grpThongTin);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmPhieuChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lập Phiếu Chi Nhuận Bút";
            this.Load += new System.EventHandler(this.FrmPhieuChi_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuaThanhToan)).EndInit();
            this.grpKetQua.ResumeLayout(false);
            this.grpKetQua.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox grpThongTin;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboTacGia;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtSoPhieu;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChuaThanhToan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private Guna.UI2.WinForms.Guna2GroupBox grpKetQua;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtTongTien;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtThue;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtThucLinh;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cboHinhThuc;
        private Guna.UI2.WinForms.Guna2Button btnLapPhieu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}