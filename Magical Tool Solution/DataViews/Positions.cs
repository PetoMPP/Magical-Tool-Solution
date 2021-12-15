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
    public partial class Positions : Form, ISelectPosition
    {
        private readonly Form parentCallingForm;
        public Positions(Form caller)
        {
            parentCallingForm = caller;
            InitializeComponent();
        }

        public void AddPosition(ListPositionModel model)
        {
            int rowIndex = positionsDataGridView.Rows.Add();
            DataGridViewRow row = positionsDataGridView.Rows[rowIndex];
            row.Cells["position"].Value = model.Position;
            if (model.Comp != null)
            {
                row.Cells["componentId"].Value = model.Comp.Id;
                row.Cells["desc1"].Value = model.Comp.Desc1;
                row.Cells["desc2"].Value = model.Comp.Desc2;
            }
            else if (model.Tool != null)
            {
                row.Cells["toolId"].Value = model.Tool.Id;
                row.Cells["desc1"].Value = model.Tool.Desc1;
                row.Cells["desc2"].Value = model.Tool.Desc2;
            }
            row.Cells["quantity"].Value = model.Quantity;
        }

        public bool IsPositionNumberInUse(int position)
        {
            if (positionsDataGridView.RowCount > 0)
            {
                foreach (DataGridViewRow row in positionsDataGridView.Rows)
                {
                    if ((int)row.Cells["position"].Value == position)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void PositionsDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (positionsDataGridView.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
            {
                //get list position position xd
                int nextPositionPosition = 0;
                if (positionsDataGridView.RowCount == 0)
                {
                    nextPositionPosition = 1;
                }
                else
                {
                    foreach (DataGridViewRow row in positionsDataGridView.Rows)
                    {
                        if ((int)row.Cells["position"].Value > nextPositionPosition)
                        {
                            nextPositionPosition = (int)row.Cells["position"].Value;
                        }
                    }
                }
                ListPositionModel model = new() { Position = nextPositionPosition, Quantity = 1 };
                Form form = new BasicItemSelector(ItemType.tool, CreatingType.creating, parentCallingForm, model, this);
                form.Visible = true;
                form.BringToFront();
                form.Focus();
                parentCallingForm.Enabled = false;
            }
            else if (positionsDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                ItemType itemType = ItemType.tool;
                ListPositionModel model = new();
                DataGridViewRow row = positionsDataGridView
                    .Rows[positionsDataGridView.HitTest(e.X, e.Y)
                    .RowIndex];
                model.Position = int.Parse(row.Cells["postion"].Value.ToString());
                model.Quantity = int.Parse(row.Cells["quantity"].Value.ToString());
                if (row.Cells["componentId"].Value.ToString() != "")
                {
                    model.Comp = new CompModel
                    {
                        Id = row.Cells["componentId"].Value.ToString(),
                        Desc1 = row.Cells["desc1"].Value.ToString(),
                        Desc2 = row.Cells["desc2"].Value.ToString()
                    };
                    itemType = ItemType.comp;
                }
                if (row.Cells["toolId"].Value.ToString() != "")
                {
                    model.Tool = new ToolModel
                    {
                        Id = row.Cells["toolId"].Value.ToString(),
                        Desc1 = row.Cells["desc1"].Value.ToString(),
                        Desc2 = row.Cells["desc2"].Value.ToString()
                    };
                    itemType = ItemType.tool;
                }
                Form form = new BasicItemSelector(itemType,
                    CreatingType.updating,
                    parentCallingForm,
                    model,
                    this);
                form.Visible = true;
                form.BringToFront();
                form.Focus();
                parentCallingForm.Enabled = false;
            }
        }
    }
}
