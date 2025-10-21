using PM.DAL;
using System;

namespace PM_QuanLyCuaHangTruyenTranh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BẮT ĐẦU SEED DỮ LIỆU ===");
            try
            {
                //AppDbSeeder.Seed();
                Console.WriteLine("=== SEED HOÀN TẤT ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi seed dữ liệu: " + ex.Message);
            }

            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
