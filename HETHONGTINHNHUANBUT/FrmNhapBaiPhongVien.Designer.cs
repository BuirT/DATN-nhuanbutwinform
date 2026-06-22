using System.Drawing;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    partial class FrmNhapBaiPhongVien
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSoBao = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenBai = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrang = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboButDanh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblVung = new System.Windows.Forms.Label();
            this.cboVung = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblVungChuyenDen = new System.Windows.Forms.Label();
            this.cboVungChuyenDen = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnNopBai = new Guna.UI2.WinForms.Guna2Button();
            this.btnKiemToanAI = new Guna.UI2.WinForms.Guna2Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnPhanTichAI = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNoiDungBaiViet = new System.Windows.Forms.RichTextBox();
            this.lblDiemAI = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDanhGiaAI = new System.Windows.Forms.RichTextBox();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.dgvBaiCuaToi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiCuaToi)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BorderRadius = 16;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.cboSoBao);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.txtTenBai);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.txtTrang);
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.cboMuc);
            this.pnlTop.Controls.Add(this.label5);
            this.pnlTop.Controls.Add(this.cboButDanh);
            this.pnlTop.Controls.Add(this.lblVung);
            this.pnlTop.Controls.Add(this.cboVung);
            this.pnlTop.Controls.Add(this.lblVungChuyenDen);
            this.pnlTop.Controls.Add(this.cboVungChuyenDen);
            this.pnlTop.Controls.Add(this.btnNopBai);
            this.pnlTop.Controls.Add(this.btnKiemToanAI);
            this.pnlTop.Controls.Add(this.lblWarning);
            this.pnlTop.Controls.Add(this.btnPhanTichAI);
            this.pnlTop.Controls.Add(this.label7);
            this.pnlTop.Controls.Add(this.txtNoiDungBaiViet);
            this.pnlTop.Controls.Add(this.lblDiemAI);
            this.pnlTop.Controls.Add(this.label8);
            this.pnlTop.Controls.Add(this.txtDanhGiaAI);
            this.pnlTop.FillColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(20, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlTop.ShadowDecoration.Depth = 8;
            this.pnlTop.Size = new System.Drawing.Size(1160, 580);
            this.pnlTop.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NHẬP BÀI MỚI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(25, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHỌN SỐ BÁO";
            // 
            // cboSoBao
            // 
            this.cboSoBao.BackColor = System.Drawing.Color.Transparent;
            this.cboSoBao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboSoBao.BorderRadius = 8;
            this.cboSoBao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSoBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoBao.FocusedColor = System.Drawing.Color.Empty;
            this.cboSoBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSoBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cboSoBao.ItemHeight = 30;
            this.cboSoBao.Location = new System.Drawing.Point(25, 87);
            this.cboSoBao.Name = "cboSoBao";
            this.cboSoBao.Size = new System.Drawing.Size(550, 36);
            this.cboSoBao.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(25, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên bài";
            // 
            // txtTenBai
            // 
            this.txtTenBai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtTenBai.BorderRadius = 8;
            this.txtTenBai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBai.DefaultText = "";
            this.txtTenBai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtTenBai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenBai.Location = new System.Drawing.Point(25, 167);
            this.txtTenBai.Name = "txtTenBai";
            this.txtTenBai.PlaceholderText = "";
            this.txtTenBai.SelectedText = "";
            this.txtTenBai.Size = new System.Drawing.Size(350, 36);
            this.txtTenBai.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(390, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Trang";
            // 
            // txtTrang
            // 
            this.txtTrang.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtTrang.BorderRadius = 8;
            this.txtTrang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTrang.DefaultText = "";
            this.txtTrang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.txtTrang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTrang.Location = new System.Drawing.Point(390, 167);
            this.txtTrang.Name = "txtTrang";
            this.txtTrang.PlaceholderText = "";
            this.txtTrang.SelectedText = "";
            this.txtTrang.Size = new System.Drawing.Size(80, 36);
            this.txtTrang.TabIndex = 2;
            this.txtTrang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTrang_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(485, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mục";
            // 
            // cboMuc
            // 
            this.cboMuc.BackColor = System.Drawing.Color.Transparent;
            this.cboMuc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboMuc.BorderRadius = 8;
            this.cboMuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMuc.FocusedColor = System.Drawing.Color.Empty;
            this.cboMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cboMuc.ItemHeight = 30;
            this.cboMuc.Location = new System.Drawing.Point(485, 167);
            this.cboMuc.Name = "cboMuc";
            this.cboMuc.Size = new System.Drawing.Size(130, 36);
            this.cboMuc.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label5.Location = new System.Drawing.Point(630, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Bút danh";
            // 
            // cboButDanh
            // 
            this.cboButDanh.BackColor = System.Drawing.Color.Transparent;
            this.cboButDanh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboButDanh.BorderRadius = 8;
            this.cboButDanh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboButDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboButDanh.FocusedColor = System.Drawing.Color.Empty;
            this.cboButDanh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboButDanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cboButDanh.ItemHeight = 30;
            this.cboButDanh.Location = new System.Drawing.Point(630, 167);
            this.cboButDanh.Name = "cboButDanh";
            this.cboButDanh.Size = new System.Drawing.Size(200, 36);
            this.cboButDanh.TabIndex = 4;
            // 
            // lblVung
            // 
            this.lblVung.AutoSize = true;
            this.lblVung.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblVung.Location = new System.Drawing.Point(845, 145);
            this.lblVung.Name = "lblVung";
            this.lblVung.Size = new System.Drawing.Size(108, 17);
            this.lblVung.TabIndex = 6;
            this.lblVung.Text = "Vùng phát hành";
            // 
            // cboVung
            // 
            this.cboVung.BackColor = System.Drawing.Color.Transparent;
            this.cboVung.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboVung.BorderRadius = 8;
            this.cboVung.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboVung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVung.FocusedColor = System.Drawing.Color.Empty;
            this.cboVung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cboVung.ItemHeight = 30;
            this.cboVung.Items.AddRange(new object[] {
            "HNI",
            "HCM",
            "DNG"});
            this.cboVung.Location = new System.Drawing.Point(845, 167);
            this.cboVung.Name = "cboVung";
            this.cboVung.Size = new System.Drawing.Size(150, 36);
            this.cboVung.TabIndex = 5;
            // 
            // lblVungChuyenDen
            // 
            this.lblVungChuyenDen.AutoSize = true;
            this.lblVungChuyenDen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVungChuyenDen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblVungChuyenDen.Location = new System.Drawing.Point(1010, 145);
            this.lblVungChuyenDen.Name = "lblVungChuyenDen";
            this.lblVungChuyenDen.Size = new System.Drawing.Size(148, 17);
            this.lblVungChuyenDen.TabIndex = 7;
            this.lblVungChuyenDen.Text = "Vùng chuyển (Tái bản)";
            // 
            // cboVungChuyenDen
            // 
            this.cboVungChuyenDen.BackColor = System.Drawing.Color.Transparent;
            this.cboVungChuyenDen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cboVungChuyenDen.BorderRadius = 8;
            this.cboVungChuyenDen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboVungChuyenDen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVungChuyenDen.FocusedColor = System.Drawing.Color.Empty;
            this.cboVungChuyenDen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVungChuyenDen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.cboVungChuyenDen.ItemHeight = 30;
            this.cboVungChuyenDen.Items.AddRange(new object[] {
            "Không có",
            "HNI",
            "HCM",
            "DNG"});
            this.cboVungChuyenDen.Location = new System.Drawing.Point(1010, 167);
            this.cboVungChuyenDen.Name = "cboVungChuyenDen";
            this.cboVungChuyenDen.Size = new System.Drawing.Size(150, 36);
            this.cboVungChuyenDen.TabIndex = 6;
            // 
            // btnNopBai
            // 
            this.btnNopBai.BorderRadius = 8;
            this.btnNopBai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnNopBai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNopBai.ForeColor = System.Drawing.Color.White;
            this.btnNopBai.Location = new System.Drawing.Point(25, 210);
            this.btnNopBai.Name = "btnNopBai";
            this.btnNopBai.Size = new System.Drawing.Size(140, 38);
            this.btnNopBai.TabIndex = 7;
            this.btnNopBai.Text = "📤 NỘP BÀI";
            this.btnNopBai.Click += new System.EventHandler(this.btnNopBai_Click);
            // 
            // btnKiemToanAI
            // 
            this.btnKiemToanAI.BorderRadius = 8;
            this.btnKiemToanAI.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnKiemToanAI.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKiemToanAI.ForeColor = System.Drawing.Color.White;
            this.btnKiemToanAI.Location = new System.Drawing.Point(180, 210);
            this.btnKiemToanAI.Name = "btnKiemToanAI";
            this.btnKiemToanAI.Size = new System.Drawing.Size(150, 38);
            this.btnKiemToanAI.TabIndex = 8;
            this.btnKiemToanAI.Text = "📋 AI KIỂM TOÁN";
            this.btnKiemToanAI.Click += new System.EventHandler(this.btnKiemToanAI_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblWarning.Location = new System.Drawing.Point(25, 530);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(1110, 50);
            this.lblWarning.TabIndex = 9;
            this.lblWarning.Visible = false;
            // 
            // btnPhanTichAI
            // 
            this.btnPhanTichAI.Animated = true;
            this.btnPhanTichAI.BorderRadius = 8;
            this.btnPhanTichAI.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnPhanTichAI.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhanTichAI.ForeColor = System.Drawing.Color.White;
            this.btnPhanTichAI.Location = new System.Drawing.Point(345, 210);
            this.btnPhanTichAI.Name = "btnPhanTichAI";
            this.btnPhanTichAI.Size = new System.Drawing.Size(170, 38);
            this.btnPhanTichAI.TabIndex = 10;
            this.btnPhanTichAI.Text = "🤖 PHÂN TÍCH AI";
            this.btnPhanTichAI.Click += new System.EventHandler(this.btnPhanTichAI_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label7.Location = new System.Drawing.Point(25, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "NỘI DUNG BÀI VIẾT";
            // 
            // txtNoiDungBaiViet
            // 
            this.txtNoiDungBaiViet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiDungBaiViet.BackColor = System.Drawing.Color.White;
            this.txtNoiDungBaiViet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoiDungBaiViet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoiDungBaiViet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtNoiDungBaiViet.Location = new System.Drawing.Point(25, 288);
            this.txtNoiDungBaiViet.Name = "txtNoiDungBaiViet";
            this.txtNoiDungBaiViet.Size = new System.Drawing.Size(1110, 100);
            this.txtNoiDungBaiViet.TabIndex = 9;
            this.txtNoiDungBaiViet.Text = "";
            // 
            // lblDiemAI
            // 
            this.lblDiemAI.AutoSize = true;
            this.lblDiemAI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDiemAI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblDiemAI.Location = new System.Drawing.Point(25, 398);
            this.lblDiemAI.Name = "lblDiemAI";
            this.lblDiemAI.Size = new System.Drawing.Size(0, 21);
            this.lblDiemAI.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label8.Location = new System.Drawing.Point(25, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "ĐÁNH GIÁ AI";
            // 
            // txtDanhGiaAI
            // 
            this.txtDanhGiaAI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDanhGiaAI.BackColor = System.Drawing.Color.White;
            this.txtDanhGiaAI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDanhGiaAI.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDanhGiaAI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtDanhGiaAI.Location = new System.Drawing.Point(25, 452);
            this.txtDanhGiaAI.Name = "txtDanhGiaAI";
            this.txtDanhGiaAI.ReadOnly = true;
            this.txtDanhGiaAI.Size = new System.Drawing.Size(1110, 60);
            this.txtDanhGiaAI.TabIndex = 14;
            this.txtDanhGiaAI.Text = "";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottom.BorderRadius = 16;
            this.pnlBottom.Controls.Add(this.lblDataTitle);
            this.pnlBottom.Controls.Add(this.dgvBaiCuaToi);
            this.pnlBottom.FillColor = System.Drawing.Color.White;
            this.pnlBottom.Location = new System.Drawing.Point(20, 615);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlBottom.ShadowDecoration.Depth = 8;
            this.pnlBottom.Size = new System.Drawing.Size(1160, 295);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblDataTitle
            // 
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDataTitle.Location = new System.Drawing.Point(25, 18);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(232, 25);
            this.lblDataTitle.TabIndex = 0;
            this.lblDataTitle.Text = "DANH SÁCH BÀI CỦA TÔI";
            // 
            // dgvBaiCuaToi
            // 
            this.dgvBaiCuaToi.AllowUserToAddRows = false;
            this.dgvBaiCuaToi.AllowUserToDeleteRows = false;
            this.dgvBaiCuaToi.AllowUserToResizeColumns = false;
            this.dgvBaiCuaToi.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvBaiCuaToi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBaiCuaToi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaiCuaToi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBaiCuaToi.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaiCuaToi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBaiCuaToi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvBaiCuaToi.Location = new System.Drawing.Point(25, 55);
            this.dgvBaiCuaToi.Name = "dgvBaiCuaToi";
            this.dgvBaiCuaToi.ReadOnly = true;
            this.dgvBaiCuaToi.RowHeadersVisible = false;
            this.dgvBaiCuaToi.RowTemplate.Height = 38;
            this.dgvBaiCuaToi.Size = new System.Drawing.Size(1110, 419);
            this.dgvBaiCuaToi.TabIndex = 0;
            this.dgvBaiCuaToi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaiCuaToi.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBaiCuaToi.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBaiCuaToi.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBaiCuaToi.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBaiCuaToi.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaiCuaToi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvBaiCuaToi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBaiCuaToi.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBaiCuaToi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvBaiCuaToi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBaiCuaToi.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBaiCuaToi.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvBaiCuaToi.ThemeStyle.ReadOnly = true;
            this.dgvBaiCuaToi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBaiCuaToi.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBaiCuaToi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvBaiCuaToi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBaiCuaToi.ThemeStyle.RowsStyle.Height = 38;
            this.dgvBaiCuaToi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBaiCuaToi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // FrmNhapBaiPhongVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1200, 850);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmNhapBaiPhongVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập bài - Phóng viên";
            this.Load += new System.EventHandler(this.FrmNhapBaiPhongVien_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaiCuaToi)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboSoBao;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtTenBai;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtTrang;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cboMuc;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cboButDanh;
        private System.Windows.Forms.Label lblVung;
        private Guna.UI2.WinForms.Guna2ComboBox cboVung;
        private System.Windows.Forms.Label lblVungChuyenDen;
        private Guna.UI2.WinForms.Guna2ComboBox cboVungChuyenDen;
        private Guna.UI2.WinForms.Guna2Button btnNopBai;
        private Guna.UI2.WinForms.Guna2Button btnKiemToanAI;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblDiemAI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox txtDanhGiaAI;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Label lblDataTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBaiCuaToi;
    }
}
