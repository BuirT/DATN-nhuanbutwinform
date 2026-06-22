namespace HETHONGTINHNHUANBUT
{
    partial class FrmXemBaiViet
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTieuDeLabel;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblPhongVienLabel;
        private System.Windows.Forms.Label lblPhongVien;
        private System.Windows.Forms.Label lblTienNBLabel;
        private System.Windows.Forms.Label lblTienNB;
        private System.Windows.Forms.Label lblDiemAILabel;
        private System.Windows.Forms.Label lblDiemAI;
        private System.Windows.Forms.Label lblLoaiCanhBaoLabel;
        private System.Windows.Forms.Label lblLoaiCanhBao;
        private System.Windows.Forms.Label lblNoiDungLabel;
        private System.Windows.Forms.RichTextBox txtNoiDung;
        private System.Windows.Forms.Label lblDanhGiaAILabel;
        private System.Windows.Forms.RichTextBox txtDanhGiaAI;
        private System.Windows.Forms.Label lblCanhBaoLabel;
        private System.Windows.Forms.RichTextBox txtNoiDungCanhBao;
        private Guna.UI2.WinForms.Guna2Button btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTieuDeLabel = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblPhongVienLabel = new System.Windows.Forms.Label();
            this.lblPhongVien = new System.Windows.Forms.Label();
            this.lblTienNBLabel = new System.Windows.Forms.Label();
            this.lblTienNB = new System.Windows.Forms.Label();
            this.lblDiemAILabel = new System.Windows.Forms.Label();
            this.lblDiemAI = new System.Windows.Forms.Label();
            this.lblLoaiCanhBaoLabel = new System.Windows.Forms.Label();
            this.lblLoaiCanhBao = new System.Windows.Forms.Label();
            this.lblNoiDungLabel = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.RichTextBox();
            this.lblDanhGiaAILabel = new System.Windows.Forms.Label();
            this.txtDanhGiaAI = new System.Windows.Forms.RichTextBox();
            this.lblCanhBaoLabel = new System.Windows.Forms.Label();
            this.txtNoiDungCanhBao = new System.Windows.Forms.RichTextBox();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.BorderRadius = 16;
            this.pnlMain.FillColor = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(15, 15);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlMain.ShadowDecoration.Depth = 8;
            this.pnlMain.ShadowDecoration.Enabled = false;
            this.pnlMain.Size = new System.Drawing.Size(770, 730);
            this.pnlMain.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "XEM CHI TIẾT BÀI VIẾT";

            // lblTieuDeLabel
            this.lblTieuDeLabel.AutoSize = true;
            this.lblTieuDeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTieuDeLabel.Location = new System.Drawing.Point(27, 70);
            this.lblTieuDeLabel.Name = "lblTieuDeLabel";
            this.lblTieuDeLabel.Size = new System.Drawing.Size(57, 19);
            this.lblTieuDeLabel.TabIndex = 1;
            this.lblTieuDeLabel.Text = "Tiêu đề:";

            // lblTieuDe
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTieuDe.Location = new System.Drawing.Point(100, 70);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(50, 19);
            this.lblTieuDe.TabIndex = 2;
            this.lblTieuDe.Text = "(Tiêu đề)";
            this.lblTieuDe.MaximumSize = new System.Drawing.Size(630, 40);

            // lblPhongVienLabel
            this.lblPhongVienLabel.AutoSize = true;
            this.lblPhongVienLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhongVienLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPhongVienLabel.Location = new System.Drawing.Point(27, 100);
            this.lblPhongVienLabel.Name = "lblPhongVienLabel";
            this.lblPhongVienLabel.Size = new System.Drawing.Size(79, 19);
            this.lblPhongVienLabel.TabIndex = 3;
            this.lblPhongVienLabel.Text = "Phóng viên:";

            // lblPhongVien
            this.lblPhongVien.AutoSize = true;
            this.lblPhongVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblPhongVien.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPhongVien.Location = new System.Drawing.Point(120, 100);
            this.lblPhongVien.Name = "lblPhongVien";
            this.lblPhongVien.Size = new System.Drawing.Size(16, 19);
            this.lblPhongVien.TabIndex = 4;
            this.lblPhongVien.Text = "-";

            // lblTienNBLabel
            this.lblTienNBLabel.AutoSize = true;
            this.lblTienNBLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTienNBLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTienNBLabel.Location = new System.Drawing.Point(27, 130);
            this.lblTienNBLabel.Name = "lblTienNBLabel";
            this.lblTienNBLabel.Size = new System.Drawing.Size(104, 19);
            this.lblTienNBLabel.TabIndex = 5;
            this.lblTienNBLabel.Text = "Tiền nhuận bút:";

            // lblTienNB
            this.lblTienNB.AutoSize = true;
            this.lblTienNB.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblTienNB.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTienNB.Location = new System.Drawing.Point(145, 130);
            this.lblTienNB.Name = "lblTienNB";
            this.lblTienNB.Size = new System.Drawing.Size(16, 19);
            this.lblTienNB.TabIndex = 6;
            this.lblTienNB.Text = "-";

            // lblDiemAILabel
            this.lblDiemAILabel.AutoSize = true;
            this.lblDiemAILabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiemAILabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDiemAILabel.Location = new System.Drawing.Point(27, 160);
            this.lblDiemAILabel.Name = "lblDiemAILabel";
            this.lblDiemAILabel.Size = new System.Drawing.Size(63, 19);
            this.lblDiemAILabel.TabIndex = 7;
            this.lblDiemAILabel.Text = "Điểm AI:";

            // lblDiemAI
            this.lblDiemAI.AutoSize = true;
            this.lblDiemAI.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiemAI.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.lblDiemAI.Location = new System.Drawing.Point(100, 160);
            this.lblDiemAI.Name = "lblDiemAI";
            this.lblDiemAI.Size = new System.Drawing.Size(16, 19);
            this.lblDiemAI.TabIndex = 8;
            this.lblDiemAI.Text = "-";

            // lblLoaiCanhBaoLabel
            this.lblLoaiCanhBaoLabel.AutoSize = true;
            this.lblLoaiCanhBaoLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLoaiCanhBaoLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblLoaiCanhBaoLabel.Location = new System.Drawing.Point(27, 190);
            this.lblLoaiCanhBaoLabel.Name = "lblLoaiCanhBaoLabel";
            this.lblLoaiCanhBaoLabel.Size = new System.Drawing.Size(103, 19);
            this.lblLoaiCanhBaoLabel.TabIndex = 9;
            this.lblLoaiCanhBaoLabel.Text = "Cảnh báo phát hiện:";

            // lblLoaiCanhBao
            this.lblLoaiCanhBao.AutoSize = true;
            this.lblLoaiCanhBao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblLoaiCanhBao.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblLoaiCanhBao.Location = new System.Drawing.Point(145, 190);
            this.lblLoaiCanhBao.Name = "lblLoaiCanhBao";
            this.lblLoaiCanhBao.Size = new System.Drawing.Size(16, 19);
            this.lblLoaiCanhBao.TabIndex = 8;
            this.lblLoaiCanhBao.Text = "-";

            // lblNoiDungLabel
            this.lblNoiDungLabel.AutoSize = true;
            this.lblNoiDungLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNoiDungLabel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblNoiDungLabel.Location = new System.Drawing.Point(25, 220);
            this.lblNoiDungLabel.Name = "lblNoiDungLabel";
            this.lblNoiDungLabel.Size = new System.Drawing.Size(158, 21);
            this.lblNoiDungLabel.TabIndex = 10;
            this.lblNoiDungLabel.Text = "NỘI DUNG BÀI VIẾT";

            // txtNoiDung
            this.txtNoiDung.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoiDung.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtNoiDung.Location = new System.Drawing.Point(29, 248);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.Size = new System.Drawing.Size(710, 180);
            this.txtNoiDung.TabIndex = 10;
            this.txtNoiDung.Text = "";

            // lblDanhGiaAILabel
            this.lblDanhGiaAILabel.AutoSize = true;
            this.lblDanhGiaAILabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDanhGiaAILabel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDanhGiaAILabel.Location = new System.Drawing.Point(25, 440);
            this.lblDanhGiaAILabel.Name = "lblDanhGiaAILabel";
            this.lblDanhGiaAILabel.Size = new System.Drawing.Size(99, 21);
            this.lblDanhGiaAILabel.TabIndex = 12;
            this.lblDanhGiaAILabel.Text = "ĐÁNH GIÁ AI";

            // txtDanhGiaAI
            this.txtDanhGiaAI.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtDanhGiaAI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDanhGiaAI.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDanhGiaAI.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtDanhGiaAI.Location = new System.Drawing.Point(29, 468);
            this.txtDanhGiaAI.Name = "txtDanhGiaAI";
            this.txtDanhGiaAI.ReadOnly = true;
            this.txtDanhGiaAI.Size = new System.Drawing.Size(710, 100);
            this.txtDanhGiaAI.TabIndex = 12;
            this.txtDanhGiaAI.Text = "";

            // lblCanhBaoLabel
            this.lblCanhBaoLabel.AutoSize = true;
            this.lblCanhBaoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCanhBaoLabel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblCanhBaoLabel.Location = new System.Drawing.Point(25, 580);
            this.lblCanhBaoLabel.Name = "lblCanhBaoLabel";
            this.lblCanhBaoLabel.Size = new System.Drawing.Size(142, 21);
            this.lblCanhBaoLabel.TabIndex = 14;
            this.lblCanhBaoLabel.Text = "NỘI DUNG CẢNH BÁO";

            // txtNoiDungCanhBao
            this.txtNoiDungCanhBao.BackColor = System.Drawing.Color.FromArgb(254, 249, 195);
            this.txtNoiDungCanhBao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNoiDungCanhBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoiDungCanhBao.ForeColor = System.Drawing.Color.FromArgb(161, 98, 7);
            this.txtNoiDungCanhBao.Location = new System.Drawing.Point(29, 608);
            this.txtNoiDungCanhBao.Name = "txtNoiDungCanhBao";
            this.txtNoiDungCanhBao.ReadOnly = true;
            this.txtNoiDungCanhBao.Size = new System.Drawing.Size(710, 60);
            this.txtNoiDungCanhBao.TabIndex = 15;
            this.txtNoiDungCanhBao.Text = "";

            // btnDong
            this.btnDong.Animated = false;
            this.btnDong.BorderRadius = 8;
            this.btnDong.FillColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(325, 680);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 36);
            this.btnDong.TabIndex = 15;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblTieuDeLabel);
            this.pnlMain.Controls.Add(this.lblTieuDe);
            this.pnlMain.Controls.Add(this.lblPhongVienLabel);
            this.pnlMain.Controls.Add(this.lblPhongVien);
            this.pnlMain.Controls.Add(this.lblTienNBLabel);
            this.pnlMain.Controls.Add(this.lblTienNB);
            this.pnlMain.Controls.Add(this.lblDiemAILabel);
            this.pnlMain.Controls.Add(this.lblDiemAI);
            this.pnlMain.Controls.Add(this.lblLoaiCanhBaoLabel);
            this.pnlMain.Controls.Add(this.lblLoaiCanhBao);
            this.pnlMain.Controls.Add(this.lblNoiDungLabel);
            this.pnlMain.Controls.Add(this.txtNoiDung);
            this.pnlMain.Controls.Add(this.lblDanhGiaAILabel);
            this.pnlMain.Controls.Add(this.txtDanhGiaAI);
            this.pnlMain.Controls.Add(this.lblCanhBaoLabel);
            this.pnlMain.Controls.Add(this.txtNoiDungCanhBao);
            this.pnlMain.Controls.Add(this.btnDong);

            // FrmXemBaiViet
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(800, 760);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem chi tiết bài viết";
            this.Controls.Add(this.pnlMain);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
