using Guna.UI2.WinForms;
using PM_QuanLyCuaHangTruyenTranh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyCuaHangTruyenTranh.userConTrol.Admin
{
    public partial class Add_Book : UserControl
    {
        public Add_Book()
        {
            InitializeComponent();
        }

        private void LoadTheLoai()
        {
           
            flpTheLoai.Controls.Clear();
            using (var db = new AppDbContext())
            {
                var dsTL = db.TheLoais.ToList();
                foreach (var tl in dsTL)
                {
                    var chk = new Guna2CheckBox()
                    {
                        Text = tl.TenTheLoai,
                        Tag = tl.MaTheLoai,
                        AutoSize = true,
                        CheckedState = { FillColor = Color.MediumPurple },
                        UncheckedState = { FillColor = Color.Transparent },
                        ForeColor = Color.Black,
                        Margin = new Padding(8)
                    };
                    flpTheLoai.Controls.Add(chk);
                }
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_Book_Load(object sender, EventArgs e)
        {
            // Load thể loại từ database
            if (!DesignMode)
            {
                LoadTheLoai();
            }
            //
            flpTheLoai.AutoScroll = true;
            flpTheLoai.WrapContents = true;
            flpTheLoai.FlowDirection = FlowDirection.LeftToRight;
            flpTheLoai.Size = new Size(340, 111);
            flpTheLoai.BorderStyle = BorderStyle.FixedSingle;
            flpTheLoai.Padding = new Padding(10);
            flpTheLoai.AutoScroll = true;
            guna2VScrollBar1.BindingContainer = flpTheLoai;
            guna2VScrollBar1.ScrollbarSize = 10;
            guna2VScrollBar1.FillColor = Color.LightGray;
            guna2VScrollBar1.ThumbColor = Color.Gray;
            guna2VScrollBar1.ThumbSize = 30;
            guna2VScrollBar1.BorderRadius = 5;
            guna2VScrollBar1.Visible = true;
            guna2VScrollBar1.BringToFront();
            guna2VScrollBar1.Location = new Point(flpTheLoai.Right - guna2VScrollBar1.Width, flpTheLoai.Top);
            guna2VScrollBar1.Height = flpTheLoai.Height;
            guna2VScrollBar1.LargeChange = 20;
            guna2VScrollBar1.Minimum = 0;
            guna2VScrollBar1.Maximum = flpTheLoai.VerticalScroll.Maximum;
            guna2VScrollBar1.Value = flpTheLoai.VerticalScroll.Value;
            guna2VScrollBar1.Scroll += (s, ev) =>
            {
                flpTheLoai.VerticalScroll.Value = guna2VScrollBar1.Value;
                flpTheLoai.PerformLayout();
            };
            // chinh sua txtGioiThieu
            txtGioiThieu.PlaceholderText = "Nhập giới thiệu về truyện...";
            txtGioiThieu.Multiline = true;
            txtGioiThieu.ScrollBars = ScrollBars.Vertical;
            txtGioiThieu.BorderRadius = 8;
            txtGioiThieu.FillColor = Color.WhiteSmoke;
            txtGioiThieu.Font = new Font("Segoe UI", 10);
            // khoa MaSach va tao ma tu dong
            GNtxtMaSach.ReadOnly = true;
            GNtxtMaSach.Enabled = false;
            GNtxtMaSach.Text=Helpers.RandHelper.TaoMa("SACH");
            // chinh sua picBiaSach
            picBiaSach.SizeMode = PictureBoxSizeMode.Zoom;
            picBiaSach.BorderRadius = 10;     
            picBiaSach.FillColor = Color.Transparent; 
            picBiaSach.BackColor = Color.Transparent;
            picBiaSach.BorderStyle = BorderStyle.FixedSingle;
        }

        private void Add_Book_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ảnh bìa (*.jpg;*.png)|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picBiaSach.Image = Image.FromFile(ofd.FileName);
                picBiaSach.Tag = ofd.FileName; // Lưu tạm đường dẫn
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var sach = new Sach()
                    {
                        MaSach = GNtxtMaSach.Text.Trim(),
                        TenSach = GNtxtTenSach.Text.Trim(),
                        //TacGia = GNtxtTacGia.Text.Trim(),
                        SoTrang = int.Parse(GNtxtSoTrang.Text),
                       // GioiThieu = txtGioiThieu.Text.Trim(),
                        //TheLoais = new List<TheLoai>()
                    };

                    //  Lưu ảnh trực tiếp vào database (dạng byte[])
                    if (picBiaSach.Tag != null)
                    {
                        string source = picBiaSach.Tag.ToString();

                        // Đọc ảnh thành mảng byte
                        sach.BiaSach = File.ReadAllBytes(source);
                    }

                    //  Duyệt các thể loại đã chọn
                    /*foreach (Guna.UI2.WinForms.Guna2CheckBox chk in flpTheLoai.Controls.OfType<Guna.UI2.WinForms.Guna2CheckBox>())
                    {
                        if (chk.Checked)
                        {
                            string maTheLoai = chk.Tag.ToString();
                            var tl = db.TheLoais.FirstOrDefault(t => t.MaTheLoai == maTheLoai);
                            if (tl != null)
                                sach.TheLoais.Add(tl);
                        }
                    }*/

                    /*db.Sachs.Add(sach);
                    db.SaveChanges();*/

                    new FormMessage("Them Thanh Cong").ShowDialog();
                    picBiaSach.Image = null;
                    picBiaSach.Tag = null;
                    GNtxtTenSach.Clear();
                    GNtxtSoTrang.Clear();
                    txtGioiThieu.Clear();
                    GNtxtTacGia.Clear();
                    foreach (var chk in flpTheLoai.Controls.OfType<Guna.UI2.WinForms.Guna2CheckBox>())
                        chk.Checked = false;
                    GNtxtMaSach.Text = Helpers.RandHelper.TaoMa("SACH");

                }
            }
            catch (Exception ex)
            {
               FormMessage f =  new FormMessage("Lỗi khi thêm sách " + ex.Message);
                f.ShowDialog();
            }
        }

       
    }
}
