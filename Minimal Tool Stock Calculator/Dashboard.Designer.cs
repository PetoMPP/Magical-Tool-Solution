
namespace Minimal_Tool_Stock_Calculator
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
            this.availableSectionsBox = new System.Windows.Forms.ListBox();
            this.launchInNewWindowButton = new System.Windows.Forms.Button();
            this.launchButton = new System.Windows.Forms.Button();
            this.availableModulesBox = new System.Windows.Forms.ListBox();
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
            this.label1.Size = new System.Drawing.Size(884, 62);
            this.label1.TabIndex = 2;
            this.label1.Text = "MTS Dashboard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // availableSectionsBox
            // 
            this.availableSectionsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.availableSectionsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.availableSectionsBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.availableSectionsBox.ForeColor = System.Drawing.Color.White;
            this.availableSectionsBox.FormattingEnabled = true;
            this.availableSectionsBox.ItemHeight = 32;
            this.availableSectionsBox.Location = new System.Drawing.Point(0, 65);
            this.availableSectionsBox.Name = "availableSectionsBox";
            this.availableSectionsBox.Size = new System.Drawing.Size(454, 386);
            this.availableSectionsBox.TabIndex = 6;
            this.availableSectionsBox.SelectedIndexChanged += new System.EventHandler(this.availableSectionsBox_SelectedIndexChanged);
            // 
            // launchInNewWindowButton
            // 
            this.launchInNewWindowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.launchInNewWindowButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.launchInNewWindowButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.launchInNewWindowButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.launchInNewWindowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchInNewWindowButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.launchInNewWindowButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.launchInNewWindowButton.Location = new System.Drawing.Point(460, 372);
            this.launchInNewWindowButton.Name = "launchInNewWindowButton";
            this.launchInNewWindowButton.Size = new System.Drawing.Size(140, 67);
            this.launchInNewWindowButton.TabIndex = 8;
            this.launchInNewWindowButton.Text = "Uruchom moduł w nowym oknie";
            this.launchInNewWindowButton.UseVisualStyleBackColor = false;
            this.launchInNewWindowButton.Click += new System.EventHandler(this.LaunchInNewWindowButton_Click);
            // 
            // launchButton
            // 
            this.launchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.launchButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.launchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.launchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.launchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.launchButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.launchButton.Location = new System.Drawing.Point(732, 372);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(140, 67);
            this.launchButton.TabIndex = 9;
            this.launchButton.Text = "Uruchom moduł";
            this.launchButton.UseVisualStyleBackColor = false;
            this.launchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // availableModulesBox
            // 
            this.availableModulesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.availableModulesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.availableModulesBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.availableModulesBox.ForeColor = System.Drawing.Color.White;
            this.availableModulesBox.FormattingEnabled = true;
            this.availableModulesBox.ItemHeight = 32;
            this.availableModulesBox.Location = new System.Drawing.Point(460, 65);
            this.availableModulesBox.Name = "availableModulesBox";
            this.availableModulesBox.Size = new System.Drawing.Size(424, 290);
            this.availableModulesBox.TabIndex = 7;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(884, 451);
            this.Controls.Add(this.availableSectionsBox);
            this.Controls.Add(this.launchInNewWindowButton);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.availableModulesBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox availableSectionsBox;
        private System.Windows.Forms.Button launchInNewWindowButton;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.ListBox availableModulesBox;
    }
}