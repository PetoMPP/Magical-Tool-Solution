using MTSLibrary;
using MTSLibrary.Connections;
using MTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magical_Tool_Solution.ToolStockCalculations
{
    public partial class CalculationWindow : Form
    {
        Form caller;
        List<CompModel> availableComps = new List<CompModel>();
        //List<CompModel> availableComps = GlobalConfig.Connection.GetCompModels();
        List<CompModel> selectedComps = new List<CompModel>();
        List<ToolModel> tools = new List<ToolModel>();
        //List<ToolModel> tools = GlobalConfig.Connection.GetToolModels();
        public CalculationWindow(string mode, Form callingForm)
        {
            caller = callingForm;
            InitializeComponent();
            SelectMode(mode);
        }


        public void SelectMode(string mode)
        {
            //change label
            AdjustUI(mode);
            //change list sources
            //change button behaviour
            AdjustButtonEvents(mode);
            WireUpLists();
        }


        private void AdjustButtonEvents(string mode)
        {
            if (mode == "missing")
            {
                CalculateButton.Click += CalculateButton_CalculateMissing_Click;
            }
            if (mode == "minimal")
            {
                CalculateButton.Click += CalculateButton_CalculateMinimal_Click;
            }
            
        }

        private void CalculateButton_CalculateMinimal_Click(object sender, EventArgs e)
        {
            _ = new CalculationProgress("minimal", selectedComps, this);
        }

        private void CalculateButton_CalculateMissing_Click(object sender, EventArgs e)
        {
            _ = new CalculationProgress("missing", selectedComps, this);
        }

        private void AdjustUI(string mode)
        {
            if (mode == "missing")
            {
                moduleNameLabel.Text = "Missing Tool Stock Calculator";
                moduleDescriptionLabel.Text = "Wybierz komponenty do policzenia brakujących stanów magazynowych:";
            }
            if (mode == "minimal")
            {
                moduleNameLabel.Text = "Minimal Tool Stock Calculator";
                moduleDescriptionLabel.Text = "Wybierz komponenty do policzenia minimalnych stanów magazynowych:";
            }
        }
        private void WireUpLists()
        {
            availableListBox.DataSource = null;
            availableListBox.DataSource = availableComps;
            availableListBox.DisplayMember = "DisplayName";

            selectedListBox.DataSource = null;
            selectedListBox.DataSource = availableComps;
            selectedListBox.DisplayMember = "DisplayName";
        }

        private void RestoreCaller(object sender, FormClosedEventArgs e)
        {
            caller.Visible = true;
        }
    }
}
