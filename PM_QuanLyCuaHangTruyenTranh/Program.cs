using PM.DAL.Models;
using PM.BUS.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PM.GUI
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
            Application.Run(new Main.Client());

         //   byte[] originalKey = AESHelper.GetOriginalKey();
         //   Console.WriteLine(Encoding.UTF8.GetString(originalKey));




            //AppDbSeeder.Seed();  ///dòng này dùng để thêm dữ liệu mẫu vào database

            //AppDbSeeder.Seed();
            /* string senderEmail = AESHelper.DecryptString(ConfigurationManager.AppSettings["EncryptedSenderEmail"]);
             string senderPassword = AESHelper.DecryptString(ConfigurationManager.AppSettings["EncryptedSenderPass"]);
             Console.WriteLine("Decrypted Email: " + senderEmail);
             Console.WriteLine("Decrypted Password: " + senderPassword);*/



        }
    }
}