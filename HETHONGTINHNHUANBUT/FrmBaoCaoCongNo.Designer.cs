namespace HETHONGTINHNHUANBUT
{
    partial class FrmBaoCaoCongNo
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
            this.lblTongNo = new System.Windows.Forms.Label();
            this.btnXuatExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnXemBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.dtpDenThang = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCongNo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.grpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongNo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoLoc.BorderRadius = 8;
            this.grpBoLoc.Controls.Add(this.lblTongNo);
            this.grpBoLoc.Controls.Add(this.btnXuatExcel);
            this.grpBoLoc.Controls.Add(this.btnXemBaoCao);
            this.grpBoLoc.Controls.Add(this.dtpDenThang);
            this.grpBoLoc.Controls.Add(this.label1);
            this.grpBoLoc.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBoLoc.ForeColor = System.Drawing.Color.White;
            this.grpBoLoc.Location = new System.Drawing.Point(30, 20);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new System.Drawing.Size(920, 120);
            this.grpBoLoc.TabIndex = 0;
            this.grpBoLoc.Text = "BÁO CÁO TỔNG CÔNG NỢ TÁC GIẢ";
            // 
            // lblTongNo
            // 
            this.lblTongNo.AutoSize = true;
            this.lblTongNo.BackColor = System.Drawing.Color.White;
            this.lblTongNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongNo.ForeColor = System.Drawing.Color.Crimson;
            this.lblTongNo.Location = new System.Drawing.Point(700, 65);
            this.lblTongNo.Name = "lblTongNo";
            this.lblTongNo.Size = new System.Drawing.Size(141, 21);
            this.lblTongNo.TabIndex = 4;
            this.lblTongNo.Text = "TỔNG NỢ: 0 VNĐ";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BorderRadius = 5;
            this.btnXuatExcel.FillColor = System.Drawing.Color.DarkOrange;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(540, 56);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(150, 45);
            this.btnXuatExcel.TabIndex = 3;
            this.btnXuatExcel.Text = "XUẤT EXCEL";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BorderRadius = 5;
            this.btnXemBaoCao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(380, 56);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(150, 45);
            this.btnXemBaoCao.TabIndex = 2;
            this.btnXemBaoCao.Text = "TÌM KIẾM";
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // dtpDenThang
            // 
            this.dtpDenThang.BorderRadius = 5;
            this.dtpDenThang.Checked = true;
            this.dtpDenThang.CustomFormat = "MM/yyyy";
            this.dtpDenThang.FillColor = System.Drawing.Color.White;
            this.dtpDenThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDenThang.ForeColor = System.Drawing.Color.Black;
            this.dtpDenThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenThang.Location = new System.Drawing.Point(180, 60);
            this.dtpDenThang.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDenThang.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDenThang.Name = "dtpDenThang";
            this.dtpDenThang.Size = new System.Drawing.Size(180, 36);
            this.dtpDenThang.TabIndex = 1;
            this.dtpDenThang.Value = new System.DateTime(2026, 4, 12, 23, 54, 33, 224);
            this.dtpDenThang.ValueChanged += new System.EventHandler(this.dtpDenThang_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tính đến tháng:";
            // 
            // dgvCongNo
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCongNo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCongNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCongNo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCongNo.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCongNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCongNo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCongNo.Location = new System.Drawing.Point(30, 160);
            this.dgvCongNo.Name = "dgvCongNo";
            this.dgvCongNo.RowHeadersVisible = false;
            this.dgvCongNo.RowTemplate.Height = 35;
            this.dgvCongNo.Size = new System.Drawing.Size(920, 460);
            this.dgvCongNo.TabIndex = 1;
            this.dgvCongNo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCongNo.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCongNo.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCongNo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCongNo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCongNo.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCongNo.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCongNo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dgvCongNo.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCongNo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCongNo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCongNo.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCongNo.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvCongNo.ThemeStyle.ReadOnly = false;
            this.dgvCongNo.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCongNo.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCongNo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCongNo.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCongNo.ThemeStyle.RowsStyle.Height = 35;
            this.dgvCongNo.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCongNo.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FrmBaoCaoCongNo
            // 
            this.ClientSize = new System.Drawing.Size(980, 660);
            this.Controls.Add(this.dgvCongNo);
            this.Controls.Add(this.grpBoLoc);
            this.Name = "FrmBaoCaoCongNo";
            this.Text = "Báo Cáo Công Nợ";
            this.Load += new System.EventHandler(this.FrmBaoCaoCongNo_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox grpBoLoc;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDenThang;
        private Guna.UI2.WinForms.Guna2Button btnXemBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnXuatExcel;
        private System.Windows.Forms.Label lblTongNo;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCongNo;
    }
}