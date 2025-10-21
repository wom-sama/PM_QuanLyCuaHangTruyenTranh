using PM.BUS.Services.Sachsv;
using PM.DAL.Models;
using PM_QuanLyCuaHangTruyenTranh.userConTrol.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Admin
{
    public partial class Edit_BOOk : UserControl
    {
        private readonly SachService _sachService = new SachService();
        private readonly TheLoaiService _theLoaiService = new TheLoaiService();
        private bool hienTheLoai = false;

        public Edit_BOOk()
        {
            InitializeComponent();
        }

        private void Edit_BOOk_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            HienTatCaSach();
        }

        private void HienTatCaSach()
        {
            var ds = _sachService.GetAll();
            //HienDanhSachSach(ds);
        }

        private void HienDanhSachSach(List<Sach> ds)
        {
            panelDanhSach.Controls.Clear();
            foreach (var sach in ds)
            {
                BooKShowcs item = new BooKShowcs(sach);
                item.Margin = new Padding(10);
                panelDanhSach.Controls.Add(item);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtFindTen.Text.Trim();
           // var ds = _sachService.FindByKeyword(tuKhoa);
            //HienDanhSachSach(ds);
        }
    }
}
