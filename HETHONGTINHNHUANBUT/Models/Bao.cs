using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    [BsonIgnoreExtraElements]
    public class Bao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // DÙNG KIỂU object: Để chấp nhận cả dữ liệu cũ (Int32) và mới (String)
        [BsonElement("Maso")]
        public object Maso { get; set; }

        [BsonElement("Tenbao")]
        public string Tenbao { get; set; }

        [BsonElement("Ngayra")]
        public DateTime Ngayra { get; set; }

        [BsonElement("Sobao")]
        public string Sobao { get; set; }

        [BsonElement("Sobo")]
        public string Sobo { get; set; }

        [BsonElement("Loaibao")]
        public string Loaibao { get; set; }

        [BsonElement("DaDuyet")]
        public string DaDuyet { get; set; } = "N";
    }
}