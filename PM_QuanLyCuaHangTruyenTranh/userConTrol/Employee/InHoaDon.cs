using PM.BUS;
using PM.BUS.Helpers;
using PM.BUS.Services;
using PM.BUS.Services.DonHangsv;
using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;


namespace PM.GUI.userConTrol.Employee
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
                try
                {
                    // 1️⃣ Đường dẫn font Unicode
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    var baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);
                    var font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

                    // 2️⃣ Tạo PDF
                    using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20);
                        iTextSharp.text.pdf.PdfWriter.GetInstance(document, fs);
                        document.Open();

                        // 3️⃣ Thông tin hóa đơn
                        document.Add(new iTextSharp.text.Paragraph("🏪 CỬA HÀNG TRUYỆN TRANH MANGA PLUS", font));
                        document.Add(new iTextSharp.text.Paragraph("HÓA ĐƠN BÁN TRUYỆN", font));
                        document.Add(new iTextSharp.text.Paragraph($"Mã đơn: {don.MaDonHang}", font));
                        document.Add(new iTextSharp.text.Paragraph($"Ngày lập: {don.NgayDat:dd/MM/yyyy HH:mm}", font));
                        document.Add(new iTextSharp.text.Paragraph($"Nhân viên: {don.MaNV}", font));
                        document.Add(new iTextSharp.text.Paragraph("❤ Cảm ơn quý khách đã mua hàng!", font));
                        document.Add(new iTextSharp.text.Paragraph(" ")); // xuống dòng

                        // 4️⃣ Bảng chi tiết
                        var table = new iTextSharp.text.pdf.PdfPTable(4) { WidthPercentage = 100 };
                        table.AddCell(new iTextSharp.text.Phrase("Tên Sách", font));
                        table.AddCell(new iTextSharp.text.Phrase("Số Lượng", font));
                        table.AddCell(new iTextSharp.text.Phrase("Đơn Giá", font));
                        table.AddCell(new iTextSharp.text.Phrase("Thành Tiền", font));

                        foreach (var ct in don.CT_DonHangs)
                        {
                            table.AddCell(new iTextSharp.text.Phrase(ct.Sach?.TenSach ?? "(Không rõ)", font));
                            table.AddCell(new iTextSharp.text.Phrase(ct.SoLuong.ToString(), font));
                            table.AddCell(new iTextSharp.text.Phrase(ct.DonGia.ToString("N0"), font));
                            table.AddCell(new iTextSharp.text.Phrase(ct.ThanhTien.ToString("N0"), font));
                        }

                        document.Add(table);

                        // 5️⃣ Tổng tiền
                        document.Add(new iTextSharp.text.Paragraph($"Tổng cộng: {don.TongTien:N0} đ", font));

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
