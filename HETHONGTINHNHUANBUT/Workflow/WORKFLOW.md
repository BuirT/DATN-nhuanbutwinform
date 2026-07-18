# Workflow Hệ Thống Tính Chi Trả Nhuận Bút

## 1. Luồng Duyệt Nhuận Bút (FrmKiemDuyetNhuanBut)

```
[1] Nhập bài
    │
    ▼
[2] Thư ký chấm tiền (TrangThaiDuyet = 1)
    │  - Nhập số tiền nhuận bút
    │  - Xác nhận → chuyển sang Kế toán
    │
    ▼
[3] Kế toán nhập liệu (TrangThaiDuyet = 2)
    │  - Xác nhận đã nhập liệu
    │  - Có thể báo sai sót → gửi trả về Thư ký (kèm lý do)
    │
    ▼
[4] Kiểm tra viên kiểm tra (TrangThaiDuyet = 3)
    │  - Xác nhận đúng → chuyển Tổng thư ký
    │  - Trả về Kế toán nếu sai
    │
    ▼
[5] Tổng thư ký ký duyệt (TrangThaiDuyet = 4)
    │  - Nhập tên người ký
    │  - Ký duyệt → hoàn tất
    │  - Trả về Kiểm tra viên nếu cần xem lại
    │
    ▼
[6] Hoàn tất (không thể duyệt tiếp)
```

### Admin / Quản trị viên
- **Quyền đặc biệt**: duyệt nhanh qua tất cả các bước
- Mỗi lần nhấn "DUYỆT (TIẾP THEO)" → tăng TrangThaiDuyet lên 1
- **Từ chối**: đưa bài về trạng thái chờ chấm tiền (TrangThaiDuyet = 0), reset toàn bộ thông tin duyệt

### Lãnh đạo
- **Chỉ xem**: không có nút duyệt/từ chối
- Xem được tất cả bài không phân biệt trạng thái
---
## 2. Quy Trình Nhập Bài

### Phóng viên tự nhập (FrmNhapBaiPhongVien)
```
Chọn số báo → Nhập tên bài, trang, mục, bút danh, vùng
→ Dán nội dung bài viết
→ AI Kiểm toán (kiểm tra metadata, trùng bài)
→ AI Phân tích (chấm điểm chất lượng, đánh giá)
→ Nộp bài
```

### Nhân viên nhập hộ (FrmNhapNhuanBut)
```
Nhập thông tin bài (tên, trang, mục, bút danh, tác giả, vùng)
→ Chọn số báo
→ Nhập số tiền nhuận bút
→ AI Kiểm toán (kiểm tra định mức, phát hiện bất thường)
→ Lưu
```

---

## 3. Quy Trình Thanh Toán

### Lập phiếu chi (FrmPhieuChi)
```
Tạo phiếu chi → chọn tác giả → nhập số tiền → ghi chú
→ Lưu phiếu
```

### Duyệt phiếu chi (FrmDuyetPhieuChi)
```
Xem danh sách phiếu chi chờ duyệt
→ Xác nhận (cập nhật DaThanhToan = 1)
→ Từ chối (xóa phiếu)
```

### Thanh toán (FrmThanhToan)
```
Xem danh sách bài đã duyệt
→ Chọn bài cần thanh toán
→ Lập phiếu chi
→ Đánh dấu đã thanh toán
```

---

## 4. Luồng AI

```
[Ollama] ←→ [AIHelper] ←→ [Forms]
                 │
    ┌────────────┼────────────┐
    ▼            ▼            ▼
[AI Kiểm toán] [AI Phân tích] [Trợ lý AI Chat]
    │            │            │
    ▼            ▼            ▼
Kiểm tra     Chấm điểm     Trả lời câu hỏi
metadata     chất lượng    từ database
trùng bài    đạo văn       + tư vấn thuế
```

### AnomalyDetector (phát hiện bất thường)
- Kiểm tra trước khi duyệt: tên bài trùng, số lượng bài trong 7 ngày, tổng chi trong tháng theo mục
- Cảnh báo mức độ: Bình thường → Để ý → Cảnh báo → Nghiêm trọng
- Nếu nghiêm trọng: hiện popup xác nhận trước khi duyệt

---

## 5. Phân Quyền

| Vai trò | TrangThaiDuyet | Nhiệm vụ chính |
|---------|---------------|----------------|
| Thư ký | 0 | Chấm tiền nhuận bút |
| Kế toán | 1 | Xác nhận nhập liệu / báo sai sót |
| Kiểm tra viên | 2 | Kiểm tra tính chính xác |
| Tổng thư ký | 3 | Ký duyệt nhuận bút |
| Lãnh đạo | -1 (all) | Xem tất cả bài (read-only) |
| Admin/Quản trị viên | -1 (all) | Duyệt nhanh, reset bài |

---

## 6. Cấu Trúc Trạng Thái (TrangThaiDuyet)

| Giá trị | Ý nghĩa |
|---------|---------|
| 0 | Chờ thư ký chấm tiền |
| 1 | Đã chấm tiền — chờ kế toán nhập liệu |
| 2 | Đã nhập liệu — chờ kiểm tra viên |
| 3 | Đã kiểm tra — chờ tổng thư ký ký duyệt |
| 4 | Đã ký duyệt — hoàn tất |
| NULL | Bài mới (chưa qua duyệt) |
