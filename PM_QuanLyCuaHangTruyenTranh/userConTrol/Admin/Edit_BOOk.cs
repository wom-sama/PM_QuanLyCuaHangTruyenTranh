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

        public Edit_BOOk()
        {
            InitializeComponent();
        }

        private void Edit_BOOk_Load(object sender, EventArgs e)
        {
            // tránh chạy khi design
            if (DesignMode) return;
            LoadAllBooks();
            flpTheLoai.Visible = false;

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

                // Lọc sách theo thể loại đã chọn
                FilterBooksBySelectedTheLoai();
            }
        }

        // ==================== HIỂN THỊ CÁC THỂ LOẠI DƯỚI DẠNG CHECKBOX ====================
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
                LoadAllBooks(); // nếu không chọn thể loại nào, hiển thị toàn bộ
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
        // khi click vào book ở edit
        private void BookItem_OnBookClick(object sender, Sach sach)
        {
            // Ví dụ: hiển thị thông tin sách được chọn
            MessageBox.Show(
                $"📘 Bạn đã chọn sách:\n\nTên: {sach.TenSach}\nMã: {sach.MaSach}",
                "Thông tin sách",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
