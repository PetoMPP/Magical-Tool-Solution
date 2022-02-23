using Magical_Tool_Solution.DataViews.Selectors;
using Magical_Tool_Solution.Interfaces;
using MTSLibrary;
using MTSLibrary.Models.Comps;
using MTSLibrary.Models.Lists;
using MTSLibrary.Models.Tools;
using System.Windows.Forms;

namespace Magical_Tool_Solution.DataViews
{
    public partial class Positions : Form
    {
        private readonly Form parentCallingForm;
        private readonly ISelectPosition _selectPosition;

        public Positions(Form caller, ISelectPosition selectPosition)
        {
            parentCallingForm = caller;
            _selectPosition = selectPosition;
            InitializeComponent();
        }

        //public void AddPosition(ListPositionModel model)
        //{
        //    int rowIndex = positionsDataGridView.Rows.Add();
        //    DataGridViewRow row = positionsDataGridView.Rows[rowIndex];
        //    row.Cells["position"].Value = model.Position;
        //    if (model.BasicComp != null)
        //    {
        //        row.Cells["componentId"].Value = model.BasicComp.Id;
        //        row.Cells["desc1"].Value = model.BasicComp.Description1;
        //        row.Cells["desc2"].Value = model.BasicComp.Description2;
        //    }
        //    else if (model.BasicTool != null)
        //    {
        //        row.Cells["toolId"].Value = model.BasicTool.Id;
        //        row.Cells["desc1"].Value = model.BasicTool.Description1;
        //        row.Cells["desc2"].Value = model.BasicTool.Description2;
        //    }
        //    row.Cells["quantity"].Value = model.Quantity;
        //}

        //public bool IsPositionNumberInUse(int position)
        //{
        //    if (positionsDataGridView.RowCount > 0)
        //    {
        //        foreach (DataGridViewRow row in positionsDataGridView.Rows)
        //        {
        //            if ((int)row.Cells["position"].Value == position)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

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
                Form form = new BasicItemSelector(ItemType.Tool, CreatingType.Creating, parentCallingForm, model, _selectPosition);
                form.Visible = true;
                form.BringToFront();
                form.Focus();
                parentCallingForm.Enabled = false;
            }
            else if (positionsDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                ItemType itemType = ItemType.Tool;
                ListPositionModel model = new();
                DataGridViewRow row = positionsDataGridView
                    .Rows[positionsDataGridView.HitTest(e.X, e.Y)
                    .RowIndex];
                model.Position = int.Parse(row.Cells["position"].Value.ToString());
                model.Quantity = int.Parse(row.Cells["quantity"].Value.ToString());
                if (!string.IsNullOrWhiteSpace(row.Cells["componentId"].Value.ToString()))
                {
                    model.BasicComp = new BasicCompModel
                    {
                        Id = row.Cells["componentId"].Value.ToString(),
                        Description1 = row.Cells["desc1"].Value.ToString(),
                        Description2 = row.Cells["desc2"].Value.ToString()
                    };
                    itemType = ItemType.Comp;
                }
                if (!string.IsNullOrWhiteSpace(row.Cells["toolId"].Value.ToString()))
                {
                    model.BasicTool = new BasicToolModel
                    {
                        Id = row.Cells["toolId"].Value.ToString(),
                        Description1 = row.Cells["desc1"].Value.ToString(),
                        Description2 = row.Cells["desc2"].Value.ToString()
                    };
                    itemType = ItemType.Tool;
                }
                Form form = new BasicItemSelector(itemType,
                    CreatingType.Updating,
                    parentCallingForm,
                    model,
                    _selectPosition);
                form.Visible = true;
                form.BringToFront();
                form.Focus();
                parentCallingForm.Enabled = false;
            }
        }

    }
}
