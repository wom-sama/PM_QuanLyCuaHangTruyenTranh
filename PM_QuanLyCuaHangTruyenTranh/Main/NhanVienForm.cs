using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh
{
    public partial class NhanVienForm : Form
    {
        public NhanVienForm(TaiKhoan a)
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            LoadBookData();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
                if (txtPhone.Text.Length >= 10)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtS_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (txtPhone.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void LoadBookData()
        {
            //try
            //{
            //    using (var db = new Model1()) // context của Entity Framework
            //    {
            //        var data = db.Books
            //            .Select(b => new
            //            {
            //                Mã_Sách = b.BookId,
            //                Tên_Sách = b.Title,
            //                Số_Lượng = b.Quantity,
            //                Tác_Giả = b.Author,
            //                Giá_Thuê = b.RentPrice
            //            })
            //            .ToList();

            //        guna2DataGridView1.DataSource = data;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi tải dữ liệu sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            ////
        }
    }
}
