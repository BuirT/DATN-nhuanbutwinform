-- ============================================================
-- Rollback: Xoá các cột đã thêm (nếu cần back lại)
-- ============================================================

USE DATNnhuanbut;
GO

IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'TrangThaiDuyet' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut DROP COLUMN TrangThaiDuyet;
GO

IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiNhap' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut DROP COLUMN NguoiNhap;
GO

IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiKiemTra' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut DROP COLUMN NguoiKiemTra;
GO

IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'NguoiKeToan' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut DROP COLUMN NguoiKeToan;
GO

IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'TongThuKy' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut DROP COLUMN TongThuKy;
GO

PRINT '✅ Đã rollback - xoá các cột đã thêm!';
