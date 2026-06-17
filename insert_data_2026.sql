USE [DATNnhuanbut]
GO

-- ===================================================================
-- DU LIEU MAU NAM 2026 (Thang 1 - Thang 6)
-- ===================================================================

-- 1. BAO (so bao 2 tuan / thang)
INSERT INTO [dbo].[Bao] ([Maso], [Tenbao], [Ngayra], [Sobao], [Sobo], [Loaibao], [DaDuyet]) VALUES
(13, N'Xuân 2026 - Số đặc biệt',           '2026-01-05', '01/2026', '01', 'XN', 'Y'),
(14, N'Đầu năm 2026',                       '2026-01-20', '02/2026', '01', 'CT', 'Y'),
(15, N'Kinh tế đầu năm',                    '2026-02-05', '03/2026', '02', 'KT', 'Y'),
(16, N'Công nghệ Xuân 2026',                '2026-02-20', '04/2026', '02', 'CN', 'Y'),
(17, N'Giáo dục tháng 3',                   '2026-03-05', '05/2026', '03', 'GD', 'Y'),
(18, N'Bất động sản quý I',                 '2026-03-20', '06/2026', '03', 'BĐS', 'Y'),
(19, N'Kinh tế số tháng 4',                 '2026-04-05', '07/2026', '04', 'KT', 'Y'),
(20, N'Pháp luật tháng 4',                  '2026-04-20', '08/2026', '04', 'PLS', 'Y'),
(21, N'Văn hóa - Thể thao tháng 5',         '2026-05-05', '09/2026', '05', 'VH', 'Y'),
(22, N'Công nghệ tháng 5',                  '2026-05-20', '10/2026', '05', 'CN', 'Y'),
(23, N'Giáo dục - Kinh tế tháng 6',         '2026-06-05', '11/2026', '06', 'GD', 'N'),
(24, N'Báo cuối tháng 6',                   '2026-06-20', '12/2026', '06', 'XN', 'N')
GO

-- 2. NHUAN BUT (Bai viet nam 2026)
INSERT INTO [dbo].[Nhuanbut] ([Maso], [Tenbai], [Trang], [Muc], [TienNhuanbut], [Butdanh], [MsBao], [Vung], [NgayNhap], [TenSoBao], [DaThanhToan]) VALUES
-- Bao 13 - Xuan 2026 (10 bai)
(21, N'Việt Nam vươn mình 2026',               N'Trang 1', N'Chính luận', 280000,  N'Nguyễn An',  13, 'MB', '2026-01-05', N'01/2026', 0),
(22, N'Phong tục ngày Tết ba miền',             N'Trang 2', N'Xã hội',     180000,  N'Nguyễn An',  13, 'MB', '2026-01-05', N'01/2026', 0),
(23, N'Ẩm thực ngày xuân',                     N'Trang 3', N'Văn hóa',    150000,  N'An Bình',    13, 'All','2026-01-05', N'01/2026', 0),
(24, N'Du lịch đầu năm',                        N'Trang 4', N'Xã hội',     160000,  N'Phạm Dung',  13, 'All','2026-01-05', N'01/2026', 0),
(25, N'Làng nghề truyền thống',                 N'Trang 5', N'Văn hóa',    140000,  N'Đỗ Phương',  13, 'All','2026-01-05', N'01/2026', 0),

-- Bao 14 - Dau nam 2026 (8 bai)
(26, N'Chính sách mới năm 2026',                N'Trang 1', N'Chính trị',  320000,  N'Trần Bình',  14, 'MB', '2026-01-20', N'02/2026', 0),
(27, N'Cải cách hành chính',                    N'Trang 2', N'Chính trị',  250000,  N'Vũ Giang',   14, 'MB', '2026-01-20', N'02/2026', 0),
(28, N'Đầu tư công năm 2026',                   N'Trang 3', N'Kinh tế',    280000,  N'Hoàng Em',   14, 'All','2026-01-20', N'02/2026', 0),
(29, N'Phát triển hạ tầng giao thông',          N'Trang 4', N'Kinh tế',    220000,  N'Lê Cường',   14, 'MB', '2026-01-20', N'02/2026', 0),
(30, N'Nông thôn mới kiểu mẫu',                 N'Trang 5', N'Xã hội',     190000,  N'Bùi Hạnh',   14, 'All','2026-01-20', N'02/2026', 0),

