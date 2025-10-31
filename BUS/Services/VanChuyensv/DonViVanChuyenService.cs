using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.BUS.Services
{
    public class DonViVanChuyenService
    {
        private readonly IUnitOfWork _unitOfWork;


    public DonViVanChuyenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public DonViVanChuyenService()
        {
            _unitOfWork = new UnitOfWork();
        }

        // ==================== LẤY DỮ LIỆU ====================
        public IEnumerable<DonViVanChuyen> GetAll()
        {
            try
            {
                return _unitOfWork.DonViVanChuyenRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách đơn vị vận chuyển: " + ex.Message);
                return new List<DonViVanChuyen>();
            }
        }

        public DonViVanChuyen GetById(string maDVVC)
        {
            try
            {
                return _unitOfWork.DonViVanChuyenRepository.GetById(maDVVC);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin đơn vị vận chuyển: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================
        public bool Add(DonViVanChuyen dvvc)
        {
            try
            {
                if (dvvc == null) return false;
                _unitOfWork.DonViVanChuyenRepository.Add(dvvc);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm đơn vị vận chuyển: " + ex.Message);
                return false;
            }
        }

        public bool Update(DonViVanChuyen dvvc)
        {
            try
            {
                if (dvvc == null) return false;
                _unitOfWork.DonViVanChuyenRepository.Update(dvvc);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật đơn vị vận chuyển: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maDVVC)
        {
            try
            {
                var dvvc = _unitOfWork.DonViVanChuyenRepository.GetById(maDVVC);
                if (dvvc == null) return false;
                _unitOfWork.DonViVanChuyenRepository.Delete(dvvc);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa đơn vị vận chuyển: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================
        public async Task<IEnumerable<DonViVanChuyen>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.DonViVanChuyenRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách đơn vị vận chuyển (async): " + ex.Message);
                return new List<DonViVanChuyen>();
            }
        }

        public async Task<DonViVanChuyen> GetByIdAsync(string maDVVC)
        {
            try
            {
                return await _unitOfWork.DonViVanChuyenRepository.GetByIdAsync(maDVVC);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy đơn vị vận chuyển (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(DonViVanChuyen dvvc)
        {
            try
            {
                if (dvvc == null) return false;
                _unitOfWork.DonViVanChuyenRepository.Add(dvvc);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm đơn vị vận chuyển (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(DonViVanChuyen dvvc)
        {
            try
            {
                if (dvvc == null) return false;
                _unitOfWork.DonViVanChuyenRepository.Update(dvvc);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật đơn vị vận chuyển (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maDVVC)
        {
            try
            {
                var dvvc = await _unitOfWork.DonViVanChuyenRepository.GetByIdAsync(maDVVC);
                if (dvvc == null) return false;
                _unitOfWork.DonViVanChuyenRepository.Delete(dvvc);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa đơn vị vận chuyển (async): " + ex.Message);
                return false;
            }
        }
    }

}
