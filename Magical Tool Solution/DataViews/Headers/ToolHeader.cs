﻿using Minimal_Tool_Stock_Calculator.DataViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Magical_Tool_Solution.DataViews.Headers
{
    public partial class ToolHeader : Form
    {
        List<Button> viewSwitchingButtons = new List<Button>();
        Form viewForm;
        Panel insertionPanel;
        Form callingForm;
        Form instance1;
        Form instance2;
        public ToolHeader(Panel targetPanel, Form caller)
        {
            callingForm = caller;
            insertionPanel = targetPanel;
            InitializeComponent();
            viewSwitchingButtons = new List<Button> { viewParametersButton, viewComponentsButton };
            ViewParametersButton_Click(viewParametersButton, new EventArgs());
        }
        private void ActivateButton(Button callingButton, Form childForm)
        {
            foreach (Button button in viewSwitchingButtons)
            {
                if (button == callingButton)
                {
                    button.BackColor = Color.FromArgb(40, 40, 40);
                    button.FlatAppearance.BorderColor = Color.BlueViolet;
                    button.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 40, 40);
                    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 40, 40);
                    OpenView(childForm);
                }
                else
                {
                    button.BackColor = Color.FromArgb(60, 60, 60);
                    button.FlatAppearance.BorderColor = Color.Gray;
                    button.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 40, 40);
                    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 40, 40);
                }
            }
        }
        private void OpenView(Form childForm)
        {
            if (viewForm != null)
            {
                viewForm.Close();
            }
            viewForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            insertionPanel.Controls.Add(childForm);
            insertionPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            childForm.Focus();
        }
        private void ViewParametersButton_Click(object sender, EventArgs e)
        {
            if (instance1 == null)
            {
                instance1 = new Parameters("tool");
            }
            ActivateButton((Button)sender, instance1);
            viewSwitcherPanel.Focus();
        }

        private void ViewComponentsButton_Click(object sender, EventArgs e)
        {
            if (instance2 == null)
            {
                instance2 = new Components(callingForm);
            }
            ActivateButton((Button)sender, instance2);
            viewSwitcherPanel.Focus();
        }
    }
}
