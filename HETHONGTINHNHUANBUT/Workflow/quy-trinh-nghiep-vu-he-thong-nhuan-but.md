# Quy Trình Nghiệp Vụ Hệ Thống Quản Lý Nhuận Bút

## 1. Tổng Quan Hệ Thống

Hệ thống quản lý nhuận bút dành cho tòa soạn báo in, hỗ trợ quy trình từ khâu nhập bài, chấm tiền nhuận bút, kiểm tra, ký duyệt, lập phiếu chi, duyệt chi đến thanh toán và thống kê.

**Công nghệ:**
- WinForms (.NET Framework) - Client
- SQL Server - Database
- Ollama (Qwen2.5) - AI hỗ trợ phát hiện bất thường, báo cáo, chatbot

---

## 2. Danh Mục Vai Trò Người Dùng

| Vai trò | Mô tả | Quyền chính | Menu thấy |
|---------|-------|-------------|-----------|
| Quản trị viên (Admin) | Quản lý toàn hệ thống | Tất cả quyền | Tất cả |
| Phóng viên / CTV / Khách mời | Đối tượng nộp bài, được thanh toán | Nộp bài, tra cứu cá nhân | NhapBai, TraCuu |
| Thư ký | Chấm tiền nhuận bút | Chấm tiền (0→1) | KiemDuyet |
| Kế toán | Nhập liệu NB, lập phiếu chi, xác nhận thanh toán | Nhập liệu (1→2), báo sai sót, lập phiếu chi, duyệt chi, AI + BC AI, thanh toán | KiemDuyet, PhieuChi, DuyetChi, TroLyAI, BaoCaoAI, DotThanhToan |
| Kiểm tra viên | Kiểm tra tính chính xác dữ liệu nhập | Kiểm tra (2→3), trả về Kế toán | KiemDuyet |
| Tổng thư ký | Ký duyệt NB cuối cùng | Ký duyệt (3→4), nhập tên ký thủ công | KiemDuyet |
| Lãnh đạo | Phê duyệt phiếu chi | Duyệt/từ chối phiếu chi, xem báo cáo, quản lý tài khoản | KiemDuyet, DuyetChi, TaiKhoan, TroLyAI, BaoCaoAI, DotThanhToan |

**Lưu ý:** Vai trò "Thư ký" tương ứng **Ban thư ký tòa soạn** - người chấm tiền NB.

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

**Màn hình**: `FrmKiemDuyetNhuanBut` (Kiểm duyệt 5 bước), `FrmNhapNhuanBut` (Nhập liệu - toàn quyền), `FrmNhapBaiPhongVien` (PV nộp bài)

**Luồng xử lý (theo quy trình thực tế - 5 bước):**

```
Bước 0: Báo đã phát hành (in xong)
        │
        ├── Ban thư ký tòa soạn chấm tiền NB cho từng bài
        │   (btn = "✅ CHẤM TIỀN", nhập TienNhuanbut, TrangThaiDuyet = 1)
        │   (btn từ chối = "❌ TỪ CHỐI" → TT=0)
        │
Bước 1: Tổ nhập liệu nhập dữ liệu vào phần mềm
        │   (btn = "✅ XÁC NHẬN NHẬP LIỆU", TrangThaiDuyet = 2)
        │
        ├── Trong quá trình nhập, xử lý sai sót:
        │   - Chấm sót, cao tiền, vượt tổng → AI cảnh báo
        │   - Báo lại người chấm (btn = "📨 BÁO SAI SÓT" → nhập lý do → TT=0)
        │
Bước 2: Người kiểm tra xác nhận tính chính xác
        │   (btn = "✅ XÁC NHẬN ĐÚNG", TrangThaiDuyet = 3)
        │   (btn trả về = "❌ TRẢ VỀ KẾ TOÁN" → TT=2)
        │
Bước 3: Tổng thư ký ký duyệt
        │   (btn = "✅ KÝ DUYỆT", nhập tên ký thủ công txtNguoiKy, TrangThaiDuyet = 4)
        │   (btn trả về = "❌ TRẢ VỀ KIỂM TRA" → TT=3)
        │
Sau khi ký duyệt: Bài sẵn sàng lập phiếu chi
        │
        ▼
    Lập phiếu chi → Lãnh đạo duyệt → Kế toán xác nhận đã thanh toán
```

**Trạng thái bài viết (Nhuanbut.TrangThaiDuyet):**

| Giá trị | Ý nghĩa | Vai trò thực hiện | Nút xác nhận | Nút từ chối/trả về |
|---------|---------|-------------------|--------------|-------------------|
| 0 | Chờ chấm tiền | Thư ký | ✅ CHẤM TIỀN → 1 | ❌ TỪ CHỐI → 0 |
| 1 | Đã chấm tiền | Kế toán (nhập liệu) | ✅ XÁC NHẬN NHẬP LIỆU → 2 | 📨 BÁO SAI SÓT → 0 |
| 2 | Đã nhập liệu | Kiểm tra viên | ✅ XÁC NHẬN ĐÚNG → 3 | ❌ TRẢ VỀ KẾ TOÁN → 2 |
| 3 | Đã kiểm tra | Tổng thư ký | ✅ KÝ DUYỆT → 4 | ❌ TRẢ VỀ KIỂM TRA → 3 |
| 4 | Đã ký duyệt | — | Đã hoàn tất | — |

