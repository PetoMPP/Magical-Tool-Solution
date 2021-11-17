using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Magical_Tool_Solution.DataViews.Selectors
{
    public partial class BasicItemLookup : Form
    {
        Form callingForm;
        public BasicItemLookup(Form caller, string[] columnNames, int leadColumn)
        {
            callingForm = caller;
            InitializeComponent();
            AdjustUI(columnNames, leadColumn);
        }

        private void AdjustUI(string[] columnNames, int leadColumn)
        {
            int i = 0;
            foreach (DataGridViewColumn column in lookupDataGridView.Columns)
            {
                column.HeaderText = columnNames[i];
                if (leadColumn == i)
                {
                    column.DisplayIndex = 0;
                }
                i++;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BasicItemLookup_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Control control in callingForm.Controls)
            {
                control.Enabled = true;
            }
        }
    }
}
