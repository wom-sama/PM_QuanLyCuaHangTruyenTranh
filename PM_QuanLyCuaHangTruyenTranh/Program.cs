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

            // in ra AES key để kiểm tra
          
           

        }
    }
}

