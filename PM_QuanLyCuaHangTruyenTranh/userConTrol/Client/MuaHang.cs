using PM.DAL.Models;
using PM.BUS.Services.DonHangsv;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PM.GUI.userConTrol.Customer
{
    public partial class MuaHang : UserControl
    {
        private Sach _sach;
        private KhachHang _khach; // 🟩 Thêm đối tượng khách hàng
        private Action _onBack;
        private CT_DonHangService _ctDonHangService = new CT_DonHangService();

        private int _soLuong = 1;
        private decimal _giaBan;
        private decimal _phiShip = 0;

        // 🟩 Constructor mới có thêm KhachHang
        public MuaHang(Sach sach, KhachHang khach, Action onBack)
        {
            InitializeComponent();
            _sach = sach;
            _khach = khach;
            _onBack = onBack;

            // Gắn sự kiện
            btnTang.Click += btnTang_Click;
            btnGiam.Click += btnGiam_Click;
            btnDatHang.Click += btnDatHang_Click;
            btnBack.Click += btnBack_Click;
            txtTen.TextChanged += txtTen_TextChanged;
            txtSDT.TextChanged += txtSDT_TextChanged;
            txtDiaChi.TextChanged += txtDiaChi_TextChanged;
            cbVanChuyen.SelectedIndexChanged += cbVanChuyen_SelectedIndexChanged;
        }

        private void MuaHang_Load(object sender, EventArgs e)
        {
            if (_sach == null) return;

            _giaBan = _sach.GiaBan;

            lblTenSach.Text = _sach.TenSach;
            lblGiaSach.Text = $"{_sach.GiaBan:N0} ₫";
            lblSoLuong.Text = _soLuong.ToString();

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

            // 🟩 Nếu có thông tin khách hàng -> tự động điền
            if (_khach != null)
            {
                txtTen.Text = _khach.HoTen;
                txtSDT.Text = _khach.SoDienThoai;
                txtDiaChi.Text = _khach.DiaChi;
            }

            // 🟩 Dữ liệu cho combobox
            cbVanChuyen.Items.Clear();
            cbVanChuyen.Items.AddRange(new object[]
            {
                "Giao hàng nhanh (2-3 ngày)",
                "Giao hàng tiết kiệm (3-5 ngày)",
                "Hỏa tốc (trong ngày)"
            });
            cbVanChuyen.SelectedIndex = 0;

            cbThanhToan.Items.Clear();
            cbThanhToan.Items.AddRange(new object[]
            {
                "Thanh toán khi nhận hàng (COD)",
                "Chuyển khoản ngân hàng",
                "Ví điện tử (Momo, ZaloPay...)"
            });
            cbThanhToan.SelectedIndex = 0;

            dtpNgayDat.Value = DateTime.Now;

            UpdatePhiShip();
            UpdateTongTien();
            UpdateButtonState();
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            _soLuong++;
            lblSoLuong.Text = _soLuong.ToString();
            UpdateTongTien();
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            if (_soLuong > 1)
            {
                _soLuong--;
                lblSoLuong.Text = _soLuong.ToString();
                UpdateTongTien();
            }
        }

        private void UpdatePhiShip()
        {
            if (cbVanChuyen.SelectedItem == null) return;

            switch (cbVanChuyen.SelectedItem.ToString())
            {
                case "Giao hàng nhanh (2-3 ngày)":
                    _phiShip = 50000;
                    break;
                case "Giao hàng tiết kiệm (3-5 ngày)":
                    _phiShip = 40000;
                    break;
                case "Hỏa tốc (trong ngày)":
                    _phiShip = 60000;
                    break;
                default:
                    _phiShip = 0;
                    break;
            }
        }

        private void cbVanChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePhiShip();
            UpdateTongTien();
        }

        private void UpdateTongTien()
        {
            decimal tong = _soLuong * _giaBan + _phiShip;
            lblTongTien.Text = $"Tổng tiền: {tong:N0} ₫ (đã gồm phí ship)";
        }

        private void UpdateButtonState()
        {
            bool filled = !string.IsNullOrWhiteSpace(txtTen.Text)
                       && !string.IsNullOrWhiteSpace(txtSDT.Text)
                       && !string.IsNullOrWhiteSpace(txtDiaChi.Text);
            btnDatHang.Enabled = filled;
            btnDatHang.FillColor = filled ? Color.OrangeRed : Color.Gray;
        }

        private void txtTen_TextChanged(object sender, EventArgs e) => UpdateButtonState();
        private void txtSDT_TextChanged(object sender, EventArgs e) => UpdateButtonState();
        private void txtDiaChi_TextChanged(object sender, EventArgs e) => UpdateButtonState();

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            if (!btnDatHang.Enabled) return;

            string maDon = "DH" + DateTime.Now.Ticks.ToString();

            var don = new DonHang
            {
                MaDonHang = maDon,
                NgayDat = dtpNgayDat.Value,
                LoaiDon = "Online",
                TrangThai = "Chờ xử lý",
                TongTien = _soLuong * _giaBan + _phiShip
            };

            var ctdh = new CT_DonHang
            {
                MaDonHang = maDon,
                MaSach = _sach.MaSach,
                SoLuong = _soLuong,
                DonGia = _giaBan,
                ThanhTien = _soLuong * _giaBan
            };

            try
            {
                _ctDonHangService.Add(ctdh);
                MessageBox.Show(
                    $"✅ Đặt hàng thành công!\nNgười nhận: {txtTen.Text}\nSĐT: {txtSDT.Text}\nĐịa chỉ: {txtDiaChi.Text}\n" +
                    $"Phí ship: {_phiShip:N0} ₫\nTổng thanh toán: {don.TongTien:N0} ₫",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _onBack?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi đặt hàng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _onBack?.Invoke();
        }
    }
}
