USE [master]
GO

IF DB_ID('DATNnhuanbut') IS NOT NULL
BEGIN
    ALTER DATABASE [DATNnhuanbut] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE [DATNnhuanbut]
END
GO

CREATE DATABASE [DATNnhuanbut]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'DATNnhuanbut_Data', FILENAME = N'D:\2.Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DATNnhuanbut.mdf', SIZE = 102400KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON
( NAME = N'DATNnhuanbut_Log', FILENAME = N'D:\2.Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DATNnhuanbut_log.ldf', SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
GO

ALTER DATABASE [DATNnhuanbut] SET COMPATIBILITY_LEVEL = 150
GO

USE [DATNnhuanbut]
GO

-- ============================================
-- 1. BANG DANH MUC
-- ============================================

-- 1.1. Loai bao
CREATE TABLE [dbo].[Loaibao](
    [Maso] [varchar](4) NOT NULL,
    [Tenloai] [nvarchar](200) NULL,
    CONSTRAINT [PK_Loaibao] PRIMARY KEY NONCLUSTERED ([Maso] ASC)
) ON [PRIMARY]
GO

-- 1.2. Vung
CREATE TABLE [dbo].[Vung](
    [Maso] [nvarchar](50) NOT NULL,
    [Tenvung] [nvarchar](50) NULL,
    CONSTRAINT [PK_Vung] PRIMARY KEY CLUSTERED ([Maso] ASC)
) ON [PRIMARY]
GO

-- 1.3. Trang
CREATE TABLE [dbo].[trang](
    [trang] [varchar](10) NULL
) ON [PRIMARY]
GO

-- 1.4. Tham so he thong
CREATE TABLE [dbo].[gThongso](
    [Maso] [varchar](50) NOT NULL,
    [Giatri] [varchar](50) NULL,
    CONSTRAINT [PK_gThongso] PRIMARY KEY NONCLUSTERED ([Maso] ASC)
) ON [PRIMARY]
GO

-- 1.5. Cong tac vien
CREATE TABLE [dbo].[ctv](
    [hoten] [varchar](255) NULL,
    [cmnd] [varchar](20) NULL,
    [mst] [varchar](20) NULL,
    [dt] [varchar](20) NULL
) ON [PRIMARY]
GO

-- ============================================
-- 2. BANG NGHIEP VU CHINH
-- ============================================

-- 2.1. Bao (Ky bao / So bao)
CREATE TABLE [dbo].[Bao](
    [Maso] [int] NOT NULL,
    [Tenbao] [nvarchar](255) NULL,
    [Ngayra] [datetime] NULL,
    [Sobao] [char](10) NULL,
    [Sobo] [char](10) NULL,
    [Loaibao] [varchar](4) NULL,
    [DaDuyet] [char](1) NULL CONSTRAINT [DF_Bao_DaDuyet] DEFAULT ('N'),
    CONSTRAINT [PK_Bao] PRIMARY KEY CLUSTERED ([Maso] ASC)
) ON [PRIMARY]
GO

-- 2.2. Tac gia (Phong vien, Cong tac vien)
CREATE TABLE [dbo].[TacGia](
    [Maso] [char](6) NOT NULL,
    [MsTG] [varchar](20) NULL,
    [Hoten] [nvarchar](50) NULL,
    [Ngaysinh] [datetime] NULL CONSTRAINT [DF_TacGia_Ngaysinh] DEFAULT (''),
    [Diachi] [nvarchar](100) NULL,
    [Dienthoai] [nvarchar](255) NULL,
    [Ddong] [nvarchar](20) NULL,
    [LoaiTacgia] [nvarchar](100) NULL,
    [Email] [nvarchar](255) NULL,
    [Hoten_Unicode] [nvarchar](100) NULL,
    [NganHang] [nvarchar](200) NULL,
    [PhongBan] [nvarchar](200) NULL,
    [SoTaiKhoan] [nvarchar](50) NULL,
    [AvatarPath] [nvarchar](MAX) NULL,
    [PdfPath] [nvarchar](MAX) NULL,
    CONSTRAINT [PK_TacGia_1] PRIMARY KEY CLUSTERED ([Maso] ASC)
) ON [PRIMARY]
GO

-- 2.3. But danh
CREATE TABLE [dbo].[Butdanh](
    [Maso] [int] IDENTITY(1000,1) NOT NULL,
    [Butdanh] [nvarchar](50) NULL,
    [MsTacgia] [char](6) NULL,
    CONSTRAINT [PK_Butdanh] PRIMARY KEY NONCLUSTERED ([Maso] ASC)
) ON [PRIMARY]
GO

-- 2.4. Nhuan but (Bai viet)
CREATE TABLE [dbo].[Nhuanbut](
    [Maso] [int] NOT NULL,
    [Tenbai] [nvarchar](200) NULL,
    [Trang] [nvarchar](50) NULL,
    [Muc] [nvarchar](50) NULL,
    [TienNhuanbut] [money] NULL,
    [Butdanh] [nvarchar](100) NULL,
    [MsBao] [int] NULL,
    [Vung] [nvarchar](6) NULL,
    [VungChuyenDen] [nvarchar](6) NULL,
    [NgoaiGio] [char](1) NULL,
    [STT] [int] NULL,
    [addby] [char](10) NULL,
    [ngaychuyen] [datetime] NULL,
    [NgayNhap] [datetime] NULL,
    [TenSoBao] [nvarchar](200) NULL,
    [DaThanhToan] [bit] NOT NULL CONSTRAINT [DF_Nhuanbut_DaThanhToan] DEFAULT (0),
    [MaPhieuChi] [varchar](20) NULL,
    CONSTRAINT [PK_Nhuanbut] PRIMARY KEY CLUSTERED ([Maso] ASC),
    CONSTRAINT [FK_Nhuanbut_Bao] FOREIGN KEY ([MsBao]) REFERENCES [dbo].[Bao]([Maso])
) ON [PRIMARY]
GO

-- 2.5. Phieu chi
CREATE TABLE [dbo].[Phieuchi](
    [Sophieu] [varchar](20) NOT NULL,
    [Ngaylap] [datetime] NULL,
    [Sotien] [money] NULL,
    [Thue] [money] NULL,
    [Conlai] [money] NULL,
    [Lydo] [nvarchar](MAX) NULL,
    [Nguoinhan] [nvarchar](100) NULL,
    [Tacgia] [nvarchar](100) NULL,
    [Nguoilap] [nvarchar](100) NULL,
    [Thuquy] [nvarchar](100) NULL,
    [Dathutien] [char](1) NULL CONSTRAINT [DF_Phieuchi_Dathutien] DEFAULT ('N'),
    [loaiTT] [char](2) NULL,
    [addby] [char](10) NULL,
    [MST] [nvarchar](50) NULL,
    [CMND] [nvarchar](50) NULL,
    [Dienthoai] [nvarchar](50) NULL,
    [Thuesuat] [real] NULL,
    [TrangThaiDuyet] [int] NOT NULL CONSTRAINT [DF_Phieuchi_TrangThaiDuyet] DEFAULT (0),
    [NguoiDuyet] [nvarchar](100) NULL,
    [NgayDuyet] [datetime] NULL,
    [LyDoTuChoi] [nvarchar](MAX) NULL,
    CONSTRAINT [PK_Phieuchi] PRIMARY KEY CLUSTERED ([Sophieu] ASC)
) ON [PRIMARY]
GO

-- 2.6. Nhuan but chi tiet (Lien ket Phieu chi - Nhuan but)
CREATE TABLE [dbo].[NhuanbutCT](
    [MsTacgia] [char](6) NOT NULL,
    [MsNhuanbut] [int] NOT NULL,
    [Sotien] [money] NULL,
    [Thue] [money] NULL,
    [Conlai] [money] NULL,
    [SoPC] [varchar](20) NULL,
    [SauThanhToan] [char](1) NULL,
    [DotTT] [int] NULL,
    CONSTRAINT [PK_NhuanbutCT] PRIMARY KEY NONCLUSTERED ([MsTacgia] ASC, [MsNhuanbut] ASC),
    CONSTRAINT [FK_NhuanbutCT_Phieuchi] FOREIGN KEY ([SoPC]) REFERENCES [dbo].[Phieuchi]([Sophieu])
) ON [PRIMARY]
GO

-- 2.7. Thanh toan
CREATE TABLE [dbo].[ThanhToan](
    [Maso] [int] NOT NULL,
    [Tengoi] [nvarchar](100) NULL,
    [Ngay] [datetime] NULL,
    [Tungay] [datetime] NULL,
    [Denngay] [datetime] NULL,
    [Loaibao] [char](3) NULL,
    [Sotien] [money] NULL,
    [Vung] [char](3) NULL,
    [LoaiTT] [char](2) NULL,
    [Khoaso] [char](1) NULL CONSTRAINT [DF_ThanhToan_Khoaso] DEFAULT ('N'),
    [hinhthucTT] [char](2) NULL,
    CONSTRAINT [PK_ThanhToan] PRIMARY KEY NONCLUSTERED ([Maso] ASC)
) ON [PRIMARY]
GO

-- 2.8. Thanh toan chi tiet
CREATE TABLE [dbo].[ThanhToanCT](
    [MsThanhToan] [int] NOT NULL,
    [MsBao] [int] NOT NULL,
    [Ngayra] [char](10) NULL,
    [Tongnhuanbut] [money] NULL,
    [Dachitra] [money] NULL,
    [Conno] [money] NULL
) ON [PRIMARY]
GO

-- ============================================
-- 3. BANG NGUOI DUNG (NEW - for WinForms app)
-- ============================================

CREATE TABLE [dbo].[Users](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [TenDangNhap] [nvarchar](100) NOT NULL,
    [MatKhau] [nvarchar](500) NOT NULL,
    [Salt] [nvarchar](100) NULL,
    [HoTen] [nvarchar](200) NULL,
    [Quyen] [nvarchar](50) NULL,
    [HoatDong] [bit] NOT NULL CONSTRAINT [DF_Users_HoatDong] DEFAULT (1),
    [MaTacGiaGoc] [nvarchar](50) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Users_TenDangNhap] UNIQUE ([TenDangNhap])
) ON [PRIMARY]
GO

