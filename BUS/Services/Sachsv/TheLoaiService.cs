using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.Sachsv
{
    public class TheLoaiService
    {
        private readonly IUnitOfWork _unitOfWork;

    public TheLoaiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public TheLoaiService()
        {
            _unitOfWork = new UnitOfWork();
        }


        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<TheLoai> GetAll()
        {
            try
            {
                return _unitOfWork.TheLoaiRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách thể loại: " + ex.Message);
                return new List<TheLoai>();
            }
        }

        public TheLoai GetById(string maTheLoai)
        {
            try
            {
                return _unitOfWork.TheLoaiRepository.GetById(maTheLoai);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thể loại theo mã: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<TheLoai> Find(Func<TheLoai, bool> predicate)
        {
            try
            {
                return _unitOfWork.TheLoaiRepository.GetAll().Where(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm thể loại: " + ex.Message);
                return new List<TheLoai>();
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(TheLoai theLoai)
        {
            try
            {
                if (theLoai == null)
                    return false;

                _unitOfWork.TheLoaiRepository.Add(theLoai);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm thể loại: " + ex.Message);
                return false;
            }
        }

        public bool Update(TheLoai theLoai)
        {
            try
            {
                if (theLoai == null)
                    return false;

                _unitOfWork.TheLoaiRepository.Update(theLoai);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật thể loại: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maTheLoai)
        {
            try
            {
                var tl = _unitOfWork.TheLoaiRepository.GetById(maTheLoai);
                if (tl == null)
                    return false;

                _unitOfWork.TheLoaiRepository.Delete(tl);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa thể loại: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<TheLoai>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.TheLoaiRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách thể loại (async): " + ex.Message);
                return new List<TheLoai>();
            }
        }

        public async Task<TheLoai> GetByIdAsync(string maTheLoai)
        {
            try
            {
                return await _unitOfWork.TheLoaiRepository.GetByIdAsync(maTheLoai);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thể loại theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(TheLoai theLoai)
        {
            try
            {
                if (theLoai == null)
                    return false;

                _unitOfWork.TheLoaiRepository.Add(theLoai);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm thể loại (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TheLoai theLoai)
        {
            try
            {
                if (theLoai == null)
                    return false;

                _unitOfWork.TheLoaiRepository.Update(theLoai);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật thể loại (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maTheLoai)
        {
            try
            {
                var tl = await _unitOfWork.TheLoaiRepository.GetByIdAsync(maTheLoai);
                if (tl == null)
                    return false;

                _unitOfWork.TheLoaiRepository.Delete(tl);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa thể loại (async): " + ex.Message);
                return false;
            }
        }
    }


}
