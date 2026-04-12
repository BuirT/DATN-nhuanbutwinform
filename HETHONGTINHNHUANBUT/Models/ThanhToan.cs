using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    [BsonIgnoreExtraElements]
    public class ThanhToan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Maso { get; set; }
        public string Tengoi { get; set; }
        public DateTime Ngay { get; set; }
        public DateTime Tungay { get; set; }
        public DateTime Denngay { get; set; }
        public string Loaibao { get; set; }
        public decimal Sotien { get; set; }
        public string Vung { get; set; }
        public string LoaiTT { get; set; }
        public string Khoaso { get; set; } = "N"; // N là chưa khóa, Y là đã duyệt/khóa
        public string hinhthucTT { get; set; }
    }
}