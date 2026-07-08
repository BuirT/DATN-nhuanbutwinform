using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HETHONGTINHNHUANBUT
{
    public class AIDashboardService
    {
        private readonly string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public async Task<DashboardData> GetDashboardDataAsync()
        {
            var data = new DashboardData();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();

                    // KPIs
                    data.TongBaiViet = Convert.ToInt32(await ExecuteScalarAsync(conn, "SELECT COUNT(*) FROM Nhuanbut"));
                    data.TongPhongVien = Convert.ToInt32(await ExecuteScalarAsync(conn, "SELECT COUNT(DISTINCT Butdanh) FROM Nhuanbut"));
                    data.TongNhuanBut = Convert.ToDecimal(await ExecuteScalarAsync(conn, "SELECT ISNULL(SUM(TienNhuanbut), 0) FROM Nhuanbut WHERE TrangThaiDuyet >= 0"));
                    data.TongBaiChuaDuyet = Convert.ToInt32(await ExecuteScalarAsync(conn, "SELECT COUNT(*) FROM Nhuanbut WHERE TrangThaiDuyet = 0"));
                    data.TongPhieuChi = Convert.ToInt32(await ExecuteScalarAsync(conn, "SELECT COUNT(*) FROM PhieuChi"));
                    data.TongCanhBao = Convert.ToInt32(await ExecuteScalarAsync(conn, "SELECT COUNT(*) FROM AICanhBao WHERE DaXuLy = 0"));
                    data.TongTacGia = Convert.ToInt32(await ExecuteScalarAsync(conn, "SELECT COUNT(*) FROM TacGia"));
                    data.TongLoaiBai = Convert.ToInt32(await ExecuteScalarAsync(conn, "SELECT COUNT(*) FROM LoaiBao"));

                    using (SqlCommand cmd = new SqlCommand("SELECT MIN(ngaychuyen), MAX(ngaychuyen) FROM Nhuanbut", conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        if (await r.ReadAsync())
                        {
                            string min = r[0] != DBNull.Value ? Convert.ToDateTime(r[0]).ToString("MM/yyyy") : "...";
                            string max = r[1] != DBNull.Value ? Convert.ToDateTime(r[1]).ToString("MM/yyyy") : "...";
                            data.KhoangThoiGian = $"Từ {min} đến {max}";
                        }
                        else
                        {
                            data.KhoangThoiGian = "Không xác định";
                        }
                    }

                    // Thống kê theo tháng
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT TOP 6 YEAR(ngaychuyen) AS Nam, MONTH(ngaychuyen) AS Thang, ISNULL(SUM(TienNhuanbut), 0) AS Tong
                        FROM Nhuanbut WHERE TrangThaiDuyet >= 0 GROUP BY YEAR(ngaychuyen), MONTH(ngaychuyen) ORDER BY Nam DESC, Thang DESC", conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            data.ThongKeTheoThang.Add($"T{r["Thang"]}/{r["Nam"]}", Convert.ToDouble(r["Tong"]));
                        }
                    }

                    // Top PV
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT TOP 10 Butdanh, ISNULL(SUM(TienNhuanbut), 0) AS Tong
                        FROM Nhuanbut WHERE TrangThaiDuyet >= 0 GROUP BY Butdanh ORDER BY Tong DESC", conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            data.TopPhongVien.Add(r["Butdanh"]?.ToString() ?? "", Convert.ToDouble(r["Tong"]));
                        }
                    }

                    // Tỉ lệ bài theo chuyên mục
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT Muc, COUNT(*) AS SoBai
                        FROM Nhuanbut WHERE TrangThaiDuyet >= 0 GROUP BY Muc ORDER BY SoBai DESC", conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            data.TiLeChuyenMuc.Add(r["Muc"]?.ToString() ?? "", Convert.ToInt32(r["SoBai"]));
                        }
                    }

                    // Điểm AI
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT Muc, AVG(DiemChatLuongAI) AS DiemTB
                        FROM Nhuanbut WHERE DiemChatLuongAI IS NOT NULL AND TrangThaiDuyet >= 0
                        GROUP BY Muc HAVING AVG(DiemChatLuongAI) > 0 ORDER BY DiemTB DESC", conn))
                    using (SqlDataReader r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            data.DiemAITrungBinh.Add(r["Muc"]?.ToString() ?? "", Convert.ToDouble(r["DiemTB"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetDashboardDataAsync: " + ex.Message);
            }

            return data;
        }

        private async Task<object> ExecuteScalarAsync(SqlConnection conn, string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                object result = await cmd.ExecuteScalarAsync();
                return result ?? 0;
            }
        }

        public async Task<(string aiReply, AIAnalysisInfo info)> AnalyzeDashboardAsync(DashboardData data)
        {
            var info = new AIAnalysisInfo
            {
                ThoiGianPhanTich = DateTime.Now,
                MoHinhAI = AIConfig.OllamaModel,
                NguonDuLieu = "Dashboard SQL Server"
            };

            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(5);

                string prompt = GeneratePrompt(data);

                var requestBody = new
                {
                    model = AIConfig.OllamaModel,
                    prompt = prompt,
                    stream = false,
                    options = new
                    {
                        temperature = 0.3,
                        top_p = 0.5
                    }
                };

                string jsonString = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(AIConfig.GenerateUrl, content);
                string responseString = await response.Content.ReadAsStringAsync();

                sw.Stop();
                info.ThoiGianXuLyGiay = Math.Round(sw.Elapsed.TotalSeconds, 2);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Lỗi kết nối Trợ lý AI: {response.StatusCode}");
                }

                JObject jsonResult = JObject.Parse(responseString);
                string aiReply = jsonResult["response"]?.ToString();

                string finalReply = string.IsNullOrEmpty(aiReply) ? "Không có kết quả phân tích từ AI." : aiReply.Trim();
                return (finalReply, info);
            }
        }

        public string AppendAIDisclaimer(string aiResponse)
        {
            string disclaimer = @"
=================================================
⚠️ LƯU Ý
Kết quả trên được Trợ lý Trí tuệ Nhân tạo (AI) tổng hợp từ dữ liệu Dashboard của hệ thống và chỉ mang tính chất hỗ trợ tham khảo.
Các nhận xét, đánh giá, cảnh báo và khuyến nghị được sinh tự động dựa trên dữ liệu hiện có tại thời điểm phân tích.
Người sử dụng cần xem xét và đối chiếu với thực tế trước khi đưa ra quyết định.
Quyết định cuối cùng thuộc về người quản lý hoặc người có thẩm quyền.
=================================================";
            return aiResponse + Environment.NewLine + disclaimer;
        }

        private string GeneratePrompt(DashboardData data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bạn là chuyên gia phân tích dữ liệu cho tòa soạn báo.");
            sb.AppendLine("Dưới đây là dữ liệu Dashboard.");
            sb.AppendLine("Hãy:");
            sb.AppendLine("- phân tích xu hướng");
            sb.AppendLine("- giải thích các KPI");
            sb.AppendLine("- nhận xét số liệu");
            sb.AppendLine("- phát hiện điểm nổi bật");
            sb.AppendLine("- phát hiện bất thường");
            sb.AppendLine("- đưa ra khuyến nghị cho lãnh đạo");
            sb.AppendLine("Trả lời bằng tiếng Việt.");
            sb.AppendLine("Không sử dụng Markdown.");
            sb.AppendLine("Không dùng ký tự đặc biệt.");
            sb.AppendLine("Trình bày theo từng mục rõ ràng.");
            sb.AppendLine();
            sb.AppendLine("DỮ LIỆU DASHBOARD:");
            sb.AppendLine($"- Tổng bài viết: {data.TongBaiViet}");
            sb.AppendLine($"- Tổng nhuận bút: {data.TongNhuanBut:N0} VNĐ");
            sb.AppendLine($"- Tổng phóng viên: {data.TongPhongVien}");
            sb.AppendLine($"- Bài chưa duyệt: {data.TongBaiChuaDuyet}");
            sb.AppendLine($"- Tổng phiếu chi: {data.TongPhieuChi}");
            sb.AppendLine($"- Cảnh báo AI chưa xử lý: {data.TongCanhBao}");
            
            sb.AppendLine("- Thống kê nhuận bút theo tháng:");
            foreach(var k in data.ThongKeTheoThang)
                sb.AppendLine($"  + {k.Key}: {k.Value:N0} VNĐ");

            sb.AppendLine("- Top phóng viên:");
            foreach (var k in data.TopPhongVien)
                sb.AppendLine($"  + {k.Key}: {k.Value:N0} VNĐ");

            sb.AppendLine("- Bài theo chuyên mục:");
            foreach (var k in data.TiLeChuyenMuc)
                sb.AppendLine($"  + {k.Key}: {k.Value} bài");

            sb.AppendLine("- Điểm chất lượng AI trung bình theo chuyên mục:");
            foreach (var k in data.DiemAITrungBinh)
                sb.AppendLine($"  + {k.Key}: {k.Value:N2} điểm");

            return sb.ToString();
        }
    }
}
