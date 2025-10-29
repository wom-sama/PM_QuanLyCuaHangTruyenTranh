using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PM.BUS.Helpers
{
    public static class AESHelper
    {

        // Đường dẫn tới file chứa DPAPI-protected key (Base64). Thay đường dẫn nếu cần.
        private static readonly string ProtectedKeyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Users\ADMIN\source\repos\PM_QuanLyCuaHangTruyenTranh\packages\key.txt");

        // Cache key đã unprotect để dùng lại
        private static byte[] _aesKey = null;
        private static object _lock = new object();

        // Lấy AES key (unprotect + derive SHA256 để đảm bảo 32 bytes)
        public static byte[] GetAesKey()
        {
            if (_aesKey != null) return _aesKey;

            lock (_lock)
            {
                if (_aesKey != null) return _aesKey;

                if (!File.Exists(ProtectedKeyFile))
                    throw new FileNotFoundException("Protected AES key file not found: " + ProtectedKeyFile);

                string base64 = File.ReadAllText(ProtectedKeyFile).Trim();
                if (string.IsNullOrEmpty(base64))
                    throw new Exception("Protected key file is empty.");

                byte[] protectedBytes = Convert.FromBase64String(base64);

                // Unprotect bằng DPAPI (chỉ user hiện tại có thể unprotect)
                byte[] unprotected = ProtectedData.Unprotect(protectedBytes, null, DataProtectionScope.CurrentUser);

                // Derive 32-byte key bằng SHA256 (an toàn, tránh vấn đề độ dài khác nhau)
                using (SHA256 sha = SHA256.Create())
                {
                    _aesKey = sha.ComputeHash(unprotected); // 32 bytes
                }

                // Zero out unprotected if muốn an toàn (best-effort)
                Array.Clear(unprotected, 0, unprotected.Length);

                return _aesKey;
            }
        }

        private static byte[] GenerateIVFromEmail(string email)
        {
            using (SHA256 sha = SHA256.Create())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(email)).Take(16).ToArray();
            }
        }


        public static void ink()
        {
            Console.WriteLine("==="+ProtectedKeyFile);
        }




        // Mã hóa chuỗi thong tin bằng AES 
        public static string EncryptString(string plainText)
        {

            byte[] key = GetAesKey(); // 32 bytes key 
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

        //overload để mã hóa với IV từ email
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

        // Giải mã chuoỗi thong tin đã mã hóa
        public static string DecryptString(string cipherText)
        {

            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] key = GetAesKey();  // 32 bytes key 
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
        //overload để giải mã với IV từ email
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
    

