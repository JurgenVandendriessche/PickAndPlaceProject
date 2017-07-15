namespace PickAndPlace
{
    partial class MergeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeForm));
            this.lvReels = new System.Windows.Forms.ListView();
            this.chDesignatorsU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chManufacturerPartNumberU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCommentU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblInstruction = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvReels
            // 
            this.lvReels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDesignatorsU,
            this.chManufacturerPartNumberU,
            this.chCommentU});
            this.lvReels.FullRowSelect = true;
            this.lvReels.Location = new System.Drawing.Point(12, 33);
            this.lvReels.MultiSelect = false;
            this.lvReels.Name = "lvReels";
            this.lvReels.Size = new System.Drawing.Size(419, 295);
            this.lvReels.TabIndex = 0;
            this.lvReels.UseCompatibleStateImageBehavior = false;
            this.lvReels.View = System.Windows.Forms.View.Details;
            // 
            // chDesignatorsU
            // 
            this.chDesignatorsU.Text = "Designators";
            this.chDesignatorsU.Width = 139;
            // 
            // chManufacturerPartNumberU
            // 
            this.chManufacturerPartNumberU.Text = "Manufacturer part number";
            this.chManufacturerPartNumberU.Width = 138;
            // 
            // chCommentU
            // 
            this.chCommentU.Text = "Comment";
            this.chCommentU.Width = 138;
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(13, 14);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(275, 13);
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "Please select the reel with the settings you want to keep:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(123, 344);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(226, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // MergeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(442, 379);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lvReels);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MergeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MergeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvReels;
        private System.Windows.Forms.ColumnHeader chDesignatorsU;
        private System.Windows.Forms.ColumnHeader chManufacturerPartNumberU;
        private System.Windows.Forms.ColumnHeader chCommentU;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}