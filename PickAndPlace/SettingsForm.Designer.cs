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

namespace PickAndPlace
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblMachine = new System.Windows.Forms.Label();
            this.cbxMachine = new System.Windows.Forms.ComboBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblNozzle1 = new System.Windows.Forms.Label();
            this.cbxNozzle1 = new System.Windows.Forms.ComboBox();
            this.lblNozzle2 = new System.Windows.Forms.Label();
            this.cbxNozzle2 = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbxProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.dgPnpFilePara = new System.Windows.Forms.DataGridView();
            this.cParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProjectFolder = new System.Windows.Forms.Label();
            this.dgBomFilePara = new System.Windows.Forms.DataGridView();
            this.cParameterBom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cValueBom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPnpFilePara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBomFilePara)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Location = new System.Drawing.Point(37, 24);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(51, 13);
            this.lblMachine.TabIndex = 0;
            this.lblMachine.Text = "Machine:";
            // 
            // cbxMachine
            // 
            this.cbxMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMachine.FormattingEnabled = true;
            this.cbxMachine.Location = new System.Drawing.Point(94, 21);
            this.cbxMachine.Name = "cbxMachine";
            this.cbxMachine.Size = new System.Drawing.Size(199, 21);
            this.cbxMachine.TabIndex = 0;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(37, 65);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "Speed:";
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(94, 63);
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(62, 20);
            this.nudSpeed.TabIndex = 1;
            // 
            // lblNozzle1
            // 
            this.lblNozzle1.AutoSize = true;
            this.lblNozzle1.Location = new System.Drawing.Point(37, 109);
            this.lblNozzle1.Name = "lblNozzle1";
            this.lblNozzle1.Size = new System.Drawing.Size(45, 13);
            this.lblNozzle1.TabIndex = 4;
            this.lblNozzle1.Text = "Nozzle1";
            // 
            // cbxNozzle1
            // 
            this.cbxNozzle1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNozzle1.FormattingEnabled = true;
            this.cbxNozzle1.Location = new System.Drawing.Point(94, 106);
            this.cbxNozzle1.Name = "cbxNozzle1";
            this.cbxNozzle1.Size = new System.Drawing.Size(199, 21);
            this.cbxNozzle1.TabIndex = 2;
            // 
            // lblNozzle2
            // 
            this.lblNozzle2.AutoSize = true;
            this.lblNozzle2.Location = new System.Drawing.Point(37, 148);
            this.lblNozzle2.Name = "lblNozzle2";
            this.lblNozzle2.Size = new System.Drawing.Size(45, 13);
            this.lblNozzle2.TabIndex = 6;
            this.lblNozzle2.Text = "Nozzle2";
            // 
            // cbxNozzle2
            // 
            this.cbxNozzle2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNozzle2.FormattingEnabled = true;
            this.cbxNozzle2.Location = new System.Drawing.Point(94, 145);
            this.cbxNozzle2.Name = "cbxNozzle2";
            this.cbxNozzle2.Size = new System.Drawing.Size(199, 21);
            this.cbxNozzle2.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(40, 313);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(218, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbxFolder
            // 
            this.tbxFolder.Location = new System.Drawing.Point(121, 207);
            this.tbxFolder.Name = "tbxFolder";
            this.tbxFolder.Size = new System.Drawing.Size(172, 20);
            this.tbxFolder.TabIndex = 4;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(299, 205);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 23);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbxProjectName
            // 
            this.tbxProjectName.Location = new System.Drawing.Point(121, 248);
            this.tbxProjectName.Name = "tbxProjectName";
            this.tbxProjectName.Size = new System.Drawing.Size(172, 20);
            this.tbxProjectName.TabIndex = 5;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(40, 254);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(72, 13);
            this.lblProjectName.TabIndex = 13;
            this.lblProjectName.Text = "Project name:";
            // 
            // dgPnpFilePara
            // 
            this.dgPnpFilePara.AllowUserToAddRows = false;
            this.dgPnpFilePara.AllowUserToDeleteRows = false;
            this.dgPnpFilePara.AllowUserToResizeColumns = false;
            this.dgPnpFilePara.AllowUserToResizeRows = false;
            this.dgPnpFilePara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPnpFilePara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cParameter,
            this.cValue});
            this.dgPnpFilePara.Location = new System.Drawing.Point(353, 13);
            this.dgPnpFilePara.Name = "dgPnpFilePara";
            this.dgPnpFilePara.RowHeadersVisible = false;
            this.dgPnpFilePara.Size = new System.Drawing.Size(340, 232);
            this.dgPnpFilePara.TabIndex = 6;
            // 
            // cParameter
            // 
            this.cParameter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            this.cParameter.DefaultCellStyle = dataGridViewCellStyle1;
            this.cParameter.HeaderText = "Parameter";
            this.cParameter.Name = "cParameter";
            this.cParameter.ReadOnly = true;
            this.cParameter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cValue
            // 
            this.cValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cValue.HeaderText = "Value";
            this.cValue.Name = "cValue";
            this.cValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblProjectFolder
            // 
            this.lblProjectFolder.AutoSize = true;
            this.lblProjectFolder.Location = new System.Drawing.Point(40, 210);
            this.lblProjectFolder.Name = "lblProjectFolder";
            this.lblProjectFolder.Size = new System.Drawing.Size(72, 13);
            this.lblProjectFolder.TabIndex = 15;
            this.lblProjectFolder.Text = "Project folder:";
            // 
            // dgBomFilePara
            // 
            this.dgBomFilePara.AllowUserToAddRows = false;
            this.dgBomFilePara.AllowUserToDeleteRows = false;
            this.dgBomFilePara.AllowUserToResizeColumns = false;
            this.dgBomFilePara.AllowUserToResizeRows = false;
            this.dgBomFilePara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBomFilePara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cParameterBom,
            this.cValueBom});
            this.dgBomFilePara.Location = new System.Drawing.Point(353, 262);
            this.dgBomFilePara.Name = "dgBomFilePara";
            this.dgBomFilePara.RowHeadersVisible = false;
            this.dgBomFilePara.Size = new System.Drawing.Size(340, 86);
            this.dgBomFilePara.TabIndex = 7;
            // 
            // cParameterBom
            // 
            this.cParameterBom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            this.cParameterBom.DefaultCellStyle = dataGridViewCellStyle2;
            this.cParameterBom.HeaderText = "Parameter";
            this.cParameterBom.Name = "cParameterBom";
            this.cParameterBom.ReadOnly = true;
            this.cParameterBom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cValueBom
            // 
            this.cValueBom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cValueBom.HeaderText = "Value";
            this.cValueBom.Name = "cValueBom";
            this.cValueBom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(712, 360);
            this.Controls.Add(this.dgBomFilePara);
            this.Controls.Add(this.lblProjectFolder);
            this.Controls.Add(this.dgPnpFilePara);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.tbxProjectName);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbxFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbxNozzle2);
            this.Controls.Add(this.lblNozzle2);
            this.Controls.Add(this.cbxNozzle1);
            this.Controls.Add(this.lblNozzle1);
            this.Controls.Add(this.nudSpeed);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.cbxMachine);
            this.Controls.Add(this.lblMachine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPnpFilePara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBomFilePara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.ComboBox cbxMachine;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.Label lblNozzle1;
        private System.Windows.Forms.ComboBox cbxNozzle1;
        private System.Windows.Forms.Label lblNozzle2;
        private System.Windows.Forms.ComboBox cbxNozzle2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbxProjectName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.DataGridView dgPnpFilePara;
        private System.Windows.Forms.Label lblProjectFolder;
        private System.Windows.Forms.DataGridView dgBomFilePara;
        private System.Windows.Forms.DataGridViewTextBoxColumn cParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn cParameterBom;
        private System.Windows.Forms.DataGridViewTextBoxColumn cValueBom;
    }
}