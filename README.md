# Hệ Thống Quản Lý & Tính Nhuận Bút Tòa Soạn (NewsPay)

[![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET Framework](https://img.shields.io/badge/.NET_Framework-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/en-us/download/dotnet-framework)
[![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![MongoDB](https://img.shields.io/badge/MongoDB-47A248?style=for-the-badge&logo=mongodb&logoColor=white)](https://www.mongodb.com/)
[![Gemini AI](https://img.shields.io/badge/Gemini_AI-8E75B2?style=for-the-badge&logo=googlegemini&logoColor=white)](https://deepmind.google/technologies/gemini/)

**NewsPay** là giải pháp phần mềm quản trị toàn diện dành cho các tòa soạn báo, được xây dựng trên nền tảng **Windows Forms (.NET Framework 4.7.2)**. Hệ thống số hóa và tự động hóa quy trình quản lý tác giả, kỳ báo, bài viết, cùng với khả năng thẩm định, chấm điểm và tính toán chi trả nhuận bút thông minh với sự hỗ trợ của **Trí tuệ Nhân tạo (Google Gemini)**.

---

## Mục Lục

- [Tổng Quan Hệ Thống](#tổng-quan-hệ-thống)
- [Công Nghệ Sử Dụng](#công-nghệ-sử-dụng)
- [Tính Năng Chính](#tính-năng-chính)
  - [1. Trí Tuệ Nhân Tạo (AI)](#1-trí-tuệ-nhân-tạo-ai)
  - [2. Quản Lý Danh Mục](#2-quản-lý-danh-mục)
  - [3. Quản Lý Nghiệp Vụ](#3-quản-lý-nghiệp-vụ)
  - [4. Báo Cáo & Thống Kê](#4-báo-cáo--thống-kê)
  - [5. Bảo Mật & Phân Quyền](#5-bảo-mật--phân-quyền)
- [Kiến Trúc Hệ Thống](#kiến-trúc-hệ-thống)
- [Cài Đặt & Cấu Hình](#cài-đặt--cấu-hình)
- [Hướng Dẫn Sử Dụng](#hướng-dẫn-sử-dụng)
- [Đóng Góp](#đóng-góp)
- [Giấy Phép](#giấy-phép)

---

## Tổng Quan Hệ Thống

**NewsPay** được phát triển nhằm giải quyết bài toán quản lý nhuận bút tại các tòa soạn báo chí. Hệ thống cung cấp một quy trình khép kín từ khâu nhập bài, kiểm định chất lượng (AI), chấm điểm, tính toán nhuận bút cho đến thanh toán và báo cáo.

### Đối tượng sử dụng

| Vai trò | Mô tả |
|---------|-------|
| **Quản trị viên** | Quản lý tài khoản, thiết lập tham số hệ thống, duyệt phiếu chi |
| **Biên tập viên** | Nhập bài, kiểm định bài viết qua AI, tra cứu nhuận bút |
| **Kế toán** | Lập phiếu chi, theo dõi công nợ, xuất báo cáo tài chính |
| **Cộng tác viên** | Tra cứu bài viết và nhuận bút của bản thân |

---

## Công Nghệ Sử Dụng

### Ngôn ngữ & Framework
- **Ngôn ngữ:** C#
- **Framework:** .NET Framework 4.7.2 (Windows Forms)
- **Mô hình:** 3-Tier Architecture (Presentation - Business - Data)

### Giao diện
- **Guna.UI2.WinForms 2.0.4.7** — Modern UI Controls
- **Guna.Charts.WinForms 1.1.0** — Biểu đồ trực quan
- Double Buffering (Reflection) — Chống giật lag DataGridView

### Cơ sở dữ liệu
- **SQL Server** — Cơ sở dữ liệu chính, lưu trữ giao dịch & bảo mật
- **MongoDB** — Cơ sở dữ liệu phụ, sẵn sàng đồng bộ dữ liệu phục vụ Web API

### Thư viện hỗ trợ
| Thư viện | Mục đích |
|----------|----------|
| `ClosedXML 0.95.4` | Xuất báo cáo Excel |
| `MongoDB.Driver 3.8.1` | Kết nối MongoDB |
| `Newtonsoft.Json 13.0.4` | Xử lý JSON |
| `DocumentFormat.OpenXml 3.5.1` | Xử lý file Office Open XML |
| `System.ValueTuple 4.6.2` | Hỗ trợ Tuple trong .NET 4.7.2 |

### AI
- **Google Gemini 2.5 Flash API** — Kiểm định & chấm điểm bài viết

---

## Tính Năng Chính

### 1. Trí Tuệ Nhân Tạo (AI)

- **Kiểm định bài viết tự động:** Gửi bài viết đến Google Gemini, AI phân tích ngữ nghĩa, phát hiện tỷ lệ đạo văn.
- **Chấm điểm chất lượng:** AI chấm điểm thang 10 kèm nhận xét chuyên môn chi tiết.
- **Tự động hóa KPI:** Điểm AI ảnh hưởng trực tiếp đến công thức tính thưởng/phạt nhuận bút.
- **Trợ lý AI:** Chat với AI ngay trong ứng dụng để tra cứu thông tin nhanh.

> ![AI Verification Form](screenshots/ai-verification.png)
> *Giao diện kiểm định bài viết bằng AI*

### 2. Quản Lý Danh Mục

| Chức năng | Mô tả | Form |
|-----------|-------|------|
| **Tác giả** | Quản lý thông tin tác giả (họ tên, bút danh, địa chỉ, tài khoản ngân hàng) | `FrmTacGia` |
| **Bút danh** | Quản lý bút danh của tác giả trên từng loại báo | `FrmButdanh` |
| **Loại báo** | Danh sách loại báo (hệ số nhuận bút, quy định riêng) | `FrmLoaiBao` |
| **Số báo** | Quản lý các kỳ xuất bản theo số báo | `FrmSoBao` |
| **Tài khoản** | Quản lý người dùng và phân quyền | `FrmTaiKhoan` |

### 3. Quản Lý Nghiệp Vụ

- **Nhập nhuận bút** (`FrmNhapNhuanBut`): Nhập bài viết và tính nhuận bút tự động theo công thức cấu hình.
- **Tra cứu nhuận bút** (`FrmTraCuuNhuanBut`): Tra cứu nhanh theo mã số, tên tác giả, bút danh với bộ lọc real-time.
- **Phiếu chi** (`FrmPhieuChi`): Lập và quản lý phiếu chi trả nhuận bút.
- **Duyệt phiếu chi** (`FrmDuyetPhieuChi`): Duyệt/từ chối phiếu chi bởi quản trị viên.
- **Thanh toán** (`FrmThanhToan`): Theo dõi trạng thái thanh toán cho tác giả.

### 4. Báo Cáo & Thống Kê

- **Tổng quan** (`FrmTongQuan`): Dashboard hiển thị số liệu tổng hợp với biểu đồ trực quan (Guna Charts).
- **Báo cáo tổng hợp** (`FrmBaoCaoTongHop`): Thống kê nhuận bút theo kỳ/tháng/năm.
- **Báo cáo chi tiết** (`FrmBaoCaoChiTiet`): Chi tiết từng bài viết và khoản nhuận bút.
- **Báo cáo công nợ** (`FrmBaoCaoCongNo`): Công nợ phải trả theo tác giả.
- **Tổng hợp tháng** (`FrmTongHopThang`): Tổng hợp nhuận bút hàng tháng.

> ![Reports Dashboard](screenshots/reports.png)
> *Dashboard báo cáo trực quan với biểu đồ*

### 5. Bảo Mật & Phân Quyền

- **Xác thực:** Đăng nhập/Đăng ký với mã hóa mật khẩu (HashHelper).
- **Phân quyền:** Phân biệt quyền Admin, Biên tập viên, Kế toán, Cộng tác viên.
- **Bảo vệ CSDL:** Tự động kiểm tra & sửa schema SQL Server khi chạy.
- **Chống lỗi:** Pre-build event tự động kill tiến trình cũ tránh xung đột file.

---

## Kiến Trúc Hệ Thống

```
DATN-nhuanbutwinform/
├── HETHONGTINHNHUANBUT/           # Project chính
│   ├── DAL/                        # Data Access Layer
│   │   ├── MongoHelper.cs          # Helper kết nối MongoDB
│   │   └── MongoProvider.cs        # Provider MongoDB
│   ├── Models/                     # Business Models
│   │   ├── AppManager.cs           # Quản lý ứng dụng (singleton)
│   │   ├── Bao.cs                  # Bài báo
│   │   ├── ButDanh.cs              # Bút danh
│   │   ├── NhuanBut.cs             # Nhuận bút
│   │   ├── PhieuChi.cs             # Phiếu chi
│   │   ├── TacGia.cs               # Tác giả
│   │   ├── ThanhToan.cs            # Thanh toán
│   │   └── User.cs                 # Người dùng
│   ├── AIHelper.cs                 # Google Gemini API integration
│   ├── HashHelper.cs               # Mã hóa mật khẩu
│   ├── UIHelper.cs                 # Helper giao diện (Double Buffering, ...)
│   ├── Program.cs                  # Entry point
│   ├── FormLogin.cs                # Đăng nhập
│   ├── FormRegister.cs             # Đăng ký
│   ├── FrmTrangChinh.cs            # Trang chính (MDI Parent)
│   ├── FrmNhapNhuanBut.cs          # Nhập nhuận bút
│   ├── FrmTraCuuNhuanBut.cs        # Tra cứu nhuận bút
│   ├── FrmKiemDinhAI.cs            # Kiểm định AI
│   ├── FrmTroLyAI.cs               # Trợ lý AI Chat
│   ├── FrmPhieuChi.cs              # Phiếu chi
│   ├── FrmDuyetPhieuChi.cs         # Duyệt phiếu chi
│   ├── FrmThanhToan.cs             # Thanh toán
│   ├── FrmTacGia.cs                # Quản lý tác giả
│   ├── FrmButdanh.cs               # Quản lý bút danh
│   ├── FrmLoaiBao.cs               # Quản lý loại báo
│   ├── FrmSoBao.cs                 # Quản lý số báo
│   ├── FrmTaiKhoan.cs              # Quản lý tài khoản
│   ├── FrmTongQuan.cs              # Dashboard tổng quan
│   ├── FrmBaoCaoTongHop.cs         # Báo cáo tổng hợp
│   ├── FrmBaoCaoChiTiet.cs         # Báo cáo chi tiết
│   ├── FrmBaoCaoCongNo.cs          # Báo cáo công nợ
│   ├── FrmTongHopThang.cs          # Tổng hợp tháng
│   ├── App.config                  # Cấu hình ứng dụng
│   ├── App.config.example          # Mẫu cấu hình
│   ├── packages.config             # NuGet dependencies
│   └── resources/                  # Tài nguyên (hình ảnh, ...)
├── packages/                       # NuGet packages (local)
├── scripts/                        # Scripts hỗ trợ
│   └── kill_hung_process.ps1       # Kill tiến trình treo
├── .gitignore
├── HETHONGTINHNHUANBUT.sln         # Solution file
└── README.md
```

### Mô hình 3-Tier

```
┌─────────────────────────────────────────┐
│           Presentation Layer            │
│   (WinForms - Guna.UI2, Charts, etc.)  │
├─────────────────────────────────────────┤
│         Business Logic Layer            │
│      (Models, AIHelper, HashHelper)     │
├─────────────────────────────────────────┤
│           Data Access Layer             │
│     (SQL Server + MongoDB Driver)       │
└─────────────────────────────────────────┘
```

### Dual-Write (Ghi kép)

Hệ thống hỗ trợ kiến trúc **Dual-Write**:
- **SQL Server:** Lưu trữ chính, bảo mật nghiệp vụ kế toán.
- **MongoDB:** Nhân bản dữ liệu phục vụ truy xuất API cho nền tảng Web sau này.

---

## Cài Đặt & Cấu Hình

### Yêu cầu hệ thống

| Thành phần | Yêu cầu |
|------------|---------|
| **HĐH** | Windows 7/10/11 |
| **.NET Framework** | 4.7.2 trở lên |
| **SQL Server** | 2016+ (LocalDB / Express / Developer / Standard) |
| **MongoDB** | (Tùy chọn) Phiên bản 6.0+ |
| **Visual Studio** | 2019/2022 (để biên dịch) |

### Bước 1: Sao chép kho lưu trữ

```bash
git clone https://github.com/BuirT/DATN-nhuanbutwinform.git
cd DATN-nhuanbutwinform
```

### Bước 2: Chuẩn bị cơ sở dữ liệu

1. Khởi động **SQL Server Management Studio (SSMS)**.
2. Tạo database tên `TN` (hoặc tên tùy chỉnh).
3. Chạy script tạo bảng (nếu có) hoặc để ứng dụng tự động tạo schema lần đầu chạy.
4. Nếu sử dụng MongoDB, đảm bảo MongoDB service đang chạy.

### Bước 3: Cấu hình kết nối

Sao chép `App.config.example` thành `App.config` và sửa chuỗi kết nối:

```xml
<connectionStrings>
  <add name="SqlConnection"
       connectionString="Server=YOUR_SERVER\SQLEXPRESS;Database=TN;Trusted_Connection=True;"
       providerName="System.Data.SqlClient" />
  <add name="MongoConnection"
       connectionString="mongodb://localhost:27017"
       providerName="MongoDB.Driver" />
</connectionStrings>
```

> **Lưu ý:** Nếu bạn có file `App.config`, hãy sửa trực tiếp chuỗi kết nối trong file đó thay vì tạo mới.

### Bước 4: Khôi phục gói NuGet

Mở **Visual Studio**, vào menu:
`Tools` → `NuGet Package Manager` → `Package Manager Console`

```powershell
Update-Package -Reinstall
```

Hoặc build solution — Visual Studio sẽ tự động khôi phục packages từ thư mục `packages/`.

### Bước 5: Biên dịch & chạy

- Chọn **Build** → **Build Solution** (Ctrl+Shift+B).
- Nhấn **F5** để chạy.

---

## Hướng Dẫn Sử Dụng

### Đăng nhập

1. Mở ứng dụng, giao diện **FormLogin** xuất hiện.
2. Nhập tên đăng nhập và mật khẩu.
3. Nếu chưa có tài khoản, chọn **Đăng ký** để tạo tài khoản mới.

### Quy trình nghiệp vụ

```
[1] Tạo/Bút danh/Tác giả → [2] Nhập bài viết → [3] Kiểm định AI
    → [4] Duyệt & tính nhuận bút → [5] Lập phiếu chi → [6] Thanh toán
```

### Một số thao tác nhanh

| Thao tác | Cách thực hiện |
|----------|---------------|
| Tìm kiếm bài viết | Nhập từ khóa vào ô tìm kiếm ở form Tra cứu (real-time filter) |
| Kiểm định AI | Chọn bài viết → Click "Kiểm định AI" → Xem kết quả điểm & nhận xét |
| Xuất Excel | Mở báo cáo → Click "Xuất Excel" (sử dụng ClosedXML) |
| Xem Dashboard | Vào menu "Tổng quan" để xem biểu đồ thống kê |

---

## Đóng Góp

Mọi đóng góp đều được hoan nghênh! Vui lòng:

1. Fork repository.
2. Tạo branch feature mới: `git checkout -b feature/amazing-feature`
3. Commit thay đổi: `git commit -m 'Add some amazing feature'`
4. Push lên branch: `git push origin feature/amazing-feature`
5. Tạo Pull Request.

---

## Giấy Phép

Dự án này thuộc sở hữu của **BuirT** và được phân phối dưới giấy phép MIT.

---

## Liên Hệ

**Tác giả:** BuirT  
**GitHub:** [https://github.com/BuirT/DATN-nhuanbutwinform](https://github.com/BuirT/DATN-nhuanbutwinform)

---

*© 2025-2026 BuirT. All rights reserved.*
