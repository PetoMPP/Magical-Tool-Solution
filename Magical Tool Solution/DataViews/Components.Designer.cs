
namespace Magical_Tool_Solution.DataViews
{
    partial class Components
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.componentsPanel = new System.Windows.Forms.Panel();
            this.componentsDataGridView = new System.Windows.Forms.DataGridView();
            this.keyComp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentD1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentD2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.componentsLabelPanel = new System.Windows.Forms.Panel();
            this.componentsLabel = new System.Windows.Forms.Label();
            this.componentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.componentsDataGridView)).BeginInit();
            this.componentsLabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // componentsPanel
            // 
            this.componentsPanel.Controls.Add(this.componentsDataGridView);
            this.componentsPanel.Controls.Add(this.componentsLabelPanel);
            this.componentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentsPanel.Location = new System.Drawing.Point(0, 0);
            this.componentsPanel.Name = "componentsPanel";
            this.componentsPanel.Padding = new System.Windows.Forms.Padding(8);
            this.componentsPanel.Size = new System.Drawing.Size(800, 450);
            this.componentsPanel.TabIndex = 0;
            // 
            // componentsDataGridView
            // 
            this.componentsDataGridView.AllowUserToAddRows = false;
            this.componentsDataGridView.AllowUserToDeleteRows = false;
            this.componentsDataGridView.AllowUserToOrderColumns = true;
            this.componentsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.componentsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.componentsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.componentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.componentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyComp,
            this.position,
            this.componentId,
            this.componentD1,
            this.componentD2,
            this.quantity});
            this.componentsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.componentsDataGridView.EnableHeadersVisualStyles = false;
            this.componentsDataGridView.Location = new System.Drawing.Point(8, 55);
            this.componentsDataGridView.Name = "componentsDataGridView";
            this.componentsDataGridView.RowHeadersVisible = false;
            this.componentsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.componentsDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.componentsDataGridView.RowTemplate.Height = 25;
            this.componentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.componentsDataGridView.ShowCellToolTips = false;
            this.componentsDataGridView.ShowEditingIcon = false;
            this.componentsDataGridView.Size = new System.Drawing.Size(784, 387);
            this.componentsDataGridView.TabIndex = 8;
            this.componentsDataGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ComponentsDataGridView_MouseDoubleClick);
            // 
            // keyComp
            // 
            this.keyComp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.keyComp.HeaderText = "Key Component";
            this.keyComp.Name = "keyComp";
            this.keyComp.Width = 108;
            // 
            // position
            // 
            this.position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.position.HeaderText = "Position";
            this.position.MaxInputLength = 5;
            this.position.Name = "position";
            this.position.ReadOnly = true;
            this.position.Width = 87;
            // 
            // componentId
            // 
            this.componentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.componentId.HeaderText = "Component Id";
            this.componentId.MaxInputLength = 10;
            this.componentId.Name = "componentId";
            this.componentId.ReadOnly = true;
            this.componentId.Width = 118;
            // 
            // componentD1
            // 
            this.componentD1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.componentD1.HeaderText = "Description";
            this.componentD1.MaxInputLength = 120;
            this.componentD1.Name = "componentD1";
            this.componentD1.ReadOnly = true;
            this.componentD1.Width = 108;
            // 
            // componentD2
            // 
            this.componentD2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.componentD2.HeaderText = "Manufacturer\'s Id";
            this.componentD2.MaxInputLength = 120;
            this.componentD2.Name = "componentD2";
            this.componentD2.ReadOnly = true;
            this.componentD2.Width = 135;
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantity.HeaderText = "Quantity";
            this.quantity.MaxInputLength = 10;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // componentsLabelPanel
            // 
            this.componentsLabelPanel.Controls.Add(this.componentsLabel);
            this.componentsLabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.componentsLabelPanel.Location = new System.Drawing.Point(8, 8);
            this.componentsLabelPanel.Name = "componentsLabelPanel";
            this.componentsLabelPanel.Size = new System.Drawing.Size(784, 47);
            this.componentsLabelPanel.TabIndex = 7;
            // 
            // componentsLabel
            // 
            this.componentsLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.componentsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentsLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.componentsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.componentsLabel.Location = new System.Drawing.Point(0, 0);
            this.componentsLabel.Name = "componentsLabel";
            this.componentsLabel.Padding = new System.Windows.Forms.Padding(5);
            this.componentsLabel.Size = new System.Drawing.Size(784, 47);
            this.componentsLabel.TabIndex = 5;
            this.componentsLabel.Text = "Tool\'s Components:";
            // 
            // Components
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.componentsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Components";
            this.ShowInTaskbar = false;
            this.Text = "Components";
            this.componentsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.componentsDataGridView)).EndInit();
            this.componentsLabelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel componentsPanel;
        private System.Windows.Forms.DataGridView componentsDataGridView;
        private System.Windows.Forms.Panel componentsLabelPanel;
        private System.Windows.Forms.Label componentsLabel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn keyComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn componentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn componentD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn componentD2;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
    }
}