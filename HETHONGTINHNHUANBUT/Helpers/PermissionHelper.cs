using System;

namespace HETHONGTINHNHUANBUT.Helpers
{
    public static class PermissionHelper
    {
        public static bool CanUseAIDashboard(string quyenHienTai)
        {
            if (string.IsNullOrEmpty(quyenHienTai)) return false;

            string quyen = quyenHienTai.Trim();
            
            // Sử dụng StartsWith để tránh lỗi encoding file chữ có dấu khi compile
            return quyen.Equals("Admin", StringComparison.OrdinalIgnoreCase) || 
                   quyen.StartsWith("Qu", StringComparison.OrdinalIgnoreCase) || // Quản trị viên
                   quyen.StartsWith("L", StringComparison.OrdinalIgnoreCase);    // Lãnh đạo
        }
    }
}
