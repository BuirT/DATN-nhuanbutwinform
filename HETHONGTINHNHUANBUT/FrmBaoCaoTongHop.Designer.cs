namespace HETHONGTINHNHUANBUT
{
    partial class FrmBaoCaoTongHop
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpThang = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnXemBaoCao = new Guna.UI2.WinForms.Guna2Button();
            this.btnXuatExcel = new Guna.UI2.WinForms.Guna2Button();
            this.dgvBaoCao = new Guna.UI2.WinForms.Guna2DataGridView();
            this.grpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoLoc.BorderRadius = 8;
            this.grpBoLoc.Controls.Add(this.btnXuatExcel);
            this.grpBoLoc.Controls.Add(this.btnXemBaoCao);
            this.grpBoLoc.Controls.Add(this.dtpThang);
            this.grpBoLoc.Controls.Add(this.label1);
            this.grpBoLoc.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBoLoc.ForeColor = System.Drawing.Color.White;
            this.grpBoLoc.Location = new System.Drawing.Point(30, 20);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new System.Drawing.Size(920, 120);
            this.grpBoLoc.TabIndex = 0;
            this.grpBoLoc.Text = "BỘ LỌC BÁO CÁO THÁNG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Tháng:";
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
            this.dtpThang.Location = new System.Drawing.Point(170, 60);
            this.dtpThang.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpThang.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(200, 36);
            this.dtpThang.TabIndex = 1;
            this.dtpThang.Value = new System.DateTime(2026, 4, 1, 0, 0, 0, 0);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BorderRadius = 5;
            this.btnXemBaoCao.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(400, 56);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(150, 45);
            this.btnXemBaoCao.TabIndex = 2;
            this.btnXemBaoCao.Text = "XEM BÁO CÁO";
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BorderRadius = 5;
            this.btnXuatExcel.FillColor = System.Drawing.Color.DarkOrange;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(570, 56);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(150, 45);
            this.btnXuatExcel.TabIndex = 3;
            this.btnXuatExcel.Text = "XUẤT EXCEL";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // dgvBaoCao
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBaoCao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBaoCao.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBaoCao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBaoCao.Location = new System.Drawing.Point(30, 160);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersVisible = false;
            this.dgvBaoCao.RowTemplate.Height = 35;
            this.dgvBaoCao.Size = new System.Drawing.Size(920, 460);
            this.dgvBaoCao.TabIndex = 1;
            this.dgvBaoCao.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaoCao.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dgvBaoCao.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            // 
            // FrmTongHopThang
            // 
            this.ClientSize = new System.Drawing.Size(980, 660);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.grpBoLoc);
            this.Name = "FrmTongHopThang";
            this.Text = "Báo Cáo Tổng Hợp Tháng";
            this.Load += new System.EventHandler(this.FrmTongHopThang_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox grpBoLoc;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpThang;
        private Guna.UI2.WinForms.Guna2Button btnXemBaoCao;
        private Guna.UI2.WinForms.Guna2Button btnXuatExcel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBaoCao;
    }
}