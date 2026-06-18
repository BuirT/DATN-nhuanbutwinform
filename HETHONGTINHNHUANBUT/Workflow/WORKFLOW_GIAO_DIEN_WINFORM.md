# WORKFLOW & DESIGN GUIDE — WinForms App (DATN-nhuanbutwinform)

> **Công nghệ**: C# .NET Framework 4.7.2 | Windows Forms | Guna.UI2 | SQL Server | Ollama Qwen2.5
> **Mục đích**: Quản lý chi trả nhuận bút cho báo chí

---

## 1. KIẾN TRÚC FORM

### 1.1. Main Form (FrmTrangChinh)

```
┌────────────────────────────────────────────────────┐
│  Sidebar (pnlMenu)        │ Content (pnlMain)      │
│  ┌──────────────────┐     │ ┌────────────────────┐  │
│  │ Logo/Title       │280px│ │                    │  │
│  ├──────────────────┤     │ │  Child Form fills  │  │
│  │ Nav buttons      │     │ │  this area via     │  │
│  │ (Dock=Top, h=50) │     │ │  Dock=Fill         │  │
│  │                  │     │ │                    │  │
│  │ ...              │     │ │                    │  │
│  ├──────────────────┤     │ │                    │  │
│  │ Đăng xuất        │     │ │                    │  │
│  └──────────────────┘     │ └────────────────────┘  │
└────────────────────────────────────────────────────┘
```

**Kích thước**:
- Form: `1200 × 750` (khi chưa maximize)
- Sidebar: `280px` — `Dock = Left`
- Content (`pnlMain`): `920px` — `Dock = Fill`
- Màn hình tối thiểu: `1366 × 768`

### 1.2. OpenChildForm — Cách mở form con

```csharp
private void OpenChildForm(Form childForm, Guna2Button clickedButton = null)
{
    if (activeForm != null) activeForm.Close();
    activeForm = childForm;
    childForm.TopLevel = false;
    childForm.FormBorderStyle = FormBorderStyle.None;
    childForm.Dock = DockStyle.Fill;
    pnlMain.Controls.Add(childForm);
    childForm.BringToFront();
    childForm.Show();
}
```

**Quan trọng**: `Dock = DockStyle.Fill` được set ở runtime.  
Form con KHÔNG cần set `ClientSize`, `Dock`, `StartPosition` trong Designer — vì runtime sẽ override.

---

## 2. BỐ CỤC FORM CHUẨN (pnlTop + pnlBottom)

Đây là pattern dùng cho **mọi form chức năng**:

```
┌─ pnlTop (BorderRadius=16, white) ──────────────────┐
│  lblTitle  (Segoe UI 15F Bold)                      │
│                                                     │
│  [Input 1] [Input 2] [Input 3]                      │
│  [Input 4] [Input 5] [Input 6]                      │
│                                                     │
│  [THÊM] [SỬA] [LƯU] [XÓA] [LÀM MỚI]               │
└─────────────────────────────────────────────────────┘
┌─ pnlBottom (BorderRadius=16, white) ────────────────┐
│  lblDataTitle (Segoe UI 13.5F Bold)                 │
│  [txtTimKiem ...]                                   │
│  ┌──────────────────────────────────────────────┐   │
│  │            DataGridView                      │   │
│  │  (Anchor=Fill, BorderStyle=None,             │   │
│  │   AutoSizeColumnsMode=Fill)                  │   │
│  └──────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────┘
```

### 2.1. pnlTop — Cấu hình

```csharp
this.pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
this.pnlTop.BackColor = Color.Transparent;   // quan trọng
this.pnlTop.BorderRadius = 16;
this.pnlTop.FillColor = Color.White;
this.pnlTop.Location = new Point(20, 15);
// KHÔNG set Size.Width — nó tự co giãn theo Anchor
this.pnlTop.ShadowDecoration.Color = Color.FromArgb(226, 232, 240);
this.pnlTop.ShadowDecoration.Depth = 8;
this.pnlTop.ShadowDecoration.Enabled = true;
```

### 2.2. pnlBottom — Cấu hình

```csharp
this.pnlBottom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
this.pnlBottom.BackColor = Color.Transparent;
this.pnlBottom.BorderRadius = 16;
this.pnlBottom.FillColor = Color.White;
this.pnlBottom.Location = new Point(20, ???); // Y = pnlTop.Bottom + ~20
// KHÔNG set Size — tự co giãn
this.pnlBottom.ShadowDecoration.Color = Color.FromArgb(226, 232, 240);
this.pnlBottom.ShadowDecoration.Depth = 8;
this.pnlBottom.ShadowDecoration.Enabled = true;
```

