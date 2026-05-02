using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace HETHONGTINHNHUANBUT.Models
{
    [BsonIgnoreExtraElements]
    public class PhieuChi
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // --- 1. THÔNG TIN PHIẾU ---
        public string SoPhieu { get; set; } // Tương ứng SQL: Sophieu (Ví dụ: PC-001)
        public DateTime NgayLap { get; set; } = DateTime.Now; // Tương ứng SQL: Ngaylap
        public string LyDo { get; set; } // Tương ứng SQL: Lydo (Ví dụ: Chi trả nhuận bút)

        // --- 2. THÔNG TIN NGƯỜI NHẬN & TÁC GIẢ ---
        public string TenTacGia { get; set; } // Tương ứng SQL: Tacgia
        public string NguoiNhan { get; set; } // Tương ứng SQL: Nguoinhan (Người trực tiếp nhận tiền)

        // --- 3. THÔNG TIN CÁ NHÂN & THUẾ (Từ SQL của thầy) ---
        public string MST { get; set; } // Tương ứng SQL: MST
        public string CMND { get; set; } // Tương ứng SQL: CMND
        public string DienThoai { get; set; } // Tương ứng SQL: Dienthoai

        // --- 4. THÔNG TIN TÀI CHÍNH ---
        public decimal TongTien { get; set; } // Tương ứng SQL: Sotien
        public decimal ThueSuat { get; set; } // Tương ứng SQL: Thuesuat (Ví dụ: 0, 10, 20)
        public decimal Thue { get; set; } // Tương ứng SQL: Thue (Tiền thuế khấu trừ)
        public decimal ThucLinh { get; set; } // Tương ứng SQL: Conlai (Tiền thực tế nhận)

        // --- 5. HÌNH THỨC & TRẠNG THÁI ---
        public string HinhThuc { get; set; } // Tương ứng SQL: loaiTT (Tiền mặt 'TM' hoặc Chuyển khoản 'CK')
        public string DaThuTien { get; set; } = "N"; // Tương ứng SQL: Dathutien ('Y' hoặc 'N')

        // --- 6. NGƯỜI PHỤ TRÁCH ---
        public string NguoiLap { get; set; } // Tương ứng SQL: Nguoilap
        public string ThuQuy { get; set; } // Tương ứng SQL: Thuquy
        public string AddBy { get; set; } // Tương ứng SQL: addby (Tài khoản hệ thống tạo phiếu)

        // --- 7. DANH SÁCH CHI TIẾT (Điểm ăn tiền của MongoDB) ---
        // Mảng chứa ID các bài viết (Nhuận bút) được thanh toán trong phiếu này.
        // Dùng cái này thì không cần phải tạo bảng PhieuChiCT (Chi tiết) như SQL nữa!
        public List<string> DanhSachBaiViet { get; set; } = new List<string>();

        // ==========================================
        // --- 8. PHỤC VỤ LÃNH ĐẠO DUYỆT CHI ---
        // ==========================================

        // TrangThaiDuyet: 0 = Chờ duyệt (Mặc định khi Kế toán lập), 1 = Đã duyệt, -1 = Từ chối
        public int TrangThaiDuyet { get; set; } = 0;

        public string NguoiDuyet { get; set; } // Tên Lãnh đạo duyệt
        public DateTime? NgayDuyet { get; set; } // Ngày giờ sếp ký duyệt
        public string LyDoTuChoi { get; set; } // Ghi chú nếu Lãnh đạo không đồng ý chi
    }
}