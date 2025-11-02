using PM.DAL;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DonHangModel = PM.DAL.Models.DonHang; 

namespace PM.GUI.userConTrol.Client
{
    public partial class DonHang : UserControl
    {
        private readonly AppDbContext _context;
        private string _maKhachHang;
        private string _trangThaiHienTai;

        // Constructor mặc định (cho Designer)
        public DonHang()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        // Constructor với tham số
        public DonHang(string maKhachHang)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _maKhachHang = maKhachHang;
        }

        private void DonHang_Load(object sender, EventArgs e)
        {
            try
            {
                CauHinhDataGridView();

                // Nếu có mã khách hàng, load đơn hàng
                if (!string.IsNullOrEmpty(_maKhachHang))
                {
                    TaiDonHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load UserControl: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cấu hình DataGridView
        /// </summary>
        private void CauHinhDataGridView()
        {
            // Xóa các cột cũ nếu có
            dgvDonHang.Columns.Clear();
            dgvDonHang.AutoGenerateColumns = false;
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.AllowUserToDeleteRows = false;
            dgvDonHang.ReadOnly = true;
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonHang.MultiSelect = false;

            // Tạo các cột
            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaDonHang",
                HeaderText = "Mã đơn hàng",
                Name = "colMaDonHang",
                Width = 120
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayDatFormatted",
                HeaderText = "Ngày đặt",
                Name = "colNgayDat",
                Width = 100
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TongTienFormatted",
                HeaderText = "Tổng tiền",
                Name = "colTongTien",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Name = "colTrangThai",
                Width = 150
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayGiaoFormatted",
                HeaderText = "Ngày giao",
                Name = "colNgayGiao",
                Width = 100
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HinhThucThanhToan",
                HeaderText = "Thanh toán",
                Name = "colThanhToan",
                Width = 120
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LoaiDon",
                HeaderText = "Loại đơn",
                Name = "colLoaiDon",
                Width = 100
            });

            // Tự động fill cột cuối
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonHang.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDonHang.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvDonHang.RowTemplate.Height = 35;
        }

        /// <summary>
        /// Load tất cả đơn hàng của khách - SỬ DỤNG TRỰC TIẾP DbContext
        /// </summary>
        public void TaiDonHang()
        {
            try
            {
                if (string.IsNullOrEmpty(_maKhachHang))
                {
                    MessageBox.Show("Vui lòng đăng nhập để xem đơn hàng!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Truy vấn trực tiếp từ DbContext
                var danhSachDonHang = _context.DonHangs
                    .Include(d => d.Khach)
                    .Include(d => d.NhanVien)
                    .Where(d => d.MaKhach == _maKhachHang)
                    .OrderByDescending(d => d.NgayDat)
                    .ToList();

                dgvDonHang.DataSource = null;
                dgvDonHang.DataSource = danhSachDonHang;

                _trangThaiHienTai = null;

                // Tô màu các dòng theo trạng thái
                ToMauTheoTrangThai();

                // Hiển thị số lượng
                HienThiSoLuongDonHang(danhSachDonHang.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đơn hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load đơn hàng theo trạng thái - TRUY VẤN TRỰC TIẾP
        /// </summary>
        internal void TaiDonHang(string trangThai)
        {
            try
            {
                if (string.IsNullOrEmpty(_maKhachHang))
                {
                    MessageBox.Show("Vui lòng đăng nhập để xem đơn hàng!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<DonHangModel> danhSachDonHang; 

                if (string.IsNullOrEmpty(trangThai) || trangThai == "Tất cả")
                {
                    danhSachDonHang = _context.DonHangs
                        .Include(d => d.Khach)
                        .Include(d => d.NhanVien)
                        .Where(d => d.MaKhach == _maKhachHang)
                        .OrderByDescending(d => d.NgayDat)
                        .ToList();
                }
                else
                {
                    danhSachDonHang = _context.DonHangs
                        .Include(d => d.Khach)
                        .Include(d => d.NhanVien)
                        .Where(d => d.MaKhach == _maKhachHang && d.TrangThai == trangThai)
                        .OrderByDescending(d => d.NgayDat)
                        .ToList();
                }

                dgvDonHang.DataSource = null;
                dgvDonHang.DataSource = danhSachDonHang;

                _trangThaiHienTai = trangThai;

                // Tô màu các dòng theo trạng thái
                ToMauTheoTrangThai();

                // Hiển thị số lượng
                HienThiSoLuongDonHang(danhSachDonHang.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc đơn hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tô màu các dòng theo trạng thái
        /// </summary>
        private void ToMauTheoTrangThai()
        {
            foreach (DataGridViewRow row in dgvDonHang.Rows)
            {
                if (row.Cells["colTrangThai"].Value != null)
                {
                    string trangThai = row.Cells["colTrangThai"].Value.ToString();

                    switch (trangThai)
                    {
                        case "Đang chuẩn bị hàng":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "Đang vận chuyển":
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                        case "Đã nhận hàng":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Đã hủy":
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Hiển thị số lượng đơn hàng
        /// </summary>
        private void HienThiSoLuongDonHang(int soLuong)
        {
            // Nếu có label hiển thị số lượng trong Designer
            if (this.Controls.ContainsKey("lblSoLuong"))
            {
                Label lblSoLuong = this.Controls["lblSoLuong"] as Label;
                if (lblSoLuong != null)
                {
                    string trangThai = string.IsNullOrEmpty(_trangThaiHienTai) ? "tất cả" : _trangThaiHienTai;
                    lblSoLuong.Text = $"Có {soLuong} đơn hàng {trangThai}";
                }
            }
        }

        /// <summary>
        /// Thiết lập mã khách hàng (public method)
        /// </summary>
        public void ThietLapKhachHang(string maKhachHang)
        {
            _maKhachHang = maKhachHang;
            TaiDonHang();
        }

        /// <summary>
        /// Xem chi tiết đơn hàng khi double click
        /// </summary>
        private void dgvDonHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string maDonHang = dgvDonHang.Rows[e.RowIndex].Cells["colMaDonHang"].Value?.ToString();

                    if (!string.IsNullOrEmpty(maDonHang))
                    {
                        // Mở form xem chi tiết đơn hàng
                        // Form formChiTiet = new FormChiTietDonHang(maDonHang);
                        // formChiTiet.ShowDialog();

                        MessageBox.Show($"Xem chi tiết đơn hàng: {maDonHang}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Làm mới dữ liệu
        /// </summary>
        public void LamMoi()
        {
            if (!string.IsNullOrEmpty(_trangThaiHienTai))
            {
                TaiDonHang(_trangThaiHienTai);
            }
            else
            {
                TaiDonHang();
            }
        }
    }
}