-- ============================================
-- 4. BANG TAM (Temp tables for reports)
-- ============================================

CREATE TABLE [dbo].[tmpNhuanBut](
    [STT] [int] NULL,
    [Maso] [int] NULL,
    [TenBai] [varchar](255) NULL,
    [Trang] [varchar](20) NULL,
    [Muc] [varchar](50) NULL,
    [ButDanh] [varchar](100) NULL,
    [SoTien] [money] NULL,
    [KyNhan] [varchar](50) NULL,
    [ID] [bigint] IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_tmpNhuanBut] PRIMARY KEY CLUSTERED ([ID] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tmpChuyen](
    [STT] [char](10) NULL,
    [Maso] [int] NULL,
    [Tenbai] [varchar](255) NULL,
    [Butdanh] [varchar](50) NULL,
    [Sotien] [money] NULL,
    [ChuyenTu] [char](3) NULL,
    [SotienTu] [money] NULL,
    [ChuyenDen] [char](3) NULL,
    [SotienDen] [money] NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tmpCongNo](
    [STT] [int] NULL,
    [MsBao] [int] NULL,
    [Ngayra] [char](10) NULL,
    [TongNhuanbut] [money] NULL,
    [Dachitra] [money] NULL,
    [Conno] [money] NULL,
    [Chibosung] [money] NULL,
    [Ghichu] [varchar](50) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tmpCongNoTacGia](
    [STT] [int] NULL,
    [Ngayra] [char](10) NULL,
    [Tenbai] [varchar](255) NULL,
    [Butdanh] [varchar](100) NULL,
    [Loaibao] [char](3) NULL,
    [Sotien] [money] NULL,
    [SoPC] [varchar](20) NULL,
    [Conlai] [money] NULL,
    [id] [bigint] IDENTITY(1,1) NOT NULL,
    [email] [varchar](255) NULL,
    CONSTRAINT [PK_tmpCongNoTacGia] PRIMARY KEY CLUSTERED ([id] ASC)
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tmpCongNoThang](
    [STT] [int] NULL,
    [Thang] [char](10) NULL,
    [TongNhuanBut] [money] NULL,
    [DaChiTra] [money] NULL,
    [ConNo] [money] NULL,
    [ChiBoSung] [money] NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tmpCongNoTong](
    [Maso] [char](6) NOT NULL,
    [Hoten] [varchar](50) NULL,
    [Sotien] [money] NULL,
    [DaTT] [money] NULL,
    [Conlai] [money] NULL
) ON [PRIMARY]
GO