-- Bao 15 - Kinh te dau nam (8 bai)
(31, N'GDP 2026 - Tăng trưởng bứt phá',        N'Trang 1', N'Kinh tế',    380000,  N'Trần Bình',  15, 'MB', '2026-02-05', N'03/2026', 0),
(32, N'Doanh nghiệp FDI tại Việt Nam',          N'Trang 2', N'Kinh tế',    300000,  N'Hoàng Em',   15, 'All','2026-02-05', N'03/2026', 0),
(33, N'Xuất khẩu nông sản',                     N'Trang 3', N'Kinh tế',    260000,  N'Nguyễn An',  15, 'MB', '2026-02-05', N'03/2026', 0),
(34, N'Thương mại điện tử bùng nổ',             N'Trang 4', N'Công nghệ',  240000,  N'Vũ Giang',   15, 'All','2026-02-05', N'03/2026', 0),
(35, N'Thị trường chứng khoán 2026',            N'Trang 5', N'Kinh tế',    350000,  N'Trần Bình',  15, 'MB', '2026-02-05', N'03/2026', 0),

-- Bao 16 - Cong nghe Xuan 2026 (8 bai)
(36, N'AI thế hệ mới',                          N'Trang 1', N'Công nghệ',  340000,  N'Vũ Giang',   16, 'MB', '2026-02-20', N'04/2026', 0),
(37, N'Blockchain trong tài chính',             N'Trang 2', N'Công nghệ',  270000,  N'Vũ Giang',   16, 'All','2026-02-20', N'04/2026', 0),
(38, N'Robot và tự động hóa',                   N'Trang 3', N'Công nghệ',  250000,  N'Lê Cường',   16, 'MB', '2026-02-20', N'04/2026', 0),
(39, N'Mạng 6G - Tương lai kết nối',            N'Trang 4', N'Công nghệ',  300000,  N'Phạm Dung',  16, 'All','2026-02-20', N'04/2026', 0),
(40, N'An ninh mạng 2026',                      N'Trang 5', N'Công nghệ',  220000,  N'Bùi Hạnh',   16, 'All','2026-02-20', N'04/2026', 0),

-- Bao 17 - Giao duc thang 3 (8 bai)
(41, N'Đổi mới chương trình phổ thông',         N'Trang 1', N'Giáo dục',   230000,  N'Phạm Dung',  17, 'MB', '2026-03-05', N'05/2026', 0),
(42, N'Giáo dục đại học tự chủ',                N'Trang 2', N'Giáo dục',   200000,  N'Phạm Dung',  17, 'All','2026-03-05', N'05/2026', 0),
(43, N'Học sinh giỏi quốc tế',                  N'Trang 3', N'Giáo dục',   180000,  N'Bùi Hạnh',   17, 'All','2026-03-05', N'05/2026', 0),
(44, N'Dạy học trực tuyến',                     N'Trang 4', N'Giáo dục',   170000,  N'Nguyễn An',  17, 'All','2026-03-05', N'05/2026', 0),
(45, N'Du học 2026 - Xu hướng mới',             N'Trang 5', N'Giáo dục',   210000,  N'Phương Nam', 17, 'MB', '2026-03-05', N'05/2026', 0),

