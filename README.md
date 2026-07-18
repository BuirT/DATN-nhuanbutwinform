# Hệ Thống Quản Lý & Tính Chi Trả Nhuận Bút Tòa Soạn (NewsPay)

![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Ollama](https://img.shields.io/badge/Ollama-000000?style=for-the-badge&logo=ollama&logoColor=white)

**NewsPay** là phần mềm quản lý toàn diện dành cho các tòa soạn báo, được xây dựng trên nền tảng Windows Forms (.NET Framework). Hệ thống giúp số hóa và tự động hóa quy trình quản lý tác giả, bài viết, tính toán và chi trả nhuận bút cho phóng viên một cách chính xác, minh bạch và hiệu quả. Điểm đặc biệt là hệ thống tích hợp **AI nội bộ thông qua Ollama** - chạy hoàn toàn offline, bảo mật, không cần internet.

---

## Giới Thiệu

Phần mềm được phát triển nhằm giải quyết bài toán quản lý nhuận bút tại các tòa soạn báo chí, cung cấp quy trình khép kín từ khâu nhập bài, quản lý danh mục tác giả - bút danh - loại báo, tính toán nhuận bút theo công thức linh hoạt, lập phiếu chi, duyệt thanh toán và xuất báo cáo thống kê.

### Tính năng AI nổi bật

- **Kiểm định bài viết tự động:** Hệ thống sử dụng **Ollama** với mô hình **Qwen2.5** để tự động đọc hiểu nội dung bài viết, đánh giá tỷ lệ đạo văn và chấm điểm chất lượng theo thang 10.
- **Trợ lý AI Kế toán:** Chat với AI được tích hợp sẵn, AI có khả năng truy vấn trực tiếp vào cơ sở dữ liệu SQL Server để trả lời các câu hỏi về số liệu tổng quan, báo cáo thống kê theo thời gian thực. AI am hiểu luật Thuế TNCN, hỗ trợ tư vấn nghiệp vụ kế toán tòa soạn.
- **Chạy hoàn toàn offline:** Tất cả xử lý AI đều diễn ra trên máy local, không cần kết nối internet, không lo lộ dữ liệu nội bộ.

---

## Công Nghệ Sử Dụng

| Công nghệ | Mục đích |
|-----------|----------|
| **C# - .NET Framework 4.7.2** | Ngôn ngữ & Framework chính |
| **Windows Forms** | Nền tảng giao diện |
| **SQL Server** | Cơ sở dữ liệu quan hệ |
| **Guna.UI2.WinForms** | Giao diện Modern UI |
| **Guna.Charts.WinForms** | Biểu đồ trực quan |
| **ClosedXML** | Xuất báo cáo Excel |
| **Ollama - Qwen2.5** | AI nội bộ (offline) |
| **Newtonsoft.Json** | Xử lý dữ liệu API |

---

## Tính Năng Chính

### Quản Lý Danh Mục

- **Tác giả:** Quản lý thông tin phóng viên, cộng tác viên (họ tên, bút danh, tài khoản ngân hàng)
- **Bút danh:** Quản lý bút danh của tác giả trên từng loại báo
- **Loại báo:** Danh sách loại báo kèm hệ số nhuận bút
- **Số báo:** Quản lý các kỳ xuất bản theo số báo
- **Tài khoản:** Quản lý người dùng và phân quyền

### AI & Kiểm Định Bài Viết

- **Kiểm định AI:** Dán nội dung bài viết, AI tự động phân tích và đưa ra:
  - Tỷ lệ đạo văn
  - Nhận xét chuyên môn
  - Điểm chất lượng (thang 10)
- **Trợ lý AI Chat:** Hỗ trợ tư vấn nghiệp vụ kế toán, tra cứu số liệu thời gian thực từ database
- **Yêu cầu:** Cài đặt Ollama và tải mô hình qwen2.5

### Quản Lý Nghiệp Vụ

- **Nhập nhuận bút:** Nhập bài viết và tự động tính nhuận bút theo công thức cấu hình
- **Tra cứu nhuận bút:** Tìm kiếm nhanh theo mã số, tác giả, bút danh với bộ lọc thời gian thực
- **Phiếu chi:** Lập và quản lý phiếu chi trả nhuận bút
- **Duyệt phiếu chi:** Quy trình duyệt/từ chối phiếu chi bởi quản trị viên
- **Thanh toán:** Theo dõi trạng thái thanh toán

### Báo Cáo & Thống Kê

- **Tổng quan:** Dashboard với biểu đồ trực quan
- **Báo cáo tổng hợp:** Thống kê nhuận bút theo kỳ/tháng/năm
- **Báo cáo chi tiết:** Chi tiết từng bài viết và khoản nhuận bút
- **Báo cáo công nợ:** Công nợ phải trả theo tác giả
- **Tổng hợp tháng:** Tổng hợp nhuận bút hàng tháng
- **Xuất Excel:** Tất cả báo cáo có thể xuất ra file Excel

### Bảo Mật & Phân Quyền

- Đăng nhập/Đăng ký với mã hóa mật khẩu
- Phân quyền chi tiết (Admin, Biên tập, Kế toán, Phóng viên)
- Tự động kiểm tra và đồng bộ cấu trúc database khi khởi động

---

## Kiến Trúc Hệ Thống

```
DATN-nhuanbutwinform/
├── HETHONGTINHNHUANBUT/
│   ├── Forms/                      # Các giao diện (WinForms)
│   │   ├── FormLogin.cs            # Đăng nhập
│   │   ├── FrmAIPhanTichDashboard.cs # Dashboard phân tích AI
│   │   ├── FrmBaoCaoAI.cs          # Báo cáo AI
│   │   ├── FrmBaoCaoCongNo.cs      # Báo cáo công nợ
│   │   ├── FrmBaoCaoLanhDao.cs     # Báo cáo lãnh đạo
│   │   ├── FrmBaoCaoThongKe.cs     # Báo cáo thống kê
│   │   ├── FrmBaoCaoTongHop.cs     # Báo cáo tổng hợp
│   │   ├── FrmButdanh.cs           # Quản lý bút danh
│   │   ├── FrmCanhBaoAI.cs         # Cảnh báo AI
│   │   ├── FrmDashboard.cs         # Dashboard
│   │   ├── FrmDuyetPhieuChi.cs     # Duyệt phiếu chi
│   │   ├── FrmKiemDuyetNhuanBut.cs # Kiểm duyệt nhuận bút
│   │   ├── FrmLichSuThanhToan.cs   # Lịch sử thanh toán
│   │   ├── FrmLoaiBao.cs           # Quản lý loại báo
│   │   ├── FrmNhapBaiPhongVien.cs  # Nhập bài phóng viên
│   │   ├── FrmNhapNhuanBut.cs      # Nhập nhuận bút
│   │   ├── FrmPhieuChi.cs          # Lập phiếu chi
│   │   ├── FrmQuanLyPhieuChi.cs    # Quản lý phiếu chi
│   │   ├── FrmSoBao.cs             # Quản lý số báo
│   │   ├── FrmTacGia.cs            # Quản lý tác giả
│   │   ├── FrmTaiKhoan.cs          # Quản lý tài khoản
│   │   ├── FrmThanhToan.cs         # Thanh toán
│   │   ├── FrmThongkePhongvien.cs  # Thống kê phóng viên
│   │   ├── FrmTongHopThang.cs      # Tổng hợp tháng
│   │   ├── FrmTraCuuNhuanBut.cs    # Tra cứu nhuận bút
│   │   ├── FrmTrangChinh.cs        # Trang chính
│   │   ├── FrmTroLyAI.cs           # Trợ lý AI
│   │   └── FrmXemBaiViet.cs        # Xem bài viết
│   ├── Services/                   # Business logic & AI services
│   │   ├── AIAuditService.cs       # Service kiểm toán AI
│   │   ├── AIHelper.cs             # Helper tích hợp Ollama
│   │   ├── AIReportService.cs      # Service báo cáo AI
│   │   ├── AnomalyDetector.cs      # Phát hiện bất thường
│   │   ├── DatabaseMigrator.cs     # Migration cơ sở dữ liệu
│   │   └── KiemDuyetService.cs     # Service kiểm duyệt
│   ├── Helpers/                    # Utility/helper classes
│   │   ├── AIConfig.cs             # Cấu hình AI
│   │   ├── AiIconResource.cs       # Resource icon AI
│   │   ├── HashHelper.cs           # Mã hóa mật khẩu
│   │   └── UIHelper.cs             # Helper giao diện
│   ├── Models/                     # Business Models
│   │   ├── Bao.cs                  # Bài báo
│   │   ├── ButDanh.cs              # Bút danh
│   │   ├── NhuanBut.cs             # Nhuận bút
│   │   ├── PhieuChi.cs             # Phiếu chi
│   │   ├── TacGia.cs               # Tác giả
│   │   ├── ThanhToan.cs            # Thanh toán
│   │   ├── User.cs                 # Người dùng
│   │   └── AICanhBao.cs            # AI Cảnh báo
│   ├── Properties/                 # Project properties
│   ├── Workflow/                   # Tài liệu quy trình
│   ├── resources/                  # Tài nguyên hình ảnh
│   ├── Program.cs                  # Entry point
│   └── App.config                  # Cấu hình
├── packages/                       # NuGet packages
├── .gitignore
├── HETHONGTINHNHUANBUT.sln
└── README.md
```

---

## Hướng Dẫn Cài Đặt

### Yêu cầu hệ thống

- Windows 7/10/11
- .NET Framework 4.7.2+
- SQL Server 2016+ (LocalDB / Express / Developer)
- Visual Studio 2019/2022
- **Ollama** (cho tính năng AI) - [https://ollama.com](https://ollama.com)

### Các bước cài đặt

#### 1. Cài đặt Ollama & tải mô hình AI

```bash
# Tải và cài Ollama từ https://ollama.com
# Sau đó chạy lệnh sau để tải mô hình:
ollama run qwen2.5
```

> Để nguyên cửa sổ CMD này mở trong suốt quá trình sử dụng phần mềm.

#### 2. Clone repository

```bash
git clone https://github.com/BuirT/DATN-nhuanbutwinform.git
cd DATN-nhuanbutwinform
```

#### 3. Tạo database

- Mở SQL Server Management Studio
- Tạo database tên `TenDatabase` hoặc khôi phục từ file `DATNnhuanbut.bak` / chạy script `DATNnhuanbut.sql`
- Ứng dụng sẽ tự động tạo bảng khi chạy lần đầu

#### 4. Cấu hình kết nối

Mở file `App.config`, sửa chuỗi kết nối:

```xml
<connectionStrings>
  <add name="TNConnection"
       connectionString="Server=YOUR_SERVER\SQLEXPRESS;Database=TenDatabase;Trusted_Connection=True;" />
</connectionStrings>
```

#### 5. Build & Run

- Mở solution bằng Visual Studio
- Build Solution (Ctrl+Shift+B)
- Chạy (F5)

---

## Hướng Dẫn Sử Dụng

### Quy trình nghiệp vụ cơ bản

```
Tạo tác giả / bút danh ➝ Nhập bài viết ➝ Kiểm định AI (tính điểm)
➝ Lập phiếu chi ➝ Duyệt phiếu chi ➝ Thanh toán
```

### Kiểm định bài viết bằng AI

1. Vào menu chức năng **Kiểm định AI**
2. Dán nội dung bài viết vào khung text
3. Nhấn **"TIẾN HÀNH QUÉT & ĐÁNH GIÁ"**
4. AI phân tích và trả về: điểm chất lượng, tỷ lệ đạo văn, nhận xét
5. Nhấn **"Lưu điểm số"** để ghi nhận kết quả

### Trợ lý AI Chat

1. Vào menu **Trợ lý AI**
2. Đặt câu hỏi về nghiệp vụ kế toán, thuế TNCN, số liệu thống kê
3. AI sẽ truy vấn database và trả lời dựa trên dữ liệu thực tế

### Thao tác nhanh

- **Tìm kiếm:** Nhập từ khóa, kết quả lọc real-time
- **Xuất Excel:** Mở báo cáo, chọn "Xuất Excel"
- **Xem Dashboard:** Vào "Tổng quan" để xem biểu đồ thống kê

---

## Liên Hệ

**Tác giả:** BuirT
**GitHub:** [https://github.com/BuirT/DATN-nhuanbutwinform](https://github.com/BuirT/DATN-nhuanbutwinform)
