using PM_QuanLyCuaHangTruyenTranh.Models;
using PM_QuanLyCuaHangTruyenTranh.userConTrol.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Admin
{
    public partial class Edit_BOOk : UserControl
    {
        private AppDbContext db = new AppDbContext();
        private bool hienTheLoai = false;
        public Edit_BOOk()
        {
            InitializeComponent();
        }
        private void HienTatCaSach()
        {
            panelDanhSach.Controls.Clear();

            var danhSach = db.Sachs.Include("TheLoais").ToList();

            foreach (var sach in danhSach)
            {
                BooKShowcs item = new BooKShowcs(sach);
                item.Margin = new Padding(10);
                panelDanhSach.Controls.Add(item);
            }
        }
        private void TaiDanhSachTheLoai()
        {
            flpTheLoai.Controls.Clear();
            var list = db.TheLoais.ToList();

            foreach (var tl in list)
            {
                CheckBox cb = new CheckBox();
                cb.Text = tl.TenTheLoai;
                cb.Tag = tl.MaTheLoai;
                cb.AutoSize = true;
                cb.Margin = new Padding(10);
                cb.Font = new Font("Segoe UI", 10);
                flpTheLoai.Controls.Add(cb);
            }
        }
        private void LocTheoTheLoai()
        {
            List<string> maTheLoaiChon = new List<string>();

            foreach (CheckBox cb in flpTheLoai.Controls)
            {
                if (cb.Checked)
                    maTheLoaiChon.Add(cb.Tag.ToString());
            }

            if (maTheLoaiChon.Count == 0)
            {
                HienTatCaSach();
                return;
            }

            /*var ketQua = db.Sachs
                .Where(s => s.TheLoais.Any(tl => maTheLoaiChon.Contains(tl.MaTheLoai)))
                .Include("TheLoais")
                .ToList();*/

           // HienDanhSachSach(ketQua);
        }
        private void HienDanhSachSach(List<Sach> danhSach)
        {
            panelDanhSach.Controls.Clear();
            foreach (var sach in danhSach)
            {
                BooKShowcs item = new BooKShowcs(sach);
                item.Margin = new Padding(10);
                panelDanhSach.Controls.Add(item);
            }
        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Edit_BOOk_Load(object sender, EventArgs e)
        {
            // ngan khong cho load 2 lan
            if (DesignMode) return;
            HienTatCaSach();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtFindTen.Text.Trim().ToLower();

            var ketQua = db.Sachs
                .Where(s => s.TenSach.ToLower().Contains(tuKhoa)
                         || s.MaSach.ToLower().Contains(tuKhoa))
                .Include("TheLoais")
                .ToList();

            HienDanhSachSach(ketQua);
        }

        private void btnTheLoai_Click(object sender, EventArgs e)
        {
            hienTheLoai = !hienTheLoai;
            flpTheLoai.Visible = hienTheLoai;

            if (hienTheLoai)
            {
                // Hiện danh sách thể loại
                TaiDanhSachTheLoai();
            }
            else
            {
                // Ẩn flpTheLoai và lọc theo thể loại đã chọn
                LocTheoTheLoai();
            }
        }
    }
}
