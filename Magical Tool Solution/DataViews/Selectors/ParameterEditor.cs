using Magical_Tool_Solution.Interfaces;
using MTSLibrary;
using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magical_Tool_Solution.DataViews.Selectors
{
    public partial class ParameterEditor : Form
    {
        private readonly CreatingType _creatingType;
        private ClgrParameterModel _model;
        private readonly ToolClassModel _activeClass;
        private readonly Form _callingForm;
        private readonly IClGr _clGr;

        public ParameterEditor(CreatingType creatingType, ClgrParameterModel model, ToolClassModel activeClass, Form caller, IClGr clGr)
        {
            _creatingType = creatingType;
            _model = model;
            _activeClass = activeClass;
            _callingForm = caller;
            _clGr = clGr;
            InitializeComponent();
            AdjustUI();
            LoadDataToUI();
        }

        private void LoadDataToUI()
        {
            positionBox.Text = _model.Position.ToString();
            idTextBox.Text = _model.ParameterId;
            viewingNameTextBox.Text = _model.Name;
            descTextBox.Text = _model.Description;
            valueTypesComboBox.SelectedItem = _model.ValueType;
            classIdTextBox.Text = _activeClass.Id;
            classD1TextBox.Text = _activeClass.Name;
            enabledGroupsDataGridView.DataSource = null;
            enabledGroupsDataGridView.DataSource = GenerateEnabledGroupsData();
        }

        private DataTable GenerateEnabledGroupsData()
        {
            //hardcoded table design
            DataTable table = new("enableToolGroups");
            table.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("enabled", typeof(bool)),
                new DataColumn("groupId", typeof(string)),
                new DataColumn("groupName", typeof(string))
            });
            //generate table rows for active class
            foreach (ToolGroupModel tc in _activeClass.ToolGroups)
            {
                object[] values = new object[]
                {
                    false,
                    tc.Id,
                    tc.Name
                };
                table.Rows.Add(values);
            }
            //mark enabled groups
            List<string> enabledGroupsIds = GlobalConfig.Connection.GetEnabledGroupsIdsByClassIdAndParameterId(_activeClass.Id, _model.ParameterId);
            foreach (DataRow row in table.Rows)
            {
                if (enabledGroupsIds.Any(i => i == row.ItemArray[1].ToString()))
                {
                    row.ItemArray[0] = true;
                }
            }
            return table;
        }

        private void AdjustUI()
        {
            if (_creatingType == CreatingType.creating)
            {
                selectorLabel.Text = "Create Parameter:";
            }
            else if (_creatingType == CreatingType.updating)
            {
                selectorLabel.Text = "Edit Parameter:";
                positionBox.Enabled = false;
                idTextBox.Enabled = false;
            }
            valueTypesComboBox.DataSource = null;
            valueTypesComboBox.DataSource = GlobalConfig.Connection.GetValueTypes();
        }

        private void ParameterEditor_FormClosed(object sender, FormClosedEventArgs e) => _callingForm.Enabled = true;

        private void OkButton_Click(object sender, EventArgs e)
        {
            _model = CreateModelFromUI();
            if (_creatingType == CreatingType.creating)
            {
                //validate position
                if (_activeClass.ClgrParameters.Any(p => p.Position == _model.Position))
                {
                    MessageBox.Show("Position already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //validate Id
                if (_activeClass.ClgrParameters.Any(p => p.ParameterId == _model.ParameterId))
                {
                    MessageBox.Show("Parameter ID already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _clGr.AddClGrParameter(_model);
            }
            else if (_creatingType == CreatingType.updating)
            {
                _clGr.UpdateClGrParameter(_model);
            }
        }

        private ClgrParameterModel CreateModelFromUI()
        {
            ClgrParameterModel model = new()
            {
                Position = int.Parse(positionBox.Text),
                ParameterId = idTextBox.Text,
                Name = viewingNameTextBox.Text,
                Description = descTextBox.Text,
                ValueType = valueTypesComboBox.SelectedValue.ToString()
            };
            List<string> selectedGroupsIds = new();
            foreach (DataGridViewRow row in enabledGroupsDataGridView.Rows)
            {
                if (bool.Parse(row.Cells["enabled"].Value.ToString()))
                {
                    selectedGroupsIds.Add(row.Cells["groupId"].Value.ToString());
                }
            }
            model.AssignedGroupsIds = selectedGroupsIds;
            return model;
        }
    }
}
