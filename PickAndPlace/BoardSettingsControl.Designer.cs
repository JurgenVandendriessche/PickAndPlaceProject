namespace PickAndPlace
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
            this.nudY = new PickAndPlace.NumericUpDownWithUnit();
            this.nudX = new PickAndPlace.NumericUpDownWithUnit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(4, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(23, 13);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "title";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(4, 25);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 7;
            this.lblX.Text = "X:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(100, 25);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 8;
            this.lblY.Text = "Y:";
            // 
            // nudY
            // 
            this.nudY.BackColor = System.Drawing.SystemColors.Window;
            this.nudY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nudY.Location = new System.Drawing.Point(123, 23);
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(67, 20);
            this.nudY.TabIndex = 10;
            // 
            // nudX
            // 
            this.nudX.BackColor = System.Drawing.SystemColors.Window;
            this.nudX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nudX.Location = new System.Drawing.Point(27, 23);
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(67, 20);
            this.nudX.TabIndex = 9;
            // 
            // BoardSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblTitle);
            this.Name = "BoardSettingsControl";
            this.Size = new System.Drawing.Size(195, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private NumericUpDownWithUnit nudX;
        private NumericUpDownWithUnit nudY;

    }
}
