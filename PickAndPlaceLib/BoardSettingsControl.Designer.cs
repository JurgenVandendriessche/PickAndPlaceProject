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
    partial class BoardSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.lblUnitX = new System.Windows.Forms.Label();
            this.lblUnitY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(4, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(23, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "title";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(4, 25);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 4;
            this.lblX.Text = "X:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(104, 25);
            this.lblY.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 6;
            this.lblY.Text = "Y:";
            // 
            // nudY
            // 
            this.nudY.BackColor = System.Drawing.SystemColors.Window;
            this.nudY.Location = new System.Drawing.Point(123, 23);
            this.nudY.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(55, 20);
            this.nudY.TabIndex = 2;
            this.nudY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudY.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // nudX
            // 
            this.nudX.BackColor = System.Drawing.SystemColors.Window;
            this.nudX.Location = new System.Drawing.Point(27, 23);
            this.nudX.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(55, 20);
            this.nudX.TabIndex = 1;
            this.nudX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudX.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // lblUnitX
            // 
            this.lblUnitX.AutoSize = true;
            this.lblUnitX.Location = new System.Drawing.Point(84, 25);
            this.lblUnitX.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.lblUnitX.Name = "lblUnitX";
            this.lblUnitX.Size = new System.Drawing.Size(0, 13);
            this.lblUnitX.TabIndex = 5;
            // 
            // lblUnitY
            // 
            this.lblUnitY.AutoSize = true;
            this.lblUnitY.Location = new System.Drawing.Point(180, 25);
            this.lblUnitY.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.lblUnitY.Name = "lblUnitY";
            this.lblUnitY.Size = new System.Drawing.Size(0, 13);
            this.lblUnitY.TabIndex = 7;
            // 
            // BoardSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUnitY);
            this.Controls.Add(this.lblUnitX);
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblTitle);
            this.Name = "BoardSettingsControl";
            this.Size = new System.Drawing.Size(210, 50);
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.Label lblUnitX;
        private System.Windows.Forms.Label lblUnitY;

    }
}
