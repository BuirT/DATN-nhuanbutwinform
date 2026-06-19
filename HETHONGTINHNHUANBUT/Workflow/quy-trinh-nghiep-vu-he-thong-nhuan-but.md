# Quy Trình Nghiệp Vụ Hệ Thống Quản Lý Nhuận Bút

## 1. Tổng Quan Hệ Thống

Hệ thống quản lý nhuận bút dành cho tòa soạn báo in, hỗ trợ quy trình từ khâu nhập bài, chấm tiền nhuận bút, kiểm tra, ký duyệt, lập phiếu chi, duyệt chi đến thanh toán và thống kê.

**Công nghệ:**
- WinForms (.NET Framework) - Client
- SQL Server - Database
- Ollama (Qwen2.5) - AI hỗ trợ phát hiện bất thường, báo cáo, chatbot

---

## 2. Danh Mục Vai Trò Người Dùng

| Vai trò | Mô tả | Quyền chính |
|---------|-------|-------------|
| Quản trị viên (Admin) | Quản lý toàn hệ thống | Tất cả quyền |
| Phóng viên / CTV | Đối tượng nộp bài, được thanh toán nhuận bút | Nộp bài, xem thông tin cá nhân |
| Thư ký | Chấm tiền nhuận bút, quản lý tác giả, bút danh, số báo | Quản lý tác giả, bút danh, bài viết, chấm tiền |
| Kế toán | Nhập liệu nhuận bút vào hệ thống, lập phiếu chi | Nhập liệu, lập phiếu chi, AI assistant |
| Kiểm tra viên | Kiểm tra tính chính xác của dữ liệu nhập, ký xác nhận | Kiểm tra, xác nhận |
| Tổng thư ký | Ký duyệt nhuận bút cuối cùng | Ký duyệt bài, ký duyệt phiếu chi |
| Lãnh đạo | Phê duyệt phiếu chi cấp cao | Duyệt chi |

**Lưu ý:** Vai trò "Thư ký" trong hệ thống tương ứng với **Ban thư ký tòa soạn** - người chấm tiền nhuận bút theo quy trình thực tế.

---

## 3. Sơ Đồ Quy Trình Nghiệp Vụ Tổng Thể

