using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT
{
    public static class DatabaseMigrator
    {
        private static bool _dbFixed = false;

        public static async Task AutoFixDatabaseColumnsAsync()
        {
            if (_dbFixed) return;
            _dbFixed = true;

            string cn = System.Configuration.ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(cn))
                {
                    await conn.OpenAsync();

                    string fixNhuanbut = @"
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TrangThaiDuyet' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD TrangThaiDuyet INT DEFAULT 0;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiNhap' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiNhap NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiKiemTra' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiKiemTra NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiKeToan' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiKeToan NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TongThuKy' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD TongThuKy NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiChamTien' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NguoiChamTien NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LyDoBaoSai' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD LyDoBaoSai NVARCHAR(500);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayBaoSai' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayBaoSai DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DiemChatLuongAI' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD DiemChatLuongAI INT;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DanhGiaAI' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD DanhGiaAI NVARCHAR(MAX);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayDanhGiaAI' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayDanhGiaAI DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NoiDungBaiViet' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NoiDungBaiViet NVARCHAR(MAX);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayChamTien' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayChamTien DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayNhapLieu' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayNhapLieu DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayKiemTra' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayKiemTra DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayKy' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD NgayKy DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DaThanhToan' AND Object_ID = Object_ID(N'Nhuanbut'))
                            ALTER TABLE Nhuanbut ADD DaThanhToan BIT DEFAULT 0;
                        UPDATE Nhuanbut SET TrangThaiDuyet = 0 WHERE TrangThaiDuyet IS NULL;";
                    using (SqlCommand cmd = new SqlCommand(fixNhuanbut, conn))
                        await cmd.ExecuteNonQueryAsync();

                    string fixNhuanbutCT = @"
                        IF NOT EXISTS(SELECT * FROM sys.objects WHERE Name = N'NhuanbutCT' AND Type = N'U')
                            CREATE TABLE NhuanbutCT (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                MsTacgia NVARCHAR(50),
                                MsNhuanbut INT,
                                Sotien DECIMAL(18,0),
                                SoPC NVARCHAR(50),
                                SauThanhToan NVARCHAR(10)
                            );";
                    using (SqlCommand cmdCT = new SqlCommand(fixNhuanbutCT, conn))
                        await cmdCT.ExecuteNonQueryAsync();

                    string fixPhieuchi = @"
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TrangThaiDuyet' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD TrangThaiDuyet INT DEFAULT 0;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiDuyet' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD NguoiDuyet NVARCHAR(100);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayDuyet' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD NgayDuyet DATETIME;
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'LyDoTuChoi' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD LyDoTuChoi NVARCHAR(MAX);
                        IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Dathutien' AND Object_ID = Object_ID(N'Phieuchi'))
                            ALTER TABLE Phieuchi ADD Dathutien NVARCHAR(1) DEFAULT 'N';
                        UPDATE Phieuchi SET TrangThaiDuyet = 0 WHERE TrangThaiDuyet IS NULL;";
                    using (SqlCommand cmd2 = new SqlCommand(fixPhieuchi, conn))
                        await cmd2.ExecuteNonQueryAsync();

                    string fixDinhMuc = @"
                        IF NOT EXISTS(SELECT * FROM sys.tables WHERE Name = N'DinhMuc')
                        BEGIN
                            CREATE TABLE DinhMuc (
                                MaDinhMuc INT IDENTITY(1,1) PRIMARY KEY,
                                Muc NVARCHAR(100) NOT NULL,
                                MucToiDa DECIMAL(18,0) NOT NULL DEFAULT 2000000,
                                NgayTao DATETIME DEFAULT GETDATE()
                            );

                            INSERT INTO DinhMuc (Muc, MucToiDa) VALUES
                                (N'Tin vắn', 500000),
                                (N'Phân tích', 3000000),
                                (N'Phỏng vấn', 2500000),
                                (N'Bài đinh', 4000000),
                                (N'Xã luận', 5000000),
                                (N'Phóng sự', 3000000),
                                (N'Góc nhìn', 2000000),
                                (N'Văn hóa', 2000000),
                                (N'Công nghệ', 2000000),
                                (N'Thể thao', 2000000),
                                (N'Kinh tế', 2500000),
                                (N'Chính trị', 3000000);
                        END";
                    using (SqlCommand cmd3 = new SqlCommand(fixDinhMuc, conn))
                        await cmd3.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi DB: " + ex.Message);
            }
        }
    }
}
