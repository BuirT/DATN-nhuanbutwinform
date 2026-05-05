using HETHONGTINHNHUANBUT.Models;

namespace HETHONGTINHNHUANBUT
{
    // Class tĩnh để lưu thông tin thằng nào đang dùng phần mềm
    public static class Session
    {
        public static string TenDangNhap { get; set; }
        public static string HoTen { get; set; }
        public static string Quyen { get; set; } // "Lãnh đạo", "Thư ký", "Kế toán", "Admin"...

        public static void Login(User user)
        {
            TenDangNhap = user.TenDangNhap;
            HoTen = user.HoTen;
            Quyen = user.Quyen;
        }

        public static void Logout()
        {
            TenDangNhap = null;
            HoTen = null;
            Quyen = null;
        }
    }
}