namespace HETHONGTINHNHUANBUT
{
    partial class FrmLoaiBao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMaso = new System.Windows.Forms.Label();
            this.txtMaso = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTenLoai = new System.Windows.Forms.Label();
            this.txtTenLoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.dgvLoaiBao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiBao)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblMaso);
            this.pnlTop.Controls.Add(this.txtMaso);
            this.pnlTop.Controls.Add(this.lblTenLoai);
            this.pnlTop.Controls.Add(this.txtTenLoai);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnXoa);
            this.pnlTop.Controls.Add(this.btnLamMoi);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.ShadowDecoration.Enabled = true;
            this.pnlTop.Size = new System.Drawing.Size(1145, 190);
            this.pnlTop.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(197, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ LOẠI BÁO";

            // 
            // lblMaso
            // 
            this.lblMaso.AutoSize = true;
            this.lblMaso.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMaso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMaso.Location = new System.Drawing.Point(25, 62);
            this.lblMaso.Name = "lblMaso";
            this.lblMaso.Size = new System.Drawing.Size(81, 17);
            this.lblMaso.TabIndex = 1;
            this.lblMaso.Text = "Mã loại báo";

            // 
            // txtMaso
            // 
            this.txtMaso.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtMaso.BorderRadius = 8;
            this.txtMaso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaso.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtMaso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaso.ForeColor = System.Drawing.Color.Black;
            this.txtMaso.Location = new System.Drawing.Point(25, 82);
            this.txtMaso.Name = "txtMaso";
            this.txtMaso.Size = new System.Drawing.Size(180, 36);
            this.txtMaso.TabIndex = 2;

            // 
            // lblTenLoai
            // 
            this.lblTenLoai.AutoSize = true;
            this.lblTenLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTenLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTenLoai.Location = new System.Drawing.Point(230, 62);
            this.lblTenLoai.Name = "lblTenLoai";
            this.lblTenLoai.Size = new System.Drawing.Size(84, 17);
            this.lblTenLoai.TabIndex = 3;
            this.lblTenLoai.Text = "Tên loại báo";

            // 
            // txtTenLoai
            // 
            this.txtTenLoai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtTenLoai.BorderRadius = 8;
            this.txtTenLoai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenLoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtTenLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenLoai.ForeColor = System.Drawing.Color.Black;
            this.txtTenLoai.Location = new System.Drawing.Point(230, 82);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(350, 36);
            this.txtTenLoai.TabIndex = 4;

            // 
            // btnThem
            // 
            this.btnThem.Animated = true;
            this.btnThem.BorderRadius = 8;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 135);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "LƯU DỮ LIỆU";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // 
            // btnSua
            // 
            this.btnSua.Animated = true;
            this.btnSua.BorderRadius = 8;
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(170, 135);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "CẬP NHẬT";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // 
            // btnXoa
            // 
            this.btnXoa.Animated = true;
            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnXoa.BorderRadius = 8;
            this.btnXoa.BorderThickness = 1;
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnXoa.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnXoa.Location = new System.Drawing.Point(315, 135);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(140, 40);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "XÓA LOẠI BÁO";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Animated = true;
            this.btnLamMoi.BorderRadius = 8;
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLamMoi.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Location = new System.Drawing.Point(470, 135);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 40);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "LÀM MỚI";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.BorderRadius = 16;
            this.pnlBottom.Controls.Add(this.lblDataTitle);
            this.pnlBottom.Controls.Add(this.dgvLoaiBao);
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(20, 225);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlBottom.ShadowDecoration.Depth = 8;
            this.pnlBottom.ShadowDecoration.Enabled = true;
            this.pnlBottom.Size = new System.Drawing.Size(1145, 480);
            this.pnlBottom.TabIndex = 1;

            // 
            // lblDataTitle
            // 
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDataTitle.Location = new System.Drawing.Point(25, 18);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(210, 25);
            this.lblDataTitle.TabIndex = 2;
            this.lblDataTitle.Text = "DANH SÁCH LOẠI BÁO";

            // dgvLoaiBao
            this.dgvLoaiBao.AllowUserToAddRows = false;
            this.dgvLoaiBao.AllowUserToDeleteRows = false;
            this.dgvLoaiBao.AllowUserToResizeColumns = false;
            this.dgvLoaiBao.AllowUserToResizeRows = false;
            this.dgvLoaiBao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoaiBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiBao.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.dgvLoaiBao.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoaiBao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoaiBao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLoaiBao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            // DÒNG XEN KẼ (Màu xám nhạt, khóa cứng Selection)
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvLoaiBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;

            // HEADER XÁM NHẠT (giống FrmTacGia)
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoaiBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLoaiBao.ColumnHeadersHeight = 40;

            // DÒNG BÌNH THƯỜNG (Trắng, chọn dòng xanh nhạt)
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoaiBao.DefaultCellStyle = dataGridViewCellStyle3;

            this.dgvLoaiBao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvLoaiBao.Location = new System.Drawing.Point(25, 60);
            this.dgvLoaiBao.Name = "dgvLoaiBao";
            this.dgvLoaiBao.ReadOnly = true;
            this.dgvLoaiBao.RowHeadersVisible = false;
            this.dgvLoaiBao.RowTemplate.Height = 38;
            this.dgvLoaiBao.Size = new System.Drawing.Size(1095, 395);
            this.dgvLoaiBao.TabIndex = 3;

            // Đồng bộ ThemeStyle của Guna
            this.dgvLoaiBao.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLoaiBao.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));

            this.dgvLoaiBao.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvLoaiBao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));

            this.dgvLoaiBao.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLoaiBao.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvLoaiBao.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.dgvLoaiBao.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));

            this.dgvLoaiBao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvLoaiBao.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvLoaiBao.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvLoaiBao.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));

            this.dgvLoaiBao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiBao_CellClick);
            
            // 
            // FrmLoaiBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1185, 725);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmLoaiBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Loại Báo";
            this.Load += new System.EventHandler(this.FrmLoaiBao_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiBao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaso;
        private Guna.UI2.WinForms.Guna2TextBox txtMaso;
        private System.Windows.Forms.Label lblTenLoai;
        private Guna.UI2.WinForms.Guna2TextBox txtTenLoai;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private System.Windows.Forms.Label lblDataTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLoaiBao;
    }
}