-- ============================================
-- 5. VIEW
-- ============================================

CREATE VIEW [dbo].[vwNhuanbutCT]
AS
SELECT
    NhuanbutCT.MsTacgia,
    NhuanbutCT.MsNhuanbut,
    NhuanbutCT.Sotien,
    Bao.Ngayra,
    NhuanbutCT.SoPC,
    Bao.Loaibao,
    Nhuanbut.Vung
FROM Nhuanbut
INNER JOIN NhuanbutCT ON Nhuanbut.Maso = NhuanbutCT.MsNhuanbut
INNER JOIN Bao ON Nhuanbut.MsBao = Bao.Maso
GO

-- ============================================
-- 6. DU LIEU MAU (SAMPLE DATA)
-- ============================================

-- 6.1. Loai bao
INSERT INTO [dbo].[Loaibao] ([Maso], [Tenloai]) VALUES
('BĐS', N'Bất động sản'),
('GD',  N'Giáo dục'),
('KT',  N'Kinh tế'),
('PLS', N'Pháp luật & Xã hội'),
('TD',  N'Thể dục - Thể thao'),
('VH',  N'Văn hóa - Giải trí'),
('XN',  N'Xã hội - Nhân văn'),
('TT',  N'Thời trang'),
('CT',  N'Chính trị'),
('CN',  N'Công nghệ')
GO

