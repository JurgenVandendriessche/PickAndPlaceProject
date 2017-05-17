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

namespace PickAndPlaceLib
{
    partial class FootprintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FootprintForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.lblUnitRotation = new System.Windows.Forms.Label();
            this.lblUnitLength = new System.Windows.Forms.Label();
            this.lblUnitWidth = new System.Windows.Forms.Label();
            this.lblUnitHeight = new System.Windows.Forms.Label();
            this.nudRotation = new System.Windows.Forms.NumericUpDown();
            this.lblRotation = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblNozzle = new System.Windows.Forms.Label();
            this.lblStackType = new System.Windows.Forms.Label();
            this.cbxNozzle = new System.Windows.Forms.ComboBox();
            this.cbxStackType = new System.Windows.Forms.ComboBox();
            this.lblFeedRate = new System.Windows.Forms.Label();
            this.nudFeedRate = new System.Windows.Forms.NumericUpDown();
            this.lblPartNumber = new System.Windows.Forms.Label();
            this.tbxMPN = new System.Windows.Forms.TextBox();
            this.lblUnitFeedRate = new System.Windows.Forms.Label();
            this.bscOffset = new PickAndPlaceLib.BoardSettingsControl();
            this.gbDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFeedRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(156, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(269, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.lblUnitRotation);
            this.gbDimensions.Controls.Add(this.lblUnitLength);
            this.gbDimensions.Controls.Add(this.lblUnitWidth);
            this.gbDimensions.Controls.Add(this.lblUnitHeight);
            this.gbDimensions.Controls.Add(this.nudRotation);
            this.gbDimensions.Controls.Add(this.lblRotation);
            this.gbDimensions.Controls.Add(this.nudHeight);
            this.gbDimensions.Controls.Add(this.nudLength);
            this.gbDimensions.Controls.Add(this.nudWidth);
            this.gbDimensions.Controls.Add(this.lblHeight);
            this.gbDimensions.Controls.Add(this.lblLength);
            this.gbDimensions.Controls.Add(this.lblWidth);
            this.gbDimensions.Location = new System.Drawing.Point(18, 52);
            this.gbDimensions.Name = "gbDimensions";
            this.gbDimensions.Size = new System.Drawing.Size(507, 90);
            this.gbDimensions.TabIndex = 3;
            this.gbDimensions.TabStop = false;
            this.gbDimensions.Text = "Dimensions";
            // 
            // lblUnitRotation
            // 
            this.lblUnitRotation.AutoSize = true;
            this.lblUnitRotation.Location = new System.Drawing.Point(137, 64);
            this.lblUnitRotation.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblUnitRotation.Name = "lblUnitRotation";
            this.lblUnitRotation.Size = new System.Drawing.Size(11, 13);
            this.lblUnitRotation.TabIndex = 23;
            this.lblUnitRotation.Text = "°";
            // 
            // lblUnitLength
            // 
            this.lblUnitLength.AutoSize = true;
            this.lblUnitLength.Location = new System.Drawing.Point(137, 25);
            this.lblUnitLength.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblUnitLength.Name = "lblUnitLength";
            this.lblUnitLength.Size = new System.Drawing.Size(23, 13);
            this.lblUnitLength.TabIndex = 20;
            this.lblUnitLength.Text = "mm";
            // 
            // lblUnitWidth
            // 
            this.lblUnitWidth.AutoSize = true;
            this.lblUnitWidth.Location = new System.Drawing.Point(302, 25);
            this.lblUnitWidth.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblUnitWidth.Name = "lblUnitWidth";
            this.lblUnitWidth.Size = new System.Drawing.Size(23, 13);
            this.lblUnitWidth.TabIndex = 21;
            this.lblUnitWidth.Text = "mm";
            // 
            // lblUnitHeight
            // 
            this.lblUnitHeight.AutoSize = true;
            this.lblUnitHeight.Location = new System.Drawing.Point(467, 25);
            this.lblUnitHeight.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblUnitHeight.Name = "lblUnitHeight";
            this.lblUnitHeight.Size = new System.Drawing.Size(23, 13);
            this.lblUnitHeight.TabIndex = 22;
            this.lblUnitHeight.Text = "mm";
            // 
            // nudRotation
            // 
            this.nudRotation.Increment = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudRotation.Location = new System.Drawing.Point(62, 62);
            this.nudRotation.Margin = new System.Windows.Forms.Padding(1);
            this.nudRotation.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudRotation.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudRotation.Name = "nudRotation";
            this.nudRotation.ReadOnly = true;
            this.nudRotation.Size = new System.Drawing.Size(74, 20);
            this.nudRotation.TabIndex = 5;
            this.nudRotation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRotation.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // lblRotation
            // 
            this.lblRotation.AutoSize = true;
            this.lblRotation.Location = new System.Drawing.Point(9, 64);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(50, 13);
            this.lblRotation.TabIndex = 16;
            this.lblRotation.Text = "Rotation:";
            // 
            // nudHeight
            // 
            this.nudHeight.DecimalPlaces = 2;
            this.nudHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudHeight.Location = new System.Drawing.Point(375, 23);
            this.nudHeight.Margin = new System.Windows.Forms.Padding(1);
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(90, 20);
            this.nudHeight.TabIndex = 4;
            this.nudHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudHeight.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nudLength
            // 
            this.nudLength.DecimalPlaces = 2;
            this.nudLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudLength.Location = new System.Drawing.Point(46, 23);
            this.nudLength.Margin = new System.Windows.Forms.Padding(1);
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(90, 20);
            this.nudLength.TabIndex = 2;
            this.nudLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLength.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nudWidth
            // 
            this.nudWidth.DecimalPlaces = 2;
            this.nudWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudWidth.Location = new System.Drawing.Point(210, 23);
            this.nudWidth.Margin = new System.Windows.Forms.Padding(1);
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(90, 20);
            this.nudWidth.TabIndex = 3;
            this.nudWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudWidth.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(337, 25);
            this.lblHeight.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 15;
            this.lblHeight.Text = "Height:";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(6, 25);
            this.lblLength.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(43, 13);
            this.lblLength.TabIndex = 13;
            this.lblLength.Text = "Length:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(170, 25);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 14;
            this.lblWidth.Text = "Width:";
            // 
            // lblNozzle
            // 
            this.lblNozzle.AutoSize = true;
            this.lblNozzle.Location = new System.Drawing.Point(289, 164);
            this.lblNozzle.Name = "lblNozzle";
            this.lblNozzle.Size = new System.Drawing.Size(42, 13);
            this.lblNozzle.TabIndex = 18;
            this.lblNozzle.Text = "Nozzle:";
            // 
            // lblStackType
            // 
            this.lblStackType.AutoSize = true;
            this.lblStackType.Location = new System.Drawing.Point(24, 164);
            this.lblStackType.Name = "lblStackType";
            this.lblStackType.Size = new System.Drawing.Size(61, 13);
            this.lblStackType.TabIndex = 17;
            this.lblStackType.Text = "Stack type:";
            // 
            // cbxNozzle
            // 
            this.cbxNozzle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNozzle.FormattingEnabled = true;
            this.cbxNozzle.Location = new System.Drawing.Point(337, 161);
            this.cbxNozzle.Name = "cbxNozzle";
            this.cbxNozzle.Size = new System.Drawing.Size(121, 21);
            this.cbxNozzle.TabIndex = 7;
            // 
            // cbxStackType
            // 
            this.cbxStackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStackType.FormattingEnabled = true;
            this.cbxStackType.Location = new System.Drawing.Point(91, 161);
            this.cbxStackType.Name = "cbxStackType";
            this.cbxStackType.Size = new System.Drawing.Size(121, 21);
            this.cbxStackType.Sorted = true;
            this.cbxStackType.TabIndex = 6;
            this.cbxStackType.SelectedIndexChanged += new System.EventHandler(this.cbxStackType_SelectedIndexChanged);
            // 
            // lblFeedRate
            // 
            this.lblFeedRate.AutoSize = true;
            this.lblFeedRate.Location = new System.Drawing.Point(289, 224);
            this.lblFeedRate.Name = "lblFeedRate";
            this.lblFeedRate.Size = new System.Drawing.Size(55, 13);
            this.lblFeedRate.TabIndex = 19;
            this.lblFeedRate.Text = "Feed rate:";
            // 
            // nudFeedRate
            // 
            this.nudFeedRate.DecimalPlaces = 2;
            this.nudFeedRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudFeedRate.Location = new System.Drawing.Point(350, 222);
            this.nudFeedRate.Margin = new System.Windows.Forms.Padding(1);
            this.nudFeedRate.Name = "nudFeedRate";
            this.nudFeedRate.Size = new System.Drawing.Size(70, 20);
            this.nudFeedRate.TabIndex = 9;
            this.nudFeedRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFeedRate.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.AutoSize = true;
            this.lblPartNumber.Location = new System.Drawing.Point(27, 18);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(69, 13);
            this.lblPartNumber.TabIndex = 12;
            this.lblPartNumber.Text = "Part Number:";
            // 
            // tbxMPN
            // 
            this.tbxMPN.Location = new System.Drawing.Point(95, 15);
            this.tbxMPN.Name = "tbxMPN";
            this.tbxMPN.Size = new System.Drawing.Size(388, 20);
            this.tbxMPN.TabIndex = 0;
            // 
            // lblUnitFeedRate
            // 
            this.lblUnitFeedRate.AutoSize = true;
            this.lblUnitFeedRate.Location = new System.Drawing.Point(422, 224);
            this.lblUnitFeedRate.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.lblUnitFeedRate.Name = "lblUnitFeedRate";
            this.lblUnitFeedRate.Size = new System.Drawing.Size(23, 13);
            this.lblUnitFeedRate.TabIndex = 24;
            this.lblUnitFeedRate.Text = "mm";
            // 
            // bscOffset
            // 
            this.bscOffset.DecimalPlaces = 2;
            this.bscOffset.IncrementX = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.bscOffset.IncrementY = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.bscOffset.Location = new System.Drawing.Point(27, 197);
            this.bscOffset.MinimumX = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bscOffset.MinimumY = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bscOffset.Name = "bscOffset";
            this.bscOffset.Size = new System.Drawing.Size(204, 51);
            this.bscOffset.TabIndex = 8;
            this.bscOffset.Title = "Offset stack";
            this.bscOffset.Unit = "mm";
            // 
            // FootprintForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(537, 303);
            this.Controls.Add(this.lblUnitFeedRate);
            this.Controls.Add(this.tbxMPN);
            this.Controls.Add(this.lblPartNumber);
            this.Controls.Add(this.nudFeedRate);
            this.Controls.Add(this.lblFeedRate);
            this.Controls.Add(this.cbxStackType);
            this.Controls.Add(this.cbxNozzle);
            this.Controls.Add(this.lblStackType);
            this.Controls.Add(this.lblNozzle);
            this.Controls.Add(this.bscOffset);
            this.Controls.Add(this.gbDimensions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FootprintForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FootprintForm";
            this.gbDimensions.ResumeLayout(false);
            this.gbDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFeedRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbDimensions;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.NumericUpDown nudRotation;
        private BoardSettingsControl bscOffset;
        private System.Windows.Forms.Label lblNozzle;
        private System.Windows.Forms.Label lblStackType;
        private System.Windows.Forms.ComboBox cbxNozzle;
        private System.Windows.Forms.ComboBox cbxStackType;
        private System.Windows.Forms.Label lblFeedRate;
        private System.Windows.Forms.NumericUpDown nudFeedRate;
        private System.Windows.Forms.Label lblPartNumber;
        private System.Windows.Forms.TextBox tbxMPN;
        private System.Windows.Forms.Label lblUnitLength;
        private System.Windows.Forms.Label lblUnitWidth;
        private System.Windows.Forms.Label lblUnitHeight;
        private System.Windows.Forms.Label lblUnitRotation;
        private System.Windows.Forms.Label lblUnitFeedRate;
    }
}