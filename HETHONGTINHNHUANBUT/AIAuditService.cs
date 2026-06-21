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
            alerts.AddRange(await KiemTraDiemCaoTienThapAsync());
            alerts.AddRange(await KiemTraDiemThapTienCaoAsync());
            alerts.AddRange(await KiemTraTangDotBienTacGiaAsync());
            alerts.AddRange(await KiemTraTangDotBienSoBaiAsync());

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
                        INSERT INTO AICanhBao (NgayCanhBao, LoaiCanhBao, MucDo, MaBaiViet, MaPhongVien, NoiDung, DaXuLy)
                        VALUES (@Ngay, @Loai, @MucDo, @MaBai, @MaPV, @NoiDung, 0)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Ngay", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Loai", alert.LoaiCanhBao);
                        cmd.Parameters.AddWithValue("@MucDo", alert.MucDo);
                        cmd.Parameters.AddWithValue("@MaBai", (object)alert.MaBaiViet ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaPV", (object)alert.MaPhongVien ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@NoiDung", alert.NoiDung ?? "");
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
                        SELECT Id, NgayCanhBao, LoaiCanhBao, MucDo, MaBaiViet, MaPhongVien, NoiDung, DaXuLy
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
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE AICanhBao SET DaXuLy = 1 WHERE Id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
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
                DaXuLy = Convert.ToBoolean(reader["DaXuLy"])
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

                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "Tiền nhuận bút quá cao",
                                MucDo = 3,
                                MaBaiViet = Convert.ToInt32(reader["Maso"]),
                                NoiDung = string.Format(
                                    "Bài \"{0}\" (CM: {1}) có tiền NB {2:N0}đ, gấp {3:F1} lần TB chuyên mục ({4:N0}đ).",
                                    tenBai, muc, tien, tb > 0 ? tien / tb : 0, tb)
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

                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "Tiền nhuận bút quá thấp",
                                MucDo = 2,
                                MaBaiViet = Convert.ToInt32(reader["Maso"]),
                                NoiDung = string.Format(
                                    "Bài \"{0}\" (CM: {1}) có tiền NB {2:N0}đ, chỉ bằng {3:F1}% TB chuyên mục ({4:N0}đ).",
                                    tenBai, muc, tien, tb > 0 ? tien / tb * 100 : 0, tb)
                            });
                        }
                    }
                }
            }
            catch { }
            return alerts;
        }

        // ======================================================================
        // LUẬT 3: Điểm AI cao (>=80) nhưng tiền thấp (<150k)
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
                        SELECT Maso, Tenbai, Muc, Butdanh, TienNhuanbut, DiemChatLuongAI
                        FROM Nhuanbut
                        WHERE DiemChatLuongAI >= 80
                          AND TienNhuanbut < 150000
                          AND TienNhuanbut > 0
                          AND TrangThaiDuyet >= 0", conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string tenBai = reader["Tenbai"]?.ToString() ?? "";
                            double diem = Convert.ToDouble(reader["DiemChatLuongAI"]);
                            decimal tien = Convert.ToDecimal(reader["TienNhuanbut"]);

                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "Điểm AI cao nhưng tiền thấp",
                                MucDo = 2,
                                MaBaiViet = Convert.ToInt32(reader["Maso"]),
                                NoiDung = string.Format(
                                    "Bài \"{0}\" có điểm AI {1:N1}/100 nhưng tiền NB chỉ {2:N0}đ. " +
                                    "Bài viết chất lượng cao nhưng nhuận bút thấp bất thường.",
                                    tenBai, diem, tien)
                            });
                        }
                    }
                }
            }
            catch { }
            return alerts;
        }

        // ======================================================================
        // LUẬT 4: Điểm AI thấp (<40) nhưng tiền cao (>=500k)
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
                        SELECT Maso, Tenbai, Muc, Butdanh, TienNhuanbut, DiemChatLuongAI
                        FROM Nhuanbut
                        WHERE DiemChatLuongAI < 40
                          AND TienNhuanbut >= 500000
                          AND TrangThaiDuyet >= 0", conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string tenBai = reader["Tenbai"]?.ToString() ?? "";
                            double diem = Convert.ToDouble(reader["DiemChatLuongAI"]);
                            decimal tien = Convert.ToDecimal(reader["TienNhuanbut"]);

                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "Điểm AI thấp nhưng tiền cao",
                                MucDo = 3,
                                MaBaiViet = Convert.ToInt32(reader["Maso"]),
                                NoiDung = string.Format(
                                    "Bài \"{0}\" chỉ có điểm AI {1:N1}/100 nhưng tiền NB lên tới {2:N0}đ. " +
                                    "Cần kiểm tra lại mức nhuận bút.",
                                    tenBai, diem, tien)
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

                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "PV nhận NB tăng đột biến",
                                MucDo = 3,
                                NoiDung = string.Format(
                                    "PV \"{0}\" nhận {1:N0}đ tháng này, gấp {2:F1} lần TB 3 tháng ({3:N0}đ/tháng). Cần kiểm tra.",
                                    butDanh, thangNay, tb > 0 ? thangNay / tb : 0, tb)
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

                            alerts.Add(new AuditAlert
                            {
                                LoaiCanhBao = "Số bài viết tăng đột biến",
                                MucDo = 2,
                                NoiDung = string.Format(
                                    "PV \"{0}\" có {1} bài tháng này, gấp {2:F1} lần TB 3 tháng ({3:F1} bài/tháng).",
                                    butDanh, soBai, tb > 0 ? soBai / tb : 0, tb)
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
