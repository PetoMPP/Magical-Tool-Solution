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
    public partial class Components : Form
    {
        Form parentCallingForm;
        public Components(Form caller)
        {
            parentCallingForm = caller;
            InitializeComponent();
        }
        private void ComponentsDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (componentsDataGridView.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
            {
                Form form = new BasicItemSelector("comp_new", parentCallingForm);
                form.Visible = true;
                form.BringToFront();
                form.Focus();
                foreach (Control control in parentCallingForm.Controls)
                {
                    control.Enabled = false;
                }
            }
            else if (componentsDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                Form form = new BasicItemSelector("comp_update", parentCallingForm);
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
