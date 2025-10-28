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

        public Kho(Action<UserControl> hienThiUC)
        {
            InitializeComponent();

            _hienThiUC = hienThiUC;

            // Khởi tạo service
            _khoService = new KhoService(new UnitOfWork());
            _nhapKhoService = new NhapKhoService(new UnitOfWork());

            // Load dữ liệu
            this.Load += Kho_Load;

            // Thêm event double click vào DataGridView
            dgvKho.CellDoubleClick += DgvKho_CellDoubleClick;
        }

        private void Kho_Load(object sender, EventArgs e)
        {
            LoadKhoData();
        }

        private void LoadKhoData()
        {
            try
            {
                var listKho = _khoService.GetAll().ToList();

                var data = listKho.Select(k =>
                {
                    int tongSoSach = _nhapKhoService.GetByKho(k.MaKho)
                        .SelectMany(nk => nk.CT_NhapKhos ?? new List<CT_NhapKho>())
                        .Sum(ct => ct.SoLuong);

                    return new
                    {
                        MaKho = k.MaKho,
                        TenKho = k.TenKho,
                        LoaiKho = k.LoaiKho,
                        TongSoSach = tongSoSach
                    };
                }).ToList();

                dgvKho.DataSource = data;

                // Highlight kho có sách < 5
                foreach (DataGridViewRow row in dgvKho.Rows)
                {
                    int soLuong = Convert.ToInt32(row.Cells["TongSoSach"].Value);
                    if (soLuong < 5)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.Cells["TongSoSach"].ToolTipText = "Cần nhập thêm sách!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu kho: " + ex.Message);
            }
        }

        // Event double click mở ChiTietKho
        private void DgvKho_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maKho = dgvKho.Rows[e.RowIndex].Cells["MaKho"].Value.ToString();
            _hienThiUC?.Invoke(new ChiTietKho(maKho, _hienThiUC));
        }
    }
}
