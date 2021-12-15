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
    public partial class ClgrSelector : Form
    {
        private MainClassModel _mainClassModel;
        private ToolClassModel _toolClassModel;
        private readonly Form callingForm;
        private readonly ISelectClGr _selectClGr;

        public ClgrSelector(Form caller, ISelectClGr selectClGr)
        {
            callingForm = caller;
            _selectClGr = selectClGr;
            InitializeComponent();
            WireUpUI();
            WireUpLists();
        }

        private void WireUpUI()
        {
            okButton.Enabled = false;
            if (toolGroupListBox.SelectedItem != null)
            {
                okButton.Enabled = true;
            }
        }

        private void WireUpLists()
        {
            mainClassListBox.DataSource = null;
            mainClassListBox.DataSource = GlobalConfig.Connection.GetMainClassesList();

            toolClassListBox.DataSource = null;
            if (mainClassListBox.SelectedItem != null)
            {
                _mainClassModel = (MainClassModel)mainClassListBox.SelectedItem;
                toolClassListBox.DataSource = _mainClassModel.ToolClasses;
            }

            toolGroupListBox.DataSource = null;
            if (toolClassListBox.SelectedItem != null)
            {
                _toolClassModel = (ToolClassModel)toolClassListBox.SelectedItem;
                toolGroupListBox.DataSource = _toolClassModel.ToolGroups;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) => Close();

        private void ListUpdate(object sender, EventArgs e)
        {
            WireUpLists();
            WireUpUI();
        }

        private void BasicItemLookup_FormClosed(object sender, FormClosedEventArgs e) => callingForm.Enabled = true;

        private void OkButton_Click(object sender, EventArgs e) =>
            //send to interface
            _selectClGr.LoadClGr((ToolGroupModel)toolGroupListBox.SelectedItem);
    }
}
