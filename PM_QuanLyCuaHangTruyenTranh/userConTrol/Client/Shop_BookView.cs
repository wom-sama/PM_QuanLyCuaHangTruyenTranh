using PM.BUS.Services.DonHangsv;
using PM.BUS.Services.Sachsv;
using PM.DAL;
using PM.DAL.Models;
using PM.GUI.userConTrol.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GHControl = PM.GUI.userConTrol.Client.GioHang; // alias cho UserControl
// Thêm ở đầu file
using GHModel = PM.DAL.Models.GioHang;  // alias cho model
namespace PM.GUI.userConTrol.Customer
{
    public partial class Shop_BookView : UserControl
    {
        private SachService sachService = new SachService();

        // 🟩 Khách hàng hiện tại
        private KhachHang currentKhachHang;
        private UnitOfWork _unitOfWork;
        private GioHangService _gioHangService;
        private CT_GioHangService _ctGioHangService;
        private GioHang currentGioHang;
      

        public Shop_BookView(KhachHang khachHang)
        {
            currentKhachHang = khachHang;
            _unitOfWork = new UnitOfWork();
            _gioHangService = new GioHangService(_unitOfWork);
            _ctGioHangService = new CT_GioHangService(_unitOfWork);
            if (!DesignMode)
                InitializeComponent();

        }

        private void Shop_BookView_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadOrCreateCart(); // ✅ KHỞI TẠO GIỎ HÀNG CHO KHÁCH HÀNG
            LoadAllBooks();
        }

        // ================== HIỂN THỊ SÁCH ==================
        private void LoadAllBooks(IEnumerable<Sach> list = null)
        {
            panelDanhSach.Controls.Clear();
            var books = list ?? sachService.GetAll();

            foreach (var sach in books)
            {
                Panel card = CreateBookCard(sach);
                panelDanhSach.Controls.Add(card);
            }
        }

        // ================== TẠO MỘT CARD HIỂN THỊ SÁCH ==================
        private Panel CreateBookCard(Sach sach)
        {
            Panel card = new Panel
            {
                Width = 180,
                Height = 250,
                Margin = new Padding(10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = sach
            };

            // ----- ẢNH BÌA -----
            PictureBox pic = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 150,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.WhiteSmoke
            };

            if (sach.BiaSach != null && sach.BiaSach.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(sach.BiaSach))
                        pic.Image = Image.FromStream(ms);
                }
                catch
                {
                    pic.Image = Properties.Resources.sparkle_hanabi;
                }
            }
            else
            {
                pic.Image = Properties.Resources.sparkle_hanabi;
            }

            // ----- TÊN SÁCH -----
            Label lblTen = new Label
            {
                Text = sach.TenSach,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ----- GIÁ -----
            Label lblGia = new Label
            {
                Text = $"{sach.GiaBan:N0} ₫",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Red,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // ----- NÚT MUA NGAY -----
            Guna.UI2.WinForms.Guna2Button btnMua = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Mua ngay",
                Dock = DockStyle.Bottom,
                BorderRadius = 8,
                Height = 35,
                FillColor = Color.OrangeRed,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Tag = sach
            };
            btnMua.Click += BtnMua_Click;

            // ----- GẮN CONTROL -----
            card.Controls.Add(btnMua);
            card.Controls.Add(lblGia);
            card.Controls.Add(lblTen);
            card.Controls.Add(pic);

            // ----- CLICK VÀO SÁCH -----
            card.Click += (s, e) => OpenBookDetail((Sach)card.Tag);
            pic.Click += (s, e) => OpenBookDetail((Sach)card.Tag);

            return card;
        }

        // ================== NÚT MUA NGAY ==================
        private void BtnMua_Click(object sender, EventArgs e)
        {
            var sach = (sender as Guna.UI2.WinForms.Guna2Button)?.Tag as Sach;
            if (sach == null) return;

            if (currentGioHang == null) LoadOrCreateCart();

            // Kiểm tra xem sách đã có trong giỏ chưa
            var ct = currentGioHang.CT_GioHangs.FirstOrDefault(c => c.MaSach == sach.MaSach);
            if (ct != null)
            {
                ct.SoLuong++;
                _ctGioHangService.Update(ct);
            }
            else
            {
                ct = new CT_GioHang
                {
                    MaGioHang = currentGioHang.MaGioHang,
                    MaSach = sach.MaSach,
                    SoLuong = 1
                };
                _ctGioHangService.Add(ct);
                currentGioHang.CT_GioHangs.Add(ct);
            }


            // Mở MuaHang
            MuaHang muaHang = null; // khai báo trước
            muaHang = new MuaHang(sach, currentKhachHang, () =>
            {
                pannelTong.Controls.Remove(muaHang);
                panelDanhSach.Visible = true;
            });

            muaHang.Dock = DockStyle.Fill;
            pannelTong.Controls.Add(muaHang);
            muaHang.BringToFront();

        }


        // ================== CLICK VÀO SÁCH ==================
        private void OpenBookDetail(Sach sach)
        {
            panelDanhSach.Visible = false;

            BookDetailControl detailControl = null;

            detailControl = new BookDetailControl(sach, currentKhachHang, () =>
            {
                pannelTong.Controls.Remove(detailControl);
                panelDanhSach.Visible = true;
            });

            detailControl.Dock = DockStyle.Fill;
            detailControl.AutoScroll = true;
            pannelTong.Controls.Add(detailControl);
            detailControl.BringToFront();
        }

        // ================== TÌM KIẾM ==================
        private void btnFind_Click(object sender, EventArgs e)
        {
            string keyword = txtFindTen.Text.Trim().ToLower();
            var filtered = sachService.Find(s => s.TenSach.ToLower().Contains(keyword));
            LoadAllBooks(filtered);
        }

        // ================== NÚT GIỎ HÀNG ==================
        private void btnCart_Click(object sender, EventArgs e)
        {
            if (currentGioHang == null)
                LoadOrCreateCart();

            panelDanhSach.Visible = false;

            // Khai báo biến trước
            GHControl cartControl = null;

            // Tạo UserControl giỏ hàng với onBack
            cartControl = new GHControl(
                currentGioHang.MaGioHang,
                currentKhachHang,
                _ctGioHangService,
                _gioHangService,
                () => // onBack
                {
                    pannelTong.Controls.Remove(cartControl); // Xóa control giỏ hàng
                    panelDanhSach.Visible = true;           // Hiển thị lại danh sách sách
                }
            );

            cartControl.Dock = DockStyle.Fill;
            pannelTong.Controls.Add(cartControl);
            cartControl.BringToFront();
        }


        private void pannelTong_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadOrCreateCart()
        {
            currentGioHang = _gioHangService.GetAll()
         .FirstOrDefault(g => g.MaKhach == currentKhachHang.TenDangNhap);

            if (currentGioHang == null)
            {
                currentGioHang = new GHModel
                {
                    MaGioHang = "GH" + DateTime.Now.Ticks,
                    MaKhach = currentKhachHang.TenDangNhap,
                    CT_GioHangs = new List<CT_GioHang>()
                };
                _gioHangService.Add(currentGioHang);
                _unitOfWork.Save();
            }
        }
    }
}
