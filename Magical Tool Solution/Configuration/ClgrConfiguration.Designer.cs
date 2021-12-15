
namespace Magical_Tool_Solution.Configuration
{
    partial class ClgrConfiguration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.moduleNameLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.clgrPanel = new System.Windows.Forms.Panel();
            this.componentsPanel = new System.Windows.Forms.Panel();
            this.clgrParametersDataGridView = new System.Windows.Forms.DataGridView();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parameterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parameterDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parameterDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parameterValueType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupsUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configureClgrParametersLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.topRightPanel = new System.Windows.Forms.Panel();
            this.groupsListBox = new System.Windows.Forms.ListBox();
            this.groupsLabel = new System.Windows.Forms.Label();
            this.topLeftPanel = new System.Windows.Forms.Panel();
            this.classesListBox = new System.Windows.Forms.ListBox();
            this.classesLabel = new System.Windows.Forms.Label();
            this.bottomPanel.SuspendLayout();
            this.clgrPanel.SuspendLayout();
            this.componentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clgrParametersDataGridView)).BeginInit();
            this.topPanel.SuspendLayout();
            this.topRightPanel.SuspendLayout();
            this.topLeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // moduleNameLabel
            // 
            this.moduleNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.moduleNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.moduleNameLabel.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.moduleNameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.moduleNameLabel.Location = new System.Drawing.Point(0, 0);
            this.moduleNameLabel.Name = "moduleNameLabel";
            this.moduleNameLabel.Size = new System.Drawing.Size(1084, 62);
            this.moduleNameLabel.TabIndex = 4;
            this.moduleNameLabel.Text = "Classes and Groups Configuration";
            this.moduleNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.clgrPanel);
            this.bottomPanel.Controls.Add(this.configureClgrParametersLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 428);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1084, 433);
            this.bottomPanel.TabIndex = 6;
            // 
            // clgrPanel
            // 
            this.clgrPanel.Controls.Add(this.componentsPanel);
            this.clgrPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clgrPanel.Location = new System.Drawing.Point(0, 42);
            this.clgrPanel.Name = "clgrPanel";
            this.clgrPanel.Size = new System.Drawing.Size(1084, 391);
            this.clgrPanel.TabIndex = 5;
            // 
            // componentsPanel
            // 
            this.componentsPanel.Controls.Add(this.clgrParametersDataGridView);
            this.componentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentsPanel.Location = new System.Drawing.Point(0, 0);
            this.componentsPanel.Name = "componentsPanel";
            this.componentsPanel.Padding = new System.Windows.Forms.Padding(8);
            this.componentsPanel.Size = new System.Drawing.Size(1084, 391);
            this.componentsPanel.TabIndex = 2;
            // 
            // clgrParametersDataGridView
            // 
            this.clgrParametersDataGridView.AllowUserToAddRows = false;
            this.clgrParametersDataGridView.AllowUserToDeleteRows = false;
            this.clgrParametersDataGridView.AllowUserToOrderColumns = true;
            this.clgrParametersDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.clgrParametersDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clgrParametersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.clgrParametersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clgrParametersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.position,
            this.parameterId,
            this.parameterDisplayName,
            this.parameterDescription,
            this.parameterValueType,
            this.groupsUsage});
            this.clgrParametersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clgrParametersDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.clgrParametersDataGridView.EnableHeadersVisualStyles = false;
            this.clgrParametersDataGridView.Location = new System.Drawing.Point(8, 8);
            this.clgrParametersDataGridView.Name = "clgrParametersDataGridView";
            this.clgrParametersDataGridView.RowHeadersVisible = false;
            this.clgrParametersDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.clgrParametersDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.clgrParametersDataGridView.RowTemplate.Height = 25;
            this.clgrParametersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.clgrParametersDataGridView.ShowCellToolTips = false;
            this.clgrParametersDataGridView.ShowEditingIcon = false;
            this.clgrParametersDataGridView.Size = new System.Drawing.Size(1068, 375);
            this.clgrParametersDataGridView.TabIndex = 8;
            this.clgrParametersDataGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PositionsDataGridView_MouseDoubleClick);
            // 
            // position
            // 
            this.position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.position.HeaderText = "Position";
            this.position.Name = "position";
            this.position.Width = 87;
            // 
            // parameterId
            // 
            this.parameterId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.parameterId.HeaderText = "Parameter Id";
            this.parameterId.MaxInputLength = 20;
            this.parameterId.MinimumWidth = 120;
            this.parameterId.Name = "parameterId";
            this.parameterId.ReadOnly = true;
            this.parameterId.Width = 120;
            // 
            // parameterDisplayName
            // 
            this.parameterDisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.parameterDisplayName.HeaderText = "Parameter Viewing Name";
            this.parameterDisplayName.MaxInputLength = 10;
            this.parameterDisplayName.MinimumWidth = 125;
            this.parameterDisplayName.Name = "parameterDisplayName";
            this.parameterDisplayName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.parameterDisplayName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.parameterDisplayName.Width = 126;
            // 
            // parameterDescription
            // 
            this.parameterDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.parameterDescription.HeaderText = "Description";
            this.parameterDescription.Name = "parameterDescription";
            this.parameterDescription.ReadOnly = true;
            // 
            // parameterValueType
            // 
            this.parameterValueType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.parameterValueType.HeaderText = "Value Type";
            this.parameterValueType.MaxInputLength = 120;
            this.parameterValueType.Name = "parameterValueType";
            this.parameterValueType.Width = 96;
            // 
            // groupsUsage
            // 
            this.groupsUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.groupsUsage.HeaderText = "Groups Using Parameter";
            this.groupsUsage.MaxInputLength = 120;
            this.groupsUsage.MinimumWidth = 150;
            this.groupsUsage.Name = "groupsUsage";
            this.groupsUsage.ReadOnly = true;
            this.groupsUsage.Width = 174;
            // 
            // configureClgrParametersLabel
            // 
            this.configureClgrParametersLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.configureClgrParametersLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.configureClgrParametersLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.configureClgrParametersLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.configureClgrParametersLabel.Location = new System.Drawing.Point(0, 0);
            this.configureClgrParametersLabel.Name = "configureClgrParametersLabel";
            this.configureClgrParametersLabel.Padding = new System.Windows.Forms.Padding(5);
            this.configureClgrParametersLabel.Size = new System.Drawing.Size(1084, 42);
            this.configureClgrParametersLabel.TabIndex = 4;
            this.configureClgrParametersLabel.Text = "Configure Class and Group Parameters";
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.topRightPanel);
            this.topPanel.Controls.Add(this.topLeftPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 62);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1084, 366);
            this.topPanel.TabIndex = 7;
            // 
            // topRightPanel
            // 
            this.topRightPanel.AutoScroll = true;
            this.topRightPanel.Controls.Add(this.groupsListBox);
            this.topRightPanel.Controls.Add(this.groupsLabel);
            this.topRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topRightPanel.Location = new System.Drawing.Point(550, 0);
            this.topRightPanel.Name = "topRightPanel";
            this.topRightPanel.Size = new System.Drawing.Size(534, 366);
            this.topRightPanel.TabIndex = 1;
            // 
            // groupsListBox
            // 
            this.groupsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupsListBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupsListBox.ForeColor = System.Drawing.Color.White;
            this.groupsListBox.FormattingEnabled = true;
            this.groupsListBox.IntegralHeight = false;
            this.groupsListBox.ItemHeight = 32;
            this.groupsListBox.Items.AddRange(new object[] {
            "tits",
            "ass"});
            this.groupsListBox.Location = new System.Drawing.Point(0, 42);
            this.groupsListBox.Name = "groupsListBox";
            this.groupsListBox.Size = new System.Drawing.Size(534, 324);
            this.groupsListBox.TabIndex = 8;
            this.groupsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GroupsListBox_MouseDoubleClick);
            // 
            // groupsLabel
            // 
            this.groupsLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupsLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupsLabel.Location = new System.Drawing.Point(0, 0);
            this.groupsLabel.Name = "groupsLabel";
            this.groupsLabel.Padding = new System.Windows.Forms.Padding(5);
            this.groupsLabel.Size = new System.Drawing.Size(534, 42);
            this.groupsLabel.TabIndex = 6;
            this.groupsLabel.Text = "Select Group (Double Click to Create/Edit)";
            // 
            // topLeftPanel
            // 
            this.topLeftPanel.AutoScroll = true;
            this.topLeftPanel.Controls.Add(this.classesListBox);
            this.topLeftPanel.Controls.Add(this.classesLabel);
            this.topLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.topLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.topLeftPanel.Name = "topLeftPanel";
            this.topLeftPanel.Size = new System.Drawing.Size(550, 366);
            this.topLeftPanel.TabIndex = 0;
            // 
            // classesListBox
            // 
            this.classesListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.classesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classesListBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.classesListBox.ForeColor = System.Drawing.Color.White;
            this.classesListBox.FormattingEnabled = true;
            this.classesListBox.IntegralHeight = false;
            this.classesListBox.ItemHeight = 32;
            this.classesListBox.Items.AddRange(new object[] {
            "one",
            "two"});
            this.classesListBox.Location = new System.Drawing.Point(0, 42);
            this.classesListBox.Name = "classesListBox";
            this.classesListBox.Size = new System.Drawing.Size(550, 324);
            this.classesListBox.TabIndex = 7;
            this.classesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ClassesListBox_MouseDoubleClick);
            // 
            // classesLabel
            // 
            this.classesLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.classesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.classesLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.classesLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.classesLabel.Location = new System.Drawing.Point(0, 0);
            this.classesLabel.Name = "classesLabel";
            this.classesLabel.Padding = new System.Windows.Forms.Padding(5);
            this.classesLabel.Size = new System.Drawing.Size(550, 42);
            this.classesLabel.TabIndex = 5;
            this.classesLabel.Text = "Select Class (Double Click to Create/Edit)";
            // 
            // ClgrConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1084, 861);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.moduleNameLabel);
            this.Name = "ClgrConfiguration";
            this.Text = "ClgrConfiguration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClgrConfiguration_FormClosed);
            this.bottomPanel.ResumeLayout(false);
            this.clgrPanel.ResumeLayout(false);
            this.componentsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clgrParametersDataGridView)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topRightPanel.ResumeLayout(false);
            this.topLeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label moduleNameLabel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label configureClgrParametersLabel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel topRightPanel;
        private System.Windows.Forms.Panel topLeftPanel;
        private System.Windows.Forms.Label classesLabel;
        private System.Windows.Forms.Label groupsLabel;
        private System.Windows.Forms.ListBox classesListBox;
        private System.Windows.Forms.ListBox groupsListBox;
        private System.Windows.Forms.Panel clgrPanel;
        private System.Windows.Forms.Panel componentsPanel;
        private System.Windows.Forms.DataGridView clgrParametersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterValueType;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupsUsage;
    }
}