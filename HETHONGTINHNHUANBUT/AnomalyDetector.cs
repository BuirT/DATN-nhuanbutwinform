using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGTINHNHUANBUT
{
    public static class AnomalyDetector
    {
        private static readonly string connStr =
            System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;

        public class AnomalyResult
        {
            public bool CoBatThuong { get; set; }
            public string[] CanhBao { get; set; } = Array.Empty<string>();
            public MucDo MucDo { get; set; } = MucDo.BinhThuong;
        }

        public enum MucDo { BinhThuong, DeY, CanhBao, NghiemTrong }

        public static async Task<AnomalyResult> KiemTraAsync(
            string tenBai, string butDanh, string muc, decimal tien,
            string maTacGia, string nguoiNhap)
        {
            var result = new AnomalyResult();
            var warnings = new System.Collections.Generic.List<string>();

            using (var conn = new SqlConnection(connStr))
            {
                await conn.OpenAsync();

                // 1. Trùng tên bài
                using (var cmd = new SqlCommand(@"
                    SELECT COUNT(*) FROM Nhuanbut
                    WHERE Tenbai LIKE @tenBai AND TrangThaiDuyet >= 0", conn))
                {
                    cmd.Parameters.AddWithValue("@tenBai", "%" + tenBai.Replace(" ", "%") + "%");
                    int count = (int)await cmd.ExecuteScalarAsync();
                    if (count > 0)
                    {
                        warnings.Add($"⚠️ Có {count} bài đã tồn tại có tên tương tự '{tenBai}'");
                        result.MucDo = MucDo.CanhBao;
                    }
                }

                // 2. Tần suất nộp bài 7 ngày
                using (var cmd = new SqlCommand(@"
                    SELECT COUNT(*) FROM Nhuanbut
                    WHERE Butdanh = @butDanh AND ngaychuyen >= DATEADD(DAY, -7, GETDATE())", conn))
                {
                    cmd.Parameters.AddWithValue("@butDanh", butDanh);
                    int bai7Ngay = (int)await cmd.ExecuteScalarAsync();
                    if (bai7Ngay >= 5)
                    {
                        warnings.Add($"⚠️ Tác giả '{butDanh}' đã nộp {bai7Ngay} bài trong 7 ngày qua");
                        result.MucDo = MucDo.CanhBao;
                    }
                }

                // 3. Tiền vượt định mức
                if (!string.IsNullOrEmpty(muc) && tien > 0)
                {
                    using (var cmd = new SqlCommand(@"SELECT MucToiDa FROM DinhMuc WHERE Muc = @muc", conn))
                    {
                        cmd.Parameters.AddWithValue("@muc", muc);
                        var dbResult = await cmd.ExecuteScalarAsync();
                        if (dbResult != null)
                        {
                            decimal mucToiDa = Convert.ToDecimal(dbResult);
                            if (tien > mucToiDa * 1.5m)
                            {
                                warnings.Add($"🚨 Tiền NB ({tien:N0}đ) vượt 150% định mức ({mucToiDa:N0}đ) của '{muc}'");
                                result.MucDo = MucDo.NghiemTrong;
                            }
                            else if (tien > mucToiDa)
                            {
                                warnings.Add($"⚠️ Tiền NB ({tien:N0}đ) vượt định mức ({mucToiDa:N0}đ) của '{muc}'");
                                if (result.MucDo < MucDo.CanhBao) result.MucDo = MucDo.CanhBao;
                            }
                        }
                    }
                }

                // 4. Tác giả mới mà xin tiền cao
                int tongBai = 0;
                using (var cmd = new SqlCommand(@"
                    SELECT COUNT(*) FROM Nhuanbut WHERE Butdanh = @butDanh", conn))
                {
                    cmd.Parameters.AddWithValue("@butDanh", butDanh);
                    tongBai = (int)await cmd.ExecuteScalarAsync();
                    if (tongBai <= 2 && tien >= 2000000)
                    {
                        warnings.Add($"⚠️ Tác giả '{butDanh}' mới ({tongBai} bài) nhưng xin {tien:N0}đ");
                        if (result.MucDo < MucDo.DeY) result.MucDo = MucDo.DeY;
                    }
                }

                // 5. Thể loại lạ so với lịch sử
                if (!string.IsNullOrEmpty(muc))
                {
                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*) FROM Nhuanbut
                        WHERE Butdanh = @butDanh AND Muc = @muc", conn))
                    {
                        cmd.Parameters.AddWithValue("@butDanh", butDanh);
                        cmd.Parameters.AddWithValue("@muc", muc);
                        int baiTheLoai = (int)await cmd.ExecuteScalarAsync();
                        if (tongBai >= 5 && baiTheLoai == 0)
                        {
                            warnings.Add($"ℹ️ Tác giả '{butDanh}' lần đầu viết thể loại '{muc}' (lạ sân)");
                            if (result.MucDo < MucDo.DeY) result.MucDo = MucDo.DeY;
                        }
                    }
                }

                // 6. Vượt ngân sách tháng (50tr)
                using (var cmd = new SqlCommand(@"
                    SELECT ISNULL(SUM(TienNhuanbut),0) FROM Nhuanbut
                    WHERE MONTH(ngaychuyen)=MONTH(GETDATE()) AND YEAR(ngaychuyen)=YEAR(GETDATE())
                    AND TrangThaiDuyet >= 0", conn))
                {
                    decimal tongThang = (decimal)await cmd.ExecuteScalarAsync();
                    if (tongThang + tien > 50000000)
                    {
                        warnings.Add($"📊 Cảnh báo ngân sách: Tháng này đã chi {tongThang:N0}đ, thêm sẽ gần/vượt 50tr");
                        if (result.MucDo < MucDo.CanhBao) result.MucDo = MucDo.CanhBao;
                    }
                }
            }

            result.CanhBao = warnings.ToArray();
            result.CoBatThuong = warnings.Count > 0;
            return result;
        }
    }
}
