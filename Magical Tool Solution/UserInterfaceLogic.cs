using MTSLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
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
                if (dataGridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                {
                    dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Selected = true;
                }
                else if (dataGridView.SelectionMode == DataGridViewSelectionMode.CellSelect)
                {
                    dataGridView.Rows[dataGridView.HitTest(e.X, e.Y).RowIndex].Cells[dataGridView.HitTest(e.X, e.Y).ColumnIndex].Selected = true;
                }
            }
            contextMenuRefresh();
        }
        public static string[] GetColumnsFromMode(ItemType itemType)
        {
            string[] output = Array.Empty<string>();
            switch (itemType)
            {
                case ItemType.Comp:
                    output = new string[] { "Component Id", "Component Description", "Comp. Manufacturer's Id" };
                    break;
                case ItemType.Tool:
                    output = new string[] { "Tool Id", "Tool Description", "Lead Comp. Manufacturer's Id" };
                    break;
                case ItemType.List:
                    output = new string[] { "Tool List Id", "Tool List Description", "Part Number" };
                    break;
                case ItemType.ToolClass:
                    output = new string[] { "Tool Class ID", "Class Description" };
                    break;
                case ItemType.ToolGroup:
                    output = new string[] { "Tool Group ID", "Group Description" };
                    break;
                case ItemType.MainClass:
                    output = new string[] { "Main Class ID", "Main Class Description" };
                    break;
            }
            return output;
        }
        public static void ValidateKeyPressedIsNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // Probably a little overkill but it makes setting minvalues in the ui not necessary
        public static void ResizePanelsEvenly(Form caller, Control widthReferenceControl, Panel panel1, Panel panel2, int minWidth1 = 0, int minWidth2 = 0, int widthOffset = 0)
        {
            SuspendLayouts(panel1, panel2);
            // Calculate potential widths
            int width = (int)Math.Round((decimal)(widthReferenceControl.Width - widthOffset) / 2);
            // If no panel is on min size resize both
            if (panel1.Width > minWidth1 && panel2.Width > minWidth2)
            {
                // Check if resizing voliates min sizes
                if (width >= minWidth1 && width >= minWidth2)
                {
                    panel1.Width = width;
                    panel2.Width = width;
                    ResumeLayouts(panel1, panel2);
                    return;
                }
                // It has to priorotize growth of one panel over the other, let's determine it by minsizes (smaller grows first), if those are equal number one grows first
                if (minWidth1 <= minWidth2)
                {
                    panel1.Width = widthReferenceControl.Width - minWidth2;
                    panel2.Width = minWidth2;
                    ResumeLayouts(panel1, panel2);
                    return;
                }
                panel1.Width = minWidth1;
                panel2.Width = widthReferenceControl.Width - minWidth1;
                ResumeLayouts(panel1, panel2);
                return;
            }
            // If both are on minimal size set current Form size as sum of minimal widths + border
            if (panel1.Width <= minWidth1 && panel2.Width <= minWidth2)
            {
                int bordersWidth = caller.Width - widthReferenceControl.Width;
                panel1.Width = minWidth1;
                panel2.Width = minWidth2;
                caller.Width = minWidth1 + minWidth2 + bordersWidth;
                caller.MinimumSize = new System.Drawing.Size(minWidth1 + minWidth2 + bordersWidth, 0);
                ResumeLayouts(panel1, panel2);
                return;
            }
            // The next steps are tricky, because those need to work with increase and decrease of width
            if (panel1.Width <= minWidth1)
            {
                panel1.Width = minWidth1 + widthReferenceControl.Width - minWidth2;
                panel2.Width = widthReferenceControl.Width - minWidth1;
                ResumeLayouts(panel1, panel2);
                return;
            }
            if (panel2.Width <= minWidth2)
            {
                panel2.Width = minWidth2 + widthReferenceControl.Width - minWidth1;
                panel1.Width = widthReferenceControl.Width - minWidth2;
                ResumeLayouts(panel1, panel2);
                return;
            }
        }

        private static void SuspendLayouts(params Panel[] panels)
        {
            foreach (Panel panel in panels)
            {
                panel.SuspendLayout();
            }
        }
        private static void ResumeLayouts(params Panel[] panels)
        {
            foreach (Panel panel in panels)
            {
                panel.ResumeLayout();
            }
        }
    }
}
