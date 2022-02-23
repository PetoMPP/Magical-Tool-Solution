using MTSLibrary;
using MTSLibrary.Models.Comps;
using MTSLibrary.Models.Lists;
using MTSLibrary.Models.SharedClasses;
using MTSLibrary.Models.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Magical_Tool_Solution
{
    public static class DataGridViewsLogic
    {
        public static IEnumerable<IListPositionModel> GetListPositionsFromUI(DataGridView dataGrid)
        {
            if (dataGrid.Rows.Count == 0)
            {
                return new List<IListPositionModel>();
            }
            List<IListPositionModel> output = new();
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                IListPositionModel model = new ListPositionModel()
                {
                    Position = int.Parse(row.Cells["position"].Value.ToString()),
                    Quantity = int.Parse(row.Cells["quantity"].Value.ToString())
                };
                if (!string.IsNullOrEmpty(row.Cells["componentId"].Value.ToString()))
                {
                    model.BasicComp = new BasicCompModel()
                    {
                        Id = row.Cells["componentId"].Value.ToString(),
                        Description1 = row.Cells["desc1"].Value.ToString(),
                        Description2 = row.Cells["desc2"].Value.ToString()
                    };
                }
                else
                {
                    model.BasicTool = new BasicToolModel()
                    {
                        Id = row.Cells["toolId"].Value.ToString(),
                        Description1 = row.Cells["desc1"].Value.ToString(),
                        Description2 = row.Cells["desc2"].Value.ToString()
                    };
                }
                output.Add(model);
            }
            return output;
        }
        public static IEnumerable<IToolComponentModel> GetComponentsFromUI(DataGridView dataGrid)
        {
            if (dataGrid.Rows.Count == 0)
            {
                return new List<IToolComponentModel>();
            }
            List<IToolComponentModel> output = new();
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                ToolComponentModel model = new()
                {
                    IsKey = bool.Parse(row.Cells["keyComp"].Value.ToString()),
                    Position = int.Parse(row.Cells["position"].Value.ToString()),
                    BasicComp = new BasicCompModel()
                    {
                        Id = row.Cells["componentId"].Value.ToString(),
                        Description1 = row.Cells["componentD1"].Value.ToString(),
                        Description2 = row.Cells["componentD2"].Value.ToString()
                    },
                    Quantity = int.Parse(row.Cells["quantity"].Value.ToString())
                };
                output.Add(model);
            }
            return output;
        }
        public static List<ParameterModel> GetParametersFromUI(DataGridView dataGrid)
        {
            if (dataGrid.Rows.Count == 0)
            {
                return new();
            }
            List<ParameterModel> output = new();
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                ParameterModel model = new()
                {
                    Position = int.Parse(row.Cells["Position"].Value.ToString()),
                    Id = row.Cells["Id"].Value.ToString(),
                    Name = row.Cells["Name"].Value.ToString(),
                    Description = row.Cells["Description"].Value.ToString(),
                    DataValueType = (DataValueType)Enum.Parse(typeof(DataValueType), row.Cells["DataValueType"].Value.ToString())
                };
                if (model.DataValueType == DataValueType.Numeric)
                {
                    if (!string.IsNullOrWhiteSpace(row.Cells["Value"].Value.ToString()))
                    {
                        string cellValue = row.Cells["Value"].Value.ToString();
                        if (!double.TryParse(cellValue, NumberStyles.Any, CultureInfo.CurrentCulture, out double value) &&
                            !double.TryParse(cellValue, NumberStyles.Any, CultureInfo.InvariantCulture, out value) &&
                            !double.TryParse(cellValue, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out value))
                        {
                            throw new FormatException("Unable to convert to double");
                        }
                        model.NumericValue = value;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(row.Cells["Value"].Value.ToString()))
                    {
                        model.TextValue = row.Cells["Value"].Value.ToString();
                    }
                }
                output.Add(model);
            }
            return output;
        }
        public static DataTable CreateListPositionsDataTable(IEnumerable<IListPositionModel> tools = null)
        {
            DataTable table = new();
            // Create Columns
            DataColumn[] dataColumns = new[]
            {
                new DataColumn("position", typeof(int)),
                new DataColumn("componentId", typeof(string)),
                new DataColumn("toolId", typeof(string)),
                new DataColumn("itemId", typeof(string)),
                new DataColumn("desc1", typeof(string)),
                new DataColumn("desc2", typeof(string)),
                new DataColumn("quantity", typeof(int)),
            };
            table.Columns.AddRange(dataColumns);
            if (tools != null)
            {
                foreach (ListPositionModel lp in tools)
                {
                    DataRow row;
                    row = table.NewRow();
                    row["position"] = lp.Position;
                    if (lp.BasicComp != null)
                    {
                        row["componentId"] = lp.BasicComp.Id;
                        row["itemId"] = lp.BasicComp.Id;
                        row["desc1"] = lp.BasicComp.Description1;
                        row["desc2"] = lp.BasicComp.Description2;
                    }
                    else if (lp.BasicTool != null)
                    {
                        row["toolId"] = lp.BasicTool.Id;
                        row["itemId"] = lp.BasicTool.Id;
                        row["desc1"] = lp.BasicTool.Description1;
                        row["desc2"] = lp.BasicTool.Description2;
                    }
                    row["quantity"] = lp.Quantity;
                    table.Rows.Add(row);
                }
            }
            return table;
        }
        public static void ConfigurePositionsDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToResizeRows = false;

            dataGrid.Columns["position"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["position"].HeaderText = "Position";
            dataGrid.Columns["position"].DisplayIndex = 0;
            dataGrid.Columns["position"].ReadOnly = true;

            dataGrid.Columns["itemId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["itemId"].HeaderText = "ID";
            dataGrid.Columns["itemId"].DisplayIndex = 1;
            dataGrid.Columns["itemId"].ReadOnly = true;

            dataGrid.Columns["desc1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["desc1"].HeaderText = "Description 1";
            dataGrid.Columns["desc1"].DisplayIndex = 2;
            dataGrid.Columns["desc1"].ReadOnly = true;

            dataGrid.Columns["desc2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns["desc2"].HeaderText = "Description 2";
            dataGrid.Columns["desc2"].DisplayIndex = 3;
            dataGrid.Columns["desc2"].ReadOnly = true;

            dataGrid.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["quantity"].HeaderText = "Quantity";
            dataGrid.Columns["quantity"].DisplayIndex = 4;
            dataGrid.Columns["quantity"].ReadOnly = true;

            dataGrid.Columns["componentId"].Visible = false;
            dataGrid.Columns["toolId"].Visible = false;
        }
        public static DataTable CreateComponentsDataTable(IEnumerable<IToolComponentModel> components = null)
        {
            DataTable table = new();
            // Create Columns
            DataColumn[] dataColumns = new[]
            {
                new DataColumn("keyComp", typeof(bool)),
                new DataColumn("position", typeof(int)),
                new DataColumn("componentId", typeof(string)),
                new DataColumn("componentD1", typeof(string)),
                new DataColumn("componentD2", typeof(string)),
                new DataColumn("quantity", typeof(int)),
            };
            table.Columns.AddRange(dataColumns);
            if (components != null)
            {
                foreach (IToolComponentModel tc in components)
                {
                    DataRow row;
                    row = table.NewRow();
                    row["keyComp"] = tc.IsKey;
                    row["position"] = tc.Position;
                    row["componentId"] = tc.BasicComp.Id;
                    row["componentD1"] = tc.BasicComp.Description1;
                    row["componentD2"] = tc.BasicComp.Description2;
                    row["quantity"] = tc.Quantity;
                    table.Rows.Add(row);
                }
            }
            return table;
        }
        public static void ConfigureParametersDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToResizeRows = false;

            dataGrid.Columns["Position"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["Position"].DisplayIndex = 0;
            dataGrid.Columns["Position"].ReadOnly = true;

            dataGrid.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["Id"].HeaderText = "ID";
            dataGrid.Columns["Id"].DisplayIndex = 1;
            dataGrid.Columns["Id"].ReadOnly = true;

            dataGrid.Columns["Value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["Value"].DisplayIndex = 2;

            dataGrid.Columns["DataValueType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["DataValueType"].HeaderText = "Value Type";
            dataGrid.Columns["DataValueType"].DisplayIndex = 3;

            dataGrid.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["Name"].HeaderText = "Parameter Name";
            dataGrid.Columns["Name"].DisplayIndex = 4;
            dataGrid.Columns["Name"].ReadOnly = true;

            dataGrid.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns["Description"].DisplayIndex = 5;
            dataGrid.Columns["Description"].ReadOnly = true;

            dataGrid.Columns["NumericValue"].Visible = false;
            dataGrid.Columns["TextValue"].Visible = false;
        }
        public static void ConfigureComponentsDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToResizeRows = false;

            dataGrid.Columns["keyComp"].HeaderText = "Is key Component?";
            dataGrid.Columns["keyComp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["keyComp"].ReadOnly = true;

            dataGrid.Columns["position"].HeaderText = "Position";
            dataGrid.Columns["position"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["position"].ReadOnly = true;

            dataGrid.Columns["componentId"].HeaderText = "Component ID";
            dataGrid.Columns["componentId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["componentId"].ReadOnly = true;

            dataGrid.Columns["componentD1"].HeaderText = "Component Description";
            dataGrid.Columns["componentD1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGrid.Columns["componentD1"].ReadOnly = true;
            dataGrid.Columns["componentD1"].Resizable = DataGridViewTriState.False;

            dataGrid.Columns["componentD2"].HeaderText = "Component Order Code";
            dataGrid.Columns["componentD2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["componentD2"].ReadOnly = true;

            dataGrid.Columns["quantity"].HeaderText = "Quantity";
            dataGrid.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGrid.Columns["quantity"].ReadOnly = true;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                row.Cells["keyComp"].ReadOnly = true;
            }
        }

    }
}
