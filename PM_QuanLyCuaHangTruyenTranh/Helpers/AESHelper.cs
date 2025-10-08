using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Helpers
{
    public static class AESHelper
    {

        // Đường dẫn tới file chứa DPAPI-protected key (Base64). Thay đường dẫn nếu cần.
        private static readonly string ProtectedKeyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "D:\\LAP\\PM_QuanLyCuaHangTruyenTranh\\packages\\key.txt");

        // Cache key đã unprotect để dùng lại
        private static byte[] _aesKey = null;
        private static object _lock = new object();

        // Lấy AES key (unprotect + derive SHA256 để đảm bảo 32 bytes)









        // Mã hóa chuỗi thong tin bằng AES 
        public static string EncryptString(string plainText)
        {

            byte[] key = Encoding.UTF8.GetBytes("3ss@@35sd68){}o??><~!@#$%^&*"); // 16 bytes key 
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();
                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }

        }
        // Giải mã chuoỗi thong tin đã mã hóa
        public static string DecryptString(string cipherText)
        {

            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] key = Encoding.UTF8.GetBytes("3ss@@35sd68){}o??><~!@#$%^&*");
            using (Aes aes = Aes.Create())
            {
                byte[] iv = new byte[16];
                Array.Copy(fullCipher, iv, iv.Length);
                aes.Key = key;
                aes.IV = iv;
                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream(fullCipher, 16, fullCipher.Length - 16))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }

        }
    }
}
