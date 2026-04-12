using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HETHONGTINHNHUANBUT.Models
{
    [BsonIgnoreExtraElements]
    public class TaiKhoan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; } // (Thực tế nên mã hóa, nhưng làm đồ án thì để text cho dễ test)
        public string HoTen { get; set; }
        public string Quyen { get; set; } // Ví dụ: "Quản trị viên", "Kế toán", "Biên tập viên"
        public bool HoatDong { get; set; } = true; // Cờ khóa tài khoản
    }
}