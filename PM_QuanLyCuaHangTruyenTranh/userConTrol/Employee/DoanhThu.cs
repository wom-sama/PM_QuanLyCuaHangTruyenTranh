using PM.BUS.Services.DonHangsv;
using PM.BUS.Services.VanChuyensv;
using PM.DAL;
using PM.DAL.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class DoanhThu : UserControl
    {
        private readonly DonHangService _donHangService;
        private readonly CT_DonHangService _ctDonHangService;
        private readonly CT_NhapKhoService _ctNhapKhoService;
        private readonly NhapKhoService _nhapKhoService;

        private readonly NhanVien _currentNV;

        public DoanhThu(NhanVien nv)
        {
            InitializeComponent();
            _currentNV = nv;

            var unitOfWork = new UnitOfWork();
            _donHangService = new DonHangService(unitOfWork);
            _ctDonHangService = new CT_DonHangService(unitOfWork);
            _ctNhapKhoService = new CT_NhapKhoService(unitOfWork);
            _nhapKhoService = new NhapKhoService(unitOfWork);

            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;

            LoadDoanhThu();
        }

        private async void LoadDoanhThu()
        {
            var result = await _ctDonHangService.TinhDoanhThuLoiNhuanAsync(_currentNV.MaChiNhanh, dtpFrom.Value.Date, dtpTo.Value.Date);
            dgvDoanhThu.DataSource = result;

            lblTongDoanhThu.Text = $"Tổng doanh thu: {result.Sum(r => r.DoanhThu):n0} VNĐ";
            lblTongChiPhi.Text = $"Tổng chi phí: {result.Sum(r => r.ChiPhi):n0} VNĐ";
            lblTongLoiNhuan.Text = $"Tổng lợi nhuận: {result.Sum(r => r.LoiNhuan):n0} VNĐ";
            lblTongSoLuongBan.Text = $"Tổng số lượng bán: {result.Sum(r => r.SoLuongBan)}";
        }



        private void btnThongKeLoiNhuan_Click(object sender, EventArgs e)
        {
            LoadDoanhThu();
        }
    }
}
