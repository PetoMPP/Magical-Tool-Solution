using MTSLibrary;
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
        public static void HandleRightClick(DataGridView dataGridView, MouseEventArgs e, Action contextMenuRefresh)
        {
            if (dataGridView.HitTest(e.X, e.Y).Type != DataGridViewHitTestType.Cell)
            {
                dataGridView.ClearSelection();
            }
            else
            {
                dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Selected = true;
            }
            contextMenuRefresh();
        }
        public static string[] GetColumnsFromMode(ItemType itemType)
        {
            string[] output = Array.Empty<string>();
            switch (itemType)
            {
                case ItemType.comp:
                    output = new string[] { "Component Id", "Component Description", "Comp. Manufacturer's Id" };
                    break;
                case ItemType.tool:
                    output = new string[] { "Tool Id", "Tool Description", "Lead Comp. Manufacturer's Id" };
                    break;
                case ItemType.list:
                    output = new string[] { "Tool List Id", "Tool List Description", "Part Number" };
                    break;
                case ItemType.toolClass:
                    output = new string[] { "Tool Class ID", "Class Description" };
                    break;
                case ItemType.toolGroup:
                    output = new string[] { "Tool Group ID", "Group Description" };
                    break;
                case ItemType.mainClass:
                    output = new string[] { "Main Class ID", "Main Class Description" };
                    break;
            }
            return output;
        }
    }
}
