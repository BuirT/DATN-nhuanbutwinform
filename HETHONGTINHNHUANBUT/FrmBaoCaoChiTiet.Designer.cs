namespace HETHONGTINHNHUANBUT
{
    partial class FrmBaoCaoChiTiet
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
            this.grpBoLoc = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTacGia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpThang = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnXemBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnXuatExcel = new Guna.UI2.WinForms.Guna2Button();
            this.dgvChiTiet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.grpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoLoc.BorderRadius = 8;
            this.grpBoLoc.Controls.Add(this.label2);
            this.grpBoLoc.Controls.Add(this.cboTacGia);
            this.grpBoLoc.Controls.Add(this.label1);
            this.grpBoLoc.Controls.Add(this.dtpThang);
            this.grpBoLoc.Controls.Add(this.btnXuatExcel);
            this.grpBoLoc.Controls.Add(this.btnXemBaoCao);
            this.grpBoLoc.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBoLoc.ForeColor = System.Drawing.Color.White;
            this.grpBoLoc.Location = new System.Drawing.Point(30, 20);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new System.Drawing.Size(920, 120);
            this.grpBoLoc.TabIndex = 0;
            this.grpBoLoc.Text = "TRA CỨU CHI TIẾT BÀI VIẾT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng:";
            // 
            // dtpThang
            // 
            this.dtpThang.BorderRadius = 5;
            this.dtpThang.Checked = true;
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.FillColor = System.Drawing.Color.White;
            this.dtpThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpThang.ForeColor = System.Drawing.Color.Black;
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThang.Location = new System.Drawing.Point(95, 60);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(150, 36);
            this.dtpThang.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(260, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tác giả:";
            // 
            // cboTacGia
            // 
            this.cboTacGia.BackColor = System.Drawing.Color.Transparent;
            this.cboTacGia.BorderRadius = 5;
            this.cboTacGia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTacGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTacGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTacGia.ForeColor = System.Drawing.Color.Black;
            this.cboTacGia.ItemHeight = 30;
            this.cboTacGia.Location = new System.Drawing.Point(340, 60);
            this.cboTacGia.Name = "cboTacGia";
            this.cboTacGia.Size = new System.Drawing.Size(250, 36);
            this.cboTacGia.TabIndex = 3;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BorderRadius = 5;
            this.btnXemBaoCao.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(610, 56);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(130, 45);
            this.btnXemBaoCao.TabIndex = 4;
            this.btnXemBaoCao.Text = "TÌM KIẾM";
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BorderRadius = 5;
            this.btnXuatExcel.FillColor = System.Drawing.Color.DarkOrange;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(750, 56);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(140, 45);
            this.btnXuatExcel.TabIndex = 5;
            this.btnXuatExcel.Text = "XUẤT EXCEL";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // dgvChiTiet
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTiet.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.Location = new System.Drawing.Point(30, 160);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowTemplate.Height = 35;
            this.dgvChiTiet.Size = new System.Drawing.Size(920, 460);
            this.dgvChiTiet.TabIndex = 1;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            // 
            // FrmBaoCaoChiTiet
            // 
            this.ClientSize = new System.Drawing.Size(980, 660);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.grpBoLoc);
            this.Name = "FrmBaoCaoChiTiet";
            this.Text = "Báo Cáo Chi Tiết";
            this.Load += new System.EventHandler(this.FrmBaoCaoChiTiet_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox grpBoLoc;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpThang;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cboTacGia;
        private Guna.UI2.WinForms.Guna2Button btnXemBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnXuatExcel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTiet;
    }
}