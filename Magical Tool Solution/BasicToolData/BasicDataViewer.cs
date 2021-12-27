using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Magical_Tool_Solution.DataViews.Headers;
using Magical_Tool_Solution.DataViews.Selectors;
using Magical_Tool_Solution.Interfaces;
using Minimal_Tool_Stock_Calculator.BasicDataSidebars;
using Minimal_Tool_Stock_Calculator.DataViews;
using Minimal_Tool_Stock_Calculator.DataViews.Headers;
using MTSLibrary;
using MTSLibrary.Models;

namespace Magical_Tool_Solution.BasicToolData
{
    public partial class BasicDataViewer : Form, ISelectItem, ISelectClGr
    {
        private readonly Form caller;
        private Form headerForm;
        private Form sideForm;
        private readonly ItemType _itemType;

        //External Controls
        //View Form
        private DataGridView _componentsDataGridView;
        private DataGridView _parametersDataGridView;
        private DataGridView _positionsDataGridView;
        //Side Form both
        private TextBox _statusBox;
        //Side Form item
        private Label _pMaterialLabel;
        private Label _mMaterialLabel;
        private Label _kMaterialLabel;
        private Label _nMaterialLabel;
        private Label _sMaterialLabel;
        private Label _hMaterialLabel;
        private TextBox _toolClassIdBox;
        private TextBox _toolClassD1Box;
        private TextBox _toolGroupIdBox;
        private TextBox _toolGroupD1Box;
        private TextBox _modeSpecificBox;
        //Side Form list
        private TextBox _materialBox;
        private TextBox _machineBox;
        private TextBox _machineGroupBox;
        private TextBox _createdByBox;
        private TextBox _modifiedByBox;
        private TextBox _responsibleBox;

        public BasicDataViewer(Form callingForm, ItemType itemType)
        {
            _itemType = itemType;
            caller = callingForm;
            InitializeComponent();
            AdjustUI();
            WireUpToolTips();
            WireUpControls();
            //Why?
            idTextBox.Text = null;
        }


        #region UI assembling
        private void AdjustUI()
        {
            if (_itemType == ItemType.comp)
            {
                moduleNameLabel.Text = "Component Viewer";
                searchTextLabel.Text = "Select or search component";
                idLabel.Text = "Component Id";
                d1Label.Text = "Component Description";
                d2Label.Text = "Component Manufacturer's Id";
                searchLabel.Text = "Search for components";
            }
            else if (_itemType == ItemType.tool)
            {
                moduleNameLabel.Text = "Tool Viewer";
                searchTextLabel.Text = "Select or search tool";
                idLabel.Text = "Tool Id";
                d1Label.Text = "Tool Description";
                d2Label.Text = "Lead Component Manufacturer's Id";
                searchLabel.Text = "Search for tools";
            }
            else if (_itemType == ItemType.list)
            {
                moduleNameLabel.Text = "Tool List Viewer";
                searchTextLabel.Text = "Select or search tool list";
                idLabel.Text = "Tool List Id";
                d1Label.Text = "Tool List Description";
                d2Label.Text = "Part Number";
                searchLabel.Text = "Search for lists";
            }
            CreateSidePanel();
            CreateViewPanel();
        }

        private void CreateViewPanel()
        {
            if (headerForm != null)
            {
                headerForm.Close();
            }

            if (_itemType == ItemType.comp)
            {
                headerForm = new ComponentHeader(selectedViewPanel);
            }
            else if (_itemType == ItemType.tool)
            {
                headerForm = new ToolHeader(selectedViewPanel, this);
            }
            else if (_itemType == ItemType.list)
            {
                headerForm = new ListHeader(selectedViewPanel, this);
            }
            else
            {
                return;
            }
            headerForm.TopLevel = false;
            viewSwitcherPanel.Controls.Add(headerForm);
            headerForm.BringToFront();
            headerForm.Show();
        }

        private void CreateSidePanel()
        {
            if (sideForm != null)
            {
                sideForm.Close();
            }
            if (_itemType == ItemType.comp || _itemType == ItemType.tool)
            {
                sideForm = new ItemSidebar(_itemType, new SuitabilityModel(), this, this);
            }
            else if (_itemType == ItemType.list)
            {
                sideForm = new ListSidebar();
            }
            else
            {
                return;
            }
            sideForm.TopLevel = false;
            sidePanel.Controls.Add(sideForm);
            sideForm.BringToFront();
            sideForm.Show();
        }
        #endregion
        #region Events
        private void CompIdTextBox_TextChanged(object sender, EventArgs e)
        => WireUpToolTips();

