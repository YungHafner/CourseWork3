using System;
using System.Security.Cryptography;
using System.Text;

namespace Course_WPF.Tools
{
    public static class HashedPassword
    {
        public static string HashPassword(string password)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                SHA256 sha256 = SHA256.Create();
                //MD5 md5 = MD5.Create();
                byte[] b = Encoding.ASCII.GetBytes(password);
                byte[] hash = sha256.ComputeHash(b);
                foreach (byte b2 in hash)
                    sb.Append(b2.ToString("X2"));
            }
            catch (Exception ex)
            {
                return null;
            }
            
            return Convert.ToString(sb);
            
        }
    }
}
