using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyCuaHangTruyenTranh.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=QuanLyCuaHangTruyenTranh")
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Khach> Khaches { get; set; }
        public DbSet<Sach> Sachs { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
    }
}
