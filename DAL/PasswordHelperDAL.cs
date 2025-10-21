using System;
using System.Security.Cryptography;
using System.Text;

namespace PM.DAL.Helpers
{
    public static class PasswordHelperDAL
    {
        // Dùng để hash mật khẩu đơn giản, tránh phụ thuộc BUS
        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
