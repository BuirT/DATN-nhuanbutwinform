using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connStr = "Server=26.232.227.232\\SQLEXPRESS,1433;Database=DATNnhuanbut;User Id=DATNnhuanbut;Password=totnghiep;";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TenDangNhap, Quyen FROM Users", conn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine(r[0].ToString() + " | " + r[1].ToString());
            }
        }
    }
}
