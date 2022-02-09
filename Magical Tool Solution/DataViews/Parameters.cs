using MTSLibrary;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Magical_Tool_Solution.DataViews
{
    public partial class Parameters : Form
    {
        private readonly ItemType _itemType;

        public Parameters(ItemType itemType)
        {
            InitializeComponent();
            AdjustUI();
            _itemType = itemType;
        }

        private void AdjustUI()
        {
            if (_itemType == ItemType.Comp)
            {
                parametersLabel.Text = "Component Parameters:";
            }
            else if (_itemType == ItemType.Tool)
            {
                parametersLabel.Text = "Tool Parameters:";
            }
        }

        private void ParametersDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == parametersDataGridView.Columns["Value"].Index)
            {
                if (Enum.Parse<DataValueType>(parametersDataGridView.Rows[e.RowIndex].Cells[parametersDataGridView.Columns["DataValueType"].Index].Value.ToString()) == DataValueType.Numeric)
                {
                    // regex sholud accept values like: 834, -3,433, 5.22
                    if (Regex.Match(e.FormattedValue.ToString(), @"^-?\d{0,6}[.,]?\d{0,6}").Length != e.FormattedValue.ToString().Length)
                    {
                        MessageBox.Show("Enter a valid numeric value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void ParametersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            parametersDataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
        }
    }
}
