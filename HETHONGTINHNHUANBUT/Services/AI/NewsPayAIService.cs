using System;
using System.Threading.Tasks;
using HETHONGTINHNHUANBUT.Services.AI.Memory;
using HETHONGTINHNHUANBUT.Services.AI.Providers;
using HETHONGTINHNHUANBUT.Services.AI.RAG;
using HETHONGTINHNHUANBUT.Services.AI.ToolCalling;

namespace HETHONGTINHNHUANBUT.Services.AI
{
    public class NewsPayAIService
    {
        private readonly IAIProvider _aiProvider;
        private readonly ConversationMemory _memory;
        private readonly RAGService _ragService;
        private readonly ToolCallingRouter _router;

        private const string KIEN_THUC_HE_THONG = @"
【QUY TRÌNH NGHIỆP VỤ NEWSPAY】
- Bài viết trải qua 5 bước duyệt:
  Bước 1: Thư ký chấm tiền (TrangThaiDuyet: 0→1)
  Bước 2: Kế toán nhập liệu nhuận bút (TrangThaiDuyet: 1→2)
  Bước 3: Kiểm tra viên kiểm tra (TrangThaiDuyet: 2→3)
  Bước 4: Tổng thư ký ký duyệt (TrangThaiDuyet: 3→4)
  Bước 5: Lập phiếu chi → Lãnh đạo duyệt chi → Thanh toán

【CÁC VAI TRÒ HỆ THỐNG】
- Phóng viên (PV): Nộp bài, tra cứu thu nhập
- Thư ký: Chấm tiền bài viết
- Kế toán: Nhập liệu nhuận bút, quản lý phiếu chi
- Kiểm tra viên: Kiểm tra số liệu
- Tổng thư ký: Ký duyệt bài
- Lãnh đạo: Ký duyệt phiếu chi
- Admin/Quản trị viên: Quản lý toàn bộ hệ thống

【CÁC TÍNH NĂNG CHÍNH】
- Nộp bài: Phóng viên nhập thông tin bài, AI kiểm toán metadata
- Kiểm duyệt: Duyệt qua 4 bước với phân quyền rõ ràng
- Tra cứu: Xem thu nhập cá nhân, trạng thái bài
- Báo cáo: Xuất Excel, biểu đồ, báo cáo AI tự động
- Phiếu chi: Lập phiếu, tính thuế TNCN 10% nếu >= 2.000.000đ
- Quản lý: Tác giả, bút danh, số báo, thể loại, tài khoản

【CÁCH TÍNH THUẾ】
- Nếu tổng tiền chi CHO MỘT LẦN trả từ 2.000.000đ trở lên: KHẤU TRỪ 10% thuế TNCN
- Dưới 2.000.000đ: KHÔNG khấu trừ thuế

【ĐỊNH MỨC NHUẬN BÚT】
- Tin vắn: tối đa 500.000đ
- Phân tích: tối đa 3.000.000đ
- Phỏng vấn: tối đa 2.500.000đ
- Bài định: tối đa 4.000.000đ
- Xã luận: tối đa 5.000.000đ
- Phóng sự: tối đa 3.000.000đ
- Các thể loại khác: tối đa 2.000.000đ";

        public NewsPayAIService(string ollamaEndpoint, string modelName, string dbConnectionString)
        {
            _aiProvider = new OllamaProvider(ollamaEndpoint, modelName);
            _memory = new ConversationMemory(10);
            _ragService = new RAGService(dbConnectionString);
            var extractor = new QueryExtractorService(_aiProvider);
            _router = new ToolCallingRouter(_ragService, extractor);
        }

        public async Task<string> ProcessUserQueryAsync(string userMessage)
        {
            try
            {
                string lower = userMessage.ToLower();

                if (LaLoiChao(lower)) return LayLoiChaoTroLy();
                if (TryLayPhanHoiXaGiao(lower, out string phanHoiXaGiao)) return phanHoiXaGiao;
                
                if (!LaCauHoiTrongPhamViHeThong(lower))
                {
                    return "Tôi chỉ hỗ trợ các câu hỏi liên quan đến hệ thống NewsPay: nhuận bút, bài viết, tác giả, bút danh, phiếu chi, thanh toán, thuế TNCN, báo cáo, cảnh báo AI, kiểm duyệt và dữ liệu nghiệp vụ trong hệ thống. Vui lòng đặt câu hỏi trong phạm vi này.";
                }

                if (LaCauHoiCachTinhThue(lower)) return LayHuongDanTinhThueTncn();

                // Bước 1: Routing & RAG
                var (dataContext, chuDe) = await _router.RouteQueryAsync(userMessage);

                // Bước 2: Lấy ngữ cảnh hội thoại từ Memory
                string lichSu = _memory.GetContextString();

                // Bước 3: Đóng gói Prompt
                string prompt = BuildPrompt(chuDe, dataContext, lichSu, userMessage);

                // Bước 4: Gọi AI Provider
                string aiResponse = await _aiProvider.GenerateResponseAsync(prompt);

                // Bước 5: Cập nhật Memory
                _memory.AddUserMessage(userMessage);
                _memory.AddAIMessage(aiResponse);

                return aiResponse;
            }
            catch (Exception ex)
            {
                return $"⚠️ Lỗi hệ thống: {ex.Message}";
            }
        }

