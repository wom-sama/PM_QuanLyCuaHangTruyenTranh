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
        public int LaySoLuongTon(string maSach, string maKho)
        {
            try
            {
                // 🔹 Tổng nhập từ phiếu nhập thuộc kho này
                var tongNhap = (from nk in _unitOfWork.NhapKhoRepository.GetAll()
                                join ctn in _unitOfWork.CT_NhapKhoRepository.GetAll()
                                    on nk.MaPhieuNhap equals ctn.MaPhieuNhap
                                where nk.MaKho == maKho && ctn.MaSach == maSach
                                select (int?)ctn.SoLuong).Sum() ?? 0;

                // 🔹 Tổng bán: hiện DonHang KHÔNG có MaKho, nên chỉ trừ tổng số sách bán ra (không phân kho)
                var tongBan = (from ctdh in _unitOfWork.CT_DonHangRepository.GetAll()
                               where ctdh.MaSach == maSach
                               select (int?)ctdh.SoLuong).Sum() ?? 0;

                // 🔹 Tổng chuyển đi
                var tongChuyenDi = (from ck in _unitOfWork.ChuyenKhoRepository.GetAll()
                                    join ctnk in _unitOfWork.CT_NhapKhoRepository.GetAll()
                                        on ck.MaPhieuChuyen equals ctnk.MaPhieuNhap
                                    where ck.MaKhoXuat == maKho && ctnk.MaSach == maSach
                                    select (int?)ctnk.SoLuong).Sum() ?? 0;

                // 🔹 Tổng chuyển đến
                var tongChuyenDen = (from ck in _unitOfWork.ChuyenKhoRepository.GetAll()
                                     join ctnk in _unitOfWork.CT_NhapKhoRepository.GetAll()
                                         on ck.MaPhieuChuyen equals ctnk.MaPhieuNhap
                                     where ck.MaKhoNhap == maKho && ctnk.MaSach == maSach
                                     select (int?)ctnk.SoLuong).Sum() ?? 0;

                // 🔹 Tổng tồn thực tế
                return tongNhap + tongChuyenDen - tongBan - tongChuyenDi;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy số lượng tồn kho: " + ex.Message);
                return 0;
            }
        }




    }


}