-- Bao 18 - Bat dong san quy I (7 bai)
(46, N'Bất động sản phục hồi mạnh',             N'Trang 1', N'Kinh tế',    400000,  N'Hoàng Em',   18, 'MB', '2026-03-20', N'06/2026', 0),
(47, N'Chung cư cao cấp tại Hà Nội',            N'Trang 2', N'Kinh tế',    320000,  N'Hoàng Em',   18, 'MB', '2026-03-20', N'06/2026', 0),
(48, N'Nhà ở xã hội chính sách mới',            N'Trang 3', N'Xã hội',     260000,  N'Bùi Hạnh',   18, 'All','2026-03-20', N'06/2026', 0),
(49, N'Thị trường văn phòng cho thuê',          N'Trang 4', N'Kinh tế',    240000,  N'Nguyễn An',  18, 'MB', '2026-03-20', N'06/2026', 0),
(50, N'Đất nền ven đô lên ngôi',                N'Trang 5', N'Kinh tế',    270000,  N'Lê Cường',   18, 'All','2026-03-20', N'06/2026', 0),

-- Bao 19 - Kinh te so thang 4 (8 bai)
(51, N'Kinh tế số - Động lực tăng trưởng',      N'Trang 1', N'Kinh tế',    360000,  N'Trần Bình',  19, 'MB', '2026-04-05', N'07/2026', 0),
(52, N'Fintech Việt Nam vươn tầm',              N'Trang 2', N'Công nghệ',  290000,  N'Vũ Giang',   19, 'MB', '2026-04-05', N'07/2026', 0),
(53, N'Thương mại xã hội',                      N'Trang 3', N'Kinh tế',    250000,  N'Hoàng Em',   19, 'All','2026-04-05', N'07/2026', 0),
(54, N'Ngân hàng số',                           N'Trang 4', N'Công nghệ',  260000,  N'Phạm Dung',  19, 'All','2026-04-05', N'07/2026', 0),
(55, N'Doanh nghiệp khởi nghiệp công nghệ',     N'Trang 5', N'Công nghệ',  230000,  N'Bùi Hạnh',   19, 'MB', '2026-04-05', N'07/2026', 0),

-- Bao 20 - Phap luat thang 4 (8 bai)
(56, N'Luật đất đai sửa đổi',                    N'Trang 1', N'Pháp luật',  310000,  N'Lê Cường',   20, 'MB', '2026-04-20', N'08/2026', 0),
(57, N'Tranh chấp thương mại quốc tế',          N'Trang 2', N'Pháp luật',  280000,  N'Lê Cường',   20, 'All','2026-04-20', N'08/2026', 0),
(58, N'Bảo vệ dữ liệu cá nhân',                 N'Trang 3', N'Pháp luật',  230000,  N'Bùi Hạnh',   20, 'All','2026-04-20', N'08/2026', 0),
(59, N'Sở hữu trí tuệ trong kỷ nguyên số',      N'Trang 4', N'Pháp luật',  250000,  N'Vũ Giang',   20, 'All','2026-04-20', N'08/2026', 0),
(60, N'Tội phạm kinh tế',                      N'Trang 5', N'Pháp luật',  270000,  N'Nguyễn An',  20, 'MB', '2026-04-20', N'08/2026', 0),

-- Bao 21 - Van hoa - The thao thang 5 (8 bai)
(61, N'Lễ hội văn hóa các dân tộc',            N'Trang 1', N'Văn hóa',    210000,  N'Nguyễn An',  21, 'All','2026-05-05', N'09/2026', 0),
(62, N'Sân khấu cải lương phục hưng',           N'Trang 2', N'Văn hóa',    190000,  N'Nguyễn An',  21, 'All','2026-05-05', N'09/2026', 0),
(63, N'Thể thao Việt Nam hội nhập',             N'Trang 3', N'Thể thao',   230000,  N'Đỗ Phương',  21, 'MB', '2026-05-05', N'09/2026', 0),
(64, N'Bóng đá Đông Nam Á 2026',                N'Trang 4', N'Thể thao',   270000,  N'Đỗ Phương',  21, 'All','2026-05-05', N'09/2026', 0),
(65, N'Esports - Môn thể thao triệu đô',        N'Trang 5', N'Thể thao',   250000,  N'Phương Nam', 21, 'All','2026-05-05', N'09/2026', 0),

