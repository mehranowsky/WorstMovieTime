using System.Security.Cryptography;
using System.Text;

namespace ServiceLayer.Utilities
{
    public class Hasher
    {
        public static string hash(string s)
        {
            using var sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(
                Encoding.UTF8.GetBytes(s));

            return Convert.ToHexString(bytes);
        }
    }
}
