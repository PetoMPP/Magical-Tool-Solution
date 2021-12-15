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
    public partial class BasicItemSelector : Form
    {
        private readonly Form callingForm;

        //ISelectComponent or ISelectPosition
        private readonly object callingIForm;
        private ItemType _itemType;
        private readonly CreatingType _creatingType;
        public BasicItemSelector(ItemType itemType, CreatingType creatingType, Form caller, ToolComponentModel model, ISelectComponent iCaller)
        {
            callingForm = caller;
            callingIForm = iCaller;
            _itemType = itemType;
            _creatingType = creatingType;
            InitializeComponent();
            AdjustUI();
            LoadSelectedModelToUI(model);
        }

        public BasicItemSelector(ItemType itemType, CreatingType creatingType, Form caller, ListPositionModel model, ISelectPosition iCaller)
        {
            callingForm = caller;
            callingIForm = iCaller;
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
                if (comp.Comp != null)
                {
                    idTextBox.Text = comp.Comp.Id;
                    d1TextBox.Text = comp.Comp.Desc1;
                    d2TextBox.Text = comp.Comp.Desc2;
                }
            }
            else if (model.GetType() == typeof(ListPositionModel))
            {
                //do list position stuff
                ListPositionModel listPosition = (ListPositionModel)model;
                positionBox.Text = listPosition.Position.ToString();
                quantityBox.Text = listPosition.Quantity.ToString();
                if (listPosition.Comp != null)
                {
                    idTextBox.Text = listPosition.Comp.Id;
                    d1TextBox.Text = listPosition.Comp.Desc1;
                    d2TextBox.Text = listPosition.Comp.Desc2;
                }
                else if (listPosition.Tool != null)
                {
                    idTextBox.Text = listPosition.Tool.Id;
                    d1TextBox.Text = listPosition.Tool.Desc1;
                    d2TextBox.Text = listPosition.Tool.Desc2;
                }
            }
        }

        private void AdjustUI()
        {
            if (callingIForm.GetType() == typeof(ISelectComponent))
            {
                selectorLabel.Text = "Select Component";
                IdLabel.Text = "Component Id:";
                D1Label.Text = "Component Description";
                D2Label.Text = "Component Manufacturer's Id:";
            }
            else if (callingIForm.GetType() == typeof(ISelectPosition))
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
            //validate id
            if (!ValidateItemId())
            {
                return;
            }
            if (_creatingType == CreatingType.creating)
            {
                if (IsPositionNumberInUse())
                {
                    MessageBox.Show("Position number already in use", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // determine which model shall be created
            if (callingIForm.GetType() == typeof(ISelectComponent))
            {
                ISelectComponent caller = (ISelectComponent)callingIForm;
                //create tool comp model from form data
                ToolComponentModel model = CreateToolComponentModel();
                //send model to interface
                caller.AddComponent(model);
            }
            else if (callingIForm.GetType() == typeof(ISelectPosition))
            {
                ISelectPosition caller = (ISelectPosition)callingIForm;
                //create position model
                ListPositionModel model = CreateListPositionModel();
                //send model to interface
                caller.AddPosition(model);
            }
            Close();
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
                model.Comp = new CompModel
                {
                    Id = idTextBox.Text,
                    Desc1 = d1TextBox.Text,
                    Desc2 = d2TextBox.Text
                };
            }
            else if (_itemType == ItemType.tool)
            {
                //create model with tool model
                model.Tool = new ToolModel
                {
                    Id = idTextBox.Text,
                    Desc1 = d1TextBox.Text,
                    Desc2 = d2TextBox.Text
                };
            }
            return model;
        }

        private ToolComponentModel CreateToolComponentModel()
        {

            ToolComponentModel model = new()
            {
                Comp = new CompModel
                {
                    Id = idTextBox.Text,
                    Desc1 = d1TextBox.Text,
                    Desc2 = d2TextBox.Text
                },
                Position = int.Parse(positionBox.Text),
                Quantity = int.Parse(quantityBox.Text)
            };
            return model;
        }

        private bool IsPositionNumberInUse()
        {
            if (callingIForm.GetType() == typeof(ISelectComponent))
            {
                ISelectComponent caller = (ISelectComponent)callingIForm;
                return caller.IsPositionNumberInUse(int.Parse(positionBox.Text));
            }
            else if (callingIForm.GetType() == typeof(ISelectPosition))
            {
                ISelectPosition caller = (ISelectPosition)callingIForm;
                return caller.IsPositionNumberInUse(int.Parse(positionBox.Text));
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
                            Comp = GlobalConfig.Connection.GetBasicCompModelById(idTextBox.Text)
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
                            Tool = GlobalConfig.Connection.GetBasicToolModelById(idTextBox.Text)
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
    }
}
