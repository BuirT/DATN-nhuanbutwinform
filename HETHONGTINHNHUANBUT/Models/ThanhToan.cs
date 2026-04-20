using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    [BsonIgnoreExtraElements] // Bùa hộ mệnh chống crash khi DB có cột lạ
    public class ThanhToan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // GIỮ NGUYÊN TÊN BIẾN ĐỂ FORM CỦA CẬU KHÔNG BỊ LỖI
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