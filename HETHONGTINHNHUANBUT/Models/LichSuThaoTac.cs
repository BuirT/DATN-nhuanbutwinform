using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    public class LichSuThaoTac
    {
        // Thuộc tính bắt buộc của MongoDB để làm Khóa chính
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string NguoiDung { get; set; }
        public string HanhDong { get; set; }
        public DateTime ThoiGian { get; set; } = DateTime.Now;
    }
}