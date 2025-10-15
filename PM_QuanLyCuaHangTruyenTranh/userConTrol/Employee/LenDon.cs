using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee
{
    public partial class LenDon : UserControl
    {
        AppDbContext db = new AppDbContext();

        public LenDon()
        {

            InitializeComponent();


        }
        private int soLuongTonBanDau = 0;
        private int selectedRowIndex = -1;
        private bool isUpdating = false;
        private void LenDon_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                MessageBox.Show("Form đang load dữ liệu!"); 
                guna2DateTimePicker1.Format = DateTimePickerFormat.Custom;
                guna2DateTimePicker1.CustomFormat = "dd/MM/yyyy";
                LoadSachData();

            }
                
        }

        // Hàm load dữ liệu sách vào bảng
        private void LoadSachData()
        {
            try
            {
                // Kiểm tra có dữ liệu trong bảng không
                int total = db.Sachs.Count();
                //MessageBox.Show("Tổng số sách trong DB: " + total);

                if (total == 0)
                {
                    MessageBox.Show("Không có sách nào trong cơ sở dữ liệu!");
                    return;
                }

                                                var data = db.Sachs
                                    .Include(s => s.TheLoai)
                                    .Include(s => s.CT_NhapKhos)
                                    .Include(s => s.CT_DonHangs)
                                    .AsNoTracking()
                                    .Select(s => new
                                    {
                                        s.MaSach,
                                        s.TenSach,
                                        TenTheLoai = s.TheLoai.TenTheLoai, 
                                        s.GiaBan,
                                        SoLuongTon =
                                            (s.CT_NhapKhos.Sum(n => (int?)n.SoLuong) ?? 0)
                                            - (s.CT_DonHangs.Sum(d => (int?)d.SoLuong) ?? 0)
                                    })
                                    .ToList();

                guna2DataGridView1.DataSource = data;

                guna2DataGridView1.Columns["MaSach"].HeaderText = "Mã Sách";
                guna2DataGridView1.Columns["TenSach"].HeaderText = "Tên Sách";
                guna2DataGridView1.Columns["TenTheLoai"].HeaderText = "Thể Loại";

                guna2DataGridView1.Columns["GiaBan"].HeaderText = "Giá Bán";
                guna2DataGridView1.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu:\n" + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Khi click vào 1 dòng, hiển thị dữ liệu lên textbox
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex; // Lưu lại chỉ số hàng đang chọn
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

                txtMS.Text = row.Cells["MaSach"].Value?.ToString();
                txtS.Text = row.Cells["TenSach"].Value?.ToString();
                txtGS.Text = row.Cells["GiaBan"].Value?.ToString();

                // Lưu số lượng tồn ban đầu (lấy từ DataGridView)
                soLuongTonBanDau = Convert.ToInt32(row.Cells["SoLuongTon"].Value);
                guna2NumericUpDown1.Value = 0;
                txtTT.Text = "0";

                guna2DateTimePicker1.Value = DateTime.Now;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ form
                string maSach = txtMS.Text.Trim();
                string tenSach = txtS.Text.Trim();
                decimal giaBan = decimal.Parse(txtGS.Text);
                int soLuongMua = (int)guna2NumericUpDown1.Value;

                // Kiểm tra dữ liệu
                if (string.IsNullOrEmpty(maSach))
                {
                    MessageBox.Show("Vui lòng chọn sách trước khi tạo đơn.", "Thông báo");
                    return;
                }

                var sach = db.Sachs.FirstOrDefault(s => s.MaSach == maSach);
                if (sach == null)
                {
                    MessageBox.Show("Không tìm thấy sách trong cơ sở dữ liệu!", "Lỗi");
                    return;
                }

                // Tính tồn thực tế
                int soLuongTon = (sach.CT_NhapKhos.Sum(n => (int?)n.SoLuong) ?? 0)
                               - (sach.CT_DonHangs.Sum(d => (int?)d.SoLuong) ?? 0);

                if (soLuongMua <= 0)
                {
                    MessageBox.Show("Số lượng mua phải lớn hơn 0!", "Cảnh báo");
                    return;
                }

                if (soLuongMua > soLuongTon)
                {
                    MessageBox.Show($"Sách '{tenSach}' chỉ còn {soLuongTon} quyển trong kho!", "Không đủ hàng");
                    return;
                }

                // === Tạo mã đơn hàng tự động ===
                string maDonHang = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // === Tạo đơn hàng mới ===
                var donHang = new DonHang
                {
                    MaDonHang = maDonHang,
                    MaKhach = null,// Khach Mua tai cho
                    MaNV = db.NhanViens.FirstOrDefault().MaNV, // Giả sử lấy NV đầu tiên
                    NgayDat = DateTime.Now,
                    NgayGiao = DateTime.Now,
                    TongTien = giaBan * soLuongMua,
                    TrangThai = "Đã bán"
                };
                db.DonHangs.Add(donHang);

                // === Tạo chi tiết đơn hàng ===
                var chiTiet = new CT_DonHang
                {
                    MaDonHang = maDonHang,
                    MaSach = maSach,
                    SoLuong = soLuongMua,
                    DonGia = giaBan,
                    ThanhTien = giaBan * soLuongMua
                };
                db.CT_DonHangs.Add(chiTiet);

                // === Lưu lại ===
                db.SaveChanges();

                MessageBox.Show($"Tạo đơn hàng thành công!\nMã đơn: {maDonHang}\nSách: {tenSach}\nTổng tiền: {giaBan * soLuongMua:N0}đ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại danh sách sách
                LoadSachData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo đơn hàng:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtHT_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtHT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; 
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.Trim().ToLower();

            var data = db.Sachs
                .Include(s => s.TheLoai)
                .Include(s => s.CT_NhapKhos)
                .Include(s => s.CT_DonHangs)
                .AsNoTracking()
                .Where(s =>
                    s.TenSach.ToLower().Contains(keyword) ||
                    s.MaSach.ToLower().Contains(keyword)
                )
                .Select(s => new
                {
                    s.MaSach,
                    s.TenSach,
                    TenTheLoai = s.TheLoai.TenTheLoai,
                    s.GiaBan,
                    SoLuongTon =
                        (s.CT_NhapKhos.Sum(n => (int?)n.SoLuong) ?? 0)
                        - (s.CT_DonHangs.Sum(d => (int?)d.SoLuong) ?? 0)
                })
                .ToList();

            guna2DataGridView1.DataSource = data;
        }

        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0) return; // chưa chọn sách

            try
            {
                if (isUpdating) return;
                isUpdating = true;

                DataGridViewRow row = guna2DataGridView1.Rows[selectedRowIndex];

                if (decimal.TryParse(txtGS.Text, out decimal giaBan))
                {
                    int soLuongMua = (int)guna2NumericUpDown1.Value;

                    // Giới hạn số lượng mua không vượt quá tồn
                    if (soLuongMua > soLuongTonBanDau)
                    {
                        soLuongMua = soLuongTonBanDau;
                        guna2NumericUpDown1.Value = soLuongTonBanDau;
                    }

                    // Tính tổng tiền
                    decimal tongTien = giaBan * soLuongMua;
                    txtTT.Text = tongTien.ToString("N0");

                    // Giảm tạm số lượng tồn trong DataGridView (chỉ hiển thị)
                    row.Cells["SoLuongTon"].Value = soLuongTonBanDau - soLuongMua;
                }
                else
                {
                    txtTT.Text = "0";
                }
            }
            finally
            {
                isUpdating = false;
            }
        }

        private void btnXemDon_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Xem Đơn Hàng";

            // Tạo instance của UserControl
            XemDon xemDonUC = new XemDon();
            xemDonUC.Dock = DockStyle.Fill; // cho UserControl chiếm toàn bộ form

            frm.Controls.Add(xemDonUC);
            frm.Show(); // hiển thị form
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt == null) return;

            // Lấy chỉ các ký tự số từ chuỗi hiện tại
            string onlyDigits = new string(txt.Text.Where(char.IsDigit).ToArray());

            // Giới hạn tối đa 10 số
            if (onlyDigits.Length > 10)
                onlyDigits = onlyDigits.Substring(0, 10);

            // Nếu chuỗi đã thay đổi, cập nhật lại TextBox
            if (txt.Text != onlyDigits)
            {
                int selStart = txt.SelectionStart; // lưu vị trí con trỏ
                txt.Text = onlyDigits;
                txt.SelectionStart = selStart > txt.Text.Length ? txt.Text.Length : selStart;
            }
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void btnduyetdon_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Duyệt Đơn Hàng";
            DuyetDon uc = new DuyetDon();
            uc.Dock = DockStyle.Fill;
            frm.Controls.Add(uc);
            frm.ShowDialog(); // modal
        }
    }
}
