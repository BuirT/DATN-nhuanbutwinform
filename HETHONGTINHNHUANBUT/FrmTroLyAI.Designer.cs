namespace HETHONGTINHNHUANBUT
{
    partial class FrmTroLyAI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlChat = new Guna.UI2.WinForms.Guna2Panel();
            this.flpChat = new System.Windows.Forms.FlowLayoutPanel();
            this.txtInput = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGui = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.pnlChat.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader (Đổi sang màu Indigo đậm)
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 70);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(321, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🤖 TRỢ LÝ AI - NEWSPAY";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);

            // pnlChat (Khung chat bóng bẩy)
            this.pnlChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChat.BackColor = System.Drawing.Color.Transparent;
            this.pnlChat.BorderRadius = 12;
            this.pnlChat.Controls.Add(this.flpChat);
            this.pnlChat.FillColor = System.Drawing.Color.White;
            this.pnlChat.Location = new System.Drawing.Point(20, 90);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.ShadowDecoration.BorderRadius = 12;
            this.pnlChat.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlChat.ShadowDecoration.Depth = 10;
            this.pnlChat.ShadowDecoration.Enabled = true;
            this.pnlChat.Size = new System.Drawing.Size(760, 380);
            this.pnlChat.TabIndex = 1;

            // flpChat (Vùng hiển thị bong bóng chat)
            this.flpChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpChat.AutoScroll = true;
            this.flpChat.BackColor = System.Drawing.Color.White;
            this.flpChat.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpChat.Location = new System.Drawing.Point(10, 10);
            this.flpChat.Name = "flpChat";
            this.flpChat.Size = new System.Drawing.Size(740, 360);
            this.flpChat.TabIndex = 0;
            this.flpChat.WrapContents = false;

            // txtInput (Khung gõ tinh tế)
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.BorderRadius = 8;
            this.txtInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInput.DefaultText = "";
            this.txtInput.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.txtInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtInput.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.txtInput.Location = new System.Drawing.Point(20, 490);
            this.txtInput.Margin = new System.Windows.Forms.Padding(4);
            this.txtInput.Name = "txtInput";
            this.txtInput.PlaceholderText = "Đồng chí cần hỏi gì về luật thuế hay nghiệp vụ...";
            this.txtInput.Size = new System.Drawing.Size(630, 45);
            this.txtInput.TabIndex = 2;

            // btnGui (Nút gửi đồng bộ màu)
            this.btnGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGui.BorderRadius = 8;
            this.btnGui.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGui.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnGui.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGui.ForeColor = System.Drawing.Color.White;
            this.btnGui.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(56)))), ((int)(((byte)(202)))));
            this.btnGui.Location = new System.Drawing.Point(660, 490);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(120, 45);
            this.btnGui.TabIndex = 3;
            this.btnGui.Text = "GỬI";
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);

            // FrmTroLyAI
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTroLyAI";
            this.Text = "Trợ lý AI";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlChat.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlChat;
        private System.Windows.Forms.FlowLayoutPanel flpChat;
        private Guna.UI2.WinForms.Guna2TextBox txtInput;
        private Guna.UI2.WinForms.Guna2Button btnGui;
    }
}