### 2.3. DataGridView — Cấu hình chuẩn

```csharp
// Basic
this.dgv.AllowUserToAddRows = false;
this.dgv.AllowUserToDeleteRows = false;
this.dgv.AllowUserToResizeColumns = false;
this.dgv.AllowUserToResizeRows = false;
this.dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
this.dgv.BackgroundColor = Color.White;
this.dgv.BorderStyle = BorderStyle.None;
this.dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
this.dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
this.dgv.ReadOnly = true;
this.dgv.RowHeadersVisible = false;
this.dgv.RowTemplate.Height = 38;
this.dgv.GridColor = Color.FromArgb(241, 245, 249);

// Alternating rows
dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
dataGridViewCellStyle1.ForeColor = Color.FromArgb(15, 23, 42);
dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(248, 250, 252);
dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(15, 23, 42);
this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;

// Column headers
dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
dataGridViewCellStyle2.BackColor = Color.FromArgb(241, 245, 249);
dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 85, 105);
dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(241, 245, 249);
dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(71, 85, 105);
dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
this.dgv.ColumnHeadersHeight = 40;

// Default rows
dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
dataGridViewCellStyle3.BackColor = Color.White;
dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
dataGridViewCellStyle3.ForeColor = Color.FromArgb(15, 23, 42);
dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(232, 240, 254);
dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(15, 23, 42);
dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
```

---

## 3. FORM-LEVEL SETTINGS CHUẨN

```csharp
this.AutoScaleDimensions = new SizeF(96F, 96F);   // DPI scaling
this.AutoScaleMode = AutoScaleMode.Dpi;            // DPI mode
this.BackColor = Color.FromArgb(244, 247, 254);    // form background
this.DoubleBuffered = true;
this.Font = new Font("Segoe UI", 10F);              // font mặc định
this.Padding = new Padding(20, 15, 20, 20);         // viền trong
// KHÔNG set ClientSize, Dock, StartPosition — runtime quyết định
```

---

## 4. BẢNG MÀU

| Token | Hex | RGB | Dùng cho |
|-------|-----|-----|----------|
| Background | `#F4F7FE` | 244,247,254 | Nền form |
| Card fill | `#FFFFFF` | White | pnlTop, pnlBottom, pnlGrid |
| Shadow | `#E2E8F0` | 226,232,240 | Shadow decoration |
| **Primary Blue** | `#1877F2` | 24,119,242 | btnThêm (mới), FocusedState |
| **Warning Amber** | `#F59E0B` | 245,158,11 | btnSửa |
| **Danger Red** | `#DC2626` | 220,38,38 | btnXóa text |
| Red fill | `#FEF2F2` | 254,242,242 | btnXóa nền |
| Red border | `#FCA5A5` | 252,165,165 | btnXóa viền |
| **Success Green** | `#10B981` | 16,185,129 | btnDuyệt, Lưu |
| Ghost gray | `#F1F5F9` | 241,245,249 | btnLàm Mới, grid header |
| **Dark text** | `#0F172A` | 15,23,42 | Tiêu đề, chữ chính |
| Muted text | `#475569` | 71,85,105 | Chữ phụ |
| Label text | `#64748B` | 100,116,139 | Label |
| Selected row | `#E8F0FE` | 232,240,254 | Row được chọn |
| Alt row | `#F8FAFC` | 248,250,252 | Hàng xen kẽ |

---

## 5. STYLE BUTTON

### 5.1. Nút chính — THÊM (Primary / Blue)
```csharp
this.btnThem.Animated = true;
this.btnThem.BorderRadius = 8;
this.btnThem.FillColor = Color.FromArgb(24, 119, 242);
this.btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
this.btnThem.ForeColor = Color.White;
this.btnThem.Size = new Size(130, 40);
```

### 5.2. Nút SỬA (Warning / Amber)
```csharp
this.btnSua.Animated = true;
this.btnSua.BorderRadius = 8;
this.btnSua.FillColor = Color.FromArgb(245, 158, 11);
this.btnSua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
this.btnSua.ForeColor = Color.White;
this.btnSua.Size = new Size(130, 40);
```

