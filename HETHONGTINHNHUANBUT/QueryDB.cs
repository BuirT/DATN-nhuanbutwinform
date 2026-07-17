using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connStr = "Server=26.232.227.232\\SQLEXPRESS,1433;Database=DATNnhuanbut;User Id=DATNnhuanbut;Password=totnghiep;";
        try
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Maso, Tenbai, TienNhuanbut FROM Nhuanbut WHERE Butdanh = N'Nguyễn An' AND Maso NOT IN (SELECT MsNhuanbut FROM NhuanbutCT) AND TrangThaiDuyet = 4", conn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Maso | Tenbai | TienNhuanbut");
                        Console.WriteLine("--------------------------");
                        while (r.Read())
                        {
                            Console.WriteLine(string.Format("{0} | {1} | {2}", r["Maso"], r["Tenbai"], r["TienNhuanbut"]));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