```
1. Quản lý danh mục        2. Quản lý tác giả       3. Quản lý báo
   ┌─────────────┐          ┌─────────────┐          ┌─────────────┐
   │ - Loại báo  │          │ - Thêm TG   │          │ - Tạo số báo│
   │ - Vùng      │          │ - Sửa TG    │          │ - Sửa số báo│
   │ - Trang     │          │ - Xóa TG    │          │ - Xóa số báo│
   │ - Tham số   │          │ - Bút danh  │          │ - Khóa báo  │
   └─────────────┘          └─────────────┘          └─────────────┘
                                                            │
                                                            ▼
4. Báo đã phát hành (báo in)                                │
   ┌──────────────────────────────────────────────────────┐│
   │ - Ban thư ký tòa soạn chấm tiền nhuận bút            ││
   │   cho từng bài, tin, ảnh trên tờ báo đã in           ││
   └──────────────────────────────────────────────────────┘│
                            │                                │
                            ▼                                │
5. Nhập liệu nhuận bút                                       │
   ┌──────────────────────────────────────────────────────┐│
   │ - Tổ nhập liệu nhập tất cả NB đã được chấm vào PM   ││
   │ - Xử lý sai sót: chấm sót, cao tiền, vượt tổng      ││
   │ - Báo lại người chấm để thống nhất nếu có sai sót    ││
   └──────────────────────────────────────────────────────┘│
                            │                                │
                            ▼                                │
6. Kiểm tra + Ký xác nhận                                    │
   ┌──────────────────────────────────────────────────────┐│
   │ - Kiểm tra tính chính xác của dữ liệu nhập           ││
   │ - Chữ ký: Người nhập + Người kiểm tra + Tổng thư ký ││
   └──────────────────────────────────────────────────────┘│
                            │                                │
                            ▼                                │
7. Lập phiếu chi             │                                │
   ┌──────────────────────────────────────────────────────┐│
   │ - Chọn tác giả cần thanh toán                        ││
   │ - Chọn các bài viết đã ký duyệt của tác giả đó       ││
   │ - Hệ thống tính tổng tiền, thuế, thực lãnh           ││
   │ - Chọn hình thức thanh toán (CK/Tiền mặt)            ││
   │ - Ghi lý do chi                                      ││
   └──────────────────────────────────────────────────────┘│
                            │                                │
                            ▼                                │
8. Lãnh đạo duyệt chi        │                                │
   ┌──────────────────────────────────────────────────────┐│
   │ - Xem danh sách phiếu chi chờ duyệt                  ││
   │ - Duyệt: cập nhật trạng thái -> "Đã duyệt"           ││
   │ - Từ chối: nhập lý do -> "Từ chối"                   ││
   └──────────────────────────────────────────────────────┘│
                            │                                │
                            ▼                                │
9. Thanh toán                                               │
   ┌──────────────────────────────────────────────────────┐│
   │ - Xác nhận đã thanh toán (CK/TM)                     ││
   │ - Cập nhật trạng thái bài -> "Đã thanh toán"         ││
   └──────────────────────────────────────────────────────┘│
                            │                                │
                            ▼                                │
10. Báo cáo thống kê                                        │
   ┌──────────────────────────────────────────────────────┐┘
   │ - Tổng hợp NB đã chi / chưa chi                      │
   │ - Công nợ tác giả, số báo                            │
   │ - Báo cáo tổng hợp tháng                             │
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

**Màn hình**: `FrmTacGia`

**Luồng xử lý:**

1. **Thêm tác giả:**
   - Nhập: Mã số TG, Họ tên, Ngày sinh, Địa chỉ, Điện thoại, CMND, MST, Email
   - Loại tác giả: PV (Phóng viên) hoặc CTV (Cộng tác viên)
   - Thông tin ngân hàng: Ngân hàng, Số tài khoản
   - Thông tin phòng ban

2. **Sửa tác giả:** Cập nhật thông tin
3. **Xóa tác giả:** Xóa khỏi hệ thống
4. **Quản lý bút danh:** Mỗi tác giả có thể có nhiều bút danh

**Bảng CSDL:**
- `TacGia (Maso, MsTG, Hoten, Ngaysinh, Diachi, Dienthoai, ...)`
- `Butdanh (Maso, Butdanh, MsTacgia)`

---

### 4.3. Quản Lý Số Báo

**Màn hình**: `FrmSoBao`

**Luồng xử lý:**

1. **Tạo số báo mới:**
   - Nhập: Tên báo, Ngày ra, Số báo, Số bộ, Loại báo
   - Trạng thái: Chưa khóa (`DaDuyet = 'N'`)

2. **Sửa số báo:** Cập nhật thông tin
3. **Xóa số báo:** Xóa khỏi hệ thống
4. **Khóa số báo:** Khi số báo đã phát hành, khóa để không cho sửa (`DaDuyet = 'Y'`)

**Bảng CSDL:**
- `Bao (Maso, Tenbao, Ngayra, Sobao, Sobo, Loaibao, DaDuyet)`

---

### 4.4. Quản Lý Bài Viết / Nhuận Bút

**Màn hình**: `FrmKiemDuyetNhuanBut` (Kiểm duyệt), `FrmNhapNhuanBut` (Nhập liệu - toàn quyền), `FrmNhapBaiPhongVien` (PV nộp bài)

**Luồng xử lý (theo quy trình thực tế):**

```
Bước 0: Báo đã phát hành (in xong)
        │
        ├── Ban thư ký tòa soạn chấm tiền NB cho từng bài
        │   (Thư ký nhập TienNhuanbut, TrangThaiDuyet = 1)
        │
Bước 1: Tổ nhập liệu nhập dữ liệu vào phần mềm
        │   (Kế toán xác nhận đã nhập, TrangThaiDuyet = 2)
        │
        ├── Trong quá trình nhập, xử lý sai sót:
        │   - Chấm sót, cao tiền, vượt tổng → AI cảnh báo
        │   - Báo lại người chấm (Thư ký) để thống nhất
        │
Bước 2: Người kiểm tra xác nhận tính chính xác
        │   (TrangThaiDuyet = 3)
        │
Bước 3: Tổng thư ký ký duyệt
            (TongThuKy, TrangThaiDuyet = 4)
