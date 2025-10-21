using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.BUS.Services.VanChuyensv
{
    public class ChiNhanhService
    {
        private readonly IUnitOfWork _unitOfWork;


    public ChiNhanhService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================
        public IEnumerable<ChiNhanh> GetAll()
        {
            try
            {
                return _unitOfWork.ChiNhanhRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi nhánh: " + ex.Message);
                return new List<ChiNhanh>();
            }
        }

        public ChiNhanh GetById(string maChiNhanh)
        {
            try
            {
                return _unitOfWork.ChiNhanhRepository.GetById(maChiNhanh);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin chi nhánh: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================
        public bool Add(ChiNhanh c)
        {
            try
            {
                if (c == null) return false;
                _unitOfWork.ChiNhanhRepository.Add(c);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi nhánh: " + ex.Message);
                return false;
            }
        }

        public bool Update(ChiNhanh c)
        {
            try
            {
                if (c == null) return false;
                _unitOfWork.ChiNhanhRepository.Update(c);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi nhánh: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maChiNhanh)
        {
            try
            {
                var cn = _unitOfWork.ChiNhanhRepository.GetById(maChiNhanh);
                if (cn == null) return false;
                _unitOfWork.ChiNhanhRepository.Delete(cn);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi nhánh: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================
        public async Task<IEnumerable<ChiNhanh>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.ChiNhanhRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi nhánh (async): " + ex.Message);
                return new List<ChiNhanh>();
            }
        }

        public async Task<ChiNhanh> GetByIdAsync(string maChiNhanh)
        {
            try
            {
                return await _unitOfWork.ChiNhanhRepository.GetByIdAsync(maChiNhanh);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi nhánh (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(ChiNhanh c)
        {
            try
            {
                if (c == null) return false;
                _unitOfWork.ChiNhanhRepository.Add(c);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi nhánh (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(ChiNhanh c)
        {
            try
            {
                if (c == null) return false;
                _unitOfWork.ChiNhanhRepository.Update(c);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi nhánh (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maChiNhanh)
        {
            try
            {
                var cn = await _unitOfWork.ChiNhanhRepository.GetByIdAsync(maChiNhanh);
                if (cn == null) return false;
                _unitOfWork.ChiNhanhRepository.Delete(cn);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi nhánh (async): " + ex.Message);
                return false;
            }
        }
    }


}
