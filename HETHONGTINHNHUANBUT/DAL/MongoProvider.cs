using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Configuration; // Đừng quên thư viện này

namespace HETHONGTINHNHUANBUT.DAL
{
    public class MongoProvider
    {
        private static MongoProvider _instance;
        public static MongoProvider Instance => _instance ?? (_instance = new MongoProvider());

        private IMongoDatabase _database;

        private MongoProvider()
        {
            try
            {
                // Đọc đúng tên thẻ trong App.config của đồng chí
                string connectionString = ConfigurationManager.ConnectionStrings["MongoDbConn"]?.ConnectionString;
                string dbName = ConfigurationManager.AppSettings["DatabaseName"];

                if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(dbName))
                {
                    throw new Exception("Chưa tìm thấy 'MongoDbConn' hoặc 'DatabaseName' trong App.config!");
                }

                var client = new MongoClient(connectionString);
                _database = client.GetDatabase(dbName);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối MongoDB Atlas: " + ex.Message);
            }
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        public void GhiNhatKy(string username, string action)
        {
            try
            {
                var collection = _database.GetCollection<BsonDocument>("LichSuThaoTac");
                var document = new BsonDocument
                {
                    { "TaiKhoan", username },
                    { "HanhDong", action },
                    { "ThoiGian", DateTime.Now }
                };
                collection.InsertOne(document);
            }
            catch { /* Bỏ qua nếu lỗi log */ }
        }
    }
}