-- Bao 22 - Cong nghe thang 5 (7 bai)
(66, N'Trí tuệ nhân tạo tạo sinh',              N'Trang 1', N'Công nghệ',  380000,  N'Vũ Giang',   22, 'MB', '2026-05-20', N'10/2026', 0),
(67, N'Cloud computing 2026',                   N'Trang 2', N'Công nghệ',  290000,  N'Phạm Dung',  22, 'All','2026-05-20', N'10/2026', 0),
(68, N'IoT trong nông nghiệp',                  N'Trang 3', N'Công nghệ',  240000,  N'Bùi Hạnh',   22, 'All','2026-05-20', N'10/2026', 0),
(69, N'Xe điện và tương lai xanh',              N'Trang 4', N'Công nghệ',  310000,  N'Hoàng Em',   22, 'MB', '2026-05-20', N'10/2026', 0),
(70, N'Chip bán dẫn Việt Nam',                  N'Trang 5', N'Công nghệ',  330000,  N'Vũ Giang',   22, 'MB', '2026-05-20', N'10/2026', 0),

-- Bao 23 - Giao duc - Kinh te thang 6 (7 bai)
(71, N'Kỳ thi tốt nghiệp 2026',                 N'Trang 1', N'Giáo dục',   220000,  N'Phạm Dung',  23, 'MB', '2026-06-05', N'11/2026', 0),
(72, N'Giáo dục STEM',                          N'Trang 2', N'Giáo dục',   190000,  N'Bùi Hạnh',   23, 'All','2026-06-05', N'11/2026', 0),
(73, N'Lạm phát và chính sách tiền tệ',         N'Trang 3', N'Kinh tế',    340000,  N'Trần Bình',  23, 'MB', '2026-06-05', N'11/2026', 0),
(74, N'Năng lượng tái tạo',                     N'Trang 4', N'Kinh tế',    280000,  N'Hoàng Em',   23, 'All','2026-06-05', N'11/2026', 0),

-- Bao 24 - Cuoi thang 6 (6 bai)
(75, N'Tổng kết 6 tháng đầu năm',               N'Trang 1', N'Chính luận', 400000,  N'Nguyễn An',  24, 'MB', '2026-06-20', N'12/2026', 0),
(76, N'Kinh tế vĩ mô 6 tháng',                  N'Trang 2', N'Kinh tế',    350000,  N'Trần Bình',  24, 'MB', '2026-06-20', N'12/2026', 0),
(77, N'Điểm sáng văn hóa 2026',                 N'Trang 3', N'Văn hóa',    220000,  N'Nguyễn An',  24, 'All','2026-06-20', N'12/2026', 0),
(78, N'An sinh xã hội',                         N'Trang 4', N'Xã hội',     200000,  N'Lê Cường',   24, 'All','2026-06-20', N'12/2026', 0),
(79, N'Du lịch hè sôi động',                    N'Trang 5', N'Xã hội',     180000,  N'Phạm Dung',  24, 'All','2026-06-20', N'12/2026', 0),
(80, N'Phát triển bền vững',                    N'Trang 5', N'Kinh tế',    260000,  N'Vũ Giang',   24, 'All','2026-06-20', N'12/2026', 0)
GO

PRINT 'Da insert ' + CAST(@@ROWCOUNT AS VARCHAR) + ' bai viet nam 2026.'
GO