### 5.3. Nút XÓA (Danger / Red outline)
```csharp
this.btnXoa.Animated = true;
this.btnXoa.BorderColor = Color.FromArgb(252, 165, 165);
this.btnXoa.BorderRadius = 8;
this.btnXoa.BorderThickness = 1;
this.btnXoa.FillColor = Color.FromArgb(254, 242, 242);
this.btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
this.btnXoa.ForeColor = Color.FromArgb(220, 38, 38);
this.btnXoa.HoverState.FillColor = Color.FromArgb(254, 226, 226);
```

### 5.4. Nút LÀM MỚI / HỦY (Ghost / Neutral)
```csharp
this.btnLamMoi.Animated = true;
this.btnLamMoi.BorderRadius = 8;
this.btnLamMoi.FillColor = Color.FromArgb(241, 245, 249);
this.btnLamMoi.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
this.btnLamMoi.ForeColor = Color.FromArgb(71, 85, 105);
this.btnLamMoi.HoverState.FillColor = Color.FromArgb(226, 232, 240);
```

### 5.5. Nút LƯU / DUYỆT (Success / Green)
```csharp
this.btnDuyet.Animated = true;
this.btnDuyet.BorderRadius = 8;
this.btnDuyet.FillColor = Color.FromArgb(16, 185, 129);
this.btnDuyet.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
this.btnDuyet.ForeColor = Color.White;
```

---

## 6. WORKFLOW XỬ LÝ FORM

### 6.1. Load form

```
Frm_Load()
  ├── Khởi tạo ComboBox (Items.AddRange)
  ├── Set trạng thái nút (btnLuu.Enabled = false)
  └── await LoadDataAsync()
        ├── Mở SQL connection
        ├── SELECT * FROM table ORDER BY ... DESC
        ├── dgv.DataSource = DataTable
        └── Format cột: HeaderText, Alignment, Format
```

### 6.2. Thêm mới

```
btnThem_Click()
  ├── isAddNew = true
  ├── Clear các input
  ├── btnLuu.Enabled = true
  └── Focus vào ô đầu tiên
```

### 6.3. Sửa

```
dgv_CellClick()
  ├── Đổ dữ liệu lên các input
  ├── btnLuu.Enabled = false
  └── Nếu Khoaso = Y (đã duyệt):
        ├── btnSua.Enabled = false
        ├── btnXoa.Enabled = false
        └── btnDuyet.Enabled = false

btnSua_Click()
  ├── isAddNew = false
  └── btnLuu.Enabled = true
```

### 6.4. Lưu (Thêm mới / Cập nhật)

```
btnLuu_Click()
  ├── Validate input (if empty -> warning)
  ├── Nếu isAddNew = true:
  │     ├── Lấy MAX(Maso) + 1
  │     └── INSERT INTO ...
  └── Nếu isAddNew = false:
        └── UPDATE ... WHERE Maso = @ma
  └── await LoadDataAsync()
  └── btnHuy_Click() (reset form)
```

### 6.5. Xóa

```
btnXoa_Click()
  ├── if empty txtMaso -> return
  ├── MessageBox xác nhận "Yes/No"
  └── Nếu Yes:
        └── DELETE FROM ... WHERE Maso = @ma
        └── await LoadDataAsync()
        └── btnHuy_Click()
```

### 6.6. Duyệt / Chốt sổ

```
btnDuyet_Click()
  ├── MessageBox xác nhận
  └── Nếu Yes:
        └── UPDATE table SET Khoaso = 'Y' WHERE Maso = @ma
        └── MessageBox "Đã Ký Duyệt"
        └── await LoadDataAsync()
        └── btnHuy_Click()
```

---

## 7. CÁC LỖI THƯỜNG GẶP (và cách tránh)

### ❌ Lỗi 1: Form thiết kế 1200px nhưng container chỉ 920px
**Nguyên nhân**: `pnlMain` trong `FrmTrangChinh` chỉ rộng `920px` (form 1200 - sidebar 280px).  
**Hậu quả**: Control bị tràn ra phải, mất nút, xô lệch.  
**Cách tránh**: Luôn thiết kế trong khung ~860px (920 - 2×20 padding). Kiểm tra `FrmTrangChinh.Designer.cs` trước.

### ❌ Lỗi 2: Xoá `.Text` của button khi replace code
**Nguyên nhân**: Khi thay thế block code, vô tình bỏ dòng `this.btnXXX.Text = "..."`.  
**Hậu quả**: Nút hiển thị không có chữ.  
**Cách tránh**: Sau mỗi lần replace, grep kiểm tra tất cả button có `.Text` không.

