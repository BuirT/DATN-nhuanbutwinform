namespace HETHONGTINHNHUANBUT
{
    partial class FrmKiemDinhAI
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
            this.panelOverlay = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rtbNoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnQuetAI = new Guna.UI2.WinForms.Guna2Button();
            this.lblDiem = new System.Windows.Forms.Label();
            this.lblDaoVan = new System.Windows.Forms.Label();
            this.lblNhanXet = new System.Windows.Forms.Label();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            this.panelOverlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOverlay (Khung nền bo góc bao phủ)
            // 
            this.panelOverlay.BackColor = System.Drawing.Color.Transparent;
            this.panelOverlay.BorderRadius = 16;
            this.panelOverlay.Controls.Add(this.lblTitle);
            this.panelOverlay.Controls.Add(this.rtbNoiDung);
            this.panelOverlay.Controls.Add(this.btnQuetAI);
            this.panelOverlay.Controls.Add(this.lblDiem);
            this.panelOverlay.Controls.Add(this.lblDaoVan);
            this.panelOverlay.Controls.Add(this.lblNhanXet);
            this.panelOverlay.Controls.Add(this.btnXacNhan);
            this.panelOverlay.Controls.Add(this.btnThoat);
            this.panelOverlay.FillColor = System.Drawing.Color.White;
            this.panelOverlay.Location = new System.Drawing.Point(20, 20);
            this.panelOverlay.Name = "panelOverlay";
            this.panelOverlay.Size = new System.Drawing.Size(740, 560);
            this.panelOverlay.TabIndex = 0;
            this.panelOverlay.ShadowDecoration.Enabled = true;
            this.panelOverlay.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.panelOverlay.ShadowDecoration.Depth = 15;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(680, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TRẠM KIỂM ĐỊNH CHẤT LƯỢNG AI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbNoiDung (Khung dán nội dung bài báo)
            // 
            this.rtbNoiDung.Animated = true;
            this.rtbNoiDung.BorderRadius = 8;
            this.rtbNoiDung.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.rtbNoiDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbNoiDung.DefaultText = "";
            this.rtbNoiDung.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.rtbNoiDung.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.rtbNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.rtbNoiDung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.rtbNoiDung.Location = new System.Drawing.Point(30, 75);
            this.rtbNoiDung.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbNoiDung.Multiline = true;
            this.rtbNoiDung.Name = "rtbNoiDung";
            this.rtbNoiDung.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.rtbNoiDung.PlaceholderText = "Đồng chí dán (Paste) nội dung bài báo cần kiểm duyệt vào đây...";
            this.rtbNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rtbNoiDung.SelectedText = "";
            this.rtbNoiDung.Size = new System.Drawing.Size(680, 220);
            this.rtbNoiDung.TabIndex = 1;
            // 
            // btnQuetAI
            // 
            this.btnQuetAI.Animated = true;
            this.btnQuetAI.BorderRadius = 8;
            this.btnQuetAI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuetAI.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242))))); // Xanh lam
            this.btnQuetAI.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnQuetAI.ForeColor = System.Drawing.Color.White;
            this.btnQuetAI.Location = new System.Drawing.Point(30, 310);
            this.btnQuetAI.Name = "btnQuetAI";
            this.btnQuetAI.Size = new System.Drawing.Size(680, 45);
            this.btnQuetAI.TabIndex = 2;
            this.btnQuetAI.Text = "🚀 TIẾN HÀNH QUÉT & ĐÁNH GIÁ";
            this.btnQuetAI.Click += new System.EventHandler(this.btnQuetAI_Click);
            // 
            // lblDiem
            // 
            this.lblDiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129))))); // Xanh lá cây ngọc
            this.lblDiem.Location = new System.Drawing.Point(30, 375);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(300, 25);
            this.lblDiem.TabIndex = 3;
            this.lblDiem.Text = "Điểm chất lượng: Chưa quét";
            // 
            // lblDaoVan
            // 
            this.lblDaoVan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDaoVan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68))))); // Đỏ cảnh báo
            this.lblDaoVan.Location = new System.Drawing.Point(340, 375);
            this.lblDaoVan.Name = "lblDaoVan";
            this.lblDaoVan.Size = new System.Drawing.Size(370, 25);
            this.lblDaoVan.TabIndex = 4;
            this.lblDaoVan.Text = "Cảnh báo đạo văn: Chưa quét";
            // 
            // lblNhanXet
            // 
            this.lblNhanXet.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Italic);
            this.lblNhanXet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNhanXet.Location = new System.Drawing.Point(30, 410);
            this.lblNhanXet.Name = "lblNhanXet";
            this.lblNhanXet.Size = new System.Drawing.Size(680, 60);
            this.lblNhanXet.TabIndex = 5;
            this.lblNhanXet.Text = "Tổng biên tập (AI) nhận xét: Vui lòng dán bài báo và bấm nút quét để hệ thống đánh giá.";
            // 
            // btnThoat (Nút hủy bỏ)
            // 
            this.btnThoat.Animated = true;
            this.btnThoat.BorderRadius = 8;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240))))); // Xám nhạt
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnThoat.Location = new System.Drawing.Point(280, 490);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(200, 45);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "HỦY BỎ";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXacNhan (Nút Lưu điểm)
            // 
            this.btnXacNhan.Animated = true;
            this.btnXacNhan.BorderRadius = 8;
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.Enabled = false; // Mặc định khóa
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129))))); // Xanh lá cây
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(510, 490);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(200, 45);
            this.btnXacNhan.TabIndex = 7;
            this.btnXacNhan.Text = "LƯU ĐIỂM SỐ";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // FrmKiemDinhAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(780, 600);
            this.Controls.Add(this.panelOverlay);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmKiemDinhAI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; // Nằm giữa form gọi nó
            this.Text = "Trạm Kiểm Định AI";
            this.panelOverlay.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelOverlay;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox rtbNoiDung;
        private Guna.UI2.WinForms.Guna2Button btnQuetAI;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Label lblDaoVan;
        private System.Windows.Forms.Label lblNhanXet;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
    }
}