-- 3. PHIEU CHI (Chi tra nhuan but nam 2026)
INSERT INTO [dbo].[Phieuchi] ([Sophieu], [Ngaylap], [Sotien], [Thue], [Conlai], [Lydo], [Nguoinhan], [Tacgia], [Nguoilap], [loaiTT], [TrangThaiDuyet], [NguoiDuyet], [NgayDuyet]) VALUES
('PC-20260210-0006', '2026-02-10', 1270000, 127000, 1143000, N'Chi trả nhuận bút tháng 1/2026',       N'Nhiều tác giả', N'Nhiều tác giả', 'admin', 'CK', 1, N'Ban Giám Đốc', '2026-02-11'),
('PC-20260310-0007', '2026-03-10', 1650000, 165000, 1485000, N'Chi trả nhuận bút tháng 2/2026',       N'Nhiều tác giả', N'Nhiều tác giả', 'admin', 'CK', 1, N'Ban Giám Đốc', '2026-03-11'),
('PC-20260410-0008', '2026-04-10', 1580000, 158000, 1422000, N'Chi trả nhuận bút tháng 3/2026',       N'Nhiều tác giả', N'Nhiều tác giả', 'admin', 'CK', 1, N'Ban Giám Đốc', '2026-04-11'),
('PC-20260510-0009', '2026-05-10', 1440000, 144000, 1296000, N'Chi trả nhuận bút tháng 4/2026',       N'Nhiều tác giả', N'Nhiều tác giả', 'ketoan', 'CK', 1, N'Ban Giám Đốc', '2026-05-11'),
('PC-20260610-0010', '2026-06-10', 1520000, 152000, 1368000, N'Chi trả nhuận bút tháng 5/2026',       N'Nhiều tác giả', N'Nhiều tác giả', 'ketoan', 'CK', 0, NULL, NULL),
('PC-20260710-0011', '2026-07-10', 2050000, 205000, 1845000, N'Chi trả nhuận bút tháng 6/2026',       N'Nhiều tác giả', N'Nhiều tác giả', 'ketoan', 'CK', 0, NULL, NULL)
GO

-- 4. NHUAN BUT CHI TIET (Chi tiet nhan tien tung bai - tung tac gia)
INSERT INTO [dbo].[NhuanbutCT] ([MsTacgia], [MsNhuanbut], [Sotien], [Thue], [Conlai], [SoPC], [SauThanhToan]) VALUES
-- Thang 1 - PC-20260210-0006
('TG0001', 21, 280000, 28000, 252000, 'PC-20260210-0006', 'Y'),
('TG0001', 22, 180000, 18000, 162000, 'PC-20260210-0006', 'Y'),
('TG0001', 23, 150000, 15000, 135000, 'PC-20260210-0006', 'Y'),
('TG0004', 24, 160000, 16000, 144000, 'PC-20260210-0006', 'Y'),
('TG0006', 25, 140000, 0, 140000, 'PC-20260210-0006', 'Y'),
('TG0002', 26, 320000, 32000, 288000, 'PC-20260210-0006', 'Y'),
-- Thang 1 tiep
('TG0007', 27, 250000, 25000, 225000, 'PC-20260210-0006', 'Y'),
('TG0005', 28, 280000, 28000, 252000, 'PC-20260210-0006', 'Y'),
('TG0003', 29, 220000, 22000, 198000, 'PC-20260210-0006', 'Y'),
('TG0008', 30, 190000, 19000, 171000, 'PC-20260210-0006', 'Y'),

-- Thang 2 - PC-20260310-0007
('TG0002', 31, 380000, 38000, 342000, 'PC-20260310-0007', 'Y'),
('TG0005', 32, 300000, 30000, 270000, 'PC-20260310-0007', 'Y'),
('TG0001', 33, 260000, 26000, 234000, 'PC-20260310-0007', 'Y'),
('TG0007', 34, 240000, 24000, 216000, 'PC-20260310-0007', 'Y'),
('TG0002', 35, 350000, 35000, 315000, 'PC-20260310-0007', 'Y'),
('TG0007', 36, 340000, 34000, 306000, 'PC-20260310-0007', 'Y'),
-- Thang 2 tiep
('TG0007', 37, 270000, 27000, 243000, 'PC-20260310-0007', 'Y'),
('TG0003', 38, 250000, 25000, 225000, 'PC-20260310-0007', 'Y'),
('TG0004', 39, 300000, 30000, 270000, 'PC-20260310-0007', 'Y'),
('TG0008', 40, 220000, 22000, 198000, 'PC-20260310-0007', 'Y'),

