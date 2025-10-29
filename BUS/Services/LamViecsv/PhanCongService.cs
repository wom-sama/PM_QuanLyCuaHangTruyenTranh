using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.BUS.Services.LamViecsv

{
    public class PhanCongService
    {
        private readonly IUnitOfWork _unitOfWork;

    public PhanCongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================
        public IEnumerable<PhanCong> GetAll()
        {
            try
            {
                return _unitOfWork.PhanCongRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách phân công: " + ex.Message);
                return new List<PhanCong>();
            }
        }

        public PhanCong GetById(int maPhanCong)
        {
            try
            {
                return _unitOfWork.PhanCongRepository.GetById(maPhanCong);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin phân công: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================
        public bool Add(PhanCong p)
        {
            try
            {
                if (p == null) return false;
                _unitOfWork.PhanCongRepository.Add(p);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm phân công: " + ex.Message);
                return false;
            }
        }

        public bool Update(PhanCong p)
        {
            try
            {
                if (p == null) return false;
                _unitOfWork.PhanCongRepository.Update(p);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật phân công: " + ex.Message);
                return false;
            }
        }

        public bool Delete(int maPhanCong)
        {
            try
            {
                var p = _unitOfWork.PhanCongRepository.GetById(maPhanCong);
                if (p == null) return false;
                _unitOfWork.PhanCongRepository.Delete(p);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phân công: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================
        public async Task<IEnumerable<PhanCong>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.PhanCongRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách phân công (async): " + ex.Message);
                return new List<PhanCong>();
            }
        }

        public async Task<PhanCong> GetByIdAsync(int maPhanCong)
        {
            try
            {
                return await _unitOfWork.PhanCongRepository.GetByIdAsync(maPhanCong);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy phân công (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(PhanCong p)
        {
            try
            {
                if (p == null) return false;
                _unitOfWork.PhanCongRepository.Add(p);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm phân công (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(PhanCong p)
        {
            try
            {
                if (p == null) return false;
                _unitOfWork.PhanCongRepository.Update(p);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật phân công (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int maPhanCong)
        {
            try
            {
                var p = await _unitOfWork.PhanCongRepository.GetByIdAsync(maPhanCong);
                if (p == null) return false;
                _unitOfWork.PhanCongRepository.Delete(p);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phân công (async): " + ex.Message);
                return false;
            }
        }
    }

}
