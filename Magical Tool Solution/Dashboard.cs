using Magical_Tool_Solution.BasicToolData;
using Magical_Tool_Solution.Configuration;
using MTSLibrary;
using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Magical_Tool_Solution
{
    public partial class Dashboard : Form
    {
        private readonly List<ProgramSectionModel> programSections = ProgramLogic.GetProgramSections();
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
            switch (selectedModule.Name)
            {
                case "Components Data":
                    {
                        BasicDataViewer form = new(this, ItemType.Comp);
                        form.Visible = true;
                        break;
                    }

                case "Tool Data":
                    {
                        BasicDataViewer form = new(this, ItemType.Tool);
                        form.Visible = true;
                        break;
                    }

                case "Tool List Data":
                    {
                        BasicDataViewer form = new(this, ItemType.List);
                        form.Visible = true;
                        break;
                    }

                case "Tool Classes and Groups":
                    {
                        ClgrConfiguration form = new(this);
                        form.Visible = true;
                        break;
                    }

                case "Main Classes Configuration":
                    {
                        MainClassesConfiguration form = new(this);
                        form.Visible = true;
                        break;
                    }

                default:
                    MessageBox.Show("Module launching instructions not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new NotSupportedException();
            }
        }

        private void AvailableSectionsBox_SelectedIndexChanged(object sender, EventArgs e) => WireUpLists();

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
                Activate();
            }
        }

        private void Dashboard_SizeChanged(object sender, EventArgs e) => UserInterfaceLogic.ResizePanelsEvenly(this, titleLabel, sectionsPanel, modulesPanel, minWidth2: launchButtonPanel.Width + launchInNewWindowButtonPanel.Width);
    }
}
