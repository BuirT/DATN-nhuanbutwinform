using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    [BsonIgnoreExtraElements] // Thuộc tính này rất tốt, giúp tránh lỗi nếu DB có cột lạ
    public class TacGia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // BsonElement giúp code C# xài tên mới (MaHT) 
        // nhưng vẫn móc đúng vào cột cũ (Maso) trong MongoDB
        [BsonElement("Maso")]
        public string MaHT { get; set; }

        [BsonElement("MsTG")]
        public string MaThe { get; set; }

        [BsonElement("Hoten")]
        public string HoTen { get; set; }

        [BsonElement("Ngaysinh")]
        public DateTime NgaySinh { get; set; }

        [BsonElement("LoaiTacgia")]
        public string PhanLoai { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Dienthoai")]
        public string DienThoai { get; set; }

        [BsonElement("Ddong")]
        public string ButDanh { get; set; }

        [BsonElement("Diachi")]
        public string DiaChi { get; set; }

        // --- HAI TRƯỜNG MỚI ĐỂ LƯU ẢNH VÀ PDF ---
        // Vì là trường mới nên không cần BsonElement, DB sẽ tự động tạo
        public string AvatarPath { get; set; }
        public string PdfPath { get; set; }
    }
}