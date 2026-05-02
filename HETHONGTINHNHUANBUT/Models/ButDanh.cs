using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HETHONGTINHNHUANBUT.Models
{
    [BsonIgnoreExtraElements]
    public class ButDanh
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Maso { get; set; }
        public string Butdanh { get; set; }
        public string MsTacgia { get; set; }
    }
}