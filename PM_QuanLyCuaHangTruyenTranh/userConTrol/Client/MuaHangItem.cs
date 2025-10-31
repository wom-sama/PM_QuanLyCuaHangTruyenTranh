using PM.DAL.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Client
{
    public partial class MuaHangItem : UserControl
    {
        private Sach _sach;
        private int _soLuong;

        public MuaHangItem(Sach sach, int soLuong)
        {
            InitializeComponent();
            _sach = sach;
            _soLuong = soLuong;
            LoadData();
        }

        private void LoadData()
        {
            lblTenSach.Text = _sach.TenSach;
            lblGiaSach.Text = $"{_sach.GiaBan:N0} ₫";
            lblSoLuong.Text = _soLuong.ToString();

            if (_sach.BiaSach != null && _sach.BiaSach.Length > 0)
            {
                using (var ms = new MemoryStream(_sach.BiaSach))
                    picBiaSach.Image = Image.FromStream(ms);
            }
            else
            {
                picBiaSach.Image = Properties.Resources.sparkle_hanabi; // ảnh mặc định
            }
        }
    }
}
