
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
            this.MissingStockButton = new System.Windows.Forms.Button();
            this.MinimalStockButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 62);
            this.label1.TabIndex = 2;
            this.label1.Text = "MTS Dashboard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MissingStockButton
            // 
            this.MissingStockButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.MissingStockButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.MissingStockButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.MissingStockButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.MissingStockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MissingStockButton.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MissingStockButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MissingStockButton.Location = new System.Drawing.Point(50, 120);
            this.MissingStockButton.Name = "MissingStockButton";
            this.MissingStockButton.Size = new System.Drawing.Size(330, 210);
            this.MissingStockButton.TabIndex = 5;
            this.MissingStockButton.Text = "Uruchom Missing Stock Calculator";
            this.MissingStockButton.UseVisualStyleBackColor = false;
            this.MissingStockButton.Click += new System.EventHandler(this.MissingStockButton_Click);
            // 
            // MinimalStockButton
            // 
            this.MinimalStockButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.MinimalStockButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.MinimalStockButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.MinimalStockButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.MinimalStockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimalStockButton.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimalStockButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MinimalStockButton.Location = new System.Drawing.Point(420, 120);
            this.MinimalStockButton.Name = "MinimalStockButton";
            this.MinimalStockButton.Size = new System.Drawing.Size(330, 210);
            this.MinimalStockButton.TabIndex = 6;
            this.MinimalStockButton.Text = "Uruchom Minimal Stock Calculator";
            this.MinimalStockButton.UseVisualStyleBackColor = false;
            this.MinimalStockButton.Click += new System.EventHandler(this.MinimalStockButton_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(804, 451);
            this.Controls.Add(this.MinimalStockButton);
            this.Controls.Add(this.MissingStockButton);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MissingStockButton;
        private System.Windows.Forms.Button MinimalStockButton;
    }
}