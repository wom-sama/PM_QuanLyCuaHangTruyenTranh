using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.VanChuyensv
{
    public class CT_NhapKhoService
    {
        private readonly IUnitOfWork _unitOfWork;


    public CT_NhapKhoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<CT_NhapKho> GetAll()
        {
            try
            {
                return _unitOfWork.CT_NhapKhoRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi tiết nhập kho: " + ex.Message);
                return new List<CT_NhapKho>();
            }
        }

        public CT_NhapKho GetById(string maPhieuNhap, string maSach)
        {
            try
            {
                return _unitOfWork.CT_NhapKhoRepository.GetById(maPhieuNhap, maSach);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết nhập kho theo mã: " + ex.Message);
                return null;
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(CT_NhapKho ct)
        {
            try
            {
                if (ct == null)
                    return false;

                _unitOfWork.CT_NhapKhoRepository.Add(ct);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết nhập kho: " + ex.Message);
                return false;
            }
        }

        public bool Update(CT_NhapKho ct)
        {
            try
            {
                if (ct == null)
                    return false;

                _unitOfWork.CT_NhapKhoRepository.Update(ct);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi tiết nhập kho: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maPhieuNhap, string maSach)
        {
            try
            {
                var ct = _unitOfWork.CT_NhapKhoRepository.GetById(maPhieuNhap, maSach);
                if (ct == null)
                    return false;

                _unitOfWork.CT_NhapKhoRepository.Delete(ct);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết nhập kho: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<CT_NhapKho>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.CT_NhapKhoRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi tiết nhập kho (async): " + ex.Message);
                return new List<CT_NhapKho>();
            }
        }

        public async Task<CT_NhapKho> GetByIdAsync(string maPhieuNhap, string maSach)
        {
            try
            {
                return await _unitOfWork.CT_NhapKhoRepository.GetByIdAsync(maPhieuNhap, maSach);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết nhập kho theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(CT_NhapKho ct)
        {
            try
            {
                if (ct == null)
                    return false;

                _unitOfWork.CT_NhapKhoRepository.Add(ct);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết nhập kho (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(CT_NhapKho ct)
        {
            try
            {
                if (ct == null)
                    return false;

                _unitOfWork.CT_NhapKhoRepository.Update(ct);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi tiết nhập kho (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maPhieuNhap, string maSach)
        {
            try
            {
                var ct = await _unitOfWork.CT_NhapKhoRepository.GetByIdAsync(maPhieuNhap, maSach);
                if (ct == null)
                    return false;

                _unitOfWork.CT_NhapKhoRepository.Delete(ct);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết nhập kho (async): " + ex.Message);
                return false;
            }
        }
    }

}
