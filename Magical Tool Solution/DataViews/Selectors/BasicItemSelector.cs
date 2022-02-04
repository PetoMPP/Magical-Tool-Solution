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
    public partial class BasicItemSelector : Form, ISelectItem
    {
        private readonly Form callingForm;

        //ISelectComponent or ISelectPosition
        private readonly ISelectComponent _selectComponent;
        private readonly ISelectPosition _selectPosition;
        private ItemType _itemType;
        private readonly CreatingType _creatingType;
        public BasicItemSelector(ItemType itemType, CreatingType creatingType, Form caller, ToolComponentModel model, ISelectComponent selectComponent)
        {
            callingForm = caller;
            _selectComponent = selectComponent;
            _itemType = itemType;
            _creatingType = creatingType;
            InitializeComponent();
            AdjustUI();
            LoadSelectedModelToUI(model);
        }

        public BasicItemSelector(ItemType itemType, CreatingType creatingType, Form caller, ListPositionModel model, ISelectPosition selectPosition)
        {
            callingForm = caller;
            _selectPosition = selectPosition;
            _itemType = itemType;
            _creatingType = creatingType;
            InitializeComponent();
            AdjustUI();
            LoadSelectedModelToUI(model);
        }

        private void LoadSelectedModelToUI(object model)
        {
            if (model.GetType() == typeof(ToolComponentModel))
            {
                ToolComponentModel comp = (ToolComponentModel)model;
                positionBox.Text = comp.Position.ToString();
                quantityBox.Text = comp.Quantity.ToString();
                if (comp.BasicComp != null)
                {
                    idTextBox.Text = comp.BasicComp.Id;
                    d1TextBox.Text = comp.BasicComp.Description1;
                    d2TextBox.Text = comp.BasicComp.Description2;
                }
                return;
            }
            if (model.GetType() == typeof(ListPositionModel))
            {
                //do list position stuff
                ListPositionModel listPosition = (ListPositionModel)model;
                positionBox.Text = listPosition.Position.ToString();
                quantityBox.Text = listPosition.Quantity.ToString();
                if (listPosition.BasicComp != null)
                {
                    idTextBox.Text = listPosition.BasicComp.Id;
                    d1TextBox.Text = listPosition.BasicComp.Description1;
                    d2TextBox.Text = listPosition.BasicComp.Description2;
                }
                else if (listPosition.BasicTool != null)
                {
                    idTextBox.Text = listPosition.BasicTool.Id;
                    d1TextBox.Text = listPosition.BasicTool.Description1;
                    d2TextBox.Text = listPosition.BasicTool.Description2;
                }
                return;
            }
            if (model.GetType() == typeof(BasicCompModel))
            {
                BasicCompModel basicComp = (BasicCompModel)model;
                idTextBox.Text = basicComp.Id;
                d1TextBox.Text = basicComp.Description1;
                d2TextBox.Text = basicComp.Description2;
                return;
            }
            if (model.GetType() == typeof(BasicToolModel))
            {
                BasicToolModel basicTool = (BasicToolModel)model;
                idTextBox.Text = basicTool.Id;
                d1TextBox.Text = basicTool.Description1;
                d2TextBox.Text = basicTool.Description2;
                return;
            }
        }

        private void AdjustUI()
        {
            if (_selectComponent != null)
            {
                selectorLabel.Text = "Select Component";
                IdLabel.Text = "Component Id:";
                D1Label.Text = "Component Description";
                D2Label.Text = "Component Manufacturer's Id:";
            }
            else if (_selectPosition != null)
            {
                selectorLabel.Text = "Select Tool or Component";
                radioSwitchPanel.Visible = true;
                radioSwitchPanel.Enabled = true;
                if (_itemType == ItemType.comp)
                {
                    IdLabel.Text = "Component Id:";
                    D1Label.Text = "Component Description";
                    D2Label.Text = "Component Manufacturer's Id:";
                    compRadioButton.Checked = true;
                }
                else if (_itemType == ItemType.tool)
                {
                    IdLabel.Text = "Tool Id:";
                    D1Label.Text = "Tool Description";
                    D2Label.Text = "Tool Manufacturer's Id:";
                    toolRadioButton.Checked = true;
                }
            }
            if (_creatingType == CreatingType.updating)
            {
                positionBox.Enabled = false;
                applyButton.Enabled = false;
            }
        }

        private void ValidateKeyPressedNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DecreaseButton_Click(object sender, EventArgs e)
        {
            int quantityBoxValue = 1;
            if (quantityBox.Text != null)
            {
                quantityBoxValue = int.Parse(quantityBox.Text);
            }
            int output = quantityBoxValue - 1;
            if (output < 1)
            {
                output = 1;
            }
            quantityBox.Text = Convert.ToString(output);
        }

        private void IncreaseButton_Click(object sender, EventArgs e)
        {
            int quantityBoxValue = 0;
            if (quantityBox.Text != null)
            {
                quantityBoxValue = int.Parse(quantityBox.Text);
            }
            int output = quantityBoxValue + 1;
            quantityBox.Text = Convert.ToString(output);
        }

        private void BasicItemSelector_FormClosed(object sender, FormClosedEventArgs e) => callingForm.Enabled = true;

        private void CancelButton_Click(object sender, EventArgs e) => Close();

        private void OkButton_Click(object sender, EventArgs e)
        {
            switch (_creatingType)
            {
                case CreatingType.updating:
                    UpdateSelectedItem();
                    break;
                case CreatingType.creating:
                    AddSelectedItem();
                    break;
            }
            Close();
        }

        private void UpdateSelectedItem()
        {
            //validate id
            if (!ValidateItemId())
            {
                return;
            }
            // determine which model shall be created
            if (_selectComponent != null)
            {
                //create tool comp model from form data
                ToolComponentModel model = CreateToolComponentModel();
                //send model to interface
                _selectComponent.UpdateToolComponent(model);
            }
            else if (_selectPosition != null)
            {
                //create position model
                ListPositionModel model = CreateListPositionModel();
                //send model to interface
                _selectPosition.UpdateListPosition(model);
            }
        }

        private void AddSelectedItem()
        {
            //validate id
            if (!ValidateItemId())
            {
                return;
            }
            if (IsPositionNumberInUse())
            {
                MessageBox.Show("Position number already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // determine which model shall be created
            if (_selectComponent != null)
            {
                //create tool comp model from form data
                ToolComponentModel model = CreateToolComponentModel();
                //send model to interface
                _selectComponent.AddToolComponent(model);
            }
            else if (_selectPosition != null)
            {
                //create position model
                ListPositionModel model = CreateListPositionModel();
                //send model to interface
                _selectPosition.AddListPosition(model);
            }
        }

        private ListPositionModel CreateListPositionModel()
        {
            ListPositionModel model = new()
            {
                Position = int.Parse(positionBox.Text),
                Quantity = int.Parse(quantityBox.Text)
            };
            if (_itemType == ItemType.comp)
            {
                //create model with comp model
                model.BasicComp = new BasicCompModel
                {
                    Id = idTextBox.Text,
                    Description1 = d1TextBox.Text,
                    Description2 = d2TextBox.Text
                };
            }
            else if (_itemType == ItemType.tool)
            {
                //create model with tool model
                model.BasicTool = new BasicToolModel
                {
                    Id = idTextBox.Text,
                    Description1 = d1TextBox.Text,
                    Description2 = d2TextBox.Text
                };
            }
            return model;
        }

        private ToolComponentModel CreateToolComponentModel()
        {

            ToolComponentModel model = new()
            {
                BasicComp = new BasicCompModel
                {
                    Id = idTextBox.Text,
                    Description1 = d1TextBox.Text,
                    Description2 = d2TextBox.Text
                },
                Position = int.Parse(positionBox.Text),
                Quantity = int.Parse(quantityBox.Text)
            };
            return model;
        }

        private bool IsPositionNumberInUse()
        {
            if (_selectComponent != null)
            {
                return _selectComponent.IsToolComponentPositionNumberInUse(int.Parse(positionBox.Text));
            }
            else if (_selectPosition != null)
            {
                return _selectPosition.IsListPositionPositionNumberInUse(int.Parse(positionBox.Text));
            }
            throw new Exception("Unsupported class type");
        }

        private bool ValidateItemId()
        {
            if (_itemType == ItemType.comp)
            {
                if (!GlobalConfig.Connection.ValidateCompId(idTextBox.Text))
                {
                    MessageBox.Show("Invaild component Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (_itemType == ItemType.tool)
            {
                if (!GlobalConfig.Connection.ValidateToolId(idTextBox.Text))
                {
                    MessageBox.Show("Invaild tool Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void IdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_itemType == ItemType.comp)
                {
                    //Load basic comp data
                    if (GlobalConfig.Connection.ValidateCompId(idTextBox.Text))
                    {
                        LoadSelectedModelToUI(new ToolComponentModel
                        {
                            Position = int.Parse(positionBox.Text),
                            Quantity = int.Parse(quantityBox.Text),
                            BasicComp = GlobalConfig.Connection.GetBasicCompModelById(idTextBox.Text)
                        });
                    }
                    else
                    {
                        MessageBox.Show("Invaild component Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (_itemType == ItemType.tool)
                {
                    if (GlobalConfig.Connection.ValidateToolId(idTextBox.Text))
                    {
                        LoadSelectedModelToUI(new ListPositionModel
                        {
                            Position = int.Parse(positionBox.Text),
                            Quantity = int.Parse(quantityBox.Text),
                            BasicTool = GlobalConfig.Connection.GetBasicToolModelById(idTextBox.Text)
                        });
                    }
                    else
                    {
                        MessageBox.Show("Invaild tool Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void ItemType_CheckedChanged(object sender, EventArgs e)
        {
            if (compRadioButton.Checked == true)
            {
                _itemType = ItemType.comp;
            }
            else if (toolRadioButton.Checked == true)
            {
                _itemType = ItemType.tool;
            }
            AdjustUI();
        }

        private void SearchByIdbutton_Click(object sender, EventArgs e) => OpenSearchWindow(0);

        private void OpenSearchWindow(int leadColumn)
        {
            string[] columnNames = UserInterfaceLogic.GetColumnsFromMode(_itemType);
            Form form = new BasicLookup(this, this, columnNames, leadColumn, _itemType);
            form.Visible = true;
            Enabled = false;
        }

        public void LoadSelectedItem(string itemId)
        {
            switch (_itemType)
            {
                case ItemType.comp:
                    LoadSelectedModelToUI(GlobalConfig.Connection.GetBasicCompModelById(itemId));
                    break;
                case ItemType.tool:
                    LoadSelectedModelToUI(GlobalConfig.Connection.GetBasicToolModelById(itemId));
                    break;
            }
        }

        private void SearchByD1Button_Click(object sender, EventArgs e) => OpenSearchWindow(1);

        private void SearchByD2Button_Click(object sender, EventArgs e) => OpenSearchWindow(2);

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            // Add selected
            AddSelectedItem();
            // Clear fields keeping the type and getting next pos number
            positionBox.Text = (int.Parse(positionBox.Text) + 1).ToString();
            quantityBox.Text = "1";
            idTextBox.Text = string.Empty;
            d1TextBox.Text = string.Empty;
            d2TextBox.Text = string.Empty;
        }
    }
}
