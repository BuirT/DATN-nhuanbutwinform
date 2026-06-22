-- ============================================================
-- Create AI Audit Alert table (AICanhBao)
-- Chạy script này trong SQL Server Management Studio (SSMS)
-- ============================================================

USE DATNnhuanbut;
GO

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
        DaXuLy BIT NOT NULL DEFAULT 0,
        GiaTriPhatHien NVARCHAR(500) NULL
    );

    PRINT N'Đã tạo bảng AICanhBao!';
END
ELSE
BEGIN
    PRINT N'Bảng AICanhBao đã tồn tại!';
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE Name = N'IX_AICanhBao_NgayCanhBao' AND Object_ID = Object_ID(N'AICanhBao'))
    CREATE INDEX IX_AICanhBao_NgayCanhBao ON AICanhBao(NgayCanhBao DESC);
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE Name = N'IX_AICanhBao_MucDo' AND Object_ID = Object_ID(N'AICanhBao'))
    CREATE INDEX IX_AICanhBao_MucDo ON AICanhBao(MucDo);
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE Name = N'IX_AICanhBao_DaXuLy' AND Object_ID = Object_ID(N'AICanhBao'))
    CREATE INDEX IX_AICanhBao_DaXuLy ON AICanhBao(DaXuLy);
GO
