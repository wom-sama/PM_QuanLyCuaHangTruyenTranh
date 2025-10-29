using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PM.GUI.userConTrol.Admin;
namespace PM.GUI.Main
{
    public partial class FromTest : Form
    {
        public FromTest()
        {
            InitializeComponent();
            var test1 = new Edit_BOOK_CT("S20251029145712777");
            PanelTest.Controls.Add(test1);
            test1.Dock = DockStyle.Fill;
        }

       
    }
}
