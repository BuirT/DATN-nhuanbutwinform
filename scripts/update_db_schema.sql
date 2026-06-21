USE DATNnhuanbut;
GO

-- 1. Tạo bảng AICanhBao nếu chưa có
IF NOT EXISTS (SELECT * FROM sys.tables WHERE Name = N'AICanhBao')
BEGIN
    CREATE TABLE AICanhBao (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        NgayCanhBao DATETIME NOT NULL DEFAULT GETDATE(),
        LoaiCanhBao NVARCHAR(100) NOT NULL,
        MucDo INT NOT NULL DEFAULT 1,
        MaBaiViet INT NULL,
        MaPhongVien INT NULL,
        NoiDung NVARCHAR(MAX) NULL,
        DaXuLy BIT NOT NULL DEFAULT 0
    );
    PRINT N'Da tao bang AICanhBao';
END
GO

-- 2. Thêm cột cho bảng Nhuanbut
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NoiDungBaiViet' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD NoiDungBaiViet NVARCHAR(MAX);
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DanhGiaAI' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD DanhGiaAI NVARCHAR(MAX);
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayDanhGiaAI' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD NgayDanhGiaAI DATETIME;
GO

-- 3. Xoa DiemChatLuongAI neu con
IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'DiemChatLuongAI' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut DROP COLUMN DiemChatLuongAI;
GO

PRINT N'Cap nhat schema hoan tat!';
GO
