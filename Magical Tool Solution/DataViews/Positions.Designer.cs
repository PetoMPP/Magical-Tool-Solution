
namespace Magical_Tool_Solution.DataViews
{
    partial class Positions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.componentsPanel = new System.Windows.Forms.Panel();
            this.positionsDataGridView = new System.Windows.Forms.DataGridView();
            this.componentsLabelPanel = new System.Windows.Forms.Panel();
            this.toolsLabel = new System.Windows.Forms.Label();
            this.componentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionsDataGridView)).BeginInit();
            this.componentsLabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // componentsPanel
            // 
            this.componentsPanel.Controls.Add(this.positionsDataGridView);
            this.componentsPanel.Controls.Add(this.componentsLabelPanel);
            this.componentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentsPanel.Location = new System.Drawing.Point(0, 0);
            this.componentsPanel.Name = "componentsPanel";
            this.componentsPanel.Padding = new System.Windows.Forms.Padding(8);
            this.componentsPanel.Size = new System.Drawing.Size(800, 450);
            this.componentsPanel.TabIndex = 1;
            // 
            // positionsDataGridView
            // 
            this.positionsDataGridView.AllowUserToAddRows = false;
            this.positionsDataGridView.AllowUserToDeleteRows = false;
            this.positionsDataGridView.AllowUserToOrderColumns = true;
            this.positionsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.positionsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.positionsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.positionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.positionsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.positionsDataGridView.EnableHeadersVisualStyles = false;
            this.positionsDataGridView.Location = new System.Drawing.Point(8, 55);
            this.positionsDataGridView.Name = "positionsDataGridView";
            this.positionsDataGridView.RowHeadersVisible = false;
            this.positionsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.positionsDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.positionsDataGridView.RowTemplate.Height = 25;
            this.positionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.positionsDataGridView.ShowCellToolTips = false;
            this.positionsDataGridView.ShowEditingIcon = false;
            this.positionsDataGridView.Size = new System.Drawing.Size(784, 387);
            this.positionsDataGridView.TabIndex = 8;
            this.positionsDataGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PositionsDataGridView_MouseDoubleClick);
            // 
            // componentsLabelPanel
            // 
            this.componentsLabelPanel.Controls.Add(this.toolsLabel);
            this.componentsLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.componentsLabelPanel.Location = new System.Drawing.Point(8, 8);
            this.componentsLabelPanel.Name = "componentsLabelPanel";
            this.componentsLabelPanel.Size = new System.Drawing.Size(784, 47);
            this.componentsLabelPanel.TabIndex = 7;
            // 
            // toolsLabel
            // 
            this.toolsLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.toolsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolsLabel.Location = new System.Drawing.Point(0, 0);
            this.toolsLabel.Name = "toolsLabel";
            this.toolsLabel.Padding = new System.Windows.Forms.Padding(5);
            this.toolsLabel.Size = new System.Drawing.Size(784, 47);
            this.toolsLabel.TabIndex = 5;
            this.toolsLabel.Text = "Tool List Positions:";
            // 
            // Positions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.componentsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Positions";
            this.ShowInTaskbar = false;
            this.Text = "Tools";
            this.TopMost = true;
            this.componentsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.positionsDataGridView)).EndInit();
            this.componentsLabelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel componentsPanel;
        private System.Windows.Forms.DataGridView positionsDataGridView;
        private System.Windows.Forms.Panel componentsLabelPanel;
        private System.Windows.Forms.Label toolsLabel;
    }
}