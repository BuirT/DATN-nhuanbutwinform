using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTroLyAI : Form
    {
        private readonly HETHONGTINHNHUANBUT.Services.AI.NewsPayAIService _aiService;

        public FrmTroLyAI()
        {
            InitializeComponent();
            
            string endpoint = AIConfig.GenerateUrl;
            string aiModel = AIConfig.OllamaModel;
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
            
            _aiService = new HETHONGTINHNHUANBUT.Services.AI.NewsPayAIService(endpoint, aiModel, connString);

            txtInput.KeyDown += TxtInput_KeyDown;
            flpChat.Resize += FlpChat_Resize;

            // Removed programmatic AI icon per user request
            
            ThemBongBongChat("🤖 Chào bạn! Tôi là Trợ lý AI hệ thống NewsPay. " +
                "Tôi có thể:\n" +
                "• 📊 Hỏi thống kê tổng quan (tổng bài, tổng tiền, trạng thái duyệt...)\n" +
                "• 👤 Tra cứu tác giả (vd: 'thông tin tác giả Nguyễn Văn A')\n" +
                "• 📅 Báo cáo theo tháng (vd: 'thống kê tháng 6/2026')\n" +
                "• 💰 Phiếu chi, thuế (vd: 'phiếu chi tháng này')\n" +
                "• 🔍 Phát hiện bất thường (vd: 'kiểm tra bài bất thường')\n" +
                "Bạn muốn hỏi gì?", false);
        }

        private void FlpChat_Resize(object sender, EventArgs e)
        {
            if (flpChat.IsDisposed) return;
            foreach (Control c in flpChat.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Panel pnl && pnl.Controls.Count > 0 && pnl.Controls[0] is Label lbl)
                {
                    lbl.MaximumSize = new Size(flpChat.ClientSize.Width - 100, 0);
                    if (pnl.FillColor == Color.FromArgb(6, 78, 59)) // isUser
                    {
                        pnl.Margin = new Padding(Math.Max(10, flpChat.ClientSize.Width - pnl.Width - 25), 10, 10, 10);
                    }
                }
                else if (c is Label oldLbl)
                {
                    oldLbl.MaximumSize = new Size(flpChat.ClientSize.Width - 100, 0);
                    if (oldLbl.BackColor == Color.FromArgb(6, 78, 59)) // isUser
                    {
                        oldLbl.Margin = new Padding(Math.Max(10, flpChat.ClientSize.Width - oldLbl.Width - 25), 10, 10, 10);
                    }
                }
            }
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnGui_Click(null, null);
            }
        }

        private async void btnGui_Click(object sender, EventArgs e)
        {
            if (this.IsDisposed) return;

            try
            {
                string cauHoi = txtInput.Text.Trim();
                if (string.IsNullOrEmpty(cauHoi)) return;

                ThemBongBongChat(cauHoi, true);
                txtInput.Clear();

                btnGui.Enabled = false;
                txtInput.ReadOnly = true;
                btnGui.Text = "ĐANG NGHĨ...";

                string phanHoi = await _aiService.ProcessUserQueryAsync(cauHoi);

                if (this.IsDisposed) return;
                ThemBongBongChat(phanHoi, false);

                btnGui.Enabled = true;
                txtInput.ReadOnly = false;
                btnGui.Text = "GỬI";
                txtInput.Focus();
            }
            catch (ObjectDisposedException) { }
            catch (InvalidOperationException) { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _aiService.ClearMemory();
            ThemBongBongChat("🔄 Đã xóa lịch sử trò chuyện. Bắt đầu phiên mới!", false);
        }

        // =========================================================================
        // HIỂN THỊ BONG BÓNG CHAT
        // =========================================================================
        private void ThemBongBongChat(string tinNhan, bool isUser)
        {
            if (this.IsDisposed || flpChat.IsDisposed) return;

            try
            {
                Label lbl = new Label();
                lbl.Text = tinNhan;
                lbl.AutoSize = true;
                lbl.MaximumSize = new Size(flpChat.ClientSize.Width - 100, 0);
                lbl.Padding = new Padding(16);
                lbl.Font = new Font("Segoe UI", 11.5F);
                lbl.BackColor = Color.Transparent;

                Guna.UI2.WinForms.Guna2Panel bubble = new Guna.UI2.WinForms.Guna2Panel();
                bubble.BorderRadius = 18;
                bubble.AutoSize = true;
                bubble.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                bubble.Controls.Add(lbl);

                flpChat.Controls.Add(bubble); // Thêm vào trước để WinForms tính toán Width

                if (isUser)
                {
                    bubble.FillColor = Color.FromArgb(6, 78, 59);
                    lbl.ForeColor = Color.White;
                    bubble.Margin = new Padding(Math.Max(10, flpChat.ClientSize.Width - bubble.Width - 25), 10, 10, 10);
                }
                else
                {
                    bubble.FillColor = Color.FromArgb(241, 245, 249);
                    lbl.ForeColor = Color.FromArgb(6, 78, 59);
                    bubble.Margin = new Padding(10, 10, 10, 10);
                }

                flpChat.ScrollControlIntoView(bubble);
            }
            catch (ObjectDisposedException) { }
        }
    }
}
