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
            if (classesListBox.SelectedItem != null)
            {
                _selectedClass = (ToolClassModel)classesListBox.SelectedItem;
                WireUpGroupsListBox();
                //load parameters datagrid
                DataTable table = ProgramLogic.CreateDataTableFromListOfModels(_selectedClass.ToolClassParameters);
                clgrParametersDataGridView.DataSource = table;
            }
        }

        private void WireUpGroupsListBox()
        {
            if (_selectedClass != null)
            {
                groupsListBox.DataSource = _selectedClass.ToolGroups;
                groupsListBox.DisplayMember = "DisplayName"; 
            }
        }

        private void ClgrConfiguration_FormClosed(object sender, FormClosedEventArgs e) =>
            callingForm.Visible = true;

        private void ClassesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (classesListBox.IndexFromPoint(e.Location) == ListBox.NoMatches)
            {
                //open new class editor 
                Form form = new ClgrEntryEditor(ItemType.toolClass, CreatingType.creating, new ToolClassModel(), this, this);
                form.Visible = true;
            }
            else
            {
                //create model from selected item
                ToolClassModel model = (ToolClassModel)classesListBox.SelectedItem;
                //open edit class editor
                Form form = new ClgrEntryEditor(ItemType.toolClass, CreatingType.updating, model, this, this);
                form.Visible = true;
            }
            Enabled = false;
        }

        private void GroupsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (groupsListBox.IndexFromPoint(e.Location) == ListBox.NoMatches)
            {
                //open new group editor
                ToolClassModel selectedClassModel = (ToolClassModel)classesListBox.SelectedItem;
                Form form = new ClgrEntryEditor(ItemType.toolGroup, CreatingType.creating, new ToolGroupModel { ToolClassId = selectedClassModel.Id}, this, this);
                form.Visible = true;
            }
            else
            {
                //create model for selected item
                ToolGroupModel model = (ToolGroupModel)groupsListBox.SelectedItem;
                //open edit group editor
                Form form = new ClgrEntryEditor(ItemType.toolGroup, CreatingType.updating, model, this, this);
                form.Visible = true;
            }
            Enabled = false;
        }
        private void PositionsDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (clgrParametersDataGridView.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
            {
                //new parameter editor
                Form form = new ParameterEditor(CreatingType.creating, new ToolClassParameterModel(), (ToolClassModel)classesListBox.SelectedItem, this, this);
                form.Visible = true;
            }
            else if (clgrParametersDataGridView.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.Cell)
            {
                //create model for selected item
                ToolClassParameterModel model = GenerateClgrParameterModelFromLocation(e);
                //update parameter
                Form form = new ParameterEditor(CreatingType.updating, model, (ToolClassModel)classesListBox.SelectedItem, this, this);
                form.Visible = true;
            }
        }

        private ToolClassParameterModel GenerateClgrParameterModelFromLocation(MouseEventArgs e)
        {
            DataGridViewRow row = clgrParametersDataGridView.Rows[clgrParametersDataGridView.HitTest(e.X, e.Y).RowIndex];
            ToolClassParameterModel model = new();
            model.Id = row.Cells["parameterId"].Value.ToString();
            model.ToolClassId = _selectedClass.Id;
            model.Position = int.Parse(row.Cells["position"].Value.ToString());
            model.Name = row.Cells["parameterDisplayName"].Value.ToString();
            model.Description = row.Cells["parameterDescription"].Value.ToString();
            model.DataValueType = row.Cells["parameterValueType"].Value.ToString();
            // TODO - fix this shit logic
            model.AssignedGroupsIds = (List<string>)row.Cells["groupsUsage"].Value;
            return model;
        }

        public void AddToolClass(ToolClassModel model)
        {
            GlobalConfig.Connection.CreateToolClass(model);
            LoadClassesData();
            WireUpListsAndParameters();
        }

        public void UpdateToolClass(ToolClassModel model)
        {
            GlobalConfig.Connection.UpdateToolClass(model);
            LoadClassesData();
            WireUpListsAndParameters();
        }

        public void AddToolGroup(ToolGroupModel model)
        {
            GlobalConfig.Connection.CreateToolGroup(model);
            LoadClassesData();
            WireUpListsAndParameters();
        }

        public void UpdateToolGroup(ToolGroupModel model)
        {
            GlobalConfig.Connection.UpdateToolGroup(model);
            LoadClassesData();
            WireUpListsAndParameters();
        }

        public void AddClGrParameter(ToolClassParameterModel model)
        {
            GlobalConfig.Connection.CreateClGrParameter(model);
            LoadClassesData();
            WireUpListsAndParameters();
        }

        public void UpdateClGrParameter(ToolClassParameterModel model)
        {
            GlobalConfig.Connection.UpdateToolClassParameter(model);
            LoadClassesData();
            WireUpListsAndParameters();
        }

        public bool ValidateToolClassId(string id) =>
            GlobalConfig.Connection.ValidateToolClassId(id);

        public bool ValidateToolGroup(ToolGroupModel model) =>
            GlobalConfig.Connection.ValidateToolGroupIdInClass(model.Id, model.ToolClassId);

        private void ClassesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedClass = (ToolClassModel)classesListBox.SelectedItem;
            WireUpGroupsListBox();
        }
    }
}
