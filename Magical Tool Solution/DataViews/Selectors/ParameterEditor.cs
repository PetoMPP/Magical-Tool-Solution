using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Magical_Tool_Solution.DataViews.Selectors
{
    public partial class ParameterEditor : Form
    {
        Form callingForm;
        public ParameterEditor(string mode, Form caller)
        {
            callingForm = caller;
            InitializeComponent();
            AdjustUI(mode);
        }

        private void AdjustUI(string mode)
        {
            if (mode == "parameter_new")
            {
                selectorLabel.Text = "Create Parameter:";
            }
            else if (mode == "parameter_update")
            {
                selectorLabel.Text = "Edit Parameter";
                idTextBox.Enabled = false;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;      // WS_EX_COMPOSITED
                return handleParam;
            }
        }
    }
}
