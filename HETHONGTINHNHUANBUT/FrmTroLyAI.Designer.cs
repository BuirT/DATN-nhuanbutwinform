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
            this.picRobot = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlChat = new Guna.UI2.WinForms.Guna2Panel();
            this.flpChat = new System.Windows.Forms.FlowLayoutPanel();
            this.txtInput = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGui = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRobot)).BeginInit();
            this.pnlChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.picRobot);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1067, 86);
            this.pnlHeader.TabIndex = 0;
            // 
            // picRobot
            // 
            this.picRobot.BackColor = System.Drawing.Color.Transparent;
            this.picRobot.FillColor = System.Drawing.Color.Transparent;
            this.picRobot.ImageRotate = 0F;
            this.picRobot.Location = new System.Drawing.Point(27, 12);
            this.picRobot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picRobot.Name = "picRobot";
            this.picRobot.Size = new System.Drawing.Size(67, 62);
            this.picRobot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRobot.TabIndex = 1;
            this.picRobot.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(107, 25);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(321, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TRỢ LÝ AI - PHÒNG KẾ TOÁN ";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // pnlChat
            // 
            this.pnlChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChat.BackColor = System.Drawing.Color.Transparent;
            this.pnlChat.BorderRadius = 15;
            this.pnlChat.Controls.Add(this.flpChat);
            this.pnlChat.FillColor = System.Drawing.Color.White;
            this.pnlChat.Location = new System.Drawing.Point(27, 111);
            this.pnlChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.ShadowDecoration.BorderRadius = 15;
            this.pnlChat.ShadowDecoration.Color = System.Drawing.Color.Silver;
            this.pnlChat.ShadowDecoration.Enabled = true;
            this.pnlChat.Size = new System.Drawing.Size(1013, 468);
            this.pnlChat.TabIndex = 1;
            // 
            // flpChat
            // 
            this.flpChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpChat.AutoScroll = true;
            this.flpChat.BackColor = System.Drawing.Color.White;
            this.flpChat.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpChat.Location = new System.Drawing.Point(20, 18);
            this.flpChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpChat.Name = "flpChat";
            this.flpChat.Size = new System.Drawing.Size(973, 431);
            this.flpChat.TabIndex = 0;
            this.flpChat.WrapContents = false;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.BorderRadius = 20;
            this.txtInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInput.DefaultText = "";
            this.txtInput.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.txtInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtInput.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.txtInput.Location = new System.Drawing.Point(27, 603);
            this.txtInput.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtInput.Name = "txtInput";
            this.txtInput.PlaceholderText = "Nhập câu hỏi tại đây...";
            this.txtInput.SelectedText = "";
            this.txtInput.Size = new System.Drawing.Size(840, 55);
            this.txtInput.TabIndex = 2;
            // 
            // btnGui
            // 
            this.btnGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGui.BorderRadius = 20;
            this.btnGui.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.btnGui.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGui.ForeColor = System.Drawing.Color.White;
            this.btnGui.Location = new System.Drawing.Point(880, 603);
            this.btnGui.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(160, 55);
            this.btnGui.TabIndex = 3;
            this.btnGui.Text = "GỬI";
            // 
            // FrmTroLyAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1067, 689);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmTroLyAI";
            this.Text = "Trợ lý AI - Bản thiết kế lột xác";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRobot)).EndInit();
            this.pnlChat.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2PictureBox picRobot;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlChat;

        // 🌟 Chốt hạ: Đã đổi RichTextBox thành FlowLayoutPanel ở đây:
        private System.Windows.Forms.FlowLayoutPanel flpChat;

        private Guna.UI2.WinForms.Guna2TextBox txtInput;
        private Guna.UI2.WinForms.Guna2Button btnGui;
    }
}