
namespace Magical_Tool_Solution.Configuration
{
    partial class MainClassesConfiguration
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
            this.components = new System.ComponentModel.Container();
            this.moduleNameLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.mainClassesListBox = new System.Windows.Forms.ListBox();
            this.mainClassesListBoxContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteMainClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainClassesLabel = new System.Windows.Forms.Label();
            this.allocateClassesLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.bottomRightPanel = new System.Windows.Forms.Panel();
            this.unallocatedClassesListBox = new System.Windows.Forms.ListBox();
            this.unallocatedClassesLabel = new System.Windows.Forms.Label();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.unallocateClassButton = new System.Windows.Forms.Button();
            this.allocateClassButton = new System.Windows.Forms.Button();
            this.bottomLeftPanel = new System.Windows.Forms.Panel();
            this.allocatedClassesListBox = new System.Windows.Forms.ListBox();
            this.allocatedClassesLabel = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.mainClassesListBoxContextMenuStrip.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.bottomRightPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.bottomLeftPanel.SuspendLayout();
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
            this.moduleNameLabel.TabIndex = 5;
            this.moduleNameLabel.Text = "Main Classes Configuration";
            this.moduleNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.mainClassesListBox);
            this.topPanel.Controls.Add(this.mainClassesLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 62);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1084, 312);
            this.topPanel.TabIndex = 6;
            // 
            // mainClassesListBox
            // 
            this.mainClassesListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mainClassesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainClassesListBox.ContextMenuStrip = this.mainClassesListBoxContextMenuStrip;
            this.mainClassesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainClassesListBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainClassesListBox.ForeColor = System.Drawing.Color.White;
            this.mainClassesListBox.FormattingEnabled = true;
            this.mainClassesListBox.IntegralHeight = false;
            this.mainClassesListBox.ItemHeight = 32;
            this.mainClassesListBox.Location = new System.Drawing.Point(0, 42);
            this.mainClassesListBox.Name = "mainClassesListBox";
            this.mainClassesListBox.Size = new System.Drawing.Size(1084, 270);
            this.mainClassesListBox.Sorted = true;
            this.mainClassesListBox.TabIndex = 8;
            this.mainClassesListBox.SelectedIndexChanged += new System.EventHandler(this.MainClassesListBox_SelectedIndexChanged);
            this.mainClassesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainClassesListBox_MouseDoubleClick);
            this.mainClassesListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainClassesListBox_MouseDown);
            // 
            // mainClassesListBoxContextMenuStrip
            // 
            this.mainClassesListBoxContextMenuStrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mainClassesListBoxContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMainClassToolStripMenuItem});
            this.mainClassesListBoxContextMenuStrip.Name = "mainClassesListBoxContextMenuStrip";
            this.mainClassesListBoxContextMenuStrip.Size = new System.Drawing.Size(168, 26);
            // 
            // deleteMainClassToolStripMenuItem
            // 
            this.deleteMainClassToolStripMenuItem.Name = "deleteMainClassToolStripMenuItem";
            this.deleteMainClassToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deleteMainClassToolStripMenuItem.Text = "Delete Main Class";
            this.deleteMainClassToolStripMenuItem.Click += new System.EventHandler(this.DeleteMainClassToolStripMenuItem_Click);
            // 
            // mainClassesLabel
            // 
            this.mainClassesLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.mainClassesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainClassesLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainClassesLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mainClassesLabel.Location = new System.Drawing.Point(0, 0);
            this.mainClassesLabel.Name = "mainClassesLabel";
            this.mainClassesLabel.Padding = new System.Windows.Forms.Padding(5);
            this.mainClassesLabel.Size = new System.Drawing.Size(1084, 42);
            this.mainClassesLabel.TabIndex = 6;
            this.mainClassesLabel.Text = "Select Main Class (Double Click to Create/Edit)";
            // 
            // allocateClassesLabel
            // 
            this.allocateClassesLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.allocateClassesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.allocateClassesLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.allocateClassesLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.allocateClassesLabel.Location = new System.Drawing.Point(0, 374);
            this.allocateClassesLabel.Name = "allocateClassesLabel";
            this.allocateClassesLabel.Padding = new System.Windows.Forms.Padding(5);
            this.allocateClassesLabel.Size = new System.Drawing.Size(1084, 42);
            this.allocateClassesLabel.TabIndex = 7;
            this.allocateClassesLabel.Text = "Allocate Classes to Main Class";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.bottomRightPanel);
            this.bottomPanel.Controls.Add(this.buttonsPanel);
            this.bottomPanel.Controls.Add(this.bottomLeftPanel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(0, 416);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1084, 445);
            this.bottomPanel.TabIndex = 14;
            // 
            // bottomRightPanel
            // 
            this.bottomRightPanel.Controls.Add(this.unallocatedClassesListBox);
            this.bottomRightPanel.Controls.Add(this.unallocatedClassesLabel);
            this.bottomRightPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.bottomRightPanel.Location = new System.Drawing.Point(584, 0);
            this.bottomRightPanel.Name = "bottomRightPanel";
            this.bottomRightPanel.Size = new System.Drawing.Size(500, 445);
            this.bottomRightPanel.TabIndex = 21;
            // 
            // unallocatedClassesListBox
            // 
            this.unallocatedClassesListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.unallocatedClassesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unallocatedClassesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unallocatedClassesListBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.unallocatedClassesListBox.ForeColor = System.Drawing.Color.White;
            this.unallocatedClassesListBox.FormattingEnabled = true;
            this.unallocatedClassesListBox.IntegralHeight = false;
            this.unallocatedClassesListBox.ItemHeight = 32;
            this.unallocatedClassesListBox.Location = new System.Drawing.Point(0, 30);
            this.unallocatedClassesListBox.Margin = new System.Windows.Forms.Padding(6);
            this.unallocatedClassesListBox.Name = "unallocatedClassesListBox";
            this.unallocatedClassesListBox.Size = new System.Drawing.Size(500, 415);
            this.unallocatedClassesListBox.TabIndex = 9;
            this.unallocatedClassesListBox.SelectedValueChanged += new System.EventHandler(this.UnallocatedClassesListBox_SelectedValueChanged);
            // 
            // unallocatedClassesLabel
            // 
            this.unallocatedClassesLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.unallocatedClassesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.unallocatedClassesLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.unallocatedClassesLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.unallocatedClassesLabel.Location = new System.Drawing.Point(0, 0);
            this.unallocatedClassesLabel.Name = "unallocatedClassesLabel";
            this.unallocatedClassesLabel.Padding = new System.Windows.Forms.Padding(5);
            this.unallocatedClassesLabel.Size = new System.Drawing.Size(500, 30);
            this.unallocatedClassesLabel.TabIndex = 8;
            this.unallocatedClassesLabel.Text = "Unallocated Classes";
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.unallocateClassButton);
            this.buttonsPanel.Controls.Add(this.allocateClassButton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonsPanel.Location = new System.Drawing.Point(500, 0);
            this.buttonsPanel.MinimumSize = new System.Drawing.Size(84, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(84, 445);
            this.buttonsPanel.TabIndex = 20;
            // 
            // unallocateClassButton
            // 
            this.unallocateClassButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.unallocateClassButton.Enabled = false;
            this.unallocateClassButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.unallocateClassButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.unallocateClassButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.unallocateClassButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unallocateClassButton.Font = new System.Drawing.Font("Webdings", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.unallocateClassButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.unallocateClassButton.Location = new System.Drawing.Point(12, 166);
            this.unallocateClassButton.Margin = new System.Windows.Forms.Padding(6);
            this.unallocateClassButton.Name = "unallocateClassButton";
            this.unallocateClassButton.Size = new System.Drawing.Size(60, 60);
            this.unallocateClassButton.TabIndex = 9;
            this.unallocateClassButton.Text = "4";
            this.unallocateClassButton.UseVisualStyleBackColor = false;
            this.unallocateClassButton.Click += new System.EventHandler(this.MoveSelectedToSelected_Click);
            // 
            // allocateClassButton
            // 
            this.allocateClassButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.allocateClassButton.Enabled = false;
            this.allocateClassButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.allocateClassButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.allocateClassButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.allocateClassButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.allocateClassButton.Font = new System.Drawing.Font("Webdings", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.allocateClassButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.allocateClassButton.Location = new System.Drawing.Point(12, 246);
            this.allocateClassButton.Margin = new System.Windows.Forms.Padding(6);
            this.allocateClassButton.Name = "allocateClassButton";
            this.allocateClassButton.Size = new System.Drawing.Size(60, 60);
            this.allocateClassButton.TabIndex = 10;
            this.allocateClassButton.Text = "3";
            this.allocateClassButton.UseVisualStyleBackColor = false;
            this.allocateClassButton.Click += new System.EventHandler(this.MoveSelectedToAvailable_Click);
            // 
            // bottomLeftPanel
            // 
            this.bottomLeftPanel.Controls.Add(this.allocatedClassesListBox);
            this.bottomLeftPanel.Controls.Add(this.allocatedClassesLabel);
            this.bottomLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.bottomLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomLeftPanel.Name = "bottomLeftPanel";
            this.bottomLeftPanel.Size = new System.Drawing.Size(500, 445);
            this.bottomLeftPanel.TabIndex = 19;
            // 
            // allocatedClassesListBox
            // 
            this.allocatedClassesListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.allocatedClassesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.allocatedClassesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allocatedClassesListBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.allocatedClassesListBox.ForeColor = System.Drawing.Color.White;
            this.allocatedClassesListBox.FormattingEnabled = true;
            this.allocatedClassesListBox.IntegralHeight = false;
            this.allocatedClassesListBox.ItemHeight = 32;
            this.allocatedClassesListBox.Location = new System.Drawing.Point(0, 30);
            this.allocatedClassesListBox.Margin = new System.Windows.Forms.Padding(6);
            this.allocatedClassesListBox.Name = "allocatedClassesListBox";
            this.allocatedClassesListBox.Size = new System.Drawing.Size(500, 415);
            this.allocatedClassesListBox.TabIndex = 9;
            this.allocatedClassesListBox.SelectedValueChanged += new System.EventHandler(this.AllocatedClassesListBox_SelectedValueChanged);
            // 
            // allocatedClassesLabel
            // 
            this.allocatedClassesLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.allocatedClassesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.allocatedClassesLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.allocatedClassesLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.allocatedClassesLabel.Location = new System.Drawing.Point(0, 0);
            this.allocatedClassesLabel.Name = "allocatedClassesLabel";
            this.allocatedClassesLabel.Padding = new System.Windows.Forms.Padding(5);
            this.allocatedClassesLabel.Size = new System.Drawing.Size(500, 30);
            this.allocatedClassesLabel.TabIndex = 8;
            this.allocatedClassesLabel.Text = "Alocated Classes";
            // 
            // MainClassesConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1084, 861);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.allocateClassesLabel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.moduleNameLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainClassesConfiguration";
            this.Text = "MainClassesConfiguration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainClassesConfiguration_FormClosed);
            this.Resize += new System.EventHandler(this.MainClassesConfiguration_Resize);
            this.topPanel.ResumeLayout(false);
            this.mainClassesListBoxContextMenuStrip.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.bottomRightPanel.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.bottomLeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label moduleNameLabel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label mainClassesLabel;
        private System.Windows.Forms.ListBox mainClassesListBox;
        private System.Windows.Forms.Label allocateClassesLabel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel bottomRightPanel;
        private System.Windows.Forms.ListBox unallocatedClassesListBox;
        private System.Windows.Forms.Label unallocatedClassesLabel;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button unallocateClassButton;
        private System.Windows.Forms.Button allocateClassButton;
        private System.Windows.Forms.Panel bottomLeftPanel;
        private System.Windows.Forms.ListBox allocatedClassesListBox;
        private System.Windows.Forms.Label allocatedClassesLabel;
        private System.Windows.Forms.ContextMenuStrip mainClassesListBoxContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteMainClassToolStripMenuItem;
    }
}