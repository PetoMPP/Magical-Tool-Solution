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

namespace Minimal_Tool_Stock_Calculator.DataViews
{
    public partial class Parameters : Form
    {
        private readonly ItemType _itemType;

        public Parameters(ItemType itemType)
        {
            InitializeComponent();
            AdjustUI();
            _itemType = itemType;
        }

        private void AdjustUI()
        {
            if (_itemType == ItemType.comp)
            {
                parametersLabel.Text = "Component Parameters:";
            }
            else if (_itemType == ItemType.tool)
            {
                parametersLabel.Text = "Tool Parameters:";
            }
        }
    }
}
