using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HETHONGTINHNHUANBUT
{
    public static class HashHelper
    {
        public static string ComputeSha256(string rawData)
        {
            if (rawData == null)
                rawData = string.Empty;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
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
