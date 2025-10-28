
using Microsoft.VisualBasic;
using PM.BUS.Helpers;
using PM.BUS.Services.DonHangsv;
using PM.BUS.Services.Facade;
using PM.BUS.Services.Sachsv;
using PM.DAL;
using PM.DAL.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Employee
{
    public partial class LenDon : UserControl
    {
        // Thay vì dùng trực tiếp AppDbContext, dùng services đã cung cấp
        private readonly SachService _sachService;
        private readonly DonHangService _donHangService;
        private readonly CT_DonHangService _ctDonHangService;
    


        private string lastCreatedOrderID = null;
        private decimal lastOrderTotal = 0;
        private decimal tienKhachDua = 0;
        private decimal tienThua = 0;


        public LenDon()
        {
            InitializeComponent();

            // Khởi tạo services theo mã bạn cung cấp
            _sachService = new SachService();                     // có ctor mặc định
            _donHangService = new DonHangService();               // có ctor mặc định
            _ctDonHangService = new CT_DonHangService(); // CT_DonHangService chỉ có ctor(IUnitOfWork)
         
        }

        private void LenDon_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
               // MessageBox.Show("Form đang load dữ liệu!");

                dgvSach.MultiSelect = true;
                dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                LoadSachData();
            }
        }

        private Object allBooks;

        // Hàm load dữ liệu sách vào bảng — dùng SachService thay cho truy vấn trực tiếp
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

                // Lấy tất cả sách từ service
                var sachEntities = _sachService.GetAll() ?? new List<PM.DAL.Models.Sach>();

                // Tính tồn kho tương tự truy vấn gốc dùng quan hệ CT_NhapKhos và CT_DonHangs
                var data = sachEntities
                    .Select(s => new
                    {
                        s.MaSach,
                        s.TenSach,
                        TenTheLoai = s.TheLoai != null ? s.TheLoai.TenTheLoai : "Chưa phân loại",
                        s.GiaBan,
                        SoLuongTon = (s.CT_NhapKhos?.Sum(n => (int?)n.SoLuong) ?? 0)
                                    - (s.CT_DonHangs?.Sum(d => (int?)d.SoLuong) ?? 0)
                    })
                    .ToList();

                dgvSach.DataSource = data;
                allBooks = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu:\n" + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            picQR.SizeMode = PictureBoxSizeMode.Zoom;
            picQR.Visible = false;
            btnXacNhan.Visible = false;
            btnXacNhan.Enabled = false;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        // Sự kiện tạo đơn (giữ nguyên tên sự kiện)
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSach.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sách để tạo đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // === Tạo mã đơn hàng tự động (dùng RandHelper.TaoMa) ===
                string maDonHang = RandHelper.TaoMa("DH");
                decimal tongTien = 0;

                // === Tạo đơn hàng (dùng DonHangService) ===
                var donHang = new DonHang
                {
                    MaDonHang = maDonHang,
                    MaKhach = null, // Khách lẻ
                    MaNV = "NV01",  // không có context NhanVien trong service hiện tại -> dùng mã mặc định
                    NgayDat = DateTime.Now,
                    NgayGiao = DateTime.Now,
                    TongTien = 0, // sẽ cập nhật sau
                    TrangThai = "Chờ thanh toán"
                };
                
                // Lưu đơn (nếu thất bại, thông báo và thoát)
                var addDonResult = _donHangService.Add(donHang);
                if (!addDonResult)
                {
                    MessageBox.Show("Không thể tạo đơn hàng (lưu DonHang thất bại).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               

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

                    // kiểm tra tồn dựa vào dữ liệu đã load lên grid
                    int soLuongTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value);
                    if (soLuongMua > soLuongTon)
                    {
                        MessageBox.Show($"Sách '{tenSach}' chỉ còn {soLuongTon} quyển, bỏ qua!", "Không đủ hàng");
                        continue;
                    }

                    // tạo chi tiết đơn (dùng CT_DonHangService)
                    var chiTiet = new CT_DonHang
                    {
                        MaDonHang = maDonHang,
                        MaSach = maSach,
                        SoLuong = soLuongMua,
                        DonGia = giaBan,
                        ThanhTien = giaBan * soLuongMua
                    };

                    var addCtResult = _ctDonHangService.Add(chiTiet);
                    if (!addCtResult)
                    {
                        // nếu thêm chi tiết thất bại, bỏ qua chi tiết đó (và không cộng tiền)
                        MessageBox.Show($"Không thể thêm chi tiết cho sách '{tenSach}', bỏ qua.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    tongTien += chiTiet.ThanhTien;
                }

                // === Nếu không có chi tiết nào hợp lệ, xóa DonHang vừa tạo và hủy ===
                if (tongTien == 0)
                {
                    // xóa đơn đã tạo (hàm Delete theo service)
                    _donHangService.Delete(maDonHang);
                    MessageBox.Show("Không có sách nào hợp lệ để tạo đơn!", "Thông báo");
                    return;
                }

                // === Cập nhật tổng tiền cho đơn ===
                donHang.TongTien = tongTien;
                _donHangService.Update(donHang);

                // 🔹 Lưu thông tin để dùng sau
                lastCreatedOrderID = maDonHang;
                lastOrderTotal = tongTien;

                // 🔹 Thông báo tạo đơn thành công
                MessageBox.Show($"✅ Đơn hàng {maDonHang} đã được tạo thành công!\nTrạng thái: Chờ thanh toán\nTổng tiền: {tongTien:N0}đ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Yêu cầu nhập tiền khách đưa
                bool validInput = false;
                while (!validInput)
                {
                    string inputTien = Interaction.InputBox($"Tổng tiền đơn: {tongTien:N0}đ\nNhập số tiền khách đưa:", "Thanh toán trực tiếp", tongTien.ToString("N0"));
                    inputTien = inputTien.Replace(",", "").Trim(); // loại bỏ dấu phẩy nếu có

                    if (decimal.TryParse(inputTien, out tienKhachDua) && tienKhachDua > 0)
                    {
                        validInput = true;
                        tienThua = tienKhachDua - tongTien;

                        if (tienThua >= 0)
                            MessageBox.Show($"Khách đưa: {tienKhachDua:N0}đ\nTiền thừa: {tienThua:N0}đ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"Khách đưa chưa đủ tiền! Thiếu: {-tienThua:N0}đ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Số tiền nhập không hợp lệ, vui lòng nhập lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.Trim().ToLower();

            // Tìm kiếm qua service thay vì truy vấn trực tiếp
            var data = (_sachService.GetAll() ?? new List<PM.DAL.Models.Sach>())
                .Where(s =>
                    (!string.IsNullOrEmpty(s.TenSach) && s.TenSach.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(s.MaSach) && s.MaSach.ToLower().Contains(keyword))
                )
                .Select(s => new
                {
                    s.MaSach,
                    s.TenSach,
                    TenTheLoai = s.TheLoai != null ? s.TheLoai.TenTheLoai : "Chưa phân loại",
                    s.GiaBan,
                    SoLuongTon = (s.CT_NhapKhos?.Sum(n => (int?)n.SoLuong) ?? 0)
                                - (s.CT_DonHangs?.Sum(d => (int?)d.SoLuong) ?? 0)
                })
                .ToList();

            dgvSach.DataSource = data;
        }

        // Tạo QR (dùng QrHelper.TaoQRThanhToan)
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

                string bankCode = "BIDV";
                string accountNo = "6910973464";
                string accountName = "TRAN DUY TAN";

                // Tạo URL QR dùng QrHelper (theo signature bạn cung cấp)
                string qrUrl = QrHelper.TaoQRThanhToan(bankCode, accountNo, accountName, lastOrderTotal, lastCreatedOrderID);

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

        // Xác nhận thanh toán (giữ nguyên event)
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

                // Lấy đơn hàng bằng service
                var don = _donHangService.GetById(lastCreatedOrderID);
                if (don == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng cần xác nhận!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật trạng thái thanh toán
                don.TrangThai = "Đã thanh toán";
                _donHangService.Update(don);

                MessageBox.Show($"✅ Đơn hàng {lastCreatedOrderID} đã được thanh toán thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở giao diện in hóa đơn
                InHoaDon hoaDonUC = new InHoaDon(lastCreatedOrderID);
                Form frm = new Form();
                frm.Text = "Hóa đơn bán hàng";
                frm.Size = new Size(900, 700);
                hoaDonUC.Dock = DockStyle.Fill;
                frm.Controls.Add(hoaDonUC);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                ResetUIAfterPrint();

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

                var don = _donHangService.GetById(lastCreatedOrderID);
                if (don == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng cần xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                don.TrangThai = "Đã thanh toán";
                _donHangService.Update(don);

                MessageBox.Show($"✅ Đơn hàng {lastCreatedOrderID} đã được thanh toán và sẵn sàng in!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Truyền luôn tiền khách đưa và tiền thừa
                InHoaDon hoaDonUC = new InHoaDon(lastCreatedOrderID, tienKhachDua, tienThua);

                Form frm = new Form();
                frm.Text = "Hóa đơn bán hàng";
                frm.Size = new Size(900, 700);
                hoaDonUC.Dock = DockStyle.Fill;
                frm.Controls.Add(hoaDonUC);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                ResetUIAfterPrint();
                LoadSachData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimSach_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimSach.Text.Trim().ToLower();

            // Lấy danh sách sách từ service và ép về List để tính toán trong bộ nhớ
            var all = _sachService.GetAll()?.ToList() ?? new List<PM.DAL.Models.Sach>();

            // Lọc theo từ khóa (không phân biệt hoa thường)
            var filtered = string.IsNullOrEmpty(keyword)
                ? all
                : all.Where(s =>
                    (!string.IsNullOrEmpty(s.TenSach) && s.TenSach.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(s.MaSach) && s.MaSach.ToLower().Contains(keyword))
                ).ToList();

            // Chuẩn bị dữ liệu hiển thị
            var data = filtered.Select(s => new
            {
                s.MaSach,
                s.TenSach,
                TenTheLoai = s.TheLoai != null ? s.TheLoai.TenTheLoai : "Chưa phân loại",
                s.GiaBan,
                SoLuongTon = (s.CT_NhapKhos?.Sum(n => (int?)n.SoLuong) ?? 0)
                            - (s.CT_DonHangs?.Sum(d => (int?)d.SoLuong) ?? 0)
            }).ToList();

            dgvSach.DataSource = data;
        }
        private void ResetUIAfterPrint()
        {
            dgvSach.Enabled = true;
            btnTaoDon.Enabled = true;
            picQR.Visible = false;
            btnXacNhan.Visible = false;
            btnXacNhan.Enabled = false;
        }

        private void picQR_Click(object sender, EventArgs e)
        {

        }
    }
}