        private void CompD1TextBox_TextChanged(object sender, EventArgs e)
        => WireUpToolTips();

        private void CompD2TextBox_TextChanged(object sender, EventArgs e)
        => WireUpToolTips();

        private void CompDataViewer_FormClosed(object sender, FormClosedEventArgs e)
        => caller.Visible = true;

        private void SearchByIdbutton_Click(object sender, EventArgs e)
        {
            string[] columnNames = GetColumnsFromMode();
            Form form = new BasicItemLookup(this, this, columnNames, 0);
            form.Visible = true;
            Enabled = false;
        }


        private void SearchByD1Button_Click(object sender, EventArgs e)
        {
            string[] columnNames = GetColumnsFromMode();
            Form form = new BasicItemLookup(this, this, columnNames, 1);
            form.Visible = true;
            Enabled = false;
        }

        private void SearchByD2Button_Click(object sender, EventArgs e)
        {
            string[] columnNames = GetColumnsFromMode();
            Form form = new BasicItemLookup(this, this, columnNames, 2);
            form.Visible = true;
            Enabled = false;
        }

        private void ClearFormButton_Click(object sender, EventArgs e)
        {
            IEnumerable<Control> textBoxes = GetAllControls(this, typeof(TextBox));
            foreach (Control textBox in textBoxes)
            {
                textBox.Text = "";
            }
            CreateSidePanel();
            CreateViewPanel();
        }
        private void SaveFormButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will save all changes done in the entry. Confirm?",
                "Save entry",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation)
                == DialogResult.OK)
            {
                SaveFormData();
            }
        }


        private void CreateFormButton_Click(object sender, EventArgs e)
        {
            // mode
            CreatingType creatingType = CreatingType.creating;
            if (_itemType == ItemType.comp)
            {
                CompModel comp = CreateCompModelFromFormData();
                string errorMessage = ProgramLogic.ValidateCompModel(comp, creatingType);
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GlobalConfig.Connection.CreateComp(comp);
                // Reload Form
                LoadSelectedItem(comp.Id);
            }
            else if (_itemType == ItemType.tool)
            {
                ToolModel tool = CreateToolModelFromFormData();
                string errorMessage = ProgramLogic.ValidateToolModel(tool, creatingType);
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GlobalConfig.Connection.CreateTool(tool);
                // Reload Form
                LoadSelectedItem(tool.Id);
            }
            else if (_itemType == ItemType.list)
            {
                ListModel list = CreateListModelFromFormData();
                string errorMessage = ProgramLogic.ValidateListModel(list, creatingType);
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GlobalConfig.Connection.CreateList(list);
                // Reload Form
                LoadSelectedItem(list.Id);
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox
                .Show(
                "This will erase all data related to this in the database. Confirm?",
                "Delete entry",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation)
                == DialogResult.OK)
            {
                DeleteEntryById(idTextBox.Text);
            }
        }
        private void IdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        => LoadDataToUI();
        private void IdTextBox_DoubleClick(object sender, EventArgs e)
        => LoadDataToUI();
        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Action will save any changes made after loading the entry.\nContinue?", "Warining", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                //Save to db
                if (SaveFormData())
                {
                    // TODO - Open copy form 
                }
            }
        }




        #endregion
        #region Utility methods
        private string[] GetColumnsFromMode()
        {
            string[] output = Array.Empty<string>();
            if (_itemType == ItemType.comp)
            {
                output = new string[] { "Component Id", "Component Description", "Comp. Manufacturer's Id" };
            }
            else if (_itemType == ItemType.tool)
            {
                output = new string[] { "Tool Id", "Tool Description", "Lead Comp. Manufacturer's Id" };
            }
            else if (_itemType == ItemType.list)
            {
                output = new string[] { "Tool List Id", "Tool List Description", "Part Number" };
            }
            return output;
        }
        private void WireUpToolTips()
        {
            compIdToolTip.SetToolTip(idTextBox, idTextBox.Text);
            compD1ToolTip.SetToolTip(d1TextBox, d1TextBox.Text);
            compD2ToolTip.SetToolTip(d2TextBox, d2TextBox.Text);
        }
        private IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.SelectMany(x => GetAllControls(x, type)).Concat(controls).Where(y => y.GetType() == type);
        }
        private IEnumerable<Control> GetAllControls(Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();
            return controls.SelectMany(x => GetAllControls(x)).Concat(controls);
        }
        private void DeleteEntryById(string id)
        {
            if (id == "")
            {
                MessageBox.Show("Id field cannot be empty!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (_itemType == ItemType.comp)
            {
                GlobalConfig.Connection.DeleteCompById(id);
            }
            else if (_itemType == ItemType.tool)
            {
                GlobalConfig.Connection.DeleteToolById(id);
            }
            else if (_itemType == ItemType.list)
            {
                GlobalConfig.Connection.DeleteListById(id);
            }

        }
        private bool SaveFormData()
        {
            CreatingType creatingType = CreatingType.updating;
            // Determine working mode (which model has to be created)
            if (_itemType == ItemType.comp)
            {
                // Gather form data
                // Create Model From data
                CompModel comp = CreateCompModelFromFormData();

                // Validate Component Model
                string errorMessage = ProgramLogic.ValidateCompModel(comp, creatingType);
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Save To Database
                GlobalConfig.Connection.UpdateComp(comp);
                // Reload Form
                LoadSelectedItem(comp.Id);
                return true;
            }
            else if (_itemType == ItemType.tool)
            {
                // Gather form data
                // Create Model From data
                ToolModel tool = CreateToolModelFromFormData();
                // Validate Tool Model
                string errorMessage = ProgramLogic.ValidateToolModel(tool, creatingType);
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Save To Database
                GlobalConfig.Connection.UpdateTool(tool);
                // Reload Form
                return true;
            }
            else if (_itemType == ItemType.list)
            {
                // Gather form data
                // Create Model From data
                ListModel list = CreateListModelFromFormData();

                // Validate List Model
                string errorMessage = ProgramLogic.ValidateListModel(list, creatingType);
                if (errorMessage.Length > 0)
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                // Save To Database
                GlobalConfig.Connection.UpdateList(list);
                // Reload Form
                return true;
            }
            return false;
        }
        #endregion

        #region Data acquiring
        private void WireUpControls()
        {
            List<Control> subControls = GetAllControls(sideForm).ToList();
            _statusBox = (TextBox)subControls.First(c => c.Name == "statusBox");
            if (_itemType == ItemType.comp || _itemType == ItemType.tool)
            {
                //wire up controls
                _pMaterialLabel = (Label)subControls.First(c => c.Name == "pMaterialLabel");
                _mMaterialLabel = (Label)subControls.First(c => c.Name == "mMaterialLabel");
                _kMaterialLabel = (Label)subControls.First(c => c.Name == "kMaterialLabel");
                _nMaterialLabel = (Label)subControls.First(c => c.Name == "nMaterialLabel");
                _sMaterialLabel = (Label)subControls.First(c => c.Name == "sMaterialLabel");
                _hMaterialLabel = (Label)subControls.First(c => c.Name == "hMaterialLabel");
                _toolClassIdBox = (TextBox)subControls.First(c => c.Name == "toolClassIdBox");
                _toolClassD1Box = (TextBox)subControls.First(c => c.Name == "toolGroupD1Box");
                _toolGroupIdBox = (TextBox)subControls.First(c => c.Name == "toolGroupIdBox");
                _toolGroupD1Box = (TextBox)subControls.First(c => c.Name == "toolGroupD1Box");
                _modeSpecificBox = (TextBox)subControls.First(c => c.Name == "modeSpecificBox");
                _parametersDataGridView = (DataGridView)GetAllControls(selectedViewPanel, typeof(DataGridView))
                .Where(dg => dg.Name == "parametersDataGridView")
                .FirstOrDefault();
                if (_itemType == ItemType.tool)
                {
                    _componentsDataGridView = (DataGridView)GetAllControls(selectedViewPanel, typeof(DataGridView))
                .Where(dg => dg.Name == "componentsDataGridView")
                .FirstOrDefault();
                }
            }
            else if (_itemType == ItemType.list)
            {
                _materialBox = (TextBox)subControls.First(c => c.Name == "materialBox");
                _machineBox = (TextBox)subControls.First(c => c.Name == "machineBox");
                _machineGroupBox = (TextBox)subControls.First(c => c.Name == "machineGroupBox");
                _createdByBox = (TextBox)subControls.First(c => c.Name == "createdByBox");
                _modifiedByBox = (TextBox)subControls.First(c => c.Name == "modifiedByBox");
                _responsibleBox = (TextBox)subControls.First(c => c.Name == "responsibleBox");
                _positionsDataGridView = (DataGridView)GetAllControls(selectedViewPanel, typeof(DataGridView))
                .Where(dg => dg.Name == "positionsDataGridView")
                .FirstOrDefault();
            }
        }
        private ListModel CreateListModelFromFormData() => new()
        {
            Id = idTextBox.Text,
            Description1 = d1TextBox.Text,
            Description2 = d2TextBox.Text,
            MachineId = _machineBox.Text,
            MachineGroupId = _machineGroupBox.Text,
            MaterialId = _materialBox.Text,
            DataStatus = _statusBox.Text,
            CreatorName = _createdByBox.Text,
            LastModifiedName = _modifiedByBox.Text,
            OwnerName = _responsibleBox.Text,
            ListPositions = GetListPositions()
        };

        private List<ListPositionModel> GetListPositions()
        {
            if (_positionsDataGridView.Rows.Count == 0)
            {
                return null;
            }
            List<ListPositionModel> output = new();
            foreach (DataGridViewRow row in _positionsDataGridView.Rows)
            {
                ListPositionModel model = new()
                {
                    Position = int.Parse(row.Cells["position"].Value.ToString()),
                    Quantity = int.Parse(row.Cells["quantity"].Value.ToString())
                };
                if (!string.IsNullOrEmpty(row.Cells["componentId"].Value.ToString()))
                {
                    model.BasicComp = new()
                    {
                        Id = row.Cells["componentId"].Value.ToString(),
                        Description1 = row.Cells["desc1"].Value.ToString(),
                        Description2 = row.Cells["desc2"].Value.ToString()
                    };
                }
                else
                {
                    model.BasicTool = new()
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


        private ToolModel CreateToolModelFromFormData() => new()
        {
            Id = idTextBox.Text,
            Description1 = d1TextBox.Text,
            Description2 = d2TextBox.Text,
            ToolClassId = _toolClassIdBox.Text,
            ToolGroupId = _toolGroupIdBox.Text,
            MachineInterfaceId = _modeSpecificBox.Text,
            DataStatus = _statusBox.Text,
            Suitability = GetSuitability(),
            Parameters = GetParameters(),
            Components = GetComponents()
        };

        private List<ToolComponentModel> GetComponents()
        {
            if (_componentsDataGridView.Rows.Count == 0)
            {
                return null;
            }
            List<ToolComponentModel> output = new();
            foreach (DataGridViewRow row in _componentsDataGridView.Rows)
            {
                ToolComponentModel model = new()
                {
                    IsKey = bool.Parse(row.Cells["keyComp"].Value.ToString()),
                    Position = int.Parse(row.Cells["position"].Value.ToString()),
                    BasicComp = new()
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


        private CompModel CreateCompModelFromFormData() => new()
        {
            Id = idTextBox.Text,
            Description1 = d1TextBox.Text,
            Description2 = d2TextBox.Text,
            ToolClassId = _toolClassIdBox.Text,
            ToolGroupId = _toolGroupIdBox.Text,
            ManufacturerName = _modeSpecificBox.Text,
            DataStatus = _statusBox.Text,
            Suitability = GetSuitability(),
            Parameters = GetParameters()
        };

        private SuitabilityModel GetSuitability() => new()
        {
            PSuitability = int.Parse(_pMaterialLabel.Tag.ToString()),
            MSuitability = int.Parse(_mMaterialLabel.Tag.ToString()),
            KSuitability = int.Parse(_kMaterialLabel.Tag.ToString()),
            NSuitability = int.Parse(_nMaterialLabel.Tag.ToString()),
            SSuitability = int.Parse(_sMaterialLabel.Tag.ToString()),
            HSuitability = int.Parse(_hMaterialLabel.Tag.ToString()),
        };

        private List<ParameterModel> GetParameters()
        {
            if (_parametersDataGridView.Rows.Count == 0)
            {
                return null;
            }
            List<ParameterModel> output = new();
            foreach (DataGridViewRow row in _parametersDataGridView.Rows)
            {
                ParameterModel model = new()
                {
                    Position = int.Parse(row.Cells["Position"].Value.ToString()),
                    ParameterId = row.Cells["ParameterId"].Value.ToString(),
                    Name = row.Cells["ParameterName"].Value.ToString(),
                    Description = row.Cells["ParameterDescription"].Value.ToString(),
                    DataValueType = (DataValueType)Enum.Parse(typeof(DataValueType), row.Cells["ValueType"].Value.ToString())
                };
                if (model.DataValueType == DataValueType.Numeric)
                {
                    model.NumericValue = double.Parse(row.Cells["Value"].Value.ToString());
                }
                else
                {
                    model.TextValue = row.Cells["Value"].Value.ToString();
                }
                output.Add(model);
            }
            return output;
        }
        #endregion
        #region Data loading
        private void LoadDataToUI()
        {
            //working mode determination
            if (_itemType == ItemType.comp)
            {
                //Verify item id
                string compId = idTextBox.Text;
                if (!GlobalConfig.Connection.ValidateCompId(compId))
                {
                    MessageBox.Show($"No component with Id of {compId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //get item model
                CompModel model = GlobalConfig.Connection.GetCompModelById(compId);
                //load model into ui
                LoadCompModelData(model);
            }
            else if (_itemType == ItemType.tool)
            {
                //Verify item id
                string toolId = idTextBox.Text;
                if (GlobalConfig.Connection.ValidateToolId(toolId))
                {
                    MessageBox.Show($"No tool with Id of {toolId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //get item model
                ToolModel model = GlobalConfig.Connection.GetToolModelById(toolId);
                //load model to ui
                LoadToolModelData(model);
            }
            else if (_itemType == ItemType.list)
            {
                //Verify item id
                string listId = idTextBox.Text;
                if (GlobalConfig.Connection.ValidateListId(listId))
                {
                    MessageBox.Show($"No tool list with Id of {listId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //get item model
                ListModel model = GlobalConfig.Connection.GetListModelById(listId);
                LoadListModelData(model);
            }
        }

        private void LoadListModelData(ListModel model)
        {
            idTextBox.Text = model.Id;
            d1TextBox.Text = model.Description1;
            d2TextBox.Text = model.Description2;
            LoadListPositions(model.ListPositions);
            _machineBox.Text = model.MachineId;
            _machineGroupBox.Text = model.MachineGroupId;
            _materialBox.Text = model.MaterialId;
            _statusBox.Text = model.DataStatus;
            _createdByBox.Text = model.CreatorName;
            _modifiedByBox.Text = model.LastModifiedName;
            _responsibleBox.Text = model.OwnerName;

        }

        private void LoadListPositions(List<ListPositionModel> tools)
        {
            _positionsDataGridView.DataSource = null;
            _positionsDataGridView.DataSource = ProgramLogic.CreateDataTableFromListOfModels(tools);
        }

        private void LoadToolModelData(ToolModel model)
        {
            //Insert all data acquired into controls
            idTextBox.Text = model.Id;
            d1TextBox.Text = model.Description1;
            d2TextBox.Text = model.Description2;
            LoadSuitability(model.Suitability);
            LoadParameters(model.Parameters);
            LoadComponents(model.Components);
            _toolClassIdBox.Text = model.ToolClassId;
            _toolClassD1Box.Text = GlobalConfig.Connection.GetClassNameById(model.ToolClassId);
            _toolGroupIdBox.Text = model.ToolGroupId;
            _toolGroupD1Box.Text = GlobalConfig.Connection.GetToolGroupNameById(model.ToolGroupId);
            _modeSpecificBox.Text = model.MachineInterfaceId;
            _statusBox.Text = model.DataStatus;
        }

        private void LoadComponents(List<ToolComponentModel> components)
        {
            _componentsDataGridView.DataSource = null;
            _componentsDataGridView.DataSource = ProgramLogic.CreateDataTableFromListOfModels(components);
        }

        private void LoadCompModelData(CompModel model)
        {
            //Insert all data acquired into controls
            idTextBox.Text = model.Id;
            d1TextBox.Text = model.Description1;
            d2TextBox.Text = model.Description2;
            LoadSuitability(model.Suitability);
            LoadParameters(model.Parameters);
            _toolClassIdBox.Text = model.ToolClassId;
            _toolClassD1Box.Text = GlobalConfig.Connection.GetClassNameById(model.ToolClassId);
            _toolGroupIdBox.Text = model.ToolGroupId;
            _toolGroupD1Box.Text = GlobalConfig.Connection.GetToolGroupNameById(model.ToolGroupId);
            _modeSpecificBox.Text = model.ManufacturerName;
            _statusBox.Text = model.DataStatus;
        }

        private void LoadParameters(List<ParameterModel> parameters)
        {
            _parametersDataGridView.DataSource = null;
            _parametersDataGridView.DataSource = ProgramLogic.CreateDataTableFromListOfModels(parameters);
        }

        private void LoadSuitability(SuitabilityModel suitability)
        {
            if (sideForm != null)
            {
                sideForm.Close();
            }
            sideForm = new ItemSidebar(_itemType, suitability, this, this);
            sideForm.TopLevel = false;
            sidePanel.Controls.Add(sideForm);
            sideForm.BringToFront();
            sideForm.Show();
        }

        #endregion


        public void LoadSelectedItem(string itemId)
        {
            idTextBox.Text = itemId;
            LoadDataToUI();
        }

        public void LoadClGr(ToolGroupModel model)
        {
            _toolClassIdBox.Text = model.ToolClassId;
            _toolClassD1Box.Text = GlobalConfig.Connection.GetClassNameById(model.ToolClassId);
            _toolGroupIdBox.Text = model.Id;
            _toolGroupD1Box.Text = model.Name;
        }
    }
}
