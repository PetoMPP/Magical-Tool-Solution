
namespace Minimal_Tool_Stock_Calculator.DataViews
{
    partial class Parameters
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.parametersPanel = new System.Windows.Forms.Panel();
            this.parametersGridPanel = new System.Windows.Forms.Panel();
            this.parametersDataGridView = new System.Windows.Forms.DataGridView();
            this.parameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parameterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parameterDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parametersLabelPanel = new System.Windows.Forms.Panel();
            this.parametersLabel = new System.Windows.Forms.Label();
            this.parametersPanel.SuspendLayout();
            this.parametersGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parametersDataGridView)).BeginInit();
            this.parametersLabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // parametersPanel
            // 
            this.parametersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.parametersPanel.Controls.Add(this.parametersGridPanel);
            this.parametersPanel.Controls.Add(this.parametersLabelPanel);
            this.parametersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersPanel.Location = new System.Drawing.Point(0, 0);
            this.parametersPanel.Name = "parametersPanel";
            this.parametersPanel.Padding = new System.Windows.Forms.Padding(8);
            this.parametersPanel.Size = new System.Drawing.Size(800, 450);
            this.parametersPanel.TabIndex = 3;
            // 
            // parametersGridPanel
            // 
            this.parametersGridPanel.AutoScroll = true;
            this.parametersGridPanel.Controls.Add(this.parametersDataGridView);
            this.parametersGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersGridPanel.Location = new System.Drawing.Point(8, 55);
            this.parametersGridPanel.Name = "parametersGridPanel";
            this.parametersGridPanel.Size = new System.Drawing.Size(784, 387);
            this.parametersGridPanel.TabIndex = 7;
            // 
            // parametersDataGridView
            // 
            this.parametersDataGridView.AllowUserToDeleteRows = false;
            this.parametersDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.parametersDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.parametersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.parametersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parametersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parameterName,
            this.parameterValue,
            this.parameterDescription});
            this.parametersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersDataGridView.EnableHeadersVisualStyles = false;
            this.parametersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.parametersDataGridView.Name = "parametersDataGridView";
            this.parametersDataGridView.RowHeadersVisible = false;
            this.parametersDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.parametersDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.parametersDataGridView.RowTemplate.Height = 25;
            this.parametersDataGridView.ShowCellToolTips = false;
            this.parametersDataGridView.ShowEditingIcon = false;
            this.parametersDataGridView.Size = new System.Drawing.Size(784, 387);
            this.parametersDataGridView.TabIndex = 5;
            // 
            // parameterName
            // 
            this.parameterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.parameterName.Frozen = true;
            this.parameterName.HeaderText = "Parameter";
            this.parameterName.Name = "parameterName";
            this.parameterName.ReadOnly = true;
            this.parameterName.Width = 102;
            // 
            // parameterValue
            // 
            this.parameterValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.parameterValue.Frozen = true;
            this.parameterValue.HeaderText = "Value";
            this.parameterValue.Name = "parameterValue";
            this.parameterValue.Width = 72;
            // 
            // parameterDescription
            // 
            this.parameterDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.parameterDescription.HeaderText = "Description";
            this.parameterDescription.Name = "parameterDescription";
            this.parameterDescription.ReadOnly = true;
            // 
            // parametersLabelPanel
            // 
            this.parametersLabelPanel.Controls.Add(this.parametersLabel);
            this.parametersLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.parametersLabelPanel.Location = new System.Drawing.Point(8, 8);
            this.parametersLabelPanel.Name = "parametersLabelPanel";
            this.parametersLabelPanel.Size = new System.Drawing.Size(784, 47);
            this.parametersLabelPanel.TabIndex = 6;
            // 
            // parametersLabel
            // 
            this.parametersLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.parametersLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parametersLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.parametersLabel.Location = new System.Drawing.Point(0, 0);
            this.parametersLabel.Name = "parametersLabel";
            this.parametersLabel.Padding = new System.Windows.Forms.Padding(5);
            this.parametersLabel.Size = new System.Drawing.Size(784, 47);
            this.parametersLabel.TabIndex = 4;
            this.parametersLabel.Text = "Component\'s Parameters:";
            // 
            // Parameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.parametersPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Parameters";
            this.ShowInTaskbar = false;
            this.Text = "Parameters";
            this.parametersPanel.ResumeLayout(false);
            this.parametersGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parametersDataGridView)).EndInit();
            this.parametersLabelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel parametersPanel;
        private System.Windows.Forms.Panel parametersGridPanel;
        private System.Windows.Forms.DataGridView parametersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterDescription;
        private System.Windows.Forms.Panel parametersLabelPanel;
        private System.Windows.Forms.Label parametersLabel;
    }
}