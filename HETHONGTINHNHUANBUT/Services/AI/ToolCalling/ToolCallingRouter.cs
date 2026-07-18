using System;
using System.Threading.Tasks;
using HETHONGTINHNHUANBUT.Services.AI.RAG;

namespace HETHONGTINHNHUANBUT.Services.AI.ToolCalling
{
    public class ToolCallingRouter
    {
        private readonly RAGService _ragService;
        private readonly QueryExtractorService _extractorService;

        public ToolCallingRouter(RAGService ragService, QueryExtractorService extractorService)
        {
            _ragService = ragService;
            _extractorService = extractorService;
        }

        public async Task<(string DataContext, string ChuDe)> RouteQueryAsync(string userQuery)
        {
            // 1. Trích xuất thông số
            var param = await _extractorService.ExtractAsync(userQuery);
            
            string dataContext = null;
            string chuDe = "hệ thống";

            // 2. Thử truy vấn động trước
            if (param.Intent != "General")
            {
                dataContext = await _ragService.ExecuteDynamicQueryAsync(param);
                chuDe = param.Intent;
            }

            // 3. Fallback về truy vấn tĩnh nếu truy vấn động trả về null
            if (dataContext == null)
            {
                string lower = userQuery.ToLower();
                if (lower.Contains("tháng") || lower.Contains("quý") || lower.Contains("năm") || lower.Contains("202"))
                {
                    dataContext = await _ragService.GetMonthlyStatsAsync(userQuery);
                    chuDe = "thống kê tháng";
                }
                else if (lower.Contains("tác giả") || lower.Contains("phóng viên") || lower.Contains("người viết") || lower.Contains("ai viết"))
                {
                    string searchKeyword = !string.IsNullOrEmpty(param.TacGia) ? param.TacGia : userQuery;
                    dataContext = await _ragService.GetAuthorInfoAsync(searchKeyword);
                    chuDe = "tác giả";
                }
                else if (lower.Contains("phiếu chi") || lower.Contains("thuế") || lower.Contains("thanh toán") || lower.Contains("đã chi"))
                {
                    dataContext = await _ragService.GetPaymentSlipInfoAsync();
                    chuDe = "phiếu chi";
                }
                else if (lower.Contains("bất thường") || lower.Contains("kiểm tra") || lower.Contains("cảnh báo") || lower.Contains("rủi ro"))
                {
                    dataContext = await _ragService.GetAnomaliesAsync();
                    chuDe = "bất thường";
                }
                else if (lower.Contains("định mức") || lower.Contains("tối đa") || lower.Contains("khung") || lower.Contains("thể loại"))
                {
                    dataContext = await _ragService.GetLimitsAsync();
                    chuDe = "định mức";
                }
                else
                {
                    dataContext = await _ragService.GetSystemOverviewAsync();
                    chuDe = "hệ thống";
                }
            }

            if (string.IsNullOrEmpty(dataContext))
            {
                dataContext = "(Không có dữ liệu phù hợp)";
            }

            return (dataContext, chuDe);
        }
    }
}
