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

        private void InitializeComponent()
        {
            this.textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox3 = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaTacGia = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.Label();
            this.txtpasswordagain = new System.Windows.Forms.Label();
            this.lblMaXacThuc = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnregister = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.panelOverlay = new System.Windows.Forms.Panel();
            this.panelOverlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOverlay
            // 
            this.panelOverlay.BackColor = System.Drawing.Color.White;
            this.panelOverlay.Controls.Add(this.label1);
            this.panelOverlay.Controls.Add(this.txtUsername);
            this.panelOverlay.Controls.Add(this.textBox1);
            this.panelOverlay.Controls.Add(this.txtPassword);
            this.panelOverlay.Controls.Add(this.textBox2);
            this.panelOverlay.Controls.Add(this.txtpasswordagain);
            this.panelOverlay.Controls.Add(this.textBox3);
            this.panelOverlay.Controls.Add(this.lblRole);
            this.panelOverlay.Controls.Add(this.cboRole);
            this.panelOverlay.Controls.Add(this.lblMaXacThuc);
            this.panelOverlay.Controls.Add(this.txtMaTacGia);
            this.panelOverlay.Controls.Add(this.btnregister);
            this.panelOverlay.Controls.Add(this.btnExit);
            this.panelOverlay.Location = new System.Drawing.Point(140, 30);
            this.panelOverlay.Name = "panelOverlay";
            this.panelOverlay.Size = new System.Drawing.Size(520, 520);
            this.panelOverlay.TabIndex = 0;
            // 
            // label1 (TIÊU ĐỀ)
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(120)))));
            this.label1.Location = new System.Drawing.Point(0, 20);
            this.label1.Size = new System.Drawing.Size(520, 45);
            this.label1.Text = "ĐĂNG KÝ TÁC GIẢ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cấu hình các nhãn (Labels) - Đảm bảo ForeColor là Black để hiện rõ
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.Location = new System.Drawing.Point(20, 90);
            this.txtUsername.Size = new System.Drawing.Size(150, 35);
            this.txtUsername.Text = "Tên đăng nhập:";
            this.txtUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(20, 150);
            this.txtPassword.Size = new System.Drawing.Size(150, 35);
            this.txtPassword.Text = "Mật khẩu:";
            this.txtPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            this.txtpasswordagain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtpasswordagain.ForeColor = System.Drawing.Color.Black;
            this.txtpasswordagain.Location = new System.Drawing.Point(20, 210);
            this.txtpasswordagain.Size = new System.Drawing.Size(150, 35);
            this.txtpasswordagain.Text = "Nhập lại MK:";
            this.txtpasswordagain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRole.ForeColor = System.Drawing.Color.Black;
            this.lblRole.Location = new System.Drawing.Point(20, 270);
            this.lblRole.Size = new System.Drawing.Size(150, 35);
            this.lblRole.Text = "Loại tài khoản:";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            this.lblMaXacThuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaXacThuc.ForeColor = System.Drawing.Color.Black;
            this.lblMaXacThuc.Location = new System.Drawing.Point(20, 330);
            this.lblMaXacThuc.Size = new System.Drawing.Size(150, 35);
            this.lblMaXacThuc.Text = "Mã xác thực:";
            this.lblMaXacThuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Cấu hình các Ô nhập (Inputs)
            // 
            this.textBox1.Location = new System.Drawing.Point(185, 90);
            this.textBox1.Size = new System.Drawing.Size(280, 35);
            this.textBox1.PlaceholderText = "Username";
            // 
            this.textBox2.Location = new System.Drawing.Point(185, 150);
            this.textBox2.Size = new System.Drawing.Size(280, 35);
            this.textBox2.PasswordChar = '*';
            // 
            this.textBox3.Location = new System.Drawing.Point(185, 210);
            this.textBox3.Size = new System.Drawing.Size(280, 35);
            this.textBox3.PasswordChar = '*';
            // 
            this.cboRole.Location = new System.Drawing.Point(185, 270);
            this.cboRole.Size = new System.Drawing.Size(280, 36);
            // 
            this.txtMaTacGia.Location = new System.Drawing.Point(185, 330);
            this.txtMaTacGia.Size = new System.Drawing.Size(280, 35);
            this.txtMaTacGia.PlaceholderText = "Mã số / CCCD";
            // 
            // btnregister (NÚT ĐĂNG KÝ)
            // 
            this.btnregister.BorderRadius = 8;
            this.btnregister.FillColor = System.Drawing.Color.ForestGreen;
            this.btnregister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnregister.ForeColor = System.Drawing.Color.White;
            this.btnregister.Location = new System.Drawing.Point(270, 410);
            this.btnregister.Name = "btnregister";
            this.btnregister.Size = new System.Drawing.Size(140, 45);
            this.btnregister.Text = "ĐĂNG KÝ"; // <--- THÊM CHỮ VÀO NÚT
            this.btnregister.Click += new System.EventHandler(this.btnregister_Click);
            // 
            // btnExit (NÚT HỦY)
            // 
            this.btnExit.BorderRadius = 8;
            this.btnExit.FillColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(110, 410);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 45);
            this.btnExit.Text = "HỦY";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // FormRegister
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelOverlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormRegister_Load);
            this.panelOverlay.ResumeLayout(false);
            this.ResumeLayout(false);
        }



        private Guna.UI2.WinForms.Guna2TextBox textBox1, textBox2, textBox3, txtMaTacGia;
        private System.Windows.Forms.Label txtUsername, txtPassword, txtpasswordagain, lblMaXacThuc, lblRole, label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboRole;
        private Guna.UI2.WinForms.Guna2Button btnregister, btnExit;
        private System.Windows.Forms.Panel panelOverlay;
    }
}