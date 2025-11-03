using PM.BUS.Services.VanChuyensv; // KhoService, NhapKhoService
using PM.DAL;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class Kho : UserControl
    {
        private readonly KhoService _khoService;
        private readonly NhapKhoService _nhapKhoService;
        private readonly Action<UserControl> _hienThiUC;
        private readonly NhanVien _currentNV;

        public Kho(NhanVien nhanVien, Action<UserControl> hienThiUC)
        {
            InitializeComponent();
            _currentNV = nhanVien;
            _hienThiUC = hienThiUC;

            // Khởi tạo service
            _khoService = new KhoService(new UnitOfWork());
            _nhapKhoService = new NhapKhoService(new UnitOfWork());

            LoadKhoTheoChiNhanh();
            this.Load += Kho_Load;

            dgvKho.CellDoubleClick += DgvKho_CellDoubleClick;
        }


        private void Kho_Load(object sender, EventArgs e)
        {
            LoadKhoTheoChiNhanh();
        }

         /// Load danh sách kho thuộc chi nhánh của nhân viên hiện tại

        private void LoadKhoTheoChiNhanh()
        {
            try
            {
                // Lấy danh sách kho theo chi nhánh
                var listKho = _khoService.GetByChiNhanh(_currentNV.MaChiNhanh).ToList();

                var data = listKho.Select(k =>
                {
                    int tongSoSach = TinhTongTonKhoTheoKho(k.MaKho, _currentNV.MaChiNhanh);

                    return new
                    {
                        MaKho = k.MaKho,
                        TenKho = k.TenKho,
                        LoaiKho = k.LoaiKho,
                        TongSoSach = tongSoSach
                    };
                }).ToList();

                dgvKho.DataSource = data;

                // Cấu hình hiển thị
                dgvKho.Columns["MaKho"].HeaderText = "Mã Kho";
                dgvKho.Columns["TenKho"].HeaderText = "Tên Kho";
                dgvKho.Columns["LoaiKho"].HeaderText = "Loại Kho";
                dgvKho.Columns["TongSoSach"].HeaderText = "Số lượng sách nhập";

                // Highlight kho có sách < 5
                foreach (DataGridViewRow row in dgvKho.Rows)
                {
                    if (row.Cells["TongSoSach"].Value != null &&
                        int.TryParse(row.Cells["TongSoSach"].Value.ToString(), out int soLuong))
                    {
                        if (soLuong < 5)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            row.DefaultCellStyle.ForeColor = Color.White;
                            row.Cells["TongSoSach"].ToolTipText = "Cần nhập thêm sách!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// Tính tổng tồn kho thực tế (Tổng nhập - Tổng bán)
        private int TinhTongTonKhoTheoKho(string maKho, string maChiNhanh)
        {
            try
            {
                // Lấy tất cả phiếu nhập của kho
                var nhapKhos = _nhapKhoService.GetByKho(maKho);

                // Tổng nhập
                int tongNhap = nhapKhos
                    .SelectMany(nk => nk.CT_NhapKhos ?? new List<CT_NhapKho>())
                    .Sum(ct => ct.SoLuong);

                // Tổng bán của chi nhánh (qua KhoService)
                int tongBan = 0;
                var sachTrongKho = nhapKhos
                    .SelectMany(nk => nk.CT_NhapKhos ?? new List<CT_NhapKho>())
                    .Select(ct => ct.MaSach)
                    .Distinct()
                    .ToList();

                foreach (var maSach in sachTrongKho)
                {
                    tongBan += _khoService.LaySoLuongBanTheoSach(maSach, maChiNhanh);
                }

                return tongNhap - tongBan;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        /// Khi double click vào 1 kho => mở ChiTietKho
        private void DgvKho_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maKho = dgvKho.Rows[e.RowIndex].Cells["MaKho"].Value.ToString();
            _hienThiUC?.Invoke(new ChiTietKho(maKho, _currentNV, _hienThiUC));

        }
    }
}
