using Magical_Tool_Solution.Interfaces;
using MTSLibrary;
using MTSLibrary.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Magical_Tool_Solution.DataViews.Selectors
{
    public partial class ClgrEntryEditor : Form, ISelectToolClass, ISelectToolGroup, ISelectMainClass
    {
        private readonly ItemType _itemType;
        private readonly CreatingType _creatingType;
        private readonly Form callingForm;
        private readonly IClGr _clGr;
        private readonly IMainClass _mainClass;
        private ToolClassModel _toolClassModel;
        private ToolGroupModel _toolGroupModel;
        private MainClassModel _mainClassModel;

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
                mainD1TextBox.Text = null;
                if (_toolClassModel.MainClassId != null)
                {
                    mainD1TextBox.Text = GlobalConfig.Connection.GetMainClassNameById(_toolClassModel.MainClassId); 
                }
            }
            else if (_itemType == ItemType.toolGroup)
            {
                idTextBox.Text = _toolGroupModel.Id;
                d1TextBox.Text = _toolGroupModel.Name;
                mainIdTextBox.Text = _toolGroupModel.ToolClassId;
                if (_toolGroupModel.ToolClassId != null)
                {
                    mainD1TextBox.Text = GlobalConfig.Connection.GetClassNameById(_toolGroupModel.ToolClassId);
                }
                else
                {
                    mainD1TextBox.Text = null;
                }
                enableSuitabilityRadioButton.Checked = _toolGroupModel.SuitabilityEnabled;
                disableSuitabilityRadioButton.Checked = !_toolGroupModel.SuitabilityEnabled;

                enableMachineHolderInterfaceRadioButton.Checked = _toolGroupModel.MachineInterfaceEnabled;
                disableMachineHolderInterfaceRadioButton.Checked = !_toolGroupModel.MachineInterfaceEnabled;

                enableInsertsRadioButton.Checked = _toolGroupModel.InsertsEnabled;
                disableInsertsRadioButton.Checked = !_toolGroupModel.InsertsEnabled;

                enableHoldingComponentsRadioButton.Checked = _toolGroupModel.HoldingOtherComponentsEnabled;
                disableHoldingComponentsRadioButton.Checked = !_toolGroupModel.HoldingOtherComponentsEnabled;

                enableComponentsCheckBox.Checked = _toolGroupModel.EnabledInComps;

                enableToolsCheckBox.Checked = _toolGroupModel.EnabledInTools;
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
                    applyButton.Enabled = false;
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
                    applyButton.Enabled = false;
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
                    applyButton.Enabled = false;
                }
            }
        }

        private void ClgrEntryEditor_FormClosed(object sender, FormClosedEventArgs e) => callingForm.Enabled = true;

        private void CancelButton_Click(object sender, EventArgs e) => Close();

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (CreateAndSendModel())
            {
                Close();
            }
        }

        private bool CreateAndSendModel()
        {
            if (string.IsNullOrWhiteSpace(idTextBox.Text))
            {
                MessageBox.Show("Id cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //Determine which model
            switch (_itemType)
            {
                case ItemType.toolClass:
                    //create model
                    ToolClassModel tc = new()
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
                        if (_clGr.ValidateToolClassId(tc.Id))
                        {
                            MessageBox.Show("Tool Class Id is already used by another class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        _clGr.AddToolClass(tc);
                    }
                    else if (_creatingType == CreatingType.updating)
                    {
                        _clGr.UpdateToolClass(tc);
                    }
                    break;
                case ItemType.toolGroup:
                    //validate if is enabled to anything
                    if (!enableComponentsCheckBox.Checked && !enableToolsCheckBox.Checked)
                    {
                        MessageBox.Show("Tool Group has to be enabled for at least one item type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    //create model
                    ToolGroupModel tg = new()
                    {
                        Id = idTextBox.Text,
                        Name = d1TextBox.Text,
                        ToolClassId = mainIdTextBox.Text,
                        SuitabilityEnabled = enableSuitabilityRadioButton.Checked,
                        MachineInterfaceEnabled = enableMachineHolderInterfaceRadioButton.Checked,
                        InsertsEnabled = enableInsertsRadioButton.Checked,
                        HoldingOtherComponentsEnabled = enableHoldingComponentsRadioButton.Checked,
                        EnabledInComps = enableComponentsCheckBox.Checked,
                        EnabledInTools = enableToolsCheckBox.Checked
                    };
                    //send to interface
                    if (_creatingType == CreatingType.creating)
                    {
                        //validate if id is taken for groups in class
                        if (_clGr.ValidateToolGroup(tg))
                        {
                            MessageBox.Show("Tool Group Id is already used by another group in this class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        _clGr.AddToolGroup(tg);
                    }
                    else if (_creatingType == CreatingType.updating)
                    {
                        _clGr.UpdateToolGroup(tg);
                    }
                    break;
                case ItemType.mainClass:
                    MainClassModel mc = new()
                    {
                        Id = idTextBox.Text,
                        Name = d1TextBox.Text
                    };
                    if (_creatingType == CreatingType.creating)
                    {
                        //validate if id is taken
                        if (_mainClass.ValidateMainClassId(mc.Id))
                        {
                            MessageBox.Show("Main Class Id is already used by another class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        _mainClass.AddMainClass(mc);
                    }
                    else if (_creatingType == CreatingType.updating)
                    {
                        _mainClass.UpdateMainClass(mc);
                    }
                    break;
            };
            return true;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (CreateAndSendModel())
            {
                ClearFields(); 
            }
        }

        private void ClearFields()
        {
            List<Control> visibleTextboxes = UserInterfaceLogic.GetAllControls(this, typeof(TextBox))
                .Where(t => t.Visible == true && t.Enabled == true).ToList();
            foreach (Control t in visibleTextboxes)
            {
                t.Text = string.Empty;
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            string[] columnNames = UserInterfaceLogic.GetColumnsFromMode(_itemType);
            Form form = new BasicLookup((ISelectToolGroup)this, this, columnNames, 0, _itemType);
            form.Visible = true;
            Enabled = false;
        }

        public void LoadSelectedToolClass(string id)
        {
            _toolClassModel = GlobalConfig.Connection.GetToolClassById(id);
            LoadModelToUI();
        }
        public void LoadSelectedToolGroup(string id, string toolClassId)
        {
            _toolGroupModel = GlobalConfig.Connection.GetToolGroupByIdToolClassId(id, toolClassId);
            LoadModelToUI();
        }

        public void LoadSelectedBasicToolClass(BasicToolClassModel model)
        {
            _toolClassModel = (ToolClassModel)model;
            LoadModelToUI();
        }

        public void LoadSelectedBasicToolGroup(BasicToolGroupModel model)
        {
            // it has to perserve tool class from before calling lookup
            ToolGroupModel toolGroup = (ToolGroupModel)model;
            toolGroup.ToolClassId = _toolGroupModel.ToolClassId;
            _toolGroupModel = toolGroup;
            LoadModelToUI();
        }

        public void LoadSelectedBasicMainClass(BasicMainClassModel model)
        {
            _mainClassModel = (MainClassModel)model;
            LoadModelToUI();
        }
    }
}
