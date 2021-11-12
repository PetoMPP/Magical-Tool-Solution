using MTSLibrary;
using MTSLibrary.Connections;
using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minimal_Tool_Stock_Calculator
{
    public partial class Dashboard : Form
    {
        List<ProgramSectionModel> programSections = ProgramLogic.GetProgramSections();
        public Dashboard()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            availableSectionsBox.DataSource = null;
            availableSectionsBox.DataSource = programSections;
            availableSectionsBox.DisplayMember = "Name";
            availableModulesBox.DataSource = null;
            if (availableSectionsBox.SelectedItem != null)
            {
                ProgramSectionModel sourceSection = (ProgramSectionModel)availableSectionsBox.SelectedItem;
                availableModulesBox.DataSource = sourceSection.AvailableModules;
                availableModulesBox.DisplayMember = "Name";
            }
        }

        private void LaunchInNewWindowButton_Click(object sender, EventArgs e)
        {
            ProgramModuleModel selectedModule = (ProgramModuleModel)availableModulesBox.SelectedItem;
            if (selectedModule.Name == "Missing Stock Calculator")
            {
                string mode = "missing";
                CalculationWindow form = new CalculationWindow(mode, this);
                form.Visible = true;
            }
            else if (selectedModule.Name == "Minimal Stock Calculator")
            {
                string mode = "minimal";
                CalculationWindow form = new CalculationWindow(mode, this);
                form.Visible = true;
            }
            else
            {
                MessageBox.Show("Module launching instructions not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            ProgramModuleModel selectedModule = (ProgramModuleModel)availableModulesBox.SelectedItem;
            if (selectedModule.Name == "Missing Stock Calculator")
            {
                string mode = "missing";
                CalculationWindow form = new CalculationWindow(mode, this);
                form.Visible = true;
            }
            else if (selectedModule.Name == "Minimal Stock Calculator")
            {
                string mode = "minimal";
                CalculationWindow form = new CalculationWindow(mode, this);
                form.Visible = true;
            }
            else
            {
                MessageBox.Show("Module launching instructions not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Visible = false;
        }

        private void availableSectionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WireUpLists();
        }
    }
}
