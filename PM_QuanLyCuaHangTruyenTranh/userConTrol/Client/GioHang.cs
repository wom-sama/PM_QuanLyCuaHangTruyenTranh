using PM.BUS.Services.DonHangsv;
using PM.DAL.Models;
using PM.GUI.userConTrol.Customer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Client
{
    public partial class GioHang : UserControl
    {
        private CT_GioHangService _ctGioHangService;
        private GioHangService _gioHangService;
        private string _maGioHang;
        private KhachHang _khach;

        private List<CT_GioHang> _items;
        private Action _onBack;

        public GioHang(string maGioHang, KhachHang khach, CT_GioHangService ctService, GioHangService ghService, Action onBack)
        {
            InitializeComponent();
            _maGioHang = maGioHang;
            _khach = khach;
            _ctGioHangService = ctService;
            _gioHangService = ghService;
            _onBack = onBack;

            LoadGioHang();
        }

        private void LoadGioHang()
        {
            pannelTong.Controls.Clear();

            _items = _ctGioHangService.GetAll()
                        .Where(x => x.MaGioHang == _maGioHang)
                        .ToList();

            // Load đầy đủ thông tin Sach nếu null
            foreach (var item in _items)
            {
                if (item.Sach == null)
                    item.Sach = _gioHangService.GetSachById(item.MaSach);
            }

            int y = 10;
            foreach (var item in _items)
            {
                Panel panelItem = new Panel
                {
                    Size = new Size(pannelTong.Width - 30, 100),
                    Location = new Point(10, y),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Ảnh sách
                PictureBox pic = new PictureBox
                {
                    Size = new Size(60, 80),
                    Location = new Point(5, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                if (item.Sach.BiaSach != null && item.Sach.BiaSach.Length > 0)
                {
                    using (var ms = new System.IO.MemoryStream(item.Sach.BiaSach))
                        pic.Image = Image.FromStream(ms);
                }
                else
                {
                    pic.Image = Properties.Resources.sparkle_hanabi; // ảnh mặc định
                }
                panelItem.Controls.Add(pic);

                // Tên sách
                Label lblTen = new Label
                {
                    Text = item.Sach?.TenSach ?? "Không xác định",
                    Location = new Point(70, 10),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                panelItem.Controls.Add(lblTen);

                // Giá
                Label lblGia = new Label
                {
                    Text = $"{item.Sach?.GiaBan:N0} ₫",
                    Location = new Point(70, 35),
                    AutoSize = true
                };
                panelItem.Controls.Add(lblGia);

                // Số lượng
                Label lblSoLuong = new Label
                {
                    Text = item.SoLuong.ToString(),
                    Location = new Point(250, 30),
                    Width = 40,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panelItem.Controls.Add(lblSoLuong);

                // Nút +
                Button btnTang = new Button
                {
                    Text = "+",
                    Location = new Point(300, 25),
                    Size = new Size(30, 30)
                };
                btnTang.Click += (s, e) =>
                {
                    item.SoLuong++;
                    lblSoLuong.Text = item.SoLuong.ToString();
                    _ctGioHangService.Update(item);
                };
                panelItem.Controls.Add(btnTang);

                // Nút -
                Button btnGiam = new Button
                {
                    Text = "-",
                    Location = new Point(340, 25),
                    Size = new Size(30, 30)
                };
                btnGiam.Click += (s, e) =>
                {
                    if (item.SoLuong > 1)
                    {
                        item.SoLuong--;
                        lblSoLuong.Text = item.SoLuong.ToString();
                        _ctGioHangService.Update(item);
                    }
                    else
                    {
                        // hỏi trước khi xóa
                        var res = MessageBox.Show(
                            $"Bạn có muốn xóa '{item.Sach.TenSach}' khỏi giỏ hàng?",
                            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            _ctGioHangService.Delete(item.MaGioHang, item.MaSach);
                            LoadGioHang(); // load lại giỏ hàng
                        }
                    }
                };
                panelItem.Controls.Add(btnGiam);

                pannelTong.Controls.Add(panelItem);
                y += 110;
            }

            // Nút Mua ngay
            Button btnMuaNgay = new Button
            {
                Text = "Mua ngay",
                Size = new Size(120, 40),
                Location = new Point(pannelTong.Width - 150, y + 10),
                BackColor = Color.OrangeRed,
                ForeColor = Color.White
            };
            btnMuaNgay.Click += BtnMuaNgay_Click;
            pannelTong.Controls.Add(btnMuaNgay);

            // Nút Quay lại
            Button btnBack = new Button
            {
                Text = "Quay lại",
                Size = new Size(120, 40),
                Location = new Point(pannelTong.Width - 280, y + 10),
                BackColor = Color.Gray,
                ForeColor = Color.White
            };
            btnBack.Click += BtnBack_Click;
            pannelTong.Controls.Add(btnBack);
        }

        private void BtnMuaNgay_Click(object sender, EventArgs e)
        {
            if (_items == null || _items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parentPanel = this.Parent;

            this.Visible = false;

            // Khai báo biến trước để lambda có thể sử dụng
            MuaHangList muaHangList = null;

            muaHangList = new MuaHangList(
                items: _items,
                khach: _khach,
                vanChuyen: "",       // bạn có thể truyền giá trị thực tế
                thanhToan: "",       // bạn có thể truyền giá trị thực tế
                ngayDat: null,       // sẽ lấy DateTime.Now nếu null
                onBack: () =>
                {
                    parentPanel.Controls.Remove(muaHangList);
                    this.Visible = true;
                }
            );

            muaHangList.Dock = DockStyle.Fill;
            parentPanel.Controls.Add(muaHangList);
            muaHangList.BringToFront();
        }



        private void BtnBack_Click(object sender, EventArgs e)
        {
            _onBack?.Invoke();
        }
    }
}
