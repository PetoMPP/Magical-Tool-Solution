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
        public Parameters(string mode)
        {
            InitializeComponent();
            AdjustUI(mode);
        }

        private void AdjustUI(string mode)
        {
            if (mode == "comp")
            {
                parametersLabel.Text = "Component Parameters:";
            }
            else if (mode == "tool")
            {
                parametersLabel.Text = "Tool Parameters:";
            }
        }
    }
}