-- Thang 3 - PC-20260410-0008
('TG0004', 41, 230000, 23000, 207000, 'PC-20260410-0008', 'Y'),
('TG0004', 42, 200000, 20000, 180000, 'PC-20260410-0008', 'Y'),
('TG0008', 43, 180000, 18000, 162000, 'PC-20260410-0008', 'Y'),
('TG0001', 44, 170000, 17000, 153000, 'PC-20260410-0008', 'Y'),
('TG0006', 45, 210000, 21000, 189000, 'PC-20260410-0008', 'Y'),
('TG0005', 46, 400000, 40000, 360000, 'PC-20260410-0008', 'Y'),
-- Thang 3 tiep
('TG0005', 47, 320000, 32000, 288000, 'PC-20260410-0008', 'Y'),
('TG0008', 48, 260000, 26000, 234000, 'PC-20260410-0008', 'Y'),
('TG0001', 49, 240000, 24000, 216000, 'PC-20260410-0008', 'Y'),
('TG0003', 50, 270000, 27000, 243000, 'PC-20260410-0008', 'Y'),

-- Thang 4 - PC-20260510-0009
('TG0002', 51, 360000, 36000, 324000, 'PC-20260510-0009', 'Y'),
('TG0007', 52, 290000, 29000, 261000, 'PC-20260510-0009', 'Y'),
('TG0005', 53, 250000, 25000, 225000, 'PC-20260510-0009', 'Y'),
('TG0004', 54, 260000, 26000, 234000, 'PC-20260510-0009', 'Y'),
('TG0008', 55, 230000, 23000, 207000, 'PC-20260510-0009', 'Y'),
('TG0003', 56, 310000, 31000, 279000, 'PC-20260510-0009', 'Y'),
-- Thang 4 tiep
('TG0003', 57, 280000, 28000, 252000, 'PC-20260510-0009', 'Y'),
('TG0008', 58, 230000, 23000, 207000, 'PC-20260510-0009', 'Y'),
('TG0007', 59, 250000, 25000, 225000, 'PC-20260510-0009', 'Y'),
('TG0001', 60, 270000, 27000, 243000, 'PC-20260510-0009', 'Y'),

-- Thang 5 - PC-20260610-0010
('TG0001', 61, 210000, 21000, 189000, 'PC-20260610-0010', 'Y'),
('TG0001', 62, 190000, 19000, 171000, 'PC-20260610-0010', 'Y'),
('TG0006', 63, 230000, 23000, 207000, 'PC-20260610-0010', 'Y'),
('TG0006', 64, 270000, 27000, 243000, 'PC-20260610-0010', 'Y'),
('TG0006', 65, 250000, 25000, 225000, 'PC-20260610-0010', 'Y'),
('TG0007', 66, 380000, 38000, 342000, 'PC-20260610-0010', 'Y'),
-- Thang 5 tiep
('TG0004', 67, 290000, 29000, 261000, 'PC-20260610-0010', 'Y'),
('TG0008', 68, 240000, 24000, 216000, 'PC-20260610-0010', 'Y'),
('TG0005', 69, 310000, 31000, 279000, 'PC-20260610-0010', 'Y'),
('TG0007', 70, 330000, 33000, 297000, 'PC-20260610-0010', 'Y'),

