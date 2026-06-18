# Quy Trình Nghiệp Vụ Hệ Thống Quản Lý Nhuận Bút

## 1. Tổng Quan Hệ Thống

Hệ thống quản lý nhuận bút dành cho tòa soạn báo, hỗ trợ quy trình từ khâu nhập bài, tính nhuận bút, lập phiếu chi, duyệt chi đến thanh toán và thống kê.

**Công nghệ:**
- WinForms (.NET Framework) - Client
- Node.js/Express - Backend API
- MongoDB (Web) / SQL Server (WinForms)
- SignalR - Real-time notifications

---

## 2. Danh Mục Vai Trò Người Dùng

| Vai trò | Mô tả | Quyền chính |
|---------|-------|-------------|
| Quản trị viên (Admin) | Quản lý toàn hệ thống | Tất cả quyền |
| Thư ký / Biên tập viên | Nhập bài, quản lý tác giả, lập phiếu chi | Quản lý tác giả, bút danh, bài viết, phiếu chi |
| Kế toán | Duyệt chi, theo dõi công nợ | Duyệt phiếu chi, thống kê |
| Phóng viên / CTV | Đối tượng được thanh toán | Xem thông tin cá nhân |
| Lãnh đạo | Phê duyệt cấp cao | Duyệt bài, duyệt chi |

---

## 3. Sơ Đồ Quy Trình Nghiệp Vụ Tổng Thể

```
1. Quản lý danh mục        2. Quản lý tác giả       3. Quản lý báo
   ┌─────────────┐          ┌─────────────┐          ┌─────────────┐
   │ - Loại báo  │          │ - Thêm TG   │          │ - Tạo số báo│
   │ - Vùng      │          │ - Sửa TG    │          │ - Sửa số báo│
   │ - Trang     │          │ - Xóa TG    │          │ - Xóa số báo│
   │ - Tham số   │          │ - Bút danh  │          │ - Duyệt báo │
   └─────────────┘          └─────────────┘          └─────────────┘
                                                           │
                                                           ▼
4. Nhập bài viết / Tính nhuận bút                          │
   ┌──────────────────────────────────────────────────────┐│
   │ - Chọn số báo, tác giả, bút danh                     ││
   │ - Nhập tên bài, trang, mục, vùng                     ││
   │ - Hệ thống tự động tính thuế (nếu >= ngưỡng)          ││
   │ - Có thể đánh dấu ngoài giờ, vùng chuyển đến          ││
   └──────────────────────────────────────────────────────┘│
                           │                                │
                           ▼                                │
5. Lập phiếu chi           │                                │
   ┌──────────────────────────────────────────────────────┐│
   │ - Chọn tác giả cần thanh toán                        ││
   │ - Chọn các bài viết đã duyệt của tác giả đó          ││
   │ - Hệ thống tính tổng tiền, thuế, thực lãnh           ││
   │ - Chọn hình thức thanh toán (CK/Tiền mặt)            ││
   │ - Ghi lý do chi                                      ││
   └──────────────────────────────────────────────────────┘│
                           │                                │
                           ▼                                │
6. Duyệt chi               │                                │
   ┌──────────────────────────────────────────────────────┐│
   │ - Kế toán xem danh sách phiếu chi chờ duyệt          ││
   │ - Duyệt: cập nhật trạng thái -> "Đã duyệt"           ││
   │ - Từ chối: nhập lý do -> "Từ chối"                   ││
   └──────────────────────────────────────────────────────┘│
                           │                                │
                           ▼                                │
7. Thanh toán                                              │
   ┌──────────────────────────────────────────────────────┐│
   │ - Thủ quỹ thực hiện chi trả                          ││
   │ - Đánh dấu "Đã thu tiền"                             ││
   │ - Cập nhật trạng thái bài -> "Đã thanh toán"         ││
   └──────────────────────────────────────────────────────┘│
                           │                                │
                           ▼                                │
8. Báo cáo thống kê                                        │
   ┌──────────────────────────────────────────────────────┐┘
   │ - Công nợ tác giả                                    │
   │ - Công nợ số báo                                     │
   │ - Báo cáo tổng hợp                                   │
   └──────────────────────────────────────────────────────┘
```

