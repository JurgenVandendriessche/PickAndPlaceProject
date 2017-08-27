/*  Copyright (C) 2017  Jurgen Vandendriessche

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace PickAndPlaceDatabaseManager
{
    partial class DatabaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseForm));
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.clbColumnsDisplay = new System.Windows.Forms.CheckedListBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgvFootprints = new System.Windows.Forms.DataGridView();
            this.pnlDgvFootprints = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblShownColumns = new System.Windows.Forms.Label();
            this.pnlTransfer = new System.Windows.Forms.Panel();
            this.pbTransfer = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFootprints)).BeginInit();
            this.pnlDgvFootprints.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.pnlTransfer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(140, 91);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear filter";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(29, 91);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(29, 47);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(140, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(29, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add new";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // clbColumnsDisplay
            // 
            this.clbColumnsDisplay.CheckOnClick = true;
            this.clbColumnsDisplay.FormattingEnabled = true;
            this.clbColumnsDisplay.Location = new System.Drawing.Point(29, 153);
            this.clbColumnsDisplay.Name = "clbColumnsDisplay";
            this.clbColumnsDisplay.Size = new System.Drawing.Size(186, 244);
            this.clbColumnsDisplay.TabIndex = 7;
            this.clbColumnsDisplay.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbColumnsDisplay_ItemCheck);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(140, 47);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvFootprints
            // 
            this.dgvFootprints.AllowUserToAddRows = false;
            this.dgvFootprints.AllowUserToDeleteRows = false;
            this.dgvFootprints.AllowUserToOrderColumns = true;
            this.dgvFootprints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFootprints.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFootprints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFootprints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFootprints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFootprints.Location = new System.Drawing.Point(7, 7);
            this.dgvFootprints.MultiSelect = false;
            this.dgvFootprints.Name = "dgvFootprints";
            this.dgvFootprints.ReadOnly = true;
            this.dgvFootprints.RowHeadersVisible = false;
            this.dgvFootprints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFootprints.Size = new System.Drawing.Size(895, 464);
            this.dgvFootprints.TabIndex = 8;
            this.dgvFootprints.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFootprints_CellDoubleClick);
            this.dgvFootprints.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFootprints_KeyDown);
            // 
            // pnlDgvFootprints
            // 
            this.pnlDgvFootprints.Controls.Add(this.dgvFootprints);
            this.pnlDgvFootprints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgvFootprints.Location = new System.Drawing.Point(0, 0);
            this.pnlDgvFootprints.Name = "pnlDgvFootprints";
            this.pnlDgvFootprints.Padding = new System.Windows.Forms.Padding(7);
            this.pnlDgvFootprints.Size = new System.Drawing.Size(909, 478);
            this.pnlDgvFootprints.TabIndex = 9;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.clbColumnsDisplay);
            this.pnlControls.Controls.Add(this.lblShownColumns);
            this.pnlControls.Controls.Add(this.btnAdd);
            this.pnlControls.Controls.Add(this.btnImport);
            this.pnlControls.Controls.Add(this.btnDelete);
            this.pnlControls.Controls.Add(this.btnClear);
            this.pnlControls.Controls.Add(this.btnEdit);
            this.pnlControls.Controls.Add(this.btnFilter);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControls.Location = new System.Drawing.Point(909, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(235, 478);
            this.pnlControls.TabIndex = 10;
            // 
            // lblShownColumns
            // 
            this.lblShownColumns.AutoSize = true;
            this.lblShownColumns.Location = new System.Drawing.Point(29, 134);
            this.lblShownColumns.Name = "lblShownColumns";
            this.lblShownColumns.Size = new System.Drawing.Size(85, 13);
            this.lblShownColumns.TabIndex = 0;
            this.lblShownColumns.Text = "Shown columns:";
            // 
            // pnlTransfer
            // 
            this.pnlTransfer.Controls.Add(this.pbTransfer);
            this.pnlTransfer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTransfer.Location = new System.Drawing.Point(0, 448);
            this.pnlTransfer.Name = "pnlTransfer";
            this.pnlTransfer.Padding = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.pnlTransfer.Size = new System.Drawing.Size(909, 30);
            this.pnlTransfer.TabIndex = 9;
            // 
            // pbTransfer
            // 
            this.pbTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbTransfer.Location = new System.Drawing.Point(7, 3);
            this.pbTransfer.Name = "pbTransfer";
            this.pbTransfer.Size = new System.Drawing.Size(895, 24);
            this.pbTransfer.TabIndex = 0;
            // 
            // DatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 478);
            this.Controls.Add(this.pnlTransfer);
            this.Controls.Add(this.pnlDgvFootprints);
            this.Controls.Add(this.pnlControls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DatabaseForm";
            this.Text = "Pick and place database";
            this.Load += new System.EventHandler(this.DatabaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFootprints)).EndInit();
            this.pnlDgvFootprints.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.pnlTransfer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckedListBox clbColumnsDisplay;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgvFootprints;
        private System.Windows.Forms.Panel pnlDgvFootprints;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Panel pnlTransfer;
        private System.Windows.Forms.ProgressBar pbTransfer;
        private System.Windows.Forms.Label lblShownColumns;

    }
}

