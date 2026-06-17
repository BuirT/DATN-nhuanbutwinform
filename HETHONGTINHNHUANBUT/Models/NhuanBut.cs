using System;

namespace HETHONGTINHNHUANBUT.Models
{
    public class NhuanBut
    {
        public string Id { get; set; }

        public string Maso { get; set; }
        public string Tenbai { get; set; }
        public string Trang { get; set; }
        public string Muc { get; set; }
        public decimal TienNhuanbut { get; set; }
        public string Butdanh { get; set; }

        public object MsBao { get; set; }

        public string Vung { get; set; }
        public string VungChuyenDen { get; set; }
        public string NgoaiGio { get; set; }
        public string STT { get; set; }
        public string addby { get; set; }
        public DateTime? ngaychuyen { get; set; }
        public string TenSoBao { get; set; }
        public bool DaThanhToan { get; set; } = false;
        public string MaPhieuChi { get; set; }

        public string TenBai { get => Tenbai; set => Tenbai = value; }
        public string ButDanh { get => Butdanh; set => Butdanh = value; }
        public decimal TienNhuanBut { get => TienNhuanbut; set => TienNhuanbut = value; }
        public string NguoiNhap { get => addby; set => addby = value; }
        public DateTime NgayNhap { get => ngaychuyen ?? DateTime.Now; set => ngaychuyen = value; }
        public string IdBao { get => MsBao?.ToString(); set => MsBao = value; }
    }
}