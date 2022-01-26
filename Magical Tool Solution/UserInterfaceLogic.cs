using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magical_Tool_Solution
{
    public static class UserInterfaceLogic
    {
        public static IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.SelectMany(x => GetAllControls(x, type)).Concat(controls).Where(y => y.GetType() == type);
        }
        public static IEnumerable<Control> GetAllControls(Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.SelectMany(x => GetAllControls(x)).Concat(controls);
        }
        public static void HandleRightClick(ListBox listBox, MouseEventArgs e, Action contextMenuRefresh)
        {
            if (listBox.IndexFromPoint(e.Location) == ListBox.NoMatches)
            {
                listBox.ClearSelected();
            }
            else
            {
                listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
            }
            contextMenuRefresh();
        }
        public static void HandleRightClick(ListBox listBox, MouseEventArgs e)
        {
            if (listBox.IndexFromPoint(e.Location) == ListBox.NoMatches)
            {
                listBox.ClearSelected();
            }
            else
            {
                listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
            }
        }
    }
}
