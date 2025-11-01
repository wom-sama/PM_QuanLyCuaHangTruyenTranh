using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.DonHangsv
{
    public class CT_GioHangService
    {
        private readonly IUnitOfWork _unitOfWork;


    public CT_GioHangService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<CT_GioHang> GetAll()
        {
            try
            {
                return _unitOfWork.CT_GioHangRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi tiết giỏ hàng: " + ex.Message);
                return new List<CT_GioHang>();
            }
        }

        public CT_GioHang GetById(string maGioHang, string maSach)
        {
            try
            {
                return _unitOfWork.CT_GioHangRepository.GetById(maGioHang, maSach);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết giỏ hàng: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(CT_GioHang ctGioHang)
        {
            try
            {
                if (ctGioHang == null)
                    return false;

                _unitOfWork.CT_GioHangRepository.Add(ctGioHang);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết giỏ hàng: " + ex.Message);
                return false;
            }
        }

        public bool Update(CT_GioHang ctGioHang)
        {
            try
            {
                if (ctGioHang == null)
                    return false;

                _unitOfWork.CT_GioHangRepository.Update(ctGioHang);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi tiết giỏ hàng: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maGioHang, string maSach)
        {
            try
            {
                var ct = _unitOfWork.CT_GioHangRepository.GetById(maGioHang, maSach);
                if (ct == null)
                    return false;

                _unitOfWork.CT_GioHangRepository.Delete(ct);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết giỏ hàng: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<CT_GioHang>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.CT_GioHangRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi tiết giỏ hàng (async): " + ex.Message);
                return new List<CT_GioHang>();
            }
        }

        public async Task<CT_GioHang> GetByIdAsync(string maGioHang, string maSach)
        {
            try
            {
                return await _unitOfWork.CT_GioHangRepository.GetByIdAsync(maGioHang, maSach);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết giỏ hàng (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(CT_GioHang ctGioHang)
        {
            try
            {
                if (ctGioHang == null)
                    return false;

                _unitOfWork.CT_GioHangRepository.Add(ctGioHang);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết giỏ hàng (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CT_GioHang ctGioHang)
        {
            try
            {
                if (ctGioHang == null)
                    return false;

                _unitOfWork.CT_GioHangRepository.Update(ctGioHang);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi tiết giỏ hàng (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maGioHang, string maSach)
        {
            try
            {
                var ct = await _unitOfWork.CT_GioHangRepository.GetByIdAsync(maGioHang, maSach);
                if (ct == null)
                    return false;

                _unitOfWork.CT_GioHangRepository.Delete(ct);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết giỏ hàng (async): " + ex.Message);
                return false;
            }
        }
        public void DeleteByGioHangId(string maGioHang)
        {
            var list = _unitOfWork.CT_GioHangRepository
                .GetAll()
                .Where(c => c.MaGioHang == maGioHang)
                .ToList();

            foreach (var item in list)
            {
                _unitOfWork.CT_GioHangRepository.Delete(item);
            }
        }

    }

}
