using PM.DAL.Models;
using System;
using System.Threading.Tasks;

namespace PM.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TaiKhoan> TaiKhoanRepository { get; }
        IGenericRepository<NhanVien> NhanVienRepository { get; }
        IGenericRepository<KhachHang> KhachHangRepository { get; }
        IGenericRepository<Sach> SachRepository { get; }
        IGenericRepository<TheLoai> TheLoaiRepository { get; }
        IGenericRepository<TacGia> TacGiaRepository { get; }
        IGenericRepository<NhaXuatBan> NhaXuatBanRepository { get; }
        IGenericRepository<ChiNhanh> ChiNhanhRepository { get; }
        IGenericRepository<Kho> KhoRepository { get; }
        IGenericRepository<KeSach> KeSachRepository { get; }
        IGenericRepository<NhapKho> NhapKhoRepository { get; }
        IGenericRepository<CT_NhapKho> CT_NhapKhoRepository { get; }
        IGenericRepository<DonHang> DonHangRepository { get; }
        IGenericRepository<CT_DonHang> CT_DonHangRepository { get; }
        IGenericRepository<GioHang> GioHangRepository { get; }
        IGenericRepository<CT_GioHang> CT_GioHangRepository { get; }
        IGenericRepository<VanChuyen> VanChuyenRepository { get; }
        IGenericRepository<HoaDon> HoaDonRepository { get; }
        IGenericRepository<KhuyenMai> KhuyenMaiRepository { get; }
        IGenericRepository<ThongBao> ThongBaoRepository { get; }
        IGenericRepository<ChucVu> ChucVuRepository { get; }
        IGenericRepository<KiemKe> KiemKeRepository { get; }
        IGenericRepository<ChuyenKho> ChuyenKhoRepository { get; }
        IGenericRepository<PhanCong> PhanCongRepository { get; }
        IGenericRepository<CongViec> CongViecRepository { get; }
        IGenericRepository<BangLuong> BangLuongRepository { get; }


        int Save();              // Đồng bộ
        Task<int> SaveAsync();   // Bất đồng bộ
    }
}
