using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    public class TacGia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Maso { get; set; }
        public string MsTG { get; set; }
        public string Hoten { get; set; }
        public string Ngaysinh { get; set; } // Trong SQL đang để chuỗi rỗng mặc định
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }
        public string Ddong { get; set; }
        public string LoaiTacgia { get; set; }
        public string Email { get; set; }
    }
}