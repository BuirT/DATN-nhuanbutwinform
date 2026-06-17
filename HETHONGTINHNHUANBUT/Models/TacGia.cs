using System;

namespace HETHONGTINHNHUANBUT.Models
{
    public class TacGia
    {
        public string Id { get; set; }

        public string Maso { get; set; }
        public string MsTG { get; set; }
        public string Hoten { get; set; }
        public DateTime Ngaysinh { get; set; } // Chuyển về DateTime chuẩn, Form bắt buộc phải chọn ngày
        public string LoaiTacgia { get; set; }
        public string Email { get; set; }
        public string Hoten_Unicode { get; set; }
        public string NganHang { get; set; }
        public string PhongBan { get; set; }
        public string SoTaiKhoan { get; set; }
        public string DienThoai { get; set; }
        public string AvatarPath { get; set; }
        public string PdfPath { get; set; }
    }
}