```

**Trạng thái bài viết (Nhuanbut.TrangThaiDuyet):**

| Giá trị | Ý nghĩa | Vai trò thực hiện |
|---------|---------|-------------------|
| 0 | Chờ chấm tiền (mới nộp / đã nhập từ báo in) | Ban thư ký |
| 1 | Đã chấm tiền | Ban thư ký |
| 2 | Đã nhập liệu vào phần mềm | Tổ nhập liệu / Kế toán |
| 3 | Đã kiểm tra xác nhận | Kiểm tra viên |
| 4 | Đã ký duyệt | Tổng thư ký |

---

### 4.5. Lập Phiếu Chi

**Màn hình**: `FrmPhieuChi`

**Luồng xử lý chi tiết:**

1. **Người phụ trách NB** chọn tác giả cần thanh toán
2. **Hệ thống hiển thị** danh sách bài viết đã ký duyệt (`TrangThaiDuyet = 4`) chưa thanh toán của tác giả đó
3. **Chọn các bài viết** muốn thanh toán trong đợt
4. **Tự động tính toán:**
   - `Tổng tiền` = Tổng tiền nhuận bút của các bài được chọn
   - `Thuế` = Tổng tiền * Thuế suất (nếu >= ngưỡng)
   - `Thực lãnh` = Tổng tiền - Thuế
5. **Nhập thông tin:**
   - Hình thức thanh toán: CK (Chuyển khoản) / TM (Tiền mặt)
   - Lý do chi, người nhận
6. **Lưu phiếu chi** -> Trạng thái: Chờ duyệt

**Bảng CSDL:**
- `Phieuchi (Sophieu, Ngaylap, Sotien, Thue, Conlai, Lydo, Nguoinhan, Nguoilap, ...)`
- `NhuanbutCT (MsTacgia, MsNhuanbut, Sotien, SoPC, SauThanhToan, ...)`

---

### 4.6. Duyệt Chi

**Màn hình**: `FrmDuyetPhieuChi`

**Luồng xử lý:**

1. Lãnh đạo mở danh sách phiếu chi chờ duyệt
2. Xem chi tiết từng phiếu chi
3. **Duyệt:** Cập nhật `TrangThaiDuyet = 1`, ghi nhận người duyệt, ngày duyệt
4. **Từ chối:** Nhập lý do, cập nhật `TrangThaiDuyet = -1`

**Trạng thái phiếu chi:**
- `0`: Chờ duyệt
- `1`: Đã duyệt
- `-1`: Từ chối

---

### 4.7. Thanh Toán

**Màn hình**: `FrmDuyetPhieuChi` (✅ XÁC NHẬN ĐÃ THANH TOÁN)

**Luồng xử lý:**

1. Phiếu chi đã được duyệt (`TrangThaiDuyet = 1`)
2. Click **✅ XÁC NHẬN ĐÃ THANH TOÁN**
3. Cập nhật `Phieuchi.Dathutien = 'Y'`
4. Cập nhật các bài viết trong phiếu chi -> `Nhuanbut.DaThanhToan = true`
5. Ghi nhận thông tin người xác nhận + ngày giờ

---

### 4.8. Báo Cáo Thống Kê

**Màn hình**: `FrmBaoCaoTongHop`, `FrmBaoCaoCongNo`, `FrmBaoCaoAI`, `FrmTongHopThang`

**Các loại báo cáo:**

1. **Báo cáo tổng hợp:**
   - Tổng hợp nhuận bút theo kỳ (tháng/quý/năm)
   - Đã chi / chưa chi

2. **Báo cáo công nợ:**
   - Công nợ tác giả
   - Công nợ số báo

3. **Báo cáo AI:**
   - Bảng thống kê do C# tự format
   - AI viết phần nhận xét ngắn

4. **Báo cáo cuối tháng:**
   - Tổng hợp NB đã chi
   - Tổng hợp NB chưa chi

---

### 4.9. AI Hỗ Trợ

**Màn hình**: `FrmTroLyAI`, `FrmBaoCaoAI`

**Các tính năng AI:**

1. **Chatbot trợ lý:** Hướng dẫn nghiệp vụ, hỗ trợ người dùng
2. **Phát hiện bất thường (AnomalyDetector):**
   - Query raw stats từ DB
   - Gửi cho Ollama phân tích
   - AI tự quyết định cảnh báo
3. **Báo cáo AI:**
   - C# tự format bảng thống kê
   - AI chỉ viết nhận xét

---

### 4.10. Quản Lý Người Dùng

**Màn hình**: `FrmTaiKhoan`

**Luồng xử lý:**
1. Tạo tài khoản: Username, Password (mã hóa), Họ tên, Quyền
2. Phân quyền theo vai trò
3. Liên kết tác giả (MaTacGiaGoc)

---

## 5. Sơ Đồ Luồng Trạng Thái

### 5.1. Luồng trạng thái bài viết

```
[Chờ chấm tiền (0)] ──> [Đã chấm tiền (1)] ──> [Đã nhập liệu (2)]
       │                                                  │
       └── (Báo sai sót) ──> [0]                          │
                                                           ▼
                                               [Đã kiểm tra (3)]
                                                      │
                                                      ▼
                                               [Đã ký duyệt (4)]
                                                      │
                                                      ▼
                                              Lập phiếu chi
                                                      │
                                                      ▼
                                              Đã thanh toán
```

### 5.2. Luồng trạng thái phiếu chi

```
               ┌──> Từ chối (-1)
               │