        public void ClearMemory()
        {
            _memory.Clear();
        }

        private bool LaLoiChao(string lower)
        {
            string text = lower.Trim();
            string[] loiChao = { "hi", "hello", "hey", "alo", "xin chào", "xin chao", "chào", "chao", "chào bạn", "chao ban", "chào ai", "chao ai", "chào trợ lý", "chao tro ly", "good morning", "good afternoon", "good evening" };
            foreach (string cauChao in loiChao) { if (text == cauChao) return true; }
            return false;
        }

        private string LayLoiChaoTroLy()
        {
            return "Xin chào! Tôi là Trợ lý AI NewsPay. Tôi có thể hỗ trợ bạn về nhuận bút, bài viết, tác giả, bút danh, phiếu chi, thanh toán, thuế TNCN, báo cáo, cảnh báo AI và quy trình kiểm duyệt trong hệ thống.";
        }

        private bool TryLayPhanHoiXaGiao(string lower, out string phanHoi)
        {
            string text = lower.Trim();
            if (text == "cảm ơn" || text == "cam on" || text == "thanks" || text == "thank you" || text == "ok cảm ơn" || text == "ok cam on")
            {
                phanHoi = "Rất vui được hỗ trợ bạn. Nếu cần, bạn có thể hỏi tôi về nhuận bút, phiếu chi, báo cáo, cảnh báo AI hoặc quy trình kiểm duyệt trong NewsPay.";
                return true;
            }
            if (text == "tạm biệt" || text == "tam biet" || text == "bye" || text == "goodbye" || text == "hẹn gặp lại" || text == "hen gap lai")
            {
                phanHoi = "Tạm biệt! Khi cần tra cứu dữ liệu hoặc nghiệp vụ trong NewsPay, bạn cứ mở Trợ lý AI để hỏi tiếp.";
                return true;
            }
            if (text == "bạn là ai" || text == "ban la ai" || text == "bạn là gì" || text == "ban la gi" || text == "trợ lý là ai" || text == "tro ly la ai")
            {
                phanHoi = "Tôi là Trợ lý AI NewsPay, hỗ trợ các câu hỏi liên quan đến hệ thống quản lý nhuận bút: bài viết, tác giả, phiếu chi, thanh toán, thuế TNCN, báo cáo, cảnh báo AI và quy trình kiểm duyệt.";
                return true;
            }
            if (text == "bạn giúp được gì" || text == "ban giup duoc gi" || text == "bạn làm được gì" || text == "ban lam duoc gi" || text == "help" || text == "hỗ trợ gì" || text == "ho tro gi")
            {
                phanHoi = "Tôi có thể hỗ trợ bạn trong NewsPay: xem tổng quan hệ thống, tra cứu tác giả/bài viết, thống kê nhuận bút, kiểm tra phiếu chi, giải thích thuế TNCN, xem định mức, cảnh báo bất thường và hướng dẫn quy trình kiểm duyệt.";
                return true;
            }
            phanHoi = null;
            return false;
        }

        private bool LaCauHoiCachTinhThue(string lower)
        {
            bool coNoiDungThue = lower.Contains("thuế") || lower.Contains("thue") || lower.Contains("tncn");
            if (!coNoiDungThue) return false;
            bool hoiCongThuc = lower.Contains("tính") || lower.Contains("tinh") || lower.Contains("cách") || lower.Contains("cach") || lower.Contains("công thức") || lower.Contains("cong thuc") || lower.Contains("khấu trừ") || lower.Contains("khau tru") || lower.Contains("phần trăm") || lower.Contains("phan tram") || lower.Contains("%") || lower.Contains("như thế nào") || lower.Contains("nhu the nao");
            bool hoiSoLieu = lower.Contains("tổng thuế") || lower.Contains("tong thue") || lower.Contains("tổng số thuế") || lower.Contains("tong so thue") || lower.Contains("thuế tháng") || lower.Contains("thue thang") || lower.Contains("thuế năm") || lower.Contains("thue nam") || lower.Contains("hiện tại") || lower.Contains("hien tai") || lower.Contains("đã khấu trừ") || lower.Contains("da khau tru");
            return hoiCongThuc && !hoiSoLieu;
        }

