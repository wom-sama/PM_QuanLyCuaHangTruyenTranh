using PM.BUS.Services.VanChuyensv;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class ChiTietKho : UserControl
    {
        private readonly KhoService _khoService;
        private readonly string _maKho;

        // Thêm delegate để hiển thị UserControl khác
        private readonly Action<UserControl> _hienThiUC;

        public ChiTietKho(string maKho, Action<UserControl> hienThiUC)
        {
            InitializeComponent();

            _maKho = maKho;
            _hienThiUC = hienThiUC;

            _khoService = new KhoService(new PM.DAL.UnitOfWork());

            LoadChiTietKho();
        }

        private void LoadChiTietKho()
        {
            try
            {
                var nhapKhos = _khoService.GetByKho(_maKho);

                var data = nhapKhos
                    .SelectMany(nk => nk.CT_NhapKhos ?? new List<CT_NhapKho>())
                    .Select(ct => new
                    {
                        MaSach = ct.MaSach,
                        TenSach = ct.Sach?.TenSach ?? "N/A",
                        TheLoai = ct.Sach?.TheLoai?.TenTheLoai ?? "N/A",
                        SoLuong = ct.SoLuong
                    })
                    .ToList();

                dgvChiTiet.DataSource = data;

                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    if (soLuong < 5)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.Cells["SoLuong"].ToolTipText = "Cần nhập thêm sách!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load chi tiết kho: " + ex.Message);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Sử dụng delegate để quay về Kho
            _hienThiUC?.Invoke(new Kho(_hienThiUC));
        }
    }
}