-- 6.2. Vung
INSERT INTO [dbo].[Vung] ([Maso], [Tenvung]) VALUES
('All',  N'Tất cả'),
('MT',   N'Miền Trung'),
('MB',   N'Miền Bắc'),
('MN',   N'Miền Nam'),
('TG',   N'Thế giới'),
('QTe',  N'Quốc tế')
GO

-- 6.3. Trang
INSERT INTO [dbo].[trang] ([trang]) VALUES
('Trang 1'), ('Trang 2'), ('Trang 3'), ('Trang 4'), ('Trang 5')
GO

-- 6.4. Tham so
INSERT INTO [dbo].[gThongso] ([Maso], [Giatri]) VALUES
('ThueSuat', '10'),
('HeSoNhuanBut', '1.5'),
('TyLeThue', '10'),
('NganSachThang', '50000000')
GO

-- 6.5. Tac gia
INSERT INTO [dbo].[TacGia] ([Maso], [MsTG], [Hoten], [Ngaysinh], [Diachi], [Dienthoai], [Ddong], [LoaiTacgia], [Email], [NganHang], [PhongBan], [SoTaiKhoan]) VALUES
('TG0001', '079201012345', N'Nguyễn Văn An',      '1990-03-15', N'Hà Nội',     '0912345678', '123456789', 'PV', N'an.nguyen@baox.vn',     N'Vietcombank',  N'Ban Thư ký',       '1010101010101'),
('TG0002', '079202098765', N'Trần Thị Bình',      '1992-07-22', N'TP HCM',    '0987654321', '987654321', 'PV', N'binh.tran@baox.vn',     N'Techcombank',  N'Ban Kinh tế',     '2020202020202'),
('TG0003', '079203011111', N'Lê Văn Cường',       '1988-01-10', N'Đà Nẵng',   '0905123456', '112233445', 'PV', N'cuong.le@baox.vn',      N'ACB',           N'Ban Xã hội',      '3030303030303'),
('TG0004', '079204022222', N'Phạm Thị Dung',      '1995-09-05', N'Hải Phòng', '0933123456', '554433221', 'CTV', N'dung.pham@baox.vn',    N'BIDV',          N'Ban Văn hóa',     '4040404040404'),
('TG0005', '079205033333', N'Hoàng Văn Em',        '1993-12-25', N'Cần Thơ',   '0977123456', '998877665', 'PV', N'em.hoang@baox.vn',       N'MB Bank',       N'Ban Pháp luật',   '5050505050505'),
('TG0006', '079206044444', N'Đỗ Thị Phương',       '1991-06-18', N'Huế',       '0944123456', '667788990', 'CTV', N'phuong.do@baox.vn',    N'VietinBank',    N'Ban Thể thao',    '6060606060606'),
('TG0007', '079207055555', N'Vũ Văn Giang',        '1987-04-30', N'Quảng Ninh','0966123456', '223344556', 'PV', N'giang.vu@baox.vn',       N'OCB',           N'Ban Công nghệ',   '7070707070707'),
('TG0008', '079208066666', N'Bùi Thị Hạnh',        '1994-08-12', N'Nam Định',  '0955123456', '778899001', 'PV', N'hanh.bui@baox.vn',      N'VPBank',        N'Ban Thư ký',       '8080808080808')
GO

