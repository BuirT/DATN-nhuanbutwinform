using System;
using System.Collections.Generic;
using System.Linq;
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
        private static readonly string baseUrl = "http://localhost:11434";
        private static readonly string aiModel = "qwen2.5";

        public static async Task<string> ChatVoiTroLyAIAsync(string cauHoiCuaUser)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(3);

                string fullPrompt = $@"<|system|>
Bạn là Trợ lý AI Kế toán nội bộ trực thuộc hệ thống NewsPay. Bạn nắm rất rõ giao diện và các chức năng của hệ thống này. Giọng điệu trả lời chuyên nghiệp, lịch sự nhưng gần gũi. Luôn xưng hô là 'tôi' và gọi người dùng là 'đồng chí'. BẮT BUỘC TRẢ LỜI BẰNG TIẾNG VIỆT 100%.

Dưới đây là sơ đồ tính năng chuẩn trên hệ thống NewsPay mà bạn PHẢI dùng để hướng dẫn người dùng:
- Nếu hỏi về xem dữ liệu tổng quát: Hướng dẫn vào menu 'DASHBOARD HỆ THỐNG'.
- Nếu hỏi về duyệt tiền hoặc duyệt phiếu chi: Hướng dẫn vào menu 'LÃNH ĐẠO DUYỆT CHI'.
- Nếu hỏi về lập phiếu chi tiền cho tác giả: Hướng dẫn vào menu 'LẬP PHIẾU CHI'.
- Nếu hỏi về xuất file báo cáo tháng ra Excel: Hướng dẫn người dùng nhìn sang menu bên trái, bấm vào tab 'BÁO CÁO TỔNG HỢP'. Tại giao diện hiện ra, chọn tháng cần xem ở mục 'Chọn tháng', nhấn nút 'TÌM KIẾM' màu xanh, rồi cuối cùng bấm vào nút 'XUẤT EXCEL' màu cam ở góc trên để tải file về máy.

QUY TẮC NGHIÊM NGẶT:
1. Tuyệt đối KHÔNG ĐƯỢC yêu cầu người dùng đi liên hệ bộ phận kỹ thuật, quản trị viên hay phần mềm ERP của bên nào khác. Hệ thống NewsPay có sẵn tính năng này.
2. Trả lời đi thẳng vào vấn đề, ngắn gọn, hướng dẫn chính xác các bước trên.

<|user|>
{cauHoiCuaUser}

<|assistant|>";

                var requestBody = new
                {
                    model = aiModel,
                    prompt = fullPrompt,
                    stream = false,
                    options = new
                    {
                        temperature = 0.3,
                        top_p = 0.3
                    }
                };

                string jsonString = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{baseUrl}/api/generate", content);
                string responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Lỗi kết nối Trợ lý AI: {response.StatusCode}");
                }

                JObject jsonResult = JObject.Parse(responseString);
                string aiReply = jsonResult["response"]?.ToString();

                return string.IsNullOrEmpty(aiReply) ? "Xin lỗi đồng chí, hiện tại tôi đang bận xử lý dữ liệu, vui lòng thử lại sau." : aiReply.Trim();
            }
        }

        public static async Task<AIKiemToanResult> KiemTraMetadataNhapLieuAsync(
            string tenBai, string muc, string butDanh, string[] danhSachBaiHomNay)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(2);

                string dsBai = danhSachBaiHomNay != null && danhSachBaiHomNay.Length > 0
                    ? string.Join("\n", danhSachBaiHomNay)
                    : "(Không có bài nào trong hôm nay)";

                string prompt = $@"Bạn là một biên tập viên giàu kinh nghiệm. Nhiệm vụ của bạn là rà soát tính hợp lý của thông tin nhập liệu dưới đây.

THÔNG TIN NHẬP VÀO:
- Tên bài: ""{tenBai}""
- Mục (Thể loại): ""{muc}""
- Bút danh: ""{butDanh}""

DANH SÁCH BÀI ĐÃ NHẬP HÔM NAY (cùng tác giả):
{dsBai}

Hãy phân tích và trả về KẾT QUẢ DUY NHẤT DƯỚI DẠNG JSON như sau (không thêm bất kỳ ký tự nào khác):
{{
    ""canhBaoTheLoai"": ""(trả về chuỗi rỗng nếu ổn, hoặc mô tả nếu tên bài không phù hợp với thể loại)"",
    ""canhBaoTrungBai"": ""(trả về chuỗi rỗng nếu không trùng, hoặc tên bài bị nghi ngờ trùng nếu có)"",
    ""tomTat"": ""(một câu tóm tắt ngắn gọn kết quả kiểm tra)""
}}

QUY TẮC:
1. canhBaoTheLoai: Chỉ cảnh báo nếu tên bài RÕ RÀNG không phù hợp với mục/ thể loại. Ví dụ bài phân tích sâu mà để mục 'Tin vắn' là sai. Nếu hợp lý thì để chuỗi rỗng.
2. canhBaoTrungBai: So sánh ngữ nghĩa tên bài nhập với danh sách bài hôm nay. Nếu có bài nào cùng chủ đề, cùng tác giả thì cảnh báo. Nếu không thì để chuỗi rỗng.
3. TUYỆT ĐỐI trả lời 100% BẰNG TIẾNG VIỆT.
4. KHÔNG ĐƯỢC thêm bất kỳ chữ nào ngoài JSON.";

                var requestBody = new
                {
                    model = aiModel,
                    prompt = prompt,
                    stream = false,
                    options = new
                    {
                        temperature = 0.0,
                        top_p = 0.1
                    }
                };

                string jsonString = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{baseUrl}/api/generate", content);
                string responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Lỗi kết nối AI Kiểm Toán: {response.StatusCode}");

                JObject jsonResult = JObject.Parse(responseString);
                string rawText = jsonResult["response"]?.ToString();

                if (string.IsNullOrEmpty(rawText))
                    throw new Exception("AI không trả về kết quả.");

                var match = Regex.Match(rawText, @"\{[\s\S]*\}", RegexOptions.Multiline);
                if (!match.Success)
                    throw new Exception($"AI không xuất JSON. Dữ liệu: {rawText}");

                JObject data = JObject.Parse(match.Value);

                return new AIKiemToanResult
                {
                    CanhBaoTheLoai = data["canhBaoTheLoai"]?.ToString() ?? "",
                    CanhBaoTrungBai = data["canhBaoTrungBai"]?.ToString() ?? "",
                    TomTat = data["tomTat"]?.ToString() ?? ""
                };
            }
        }
    }

    public class AIKiemToanResult
    {
        public string CanhBaoTheLoai { get; set; }
        public string CanhBaoTrungBai { get; set; }
        public string TomTat { get; set; }
    }
}