[Lập phiếu] ───┼──> [Chờ duyệt (0)] ──> [Đã duyệt (1)] ──> [Đã thanh toán]
               │
               └──> Sửa lại và gửi lại
```

### 5.3. Luồng trạng thái số báo

```
[Tạo số báo] ──> [Chưa khóa (N)] ──> [Đã khóa (Y)] (sau khi phát hành)
```

---

## 6. Mối Quan Hệ Giữa Các Module

```
Báo (Bao)
  │
  ├──< Chứa bài viết >── Nhuanbut (Bài viết / Nhuận bút)
  │                           │
  │                           ├──< Thuộc về >── TacGia (Tác giả)
  │                           │                    │
  │                           │                    └──< Có >── Butdanh (Bút danh)
  │                           │
  │                           └──< Chi tiết >── NhuanbutCT
  │                                                │
  │                                                └──< Thuộc >── Phieuchi (Phiếu chi)
  │                                                                     │
  │                                                                     └──< Đã duyệt >── Thanh toán
  │
  └──< Thuộc loại >── Loaibao (Loại báo)

TacGia (Tác giả)
  │
  └──< Liên kết >── Users (Người dùng hệ thống)
```

---

## 7. Quy Tắc Nghiệp Vụ Quan Trọng

### 7.1. Chữ ký
- Mỗi bước duyệt lưu lại tên người thực hiện + datetime
- Chữ ký text-based (tên + ngày), không upload ảnh, không vẽ chuột
- Hiển thị ở signature panel dưới grid và ở form phù hợp

### 7.2. Ràng buộc khi lập phiếu chi
- Một bài viết chỉ được thanh toán một lần (`DaThanhToan`)
- Chỉ lập phiếu chi cho bài viết đã ký duyệt (`TrangThaiDuyet = 4`)
- Khi lập phiếu chi, bài viết chưa được thuộc phiếu chi nào khác

### 7.3. Xử lý CTV theo vùng
- CTV có thể được chuyển về khu vực để chi hoặc tập trung một nơi
- Sử dụng cột Vung, VungChuyenDen để phân luồng

### 7.4. AI Anomaly Detector
- C# query raw stats từ DB
- Gửi cho Ollama phân tích
- AI tự quyết định bất thường
- Fallback silent nếu AI offline

### 7.5. Kiểm soát ngân sách
- Cảnh báo nếu tổng chi tháng vượt ngân sách (50tr)
- AI hỗ trợ phát hiện bất thường về tiền

---

## 8. Kiến Trúc Hệ Thống

### 8.1. WinForms Application

```
HETHONGTINHNHUANBUT/
├── FrmTrangChinh.cs        # Main form - menu chính + phân quyền
├── FormLogin.cs             # Đăng nhập
├── FrmKiemDuyetNhuanBut.cs  # Duyệt bài (chấm tiền → nhập liệu → kiểm tra → ký)
├── FrmNhapNhuanBut.cs       # Nhập liệu toàn quyền (admin/thư ký)
├── FrmNhapBaiPhongVien.cs   # Nộp bài cho phóng viên/CTV
├── FrmPhieuChi.cs           # Lập phiếu chi
├── FrmDuyetPhieuChi.cs      # Duyệt chi + xác nhận thanh toán
├── FrmBaoCaoTongHop.cs      # Báo cáo tổng hợp
├── FrmBaoCaoCongNo.cs       # Báo cáo công nợ
├── FrmBaoCaoAI.cs           # Báo cáo AI
├── FrmTongHopThang.cs       # Tổng hợp tháng
├── FrmTraCuuNhuanBut.cs     # Tra cứu nhuận bút (cá nhân)
├── FrmTroLyAI.cs            # Chatbot AI
├── FrmTongQuan.cs           # Dashboard
├── FrmSoBao.cs              # Quản lý số báo
├── FrmLoaiBao.cs            # Quản lý loại báo
├── FrmTacGia.cs             # Quản lý tác giả
├── FrmButdanh.cs            # Quản lý bút danh
├── FrmTaiKhoan.cs           # Quản lý người dùng
├── AnomalyDetector.cs       # AI phát hiện bất thường
└── AIHelper.cs              # Helper gọi Ollama
```

### 8.2. Database

```
├── Bảng danh mục: Loaibao, Vung, Trang, DinhMuc, gThongso
├── Bảng nghiệp vụ: Bao, TacGia, Butdanh, Nhuanbut
├── Bảng chứng từ: Phieuchi, NhuanbutCT
├── Bảng người dùng: Users
└── Bảng tạm: tmpNhuanBut, tmpCongNo, ...
```

---

*Tài liệu được cập nhật ngày 19/06/2026 - Dựa trên quy trình nghiệp vụ thực tế của tòa soạn*
