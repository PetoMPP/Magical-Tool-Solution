using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minimal_Tool_Stock_Calculator
{
    public partial class CalculationResults : Form
    {
        List<int> calculatedInts = new List<int>();
        Form parentCaller = new Form();
        public CalculationResults(Form calulationCallingForm, List<int> dummyResults)
        {
            Visible = true;
            InitializeComponent();
            parentCaller = calulationCallingForm;
            calculatedInts = dummyResults;
            WireUpLists();
        }

        private void WireUpLists()
        {
            calculationResultListBox.DataSource = null;
            calculationResultListBox.DataSource = calculatedInts;
        }

        private void RestoreParentCaller(object sender, FormClosedEventArgs e)
        {
            parentCaller.Show();
        }

        private void returnToCalculationScreenButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
            parentCaller.Show();
        }
    }
}
