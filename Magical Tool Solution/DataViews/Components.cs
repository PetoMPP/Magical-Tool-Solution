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
    public partial class Components : Form, ISelectComponent
    {
        private readonly Form parentCallingForm;
        public Components(Form caller)
        {
            parentCallingForm = caller;
            InitializeComponent();
        }

        public void AddComponent(ToolComponentModel model)
        {
            int rowIndex = componentsDataGridView.Rows.Add();
            DataGridViewRow row = componentsDataGridView.Rows[rowIndex];
            row.Cells["keyComp"].Value = model.IsKey;
            row.Cells["position"].Value = model.Position;
            row.Cells["componentId"].Value = model.Comp.Id;
            row.Cells["componentD1"].Value = model.Comp.Desc1;
            row.Cells["componentD2"].Value = model.Comp.Desc2;
            row.Cells["quantity"].Value = model.Quantity;
        }

        public bool IsPositionNumberInUse(int position)
        {
            if (componentsDataGridView.RowCount > 0)
            {
                foreach (DataGridViewRow row in componentsDataGridView.Rows)
                {
                    if (int.Parse(row.Cells["position"].Value.ToString()) == position)
                    {
                        return true;
                    }
                }
            }
            return false;
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
                }
                ToolComponentModel model = new() { Position = nextCompPosition, Quantity = 1 };
                Form form = new BasicItemSelector(ItemType.comp, CreatingType.creating, parentCallingForm, model, this);
                form.Visible = true;
                form.BringToFront();
                form.Focus();
                parentCallingForm.Enabled = false;
            }
            else if (componentsDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                // If double click in key comp column switch value for clicked component
                if (componentsDataGridView.HitTest(e.X, e.Y).ColumnIndex == componentsDataGridView.Columns["keyComp"].Index)
                {
                    DataGridViewCell cell = componentsDataGridView.Rows[componentsDataGridView.HitTest(e.X, e.Y).RowIndex].Cells["keyComp"];
                    if ((bool)cell.Value)
                    {
                        cell.Value = false;
                    }
                    else
                    {
                        cell.Value = true;
                    }
                }
                //Create model from selected row
                else
                {
                    ToolComponentModel model = new();
                    model.Comp = new CompModel();
                    DataGridViewRow row = componentsDataGridView
                        .Rows[componentsDataGridView.HitTest(e.X, e.Y)
                        .RowIndex];
                    model.IsKey = bool.Parse(row.Cells["keyComp"].Value.ToString());
                    model.Position = int.Parse(row.Cells["position"].Value.ToString());
                    model.Comp.Id = row.Cells["componentId"].Value.ToString();
                    model.Comp.Desc1 = row.Cells["componentD1"].Value.ToString();
                    model.Comp.Desc2 = row.Cells["componentD2"].Value.ToString();
                    model.Quantity = int.Parse(row.Cells["quantity"].Value.ToString());
                    Form form = new BasicItemSelector(ItemType.comp, CreatingType.updating, parentCallingForm, model, this);
                    form.Visible = true;
                    form.BringToFront();
                    form.Focus();
                    parentCallingForm.Enabled = false;
                }
            }
        }
    }
}
