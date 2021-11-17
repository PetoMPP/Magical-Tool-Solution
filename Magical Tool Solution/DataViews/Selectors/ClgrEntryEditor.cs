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
        Form callingForm;
        public ClgrEntryEditor(string mode, Form caller)
        {
            callingForm = caller;
            InitializeComponent();
            AdjustUI(mode);
        }

        private void AdjustUI(string mode)
        {
            if (mode == "class_new" || mode == "class_update")
            {
                basicDataLabel.Text = "Basic Class Data:";
                idD1Label.Text = "Class ID and Description";

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

                if (mode == "class_new")
                {
                    selectorLabel.Text = "Add a new Class";
                }
                else
                {
                    selectorLabel.Text = "Modify selected Class";
                    idTextBox.Enabled = false;
                    browseButton.Enabled = false;
                }
            }
            else if (mode == "group_new" || mode == "group_update")
            {
                basicDataLabel.Text = "Basic Group Data:";
                idD1Label.Text = "Group ID and Description";
                if (mode == "group_new")
                {
                    selectorLabel.Text = "Add a new Group";
                }
                else
                {
                    selectorLabel.Text = "Modify selected Group";
                    idTextBox.Enabled = false;
                    browseButton.Enabled = false;
                }
            }
        }

        private void ClgrEntryEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Control control in callingForm.Controls)
            {
                control.Enabled = true;
            }
        }
    }
}