**Signature panel (5 labels dưới grid):**
- 📝 Người nhập — `NguoiNhap` + ngày nhập
- 🖊 Người chấm — `NguoiChamTien` + `NgayChamTien`
- 📋 Nhập liệu — `NguoiKeToan` + `NgayNhapLieu`
- ✅ Kiểm tra — `NguoiKiemTra` + `NgayKiemTra`
- 📌 Ký duyệt — `TongThuKy` + `NgayKy`

**Ô nhập tên ký (Tổng thư ký):** `txtNguoiKy` (Guna2TextBox, PlaceholderText = "Nhập tên ký...")

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

**Màn hình**: `FrmDuyetPhieuChi` (btnThanhToan tạo programmatically)

**Luồng xử lý:**

1. Phiếu chi đã được duyệt (`TrangThaiDuyet = 1`)
2. Kế toán mở `FrmDuyetPhieuChi` → chọn phiếu chi có `Dathutien = 'N'`
3. Click **✅ XÁC NHẬN ĐÃ THANH TOÁN** (btnThanhToan, chỉ hiện khi role=Kế toán & phiếu đã duyệt & chưa thanh toán)
4. Transaction:
   - `UPDATE Phieuchi SET Dathutien = 'Y'` 
   - `UPDATE NhuanbutCT SET SauThanhToan = 'Y' WHERE SoPC = @id`
5. Nút tự động ẩn sau khi thanh toán

**Lưu ý:** Không có FrmThanhToan riêng. Kế toán xác nhận trực tiếp trên lưới phiếu chi.

---

### 4.8. Báo Cáo Thống Kê

**Các màn hình báo cáo:**

| Màn hình | Chức năng | Công nghệ biểu đồ |
|----------|-----------|-------------------|
| `FrmBaoCaoTongHop` | Báo cáo tổng hợp theo tháng | Chart (WinForms) |
| `FrmBaoCaoCongNo` | Công nợ tác giả (3 cột: Tổng nợ/Đã trả/Còn nợ), xuất Excel | Chart cột + ClosedXML |
| `FrmBaoCaoLanhDao` | Báo cáo lãnh đạo cuối tháng: 2 grid (tổng hợp tác giả + chi tiết NB), doughnut (đã chi/chưa chi), hbar (top 8 tác giả), footer thống kê, xuất Excel 2 sheets | Guna.Charts.WinForms + ClosedXML |
| `FrmBaoCaoAI` | Bảng thống kê C# format + AI commentary (Ollama) | — |
| `FrmTongQuan` | Dashboard: 4 thẻ tóm tắt, biểu đồ đường (chi theo tháng), biểu đồ tròn (loại báo), lưới hoạt động gần đây | Guna.Charts.WinForms |
| `FrmTongHopThang` | Tổng hợp tháng | — |

**Chi tiết FrmBaoCaoLanhDao:**
- Grid trên: Tổng hợp theo tác giả (Tác giả, Số bài, Tổng NB, Đã chi, Chưa chi)
- Grid dưới: Chi tiết từng bài (Maso, Tên bài, Bút danh, Tác giả, NB, Trạng thái, Ngày đăng)
- Footer: Tổng số bài, Tổng NB, Đã chi, Chưa chi
- Biểu đồ trái: Doughnut (Đã chi / Chưa chi)
- Biểu đồ phải: Horizontal bar (Top 8 tác giả theo tổng NB)
- Xuất Excel: 2 sheets (Tổng hợp tác giả + Chi tiết NB)

**Chi tiết FrmBaoCaoCongNo:**
- Biểu đồ cột 3 màu: Tổng nợ (xanh) / Đã thanh toán (xanh lá) / Còn nợ (đỏ)
- 3 thẻ summary: Tổng nợ, Đã thanh toán, Còn nợ (đổi màu thông minh)
- Xuất Excel

---

### 4.9. AI Hỗ Trợ

**Màn hình**: `FrmTroLyAI` (Chat AI), `FrmBaoCaoAI` (Báo cáo AI)

**Endpoint**: `http://localhost:11434/api/generate` — Model: `qwen2.5:7b`

**Các tính năng AI:**

1. **Chatbot trợ lý** (`FrmTroLyAI`):
   - Hỏi đáp về tác giả, thống kê, phiếu chi, bất thường, định mức
   - Giao diện chat bubbles (FlowLayoutPanel)

