using PM.BUS.Services.Facade;
using PM.DAL.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class DuyetDon : UserControl
    {
        private readonly QuanLyDonHangBUS _bus;
        private string selectedMaDonHang = null;
        public event Action OnDonHangDuyet; // 🔔 sự kiện callback

        // ✅ Constructor nhận bus từ form cha
        public DuyetDon(QuanLyDonHangBUS bus)
        {
            InitializeComponent();
            _bus = bus ?? throw new ArgumentNullException(nameof(bus)); // đảm bảo không null

            // Định dạng label sau khi InitializeComponent()
            var labels = new[] { lblTenKhach, lblSDT, lblEmail, lblDiaChi, lblDonViVC, lblTongTien, lblNgayDat, lblNgayGiao, lblHTTT };
            int x = 20, y = 15, spacing = 22;
            foreach (var lbl in labels)
            {
                lbl.Font = new System.Drawing.Font("Segoe UI", 10.5F);
                lbl.ForeColor = System.Drawing.Color.DimGray;
                lbl.Location = new System.Drawing.Point(x, y);
                lbl.AutoSize = true;
                y += spacing;
            }

            // Nạp danh sách đơn hàng
            dgvDonHang.DataSource = _bus.LayDanhSachDonHangTheoTrangThai("Chờ xử lý");
            dgvChiTiet.DataSource = null;
        }

        private void LoadDonHang()
        {
            dgvDonHang.DataSource = _bus.LayDanhSachDonHangTheoTrangThai("Chờ xử lý");
            dgvChiTiet.DataSource = null;
            selectedMaDonHang = null;
            OnDonHangDuyet?.Invoke(); // 🔔 đảm bảo luôn sync chuông khi tải lại
            XoaThongTinChiTiet();
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedMaDonHang = dgvDonHang.Rows[e.RowIndex].Cells["MaDonHang"].Value.ToString();
            HienThiChiTietDonHang(selectedMaDonHang);
        }

        private void HienThiChiTietDonHang(string maDonHang)
        {
            var don = _bus.LayDonHangTheoMa(maDonHang);
            if (don == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng!");
                return;
            }

            // 🧍 Thông tin khách hàng
            var kh = don.Khach;
            lblTenKhach.Text = $"👤 Khách hàng: {kh?.HoTen ?? "N/A"}";
            lblSDT.Text = $"☎️ SĐT: {kh?.SoDienThoai ?? "N/A"}";
            lblEmail.Text = $"✉️ Email: {kh?.Email ?? "N/A"}";
            lblDiaChi.Text = $"🏠 Địa chỉ: {kh?.DiaChi ?? "N/A"}";

            // 🚚 Đơn vị vận chuyển
            var vc = don.VanChuyen?.DonViVanChuyen;
            lblDonViVC.Text = vc != null
                ? $"🚚 ĐVVC: {vc.TenDonVi} ({vc.SoDienThoai})"
                : "🚚 ĐVVC: Chưa có";

            // 💰 Tổng tiền, ngày
            lblTongTien.Text = $"💰 Tổng tiền: {don.TongTien:C0}";
            lblNgayDat.Text = $"📅 Ngày đặt: {don.NgayDat:dd/MM/yyyy}";
            lblNgayGiao.Text = don.NgayGiao != null
                ? $"📦 Ngày giao: {don.NgayGiao:dd/MM/yyyy}"
                : $"📦 Ngày giao: Chưa giao";
            lblHTTT.Text = $"💳 Hình thức TT: {don.HinhThucThanhToan}";
            // 📦 Danh sách sản phẩm
            dgvChiTiet.DataSource = don.CT_DonHangs
                .Select(ct => new
                {
                    Tên_sách = ct.Sach.TenSach,
                    Số_lượng = ct.SoLuong,
                    Đơn_giá = ct.DonGia,
                    Thành_tiền = ct.ThanhTien
                })
                .ToList();

            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTiet.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            dgvChiTiet.EnableHeadersVisualStyles = false;

            dgvChiTiet.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            dgvChiTiet.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvChiTiet.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(210, 240, 255);
            dgvChiTiet.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            // 🌈 Xen kẽ màu dòng để dễ nhìn
            dgvChiTiet.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            dgvChiTiet.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;

            // 🧩 Căn giữa số lượng và giá tiền
            if (dgvChiTiet.Columns.Contains("Số_lượng"))
                dgvChiTiet.Columns["Số_lượng"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgvChiTiet.Columns.Contains("Đơn_giá"))
                dgvChiTiet.Columns["Đơn_giá"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (dgvChiTiet.Columns.Contains("Thành_tiền"))
                dgvChiTiet.Columns["Thành_tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // 🚫 Không cho sửa trực tiếp
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.RowHeadersVisible = false;

            // Bo góc nhẹ, khoảng cách dòng dễ nhìn
            dgvChiTiet.RowTemplate.Height = 28;
        }

        private void XoaThongTinChiTiet()
        {
            lblTenKhach.Text = lblSDT.Text = lblEmail.Text =
                lblDiaChi.Text = lblDonViVC.Text =
                lblTongTien.Text = lblNgayDat.Text = lblNgayGiao.Text = "";
            dgvChiTiet.DataSource = null;
        }

        private void BtnDuyetDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaDonHang))
            {
                MessageBox.Show("⚠️ Vui lòng chọn đơn hàng trước!", "Thông báo");
                return;
            }

            var donHang = _bus.LayDonHangTheoMa(selectedMaDonHang);
            if (donHang == null)
            {
                MessageBox.Show("❌ Không tìm thấy đơn hàng!");
                return;
            }

            if (donHang.TrangThai != "Chờ xử lý")
            {
                MessageBox.Show("⚠️ Chỉ duyệt các đơn đang xử lý!");
                return;
            }

            bool ok = _bus.DuyetDon(selectedMaDonHang);
            if (ok)
            {
                MessageBox.Show($"✅ Đơn {selectedMaDonHang} đã chuyển sang trạng thái 'Đang giao'!");
                LoadDonHang();
                OnDonHangDuyet?.Invoke(); // 🔔 Báo lại cho form cha cập nhật chuông
            }
            else
            {
                MessageBox.Show("❌ Duyệt đơn thất bại!");
            }

            LoadDonHang();
        }


        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDonHang();
        }
        private void dgvDonHang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnKhongDuyet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaDonHang))
            {
                MessageBox.Show("⚠️ Vui lòng chọn đơn hàng trước!", "Thông báo");
                return;
            }

            var donHang = _bus.LayDonHangTheoMa(selectedMaDonHang);
            if (donHang == null)
            {
                MessageBox.Show("❌ Không tìm thấy đơn hàng!");
                return;
            }

            if (donHang.TrangThai != "Chờ xử lý")
            {
                MessageBox.Show("⚠️ Chỉ có thể hủy các đơn đang xử lý!");
                return;
            }

            bool ok = _bus.KhongDuyetDon(selectedMaDonHang);
            if (ok)
            {
                MessageBox.Show($"❌ Đơn {selectedMaDonHang} đã được đánh dấu là 'Không duyệt'!");
                LoadDonHang();
                OnDonHangDuyet?.Invoke(); // 🔔 báo lại cho form cha cập nhật chuông
            }
            else
            {
                MessageBox.Show("❌ Thao tác không thành công!");
            }
        }
    }
}
