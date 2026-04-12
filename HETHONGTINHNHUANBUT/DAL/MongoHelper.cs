using MongoDB.Driver;
using System;
using System.Configuration;

namespace HETHONGTINHNHUANBUT.DAL
{
    public class MongoHelper
    {
        private static IMongoDatabase _database;

        public static IMongoDatabase GetDatabase()
        {
            if (_database == null)
            {
                // Đồng chí có thể để connection string trong App.config để bảo mật
                string connectionString = "mongodb://localhost:27017";
                string dbName = "NhuanButDB_Cloud";

                var client = new MongoClient(connectionString);
                _database = client.GetDatabase(dbName);
            }
            return _database;
        }

        // Hàm generic để lấy bất kỳ Collection nào
        public static IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return GetDatabase().GetCollection<T>(collectionName);
        }
    }
}