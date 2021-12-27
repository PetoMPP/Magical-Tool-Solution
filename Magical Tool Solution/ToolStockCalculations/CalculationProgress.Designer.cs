
namespace Magical_Tool_Solution.ToolStockCalculations
{
    partial class CalculationProgress
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
            this.calculatingDescriptionLabel = new System.Windows.Forms.Label();
            this.calculatingNameLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.calculationOutputBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.showResultsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calculatingDescriptionLabel
            // 
            this.calculatingDescriptionLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.calculatingDescriptionLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.calculatingDescriptionLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.calculatingDescriptionLabel.Location = new System.Drawing.Point(0, 78);
            this.calculatingDescriptionLabel.Name = "calculatingDescriptionLabel";
            this.calculatingDescriptionLabel.Padding = new System.Windows.Forms.Padding(10);
            this.calculatingDescriptionLabel.Size = new System.Drawing.Size(800, 86);
            this.calculatingDescriptionLabel.TabIndex = 2;
            this.calculatingDescriptionLabel.Text = "<Module Description>";
            // 
            // calculatingNameLabel
            // 
            this.calculatingNameLabel.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.calculatingNameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.calculatingNameLabel.Location = new System.Drawing.Point(0, 0);
            this.calculatingNameLabel.Name = "calculatingNameLabel";
            this.calculatingNameLabel.Padding = new System.Windows.Forms.Padding(10);
            this.calculatingNameLabel.Size = new System.Drawing.Size(800, 78);
            this.calculatingNameLabel.TabIndex = 3;
            this.calculatingNameLabel.Text = "<Module Name>";
            this.calculatingNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(222)))), ((int)(((byte)(0)))));
            this.progressBar.Location = new System.Drawing.Point(150, 402);
            this.progressBar.Margin = new System.Windows.Forms.Padding(10);
            this.progressBar.MarqueeAnimationSpeed = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(500, 20);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 4;
            // 
            // progressLabel
            // 
            this.progressLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.progressLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressLabel.Location = new System.Drawing.Point(0, 334);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Padding = new System.Windows.Forms.Padding(10);
            this.progressLabel.Size = new System.Drawing.Size(800, 58);
            this.progressLabel.TabIndex = 2;
            this.progressLabel.Text = "x% <cur>/<tot>";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // calculationOutputBox
            // 
            this.calculationOutputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.calculationOutputBox.ForeColor = System.Drawing.SystemColors.Window;
            this.calculationOutputBox.Location = new System.Drawing.Point(12, 167);
            this.calculationOutputBox.Multiline = true;
            this.calculationOutputBox.Name = "calculationOutputBox";
            this.calculationOutputBox.ReadOnly = true;
            this.calculationOutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.calculationOutputBox.Size = new System.Drawing.Size(776, 164);
            this.calculationOutputBox.TabIndex = 5;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.closeButton.Enabled = false;
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.closeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.closeButton.Location = new System.Drawing.Point(668, 447);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(120, 60);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Wróć";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelButton.Location = new System.Drawing.Point(530, 447);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 60);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // showResultsButton
            // 
            this.showResultsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.showResultsButton.Enabled = false;
            this.showResultsButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.showResultsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.showResultsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.showResultsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showResultsButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showResultsButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.showResultsButton.Location = new System.Drawing.Point(392, 447);
            this.showResultsButton.Name = "showResultsButton";
            this.showResultsButton.Size = new System.Drawing.Size(120, 60);
            this.showResultsButton.TabIndex = 8;
            this.showResultsButton.Text = "Przejdź do wyników";
            this.showResultsButton.UseVisualStyleBackColor = false;
            this.showResultsButton.Click += new System.EventHandler(this.ShowResultsButton_Click);
            // 
            // CalculationProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 519);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.showResultsButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.calculationOutputBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.calculatingDescriptionLabel);
            this.Controls.Add(this.calculatingNameLabel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculationProgress";
            this.Text = "CalculationProgress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label calculatingDescriptionLabel;
        private System.Windows.Forms.Label calculatingNameLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.TextBox calculationOutputBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button showResultsButton;
    }
}