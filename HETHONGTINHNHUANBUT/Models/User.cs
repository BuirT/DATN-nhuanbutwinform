using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HETHONGTINHNHUANBUT.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; } // Tên đăng nhập
        public string Password { get; set; } // Mật khẩu (đã hash hoặc chưa)
        public string GroupID { get; set; }
        public string privelege { get; set; } // Quyền hạn
        public string fullname { get; set; }
    }
}