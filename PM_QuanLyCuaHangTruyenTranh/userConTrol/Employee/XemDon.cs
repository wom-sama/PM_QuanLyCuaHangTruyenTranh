using PM.BUS.Services.Facade;
using PM.DAL.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class XemDon : UserControl
    {
        private readonly QuanLyDonHangBUS _bus = new QuanLyDonHangBUS();
        private readonly NhanVien _currentNV;
        public XemDon(NhanVien nv)
        {
            InitializeComponent();
            _currentNV = nv;
            this.Load += XemDon_Load;
        }

        private void XemDon_Load(object sender, EventArgs e)
        {
            // Đặt format ngày theo kiểu Việt Nam
            dtTuNgay.Format = DateTimePickerFormat.Custom;
            dtTuNgay.CustomFormat = "dd/MM/yyyy";

            dtDenNgay.Format = DateTimePickerFormat.Custom;
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            LoadDonHang();
            CapNhatSoLuongBadge();
            TinhChinhDataGridView();
        }

        private void LoadDonHang(string trangThai = null)
        {
            try
            {
                // ✅ Lấy danh sách đơn hàng theo chi nhánh của nhân viên
                guna2DataGridView1.DataSource = _bus.LayDanhSachDonHangTheoTrangThai(trangThai, _currentNV.MaChiNhanh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tải danh sách đơn hàng: " + ex.Message);
            }
            
        }

        private void TinhChinhDataGridView()
        {
            var dgv = guna2DataGridView1;

            dgv.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgv.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgv.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(225, 240, 255);
            dgv.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(0, 122, 204);
            dgv.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgv.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
            dgv.RowTemplate.Height = 30;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(240, 240, 240);
        }

        private void CapNhatSoLuongBadge()
        {
            string maCN = _currentNV.MaChiNhanh;

            int tatCa = _bus.LayDanhSachDonHangTheoTrangThai(null, maCN).Count();
            int dangXuLy = _bus.LayDanhSachDonHangTheoTrangThai("Chờ xử lý", maCN).Count();
            int dangGiao = _bus.LayDanhSachDonHangTheoTrangThai("Đang giao", maCN).Count();
            int daGiao = _bus.LayDanhSachDonHangTheoTrangThai("Đã giao", maCN).Count();
            int daBan = _bus.LayDanhSachDonHangTheoTrangThai("Đã thanh toán", maCN).Count();
            int khongDuyet = _bus.LayDanhSachDonHangTheoTrangThai("Không duyệt", maCN).Count();
            int daHuy = _bus.LayDanhSachDonHangTheoTrangThai("Đơn Hàng Không Giao", maCN).Count();

            btnTatCa.Text = $"Tất cả ({tatCa})";
            btnXuLy.Text = $"Chờ xử lý ({dangXuLy})";
            btnDangGiao.Text = $"Đang giao ({dangGiao})";
            btnĐaGiao.Text = $"Đã giao ({daGiao})";
            btnDaban.Text = $"Đã thanh toán ({daBan})";
            btnKhongDuyet.Text = $"Không duyệt ({khongDuyet})";
            btnDaHuy.Text = $"Đơn Hàng Không Giao ({daHuy})";
        }


        // ==== Sự kiện lọc ====

        private void btnLoc_Click_1(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string loaiDon = cbLoaiDon.SelectedItem?.ToString() ?? "";
            DateTime tuNgay = dtTuNgay.Value.Date;
            DateTime denNgay = dtDenNgay.Value.Date.AddDays(1); // bao gồm ngày cuối

            try
            {
                var list = _bus.LayDanhSachDonHangDTO(null).ToList(); // lấy danh sách từ BUS

                // 🔍 Tìm kiếm
                if (!string.IsNullOrEmpty(keyword))
                {
                    list = list.Where(d =>
                        (!string.IsNullOrEmpty(d.MaDonHang) && d.MaDonHang.ToLower().Contains(keyword)) ||
                        (!string.IsNullOrEmpty(d.TenKhachHang) && d.TenKhachHang.ToLower().Contains(keyword)) ||
                        (!string.IsNullOrEmpty(d.SDT) && d.SDT.Contains(keyword)) ||
                        (!string.IsNullOrEmpty(d.TenNhanVien) && d.TenNhanVien.ToLower().Contains(keyword))
                    ).ToList();
                }

                // 🗂 Lọc loại đơn
                /*f (loaiDon == "Online")
                    list = list.Where(d => d.LoaiDon == "Online").ToList();
                else if (loaiDon == "Trực tiếp")
                    list = list.Where(d => d.LoaiDon == "Trực tiếp").ToList();*/

                // 📅 Lọc theo ngày
                list = list.Where(d => d.NgayTao >= tuNgay && d.NgayTao < denNgay).ToList();

                guna2DataGridView1.DataSource = list;

                // 🧱 Ẩn/hiện thông tin khách hàng
                if (guna2DataGridView1.Columns.Contains("TenKhachHang"))
                    guna2DataGridView1.Columns["TenKhachHang"].Visible = loaiDon != "Trực tiếp";
                if (guna2DataGridView1.Columns.Contains("SDT"))
                    guna2DataGridView1.Columns["SDT"].Visible = loaiDon != "Trực tiếp";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message);
            }
        }
       

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {

        }
        // ==== Sự kiện lọc ====

        private void btnXuLy_Click_1(object sender, EventArgs e) => LoadDonHang("Chờ xử lý");

        private void btnĐaGiao_Click_1(object sender, EventArgs e) => LoadDonHang("Đã giao");

        private void btnTatCa_Click(object sender, EventArgs e) => LoadDonHang();
        private void btnDangGiao_Click(object sender, EventArgs e) => LoadDonHang("Đang giao");
        private void btnDaban_Click(object sender, EventArgs e) => LoadDonHang("Đã thanh toán");

        private void btnTaiLai_Click(object sender, EventArgs e) =>LoadDonHang();

        private void btnKhongDuyet_Click(object sender, EventArgs e) => LoadDonHang("Không duyệt");

        private void btnDaHuy_Click(object sender, EventArgs e) => LoadDonHang("Đơn Hàng Không Giao");



    }
}


