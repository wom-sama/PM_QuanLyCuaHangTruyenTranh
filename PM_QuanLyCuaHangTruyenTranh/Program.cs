using PM_QuanLyCuaHangTruyenTranh.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

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
             Application.Run(new LoginForm());
            
           /* string senderEmail = AESHelper.DecryptString(ConfigurationManager.AppSettings["EncryptedSenderEmail"]);
            string senderPassword = AESHelper.DecryptString(ConfigurationManager.AppSettings["EncryptedSenderPass"]);
            Console.WriteLine("Decrypted Email: " + senderEmail);
            Console.WriteLine("Decrypted Password: " + senderPassword);
            */
          /*  string email = "nnnaaahhh199@gmail.com";
            string password = "kmmq vpig muph shnz";

            string encEmail = AESHelper.EncryptString(email);
            string encPass = AESHelper.EncryptString(password);

            Console.WriteLine("Encrypted Email: " + encEmail);
            Console.WriteLine("Encrypted Pass: " + encPass);*/
        }
    }
}

