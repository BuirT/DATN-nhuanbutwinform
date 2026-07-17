using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HETHONGTINHNHUANBUT.Services.AI.Providers;

namespace HETHONGTINHNHUANBUT.Services.AI.ToolCalling
{
    public class QueryExtractorService
    {
        private readonly IAIProvider _aiProvider;

        public QueryExtractorService(IAIProvider aiProvider)
        {
            _aiProvider = aiProvider;
        }

        public async Task<QueryParameters> ExtractAsync(string userQuery)
        {
            string prompt = $@"Bạn là hệ thống trích xuất thông tin từ câu hỏi tiếng Việt. Nhiệm vụ của bạn là phân tích và trả về ĐÚNG định dạng JSON thuần, không kèm văn bản giải thích.

LƯU Ý QUAN TRỌNG:
- Nếu người dùng nhắc đến các từ ""bài"", ""bài báo"", ""bài viết"", thì ""Intent"" CHẮC CHẮN là ""BaiViet"".
- Cụm từ đi ngay sau chữ ""bài"", ""về"", ""thông tin"" thường là tên bài báo hoặc chủ đề (ví dụ: công nghệ AI trong y tế). Cho dù không có dấu ngoặc kép, hãy trích xuất toàn bộ cụm từ đó làm ""TuKhoa"".

Các trường trong JSON cần trích xuất:
- ""Intent"": Chọn MỘT giá trị: BaiViet (hỏi bài viết/bài báo), TacGia (hồ sơ tác giả), PhieuChi (phiếu chi), ThongKe (số liệu tháng/năm), CanhBao (lỗi/bất thường), DinhMuc (khung nhuận bút), General (không liên quan).
- ""TacGia"": Tên tác giả hoặc bút danh được nhắc đến. Trả về null nếu không có.
- ""Thang"": Số tháng được nhắc đến. Trả về null nếu không có.
- ""Nam"": Số năm được nhắc đến. Trả về null nếu không có.
- ""TrangThai"": Trạng thái (DaDuyet, ChoDuyet). Trả về null nếu không có.
- ""TuKhoa"": Tên bài báo, chủ đề, hoặc từ khóa tìm kiếm. Trả về null nếu không có.

Câu hỏi: ""{userQuery}""
";
            try
            {
                string jsonString = await _aiProvider.ExtractJsonAsync(prompt);
                
                // Tiền xử lý json đề phòng AI trả về dư thừa
                int startIndex = jsonString.IndexOf('{');
                int endIndex = jsonString.LastIndexOf('}');
                
                if (startIndex >= 0 && endIndex >= startIndex)
                {
                    jsonString = jsonString.Substring(startIndex, endIndex - startIndex + 1);
                    return JsonConvert.DeserializeObject<QueryParameters>(jsonString);
                }
                
                return new QueryParameters { Intent = "General" };
            }
            catch
            {
                return new QueryParameters { Intent = "General" };
            }
        }
    }
}
