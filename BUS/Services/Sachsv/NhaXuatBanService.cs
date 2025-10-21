using PM.DAL;
using PM.DAL.Models;
using PM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services.Sachsv
{
    public class NhaXuatBanService
    {
        private readonly IUnitOfWork _unitOfWork;

    public NhaXuatBanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================

        public IEnumerable<NhaXuatBan> GetAll()
        {
            try
            {
                return _unitOfWork.NhaXuatBanRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách NXB: " + ex.Message);
                return new List<NhaXuatBan>();
            }
        }

        public NhaXuatBan GetById(string maNXB)
        {
            try
            {
                return _unitOfWork.NhaXuatBanRepository.GetById(maNXB);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy NXB theo mã: " + ex.Message);
                return null;
            }
        }

        public IEnumerable<NhaXuatBan> Find(Func<NhaXuatBan, bool> predicate)
        {
            try
            {
                return _unitOfWork.NhaXuatBanRepository.GetAll().Where(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm NXB: " + ex.Message);
                return new List<NhaXuatBan>();
            }
        }

        // ==================== THÊM / SỬA / XÓA ====================

        public bool Add(NhaXuatBan nxb)
        {
            try
            {
                if (nxb == null)
                    return false;

                _unitOfWork.NhaXuatBanRepository.Add(nxb);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm NXB: " + ex.Message);
                return false;
            }
        }

        public bool Update(NhaXuatBan nxb)
        {
            try
            {
                if (nxb == null)
                    return false;

                _unitOfWork.NhaXuatBanRepository.Update(nxb);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật NXB: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maNXB)
        {
            try
            {
                var nxb = _unitOfWork.NhaXuatBanRepository.GetById(maNXB);
                if (nxb == null)
                    return false;

                _unitOfWork.NhaXuatBanRepository.Delete(nxb);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa NXB: " + ex.Message);
                return false;
            }
        }

        // ==================== BẤT ĐỒNG BỘ ====================

        public async Task<IEnumerable<NhaXuatBan>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.NhaXuatBanRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách NXB (async): " + ex.Message);
                return new List<NhaXuatBan>();
            }
        }

        public async Task<NhaXuatBan> GetByIdAsync(string maNXB)
        {
            try
            {
                return await _unitOfWork.NhaXuatBanRepository.GetByIdAsync(maNXB);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy NXB theo mã (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(NhaXuatBan nxb)
        {
            try
            {
                if (nxb == null)
                    return false;

                _unitOfWork.NhaXuatBanRepository.Add(nxb);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm NXB (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(NhaXuatBan nxb)
        {
            try
            {
                if (nxb == null)
                    return false;

                _unitOfWork.NhaXuatBanRepository.Update(nxb);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật NXB (async): " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string maNXB)
        {
            try
            {
                var nxb = await _unitOfWork.NhaXuatBanRepository.GetByIdAsync(maNXB);
                if (nxb == null)
                    return false;

                _unitOfWork.NhaXuatBanRepository.Delete(nxb);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa NXB (async): " + ex.Message);
                return false;
            }
        }
    }

}
