using iTextSharp.text;
using iTextSharp.text.pdf;
using PM.DAL.Models;
using System;
using System.IO;

namespace PM.BUS.Helpers
{
    public static class PDFHelper
    {
        /// <summary>
        /// Xuất hóa đơn ra file PDF từ đối tượng DonHang
        /// </summary>
        public static void XuatHoaDon(DonHang donHang, string filePath)
        {
            if (donHang == null)
                throw new ArgumentNullException(nameof(donHang), "Hóa đơn không hợp lệ!");

            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            var titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
            var normalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            Paragraph header = new Paragraph("CỬA HÀNG TRUYỆN TRANH MANGA PLUS", titleFont)
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(header);

            Paragraph subHeader = new Paragraph("HÓA ĐƠN BÁN TRUYỆN", titleFont)
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(subHeader);

            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph($"Mã đơn: {donHang.MaDonHang}", normalFont));
            doc.Add(new Paragraph($"Ngày lập: {donHang.NgayDat:dd/MM/yyyy HH:mm}", normalFont));
            doc.Add(new Paragraph($"Nhân viên: {donHang.MaNV}", normalFont));
            doc.Add(new Paragraph("\n"));

            PdfPTable table = new PdfPTable(4)
            {
                WidthPercentage = 100
            };
            table.AddCell("Tên sách");
            table.AddCell("Số lượng");
            table.AddCell("Đơn giá");
            table.AddCell("Thành tiền");

            foreach (var ct in donHang.CT_DonHangs)
            {
                table.AddCell(ct.Sach?.TenSach ?? "(Không rõ)");
                table.AddCell(ct.SoLuong.ToString());
                table.AddCell(ct.DonGia.ToString("N0"));
                table.AddCell(ct.ThanhTien.ToString("N0"));
            }

            doc.Add(table);
            doc.Add(new Paragraph($"\nTổng cộng: {donHang.TongTien:N0} đ", normalFont));
            doc.Add(new Paragraph("\n❤ Cảm ơn quý khách đã mua hàng!", normalFont));
            doc.Close();
        }
    }
}
