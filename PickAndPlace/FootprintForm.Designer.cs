namespace PickAndPlace
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbDimensions = new System.Windows.Forms.GroupBox();
            this.nudwuRotation = new PickAndPlace.NumericUpDownWithUnit();
            this.lblRotation = new System.Windows.Forms.Label();
            this.nudwuHeight = new PickAndPlace.NumericUpDownWithUnit();
            this.nudwuLength = new PickAndPlace.NumericUpDownWithUnit();
            this.nudwuWidth = new PickAndPlace.NumericUpDownWithUnit();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblNozzle = new System.Windows.Forms.Label();
            this.lblStackType = new System.Windows.Forms.Label();
            this.cbxNozzle = new System.Windows.Forms.ComboBox();
            this.cbxStackType = new System.Windows.Forms.ComboBox();
            this.cbxKnown = new System.Windows.Forms.ComboBox();
            this.lblFeedRate = new System.Windows.Forms.Label();
            this.nudwuFeedRate = new PickAndPlace.NumericUpDownWithUnit();
            this.bscOffset = new PickAndPlace.BoardSettingsControl();
            this.lblPartNumber = new System.Windows.Forms.Label();
            this.tbxMPN = new System.Windows.Forms.TextBox();
            this.gbDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudwuRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudwuHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudwuLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudwuWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudwuFeedRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(147, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(292, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbDimensions
            // 
            this.gbDimensions.Controls.Add(this.nudwuRotation);
            this.gbDimensions.Controls.Add(this.lblRotation);
            this.gbDimensions.Controls.Add(this.nudwuHeight);
            this.gbDimensions.Controls.Add(this.nudwuLength);
            this.gbDimensions.Controls.Add(this.nudwuWidth);
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
            // nudwuRotation
            // 
            this.nudwuRotation.Increment = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudwuRotation.Location = new System.Drawing.Point(59, 59);
            this.nudwuRotation.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudwuRotation.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudwuRotation.Name = "nudwuRotation";
            this.nudwuRotation.ReadOnly = true;
            this.nudwuRotation.Size = new System.Drawing.Size(96, 20);
            this.nudwuRotation.TabIndex = 7;
            this.nudwuRotation.unit = "°";
            // 
            // lblRotation
            // 
            this.lblRotation.AutoSize = true;
            this.lblRotation.Location = new System.Drawing.Point(6, 61);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(47, 13);
            this.lblRotation.TabIndex = 6;
            this.lblRotation.Text = "Roation:";
            // 
            // nudwuHeight
            // 
            this.nudwuHeight.DecimalPlaces = 2;
            this.nudwuHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudwuHeight.Location = new System.Drawing.Point(376, 23);
            this.nudwuHeight.Name = "nudwuHeight";
            this.nudwuHeight.Size = new System.Drawing.Size(120, 20);
            this.nudwuHeight.TabIndex = 5;
            this.nudwuHeight.unit = "mm";
            this.nudwuHeight.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // nudwuLength
            // 
            this.nudwuLength.DecimalPlaces = 2;
            this.nudwuLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudwuLength.Location = new System.Drawing.Point(203, 23);
            this.nudwuLength.Name = "nudwuLength";
            this.nudwuLength.Size = new System.Drawing.Size(120, 20);
            this.nudwuLength.TabIndex = 4;
            this.nudwuLength.unit = "mm";
            // 
            // nudwuWidth
            // 
            this.nudwuWidth.DecimalPlaces = 2;
            this.nudwuWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudwuWidth.Location = new System.Drawing.Point(50, 23);
            this.nudwuWidth.Name = "nudwuWidth";
            this.nudwuWidth.Size = new System.Drawing.Size(105, 20);
            this.nudwuWidth.TabIndex = 3;
            this.nudwuWidth.unit = "mm";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(329, 25);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 2;
            this.lblHeight.Text = "Height:";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(161, 25);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(43, 13);
            this.lblLength.TabIndex = 1;
            this.lblLength.Text = "Length:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(6, 25);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width:";
            // 
            // lblNozzle
            // 
            this.lblNozzle.AutoSize = true;
            this.lblNozzle.Location = new System.Drawing.Point(289, 164);
            this.lblNozzle.Name = "lblNozzle";
            this.lblNozzle.Size = new System.Drawing.Size(42, 13);
            this.lblNozzle.TabIndex = 6;
            this.lblNozzle.Text = "Nozzle:";
            // 
            // lblStackType
            // 
            this.lblStackType.AutoSize = true;
            this.lblStackType.Location = new System.Drawing.Point(24, 164);
            this.lblStackType.Name = "lblStackType";
            this.lblStackType.Size = new System.Drawing.Size(61, 13);
            this.lblStackType.TabIndex = 7;
            this.lblStackType.Text = "Stack type:";
            // 
            // cbxNozzle
            // 
            this.cbxNozzle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNozzle.FormattingEnabled = true;
            this.cbxNozzle.Location = new System.Drawing.Point(337, 161);
            this.cbxNozzle.Name = "cbxNozzle";
            this.cbxNozzle.Size = new System.Drawing.Size(121, 21);
            this.cbxNozzle.TabIndex = 8;
            // 
            // cbxStackType
            // 
            this.cbxStackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStackType.FormattingEnabled = true;
            this.cbxStackType.Location = new System.Drawing.Point(91, 161);
            this.cbxStackType.Name = "cbxStackType";
            this.cbxStackType.Size = new System.Drawing.Size(121, 21);
            this.cbxStackType.Sorted = true;
            this.cbxStackType.TabIndex = 9;
            this.cbxStackType.SelectedIndexChanged += new System.EventHandler(this.cbxStackType_SelectedIndexChanged);
            // 
            // cbxKnown
            // 
            this.cbxKnown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKnown.FormattingEnabled = true;
            this.cbxKnown.Location = new System.Drawing.Point(353, 15);
            this.cbxKnown.Name = "cbxKnown";
            this.cbxKnown.Size = new System.Drawing.Size(164, 21);
            this.cbxKnown.TabIndex = 10;
            // 
            // lblFeedRate
            // 
            this.lblFeedRate.AutoSize = true;
            this.lblFeedRate.Location = new System.Drawing.Point(289, 224);
            this.lblFeedRate.Name = "lblFeedRate";
            this.lblFeedRate.Size = new System.Drawing.Size(55, 13);
            this.lblFeedRate.TabIndex = 11;
            this.lblFeedRate.Text = "Feed rate:";
            // 
            // nudwuFeedRate
            // 
            this.nudwuFeedRate.DecimalPlaces = 2;
            this.nudwuFeedRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudwuFeedRate.Location = new System.Drawing.Point(350, 222);
            this.nudwuFeedRate.Name = "nudwuFeedRate";
            this.nudwuFeedRate.Size = new System.Drawing.Size(70, 20);
            this.nudwuFeedRate.TabIndex = 12;
            this.nudwuFeedRate.unit = "mm";
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
            this.bscOffset.TabIndex = 5;
            this.bscOffset.title = "Offset stack";
            this.bscOffset.unit = "mm";
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.AutoSize = true;
            this.lblPartNumber.Location = new System.Drawing.Point(27, 18);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(69, 13);
            this.lblPartNumber.TabIndex = 13;
            this.lblPartNumber.Text = "Part Number:";
            // 
            // tbxMPN
            // 
            this.tbxMPN.Location = new System.Drawing.Point(95, 15);
            this.tbxMPN.Name = "tbxMPN";
            this.tbxMPN.Size = new System.Drawing.Size(240, 20);
            this.tbxMPN.TabIndex = 14;
            // 
            // FootprintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 303);
            this.Controls.Add(this.tbxMPN);
            this.Controls.Add(this.lblPartNumber);
            this.Controls.Add(this.nudwuFeedRate);
            this.Controls.Add(this.lblFeedRate);
            this.Controls.Add(this.cbxKnown);
            this.Controls.Add(this.cbxStackType);
            this.Controls.Add(this.cbxNozzle);
            this.Controls.Add(this.lblStackType);
            this.Controls.Add(this.lblNozzle);
            this.Controls.Add(this.bscOffset);
            this.Controls.Add(this.gbDimensions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "FootprintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FootprintForm";
            this.gbDimensions.ResumeLayout(false);
            this.gbDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudwuRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudwuHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudwuLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudwuWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudwuFeedRate)).EndInit();
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
        private NumericUpDownWithUnit nudwuHeight;
        private NumericUpDownWithUnit nudwuLength;
        private NumericUpDownWithUnit nudwuWidth;
        private System.Windows.Forms.Label lblRotation;
        private NumericUpDownWithUnit nudwuRotation;
        private BoardSettingsControl bscOffset;
        private System.Windows.Forms.Label lblNozzle;
        private System.Windows.Forms.Label lblStackType;
        private System.Windows.Forms.ComboBox cbxNozzle;
        private System.Windows.Forms.ComboBox cbxStackType;
        private System.Windows.Forms.ComboBox cbxKnown;
        private System.Windows.Forms.Label lblFeedRate;
        private NumericUpDownWithUnit nudwuFeedRate;
        private System.Windows.Forms.Label lblPartNumber;
        private System.Windows.Forms.TextBox tbxMPN;
    }
}