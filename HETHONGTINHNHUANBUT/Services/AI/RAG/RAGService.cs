using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT.Services.AI.RAG
{
    public class RAGService
    {
        private readonly string _connectionString;

        public RAGService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<string> GetSystemOverviewAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS TongBai, ISNULL(SUM(TienNhuanbut),0) AS TongTien,
                               AVG(TienNhuanbut) AS TrungBinh, MAX(TienNhuanbut) AS CaoNhat
                        FROM Nhuanbut WHERE TrangThaiDuyet >= 4", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        if (r.Read())
                            sb.AppendLine($"【TỔNG QUAN ĐÃ DUYỆT】Bài: {r["TongBai"]}, Tiền: {Convert.ToDecimal(r["TongTien"]):N0}đ, TB: {Convert.ToDecimal(r["TrungBinh"]):N0}đ, Cao nhất: {Convert.ToDecimal(r["CaoNhat"]):N0}đ");
                        r.Close();
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT TrangThaiDuyet, COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS TongTien
                        FROM Nhuanbut GROUP BY TrangThaiDuyet ORDER BY TrangThaiDuyet", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        sb.AppendLine("【TRẠNG THÁI】");
                        while (r.Read())
                        {
                            int tt = Convert.ToInt32(r["TrangThaiDuyet"]);
                            string ten = tt == 0 ? "Chờ chấm tiền" : tt == 1 ? "Đã chấm - chờ nhập liệu" : tt == 2 ? "Đã nhập - chờ kiểm tra" : tt == 3 ? "Đã kiểm tra - chờ ký duyệt" : "Đã ký duyệt";
                            sb.AppendLine($"• {ten}: {r["SL"]} bài - {Convert.ToDecimal(r["TongTien"]):N0}đ");
                        }
                        r.Close();
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL, ISNULL(SUM(Sotien),0) AS Tong FROM Phieuchi WHERE TrangThaiDuyet = 0", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        if (r.Read())
                            sb.AppendLine($"【PHIẾU CHỜ】{r["SL"]} phiếu - {Convert.ToDecimal(r["Tong"]):N0}đ");
                        r.Close();
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS Tong
                        FROM Nhuanbut WHERE MONTH(ngaychuyen)=MONTH(GETDATE()) AND YEAR(ngaychuyen)=YEAR(GETDATE())", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        if (r.Read())
                            sb.AppendLine($"【THÁNG NÀY】{r["SL"]} bài - {Convert.ToDecimal(r["Tong"]):N0}đ");
                        r.Close();
                    }

                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "[LỖI DB] " + ex.Message;
            }
        }

        public async Task<string> GetAuthorInfoAsync(string cauHoi)
        {
            try
            {
                string keyword = cauHoi.ToLower();
                string[] stopWords = { "thông tin", "tác giả", "phóng viên", "người viết", "tra cứu", "tìm", "hồ sơ", "của", "cho", "tôi", "xem", "về", "có", "không", "tên", "là", "ai", "một", "1", "những", "các", "đó", "này", "kia", "chi tiết" };
                foreach (var word in stopWords)
                {
                    keyword = System.Text.RegularExpressions.Regex.Replace(keyword, $@"\b{word}\b", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                }
                keyword = keyword.Trim().Trim(' ', ',', '.', '?');

                if (string.IsNullOrEmpty(keyword)) keyword = "%";

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();

                    string cauHoiLower = cauHoi.ToLower();
                    bool laHoiTop = cauHoiLower.Contains("cao nhất") || cauHoiLower.Contains("nhiều nhất") || cauHoiLower.Contains("top");
                    bool laHoiThap = cauHoiLower.Contains("thấp nhất") || cauHoiLower.Contains("ít nhất") || cauHoiLower.Contains("cuối cùng");

                    if (laHoiTop || laHoiThap)
                    {
                        string sortOrder = laHoiTop ? "DESC" : "ASC";
                        string sqlTop = $@"
                            SELECT TOP 5 tg.Hoten, tg.MsTG, tg.PhongBan,
                                   (SELECT COUNT(*) FROM Nhuanbut nb JOIN ButDanh bd ON nb.Butdanh = bd.Butdanh WHERE bd.MsTacgia = tg.Maso) AS SoBai,
                                   (SELECT ISNULL(SUM(nb.TienNhuanbut),0) FROM Nhuanbut nb JOIN ButDanh bd ON nb.Butdanh = bd.Butdanh WHERE bd.MsTacgia = tg.Maso AND nb.TrangThaiDuyet >= 4) AS TongTien
                            FROM TacGia tg
                            ORDER BY 
                                (SELECT ISNULL(SUM(nb2.TienNhuanbut),0) FROM Nhuanbut nb2 JOIN ButDanh bd2 ON nb2.Butdanh = bd2.Butdanh WHERE bd2.MsTacgia = tg.Maso AND nb2.TrangThaiDuyet >= 4) {sortOrder},
                                (SELECT COUNT(*) FROM Nhuanbut nb3 JOIN ButDanh bd3 ON nb3.Butdanh = bd3.Butdanh WHERE bd3.MsTacgia = tg.Maso) {sortOrder}";

                        using (var cmd = new SqlCommand(sqlTop, conn))
                        {
                            using (var r = await cmd.ExecuteReaderAsync())
                            {
                                int stt = 0;
                                string title = laHoiTop ? "【TOP TÁC GIẢ NỔI BẬT NHẤT HỆ THỐNG】" : "【TOP TÁC GIẢ THẤP NHẤT HỆ THỐNG】";
                                sb.AppendLine(title);
                                while (r.Read())
                                {
                                    stt++;
                                    sb.AppendLine($"{stt}. {r["Hoten"]} (Mã: {r["MsTG"]}) - Phòng: {r["PhongBan"]} - Tổng bài: {r["SoBai"]} - Tổng tiền: {Convert.ToDecimal(r["TongTien"]):N0}đ");
                                }
                                if (stt == 0) sb.AppendLine("Chưa có dữ liệu tác giả.");
                            }
                        }
                    }
                    else
                    {
                        string sql = @"
                            SELECT tg.Hoten, tg.MsTG, tg.PhongBan, tg.DienThoai, tg.Email, tg.LoaiTacgia,
                                   (SELECT COUNT(*) FROM Nhuanbut nb JOIN ButDanh bd ON nb.Butdanh = bd.Butdanh WHERE bd.MsTacgia = tg.Maso) AS SoBai,
                                    (SELECT ISNULL(SUM(nb.TienNhuanbut),0) FROM Nhuanbut nb JOIN ButDanh bd ON nb.Butdanh = bd.Butdanh WHERE bd.MsTacgia = tg.Maso AND nb.TrangThaiDuyet >= 4) AS TongTien
                            FROM TacGia tg
                            WHERE tg.Hoten LIKE N'%' + @k + '%' OR tg.MsTG LIKE '%' + @k + '%'";

                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@k", keyword);
                            using (var r = await cmd.ExecuteReaderAsync())
                            {
                                int stt = 0;
                                while (r.Read())
                                {
                                    stt++;
                                    sb.AppendLine($"【TÁC GIẢ {stt}】{r["Hoten"]} (Mã: {r["MsTG"]})");
                                    sb.AppendLine($"   Loại: {r["LoaiTacgia"]}, Phòng: {r["PhongBan"]}");
                                    sb.AppendLine($"   Email: {r["Email"]}, ĐT: {r["DienThoai"]}");
                                    sb.AppendLine($"   Tổng bài: {r["SoBai"]}, Tổng tiền đã duyệt: {Convert.ToDecimal(r["TongTien"]):N0}đ");
                                }
                                if (stt == 0) sb.AppendLine("Không tìm thấy tác giả phù hợp.");
                            }
                        }
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "[LỖI TRA CỨU TÁC GIẢ] " + ex.Message;
            }
        }

        public async Task<string> GetMonthlyStatsAsync(string cauHoi)
        {
            try
            {
                int thang = DateTime.Now.Month, nam = DateTime.Now.Year;

                var matchMonthYear = System.Text.RegularExpressions.Regex.Match(cauHoi, @"tháng\s+(\d{1,2})(?:\s*(?:/|-|năm)\s*(\d{4}))?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                var matchSlash = System.Text.RegularExpressions.Regex.Match(cauHoi, @"(\d{1,2})\s*[/\-]\s*(\d{4})");

                if (matchMonthYear.Success)
                {
                    thang = int.Parse(matchMonthYear.Groups[1].Value);
                    if (matchMonthYear.Groups[2].Success)
                        nam = int.Parse(matchMonthYear.Groups[2].Value);
                }
                else if (matchSlash.Success)
                {
                    thang = int.Parse(matchSlash.Groups[1].Value);
                    nam = int.Parse(matchSlash.Groups[2].Value);
                }

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();
                    sb.AppendLine($"【BÁO CÁO THÁNG {thang}/{nam}】");

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS Tong,
                               COUNT(DISTINCT Butdanh) AS SoTG
                        FROM Nhuanbut WHERE MONTH(ngaychuyen)=@t AND YEAR(ngaychuyen)=@n", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            if (r.Read())
                                sb.AppendLine($"Tổng: {r["SL"]} bài, {Convert.ToDecimal(r["Tong"]):N0}đ, {r["SoTG"]} tác giả");
                            r.Close();
                        }
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT TOP 5 nb.Butdanh, COUNT(*) AS SL, ISNULL(SUM(nb.TienNhuanbut),0) AS Tong
                        FROM Nhuanbut nb WHERE MONTH(nb.ngaychuyen)=@t AND YEAR(nb.ngaychuyen)=@n
                        GROUP BY nb.Butdanh ORDER BY Tong DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        sb.AppendLine("Top tác giả cao nhất:");
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            int stt = 1;
                            while (r.Read())
                                sb.AppendLine($"  {stt++}. {r["Butdanh"]}: {r["SL"]} bài - {Convert.ToDecimal(r["Tong"]):N0}đ");
                            r.Close();
                        }
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT TOP 5 nb.Butdanh, COUNT(*) AS SL, ISNULL(SUM(nb.TienNhuanbut),0) AS Tong
                        FROM Nhuanbut nb WHERE MONTH(nb.ngaychuyen)=@t AND YEAR(nb.ngaychuyen)=@n
                        GROUP BY nb.Butdanh ORDER BY Tong ASC", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        sb.AppendLine("Top tác giả thấp nhất:");
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            int stt = 1;
                            while (r.Read())
                                sb.AppendLine($"  {stt++}. {r["Butdanh"]}: {r["SL"]} bài - {Convert.ToDecimal(r["Tong"]):N0}đ");
                            r.Close();
                        }
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT Muc, COUNT(*) AS SL, ISNULL(SUM(TienNhuanbut),0) AS Tong
                        FROM Nhuanbut WHERE MONTH(ngaychuyen)=@t AND YEAR(ngaychuyen)=@n
                        GROUP BY Muc ORDER BY Tong DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@t", thang);
                        cmd.Parameters.AddWithValue("@n", nam);
                        sb.AppendLine("Theo thể loại:");
                        using (var r = await cmd.ExecuteReaderAsync())
                        {
                            while (r.Read())
                                sb.AppendLine($"  • {r["Muc"]}: {r["SL"]} bài - {Convert.ToDecimal(r["Tong"]):N0}đ");
                            r.Close();
                        }
                    }

                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "[LỖI THỐNG KÊ] " + ex.Message;
            }
        }

        public async Task<string> GetPaymentSlipInfoAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();

                    using (var cmd = new SqlCommand(@"
                        SELECT 
                            COUNT(*) AS TongPhieu,
                            ISNULL(SUM(Sotien),0) AS TongTien,
                            ISNULL(SUM(Thue),0) AS TongThue,
                            SUM(CASE WHEN TrangThaiDuyet = 1 THEN Sotien ELSE 0 END) AS DaDuyet,
                            SUM(CASE WHEN TrangThaiDuyet = 0 THEN Sotien ELSE 0 END) AS ChoDuyet
                        FROM Phieuchi", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        if (r.Read())
                        {
                            sb.AppendLine("【PHIẾU CHI】");
                            sb.AppendLine($"Tổng: {r["TongPhieu"]} phiếu");
                            sb.AppendLine($"Tổng tiền: {Convert.ToDecimal(r["TongTien"]):N0}đ");
                            sb.AppendLine($"Thuế: {Convert.ToDecimal(r["TongThue"]):N0}đ");
                            sb.AppendLine($"Đã duyệt: {Convert.ToDecimal(r["DaDuyet"]):N0}đ");
                            sb.AppendLine($"Chờ duyệt: {Convert.ToDecimal(r["ChoDuyet"]):N0}đ");
                        }
                        r.Close();
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "[LỖI PHIẾU CHI] " + ex.Message;
            }
        }

        public async Task<string> GetAnomaliesAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    var warnings = new List<string>();

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL FROM Nhuanbut 
                        WHERE TrangThaiDuyet < 2 AND ngaychuyen < DATEADD(DAY, -7, GETDATE())", conn))
                    {
                        int sl = (int)(await cmd.ExecuteScalarAsync() ?? 0);
                        if (sl > 0) warnings.Add($"⚠️ {sl} bài chờ ký duyệt quá 7 ngày");
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT Butdanh, COUNT(*) AS SL FROM Nhuanbut
                        WHERE ngaychuyen >= DATEADD(DAY, -7, GETDATE())
                        GROUP BY Butdanh HAVING COUNT(*) >= 5", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        while (r.Read())
                            warnings.Add($"⚠️ Tác giả '{r["Butdanh"]}' nộp {r["SL"]} bài/7 ngày");
                        r.Close();
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT nb.Muc, nb.Butdanh, nb.TienNhuanbut, dm.MucToiDa
                        FROM Nhuanbut nb JOIN DinhMuc dm ON nb.Muc = dm.Muc
                        WHERE nb.TienNhuanbut > dm.MucToiDa AND nb.TrangThaiDuyet < 2", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        while (r.Read())
                            warnings.Add($"🚨 {r["Butdanh"]}: {r["TienNhuanbut"]:N0}đ > {r["MucToiDa"]:N0}đ (định mức {r["Muc"]})");
                        r.Close();
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) AS SL FROM Phieuchi 
                        WHERE TrangThaiDuyet = 0 AND Ngaylap < DATEADD(DAY, -5, GETDATE())", conn))
                    {
                        int slPc = (int)(await cmd.ExecuteScalarAsync() ?? 0);
                        if (slPc > 0) warnings.Add($"⚠️ {slPc} phiếu chi chờ duyệt quá 5 ngày");
                    }

                    if (warnings.Count == 0) return "✅ Không phát hiện bất thường nào.";
                    return "【PHÁT HIỆN BẤT THƯỜNG】\n" + string.Join("\n", warnings);
                }
            }
            catch (Exception ex)
            {
                return "[LỖI] " + ex.Message;
            }
        }

        public async Task<string> GetLimitsAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();
                    sb.AppendLine("【ĐỊNH MỨC NHUẬN BÚT】");

                    using (var cmd = new SqlCommand("SELECT Muc, MucToiDa FROM DinhMuc ORDER BY MucToiDa DESC", conn))
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        while (r.Read())
                            sb.AppendLine($"• {r["Muc"]}: tối đa {Convert.ToDecimal(r["MucToiDa"]):N0}đ");
                        r.Close();
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return "[LỖI] " + ex.Message;
            }
        }

        public async Task<string> ExecuteDynamicQueryAsync(HETHONGTINHNHUANBUT.Services.AI.ToolCalling.QueryParameters p)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    var sb = new StringBuilder();

                    if (p.Intent == "BaiViet")
                    {
                        string sql = @"
                            SELECT TOP 20 nb.TenBai, nb.Butdanh, nb.TienNhuanbut, nb.TrangThaiDuyet, nb.ngaychuyen, nb.Muc 
                            FROM Nhuanbut nb 
                            JOIN ButDanh bd ON nb.Butdanh = bd.Butdanh
                            JOIN TacGia tg ON bd.MsTacgia = tg.Maso
                            WHERE 1=1 ";

                        if (!string.IsNullOrEmpty(p.TacGia)) sql += " AND (tg.Hoten LIKE '%' + @tacgia + '%' OR bd.Butdanh LIKE '%' + @tacgia + '%') ";
                        if (p.Thang.HasValue) sql += " AND MONTH(nb.ngaychuyen) = @thang ";
                        if (p.Nam.HasValue) sql += " AND YEAR(nb.ngaychuyen) = @nam ";
                        if (!string.IsNullOrEmpty(p.TuKhoa)) sql += " AND nb.TenBai LIKE '%' + @tukhoa + '%' ";
                        if (!string.IsNullOrEmpty(p.TrangThai))
                        {
                            if (p.TrangThai.ToLower().Contains("đã")) sql += " AND nb.TrangThaiDuyet >= 4 ";
                            else if (p.TrangThai.ToLower().Contains("chờ")) sql += " AND nb.TrangThaiDuyet < 4 ";
                        }
                        
                        sql += " ORDER BY nb.ngaychuyen DESC";

                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            if (!string.IsNullOrEmpty(p.TacGia)) cmd.Parameters.AddWithValue("@tacgia", p.TacGia);
                            if (p.Thang.HasValue) cmd.Parameters.AddWithValue("@thang", p.Thang.Value);
                            if (p.Nam.HasValue) cmd.Parameters.AddWithValue("@nam", p.Nam.Value);
                            if (!string.IsNullOrEmpty(p.TuKhoa)) cmd.Parameters.AddWithValue("@tukhoa", p.TuKhoa);

                            using (var r = await cmd.ExecuteReaderAsync())
                            {
                                sb.AppendLine("【DANH SÁCH BÀI VIẾT CHI TIẾT (TỐI ĐA 20 BÀI)】");
                                int count = 0;
                                while (r.Read())
                                {
                                    count++;
                                    string tenBai = r["TenBai"].ToString();
                                    string bd = r["Butdanh"].ToString();
                                    string muc = r["Muc"].ToString();
                                    decimal tien = r["TienNhuanbut"] != DBNull.Value ? Convert.ToDecimal(r["TienNhuanbut"]) : 0;
                                    string tt = Convert.ToInt32(r["TrangThaiDuyet"]) >= 4 ? "Đã duyệt" : "Chờ duyệt";
                                    sb.AppendLine($"- Bài: '{tenBai}' | Bút danh: {bd} | Thể loại: {muc} | Trạng thái: {tt} | Tiền: {tien:N0}đ");
                                }
                                if (count == 0) sb.AppendLine("Không tìm thấy bài viết nào phù hợp.");
                            }
                        }
                        return sb.ToString();
                    }
                    
                    return null; // Trả về null nếu không phải ý định có thể xử lý động, để fallback về các hàm cũ
                }
            }
            catch (Exception ex)
            {
                return "[LỖI TRUY VẤN ĐỘNG] " + ex.Message;
            }
        }
    }
}
