using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace HETHONGTINHNHUANBUT.Models
{
    [BsonIgnoreExtraElements]
    public class PhieuChi
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string SoPhieu { get; set; } // Ví dụ: PC-001
        public DateTime NgayLap { get; set; } = DateTime.Now;

        public string TenTacGia { get; set; } // Người nhận tiền
        public string HinhThuc { get; set; } // Tiền mặt (TM) hoặc Chuyển khoản (CK)

        public decimal TongTien { get; set; }
        public decimal Thue { get; set; } // Tiền thuế khấu trừ (nếu có)
        public decimal ThucLinh { get; set; } // Tiền thực tế nhận

        public string NguoiLap { get; set; } // Tài khoản kế toán lập phiếu

        // Mảng chứa ID các bài viết (Nhuận bút) được thanh toán trong phiếu này
        public List<string> DanhSachBaiViet { get; set; } = new List<string>();
    }
}