        private string LayHuongDanTinhThueTncn()
        {
            return "Trong hệ thống NewsPay, thuế TNCN được tính theo từng lần lập phiếu chi:\n- Nếu tổng tiền chi trả từ 2.000.000đ trở lên: khấu trừ 10% thuế TNCN.\n- Nếu tổng tiền chi trả dưới 2.000.000đ: không khấu trừ thuế.\n- Số tiền thực lĩnh = Tổng nhuận bút - Thuế TNCN.";
        }

        private bool LaCauHoiTrongPhamViHeThong(string lower)
        {
            string[] tuKhoaHeThong = { "newspay", "hệ thống", "phần mềm", "chức năng", "menu", "dữ liệu", "database", "nhuận bút", "nhuan but", "bài", "bài viết", "báo", "số báo", "loại báo", "tác giả", "tac gia", "phóng viên", "phong vien", "cộng tác viên", "ctv", "bút danh", "but danh", "phiếu chi", "phieu chi", "thanh toán", "thanh toan", "thuế", "thue", "tncn", "duyệt", "duyet", "kiểm duyệt", "kiem duyet", "kiểm tra", "kiem tra", "lãnh đạo", "lanh dao", "kế toán", "ke toan", "thư ký", "thu ky", "tổng thư ký", "tong thu ky", "tài khoản", "tai khoan", "đăng nhập", "dang nhap", "báo cáo", "bao cao", "thống kê", "thong ke", "dashboard", "excel", "công nợ", "cong no", "cảnh báo", "canh bao", "bất thường", "bat thuong", "rủi ro", "rui ro", "định mức", "dinh muc", "tiền", "tien", "chi trả", "chi tra", "trạng thái", "trang thai", "quy trình", "quy trinh", "nhập bài", "nhap bai", "tra cứu", "tra cuu", "vai trò", "vai tro", "quyền", "quyen", "tháng", "năm", "quý", "vậy", "nhất", "thấp", "ít", "cao", "nhiều" };
            foreach (string tuKhoa in tuKhoaHeThong) { if (lower.Contains(tuKhoa)) return true; }
            return false;
        }

        private string BuildPrompt(string chuDe, string dataContext, string lichSu, string userMessage)
        {
            return $@"Bạn là chuyên gia tư vấn về nhuận bút báo chí và Trợ lý AI của hệ thống NewsPay.

Bạn đang hỏi về: {chuDe}

KIẾN THỨC NỀN TẢNG VỀ HỆ THỐNG NEWSPAY:
{KIEN_THUC_HE_THONG}

DỮ LIỆU THỰC TẾ TỪ HỆ THỐNG ĐỂ TRẢ LỜI CÂU HỎI (nếu có):
{dataContext}

LỊCH SỬ TRÒ CHUYỆN (Ngữ cảnh):
{lichSu}

Hướng dẫn trả lời:
- Ưu tiên dùng DỮ LIỆU THỰC TẾ TỪ HỆ THỐNG ở trên để trả lời nếu có thông tin liên quan.
- Dựa vào KIẾN THỨC NỀN TẢNG để trả lời các câu hỏi chung về quy trình, định mức, vai trò, cách tính thuế, thông tin hồ sơ hệ thống nếu Dữ liệu thực tế báo Không tìm thấy.
- Dựa vào lịch sử trò chuyện để hiểu các từ như 'vậy', 'thì sao', 'còn', hoặc các câu hỏi nối tiếp.
- Nếu câu hỏi không liên quan đến hệ thống NewsPay hoặc nghiệp vụ nhuận bút, không được dùng kiến thức chung để trả lời.
- Trả lời bằng tiếng Việt, chuyên nghiệp, dễ hiểu.

QUY TẮC PHẠM VI BẮT BUỘC:
- Chỉ trả lời nội dung liên quan trực tiếp đến hệ thống NewsPay, dữ liệu nghiệp vụ trong hệ thống, nhuận bút, bài viết, tác giả, hồ sơ tác giả, phiếu chi, thanh toán, thuế TNCN, báo cáo, cảnh báo AI, kiểm duyệt, phân quyền.
- Không trả lời câu hỏi ngoài phạm vi như thời tiết, giải trí, lập trình chung, học tập, tin tức, đời sống, hay chủ đề không liên quan NewsPay.
- Nếu câu hỏi ngoài phạm vi, chỉ trả lời đúng một câu: ""Tôi chỉ hỗ trợ các câu hỏi liên quan đến hệ thống NewsPay và nghiệp vụ nhuận bút. Vui lòng đặt câu hỏi trong phạm vi này.""

Câu hỏi: {userMessage}";
        }
    }
}