### ❌ Lỗi 3: pnlTop height quá thấp
**Nguyên nhân**: Không tính toán tổng chiều cao content (title + inputs + buttons).  
**Hậu quả**: Button nằm ngoài pnlTop.  
**Cách tránh**: Tính `pnlTop.Height = title(18+28) + row1(76+34) + row2(142+34) + buttons(195+38) + margin ~ 260`.

### ❌ Lỗi 4: Quên `btnLuu.Enabled = false`
**Nguyên nhân**: Khi replace block, thiếu dòng này.  
**Hậu quả**: Nút Lưu luôn active dù chưa chọn gì.  
**Cách tránh**: Kiểm tra `Enabled` của các button có trạng thái đặc biệt.

### ❌ Lỗi 5: Không gắn `Anchor = Right` cho nút bên phải
**Nguyên nhân**: `btnDuyet` đặt x=980 cố định.  
**Hậu quả**: Khi form co giãn, nút không bám phải.  
**Cách tránh**: `this.btnDuyet.Anchor = AnchorStyles.Top | AnchorStyles.Right;`

### ❌ Lỗi 6: Để `ClientSize` và `StartPosition` trong form con
**Nguyên nhân**: Khi `OpenChildForm` đã set `Dock=Fill`, `ClientSize` không có tác dụng.  
**Hậu quả**: Form vẫn giữ kích thước design-time, không fill đúng.  
**Cách tránh**: Bỏ `ClientSize`, `Dock`, `StartPosition` khỏi form con.

### ❌ Lỗi 7: Dùng font VNI-Times gây lỗi tiếng Việt
**Nguyên nhân**: VNI-Times không hỗ trợ đúng Unicode.  
**Hậu quả**: Chữ hiện "?" thay vì tiếng Việt.  
**Cách tránh**: Chỉ dùng `Segoe UI` cho mọi control.

### ❌ Lỗi 8: DataGridView thiếu ThemeStyle (Guna)
**Nguyên nhân**: Guna2DataGridView yêu cầu set ThemeStyle ngoài DefaultCellStyle.  
**Hậu quả**: Màu sắc grid không đúng, selection bị lỗi.  
**Cách tránh**: Luôn set cả `ThemeStyle` block sau `DefaultCellStyle`.

---

## 8. DATABASE PATTERNS

### 8.1. Connection string
```xml
<connectionStrings>
  <add name="TNConnection" 
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=DATNnhuanbut;Integrated Security=True" />
</connectionStrings>
```

### 8.2. Các bảng chính
- **Bao** — Số báo
- **TacGia** — Tác giả
- **ButDanh** — Bút danh
- **NhuanBut** — Nhuận bút
- **PhieuChi** — Phiếu chi
- **ThanhToan** — Thanh toán
- **Users** — Người dùng (Salt + SHA256 hash)

### 8.3. Query pattern
```csharp
using (SqlConnection conn = new SqlConnection(sqlConnectionString))
{
    await conn.OpenAsync();
    string query = "SELECT * FROM ...";
    using (SqlCommand cmd = new SqlCommand(query, conn))
    {
        DataTable dt = new DataTable();
        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
        {
            dt.Load(reader);
        }
        dgv.DataSource = dt;
    }
}
```

---

## 9. AI FEATURES (Ollama Qwen2.5)

- **Endpoint**: `http://localhost:11434/api/generate`
- **Model**: `qwen2.5:7b` (offline)
- **Dùng cho**: Kiểm định bài viết (FrmKiemDinhAI), trợ lý AI chat (FrmTroLyAI)
- **Gọi API**: HTTP POST với HTTPClient, stream response

---

## 10. CHECKLIST KHI TẠO FORM MỚI

1. **Thiết kế layout trong khung 860px** (920px container - 2×20 padding)
2. **Dùng pnlTop + pnlBottom** pattern (BorderRadius=16, shadow)
3. **KHÔNG set** `ClientSize`, `Dock`, `StartPosition`
4. **Set Anchor** đúng: pnlTop(Top|Left|Right), pnlBottom(Top|Bottom|Left|Right)
5. **Font**: Segoe UI (mọi control), không dùng VNI-Times
6. **Button style**: theo màu chuẩn (Blue/Amber/Red/Ghost/Green)
7. **DataGridView**: set đủ 3 cell style + ThemeStyle + ReadOnly
8. **Kiểm tra** mọi button có `.Text` và `.Click` event
9. **Kiểm tra** `Enabled` state của các nút đặc biệt
10. **Anchor = Right** cho nút nằm bên phải
11. **Build** — phải 0 warning, 0 error
12. **Test** — chạy thử với dữ liệu thật
