using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT
{
    public static class AIReportService
    {
        private static readonly string connStr =
            System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public static async Task<string> TaoBaoCaoTongQuanAsync(int thang, int nam)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("BÁO CÁO TỔNG QUAN THÁNG {0}/{1}\n", thang, nam);
            sb.AppendLine(new string('=', 50));

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();

                    // Tổng bài viết
                    int tongBai = await ExecuteScalarAsync<int>(conn, @"
                        SELECT COUNT(*) FROM Nhuanbut
                        WHERE MONTH(ngaychuyen) = @thang AND YEAR(ngaychuyen) = @nam",
                        thang, nam);

                    // Tổng NB đã chi
                    decimal tongChi = await ExecuteScalarAsync<decimal>(conn, @"
                        SELECT ISNULL(SUM(TienNhuanbut), 0) FROM Nhuanbut
                        WHERE MONTH(ngaychuyen) = @thang AND YEAR(ngaychuyen) = @nam
                          AND TrangThaiDuyet >= 0", thang, nam);

                    // Chuyên mục chi cao nhất
                    string cmCaoNhat = "";
                    decimal tienCaoNhat = 0;
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT TOP 1 Muc, SUM(TienNhuanbut) AS Tong
                        FROM Nhuanbut
                        WHERE MONTH(ngaychuyen) = @thang AND YEAR(ngaychuyen) = @nam
                          AND TrangThaiDuyet >= 0
                        GROUP BY Muc ORDER BY Tong DESC", conn))
                    {
                        cmd.Parameters.AddWithValue("@thang", thang);
                        cmd.Parameters.AddWithValue("@nam", nam);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                cmCaoNhat = reader["Muc"]?.ToString() ?? "";
                                tienCaoNhat = Convert.ToDecimal(reader["Tong"]);
                            }
                        }
                    }

                    // Số bài chưa duyệt
                    int chuaDuyet = await ExecuteScalarAsync<int>(conn, @"
                        SELECT COUNT(*) FROM Nhuanbut
                        WHERE TrangThaiDuyet = 0
                          AND MONTH(ngaychuyen) = @thang AND YEAR(ngaychuyen) = @nam",
                        thang, nam);

                    // Cảnh báo
                    int canhBao = await ExecuteScalarAsync<int>(conn, @"
                        SELECT COUNT(*) FROM AICanhBao
                        WHERE DaXuLy = 0
                          AND MONTH(NgayCanhBao) = @thang AND YEAR(NgayCanhBao) = @nam",
                        thang, nam);

                    // Số PV
                    int tongPV = await ExecuteScalarAsync<int>(conn, @"
                        SELECT COUNT(DISTINCT Butdanh) FROM Nhuanbut
                        WHERE MONTH(ngaychuyen) = @thang AND YEAR(ngaychuyen) = @nam",
                        thang, nam);

                    // Số phiếu chi
                    int phieuChi = await ExecuteScalarAsync<int>(conn, @"
                        SELECT COUNT(*) FROM PhieuChi
                        WHERE MONTH(NgayLap) = @thang AND YEAR(NgayLap) = @nam",
                        thang, nam);

                    sb.AppendFormat("\n• Tổng số bài viết: {0:N0}\n", tongBai);
                    sb.AppendFormat("• Tổng số phóng viên: {0:N0}\n", tongPV);
                    sb.AppendFormat("• Tổng nhuận bút đã chi: {0:N0}đ\n", tongChi);
                    if (!string.IsNullOrEmpty(cmCaoNhat))
                        sb.AppendFormat("• Chuyên mục chi cao nhất: \"{0}\" ({1:N0}đ)\n", cmCaoNhat, tienCaoNhat);
                    sb.AppendFormat("• Số bài chưa duyệt: {0:N0}\n", chuaDuyet);
                    sb.AppendFormat("• Số phiếu chi đã lập: {0:N0}\n", phieuChi);
                    sb.AppendFormat("• Số cảnh báo AI: {0:N0}\n", canhBao);

                    if (canhBao > 0)
                        sb.AppendFormat("\n⚠ Có {0} cảnh báo bất thường cần xem xét.\n", canhBao);

                    if (chuaDuyet > 10)
                        sb.AppendFormat("\n⚠ Có {0} bài chưa duyệt, cần đẩy nhanh quy trình xử lý.\n", chuaDuyet);
                }
            }
            catch (Exception ex)
            {
                sb.AppendFormat("\nLỗi khi tạo báo cáo: {0}", ex.Message);
            }

            sb.AppendFormat("\n\n--- Báo cáo được tạo lúc {0:dd/MM/yyyy HH:mm:ss} ---", DateTime.Now);
            return sb.ToString();
        }

        private static async Task<T> ExecuteScalarAsync<T>(SqlConnection conn, string sql, int thang, int nam)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@thang", thang);
                cmd.Parameters.AddWithValue("@nam", nam);
                object result = await cmd.ExecuteScalarAsync();
                if (result == null || result == DBNull.Value)
                    return default(T);
                return (T)Convert.ChangeType(result, typeof(T));
            }
        }
    }
}
