namespace HETHONGTINHNHUANBUT.Models
{
    public class User
    {
        public string Id { get; set; }

        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; } // (Thực tế nên mã hóa, nhưng làm đồ án thì để text cho dễ test)
        public string Salt { get; set; } // Thêm trường này
        public string HoTen { get; set; }
        public string Quyen { get; set; } // Ví dụ: "Quản trị viên", "Kế toán", "Biên tập viên"
        public bool HoatDong { get; set; } = true; // Cờ khóa tài khoản
                                                   // ĐÂY LÀ SỢI DÂY XÍCH BUỘC TÀI KHOẢN VÀO TÁC GIẢ TRONG CSDL
        public string MaTacGiaGoc { get; set; }
    }
}