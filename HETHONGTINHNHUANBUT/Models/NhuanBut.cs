using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    public class NhuanBut
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Maso { get; set; }
        public string Tenbai { get; set; }
        public string Trang { get; set; }
        public string Muc { get; set; }
        public decimal? TienNhuanbut { get; set; }
        public string Butdanh { get; set; }
        public int? MsBao { get; set; }
        public string Vung { get; set; }
        public string VungChuyenDen { get; set; }
        public string NgoaiGio { get; set; }
        public int? STT { get; set; }
        public string addby { get; set; }
        public DateTime? ngaychuyen { get; set; }
    }
}