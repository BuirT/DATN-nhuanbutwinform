# AGENTS.md — Hệ thống Quản lý Nhuận bút (NewsPay)

## Công nghệ

- **Ngôn ngữ**: C# .NET Framework 4.7.2
- **Giao diện**: Windows Forms + Guna.UI2 v2.0.4.7 + Guna.Charts.WinForms v1.1.0
- **CSDL**: SQL Server (System.Data.SqlClient) — `TNConnection`
- **Excel**: ClosedXML v0.95.4
- **AI**: Ollama + Qwen2.5:7b (local, <http://localhost:11434/api/generate>)
- **NuGet**: 42 packages

## Cấu trúc project

```
HETHONGTINHNHUANBUT/
├── Models/              (8 POCO classes: User, Bao, ButDanh, NhuanBut, PhieuChi, TacGia, ThanhToan, AppManager)
├── Workflow/            (business process docs)
├── App.config           (connection string + settings)
├── packages.config      (NuGet references)
├── Program.cs           (entry: Application.Run(new FormLogin()))
├── Helpers/             (AIConfig, UIHelper, HashHelper, PermissionHelper, AiIconResource)
├── Services/            (AIHelper, AIAuditService, AIDashboardService, AIReportService, AnomalyDetector, DatabaseMigrator, KiemDuyetService)
└── Frm*.cs              (28 form files)
```

## Connection string

```xml
<connectionStrings>
  <add name="TNConnection"
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=TenDatabase;Integrated Security=True" />
</connectionStrings>
```

(Xem `App.config.example` cho các cấu hình kết nối khác như Radmin VPN)

---

## Database schema

### Bảng chính

| Table      | Mô tả                                              | PK                  |
| ---------- | -------------------------------------------------- | ------------------- |
| Bao        | Số báo                                             | Maso (NVARCHAR)     |
| TacGia     | Tác giả                                            | MaTacgia (NVARCHAR) |
| ButDanh    | Bút danh — liên kết TacGia -> NhuanBut             | MsTacgia + Butdanh  |
| NhuanBut   | Nhuận bút (bài viết)                               | Maso (INT)          |
| NhuanbutCT | Chi tiết nhuận bút — liên kết NhuanBut -> PhieuChi | Id (INT IDENTITY)   |
| PhieuChi   | Phiếu chi                                          | Sophieu (NVARCHAR)  |
| ThanhToan  | Thanh toán                                         | N/A                 |
| DinhMuc    | Định mức theo thể loại                             | MaDM                |
| Users      | Người dùng                                         | Id (INT IDENTITY)   |
| AICanhBao  | Lịch sử cảnh báo bất thường do AI quét             | Id (INT IDENTITY)   |

### NhuanBut — TrangThaiDuyet workflow (5 bước)

| Giá trị | Ý nghĩa                 | Người thực hiện       |
| ------- | ----------------------- | --------------------- |
| 0       | Chờ chấm tiền           | Thư ký (hoặc mới tạo) |
| 1       | Đã chấm tiền            | Thư ký                |
| 2       | Đã nhập liệu (xác nhận) | Kế toán               |
| 3       | Đã kiểm tra             | Kiểm tra viên         |
| 4       | Đã ký duyệt             | Tổng thư ký           |

### NhuanBut — Các cột quan trọng

`TrangThaiDuyet`, `NguoiNhap`, `NguoiKiemTra`, `NguoiKeToan`, `TongThuKy`, `NguoiChamTien`, `LyDoBaoSai`, `NgayBaoSai`, `NgayChamTien`, `NgayNhapLieu`, `NgayKiemTra`, `NgayKy`

### PhieuChi — TrangThaiDuyet

| Giá trị | Ý nghĩa   |
| ------- | --------- |
| -1      | Từ chối   |
| 0       | Chờ duyệt |
| 1       | Đã duyệt  |

### PhieuChi — Cột đặc biệt

- `Dathutien`: 'N' = Chưa thanh toán, 'Y' = Đã thanh toán
- `TrangThaiDuyet`, `NguoiDuyet`, `NgayDuyet`, `LyDoTuChoi`

---

## File map — mỗi form làm gì?

### Login & Main

| File               | Chức năng                                     | Controls chính                        |
| ------------------ | --------------------------------------------- | ------------------------------------- |
| `FormLogin.cs`     | Đăng nhập, tự tạo Users table, SHA-256 + salt | Guna2TextBox, Guna2Button, Guna2Panel |
| `FrmTrangChinh.cs` | Navigation chính, sidebar, role-based menu    | Guna2Button x18+, Guna2Panel x2       |

### Tổng quan & Báo cáo

| File                  | Chức năng                                                                                                 | Controls chính                                                |
| --------------------- | --------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------- |
| `FrmDashboard.cs`           | Dashboard: thẻ tóm tắt, biểu đồ nhuận bút, top tác giả, biểu đồ tròn, lưới hoạt động gần đây              | GunaChart x4, Guna2DataGridView, Timer                        |
| `FrmBaoCaoThongKe.cs`       | Báo cáo thống kê, xuất báo cáo ra Excel với tiêu đề cột tiếng Việt                                        | Guna2DataGridView, Guna2ComboBox                              |
| `FrmBaoCaoTongHop.cs`       | Báo cáo tổng hợp theo tháng, biểu đồ đường nợ, xuất Excel                                                 | Chart (System.Windows.Forms), Guna2DataGridView               |
| `FrmBaoCaoCongNo.cs`        | Công nợ tác giả, biểu đồ cột 3 màu (tổng nợ/đã trả/còn nợ), xuất Excel                                    | Chart (System.Windows.Forms), Guna2DataGridView               |
| `FrmBaoCaoLanhDao.cs`       | Báo cáo lãnh đạo: biểu đồ tròn (đã chi/chưa chi), biểu đồ ngang (top tác giả), 2 lưới, xuất Excel 2 sheet | GunaChart x2 (Doughnut + HorizontalBar), Guna2DataGridView x2 |
| `FrmBaoCaoAI.cs`            | Báo cáo AI: thống kê dạng bảng + AI commentary, copy/save .txt                                            | Button x3, TextBox, DateTimePicker                            |
| `FrmAIPhanTichDashboard.cs` | Dashboard phân tích AI chuyên sâu, hiển thị cảnh báo, rủi ro                                              | Panels, Guna2DataGridView                                     |
| `FrmCanhBaoAI.cs`           | Quản lý cảnh báo AI, kiểm duyệt cảnh báo (xóa, đánh dấu đã xử lý)                                         | Guna2DataGridView, Buttons                                    |

### Nghiệp vụ chính

| File                      | Chức năng                                                                           | Controls chính                                  |
| ------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------- |
| `FrmKiemDuyetNhuanBut.cs` | Duyệt bài 5 bước, chữ ký số, AI phát hiện bất thường, báo sai sót                   | Guna2DataGridView, dynamic signature panels     |
| `FrmNhapNhuanBut.cs`      | Nhập bài (thư ký/admin), CRUD, AI kiểm toán, kiểm tra định mức                      | Guna2DataGridView, ComboBox x4, Guna2TextBox x5 |
| `FrmNhapBaiPhongVien.cs`  | Nhập bài cho phóng viên (chỉ nhập thông tin, không nhập tiền)                       | Guna2DataGridView, ComboBox x3                  |
| `FrmPhieuChi.cs`          | Lập phiếu chi, chọn tác giả -> chọn bài -> tính thuế (10% nếu >=2tr) -> transaction | Guna2DataGridView (manual columns), ComboBox x2 |
| `FrmQuanLyPhieuChi.cs`    | Xem và quản lý các phiếu chi đã lập, hiển thị danh sách tổng quan                   | Guna2DataGridView                               |
| `FrmDuyetPhieuChi.cs`     | Duyệt/từ chối phiếu chi, xác nhận đã thanh toán (kế toán)                           | Guna2DataGridView, dynamic btnThanhToan         |
| `FrmLichSuThanhToan.cs`   | Tra cứu lịch sử thanh toán chi tiết của tác giả hoặc phiếu chi                      | Guna2DataGridView, ComboBox                     |
| `FrmTroLyAI.cs`           | Chat AI: hỏi đáp về tác giả, thống kê, phiếu chi, bất thường, định mức              | FlowLayoutPanel (chat bubbles), Guna2TextBox    |
| `FrmThongkePhongvien.cs`  | Thống kê nhuận bút cá nhân dành cho phóng viên                                      | Guna2DataGridView, GunaChart                    |
| `FrmXemBaiViet.cs`        | Xem trước hoặc chỉnh sửa nội dung bài viết                                          | Guna2TextBox, Guna2Button                       |

### CRUD forms

`FrmTacGia.cs`, `FrmButdanh.cs`, `FrmSoBao.cs`, `FrmLoaiBao.cs`, `FrmTaiKhoan.cs`, `FrmThanhToan.cs`, `FrmTongHopThang.cs`, `FrmTraCuuNhuanBut.cs`

---

## Kiến trúc form

### Main form (FrmTrangChinh)

```
┌─────────────────────────────────────────────┐
│  pnlMenu (280px, Dock=Left) │ pnlMain (Fill)│
│  ┌─────────────────────┐    │ ┌───────────┐  │
│  │ Logo                │    │ │ ChildForm  │  │
│  │ btnTongQuan         │    │ │ Dock=Fill  │  │
│  │ btnTroLyAI          │    │ │            │  │
│  │ btnTacGia (+sub)    │    │ │            │  │
│  │ btnQuanLyBao (+sub) │    │ └───────────┘  │
│  │ btnNhapNhuanBut     │    │                 │
│  │ btnTraCuuCaNhan     │    │                 │
│  │ btnKiemDuyet        │    │                 │
│  │ btnPhieuChi         │    │                 │
│  │ btnDuyetChi         │    │                 │
│  │ btnBaoCao (+sub)    │    │                 │
│  │ btnBaoCaoAI         │    │                 │
│  │ btnDotThanhToan     │    │                 │
│  │ btnTaiKhoan         │    │                 │
│  │ btnDangXuat         │    │                 │
│  └─────────────────────┘    └─────────────────┘
└─────────────────────────────────────────────┘
```

### Mở form con

```csharp
private void OpenChildForm(Form childForm, Guna2Button clickedButton = null)
{
    if (activeForm != null) activeForm.Close();
    activeForm = childForm;
    // Inject quyền + mã tác giả qua reflection
    childForm.GetType().GetProperty("QuyenHienTai")?.SetValue(childForm, currentPrivilege);
    childForm.GetType().GetProperty("MaTacGiaCuaToi")?.SetValue(childForm, currentMaTacGia);
    childForm.TopLevel = false;
    childForm.FormBorderStyle = FormBorderStyle.None;
    childForm.Dock = DockStyle.Fill;
    pnlMain.Controls.Add(childForm);
    childForm.BringToFront();
    childForm.Show();
}
```

**Lưu ý**: Form con KHÔNG set `ClientSize`, `Dock`, `StartPosition` trong Designer.

### Pattern form con chuẩn (pnlTop + pnlBottom)

```
┌─ pnlTop (BorderRadius=16, white, Anchor=Top|Left|Right) ─┐
│  Title (Segoe UI 15F Bold)                                 │
│  [Input 1] [Input 2] [Input 3]                             │
│  [THÊM] [SỬA] [LƯU] [XÓA] [LÀM MỚI]                      │
└────────────────────────────────────────────────────────────┘
┌─ pnlBottom (Anchor=Top|Bottom|Left|Right) ─────────────────┐
│  [txtTimKiem ...]                                           │
│  ┌──────────────────────────────────────────────────────┐   │
│  │  Guna2DataGridView (Anchor=Fill)                     │   │
│  └──────────────────────────────────────────────────────┘   │
└────────────────────────────────────────────────────────────┘
```

---

## Helper classes

### UIHelper

- `FormatGiaoDienBang(Guna2DataGridView dgv)` — style chuẩn (Segoe UI, alternating rows, slate header)
- `ConfigureColumns(Guna2DataGridView dgv, params (string Name, string Header, bool IsNumeric, bool IsCenter)[] columns)` — format + FillWeight đều

**Luôn gọi `FormatGiaoDienBang` trong constructor, `ConfigureColumns` sau khi set DataSource.**

### HashHelper

- `GenerateSalt()` — 16-byte random salt, Base64
- `ComputeSha256(string password, string salt)` — SHA-256 hex string
- `IsSha256Hash(string value)` — validate format

### AIHelper

- `KiemTraMetadataNhapLieuAsync(...)` — gọi Ollama, kiểm tra tiêu đề/thể loại/trùng lặp
- Endpoint: `http://localhost:11434/api/generate`, model: `qwen2.5:7b`

### AnomalyDetector

- `KiemTraAsync(...)` — phân tích thống kê + AI gọi Ollama, trả về mức độ bất thường
- Dùng trong `FrmKiemDuyetNhuanBut` trước khi duyệt

---

## Quy tắc bất động (coding conventions)

### Font & Style

- **Font duy nhất**: Segoe UI, KHÔNG dùng VNI-Times
- **Form nền**: `Color.FromArgb(244, 247, 254)` — light blue-gray
- **Card fill**: `Color.White` với `BorderRadius = 16`, shadow `#E2E8F0`

### DataGridView

- Luôn gọi `UIHelper.FormatGiaoDienBang(dgv)` trong constructor
- Luôn gọi `UIHelper.ConfigureColumns()` sau `dgv.DataSource = ...`
- Thiết kế form con trong khung 860px (920px container - 2x20 padding)
- KHÔNG set `ClientSize`, `Dock`, `StartPosition` trên form con

### Database

- Async: `SqlDataAdapter` + `await Task.Run(() => da.Fill(dt))` — **không dùng `dt.Load(reader)`** (block UI)
- Connection string: `ConfigurationManager.ConnectionStrings["TNConnection"].ConnectionString`
- Transaction khi cần insert/update nhiều bảng

### Performance (chống giật lag)

1. **Cache chart controls**: Tạo GunaChart/GunaDataset 1 lần, chỉ Clear + Add DataPoints mỗi lần load
2. **SuspendLayout/ResumeLayout**: Gom nhóm thay đổi Visible, Enabled, Text...
3. **Double buffer form**: `typeof(Control).GetProperty("DoubleBuffered", ...).SetValue(this, true, null)` trong constructor
4. **Tắt Shadow + Animation**: `ShadowDecoration.Enabled = false`, `.Animated = false` trong Load
5. **Static flag cho DB setup**: `if (!_dbFixed) { await Task.Run(...); _dbFixed = true; }`
6. **Dùng field Designer, không `Controls.Find`** (duyệt cây control chậm)
7. **Parallel độc lập**: `await Task.WhenAll(task1, task2, ...)`
8. **Tránh LINQ Dictionary cho chart data**: Add trực tiếp từ reader
9. **BackgroundImage**: Set null trong constructor, restore trong Load để tránh stretch khi render lần đầu

### AI

- Ollama endpoint: `http://localhost:11434/api/generate`
- Model: `qwen2.5:7b`
- Timeout: 120s (2 phút)
- Stream response, check `IsDisposed` trước khi cập nhật UI

---

## Role & Permission mapping

| Role                               | Các nút hiển thị                                                                              |
| ---------------------------------- | --------------------------------------------------------------------------------------------- |
| Admin                              | Tất cả                                                                                        |
| Phóng viên / CTV / Khách mời       | NHẬP BÀI, TRA CỨU CÁ NHÂN                                                                     |
| Thư ký                             | NHẬP BÀI, TRA CỨU, KIỂM DUYỆT, BÁO CÁO TK (cả menu con), CẢNH BÁO AI, DASHBOARD              |
| Kế toán                            | NHẬP BÀI, TRA CỨU, KIỂM DUYỆT, PHIẾU CHI, DUYỆT CHI, LỊCH SỬ TT, BÁO CÁO TK (cả menu con), CẢNH BÁO AI, DASHBOARD, TRỢ LÝ AI, BÁO CÁO AI, ĐỢT CHI |
| Lãnh đạo                           | NHẬP BÀI, TRA CỨU, KIỂM DUYỆT, QL PHIẾU CHI, DUYỆT CHI, LỊCH SỬ TT, BÁO CÁO TK (cả menu con), CẢNH BÁO AI, DASHBOARD, TRỢ LÝ AI, BÁO CÁO AI, ĐỢT CHI, TÀI KHOẢN |
| Kiểm tra viên                      | NHẬP BÀI, TRA CỨU, KIỂM DUYỆT, BÁO CÁO TK (cả menu con), CẢNH BÁO AI, DASHBOARD              |
| Tổng thư ký                        | NHẬP BÀI, TRA CỨU, KIỂM DUYỆT, BÁO CÁO TK (cả menu con), CẢNH BÁO AI, DASHBOARD              |

---

## Quy tắc nghiệp vụ quan trọng

- **Thuế TNCN**: Nếu tổng tiền >= 2,000,000 VND -> khấu trừ 10%. Dưới 2tr -> 0%.
- **Định mức thể loại**: Kiểm tra khi nhập tiền, cảnh báo nếu vượt định mức (VD: "Tin van" tối đa 500,000)
- **Phiếu chi**: Sau khi duyệt/từ chối, nếu từ chối thì DELETE NhuanbutCT (giải phóng bài về trạng thái chưa thanh toán)

---

## Những lỗi AI hay mắc phải

| Lỗi                        | Cách tránh                                        |
| -------------------------- | ------------------------------------------------- |
| Form overflow >860px       | Thiết kế trong khung 860px                        |
| Quên .Text / .Click event  | Kiểm tra mọi button có đủ 2 thuộc tính            |
| `dt.Load(reader)` block UI | Dùng `SqlDataAdapter` + `Task.Run`                |
| Tạo lại chart mỗi Load     | Cache control, chỉ update DataPoints              |
| `Controls.Find` chậm       | Dùng field Designer                               |
| Shadow/Animation gây lag   | Tắt trong Load                                    |
| Form con set ClientSize    | Bỏ, để runtime fill                               |
| `System.Resources.Extensions` version mismatch  | .NET 10 SDK preserializes resx images → cần v6.0.0 tại runtime. Fix: `GenerateResourceUsePreserializedResources=true` trong csproj + NuGet `System.Resources.Extensions` v6.0.0 + binding redirect trong App.config |
| Font VNI-Times             | Chỉ dùng Segoe UI                                 |

---

## File workflow tham khảo

- `Workflow/WORKFLOW_GIAO_DIEN_WINFORM.md` — Design guide, style, pattern chi tiết
- `Workflow/quy-trinh-nghiep-vu-he-thong-nhuan-but.md` — Quy trình nghiệp vụ

### Quy tắc giao diện

- **Phân tích logic và design**: LUÔN LUÔN ghi nhớ file .cs chỉ được dùng để viết logic (xử lý sự kiện, nghiệp vụ, API, v.v.). KHÔNG ĐƯỢC viết code khởi tạo giao diện (UI design, add controls, set properties) trong file .cs. Mọi code khởi tạo giao diện, định dạng layout bắt buộc phải được viết trong file .Designer.cs (phương thức InitializeComponent).