-- 6.6. But danh
INSERT INTO [dbo].[Butdanh] ([Butdanh], [MsTacgia]) VALUES
(N'Nguyễn An',       'TG0001'),
(N'Trần Bình',       'TG0002'),
(N'Lê Cường',        'TG0003'),
(N'Phạm Dung',       'TG0004'),
(N'Hoàng Em',        'TG0005'),
(N'Đỗ Phương',       'TG0006'),
(N'Vũ Giang',        'TG0007'),
(N'Bùi Hạnh',        'TG0008'),
(N'An Bình',         'TG0001'),
(N'Phương Nam',      'TG0006')
GO

-- 6.7. Bao
INSERT INTO [dbo].[Bao] ([Maso], [Tenbao], [Ngayra], [Sobao], [Sobo], [Loaibao], [DaDuyet]) VALUES
(1, N'Báo Xuân 2025',                          '2025-01-01', '01/2025', '01', 'XN', 'Y'),
(2, N'Chào năm mới 2025',                      '2025-01-15', '02/2025', '01', 'CT', 'Y'),
(3, N'Kinh tế Việt Nam 2025',                  '2025-02-01', '03/2025', '02', 'KT', 'Y'),
(4, N'Giáo dục - Đào tạo tháng 2',             '2025-02-15', '04/2025', '02', 'GD', 'Y'),
(5, N'Công nghệ số',                            '2025-03-01', '05/2025', '03', 'CN', 'Y'),
(6, N'Bất động sản đầu năm',                    '2025-03-15', '06/2025', '03', 'BĐS', 'Y'),
(7, N'Thể thao tuần qua',                       '2025-03-20', '07/2025', '03', 'TD', 'Y'),
(8, N'Văn hóa - Giải trí cuối tuần',            '2025-04-05', '08/2025', '04', 'VH', 'Y'),
(9, N'Pháp luật & Xã hội',                     '2025-04-15', '09/2025', '04', 'PLS', 'Y'),
(10, N'Thời trang xuân hè 2025',               '2025-05-01', '10/2025', '05', 'TT', 'Y'),
(11, N'Báo tháng 6 - Kinh tế số',               '2025-06-01', '11/2025', '06', 'KT', 'N'),
(12, N'Công nghệ thông tin số 12',              '2025-06-15', '12/2025', '06', 'CN', 'N')
GO

