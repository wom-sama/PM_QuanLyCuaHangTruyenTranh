using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.DonHangsv
{
    public class CT_DonHangService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork => _unitOfWork;

        public CT_DonHangService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CT_DonHangService()
        {
            _unitOfWork = new UnitOfWork();
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<CT_DonHang> GetAll()
        {
            try
            {
                return _unitOfWork.CT_DonHangRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi tiết đơn hàng: " + ex.Message);
                return new List<CT_DonHang>();
            }
        }

        public CT_DonHang GetById(string maDonHang, string maSach)
        {
            try
            {
                return _unitOfWork.CT_DonHangRepository.GetById(maDonHang, maSach);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết đơn hàng theo mã: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<CT_DonHang> Find(Func<CT_DonHang, bool> predicate)
        {
            try
            {
                return _unitOfWork.CT_DonHangRepository.GetAll().Where(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm chi tiết đơn hàng: " + ex.Message);
                return new List<CT_DonHang>();
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(CT_DonHang ctDonHang)
        {
            try
            {
                if (ctDonHang == null)
                    return false;

                _unitOfWork.CT_DonHangRepository.Add(ctDonHang);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết đơn hàng: " + ex.Message);
                return false;
            }
        }

        public bool Update(CT_DonHang ctDonHang)
        {
            try
            {
                if (ctDonHang == null)
                    return false;

                _unitOfWork.CT_DonHangRepository.Update(ctDonHang);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi tiết đơn hàng: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maDonHang, string maSach)
        {
            try
            {
                var ct = _unitOfWork.CT_DonHangRepository.GetById(maDonHang, maSach);
                if (ct == null)
                    return false;

                _unitOfWork.CT_DonHangRepository.Delete(ct);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết đơn hàng: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<CT_DonHang>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.CT_DonHangRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi tiết đơn hàng (async): " + ex.Message);
                return new List<CT_DonHang>();
            }
        }

        public async Task<CT_DonHang> GetByIdAsync(string maDonHang, string maSach)
        {
            try
            {
                return await _unitOfWork.CT_DonHangRepository.GetByIdAsync(maDonHang, maSach);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết đơn hàng theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(CT_DonHang ctDonHang)
        {
            try
            {
                if (ctDonHang == null)
                    return false;

                _unitOfWork.CT_DonHangRepository.Add(ctDonHang);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết đơn hàng (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CT_DonHang ctDonHang)
        {
            try
            {
                if (ctDonHang == null)
                    return false;

                _unitOfWork.CT_DonHangRepository.Update(ctDonHang);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi tiết đơn hàng (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maDonHang, string maSach)
        {
            try
            {
                var ct = await _unitOfWork.CT_DonHangRepository.GetByIdAsync(maDonHang, maSach);
                if (ct == null)
                    return false;

                _unitOfWork.CT_DonHangRepository.Delete(ct);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết đơn hàng (async): " + ex.Message);
                return false;
            }
        }
    }


}
