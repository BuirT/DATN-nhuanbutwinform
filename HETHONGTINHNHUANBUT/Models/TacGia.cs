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

        public string Maso { get; set; }
        public string MsTG { get; set; }
        public string Hoten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string LoaiTacgia { get; set; }
        public string Email { get; set; }
        public string Hoten_Unicode { get; set; }
        public string NganHang { get; set; }
        public string PhongBan { get; set; }
        public string SoTaiKhoan { get; set; }
        public string DienThoai { get; set; }
        public string AvatarPath { get; set; }
        public string PdfPath { get; set; }

        [BsonIgnore] public string MaHT { get => Maso; set => Maso = value; }
        [BsonIgnore] public string MaThe { get => MsTG; set => MsTG = value; }
        [BsonIgnore] public string HoTen { get => Hoten; set => Hoten = value; }
        [BsonIgnore] public DateTime NgaySinh { get => Ngaysinh ?? DateTime.Now; set => Ngaysinh = value; }
        [BsonIgnore] public string PhanLoai { get => LoaiTacgia; set => LoaiTacgia = value; }
        [BsonIgnore] public string ButDanh { get; set; }
    }
}