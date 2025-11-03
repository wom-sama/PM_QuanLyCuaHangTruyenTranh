using PM.BUS.Services.TaiKhoansv;
using PM.BUS.Services.VanChuyensv;
using PM.DAL.Models;
using PM.GUI;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Common
{
    public partial class ShowTTCN : UserControl
    {
        private NhanVien _nhanVien;
        private readonly NhanVienService _nhanVienService;
        private readonly ChucVuService _chucVuService;
        private readonly ChiNhanhService _chiNhanhService;

        private bool _isEditing = false;

        public ShowTTCN(string nhanVien)
        {
            InitializeComponent();
         
            _nhanVienService = new NhanVienService();
            _chucVuService = new ChucVuService(new PM.DAL.UnitOfWork());
            _chiNhanhService = new ChiNhanhService(new PM.DAL.UnitOfWork());
            _nhanVien=_nhanVienService.GetById(nhanVien);
            this.Load += ShowTTCN_Load;
        }

        private void ShowTTCN_Load(object sender, EventArgs e)
        {
            // Ẩn groupbox và nút Lưu/Hủy
            //grb_TTCN.Visible = false;
            btn_Luu.Visible = false;
            btn_Huy.Visible = false;
            btn_Luu.Enabled = false;
            btn_Huy.Enabled = false;
            btn_suaAnh.Enabled = false;
            btn_suaAnh.Visible = false;

            // Khóa input ban đầu
            SetEnableInput(false);
            txt_maNV.Enabled = false;
            txt_ChucVu.Enabled = false;
            txt_ChiNhanh.Enabled = false;
           
         
            
          

            // Load dữ liệu nhân viên
            LoadNhanVienInfo();
        }

        private void LoadNhanVienInfo()
        {
            if (_nhanVien == null) return;
            txt_maNV.Text = _nhanVien.MaNV;
            txt_HoTen.Text = _nhanVien.HoTen;
            DTP_NgaySinh.Value = _nhanVien.NgaySinh;
         
            txt_SDT.Text = _nhanVien.SoDienThoai;
            txt_Email.Text = _nhanVien.Email;
            txt_DC.Text = _nhanVien.DiaChi;
            // Load Chức Vụ
            var chucVu = _chucVuService.GetById(_nhanVien.MaChucVu);
            txt_ChucVu.Text = chucVu != null ? chucVu.TenChucVu : "";
            // Load Chi Nhánh
            var chiNhanh = _chiNhanhService.GetById(_nhanVien.MaChiNhanh);
            txt_ChiNhanh.Text = chiNhanh != null ? chiNhanh.TenChiNhanh : "";
            //Load Giới Tính
            cbo_GioiTinh.SelectedIndex = cbo_GioiTinh.Items.IndexOf(_nhanVien.GioiTinh);
            // Load Ảnh Đại Diện
            if (_nhanVien.AnhDaiDien != null && _nhanVien.AnhDaiDien.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(_nhanVien.AnhDaiDien))
                {
                    pic_AnhDaiDien.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pic_AnhDaiDien.Image =null; 
            }
        }

        private void SetEnableInput(bool enable)
        {
            
            txt_HoTen.Enabled = enable;
            txt_SDT.Enabled = enable;
            txt_Email.Enabled = enable;
            DTP_NgaySinh.Enabled = enable;
            cbo_GioiTinh.Enabled = enable;
            txt_DC.Enabled = enable;


        }

        private void Btn_Sua_Click(object sender, EventArgs e)
        {
            // Bật chế độ chỉnh sửa
            _isEditing = true;
            SetEnableInput(true);
            // Hiện nút Lưu và Hủy
            btn_Luu.Visible = true;
            btn_Huy.Visible = true;
            btn_Luu.Enabled = true;
            btn_Huy.Enabled = true;
            btn_suaAnh.Enabled = true;
            btn_suaAnh.Visible = true;

        }

        private void Btn_Huy_Click(object sender, EventArgs e)
        {
            // Hủy chỉnh sửa, tắt chế độ chỉnh sửa
            _isEditing = false;
            SetEnableInput(false);
            // Ẩn nút Lưu và Hủy
            btn_Luu.Visible = false;
            btn_Huy.Visible = false;
            btn_Luu.Enabled = false;
            btn_Huy.Enabled = false;
            btn_suaAnh.Visible = false;
            btn_suaAnh.Enabled = false;
            // Load lại thông tin nhân viên
            LoadNhanVienInfo();

        }

        private void Btn_Luu_Click(object sender, EventArgs e)
        {
            // Lưu thông tin chỉnh sửa
            _isEditing = false;
            SetEnableInput(false);
            // Ẩn nút Lưu và Hủy
            btn_Luu.Visible = false;
            btn_Huy.Visible = false;
            btn_Luu.Enabled = false;
            btn_Huy.Enabled = false;
            btn_suaAnh.Visible = false;
            btn_suaAnh.Enabled = false;
            // Cập nhật thông tin nhân viên
            _nhanVien.HoTen = txt_HoTen.Text;
            _nhanVien.NgaySinh = DTP_NgaySinh.Value;
            _nhanVien.GioiTinh = cbo_GioiTinh.Text;
            _nhanVien.SoDienThoai = txt_SDT.Text;
            _nhanVien.Email = txt_Email.Text;
            _nhanVien.DiaChi = txt_DC.Text;
            // Cập nhật vào database
            _nhanVienService.Update(_nhanVien);


        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void btn_suaAnh_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn ảnh
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh đại diện";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị ảnh lên PictureBox
                    string selectedImagePath = openFileDialog.FileName;
                    pic_AnhDaiDien.Image = Image.FromFile(selectedImagePath);
                    // Lưu ảnh vào database dưới dạng byte array
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pic_AnhDaiDien.Image.Save(ms, pic_AnhDaiDien.Image.RawFormat);
                        _nhanVien.AnhDaiDien = ms.ToArray();
                    }
                    // Cập nhật vào database
                    _nhanVienService.Update(_nhanVien);
                }
            }

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void DTP_NgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Panel_Tong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void grb_TTCN_Click(object sender, EventArgs e)
        {

        }
    }
}
