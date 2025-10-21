using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.Sachsv
{
    public class SachService
    {
        private readonly IUnitOfWork _unitOfWork;

    public SachService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public SachService()
        {
            _unitOfWork = new UnitOfWork();
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<PM.DAL.Models.Sach> GetAll()
        {
            try
            {
                return _unitOfWork.SachRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách sách: " + ex.Message);
                return new List<PM.DAL.Models.Sach>();
            }
        }

        public PM.DAL.Models.Sach GetById(string maSach)
        {
            try
            {
                return _unitOfWork.SachRepository.GetById(maSach);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy sách theo mã: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<PM.DAL.Models.Sach> Find(Func<PM.DAL.Models.Sach, bool> predicate)
        {
            try
            {
                return _unitOfWork.SachRepository.GetAll().Where(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm sách: " + ex.Message);
                return new List<PM.DAL.Models.Sach>();
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(PM.DAL.Models.Sach sach)
        {
            try
            {
                if (sach == null)
                    return false;

                _unitOfWork.SachRepository.Add(sach);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm sách: " + ex.Message);
                return false;
            }
        }

        public bool Update(PM.DAL.Models.Sach sach)
        {
            try
            {
                if (sach == null)
                    return false;

                _unitOfWork.SachRepository.Update(sach);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật sách: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maSach)
        {
            try
            {
                var sach = _unitOfWork.SachRepository.GetById(maSach);
                if (sach == null)
                    return false;

                _unitOfWork.SachRepository.Delete(sach);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa sách: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<PM.DAL.Models.Sach>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.SachRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách sách (async): " + ex.Message);
                return new List<PM.DAL.Models.Sach>();
            }
        }

        public async Task<PM.DAL.Models.Sach> GetByIdAsync(string maSach)
        {
            try
            {
                return await _unitOfWork.SachRepository.GetByIdAsync(maSach);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy sách theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(PM.DAL.Models.Sach sach)
        {
            try
            {
                if (sach == null)
                    return false;

                _unitOfWork.SachRepository.Add(sach);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm sách (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(PM.DAL.Models.Sach sach)
        {
            try
            {
                if (sach == null)
                    return false;

                _unitOfWork.SachRepository.Update(sach);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật sách (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maSach)
        {
            try
            {
                var sach = await _unitOfWork.SachRepository.GetByIdAsync(maSach);
                if (sach == null)
                    return false;

                _unitOfWork.SachRepository.Delete(sach);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa sách (async): " + ex.Message);
                return false;
            }
        }
    }

}
