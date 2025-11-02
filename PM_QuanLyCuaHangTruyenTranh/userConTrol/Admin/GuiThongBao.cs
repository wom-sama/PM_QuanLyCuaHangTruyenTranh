using PM.BUS.Services;
using PM.BUS.Services.TaiKhoansv;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Admin
{
    public partial class GuiThongBao : UserControl
    {
        ThongBaoService thongBaoService = new ThongBaoService();
        NhanVienService nhanVienService = new NhanVienService();
        KhachHangService khachHangService = new KhachHangService();
        public GuiThongBao()
        {
            InitializeComponent();
        }

        private void GuiThongBao_Load(object sender, EventArgs e)
        {
            cbo_nhanVien.Visible=false;
            cbo_Khack.Visible = false;
            Common.Edit_Lable.AdjustFontSize(lbl_title);
            txt_TuaDe.PlaceholderText = "Nhập tiêu đề thông báo...";
            RTB_NoiDung.Text = "...";
            //mac dinh chon gui tat ca
            check_ALL.Checked = true;
            //load danh sach nhan vien vao combobox
            var danhSachNhanVien = nhanVienService.GetAll();
            cbo_nhanVien.DataSource = danhSachNhanVien.ToList();
            cbo_nhanVien.DisplayMember = "HoTen"; // Thuộc tính hiển thị
            cbo_nhanVien.ValueMember = "MaNV";   // Thuộc tính giá trị
            cbo_nhanVien.SelectedIndex = -1; // Không chọn mục nào ban đầu
            //load danh sach khach hang vao combobox
            var danhSachKhachHang = khachHangService.LayTatCa();
            cbo_Khack.DataSource = danhSachKhachHang.ToList();
            cbo_Khack.DisplayMember = "HoTen"; // Thuộc tính hiển thị
            cbo_Khack.ValueMember = "TenDangNhap";   // Thuộc tính giá trị
            cbo_Khack.SelectedIndex = -1; // Không chọn mục nào ban đầu




        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            //kiểm tra tiêu đề và nội dung
            if (string.IsNullOrWhiteSpace(txt_TuaDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề thông báo.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //kiểm tra gửi cho ai
            if (!check_ALL.Checked && !check_One.Checked && !check_Khach.Checked)
            {
                MessageBox.Show("Vui lòng chọn người nhận thông báo.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (check_ALL.Checked)
                {
                    //gửi cho tất cả nhân viên
                    var tb = new DAL.Models.ThongBao
                    {
                        MaThongBao = BUS.Helpers.RandHelper.TaoMa("TB"),
                        TieuDe = txt_TuaDe.Text,
                        NoiDung = RTB_NoiDung.Text,
                        NgayGui = DateTime.Now,
                        NguoiNhan = "ALL"
                    };
                    thongBaoService.Add(tb);

                }
                else if (check_One.Checked)
                {
                    //gửi cho nhân viên cụ thể
                    var tb = new DAL.Models.ThongBao
                    {
                        MaThongBao = BUS.Helpers.RandHelper.TaoMa("TB"),
                        TieuDe = txt_TuaDe.Text,
                        NoiDung = RTB_NoiDung.Text,
                        NgayGui = DateTime.Now,
                        NguoiNhan = cbo_nhanVien.SelectedValue.ToString()
                    };
                    thongBaoService.Add(tb);


                }
                else if (check_Khach.Checked)
                {
                    //gửi cho khách hàng cụ thể
                    var tb = new DAL.Models.ThongBao
                    {
                        MaThongBao = BUS.Helpers.RandHelper.TaoMa("TB"),
                        TieuDe = txt_TuaDe.Text,
                        NoiDung = RTB_NoiDung.Text,
                        NgayGui = DateTime.Now,
                        NguoiNhan = cbo_Khack.SelectedValue.ToString()
                    };
                    thongBaoService.Add(tb);
                    MessageBox.Show("Gửi thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi thông báo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void check_One_CheckedChanged(object sender, EventArgs e)
        {
            //hiện combobox chọn nhân viên neu chọn gửi cho 1 nhân viên
            cbo_nhanVien.Visible = check_One.Checked;

        }

        private void check_Khach_CheckedChanged(object sender, EventArgs e)
        {
           
            cbo_Khack.Visible = check_Khach.Checked;

        }
    }
}
