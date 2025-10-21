using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.DonHangsv
{
    public class DonHangService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DonHangService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public DonHangService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<DonHang> GetAll()
        {
            try
            {
                return _unitOfWork.DonHangRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách đơn hàng: " + ex.Message);
                return new List<DonHang>();
            }
        }

        public DonHang GetById(string maDonHang)
        {
            try
            {
                return _unitOfWork.DonHangRepository.GetById(maDonHang);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy đơn hàng theo mã: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<DonHang> Find(Func<DonHang, bool> predicate)
        {
            try
            {
                return _unitOfWork.DonHangRepository.GetAll().Where(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm đơn hàng: " + ex.Message);
                return new List<DonHang>();
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(DonHang donHang)
        {
            try
            {
                if (donHang == null)
                    return false;

                _unitOfWork.DonHangRepository.Add(donHang);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm đơn hàng: " + ex.Message);
                return false;
            }
        }

        public bool Update(DonHang donHang)
        {
            try
            {
                if (donHang == null)
                    return false;

                _unitOfWork.DonHangRepository.Update(donHang);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật đơn hàng: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maDonHang)
        {
            try
            {
                var donHang = _unitOfWork.DonHangRepository.GetById(maDonHang);
                if (donHang == null)
                    return false;

                _unitOfWork.DonHangRepository.Delete(donHang);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa đơn hàng: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<DonHang>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.DonHangRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách đơn hàng (async): " + ex.Message);
                return new List<DonHang>();
            }
        }

        public async Task<DonHang> GetByIdAsync(string maDonHang)
        {
            try
            {
                return await _unitOfWork.DonHangRepository.GetByIdAsync(maDonHang);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy đơn hàng theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(DonHang donHang)
        {
            try
            {
                if (donHang == null)
                    return false;

                _unitOfWork.DonHangRepository.Add(donHang);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm đơn hàng (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(DonHang donHang)
        {
            try
            {
                if (donHang == null)
                    return false;

                _unitOfWork.DonHangRepository.Update(donHang);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật đơn hàng (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maDonHang)
        {
            try
            {
                var donHang = await _unitOfWork.DonHangRepository.GetByIdAsync(maDonHang);
                if (donHang == null)
                    return false;

                _unitOfWork.DonHangRepository.Delete(donHang);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa đơn hàng (async): " + ex.Message);
                return false;
            }
        }
    }


}
