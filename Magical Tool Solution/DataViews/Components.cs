using Magical_Tool_Solution.DataViews.Selectors;
using Magical_Tool_Solution.Interfaces;
using MTSLibrary;
using MTSLibrary.Models;
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
        private readonly Form parentCallingForm;
        private readonly ISelectComponent _selectComponent;

        public Components(Form caller, ISelectComponent selectComponent)
        {
            parentCallingForm = caller;
            _selectComponent = selectComponent;
            InitializeComponent();
        }

        private void ComponentsDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (componentsDataGridView.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
            {
                int nextCompPosition = 0;
                if (componentsDataGridView.RowCount == 0)
                {
                    nextCompPosition = 1;
                }
                else
                {
                    //get position column index
                    foreach (DataGridViewRow row in componentsDataGridView.Rows)
                    {
                        if (int.Parse(row.Cells["position"].Value.ToString()) > nextCompPosition)
                        {
                            nextCompPosition = int.Parse(row.Cells["position"].Value.ToString());
                        }
                    }
                    nextCompPosition++;
                }
                ToolComponentModel model = new() { Position = nextCompPosition, Quantity = 1 };
                Form form = new BasicItemSelector(ItemType.comp, CreatingType.creating, parentCallingForm, model, _selectComponent);
                form.Visible = true;
                form.BringToFront();
                form.Focus();
                parentCallingForm.Enabled = false;
            }
            else if (componentsDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                if (componentsDataGridView.HitTest(e.X, e.Y).ColumnIndex == componentsDataGridView.Columns["keyComp"].Index)
                {
                    return;
                }
                //Create model from selected row
                ToolComponentModel model = new();
                model.BasicComp = new BasicCompModel();
                DataGridViewRow row = componentsDataGridView
                    .Rows[componentsDataGridView.HitTest(e.X, e.Y)
                    .RowIndex];
                model.IsKey = bool.Parse(row.Cells["keyComp"].Value.ToString());
                model.Position = int.Parse(row.Cells["position"].Value.ToString());
                model.BasicComp.Id = row.Cells["componentId"].Value.ToString();
                model.BasicComp.Description1 = row.Cells["componentD1"].Value.ToString();
                model.BasicComp.Description2 = row.Cells["componentD2"].Value.ToString();
                model.Quantity = int.Parse(row.Cells["quantity"].Value.ToString());
                Form form = new BasicItemSelector(ItemType.comp, CreatingType.updating, parentCallingForm, model, _selectComponent);
                form.Visible = true;
                form.BringToFront();
                form.Focus();
                parentCallingForm.Enabled = false;
            }
        }

        private void DeleteComponentToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (componentsDataGridView.HitTest(e.X, e.Y) != DataGridView.HitTestInfo.Nowhere)
            {
                _selectComponent.DeleteToolComponent(int.Parse(componentsDataGridView.SelectedRows[0].Cells["position"].Value.ToString()));
            }
        }
        private void WireUpContextMenu()
        {
            if (componentsDataGridView.SelectedRows.Count > 0)
            {
                deleteComponentToolStripMenuItem.Enabled = true;
                return;
            }
            deleteComponentToolStripMenuItem.Enabled = false;
        }

        private void ComponentsDataGridView_MouseDown(object sender, MouseEventArgs e) => UserInterfaceLogic.HandleRightClick(componentsDataGridView, e, WireUpContextMenu);

        private static void EnforceSingleKeyComponent(DataGridView dataGrid, DataGridViewCell cell)
        {
            if ((bool)cell.Value == true)
            {
                cell.Value = false;
                return;
            }
            int keyColumnIndex = dataGrid.Columns["keyComp"].Index;
            int trueIndex = -1;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.Cells[keyColumnIndex].Value.ToString() == true.ToString())
                {
                    trueIndex = row.Cells[keyColumnIndex].RowIndex;
                }
            }
            if (trueIndex > -1 && trueIndex != cell.RowIndex)
            {
                cell.Value = false;
            }
            else
            {
                cell.Value = true;
            }
        }

        //private void ComponentsDataGridView_MouseUp(object sender, MouseEventArgs e)
        //{
        //    DataGridView dataGrid = (DataGridView)sender;
        //    dataGrid.CancelEdit();
        //}

        //private void ComponentsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    // This method launches after changing the value
        //    if (e.RowIndex < 0 || e.ColumnIndex < 0)
        //    {
        //        return;
        //    }
        //    DataGridView dataGrid = (DataGridView)sender;
        //    if (!EnforceSingleKeyComponent(dataGrid))
        //    {
        //        DataGridViewCell cell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //        cell.Value = false;
        //    }
        //}

        private void ComponentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;
            if (e.ColumnIndex == dataGrid.Columns["keyComp"].Index)
            {
                dataGrid.EndEdit();
                DataGridViewCell cell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                EnforceSingleKeyComponent(dataGrid, cell); 
            }
        }

        //private void ComponentsDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    DataGridView dataGrid = (DataGridView)sender;
        //    dataGrid.EndEdit();
        //}

        //private void ComponentsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    // todo - fix
        //    // get index of IsKey column
        //    int keyColumnIndex = componentsDataGridView.Columns["keyComp"].Index;
        //    // check if event fired in IsKey column
        //    if (e.ColumnIndex == keyColumnIndex)
        //    {
        //        // There can be only one Key Component in assembly
        //        int trueRowIndex = -1;
        //        foreach (DataGridViewRow row in componentsDataGridView.Rows)
        //        {
        //            if (row.Cells[keyColumnIndex].Value.ToString() == true.ToString())
        //            {
        //                trueRowIndex = row.Index;
        //            }
        //        }
        //        if (trueRowIndex != e.RowIndex && trueRowIndex != -1)
        //        {
        //            e.Cancel = true;
        //        }
        //    }
        //    componentsDataGridView.ClearSelection();
        //}

        //private void ComponentsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == -1 || e.RowIndex == -1)
        //    {
        //        return;
        //    }
        //    DataGridView dataGrid = (DataGridView)sender;
        //    // get index of IsKey column
        //    int keyColumnIndex = dataGrid.Columns["keyComp"].Index;
        //    // check if event fired in IsKey column
        //    if (e.ColumnIndex == keyColumnIndex)
        //    {
        //        // There can be only one Key Component in assembly
        //        int trueRowIndex = -1;
        //        foreach (DataGridViewRow row in dataGrid.Rows)
        //        {
        //            if (row.Cells[keyColumnIndex].Value.ToString() == true.ToString())
        //            {
        //                trueRowIndex = row.Index;
        //            }
        //        }
        //        if (trueRowIndex != e.RowIndex && trueRowIndex != -1)
        //        {
        //            DataGridViewCell cell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //            cell.Value = false;
        //        }
        //    }
        //}
    }
}
