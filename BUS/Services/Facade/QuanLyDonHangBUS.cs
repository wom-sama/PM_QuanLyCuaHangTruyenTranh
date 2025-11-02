using BUS.DTOs;
using PM.BUS.Services.DonHangsv;
using PM.BUS.Services.VanChuyensv;
using PM.DAL;
using PM.DAL.Interfaces;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PM.BUS.Services; // thêm namespace chứa ThongBaoService
namespace PM.BUS.Services.Facade
{
    public class QuanLyDonHangBUS
    {
        private readonly DonHangService _donHangService;
        private readonly CT_DonHangService _ctDonHangService;
        private readonly VanChuyenService _vanChuyenService;
        private readonly UnitOfWork _unitOfWork;
        private readonly ThongBaoService _thongBaoService;
        public event Action OnDonHangDuyet; // 🔔 Sự kiện báo khi duyệt đơn
        public event Action OnDonHangHoanTat; // 🔔 Sự kiện báo khi hoàn tất giao

        public QuanLyDonHangBUS()
        {
            // BUS được phép khởi tạo UoW
            _unitOfWork = new UnitOfWork(new AppDbContext());
            _donHangService = new DonHangService(_unitOfWork);
            _ctDonHangService = new CT_DonHangService(_unitOfWork);
            _vanChuyenService = new VanChuyenService(_unitOfWork);
            _thongBaoService = new ThongBaoService(_unitOfWork);
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
            _unitOfWork.Save(); //  lưu thay đổi vào DB                          
            _thongBaoService.Add(new ThongBao // ✅ Gửi thông báo cho khách hàng
            {
                MaThongBao = "TB" + DateTime.Now.Ticks,
                TieuDe = "Đơn hàng được duyệt",
                NoiDung = $"Đơn hàng {don.MaDonHang} của bạn đã được duyệt và đang giao.",
                NguoiNhan = don.MaKhach,
                NgayGui = DateTime.Now
            });
            OnDonHangDuyet?.Invoke(); // 🔔 Gọi event để form cập nhật chuông
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
        // ==================== HOÀN TẤT GIAO ĐƠN ====================
        public bool HoanTatGiao(string maDonHang)
        {
            var don = _donHangService.GetById(maDonHang);
            if (don == null) return false;

            don.TrangThai = "Đã giao";
            don.NgayGiao = DateTime.Now;
            _donHangService.Update(don);

            // ✅ Cập nhật lượt bán cho từng sách trong đơn
            foreach (var ct in don.CT_DonHangs)
            {
                var sach = ct.Sach;
                if (sach != null)
                {
                    sach.LuotBan += ct.SoLuong;
                    _unitOfWork.SachRepository.Update(sach);
                }
            }

            _unitOfWork.Save(); // 💾 Lưu tất cả thay đổi (Đơn + Sách)
            OnDonHangHoanTat?.Invoke(); // 🔔 Gửi sự kiện để form cập nhật giao diện

            return true;
        }

        public bool TaoDonHang(KhachHang kh, string loaiDon, string maDVVC, string hinhThucThanhToan, decimal tongTien, List<CT_GioHang> items)
        {
            try
            {
                var don = new DonHang
                {
                    MaDonHang = "DH" + DateTime.Now.Ticks.ToString(),
                    MaKhach = kh.TenDangNhap,
                    NgayDat = DateTime.Now,
                    LoaiDon = loaiDon,
                    TrangThai = "Chờ xử lý",
                    TongTien = tongTien,
                    HinhThucThanhToan = hinhThucThanhToan,
                    NgayGiao = null
                };
                _donHangService.Add(don);

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

                var vc = new VanChuyen
                {
                    MaDonHang = don.MaDonHang,
                    MaDVVC = maDVVC,
                    NgayTao = DateTime.Now,
                    TrangThai = "Chờ xử lý",
                    GhiChu = ""
                };
                _vanChuyenService.Add(vc);

                // Save tất cả (DonHang + CT + VanChuyen)
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tạo đơn hàng: " + ex);
                return false;
            }
        }
        public void XoaGioHangSauKhiDat(string maKhach)
        {
            // Dùng lại UnitOfWork hiện có
            var gioHangService = new GioHangService(_unitOfWork);
            var ctGioHangService = new CT_GioHangService(_unitOfWork);

            var gioHang = gioHangService.GetAll()
                .FirstOrDefault(g => g.MaKhach == maKhach);

            if (gioHang != null)
            {
                ctGioHangService.DeleteByGioHangId(gioHang.MaGioHang);
                _unitOfWork.Save(); // ✅ Save qua UnitOfWork của BUS
            }
        }
        public int DemDonHangChoXuLy()
        {
            return _donHangService.GetAll()
                .Count(d => d.TrangThai == "Chờ xử lý");
        }
        // Khong Duyệt Đơn
        public bool KhongDuyetDon(string maDonHang)
        {
            var don = LayDonHangTheoMa(maDonHang);
            if (don == null) return false;
            if (don.TrangThai != "Chờ xử lý") return false;

            don.TrangThai = "Không duyệt";
            var result = _donHangService.Update(don);

            if (result)
            {
                _thongBaoService.Add(new ThongBao
                {
                    MaThongBao = "TB" + DateTime.Now.Ticks,
                    TieuDe = "Đơn hàng không được duyệt",
                    NoiDung = $"Đơn hàng {don.MaDonHang} đã bị từ chối duyệt.",
                    NguoiNhan = don.MaKhach,
                    NgayGui = DateTime.Now
                });
            }

            return result;
        }

        // Hủy Giao Đơn
        public bool HuyGiaoDon(string maDonHang)
        {
            var don = LayDonHangTheoMa(maDonHang);
            if (don == null) return false;

            if (don.TrangThai != "Đang giao") return false;

            don.TrangThai = "Đơn Hàng Không Giao"; // trạng thái mới
            return _donHangService.Update(don); 
        }



    }
}
