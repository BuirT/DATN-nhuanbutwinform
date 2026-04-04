using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HETHONGTINHNHUANBUT.DAL
{
    public class DataProvider
    {
        private readonly string connectionSTR;

        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider()
        {
            connectionSTR = ConfigurationManager.ConnectionStrings["HETHONGTINHNHUANBUT.Properties.Settings.TNConnectionString"]?.ConnectionString
                            ?? @"Data Source=LAPTOP-5O9OTMIJ\SQLEXPRESS;Initial Catalog=TN;Integrated Security=True;TrustServerCertificate=True";

        }

        private void FillParameters(SqlCommand command, string query, object[] parameter)
        {
            if (parameter == null || parameter.Length == 0)
                return;

            string[] listPara = query.Split(new[] { ' ', '\n', '\r', '\t', ',', '(', ')', '=' }, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            foreach (string item in listPara)
            {
                if (!item.StartsWith("@") || command.Parameters.Contains(item))
                    continue;

                object value = i < parameter.Length ? parameter[i] ?? DBNull.Value : DBNull.Value;
                command.Parameters.AddWithValue(item, value);
                i++;
            }
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    FillParameters(command, query, parameter);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(data);
                    }
                }
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    FillParameters(command, query, parameter);
                    data = command.ExecuteNonQuery();
                }
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    FillParameters(command, query, parameter);
                    data = command.ExecuteScalar();
                }
            }
            return data;
        }

        public void GhiNhatKy(string tenTaiKhoan, string chiTietHanhDong)
        {
            try
            {
                string sql = "INSERT INTO LichSuThaoTac (NguoiDung, HanhDong) VALUES (@nguoidung, @hanhdong)";
                ExecuteNonQuery(sql, new object[] { tenTaiKhoan, chiTietHanhDong });
            }
            catch
            {
            }
        }
    }
}
