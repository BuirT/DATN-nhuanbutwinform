using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT
{
    public class AuditAlert
    {
        public int Id { get; set; }
        public DateTime NgayCanhBao { get; set; }
        public string LoaiCanhBao { get; set; }
        public int MucDo { get; set; }
        public int? MaBaiViet { get; set; }
        public int? MaPhongVien { get; set; }
        public string NoiDung { get; set; }
        public bool DaXuLy { get; set; }
        public string GiaTriPhatHien { get; set; }
    }

    public static class AIAuditService
    {
        private static readonly string connStr =
            System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public static async Task<List<AuditAlert>> KiemToanHetAsync()
        {
            List<AuditAlert> alerts = new List<AuditAlert>();

            alerts.AddRange(await KiemTraTienQuaCaoAsync());
            alerts.AddRange(await KiemTraTienQuaThapAsync());
            alerts.AddRange(await KiemTraTangDotBienTacGiaAsync());
            alerts.AddRange(await KiemTraTangDotBienSoBaiAsync());
            alerts.AddRange(await KiemTraDiemCaoTienThapAsync());
            alerts.AddRange(await KiemTraDiemThapTienCaoAsync());

            foreach (var alert in alerts)
                await LuuCanhBao(alert);

            return alerts;
        }

        private static async Task LuuCanhBao(AuditAlert alert)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        IF NOT EXISTS (
                            SELECT 1 FROM AICanhBao 
                            WHERE LoaiCanhBao = @Loai 
                              AND ISNULL(MaBaiViet, 0) = ISNULL(@MaBai, 0)
                              AND ISNULL(MaPhongVien, 0) = ISNULL(@MaPV, 0)
                        )
                        BEGIN
                            INSERT INTO AICanhBao (NgayCanhBao, LoaiCanhBao, MucDo, MaBaiViet, MaPhongVien, NoiDung, DaXuLy, GiaTriPhatHien)
                            VALUES (@Ngay, @Loai, @MucDo, @MaBai, @MaPV, @NoiDung, 0, @GiaTri)
                        END", conn))
                    {
                        cmd.Parameters.AddWithValue("@Ngay", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Loai", alert.LoaiCanhBao);
                        cmd.Parameters.AddWithValue("@MucDo", alert.MucDo);
                        cmd.Parameters.AddWithValue("@MaBai", (object)alert.MaBaiViet ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaPV", (object)alert.MaPhongVien ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@NoiDung", alert.NoiDung ?? "");
                        cmd.Parameters.AddWithValue("@GiaTri", (object)alert.GiaTriPhatHien ?? DBNull.Value);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch { }
        }

        public static async Task<List<AuditAlert>> LayTatCaCanhBaoAsync()
        {
            List<AuditAlert> list = new List<AuditAlert>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT Id, NgayCanhBao, LoaiCanhBao, MucDo, MaBaiViet, MaPhongVien, NoiDung, DaXuLy, GiaTriPhatHien
                        FROM AICanhBao ORDER BY NgayCanhBao DESC", conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                            list.Add(MapReader(reader));
                    }
                }
            }
            catch { }
            return list;
        }

        public static async Task DanhDauDaXuLyAsync(int id)
        {
            await CapNhatTrangThaiXuLyAsync(id, true);
        }

        public static async Task CapNhatTrangThaiXuLyAsync(int id, bool daXuLy)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE AICanhBao SET DaXuLy = @daXuLy WHERE Id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@daXuLy", daXuLy);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch { }
        }

        private static AuditAlert MapReader(SqlDataReader reader)
        {
            return new AuditAlert
            {
                Id = Convert.ToInt32(reader["Id"]),
                NgayCanhBao = Convert.ToDateTime(reader["NgayCanhBao"]),
                LoaiCanhBao = reader["LoaiCanhBao"]?.ToString() ?? "",
                MucDo = Convert.ToInt32(reader["MucDo"]),
                MaBaiViet = reader["MaBaiViet"] != DBNull.Value ? Convert.ToInt32(reader["MaBaiViet"]) : (int?)null,
                MaPhongVien = reader["MaPhongVien"] != DBNull.Value ? Convert.ToInt32(reader["MaPhongVien"]) : (int?)null,
                NoiDung = reader["NoiDung"]?.ToString() ?? "",
                DaXuLy = Convert.ToBoolean(reader["DaXuLy"]),
                GiaTriPhatHien = reader["GiaTriPhatHien"]?.ToString() ?? ""
            };
        }

        // ======================================================================
        // LUẬT 1: Tiền nhuận bút quá cao so với trung bình chuyên mục
        // ======================================================================
        private static async Task<List<AuditAlert>> KiemTraTienQuaCaoAsync()
        {
            List<AuditAlert> alerts = new List<AuditAlert>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT n.Maso, n.Tenbai, n.TienNhuanbut, n.Muc, n.Butdanh,
                               AVG(n2.TienNhuanbut) AS TrungBinh,
                               STDEV(n2.TienNhuanbut) AS DoLechChuan
                        FROM Nhuanbut n
                        CROSS APPLY (
                            SELECT TienNhuanbut FROM Nhuanbut
                            WHERE Muc = n.Muc AND TienNhuanbut > 0 AND Maso != n.Maso
                        ) n2
                        WHERE n.TienNhuanbut > 0 AND n.TrangThaiDuyet >= 0
                        GROUP BY n.Maso, n.Tenbai, n.TienNhuanbut, n.Muc, n.Butdanh
                        HAVING n.TienNhuanbut > AVG(n2.TienNhuanbut) * 3
                           AND n.TienNhuanbut > AVG(n2.TienNhuanbut) + 2 * STDEV(n2.TienNhuanbut)
                        ORDER BY n.TienNhuanbut DESC", conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string tenBai = reader["Tenbai"]?.ToString() ?? "";
                            string muc = reader["Muc"]?.ToString() ?? "";
                            decimal tien = Convert.ToDecimal(reader["TienNhuanbut"]);
                            decimal tb = Convert.ToDecimal(reader["TrungBinh"]);

                            decimal tyLe = tb > 0 ? tien / tb : 0;
                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "Tiền nhuận bút quá cao",
                                MucDo = 3,
                                MaBaiViet = Convert.ToInt32(reader["Maso"]),
                                NoiDung = string.Format(
                                    "Bài \"{0}\" (CM: {1}) có tiền NB {2:N0}đ, gấp {3:F1} lần TB chuyên mục ({4:N0}đ).",
                                    tenBai, muc, tien, tyLe, tb),
                                GiaTriPhatHien = string.Format(
                                    "TB chuyên mục: {0:N0}đ | Tiền hiện tại: {1:N0}đ | Tỷ lệ: {2:F0}%",
                                    tb, tien, tyLe * 100)
                            });
                        }
                    }
                }
            }
            catch { }
            return alerts;
        }

        // ======================================================================
        // LUẬT 2: Tiền nhuận bút quá thấp so với trung bình chuyên mục
        // ======================================================================
        private static async Task<List<AuditAlert>> KiemTraTienQuaThapAsync()
        {
            List<AuditAlert> alerts = new List<AuditAlert>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT n.Maso, n.Tenbai, n.TienNhuanbut, n.Muc, n.Butdanh,
                               AVG(n2.TienNhuanbut) AS TrungBinh
                        FROM Nhuanbut n
                        CROSS APPLY (
                            SELECT TienNhuanbut FROM Nhuanbut
                            WHERE Muc = n.Muc AND TienNhuanbut > 0 AND Maso != n.Maso
                        ) n2
                        WHERE n.TienNhuanbut > 0 AND n.TrangThaiDuyet >= 0
                        GROUP BY n.Maso, n.Tenbai, n.TienNhuanbut, n.Muc, n.Butdanh
                        HAVING n.TienNhuanbut < AVG(n2.TienNhuanbut) * 0.3
                           AND AVG(n2.TienNhuanbut) > 50000
                        ORDER BY n.TienNhuanbut ASC", conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string tenBai = reader["Tenbai"]?.ToString() ?? "";
                            string muc = reader["Muc"]?.ToString() ?? "";
                            decimal tien = Convert.ToDecimal(reader["TienNhuanbut"]);
                            decimal tb = Convert.ToDecimal(reader["TrungBinh"]);

                            decimal tyLe = tb > 0 ? tien / tb * 100 : 0;
                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "Tiền nhuận bút quá thấp",
                                MucDo = 2,
                                MaBaiViet = Convert.ToInt32(reader["Maso"]),
                                NoiDung = string.Format(
                                    "Bài \"{0}\" (CM: {1}) có tiền NB {2:N0}đ, chỉ bằng {3:F1}% TB chuyên mục ({4:N0}đ).",
                                    tenBai, muc, tien, tyLe, tb),
                                GiaTriPhatHien = string.Format(
                                    "TB chuyên mục: {0:N0}đ | Tiền hiện tại: {1:N0}đ | Tỷ lệ: {2:F0}%",
                                    tb, tien, tyLe)
                            });
                        }
                    }
                }
            }
            catch { }
            return alerts;
        }

        // ======================================================================
        // LUẬT 5: Phóng viên nhận nhuận bút tăng đột biến
        // ======================================================================
        private static async Task<List<AuditAlert>> KiemTraTangDotBienTacGiaAsync()
        {
            List<AuditAlert> alerts = new List<AuditAlert>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT
                            n.Butdanh,
                            SUM(CASE WHEN n.ngaychuyen >= DATEADD(MONTH, -1, GETDATE()) THEN n.TienNhuanbut ELSE 0 END) AS ThangNay,
                            AVG(CASE
                                WHEN n.ngaychuyen >= DATEADD(MONTH, -4, GETDATE())
                                 AND n.ngaychuyen < DATEADD(MONTH, -1, GETDATE())
                                THEN n.TienNhuanbut ELSE NULL
                            END) AS TrungBinh3Thang
                        FROM Nhuanbut n
                        WHERE n.TienNhuanbut > 0 AND n.TrangThaiDuyet >= 0
                        GROUP BY n.Butdanh
                        HAVING
                            SUM(CASE WHEN n.ngaychuyen >= DATEADD(MONTH, -1, GETDATE()) THEN n.TienNhuanbut ELSE 0 END) >
                            ISNULL(AVG(CASE
                                WHEN n.ngaychuyen >= DATEADD(MONTH, -4, GETDATE())
                                 AND n.ngaychuyen < DATEADD(MONTH, -1, GETDATE())
                                THEN n.TienNhuanbut ELSE NULL
                            END), 0) * 3
                            AND AVG(CASE
                                WHEN n.ngaychuyen >= DATEADD(MONTH, -4, GETDATE())
                                 AND n.ngaychuyen < DATEADD(MONTH, -1, GETDATE())
                                THEN n.TienNhuanbut ELSE NULL
                            END) > 100000", conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string butDanh = reader["Butdanh"]?.ToString() ?? "";
                            decimal thangNay = Convert.ToDecimal(reader["ThangNay"]);
                            decimal tb = reader["TrungBinh3Thang"] != DBNull.Value
                                ? Convert.ToDecimal(reader["TrungBinh3Thang"]) : 0;

                            decimal tyLe = tb > 0 ? thangNay / tb : 0;
                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "PV nhận NB tăng đột biến",
                                MucDo = 3,
                                NoiDung = string.Format(
                                    "PV \"{0}\" nhận {1:N0}đ tháng này, gấp {2:F1} lần TB 3 tháng ({3:N0}đ/tháng). Cần kiểm tra.",
                                    butDanh, thangNay, tyLe, tb),
                                GiaTriPhatHien = string.Format(
                                    "Tháng này: {0:N0}đ | TB 3 tháng: {1:N0}đ | Tỷ lệ: {2:F0}%",
                                    thangNay, tb, tyLe * 100)
                            });
                        }
                    }
                }
            }
            catch { }
            return alerts;
        }

        // ======================================================================
        // LUẬT 6: Số lượng bài viết tăng đột biến theo tác giả
        // ======================================================================
        private static async Task<List<AuditAlert>> KiemTraTangDotBienSoBaiAsync()
        {
            List<AuditAlert> alerts = new List<AuditAlert>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT
                            n.Butdanh,
                            COUNT(CASE WHEN n.ngaychuyen >= DATEADD(MONTH, -1, GETDATE()) THEN 1 ELSE NULL END) AS SoBaiThangNay,
                            AVG(CASE
                                WHEN n.ngaychuyen >= DATEADD(MONTH, -4, GETDATE())
                                 AND n.ngaychuyen < DATEADD(MONTH, -1, GETDATE())
                                THEN 1 ELSE NULL
                            END) * 1.0 AS TbBai3Thang
                        FROM Nhuanbut n
                        WHERE n.TrangThaiDuyet >= 0
                        GROUP BY n.Butdanh
                        HAVING
                            COUNT(CASE WHEN n.ngaychuyen >= DATEADD(MONTH, -1, GETDATE()) THEN 1 ELSE NULL END) >
                            ISNULL(AVG(CASE
                                WHEN n.ngaychuyen >= DATEADD(MONTH, -4, GETDATE())
                                 AND n.ngaychuyen < DATEADD(MONTH, -1, GETDATE())
                                THEN 1 ELSE NULL
                            END), 0) * 3
                            AND COUNT(CASE WHEN n.ngaychuyen >= DATEADD(MONTH, -1, GETDATE()) THEN 1 ELSE NULL END) >= 5", conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string butDanh = reader["Butdanh"]?.ToString() ?? "";
                            int soBai = Convert.ToInt32(reader["SoBaiThangNay"]);
                            double tb = reader["TbBai3Thang"] != DBNull.Value
                                ? Convert.ToDouble(reader["TbBai3Thang"]) : 0;

                            double tyLe = tb > 0 ? soBai / tb : 0;
                            string noiDung = tb > 0
                                ? string.Format(
                                    "PV \"{0}\" có {1} bài tháng này, gấp {2:F1} lần TB 3 tháng ({3:F1} bài/tháng).",
                                    butDanh, soBai, tyLe, tb)
                                : string.Format(
                                    "PV \"{0}\" có {1} bài tháng này. Chưa có dữ liệu trung bình 3 tháng trước để đối chiếu, cần kiểm tra thủ công.",
                                    butDanh, soBai);
                            string giaTriPhatHien = tb > 0
                                ? string.Format(
                                    "Tháng này: {0} bài | TB 3 tháng: {1:F0} bài | Tỷ lệ: {2:F0}%",
                                    soBai, tb, tyLe * 100)
                                : string.Format(
                                    "Tháng này: {0} bài | TB 3 tháng: chưa có dữ liệu | Tỷ lệ: không xác định",
                                    soBai);

                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "Số bài viết tăng đột biến",
                                MucDo = 2,
                                NoiDung = noiDung,
                                GiaTriPhatHien = giaTriPhatHien
                            });
                        }
                    }
                }
            }
            catch { }
            return alerts;
        }

        // ======================================================================
        // LUẬT 5: Điểm AI cao nhưng tiền nhuận bút thấp bất thường
        // ======================================================================
        private static async Task<List<AuditAlert>> KiemTraDiemCaoTienThapAsync()
        {
            List<AuditAlert> alerts = new List<AuditAlert>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT n.Maso, n.Tenbai, n.TienNhuanbut, n.DiemChatLuongAI, n.Muc, n.Butdanh,
                               AVG(n2.TienNhuanbut) AS TrungBinh
                        FROM Nhuanbut n
                        CROSS APPLY (
                            SELECT TienNhuanbut FROM Nhuanbut
                            WHERE Muc = n.Muc AND TienNhuanbut > 0 AND Maso != n.Maso
                        ) n2
                        WHERE n.TienNhuanbut > 0
                          AND n.TrangThaiDuyet >= 0
                          AND n.DiemChatLuongAI IS NOT NULL
                          AND n.DiemChatLuongAI >= 85
                        GROUP BY n.Maso, n.Tenbai, n.TienNhuanbut, n.DiemChatLuongAI, n.Muc, n.Butdanh
                        HAVING n.TienNhuanbut < AVG(n2.TienNhuanbut)
                           AND AVG(n2.TienNhuanbut) > 0
                        ORDER BY n.TienNhuanbut ASC", conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string tenBai = reader["Tenbai"]?.ToString() ?? "";
                            string muc = reader["Muc"]?.ToString() ?? "";
                            decimal tien = Convert.ToDecimal(reader["TienNhuanbut"]);
                            int diemAI = Convert.ToInt32(reader["DiemChatLuongAI"]);
                            decimal tb = Convert.ToDecimal(reader["TrungBinh"]);

                            decimal tyLe = tb > 0 ? tien / tb * 100 : 0;
                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "Điểm AI cao nhưng mức nhuận bút được chấm thấp bất thường",
                                MucDo = 2,
                                MaBaiViet = Convert.ToInt32(reader["Maso"]),
                                NoiDung = string.Format(
                                    "Bài \"{0}\" (CM: {1}) có điểm AI {2}/100 nhưng tiền NB chỉ {3:N0}đ, thấp hơn TB chuyên mục ({4:N0}đ).",
                                    tenBai, muc, diemAI, tien, tb),
                                GiaTriPhatHien = string.Format(
                                    "Điểm AI: {0}/100 | Tiền NB: {1:N0}đ | TB chuyên mục: {2:N0}đ | Tỷ lệ: {3:F0}%",
                                    diemAI, tien, tb, tyLe)
                            });
                        }
                    }
                }
            }
            catch { }
            return alerts;
        }

        // ======================================================================
        // LUẬT 6: Điểm AI thấp nhưng tiền nhuận bút cao bất thường
        // ======================================================================
        private static async Task<List<AuditAlert>> KiemTraDiemThapTienCaoAsync()
        {
            List<AuditAlert> alerts = new List<AuditAlert>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT n.Maso, n.Tenbai, n.TienNhuanbut, n.DiemChatLuongAI, n.Muc, n.Butdanh,
                               AVG(n2.TienNhuanbut) AS TrungBinh
                        FROM Nhuanbut n
                        CROSS APPLY (
                            SELECT TienNhuanbut FROM Nhuanbut
                            WHERE Muc = n.Muc AND TienNhuanbut > 0 AND Maso != n.Maso
                        ) n2
                        WHERE n.TienNhuanbut > 0
                          AND n.TrangThaiDuyet >= 0
                          AND n.DiemChatLuongAI IS NOT NULL
                          AND n.DiemChatLuongAI <= 60
                        GROUP BY n.Maso, n.Tenbai, n.TienNhuanbut, n.DiemChatLuongAI, n.Muc, n.Butdanh
                        HAVING n.TienNhuanbut > AVG(n2.TienNhuanbut)
                           AND AVG(n2.TienNhuanbut) > 0
                        ORDER BY n.TienNhuanbut DESC", conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string tenBai = reader["Tenbai"]?.ToString() ?? "";
                            string muc = reader["Muc"]?.ToString() ?? "";
                            decimal tien = Convert.ToDecimal(reader["TienNhuanbut"]);
                            int diemAI = Convert.ToInt32(reader["DiemChatLuongAI"]);
                            decimal tb = Convert.ToDecimal(reader["TrungBinh"]);

                            decimal tyLe = tb > 0 ? tien / tb * 100 : 0;
                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "Điểm AI thấp nhưng mức nhuận bút được chấm cao bất thường",
                                MucDo = 3,
                                MaBaiViet = Convert.ToInt32(reader["Maso"]),
                                NoiDung = string.Format(
                                    "Bài \"{0}\" (CM: {1}) có điểm AI {2}/100 nhưng tiền NB {3:N0}đ, cao hơn TB chuyên mục ({4:N0}đ).",
                                    tenBai, muc, diemAI, tien, tb),
                                GiaTriPhatHien = string.Format(
                                    "Điểm AI: {0}/100 | Tiền NB: {1:N0}đ | TB chuyên mục: {2:N0}đ | Tỷ lệ: {3:F0}%",
                                    diemAI, tien, tb, tyLe)
                            });
                        }
                    }
                }
            }
            catch { }
            return alerts;
        }

        // ======================================================================
        // Thống kê cho Dashboard
        // ======================================================================
        public static async Task<int> DemCanhBaoChuaXuLyAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM AICanhBao WHERE DaXuLy = 0", conn))
                    {
                        return (int)await cmd.ExecuteScalarAsync();
                    }
                }
            }
            catch { return 0; }
        }
    }
}