-- Thang 6 - PC-20260710-0011
('TG0004', 71, 220000, 22000, 198000, 'PC-20260710-0011', 'N'),
('TG0008', 72, 190000, 19000, 171000, 'PC-20260710-0011', 'N'),
('TG0002', 73, 340000, 34000, 306000, 'PC-20260710-0011', 'N'),
('TG0005', 74, 280000, 28000, 252000, 'PC-20260710-0011', 'N'),
('TG0001', 75, 400000, 40000, 360000, 'PC-20260710-0011', 'N'),
('TG0002', 76, 350000, 35000, 315000, 'PC-20260710-0011', 'N'),
-- Thang 6 tiep
('TG0001', 77, 220000, 22000, 198000, 'PC-20260710-0011', 'N'),
('TG0003', 78, 200000, 20000, 180000, 'PC-20260710-0011', 'N'),
('TG0004', 79, 180000, 18000, 162000, 'PC-20260710-0011', 'N'),
('TG0007', 80, 260000, 26000, 234000, 'PC-20260710-0011', 'N')
GO

PRINT 'Da insert ' + CAST(@@ROWCOUNT AS VARCHAR) + ' dong chi tiet nhuan but.'
GO

-- 5. THANH TOAN
INSERT INTO [dbo].[ThanhToan] ([Maso], [Tengoi], [Ngay], [Tungay], [Denngay], [Loaibao], [Sotien], [Vung], [LoaiTT], [Khoaso], [hinhthucTT]) VALUES
(6,  N'Thanh toán nhuận bút T01/2026',  '2026-02-10', '2026-01-01', '2026-01-31', 'XN', 2170000, 'MB', 'CK', 'Y', 'CK'),
(7,  N'Thanh toán nhuận bút T02/2026',  '2026-03-10', '2026-02-01', '2026-02-28', 'KT', 2910000, 'MB', 'CK', 'Y', 'CK'),
(8,  N'Thanh toán nhuận bút T03/2026',  '2026-04-10', '2026-03-01', '2026-03-31', 'GD', 2480000, 'MB', 'CK', 'Y', 'CK'),
(9,  N'Thanh toán nhuận bút T04/2026',  '2026-05-10', '2026-04-01', '2026-04-30', 'KT', 2730000, 'MB', 'CK', 'Y', 'CK'),
(10, N'Thanh toán nhuận bút T05/2026',  '2026-06-10', '2026-05-01', '2026-05-31', 'VH', 2700000, 'MB', 'CK', 'N', 'CK'),
(11, N'Thanh toán nhuận bút T06/2026',  '2026-07-10', '2026-06-01', '2026-06-30', 'GD', 2440000, 'MB', 'CK', 'N', 'CK')
GO

-- 6. THANH TOAN CHI TIET
INSERT INTO [dbo].[ThanhToanCT] ([MsThanhToan], [MsBao], [Ngayra], [Tongnhuanbut], [Dachitra], [Conno]) VALUES
(6, 13, '05/01/2026', 910000,  910000,  0),
(6, 14, '20/01/2026', 1260000, 1260000, 0),
(7, 15, '05/02/2026', 1530000, 1530000, 0),
(7, 16, '20/02/2026', 1380000, 1380000, 0),
(8, 17, '05/03/2026', 990000,  990000,  0),
(8, 18, '20/03/2026', 1490000, 1490000, 0),
(9, 19, '05/04/2026', 1390000, 1390000, 0),
(9, 20, '20/04/2026', 1340000, 1340000, 0),
(10, 21, '05/05/2026', 1150000, 1150000, 0),
(10, 22, '20/05/2026', 1550000, 1550000, 0),
(11, 23, '05/06/2026', 1030000, 515000,  515000),
(11, 24, '20/06/2026', 1610000, 805000,  805000)
GO

PRINT 'Da insert du lieu thanh toan nam 2026.'
GO

PRINT 'HOAN THANH! Da them du lieu bao gom 12 so bao, 60 bai viet, 6 phieu chi cho 6 thang dau nam 2026.'
GO
