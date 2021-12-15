
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.availableSectionsBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.availableModulesBox = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.launchInNewWindowButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.launchButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(624, 62);
            this.label1.TabIndex = 2;
            this.label1.Text = "MTS Dashboard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.availableSectionsBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 379);
            this.panel1.TabIndex = 10;
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
            this.availableSectionsBox.Size = new System.Drawing.Size(280, 379);
            this.availableSectionsBox.TabIndex = 8;
            this.availableSectionsBox.SelectedIndexChanged += new System.EventHandler(this.AvailableSectionsBox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.availableModulesBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(280, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 304);
            this.panel2.TabIndex = 12;
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
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(280, 366);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(344, 75);
            this.panel3.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.launchInNewWindowButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(148, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(6);
            this.panel5.Size = new System.Drawing.Size(148, 75);
            this.panel5.TabIndex = 11;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.launchButton);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(6);
            this.panel4.Size = new System.Drawing.Size(148, 75);
            this.panel4.TabIndex = 10;
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
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox availableModulesBox;
        private System.Windows.Forms.Button launchInNewWindowButton;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox availableSectionsBox;
    }
}