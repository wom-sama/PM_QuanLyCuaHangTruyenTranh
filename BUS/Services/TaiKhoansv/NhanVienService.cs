using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.TaiKhoansv
{
    public class NhanVienService
    {
        private readonly IUnitOfWork _unitOfWork;


    public NhanVienService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public NhanVienService() : this(new UnitOfWork())
        {
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<NhanVien> GetAll()
        {
            try
            {
                return _unitOfWork.NhanVienRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
                return new List<NhanVien>();
            }
        }

        public NhanVien GetById(string maNV)
        {
            try
            {
                return _unitOfWork.NhanVienRepository.GetById(maNV);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy nhân viên theo mã: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<NhanVien> Find(Func<NhanVien, bool> predicate)
        {
            try
            {
                return _unitOfWork.NhanVienRepository.GetAll().Where(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
                return new List<NhanVien>();
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(NhanVien nhanVien)
        {
            try
            {
                if (nhanVien == null)
                    return false;

                _unitOfWork.NhanVienRepository.Add(nhanVien);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm nhân viên: " + ex.Message);
                return false;
            }
        }

        public bool Update(NhanVien nhanVien)
        {
            try
            {
                if (nhanVien == null)
                    return false;

                _unitOfWork.NhanVienRepository.Update(nhanVien);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật nhân viên: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maNV)
        {
            try
            {
                var nv = _unitOfWork.NhanVienRepository.GetById(maNV);
                if (nv == null)
                    return false;

                _unitOfWork.NhanVienRepository.Delete(nv);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa nhân viên: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<NhanVien>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.NhanVienRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách nhân viên (async): " + ex.Message);
                return new List<NhanVien>();
            }
        }

        public async Task<NhanVien> GetByIdAsync(string maNV)
        {
            try
            {
                return await _unitOfWork.NhanVienRepository.GetByIdAsync(maNV);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy nhân viên theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(NhanVien nhanVien)
        {
            try
            {
                if (nhanVien == null)
                    return false;

                _unitOfWork.NhanVienRepository.Add(nhanVien);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm nhân viên (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(NhanVien nhanVien)
        {
            try
            {
                if (nhanVien == null)
                    return false;

                _unitOfWork.NhanVienRepository.Update(nhanVien);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật nhân viên (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maNV)
        {
            try
            {
                var nv = await _unitOfWork.NhanVienRepository.GetByIdAsync(maNV);
                if (nv == null)
                    return false;

                _unitOfWork.NhanVienRepository.Delete(nv);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa nhân viên (async): " + ex.Message);
                return false;
            }
        }
    }


}
