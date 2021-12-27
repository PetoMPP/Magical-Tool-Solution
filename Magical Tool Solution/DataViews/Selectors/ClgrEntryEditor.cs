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

namespace Magical_Tool_Solution.DataViews.Selectors
{
    public partial class ClgrEntryEditor : Form
    {
        private readonly ItemType _itemType;
        private readonly CreatingType _creatingType;
        private readonly Form callingForm;
        private readonly IClGr _clGr;
        private readonly IMainClass _mainClass;
        private readonly ToolClassModel _toolClassModel;
        private readonly ToolGroupModel _toolGroupModel;
        private readonly MainClassModel _mainClassModel;

        public ClgrEntryEditor(ItemType itemType, CreatingType creatingType, object model, Form caller, IClGr clGr)
        {
            _itemType = itemType;
            _creatingType = creatingType;
            callingForm = caller;
            _clGr = clGr;
            if (model.GetType() == typeof(ToolClassModel))
            {
                _toolClassModel = (ToolClassModel)model;
            }
            else if (model.GetType() == typeof(ToolGroupModel))
            {
                _toolGroupModel = (ToolGroupModel)model;
            }
            InitializeComponent();
            AdjustUI();
            LoadModelToUI();
        }
        public ClgrEntryEditor(ItemType itemType, CreatingType creatingType, MainClassModel model, Form caller, IMainClass mainClass)
        {
            _itemType = itemType;
            _creatingType = creatingType;
            callingForm = caller;
            _mainClass = mainClass;
            _mainClassModel = model;
            InitializeComponent();
            AdjustUI();
            LoadModelToUI();
        }

        private void LoadModelToUI()
        {
            if (_itemType == ItemType.toolClass)
            {
                idTextBox.Text = _toolClassModel.Id;
                d1TextBox.Text = _toolClassModel.Name;
                mainIdTextBox.Text = _toolClassModel.MainClassId;
                mainD1TextBox.Text = GlobalConfig.Connection.GetMainClassNameById(_toolClassModel.MainClassId);
            }
            else if (_itemType == ItemType.toolGroup)
            {
                idTextBox.Text = _toolGroupModel.Id;
                d1TextBox.Text = _toolGroupModel.Name;
                mainIdTextBox.Text = _toolGroupModel.ToolClassId;
                mainD1TextBox.Text = GlobalConfig.Connection.GetClassNameById(_toolGroupModel.ToolClassId);
                if (_toolGroupModel.SuitabilityEnabled)
                {
                    enableSuitabilityRadioButton.Checked = true;
                }
                else
                {
                    disableSuitabilityRadioButton.Checked = true;
                }
                if (_toolGroupModel.MachineInterfaceEnabled)
                {
                    enableMachineHolderInterfaceRadioButton.Checked = true;
                }
                else
                {
                    disableMachineHolderInterfaceRadioButton.Checked = true;
                }
                if (_toolGroupModel.InsertsEnabled)
                {
                    enableInsertsRadioButton.Checked = true;
                }
                else
                {
                    disableInsertsRadioButton.Checked = true;
                }
                if (_toolGroupModel.HoldingOtherComponentsEnabled)
                {
                    enableHoldingComponentsRadioButton.Checked = true;
                }
                else
                {
                    disableHoldingComponentsRadioButton.Checked = true;
                }
                if (_toolGroupModel.EnabledInComps)
                {
                    enableComponentsCheckBox.Checked = true;
                }
                else
                {
                    enableComponentsCheckBox.Checked = false;
                }
                if (_toolGroupModel.EnabledInTools)
                {
                    enableToolsCheckBox.Checked = true;
                }
                else
                {
                    enableToolsCheckBox.Checked = false;
                }
            }
            else if (_itemType == ItemType.mainClass)
            {
                idTextBox.Text = _mainClassModel.Id;
                d1TextBox.Text = _mainClassModel.Name;
            }
        }

