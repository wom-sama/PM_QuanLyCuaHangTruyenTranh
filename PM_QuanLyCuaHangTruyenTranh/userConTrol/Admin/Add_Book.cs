using Guna.UI2.WinForms;
using PM.BUS.Helpers;
using PM.BUS.Services.Sachsv;
using PM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PM.GUI.FormThongBao;

namespace PM.GUI.userConTrol.Admin
{
    public partial class Add_Book : UserControl
    {
        private readonly SachService _sachService = new SachService();
        private readonly TheLoaiService _theLoaiService = new TheLoaiService();
        private string _anhBiaPath = null;

        public Add_Book()
        {
            InitializeComponent();
        }

        private void Add_Book_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                LoadTheLoai();
                txtMaSach.Text = RandHelper.TaoMa("SACH");
            }
            catch (Exception ex)
            {
                new FormMessage("Lỗi khi tải thể loại: " + ex.Message).ShowDialog();
            }
        }

        // ===================== LOAD THỂ LOẠI =====================
        private void LoadTheLoai()
        {
            flpTheLoai.Controls.Clear();
            var list = _theLoaiService.GetAll();

            if (list == null || !list.Any())
            {
                flpTheLoai.Controls.Add(new Label
                {
                    Text = "Không có thể loại nào!",
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Italic)
                });
                return;
            }

            foreach (var tl in list)
            {
                var chk = new Guna2CheckBox
                {
                    Text = tl.TenTheLoai,
                    Tag = tl.MaTheLoai,
                    AutoSize = true,
                    ForeColor = Color.Black,
                    Margin = new Padding(6)
                };
                flpTheLoai.Controls.Add(chk);
            }
        }

        // ===================== CHỌN ẢNH =====================
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Ảnh bìa (*.jpg;*.png)|*.jpg;*.png";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        picBiaSach.Image = Image.FromFile(ofd.FileName);
                        _anhBiaPath = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                new FormMessage("Lỗi khi chọn ảnh: " + ex.Message).ShowDialog();
            }
        }

        // ===================== NÚT LƯU =====================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra hợp lệ
                if (string.IsNullOrWhiteSpace(GNtxtTenSach.Text))
                {
                    new FormMessage("Vui lòng nhập tên sách!").ShowDialog();
                    return;
                }

                if (!int.TryParse(GNtxtSoTrang.Text, out int soTrang))
                {
                    new FormMessage("Số trang phải là số hợp lệ!").ShowDialog();
                    return;
                }

                // Thu thập thể loại đã chọn
                var theLoaiChon = flpTheLoai.Controls
                    .OfType<Guna2CheckBox>()
                    .Where(c => c.Checked)
                    .Select(c => c.Tag.ToString())
                    .ToList();

                // Tạo đối tượng sách mới
                var sach = new Sach
                {
                    MaSach = txtMaSach.Text.Trim(),
                    TenSach = GNtxtTenSach.Text.Trim(),
                    SoTrang = soTrang,
                    //NgayNhap = DateTime.Now
                };

                // Chuyển ảnh thành byte[] nếu có
                if (!string.IsNullOrEmpty(_anhBiaPath) && File.Exists(_anhBiaPath))
                {
                    sach.BiaSach = File.ReadAllBytes(_anhBiaPath);
                }

                // Gọi BUS thêm sách
                bool kq = _sachService.Add(sach);

                if (kq)
                {
                    new FormMessage("✅ Thêm sách thành công!").ShowDialog();
                    ResetForm();
                }
                else
                {
                    new FormMessage("❌ Không thể thêm sách!").ShowDialog();
                }
            }
            catch (Exception ex)
            {
                new FormMessage("Lỗi: " + ex.Message).ShowDialog();
            }
        }

        // ===================== RESET FORM =====================
        private void ResetForm()
        {
            GNtxtTenSach.Clear();
            GNtxtSoTrang.Clear();
            picBiaSach.Image = null;
            _anhBiaPath = null;
            txtMaSach.Text = RandHelper.TaoMa("SACH");

            foreach (var chk in flpTheLoai.Controls.OfType<Guna2CheckBox>())
                chk.Checked = false;
        }

        // ===================== EVENT KHÁC =====================
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Không chỉnh event gốc, giữ nguyên
        }
    }
}
