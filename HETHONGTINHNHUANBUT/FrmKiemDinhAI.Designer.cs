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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.panelOverlay = new Guna.UI2.WinForms.Guna2Panel();
            this.rtbNoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnQuetAI = new Guna.UI2.WinForms.Guna2GradientButton();
            this.pnlResult = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNhanXet = new System.Windows.Forms.Label();
            this.lblDaoVan = new System.Windows.Forms.Label();
            this.lblDiem = new System.Windows.Forms.Label();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            this.panelOverlay.SuspendLayout();
            this.pnlResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🧠  TRẠM KIỂM ĐỊNH CHẤT LƯỢNG AI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubTitle.Location = new System.Drawing.Point(0, 52);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(760, 22);
            this.lblSubTitle.TabIndex = 9;
            this.lblSubTitle.Text = "Dán nội dung bài viết vào ô bên dưới, hệ thống sẽ tự động đánh giá chất lượng và " +
    "phát hiện đạo văn.";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelOverlay
            // 
            this.panelOverlay.BackColor = System.Drawing.Color.Transparent;
            this.panelOverlay.BorderRadius = 20;
            this.panelOverlay.Controls.Add(this.lblTitle);
            this.panelOverlay.Controls.Add(this.lblSubTitle);
            this.panelOverlay.Controls.Add(this.rtbNoiDung);
            this.panelOverlay.Controls.Add(this.btnQuetAI);
            this.panelOverlay.Controls.Add(this.pnlResult);
            this.panelOverlay.Controls.Add(this.btnXacNhan);
            this.panelOverlay.Controls.Add(this.btnThoat);
            this.panelOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOverlay.FillColor = System.Drawing.Color.White;
            this.panelOverlay.Location = new System.Drawing.Point(20, 20);
            this.panelOverlay.Margin = new System.Windows.Forms.Padding(0);
            this.panelOverlay.Name = "panelOverlay";
            this.panelOverlay.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panelOverlay.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.panelOverlay.ShadowDecoration.Depth = 12;
            this.panelOverlay.ShadowDecoration.Enabled = true;
            this.panelOverlay.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 4, 6);
            this.panelOverlay.Size = new System.Drawing.Size(762, 607);
            this.panelOverlay.TabIndex = 0;
            // 
            // rtbNoiDung
            // 
            this.rtbNoiDung.Animated = true;
            this.rtbNoiDung.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.rtbNoiDung.BorderRadius = 12;
            this.rtbNoiDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbNoiDung.DefaultText = "";
            this.rtbNoiDung.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.rtbNoiDung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.rtbNoiDung.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtbNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.rtbNoiDung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.rtbNoiDung.Location = new System.Drawing.Point(0, 82);
            this.rtbNoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.rtbNoiDung.Multiline = true;
            this.rtbNoiDung.Name = "rtbNoiDung";
            this.rtbNoiDung.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.rtbNoiDung.PlaceholderText = "📝 Dán (Paste) nội dung bài báo cần kiểm duyệt vào đây...";
            this.rtbNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rtbNoiDung.SelectedText = "";
            this.rtbNoiDung.Size = new System.Drawing.Size(740, 190);
            this.rtbNoiDung.TabIndex = 1;
            // 
            // btnQuetAI
            // 
            this.btnQuetAI.Animated = true;
            this.btnQuetAI.BorderRadius = 12;
            this.btnQuetAI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuetAI.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnQuetAI.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.btnQuetAI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuetAI.ForeColor = System.Drawing.Color.White;
            this.btnQuetAI.Location = new System.Drawing.Point(0, 288);
            this.btnQuetAI.Name = "btnQuetAI";
            this.btnQuetAI.Size = new System.Drawing.Size(740, 52);
            this.btnQuetAI.TabIndex = 2;
            this.btnQuetAI.Text = "🚀  TIẾN HÀNH QUÉT TỰ ĐỘNG BẰNG AI";
            this.btnQuetAI.Click += new System.EventHandler(this.btnQuetAI_Click);
            // 
            // pnlResult
            // 
            this.pnlResult.BackColor = System.Drawing.Color.Transparent;
            this.pnlResult.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlResult.BorderRadius = 16;
            this.pnlResult.BorderThickness = 1;
            this.pnlResult.Controls.Add(this.lblNhanXet);
            this.pnlResult.Controls.Add(this.lblDaoVan);
            this.pnlResult.Controls.Add(this.lblDiem);
            this.pnlResult.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlResult.Location = new System.Drawing.Point(0, 356);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(740, 135);
            this.pnlResult.TabIndex = 8;
            // 
            // lblNhanXet
            // 
            this.lblNhanXet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            this.lblNhanXet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNhanXet.Location = new System.Drawing.Point(15, 58);
            this.lblNhanXet.Name = "lblNhanXet";
            this.lblNhanXet.Size = new System.Drawing.Size(710, 65);
            this.lblNhanXet.TabIndex = 5;
            this.lblNhanXet.Text = "💬 Nhận xét từ AI: Vui lòng dán bài báo và bấm nút quét để hệ thống đánh giá chi " +
    "tiết.";
            // 
            // lblDaoVan
            // 
            this.lblDaoVan.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblDaoVan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblDaoVan.Location = new System.Drawing.Point(380, 14);
            this.lblDaoVan.Name = "lblDaoVan";
            this.lblDaoVan.Size = new System.Drawing.Size(345, 35);
            this.lblDaoVan.TabIndex = 4;
            this.lblDaoVan.Text = "⚠️ Cảnh báo đạo văn: Chưa quét";
            this.lblDaoVan.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDiem
            // 
            this.lblDiem.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblDiem.Location = new System.Drawing.Point(15, 14);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(350, 35);
            this.lblDiem.TabIndex = 3;
            this.lblDiem.Text = "🏆 Điểm chất lượng: Chưa quét";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Animated = true;
            this.btnXacNhan.BorderRadius = 12;
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.Enabled = false;
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnXacNhan.Location = new System.Drawing.Point(500, 508);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(220, 48);
            this.btnXacNhan.TabIndex = 7;
            this.btnXacNhan.Text = "✅  LƯU ĐIỂM SỐ";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Animated = true;
            this.btnThoat.BorderRadius = 12;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnThoat.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnThoat.Location = new System.Drawing.Point(20, 508);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(150, 48);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "✖  HỦY BỎ";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmKiemDinhAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(802, 647);
            this.Controls.Add(this.panelOverlay);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmKiemDinhAI";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trạm Kiểm Định AI";
            this.panelOverlay.ResumeLayout(false);
            this.pnlResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelOverlay;
        private Guna.UI2.WinForms.Guna2TextBox rtbNoiDung;
        private Guna.UI2.WinForms.Guna2GradientButton btnQuetAI;
        private Guna.UI2.WinForms.Guna2Panel pnlResult;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Label lblDaoVan;
        private System.Windows.Forms.Label lblNhanXet;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
    }
}