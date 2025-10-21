using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.VanChuyensv
{
    public class KiemKeService
    {
        private readonly IUnitOfWork _unitOfWork;

    public KiemKeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<KiemKe> GetAll()
        {
            try
            {
                return _unitOfWork.KiemKeRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách kiểm kê: " + ex.Message);
                return new List<KiemKe>();
            }
        }

        public KiemKe GetById(string maKiemKe)
        {
            try
            {
                return _unitOfWork.KiemKeRepository.GetById(maKiemKe);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin kiểm kê: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(KiemKe k)
        {
            try
            {
                if (k == null) return false;
                _unitOfWork.KiemKeRepository.Add(k);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm phiếu kiểm kê: " + ex.Message);
                return false;
            }
        }

        public bool Update(KiemKe k)
        {
            try
            {
                if (k == null) return false;
                _unitOfWork.KiemKeRepository.Update(k);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật phiếu kiểm kê: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maKiemKe)
        {
            try
            {
                var kk = _unitOfWork.KiemKeRepository.GetById(maKiemKe);
                if (kk == null) return false;
                _unitOfWork.KiemKeRepository.Delete(kk);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phiếu kiểm kê: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<KiemKe>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.KiemKeRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách kiểm kê (async): " + ex.Message);
                return new List<KiemKe>();
            }
        }

        public async Task<KiemKe> GetByIdAsync(string maKiemKe)
        {
            try
            {
                return await _unitOfWork.KiemKeRepository.GetByIdAsync(maKiemKe);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy phiếu kiểm kê (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(KiemKe k)
        {
            try
            {
                if (k == null) return false;
                _unitOfWork.KiemKeRepository.Add(k);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm phiếu kiểm kê (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(KiemKe k)
        {
            try
            {
                if (k == null) return false;
                _unitOfWork.KiemKeRepository.Update(k);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật phiếu kiểm kê (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maKiemKe)
        {
            try
            {
                var kk = await _unitOfWork.KiemKeRepository.GetByIdAsync(maKiemKe);
                if (kk == null) return false;
                _unitOfWork.KiemKeRepository.Delete(kk);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phiếu kiểm kê (async): " + ex.Message);
                return false;
            }
        }
    }


}
