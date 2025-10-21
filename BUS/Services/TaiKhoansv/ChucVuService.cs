using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.TaiKhoansv
{
    public class ChucVuService
    {
        private readonly IUnitOfWork _unitOfWork;

    public ChucVuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<ChucVu> GetAll()
        {
            try
            {
                return _unitOfWork.ChucVuRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chức vụ: " + ex.Message);
                return new List<ChucVu>();
            }
        }

        public ChucVu GetById(string maChucVu)
        {
            try
            {
                return _unitOfWork.ChucVuRepository.GetById(maChucVu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chức vụ theo mã: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(ChucVu chucVu)
        {
            try
            {
                if (chucVu == null)
                    return false;

                _unitOfWork.ChucVuRepository.Add(chucVu);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chức vụ: " + ex.Message);
                return false;
            }
        }

        public bool Update(ChucVu chucVu)
        {
            try
            {
                if (chucVu == null)
                    return false;

                _unitOfWork.ChucVuRepository.Update(chucVu);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chức vụ: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maChucVu)
        {
            try
            {
                var cv = _unitOfWork.ChucVuRepository.GetById(maChucVu);
                if (cv == null)
                    return false;

                _unitOfWork.ChucVuRepository.Delete(cv);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chức vụ: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<ChucVu>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.ChucVuRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chức vụ (async): " + ex.Message);
                return new List<ChucVu>();
            }
        }

        public async Task<ChucVu> GetByIdAsync(string maChucVu)
        {
            try
            {
                return await _unitOfWork.ChucVuRepository.GetByIdAsync(maChucVu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chức vụ theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(ChucVu chucVu)
        {
            try
            {
                if (chucVu == null)
                    return false;

                _unitOfWork.ChucVuRepository.Add(chucVu);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chức vụ (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(ChucVu chucVu)
        {
            try
            {
                if (chucVu == null)
                    return false;

                _unitOfWork.ChucVuRepository.Update(chucVu);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chức vụ (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maChucVu)
        {
            try
            {
                var cv = await _unitOfWork.ChucVuRepository.GetByIdAsync(maChucVu);
                if (cv == null)
                    return false;

                _unitOfWork.ChucVuRepository.Delete(cv);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chức vụ (async): " + ex.Message);
                return false;
            }
        }
    }

}
