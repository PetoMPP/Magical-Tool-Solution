using Magical_Tool_Solution.Interfaces;
using MTSLibrary;
using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private readonly ItemType _itemType;

        public ClgrSelector(Form caller, ISelectClGr selectClGr, ItemType itemType)
        {
            callingForm = caller;
            _selectClGr = selectClGr;
            _itemType = itemType;
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
            mainClassListBox.DisplayMember = "DisplayName";
            WireUpToolClassesList();
        }

        private void WireUpToolGroupsList()
        {
            toolGroupListBox.DataSource = null;
            if (toolClassListBox.SelectedItem != null)
            {
                _toolClassModel = (ToolClassModel)toolClassListBox.SelectedItem;
                switch (_itemType)
                {
                    case ItemType.comp:
                        toolGroupListBox.DataSource = _toolClassModel.ToolGroups
                            .Where(tg => tg.EnabledInComps == true).ToList();
                        break;
                    case ItemType.tool:
                        toolGroupListBox.DataSource = _toolClassModel.ToolGroups
                            .Where(tg => tg.EnabledInTools == true).ToList();
                        break;
                }
                toolGroupListBox.DisplayMember = "DisplayName";
            }
        }

        private void WireUpToolClassesList()
        {
            toolClassListBox.DataSource = null;
            if (mainClassListBox.SelectedItem != null)
            {
                _mainClassModel = (MainClassModel)mainClassListBox.SelectedItem;
                toolClassListBox.DataSource = _mainClassModel.ToolClasses;
                toolClassListBox.DisplayMember = "DisplayName";
            }
            WireUpToolGroupsList();
        }

        private void CancelButton_Click(object sender, EventArgs e) => Close();


        private void BasicItemLookup_FormClosed(object sender, FormClosedEventArgs e) => callingForm.Enabled = true;

        private void OkButton_Click(object sender, EventArgs e) => SendToInterface();

        private void MainClassListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WireUpToolClassesList();
            WireUpUI();
        }

        private void ToolClassListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WireUpToolGroupsList();
            WireUpUI();
        }

        private void ToolGroupListBox_SelectedIndexChanged(object sender, EventArgs e) => WireUpUI();

        private void ToolGroupListBox_MouseDoubleClick(object sender, MouseEventArgs e) => SendToInterface();
        private void SendToInterface()
        {
            _selectClGr.LoadClGr((ToolGroupModel)toolGroupListBox.SelectedItem);
            Close();
        }
    }
}
