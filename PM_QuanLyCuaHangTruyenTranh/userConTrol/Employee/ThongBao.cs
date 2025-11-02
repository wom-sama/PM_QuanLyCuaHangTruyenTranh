using PM.BUS.Services;
using PM.BUS.Services.Facade;
using PM.DAL;
using PM.DAL.Interfaces;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class ThongBao : UserControl
    {
        private readonly ThongBaoService _service;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NhanVien _nhanVien;
        public ThongBao(NhanVien nv)
        {
            InitializeComponent();
            _nhanVien = nv;
            // ✅ Khởi tạo UnitOfWork và ThongBaoService đúng thứ tự
            _unitOfWork = new UnitOfWork();            // ✅ khởi tạo UnitOfWork
            _service = new ThongBaoService(_unitOfWork); // ✅ truyền vào constructor
        }

        private void ThongBao_Load(object sender, EventArgs e)
        {
            HienThiThongBao();
        }

        private void HienThiThongBao()
        {
            var ds = _service.GetListByNguoiNhan(_nhanVien.MaNV);

            panelDanhSach.Controls.Clear();

            if (ds.Count == 0)
            {
                Label lbl = new Label
                {
                    Text = "Không có thông báo nào.",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Dock = DockStyle.Top
                };
                panelDanhSach.Controls.Add(lbl);
                return;
            }

            foreach (var tb in ds)
            {
                Panel item = new Panel
                {
                    Height = 70,
                    Dock = DockStyle.Top,
                    Padding = new Padding(10),
                    BackColor = Color.WhiteSmoke
                };

                Label lblTieuDe = new Label
                {
                    Text = tb.TieuDe,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = true,
                    Dock = DockStyle.Top
                };

                Label lblNoiDung = new Label
                {
                    Text = tb.NoiDung,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    AutoSize = true,
                    Dock = DockStyle.Top
                };

                Label lblNgay = new Label
                {
                    Text = tb.NgayGui.ToString("dd/MM/yyyy HH:mm"),
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = Color.DimGray,
                    Dock = DockStyle.Bottom
                };

                item.Controls.Add(lblNgay);
                item.Controls.Add(lblNoiDung);
                item.Controls.Add(lblTieuDe);

                panelDanhSach.Controls.Add(item);
                panelDanhSach.Controls.SetChildIndex(item, 0); // đẩy lên trên cùng
            }
        }
    }
}
