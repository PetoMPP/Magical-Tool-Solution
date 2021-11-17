using Magical_Tool_Solution.DataViews.Selectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Magical_Tool_Solution.Configuration
{
    public partial class ClgrConfiguration : Form
    {
        Form callingForm;
        public ClgrConfiguration(Form caller)
        {
            callingForm = caller;
            InitializeComponent();
        }

        private void ClgrConfiguration_FormClosed(object sender, FormClosedEventArgs e)
        {
            callingForm.Visible = true;
        }

        private void ClassesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (classesListBox.SelectedItem == null)
            {
                //open new class editor 
                Form form = new ClgrEntryEditor("class_new", this);
                form.Visible = true;
            }
            else
            {
                //open edit class editor
                Form form = new ClgrEntryEditor("class_update", this);
                form.Visible = true;
            }
            DisableForm();
        }

        private void DisableForm()
        {
            foreach (Control control in Controls)
            {
                control.Enabled = false;
            }
        }

        private void GroupsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (groupsListBox.SelectedItem == null)
            {
                //open new group editor 
                Form form = new ClgrEntryEditor("group_new", this);
                form.Visible = true;
            }
            else
            {
                //open edit group editor
                Form form = new ClgrEntryEditor("group_update", this);
                form.Visible = true;
            }
            DisableForm();
        }
        private void PositionsDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (positionsDataGridView.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
            {
                //new parameter editor
                Form form = new ParameterEditor("parameter_new", this);
                form.Visible = true;
            }
            else if (positionsDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                //update parameter
                Form form = new ParameterEditor("parameter_update", this);
                form.Visible = true;
            }
        }
    }
}
