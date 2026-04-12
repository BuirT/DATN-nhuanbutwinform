using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HETHONGTINHNHUANBUT.Models
{
    // Bỏ qua các field thừa trong DB (nếu có) để không bị crash khi truy vấn
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("fullname")]
        public string FullName { get; set; }

        // Viết đúng chính tả tiếng Anh trong code, nhưng map đúng tên cột cũ trong DB
        [BsonElement("privelege")]
        public string Privilege { get; set; }

        [BsonElement("GroupID")]
        public string GroupID { get; set; }
    }
}