using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    [BsonIgnoreExtraElements]
    public class TacGia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Maso { get; set; } // Mã hệ thống
        public string MsTG { get; set; } // Mã TG/Thẻ
        public string Hoten { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string LoaiTacgia { get; set; }
        public string Email { get; set; }
        public string Dienthoai { get; set; }
        public string Ddong { get; set; } // Bút danh
        public string Diachi { get; set; }
    }
}