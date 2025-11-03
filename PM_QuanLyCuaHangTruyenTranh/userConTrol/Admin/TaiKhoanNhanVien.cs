using PM.BUS.Services;
using PM.BUS.Services.TaiKhoansv;
using PM.BUS.Services.VanChuyensv;
using PM.DAL;
using PM.DAL.Models;
using PM.GUI.userConTrol.Common;
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
    public partial class TaiKhoanNhanVien : UserControl
    {
        NhanVienService _nhanViensv ;
        TaiKhoanService _taiKhoansv ;
        ChiNhanhService _chiNhanhsv = new ChiNhanhService();
        ChucVuService _chucVusv = new ChucVuService();
        // thuoc tinh doi tuong nhan vien
        TaiKhoan _taiKhoan = new TaiKhoan();
        NhanVien _nhanVien = new NhanVien();
        public TaiKhoanNhanVien()
        {
            InitializeComponent();
           SetNhanVienThem();
            UnitOfWork unitOfWork = new UnitOfWork();
            _nhanViensv = new NhanVienService(unitOfWork);
            _taiKhoansv = new TaiKhoanService (unitOfWork);



        }
        private void SetNhanVienThem()
        {
            _taiKhoan.Quyen = "NhanVien";
            _taiKhoan.TrangThai = true;
            _nhanVien.TrangThai = true;
            _nhanVien.MaNV = BUS.Helpers.RandHelper.TaoMa("NV");
            _nhanVien.GioiTinh = "Khác";
            _nhanVien.NgaySinh = DateTime.Now.AddYears(-18);
            _nhanVien.DiaChi = "Chưa cập nhật";
            _nhanVien.Email = "Chưa cập nhật";
            _nhanVien.SoDienThoai = "Chưa cập nhật";
            _nhanVien.HoTen = "Chưa cập nhật";
            _nhanVien.AnhDaiDien = null;

        }

        private void panel_tong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            //load datadirdview
            DGV_TaiKhoanNhanVien.DataSource = _taiKhoansv.GetTaiKhoanNhanVien().ToList();
            //load chuc vu va chi nhanh khi them va khi sua
            var chucVus = _chucVusv.GetAll().ToList();
            var chiNhanhs = _chiNhanhsv.GetAll().ToList();
            cbo_ChucVuThem.DataSource = chucVus;
            cbo_ChucVuThem.DisplayMember = "TenChucVu";
            cbo_ChucVuThem.ValueMember = "MaChucVu";
            cbo_ChiNhanhThem.DataSource = chiNhanhs;
            cbo_ChiNhanhThem.DisplayMember = "TenChiNhanh";
            cbo_ChiNhanhThem.ValueMember = "MaChiNhanh";
            cbo_CvSua.DataSource = chucVus;
            cbo_CvSua.DisplayMember = "TenChucVu";
            cbo_CvSua.ValueMember = "MaChucVu";
            cbo_ChiNhanhSua.DataSource = chiNhanhs;
            cbo_ChiNhanhSua.DisplayMember = "TenChiNhanh";
            cbo_ChiNhanhSua.ValueMember = "MaChiNhanh";

            //them tieu de va lam dep data
            if (DGV_TaiKhoanNhanVien.Columns.Count > 0)
            {
                DGV_TaiKhoanNhanVien.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                DGV_TaiKhoanNhanVien.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                DGV_TaiKhoanNhanVien.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
                DGV_TaiKhoanNhanVien.Columns["TenChiNhanh"].HeaderText = "Chi nhánh";
                DGV_TaiKhoanNhanVien.Columns["TenChucVu"].HeaderText = "Chức vụ";
            }

            // Tùy chỉnh hiển thị cho đẹp
            DGV_TaiKhoanNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_TaiKhoanNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_TaiKhoanNhanVien.MultiSelect = false;
            DGV_TaiKhoanNhanVien.AllowUserToAddRows = false;
            DGV_TaiKhoanNhanVien.ReadOnly = true;

            // Tùy chỉnh header
            DGV_TaiKhoanNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            DGV_TaiKhoanNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Căn giữa nội dung
            DGV_TaiKhoanNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_TaiKhoanNhanVien.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            //dieu chinh khac
            Edit_Lable.AdjustFontSize(lbl_Title);
            panel_Sua.Visible = false;
            panel_Sua.Enabled = false;
            Panel_Them.Visible = false;
            Panel_Them.Enabled = false;



        }

        private void DGV_TaiKhoanNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            try
            {
                // Giả định textbox tìm kiếm có tên txt_Tim.
                // Nếu tên textbox khác, đổi txt_Tim thành tên thực tế.
                string keyword = string.Empty;
                keyword = txtTim.Text.Trim();
                // Nếu không có từ khóa hiển thị lại toàn bộ danh sách
                var all = _taiKhoansv.GetTaiKhoanNhanVien().ToList();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    DGV_TaiKhoanNhanVien.DataSource = all;
                    return;
                }

                // Lọc theo tên nhân viên (không phân biệt hoa thường)
                var filtered = all
                    .Where(r =>
                    {
                        // r is an anonymous object so use reflection-safe access via dynamic-like approach
                        try
                        {
                            var prop = r.GetType().GetProperty("TenNhanVien");
                            if (prop == null) return false;
                            var val = prop.GetValue(r) as string;
                            return !string.IsNullOrEmpty(val) && val.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
                        }
                        catch
                        {
                            return false;
                        }
                    })
                    .ToList();

                if (filtered.Any())
                {
                    DGV_TaiKhoanNhanVien.DataSource = filtered;
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy nhân viên có tên chứa \"{keyword}\".", "Kết quả tìm kiếm");
                    DGV_TaiKhoanNhanVien.DataSource = new List<object>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi");
            }




        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            //lay thong  tin hang dang chon
            if (DGV_TaiKhoanNhanVien.SelectedRows.Count > 0)
            {
                var selectedRow = DGV_TaiKhoanNhanVien.SelectedRows[0];
                string tenDangNhap = selectedRow.Cells["TenDangNhap"].Value.ToString();
                //xac nhan xoa
                var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa tài khoản \"{tenDangNhap}\"?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    //thuc hien xoa
                    bool success = _taiKhoansv.Delete(tenDangNhap);
                    //xoa nhan vien lien quan
                    var nhanVien = _nhanViensv.GetAll().FirstOrDefault(nv => nv.MaNV == _taiKhoansv.GetById(tenDangNhap).MaNhanVien);

                    bool successnv = _nhanViensv.Delete(nhanVien.MaNV);

                    if (success && successnv)
                    {
                        MessageBox.Show("Xóa tài khoản và nhân viên thành công!");
                        //tai lai du lieu
                        DGV_TaiKhoanNhanVien.DataSource = _taiKhoansv.GetTaiKhoanNhanVien().ToList();
                    }
                    else
                    {
                        MessageBox.Show("Xóa tài khoản thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa.");
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            //dong panel sua neu dang mo
            if (panel_Sua.Enabled == true)
            {
                TransT.Hide(panel_Sua);
                panel_Sua.Enabled = false;
            }
                //hiem  thi panel them voi hieu ung
                TransT.ShowSync(Panel_Them);
           
            Panel_Them.Enabled = true;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            //Dong panel them neu dang mo
            if (Panel_Them.Enabled == true)
            {   TransT.Hide(Panel_Them);
                Panel_Them.Enabled = false;
            }
                // Hiện panel sửa
                TransT.Show(panel_Sua);
            panel_Sua.Enabled = true;
            //khong cho nguoi dung chon dong khac khi dang sua

            // Kiểm tra có chọn dòng nào chưa
            if (DGV_TaiKhoanNhanVien.SelectedRows.Count > 0)
            {
                var selectedRow = DGV_TaiKhoanNhanVien.SelectedRows[0];

                // Lấy dữ liệu từ dòng đang chọn
              

                string maNV = selectedRow.Cells["MaNV"].Value?.ToString();
                _nhanVien= _nhanViensv.GetById(maNV);

                // Hiển thị tên nhân viên hoặc các thông tin khác lên ô sửa (nếu có)
                txtTenNhanVienSua.Text = _nhanVien.HoTen; // ví dụ textbox sửa tên

                // Gán giá trị Chức vụ và Chi nhánh cho combobox
                cbo_CvSua.SelectedValue = _nhanVien.MaChucVu;
                cbo_ChiNhanhSua.SelectedValue = _nhanVien.MaChiNhanh;
                // Lưu thông tin tài khoản và nhân viên để sửa


            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo");
                panel_Sua.Visible = false;
                panel_Sua.Enabled = false;
            }
        }


        private void btn_huy_Click(object sender, EventArgs e)
        {
            //an panel sua
            TransT.Hide(panel_Sua);
            panel_Sua.Enabled = false;
            SetNhanVienThem();

        }

        private void btn_Bo_Click(object sender, EventArgs e)
        {
            //an panel them
            TransT.Hide(Panel_Them);
            Panel_Them.Enabled = false;
            SetNhanVienThem ();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            panel_Sua.Visible = false;
            panel_Sua.Enabled = false;
            //cap nhat thong tin tai khoan va nhan vien

            _nhanVien.MaChucVu = cbo_CvSua.SelectedValue.ToString();
            _nhanVien.MaChiNhanh = cbo_ChiNhanhSua.SelectedValue.ToString();
            //thuc hien cap nhat
            
            bool successnv = _nhanViensv.Update(_nhanVien);

            if (successnv)
            {
                //tai lai du lieu
                DGV_TaiKhoanNhanVien.DataSource = _taiKhoansv.GetTaiKhoanNhanVien().ToList();
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
               
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thất bại!");


            }
            SetNhanVienThem();
        }

        private void btn_Tao_Click(object sender, EventArgs e)
        {
            panel_Sua.Visible = false; panel_Sua.Enabled = false;
            Panel_Them.Visible = false; Panel_Them.Enabled = false;
            SetNhanVienThem();
            //tao tai khoan va nhan vien moi
            _taiKhoan.TenDangNhap = txtTaiKhoan.Text.Trim();
            _taiKhoan.MatKhau = BUS.Helpers.PasswordHelper.HashPassword(txt_MatKhau.Text.Trim());
            _taiKhoan.MaNhanVien = _nhanVien.MaNV;
            _taiKhoan.TrangThai = true;
            _taiKhoan.Quyen = "NhanVien";
            _nhanVien.MaChucVu = cbo_ChucVuThem.SelectedValue.ToString();
            _nhanVien.MaChiNhanh = cbo_ChiNhanhThem.SelectedValue.ToString();
            //thuc hien them
           
            bool successnv = _nhanViensv.Add(_nhanVien);
            bool successtk = _taiKhoansv.Add(_taiKhoan);
            //kiem tra ket qua
            if (successnv && successtk)
            {
                //tai lai du lieu
                DGV_TaiKhoanNhanVien.DataSource = _taiKhoansv.GetTaiKhoanNhanVien().ToList();
                MessageBox.Show("Tạo tài khoản và nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Tạo tài khoản hoặc nhân viên thất bại!");
            }
        }
    }
}