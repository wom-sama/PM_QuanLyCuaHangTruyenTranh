using BUS.DTOs;
using PM.BUS.Services.DonHangsv;
using PM.BUS.Services.VanChuyensv;
using PM.DAL;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PM.BUS.Services.Facade
{
    public class QuanLyDonHangBUS
    {
        private readonly DonHangService _donHangService;
        private readonly CT_DonHangService _ctDonHangService;
        private readonly VanChuyenService _vanChuyenService;

        public QuanLyDonHangBUS()
        {
            // BUS được phép khởi tạo UoW
            var uow = new UnitOfWork(new AppDbContext());
            _donHangService = new DonHangService(uow);
            _ctDonHangService = new CT_DonHangService(uow);
            _vanChuyenService = new VanChuyenService(uow);
        }

        // ==================== DANH SÁCH ĐƠN ====================

        public IEnumerable<object> LayDanhSachDonHang(string trangThai = null)
        {
            var ds = _donHangService.GetAll();

            if (!string.IsNullOrEmpty(trangThai))
                ds = ds.Where(d => d.TrangThai == trangThai);

            return ds.Select(d => new
            {
                d.MaDonHang,
                KháchHàng = d.Khach?.HoTen,
                NhânViên = d.NhanVien?.HoTen,
                NgàyĐặt = d.NgayDat,
                NgàyGiao = d.NgayGiao,
                d.TongTien,
                d.TrangThai
            }).ToList();
        }
        public IEnumerable<DonHangDTO> LayDanhSachDonHangDTO(string trangThai = null)
        {
            var ds = _donHangService.GetAll();

            if (!string.IsNullOrEmpty(trangThai))
                ds = ds.Where(d => d.TrangThai == trangThai);

            return ds.Select(d => new DonHangDTO
            {
                MaDonHang = d.MaDonHang,
                TenKhachHang = d.Khach?.HoTen,
                SDT = d.Khach?.SoDienThoai,
                TenNhanVien = d.NhanVien?.HoTen,
              
                NgayTao = d.NgayDat,
                NgayGiao = d.NgayGiao,
                TongTien = d.TongTien,
                TrangThai = d.TrangThai
            }).ToList();
        }


        // ==================== CHI TIẾT ĐƠN ====================

        public IEnumerable<object> LayChiTietDon(string maDonHang)
        {
            return _ctDonHangService.Find(ct => ct.MaDonHang == maDonHang)
                .Select(ct => new
                {
                    MãSách = ct.MaSach,
                    TênSách = ct.Sach?.TenSach,
                    ct.SoLuong,
                    ct.DonGia,
                    ct.ThanhTien
                }).ToList();
        }

        // ==================== DUYỆT ĐƠN ====================

        public bool DuyetDon(string maDonHang)
        {
            var don = _donHangService.GetById(maDonHang);
            if (don == null) return false;

            don.TrangThai = "Đang giao";
            don.NgayGiao = DateTime.Now;
            _donHangService.Update(don);

            var vanChuyen = new VanChuyen
            {
              //  MaVanChuyen = "VC" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                MaDonHang = don.MaDonHang,
              //  DonViVanChuyen = "Giao nội bộ",
                NgayGiao = DateTime.Now,
                TrangThai = "Đang giao"
            };

            _vanChuyenService.Add(vanChuyen);
            return true;
        }
        public List<object> LayChiTiet(string maDonHang)
        {
            var don = _donHangService.GetById(maDonHang);
            if (don == null) return new List<object>();

            return don.CT_DonHangs.Select(ct => new
            {
                TenSach = ct.Sach?.TenSach ?? "(Không rõ)",
                SoLuong = ct.SoLuong,
                DonGia = ct.DonGia,
                ThanhTien = ct.ThanhTien
            }).ToList<object>();
        }
        // ==================== BỔ SUNG PHƯƠNG THỨC CHO FORM DUYỆT ====================

        // Lấy danh sách đơn hàng theo trạng thái cụ thể
        public List<object> LayDanhSachDonHangTheoTrangThai(string trangThai)
        {
            return LayDanhSachDonHang(trangThai).ToList();
        }

        // Lấy đơn hàng theo mã đơn
        public DonHang LayDonHangTheoMa(string maDonHang)
        {
            return _donHangService.GetById(maDonHang);
        }
        // Hoàn tất giao đơn hàng
        public bool HoanTatGiao(string maDonHang)
        {
            var don = _donHangService.GetById(maDonHang);
            if (don == null) return false;

            don.TrangThai = "Đã giao";
            don.NgayGiao = DateTime.Now;
            _donHangService.Update(don);

            return true;
        }
        public bool TaoDonHang(KhachHang kh, string loaiDon, string hinhThucThanhToan, decimal tongTien, List<CT_GioHang> items)
        {
            try
            {
                // 1. Tạo đơn
                var don = new DonHang
                {
                    MaDonHang = "DH" + DateTime.Now.Ticks,
                    Khach = kh,
                    NgayDat = DateTime.Now,
                    TongTien = tongTien,
                    TrangThai = "Đang xử lý",
                    LoaiDon = loaiDon,
                    HinhThucThanhToan = hinhThucThanhToan
                };

                // 2. Thêm đơn vào DbSet (chưa save)
                _donHangService.Add(don);

                // 3. Thêm chi tiết đơn
                foreach (var item in items)
                {
                    var ct = new CT_DonHang
                    {
                        MaDonHang = don.MaDonHang,
                        MaSach = item.Sach.MaSach,
                        SoLuong = item.SoLuong,
                        DonGia = item.Sach.GiaBan,
                        ThanhTien = item.SoLuong * item.Sach.GiaBan
                    };
                    _ctDonHangService.Add(ct);
                }

                // 4. Lưu tất cả vào database
                _donHangService.UnitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tạo đơn hàng: " + ex);
                return false; // trả về false nếu có lỗi
            }
        }


    }
}
