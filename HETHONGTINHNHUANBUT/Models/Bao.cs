using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    public class Bao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // ID tự sinh của MongoDB

        [BsonElement("Mabao")]
        public string Mabao { get; set; } // Mã báo (ví dụ: B001)

        [BsonElement("Tenbao")]
        public string Tenbao { get; set; } // Tên tờ báo

        [BsonElement("Loaibao")]
        public string Loaibao { get; set; } // Báo in, Báo điện tử...

        [BsonElement("Dongia")]
        public decimal Dongia { get; set; } // Đơn giá nhuận bút mặc định

        [BsonElement("Ghichu")]
        public string Ghichu { get; set; }

        [BsonElement("NgayTao")]
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}