using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.Sachsv
{
    public class TacGiaService
    {
        private readonly IUnitOfWork _unitOfWork;

    public TacGiaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<TacGia> GetAll()
        {
            try
            {
                return _unitOfWork.TacGiaRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách tác giả: " + ex.Message);
                return new List<TacGia>();
            }
        }

        public TacGia GetById(string maTacGia)
        {
            try
            {
                return _unitOfWork.TacGiaRepository.GetById(maTacGia);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy tác giả theo mã: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<TacGia> Find(Func<TacGia, bool> predicate)
        {
            try
            {
                return _unitOfWork.TacGiaRepository.GetAll().Where(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm tác giả: " + ex.Message);
                return new List<TacGia>();
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(TacGia tacGia)
        {
            try
            {
                if (tacGia == null)
                    return false;

                _unitOfWork.TacGiaRepository.Add(tacGia);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm tác giả: " + ex.Message);
                return false;
            }
        }

        public bool Update(TacGia tacGia)
        {
            try
            {
                if (tacGia == null)
                    return false;

                _unitOfWork.TacGiaRepository.Update(tacGia);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật tác giả: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maTacGia)
        {
            try
            {
                var tg = _unitOfWork.TacGiaRepository.GetById(maTacGia);
                if (tg == null)
                    return false;

                _unitOfWork.TacGiaRepository.Delete(tg);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa tác giả: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<TacGia>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.TacGiaRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách tác giả (async): " + ex.Message);
                return new List<TacGia>();
            }
        }

        public async Task<TacGia> GetByIdAsync(string maTacGia)
        {
            try
            {
                return await _unitOfWork.TacGiaRepository.GetByIdAsync(maTacGia);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy tác giả theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(TacGia tacGia)
        {
            try
            {
                if (tacGia == null)
                    return false;

                _unitOfWork.TacGiaRepository.Add(tacGia);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm tác giả (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TacGia tacGia)
        {
            try
            {
                if (tacGia == null)
                    return false;

                _unitOfWork.TacGiaRepository.Update(tacGia);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật tác giả (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maTacGia)
        {
            try
            {
                var tg = await _unitOfWork.TacGiaRepository.GetByIdAsync(maTacGia);
                if (tg == null)
                    return false;

                _unitOfWork.TacGiaRepository.Delete(tg);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa tác giả (async): " + ex.Message);
                return false;
            }
        }
    }

}
