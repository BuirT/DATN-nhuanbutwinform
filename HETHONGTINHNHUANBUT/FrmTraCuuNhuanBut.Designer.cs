namespace HETHONGTINHNHUANBUT
{
    partial class FrmTraCuuNhuanBut
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMaSo = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDaNhan = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlChoChi = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDangCho = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTraCuu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlDaNhan.SuspendLayout();
            this.pnlChoChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraCuu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblMaSo);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 80);
            this.pnlHeader.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1058, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 45);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "🔄 LÀM MỚI";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(16, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 45);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "TRUNG TÂM THU NHẬP";
            // lblMaSo
            // 
            this.lblMaSo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaSo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblMaSo.Location = new System.Drawing.Point(16, 50);
            this.lblMaSo.Name = "lblMaSo";
            this.lblMaSo.Size = new System.Drawing.Size(400, 20);
            this.lblMaSo.TabIndex = 4;
            this.lblMaSo.Text = "";
            // 
            // lblMaSo
            // 
            this.lblMaSo = new System.Windows.Forms.Label();
            this.lblMaSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaSo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMaSo.Location = new System.Drawing.Point(16, 58);
            this.lblMaSo.Name = "lblMaSo";
            this.lblMaSo.Size = new System.Drawing.Size(400, 20);
            this.lblMaSo.TabIndex = 4;
            this.lblMaSo.Text = "";
            // 
            // pnlCards
            // 
            this.pnlCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.pnlCards.Controls.Add(this.pnlDaNhan);
            this.pnlCards.Controls.Add(this.pnlChoChi);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 80);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Padding = new System.Windows.Forms.Padding(20, 15, 10, 10);
            this.pnlCards.Size = new System.Drawing.Size(1200, 150);
            this.pnlCards.TabIndex = 1;
            // 
            // pnlDaNhan
            // 
            this.pnlDaNhan.BackColor = System.Drawing.Color.Transparent;
            this.pnlDaNhan.BorderRadius = 15;
            this.pnlDaNhan.Controls.Add(this.lblTongTien);
            this.pnlDaNhan.Controls.Add(this.label1);
            this.pnlDaNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.pnlDaNhan.Location = new System.Drawing.Point(23, 18);
            this.pnlDaNhan.Name = "pnlDaNhan";
            this.pnlDaNhan.ShadowDecoration.Enabled = true;
            this.pnlDaNhan.Size = new System.Drawing.Size(380, 115);
            this.pnlDaNhan.TabIndex = 0;
            // 
            // lblTongTien
            // 
            this.lblTongTien.BackColor = System.Drawing.Color.Transparent;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.White;
            this.lblTongTien.Location = new System.Drawing.Point(10, 45);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(360, 55);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "0 VNĐ";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐÃ QUYẾT TOÁN";
            // 
            // pnlChoChi
            // 
            this.pnlChoChi.BackColor = System.Drawing.Color.Transparent;
            this.pnlChoChi.BorderRadius = 15;
            this.pnlChoChi.Controls.Add(this.lblDangCho);
            this.pnlChoChi.Controls.Add(this.label2);
            this.pnlChoChi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.pnlChoChi.Location = new System.Drawing.Point(409, 18);
            this.pnlChoChi.Name = "pnlChoChi";
            this.pnlChoChi.ShadowDecoration.Enabled = true;
            this.pnlChoChi.Size = new System.Drawing.Size(380, 115);
            this.pnlChoChi.TabIndex = 1;
            this.pnlChoChi.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChoChi_Paint);
            // 
            // lblDangCho
            // 
            this.lblDangCho.BackColor = System.Drawing.Color.Transparent;
            this.lblDangCho.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblDangCho.ForeColor = System.Drawing.Color.White;
            this.lblDangCho.Location = new System.Drawing.Point(10, 45);
            this.lblDangCho.Name = "lblDangCho";
            this.lblDangCho.Size = new System.Drawing.Size(360, 55);
            this.lblDangCho.TabIndex = 0;
            this.lblDangCho.Text = "0 VNĐ";
            this.lblDangCho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ĐANG CHỜ XỬ LÝ";
            // 
            // dgvTraCuu
            // 
            this.dgvTraCuu.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvTraCuu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTraCuu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTraCuu.ColumnHeadersHeight = 45;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTraCuu.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTraCuu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraCuu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTraCuu.Location = new System.Drawing.Point(0, 230);
            this.dgvTraCuu.Name = "dgvTraCuu";
            this.dgvTraCuu.ReadOnly = true;
            this.dgvTraCuu.RowHeadersVisible = false;
            this.dgvTraCuu.Size = new System.Drawing.Size(1200, 520);
            this.dgvTraCuu.TabIndex = 0;
            this.dgvTraCuu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTraCuu.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTraCuu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTraCuu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTraCuu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTraCuu.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTraCuu.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTraCuu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(120)))));
            this.dgvTraCuu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTraCuu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvTraCuu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTraCuu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTraCuu.ThemeStyle.HeaderStyle.Height = 45;
            this.dgvTraCuu.ThemeStyle.ReadOnly = true;
            this.dgvTraCuu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTraCuu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTraCuu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvTraCuu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTraCuu.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTraCuu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTraCuu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FrmTraCuuNhuanBut
            // 
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.dgvTraCuu);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTraCuuNhuanBut";
            this.Load += new System.EventHandler(this.FrmTraCuuNhuanBut_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlCards.ResumeLayout(false);
            this.pnlDaNhan.ResumeLayout(false);
            this.pnlChoChi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraCuu)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, label1, label2, lblTongTien, lblDangCho, lblMaSo;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel pnlCards;
        private Guna.UI2.WinForms.Guna2Panel pnlDaNhan, pnlChoChi;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTraCuu;
    }
}