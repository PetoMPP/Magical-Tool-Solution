using Magical_Tool_Solution.BasicDataSidebars;
using Magical_Tool_Solution.DataViews.Headers;
using Magical_Tool_Solution.DataViews.Selectors;
using Magical_Tool_Solution.Interfaces;
using MTSLibrary;
using MTSLibrary.Models;
using MTSLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

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
        private Panel _machineInterfacePanel;
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
        private TextBox _toolManufacturerBox;
        private TextBox _machineInterfaceBox;
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
            if (_itemType == ItemType.Tool)
            {
                LoadComponents();
            }
            if (_itemType == ItemType.List)
            {
                LoadListPositions();
            }
        }


        #region UI assembling
        private void AdjustUI()
        {
            if (_itemType == ItemType.Comp)
            {
                moduleNameLabel.Text = "Component Viewer";
                searchTextLabel.Text = "Select or search component";
                idLabel.Text = "Component Id";
                d1Label.Text = "Component Description";
                d2Label.Text = "Component Manufacturer's Id";
                searchLabel.Text = "Search for components";
            }
            else if (_itemType == ItemType.Tool)
            {
                moduleNameLabel.Text = "Tool Viewer";
                searchTextLabel.Text = "Select or search tool";
                idLabel.Text = "Tool Id";
                d1Label.Text = "Tool Description";
                d2Label.Text = "Lead Component Manufacturer's Id";
                searchLabel.Text = "Search for tools";
            }
            else if (_itemType == ItemType.List)
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
            switch (_itemType)
            {
                case ItemType.Comp:
                    headerForm = new ComponentHeader(selectedViewPanel);
                    break;
                case ItemType.Tool:
                    headerForm = new ToolHeader(selectedViewPanel, this, this);
                    break;
                case ItemType.List:
                    headerForm = new ListHeader(selectedViewPanel, this, this);
                    break;
                default:
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
            if (_itemType == ItemType.Comp || _itemType == ItemType.Tool)
            {
                sideForm = new ItemSidebar(_itemType, new SuitabilityModel(), this, this);
            }
            else if (_itemType == ItemType.List)
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

        private void ClearFormButton_Click(object sender, EventArgs e) => ClearFormData();

        private void SaveFormButton_Click(object sender, EventArgs e)
        {
            if (ShowQuery("This will save all changes done in the entry. Confirm?", "Save entry")
                != DialogResult.OK)
            {
                return;
            }
            if (SaveFormData())
            {
                ShowSuccess($"{_itemType} was saved successfully!", "Success!");
            }
        }

        private void CreateFormButton_Click(object sender, EventArgs e)
        {
            CreatingType creatingType = CreatingType.Creating;
            if (_itemType == ItemType.Comp)
            {
                CompModel comp = CreateCompModelFromFormData();
                string errorMessage = CompValidation.ValidateModel(comp, creatingType);
                if (errorMessage.Length > 0)
                {
                    ShowError(errorMessage);
                    return;
                }
                GlobalConfig.Connection.CreateComp(comp);
                LoadSelectedItem(comp.Id);
            }
            else if (_itemType == ItemType.Tool)
            {
                ToolModel tool = CreateToolModelFromFormData();
                string errorMessage = ToolValidation.ValidateModel(tool, creatingType);
                if (errorMessage.Length > 0)
                {
                    ShowError(errorMessage);
                    return;
                }
                GlobalConfig.Connection.CreateTool(tool);
                LoadSelectedItem(tool.Id);
            }
            else if (_itemType == ItemType.List)
            {
                ListModel list = CreateListModelFromFormData();
                string errorMessage = ListValidation.ValidateModel(list, creatingType);
                if (errorMessage.Length > 0)
                {
                    ShowError(errorMessage);
                    return;
                }
                GlobalConfig.Connection.CreateList(list);
                LoadSelectedItem(list.Id);
            }
            MessageBox.Show($"{_itemType} was created successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ShowQuery("This will erase all data related to this in the database. Confirm?", "Delete entry") == DialogResult.OK)
            {
                DeleteEntryById(idTextBox.Text);
                ClearFormData();
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
            if (ShowQuery("Action will save any changes made after loading the entry.\nContinue?", "Warining") == DialogResult.OK)
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
        private static void ShowSuccess(string message, string header) => MessageBox.Show(message, header, MessageBoxButtons.OK, MessageBoxIcon.Information);
        private static DialogResult ShowQuery(string question, string header) => MessageBox.Show(question, header, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        private static void ShowError(string errorMessage) => MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void WireUpControls()
        {
            List<Control> subControls = UserInterfaceLogic.GetAllControls(sideForm).ToList();
            _statusBox = (TextBox)subControls.First(c => c.Name == "statusBox");
            if (_itemType == ItemType.Comp || _itemType == ItemType.Tool)
            {
                //wire up controls
                _materialSuitabilityPanel = (Panel)subControls.First(c => c.Name == "materialSuitabilityPanel");
                _machineInterfacePanel = (Panel)subControls.First(c => c.Name == "machineInterfacePanel");
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
                _toolManufacturerBox = (TextBox)subControls.First(c => c.Name == "toolManufacturerBox");
                _machineInterfaceBox = (TextBox)subControls.First(c => c.Name == "machineInterfaceBox");
                _parametersDataGridView = (DataGridView)UserInterfaceLogic.GetAllControls(selectedViewPanel, typeof(DataGridView))
                .Where(dg => dg.Name == "parametersDataGridView")
                .FirstOrDefault();
                if (_itemType == ItemType.Tool)
                {
                    _componentsDataGridView = (DataGridView)UserInterfaceLogic.GetAllControls(selectedViewPanel, typeof(DataGridView))
                .Where(dg => dg.Name == "componentsDataGridView")
                .FirstOrDefault();
                }
            }
            else if (_itemType == ItemType.List)
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

        private void ClearFormData()
        {
            IEnumerable<Control> textBoxes = UserInterfaceLogic.GetAllControls(this, typeof(TextBox));
            foreach (Control textBox in textBoxes)
            {
                textBox.Text = string.Empty;
            }
            CreateSidePanel();
            CreateViewPanel();
            if (_itemType == ItemType.Tool)
            {
                // Load Components Table
                LoadComponents();
            }
            if (_itemType == ItemType.List)
            {
                LoadListPositions();
            }
        }

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
                ShowError("Id field cannot be empty!");
                return;
            }
            if (_itemType == ItemType.Comp)
            {
                if (!GlobalConfig.Connection.ValidateCompId(id))
                {
                    ShowError("Id not found!");
                    return;
                }
                GlobalConfig.Connection.DeleteCompById(id);
            }
            else if (_itemType == ItemType.Tool)
            {
                if (!GlobalConfig.Connection.ValidateToolId(id))
                {
                    ShowError("Id not found!");
                    return;
                }
                GlobalConfig.Connection.DeleteToolById(id);
            }
            else if (_itemType == ItemType.List)
            {
                if (!GlobalConfig.Connection.ValidateListId(id))
                {
                    ShowError("Id not found!");
                    return;
                }
                GlobalConfig.Connection.DeleteListById(id);
            }
            ShowSuccess($"{_itemType} was deleted successfully!", "Success!");
        }
        private bool SaveFormData()
        {
            CreatingType creatingType = CreatingType.Updating;
            string errorMessage;
            // Determine working mode (which model has to be created)
            switch (_itemType)
            {
                case ItemType.Comp:
                    CompModel comp = CreateCompModelFromFormData();
                    errorMessage = CompValidation.ValidateModel(comp, creatingType);
                    if (errorMessage.Length > 0)
                    {
                        ShowError(errorMessage);
                        return false;
                    }
                    GlobalConfig.Connection.UpdateComp(comp);
                    LoadSelectedItem(comp.Id);
                    return true;

                case ItemType.Tool:
                    ToolModel tool = CreateToolModelFromFormData();
                    errorMessage = ToolValidation.ValidateModel(tool, creatingType);
                    if (errorMessage.Length > 0)
                    {
                        ShowError(errorMessage);
                        return false;
                    }
                    GlobalConfig.Connection.UpdateTool(tool);
                    LoadSelectedItem(tool.Id);
                    return true;

                case ItemType.List:
                    ListModel list = CreateListModelFromFormData();
                    errorMessage = ListValidation.ValidateModel(list, creatingType);
                    if (errorMessage.Length > 0)
                    {
                        ShowError(errorMessage);
                        return false;
                    }
                    GlobalConfig.Connection.UpdateList(list);
                    LoadSelectedItem(list.Id);
                    return true;
            }
            return false;
        }

        #endregion

        #region Data retrieving from UI
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
            LastModifiedName = WindowsIdentity.GetCurrent().Name.Any(c => c == '\\') == true ? WindowsIdentity.GetCurrent().Name[(WindowsIdentity.GetCurrent().Name.IndexOf('\\') + 1)..] : WindowsIdentity.GetCurrent().Name,
            OwnerName = _responsibleBox.Text,
            ListPositions = DataGridViewsLogic.GetListPositionsFromUI(_positionsDataGridView)
        };

        private ToolModel CreateToolModelFromFormData() => new()
        {
            Id = idTextBox.Text,
            Description1 = d1TextBox.Text,
            Description2 = d2TextBox.Text,
            ToolClassId = _toolClassIdBox.Text,
            ToolGroupId = _toolGroupIdBox.Text,
            MachineInterfaceName = _machineInterfaceBox.Text,
            DataStatus = _statusBox.Text,
            Suitability = GetSuitabilityFromUI(),
            Parameters = DataGridViewsLogic.GetParametersFromUI(_parametersDataGridView),
            Components = DataGridViewsLogic.GetComponentsFromUI(_componentsDataGridView)
        };


        private CompModel CreateCompModelFromFormData() => new()
        {
            Id = idTextBox.Text,
            Description1 = d1TextBox.Text,
            Description2 = d2TextBox.Text,
            ToolClassId = _toolClassIdBox.Text,
            ToolGroupId = _toolGroupIdBox.Text,
            ManufacturerName = _toolManufacturerBox.Text,
            MachineInterfaceName = _machineInterfaceBox.Text,
            DataStatus = _statusBox.Text,
            Suitability = GetSuitabilityFromUI(),
            Parameters = DataGridViewsLogic.GetParametersFromUI(_parametersDataGridView)
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
        #endregion
        #region Data loading to UI
        public void LoadSelectedItem(string itemId)
        {
            idTextBox.Text = itemId;
            LoadDataToUI();
        }
        private void LoadDataToUI()
        {
            if (string.IsNullOrWhiteSpace(idTextBox.Text))
            {
                return;
            }
            //working mode determination
            if (_itemType == ItemType.Comp)
            {
                //Verify item id
                string compId = idTextBox.Text;
                if (!GlobalConfig.Connection.ValidateCompId(compId))
                {
                    ShowError($"No component with Id of {compId}.");
                    return;
                }
                //get item model
                CompModel model = GlobalConfig.Connection.GetCompModelById(compId);
                //load model into ui
                LoadCompModelData(model);
            }
            else if (_itemType == ItemType.Tool)
            {
                //Verify item id
                string toolId = idTextBox.Text;
                if (!GlobalConfig.Connection.ValidateToolId(toolId))
                {
                    ShowError($"No tool with Id of {toolId}.");
                    return;
                }
                //get item model
                ToolModel model = GlobalConfig.Connection.GetToolModelById(toolId);
                //load model to ui
                LoadToolModelData(model);
            }
            else if (_itemType == ItemType.List)
            {
                //Verify item id
                string listId = idTextBox.Text;
                if (!GlobalConfig.Connection.ValidateListId(listId))
                {
                    ShowError($"No tool list with Id of {listId}.");
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
            _positionsDataGridView.DataSource = DataGridViewsLogic.CreateListPositionsDataTable(tools);
            DataGridViewsLogic.ConfigurePositionsDataGrid(_positionsDataGridView);
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
            _toolClassD1Box.Text = GlobalConfig.Connection.GetToolClassNameById(model.ToolClassId);
            _toolGroupIdBox.Text = model.ToolGroupId;
            _toolGroupD1Box.Text = GlobalConfig.Connection.GetToolGroupNameByIdToolClassId(model.ToolGroupId, model.ToolClassId);
            _machineInterfaceBox.Text = model.MachineInterfaceName;
            _statusBox.Text = model.DataStatus;
            _toolGroup = GlobalConfig.Connection.GetToolGroupByIdToolClassId(model.ToolGroupId, model.ToolClassId);
            LoadToolGroupConfiguration();
        }

        private void LoadComponents(List<ToolComponentModel> components = null)
        {
            _componentsDataGridView.DataSource = null;
            _componentsDataGridView.DataSource = DataGridViewsLogic.CreateComponentsDataTable(components);
            DataGridViewsLogic.ConfigureComponentsDataGrid(_componentsDataGridView);
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
            _toolClassD1Box.Text = GlobalConfig.Connection.GetToolClassNameById(model.ToolClassId);
            _toolGroupIdBox.Text = model.ToolGroupId;
            _toolGroupD1Box.Text = GlobalConfig.Connection.GetToolGroupNameByIdToolClassId(model.ToolGroupId, model.ToolClassId);
            _toolManufacturerBox.Text = model.ManufacturerName;
            _machineInterfaceBox.Text = model.MachineInterfaceName;
            _statusBox.Text = model.DataStatus;
            _toolGroup = GlobalConfig.Connection.GetToolGroupByIdToolClassId(model.ToolGroupId, model.ToolClassId);
            LoadToolGroupConfiguration();
        }

        private void LoadParameters(List<ParameterModel> parameters)
        {
            _parametersDataGridView.DataSource = null;
            _parametersDataGridView.DataSource = ProgramLogic.CreateDataTableFromListOfModels(parameters);
            DataGridViewsLogic.ConfigureParametersDataGrid(_parametersDataGridView);
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
        public void LoadClGr(ToolGroupModel model)
        {
            _toolGroup = model;
            _toolClassIdBox.Text = _toolGroup.ToolClassId;
            _toolClassD1Box.Text = GlobalConfig.Connection.GetToolClassNameById(_toolGroup.ToolClassId);
            _toolGroupIdBox.Text = _toolGroup.Id;
            _toolGroupD1Box.Text = _toolGroup.Name;
            LoadToolGroupConfiguration();
            List<ParameterModel> parameters = GlobalConfig.Connection.GetParametersByToolClassIdToolGroupId(_toolClassIdBox.Text, _toolGroupIdBox.Text);
            // Try to assign as many parameters from existing datagrid to new configuration
            List<ParameterModel> currentParameters = DataGridViewsLogic.GetParametersFromUI(_parametersDataGridView);
            foreach (ParameterModel p in currentParameters)
            {
                if (parameters.Any(pm => pm.Id == p.Id))
                {
                    parameters.Where(pm => pm.Id == p.Id).First().NumericValue = p.NumericValue;
                    parameters.Where(pm => pm.Id == p.Id).First().TextValue = p.TextValue;
                }
            }
            LoadParameters(parameters);
        }
        private void LoadToolGroupConfiguration()
        {
            // apply group config
            // public bool SuitabilityEnabled { get; set; }
            _materialSuitabilityPanel.Visible = _toolGroup.SuitabilityEnabled;
            // public bool MachineInterfaceEnabled { get; set; }
            _machineInterfacePanel.Visible = _toolGroup.MachineInterfaceEnabled;
            // public bool InsertsEnabled { get; set; }
            ;
        }
        #endregion
        #region Interfaces Methods
        public void AddToolComponent(ToolComponentModel model)
        {
            // This method has to get existing tool components, add provided to those and load them back to datagrid
            List<ToolComponentModel> toolComponents = DataGridViewsLogic.GetComponentsFromUI(_componentsDataGridView);
            toolComponents.Add(model);
            LoadComponents(toolComponents);
        }


        public void DeleteToolComponent(int position)
        {
            List<ToolComponentModel> toolComponents = DataGridViewsLogic.GetComponentsFromUI(_componentsDataGridView);
            toolComponents.Remove(toolComponents.Where(tc => tc.Position == position).First());
            LoadComponents(toolComponents);
        }

        public void AddPosition(ListPositionModel model)
        {
            // This method has to get existing position, add provided to those and load them back to datagrid
            List<ListPositionModel> listPositions = DataGridViewsLogic.GetListPositionsFromUI(_positionsDataGridView);
            listPositions.Add(model);
            LoadListPositions(listPositions);
        }

        public void UpdateToolComponent(ToolComponentModel model)
        {
            // This method has to get existing components, replace edited by model provided and load them back to datagrid
            List<ToolComponentModel> toolComponents = DataGridViewsLogic.GetComponentsFromUI(_componentsDataGridView);
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
            List<ListPositionModel> listPositions = DataGridViewsLogic.GetListPositionsFromUI(_positionsDataGridView);
            listPositions.Add(model);
            LoadListPositions(listPositions);
        }

        public bool IsListPositionPositionNumberInUse(int position)
        {
            bool result = false;
            if (_positionsDataGridView.RowCount > 0)
            {
                List<int> positions = _positionsDataGridView.Rows.OfType<DataGridViewRow>().Select(r => int.Parse(r.Cells["position"].Value.ToString())).ToList();
                result = positions.Any(p => p == position);
            }
            return result;
        }

        public void DeleteListPosition(ListPositionModel model)
        {
            List<ListPositionModel> listPositions = DataGridViewsLogic.GetListPositionsFromUI(_positionsDataGridView);
            listPositions.Remove(listPositions.Where(lp => lp.Position == model.Position).First());
            LoadListPositions();
        }

        public void UpdateListPosition(ListPositionModel model)
        {
            // This method has to get existing list positions, replace edited by model provided and load them back to datagrid
            List<ListPositionModel> listPositions = DataGridViewsLogic.GetListPositionsFromUI(_positionsDataGridView);
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
            bool result = false;
            if (_componentsDataGridView.RowCount > 0)
            {
                List<int> positions = _componentsDataGridView.Rows.OfType<DataGridViewRow>().Select(r => int.Parse(r.Cells["position"].Value.ToString())).ToList();
                result = positions.Any(p => p == position);
            }
            return result;
        }
        #endregion
    }
}
