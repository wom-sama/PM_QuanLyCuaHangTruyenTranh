using PM_QuanLyCuaHangTruyenTranh.Helpers;
using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new LoginForm());
             Application.Run(new AdminForm(null));
            
            /* string senderEmail = AESHelper.DecryptString(ConfigurationManager.AppSettings["EncryptedSenderEmail"]);
             string senderPassword = AESHelper.DecryptString(ConfigurationManager.AppSettings["EncryptedSenderPass"]);
             Console.WriteLine("Decrypted Email: " + senderEmail);
             Console.WriteLine("Decrypted Password: " + senderPassword);
             */

            // in ra AES key để kiểm tra
          /*  using (var db = new AppDbContext())
            {
                // Kiểm tra nếu chưa có admin nào
                if (!db.Admins.Any())
                {
                    var admin = new Admin
                    {
                        MaAdmin = "AD001",
                        TenDangNhap = "admin",
                        MatKhau = PasswordHelper.HashPassword("123456"), // mật khẩu được mã hóa
                        Email = "admin@example.com"
                    };

                    db.Admins.Add(admin);
                    db.SaveChanges();

                    Console.WriteLine("✅ Đã thêm tài khoản admin mặc định (admin / 123456)");
                }
                else
                {
                    Console.WriteLine("⚙️ Đã có tài khoản admin trong hệ thống, bỏ qua.");
                }
            }

            Console.WriteLine("Nhấn Enter để thoát...");
            Console.ReadLine();*/
        }



    }
}

