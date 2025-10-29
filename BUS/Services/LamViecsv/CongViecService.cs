using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.BUS.Services.LamViecsv
{
    public class CongViecService
    {
        private readonly IUnitOfWork _unitOfWork;


    public CongViecService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================
        public IEnumerable<CongViec> GetAll()
        {
            try
            {
                return _unitOfWork.CongViecRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách công việc: " + ex.Message);
                return new List<CongViec>();
            }
        }

        public CongViec GetById(int maCongViec)
        {
            try
            {
                return _unitOfWork.CongViecRepository.GetById(maCongViec);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin công việc: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================
        public bool Add(CongViec c)
        {
            try
            {
                if (c == null) return false;
                _unitOfWork.CongViecRepository.Add(c);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm công việc: " + ex.Message);
                return false;
            }
        }

        public bool Update(CongViec c)
        {
            try
            {
                if (c == null) return false;
                _unitOfWork.CongViecRepository.Update(c);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật công việc: " + ex.Message);
                return false;
            }
        }

        public bool Delete(int maCongViec)
        {
            try
            {
                var c = _unitOfWork.CongViecRepository.GetById(maCongViec);
                if (c == null) return false;
                _unitOfWork.CongViecRepository.Delete(c);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa công việc: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================
        public async Task<IEnumerable<CongViec>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.CongViecRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách công việc (async): " + ex.Message);
                return new List<CongViec>();
            }
        }

        public async Task<CongViec> GetByIdAsync(int maCongViec)
        {
            try
            {
                return await _unitOfWork.CongViecRepository.GetByIdAsync(maCongViec);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy công việc (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(CongViec c)
        {
            try
            {
                if (c == null) return false;
                _unitOfWork.CongViecRepository.Add(c);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm công việc (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CongViec c)
        {
            try
            {
                if (c == null) return false;
                _unitOfWork.CongViecRepository.Update(c);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật công việc (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int maCongViec)
        {
            try
            {
                var c = await _unitOfWork.CongViecRepository.GetByIdAsync(maCongViec);
                if (c == null) return false;
                _unitOfWork.CongViecRepository.Delete(c);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa công việc (async): " + ex.Message);
                return false;
            }
        }
    }

}
