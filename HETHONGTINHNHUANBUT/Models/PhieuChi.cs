using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    public class PhieuChi
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Sophieu { get; set; }
        public DateTime? Ngaylap { get; set; }
        public decimal? Sotien { get; set; }
        public decimal? Thue { get; set; }
        public decimal? Conlai { get; set; }
        public string Lydo { get; set; }
        public string Nguoinhan { get; set; }
        public string Tacgia { get; set; }
        public string Nguoilap { get; set; }
        public string Thuquy { get; set; }
        public string Dathutien { get; set; } // Y hoặc N
        public string loaiTT { get; set; }
        public string addby { get; set; }
        public string MST { get; set; }
        public string CMND { get; set; }
        public string Dienthoai { get; set; }
        public float? Thuesuat { get; set; }
    }
}