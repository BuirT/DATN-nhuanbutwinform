using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HETHONGTINHNHUANBUT
{
    public static class HashHelper
    {
        // Tạo Salt ngẫu nhiên (16 bytes)
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Băm mật khẩu kết hợp với Salt
        public static string ComputeSha256(string password, string salt)
        {
            if (password == null) password = string.Empty;
            if (salt == null) salt = string.Empty;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Kết hợp mật khẩu và muối trước khi băm
                string combinedData = password + salt;
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(combinedData));

                StringBuilder builder = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool IsSha256Hash(string value)
        {
            return !string.IsNullOrWhiteSpace(value)
                   && value.Length == 64
                   && value.All(Uri.IsHexDigit);
        }
    }
}