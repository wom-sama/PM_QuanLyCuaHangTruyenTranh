using PM.BUS.Services.LamViecsv;
using PM.DAL;
using System;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class XemLuong : UserControl
    {
        private readonly BangLuongService _bangLuongService;
        private readonly string _maNhanVien;

        public XemLuong(string maNhanVien)
        {
            InitializeComponent();
            _maNhanVien = maNhanVien;
            _bangLuongService = new BangLuongService(new UnitOfWork());
            LoadLuong();
        }

        private void LoadLuong()
        {
            try
            {
                var danhSachLuong = _bangLuongService.GetAll()
                    .Where(b => b.MaNV == _maNhanVien)
                    .OrderByDescending(b => b.ThangTinhLuong)
                    .Select(b => new
                    {
                        Mã_Bảng_Lương = b.MaBangLuong,
                        Mã_Nhân_Viên = b.MaNV,
                        Lương_Cơ_Bản = b.LuongCoBan.ToString("N0") + " ₫",
                        Phụ_Cấp = b.PhuCap.ToString("N0") + " ₫",
                        Thưởng = b.Thuong.ToString("N0") + " ₫",
                        Khấu_Trừ = b.KhauTru.ToString("N0") + " ₫",
                        Tổng_Lương = b.TongLuong.ToString("N0") + " ₫",
                        Tháng_Tính_Lương = b.ThangTinhLuong.ToString("MM/yyyy")
                    })
                    .ToList();

                // Nếu panel hiển thị chưa có gì thì thêm DataGridView
                guna2Panel1.Controls.Clear();

                var dgv = new Guna2DataGridView
                {
                    Dock = DockStyle.Fill,
                    DataSource = danhSachLuong,
                    ReadOnly = true,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid
                };

                guna2Panel1.Controls.Add(dgv);

                // Tính tổng thu nhập
                decimal tongThuNhap = _bangLuongService.GetAll()
                    .Where(b => b.MaNV == _maNhanVien)
                    .Sum(b => b.TongLuong);

                // Hiển thị tổng thu nhập bên dưới
                Label lblTong = new Label
                {
                    Text = $"Tổng thu nhập: {tongThuNhap:N0} ₫",
                    Dock = DockStyle.Bottom,
                    Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                    Height = 40,
                    TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 15, 0)
                };

                guna2Panel1.Controls.Add(lblTong);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
