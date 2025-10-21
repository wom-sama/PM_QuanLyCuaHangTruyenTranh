using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.DonHangsv
{
    public class HoaDonService
    {
        private readonly IUnitOfWork _unitOfWork;


    public HoaDonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public HoaDonService() { }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<HoaDon> GetAll()
        {
            try
            {
                return _unitOfWork.HoaDonRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
                return new List<HoaDon>();
            }
        }

        public HoaDon GetById(string maHoaDon)
        {
            try
            {
                return _unitOfWork.HoaDonRepository.GetById(maHoaDon);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy hóa đơn theo mã: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(HoaDon hoaDon)
        {
            try
            {
                if (hoaDon == null)
                    return false;

                _unitOfWork.HoaDonRepository.Add(hoaDon);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
                return false;
            }
        }

        public bool Update(HoaDon hoaDon)
        {
            try
            {
                if (hoaDon == null)
                    return false;

                _unitOfWork.HoaDonRepository.Update(hoaDon);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật hóa đơn: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maHoaDon)
        {
            try
            {
                var hd = _unitOfWork.HoaDonRepository.GetById(maHoaDon);
                if (hd == null)
                    return false;

                _unitOfWork.HoaDonRepository.Delete(hd);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa hóa đơn: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<HoaDon>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.HoaDonRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hóa đơn (async): " + ex.Message);
                return new List<HoaDon>();
            }
        }

        public async Task<HoaDon> GetByIdAsync(string maHoaDon)
        {
            try
            {
                return await _unitOfWork.HoaDonRepository.GetByIdAsync(maHoaDon);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy hóa đơn theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(HoaDon hoaDon)
        {
            try
            {
                if (hoaDon == null)
                    return false;

                _unitOfWork.HoaDonRepository.Add(hoaDon);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(HoaDon hoaDon)
        {
            try
            {
                if (hoaDon == null)
                    return false;

                _unitOfWork.HoaDonRepository.Update(hoaDon);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật hóa đơn (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maHoaDon)
        {
            try
            {
                var hd = await _unitOfWork.HoaDonRepository.GetByIdAsync(maHoaDon);
                if (hd == null)
                    return false;

                _unitOfWork.HoaDonRepository.Delete(hd);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa hóa đơn (async): " + ex.Message);
                return false;
            }
        }
    }
}
