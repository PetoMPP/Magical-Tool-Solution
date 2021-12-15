using Magical_Tool_Solution.Interfaces;
using MTSLibrary.Models;
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
        private readonly ISelectItem callingIForm;
        private readonly Form callingForm;
        public BasicItemLookup(ISelectItem callingInterface, Form caller, string[] columnNames, int leadColumn)
        {
            callingIForm = callingInterface;
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

        private void CancelButton_Click(object sender, EventArgs e) => Close();

        private void BasicItemLookup_FormClosed(object sender, FormClosedEventArgs e) => callingForm.Enabled = true;

        private void OkButton_Click(object sender, EventArgs e)
        {
            //Get id column index
            int idColumnIndex = GetIdColumnIndex();
            //Execute selected item load
            string itemId = lookupDataGridView.SelectedRows[0].Cells[idColumnIndex].Value.ToString();
            callingIForm.LoadSelectedItem(itemId);

        }

        private int GetIdColumnIndex()
        {
            int idColumnIndex = 0;
            foreach (DataGridViewColumn column in lookupDataGridView.Columns)
            {
                if (column.HeaderText == "Component Id" || column.HeaderText == "Tool Id" || column.HeaderText == "Tool List Id")
                {
                    idColumnIndex = column.Index;
                    break;
                }
            }
            return idColumnIndex;
        }

        private void LookupDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lookupDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                string itemId = lookupDataGridView.Rows[lookupDataGridView.HitTest(e.X, e.Y).RowIndex].Cells[GetIdColumnIndex()].Value.ToString();
                callingIForm.LoadSelectedItem(itemId);
            }
        }

        private void LookupDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (lookupDataGridView.SelectedRows != null)
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }

    }
}
