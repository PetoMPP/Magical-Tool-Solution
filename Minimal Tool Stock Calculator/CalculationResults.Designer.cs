
namespace Minimal_Tool_Stock_Calculator
{
    partial class CalculationResults
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
            this.filterAvailableBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.calculationResultListBox = new System.Windows.Forms.CheckedListBox();
            this.showSelectedButton = new System.Windows.Forms.Button();
            this.showDeselectedButton = new System.Windows.Forms.Button();
            this.exportToCsv = new System.Windows.Forms.Button();
            this.exportToTDM = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.deselectAllButton = new System.Windows.Forms.Button();
            this.returnToCalculationScreenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(847, 62);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wyniki kalkulacji";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // filterAvailableBox
            // 
            this.filterAvailableBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterAvailableBox.Location = new System.Drawing.Point(71, 163);
            this.filterAvailableBox.Name = "filterAvailableBox";
            this.filterAvailableBox.Size = new System.Drawing.Size(484, 29);
            this.filterAvailableBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filtruj:";
            // 
            // calculationResultListBox
            // 
            this.calculationResultListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.calculationResultListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.calculationResultListBox.FormattingEnabled = true;
            this.calculationResultListBox.Location = new System.Drawing.Point(12, 195);
            this.calculationResultListBox.Name = "calculationResultListBox";
            this.calculationResultListBox.Size = new System.Drawing.Size(543, 508);
            this.calculationResultListBox.TabIndex = 4;
            // 
            // showSelectedButton
            // 
            this.showSelectedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.showSelectedButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.showSelectedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.showSelectedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.showSelectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showSelectedButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showSelectedButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.showSelectedButton.Location = new System.Drawing.Point(294, 97);
            this.showSelectedButton.Name = "showSelectedButton";
            this.showSelectedButton.Size = new System.Drawing.Size(120, 60);
            this.showSelectedButton.TabIndex = 7;
            this.showSelectedButton.Text = "Pokaż zaznaczone";
            this.showSelectedButton.UseVisualStyleBackColor = false;
            // 
            // showDeselectedButton
            // 
            this.showDeselectedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.showDeselectedButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.showDeselectedButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.showDeselectedButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.showDeselectedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showDeselectedButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showDeselectedButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.showDeselectedButton.Location = new System.Drawing.Point(435, 97);
            this.showDeselectedButton.Name = "showDeselectedButton";
            this.showDeselectedButton.Size = new System.Drawing.Size(120, 60);
            this.showDeselectedButton.TabIndex = 8;
            this.showDeselectedButton.Text = "Pokaż niezaznaczone";
            this.showDeselectedButton.UseVisualStyleBackColor = false;
            // 
            // exportToCsv
            // 
            this.exportToCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exportToCsv.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.exportToCsv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.exportToCsv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.exportToCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportToCsv.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exportToCsv.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exportToCsv.Location = new System.Drawing.Point(598, 294);
            this.exportToCsv.Name = "exportToCsv";
            this.exportToCsv.Size = new System.Drawing.Size(224, 109);
            this.exportToCsv.TabIndex = 8;
            this.exportToCsv.Text = "Wyeksportuj do pliku *.csv";
            this.exportToCsv.UseVisualStyleBackColor = false;
            // 
            // exportToTDM
            // 
            this.exportToTDM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exportToTDM.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.exportToTDM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.exportToTDM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.exportToTDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportToTDM.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exportToTDM.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exportToTDM.Location = new System.Drawing.Point(598, 428);
            this.exportToTDM.Name = "exportToTDM";
            this.exportToTDM.Size = new System.Drawing.Size(224, 109);
            this.exportToTDM.TabIndex = 8;
            this.exportToTDM.Text = "Dodaj wyniki do bazy danych";
            this.exportToTDM.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(561, 166);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(298, 105);
            this.label5.TabIndex = 9;
            this.label5.Text = "Poniższe działania biorą pod uwagę tylko zaznaczone komponenty";
            // 
            // selectAllButton
            // 
            this.selectAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.selectAllButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.selectAllButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.selectAllButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.selectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectAllButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectAllButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectAllButton.Location = new System.Drawing.Point(12, 97);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(120, 60);
            this.selectAllButton.TabIndex = 10;
            this.selectAllButton.Text = "Zaznacz wszystko";
            this.selectAllButton.UseVisualStyleBackColor = false;
            // 
            // deselectAllButton
            // 
            this.deselectAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.deselectAllButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.deselectAllButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.deselectAllButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.deselectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deselectAllButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deselectAllButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.deselectAllButton.Location = new System.Drawing.Point(153, 97);
            this.deselectAllButton.Name = "deselectAllButton";
            this.deselectAllButton.Size = new System.Drawing.Size(120, 60);
            this.deselectAllButton.TabIndex = 11;
            this.deselectAllButton.Text = "Odznacz wszystko";
            this.deselectAllButton.UseVisualStyleBackColor = false;
            // 
            // returnToCalculationScreenButton
            // 
            this.returnToCalculationScreenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.returnToCalculationScreenButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.returnToCalculationScreenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.returnToCalculationScreenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.returnToCalculationScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnToCalculationScreenButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.returnToCalculationScreenButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.returnToCalculationScreenButton.Location = new System.Drawing.Point(598, 562);
            this.returnToCalculationScreenButton.Name = "returnToCalculationScreenButton";
            this.returnToCalculationScreenButton.Size = new System.Drawing.Size(224, 109);
            this.returnToCalculationScreenButton.TabIndex = 8;
            this.returnToCalculationScreenButton.Text = "Powrót do ekranu kalkulacji";
            this.returnToCalculationScreenButton.UseVisualStyleBackColor = false;
            this.returnToCalculationScreenButton.Click += new System.EventHandler(this.returnToCalculationScreenButton_Click);
            // 
            // CalculationResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(874, 711);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.deselectAllButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.showSelectedButton);
            this.Controls.Add(this.returnToCalculationScreenButton);
            this.Controls.Add(this.exportToTDM);
            this.Controls.Add(this.exportToCsv);
            this.Controls.Add(this.showDeselectedButton);
            this.Controls.Add(this.filterAvailableBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calculationResultListBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(890, 750);
            this.MinimumSize = new System.Drawing.Size(890, 750);
            this.Name = "CalculationResults";
            this.Text = "CalculationResults";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RestoreParentCaller);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filterAvailableBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox calculationResultListBox;
        private System.Windows.Forms.Button showSelectedButton;
        private System.Windows.Forms.Button showDeselectedButton;
        private System.Windows.Forms.Button exportToCsv;
        private System.Windows.Forms.Button exportToTDM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button deselectAllButton;
        private System.Windows.Forms.Button returnToCalculationScreenButton;
    }
}