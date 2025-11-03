using PM.BUS.Services;
using PM.BUS.Services.TaiKhoansv;
using PM.DAL.Models;
using PM.GUI.FormThongBao;
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
            cbo_nhanVien.SelectedIndex = 0;
            //load danh sach khach hang vao combobox
            var danhSachKhachHang = khachHangService.LayTatCa();
            cbo_Khack.DataSource = danhSachKhachHang.ToList();
            cbo_Khack.DisplayMember = "HoTen"; // Thuộc tính hiển thị
            cbo_Khack.ValueMember = "TenDangNhap";   // Thuộc tính giá trị
            cbo_Khack.SelectedIndex = 0;




        }
        private void ShowMessage(string text)
        {
            var fm = new FormMessage(text);
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
        }
        private void CleanTT()
        {
            this.RTB_NoiDung.Text = "...";
            this.txt_TuaDe.Text = null;
            this.check_ALL.Checked = true;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            //kiểm tra tiêu đề và nội dung
            if (string.IsNullOrWhiteSpace(txt_TuaDe.Text))
            {
                ShowMessage("Vui Lòng nhập tự đề thông báo");
                return;
            }
            //kiểm tra gửi cho ai
            if (!check_ALL.Checked && !check_One.Checked && !check_Khach.Checked)
            {
                ShowMessage("Vui lòng chọn người nhận");
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
                    ShowMessage("Gửi Thông Báo Thành Công");
                    CleanTT();
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
                    ShowMessage("Gửi Thông Báo Thành Công");
                    CleanTT();

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
                    ShowMessage("Gửi Thông Báo Thành Công");
                    CleanTT();
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Lỗi Khi Gửi" + ex.Message);
                CleanTT();
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
