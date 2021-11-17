
namespace Magical_Tool_Solution.ToolStockCalculations
{
    partial class CalculationWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.availableListBox = new System.Windows.Forms.CheckedListBox();
            this.moduleNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.filterAvailableBox = new System.Windows.Forms.TextBox();
            this.moduleDescriptionLabel = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.selectedListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.filterSelectedBox = new System.Windows.Forms.TextBox();
            this.deselectAllSelectedButton = new System.Windows.Forms.Button();
            this.selectAllSelectedButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.moveSelectedToAvailable = new System.Windows.Forms.Button();
            this.moveSelectedToSelected = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.deselectAllAvailAbleButton = new System.Windows.Forms.Button();
            this.selectAllAvailableButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // availableListBox
            // 
            this.availableListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.availableListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.availableListBox.FormattingEnabled = true;
            this.availableListBox.Location = new System.Drawing.Point(12, 321);
            this.availableListBox.Name = "availableListBox";
            this.availableListBox.Size = new System.Drawing.Size(258, 508);
            this.availableListBox.TabIndex = 0;
            // 
            // moduleNameLabel
            // 
            this.moduleNameLabel.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.moduleNameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.moduleNameLabel.Location = new System.Drawing.Point(12, 9);
            this.moduleNameLabel.Name = "moduleNameLabel";
            this.moduleNameLabel.Size = new System.Drawing.Size(977, 62);
            this.moduleNameLabel.TabIndex = 1;
            this.moduleNameLabel.Text = "<Module Name>";
            this.moduleNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filtruj:";
            // 
            // filterAvailableBox
            // 
            this.filterAvailableBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterAvailableBox.Location = new System.Drawing.Point(71, 289);
            this.filterAvailableBox.Name = "filterAvailableBox";
            this.filterAvailableBox.Size = new System.Drawing.Size(199, 29);
            this.filterAvailableBox.TabIndex = 3;
            // 
            // moduleDescriptionLabel
            // 
            this.moduleDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.moduleDescriptionLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.moduleDescriptionLabel.Location = new System.Drawing.Point(12, 71);
            this.moduleDescriptionLabel.Name = "moduleDescriptionLabel";
            this.moduleDescriptionLabel.Size = new System.Drawing.Size(645, 97);
            this.moduleDescriptionLabel.TabIndex = 1;
            this.moduleDescriptionLabel.Text = "<Module Description>";
            // 
            // selectedListBox
            // 
            this.selectedListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.selectedListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedListBox.FormattingEnabled = true;
            this.selectedListBox.Location = new System.Drawing.Point(398, 321);
            this.selectedListBox.Name = "selectedListBox";
            this.selectedListBox.Size = new System.Drawing.Size(258, 508);
            this.selectedListBox.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(399, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Filtruj:";
            // 
            // filterSelectedBox
            // 
            this.filterSelectedBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterSelectedBox.Location = new System.Drawing.Point(458, 289);
            this.filterSelectedBox.Name = "filterSelectedBox";
            this.filterSelectedBox.Size = new System.Drawing.Size(199, 29);
            this.filterSelectedBox.TabIndex = 3;
            // 
            // deselectAllSelectedButton
            // 
            this.deselectAllSelectedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.deselectAllSelectedButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.deselectAllSelectedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.deselectAllSelectedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.deselectAllSelectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deselectAllSelectedButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deselectAllSelectedButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deselectAllSelectedButton.Location = new System.Drawing.Point(549, 213);
            this.deselectAllSelectedButton.Name = "deselectAllSelectedButton";
            this.deselectAllSelectedButton.Size = new System.Drawing.Size(108, 60);
            this.deselectAllSelectedButton.TabIndex = 4;
            this.deselectAllSelectedButton.Text = "Odznacz wszystko";
            this.deselectAllSelectedButton.UseVisualStyleBackColor = false;
            // 
            // selectAllSelectedButton
            // 
            this.selectAllSelectedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.selectAllSelectedButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.selectAllSelectedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.selectAllSelectedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.selectAllSelectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAllSelectedButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectAllSelectedButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectAllSelectedButton.Location = new System.Drawing.Point(399, 213);
            this.selectAllSelectedButton.Name = "selectAllSelectedButton";
            this.selectAllSelectedButton.Size = new System.Drawing.Size(108, 60);
            this.selectAllSelectedButton.TabIndex = 4;
            this.selectAllSelectedButton.Text = "Zaznacz wszystko";
            this.selectAllSelectedButton.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(12, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 42);
            this.label5.TabIndex = 1;
            this.label5.Text = "Dostępne komponenty:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(399, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 42);
            this.label6.TabIndex = 1;
            this.label6.Text = "Wybrane komponenty:";
            // 
            // moveSelectedToAvailable
            // 
            this.moveSelectedToAvailable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.moveSelectedToAvailable.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.moveSelectedToAvailable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.moveSelectedToAvailable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.moveSelectedToAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveSelectedToAvailable.Font = new System.Drawing.Font("Webdings", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.moveSelectedToAvailable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.moveSelectedToAvailable.Location = new System.Drawing.Point(304, 562);
            this.moveSelectedToAvailable.Name = "moveSelectedToAvailable";
            this.moveSelectedToAvailable.Size = new System.Drawing.Size(60, 60);
            this.moveSelectedToAvailable.TabIndex = 4;
            this.moveSelectedToAvailable.Text = "3";
            this.moveSelectedToAvailable.UseVisualStyleBackColor = false;
            // 
            // moveSelectedToSelected
            // 
            this.moveSelectedToSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.moveSelectedToSelected.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.moveSelectedToSelected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.moveSelectedToSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.moveSelectedToSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveSelectedToSelected.Font = new System.Drawing.Font("Webdings", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.moveSelectedToSelected.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.moveSelectedToSelected.Location = new System.Drawing.Point(304, 483);
            this.moveSelectedToSelected.Name = "moveSelectedToSelected";
            this.moveSelectedToSelected.Size = new System.Drawing.Size(60, 60);
            this.moveSelectedToSelected.TabIndex = 4;
            this.moveSelectedToSelected.Text = "4";
            this.moveSelectedToSelected.UseVisualStyleBackColor = false;
            // 
            // CalculateButton
            // 
            this.CalculateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CalculateButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.CalculateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.CalculateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.CalculateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CalculateButton.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CalculateButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CalculateButton.Location = new System.Drawing.Point(696, 439);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(293, 139);
            this.CalculateButton.TabIndex = 4;
            this.CalculateButton.Text = "Oblicz wybrane!";
            this.CalculateButton.UseVisualStyleBackColor = false;
            // 
            // deselectAllAvailAbleButton
            // 
            this.deselectAllAvailAbleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.deselectAllAvailAbleButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.deselectAllAvailAbleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.deselectAllAvailAbleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.deselectAllAvailAbleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deselectAllAvailAbleButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deselectAllAvailAbleButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deselectAllAvailAbleButton.Location = new System.Drawing.Point(162, 213);
            this.deselectAllAvailAbleButton.Name = "deselectAllAvailAbleButton";
            this.deselectAllAvailAbleButton.Size = new System.Drawing.Size(108, 60);
            this.deselectAllAvailAbleButton.TabIndex = 4;
            this.deselectAllAvailAbleButton.Text = "Odznacz wszystko";
            this.deselectAllAvailAbleButton.UseVisualStyleBackColor = false;
            // 
            // selectAllAvailableButton
            // 
            this.selectAllAvailableButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.selectAllAvailableButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.selectAllAvailableButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.selectAllAvailableButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.selectAllAvailableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAllAvailableButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectAllAvailableButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectAllAvailableButton.Location = new System.Drawing.Point(12, 213);
            this.selectAllAvailableButton.Name = "selectAllAvailableButton";
            this.selectAllAvailableButton.Size = new System.Drawing.Size(108, 60);
            this.selectAllAvailableButton.TabIndex = 4;
            this.selectAllAvailableButton.Text = "Zaznacz wszystko";
            this.selectAllAvailableButton.UseVisualStyleBackColor = false;
            // 
            // CalculationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1004, 841);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.selectAllSelectedButton);
            this.Controls.Add(this.selectAllAvailableButton);
            this.Controls.Add(this.deselectAllSelectedButton);
            this.Controls.Add(this.moveSelectedToSelected);
            this.Controls.Add(this.moveSelectedToAvailable);
            this.Controls.Add(this.deselectAllAvailAbleButton);
            this.Controls.Add(this.filterSelectedBox);
            this.Controls.Add(this.filterAvailableBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.moduleDescriptionLabel);
            this.Controls.Add(this.moduleNameLabel);
            this.Controls.Add(this.selectedListBox);
            this.Controls.Add(this.availableListBox);
            this.MaximizeBox = false;
            this.Name = "CalculationWindow";
            this.Text = "Minimal Tool Stock Calculator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RestoreCaller);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox availableListBox;
        private System.Windows.Forms.Label moduleNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filterAvailableBox;
        private System.Windows.Forms.Label moduleDescriptionLabel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.CheckedListBox selectedListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox filterSelectedBox;
        private System.Windows.Forms.Button deselectAllSelectedButton;
        private System.Windows.Forms.Button selectAllSelectedButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button moveSelectedToAvailable;
        private System.Windows.Forms.Button moveSelectedToSelected;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Button deselectAllAvailAbleButton;
        private System.Windows.Forms.Button selectAllAvailableButton;
    }
}

