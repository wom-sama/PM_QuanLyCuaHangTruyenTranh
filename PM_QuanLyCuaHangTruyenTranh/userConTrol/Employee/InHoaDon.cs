using PM.BUS;
using PM.BUS.Helpers;
using PM.BUS.Services;
using PM.BUS.Services.DonHangsv;
using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace PM.GUI.userConTrol.Employee
{
    public partial class InHoaDon : UserControl
    {
        private decimal TienKhachDua;
        private decimal TienThua;
        private readonly DonHangService _donHangService;
        private string _maDonHienTai;

        // Constructor 1 tham số
        public InHoaDon(string maDon)
        {
            InitializeComponent();
            _donHangService = new DonHangService();
            _maDonHienTai = maDon;
            LoadHoaDon(maDon);
        }

        // Constructor 3 tham số (mới)
        public InHoaDon(string maDon, decimal tienKhachDua, decimal tienThua)
            : this(maDon) // gọi constructor 1 tham số
        {
            this.TienKhachDua = tienKhachDua;
            this.TienThua = tienThua;

            // Nếu muốn hiển thị luôn lên label
            lblTienKhachDua.Text = $"Tiền khách đưa: {TienKhachDua:N0} đ";
            lblTienThua.Text = $"Tiền thừa: {TienThua:N0} đ";
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

            // Nếu constructor 3 tham số đã truyền, hiển thị luôn
            lblTienKhachDua.Text = $"Tiền khách đưa: {TienKhachDua:N0} đ";
            lblTienThua.Text = $"Tiền thừa: {TienThua:N0} đ";
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
                try
                {
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    var baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    // Dùng alias Font đã khai báo
                    var font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);



                    using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        var document = new Document(PageSize.A4, 20, 20, 20, 20);
                        PdfWriter.GetInstance(document, fs);
                        document.Open();

                        document.Add(new Paragraph("🏪 CỬA HÀNG TRUYỆN TRANH MANGA PLUS", font));
                        document.Add(new Paragraph("HÓA ĐƠN BÁN TRUYỆN", font));
                        document.Add(new Paragraph($"Mã đơn: {don.MaDonHang}", font));
                        document.Add(new Paragraph($"Ngày lập: {don.NgayDat:dd/MM/yyyy HH:mm}", font));
                        document.Add(new Paragraph($"Nhân viên: {don.MaNV}", font));
                        document.Add(new Paragraph("❤ Cảm ơn quý khách đã mua hàng!", font));
                        document.Add(new Paragraph(" "));

                        var table = new PdfPTable(4) { WidthPercentage = 100 };
                        table.AddCell(new Phrase("Tên Sách", font));
                        table.AddCell(new Phrase("Số Lượng", font));
                        table.AddCell(new Phrase("Đơn Giá", font));
                        table.AddCell(new Phrase("Thành Tiền", font));

                        foreach (var ct in don.CT_DonHangs)
                        {
                            table.AddCell(new Phrase(ct.Sach?.TenSach ?? "(Không rõ)", font));
                            table.AddCell(new Phrase(ct.SoLuong.ToString(), font));
                            table.AddCell(new Phrase(ct.DonGia.ToString("N0"), font));
                            table.AddCell(new Phrase(ct.ThanhTien.ToString("N0"), font));
                        }

                        document.Add(table);

                        document.Add(new Paragraph($"Tổng cộng: {don.TongTien:N0} đ", font));
                        document.Add(new Paragraph($"Tiền khách đưa: {TienKhachDua:N0} đ", font));
                        document.Add(new Paragraph($"Tiền thừa: {TienThua:N0} đ", font));

                        document.Close();
                    }

                    MessageBox.Show("✅ Xuất hóa đơn PDF thành công!", "Thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Xuất hóa đơn thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
