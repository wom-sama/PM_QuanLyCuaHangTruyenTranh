using PM.BUS.Services.LamViecsv;
using PM.DAL;
using PM.DAL.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class CaLam : UserControl
    {
        private readonly PhanCongService _phanCongService;
        private readonly string _maNhanVien;

        public CaLam(string maNhanVien = null)
        {
            InitializeComponent();
            _maNhanVien = maNhanVien;

            _phanCongService = new PhanCongService(new UnitOfWork());
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var data = _phanCongService.GetAll();

                if (!string.IsNullOrEmpty(_maNhanVien))
                {
                    data = data.Where(p => p.MaNV == _maNhanVien);
                }

                dgvCaLam.DataSource = data
                    .Select(p => new
                    {
                        p.MaPhanCong,
                        p.TenCongViec,
                        p.MoTa,
                        NgayBatDau = p.NgayBatDau.ToString("dd/MM/yyyy"),
                        NgayKetThuc = p.NgayKetThuc.HasValue ? p.NgayKetThuc.Value.ToString("dd/MM/yyyy") : "Chưa kết thúc",
                        TrangThai = p.HoanThanh ? "Hoàn thành" : "Đang làm"
                    })
                    .ToList();

                lblNhanVien.Text = string.IsNullOrEmpty(_maNhanVien)
                    ? "Tất cả nhân viên"
                    : $"Nhân viên: {_maNhanVien}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ca làm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
