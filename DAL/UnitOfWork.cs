using PM.DAL.Interfaces;
using PM.DAL.Models;
using PM.DAL.Repositories;
using System;
using System.Threading.Tasks;
namespace PM.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<TaiKhoan> TaiKhoanRepository { get; private set; }
        public IGenericRepository<NhanVien> NhanVienRepository { get; private set; }
        public IGenericRepository<KhachHang> KhachHangRepository { get; private set; }
        public IGenericRepository<Sach> SachRepository { get; private set; }
        public IGenericRepository<TheLoai> TheLoaiRepository { get; private set; }
        public IGenericRepository<TacGia> TacGiaRepository { get; private set; }
        public IGenericRepository<NhaXuatBan> NhaXuatBanRepository { get; private set; }
        public IGenericRepository<ChiNhanh> ChiNhanhRepository { get; private set; }
        public IGenericRepository<Kho> KhoRepository { get; private set; }
        public IGenericRepository<KeSach> KeSachRepository { get; private set; }
        public IGenericRepository<NhapKho> NhapKhoRepository { get; private set; }
        public IGenericRepository<CT_NhapKho> CT_NhapKhoRepository { get; private set; }
        public IGenericRepository<DonHang> DonHangRepository { get; private set; }
        public IGenericRepository<CT_DonHang> CT_DonHangRepository { get; private set; }
        public IGenericRepository<GioHang> GioHangRepository { get; private set; }
        public IGenericRepository<CT_GioHang> CT_GioHangRepository { get; private set; }
        public IGenericRepository<VanChuyen> VanChuyenRepository { get; private set; }
        public IGenericRepository<HoaDon> HoaDonRepository { get; private set; }
        public IGenericRepository<KhuyenMai> KhuyenMaiRepository { get; private set; }
        public IGenericRepository<ThongBao> ThongBaoRepository { get; private set; }
        public IGenericRepository<ChucVu> ChucVuRepository { get; private set; }
      
        public IGenericRepository<KiemKe> KiemKeRepository { get; private set; }
        public IGenericRepository<ChuyenKho> ChuyenKhoRepository { get; private set; }
        public IGenericRepository<PhanCong> PhanCongRepository { get; private set; }
        public IGenericRepository<CongViec> CongViecRepository { get; private set; }
        public IGenericRepository<BangLuong> BangLuongRepository { get; private set; }

        public UnitOfWork() : this(new AppDbContext())
        {
        }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            TaiKhoanRepository = new GenericRepository<TaiKhoan>(_context);
            NhanVienRepository = new GenericRepository<NhanVien>(_context);
            KhachHangRepository = new GenericRepository<KhachHang>(_context);
            SachRepository = new GenericRepository<Sach>(_context);
            TheLoaiRepository = new GenericRepository<TheLoai>(_context);
            TacGiaRepository = new GenericRepository<TacGia>(_context);
            NhaXuatBanRepository = new GenericRepository<NhaXuatBan>(_context);
            ChiNhanhRepository = new GenericRepository<ChiNhanh>(_context);
            KhoRepository = new GenericRepository<Kho>(_context);
            KeSachRepository = new GenericRepository<KeSach>(_context);
            NhapKhoRepository = new GenericRepository<NhapKho>(_context);
            CT_NhapKhoRepository = new GenericRepository<CT_NhapKho>(_context);
            DonHangRepository = new GenericRepository<DonHang>(_context);
            CT_DonHangRepository = new GenericRepository<CT_DonHang>(_context);
            GioHangRepository = new GenericRepository<GioHang>(_context);
            CT_GioHangRepository = new GenericRepository<CT_GioHang>(_context);
            VanChuyenRepository = new GenericRepository<VanChuyen>(_context);
            HoaDonRepository = new GenericRepository<HoaDon>(_context);
            KhuyenMaiRepository = new GenericRepository<KhuyenMai>(_context);
            ThongBaoRepository = new GenericRepository<ThongBao>(_context);
            ChucVuRepository = new GenericRepository<ChucVu>(_context);

            KiemKeRepository = new GenericRepository<KiemKe>(_context);
            ChuyenKhoRepository = new GenericRepository<ChuyenKho>(_context);

            BangLuongRepository = new GenericRepository<BangLuong>(_context);
            PhanCongRepository = new GenericRepository<PhanCong>(_context);
            CongViecRepository = new GenericRepository<CongViec>(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
