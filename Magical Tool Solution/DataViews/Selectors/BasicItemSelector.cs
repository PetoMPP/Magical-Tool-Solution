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
        Form callingForm;
        public BasicItemSelector(string mode, Form caller)
        {
            callingForm = caller;
            InitializeComponent();
            AdjustUI(mode);
        }

        private void AdjustUI(string mode)
        {
            if (mode == "comp_new" || mode == "comp_update")
            {
                selectorLabel.Text = "Select Component";
                IDLabel.Text = "Component ID:";
                D1Label.Text = "Component Description";
                D2Label.Text = "Component Manufacturer's ID:";
            }
            else if (mode == "tool_new" || mode == "tool_update")
            {
                selectorLabel.Text = "Select Tool";
                IDLabel.Text = "Tool ID:";
                D1Label.Text = "Tool Description";
                D2Label.Text = "Lead Component Manufacturer's ID:";
            }
            else if (mode == "position_new" || mode == "position_update")
            {
                selectorLabel.Text = "Select Tool/Component";
                radioSwitchPanel.Visible = true;
            }
            if (mode == "comp_update" || mode == "tool_update" || mode == "position_update")
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

        private void BasicItemSelector_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Control control in callingForm.Controls)
            {
                control.Enabled = true;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
