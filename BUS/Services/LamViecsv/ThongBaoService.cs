using PM.DAL;
using PM.DAL.Interfaces;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PM.BUS.Services
{
    public class ThongBaoService
    {
        private readonly IUnitOfWork _unitOfWork;


    public ThongBaoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ==================== LẤY DỮ LIỆU ====================
        public IEnumerable<ThongBao> GetAll()
        {
            try
            {
                return _unitOfWork.ThongBaoRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách thông báo: " + ex.Message);
                return new List<ThongBao>();
            }
        }

        public ThongBao GetById(string maThongBao)
        {
            try
            {
                return _unitOfWork.ThongBaoRepository.GetById(maThongBao);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông báo: " + ex.Message);
                return null;
            }
        }
        // Lấy danh sách thông báo dành cho người nhận (hoặc ALL)
        public List<ThongBao> GetAllThongBaoChung()
        {
            try
            {
                return _unitOfWork.ThongBaoRepository
                        .Find(tb => tb.NguoiNhan == "ALL")
                        .OrderByDescending(tb => tb.NgayGui)
                        .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách thông báo chung: " + ex.Message);
                return new List<ThongBao>();
            }
        }


        // ==================== THÊM ====================
        public bool Add(ThongBao thongBao)
        {
            try
            {
                if (thongBao == null) return false;
                thongBao.NgayGui = DateTime.Now;
                _unitOfWork.ThongBaoRepository.Add(thongBao);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm thông báo: " + ex.Message);
                return false;
            }
        }

       

      

        // ==================== BẤT ĐỒNG BỘ ====================
        public async Task<IEnumerable<ThongBao>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.ThongBaoRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách thông báo (async): " + ex.Message);
                return new List<ThongBao>();
            }
        }

        public async Task<ThongBao> GetByIdAsync(string maThongBao)
        {
            try
            {
                return await _unitOfWork.ThongBaoRepository.GetByIdAsync(maThongBao);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông báo (async): " + ex.Message);
                return null;
            }
        }

        public async Task<bool> AddAsync(ThongBao thongBao)
        {
            try
            {
                if (thongBao == null) return false;
                thongBao.NgayGui = DateTime.Now;
                _unitOfWork.ThongBaoRepository.Add(thongBao);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm thông báo (async): " + ex.Message);
                return false;
            }
        }


    }
       


}
