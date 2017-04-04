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
    partial class StackControl
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
            this.pnlStackType = new System.Windows.Forms.Panel();
            this.lblStackType = new System.Windows.Forms.Label();
            this.pnlCbxReel = new System.Windows.Forms.Panel();
            this.cbxReels = new System.Windows.Forms.ComboBox();
            this.pnlCbLocked = new System.Windows.Forms.Panel();
            this.cbLocked = new System.Windows.Forms.CheckBox();
            this.pnlNudSpeed = new System.Windows.Forms.Panel();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.pnlLblSpeed = new System.Windows.Forms.Panel();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.pnlStackType.SuspendLayout();
            this.pnlCbxReel.SuspendLayout();
            this.pnlCbLocked.SuspendLayout();
            this.pnlNudSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.pnlLblSpeed.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStackType
            // 
            this.pnlStackType.Controls.Add(this.lblStackType);
            this.pnlStackType.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStackType.Location = new System.Drawing.Point(0, 0);
            this.pnlStackType.Name = "pnlStackType";
            this.pnlStackType.Size = new System.Drawing.Size(73, 25);
            this.pnlStackType.TabIndex = 0;
            // 
            // lblStackType
            // 
            this.lblStackType.AutoSize = true;
            this.lblStackType.Location = new System.Drawing.Point(-3, 5);
            this.lblStackType.Name = "lblStackType";
            this.lblStackType.Size = new System.Drawing.Size(28, 13);
            this.lblStackType.TabIndex = 3;
            this.lblStackType.Text = "Tray";
            // 
            // pnlCbxReel
            // 
            this.pnlCbxReel.Controls.Add(this.cbxReels);
            this.pnlCbxReel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCbxReel.Location = new System.Drawing.Point(73, 0);
            this.pnlCbxReel.Name = "pnlCbxReel";
            this.pnlCbxReel.Size = new System.Drawing.Size(176, 25);
            this.pnlCbxReel.TabIndex = 1;
            // 
            // cbxReels
            // 
            this.cbxReels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxReels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReels.FormattingEnabled = true;
            this.cbxReels.Location = new System.Drawing.Point(0, 0);
            this.cbxReels.Name = "cbxReels";
            this.cbxReels.Size = new System.Drawing.Size(176, 21);
            this.cbxReels.TabIndex = 0;
            // 
            // pnlCbLocked
            // 
            this.pnlCbLocked.Controls.Add(this.cbLocked);
            this.pnlCbLocked.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCbLocked.Location = new System.Drawing.Point(338, 0);
            this.pnlCbLocked.Name = "pnlCbLocked";
            this.pnlCbLocked.Size = new System.Drawing.Size(77, 25);
            this.pnlCbLocked.TabIndex = 2;
            // 
            // cbLocked
            // 
            this.cbLocked.AutoSize = true;
            this.cbLocked.Location = new System.Drawing.Point(0, 4);
            this.cbLocked.Name = "cbLocked";
            this.cbLocked.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cbLocked.Size = new System.Drawing.Size(77, 17);
            this.cbLocked.TabIndex = 2;
            this.cbLocked.Text = "Unlocked";
            this.cbLocked.UseVisualStyleBackColor = true;
            // 
            // pnlNudSpeed
            // 
            this.pnlNudSpeed.Controls.Add(this.nudSpeed);
            this.pnlNudSpeed.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNudSpeed.Location = new System.Drawing.Point(290, 0);
            this.pnlNudSpeed.Name = "pnlNudSpeed";
            this.pnlNudSpeed.Size = new System.Drawing.Size(48, 25);
            this.pnlNudSpeed.TabIndex = 1;
            // 
            // nudSpeed
            // 
            this.nudSpeed.Location = new System.Drawing.Point(0, 3);
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(48, 20);
            this.nudSpeed.TabIndex = 1;
            this.nudSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // pnlLblSpeed
            // 
            this.pnlLblSpeed.Controls.Add(this.lblSpeed);
            this.pnlLblSpeed.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLblSpeed.Location = new System.Drawing.Point(249, 0);
            this.pnlLblSpeed.Name = "pnlLblSpeed";
            this.pnlLblSpeed.Size = new System.Drawing.Size(41, 25);
            this.pnlLblSpeed.TabIndex = 1;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Location = new System.Drawing.Point(0, 5);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(41, 25);
            this.lblSpeed.TabIndex = 5;
            this.lblSpeed.Text = "Speed:";
            // 
            // StackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCbxReel);
            this.Controls.Add(this.pnlLblSpeed);
            this.Controls.Add(this.pnlNudSpeed);
            this.Controls.Add(this.pnlCbLocked);
            this.Controls.Add(this.pnlStackType);
            this.Name = "StackControl";
            this.Size = new System.Drawing.Size(415, 25);
            this.pnlStackType.ResumeLayout(false);
            this.pnlStackType.PerformLayout();
            this.pnlCbxReel.ResumeLayout(false);
            this.pnlCbLocked.ResumeLayout(false);
            this.pnlCbLocked.PerformLayout();
            this.pnlNudSpeed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.pnlLblSpeed.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStackType;
        private System.Windows.Forms.Panel pnlCbxReel;
        private System.Windows.Forms.Panel pnlCbLocked;
        private System.Windows.Forms.Panel pnlNudSpeed;
        private System.Windows.Forms.Panel pnlLblSpeed;
        private System.Windows.Forms.Label lblStackType;
        private System.Windows.Forms.ComboBox cbxReels;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.CheckBox cbLocked;
    }
}
