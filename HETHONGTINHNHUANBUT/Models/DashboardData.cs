using System;
using System.Collections.Generic;

namespace HETHONGTINHNHUANBUT
{
    public class DashboardData
    {
        public int TongBaiViet { get; set; }
        public int TongPhongVien { get; set; }
        public decimal TongNhuanBut { get; set; }
        public int TongBaiChuaDuyet { get; set; }
        public int TongPhieuChi { get; set; }
        public int TongCanhBao { get; set; }
        public int TongTacGia { get; set; }
        public int TongLoaiBai { get; set; }
        public string KhoangThoiGian { get; set; }

        public Dictionary<string, double> ThongKeTheoThang { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, double> TopPhongVien { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, int> TiLeChuyenMuc { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, double> DiemAITrungBinh { get; set; } = new Dictionary<string, double>();
    }
}