---

## 4. Quy Trình Chi Tiết Từng Module

### 4.1. Quản Lý Danh Mục

#### a. Loại báo (Newspaper types)
- **Mã số**: `varchar(4)` - PK
- **Tên loại**: VD: Bất động sản, Giáo dục, Kinh tế, Pháp luật & Xã hội, Thể dục, Văn hóa, Xã hội, Thời trang, Chính trị, Công nghệ

#### b. Vùng (Regions)
- **Mã số**: `nvarchar(50)` - PK
- **Tên vùng**: Tất cả, Miền Trung, Miền Bắc, Miền Nam, Thế giới, Quốc tế

#### c. Trang (Pages)
- Danh sách trang: Trang 1, Trang 2, Trang 3, Trang 4, Trang 5

#### d. Tham số hệ thống (System parameters)
- `ThueSuat`: Thuế suất (%), mặc định 10
- `HeSoNhuanBut`: Hệ số nhuận bút
- `TyLeThue`: Tỷ lệ thuế
- `NganSachThang`: Ngân sách tháng (VD: 50,000,000 VND)

---

### 4.2. Quản Lý Tác Giả

**Màn hình**: `frmTacGia` (WinForms), `tacGiaRoute.js` (Web)

**Luồng xử lý:**

1. **Thêm tác giả:**
   - Nhập: Mã số TG, Họ tên, Ngày sinh, Địa chỉ, Điện thoại, CMND, MST, Email
   - Loại tác giả: PV (Phóng viên) hoặc CTV (Cộng tác viên)
   - Thông tin ngân hàng: Ngân hàng, Số tài khoản
   - Thông tin phòng ban
   - Upload: Avatar, PDF (hồ sơ)

2. **Sửa tác giả:** Cập nhật thông tin

3. **Xóa tác giả:** (Xóa mềm / Xóa cứng tùy phiên bản)

4. **Quản lý bút danh:** Mỗi tác giả có thể có nhiều bút danh

**Bảng CSDL:**
- `TacGia (Maso, MsTG, Hoten, Ngaysinh, Diachi, Dienthoai, ...)`
- `Butdanh (Maso, Butdanh, MsTacgia)`

---

### 4.3. Quản Lý Số Báo

**Màn hình**: `frmBao` (WinForms), `soBaoRoute.js` (Web)

**Luồng xử lý:**

1. **Tạo số báo mới:**
   - Nhập: Tên báo, Ngày ra, Số báo, Số bộ, Loại báo
   - Trạng thái: Chưa duyệt (`DaDuyet = 'N'`)

2. **Sửa số báo:** Cập nhật thông tin

3. **Xóa số báo:** Xóa khỏi hệ thống

4. **Duyệt số báo:** Khi số báo đã hoàn chỉnh, đánh dấu `DaDuyet = 'Y'`

**Lưu ý:** Chỉ có thể thêm bài viết vào số báo đã được duyệt.

**Bảng CSDL:**
- `Bao (Maso, Tenbao, Ngayra, Sobao, Sobo, Loaibao, DaDuyet)`

---

### 4.4. Quản Lý Bài Viết / Nhuận Bút

**Màn hình**: `frmNhuanBut` (WinForms), `nhuanButRoute.js` (Web)

**Mô tả:** Đây là module cốt lõi, quản lý bài viết và tính nhuận bút.

**Luồng xử lý:**

