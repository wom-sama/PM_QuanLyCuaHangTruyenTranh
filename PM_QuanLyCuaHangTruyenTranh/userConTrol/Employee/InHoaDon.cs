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
            : this(maDon)
        {
            this.TienKhachDua = tienKhachDua;
            this.TienThua = tienThua;

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

            dataGridViewCT.DataSource = don.CT_DonHangs.Select(ct => new
            {
                Tên_Sách = ct.Sach?.TenSach ?? "(Không rõ)",
                Số_Lượng = ct.SoLuong,
                Đơn_Giá = ct.DonGia,
                Thành_Tiền = ct.ThanhTien
            }).ToList();

            lblTongTien.Text = $"Tổng cộng: {don.TongTien:N0} đ";
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
                    // Dùng font Unicode hỗ trợ tiếng Việt tốt
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "tahoma.ttf");
                    var baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    var font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

                    using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        // Tăng margin để không bị cắt chữ
                        var document = new Document(PageSize.A4, 40, 40, 40, 40);
                        PdfWriter.GetInstance(document, fs);
                        document.Open();

                        // ======= PHẦN TIÊU ĐỀ =======
                        Paragraph title = new Paragraph("CỬA HÀNG TRUYỆN TRANH MANGA PLUS", font);
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 8f;
                        document.Add(title);

                        Paragraph subtitle = new Paragraph("HÓA ĐƠN BÁN TRUYỆN", font);
                        subtitle.Alignment = Element.ALIGN_CENTER;
                        subtitle.SpacingAfter = 15f;
                        document.Add(subtitle);

                        // ======= THÔNG TIN HÓA ĐƠN =======
                        Paragraph thongtin = new Paragraph($"Mã đơn: {don.MaDonHang}\n" +
                                                            $"Ngày lập: {don.NgayDat:dd/MM/yyyy HH:mm}\n" +
                                                            $"Nhân viên: {don.MaNV}", font);
                        thongtin.SpacingAfter = 15f;
                        document.Add(thongtin);

                        // ======= BẢNG SẢN PHẨM =======
                        PdfPTable table = new PdfPTable(4) { WidthPercentage = 100 };
                        table.SetWidths(new float[] { 40f, 15f, 20f, 25f });

                        // Header
                        string[] headers = { "Tên Sách", "Số Lượng", "Đơn Giá", "Thành Tiền" };
                        foreach (var header in headers)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(header, font))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5f,
                                BackgroundColor = new BaseColor(230, 230, 230)
                            };
                            table.AddCell(cell);
                        }

                        // Dữ liệu chi tiết
                        foreach (var ct in don.CT_DonHangs)
                        {
                            table.AddCell(new Phrase(ct.Sach?.TenSach ?? "(Không rõ)", font));
                            table.AddCell(new Phrase(ct.SoLuong.ToString(), font));
                            table.AddCell(new Phrase(ct.DonGia.ToString("N0"), font));
                            table.AddCell(new Phrase(ct.ThanhTien.ToString("N0"), font));
                        }

                        table.SpacingAfter = 15f;
                        document.Add(table);

                        // ======= TỔNG KẾT =======
                        Paragraph summary = new Paragraph(
                            $"Tổng cộng: {don.TongTien:N0} đ\n" +
                            $"Tiền khách đưa: {TienKhachDua:N0} đ\n" +
                            $"Tiền thừa: {TienThua:N0} đ", font);
                        summary.Alignment = Element.ALIGN_RIGHT;
                        summary.SpacingAfter = 20f;
                        document.Add(summary);

                        // ======= LỜI CẢM ƠN =======
                        Paragraph thank = new Paragraph("❤ Cảm ơn quý khách đã mua hàng!", font);
                        thank.Alignment = Element.ALIGN_CENTER;
                        thank.SpacingBefore = 10f;
                        document.Add(thank);

                        document.Close();
                    }

                    MessageBox.Show("✅ Xuất hóa đơn PDF thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Xuất hóa đơn thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
