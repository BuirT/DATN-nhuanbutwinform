using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT.Models
{
    public class AICanhBao
    {
        public int Id { get; set; }
        public DateTime NgayCanhBao { get; set; }
        public string LoaiCanhBao { get; set; }
        public int MucDo { get; set; }
        public int? MaBaiViet { get; set; }
        public int? MaPhongVien { get; set; }
        public string NoiDung { get; set; }
        public bool DaXuLy { get; set; }
    }
}