        private void AdjustUI()
        {
            if (_itemType == ItemType.toolClass)
            {
                mainClassLabel.Text = "Main Class Id and Description";
                mainClassIdD1Panel.Enabled = false;

                basicDataLabel.Text = "Basic Class Data:";
                idD1Label.Text = "Class Id and Description";

                suitabilityEnabledLabel.Visible = false;
                suitabilityRadioSwitchPanel.Visible = false;

                machineHolderInterfaceLabel.Visible = false;
                machineHolderInterfaceRadioSwitchPanel.Visible = false;

                insertsLabel.Visible = false;
                insertsRadioSwitchPanel.Visible = false;

                holdingComponentsLabel.Visible = false;
                holdingComponentsRadioSwitchPanel.Visible = false;

                classModeLabel.Visible = false;
                classModeCheckBoxPanel.Visible = false;

                if (_creatingType == CreatingType.creating)
                {
                    selectorLabel.Text = "Add a new Class";
                }
                else if (_creatingType == CreatingType.updating)
                {
                    selectorLabel.Text = "Modify selected Class";
                    idTextBox.Enabled = false;
                    browseButton.Enabled = false;
                }
            }
            else if (_itemType == ItemType.toolGroup)
            {
                mainClassLabel.Text = "Parent Class Id and Description";
                mainClassIdD1Panel.Enabled = false;

                basicDataLabel.Text = "Basic Group Data:";
                idD1Label.Text = "Group Id and Description";
                if (_creatingType == CreatingType.creating)
                {
                    selectorLabel.Text = "Add a new Group";
                }
                else if (_creatingType == CreatingType.updating)
                {
                    selectorLabel.Text = "Modify selected Group";
                    idTextBox.Enabled = false;
                    browseButton.Enabled = false;
                }
            }
            else if (_itemType == ItemType.mainClass)
            {
                basicDataLabel.Text = "Basic Main Class Data:";
                idD1Label.Text = "Main Class Id and Description";

                mainClassPanel.Visible = false;

                suitabilityEnabledLabel.Visible = false;
                suitabilityRadioSwitchPanel.Visible = false;

                machineHolderInterfaceLabel.Visible = false;
                machineHolderInterfaceRadioSwitchPanel.Visible = false;

                insertsLabel.Visible = false;
                insertsRadioSwitchPanel.Visible = false;

                holdingComponentsLabel.Visible = false;
                holdingComponentsRadioSwitchPanel.Visible = false;

                classModeLabel.Visible = false;
                classModeCheckBoxPanel.Visible = false;
                if (_creatingType == CreatingType.creating)
                {
                    selectorLabel.Text = "Add a new Main Class";
                }
                else if (_creatingType == CreatingType.updating)
                {
                    selectorLabel.Text = "Modify selected Main Class";
                    idTextBox.Enabled = false;
                    browseButton.Enabled = false;
                }
            }
        }

        private void ClgrEntryEditor_FormClosed(object sender, FormClosedEventArgs e) => callingForm.Enabled = true;

        private void CancelButton_Click(object sender, EventArgs e) => Close();

        private void OkButton_Click(object sender, EventArgs e)
        {
            CreateAndSendModel();
            Close();
        }

        private void CreateAndSendModel()
        {
            //Determine which model
            if (_itemType == ItemType.toolClass)
            {
                //create model
                ToolClassModel model = new()
                {
                    Id = idTextBox.Text,
                    Name = d1TextBox.Text,
                    MainClassId = mainIdTextBox.Text
                };
                //updating doesnt affect allocated groups
                //send to interface
                if (_creatingType == CreatingType.creating)
                {
                    //validate if id is taken for all classes
                    if (_clGr.ValidateToolClassId(model.Id))
                    {
                        MessageBox.Show("Tool Class Id is already used by another class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _clGr.AddToolClass(model);
                }
                else if (_creatingType == CreatingType.updating)
                {
                    _clGr.UpdateToolClass(model);
                }
            }
            else if (_itemType == ItemType.toolGroup)
            {
                //validate if is enabled to anything
                if (!enableComponentsCheckBox.Checked && !enableToolsCheckBox.Checked)
                {
                    MessageBox.Show("Tool Group has to be enabled for at least one item type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //create model
                ToolGroupModel model = new()
                {
                    Id = idTextBox.Text,
                    Name = d1TextBox.Text,
                    ToolClassId = mainIdTextBox.Text
                };
                if (enableSuitabilityRadioButton.Checked)
                {
                    model.SuitabilityEnabled = true;
                }
                else
                {
                    model.SuitabilityEnabled = false;
                }
                if (enableMachineHolderInterfaceRadioButton.Checked)
                {
                    model.MachineInterfaceEnabled = true;
                }
                else
                {
                    model.MachineInterfaceEnabled = false;
                }
                if (enableInsertsRadioButton.Checked)
                {
                    model.InsertsEnabled = true;
                }
                else
                {
                    model.InsertsEnabled = false;
                }
                if (enableHoldingComponentsRadioButton.Checked)
                {
                    model.HoldingOtherComponentsEnabled = true;
                }
                else
                {
                    model.HoldingOtherComponentsEnabled = false;
                }
                if (enableComponentsCheckBox.Checked)
                {
                    model.EnabledInComps = true;
                }
                else
                {
                    model.EnabledInComps = false;
                }
                if (enableToolsCheckBox.Checked)
                {
                    model.EnabledInTools = true;
                }
                else
                {
                    model.EnabledInTools = false;
                }
                //send to interface
                if (_creatingType == CreatingType.creating)
                {
                    //validate if id is taken for groups in class
                    if (_clGr.ValidateToolGroup(model))
                    {
                        MessageBox.Show("Tool Group Id is already used by another group in this class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _clGr.AddToolGroup(model);
                }
                else if (_creatingType == CreatingType.updating)
                {
                    _clGr.UpdateToolGroup(model);
                }
            }
            else if (_itemType == ItemType.mainClass)
            {
                MainClassModel model = new()
                {
                    Id = idTextBox.Text,
                    Name = d1TextBox.Text
                };
                if (_creatingType == CreatingType.creating)
                {
                    //validate if id is taken
                    if (_mainClass.ValidateMainClassId(model.Id))
                    {
                        MessageBox.Show("Main Class Id is already used by another class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _mainClass.AddMainClass(model);
                }
                else if (_creatingType == CreatingType.updating)
                {
                    _mainClass.UpdateMainClass(model);
                }
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        => CreateAndSendModel();
    }
}
