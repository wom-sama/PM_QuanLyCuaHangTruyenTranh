using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.BUS.Services
{
    public class TaiKhoanService
    {
        private readonly IUnitOfWork _unitOfWork;

    public TaiKhoanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================
        public IEnumerable<TaiKhoan> GetAll()
        {
            try
            {
                return _unitOfWork.TaiKhoanRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách tài khoản: " + ex.Message);
                return new List<TaiKhoan>();
            }
        }

        public TaiKhoan GetById(string tenDangNhap)
        {
            try
            {
                return _unitOfWork.TaiKhoanRepository.GetById(tenDangNhap);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin tài khoản: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================
        public bool Add(TaiKhoan tk)
        {
            try
            {
                if (tk == null) return false;
                _unitOfWork.TaiKhoanRepository.Add(tk);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm tài khoản: " + ex.Message);
                return false;
            }
        }

        public bool Update(TaiKhoan tk)
        {
            try
            {
                if (tk == null) return false;
                _unitOfWork.TaiKhoanRepository.Update(tk);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật tài khoản: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string tenDangNhap)
        {
            try
            {
                var tk = _unitOfWork.TaiKhoanRepository.GetById(tenDangNhap);
                if (tk == null) return false;
                _unitOfWork.TaiKhoanRepository.Delete(tk);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa tài khoản: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================
        public async Task<IEnumerable<TaiKhoan>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.TaiKhoanRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách tài khoản (async): " + ex.Message);
                return new List<TaiKhoan>();
            }
        }

        public async Task<TaiKhoan> GetByIdAsync(string tenDangNhap)
        {
            try
            {
                return await _unitOfWork.TaiKhoanRepository.GetByIdAsync(tenDangNhap);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy tài khoản (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(TaiKhoan tk)
        {
            try
            {
                if (tk == null) return false;
                _unitOfWork.TaiKhoanRepository.Add(tk);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm tài khoản (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TaiKhoan tk)
        {
            try
            {
                if (tk == null) return false;
                _unitOfWork.TaiKhoanRepository.Update(tk);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật tài khoản (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string tenDangNhap)
        {
            try
            {
                var tk = await _unitOfWork.TaiKhoanRepository.GetByIdAsync(tenDangNhap);
                if (tk == null) return false;
                _unitOfWork.TaiKhoanRepository.Delete(tk);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa tài khoản (async): " + ex.Message);
                return false;
            }
        }
    }

}