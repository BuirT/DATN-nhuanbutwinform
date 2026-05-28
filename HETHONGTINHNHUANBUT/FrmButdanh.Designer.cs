using System.Drawing;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    partial class FrmButDanh
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
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaso = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtButDanh = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTacGia = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvButDanh = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvButDanh)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle1);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.txtMaso);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.txtButDanh);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.cboTacGia);
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
            this.pnlTop.Size = new System.Drawing.Size(1134, 215);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle1.Location = new System.Drawing.Point(25, 18);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(232, 28);
            this.lblTitle1.TabIndex = 1;
            this.lblTitle1.Text = "THÔNG TIN BÚT DANH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(25, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã số bút danh";
            // 
            // txtMaso
            // 
            this.txtMaso.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtMaso.BorderRadius = 8;
            this.txtMaso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaso.DefaultText = "";
            this.txtMaso.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtMaso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaso.ForeColor = System.Drawing.Color.Black;
            this.txtMaso.Location = new System.Drawing.Point(25, 84);
            this.txtMaso.Name = "txtMaso";
            this.txtMaso.Size = new System.Drawing.Size(180, 36);
            this.txtMaso.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(225, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên bút danh hiển thị";
            // 
            // txtButDanh
            // 
            this.txtButDanh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtButDanh.BorderRadius = 8;
            this.txtButDanh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtButDanh.DefaultText = "";
            this.txtButDanh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtButDanh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtButDanh.ForeColor = System.Drawing.Color.Black;
            this.txtButDanh.Location = new System.Drawing.Point(225, 84);
            this.txtButDanh.Name = "txtButDanh";
            this.txtButDanh.Size = new System.Drawing.Size(350, 36);
            this.txtButDanh.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(595, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tác giả chủ quản";
            // 
            // cboTacGia
            // 
            this.cboTacGia.BackColor = System.Drawing.Color.Transparent;
            this.cboTacGia.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboTacGia.BorderRadius = 8;
            this.cboTacGia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTacGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTacGia.FocusedColor = System.Drawing.Color.Empty;
            this.cboTacGia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTacGia.ForeColor = System.Drawing.Color.Black;
            this.cboTacGia.ItemHeight = 30;
            this.cboTacGia.Location = new System.Drawing.Point(595, 84);
            this.cboTacGia.Name = "cboTacGia";
            this.cboTacGia.Size = new System.Drawing.Size(280, 36);
            this.cboTacGia.TabIndex = 7;
            // 
            // btnThem
            // 
            this.btnThem.Animated = true;
            this.btnThem.BorderRadius = 8;
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 145);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.TabIndex = 8;
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
            this.btnSua.Location = new System.Drawing.Point(170, 145);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.TabIndex = 9;
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
            this.btnXoa.Location = new System.Drawing.Point(315, 145);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 40);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "XÓA BỎ";
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
            this.btnLamMoi.Location = new System.Drawing.Point(460, 145);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 40);
            this.btnLamMoi.TabIndex = 11;
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
            this.pnlBottom.Controls.Add(this.lblTitle2);
            this.pnlBottom.Controls.Add(this.txtTimKiem);
            this.pnlBottom.Controls.Add(this.dgvButDanh);
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(20, 245);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlBottom.ShadowDecoration.Depth = 8;
            this.pnlBottom.ShadowDecoration.Enabled = true;
            this.pnlBottom.Size = new System.Drawing.Size(1134, 395);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle2.Location = new System.Drawing.Point(25, 18);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(235, 25);
            this.lblTitle2.TabIndex = 1;
            this.lblTitle2.Text = "DANH SÁCH BÚT DANH";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtTimKiem.BorderRadius = 8;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(829, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "🔍 Nhập mã, bút danh, tên tác giả...";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 36);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // dgvButDanh
            // 
            this.dgvButDanh.AllowUserToAddRows = false;
            this.dgvButDanh.AllowUserToDeleteRows = false;
            this.dgvButDanh.AllowUserToResizeColumns = false;
            this.dgvButDanh.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvButDanh.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvButDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvButDanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvButDanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvButDanh.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvButDanh.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvButDanh.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvButDanh.Location = new System.Drawing.Point(25, 60);
            this.dgvButDanh.Name = "dgvButDanh";
            this.dgvButDanh.ReadOnly = true;
            this.dgvButDanh.RowHeadersVisible = false;
            this.dgvButDanh.RowTemplate.Height = 38;
            this.dgvButDanh.Size = new System.Drawing.Size(1084, 310);
            this.dgvButDanh.TabIndex = 3;
            this.dgvButDanh.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.Empty;
            this.dgvButDanh.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvButDanh.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvButDanh.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvButDanh.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvButDanh.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvButDanh.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvButDanh.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Empty;
            this.dgvButDanh.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvButDanh.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvButDanh.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvButDanh.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvButDanh.ThemeStyle.HeaderStyle.Height = 42;
            this.dgvButDanh.ThemeStyle.ReadOnly = true;
            this.dgvButDanh.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.Empty;
            this.dgvButDanh.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvButDanh.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvButDanh.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvButDanh.ThemeStyle.RowsStyle.Height = 38;
            this.dgvButDanh.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvButDanh.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvButDanh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvButDanh_CellClick);
            // 
            // FrmButDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1174, 660);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmButDanh";
            this.Text = "Quản Lý Danh Mục Bút Danh";
            this.Load += new System.EventHandler(this.FrmButDanh_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvButDanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtMaso;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtButDanh;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cboTacGia;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private System.Windows.Forms.Label lblTitle2;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvButDanh;
    }
}