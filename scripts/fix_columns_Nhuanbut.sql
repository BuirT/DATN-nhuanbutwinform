-- ============================================================
-- Fix: Thêm các cột còn thiếu trong bảng Nhuanbut
-- Chạy script này trong SQL Server Management Studio (SSMS)
-- ============================================================

USE DATNnhuanbut;
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TrangThaiDuyet' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD TrangThaiDuyet INT DEFAULT 0;
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiNhap' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD NguoiNhap NVARCHAR(100);
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiKiemTra' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD NguoiKiemTra NVARCHAR(100);
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiKeToan' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD NguoiKeToan NVARCHAR(100);
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TongThuKy' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD TongThuKy NVARCHAR(100);
GO

-- Cập nhật TrangThaiDuyet cũ (2 -> 3)
IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'TrangThaiDuyet' AND Object_ID = Object_ID(N'Nhuanbut'))
    UPDATE Nhuanbut SET TrangThaiDuyet = 3 WHERE TrangThaiDuyet = 2;
GO

PRINT '✅ Hoàn tất fix cột cho bảng Nhuanbut!';
