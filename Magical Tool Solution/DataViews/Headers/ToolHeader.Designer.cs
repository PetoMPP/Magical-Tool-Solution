
namespace Magical_Tool_Solution.DataViews.Headers
{
    partial class ToolHeader
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
            this.viewComponentsButton = new System.Windows.Forms.Button();
            this.parametersButtonPanel = new System.Windows.Forms.Panel();
            this.viewParametersButton = new System.Windows.Forms.Button();
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
            this.connectionsButtonPanel.Controls.Add(this.viewComponentsButton);
            this.connectionsButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.connectionsButtonPanel.Location = new System.Drawing.Point(138, 0);
            this.connectionsButtonPanel.Name = "connectionsButtonPanel";
            this.connectionsButtonPanel.Padding = new System.Windows.Forms.Padding(1, 6, 1, 0);
            this.connectionsButtonPanel.Size = new System.Drawing.Size(138, 39);
            this.connectionsButtonPanel.TabIndex = 17;
            // 
            // viewComponentsButton
            // 
            this.viewComponentsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.viewComponentsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewComponentsButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.viewComponentsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.viewComponentsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.viewComponentsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewComponentsButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viewComponentsButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.viewComponentsButton.Location = new System.Drawing.Point(1, 6);
            this.viewComponentsButton.Margin = new System.Windows.Forms.Padding(8);
            this.viewComponentsButton.Name = "viewComponentsButton";
            this.viewComponentsButton.Size = new System.Drawing.Size(136, 33);
            this.viewComponentsButton.TabIndex = 8;
            this.viewComponentsButton.Text = "Components";
            this.viewComponentsButton.UseVisualStyleBackColor = false;
            this.viewComponentsButton.Click += new System.EventHandler(this.ViewComponentsButton_Click);
            // 
            // parametersButtonPanel
            // 
            this.parametersButtonPanel.Controls.Add(this.viewParametersButton);
            this.parametersButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.parametersButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.parametersButtonPanel.Name = "parametersButtonPanel";
            this.parametersButtonPanel.Padding = new System.Windows.Forms.Padding(1, 6, 1, 0);
            this.parametersButtonPanel.Size = new System.Drawing.Size(138, 39);
            this.parametersButtonPanel.TabIndex = 16;
            // 
            // viewParametersButton
            // 
            this.viewParametersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.viewParametersButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewParametersButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.viewParametersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.viewParametersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.viewParametersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewParametersButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viewParametersButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.viewParametersButton.Location = new System.Drawing.Point(1, 6);
            this.viewParametersButton.Margin = new System.Windows.Forms.Padding(8);
            this.viewParametersButton.Name = "viewParametersButton";
            this.viewParametersButton.Size = new System.Drawing.Size(136, 33);
            this.viewParametersButton.TabIndex = 8;
            this.viewParametersButton.Text = "Parameters";
            this.viewParametersButton.UseVisualStyleBackColor = false;
            this.viewParametersButton.Click += new System.EventHandler(this.ViewParametersButton_Click);
            // 
            // ToolHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 39);
            this.ControlBox = false;
            this.Controls.Add(this.viewSwitcherPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToolHeader";
            this.ShowInTaskbar = false;
            this.Text = "ToolHeader";
            this.TopMost = true;
            this.viewSwitcherPanel.ResumeLayout(false);
            this.connectionsButtonPanel.ResumeLayout(false);
            this.parametersButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel viewSwitcherPanel;
        private System.Windows.Forms.Panel connectionsButtonPanel;
        private System.Windows.Forms.Button viewComponentsButton;
        private System.Windows.Forms.Panel parametersButtonPanel;
        private System.Windows.Forms.Button viewParametersButton;
    }
}