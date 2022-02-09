
namespace Magical_Tool_Solution
{
    partial class Dashboard
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.sectionsPanel = new System.Windows.Forms.Panel();
            this.availableSectionsBox = new System.Windows.Forms.ListBox();
            this.modulesPanel = new System.Windows.Forms.Panel();
            this.availableModulesBox = new System.Windows.Forms.ListBox();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.launchInNewWindowButtonPanel = new System.Windows.Forms.Panel();
            this.launchInNewWindowButton = new System.Windows.Forms.Button();
            this.launchButtonPanel = new System.Windows.Forms.Panel();
            this.launchButton = new System.Windows.Forms.Button();
            this.sectionsPanel.SuspendLayout();
            this.modulesPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.launchInNewWindowButtonPanel.SuspendLayout();
            this.launchButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(688, 62);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "MTS Dashboard";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // sectionsPanel
            // 
            this.sectionsPanel.Controls.Add(this.availableSectionsBox);
            this.sectionsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sectionsPanel.Location = new System.Drawing.Point(0, 62);
            this.sectionsPanel.Name = "sectionsPanel";
            this.sectionsPanel.Size = new System.Drawing.Size(344, 379);
            this.sectionsPanel.TabIndex = 10;
            // 
            // availableSectionsBox
            // 
            this.availableSectionsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.availableSectionsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.availableSectionsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.availableSectionsBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.availableSectionsBox.ForeColor = System.Drawing.Color.White;
            this.availableSectionsBox.FormattingEnabled = true;
            this.availableSectionsBox.IntegralHeight = false;
            this.availableSectionsBox.ItemHeight = 32;
            this.availableSectionsBox.Location = new System.Drawing.Point(0, 0);
            this.availableSectionsBox.Name = "availableSectionsBox";
            this.availableSectionsBox.Size = new System.Drawing.Size(344, 379);
            this.availableSectionsBox.TabIndex = 8;
            this.availableSectionsBox.SelectedIndexChanged += new System.EventHandler(this.AvailableSectionsBox_SelectedIndexChanged);
            // 
            // modulesPanel
            // 
            this.modulesPanel.Controls.Add(this.availableModulesBox);
            this.modulesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modulesPanel.Location = new System.Drawing.Point(344, 62);
            this.modulesPanel.Name = "modulesPanel";
            this.modulesPanel.Size = new System.Drawing.Size(344, 304);
            this.modulesPanel.TabIndex = 12;
            // 
            // availableModulesBox
            // 
            this.availableModulesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.availableModulesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.availableModulesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.availableModulesBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.availableModulesBox.ForeColor = System.Drawing.Color.White;
            this.availableModulesBox.FormattingEnabled = true;
            this.availableModulesBox.IntegralHeight = false;
            this.availableModulesBox.ItemHeight = 32;
            this.availableModulesBox.Location = new System.Drawing.Point(0, 0);
            this.availableModulesBox.Name = "availableModulesBox";
            this.availableModulesBox.Size = new System.Drawing.Size(344, 304);
            this.availableModulesBox.TabIndex = 7;
            this.availableModulesBox.DoubleClick += new System.EventHandler(this.LaunchButton_Click);
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.launchInNewWindowButtonPanel);
            this.buttonsPanel.Controls.Add(this.launchButtonPanel);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.Location = new System.Drawing.Point(344, 366);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(344, 75);
            this.buttonsPanel.TabIndex = 10;
            // 
            // launchInNewWindowButtonPanel
            // 
            this.launchInNewWindowButtonPanel.Controls.Add(this.launchInNewWindowButton);
            this.launchInNewWindowButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.launchInNewWindowButtonPanel.Location = new System.Drawing.Point(148, 0);
            this.launchInNewWindowButtonPanel.Name = "launchInNewWindowButtonPanel";
            this.launchInNewWindowButtonPanel.Padding = new System.Windows.Forms.Padding(6);
            this.launchInNewWindowButtonPanel.Size = new System.Drawing.Size(148, 75);
            this.launchInNewWindowButtonPanel.TabIndex = 11;
            // 
            // launchInNewWindowButton
            // 
            this.launchInNewWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.launchInNewWindowButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.launchInNewWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.launchInNewWindowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.launchInNewWindowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.launchInNewWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchInNewWindowButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.launchInNewWindowButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.launchInNewWindowButton.Location = new System.Drawing.Point(6, 6);
            this.launchInNewWindowButton.Margin = new System.Windows.Forms.Padding(8);
            this.launchInNewWindowButton.Name = "launchInNewWindowButton";
            this.launchInNewWindowButton.Size = new System.Drawing.Size(136, 63);
            this.launchInNewWindowButton.TabIndex = 8;
            this.launchInNewWindowButton.Text = "Uruchom moduł w nowym oknie";
            this.launchInNewWindowButton.UseVisualStyleBackColor = false;
            this.launchInNewWindowButton.Click += new System.EventHandler(this.LaunchInNewWindowButton_Click);
            // 
            // launchButtonPanel
            // 
            this.launchButtonPanel.Controls.Add(this.launchButton);
            this.launchButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.launchButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.launchButtonPanel.Name = "launchButtonPanel";
            this.launchButtonPanel.Padding = new System.Windows.Forms.Padding(6);
            this.launchButtonPanel.Size = new System.Drawing.Size(148, 75);
            this.launchButtonPanel.TabIndex = 10;
            // 
            // launchButton
            // 
            this.launchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.launchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.launchButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.launchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.launchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.launchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.launchButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.launchButton.Location = new System.Drawing.Point(6, 6);
            this.launchButton.Margin = new System.Windows.Forms.Padding(8);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(136, 63);
            this.launchButton.TabIndex = 9;
            this.launchButton.Text = "Uruchom moduł";
            this.launchButton.UseVisualStyleBackColor = false;
            this.launchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(688, 441);
            this.Controls.Add(this.modulesPanel);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.sectionsPanel);
            this.Controls.Add(this.titleLabel);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Dashboard_SizeChanged);
            this.sectionsPanel.ResumeLayout(false);
            this.modulesPanel.ResumeLayout(false);
            this.buttonsPanel.ResumeLayout(false);
            this.launchInNewWindowButtonPanel.ResumeLayout(false);
            this.launchButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel sectionsPanel;
        private System.Windows.Forms.Panel modulesPanel;
        private System.Windows.Forms.ListBox availableModulesBox;
        private System.Windows.Forms.Button launchInNewWindowButton;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Panel launchInNewWindowButtonPanel;
        private System.Windows.Forms.Panel launchButtonPanel;
        private System.Windows.Forms.ListBox availableSectionsBox;
    }
}