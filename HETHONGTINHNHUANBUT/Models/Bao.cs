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

        [BsonElement("Maso")]
        public int Maso { get; set; } // Mã số báo (kiểu int theo SQL cũ)

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
        public string DaDuyet { get; set; } = "N"; // 'N' là chưa duyệt, 'Y' là đã duyệt
    }
}