﻿using Magical_Tool_Solution.BasicToolData;
using Magical_Tool_Solution.Configuration;
using Magical_Tool_Solution.ToolStockCalculations;
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

namespace Magical_Tool_Solution
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
        private void LaunchButton_Click(object sender, EventArgs e)
        {
            try
            {
                LaunchModule();
            }
            catch (NotSupportedException)
            {
                return;
            }
            Visible = false;
        }

        private void LaunchInNewWindowButton_Click(object sender, EventArgs e)
        {
            try
            {
                LaunchModule();
            }
            catch (NotSupportedException)
            {
                return;
            }
        }
        private void LaunchModule()
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
            else if (selectedModule.Name == "Components Data")
            {
                BasicDataViewer form = new BasicDataViewer(this, "comp");
                form.Visible = true;
            }
            else if (selectedModule.Name == "Tool Data")
            {
                BasicDataViewer form = new BasicDataViewer(this, "tool");
                form.Visible = true;
            }
            else if (selectedModule.Name == "Tool List Data")
            {
                BasicDataViewer form = new BasicDataViewer(this, "list");
                form.Visible = true;
            }
            else if (selectedModule.Name == "Tool Classes and Groups")
            {
                ClgrConfiguration form = new ClgrConfiguration(this);
                form.Visible = true;
            }
            else
            {
                MessageBox.Show("Module launching instructions not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new NotSupportedException();
            }
        }

        private void AvailableSectionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WireUpLists();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
                Activate();
            }
        }
    }
}