-- 6.8. Nhuan but
INSERT INTO [dbo].[Nhuanbut] ([Maso], [Tenbai], [Trang], [Muc], [TienNhuanbut], [Butdanh], [MsBao], [Vung], [addby], [ngaychuyen], [NgayNhap], [TenSoBao], [DaThanhToan]) VALUES
(1,  N'Xuân về trên mọi nẻo đường',               N'Trang 1', N'Chính luận', 200000,  N'Nguyễn An',  1, 'MB', 'admin', '2025-01-01', '2025-01-01', N'01/2025', 1),
(2,  N'Phong tục ngày Tết Việt Nam',              N'Trang 2', N'Xã hội',     150000,  N'Nguyễn An',  1, 'All', 'admin', '2025-01-01', '2025-01-01', N'01/2025', 1),
(3,  N'Phát triển kinh tế 2025',                  N'Trang 1', N'Kinh tế',    250000,  N'Trần Bình',  2, 'MB', 'admin', '2025-01-15', '2025-01-15', N'02/2025', 1),
(4,  N'Đầu tư công nghệ trong giáo dục',           N'Trang 3', N'Giáo dục',   180000,  N'Lê Cường',   2, 'All', 'admin', '2025-01-15', '2025-01-15', N'02/2025', 1),
(5,  N'GDP Việt Nam tăng trưởng ấn tượng',         N'Trang 1', N'Kinh tế',    300000,  N'Trần Bình',  3, 'MB', 'admin', '2025-02-01', '2025-02-01', N'03/2025', 1),
(6,  N'Doanh nghiệp nhỏ và vừa',                 N'Trang 2', N'Kinh tế',    220000,  N'Hoàng Em',   3, 'All', 'admin', '2025-02-01', '2025-02-01', N'03/2025', 1),
(7,  N'Đổi mới chương trình đào tạo',             N'Trang 1', N'Giáo dục',   160000,  N'Phạm Dung',  4, 'MB', 'admin', '2025-02-15', '2025-02-15', N'04/2025', 0),
(8,  N'Du học - Cơ hội và thách thức',             N'Trang 2', N'Giáo dục',   140000,  N'Phạm Dung',  4, 'All', 'admin', '2025-02-15', '2025-02-15', N'04/2025', 0),
(9,  N'AI và tương lai ngành báo chí',             N'Trang 1', N'Công nghệ',  280000,  N'Vũ Giang',   5, 'MB', 'admin', '2025-03-01', '2025-03-01', N'05/2025', 0),
(10, N'Blockchain trong quản lý bản quyền',        N'Trang 2', N'Công nghệ',  200000,  N'Vũ Giang',   5, 'All', 'admin', '2025-03-01', '2025-03-01', N'05/2025', 0),
(11, N'Thị trường bất động sản quý 1',            N'Trang 1', N'Kinh tế',    350000,  N'Hoàng Em',   6, 'MB', 'admin', '2025-03-15', '2025-03-15', N'06/2025', 0),
(12, N'Chung cư mini - Thực trạng',               N'Trang 3', N'Xã hội',     180000,  N'Bùi Hạnh',   6, 'All', 'admin', '2025-03-15', '2025-03-15', N'06/2025', 0),
(13, N'Giải bóng đá U23 Châu Á',                   N'Trang 1', N'Thể thao',   150000,  N'Đỗ Phương',  7, 'All', 'admin', '2025-03-20', '2025-03-20', N'07/2025', 0),
(14, N'VĐV điền kinh Việt Nam',                    N'Trang 2', N'Thể thao',   120000,  N'Đỗ Phương',  7, 'All', 'admin', '2025-03-20', '2025-03-20', N'07/2025', 0),
(15, N'Triển lãm tranh đương đại',                N'Trang 1', N'Văn hóa',    190000,  N'Nguyễn An',  8, 'All', 'admin', '2025-04-05', '2025-04-05', N'08/2025', 0),
(16, N'Phim Việt Nam bội thu dịp lễ',             N'Trang 2', N'Văn hóa',    170000,  N'Trần Bình',  8, 'All', 'admin', '2025-04-05', '2025-04-05', N'08/2025', 0),
(17, N'Tội phạm công nghệ cao',                   N'Trang 1', N'Pháp luật',  260000,  N'Lê Cường',   9, 'All', 'admin', '2025-04-15', '2025-04-15', N'09/2025', 0),
(18, N'Bảo vệ quyền lợi người tiêu dùng',          N'Trang 3', N'Pháp luật',  210000,  N'Bùi Hạnh',   9, 'All', 'admin', '2025-04-15', '2025-04-15', N'09/2025', 0),
(19, N'Xu hướng thời trang xuân hè',              N'Trang 1', N'Thời trang', 130000,  N'Hoàng Em',   10, 'All', 'admin', '2025-05-01', '2025-05-01', N'10/2025', 0),
(20, N'Phong cách streetwear',                     N'Trang 2', N'Thời trang', 110000,  N'Phạm Dung',  10, 'All', 'admin', '2025-05-01', '2025-05-01', N'10/2025', 0)
GO

-- 6.9. Phieu chi
INSERT INTO [dbo].[Phieuchi] ([Sophieu], [Ngaylap], [Sotien], [Thue], [Conlai], [Lydo], [Nguoinhan], [Tacgia], [Nguoilap], [loaiTT], [TrangThaiDuyet], [NguoiDuyet], [NgayDuyet]) VALUES
('PC-20250101-0001', '2025-01-10', 350000, 0, 350000,  N'Chi trả nhuận bút tháng 1',        N'Nguyễn Văn An',     N'Nguyễn An',  'admin', 'CK', 1, N'Ban Giám Đốc', '2025-01-11'),
('PC-20250115-0002', '2025-01-20', 430000, 43000, 387000, N'Chi trả nhuận bút tháng 1 đợt 2', N'Trần Thị Bình',    N'Trần Bình',  'admin', 'CK', 1, N'Ban Giám Đốc', '2025-01-21'),
('PC-20250201-0003', '2025-02-10', 520000, 52000, 468000, N'Chi trả nhuận bút tháng 2',        N'Lê Văn Cường',    N'Lê Cường',  'admin', 'TM', 1, N'Ban Giám Đốc', '2025-02-11'),
('PC-20250215-0004', '2025-02-25', 300000, 0, 300000,  N'Chi trả nhuận bút tháng 2 đợt 2', N'Hoàng Văn Em',     N'Hoàng Em',   'admin', 'CK', 0, NULL, NULL),
('PC-20250301-0005', '2025-03-10', 480000, 48000, 432000, N'Chi trả nhuận bút tháng 3',        N'Vũ Văn Giang',     N'Vũ Giang',  'admin', 'CK', 0, NULL, NULL)
GO

