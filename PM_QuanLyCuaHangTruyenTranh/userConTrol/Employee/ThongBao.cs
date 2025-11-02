using PM.BUS.Services;
using PM.BUS.Services.Facade;
using PM.DAL;
using PM.DAL.Interfaces;
using PM.DAL.Models;
using System;
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

            // Khởi tạo UnitOfWork và Service
            _unitOfWork = new UnitOfWork();
            _service = new ThongBaoService(_unitOfWork);

            // Đăng ký Load event
            this.Load += ThongBao_Load;

            // Bật scroll panel
            panelDanhSach.AutoScroll = true;
            panelDanhSach.BackColor = Color.WhiteSmoke;
        }

        private void ThongBao_Load(object sender, EventArgs e)
        {
            HienThiThongBao();
        }

        private void HienThiThongBao()
        {
            // Lấy tất cả thông báo chung (ALL)
            var dsChung = _service.GetAllThongBaoChung();

            // Nếu muốn hiển thị cả thông báo cá nhân:
            // var dsCaNhan = _service.GetAllThongBaoCaNhan(_nhanVien.MaNV);
            // var ds = dsChung.Concat(dsCaNhan).OrderByDescending(tb => tb.NgayGui).ToList();

            var ds = dsChung.OrderByDescending(tb => tb.NgayGui).ToList();

            panelDanhSach.Controls.Clear();

            if (ds.Count == 0)
            {
                Label lbl = new Label
                {
                    Text = "Không có thông báo nào.",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Dock = DockStyle.Top,
                    Padding = new Padding(10)
                };
                panelDanhSach.Controls.Add(lbl);
                return;
            }

            foreach (var tb in ds)
            {
                Panel item = new Panel
                {
                    Height = 80,
                    Dock = DockStyle.Top,
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    BackColor = Color.White
                };

                // Tiêu đề
                Label lblTieuDe = new Label
                {
                    Text = tb.TieuDe,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = true,
                    Dock = DockStyle.Top
                };

                // Nội dung
                Label lblNoiDung = new Label
                {
                    Text = tb.NoiDung,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    AutoSize = true,
                    Dock = DockStyle.Top
                };

                // Ngày gửi
                Label lblNgay = new Label
                {
                    Text = tb.NgayGui.ToString("dd/MM/yyyy HH:mm"),
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    ForeColor = Color.DimGray,
                    Dock = DockStyle.Bottom
                };

                // Thêm controls vào panel item
                item.Controls.Add(lblNgay);
                item.Controls.Add(lblNoiDung);
                item.Controls.Add(lblTieuDe);

                // Thêm panel item vào panelDanhSach
                panelDanhSach.Controls.Add(item);
                panelDanhSach.Controls.SetChildIndex(item, 0); // Đẩy item mới lên trên cùng
            }
        }
    }
}
