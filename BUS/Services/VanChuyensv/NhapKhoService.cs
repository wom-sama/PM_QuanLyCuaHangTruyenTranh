using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.VanChuyensv
{
    public class NhapKhoService
    {
        private readonly IUnitOfWork _unitOfWork;

    public NhapKhoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<NhapKho> GetAll()
        {
            try
            {
                return _unitOfWork.NhapKhoRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách phiếu nhập: " + ex.Message);
                return new List<NhapKho>();
            }
        }

        public NhapKho GetById(string maPhieuNhap)
        {
            try
            {
                return _unitOfWork.NhapKhoRepository.GetById(maPhieuNhap);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin phiếu nhập: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(NhapKho n)
        {
            try
            {
                if (n == null) return false;
                _unitOfWork.NhapKhoRepository.Add(n);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm phiếu nhập: " + ex.Message);
                return false;
            }
        }

        public bool Update(NhapKho n)
        {
            try
            {
                if (n == null) return false;
                _unitOfWork.NhapKhoRepository.Update(n);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật phiếu nhập: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maPhieuNhap)
        {
            try
            {
                var phieu = _unitOfWork.NhapKhoRepository.GetById(maPhieuNhap);
                if (phieu == null) return false;
                _unitOfWork.NhapKhoRepository.Delete(phieu);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phiếu nhập: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<NhapKho>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.NhapKhoRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách phiếu nhập (async): " + ex.Message);
                return new List<NhapKho>();
            }
        }

        public async Task<NhapKho> GetByIdAsync(string maPhieuNhap)
        {
            try
            {
                return await _unitOfWork.NhapKhoRepository.GetByIdAsync(maPhieuNhap);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy phiếu nhập (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(NhapKho n)
        {
            try
            {
                if (n == null) return false;
                _unitOfWork.NhapKhoRepository.Add(n);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm phiếu nhập (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(NhapKho n)
        {
            try
            {
                if (n == null) return false;
                _unitOfWork.NhapKhoRepository.Update(n);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật phiếu nhập (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maPhieuNhap)
        {
            try
            {
                var phieu = await _unitOfWork.NhapKhoRepository.GetByIdAsync(maPhieuNhap);
                if (phieu == null) return false;
                _unitOfWork.NhapKhoRepository.Delete(phieu);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phiếu nhập (async): " + ex.Message);
                return false;
            }
        }
    }

}
