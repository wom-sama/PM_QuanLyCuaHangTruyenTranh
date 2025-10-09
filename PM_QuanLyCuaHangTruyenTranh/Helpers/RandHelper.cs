using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Helpers
{
    public static class RandHelper
    {
        public static string GenerateOTP(int length = 5)
        {
            Random random = new Random();
            string otp = "";
            for (int i = 0; i < length; i++)
            {
                otp += random.Next(0, 10).ToString();
            }
            return otp;
        }

        public static string TaoMa(string s)
        {
            // Mã có định dạng: SyyyyMMddHHmmssfff
            return s + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }




    }
}
