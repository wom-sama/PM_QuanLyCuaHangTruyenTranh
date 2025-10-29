using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.BUS.Services.LamViecsv
{
    public class BangLuongService
    {
        private readonly IUnitOfWork _unitOfWork;


    public BangLuongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================
        public IEnumerable<BangLuong> GetAll()
        {
            try
            {
                return _unitOfWork.BangLuongRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách bảng lương: " + ex.Message);
                return new List<BangLuong>();
            }
        }

        public BangLuong GetById(int maBangLuong)
        {
            try
            {
                return _unitOfWork.BangLuongRepository.GetById(maBangLuong);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin bảng lương: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================
        public bool Add(BangLuong b)
        {
            try
            {
                if (b == null) return false;
                _unitOfWork.BangLuongRepository.Add(b);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm bảng lương: " + ex.Message);
                return false;
            }
        }

        public bool Update(BangLuong b)
        {
            try
            {
                if (b == null) return false;
                _unitOfWork.BangLuongRepository.Update(b);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật bảng lương: " + ex.Message);
                return false;
            }
        }

        public bool Delete(int maBangLuong)
        {
            try
            {
                var b = _unitOfWork.BangLuongRepository.GetById(maBangLuong);
                if (b == null) return false;
                _unitOfWork.BangLuongRepository.Delete(b);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa bảng lương: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================
        public async Task<IEnumerable<BangLuong>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.BangLuongRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách bảng lương (async): " + ex.Message);
                return new List<BangLuong>();
            }
        }

        public async Task<BangLuong> GetByIdAsync(int maBangLuong)
        {
            try
            {
                return await _unitOfWork.BangLuongRepository.GetByIdAsync(maBangLuong);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy bảng lương (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(BangLuong b)
        {
            try
            {
                if (b == null) return false;
                _unitOfWork.BangLuongRepository.Add(b);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm bảng lương (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(BangLuong b)
        {
            try
            {
                if (b == null) return false;
                _unitOfWork.BangLuongRepository.Update(b);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật bảng lương (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int maBangLuong)
        {
            try
            {
                var b = await _unitOfWork.BangLuongRepository.GetByIdAsync(maBangLuong);
                if (b == null) return false;
                _unitOfWork.BangLuongRepository.Delete(b);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa bảng lương (async): " + ex.Message);
                return false;
            }
        }
    }


}
