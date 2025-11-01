using PM.BUS.Services.DonHangsv;
using PM.DAL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// Alias để tránh trùng tên
using GHModel = PM.DAL.Models.GioHang;
using GHControl = PM.GUI.userConTrol.Client.GioHang;

namespace PM.GUI.userConTrol.Customer
{
    public partial class BookDetailControl : UserControl
    {
        // thuoc tinh rieng
        string _maChiNhanh;

        //
        private Sach _sach;
        private KhachHang _khachHang;
        private Action _onBack;

        // Services giỏ hàng
        private GioHangService _gioHangService;
        private CT_GioHangService _ctGioHangService;
        private GHModel _currentGioHang;

        public BookDetailControl(Sach sach, KhachHang khachHang, string maChiNhanh, Action onBack)
        {
            InitializeComponent();

            if (!DesignMode)
            {
                _sach = sach;
                _khachHang = khachHang;
                _onBack = onBack;
                this._maChiNhanh = maChiNhanh;

                // Khởi tạo service
                var unit = new DAL.UnitOfWork();
                _gioHangService = new GioHangService(unit);
                _ctGioHangService = new CT_GioHangService(unit);

                LoadOrCreateCart();
            }

            _maChiNhanh = maChiNhanh;
        }

        private void BookDetailControl_Load(object sender, EventArgs e)
        {
            if (_sach == null) return;

            lblTenSach.Text = _sach.TenSach;
            lblGiaBan.Text = $"{_sach.GiaBan:N0} ₫";
            lblLuotBan.Text = $"Lượt bán: {_sach.LuotBan}";

            // Lấy số lượng tồn thực tế
            var khoService = new PM.BUS.Services.VanChuyensv.KhoService(new PM.DAL.UnitOfWork());
            int soLuongTon = khoService.LaySoLuongTon(_sach.MaSach,_maChiNhanh);
            lblSoLuong.Text = $"Số lượng còn: {soLuongTon}";

            txtMoTa.Text = _sach.MoTa ?? "Chưa có mô tả cho cuốn sách này.";
            lblSoTrang.Text = $"Số trang: {_sach.SoTrang}";
            lblNamXB.Text = $"Năm XB: {_sach.NamXuatBan}";
            lblTacGia.Text = $"Tác giả: {_sach.TacGia?.TenTacGia ?? "Không rõ"}";
            lblTheLoai.Text = $"Thể loại: {_sach.TheLoai?.TenTheLoai ?? "Không rõ"}";
            lblNXB.Text = $"NXB: {_sach.NhaXuatBan?.TenNXB ?? "Không rõ"}";

            // Ảnh bìa
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

            var khoService = new PM.BUS.Services.VanChuyensv.KhoService(new PM.DAL.UnitOfWork());
            int soLuongTon = khoService.LaySoLuongTon(_sach.MaSach,_maChiNhanh);

            if (soLuongTon <= 0)
            {
                MessageBox.Show($"❌ Sản phẩm '{_sach.TenSach}' hiện đã hết hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_sach == null || _khachHang == null)
            {
                MessageBox.Show("❌ Vui lòng đăng nhập để mua hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parentPanel = this.Parent;

            this.Visible = false;

            // 🔹 Khai báo trước biến muaHang
            MuaHang muaHang = null;

            muaHang = new MuaHang(_sach, _khachHang, _maChiNhanh, () =>
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

            var khoService = new PM.BUS.Services.VanChuyensv.KhoService(new PM.DAL.UnitOfWork());
            int soLuongTon = khoService.LaySoLuongTon(_sach.MaSach,_maChiNhanh);

            if (soLuongTon <= 0)
            {
                MessageBox.Show($"❌ Sản phẩm '{_sach.TenSach}' hiện đã hết hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_sach == null || _khachHang == null)
            {
                MessageBox.Show("❌ Vui lòng đăng nhập để thêm vào giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra sách đã có trong giỏ chưa
            var ct = _currentGioHang.CT_GioHangs.FirstOrDefault(c => c.MaSach == _sach.MaSach);
            if (ct != null)
            {
                ct.SoLuong++;
                _ctGioHangService.Update(ct);
            }
            else
            {
                ct = new CT_GioHang
                {
                    MaGioHang = _currentGioHang.MaGioHang,
                    MaSach = _sach.MaSach,
                    SoLuong = 1
                };
                _ctGioHangService.Add(ct);
                _currentGioHang.CT_GioHangs.Add(ct);
            }

            MessageBox.Show($"✅ Đã thêm {_sach.TenSach} vào giỏ hàng!", "Giỏ hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _onBack?.Invoke();
        }

        private void LoadOrCreateCart()
        {
            _currentGioHang = _gioHangService.GetAll().FirstOrDefault(g => g.MaKhach == _khachHang.TenDangNhap);
            if (_currentGioHang == null)
            {
                _currentGioHang = new GHModel
                {
                    MaGioHang = "GH" + DateTime.Now.Ticks,
                    MaKhach = _khachHang.TenDangNhap,
                    CT_GioHangs = new System.Collections.Generic.List<CT_GioHang>()
                };
                _gioHangService.Add(_currentGioHang);
            }
        }
    }
}