1. **Thêm bài viết:**
   - Chọn số báo (chỉ hiện số báo đã duyệt)
   - Nhập tên bài, chọn trang, mục
   - Chọn bút danh (tự động lấy tác giả tương ứng)
   - Nhập số tiền nhuận bút
   - Chọn vùng, vùng chuyển đến (nếu có)
   - Đánh dấu ngoài giờ (nếu có)
   - **Hệ thống tự động tính thuế:**
     - Nếu tiền nhuận bút >= Ngưỡng chịu thuế (cấu hình) -> Tính thuế = Tiền * Thuế suất%
     - Nếu < Ngưỡng -> Thuế = 0
     - Thực lãnh = Tiền nhuận bút - Thuế
   - Trạng thái ban đầu: "Chờ duyệt" (WinForms) / Không có (Web)

2. **Sửa bài viết:**
   - Nếu sửa tiền nhuận bút -> Tính lại thuế và thực lãnh
   - Lưu vết kiểm toán: người duyệt, ngày duyệt khi chuyển trạng thái

3. **Xóa bài viết:**
   - WinForms: Xóa cứng
   - Web: Xóa mềm (`isDeleted = true`)

4. **Trạng thái bài viết (Web):**
   - `Chờ duyệt` -> `Đã duyệt` -> `Đã thanh toán` -> `Đã hủy`

**Bảng CSDL:**
- `Nhuanbut (Maso, Tenbai, Trang, Muc, TienNhuanbut, Butdanh, MsBao, Vung, VungChuyenDen, NgoaiGio, DaThanhToan, MaPhieuChi, ...)`
- Model Web: `NhuanBut (tenBai, tacGia, soBao, tienNhuanBut, thue, thucLanh, trangThai, ...)`

---

### 4.5. Lập Phiếu Chi

**Màn hình**: `frmPhieuChi` (WinForms), `phieuChiRoute.js` (Web)

**Luồng xử lý chi tiết:**

1. **Chọn tác giả** cần thanh toán
2. **Hệ thống hiển thị danh sách bài viết chưa thanh toán** của tác giả đó
3. **Chọn các bài viết** muốn thanh toán trong kỳ này
4. **Tự động tính toán:**
   - `Tổng tiền` = Tổng tiền nhuận bút của các bài được chọn
   - `Tổng thuế` = Tổng thuế của các bài
   - `Thực lãnh` = Tổng tiền - Tổng thuế
5. **Nhập thông tin:**
   - Hình thức thanh toán: CK (Chuyển khoản) / TM (Tiền mặt)
   - Lý do chi, người nhận
   - Người lập phiếu (tự động từ người dùng hiện tại)
6. **Lưu phiếu chi:**
   - Sinh mã phiếu tự động: `PC-YYYYMMDD-NNNN`
   - Cập nhật trạng thái các bài viết -> "Đã thanh toán" (Web) / `DaThanhToan = 0` (chờ duyệt)
   - Trạng thái duyệt ban đầu: 0 (Chờ duyệt) / `TrangThaiDuyet = 0`

**Trạng thái phiếu chi:**
- `0`: Chờ duyệt
- `1`: Đã duyệt
- `2`: Từ chối

**Bảng CSDL:**
- `Phieuchi (Sophieu, Ngaylap, Sotien, Thue, Conlai, Lydo, Nguoinhan, Nguoilap, Thuquy, Dathutien, TrangThaiDuyet, NguoiDuyet, NgayDuyet, LyDoTuChoi)`
- `NhuanbutCT (MsTacgia, MsNhuanbut, Sotien, Thue, Conlai, SoPC, SauThanhToan, DotTT)`

---

### 4.6. Duyệt Chi

**Màn hình**: `frmDuyetChi` (WinForms), `duyetChiRoute.js` (Web)

**Luồng xử lý:**

1. Kế toán mở danh sách phiếu chi
2. Xem chi tiết từng phiếu chi (các bài viết kèm theo)
3. **Thao tác duyệt:**
   - **Duyệt:** Hệ thống kiểm tra tính hợp lệ
     - WinForms: Cập nhật `TrangThaiDuyet = 1`, ghi nhận người duyệt, ngày duyệt
     - Web: Cập nhật `trangThai = "Đã duyệt"`, ghi nhận `nguoiDuyet`, `ngayDuyet`
   - **Từ chối:**
     - Nhập lý do từ chối (`LyDoTuChoi`)
     - Cập nhật `TrangThaiDuyet = 2` (hoặc `trangThai = "Từ chối"`)
