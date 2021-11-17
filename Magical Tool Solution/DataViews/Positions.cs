using Magical_Tool_Solution.DataViews.Selectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Magical_Tool_Solution.DataViews
{
    public partial class Tools : Form
    {
        Form parentCallingForm;
        public Tools(Form caller)
        {
            parentCallingForm = caller;
            InitializeComponent();
        }
        private void PositionsDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (positionsDataGridView.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
            {
                Form form = new BasicItemSelector("position_new", parentCallingForm);
                form.Visible = true;
                form.BringToFront();
                form.Focus();
                foreach (Control control in parentCallingForm.Controls)
                {
                    control.Enabled = false;
                }
            }
            else if (positionsDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                Form form = new BasicItemSelector("position_update", parentCallingForm);
                form.Visible = true;
                form.BringToFront();
                form.Focus();
                foreach (Control control in parentCallingForm.Controls)
                {
                    control.Enabled = false;
                }
            }
        }
    }
}
