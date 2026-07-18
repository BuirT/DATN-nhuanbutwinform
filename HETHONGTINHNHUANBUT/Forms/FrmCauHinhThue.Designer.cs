using System.Drawing;

namespace HETHONGTINHNHUANBUT
{
    partial class FrmCauHinhThue
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

        private void InitializeComponent()
        {
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMucChiuThue = new System.Windows.Forms.Label();
            this.txtMucChiuThue = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhanTramThue = new System.Windows.Forms.Label();
            this.txtPhanTramThue = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.btnLuu);
            this.pnlTop.Controls.Add(this.txtPhanTramThue);
            this.pnlTop.Controls.Add(this.lblPhanTramThue);
            this.pnlTop.Controls.Add(this.txtMucChiuThue);
            this.pnlTop.Controls.Add(this.lblMucChiuThue);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlTop.ShadowDecoration.Depth = 10;
            this.pnlTop.ShadowDecoration.Enabled = true;
            this.pnlTop.Size = new System.Drawing.Size(820, 200);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(232, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CẤU HÌNH THUẾ TNCN";
            // 
            // lblMucChiuThue
            // 
            this.lblMucChiuThue.AutoSize = true;
            this.lblMucChiuThue.BackColor = System.Drawing.Color.White;
            this.lblMucChiuThue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMucChiuThue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMucChiuThue.Location = new System.Drawing.Point(25, 62);
            this.lblMucChiuThue.Name = "lblMucChiuThue";
            this.lblMucChiuThue.Size = new System.Drawing.Size(138, 17);
            this.lblMucChiuThue.TabIndex = 1;
            this.lblMucChiuThue.Text = "Mức chịu thuế (VNĐ)";
            // 
            // txtMucChiuThue
            // 
            this.txtMucChiuThue.BorderRadius = 6;
            this.txtMucChiuThue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMucChiuThue.DefaultText = "";
            this.txtMucChiuThue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMucChiuThue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMucChiuThue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMucChiuThue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMucChiuThue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMucChiuThue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMucChiuThue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtMucChiuThue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMucChiuThue.Location = new System.Drawing.Point(25, 85);
            this.txtMucChiuThue.Name = "txtMucChiuThue";
            this.txtMucChiuThue.PasswordChar = '\0';
            this.txtMucChiuThue.PlaceholderText = "Ví dụ: 2000000";
            this.txtMucChiuThue.SelectedText = "";
            this.txtMucChiuThue.Size = new System.Drawing.Size(260, 36);
            this.txtMucChiuThue.TabIndex = 2;
            // 
            // lblPhanTramThue
            // 
            this.lblPhanTramThue.AutoSize = true;
            this.lblPhanTramThue.BackColor = System.Drawing.Color.White;
            this.lblPhanTramThue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPhanTramThue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPhanTramThue.Location = new System.Drawing.Point(310, 62);
            this.lblPhanTramThue.Name = "lblPhanTramThue";
            this.lblPhanTramThue.Size = new System.Drawing.Size(126, 17);
            this.lblPhanTramThue.TabIndex = 3;
            this.lblPhanTramThue.Text = "Phần trăm thuế (%)";
            // 
            // txtPhanTramThue
            // 
            this.txtPhanTramThue.BorderRadius = 6;
            this.txtPhanTramThue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhanTramThue.DefaultText = "";
            this.txtPhanTramThue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhanTramThue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhanTramThue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhanTramThue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhanTramThue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhanTramThue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPhanTramThue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtPhanTramThue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhanTramThue.Location = new System.Drawing.Point(310, 85);
            this.txtPhanTramThue.Name = "txtPhanTramThue";
            this.txtPhanTramThue.PasswordChar = '\0';
            this.txtPhanTramThue.PlaceholderText = "Ví dụ: 10";
            this.txtPhanTramThue.SelectedText = "";
            this.txtPhanTramThue.Size = new System.Drawing.Size(260, 36);
            this.txtPhanTramThue.TabIndex = 4;
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 8;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(25, 140);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 36);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "LƯU CẤU HÌNH";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FrmCauHinhThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(860, 600);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCauHinhThue";
            this.Text = "Cấu hình thuế";
            this.Load += new System.EventHandler(this.FrmCauHinhThue_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMucChiuThue;
        private Guna.UI2.WinForms.Guna2TextBox txtMucChiuThue;
        private System.Windows.Forms.Label lblPhanTramThue;
        private Guna.UI2.WinForms.Guna2TextBox txtPhanTramThue;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
    }
}
