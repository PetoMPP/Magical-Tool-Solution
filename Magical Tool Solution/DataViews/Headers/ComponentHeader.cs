using MTSLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Magical_Tool_Solution.DataViews.Headers
{
    public partial class ComponentHeader : Form
    {
        private readonly List<Button> viewSwitchingButtons = new();
        private Form viewForm;
        private readonly Panel insertionPanel;
        private Form instance1;
        private Form instance2;
        public ComponentHeader(Panel targetPanel)
        {
            insertionPanel = targetPanel;
            InitializeComponent();
            viewSwitchingButtons = new List<Button> { viewParametersButton, viewConnectionsButton };
            PreloadViews();
        }

        private void PreloadViews()
        {
            ViewConnectionsButton_Click(viewConnectionsButton, new EventArgs());
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
                viewForm.Hide();
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
                instance1 = new Parameters(ItemType.Comp);
            }
            ActivateButton((Button)sender, instance1);
            viewSwitcherPanel.Focus();
        }

        private void ViewConnectionsButton_Click(object sender, EventArgs e)
        {
            if (instance2 == null)
            {
                instance2 = new Connections();
            }
            ActivateButton((Button)sender, instance2);
            viewSwitcherPanel.Focus();
        }
    }
}