2. **Phát hiện bất thường (AnomalyDetector)** — gọi trước khi duyệt:
   - Query raw stats từ DB
   - Gửi cho Ollama phân tích
   - AI tự quyết định: `MucDo.Nhe` (cảnh báo kèm) / `MucDo.NghiemTrong` (popup Yes/No)
   - Fallback silent nếu AI offline

3. **Báo cáo AI** (`FrmBaoCaoAI`):
   - C# tự format bảng thống kê (font Consolas, căn cột)
   - AI chỉ viết phần nhận xét ngắn
   - Copy / Save .txt

---

### 4.10. Quản Lý Người Dùng

**Màn hình**: `FrmTaiKhoan`

**Luồng xử lý:**
1. Tạo tài khoản: Username, Password (SHA-256 + salt), Họ tên, Quyền
2. Các quyền có sẵn: Admin, Thư ký, Kế toán, Kiểm tra viên, Tổng thư ký, Lãnh đạo, Phóng viên, Cộng tác viên, Khách mời
3. Liên kết tác giả (MaTacGiaGoc)

**Mã hóa:** `HashHelper.cs` — GenerateSalt() 16-byte + ComputeSha256(password, salt) → hex string

---

## 5. Sơ Đồ Luồng Trạng Thái

### 5.1. Luồng trạng thái bài viết

```
[Chờ chấm tiền (0)] ──┬──> [Đã chấm tiền (1)] ──> [Đã nhập liệu (2)]
       ▲              │                                │
       │              └── Thư ký từ chối               │
       │                                               │
       ├── (Kế toán báo sai sót) ──────────────────────┘
       │                                               │
       │                                  ┌────────────┘
       │                                  ▼
       │                          [Đã kiểm tra (3)]
       │                               │         │
       │                               │         └── (Trả về Kế toán) ──> [2]
       │                               ▼
       │                        [Đã ký duyệt (4)]
       │                             │         │
       │                             │         └── (Trả về Kiểm tra) ──> [3]
       │                             ▼
       │                     Lập phiếu chi
       │                             │
       │                             ▼
       │                     Lãnh đạo duyệt chi
       │                             │
       │                             ▼
       │                     Kế toán xác nhận đã thanh toán
       │
       └── Admin có thể đưa về [0] bất kỳ lúc nào
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
├── FrmTrangChinh.cs        # Main form - menu + phân quyền (sidebar 280px + content 920px)
├── FormLogin.cs             # Đăng nhập, SHA-256 + salt, tự tạo Users table
├── FrmKiemDuyetNhuanBut.cs  # Duyệt bài 5 bước + signature panel + AI anomaly
├── FrmNhapNhuanBut.cs       # Nhập liệu toàn quyền (admin/thư ký) + AI kiểm toán
├── FrmNhapBaiPhongVien.cs   # Nộp bài cho phóng viên/CTV
├── FrmPhieuChi.cs           # Lập phiếu chi (thuế 10% nếu >=2tr)
├── FrmDuyetPhieuChi.cs      # Duyệt chi + btnThanhToan programmatic
├── FrmBaoCaoTongHop.cs      # Báo cáo tổng hợp (Chart đường)
├── FrmBaoCaoCongNo.cs       # Công nợ tác giả (Chart cột 3 màu + Excel)
├── FrmBaoCaoLanhDao.cs      # Báo cáo lãnh đạo (Guna Doughnut + HBar + 2 grid + Excel 2 sheets)
├── FrmBaoCaoAI.cs           # Báo cáo AI: bảng C# + AI commentary
├── FrmTongHopThang.cs       # Tổng hợp tháng
├── FrmTraCuuNhuanBut.cs     # Tra cứu nhuận bút (cá nhân)
├── FrmTroLyAI.cs            # Chatbot AI (Ollama qwen2.5)
├── FrmTongQuan.cs           # Dashboard: Guna line chart + doughnut + 4 summary cards
├── FrmSoBao.cs              # Quản lý số báo
├── FrmLoaiBao.cs            # Quản lý loại báo
├── FrmTacGia.cs             # Quản lý tác giả
├── FrmButdanh.cs            # Quản lý bút danh
├── FrmTaiKhoan.cs           # Quản lý người dùng
├── FrmThanhToan.cs          # Đợt thanh toán (menu DotThanhToan)
├── AnomalyDetector.cs       # AI phát hiện bất thường (2 mức: Nhẹ/Nghiêm trọng)
├── AIHelper.cs              # Helper gọi Ollama API
├── UIHelper.cs              # FormatGiaoDienBang + ConfigureColumns
└── HashHelper.cs            # SHA-256 + salt password

Workflow/
├── quy-trinh-nghiep-vu-he-thong-nhuan-but.md   # Quy trình nghiệp vụ (file này)
└── WORKFLOW_GIAO_DIEN_WINFORM.md                  # Design guide + coding conventions
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

*Tài liệu được cập nhật ngày 20/06/2026 - Dựa trên quy trình nghiệp vụ thực tế của tòa soạn (báo in)*
