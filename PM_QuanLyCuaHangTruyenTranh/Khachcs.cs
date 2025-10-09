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
    public partial class Khachcs : Form
    {
        public Khachcs()
        {
            InitializeComponent();
        }

        private void Khachcs_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form form = new FormMessage("LOL");
            form.ShowDialog();
            guna2PictureBox1.Visible = true;
            guna2Button4.Visible = false;
        }
    }
}