4. **Sau khi duyệt:**
   - Nếu duyệt: Phiếu chi chuyển sang trạng thái chờ thanh toán
   - Nếu từ chối: Có thể sửa lại phiếu chi và gửi duyệt lại

---

### 4.7. Thanh Toán

**Màn hình**: `frmThanhToan` (WinForms)

**Luồng xử lý:**

1. **Tạo đợt thanh toán:**
   - Nhập tên gợi nhớ (VD: "Thanh toán nhuận bút T01/2025")
   - Chọn khoảng thời gian (Từ ngày - Đến ngày)
   - Chọn loại báo, vùng
   - Chọn hình thức thanh toán

2. **Chi tiết thanh toán:**
   - Hiển thị danh sách số báo trong kỳ
   - Tổng nhuận bút, đã chi trả, còn nợ

3. **Thủ quỹ thực hiện chi:**
   - Đánh dấu "Đã thu tiền" (`Dathutien = 'Y'`)
   - Cập nhật trạng thái bài viết và phiếu chi

**Bảng CSDL:**
- `ThanhToan (Maso, Tengoi, Ngay, Tungay, Denngay, Loaibao, Sotien, Vung, LoaiTT, Khoaso, hinhthucTT)`
- `ThanhToanCT (MsThanhToan, MsBao, Ngayra, Tongnhuanbut, Dachitra, Conno)`

---

### 4.8. Báo Cáo Thống Kê

**Màn hình**: `frmThongKe` (WinForms), `thongKeRoute.js` (Web)

**Các loại báo cáo:**

1. **Công nợ tác giả:**
   - Theo dõi số tiền nhuận bút còn nợ từng tác giả
   - Bảng tạm: `tmpCongNoTacGia`

2. **Công nợ số báo:**
   - Tổng nhuận bút, đã chi trả, còn nợ theo từng số báo
   - Bảng tạm: `tmpCongNo`

3. **Công nợ tháng:**
   - Tổng nhuận bút, đã chi, còn nợ theo từng tháng
   - Bảng tạm: `tmpCongNoThang`

4. **Tổng hợp công nợ:**
   - Tổng quan công nợ của tất cả tác giả
   - Bảng tạm: `tmpCongNoTong`

5. **Thống kê theo tác giả (Web):**
   - Tổng tiền, số bài theo từng tác giả
   - Lọc theo tháng, năm
   - Chỉ thống kê bài ở trạng thái "Đã duyệt"

---

### 4.9. Quản Lý Người Dùng

**Màn hình**: `frmUser` hoặc tích hợp trong hệ thống

**Luồng xử lý:**
1. **Tạo tài khoản:** Username, Password (mã hóa SHA256/bcrypt), Họ tên, Quyền
2. **Phân quyền:** Gán vai trò (Quản trị viên, Kế toán, Thư ký, Phóng viên)
3. **Liên kết tác giả:** Có thể gán tài khoản với mã tác giả gốc (`MaTacGiaGoc`)

**Bảng CSDL:**
- `Users (Id, TenDangNhap, MatKhau, Salt, HoTen, Quyen, HoatDong, MaTacGiaGoc)`

---

## 5. Sơ Đồ Luồng Trạng Thái

### 5.1. Luồng trạng thái bài viết

```
[Chờ duyệt] ──> [Đã duyệt] ──> [Đã thanh toán]
      │                              │
      └──> [Đã hủy]                  │
                                     │
                [Từ chối] <──────────┘
```

### 5.2. Luồng trạng thái phiếu chi

```
             ┌──> Từ chối (2)
             │
[Lập phiếu] ──┼──> [Chờ duyệt (0)] ──> [Đã duyệt (1)] ──> [Đã thu tiền]
             │
             └──> [Có thể sửa lại và gửi lại]
```

