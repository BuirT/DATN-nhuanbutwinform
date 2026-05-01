using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HETHONGTINHNHUANBUT.Models
{
    [BsonIgnoreExtraElements]
    public class NhuanBut
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Maso { get; set; }
        public string Tenbai { get; set; }
        public string Trang { get; set; }
        public string Muc { get; set; }
        public decimal TienNhuanbut { get; set; }
        public string Butdanh { get; set; }

        // ĐÃ CẬP NHẬT: Dùng object để khớp với bảng Bao.Maso[cite: 1]
        public object MsBao { get; set; }

        public string Vung { get; set; }
        public string VungChuyenDen { get; set; }
        public string NgoaiGio { get; set; }
        public string STT { get; set; }
        public string addby { get; set; }
        public DateTime? ngaychuyen { get; set; }
        public string TenSoBao { get; set; }
        public bool DaThanhToan { get; set; } = false;
        public string MaPhieuChi { get; set; }

        [BsonIgnore] public string TenBai { get => Tenbai; set => Tenbai = value; }
        [BsonIgnore] public string ButDanh { get => Butdanh; set => Butdanh = value; }
        [BsonIgnore] public decimal TienNhuanBut { get => TienNhuanbut; set => TienNhuanbut = value; }
        [BsonIgnore] public string NguoiNhap { get => addby; set => addby = value; }
        [BsonIgnore] public DateTime NgayNhap { get => ngaychuyen ?? DateTime.Now; set => ngaychuyen = value; }
        [BsonIgnore] public string IdBao { get => MsBao?.ToString(); set => MsBao = value; }
    }
}