using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.GUI.userConTrol.Common
{
    public static class Edit_Lable
    {
        public static void AdjustFontSize(Guna2HtmlLabel lbl)
        {
            if (string.IsNullOrEmpty(lbl.Text))
                return;

            Graphics g = lbl.CreateGraphics();
            float fontSize = lbl.Font.Size;

            SizeF textSize = g.MeasureString(lbl.Text, lbl.Font);
            float ratio = Math.Min(lbl.Width / textSize.Width, lbl.Height / textSize.Height);

            // Giới hạn cỡ chữ tối đa và tối thiểu
            float newSize = Math.Max(8, lbl.Font.Size * ratio);

            lbl.Font = new Font(lbl.Font.FontFamily, newSize, lbl.Font.Style);
        }
    }
}
