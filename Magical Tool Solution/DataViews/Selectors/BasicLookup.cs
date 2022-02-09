using Magical_Tool_Solution.Interfaces;
using MTSLibrary;
using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Magical_Tool_Solution.DataViews.Selectors
{
    public partial class BasicLookup : Form
    {
        private readonly ISelectItem _selectItem;
        private readonly ISelectToolClass _selectToolClass;
        private readonly ISelectToolGroup _selectToolGroup;
        private readonly ISelectMainClass _selectMainClass;
        private readonly Form _callingForm;
        public BasicLookup(ISelectItem callingInterface, Form caller, string[] columnNames, int leadColumn, ItemType itemType)
        {
            _selectItem = callingInterface;
            _callingForm = caller;
            InitializeComponent();
            LoadData(itemType, columnNames, leadColumn);
            AdjustUI();
        }
        public BasicLookup(ISelectToolClass selectToolClass, Form caller, string[] columnNames, int leadColumn, ItemType itemType)
        {
            _selectToolClass = selectToolClass;
            _callingForm = caller;
            InitializeComponent();
            LoadData(itemType, columnNames, leadColumn);
            AdjustUI();
        }

        public BasicLookup(ISelectToolGroup selectToolGroup, Form caller, string[] columnNames, int leadColumn, ItemType itemType)
        {
            _selectToolGroup = selectToolGroup;
            _callingForm = caller;
            InitializeComponent();
            LoadData(itemType, columnNames, leadColumn);
            AdjustUI();
        }
        public BasicLookup(ISelectMainClass selectMainClass, Form caller, string[] columnNames, int leadColumn, ItemType itemType)
        {
            _selectMainClass = selectMainClass;
            _callingForm = caller;
            InitializeComponent();
            LoadData(itemType, columnNames, leadColumn);
            AdjustUI();
        }

        private void LoadData(ItemType itemType, string[] columnNames, int leadColumn)
        {
            // get datatable of specified data type
            DataTable table = new();
            switch (itemType)
            {
                case ItemType.Comp:
                    List<BasicCompModel> basicCompModels = GlobalConfig.Connection.GetBasicCompModels();
                    table = ProgramLogic.CreateDataTableFromListOfModels(basicCompModels);
                    break;
                case ItemType.Tool:
                    List<BasicToolModel> basicToolModels = GlobalConfig.Connection.GetBasicToolModels();
                    table = ProgramLogic.CreateDataTableFromListOfModels(basicToolModels);
                    break;
                case ItemType.List:
                    List<BasicListModel> basicListModels = GlobalConfig.Connection.GetBasicListModels();
                    table = ProgramLogic.CreateDataTableFromListOfModels(basicListModels);
                    break;
                case ItemType.ToolClass:
                    List<BasicToolClassModel> basicToolClassModels = GlobalConfig.Connection.GetBasicToolClassModels();
                    table = ProgramLogic.CreateDataTableFromListOfModels(basicToolClassModels);
                    break;
                case ItemType.ToolGroup:
                    List<BasicToolGroupModel> basicToolGroupModels = GlobalConfig.Connection.GetBasicToolGroupsModels();
                    table = ProgramLogic.CreateDataTableFromListOfModels(basicToolGroupModels);
                    break;
                case ItemType.MainClass:
                    List<BasicMainClassModel> basicMainClassModels = GlobalConfig.Connection.GetBasicMainClassModels();
                    table = ProgramLogic.CreateDataTableFromListOfModels(basicMainClassModels);
                    break;
                case ItemType.User:
                    List<string> userNames = GlobalConfig.Connection.GetUsers();
                    table = ProgramLogic.CreateSimpleDataTable(userNames);
                    break;
            }

            // wire up data grid
            WireUpDataGrid(columnNames, leadColumn, table);
        }

        private void WireUpDataGrid(string[] columnNames, int leadColumn, DataTable table)
        {
            lookupDataGridView.DataSource = table;
            for (int i = 0; i < columnNames.Length; i++)
            {
                DataGridViewColumn column = lookupDataGridView.Columns[i];
                column.HeaderText = columnNames[i];
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (i == leadColumn)
                {
                    column.DisplayIndex = 0;
                }
            }
        }

        private void AdjustUI()
        {
            int requiredTextBoxesCount = lookupDataGridView.ColumnCount;
            switch (requiredTextBoxesCount)
            {
                case 2:
                    searchTextBox3Panel.Visible = false;
                    Width -= 201;
                    break;
                case 1:
                    searchTextBox3Panel.Visible = false;
                    searchTextBox2Panel.Visible = false;
                    Width -= 402;
                    okButtonPanel.Width = 100;
                    cancelButtonPanel.Width = 100;
                    break;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) => Close();

        private void BasicLookup_FormClosed(object sender, FormClosedEventArgs e) => _callingForm.Enabled = true;

        private void OkButton_Click(object sender, EventArgs e)
        {
            //Execute selected item load
            LoadSelectedItem();
            Close();
        }

        private void LoadSelectedItem()
        {
            string id = lookupDataGridView.SelectedRows[0].Cells["Id"].Value.ToString();
            if (_selectItem != null)
            {
                _selectItem.LoadSelectedItem(id);
                return;
            }
            string name = lookupDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
            if (_selectToolClass != null)
            {
                _selectToolClass.LoadSelectedBasicToolClass(new BasicToolClassModel() { Id = id, Name = name });
                return;
            }
            if (_selectToolGroup != null)
            {
                _selectToolGroup.LoadSelectedBasicToolGroup(new BasicToolGroupModel() { Id = id, Name = name });
                return;
            }
            if (_selectMainClass != null)
            {
                _selectMainClass.LoadSelectedBasicMainClass(new BasicMainClassModel() { Id = id, Name = name });
            }
        }

        private void LookupDataGridViewISelectItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lookupDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                LoadSelectedItem();
                Close();
            }
        }

        private void LookupDataGridView_SelectionChanged(object sender, EventArgs e) => okButton.Enabled = lookupDataGridView.SelectedRows != null;

    }
}