### 5.3. Luồng trạng thái số báo

```
[Tạo số báo] ──> [Chưa duyệt (N)] ──> [Đã duyệt (Y)]
```

---

## 6. Mối Quan Hệ Giữa Các Module

```
Báo (Newspaper)
  │
  ├──< Chứa bài viết >── Nhuanbut (Article/Royalty)
  │                           │
  │                           ├──< Thuộc về >── TacGia (Author)
  │                           │                    │
  │                           │                    └──< Có >── Butdanh (Pseudonym)
  │                           │
  │                           └──< Chi tiết >── NhuanbutCT
  │                                                │
  │                                                └──< Thuộc >── Phieuchi (Payment Voucher)
  │                                                                     │
  │                                                                     ├──< Có >── TrangThaiDuyet
  │                                                                     │
  │                                                                     └──< Thuộc >── ThanhToanCT
  │                                                                                      │
  │                                                                                      └──< Thuộc >── ThanhToan (Payment Batch)
  │
  └──< Thuộc loại >── Loaibao (Newspaper Type)

TacGia (Author)
  │
  ├──< Liên kết >── Users (System Users - via MaTacGiaGoc)
  │
  └──< Thuộc vùng >── Vung (Region)

gThongso (System parameters) ──> Điều khiển cách tính thuế nhuận bút
```

---

## 7. Quy Tắc Nghiệp Vụ Quan Trọng

### 7.1. Tính thuế nhuận bút
- **Ngưỡng chịu thuế**: Cấu hình động trong bảng `gThongso` / `CauHinh`
- **Công thức:**
  - Nếu `tienNhuanBut >= mucChiuThue`:
    - `Thue = tienNhuanBut * phanTramThue / 100`
    - `ThucLanh = tienNhuanBut - Thue`
  - Nếu `tienNhuanBut < mucChiuThue`:
    - `Thue = 0`
    - `ThucLanh = tienNhuanBut`

### 7.2. Ràng buộc khi lập phiếu chi
- Một bài viết chỉ được thanh toán một lần (`DaThanhToan` / `SauThanhToan`)
- Chỉ lập phiếu chi cho bài viết đã được duyệt
- Khi lập phiếu chi, bài viết chưa được thuộc phiếu chi nào khác

### 7.3. Ràng buộc số báo
- Chỉ thêm bài viết vào số báo đã duyệt (`DaDuyet = 'Y'`)
- Mỗi số báo thuộc một loại báo

### 7.4. Quy trình duyệt
- Kế toán duyệt phiếu chi
- Có thể từ chối kèm lý do
- Sau khi duyệt, thủ quỹ thực hiện chi

---

## 8. Kiến Trúc Hệ Thống

### 8.1. WinForms (Desktop Application)

```
DATN-nhuanbutwinform/
├── frmMain.cs              # MDI Main - Đăng nhập, menu
├── frmDangNhap.cs          # Đăng nhập
├── frmBao.cs               # Quản lý số báo
├── frmTacGia.cs            # Quản lý tác giả
├── frmButDanh.cs           # Quản lý bút danh
├── frmNhuanBut.cs          # Quản lý nhuận bút
├── frmPhieuChi.cs          # Lập phiếu chi
├── frmDuyetChi.cs          # Duyệt chi
├── frmThanhToan.cs         # Thanh toán
├── frmThongKe.cs           # Báo cáo thống kê
├── frmCauHinh.cs           # Cấu hình hệ thống
├── frmLoaiBao.cs           # Danh mục loại báo
├── frmVung.cs              # Danh mục vùng
├── BUS/                    # Business Layer
│   ├── BaoBUS.cs
│   ├── TacGiaBUS.cs
│   ├── NhuanButBUS.cs
│   └── ...
├── DAO/                    # Data Access Layer
│   ├── BaoDAO.cs
│   ├── TacGiaDAO.cs
│   └── ...
├── DTO/                    # Data Transfer Objects
└── SQLHelper.cs            # Kết nối SQL Server
```

