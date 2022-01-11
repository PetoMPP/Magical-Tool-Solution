﻿using Magical_Tool_Solution.DataViews.Selectors;
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

namespace Magical_Tool_Solution.Configuration
{
    public partial class MainClassesConfiguration : Form, IMainClass
    {
        private readonly Form callingForm;
        private MainClassModel _mainClassModel;
        public MainClassesConfiguration(Form caller)
        {
            callingForm = caller;
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpContextMenu()
        {
            if (_mainClassModel != null)
            {
                deleteMainClassToolStripMenuItem.Enabled = true;
                return;
            }
            deleteMainClassToolStripMenuItem.Enabled = false;
        }

        private void WireUpLists()
        {
            LoadMainClasses();
            _mainClassModel = null;
            if (mainClassesListBox.SelectedItem != null)
            {
                _mainClassModel = (MainClassModel)mainClassesListBox.SelectedItem;
                LoadAllocatedClasses();
                LoadUnallocatedClasses();
            }
            WireUpContextMenu();
        }

        private void LoadUnallocatedClasses()
        {
            allocatedClassesListBox.DataSource = null;
            allocatedClassesListBox.DataSource = GlobalConfig.Connection.GetUnallocatedToolClasses();
        }

        private void LoadAllocatedClasses()
        {
            allocatedClassesListBox.DataSource = null;
            allocatedClassesListBox.DataSource = _mainClassModel.ToolClasses;
        }

        private void LoadMainClasses()
        {
            mainClassesListBox.DataSource = null;
            mainClassesListBox.DataSource = GlobalConfig.Connection.GetMainClassesList();
            mainClassesListBox.DisplayMember = "DisplayName";
        }

        private void MainClassesConfiguration_FormClosed(object sender, FormClosedEventArgs e) =>
            callingForm.Visible = true;

        private void MoveSelectedToSelected_Click(object sender, EventArgs e) => UnallocateClass();

        private void AllocateClass()
        {
            ToolClassModel toolClass = (ToolClassModel)unallocatedClassesListBox.SelectedItem;
            GlobalConfig.Connection.SetMainClassIdById(_mainClassModel.Id, toolClass.Id);
            WireUpLists();
        }

        private void AllocatedClassesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (allocatedClassesListBox.SelectedItem != null)
            {
                unallocateClassButton.Enabled = true;
            }
            else
            {
                unallocateClassButton.Enabled = false;
            }
        }

        private void UnallocatedClassesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (unallocatedClassesListBox.SelectedItem != null)
            {
                allocateClassButton.Enabled = true;
            }
            else
            {
                allocateClassButton.Enabled = false;
            }
        }

        private void MoveSelectedToAvailable_Click(object sender, EventArgs e) => AllocateClass();

        private void UnallocateClass()
        {
            ToolClassModel toolClass = (ToolClassModel)allocatedClassesListBox.SelectedItem;
            GlobalConfig.Connection.SetMainClassIdById(null, toolClass.Id);
            WireUpLists();
        }

        private void MainClassesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (mainClassesListBox.IndexFromPoint(e.Location) == ListBox.NoMatches)
            {
                // open what?? another new form? sigh.. lets to it by clgrEditor
                Form form = new ClgrEntryEditor(
                    ItemType.mainClass,
                    CreatingType.creating,
                    new MainClassModel(),
                    this,
                    this);
                form.Visible = true;
            }
            else
            {
                //edit main class
                MainClassModel model = (MainClassModel)mainClassesListBox.SelectedItem;
                Form form = new ClgrEntryEditor(
                    ItemType.mainClass,
                    CreatingType.updating,
                    model,
                    this,
                    this);
                form.Visible = true;
            }
            Enabled = false;
        }

        public bool ValidateMainClassId(string id) => GlobalConfig.Connection.ValidateMainClassId(id);

        public void AddMainClass(MainClassModel model)
        {
            GlobalConfig.Connection.CreateMainClass(model);
            WireUpLists();
        }

        public void UpdateMainClass(MainClassModel model)
        {
            GlobalConfig.Connection.UpdateMainClass(model);
            WireUpLists();
        }

        private void DeleteMainClassToolStripMenuItem_Click(object sender, EventArgs e) => DeleteSelectedMainClass();
        private void DeleteSelectedMainClass()
        {
            if (MessageBox.Show($"Are you sure you want to delete {_mainClassModel.Name}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                GlobalConfig.Connection.DeleteMainClassById(_mainClassModel.Id);
            }
            WireUpLists();
        }
    }
}
