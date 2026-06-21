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
            this.panelOverlay = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlChat = new Guna.UI2.WinForms.Guna2Panel();
            this.flpChat = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlInput = new Guna.UI2.WinForms.Guna2Panel();
            this.txtInput = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGui = new Guna.UI2.WinForms.Guna2Button();
            this.panelOverlay.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlChat.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOverlay
            // 
            this.panelOverlay.BackColor = System.Drawing.Color.Transparent;
            this.panelOverlay.BorderRadius = 16;
            this.panelOverlay.Controls.Add(this.pnlHeader);
            this.panelOverlay.Controls.Add(this.pnlChat);
            this.panelOverlay.Controls.Add(this.pnlInput);
            this.panelOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOverlay.FillColor = System.Drawing.Color.White;
            this.panelOverlay.Location = new System.Drawing.Point(20, 20);
            this.panelOverlay.Margin = new System.Windows.Forms.Padding(0);
            this.panelOverlay.Name = "panelOverlay";
            this.panelOverlay.Padding = new System.Windows.Forms.Padding(20);
            this.panelOverlay.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.panelOverlay.ShadowDecoration.Depth = 12;
            this.panelOverlay.ShadowDecoration.Enabled = false;
            this.panelOverlay.Size = new System.Drawing.Size(1485, 652);
            this.panelOverlay.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Location = new System.Drawing.Point(20, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1445, 70);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(313, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🤖  TRỢ LÝ AI - NEWSPAY";
            // 
            // btnRefresh
            // 
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Animated = false;
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1155, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 42);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "🔄 LÀM MỚI";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlChat
            // 
            this.pnlChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChat.BackColor = System.Drawing.Color.Transparent;
            this.pnlChat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlChat.BorderRadius = 12;
            this.pnlChat.BorderThickness = 1;
            this.pnlChat.Controls.Add(this.flpChat);
            this.pnlChat.FillColor = System.Drawing.Color.White;
            this.pnlChat.Location = new System.Drawing.Point(20, 90);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(1445, 442);
            this.pnlChat.TabIndex = 2;
            // 
            // flpChat
            // 
            this.flpChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpChat.AutoScroll = true;
            this.flpChat.BackColor = System.Drawing.Color.White;
            this.flpChat.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpChat.Location = new System.Drawing.Point(12, 12);
            this.flpChat.Name = "flpChat";
            this.flpChat.Size = new System.Drawing.Size(1421, 418);
            this.flpChat.TabIndex = 0;
            this.flpChat.WrapContents = false;
            // 
            // pnlInput
            // 
            this.pnlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInput.BackColor = System.Drawing.Color.Transparent;
            this.pnlInput.Controls.Add(this.txtInput);
            this.pnlInput.Controls.Add(this.btnGui);
            this.pnlInput.FillColor = System.Drawing.Color.Transparent;
            this.pnlInput.Location = new System.Drawing.Point(20, 547);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(1445, 55);
            this.pnlInput.TabIndex = 3;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtInput.BorderRadius = 8;
            this.txtInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInput.DefaultText = "";
            this.txtInput.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.txtInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtInput.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.txtInput.Location = new System.Drawing.Point(0, 5);
            this.txtInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInput.Name = "txtInput";
            this.txtInput.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtInput.PlaceholderText = "💬 Nhập câu hỏi về luật thuế, nghiệp vụ hoặc chính sách...";
            this.txtInput.SelectedText = "";
            this.txtInput.Size = new System.Drawing.Size(1315, 45);
            this.txtInput.TabIndex = 4;
            // 
            // btnGui
            // 
            this.btnGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGui.Animated = false;
            this.btnGui.BorderRadius = 8;
            this.btnGui.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGui.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnGui.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGui.ForeColor = System.Drawing.Color.White;
            this.btnGui.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(56)))), ((int)(((byte)(202)))));
            this.btnGui.Location = new System.Drawing.Point(1325, 5);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(120, 45);
            this.btnGui.TabIndex = 5;
            this.btnGui.Text = "GỬI ➤";
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // FrmTroLyAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1525, 692);
            this.Controls.Add(this.panelOverlay);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTroLyAI";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Trợ lý AI";
            this.panelOverlay.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlChat.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.DoubleBuffered = true;
            this.ResumeLayout(false);

        }
        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelOverlay;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlChat;
        private System.Windows.Forms.FlowLayoutPanel flpChat;
        private Guna.UI2.WinForms.Guna2Panel pnlInput;
        private Guna.UI2.WinForms.Guna2TextBox txtInput;
        private Guna.UI2.WinForms.Guna2Button btnGui;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
    }
}