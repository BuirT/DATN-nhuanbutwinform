using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HETHONGTINHNHUANBUT
{
    partial class FrmAIPhanTichDashboard
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblIconAI = new System.Windows.Forms.Label();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportPdf = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveTxt = new Guna.UI2.WinForms.Guna2Button();
            this.btnCopy = new Guna.UI2.WinForms.Guna2Button();
            this.btnReAnalyze = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlLoading = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.progressRing = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.pnlInfoCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatsData = new System.Windows.Forms.Label();
            this.lblStatsTitle = new System.Windows.Forms.Label();
            this.lblInfoData = new System.Windows.Forms.Label();
            this.lblInfoTitle = new System.Windows.Forms.Label();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLoading.SuspendLayout();
            this.pnlInfoCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblIconAI);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.ShadowDecoration.Enabled = true;
            this.pnlHeader.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(54, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(261, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "AI Phân Tích Dashboard";
            // 
            // lblIconAI
            // 
            this.lblIconAI.AutoSize = true;
            this.lblIconAI.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lblIconAI.Location = new System.Drawing.Point(12, 12);
            this.lblIconAI.Name = "lblIconAI";
            this.lblIconAI.Size = new System.Drawing.Size(52, 36);
            this.lblIconAI.TabIndex = 0;
            this.lblIconAI.Text = "🤖";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnExportPdf);
            this.pnlBottom.Controls.Add(this.btnSaveTxt);
            this.pnlBottom.Controls.Add(this.btnCopy);
            this.pnlBottom.Controls.Add(this.btnReAnalyze);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 530);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.ShadowDecoration.Enabled = true;
            this.pnlBottom.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlBottom.Size = new System.Drawing.Size(900, 70);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 6;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(768, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.BorderRadius = 6;
            this.btnExportPdf.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportPdf.Location = new System.Drawing.Point(380, 15);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(120, 40);
            this.btnExportPdf.TabIndex = 2;
            this.btnExportPdf.Text = "Xuất PDF";
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // btnSaveTxt
            // 
            this.btnSaveTxt.BorderRadius = 6;
            this.btnSaveTxt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnSaveTxt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveTxt.ForeColor = System.Drawing.Color.White;
            this.btnSaveTxt.Location = new System.Drawing.Point(250, 15);
            this.btnSaveTxt.Name = "btnSaveTxt";
            this.btnSaveTxt.Size = new System.Drawing.Size(120, 40);
            this.btnSaveTxt.TabIndex = 1;
            this.btnSaveTxt.Text = "Lưu TXT";
            this.btnSaveTxt.Click += new System.EventHandler(this.btnSaveTxt_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BorderRadius = 6;
            this.btnCopy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnCopy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Location = new System.Drawing.Point(120, 15);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(120, 40);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnReAnalyze
            // 
            this.btnReAnalyze.BorderRadius = 6;
            this.btnReAnalyze.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnReAnalyze.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReAnalyze.ForeColor = System.Drawing.Color.White;
            this.btnReAnalyze.Location = new System.Drawing.Point(510, 15);
            this.btnReAnalyze.Name = "btnReAnalyze";
            this.btnReAnalyze.Size = new System.Drawing.Size(140, 40);
            this.btnReAnalyze.TabIndex = 3;
            this.btnReAnalyze.Text = "Phân tích lại";
            this.btnReAnalyze.Click += new System.EventHandler(this.btnReAnalyze_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlLoading);
            this.pnlMain.Controls.Add(this.rtbResult);
            this.pnlMain.Controls.Add(this.pnlInfoCard);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(900, 470);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlLoading
            // 
            this.pnlLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlLoading.Controls.Add(this.lblLoading);
            this.pnlLoading.Controls.Add(this.progressRing);
            this.pnlLoading.Location = new System.Drawing.Point(300, 150);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(300, 208);
            this.pnlLoading.TabIndex = 1;
            this.pnlLoading.Visible = false;
            // 
            // lblLoading
            // 
            this.lblLoading.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblLoading.Location = new System.Drawing.Point(0, 100);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(300, 30);
            this.lblLoading.TabIndex = 1;
            this.lblLoading.Text = "AI đang phân tích Dashboard...";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressRing
            // 
            this.progressRing.Location = new System.Drawing.Point(115, 20);
            this.progressRing.Name = "progressRing";
            this.progressRing.Size = new System.Drawing.Size(70, 70);
            this.progressRing.TabIndex = 0;
            // 
            // rtbResult
            // 
            this.rtbResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.rtbResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResult.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rtbResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.rtbResult.Location = new System.Drawing.Point(20, 180);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.ReadOnly = true;
            this.rtbResult.Size = new System.Drawing.Size(860, 270);
            this.rtbResult.TabIndex = 0;
            this.rtbResult.Text = "";
            // 
            // pnlInfoCard
            // 
            this.pnlInfoCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlInfoCard.BorderRadius = 8;
            this.pnlInfoCard.Controls.Add(this.lblStatsData);
            this.pnlInfoCard.Controls.Add(this.lblStatsTitle);
            this.pnlInfoCard.Controls.Add(this.lblInfoData);
            this.pnlInfoCard.Controls.Add(this.lblInfoTitle);
            this.pnlInfoCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfoCard.Location = new System.Drawing.Point(20, 20);
            this.pnlInfoCard.Name = "pnlInfoCard";
            this.pnlInfoCard.Padding = new System.Windows.Forms.Padding(15);
            this.pnlInfoCard.ShadowDecoration.Enabled = true;
            this.pnlInfoCard.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlInfoCard.Size = new System.Drawing.Size(860, 160);
            this.pnlInfoCard.TabIndex = 2;
            this.pnlInfoCard.Visible = false;
            // 
            // lblStatsData
            // 
            this.lblStatsData.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatsData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblStatsData.Location = new System.Drawing.Point(430, 45);
            this.lblStatsData.Name = "lblStatsData";
            this.lblStatsData.Size = new System.Drawing.Size(400, 100);
            this.lblStatsData.TabIndex = 3;
            this.lblStatsData.Text = "Bài viết: ... | Phóng viên: ...\r\nTác giả: ... | Loại bài: ...\r\nNhuận bút: ...\r\nKh" +
    "oảng thời gian: ...";
            // 
            // lblStatsTitle
            // 
            this.lblStatsTitle.AutoSize = true;
            this.lblStatsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblStatsTitle.Location = new System.Drawing.Point(430, 15);
            this.lblStatsTitle.Name = "lblStatsTitle";
            this.lblStatsTitle.Size = new System.Drawing.Size(212, 19);
            this.lblStatsTitle.TabIndex = 2;
            this.lblStatsTitle.Text = "📊 DỮ LIỆU ĐƯỢC PHÂN TÍCH";
            // 
            // lblInfoData
            // 
            this.lblInfoData.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblInfoData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblInfoData.Location = new System.Drawing.Point(15, 45);
            this.lblInfoData.Name = "lblInfoData";
            this.lblInfoData.Size = new System.Drawing.Size(400, 100);
            this.lblInfoData.TabIndex = 1;
            this.lblInfoData.Text = "Thời gian: ...\r\nMô hình AI: ...\r\nThời gian xử lý: ...\r\nNguồn dữ liệu: ...";
            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.AutoSize = true;
            this.lblInfoTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblInfoTitle.Name = "lblInfoTitle";
            this.lblInfoTitle.Size = new System.Drawing.Size(238, 19);
            this.lblInfoTitle.TabIndex = 0;
            this.lblInfoTitle.Text = "ℹ️ THÔNG TIN PHIÊN PHÂN TÍCH";
            // 
            // FrmAIPhanTichDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAIPhanTichDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI Phân Tích Dashboard";
            this.Load += new System.EventHandler(this.FrmAIPhanTichDashboard_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlLoading.ResumeLayout(false);
            this.pnlInfoCard.ResumeLayout(false);
            this.pnlInfoCard.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblIconAI;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnExportPdf;
        private Guna.UI2.WinForms.Guna2Button btnSaveTxt;
        private Guna.UI2.WinForms.Guna2Button btnCopy;
        private Guna.UI2.WinForms.Guna2Button btnReAnalyze;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private System.Windows.Forms.RichTextBox rtbResult;
        private Guna.UI2.WinForms.Guna2Panel pnlLoading;
        private System.Windows.Forms.Label lblLoading;
        private Guna.UI2.WinForms.Guna2ProgressIndicator progressRing;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlInfoCard;
        private System.Windows.Forms.Label lblInfoTitle;
        private System.Windows.Forms.Label lblInfoData;
        private System.Windows.Forms.Label lblStatsTitle;
        private System.Windows.Forms.Label lblStatsData;
    }
}
