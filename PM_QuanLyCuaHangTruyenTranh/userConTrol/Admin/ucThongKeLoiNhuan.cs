using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PM.BUS.Services.DonHangsv;
using PM.BUS.Services.TaiKhoansv;
using PM.BUS.Services.VanChuyensv;
using PM.DAL;

namespace PM.GUI.userConTrol.Admin
{
    public partial class ucThongKeLoiNhuan : UserControl
    {
        private readonly DonHangService _donHangService;
        private readonly CT_DonHangService _ctDonHangService;
        private readonly NhanVienService _nhanVienService;
        private readonly CT_NhapKhoService _ctNhapKhoService;
        private readonly NhapKhoService _nhapKhoService;

        public ucThongKeLoiNhuan()
        {
            InitializeComponent();

            // Khởi tạo UnitOfWork
            var unitOfWork = new UnitOfWork();

            // Khởi tạo service với UnitOfWork
            _donHangService = new DonHangService(unitOfWork);
            _ctDonHangService = new CT_DonHangService(unitOfWork);
            _nhanVienService = new NhanVienService(unitOfWork);
            _ctNhapKhoService = new CT_NhapKhoService(unitOfWork);
            _nhapKhoService = new NhapKhoService(unitOfWork);

            LoadChiNhanh();
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
        }

        private void LoadChiNhanh()
        {
            var listChiNhanh = _nhanVienService.GetAll()
                .Where(nv => nv.ChiNhanh != null && nv.ChiNhanh.TrangThai)
                .Select(nv => nv.ChiNhanh)
                .Distinct()
                .Select(c => new { c.MaChiNhanh, c.TenChiNhanh })
                .ToList();

            cmbChiNhanh.DataSource = listChiNhanh;
            cmbChiNhanh.DisplayMember = "TenChiNhanh";
            cmbChiNhanh.ValueMember = "MaChiNhanh";
            cmbChiNhanh.SelectedIndex = -1;
        }

        private async void btnThongKe_Click(object sender, EventArgs e)
        {
            string maCN = cmbChiNhanh.SelectedValue?.ToString();
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;

            var donHangs = (await _donHangService.GetAllAsync())
                .Where(dh => dh.NgayDat >= fromDate && dh.NgayDat <= toDate);

            if (!string.IsNullOrEmpty(maCN))
            {
                donHangs = donHangs
                    .Where(dh => dh.NhanVien != null && dh.NhanVien.MaChiNhanh == maCN);
            }

            var donHangIds = donHangs.Select(dh => dh.MaDonHang).ToList();

            var ctDonHangs = (await _ctDonHangService.GetAllAsync())
                .Where(ct => donHangIds.Contains(ct.MaDonHang))
                .ToList();

            var result = ctDonHangs.Select(ct =>
            {
                // Lấy chi tiết nhập kho gần nhất cho sách này
                var nhapKho = (from ctNk in _ctNhapKhoService.GetAll()
                               join nk in _nhapKhoService.GetAll() on ctNk.MaPhieuNhap equals nk.MaPhieuNhap
                               where ctNk.MaSach == ct.MaSach
                               orderby nk.NgayNhap descending
                               select ctNk)
                              .FirstOrDefault();

                decimal chiPhi = (nhapKho?.DonGia ?? 0) * ct.SoLuong;

                return new
                {
                    ct.MaDonHang,
                    NgayDat = ct.DonHang?.NgayDat ?? DateTime.MinValue,
                    TenSach = ct.Sach?.TenSach ?? "Không xác định",
                    SoLuongBan = ct.SoLuong,
                    DoanhThu = ct.ThanhTien,
                    ChiPhi = chiPhi,
                    LoiNhuan = ct.ThanhTien - chiPhi
                };
            })
            .OrderBy(r => r.NgayDat)
            .ToList();

            dgvLoiNhuan.DataSource = result;

            lblTongDoanhThu.Text = $"Tổng doanh thu: {result.Sum(r => r.DoanhThu):n0} VNĐ";
            lblTongChiPhi.Text = $"Tổng chi phí: {result.Sum(r => r.ChiPhi):n0} VNĐ";
            lblTongLoiNhuan.Text = $"Tổng lợi nhuận: {result.Sum(r => r.LoiNhuan):n0} VNĐ";
        }
    }
}
