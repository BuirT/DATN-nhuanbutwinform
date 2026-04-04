namespace HETHONGTINHNHUANBUT
{
    partial class FormRegister
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
            this.textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox3 = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.Label();
            this.txtpasswordagain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnregister = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.panelOverlay = new System.Windows.Forms.Panel();
            this.panelOverlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderRadius = 8;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DefaultText = "";
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox1.Location = new System.Drawing.Point(190, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Nhập tên đăng nhập";
            this.textBox1.SelectedText = "";
            this.textBox1.Size = new System.Drawing.Size(280, 40);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BorderRadius = 8;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.DefaultText = "";
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox2.Location = new System.Drawing.Point(190, 140);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.PlaceholderText = "Nhập mật khẩu";
            this.textBox2.SelectedText = "";
            this.textBox2.Size = new System.Drawing.Size(280, 40);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.BorderRadius = 8;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox3.DefaultText = "";
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox3.Location = new System.Drawing.Point(190, 200);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.PlaceholderText = "Nhập lại mật khẩu";
            this.textBox3.SelectedText = "";
            this.textBox3.Size = new System.Drawing.Size(280, 40);
            this.textBox3.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(30, 80);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(150, 40);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Tên đăng nhập:";
            this.txtUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(30, 140);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 40);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Mật khẩu:";
            this.txtPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtpasswordagain
            // 
            this.txtpasswordagain.BackColor = System.Drawing.Color.Transparent;
            this.txtpasswordagain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtpasswordagain.ForeColor = System.Drawing.Color.Black;
            this.txtpasswordagain.Location = new System.Drawing.Point(30, 200);
            this.txtpasswordagain.Name = "txtpasswordagain";
            this.txtpasswordagain.Size = new System.Drawing.Size(150, 40);
            this.txtpasswordagain.TabIndex = 3;
            this.txtpasswordagain.Text = "Nhập lại mật khẩu:";
            this.txtpasswordagain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(120)))));
            this.label1.Location = new System.Drawing.Point(39, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "HỆ THỐNG TÍNH NHUẬN BÚT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnregister
            // 
            this.btnregister.BorderRadius = 8;
            this.btnregister.FillColor = System.Drawing.Color.ForestGreen;
            this.btnregister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnregister.ForeColor = System.Drawing.Color.White;
            this.btnregister.Location = new System.Drawing.Point(270, 270);
            this.btnregister.Name = "btnregister";
            this.btnregister.Size = new System.Drawing.Size(140, 45);
            this.btnregister.TabIndex = 4;
            this.btnregister.Text = "Đăng ký";
            this.btnregister.Click += new System.EventHandler(this.btnregister_Click);
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 8;
            this.btnExit.FillColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(90, 270);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 45);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Hủy";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // panelOverlay
            // 
            this.panelOverlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelOverlay.Controls.Add(this.label1);
            this.panelOverlay.Controls.Add(this.txtUsername);
            this.panelOverlay.Controls.Add(this.txtPassword);
            this.panelOverlay.Controls.Add(this.txtpasswordagain);
            this.panelOverlay.Controls.Add(this.textBox1);
            this.panelOverlay.Controls.Add(this.textBox2);
            this.panelOverlay.Controls.Add(this.textBox3);
            this.panelOverlay.Controls.Add(this.btnregister);
            this.panelOverlay.Controls.Add(this.btnExit);
            this.panelOverlay.Location = new System.Drawing.Point(150, 70);
            this.panelOverlay.Name = "panelOverlay";
            this.panelOverlay.Size = new System.Drawing.Size(521, 360);
            this.panelOverlay.TabIndex = 0;
            // 
            // FormRegister
            // 
            this.BackgroundImage = global::HETHONGTINHNHUANBUT.Properties.Resources.bao_2_185727174524549;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panelOverlay);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelOverlay.ResumeLayout(false);
            this.panelOverlay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo các control - giữ nguyên tên cũ
        private Guna.UI2.WinForms.Guna2TextBox textBox1;
        private Guna.UI2.WinForms.Guna2TextBox textBox2;
        private Guna.UI2.WinForms.Guna2TextBox textBox3;
        private System.Windows.Forms.Label txtUsername;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.Label txtpasswordagain;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnregister;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.Panel panelOverlay;
    }
}