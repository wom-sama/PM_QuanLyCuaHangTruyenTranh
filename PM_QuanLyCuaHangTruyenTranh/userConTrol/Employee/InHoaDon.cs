using iTextSharp.text;
using iTextSharp.text.pdf;
using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee
{
    public partial class InHoaDon : UserControl
    {
        private AppDbContext db = new AppDbContext();
        private string currentMaDon;

        public InHoaDon(string maDon)
        {
            InitializeComponent();
            currentMaDon = maDon;
            LoadHoaDon(maDon);
        }

        private void LoadHoaDon(string maDon)
        {
            var don = db.DonHangs
                        .Include("CT_DonHangs.Sach")
                        .FirstOrDefault(d => d.MaDonHang == maDon);

            if (don == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng!");
                return;
            }

            lblTenCuaHang.Text = "🏪 CỬA HÀNG TRUYỆN TRANH MANGA PLUS";
            lblTieuDe.Text = "HÓA ĐƠN BÁN TRUYỆN";
            lblMaDon.Text = $"Mã đơn: {don.MaDonHang}";
            lblNgayLap.Text = $"Ngày lập: {don.NgayDat:dd/MM/yyyy HH:mm}";
            lblNhanVien.Text = $"Nhân viên: {don.MaNV}";
            lblCamOn.Text = "❤ Cảm ơn quý khách đã mua hàng!";

            var data = don.CT_DonHangs.Select(ct => new
            {
                Tên_Sách = ct.Sach.TenSach,
                Số_Lượng = ct.SoLuong,
                Đơn_Giá = ct.DonGia,
                Thành_Tiền = ct.ThanhTien
            }).ToList();

            dataGridViewCT.DataSource = data;
            dataGridViewCT.Columns["Đơn_Giá"].DefaultCellStyle.Format = "N0";
            dataGridViewCT.Columns["Thành_Tiền"].DefaultCellStyle.Format = "N0";

            lblTongTien.Text = $"Tổng cộng: {don.TongTien:N0} đ";
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            ExportToPDF(currentMaDon);
        }

        private void ExportToPDF(string maDon)
        {
            var don = db.DonHangs
                        .Include("CT_DonHangs.Sach")
                        .FirstOrDefault(d => d.MaDonHang == maDon);
            if (don == null) return;

            // Chọn nơi lưu file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF file|*.pdf";
            sfd.FileName = $"HoaDon_{maDon}.pdf";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            // Tạo tài liệu PDF
            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
            doc.Open();

            // Font chữ
            var titleFont = iTextSharp.text.FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD);
            var normalFont = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL);


            // Tiêu đề
            Paragraph header = new Paragraph("CỬA HÀNG TRUYỆN TRANH MANGA PLUS", titleFont);
            header.Alignment = Element.ALIGN_CENTER;
            doc.Add(header);

            Paragraph subHeader = new Paragraph("HÓA ĐƠN BÁN TRUYỆN", titleFont);
            subHeader.Alignment = Element.ALIGN_CENTER;
            doc.Add(subHeader);

            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph($"Mã đơn: {don.MaDonHang}", normalFont));
            doc.Add(new Paragraph($"Ngày lập: {don.NgayDat:dd/MM/yyyy HH:mm}", normalFont));
            doc.Add(new Paragraph($"Nhân viên: {don.MaNV}", normalFont));
            doc.Add(new Paragraph("\n"));

            // Bảng chi tiết
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.AddCell("Tên sách");
            table.AddCell("Số lượng");
            table.AddCell("Đơn giá");
            table.AddCell("Thành tiền");

            foreach (var ct in don.CT_DonHangs)
            {
                table.AddCell(ct.Sach.TenSach);
                table.AddCell(ct.SoLuong.ToString());
                table.AddCell(ct.DonGia.ToString("N0"));
                table.AddCell(ct.ThanhTien.ToString("N0"));
            }

            doc.Add(table);
            doc.Add(new Paragraph($"\nTổng cộng: {don.TongTien:N0} đ", normalFont));
            doc.Add(new Paragraph("\n❤ Cảm ơn quý khách đã mua hàng!", normalFont));
            doc.Close();

            MessageBox.Show("Xuất hóa đơn PDF thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
