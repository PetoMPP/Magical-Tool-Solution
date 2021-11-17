using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Magical_Tool_Solution.DataViews.Headers;
using Magical_Tool_Solution.DataViews.Selectors;
using Minimal_Tool_Stock_Calculator.BasicDataSidebars;
using Minimal_Tool_Stock_Calculator.DataViews.Headers;

namespace Magical_Tool_Solution.BasicToolData
{
    public partial class BasicDataViewer : Form
    {
        Form caller;
        Form headerForm;
        Form sideForm;
        string creatingMode;
        public BasicDataViewer(Form callingForm, string mode)
        {
            creatingMode = mode;
            caller = callingForm;
            InitializeComponent();
            AdjustUI(creatingMode);
            WireUpToolTips();
        }

        private void AdjustUI(string mode)
        {
            if (mode == "comp")
            {
                moduleNameLabel.Text = "Component Viewer";
                searchTextLabel.Text = "Select or search component";
                IDLabel.Text = "Component ID";
                D1Label.Text = "Component Description";
                D2Label.Text = "Component Manufacturer's ID";
                searchLabel.Text = "Search for components";
            }
            else if (mode == "tool")
            {
                moduleNameLabel.Text = "Tool Viewer";
                searchTextLabel.Text = "Select or search tool";
                IDLabel.Text = "Tool ID";
                D1Label.Text = "Tool Description";
                D2Label.Text = "Lead Component Manufacturer's ID";
                searchLabel.Text = "Search for tools";
            }
            else if (mode == "list")
            {
                moduleNameLabel.Text = "Tool List Viewer";
                searchTextLabel.Text = "Select or search tool list";
                IDLabel.Text = "Tool List ID";
                D1Label.Text = "Tool List Description";
                D2Label.Text = "Part Number";
                searchLabel.Text = "Search for lists";
            }
            CreateSidePanel(mode);
            CreateViewPanel(mode);
        }

        private void CreateViewPanel(string mode)
        {
            if (headerForm != null)
            {
                headerForm.Close();
            }

            if (mode == "comp")
            {
                headerForm = new ComponentHeader(selectedViewPanel);
            }
            else if (mode == "tool")
            {
                headerForm = new ToolHeader(selectedViewPanel, this);
            }
            else if (mode == "list")
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

        private void CreateSidePanel(string mode)
        {
            if (sideForm != null)
            {
                sideForm.Close();
            }
            if (mode == "comp" || mode == "tool")
            {
                sideForm = new ItemSidebar(mode);
            }
            else if (mode == "list")
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
        private void WireUpToolTips()
        {
            compIDToolTip.SetToolTip(IDTextBox, IDTextBox.Text);
            compD1ToolTip.SetToolTip(D1TextBox, D1TextBox.Text);
            compD2ToolTip.SetToolTip(D2TextBox, D2TextBox.Text);
        }

        private void CompIDTextBox_TextChanged(object sender, EventArgs e)
        {
            WireUpToolTips();
        }

        private void CompD1TextBox_TextChanged(object sender, EventArgs e)
        {
            WireUpToolTips();
        }

        private void CompD2TextBox_TextChanged(object sender, EventArgs e)
        {
            WireUpToolTips();
        }

        private void CompDataViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            caller.Visible = true;
        }

        private void SearchByIDbutton_Click(object sender, EventArgs e)
        {
            string[] columnNames = GetColumnsFromMode(creatingMode);
            Form form = new BasicItemLookup(this, columnNames, 0);
            form.Visible = true;
        }

        private string[] GetColumnsFromMode(string creatingMode)
        {
            string[] output = new string[] { };
            if (creatingMode == "comp")
            {
                output = new string[] {"Component ID", "Component Description", "Comp. Manufacturer's ID" };
            }
            else if (creatingMode == "tool")
            {
                output = new string[] { "Tool ID", "Tool Description", "Lead Comp. Manufacturer's ID" };
            }
            else if (creatingMode == "list")
            {
                output = new string[] { "Tool List ID", "Tool List Description", "Part Number" };
            }
            return output;
        }

        private void SearchByD1Button_Click(object sender, EventArgs e)
        {
            string[] columnNames = GetColumnsFromMode(creatingMode);
            Form form = new BasicItemLookup(this, columnNames, 1);
            form.Visible = true;
        }

        private void SearchByD2Button_Click(object sender, EventArgs e)
        {
            string[] columnNames = GetColumnsFromMode(creatingMode);
            Form form = new BasicItemLookup(this, columnNames, 2);
            form.Visible = true;
        }

        private void ClearFormButton_Click(object sender, EventArgs e)
        {
            IEnumerable<Control> textBoxes = GetAllControls(this, typeof(TextBox));
            foreach (Control textBox in textBoxes)
            {
                textBox.Text = "";
            }
            CreateSidePanel(creatingMode);
            CreateViewPanel(creatingMode);
        }

        private IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(x => GetAllControls(x, type)).Concat(controls).Where(y => y.GetType() == type);
        }

        private void SaveFormButton_Click(object sender, EventArgs e)
        {
            // Create Model

            // Save To Database
        }

        //private List<TextBox> GetFormTextBoxes()
        //{
        //List<TextBox> output = new List<TextBox>();
        //foreach (Control bigControl in Controls)
        //{
        //    foreach (Control control in bigControl.Controls)
        //    {
        //        if (control.Tag is string @tag)
        //        {
        //            if (@tag == "TextBox")
        //            {
        //                output.Add((TextBox)control);
        //            } 
        //        }
        //    }

        //}
        //return output;
        //}
    }
}
