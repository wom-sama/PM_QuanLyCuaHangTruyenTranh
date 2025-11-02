using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PM.BUS.Helpers
{
    public static class AESHelper
    {
        // 🔑 Key gốc (chuỗi gốc)
        private const string RawKey = "3ss@@35sd68){}o??><~!@#$%^&*";

        // Cache key SHA256 (32 bytes)
        private static byte[] _aesKey = null;
        private static readonly object _lock = new object();

        // Sinh key 32 bytes từ chuỗi RawKey bằng SHA256
        public static byte[] GetAesKey()
        {
            if (_aesKey != null) return _aesKey;

            lock (_lock)
            {
                if (_aesKey != null) return _aesKey;

                using (SHA256 sha = SHA256.Create())
                {
                    _aesKey = sha.ComputeHash(Encoding.UTF8.GetBytes(RawKey));
                }

                return _aesKey;
            }
        }

        // Sinh IV từ email (16 bytes đầu của SHA256(email))
        private static byte[] GenerateIVFromEmail(string email)
        {
            using (SHA256 sha = SHA256.Create())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(email)).Take(16).ToArray();
            }
        }

        // 🔒 Mã hóa chuỗi (sinh IV ngẫu nhiên)
        public static string EncryptString(string plainText)
        {
            byte[] key = GetAesKey();

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

        //  Mã hóa chuỗi (IV từ email)
        public static string EncryptString(string plainText, string email)
        {
            byte[] key = GetAesKey();
            byte[] iv = GenerateIVFromEmail(email);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs, Encoding.UTF8))
                {
                    sw.Write(plainText);
                    sw.Flush();
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        // 🔓 Giải mã (với IV lưu trong ciphertext)
        public static string DecryptString(string cipherText)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] key = GetAesKey();

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

        // 🔓 Giải mã (với IV từ email)
        public static string DecryptString(string cipherText, string email)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] key = GetAesKey();
            byte[] iv = GenerateIVFromEmail(email);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (var ms = new MemoryStream(fullCipher))
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs, Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