### 8.2. Web API (Node.js/Express)

```
DATN-nhuatbutweb/backend/
├── server.js               # Entry point
├── routes/
│   ├── authRoute.js        # Đăng nhập, JWT
│   ├── tacGiaRoute.js      # CRUD tác giả
│   ├── soBaoRoute.js       # CRUD số báo
│   ├── nhuanButRoute.js    # CRUD bài viết + tính thuế
│   ├── phieuChiRoute.js    # Lập phiếu chi
│   ├── duyetChiRoute.js    # Duyệt bài viết
│   ├── thongKeRoute.js     # Thống kê
│   ├── cauHinhRoute.js     # Cấu hình thuế
│   └── userRoute.js        # Quản lý người dùng
├── models/                 # MongoDB models
│   ├── TacGia.js
│   ├── SoBao.js
│   ├── NhuanBut.js
│   ├── PhieuChi.js
│   ├── CauHinh.js
│   └── TaiKhoan.js
└── .env                    # Cấu hình
```

---

## 9. Luồng Dữ Liệu Giữa WinForms Và SQL Server

```
User Interface (WinForms)
    │
    ▼
BUS Layer (Business Logic)
    │  - Validation
    │  - Tính toán nghiệp vụ
    │  - Điều phối DAO
    ▼
DAO Layer (Data Access)
    │  - Stored Procedures
    │  - SQL Queries
    │  - Transactions
    ▼
SQLHelper ──> SQL Server Database
                  │
                  ├── Bảng danh mục: Loaibao, Vung, trang, gThongso
                  ├── Bảng nghiệp vụ: Bao, TacGia, Butdanh, Nhuanbut
                  ├── Bảng chứng từ: Phieuchi, NhuanbutCT, ThanhToan, ThanhToanCT
                  ├── Bảng người dùng: Users
                  └── Bảng tạm: tmpNhuanBut, tmpChuyen, tmpCongNo, ...
```

---

## 10. Các API Endpoint (REST)

| Phương thức | Endpoint | Chức năng |
|------------|----------|-----------|
| POST | `/api/auth/login` | Đăng nhập |
| GET | `/api/tac-gia/danh-sach` | Danh sách tác giả |
| POST | `/api/tac-gia/them` | Thêm tác giả |
| PUT | `/api/tac-gia/:id` | Sửa tác giả |
| DELETE | `/api/tac-gia/:id` | Xóa tác giả |
| GET | `/api/so-bao/danh-sach` | Danh sách số báo |
| POST | `/api/so-bao/them` | Thêm số báo |
| PUT | `/api/so-bao/:id` | Sửa số báo |
| DELETE | `/api/so-bao/:id` | Xóa số báo |
| GET | `/api/nhuan-but/danh-sach` | Danh sách bài viết |
| POST | `/api/nhuan-but/nhap-bai` | Thêm bài viết |
| PUT | `/api/nhuan-but/:id` | Sửa bài viết |
| DELETE | `/api/nhuan-but/:id` | Xóa bài viết (mềm) |
| POST | `/api/phieu-chi/tao-phieu` | Tạo phiếu chi |
| GET | `/api/phieu-chi/danh-sach` | Danh sách phiếu chi |
| PUT | `/api/duyet-chi/duyet-bai/:id` | Duyệt/từ chối bài |
| GET | `/api/thong-ke/thong-ke-tong` | Thống kê tổng hợp |
| GET | `/api/cau-hinh` | Lấy cấu hình |
| PUT | `/api/cau-hinh` | Cập nhật cấu hình |
| GET | `/api/users/danh-sach` | Danh sách người dùng |
| POST | `/api/users/them` | Thêm người dùng |
| PUT | `/api/users/:id` | Sửa người dùng |
| DELETE | `/api/users/:id` | Xóa người dùng |

---

*Tài liệu được tạo ngày 18/06/2026 - Dựa trên phân tích mã nguồn DATN-nhuanbutwinform và DATN-nhuatbutweb*
