using PM.BUS.Services.Sachsv;
using PM.DAL.Models;
using PM.GUI.userConTrol.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PM.GUI.userConTrol.Admin
{
    public partial class Edit_BOOk : UserControl
    {
        private TheLoaiService theLoaiService = new TheLoaiService();
        private SachService sachService = new SachService();

        private bool isTheLoaiVisible = false;
        private List<string> selectedTheLoais = new List<string>();

        private Edit_BOOK_CT currentEditControl; // 🔹 Control chi tiết đang mở

        public Edit_BOOk(NhanVien a)
        {
            if (!DesignMode)
            {
                InitializeComponent();
            }
        }

        private void Edit_BOOk_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            LoadAllBooks();
            flpTheLoai.Visible = false;
            btnThoat.Visible = false;
            btnThoat.Enabled = false;
        }

        // ==================== HIỂN THỊ DANH SÁCH SÁCH ====================
        private void LoadAllBooks(IEnumerable<Sach> list = null)
        {
            panelDanhSach.Controls.Clear();
            var books = list ?? sachService.GetAll();

            foreach (var sach in books)
            {
                BooKShowcs bookItem = new BooKShowcs(sach);
                bookItem.Margin = new Padding(10);
                panelDanhSach.Controls.Add(bookItem);
                bookItem.OnBookClick += BookItem_OnBookClick;
            }

            panelDanhSach.Visible = true;
        }

        // ==================== NÚT THỂ LOẠI ====================
        private void btnTheLoai_Click(object sender, EventArgs e)
        {
            isTheLoaiVisible = !isTheLoaiVisible;

            if (isTheLoaiVisible)
            {
                ShowTheLoaiList();
            }
            else
            {
                flpTheLoai.Visible = false;
                panelDanhSach.Visible = true;
                FilterBooksBySelectedTheLoai();
            }
        }

        // ==================== HIỂN THỊ CÁC THỂ LOẠI ====================
        private void ShowTheLoaiList()
        {
            flpTheLoai.Controls.Clear();
            var listTheLoai = theLoaiService.GetAll();

            foreach (var tl in listTheLoai)
            {
                CheckBox chk = new CheckBox
                {
                    Text = tl.TenTheLoai,
                    Tag = tl.MaTheLoai,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Black,
                    Margin = new Padding(5)
                };

                if (selectedTheLoais.Contains(tl.MaTheLoai))
                    chk.Checked = true;

                chk.CheckedChanged += (s, e) =>
                {
                    string maTL = chk.Tag.ToString();
                    if (chk.Checked)
                        selectedTheLoais.Add(maTL);
                    else
                        selectedTheLoais.Remove(maTL);
                };

                flpTheLoai.Controls.Add(chk);
            }

            flpTheLoai.Visible = true;
            panelDanhSach.Visible = false;
        }

        // ==================== LỌC SÁCH THEO THỂ LOẠI ====================
        private void FilterBooksBySelectedTheLoai()
        {
            if (selectedTheLoais.Count == 0)
            {
                LoadAllBooks();
                return;
            }

            var allBooks = sachService.GetAll();
            var filtered = allBooks.Where(s => selectedTheLoais.Contains(s.MaTheLoai));
            LoadAllBooks(filtered);
        }

        // ==================== NÚT TÌM KIẾM ====================
        private void btnFind_Click(object sender, EventArgs e)
        {
            string keyword = txtFindTen.Text.Trim().ToLower();
            var filtered = sachService.Find(s => s.TenSach.ToLower().Contains(keyword));
            LoadAllBooks(filtered);
        }

        // ==================== CLICK VÀO BOOK ITEM ====================
        private void BookItem_OnBookClick(object sender, Sach sach)
        {
            // 1️⃣ Ẩn danh sách và các nút lọc
            panelDanhSach.Visible = false;
            flpTheLoai.Visible = false;
            btnTheLoai.Enabled = false;
            btnFind.Enabled = false;
            txtFindTen.Enabled = false;

            // 2️⃣ Tạo control Edit_BOOK_CT
            currentEditControl = new Edit_BOOK_CT(sach.MaSach);
            currentEditControl.Dock = DockStyle.Fill;

            // 3️⃣ Khi user nhấn "Thoát" trong Edit_BOOK_CT
            currentEditControl.OnExitClicked += (s2, e2) =>
            {
                RemoveEditControl();
            };

            // 4️⃣ Thêm vào giao diện
            this.Controls.Add(currentEditControl);
            currentEditControl.BringToFront();

            // 5️⃣ Hiện nút thoát
            btnThoat.Visible = true;
            btnThoat.Enabled = true;
        }

        // ==================== NÚT THOÁT ====================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            RemoveEditControl();
        }

        // ==================== HÀM XỬ LÝ KHI QUAY LẠI DANH SÁCH ====================
        private void RemoveEditControl()
        {
            if (currentEditControl != null)
            {
                this.Controls.Remove(currentEditControl);
                currentEditControl.Dispose();
                currentEditControl = null;
            }

            btnThoat.Visible = false;
            btnThoat.Enabled = false;
            btnTheLoai.Enabled = true;
            btnFind.Enabled = true;
            txtFindTen.Enabled = true;

            // Load lại danh sách
            LoadAllBooks();
        }
    }
}
