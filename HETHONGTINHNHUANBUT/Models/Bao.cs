using System;

namespace HETHONGTINHNHUANBUT.Models
{
    public class Bao
    {
        public string Id { get; set; }

        public object Maso { get; set; }

        public string Tenbao { get; set; }

        public DateTime Ngayra { get; set; }

        public string Sobao { get; set; }

        public string Sobo { get; set; }

        public string Loaibao { get; set; }

        public string DaDuyet { get; set; } = "N";
    }
}