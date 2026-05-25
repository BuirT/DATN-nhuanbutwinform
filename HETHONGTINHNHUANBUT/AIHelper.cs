using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HETHONGTINHNHUANBUT
{
    public static class AIHelper
    {
        // THAY KEY MỚI VÀO ĐÂY SAU KHI ĐÃ XÓA KEY CŨ TRÊN GOOGLE AI STUDIO
        private static readonly string apiKey = "TAIzaSyD0VAbgVQvdn3Qh-yS2r2HH1R0GdXvkfnU";
        private static readonly string endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={apiKey}";

        public static async Task<AIResult> KiemDinhBaiBaoAsync(string noiDung)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Prompt ép AI phải chấm điểm thực tế dựa trên nội dung, không lấy mặc định
                    string prompt = $@"Bạn là một tổng biên tập khó tính. Hãy đọc và phân tích bài viết dưới đây dựa trên tiêu chí: nội dung, văn phong và tính hấp dẫn.
            1. Tự đánh giá tỷ lệ đạo văn.
            2. Viết 1 câu nhận xét sắc bén.
            3. Chấm điểm chất lượng bài viết trên thang điểm từ 1.0 đến 10.0 (Tuyệt đối không lấy số 8 làm mặc định, phải chấm theo nội dung thực tế).
            
            TRẢ VỀ ĐÚNG ĐỊNH DẠNG JSON NÀY (Không thêm lời dẫn):
            {{
                ""TyLeDaoVan"": ""X%"",
                ""NhanXet"": ""Nhận xét của bạn"",
                ""DiemChatLuong"": 0.0
            }}
            
            Bài viết cần phân tích: {noiDung}";

                    var requestBody = new { contents = new[] { new { parts = new[] { new { text = prompt } } } } };
                    string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(endpoint, content);
                    string responseString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception($"API lỗi: {responseString}");

                    JObject jsonResult = JObject.Parse(responseString);
                    string rawText = jsonResult["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

                    if (string.IsNullOrEmpty(rawText)) return null;

                    // Dùng Regex để lọc lấy phần JSON sạch sẽ
                    var match = Regex.Match(rawText, @"\{.*\}", RegexOptions.Singleline);
                    if (!match.Success) throw new Exception("AI không trả về JSON hợp lệ.");

                    JObject finalData = JObject.Parse(match.Value);

                    return new AIResult
                    {
                        TyLeDaoVan = finalData["TyLeDaoVan"]?.ToString() ?? "0%",
                        NhanXet = finalData["NhanXet"]?.ToString() ?? "Không có nhận xét",
                        DiemChatLuong = finalData["DiemChatLuong"] != null ? Convert.ToDouble(finalData["DiemChatLuong"]) : 0.0
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi AI: " + ex.Message);
                return null;
            }
        }
    }

    // ĐÃ CHUYỂN RA NGOÀI KHỎI CLASS AIHELPER ĐỂ FIX LỖI CS0246
    public class AIResult
    {
        public string TyLeDaoVan { get; set; }
        public string NhanXet { get; set; }
        public double DiemChatLuong { get; set; }
    }
}