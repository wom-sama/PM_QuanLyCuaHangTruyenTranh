using PM.BUS;
using PM.BUS.Helpers;
using PM.BUS.Services;
using PM.BUS.Services.DonHangsv;
using System;
using System.Windows.Forms;
using System.Linq;


namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee
{
    public partial class InHoaDon : UserControl
    {
        private readonly DonHangService _donHangService;
        private string _maDonHienTai;
        public InHoaDon(string maDon)
        {
            InitializeComponent();
            _donHangService = new DonHangService();  // ✅ BUS tự tạo UoW
            _maDonHienTai = maDon;
            LoadHoaDon(maDon);
        }

        private void LoadHoaDon(string maDon)
        {
            var don = _donHangService.GetById(maDon);
            if (don == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblTenCuaHang.Text = "🏪 CỬA HÀNG TRUYỆN TRANH MANGA PLUS";
            lblTieuDe.Text = "HÓA ĐƠN BÁN TRUYỆN";
            lblMaDon.Text = $"Mã đơn: {don.MaDonHang}";
            lblNgayLap.Text = $"Ngày lập: {don.NgayDat:dd/MM/yyyy HH:mm}";
            lblNhanVien.Text = $"Nhân viên: {don.MaNV}";
            lblCamOn.Text = "❤ Cảm ơn quý khách đã mua hàng!";

            dataGridViewCT.DataSource = don.CT_DonHangs.Select(ct => new
            {
                Tên_Sách = ct.Sach?.TenSach ?? "(Không rõ)",
                Số_Lượng = ct.SoLuong,
                Đơn_Giá = ct.DonGia,
                Thành_Tiền = ct.ThanhTien
            }).ToList();

            lblTongTien.Text = $"Tổng cộng: {don.TongTien:N0} đ";
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            var don = _donHangService.GetById(_maDonHienTai);
            if (don == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF file|*.pdf",
                FileName = $"HoaDon_{_maDonHienTai}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PDFHelper.XuatHoaDon(don, sfd.FileName);
                MessageBox.Show("✅ Xuất hóa đơn PDF thành công!", "Thành công");
            }
        }
    }
}
