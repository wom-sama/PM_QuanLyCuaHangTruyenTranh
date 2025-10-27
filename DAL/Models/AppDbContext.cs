using System.Data.Entity;
using PM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PM.DAL.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=QuanLyCuaHangTruyenTranh") { }

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
        public DbSet<KiemKe> KiemKes { get; set; }
        public DbSet<ChuyenKho> ChuyenKhos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==============================
            // 1️⃣ TaiKhoan - KhachHang
            // Một tài khoản có thể có hoặc không có khách hàng
            // Một khách hàng phải có tài khoản (dựa trên TenDangNhap)
            modelBuilder.Entity<KhachHang>()
                .HasRequired(k => k.TaiKhoan)
                .WithOptional(t => t.KhachHang)
                .WillCascadeOnDelete(false); // tránh lỗi multiple cascade paths

            // ==============================
            // 2️⃣ TaiKhoan - NhanVien
            // Một tài khoản có thể gắn với nhân viên, hoặc không
            // Một nhân viên có thể có hoặc không có tài khoản
            modelBuilder.Entity<TaiKhoan>()
                .HasOptional(t => t.NhanVien)
                .WithMany() // không cần navigation ở NhanVien
                .HasForeignKey(t => t.MaNhanVien)
                .WillCascadeOnDelete(false);
        }
    }
}
