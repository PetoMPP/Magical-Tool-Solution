using Magical_Tool_Solution.DataViews.Selectors;
using Magical_Tool_Solution.Interfaces;
using MTSLibrary;
using MTSLibrary.Models.ToolClasses;
using MTSLibrary.Models.ToolClassParameters;
using MTSLibrary.Models.ToolGroups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Magical_Tool_Solution.Configuration
{
    public partial class ClgrConfiguration : Form, IClGr
    {
        private readonly Form callingForm;
        private List<ToolClassModel> toolClasses;
        private ToolClassModel _selectedClass;
        public ClgrConfiguration(Form caller)
        {
            callingForm = caller;
            InitializeComponent();
            LoadClassesData();
            WireUpListsAndParameters();
        }

        private void LoadClassesData() =>
            toolClasses = GlobalConfig.Connection.GetToolClassesList();

        private void WireUpListsAndParameters()
        {
            //populate classes
            classesListBox.DataSource = null;
            classesListBox.DataSource = toolClasses;
            classesListBox.DisplayMember = "DisplayName";
            //populate groups
            groupsListBox.DataSource = null;
            clgrParametersDataGridView.DataSource = null;
            WireUpParametersDataGrid();
        }
        private void WireUpListsAndParameters(int index)
        {
            //populate classes
            classesListBox.DataSource = null;
            classesListBox.DataSource = toolClasses;
            classesListBox.DisplayMember = "DisplayName";
            classesListBox.SelectedIndex = index;
            //populate groups
            groupsListBox.DataSource = null;
            clgrParametersDataGridView.DataSource = null;
            WireUpParametersDataGrid();
        }
        private void WireUpListsAndParameters(ToolClassModel model)
        {
            //populate classes
            classesListBox.DataSource = null;
            classesListBox.DataSource = toolClasses;
            classesListBox.DisplayMember = "DisplayName";

            foreach (ToolClassModel tc in classesListBox.Items)
            {
                if (tc.Id == model.Id)
                {
                    classesListBox.SelectedIndex = classesListBox.Items.IndexOf(tc);
                    break;
                }
            }
            //populate groups
            groupsListBox.DataSource = null;
            clgrParametersDataGridView.DataSource = null;
            WireUpParametersDataGrid();
        }

        private void WireUpParametersDataGrid()
        {
            if (classesListBox.SelectedItem == null)
            {
                clgrParametersDataGridView.DataSource = null;
                return;
            }
            _selectedClass = (ToolClassModel)classesListBox.SelectedItem;
            WireUpGroupsListBox();
            //load parameters datagrid
            DataTable table = ProgramLogic.CreateDataTableFromListOfModels(_selectedClass.ToolClassParameters);
            clgrParametersDataGridView.DataSource = table;
            clgrParametersDataGridView.Columns["Id"].HeaderText = "Parameter Id";
            clgrParametersDataGridView.Columns["ToolClassId"].HeaderText = "Related Tool Class";
            clgrParametersDataGridView.Columns["Name"].HeaderText = "Parameter Viewing Name";
            clgrParametersDataGridView.Columns["Description"].HeaderText = "Parameter Description";
            clgrParametersDataGridView.Columns["DataValueType"].HeaderText = "Data Type";
            clgrParametersDataGridView.Columns["AssignedGroupsIdDisplayString"].HeaderText = "Assigned Tool Groups";
            clgrParametersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            clgrParametersDataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clgrParametersDataGridView.AutoResizeColumns();
        }

        private void WireUpGroupsListBox()
        {
            if (_selectedClass == null)
            {
                groupsListBox.DataSource = null;
                return;
            }
            groupsListBox.DataSource = _selectedClass.ToolGroups;
            groupsListBox.DisplayMember = "DisplayName";
        }

        private void ClgrConfiguration_FormClosed(object sender, FormClosedEventArgs e) =>
            callingForm.Visible = true;

        private void ClassesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (classesListBox.IndexFromPoint(e.Location) == ListBox.NoMatches)
            {
                //open new class editor 
                Form form = new ClgrEntryEditor(ItemType.ToolClass, CreatingType.Creating, new ToolClassModel(), this, this);
                form.Visible = true;
            }
            else
            {
                //create model from selected item
                ToolClassModel model = (ToolClassModel)classesListBox.SelectedItem;
                //open edit class editor
                Form form = new ClgrEntryEditor(ItemType.ToolClass, CreatingType.Updating, model, this, this);
                form.Visible = true;
            }
            Enabled = false;
        }

        private void GroupsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (classesListBox.SelectedItem == null)
            {
                return;
            }
            if (groupsListBox.IndexFromPoint(e.Location) == ListBox.NoMatches)
            {
                //open new group editor
                ToolClassModel selectedClassModel = (ToolClassModel)classesListBox.SelectedItem;
                Form form = new ClgrEntryEditor(ItemType.ToolGroup, CreatingType.Creating, new ToolGroupModel { ToolClassId = selectedClassModel.Id }, this, this);
                form.Visible = true;
            }
            else
            {
                //create model for selected item
                ToolGroupModel model = (ToolGroupModel)groupsListBox.SelectedItem;
                //open edit group editor
                Form form = new ClgrEntryEditor(ItemType.ToolGroup, CreatingType.Updating, model, this, this);
                form.Visible = true;
            }
            Enabled = false;
        }
        private void PositionsDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (classesListBox.SelectedItem == null)
            {
                return;
            }
            ToolClassModel toolClass = (ToolClassModel)classesListBox.SelectedItem;
            if (clgrParametersDataGridView.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
            {
                //new parameter editor
                Form form = new ParameterEditor(CreatingType.Creating,
                                                new ToolClassParameterModel()
                                                {
                                                    Position = GlobalConfig.Connection.GetToolClassParameterNextPositionByToolClassId(toolClass.Id)
                                                },
                                                (ToolClassModel)classesListBox.SelectedItem,
                                                this,
                                                this);
                form.Visible = true;
                Enabled = false;
            }
            else if (clgrParametersDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                //create model for selected item
                ToolClassParameterModel model = GenerateClgrParameterModelFromLocation(e);
                //update parameter
                Form form = new ParameterEditor(CreatingType.Updating, model, (ToolClassModel)classesListBox.SelectedItem, this, this);
                form.Visible = true;
                Enabled = false;
            }
        }

        private ToolClassParameterModel GenerateClgrParameterModelFromLocation(MouseEventArgs e)
        {
            DataGridViewRow row = clgrParametersDataGridView.Rows[clgrParametersDataGridView.HitTest(e.X, e.Y).RowIndex];
            ToolClassParameterModel model = new();
            model.Id = row.Cells["Id"].Value.ToString();
            model.ToolClassId = _selectedClass.Id;
            model.Position = int.Parse(row.Cells["Position"].Value.ToString());
            model.Name = row.Cells["Name"].Value.ToString();
            model.Description = row.Cells["Description"].Value.ToString();
            model.DataValueType = row.Cells["DataValueType"].Value.ToString();
            string idsString = row.Cells["AssignedGroupsIdDisplayString"].Value.ToString();
            model.AssignedToolGroupIds = new List<string>();
            switch (idsString)
            {
                case "No Groups Assigned":
                    break;
                default:
                    foreach (string id in idsString.Split(", "))
                    {
                        model.AssignedToolGroupIds.ToList().Add(id);
                    }
                    break;
            }
            return model;
        }

        public void AddToolClass(ToolClassModel model)
        {
            GlobalConfig.Connection.CreateToolClass(model);
            LoadClassesData();
            WireUpListsAndParameters(model);
        }

        public void UpdateToolClass(ToolClassModel model)
        {
            GlobalConfig.Connection.UpdateToolClass(model);
            LoadClassesData();
            WireUpListsAndParameters(classesListBox.SelectedIndex);
        }

        public void AddToolGroup(ToolGroupModel model)
        {
            GlobalConfig.Connection.CreateToolGroup(model);
            LoadClassesData();
            WireUpListsAndParameters(classesListBox.SelectedIndex);
        }

        public void UpdateToolGroup(ToolGroupModel model)
        {
            GlobalConfig.Connection.UpdateToolGroup(model);
            LoadClassesData();
            WireUpListsAndParameters(classesListBox.SelectedIndex);
        }

        public void AddClGrParameter(ToolClassParameterModel model)
        {
            GlobalConfig.Connection.CreateToolClassParameter(model);
            LoadClassesData();
            WireUpListsAndParameters(classesListBox.SelectedIndex);
        }

        public void UpdateClGrParameter(ToolClassParameterModel model)
        {
            GlobalConfig.Connection.UpdateToolClassParameter(model);
            LoadClassesData();
            WireUpListsAndParameters(classesListBox.SelectedIndex);
        }

        public bool ValidateToolClassId(string id) =>
            GlobalConfig.Connection.ValidateToolClassId(id);

        public bool ValidateToolGroup(ToolGroupModel model) =>
            GlobalConfig.Connection.ValidateToolGroupIdInClass(model.Id, model.ToolClassId);

        private void ClassesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedClass = (ToolClassModel)classesListBox.SelectedItem;
            WireUpGroupsListBox();
            WireUpParametersDataGrid();
        }

        private void DeleteToolClassToolStripMenuItem_Click(object sender, EventArgs e) => DeleteSelectedToolClass();
        private void DeleteSelectedToolClass()
        {
            if (MessageBox.Show($"Are you sure you want to delete {_selectedClass.DisplayName}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                // delete related groups
                if (_selectedClass.ToolGroups.ToList().Count > 0)
                {
                    GlobalConfig.Connection.DeleteToolGroupsByToolClassId(_selectedClass.Id);
                }
                // delete parameters
                if (_selectedClass.ToolClassParameters.ToList().Count > 0)
                {
                    GlobalConfig.Connection.DeleteToolClassParametersByToolClassId(_selectedClass.Id);
                }
                // delete tool class
                GlobalConfig.Connection.DeleteToolClassById(_selectedClass.Id);
            }
            LoadClassesData();
            WireUpListsAndParameters();
        }

        private void DeleteToolGroupToolStripMenuItem_Click(object sender, EventArgs e) => DeleteSelectedToolGroup();
        private void DeleteSelectedToolGroup()
        {
            ToolGroupModel model = (ToolGroupModel)groupsListBox.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete {model.DisplayName}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                // delete tool group
                GlobalConfig.Connection.DeleteToolGroupByIdToolClassId(model.Id, model.ToolClassId);
            }
            LoadClassesData();
            WireUpListsAndParameters();
        }

        private void WireUpContextMenus()
        {
            deleteToolClassToolStripMenuItem.Enabled = false;
            deleteToolGroupToolStripMenuItem.Enabled = false;
            if (_selectedClass != null)
            {
                deleteToolClassToolStripMenuItem.Enabled = true;
            }
            if (groupsListBox.SelectedItem != null)
            {
                deleteToolGroupToolStripMenuItem.Enabled = true;
            }
        }
        private void WireUpDataGridContextMenu()
        {
            deleteParameterToolStripMenuItem.Enabled = false;
            if (clgrParametersDataGridView.SelectedCells.Count > 0)
            {
                deleteParameterToolStripMenuItem.Enabled = true;
            }
        }

        private void ClassesListBox_MouseDown(object sender, MouseEventArgs e) => UserInterfaceLogic.HandleRightClick(classesListBox, e, WireUpContextMenus);

        private void GroupsListBox_MouseDown(object sender, MouseEventArgs e) => UserInterfaceLogic.HandleRightClick(groupsListBox, e, WireUpContextMenus);

        private void ClgrConfiguration_Resize(object sender, EventArgs e)
        {
            //int listBoxWidth = (int)Math.Round((decimal)topPanel.Width / 2);
            //topLeftPanel.Width = listBoxWidth;
            //topRightPanel.Width = listBoxWidth;
            UserInterfaceLogic.ResizePanelsEvenly(this, topPanel, topLeftPanel, topRightPanel);
        }

        private void DeleteParameterToolStripMenuItem_Click(object sender, EventArgs e) => DeleteSelectedToolClassParameter();
        private void DeleteSelectedToolClassParameter()
        {
            if (MessageBox.Show("Deleting the parameter will delete related values in tools and comps and remove all group allocation!\nContinue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                string parameterId = clgrParametersDataGridView.Rows[clgrParametersDataGridView.SelectedCells[0].RowIndex].Cells["Id"].Value.ToString();
                GlobalConfig.Connection.DeleteToolClassParameterByParameterIdToolClassId(parameterId, _selectedClass.Id);
                int index = classesListBox.SelectedIndex;
                LoadClassesData();
                WireUpListsAndParameters(index);
            }
        }

        private void ClgrParametersDataGridView_MouseClick(object sender, MouseEventArgs e) => UserInterfaceLogic.HandleRightClick(clgrParametersDataGridView, e, WireUpDataGridContextMenu);

        private void ClgrParametersDataGridView_MouseDown(object sender, MouseEventArgs e) => UserInterfaceLogic.HandleRightClick(clgrParametersDataGridView, e, WireUpDataGridContextMenu);
    }
}
