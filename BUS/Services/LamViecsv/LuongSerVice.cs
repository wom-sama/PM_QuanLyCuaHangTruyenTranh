using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.DAL.Models;
using PM.DAL;
using PM.DAL.Interfaces;

namespace BUS.Services.LamViecsv
{
    public class LuongService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LuongService()
        {
            _unitOfWork = new UnitOfWork();
        }

        // 🔹 Lấy danh sách bảng lương
        public IEnumerable<BangLuong> GetAll()
        {
            return _unitOfWork.BangLuongRepository.GetAll();
        }

        // 🔹 Tính lương cho 1 nhân viên
        public BangLuong TinhLuong(string maNV, decimal luongCoBan, decimal phuCap, decimal thuong, decimal khauTru, DateTime thangTinhLuong)
        {
            var bangLuong = new BangLuong
            {
                MaNV = maNV,
                LuongCoBan = luongCoBan,
                PhuCap = phuCap,
                Thuong = thuong,
                KhauTru = khauTru,
                ThangTinhLuong = thangTinhLuong
            };

            _unitOfWork.BangLuongRepository.Add(bangLuong);
            _unitOfWork.Save();

            return bangLuong;
        }

        // 🔹 Thêm bảng lương
        public void Add(BangLuong bangLuong)
        {
            _unitOfWork.BangLuongRepository.Add(bangLuong);
            _unitOfWork.Save();
        }

        // 🔹 Sửa bảng lương
        public void Update(BangLuong bangLuong)
        {
            var existing = _unitOfWork.BangLuongRepository.GetById(bangLuong.MaBangLuong);
            if (existing != null)
            {
                existing.LuongCoBan = bangLuong.LuongCoBan;
                existing.PhuCap = bangLuong.PhuCap;
                existing.Thuong = bangLuong.Thuong;
                existing.KhauTru = bangLuong.KhauTru;
                existing.ThangTinhLuong = bangLuong.ThangTinhLuong;
                existing.MaNV = bangLuong.MaNV;

                _unitOfWork.BangLuongRepository.Update(existing);
                _unitOfWork.Save();
            }
        }

        // 🔹 Xóa bảng lương
        public void Delete(int maBangLuong)
        {
            var existing = _unitOfWork.BangLuongRepository.GetById(maBangLuong);
            if (existing != null)
            {
                _unitOfWork.BangLuongRepository.Delete(existing);
                _unitOfWork.Save();
            }
        }

        // 🔹 Tính tổng lương cho tất cả nhân viên trong tháng
        public decimal TongLuongTheoThang(DateTime thang)
        {
            var list = _unitOfWork.BangLuongRepository
                .GetAll()
                .Where(b => b.ThangTinhLuong.Month == thang.Month && b.ThangTinhLuong.Year == thang.Year)
                .ToList();

            return list.Sum(b => b.TongLuong);
        }

        // 🔹 Tìm bảng lương theo mã nhân viên
        public IEnumerable<BangLuong> FindByMaNV(string maNV)
        {
            return _unitOfWork.BangLuongRepository
                            .GetAll()
                            .Where(b => b.MaNV == maNV);
        }
    }
}