using System;

namespace HETHONGTINHNHUANBUT.Services.AI.ToolCalling
{
    public class QueryParameters
    {
        public string Intent { get; set; } // BaiViet, TacGia, PhieuChi, ThongKe, CanhBao, DinhMuc, General
        public string TacGia { get; set; }
        public int? Thang { get; set; }
        public int? Nam { get; set; }
        public string TrangThai { get; set; }
        public string TuKhoa { get; set; }
    }
}
