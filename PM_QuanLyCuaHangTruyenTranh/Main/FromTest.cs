using PM.BUS.Services.TaiKhoansv;
using PM.BUS.Services;
using PM.DAL.Models;
using PM.GUI.userConTrol.Admin;
using PM.GUI.userConTrol.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PM.GUI.Main
{
    public partial class FromTest : Form
    {
        private KhachHang currentKhachHang; // Lấy từ user đăng nhập
        private Shop_BookView shopView;

        public FromTest(KhachHang kh)
        {
            InitializeComponent();
            currentKhachHang = kh;
            NhanVienService sv=new NhanVienService();
           // NhanVien a= sv.GetById("NV_ONLINE_HCM");
            shopView = new Shop_BookView(currentKhachHang)
            {
                Dock = DockStyle.Fill
            };

            PanelTest.Controls.Add(shopView);
        }
    }

}
