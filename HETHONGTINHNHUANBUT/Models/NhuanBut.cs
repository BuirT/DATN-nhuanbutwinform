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

        // ========================================================
        // NHÓM 1: CÁC TRƯỜNG BÁM SÁT 100% THEO SQL CỦA THẦY
        // ========================================================
        public string Maso { get; set; }
        public string Tenbai { get; set; }
        public string Trang { get; set; }
        public string Muc { get; set; }
        public decimal TienNhuanbut { get; set; }
        public string Butdanh { get; set; }
        public string MsBao { get; set; }
        public string Vung { get; set; }
        public string VungChuyenDen { get; set; }
        public string NgoaiGio { get; set; }
        public string STT { get; set; }
        public string addby { get; set; }
        public DateTime? ngaychuyen { get; set; }

        // ========================================================
        // NHÓM 2: CÁC TRƯỜNG BỔ TRỢ CHO LOGIC PHẦN MỀM WINFORMS
        // ========================================================
        public string TenSoBao { get; set; }
        public bool DaThanhToan { get; set; } = false;
        public string MaPhieuChi { get; set; }

        // ========================================================
        // NHÓM 3: "CẦU NỐI" CỨU HỘ CHO CÁC FORM CŨ ĐỠ BỊ LỖI
        // (BsonIgnore giúp MongoDB không tạo thêm cột thừa trong DB)
        // ========================================================

        [BsonIgnore]
        public string TenBai
        {
            get => Tenbai;
            set => Tenbai = value;
        }

        [BsonIgnore]
        public string ButDanh
        {
            get => Butdanh;
            set => Butdanh = value;
        }

        [BsonIgnore]
        public decimal TienNhuanBut
        {
            get => TienNhuanbut;
            set => TienNhuanbut = value;
        }

        [BsonIgnore]
        public string NguoiNhap
        {
            get => addby;
            set => addby = value;
        }

        [BsonIgnore]
        public DateTime NgayNhap
        {
            get => ngaychuyen ?? DateTime.Now;
            set => ngaychuyen = value;
        }

        [BsonIgnore]
        public string IdBao
        {
            get => MsBao;
            set => MsBao = value;
        }
    }
}