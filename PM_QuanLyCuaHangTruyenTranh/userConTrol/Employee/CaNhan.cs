using PM.BUS.Services.TaiKhoansv;
using PM.DAL;
using PM.DAL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class CaNhan : UserControl
    {
        private readonly NhanVienService _nvService;
        private readonly ChucVuService _cvService;
        private readonly string _maNhanVien;

        public CaNhan(string maNhanVien)
        {
            InitializeComponent();
            _maNhanVien = maNhanVien;
            _nvService = new NhanVienService(new UnitOfWork());
            _cvService = new ChucVuService(new UnitOfWork());

            LoadThongTinCaNhan();
        }

        private void LoadThongTinCaNhan()
        {
            try
            {
                var nv = _nvService.GetById(_maNhanVien);
                if (nv == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xóa mọi control cũ trước khi tạo lại
                pannelCaNhan.Controls.Clear();

                // Ảnh đại diện
                var pic = new Guna2CirclePictureBox
                {
                    Size = new Size(150, 150),
                    Location = new Point(50, 30),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Image = nv.AnhDaiDien != null ? ByteArrayToImage(nv.AnhDaiDien) : Properties.Resources.Roblox_3_2_2025_12_02_38_AM
                };

                // Thông tin nhân viên
                var lblTen = new Label
                {
                    Text = nv.HoTen,
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    Location = new Point(230, 40),
                    AutoSize = true
                };

                var lblMaNV = CreateInfoLabel($"Mã NV: {nv.MaNV}", 230, 90);
                var lblGioiTinh = CreateInfoLabel($"Giới tính: {nv.GioiTinh}", 230, 120);
                var lblNgaySinh = CreateInfoLabel($"Ngày sinh: {nv.NgaySinh:dd/MM/yyyy}", 230, 150);
                var lblChucVu = CreateInfoLabel($"Chức vụ: {nv.ChucVu?.TenChucVu ?? "Chưa có"}", 230, 180);
                var lblChiNhanh = CreateInfoLabel($"Chi nhánh: {nv.ChiNhanh?.TenChiNhanh ?? "Chưa có"}", 230, 210);
                var lblSDT = CreateInfoLabel($"Số điện thoại: {nv.SoDienThoai}", 230, 240);
                var lblEmail = CreateInfoLabel($"Email: {nv.Email}", 230, 270);
                var lblDiaChi = CreateInfoLabel($"Địa chỉ: {nv.DiaChi}", 230, 300);

                // Thêm control vào panel
                pannelCaNhan.Controls.Add(pic);
                pannelCaNhan.Controls.Add(lblTen);
                pannelCaNhan.Controls.Add(lblMaNV);
                pannelCaNhan.Controls.Add(lblGioiTinh);
                pannelCaNhan.Controls.Add(lblNgaySinh);
                pannelCaNhan.Controls.Add(lblChucVu);
                pannelCaNhan.Controls.Add(lblChiNhanh);
                pannelCaNhan.Controls.Add(lblSDT);
                pannelCaNhan.Controls.Add(lblEmail);
                pannelCaNhan.Controls.Add(lblDiaChi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin cá nhân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Label CreateInfoLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 11),
                Location = new Point(x, y),
                AutoSize = true
            };
        }

        private Image ByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
