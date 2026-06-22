using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT
{
    public class KiemDuyetService
    {
        private readonly string _connectionString;

        public KiemDuyetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DataTable> LoadDataAsync(int trangThaiHienTai, string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                string query = @"
                    SELECT n.Maso, n.Tenbai, n.Trang, n.Muc, n.Butdanh, 
                           n.TienNhuanbut,
                           n.NoiDungBaiViet,
                           n.DiemChatLuongAI,
                           n.NguoiNhap, n.NguoiChamTien, n.NguoiKeToan, n.NguoiKiemTra, n.TongThuKy,
                           n.LyDoBaoSai,
                           n.ngaychuyen AS NgayNhap,
                           n.NgayChamTien, n.NgayNhapLieu, n.NgayKiemTra, n.NgayKy,
                           b.Tenbao AS TenSoBao,
                           n.TrangThaiDuyet,
                           n.DanhGiaAI
                    FROM Nhuanbut n
                    LEFT JOIN Bao b ON n.MsBao = b.Maso";

                bool isAdmin = trangThaiHienTai == -1;
                if (!isAdmin)
                    query += " WHERE n.TrangThaiDuyet = @tt";

                if (!string.IsNullOrWhiteSpace(keyword))
                    query += (isAdmin ? " WHERE" : " AND") + " (n.Tenbai LIKE @kw OR n.Butdanh LIKE @kw OR n.NguoiNhap LIKE @kw)";

                query += " ORDER BY n.ngaychuyen DESC";

                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!isAdmin)
                        cmd.Parameters.AddWithValue("@tt", trangThaiHienTai);
                    if (!string.IsNullOrWhiteSpace(keyword))
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    string trangVal = row["Trang"]?.ToString() ?? "";
                    row["Trang"] = Regex.Replace(trangVal, @"^\D+", "");
                }

                return dt;
            }
        }

        public async Task<bool> ExecuteApprovalAsync(string maSo, int trangThaiMoi, string role, string nguoiDangNhap, decimal? tien, string nguoiKy)
        {
            string sql = GetApprovalSql(role);
            if (sql == null) return false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tt", trangThaiMoi);
                    cmd.Parameters.AddWithValue("@ma", maSo);

                    switch (role)
                    {
                        case "thư ký":
                            cmd.Parameters.AddWithValue("@tien", tien ?? 0);
                            cmd.Parameters.AddWithValue("@nguoi", nguoiDangNhap ?? "Thư ký");
                            break;
                        case "kế toán":
                            cmd.Parameters.AddWithValue("@nguoi", nguoiDangNhap ?? "Kế toán");
                            break;
                        case "kiểm tra viên":
                            cmd.Parameters.AddWithValue("@nguoi", nguoiDangNhap ?? "Kiểm tra viên");
                            break;
                        case "tổng thư ký":
                            cmd.Parameters.AddWithValue("@nguoi", nguoiKy ?? "");
                            break;
                    }

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return true;
        }

        public async Task<bool> ExecuteRejectionAsync(string maSo, int trangThaiVe, string role, string lyDo = null)
        {
            string sql = GetRejectionSql(role);
            if (sql == null) return false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tt", trangThaiVe);
                    cmd.Parameters.AddWithValue("@ma", maSo);
                    if (role == "kế toán" && !string.IsNullOrEmpty(lyDo))
                        cmd.Parameters.AddWithValue("@lydo", lyDo);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return true;
        }

        public async Task<AnomalyDetector.AnomalyResult> KiemTraBatThuongAsync(string tenBai, string butDanh, string muc, decimal tien, string maSo)
        {
            return await AnomalyDetector.KiemTraAsync(tenBai, butDanh, muc, tien, "", "", maSo);
        }

        private string GetApprovalSql(string role)
        {
            switch (role)
            {
                case "thư ký":
                    return @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            TienNhuanbut = @tien,
                            NguoiChamTien = @nguoi,
                            NgayChamTien = GETDATE(),
                            LyDoBaoSai = NULL,
                            NgayBaoSai = NULL
                            WHERE Maso = @ma";
                case "kế toán":
                    return @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            NguoiKeToan = @nguoi,
                            NgayNhapLieu = GETDATE()
                            WHERE Maso = @ma";
                case "kiểm tra viên":
                    return @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            NguoiKiemTra = @nguoi,
                            NgayKiemTra = GETDATE()
                            WHERE Maso = @ma";
                case "tổng thư ký":
                    return @"UPDATE Nhuanbut SET 
                            TrangThaiDuyet = @tt, 
                            TongThuKy = @nguoi,
                            NgayKy = GETDATE()
                            WHERE Maso = @ma";
                case "admin":
                case "quản trị viên":
                    return @"UPDATE Nhuanbut SET TrangThaiDuyet = @tt WHERE Maso = @ma";
                default:
                    return null;
            }
        }

        private string GetRejectionSql(string role)
        {
            switch (role)
            {
                case "thư ký":
                case "kiểm tra viên":
                case "tổng thư ký":
                    return "UPDATE Nhuanbut SET TrangThaiDuyet = @tt WHERE Maso = @ma";
                case "kế toán":
                    return "UPDATE Nhuanbut SET TrangThaiDuyet = @tt, LyDoBaoSai = @lydo, NgayBaoSai = GETDATE() WHERE Maso = @ma";
                case "admin":
                case "quản trị viên":
                    return @"UPDATE Nhuanbut SET TrangThaiDuyet = @tt, TienNhuanbut = 0, 
                            NguoiChamTien = NULL, NgayChamTien = NULL, 
                            NguoiKeToan = NULL, NgayNhapLieu = NULL, 
                            NguoiKiemTra = NULL, NgayKiemTra = NULL, 
                            TongThuKy = NULL, NgayKy = NULL, 
                            LyDoBaoSai = NULL, NgayBaoSai = NULL WHERE Maso = @ma";
                default:
                    return null;
            }
        }
    }
}
