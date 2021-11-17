
namespace Magical_Tool_Solution.DataViews.Headers
{
    partial class ListHeader
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
            this.viewSwitcherPanel = new System.Windows.Forms.Panel();
            this.connectionsButtonPanel = new System.Windows.Forms.Panel();
            this.viewFileManagementButton = new System.Windows.Forms.Button();
            this.parametersButtonPanel = new System.Windows.Forms.Panel();
            this.viewToolsButton = new System.Windows.Forms.Button();
            this.viewSwitcherPanel.SuspendLayout();
            this.connectionsButtonPanel.SuspendLayout();
            this.parametersButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewSwitcherPanel
            // 
            this.viewSwitcherPanel.Controls.Add(this.connectionsButtonPanel);
            this.viewSwitcherPanel.Controls.Add(this.parametersButtonPanel);
            this.viewSwitcherPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewSwitcherPanel.Location = new System.Drawing.Point(0, 0);
            this.viewSwitcherPanel.Name = "viewSwitcherPanel";
            this.viewSwitcherPanel.Size = new System.Drawing.Size(800, 39);
            this.viewSwitcherPanel.TabIndex = 3;
            // 
            // connectionsButtonPanel
            // 
            this.connectionsButtonPanel.Controls.Add(this.viewFileManagementButton);
            this.connectionsButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.connectionsButtonPanel.Location = new System.Drawing.Point(138, 0);
            this.connectionsButtonPanel.Name = "connectionsButtonPanel";
            this.connectionsButtonPanel.Padding = new System.Windows.Forms.Padding(1, 6, 1, 0);
            this.connectionsButtonPanel.Size = new System.Drawing.Size(138, 39);
            this.connectionsButtonPanel.TabIndex = 17;
            // 
            // viewFileManagementButton
            // 
            this.viewFileManagementButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.viewFileManagementButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewFileManagementButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.viewFileManagementButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.viewFileManagementButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.viewFileManagementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewFileManagementButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viewFileManagementButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.viewFileManagementButton.Location = new System.Drawing.Point(1, 6);
            this.viewFileManagementButton.Margin = new System.Windows.Forms.Padding(8);
            this.viewFileManagementButton.Name = "viewFileManagementButton";
            this.viewFileManagementButton.Size = new System.Drawing.Size(136, 33);
            this.viewFileManagementButton.TabIndex = 8;
            this.viewFileManagementButton.Text = "File management";
            this.viewFileManagementButton.UseVisualStyleBackColor = false;
            this.viewFileManagementButton.Click += new System.EventHandler(this.ViewFileManagementButton_Click);
            // 
            // parametersButtonPanel
            // 
            this.parametersButtonPanel.Controls.Add(this.viewToolsButton);
            this.parametersButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.parametersButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.parametersButtonPanel.Name = "parametersButtonPanel";
            this.parametersButtonPanel.Padding = new System.Windows.Forms.Padding(1, 6, 1, 0);
            this.parametersButtonPanel.Size = new System.Drawing.Size(138, 39);
            this.parametersButtonPanel.TabIndex = 16;
            // 
            // viewToolsButton
            // 
            this.viewToolsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.viewToolsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewToolsButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.viewToolsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.viewToolsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.viewToolsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewToolsButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viewToolsButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.viewToolsButton.Location = new System.Drawing.Point(1, 6);
            this.viewToolsButton.Margin = new System.Windows.Forms.Padding(8);
            this.viewToolsButton.Name = "viewToolsButton";
            this.viewToolsButton.Size = new System.Drawing.Size(136, 33);
            this.viewToolsButton.TabIndex = 8;
            this.viewToolsButton.Text = "Tools";
            this.viewToolsButton.UseVisualStyleBackColor = false;
            this.viewToolsButton.Click += new System.EventHandler(this.ViewToolsButton_Click);
            // 
            // ListHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 39);
            this.ControlBox = false;
            this.Controls.Add(this.viewSwitcherPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListHeader";
            this.ShowInTaskbar = false;
            this.Text = "ListHeader";
            this.TopMost = true;
            this.viewSwitcherPanel.ResumeLayout(false);
            this.connectionsButtonPanel.ResumeLayout(false);
            this.parametersButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel viewSwitcherPanel;
        private System.Windows.Forms.Panel connectionsButtonPanel;
        private System.Windows.Forms.Button viewFileManagementButton;
        private System.Windows.Forms.Panel parametersButtonPanel;
        private System.Windows.Forms.Button viewToolsButton;
    }
}