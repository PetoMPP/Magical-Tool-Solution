using Magical_Tool_Solution.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Magical_Tool_Solution.CustomControls
{
    internal class CustomComboBox : ComboBox
    {
        private const int WM_PAINT = 0xF;
        private readonly int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                using Graphics g = Graphics.FromHwnd(Handle);

                using (Pen p = new(BorderColor, 1))
                {
                    g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                }
                using (Pen p = new(BorderColor, 1))
                {
                    Rectangle rectangle = new(0, 0, Width - buttonWidth - 1, Height - 1);
                    g.DrawRectangle(p, rectangle);
                    //Leave 1px space on top and bottom for the border
                    rectangle = new Rectangle(1, 1, Width - buttonWidth - 2, Height - 2);
                    using SolidBrush br = new(BackColor);
                    g.FillRectangle(br, rectangle);
                }
                g.DrawImageUnscaled(Resources.arrow_down_small, new Rectangle(Width - buttonWidth, 1, Width - 1, Height - 1));
            }
        }

        public CustomComboBox()
        {
            BorderColor = Color.Gray;
        }

        [Browsable(true)]
        [Category("Wygląd")]  //Terrible
        [DefaultValue(typeof(Color), "Gray")]
        public Color BorderColor { get; set; }
    }
}
