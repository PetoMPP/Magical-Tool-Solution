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
    public partial class BasicDataViewer : Form, ISelectItem, ISelectClGr, ISelectComponent, ISelectPosition
    {
        private readonly Form caller;
        private Form headerForm;
        private Form sideForm;
        private readonly ItemType _itemType;
        private ToolGroupModel _toolGroup;

        //External Controls
        //View Form
        private DataGridView _componentsDataGridView;
        private DataGridView _parametersDataGridView;
        private DataGridView _positionsDataGridView;
        //Side Form both
        private TextBox _statusBox;
        //Side Form item
        private Panel _materialSuitabilityPanel;
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
            if (_itemType == ItemType.tool)
            {
                // Load Components Table
                LoadComponents(); 
            }
            if (_itemType == ItemType.list)
            {
                LoadListPositions();
            }
            // Why?
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
                headerForm = new ToolHeader(selectedViewPanel, this, this);
            }
            else if (_itemType == ItemType.list)
            {
                headerForm = new ListHeader(selectedViewPanel, this, this);
            }
            else
            {
                return;
            }
            headerForm.TopLevel = false;
            viewSwitcherPanel.Controls.Add(headerForm);
            headerForm.BringToFront();
            headerForm.Show();
            WireUpControls();
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
            WireUpControls();
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
            string[] columnNames = UserInterfaceLogic.GetColumnsFromMode(_itemType);
            Form form = new BasicLookup(this, this, columnNames, 0, _itemType);
            form.Visible = true;
            Enabled = false;
        }


        private void SearchByD1Button_Click(object sender, EventArgs e)
        {
            string[] columnNames = UserInterfaceLogic.GetColumnsFromMode(_itemType);
            Form form = new BasicLookup(this, this, columnNames, 1, _itemType);
            form.Visible = true;
            Enabled = false;
        }

        private void SearchByD2Button_Click(object sender, EventArgs e)
        {
            string[] columnNames = UserInterfaceLogic.GetColumnsFromMode(_itemType);
            Form form = new BasicLookup(this, this, columnNames, 2, _itemType);
            form.Visible = true;
            Enabled = false;
        }

        private void ClearFormButton_Click(object sender, EventArgs e)
        {
            IEnumerable<Control> textBoxes = UserInterfaceLogic.GetAllControls(this, typeof(TextBox));
            foreach (Control textBox in textBoxes)
            {
                textBox.Text = string.Empty;
            }
            CreateSidePanel();
            CreateViewPanel();
            if (_itemType == ItemType.tool)
            {
                // Load Components Table
                LoadComponents();
            }
            if (_itemType == ItemType.list)
            {
                LoadListPositions();
            }
        }
        private void SaveFormButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will save all changes done in the entry. Confirm?",
                "Save entry",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Exclamation)
                == DialogResult.OK)
            {
                if (SaveFormData())
                {
                    MessageBox.Show($"The {_itemType} was saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            MessageBox.Show($"{_itemType} was created successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ClearFormButton_Click(sender, e);
            }
        }
        private void IdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadDataToUI();
            }
        }
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
        
        private void WireUpToolTips()
        {
            compIdToolTip.SetToolTip(idTextBox, idTextBox.Text);
            compD1ToolTip.SetToolTip(d1TextBox, d1TextBox.Text);
            compD2ToolTip.SetToolTip(d2TextBox, d2TextBox.Text);
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
                if (!GlobalConfig.Connection.ValidateCompId(id))
                {
                    MessageBox.Show("Id not found!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                GlobalConfig.Connection.DeleteCompById(id);
            }
            else if (_itemType == ItemType.tool)
            {
                if (!GlobalConfig.Connection.ValidateToolId(id))
                {
                    MessageBox.Show("Id not found!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                GlobalConfig.Connection.DeleteToolById(id);
            }
            else if (_itemType == ItemType.list)
            {
                if (!GlobalConfig.Connection.ValidateListId(id))
                {
                    MessageBox.Show("Id not found!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                GlobalConfig.Connection.DeleteListById(id);
            }
            MessageBox.Show($"{_itemType} was deleted successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            List<Control> subControls = UserInterfaceLogic.GetAllControls(sideForm).ToList();
            _statusBox = (TextBox)subControls.First(c => c.Name == "statusBox");
            if (_itemType == ItemType.comp || _itemType == ItemType.tool)
            {
                //wire up controls
                _materialSuitabilityPanel = (Panel)subControls.First(c => c.Name == "materialSuitabilityPanel");
                _pMaterialLabel = (Label)subControls.First(c => c.Name == "pMaterialLabel");
                _mMaterialLabel = (Label)subControls.First(c => c.Name == "mMaterialLabel");
                _kMaterialLabel = (Label)subControls.First(c => c.Name == "kMaterialLabel");
                _nMaterialLabel = (Label)subControls.First(c => c.Name == "nMaterialLabel");
                _sMaterialLabel = (Label)subControls.First(c => c.Name == "sMaterialLabel");
                _hMaterialLabel = (Label)subControls.First(c => c.Name == "hMaterialLabel");
                _toolClassIdBox = (TextBox)subControls.First(c => c.Name == "toolClassIdBox");
                _toolClassD1Box = (TextBox)subControls.First(c => c.Name == "toolClassD1Box");
                _toolGroupIdBox = (TextBox)subControls.First(c => c.Name == "toolGroupIdBox");
                _toolGroupD1Box = (TextBox)subControls.First(c => c.Name == "toolGroupD1Box");
                _modeSpecificBox = (TextBox)subControls.First(c => c.Name == "modeSpecificBox");
                _parametersDataGridView = (DataGridView)UserInterfaceLogic.GetAllControls(selectedViewPanel, typeof(DataGridView))
                .Where(dg => dg.Name == "parametersDataGridView")
                .FirstOrDefault();
                if (_itemType == ItemType.tool)
                {
                    _componentsDataGridView = (DataGridView)UserInterfaceLogic.GetAllControls(selectedViewPanel, typeof(DataGridView))
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
                _positionsDataGridView = (DataGridView)UserInterfaceLogic.GetAllControls(selectedViewPanel, typeof(DataGridView))
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
                return new List<ListPositionModel>();
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
            Suitability = GetSuitabilityFromUI(),
            Parameters = GetParametersFromUI(),
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
            Suitability = GetSuitabilityFromUI(),
            Parameters = GetParametersFromUI()
        };

        private SuitabilityModel GetSuitabilityFromUI() => new()
        {
            PSuitability = int.Parse(_pMaterialLabel.Tag.ToString()),
            MSuitability = int.Parse(_mMaterialLabel.Tag.ToString()),
            KSuitability = int.Parse(_kMaterialLabel.Tag.ToString()),
            NSuitability = int.Parse(_nMaterialLabel.Tag.ToString()),
            SSuitability = int.Parse(_sMaterialLabel.Tag.ToString()),
            HSuitability = int.Parse(_hMaterialLabel.Tag.ToString()),
        };

        private List<ParameterModel> GetParametersFromUI()
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
                    Name = row.Cells["Name"].Value.ToString(),
                    Description = row.Cells["Description"].Value.ToString(),
                    DataValueType = (DataValueType)Enum.Parse(typeof(DataValueType), row.Cells["DataValueType"].Value.ToString())
                };
                if (model.DataValueType == DataValueType.Numeric)
                {
                    if (!string.IsNullOrWhiteSpace(row.Cells["Value"].Value.ToString()))
                    {
                        model.NumericValue = double.Parse(row.Cells["Value"].Value.ToString());
                    }
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
            if (string.IsNullOrWhiteSpace(idTextBox.Text))
            {
                return;
            }
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
                if (!GlobalConfig.Connection.ValidateToolId(toolId))
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
                if (!GlobalConfig.Connection.ValidateListId(listId))
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

        private void LoadListPositions(List<ListPositionModel> tools = null)
        {
            _positionsDataGridView.DataSource = null;
            _positionsDataGridView.DataSource = CreateListPositionsDataTable(tools);
            ConfigurePositionsDataGrid();
        }

        private DataTable CreateListPositionsDataTable(List<ListPositionModel> tools = null)
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

        private void ConfigurePositionsDataGrid()
        {
            //    new DataColumn("position", typeof(int)),
            //    new DataColumn("componentId", typeof(string)),
            //    new DataColumn("toolId", typeof(string)),
            //    new DataColumn("itemId", typeof(string)),
            //    new DataColumn("desc1", typeof(string)),
            //    new DataColumn("desc2", typeof(string)),
            //    new DataColumn("quantity", typeof(int)),
            _positionsDataGridView.AllowUserToResizeRows = false;

            _positionsDataGridView.Columns["position"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _positionsDataGridView.Columns["position"].HeaderText = "Position";
            _positionsDataGridView.Columns["position"].DisplayIndex = 0;
            _positionsDataGridView.Columns["position"].ReadOnly = true;

            _positionsDataGridView.Columns["itemId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _positionsDataGridView.Columns["itemId"].HeaderText = "ID";
            _positionsDataGridView.Columns["itemId"].DisplayIndex = 1;
            _positionsDataGridView.Columns["itemId"].ReadOnly = true;

            _positionsDataGridView.Columns["desc1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _positionsDataGridView.Columns["desc1"].HeaderText = "Description 1";
            _positionsDataGridView.Columns["desc1"].DisplayIndex = 2;
            _positionsDataGridView.Columns["desc1"].ReadOnly = true;

            _positionsDataGridView.Columns["desc2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _positionsDataGridView.Columns["desc2"].HeaderText = "Description 2";
            _positionsDataGridView.Columns["desc2"].DisplayIndex = 3;
            _positionsDataGridView.Columns["desc2"].ReadOnly = true;

            _positionsDataGridView.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _positionsDataGridView.Columns["quantity"].HeaderText = "Quantity";
            _positionsDataGridView.Columns["quantity"].DisplayIndex = 4;
            _positionsDataGridView.Columns["quantity"].ReadOnly = true;

            _positionsDataGridView.Columns["componentId"].Visible = false;
            _positionsDataGridView.Columns["toolId"].Visible = false;
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
            _toolGroupD1Box.Text = GlobalConfig.Connection.GetToolGroupNameByIdToolClassId(model.ToolGroupId, model.ToolClassId);
            _modeSpecificBox.Text = model.MachineInterfaceId;
            _statusBox.Text = model.DataStatus;
            _toolGroup = GlobalConfig.Connection.GetToolGroupByIdToolClassId(model.ToolGroupId, model.ToolClassId);
            LoadToolGroupConfiguration();
        }

        private void LoadComponents(List<ToolComponentModel> components = null)
        {
            _componentsDataGridView.DataSource = null;
            _componentsDataGridView.DataSource = CreateComponentsDataTable(components);
            ConfigureComponentsDataGrid();
        }


        private static DataTable CreateComponentsDataTable(List<ToolComponentModel> components = null)
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
                foreach (ToolComponentModel tc in components)
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

        private void LoadCompModelData(CompModel model)
        {
            //Insert all data acquired into controls
            idTextBox.Text = model.Id;
            d1TextBox.Text = model.Description1;
            d2TextBox.Text = model.Description2;
            LoadParameters(model.Parameters);
            LoadSuitability(model.Suitability);
            _toolClassIdBox.Text = model.ToolClassId;
            _toolClassD1Box.Text = GlobalConfig.Connection.GetClassNameById(model.ToolClassId);
            _toolGroupIdBox.Text = model.ToolGroupId;
            _toolGroupD1Box.Text = GlobalConfig.Connection.GetToolGroupNameByIdToolClassId(model.ToolGroupId, model.ToolClassId);
            _modeSpecificBox.Text = model.ManufacturerName;
            _statusBox.Text = model.DataStatus;
            _toolGroup = GlobalConfig.Connection.GetToolGroupByIdToolClassId(model.ToolGroupId, model.ToolClassId);
            LoadToolGroupConfiguration();
        }

        private void LoadParameters(List<ParameterModel> parameters)
        {
            _parametersDataGridView.DataSource = null;
            _parametersDataGridView.DataSource = ProgramLogic.CreateDataTableFromListOfModels(parameters);
            ConfigureParametersDataGrid();
        }

        private void ConfigureParametersDataGrid()
        {
            _parametersDataGridView.AllowUserToResizeRows = false;

            _parametersDataGridView.Columns["Position"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _parametersDataGridView.Columns["Position"].DisplayIndex = 0;
            _parametersDataGridView.Columns["Position"].ReadOnly = true;

            _parametersDataGridView.Columns["ParameterId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _parametersDataGridView.Columns["ParameterId"].HeaderText = "ID";
            _parametersDataGridView.Columns["ParameterId"].DisplayIndex = 1;
            _parametersDataGridView.Columns["ParameterId"].ReadOnly = true;

            _parametersDataGridView.Columns["Value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _parametersDataGridView.Columns["Value"].DisplayIndex = 2;

            _parametersDataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _parametersDataGridView.Columns["Name"].HeaderText = "Parameter Name";
            _parametersDataGridView.Columns["Name"].DisplayIndex = 3;
            _parametersDataGridView.Columns["Name"].ReadOnly = true;

            _parametersDataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _parametersDataGridView.Columns["Description"].DisplayIndex = 4;
            _parametersDataGridView.Columns["Description"].ReadOnly = true;

            _parametersDataGridView.Columns["DataValueType"].Visible = false;
            _parametersDataGridView.Columns["NumericValue"].Visible = false;
            _parametersDataGridView.Columns["TextValue"].Visible = false;

            // clear 0's
            foreach (DataGridViewRow row in _parametersDataGridView.Rows)
            {
                if (row.Cells["Value"].Value.ToString() == "0")
                {
                    row.Cells["Value"].Value = string.Empty;
                }
            }
        }
        private void ConfigureComponentsDataGrid()
        {
            _componentsDataGridView.AllowUserToResizeRows = false;

            _componentsDataGridView.Columns["keyComp"].HeaderText = "Is key Component?";
            _componentsDataGridView.Columns["keyComp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _componentsDataGridView.Columns["keyComp"].ReadOnly = true;

            _componentsDataGridView.Columns["position"].HeaderText = "Position";
            _componentsDataGridView.Columns["position"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _componentsDataGridView.Columns["position"].ReadOnly = true;

            _componentsDataGridView.Columns["componentId"].HeaderText = "Component ID";
            _componentsDataGridView.Columns["componentId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _componentsDataGridView.Columns["componentId"].ReadOnly = true;

            _componentsDataGridView.Columns["componentD1"].HeaderText = "Component Description";
            _componentsDataGridView.Columns["componentD1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _componentsDataGridView.Columns["componentD1"].ReadOnly = true;
            _componentsDataGridView.Columns["componentD1"].Resizable = DataGridViewTriState.False;

            _componentsDataGridView.Columns["componentD2"].HeaderText = "Component Order Code";
            _componentsDataGridView.Columns["componentD2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _componentsDataGridView.Columns["componentD2"].ReadOnly = true;

            _componentsDataGridView.Columns["quantity"].HeaderText = "Quantity";
            _componentsDataGridView.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _componentsDataGridView.Columns["quantity"].ReadOnly = true;
            foreach (DataGridViewRow row in _componentsDataGridView.Rows)
            {
                row.Cells["keyComp"].ReadOnly = true;
            }
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
            WireUpControls();
        }

        #endregion


        public void LoadSelectedItem(string itemId)
        {
            idTextBox.Text = itemId;
            LoadDataToUI();
        }

        public void LoadClGr(ToolGroupModel model)
        {
            _toolGroup = model;
            _toolClassIdBox.Text = _toolGroup.ToolClassId;
            _toolClassD1Box.Text = GlobalConfig.Connection.GetClassNameById(_toolGroup.ToolClassId);
            _toolGroupIdBox.Text = _toolGroup.Id;
            _toolGroupD1Box.Text = _toolGroup.Name;
            LoadToolGroupConfiguration();
            List<ParameterModel> parameters = GetCompParameters();
            LoadParameters(parameters);
        }


        private List<ParameterModel> GetCompParameters()
        {
            List<ParameterModel> parameters = GlobalConfig.Connection.GetParametersByToolClassIdToolGroupId(_toolClassIdBox.Text, _toolGroupIdBox.Text);

            if (string.IsNullOrWhiteSpace(idTextBox.Text))
            {
                // Get list of parameters with values
                List<ParameterModel> parameterValues = GlobalConfig.Connection.GetCompParametersById(idTextBox.Text);
                foreach (ParameterModel pv in parameterValues)
                {
                    parameters.Where(p => p.ParameterId == pv.ParameterId).First().NumericValue = pv.NumericValue;
                    parameters.Where(p => p.ParameterId == pv.ParameterId).First().TextValue = pv.TextValue;
                }
            }

            return parameters;
        }

        private void LoadToolGroupConfiguration()
        {
            // apply group config
            // public bool SuitabilityEnabled { get; set; }
            _materialSuitabilityPanel.Visible = _toolGroup.SuitabilityEnabled;
            // public bool MachineInterfaceEnabled { get; set; }
            ;
            // public bool InsertsEnabled { get; set; }
            ;
        }

        public void AddToolComponent(ToolComponentModel model)
        {
            // This method has to get existing tool components, add provided to those and load them back to datagrid
            List<ToolComponentModel> toolComponents = GetComponents();
            if (toolComponents == null)
            {
                toolComponents = new();
            }
            toolComponents.Add(model);
            LoadComponents(toolComponents);
        }


        public void DeleteToolComponent(int position)
        {
            List<ToolComponentModel> toolComponents = GetComponents();
            toolComponents.Remove(toolComponents.Where(tc => tc.Position == position).First());
            LoadComponents(toolComponents);
        }

        public void AddPosition(ListPositionModel model)
        {
            // This method has to get existing position, add provided to those and load them back to datagrid
            List<ListPositionModel> listPositions = GetListPositions();
            if (listPositions == null)
            {
                listPositions = new();
            }
            listPositions.Add(model);
            LoadListPositions(listPositions);
        }

        public void UpdateToolComponent(ToolComponentModel model)
        {
            // This method has to get existing components, replace edited by model provided and load them back to datagrid
            List<ToolComponentModel> toolComponents = GetComponents();
            // get index of updated component
            int index = toolComponents.FindIndex(tc => tc.Position == model.Position);
            // IsKey is not provided by model and should be taken from replaced component
            model.IsKey = toolComponents[index].IsKey;
            // remove component
            toolComponents.RemoveAt(index);
            // add updated model
            toolComponents.Insert(index, model);
            LoadComponents(toolComponents);
        }

        public void AddListPosition(ListPositionModel model)
        {
            // This method has to get existing positions, add provided to those and load them back to datagrid
            List<ListPositionModel> listPositions = GetListPositions();
            if (listPositions == null)
            {
                listPositions = new();
            }
            listPositions.Add(model);
            LoadListPositions(listPositions);
        }

        public bool IsListPositionPositionNumberInUse(int position)
        {
            if (_positionsDataGridView.RowCount > 0)
            {
                foreach (DataGridViewRow row in _positionsDataGridView.Rows)
                {
                    if (int.Parse(row.Cells["position"].Value.ToString()) == position)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void DeleteListPosition(ListPositionModel model)
        {
            List<ListPositionModel> listPositions = GetListPositions();
            listPositions.Remove(listPositions.Where(lp => lp.Position == model.Position).First());
            LoadListPositions();
        }

        public void UpdateListPosition(ListPositionModel model)
        {
            // This method has to get existing list positions, replace edited by model provided and load them back to datagrid
            List<ListPositionModel> listPositions = GetListPositions();
            // get index of updated position
            int index = listPositions.FindIndex(lp => lp.Position == model.Position);
            // remove position
            listPositions.RemoveAt(index);
            // add updated model
            listPositions.Insert(index, model);
            LoadListPositions(listPositions);
        }

        public bool IsToolComponentPositionNumberInUse(int position)
        {
            if (_componentsDataGridView.RowCount > 0)
            {
                foreach (DataGridViewRow row in _componentsDataGridView.Rows)
                {
                    if (int.Parse(row.Cells["position"].Value.ToString()) == position)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
