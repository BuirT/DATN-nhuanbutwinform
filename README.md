# 📰 HỆ THỐNG QUẢN LÝ VÀ TÍNH NHUẬN BÚT TÒA SOẠN (NEWSPAY)

![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-4EA94B?style=for-the-badge&logo=mongodb&logoColor=white)
![Gemini AI](https://img.shields.io/badge/Gemini_AI-8E75B2?style=for-the-badge&logo=google-bard&logoColor=white)

**NewsPay** là giải pháp phần mềm quản trị toàn diện dành cho các tòa soạn báo, được phát triển trên nền tảng Windows Forms. Hệ thống giúp số hóa và tự động hóa quy trình quản lý tác giả, kỳ xuất bản, và đặc biệt là quy trình thẩm định, chấm điểm, tính toán chi trả nhuận bút với sự hỗ trợ của Trí tuệ Nhân tạo (AI).

---

## ✨ TÍNH NĂNG NỔI BẬT

### 🤖 1. Tích Hợp Trợ Lý Trí Tuệ Nhân Tạo (AI)

- **Kiểm định bài viết tự động:** Tích hợp API của mô hình **Google Gemini 2.5 Flash**.
- **Chấm điểm thông minh:** AI tự động đọc hiểu bài viết, phân tích ngữ nghĩa để đưa ra _Tỷ lệ đạo văn_, _Nhận xét chuyên môn_, và _Chấm điểm chất lượng (Thang 10)_.
- **Tự động hóa KPI:** Điểm số từ AI được tự động liên kết với hệ thống để cộng thưởng/phạt tiền nhuận bút.

### ⚡ 2. Tối Ưu Hiệu Năng & Trải Nghiệm Người Dùng (UI/UX)

- **Giao diện Modern UI:** Sử dụng thư viện **Guna UI2** mang lại thiết kế phẳng, bo góc mềm mại, hiệu ứng đổ bóng (Shadow) và chuyển cảnh (Animation) mượt mà như ứng dụng Web.
- **Triệt tiêu giật lag (Anti-Lag):** Áp dụng kỹ thuật ép xung **Double Buffering** (Bộ đệm kép) thông qua Reflection cho toàn bộ các DataGridView, giúp cuộn hàng ngàn dòng dữ liệu không bị khựng hay nháy màn hình.
- **Tìm kiếm Real-time:** Bộ lọc dữ liệu tức thời (Live Search) hỗ trợ tìm kiếm linh hoạt theo Mã số, Tên hiển thị, Tên tác giả...

### 🗄️ 3. Kiến Trúc Dữ Liệu Nâng Cao

- **Chuẩn hóa Database:** Phân tách dữ liệu chuẩn hóa cấp cao (VD: Tách riêng bảng `Loaibao` làm từ điển danh mục và `Bao` làm dữ liệu giao dịch).
- **Auto-Fix Schema:** Tích hợp cơ chế tự động kiểm tra và khởi tạo các cột còn thiếu trong SQL Server ngay khi khởi động Form, triệt tiêu hoàn toàn lỗi _Invalid column name_.
- **Kiến trúc 3 Lớp (3-Tier) & Đa CSDL:** Xây dựng sẵn thư mục `Models` và `DAL` áp dụng Data Annotations (BsonElement) sẵn sàng cho cơ chế **Ghi kép (Dual-Write)** đồng bộ dữ liệu song song giữa **SQL Server** (Bảo mật nghiệp vụ kế toán) và **MongoDB** (Phục vụ truy xuất API cho Nền tảng Web sau này).

---

## 🛠️ CÔNG NGHỆ SỬ DỤNG

- **Ngôn ngữ lập trình:** C#
- **Framework:** .NET Framework (Windows Forms)
- **Giao diện:** Guna.UI2.WinForms
- **Cơ sở dữ liệu:** Microsoft SQL Server (Chính) & MongoDB (Sẵn sàng mở rộng)
- **Thư viện bên thứ 3:** \* `Newtonsoft.Json` (Xử lý dữ liệu API)
  - `MongoDB.Driver` (Kết nối CSDL NoSQL)

---

## 🚀 HƯỚNG DẪN CÀI ĐẶT & CẤU HÌNH

### 1. Chuẩn bị Cơ sở dữ liệu

- Hệ thống yêu cầu có SQL Server đang chạy máy chủ cục bộ (Localhost).
- Đảm bảo Database mang tên `TN` đã được Restore trên SQL Server Management Studio (SSMS).
- Các cột cấu trúc mới (KPI, AI) sẽ được phần mềm tự động tạo khi chạy lần đầu tiên.

### 2. Cấu hình Chuỗi kết nối (Connection String)

Để ứng dụng chạy đúng trên máy tính của bạn, cần sửa lại chuỗi kết nối trong các file mã nguồn (VD: `FrmNhapNhuanBut.cs`, `FrmButDanh.cs`...):

```csharp
private readonly string sqlConnectionString = @"Server=TÊN_MÁY_CỦA_BẠN\SQLEXPRESS;Database=TN;Trusted_Connection=True;";
```
