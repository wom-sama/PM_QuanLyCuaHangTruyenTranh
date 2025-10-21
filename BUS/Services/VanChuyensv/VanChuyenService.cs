using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.VanChuyensv
{
    public class VanChuyenService
    {
        private readonly IUnitOfWork _unitOfWork;

    public VanChuyenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<VanChuyen> GetAll()
        {
            try
            {
                return _unitOfWork.VanChuyenRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách vận chuyển: " + ex.Message);
                return new List<VanChuyen>();
            }
        }

        public VanChuyen GetById(string maVanChuyen)
        {
            try
            {
                return _unitOfWork.VanChuyenRepository.GetById(maVanChuyen);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin vận chuyển: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(VanChuyen v)
        {
            try
            {
                if (v == null) return false;
                _unitOfWork.VanChuyenRepository.Add(v);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm vận chuyển: " + ex.Message);
                return false;
            }
        }

        public bool Update(VanChuyen v)
        {
            try
            {
                if (v == null) return false;
                _unitOfWork.VanChuyenRepository.Update(v);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật vận chuyển: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maVanChuyen)
        {
            try
            {
                var vc = _unitOfWork.VanChuyenRepository.GetById(maVanChuyen);
                if (vc == null) return false;
                _unitOfWork.VanChuyenRepository.Delete(vc);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa vận chuyển: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<VanChuyen>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.VanChuyenRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách vận chuyển (async): " + ex.Message);
                return new List<VanChuyen>();
            }
        }

        public async Task<VanChuyen> GetByIdAsync(string maVanChuyen)
        {
            try
            {
                return await _unitOfWork.VanChuyenRepository.GetByIdAsync(maVanChuyen);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy vận chuyển (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(VanChuyen v)
        {
            try
            {
                if (v == null) return false;
                _unitOfWork.VanChuyenRepository.Add(v);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm vận chuyển (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(VanChuyen v)
        {
            try
            {
                if (v == null) return false;
                _unitOfWork.VanChuyenRepository.Update(v);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật vận chuyển (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maVanChuyen)
        {
            try
            {
                var vc = await _unitOfWork.VanChuyenRepository.GetByIdAsync(maVanChuyen);
                if (vc == null) return false;
                _unitOfWork.VanChuyenRepository.Delete(vc);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa vận chuyển (async): " + ex.Message);
                return false;
            }
        }
    }

}
