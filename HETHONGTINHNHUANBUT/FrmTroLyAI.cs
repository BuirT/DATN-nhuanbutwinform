using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // 🔥 ĐÃ THÊM THƯ VIỆN NÀY ĐỂ ĐỌC DATABASE

namespace HETHONGTINHNHUANBUT
{
    public partial class FrmTroLyAI : Form
    {
        // Đường dẫn kết nối Ollama và SQL
        private static readonly string endpoint = "http://localhost:11434/api/generate";
        private static readonly string aiModel = "qwen2.5";

        // Chuỗi kết nối Database (Đồng bộ với FrmNhapNhuanBut)
        private readonly string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public FrmTroLyAI()
        {
            InitializeComponent();
            txtInput.KeyDown += TxtInput_KeyDown;

            ThemBongBongChat("🤖 AI Kế Toán: Chào đồng chí! Tôi là Trợ lý AI nội bộ của hệ thống NewsPay. Không chỉ nắm vững luật Thuế, tôi còn được cấp quyền truy cập dữ liệu trực tiếp. Đồng chí có thể hỏi tôi về số liệu tổng quan ngay bây giờ!", false);
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
            string cauHoi = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(cauHoi)) return;

            ThemBongBongChat(cauHoi, true);
            txtInput.Clear();

            btnGui.Enabled = false;
            txtInput.ReadOnly = true;
            btnGui.Text = "ĐANG NGHĨ...";

            string phanHoi = await GuiTinNhanChatAI(cauHoi);
            ThemBongBongChat(phanHoi, false);

            btnGui.Enabled = true;
            txtInput.ReadOnly = false;
            btnGui.Text = "GỬI";
            txtInput.Focus();
        }

        // =========================================================================
        // HÀM LẤY SỐ LIỆU TỪ SQL (CẤP "ĐÔI MẮT" CHO AI)
        // =========================================================================
        private async Task<string> LayThongTinHeThongAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    await conn.OpenAsync();
                    // Lấy tổng số bài và tổng tiền nhuận bút trong Database
                    string query = "SELECT COUNT(*) as TongSoBai, ISNULL(SUM(TienNhuanbut), 0) as TongTien FROM Nhuanbut";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            int tongSoBai = Convert.ToInt32(reader["TongSoBai"]);
                            decimal tongTien = Convert.ToDecimal(reader["TongTien"]);
                            // Đóng gói thành chuỗi thông tin để gửi cho AI
                            return $"[THÔNG TIN DỮ LIỆU HIỆN TẠI (Real-time): Tổng số bài báo đã duyệt: {tongSoBai} bài. Tổng quỹ nhuận bút đã chi: {tongTien:N0} VNĐ.]";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return "[THÔNG TIN DỮ LIỆU: Hiện đang mất kết nối với cơ sở dữ liệu, chưa lấy được số liệu mới nhất.]";
            }
            return "";
        }

        private async Task<string> GuiTinNhanChatAI(string userMessage)
        {
            try
            {
                // 1. Lấy thông tin thống kê mới nhất từ SQL
                string thongTinThucTe = await LayThongTinHeThongAsync();

                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(2);

                    // 2. Nhồi "Luật Kế Toán" VÀ "Dữ liệu thực tế" vào đầu AI
                    string systemPrompt = $@"Bạn là Trợ lý Kế toán trưởng chuyên nghiệp của tòa soạn báo NewsPay tại Việt Nam. 
Bạn phải tuân thủ tuyệt đối các quy định sau:
1. Luật Thuế TNCN: Nếu mức chi trả TỪ 2.000.000 VNĐ TRỞ LÊN cho 1 lần trả, thì BẮT BUỘC KHẤU TRỪ 10% thuế TNCN. DƯỚI 2.000.000 VNĐ thì KHÔNG trừ thuế.
2. Luôn xưng hô là 'Tôi' và gọi người dùng là 'Đồng chí'. 

{thongTinThucTe}
Nếu người dùng hỏi về báo cáo, thống kê, tổng tiền, tổng bài viết... hãy sử dụng chính xác con số trong phần [THÔNG TIN DỮ LIỆU HIỆN TẠI] ở trên để trả lời thật tự nhiên. Tuyệt đối không tự bịa ra số liệu.

Câu hỏi của đồng chí: ";

                    var requestBody = new
                    {
                        model = aiModel,
                        prompt = systemPrompt + userMessage,
                        stream = false,
                        options = new { temperature = 0.1 } // Ép nhiệt độ cực thấp để báo cáo số liệu chuẩn 100%
                    };

                    string jsonString = JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(endpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseJson = await response.Content.ReadAsStringAsync();
                        JObject result = JObject.Parse(responseJson);
                        string answer = result["response"]?.ToString();
                        return answer.Replace("**", "");
                    }
                    else
                    {
                        return $"Ollama báo lỗi hệ thống: {response.StatusCode}";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Chưa khởi động Ollama! Đồng chí mở CMD gõ 'ollama run qwen2.5' trước nhé. Chi tiết: " + ex.Message;
            }
        }

        private void ThemBongBongChat(string tinNhan, bool isUser)
        {
            Label lbl = new Label();
            lbl.Text = tinNhan;
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(flpChat.Width - 60, 0);
            lbl.Padding = new Padding(14);
            lbl.Margin = new Padding(10, 8, 10, 8);
            lbl.Font = new Font("Segoe UI", 10.5F);

            if (isUser)
            {
                lbl.BackColor = Color.FromArgb(79, 70, 229);
                lbl.ForeColor = Color.White;
            }
            else
            {
                lbl.BackColor = Color.FromArgb(241, 245, 249);
                lbl.ForeColor = Color.FromArgb(15, 23, 42);
            }

            flpChat.Controls.Add(lbl);
            flpChat.ScrollControlIntoView(lbl);
        }

    }
}