-- ============================================================
-- Add AI Content Evaluation columns to Nhuanbut table
-- Chạy script này trong SQL Server Management Studio (SSMS)
-- ============================================================

USE DATNnhuanbut;
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NoiDungBaiViet' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD NoiDungBaiViet NVARCHAR(MAX);
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DanhGiaAI' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD DanhGiaAI NVARCHAR(MAX);
GO

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'NgayDanhGiaAI' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut ADD NgayDanhGiaAI DATETIME;
GO

-- Remove DiemChatLuongAI column (AI score no longer needed)
IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'DiemChatLuongAI' AND Object_ID = Object_ID(N'Nhuanbut'))
    ALTER TABLE Nhuanbut DROP COLUMN DiemChatLuongAI;
GO

PRINT N'Đã cập nhật cột AI (xoá DiemChatLuongAI) trong bảng Nhuanbut!';
GO
