using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee
{
    public partial class XemDon : UserControl
    {
        AppDbContext db = new AppDbContext();

        public XemDon()
        {
            InitializeComponent();
        }

        private void XemDon_Load(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void LoadDonHang(string trangThai = null)
        {
            try
            {
                var query = db.DonHangs.AsQueryable();

                if (!string.IsNullOrEmpty(trangThai))
                {
                    query = query.Where(d => d.TrangThai == trangThai);
                }

                var data = query
                    .Select(d => new
                    {
                        Mã_Đơn_Hàng = d.MaDonHang,
                        Khách_Hàng = d.Khach.HoTen,
                        Nhân_Viên = d.NhanVien.HoTen,
                        Ngày_Đặt = d.NgayDat,
                        Ngày_Giao = d.NgayGiao,
                        Tổng_Tiền = d.TongTien,
                        Trạng_Thái = d.TrangThai
                    })
                    .ToList();

                guna2DataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đơn hàng: " + ex.Message);
            }
        }




        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            LoadDonHang("Đang xử lý");
        }

        private void btnDangGiao_Click(object sender, EventArgs e)
        {
            LoadDonHang("Đang giao");
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void btnĐaGiao_Click(object sender, EventArgs e)
        {
            LoadDonHang("Đã giao");
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void btnDaban_Click(object sender, EventArgs e)
        {
            LoadDonHang("Đã bán");
        }
    }
}
