using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

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

            /* Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new LoginForm());
            */
            string rawKey = "3ss@@35sd68){}o??><~!@#$%^&*";
            byte[] protectedKey = ProtectedData.Protect(
                Encoding.UTF8.GetBytes(rawKey),
                null,
                DataProtectionScope.CurrentUser);

            Console.WriteLine(Convert.ToBase64String(protectedKey));
        }
    }
   }

