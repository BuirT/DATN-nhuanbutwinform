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

        // Bắt buộc: Bài viết này thuộc Tờ báo/Số báo nào?
        public string IdBao { get; set; }
        public string TenSoBao { get; set; }

        public string TenBai { get; set; }
        public string Trang { get; set; }
        public string Muc { get; set; } // Thể loại: Bài, Tin, Ảnh...

        public string ButDanh { get; set; } // Ai viết?

        public decimal TienNhuanBut { get; set; }

        public string NguoiNhap { get; set; } // Lưu lại tài khoản người nhập liệu
        public DateTime NgayNhap { get; set; } = DateTime.Now;
        // Cờ đánh dấu đã làm phiếu chi hay chưa
        public bool DaThanhToan { get; set; } = false;
        // Lưu lại mã phiếu chi để sau này biết bài này được trả ở phiếu nào
        public string MaPhieuChi { get; set; }
    }
}