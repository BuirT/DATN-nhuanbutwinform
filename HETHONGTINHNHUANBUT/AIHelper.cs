using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HETHONGTINHNHUANBUT
{
    public static class AIHelper
    {
        // Chạy thẳng ở máy nội bộ, vĩnh biệt API Key, vĩnh biệt lỗi mạng!
        private static readonly string endpoint = "http://localhost:11434/api/generate";
        // Khai báo đúng tên con AI đồng chí vừa tải ở Giai đoạn 1
        private static readonly string aiModel = "qwen2.5";

        public static async Task<AIResult> KiemDinhBaiBaoAsync(string noiDung)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(3); // AI chạy offline có thể lâu hơn cloud, cho nó 3 phút suy nghĩ

                string prompt = $@"Bạn là một tổng biên tập khó tính. Hãy đọc và phân tích bài viết dưới đây.
        1. Đánh giá tỷ lệ đạo văn.
        2. Viết 1 câu nhận xét sắc bén.
        3. Chấm điểm chất lượng bài viết trên thang điểm từ 1.0 đến 10.0 (Tuyệt đối không lấy số 8 làm mặc định, phải chấm theo nội dung thực tế).
        
        Trả về KẾT QUẢ DUY NHẤT DƯỚI DẠNG JSON với cấu trúc chính xác như sau (không thêm bất kỳ ký tự nào khác):
        {{
            ""TyLeDaoVan"": ""..."",
            ""NhanXet"": ""..."",
            ""DiemChatLuong"": ...
        }}
        
        Nội dung bài viết: {noiDung}";

                var requestBody = new
                {
                    model = aiModel,
                    prompt = prompt,
                    stream = false,
                    // 🔥 THÊM ĐOẠN NÀY VÀO: Ép AI làm việc như cái máy tính, không được có "cảm xúc"
                    options = new
                    {
                        temperature = 0.0,   // Khóa chặt tính ngẫu nhiên
                        top_p = 0.1          // Siết chặt độ nhất quán của từ vựng
                    }
                };

                string jsonString = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                string responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Không thể kết nối đến Ollama. Hãy chắc chắn bảng CMD đang chạy. Mã lỗi: {response.StatusCode}");
                }

                JObject jsonResult = JObject.Parse(responseString);
                string rawText = jsonResult["response"]?.ToString();

                if (string.IsNullOrEmpty(rawText)) throw new Exception("AI chạy thành công nhưng không trả về chữ nào.");

                var match = Regex.Match(rawText, @"\{[\s\S]*\}", RegexOptions.Multiline);
                if (!match.Success) throw new Exception($"AI không xuất ra chuẩn JSON. Dữ liệu thực tế: \n{rawText}");

                JObject finalData = JObject.Parse(match.Value);

                return new AIResult
                {
                    TyLeDaoVan = finalData["TyLeDaoVan"]?.ToString() ?? "0%",
                    NhanXet = finalData["NhanXet"]?.ToString() ?? "Không có nhận xét",
                    DiemChatLuong = finalData["DiemChatLuong"] != null ? Convert.ToDouble(finalData["DiemChatLuong"]) : 0.0
                };
            }
        }
    }

    public class AIResult
    {
        public string TyLeDaoVan { get; set; }
        public string NhanXet { get; set; }
        public double DiemChatLuong { get; set; }
    }
}