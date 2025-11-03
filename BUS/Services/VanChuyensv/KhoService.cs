using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.VanChuyensv
{
    public class KhoService
    {
        private readonly IUnitOfWork _unitOfWork;


    public KhoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public KhoService() { 
        _unitOfWork=new UnitOfWork();
        }
        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<Kho> GetAll()
        {
            try
            {
                return _unitOfWork.KhoRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách kho: " + ex.Message);
                return new List<Kho>();
            }
        }

        public Kho GetById(string maKho)
        {
            try
            {
                return _unitOfWork.KhoRepository.GetById(maKho);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy kho theo mã: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(Kho kho)
        {
            try
            {
                if (kho == null)
                    return false;

                _unitOfWork.KhoRepository.Add(kho);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm kho: " + ex.Message);
                return false;
            }
        }

        public bool Update(Kho kho)
        {
            try
            {
                if (kho == null)
                    return false;

                _unitOfWork.KhoRepository.Update(kho);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật kho: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maKho)
        {
            try
            {
                var k = _unitOfWork.KhoRepository.GetById(maKho);
                if (k == null)
                    return false;

                _unitOfWork.KhoRepository.Delete(k);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa kho: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<Kho>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.KhoRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách kho (async): " + ex.Message);
                return new List<Kho>();
            }
        }

        public async Task<Kho> GetByIdAsync(string maKho)
        {
            try
            {
                return await _unitOfWork.KhoRepository.GetByIdAsync(maKho);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy kho theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(Kho kho)
        {
            try
            {
                if (kho == null)
                    return false;

                _unitOfWork.KhoRepository.Add(kho);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm kho (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Kho kho)
        {
            try
            {
                if (kho == null)
                    return false;

                _unitOfWork.KhoRepository.Update(kho);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật kho (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maKho)
        {
            try
            {
                var k = await _unitOfWork.KhoRepository.GetByIdAsync(maKho);
                if (k == null)
                    return false;

                _unitOfWork.KhoRepository.Delete(k);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa kho (async): " + ex.Message);
                return false;
            }
        }
        public IEnumerable<NhapKho> GetByKho(string maKho)
        {
            try
            {
                return _unitOfWork.NhapKhoRepository.GetAll()
                    .Where(nk => nk.MaKho == maKho)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy phiếu nhập kho: " + ex.Message);
                return new List<NhapKho>();
            }
        }
        public class NhapKhoService
        {
            private readonly IUnitOfWork _unitOfWork;

            public NhapKhoService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public IEnumerable<NhapKho> GetByKho(string maKho)
            {
                return _unitOfWork.NhapKhoRepository.GetAll()
                    .Where(nk => nk.MaKho == maKho)
                    .ToList();
            }
        }



        public int LaySoLuongTon(string maSach, string maChiNhanh)
        {
            try
            {
                // Lấy tất cả kho thuộc chi nhánh
                var danhSachKho = _unitOfWork.KhoRepository
                    .GetAll()
                    .Where(k => k.MaChiNhanh == maChiNhanh)
                    .Select(k => k.MaKho)
                    .ToList();

                int tongNhap = (from nk in _unitOfWork.NhapKhoRepository.GetAll()
                                join ctn in _unitOfWork.CT_NhapKhoRepository.GetAll()
                                    on nk.MaPhieuNhap equals ctn.MaPhieuNhap
                                where danhSachKho.Contains(nk.MaKho)
                                      && ctn.MaSach == maSach
                                select (int?)ctn.SoLuong).Sum() ?? 0;

                // Lấy danh sách nhân viên của chi nhánh
                var danhSachNhanVien = _unitOfWork.NhanVienRepository
                    .GetAll()
                    .Where(nv => nv.MaChiNhanh == maChiNhanh)
                    .Select(nv => nv.MaNV)
                    .ToList();

                int tongBan = (from dh in _unitOfWork.DonHangRepository.GetAll()
                               join ctdh in _unitOfWork.CT_DonHangRepository.GetAll()
                                   on dh.MaDonHang equals ctdh.MaDonHang
                               where danhSachNhanVien.Contains(dh.MaNV)
                                     && ctdh.MaSach == maSach
                               select (int?)ctdh.SoLuong).Sum() ?? 0;

                return tongNhap - tongBan;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tính tồn kho chi nhánh: " + ex.Message);
                return 0;
            }
        }




        public void CapNhatTonSauKhiNhap(string maPhieuNhap, string maSach, int soLuong, decimal Gia)
        {
            try
            {
                var chiTiet = new CT_NhapKho
                {
                    MaPhieuNhap = maPhieuNhap,
                    MaSach = maSach,
                    SoLuong = soLuong,
                    DonGia = Gia,
                };

                _unitOfWork.CT_NhapKhoRepository.Add(chiTiet);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi nhập kho: " + ex.Message);
            }
        }
        ////chi nhanh theo kho
        public IEnumerable<Kho> GetByChiNhanh(string maChiNhanh)
        {
            try
            {
                return _unitOfWork.KhoRepository.GetAll()
                    .Where(k => k.MaChiNhanh == maChiNhanh)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách kho theo chi nhánh: " + ex.Message);
                return new List<Kho>();
            }
        }
        //lấy số lượng bán theo sách trong chi nhánh
        public int LaySoLuongBanTheoSach(string maSach, string maChiNhanh)
        {
            var danhSachNV = _unitOfWork.NhanVienRepository.GetAll()
                .Where(nv => nv.MaChiNhanh == maChiNhanh)
                .Select(nv => nv.MaNV)
                .ToList();

            return (from dh in _unitOfWork.DonHangRepository.GetAll()
                    join ctdh in _unitOfWork.CT_DonHangRepository.GetAll()
                        on dh.MaDonHang equals ctdh.MaDonHang
                    where danhSachNV.Contains(dh.MaNV)
                          && ctdh.MaSach == maSach
                          && dh.TrangThai == "Đã giao"
                    select ctdh.SoLuong).Sum();
        }

    }


}
