using MTSLibrary.Connections;
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
        public Dashboard()
        {
            InitializeComponent();
        }

        private void MinimalStockButton_Click(object sender, EventArgs e)
        {
            string mode = "minimal";
            CalculationWindow form = new CalculationWindow(mode, this);
            form.Visible = true;
        }

        private void MissingStockButton_Click(object sender, EventArgs e)
        {
            string mode = "missing";
            CalculationWindow form = new CalculationWindow(mode, this);
            form.Visible = true;
        }
    }
}
