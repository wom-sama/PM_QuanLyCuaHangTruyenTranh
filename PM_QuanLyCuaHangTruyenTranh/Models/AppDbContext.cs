using PM_QuanLyCuaHangTruyenTranh.userConTrol.Client;
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

        // public DbSet<Admin> Admins { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<Sach> Sachs { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public DbSet<ChiNhanh> ChiNhanhs { get; set; }
        public DbSet<Kho> Khos { get; set; }
        public DbSet<KeSach> KeSachs { get; set; }
        public DbSet<NhapKho> NhapKhos { get; set; }
        public DbSet<CT_NhapKho> CT_NhapKhos { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<CT_DonHang> CT_DonHangs { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<CT_GioHang> CT_GioHangs { get; set; }
        public DbSet<VanChuyen> VanChuyens { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<ThongBao> ThongBaos { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<BanQuyen> BanQuyens { get;set; }
        public DbSet<KiemKe> KiemKes { get; set; }
        public DbSet<ChuyenKho> ChuyenKhos { get; set; }
    }
}
