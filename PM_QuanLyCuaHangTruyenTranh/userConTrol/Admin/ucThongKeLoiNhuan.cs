using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PM.DAL.Models;

namespace PM.GUI.userConTrol.Admin
{
    public partial class ucThongKeLoiNhuan : UserControl
    {
        private AppDbContext _context;

        public ucThongKeLoiNhuan()
        {
            InitializeComponent();
            _context = new AppDbContext();

            LoadChiNhanh();
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
        }

        // Load danh sách chi nhánh vào ComboBox
        private void LoadChiNhanh()
        {
            var listChiNhanh = _context.ChiNhanhs
                .Where(c => c.TrangThai)
                .Select(c => new { c.MaChiNhanh, c.TenChiNhanh })
                .ToList();

            cmbChiNhanh.DataSource = listChiNhanh;
            cmbChiNhanh.DisplayMember = "TenChiNhanh";
            cmbChiNhanh.ValueMember = "MaChiNhanh";
            cmbChiNhanh.SelectedIndex = -1; // không chọn mặc định
        }

        // Xử lý nút Thống kê
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string maCN = cmbChiNhanh.SelectedValue?.ToString();
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;

            // Lấy danh sách đơn hàng theo chi nhánh và khoảng thời gian
            var query = _context.CT_DonHangs
                .Where(ct => ct.DonHang.NgayDat >= fromDate && ct.DonHang.NgayDat <= toDate);

            if (!string.IsNullOrEmpty(maCN))
            {
                query = query.Where(ct => ct.DonHang.NhanVien.MaChiNhanh == maCN);
            }

            var result = query
                .Select(ct => new
                {
                    ct.MaDonHang,
                    ct.DonHang.NgayDat,
                    TenSach = ct.Sach.TenSach,
                    SoLuongBan = ct.SoLuong,
                    DoanhThu = ct.ThanhTien,
                    // Lấy giá nhập từ CT_NhapKho tương ứng
                    ChiPhi = _context.CT_NhapKhos
                        .Where(nk => nk.MaSach == ct.MaSach)
                        .Select(nk => nk.DonGia * ct.SoLuong)
                        .FirstOrDefault(),
                    LoiNhuan = ct.ThanhTien - _context.CT_NhapKhos
                        .Where(nk => nk.MaSach == ct.MaSach)
                        .Select(nk => nk.DonGia * ct.SoLuong)
                        .FirstOrDefault()
                })
                .OrderBy(r => r.NgayDat)
                .ToList();

            dgvLoiNhuan.DataSource = result;
        }
    }
}