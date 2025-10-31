using DAL.Migrations;
using PM.DAL;
using PM.DAL.Interfaces;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.DonHangsv
{
    public class GioHangService
    {
        private readonly IUnitOfWork _unitOfWork;

    public GioHangService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<GioHang> GetAll()
        {
            try
            {
                return _unitOfWork.GioHangRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách giỏ hàng: " + ex.Message);
                return new List<GioHang>();
            }
        }

        public GioHang GetById(string maGioHang)
        {
            try
            {
                return _unitOfWork.GioHangRepository.GetById(maGioHang);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy giỏ hàng theo mã: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(GioHang gioHang)
        {
            try
            {
                if (gioHang == null)
                    return false;

                _unitOfWork.GioHangRepository.Add(gioHang);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm giỏ hàng: " + ex.Message);
                return false;
            }
        }

        public bool Update(GioHang gioHang)
        {
            try
            {
                if (gioHang == null)
                    return false;

                _unitOfWork.GioHangRepository.Update(gioHang);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật giỏ hàng: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maGioHang)
        {
            try
            {
                var gh = _unitOfWork.GioHangRepository.GetById(maGioHang);
                if (gh == null)
                    return false;

                _unitOfWork.GioHangRepository.Delete(gh);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa giỏ hàng: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<GioHang>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.GioHangRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách giỏ hàng (async): " + ex.Message);
                return new List<GioHang>();
            }
        }

        public async Task<GioHang> GetByIdAsync(string maGioHang)
        {
            try
            {
                return await _unitOfWork.GioHangRepository.GetByIdAsync(maGioHang);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy giỏ hàng theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(GioHang gioHang)
        {
            try
            {
                if (gioHang == null)
                    return false;

                _unitOfWork.GioHangRepository.Add(gioHang);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm giỏ hàng (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(GioHang gioHang)
        {
            try
            {
                if (gioHang == null)
                    return false;

                _unitOfWork.GioHangRepository.Update(gioHang);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật giỏ hàng (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maGioHang)
        {
            try
            {
                var gh = await _unitOfWork.GioHangRepository.GetByIdAsync(maGioHang);
                if (gh == null)
                    return false;

                _unitOfWork.GioHangRepository.Delete(gh);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa giỏ hàng (async): " + ex.Message);
                return false;
            }
        }
        public Sach GetSachById(string maSach)
        {
            return _unitOfWork.SachRepository.GetAll().FirstOrDefault(s => s.MaSach == maSach);
        }

    }


}
