using Guna.UI2.WinForms;
using PM.BUS.Services;
using PM.BUS.Services.DonHangsv;
using PM.BUS.Services.VanChuyensv;
using PM.DAL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Customer
{
    public partial class MuaHang : UserControl
    {
        private Sach _sach;
        private KhachHang _khach;
        private Action _onBack;
        private DonViVanChuyenService _donViVanChuyenService = new DonViVanChuyenService();
        private CT_DonHangService _ctDonHangService = new CT_DonHangService();
        private DonHangService _donHangService = new DonHangService();
        private VanChuyenService _vanChuyenService = new VanChuyenService(); 

        private int _soLuong = 1;
        private decimal _giaBan;
        private decimal _phiShip = 0;
      
        private NhanVien nv;

        public MuaHang(Sach sach, KhachHang khach, NhanVien a,Action onBack)
        {
            InitializeComponent();
            _sach = sach;
            _khach = khach;
            _onBack = onBack;
           
           this.nv=a;

            // Gắn sự kiện
            btnTang.Click += btnTang_Click;
            btnGiam.Click += btnGiam_Click;
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

            if (_sach.BiaSach != null && _sach.BiaSach.Length > 0)
            {
                using (var ms = new MemoryStream(_sach.BiaSach))
                    picBiaSach.Image = Image.FromStream(ms);
            }
            else
            {
                picBiaSach.Image = Properties.Resources.sparkle_hanabi;
            }

            if (_khach != null)
            {
                txtTen.Text = _khach.HoTen;
                txtSDT.Text = _khach.SoDienThoai;
                txtDiaChi.Text = _khach.DiaChi;
            }

            dtpNgayDat.Format = DateTimePickerFormat.Custom;
            dtpNgayDat.CustomFormat = "dd/MM/yyyy";
            dtpNgayDat.Value = DateTime.Now;

            // 🟩 Lấy danh sách đơn vị vận chuyển từ DB
            var dsVanChuyen = _donViVanChuyenService.GetAll().ToList();
            if (dsVanChuyen.Any())
            {
                cbVanChuyen.DataSource = dsVanChuyen;
                cbVanChuyen.DisplayMember = "TenDonVi";
                cbVanChuyen.ValueMember = "MaDVVC";
            }

            cbThanhToan.Items.Clear();
            cbThanhToan.Items.AddRange(new object[]
            {
                "Thanh toán khi nhận hàng (COD)",
                "Chuyển khoản ngân hàng",
            });
            cbThanhToan.SelectedIndex = 0;

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
            if (cbVanChuyen.SelectedValue == null) return;

            var maVC = cbVanChuyen.SelectedValue.ToString();
            var vc = _donViVanChuyenService.GetById(maVC);
            if (vc != null)
                _phiShip = vc.PhiCoBan + 10000; // 🟩 dùng đúng thuộc tính trong DB
            else
                _phiShip = 0;
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

            // Kiểm tra số lượng tồn kho
            var khoService = new KhoService(new DAL.UnitOfWork());
            int soLuongTon = khoService.LaySoLuongTon(_sach.MaSach,nv.MaChiNhanh );

            if (_soLuong <= 0)
            {
                MessageBox.Show("❌ Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_soLuong > soLuongTon)
            {
                MessageBox.Show($"❌ Số lượng '{_sach.TenSach}' vượt quá số lượng tồn kho ({soLuongTon})!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDon = "DH" + DateTime.Now.Ticks.ToString();

            var don = new DonHang
            {
                MaDonHang = maDon,
                MaKhach = _khach.TenDangNhap,MaNV=nv.MaNV,
                NgayDat = dtpNgayDat.Value,
                LoaiDon = "Online",
                TrangThai = "Chờ xử lý",
                TongTien = _soLuong * _giaBan + _phiShip,
                HinhThucThanhToan = cbThanhToan.SelectedItem.ToString(),
                NgayGiao = null
            };

            var ctdh = new CT_DonHang
            {
                MaDonHang = maDon,
                MaSach = _sach.MaSach,
                SoLuong = _soLuong,
                DonGia = _giaBan,
                ThanhTien = _soLuong * _giaBan
            };

            var vc = new VanChuyen
            {
                MaDonHang = maDon,
                MaDVVC = cbVanChuyen.SelectedValue.ToString(),
                NgayTao = DateTime.Now,
                TrangThai = "Đang xử lý",
                GhiChu = $"Giao đến {txtDiaChi.Text}"
            };

            try
            {
                // 🟧 Nếu chọn thanh toán qua ngân hàng
                if (cbThanhToan.SelectedItem.ToString() == "Chuyển khoản ngân hàng")
                {
                    var qrControl = new ThanhToanQR(maDon, _soLuong * _giaBan + _phiShip, () =>
                    {
                        // Khi người dùng xác nhận thanh toán
                        _donHangService.Add(don);
                        _ctDonHangService.Add(ctdh);
                        _vanChuyenService.Add(vc);

                        MessageBox.Show("✅ Thanh toán và đặt hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 🟢 Gọi lại _onBack để quay lại danh sách sách (Shop_BookView)
                        if (this.Parent != null)
                        {
                            this.Parent.Controls.Remove(this); // xóa control MuaHang
                        }
                        _onBack?.Invoke(); // chạy callback để hiển thị lại danh sách
                    });

                    qrControl.Dock = DockStyle.Fill;
                    this.Parent.Controls.Add(qrControl);
                    qrControl.BringToFront();
                    this.Hide(); // Ẩn form mua hàng để hiển thị QR
                }

                else
                {
                    // 🟩 Trường hợp COD
                    _donHangService.Add(don);
                    _ctDonHangService.Add(ctdh);
                    _vanChuyenService.Add(vc);

                    MessageBox.Show(
                        $"✅ Đặt hàng thành công!\nNgười nhận: {txtTen.Text}\nSĐT: {txtSDT.Text}\nĐịa chỉ: {txtDiaChi.Text}\n" +
                        $"Phí ship: {_phiShip:N0} ₫\nTổng thanh toán: {don.TongTien:N0} ₫",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _onBack?.Invoke();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi đặt hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            _onBack?.Invoke();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
