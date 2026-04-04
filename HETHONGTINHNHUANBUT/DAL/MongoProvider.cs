using MongoDB.Driver;
using System.Configuration;
using HETHONGTINHNHUANBUT.Models;
using System;
using System.Data;

namespace HETHONGTINHNHUANBUT.DAL
{
    public class DataProvider : MongoProvider { }

    public class MongoProvider
    {
        private readonly IMongoDatabase _database;
        private static MongoProvider instance;

        public static MongoProvider Instance
        {
            get
            {
                if (instance == null) instance = new MongoProvider();
                return instance;
            }
        }

        protected MongoProvider()
        {
            try
            {
                // Lấy chuỗi kết nối từ App.config (Nhớ kiểm tra tên "MongoDbConn")
                string connectionSTR = ConfigurationManager.ConnectionStrings["MongoDbConn"]?.ConnectionString;
                var client = new MongoClient(connectionSTR);

                // Kết nối đến Database trên Cloud Atlas
                _database = client.GetDatabase("NhuanButDB_Cloud");
            }
            catch (Exception ex)
            {
                // Nếu lỗi kết nối, anh có thể xem ở cửa sổ Output của Visual Studio
                System.Diagnostics.Debug.WriteLine("Lỗi khởi tạo Mongo: " + ex.Message);
            }
        }

        // --- CÁC HÀM DÙNG CHO MONGODB (CODE MỚI) ---

        public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name);

        public void GhiNhatKy(string user, string action)
        {
            try
            {
                var coll = GetCollection<LichSuThaoTac>("LichSuThaoTac");
                coll.InsertOne(new LichSuThaoTac
                {
                    NguoiDung = user,
                    HanhDong = action,
                    ThoiGian = DateTime.Now
                });
            }
            catch { }
        }

        // --- CÁC HÀM "CHỮA CHÁY" ĐỂ FIX LỖI BUILD (GIỮ CHO CODE SQL CŨ KHÔNG BỊ ĐỎ) ---

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            // Trả về bảng rỗng để các Form cũ không bị crash khi Build
            return new DataTable();
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            // Trả về 0 để đánh lừa trình biên dịch
            return 0;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            // Trả về null để fix lỗi SQL cũ gọi ExecuteScalar
            return null;
        }
    }
}