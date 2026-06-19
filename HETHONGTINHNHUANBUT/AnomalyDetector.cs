using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HETHONGTINHNHUANBUT
{
    public static class AnomalyDetector
    {
        private static readonly string connStr =
            System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        private static readonly string ollamaUrl = "http://localhost:11434/api/generate";
        private static readonly string modelName = "qwen2.5";

        public class AnomalyResult
        {
            public bool CoBatThuong { get; set; }
            public string[] CanhBao { get; set; } = Array.Empty<string>();
            public MucDo MucDo { get; set; } = MucDo.BinhThuong;
        }

        public enum MucDo { BinhThuong, DeY, CanhBao, NghiemTrong }

        public static async Task<AnomalyResult> KiemTraAsync(
            string tenBai, string butDanh, string muc, decimal tien,
            string maTacGia, string nguoiNhap, string excludeMaso = null)
        {
            var result = new AnomalyResult();

            long baiTrungTen = 0;
            int bai7Ngay = 0;
            int tongBai = 0;
            int baiTheLoai = 0;
            decimal tongChiThang = 0;
            decimal mucToiDa = 0;
            bool coDinhMuc = false;

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) FROM Nhuanbut
                        WHERE Tenbai LIKE @tenBai AND TrangThaiDuyet >= 0" +
                        (string.IsNullOrEmpty(excludeMaso) ? "" : " AND Maso != @excludeMaso"), conn))
                    {
                        cmd.Parameters.AddWithValue("@tenBai", "%" + tenBai.Replace(" ", "%") + "%");
                        if (!string.IsNullOrEmpty(excludeMaso))
                            cmd.Parameters.AddWithValue("@excludeMaso", excludeMaso);
                        baiTrungTen = (long)await cmd.ExecuteScalarAsync();
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) FROM Nhuanbut
                        WHERE Butdanh = @butDanh AND ngaychuyen >= DATEADD(DAY, -7, GETDATE())", conn))
                    {
                        cmd.Parameters.AddWithValue("@butDanh", butDanh);
                        bai7Ngay = (int)await cmd.ExecuteScalarAsync();
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) FROM Nhuanbut WHERE Butdanh = @butDanh", conn))
                    {
                        cmd.Parameters.AddWithValue("@butDanh", butDanh);
                        tongBai = (int)await cmd.ExecuteScalarAsync();
                    }

                    if (!string.IsNullOrEmpty(muc))
                    {
                        using (var cmd = new SqlCommand(@"
                            SELECT COUNT(*) FROM Nhuanbut
                            WHERE Butdanh = @butDanh AND Muc = @muc", conn))
                        {
                            cmd.Parameters.AddWithValue("@butDanh", butDanh);
                            cmd.Parameters.AddWithValue("@muc", muc);
                            baiTheLoai = (int)await cmd.ExecuteScalarAsync();
                        }

                        using (var cmd = new SqlCommand(@"SELECT MucToiDa FROM DinhMuc WHERE Muc = @muc", conn))
                        {
                            cmd.Parameters.AddWithValue("@muc", muc);
                            var dbResult = await cmd.ExecuteScalarAsync();
                            if (dbResult != null)
                            {
                                mucToiDa = Convert.ToDecimal(dbResult);
                                coDinhMuc = true;
                            }
                        }
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT ISNULL(SUM(TienNhuanbut),0) FROM Nhuanbut
                        WHERE MONTH(ngaychuyen)=MONTH(GETDATE()) AND YEAR(ngaychuyen)=YEAR(GETDATE())
                        AND TrangThaiDuyet >= 0", conn))
                    {
                        tongChiThang = (decimal)await cmd.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[AnomalyDetector] DB error: {ex.Message}");
            }

            try
            {
                string prompt = $@"Bạn là chuyên gia kiểm toán nội bộ hệ thống tính nhuận bút. Hãy phân tích dữ liệu dưới đây và phát hiện bất thường (nếu có).

THÔNG TIN BÀI VIẾT ĐANG DUYỆT:
- Tên bài: ""{tenBai}""
- Bút danh: ""{butDanh}""
- Thể loại (Mục): ""{muc}""
- Tiền nhuận bút đề xuất: {tien:N0}đ

THỐNG KÊ TỪ HỆ THỐNG:
- Số bài có tên tương tự trong CSDL: {baiTrungTen}
- Số bài tác giả nộp trong 7 ngày qua: {bai7Ngay}
- Tổng số bài tác giả đã nộp từ trước: {tongBai}
- Số bài tác giả đã viết thể loại này: {baiTheLoai}
- Tổng chi nhuận bút tháng này (chưa gồm bài này): {tongChiThang:N0}đ
- Định mức tối đa của thể loại '{muc}': {(coDinhMuc ? mucToiDa.ToString("N0") + "đ" : "Không có")}

YÊU CẦU:
Phân tích các khía cạnh sau:
1. Tên bài có khả năng trùng lặp với bài khác không? (dựa vào ngữ nghĩa, context)
2. Tác giả có nộp bài quá thường xuyên so với bình thường không?
3. Tiền nhuận bút có hợp lý so với định mức và lịch sử tác giả không?
4. Tác giả có đang viết thể loại lạ so với lịch sử không?
5. Ngân sách tháng có bị ảnh hưởng không?

Trả về KẾT QUẢ DUY NHẤT dưới dạng JSON (tuyệt đối không thêm ký tự nào ngoài JSON):
{{
    ""coBatThuong"": true/false,
    ""mucDo"": ""BinhThuong"", ""DeY"", ""CanhBao"", ""NghiemTrong"",
    ""canhBao"": [""mô tả cảnh báo 1"", ""mô tả cảnh báo 2""],
    ""giaiThich"": ""tóm tắt ngắn gọn kết luận""
}}

QUY TẮC:
- Chỉ đánh giá coBatThuong=true nếu có dấu hiệu thực sự bất thường.
- Mảng canhBao có thể rỗng nếu không có cảnh báo.
- Dùng tiếng Việt 100%, rõ ràng, ngắn gọn.
- Không thêm bất kỳ chữ nào ngoài JSON.";

                var requestBody = new
                {
                    model = modelName,
                    prompt = prompt,
                    stream = false,
                    options = new
                    {
                        temperature = 0.0,
                        top_p = 0.1
                    }
                };

                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    string jsonString = JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(ollamaUrl, content);
                    string responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        JObject jsonResult = JObject.Parse(responseString);
                        string rawText = jsonResult["response"]?.ToString();

                        if (!string.IsNullOrEmpty(rawText))
                        {
                            var match = Regex.Match(rawText, @"\{[\s\S]*\}", RegexOptions.Multiline);
                            if (match.Success)
                            {
                                JObject aiData = JObject.Parse(match.Value);
                                bool coBatThuong = aiData["coBatThuong"]?.Value<bool>() ?? false;
                                string mucDoStr = aiData["mucDo"]?.ToString() ?? "BinhThuong";
                                var canhBaoArr = aiData["canhBao"]?.ToObject<string[]>() ?? Array.Empty<string>();

                                result.CoBatThuong = coBatThuong;
                                switch (mucDoStr)
                                {
                                    case "DeY": result.MucDo = MucDo.DeY; break;
                                    case "CanhBao": result.MucDo = MucDo.CanhBao; break;
                                    case "NghiemTrong": result.MucDo = MucDo.NghiemTrong; break;
                                    default: result.MucDo = MucDo.BinhThuong; break;
                                }
                                result.CanhBao = canhBaoArr;
                            }
                        }
                    }
                }
            }
            catch
            {
                // AI offline — fallback silent, không cảnh báo
            }

            return result;
        }
    }
}
