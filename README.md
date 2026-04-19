# Royalty Management System (Hệ Thống Quản Lý Nhuận Bút)

![.NET Framework](https://img.shields.io/badge/.NET-Framework_4.7.2+-512BD4?logo=.net)
![C#](https://img.shields.io/badge/C%23-Language-239120?logo=c-sharp)
![MongoDB](https://img.shields.io/badge/MongoDB-NoSQL-47A248?logo=mongodb)
![GunaUI](https://img.shields.io/badge/UI-Guna.UI2-orange)

## 📝 Executive Summary
**Royalty Management System** là một ứng dụng Desktop (Windows Forms) được thiết kế chuyên biệt để tự động hóa và tối ưu hóa vòng đời quản lý, chi trả thù lao cho tác giả, phóng viên tại các tòa soạn báo và nhà xuất bản. 

Hệ thống giải quyết bài toán phân mảnh dữ liệu khi quản lý bằng công cụ thủ công (Excel), cung cấp một luồng nghiệp vụ khép kín từ khâu lên danh sách bài đăng, chấm điểm nhuận bút, tính toán thuế TNCN, cho đến việc xuất phiếu chi và theo dõi công nợ tác giả.

## 🏗 System Architecture & Tech Stack
Hệ thống được xây dựng dựa trên kiến trúc phân lớp (N-Tier Architecture), đảm bảo tính module hóa cao và dễ dàng mở rộng:

* **Presentation Layer (UI):** C# Windows Forms kết hợp với thư viện đồ họa **Guna.UI2** để mang lại trải nghiệm người dùng (UX) hiện đại, Flat Design và Fully Responsive.
* **Data Access Layer (DAL):** Giao tiếp với cơ sở dữ liệu thông qua thư viện `MongoDB.Driver`. Mọi thao tác I/O đều được triển khai theo cơ chế bất đồng bộ (Asynchronous).
* **Database:** **MongoDB** (NoSQL). Lựa chọn mô hình Document-based giúp lưu trữ linh hoạt các siêu dữ liệu của bài báo, thông tin tác giả và lịch sử giao dịch mà không bị gò bó bởi schema cứng nhắc của RDBMS truyền thống.

## 🚀 Core Business Modules

### 1. Publication Management (Quản lý Kỳ báo/Số báo)
* Quản lý danh sách các ấn phẩm, số báo theo từng đợt xuất bản.
* Theo dõi trạng thái duyệt của từng số báo để kiểm soát luồng khóa/mở dữ liệu nhuận bút.

### 2. Author & Pen Name Management (Quản lý Tác giả)
* Quản lý thông tin định danh tác giả (Họ tên, CCCD, MST, STK Ngân hàng).
* Hỗ trợ cơ chế định tuyến linh hoạt: Một tác giả thực thể (Physical Author) có thể sở hữu nhiều Bút danh (Pen Names) khác nhau trên các bài viết.

### 3. Royalty Processing (Nghiệp vụ Chấm Nhuận bút)
* Tự động tải danh sách bài viết theo Kỳ xuất bản (Issue-based filtering).
* Giao diện nhập liệu tối ưu (Fast-entry UI): Click-to-bind dữ liệu, tính toán Real-time tổng quỹ nhuận bút đã duyệt của một số báo nhằm chống vượt ngân sách.
* Hỗ trợ cơ chế Insert/Update thông minh trên cùng một ngữ cảnh UI.

### 4. Payment & Voucher Generation (Lập Phiếu chi)
* Liệt kê các khoản nhuận bút chưa thanh toán (Pending Royalties).
* Batch Processing: Cho phép chọn nhiều bài viết để gộp vào một phiếu chi duy nhất.
* Tự động áp dụng công thức tính Thuế thu nhập cá nhân (TNCN) và xuất ra số tiền Thực lĩnh cuối cùng.
* Hỗ trợ đa dạng phương thức thanh toán (Cash/Bank Transfer).

### 5. Reporting & Analytics (Thống kê - Báo cáo)
* **Dashboard:** Cung cấp cái nhìn toàn cảnh về tình hình tài chính, top tác giả, tiến độ thanh toán qua biểu đồ và thẻ số liệu.
* Báo cáo tổng hợp & Chi tiết theo từng tác giả, từng kỳ báo.
* Theo dõi công nợ (Liabilities).

## 💡 Technical Highlights
* **Asynchronous Processing:** Sử dụng triệt để `async/await` trong các thao tác truy vấn MongoDB (như `ToListAsync()`, `InsertOneAsync()`, `UpdateOneAsync()`), triệt tiêu hoàn toàn tình trạng UI blocking (treo giao diện) khi xử lý tập dữ liệu lớn.
* **Responsive UI/UX:** Áp dụng thuật toán Anchor & Docking linh hoạt. Giao diện có khả năng tự động Scale (Maximized) thích ứng với mọi độ phân giải màn hình mà không phá vỡ Layout.
* **State Management:** Quản lý trạng thái UI thông minh qua các sự kiện `CheckedState` của RadioButton mode, giúp điều hướng trực quan.
* **Anonymous Types & Data Binding:** Tối ưu hóa việc hiển thị dữ liệu phức hợp (như gộp Số báo + Tên báo + Ngày ra) trực tiếp qua LINQ Select, giảm thiểu việc phải tạo thêm các DTO Models dư thừa.
* **Audit Logging:** Tích hợp cơ chế ghi vết (Log) mọi thao tác thay đổi dữ liệu (Insert/Update/Delete) gắn liền với Session người dùng hiện tại, đảm bảo tính Non-repudiation (Không thể chối bỏ) trong hệ thống tài chính.
