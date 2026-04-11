using MongoDB.Driver;
using System.Configuration;

namespace HETHONGTINHNHUANBUT.DAL
{
    public class MongoHelper
    {
        private static IMongoDatabase _db;
        public static IMongoDatabase GetDatabase()
        {
            if (_db == null)
            {
                var connString = ConfigurationManager.ConnectionStrings["MongoDbConn"].ConnectionString;
                var dbName = ConfigurationManager.AppSettings["DatabaseName"];
                var client = new MongoClient(connString);
                _db = client.GetDatabase(dbName);
            }
            return _db;
        }
    }
}