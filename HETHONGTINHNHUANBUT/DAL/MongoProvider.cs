using MongoDB.Driver;
using System.Configuration;
using HETHONGTINHNHUANBUT.Models;
using System;

namespace HETHONGTINHNHUANBUT.DAL
{
    public class MongoProvider
    {
        private readonly IMongoDatabase _database;
        private static MongoProvider instance;

        public static MongoProvider Instance
        {
            get { if (instance == null) instance = new MongoProvider(); return instance; }
        }

        private MongoProvider()
        {
            // Lấy chuỗi kết nối từ App.config (MongoDbConn)
            string connectionSTR = ConfigurationManager.ConnectionStrings["MongoDbConn"]?.ConnectionString;
            var client = new MongoClient(connectionSTR);
            _database = client.GetDatabase("NhuanButDB_Cloud");
        }

        // Hàm vạn năng lấy bảng
        public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name);

        // Hàm ghi nhật ký tích hợp
        public void GhiNhatKy(string user, string action)
        {
            try
            {
                var coll = GetCollection<LichSuThaoTac>("LichSuThaoTac");
                coll.InsertOne(new LichSuThaoTac { NguoiDung = user, HanhDong = action, ThoiGian = DateTime.Now });
            }
            catch { }
        }
    }
}