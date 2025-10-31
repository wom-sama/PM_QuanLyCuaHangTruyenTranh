using PM.DAL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Customer
{
    public partial class BookDetailControl : UserControl
    {
        private Sach _sach;
        private KhachHang _khachHang; // 🟩 Thêm thông tin khách hàng
        private Action _onBack;

        // 🟩 Constructor mới
        public BookDetailControl(Sach sach, KhachHang khachHang, Action onBack)
        {
            InitializeComponent();

            if (!DesignMode)
            {
                _sach = sach;
                _khachHang = khachHang;
                _onBack = onBack;
            }
        }

        private void BookDetailControl_Load(object sender, EventArgs e)
        {
            if (_sach == null) return;

            lblTenSach.Text = _sach.TenSach;
            lblGiaBan.Text = $"{_sach.GiaBan:N0} ₫";
            lblLuotBan.Text = $"Lượt bán: {_sach.LuotBan}";

            // 🟩 Lấy số lượng tồn thực tế
            var khoService = new PM.BUS.Services.VanChuyensv.KhoService(new PM.DAL.UnitOfWork());
            int soLuongTon = khoService.LaySoLuongTon(_sach.MaSach);
            lblSoLuong.Text = $"Số lượng còn: {soLuongTon}";

            txtMoTa.Text = _sach.MoTa ?? "Chưa có mô tả cho cuốn sách này.";

            lblSoTrang.Text = $"Số trang: {_sach.SoTrang}";
            lblNamXB.Text = $"Năm XB: {_sach.NamXuatBan}";
            lblTacGia.Text = $"Tác giả: {_sach.TacGia?.TenTacGia ?? "Không rõ"}";
            lblTheLoai.Text = $"Thể loại: {_sach.TheLoai?.TenTheLoai ?? "Không rõ"}";
            lblNXB.Text = $"NXB: {_sach.NhaXuatBan?.TenNXB ?? "Không rõ"}";

            // 🖼 Ảnh bìa
            if (_sach.BiaSach != null && _sach.BiaSach.Length > 0)
            {
                using (var ms = new MemoryStream(_sach.BiaSach))
                    picBiaSach.Image = Image.FromStream(ms);
            }
            else
            {
                picBiaSach.Image = Properties.Resources.sparkle_hanabi;
            }
        }

        private void btnMuaNgay_Click(object sender, EventArgs e)
        {
            if (_sach == null) return;
            if (_khachHang == null)
            {
                MessageBox.Show("❌ Vui lòng đăng nhập để mua hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parentPanel = this.Parent; // Lấy panel chứa BookDetailControl

            // Ẩn control hiện tại
            this.Visible = false;

            // 🟩 Khai báo trước
            MuaHang muaHang = null;

            // 🟩 Khởi tạo MuaHang với KhachHang
            muaHang = new MuaHang(_sach, _khachHang, () =>
            {
                parentPanel.Controls.Remove(muaHang);
                this.Visible = true;
            });

            muaHang.Dock = DockStyle.Fill;
            parentPanel.Controls.Add(muaHang);
            muaHang.BringToFront();
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"✅ Đã thêm {_sach.TenSach} vào giỏ hàng!",
                "Giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _onBack?.Invoke();
        }
    }
}
