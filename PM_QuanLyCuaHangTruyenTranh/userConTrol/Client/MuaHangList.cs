using PM.BUS.Services;
using PM.BUS.Services.DonHangsv;
using PM.BUS.Services.Facade;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Client
{
    public partial class MuaHangList : UserControl
    {
        private List<CT_GioHang> _items;
        private KhachHang _khach;
        private Action _onBack;

        // Controls mới
        private ComboBox cbVanChuyen;
        private ComboBox cbThanhToan;
        private Label lblTongTien;
        private Button btnDatHang;
        private DateTimePicker dtpNgayDat;

        public MuaHangList(List<CT_GioHang> items, KhachHang khach, string vanChuyen = "", string thanhToan = "", DateTime? ngayDat = null, Action onBack = null)
        {
            _items = items;
            _khach = khach;
            _onBack = onBack;

            InitializeComponent();
            LoadItems(vanChuyen, thanhToan, ngayDat ?? DateTime.Now);
        }

        private void LoadItems(string vanChuyen, string thanhToan, DateTime ngayDat)
        {
            pannelTong.Controls.Clear();
            int y = 10;

            // Tên khách
            TextBox txtHoTen = new TextBox
            {
                Text = _khach?.HoTen ?? "",
                Location = new Point(10, y),
                Width = 250
            };
            pannelTong.Controls.Add(txtHoTen);
            y += 30;

            // Số điện thoại
            TextBox txtSDT = new TextBox
            {
                Text = _khach?.SoDienThoai ?? "",
                Location = new Point(10, y),
                Width = 250
            };
            pannelTong.Controls.Add(txtSDT);
            y += 30;

            // Địa chỉ
            TextBox txtDiaChi = new TextBox
            {
                Text = _khach?.DiaChi ?? "",
                Location = new Point(10, y),
                Width = 350
            };
            pannelTong.Controls.Add(txtDiaChi);
            y += 40;

            // Danh sách sách
            foreach (var ct in _items)
            {
                Panel itemPanel = new Panel
                {
                    Size = new Size(pannelTong.Width - 40, 90),
                    Location = new Point(10, y),
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox pic = new PictureBox
                {
                    Size = new Size(60, 80),
                    Location = new Point(5, 5),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                if (ct.Sach?.BiaSach != null && ct.Sach.BiaSach.Length > 0)
                {
                    using (var ms = new System.IO.MemoryStream(ct.Sach.BiaSach))
                        pic.Image = Image.FromStream(ms);
                }
                else
                    pic.Image = Properties.Resources.sparkle_hanabi;

                itemPanel.Controls.Add(pic);

                Label lblTenSach = new Label
                {
                    Text = ct.Sach?.TenSach ?? "",
                    Location = new Point(75, 10),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                itemPanel.Controls.Add(lblTenSach);

                Label lblGia = new Label
                {
                    Text = $"{ct.Sach?.GiaBan:N0} ₫",
                    Location = new Point(75, 35),
                    AutoSize = true,
                    ForeColor = Color.Red
                };
                itemPanel.Controls.Add(lblGia);

                Label lblSoLuong = new Label
                {
                    Text = $"Số lượng: {ct.SoLuong}",
                    Location = new Point(250, 35),
                    AutoSize = true
                };
                itemPanel.Controls.Add(lblSoLuong);

                pannelTong.Controls.Add(itemPanel);
                y += itemPanel.Height + 10;
            }

            y += 10;

            // ComboBox vận chuyển
            cbVanChuyen = new ComboBox
            {
                Location = new Point(10, y),
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "TenDonVi",  // hiển thị tên
                ValueMember = "MaDVVC"        // giá trị thực tế
            };

            // lấy danh sách đơn vị vận chuyển từ DB
            var donViService = new DonViVanChuyenService();  // service cho bảng DonViVanChuyen
            var danhSachDVC = donViService.GetAll();         // phương thức trả về List<DonViVanChuyen>

            cbVanChuyen.DataSource = danhSachDVC;

            // chọn giá trị nếu có
            if (!string.IsNullOrEmpty(vanChuyen))
                cbVanChuyen.SelectedValue = vanChuyen;
            else if (cbVanChuyen.Items.Count > 0)
                cbVanChuyen.SelectedIndex = 0;

            cbVanChuyen.SelectedIndexChanged += (s, e) => UpdateTongTien();
            pannelTong.Controls.Add(cbVanChuyen);
            y += 30;

            // ComboBox thanh toán
            cbThanhToan = new ComboBox
            {
                Location = new Point(10, y),
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbThanhToan.Items.AddRange(new object[]
            {
                "COD",
                "Chuyển khoản ngân hàng",
                "Ví điện tử"
            });
            cbThanhToan.SelectedItem = thanhToan != "" ? thanhToan : cbThanhToan.Items[0];
            pannelTong.Controls.Add(cbThanhToan);
            y += 30;

            // DatePicker ngày đặt
            dtpNgayDat = new DateTimePicker
            {
                Location = new Point(10, y),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Enabled = false,
                Value = ngayDat
            };
            pannelTong.Controls.Add(dtpNgayDat);
            y += 30;

            // Tổng tiền
            lblTongTien = new Label
            {
                Location = new Point(10, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            pannelTong.Controls.Add(lblTongTien);
            y += 40;
            UpdateTongTien();

            // Nút đặt hàng
            btnDatHang = new Button
            {
                Text = "Đặt hàng",
                Size = new Size(120, 40),
                Location = new Point(10, y),
                BackColor = Color.OrangeRed,
                ForeColor = Color.White
            };
            btnDatHang.Click += BtnDatHang_Click;
            pannelTong.Controls.Add(btnDatHang);
            y += 50;

            // Nút quay lại
            Button btnBack = new Button
            {
                Text = "Quay lại",
                Size = new Size(120, 40),
                Location = new Point(150, y),
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            btnBack.Click += (s, e) => _onBack?.Invoke();
            pannelTong.Controls.Add(btnBack);
        }

        private decimal tong = 0;
        private void UpdateTongTien()
        {
            decimal phiShip = 0;
            if (cbVanChuyen.SelectedItem is DonViVanChuyen dvc)
                phiShip = dvc.PhiCoBan;

            tong = _items.Sum(x => x.SoLuong * x.Sach.GiaBan) + phiShip+50000;
            lblTongTien.Text = $"Tổng tiền: {tong:N0} ₫ (đã gồm phí ship)";
        }

        private void BtnDatHang_Click(object sender, EventArgs e)
        {
            // Lấy số trong chuỗi lblTongTien
            bool ok = new QuanLyDonHangBUS().TaoDonHang(
                _khach,"Online", cbVanChuyen.SelectedValue?.ToString(),
                cbThanhToan.SelectedItem?.ToString(),
                tong,
                _items // danh sách CT_GioHang
            );

            if (ok)
            {
                MessageBox.Show("✅ Đặt hàng thành công! Đơn đã được gửi sang trạng thái 'Chờ xử lý'.");

                var qlDonHangBus = new QuanLyDonHangBUS();
                qlDonHangBus.XoaGioHangSauKhiDat(_khach.TenDangNhap);

                // 🟢 Chỉ cần gọi callback, reload sẽ được thực hiện trong callback ở GioHang
                _onBack?.Invoke();
            }
            else
            {
                MessageBox.Show("❌ Đặt hàng thất bại!");
            }


        }


    }
}