-- 6.10. Nhuan but chi tiet
INSERT INTO [dbo].[NhuanbutCT] ([MsTacgia], [MsNhuanbut], [Sotien], [Thue], [Conlai], [SoPC], [SauThanhToan]) VALUES
('TG0001', 1, 200000, 0, 200000, 'PC-20250101-0001', 'Y'),
('TG0001', 2, 150000, 0, 150000, 'PC-20250101-0001', 'Y'),
('TG0002', 3, 250000, 25000, 225000, 'PC-20250115-0002', 'Y'),
('TG0003', 4, 180000, 18000, 162000, 'PC-20250115-0002', 'Y'),
('TG0002', 5, 300000, 30000, 270000, 'PC-20250201-0003', 'Y'),
('TG0005', 6, 220000, 22000, 198000, 'PC-20250201-0003', 'Y'),
('TG0004', 7, 160000, 0, 160000, 'PC-20250215-0004', 'Y'),
('TG0004', 8, 140000, 0, 140000, 'PC-20250215-0004', 'Y'),
('TG0007', 9, 280000, 28000, 252000, 'PC-20250301-0005', 'Y'),
('TG0007', 10, 200000, 20000, 180000, 'PC-20250301-0005', 'Y')
GO

-- 6.11. Thanh toan
INSERT INTO [dbo].[ThanhToan] ([Maso], [Tengoi], [Ngay], [Tungay], [Denngay], [Loaibao], [Sotien], [Vung], [LoaiTT], [Khoaso], [hinhthucTT]) VALUES
(1, N'Thanh toán nhuận bút T01/2025',  '2025-01-31', '2025-01-01', '2025-01-31', 'XN', 350000, 'MB', 'CK', 'Y', 'CK'),
(2, N'Thanh toán nhuận bút T01/2025',  '2025-01-31', '2025-01-01', '2025-01-31', 'CT', 430000, 'MB', 'CK', 'Y', 'CK'),
(3, N'Thanh toán nhuận bút T02/2025',  '2025-02-28', '2025-02-01', '2025-02-28', 'KT', 520000, 'MB', 'TM', 'Y', 'TM'),
(4, N'Thanh toán nhuận bút T02/2025',  '2025-02-28', '2025-02-01', '2025-02-28', 'GD', 300000, 'MB', 'CK', 'Y', 'CK'),
(5, N'Thanh toán nhuận bút T03/2025',  '2025-03-31', '2025-03-01', '2025-03-31', 'CN', 480000, 'MB', 'CK', 'N', 'CK')
GO

-- 6.12. Users (Mat khau: admin -> ma hoa SHA256)
INSERT INTO [dbo].[Users] ([TenDangNhap], [MatKhau], [Salt], [HoTen], [Quyen], [HoatDong], [MaTacGiaGoc]) VALUES
('admin',     '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', NULL, N'Ban Quản trị',  N'Quản trị viên', 1, NULL),
('ketoan',    '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', NULL, N'Kế toán',       N'Kế toán',       1, NULL),
('bientap',   '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', NULL, N'Biên tập viên', N'Thư ký',        1, 'TG0001'),
('phongvien1','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', NULL, N'Trần Bình',     N'Phóng viên',    1, 'TG0002'),
('phongvien2','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', NULL, N'Vũ Giang',      N'Phóng viên',    1, 'TG0007'),
('ctv',       '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', NULL, N'Phạm Dung',     N'Phóng viên',    1, 'TG0004')
GO

PRINT 'Da tao database DATNnhuanbut thanh cong!'
PRINT 'Tai khoan mac dinh: admin / admin'
GO
