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

        public DonHang()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

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

                if (!string.IsNullOrEmpty(_maKhachHang))
                    TaiDonHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load UserControl: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CauHinhDataGridView()
        {
            dgvDonHang.Columns.Clear();
            dgvDonHang.AutoGenerateColumns = false;
            dgvDonHang.AllowUserToAddRows = false;
            dgvDonHang.AllowUserToDeleteRows = false;
            dgvDonHang.ReadOnly = true;
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonHang.MultiSelect = false;

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaDonHang",
                HeaderText = "Mã đơn hàng",
                Width = 120
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayDat",
                HeaderText = "Ngày đặt",
                Width = 100
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TongTien",
                HeaderText = "Tổng tiền",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Width = 150
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayGiao",
                HeaderText = "Ngày giao",
                Width = 100
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HinhThucThanhToan",
                HeaderText = "Thanh toán",
                Width = 150
            });

            dgvDonHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LoaiDon",
                HeaderText = "Loại đơn",
                Width = 100
            });

            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonHang.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDonHang.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvDonHang.RowTemplate.Height = 35;
        }

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

                var danhSachDonHang = _context.DonHangs
                    .Include(d => d.Khach)
                    .Include(d => d.NhanVien)
                    .Where(d => d.MaKhach == _maKhachHang)
                    .OrderByDescending(d => d.NgayDat)
                    .ToList()
                    .Select(d => new
                    {
                        d.MaDonHang,
                        NgayDat = d.NgayDat.ToString("dd/MM/yyyy"),
                        TongTien = d.TongTien.ToString("N0") + " đ",
                        d.TrangThai,
                        NgayGiao = d.NgayGiao.HasValue ? d.NgayGiao.Value.ToString("dd/MM/yyyy") : "",
                        d.HinhThucThanhToan,
                        d.LoaiDon
                    })
                    .ToList();

                dgvDonHang.DataSource = null;
                dgvDonHang.DataSource = danhSachDonHang;

                _trangThaiHienTai = null;

                ToMauTheoTrangThai();
                HienThiSoLuongDonHang(danhSachDonHang.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đơn hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                var danhSachDonHang = _context.DonHangs
                    .Include(d => d.Khach)
                    .Include(d => d.NhanVien)
                    .Where(d => d.MaKhach == _maKhachHang &&
                        (string.IsNullOrEmpty(trangThai) || trangThai == "Tất cả" || d.TrangThai == trangThai))
                    .OrderByDescending(d => d.NgayDat)
                    .ToList()
                    .Select(d => new
                    {
                        d.MaDonHang,
                        NgayDat = d.NgayDat.ToString("dd/MM/yyyy"),
                        TongTien = d.TongTien.ToString("N0") + " đ",
                        d.TrangThai,
                        NgayGiao = d.NgayGiao.HasValue ? d.NgayGiao.Value.ToString("dd/MM/yyyy") : "",
                        d.HinhThucThanhToan,
                        d.LoaiDon
                    })
                    .ToList();

                dgvDonHang.DataSource = null;
                dgvDonHang.DataSource = danhSachDonHang;

                _trangThaiHienTai = trangThai;

                ToMauTheoTrangThai();
                HienThiSoLuongDonHang(danhSachDonHang.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc đơn hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToMauTheoTrangThai()
        {
            foreach (DataGridViewRow row in dgvDonHang.Rows)
            {
                if (row.Cells["TrangThai"].Value != null)
                {
                    string trangThai = row.Cells["TrangThai"].Value.ToString();

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

        private void HienThiSoLuongDonHang(int soLuong)
        {
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

        public void ThietLapKhachHang(string maKhachHang)
        {
            _maKhachHang = maKhachHang;
            TaiDonHang();
        }

        private void dgvDonHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string maDonHang = dgvDonHang.Rows[e.RowIndex].Cells["MaDonHang"].Value?.ToString();

                    if (!string.IsNullOrEmpty(maDonHang))
                    {
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

        public void LamMoi()
        {
            if (!string.IsNullOrEmpty(_trangThaiHienTai))
                TaiDonHang(_trangThaiHienTai);
            else
                TaiDonHang();
        }
    }
}
