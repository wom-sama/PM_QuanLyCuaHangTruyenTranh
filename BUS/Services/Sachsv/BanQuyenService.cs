using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.Sachsv
{
    public class BanQuyenService
    {
        private readonly IUnitOfWork _unitOfWork;


    public BanQuyenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<BanQuyen> GetAll()
        {
            try
            {
                return _unitOfWork.BanQuyenRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách bản quyền: " + ex.Message);
                return new List<BanQuyen>();
            }
        }

        public BanQuyen GetById(string maBanQuyen)
        {
            try
            {
                return _unitOfWork.BanQuyenRepository.GetById(maBanQuyen);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy bản quyền theo mã: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<BanQuyen> Find(Func<BanQuyen, bool> predicate)
        {
            try
            {
                return _unitOfWork.BanQuyenRepository.GetAll().Where(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm bản quyền: " + ex.Message);
                return new List<BanQuyen>();
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(BanQuyen banQuyen)
        {
            try
            {
                if (banQuyen == null)
                    return false;

                _unitOfWork.BanQuyenRepository.Add(banQuyen);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm bản quyền: " + ex.Message);
                return false;
            }
        }

        public bool Update(BanQuyen banQuyen)
        {
            try
            {
                if (banQuyen == null)
                    return false;

                _unitOfWork.BanQuyenRepository.Update(banQuyen);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật bản quyền: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maBanQuyen)
        {
            try
            {
                var banQuyen = _unitOfWork.BanQuyenRepository.GetById(maBanQuyen);
                if (banQuyen == null)
                    return false;

                _unitOfWork.BanQuyenRepository.Delete(banQuyen);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa bản quyền: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<BanQuyen>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.BanQuyenRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách bản quyền (async): " + ex.Message);
                return new List<BanQuyen>();
            }
        }

        public async Task<BanQuyen> GetByIdAsync(string maBanQuyen)
        {
            try
            {
                return await _unitOfWork.BanQuyenRepository.GetByIdAsync(maBanQuyen);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy bản quyền theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(BanQuyen banQuyen)
        {
            try
            {
                if (banQuyen == null)
                    return false;

                _unitOfWork.BanQuyenRepository.Add(banQuyen);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm bản quyền (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(BanQuyen banQuyen)
        {
            try
            {
                if (banQuyen == null)
                    return false;

                _unitOfWork.BanQuyenRepository.Update(banQuyen);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật bản quyền (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maBanQuyen)
        {
            try
            {
                var banQuyen = await _unitOfWork.BanQuyenRepository.GetByIdAsync(maBanQuyen);
                if (banQuyen == null)
                    return false;

                _unitOfWork.BanQuyenRepository.Delete(banQuyen);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa bản quyền (async): " + ex.Message);
                return false;
            }
        }
    }


}
