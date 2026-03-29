using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTroLyAI : Form
    {
        // Chìa khóa API xịn của đồng chí Tí:
        private readonly string apiKey = "AIzaSyDZvMYzl9d6xjqmtAdmlpA1DSKkvgOGVGg";
        // Đã nâng cấp lên bộ não 2.5-flash siêu tốc:
        private readonly string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent";

        public FrmTroLyAI()
        {
            InitializeComponent();

            // Gắn sự kiện bấm phím Enter để gửi tin nhắn cho nhanh
            txtInput.KeyDown += TxtInput_KeyDown;

            // Lời chào mở đầu của AI (Vẽ bong bóng tự động bên trái)
            ThemBongBongChat("🤖 AI Kế Toán: Chào đồng chí Tí! Tôi là trợ lý ảo của hệ thống tính nhuận bút. Đồng chí cần tôi hỗ trợ gì về luật thuế hay nghiệp vụ tòa soạn không?", false);
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Chống tiếng "bíp" khi ấn Enter
                btnGui_Click(sender, e);
            }
        }

        private async void btnGui_Click(object sender, EventArgs e)
        {
            string cauHoi = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(cauHoi)) return;

            // Vẽ bong bóng câu hỏi của người dùng
            ThemBongBongChat(cauHoi, true);
            txtInput.Clear();

            // 🛠️ FIX LỖI SPAM: Khóa nút Gửi VÀ Khóa luôn khung gõ chữ
            btnGui.Enabled = false;
            txtInput.ReadOnly = true;

            // Gọi API hỏi AI
            string traLoi = await GoiGeminiAPI(cauHoi);

            // Vẽ bong bóng câu trả lời của AI
            ThemBongBongChat(traLoi, false);

            // 🛠️ MỞ KHÓA LẠI SAU KHI AI TRẢ LỜI XONG
            btnGui.Enabled = true;
            txtInput.ReadOnly = false;
            txtInput.Focus();
        }

        // =======================================================
        // HÀM VẼ BONG BÓNG CHAT (UI/UX CHUẨN XỊN CỦA EM THANH)
        // =======================================================
        private void ThemBongBongChat(string noiDung, bool laNguoiDung)
        {
            // 1. Tạo một cái nhãn (Label) để chứa chữ
            Label lblTinNhan = new Label();
            lblTinNhan.Text = noiDung;
            lblTinNhan.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblTinNhan.AutoSize = true;
            lblTinNhan.MaximumSize = new Size(flpChat.Width - 150, 0); // Ép xuống dòng nếu chữ quá dài
            lblTinNhan.Padding = new Padding(12, 10, 12, 10);

            // 2. Tạo một cái Bong bóng (Guna2Panel) để bọc cái chữ lại
            Guna.UI2.WinForms.Guna2Panel pnlBongBong = new Guna.UI2.WinForms.Guna2Panel();
            pnlBongBong.BorderRadius = 15;
            pnlBongBong.AutoSize = true;
            pnlBongBong.MaximumSize = new Size(flpChat.Width - 100, 0);
            pnlBongBong.Controls.Add(lblTinNhan);

            // 3. Phân biệt màu sắc và vị trí (Người dùng vs AI)
            if (laNguoiDung)
            {
                // Bong bóng của Đồng chí Tí (Màu tím, chữ trắng, lệch phải)
                pnlBongBong.FillColor = Color.FromArgb(162, 110, 255);
                lblTinNhan.ForeColor = Color.White;
                lblTinNhan.BackColor = Color.Transparent;
                pnlBongBong.Margin = new Padding(flpChat.Width - pnlBongBong.Width - 40, 10, 20, 10); // Đẩy sang phải
            }
            else
            {
                // Bong bóng của AI (Màu xám nhạt, chữ đen, lệch trái)
                pnlBongBong.FillColor = Color.FromArgb(240, 240, 245);
                lblTinNhan.ForeColor = Color.Black;
                lblTinNhan.BackColor = Color.Transparent;
                pnlBongBong.Margin = new Padding(20, 10, 50, 10); // Đẩy sang trái
            }

            // 4. Nhét bong bóng vào khung chat và tự động cuộn xuống đáy
            flpChat.Controls.Add(pnlBongBong);
            flpChat.ScrollControlIntoView(pnlBongBong);
        }

        // =======================================================
        // HÀM GỌI API GEMINI 2.5 FLASH SIÊU TỐC
        // =======================================================
        private async Task<string> GoiGeminiAPI(string prompt)
        {
            try
            {
                // 1. Ép C# bỏ qua lỗi chứng chỉ SSL của phần mềm diệt virus
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                // 2. Ép WinForms sử dụng chuẩn bảo mật mạng TLS 1.2
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                // 3. Khai báo bộ xử lý mạng để ép C# đi thẳng ra Internet, phớt lờ Proxy
                HttpClientHandler handler = new HttpClientHandler();
                handler.UseProxy = false;

                using (HttpClient client = new HttpClient(handler))
                {
                    // Lệnh bài: Ép AI đóng vai Kế toán tòa soạn
                    string systemInstruction = "Bạn là trợ lý ảo xuất sắc của phần mềm Quản lý Nhuận bút tòa soạn báo. Hãy trả lời ngắn gọn, lịch sự, chuyên nghiệp, tập trung vào nghiệp vụ báo chí, tính nhuận bút và thuế thu nhập cá nhân tại Việt Nam. Câu hỏi của người dùng là: ";
                    string fullPrompt = systemInstruction + prompt;

                    // Gói dữ liệu gửi đi theo chuẩn JSON của Google
                    var requestBody = new
                    {
                        contents = new[] { new { parts = new[] { new { text = fullPrompt } } } }
                    };

                    string jsonString = JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // Bắn dữ liệu lên máy chủ Google và chờ kết quả
                    HttpResponseMessage response = await client.PostAsync($"{apiUrl}?key={apiKey}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();

                        // Dịch chuỗi JSON trả về để lấy đúng câu trả lời 
                        dynamic result = JsonConvert.DeserializeObject(responseJson);
                        string answer = result.candidates[0].content.parts[0].text;

                        // Xóa các dấu sao (*) định dạng markdown của AI để WinForms hiện cho đẹp
                        answer = answer.Replace("**", "");
                        return answer;
                    }
                    else
                    {
                        string errorJson = await response.Content.ReadAsStringAsync();
                        return $"Google từ chối (Lỗi {response.StatusCode}):\nChi tiết: {errorJson}";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Lỗi rớt mạng hoặc đường truyền: " + ex.Message;
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}