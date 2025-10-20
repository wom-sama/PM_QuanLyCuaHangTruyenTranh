using Microsoft.VisualBasic;
using PM_QuanLyCuaHangTruyenTranh.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Employee
{
    public partial class LenDon : UserControl
    {
        AppDbContext db = new AppDbContext();
        private string lastCreatedOrderID = null;
        private decimal lastOrderTotal = 0;
        public LenDon()
        {

            InitializeComponent();


        }
        
        private void LenDon_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                MessageBox.Show("Form đang load dữ liệu!"); 
               
                dgvSach.MultiSelect = true;
                dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                LoadSachData();

            }
                
        }
        private List<dynamic> allBooks;
        // Hàm load dữ liệu sách vào bảng
        private void LoadSachData()
        {
            try
            {
                dgvSach.AutoGenerateColumns = false;

                if (dgvSach.Columns.Count == 0)
                {
                    dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaSach", HeaderText = "Mã Sách", DataPropertyName = "MaSach" });
                    dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenSach", HeaderText = "Tên Sách", DataPropertyName = "TenSach" });
                    dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenTheLoai", HeaderText = "Thể Loại", DataPropertyName = "TenTheLoai" });
                    dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiaBan", HeaderText = "Giá Bán", DataPropertyName = "GiaBan" });
                    dgvSach.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoLuongTon", HeaderText = "Số Lượng Tồn", DataPropertyName = "SoLuongTon" });
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
                        TenTheLoai = s.TheLoai != null ? s.TheLoai.TenTheLoai : "Chưa phân loại",
                        s.GiaBan,
                        SoLuongTon = (s.CT_NhapKhos.Sum(n => (int?)n.SoLuong) ?? 0)
                                    - (s.CT_DonHangs.Sum(d => (int?)d.SoLuong) ?? 0)
                    })
                    .ToList();

                dgvSach.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu:\n" + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            picQR.SizeMode = PictureBoxSizeMode.Zoom;  
            picQR.Visible=false;
            btnXacNhan.Visible=false;
            btnXacNhan.Enabled=false;
        }


        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSach.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sách để tạo đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // === Tạo mã đơn hàng tự động ===
                string maDonHang = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss");

                decimal tongTien = 0;

                // === Tạo đơn hàng ===
                var donHang = new DonHang
                {
                    MaDonHang = maDonHang,
                    MaKhach = null, // Khách lẻ
                    MaNV = db.NhanViens.FirstOrDefault()?.MaNV ?? "NV01",
                    NgayDat = DateTime.Now,
                    NgayGiao = DateTime.Now,
                    TongTien = 0, // sẽ cập nhật sau
                    TrangThai = "Chờ thanh toán"
                };
                db.DonHangs.Add(donHang);

                // === Duyệt qua từng sách được chọn ===
                foreach (DataGridViewRow row in dgvSach.SelectedRows)
                {
                    string maSach = row.Cells["MaSach"].Value?.ToString();
                    string tenSach = row.Cells["TenSach"].Value?.ToString();
                    decimal giaBan = Convert.ToDecimal(row.Cells["GiaBan"].Value);

                    // hỏi số lượng
                    int soLuongMua = 1; // mặc định là 1
                    string input = Microsoft.VisualBasic.Interaction.InputBox($"Nhập số lượng mua cho \"{tenSach}\"", "Số lượng", "1");

                    if (!int.TryParse(input, out soLuongMua) || soLuongMua <= 0)
                    {
                        MessageBox.Show($"Số lượng cho '{tenSach}' không hợp lệ, bỏ qua.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    // kiểm tra tồn
                    int soLuongTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value);
                    if (soLuongMua > soLuongTon)
                    {
                        MessageBox.Show($"Sách '{tenSach}' chỉ còn {soLuongTon} quyển, bỏ qua!", "Không đủ hàng");
                        continue;
                    }

                    // tạo chi tiết đơn
                    var chiTiet = new CT_DonHang
                    {
                        MaDonHang = maDonHang,
                        MaSach = maSach,
                        SoLuong = soLuongMua,
                        DonGia = giaBan,
                        ThanhTien = giaBan * soLuongMua
                    };
                    db.CT_DonHangs.Add(chiTiet);

                    tongTien += chiTiet.ThanhTien;
                }

                // === Nếu không có chi tiết nào hợp lệ, hủy đơn ===
                if (tongTien == 0)
                {
                    MessageBox.Show("Không có sách nào hợp lệ để tạo đơn!", "Thông báo");
                    db.Entry(donHang).State = EntityState.Detached;
                    return;
                }

                // === Cập nhật tổng tiền cho đơn ===
                donHang.TongTien = tongTien;
                db.SaveChanges();

                // 🔹 Lưu thông tin để dùng sau
                lastCreatedOrderID = maDonHang;
                lastOrderTotal = tongTien;

                // 🔹 Thông báo tạo đơn thành công
                MessageBox.Show($"✅ Đơn hàng {maDonHang} đã được tạo thành công!\nTrạng thái: Chờ thanh toán\nTổng tiền: {tongTien:N0}đ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới danh sách
                LoadSachData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo đơn hàng:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            dgvSach.DataSource = data;
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lastCreatedOrderID) || lastOrderTotal <= 0)
                {
                    MessageBox.Show("⚠️ Vui lòng tạo đơn hàng trước khi tạo mã QR!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string bankCode = "BIDV"; // MB Bank
                string accountNo = "6910973464"; // số tài khoản
                string accountName = "TRAN DUY TAN"; // tên chủ TK

                // Ghi chú = mã đơn hàng
                string ghiChu = $"Thanh toan don {lastCreatedOrderID}";

                // Tạo URL QR MB Bank (VietQR)
                string qrUrl = $"https://img.vietqr.io/image/{bankCode}-{accountNo}-compact2.png" +
                               $"?amount={lastOrderTotal}" +
                               $"&addInfo={Uri.EscapeDataString(ghiChu)}" +
                               $"&accountName={Uri.EscapeDataString(accountName)}";

                // Hiển thị QR trong PictureBox có sẵn
                picQR.Visible = true;
                picQR.SizeMode = PictureBoxSizeMode.Zoom;
                picQR.Load(qrUrl);

                // Hiện nút xác nhận thanh toán
                btnXacNhan.Visible = true;
                btnXacNhan.Enabled = true;

                // Tùy chọn: ẩn các phần khác nếu muốn gọn hơn
                dgvSach.Enabled = false;
                btnTaoDon.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo mã QR: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lastCreatedOrderID))
                {
                    MessageBox.Show("⚠️ Chưa có đơn hàng nào để xác nhận!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // === Lấy đơn hàng vừa tạo ===
                var don = db.DonHangs.FirstOrDefault(d => d.MaDonHang == lastCreatedOrderID);
                if (don == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng cần xác nhận!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // === Cập nhật trạng thái thanh toán ===
                don.TrangThai = "Đã thanh toán";
                db.SaveChanges();

                MessageBox.Show($"✅ Đơn hàng {lastCreatedOrderID} đã được thanh toán thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // === Mở giao diện in hóa đơn ===
                InHoaDon hoaDonUC = new InHoaDon(lastCreatedOrderID);
                Form frm = new Form();
                frm.Text = "Hóa đơn bán hàng";
                frm.Size = new Size(900, 700);
                hoaDonUC.Dock = DockStyle.Fill;
                frm.Controls.Add(hoaDonUC);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                // Làm mới dữ liệu sau khi in
                LoadSachData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận thanh toán: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatdon_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lastCreatedOrderID))
                {
                    MessageBox.Show("⚠️ Chưa có đơn hàng nào để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tìm đơn hàng vừa tạo
                var don = db.DonHangs.FirstOrDefault(d => d.MaDonHang == lastCreatedOrderID);
                if (don == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng cần xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật trạng thái đơn hàng thành "Đã thanh toán"
                don.TrangThai = "Đã thanh toán";
                db.SaveChanges();

                MessageBox.Show($"✅ Đơn hàng {lastCreatedOrderID} đã được thanh toán và sẵn sàng in!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở form In Hóa Đơn
                InHoaDon hoaDonUC = new InHoaDon(lastCreatedOrderID);
                Form frm = new Form();
                frm.Text = "Hóa đơn bán hàng";
                frm.Size = new Size(900, 700);
                hoaDonUC.Dock = DockStyle.Fill;
                frm.Controls.Add(hoaDonUC);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                LoadSachData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtTimSach_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimSach.Text.Trim().ToLower(); // sửa lại đây

            var query = db.Sachs
                .Include(s => s.TheLoai)
                .Include(s => s.CT_NhapKhos)
                .Include(s => s.CT_DonHangs)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(s =>
                    s.TenSach.ToLower().Contains(keyword) ||
                    s.MaSach.ToLower().Contains(keyword));
            }

            var data = query.Select(s => new
            {
                s.MaSach,
                s.TenSach,
                TenTheLoai = s.TheLoai != null ? s.TheLoai.TenTheLoai : "Chưa phân loại",
                s.GiaBan,
                SoLuongTon =
                    (s.CT_NhapKhos.Sum(n => (int?)n.SoLuong) ?? 0)
                    - (s.CT_DonHangs.Sum(d => (int?)d.SoLuong) ?? 0)
            })
            .ToList();

            dgvSach.DataSource = data;
        }
    }
}
