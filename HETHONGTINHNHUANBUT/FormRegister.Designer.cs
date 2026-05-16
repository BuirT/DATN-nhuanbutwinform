using System.Drawing;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    partial class FormRegister
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSeparator = new Guna.UI2.WinForms.Guna2Panel();
            this.textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox3 = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtMaTacGia = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnregister = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();

            // Giữ nguyên khai báo biến nhãn cũ ẩn để bảo toàn liên kết hệ thống
            this.txtUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.Label();
            this.txtpasswordagain = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblMaXacThuc = new System.Windows.Forms.Label();

            this.panelOverlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOverlay (Khung kính Đăng ký trắng mờ đồng bộ hoàn hảo)
            // 
            this.panelOverlay.BackColor = System.Drawing.Color.Transparent;
            this.panelOverlay.BorderRadius = 20;
            this.panelOverlay.BorderThickness = 1;
            this.panelOverlay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panelOverlay.Controls.Add(this.label1);
            this.panelOverlay.Controls.Add(this.pnlSeparator);
            this.panelOverlay.Controls.Add(this.textBox1);
            this.panelOverlay.Controls.Add(this.textBox2);
            this.panelOverlay.Controls.Add(this.textBox3);
            this.panelOverlay.Controls.Add(this.cboRole);
            this.panelOverlay.Controls.Add(this.txtMaTacGia);
            this.panelOverlay.Controls.Add(this.btnregister);
            this.panelOverlay.Controls.Add(this.btnExit);
            this.panelOverlay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))); // Trắng mờ 94% dịu sáng
            this.panelOverlay.Location = new System.Drawing.Point(180, 25);
            this.panelOverlay.Name = "panelOverlay";
            this.panelOverlay.Size = new System.Drawing.Size(440, 510);
            this.panelOverlay.TabIndex = 0;
            this.panelOverlay.ShadowDecoration.Enabled = true;
            this.panelOverlay.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.panelOverlay.ShadowDecoration.Depth = 25;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG KÝ TÀI KHOẢN TÁC GIẢ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.Transparent;
            this.pnlSeparator.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlSeparator.Location = new System.Drawing.Point(140, 68);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(160, 2);
            this.pnlSeparator.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Animated = true;
            this.textBox1.BorderRadius = 10;
            this.textBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DefaultText = "";
            this.textBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.textBox1.FocusedState.FillColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(40, 95);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.textBox1.PlaceholderText = "Tạo tên đăng nhập mới / Username";
            this.textBox1.SelectedText = "";
            this.textBox1.Size = new System.Drawing.Size(360, 42);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // textBox2
            // 
            this.textBox2.Animated = true;
            this.textBox2.BorderRadius = 10;
            this.textBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.DefaultText = "";
            this.textBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.textBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.textBox2.FocusedState.FillColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(40, 152);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '●';
            this.textBox2.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.textBox2.PlaceholderText = "Thiết lập mật khẩu / Password";
            this.textBox2.SelectedText = "";
            this.textBox2.Size = new System.Drawing.Size(360, 42);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // textBox3
            // 
            this.textBox3.Animated = true;
            this.textBox3.BorderRadius = 10;
            this.textBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.textBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox3.DefaultText = "";
            this.textBox3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.textBox3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.textBox3.FocusedState.FillColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(40, 209);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '●';
            this.textBox3.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.textBox3.PlaceholderText = "Xác nhận lại mật khẩu / Confirm";
            this.textBox3.SelectedText = "";
            this.textBox3.Size = new System.Drawing.Size(360, 42);
            this.textBox3.TabIndex = 3;
            this.textBox3.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // cboRole
            // 
            this.cboRole.BackColor = System.Drawing.Color.Transparent;
            this.cboRole.BorderRadius = 10;
            this.cboRole.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cboRole.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.cboRole.ItemHeight = 30;
            this.cboRole.Location = new System.Drawing.Point(40, 266);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(360, 36);
            this.cboRole.TabIndex = 4;
            this.cboRole.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // txtMaTacGia
            // 
            this.txtMaTacGia.Animated = true;
            this.txtMaTacGia.BorderRadius = 10;
            this.txtMaTacGia.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtMaTacGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaTacGia.DefaultText = "";
            this.txtMaTacGia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtMaTacGia.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtMaTacGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtMaTacGia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtMaTacGia.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtMaTacGia.Location = new System.Drawing.Point(40, 323);
            this.txtMaTacGia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaTacGia.Name = "txtMaTacGia";
            this.txtMaTacGia.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtMaTacGia.PlaceholderText = "Mã xác thực hồ sơ / Mã số / CCCD";
            this.txtMaTacGia.SelectedText = "";
            this.txtMaTacGia.Size = new System.Drawing.Size(360, 42);
            this.txtMaTacGia.TabIndex = 5;
            this.txtMaTacGia.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // btnregister
            // 
            this.btnregister.Animated = true;
            this.btnregister.BorderRadius = 22;
            this.btnregister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnregister.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnregister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnregister.ForeColor = System.Drawing.Color.White;
            this.btnregister.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnregister.Location = new System.Drawing.Point(40, 395);
            this.btnregister.Name = "btnregister";
            this.btnregister.Size = new System.Drawing.Size(360, 45);
            this.btnregister.TabIndex = 6;
            this.btnregister.Text = "HOÀN TẤT ĐĂNG KÝ";
            this.btnregister.Click += new System.EventHandler(this.btnregister_Click);
            // 
            // btnExit
            // 
            this.btnExit.Animated = true;
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Underline);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnExit.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnExit.Location = new System.Drawing.Point(40, 455);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(360, 30);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Quay lại màn hình đăng nhập";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.BackgroundImage = global::HETHONGTINHNHUANBUT.Properties.Resources.bao_2_185727174524549;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.panelOverlay);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormRegister_Load);
            this.panelOverlay.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel pnlSeparator;
        private Guna.UI2.WinForms.Guna2TextBox textBox1;
        private Guna.UI2.WinForms.Guna2TextBox textBox2;
        private Guna.UI2.WinForms.Guna2TextBox textBox3;
        private Guna.UI2.WinForms.Guna2ComboBox cboRole;
        private Guna.UI2.WinForms.Guna2TextBox txtMaTacGia;
        private Guna.UI2.WinForms.Guna2Button btnregister;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Panel panelOverlay;

        private System.Windows.Forms.Label txtUsername;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.Label txtpasswordagain;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblMaXacThuc;
    }
}