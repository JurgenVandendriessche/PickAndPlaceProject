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
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnBrowsePnP = new System.Windows.Forms.Button();
            this.btnBrowseBOM = new System.Windows.Forms.Button();
            this.tbxPnPfile = new System.Windows.Forms.TextBox();
            this.tbxBOMfile = new System.Windows.Forms.TextBox();
            this.lblSelectPnPfile = new System.Windows.Forms.Label();
            this.lblSelectBOMfile = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lvIncluded = new System.Windows.Forms.ListView();
            this.chDesignatorsU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chManufacturerPartNumberU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCommentU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbOffsetAndPanelization = new System.Windows.Forms.GroupBox();
            this.bscDimensions = new PickAndPlaceLib.BoardSettingsControl();
            this.bscDistBetwBoards = new PickAndPlaceLib.BoardSettingsControl();
            this.bscNumberOfBoards = new PickAndPlaceLib.BoardSettingsControl();
            this.bscOrigin = new PickAndPlaceLib.BoardSettingsControl();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExclude = new System.Windows.Forms.Button();
            this.lvExcluded = new System.Windows.Forms.ListView();
            this.chDesignatorsL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chManufacturerPartNumberL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCommentL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInclude = new System.Windows.Forms.Button();
            this.tcPhaseDisplayer = new System.Windows.Forms.TabControl();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.btnLdStackConfig = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.llblVersion = new System.Windows.Forms.LinkLabel();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.btnMerge = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlExportButtons = new System.Windows.Forms.Panel();
            this.gbOffsetAndPanelization.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlExportButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowsePnP
            // 
            this.btnBrowsePnP.Location = new System.Drawing.Point(239, 36);
            this.btnBrowsePnP.Name = "btnBrowsePnP";
            this.btnBrowsePnP.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsePnP.TabIndex = 1;
            this.btnBrowsePnP.Text = "Browse";
            this.btnBrowsePnP.UseVisualStyleBackColor = true;
            this.btnBrowsePnP.Click += new System.EventHandler(this.btnBrowsePnP_Click);
            // 
            // btnBrowseBOM
            // 
            this.btnBrowseBOM.Location = new System.Drawing.Point(239, 101);
            this.btnBrowseBOM.Name = "btnBrowseBOM";
            this.btnBrowseBOM.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseBOM.TabIndex = 3;
            this.btnBrowseBOM.Text = "Browse";
            this.btnBrowseBOM.UseVisualStyleBackColor = true;
            this.btnBrowseBOM.Click += new System.EventHandler(this.btnBrowseBOM_Click);
            // 
            // tbxPnPfile
            // 
            this.tbxPnPfile.Location = new System.Drawing.Point(26, 38);
            this.tbxPnPfile.Name = "tbxPnPfile";
            this.tbxPnPfile.Size = new System.Drawing.Size(193, 20);
            this.tbxPnPfile.TabIndex = 0;
            // 
            // tbxBOMfile
            // 
            this.tbxBOMfile.Location = new System.Drawing.Point(26, 103);
            this.tbxBOMfile.Name = "tbxBOMfile";
            this.tbxBOMfile.Size = new System.Drawing.Size(193, 20);
            this.tbxBOMfile.TabIndex = 2;
            // 
            // lblSelectPnPfile
            // 
            this.lblSelectPnPfile.AutoSize = true;
            this.lblSelectPnPfile.Location = new System.Drawing.Point(23, 22);
            this.lblSelectPnPfile.Name = "lblSelectPnPfile";
            this.lblSelectPnPfile.Size = new System.Drawing.Size(76, 13);
            this.lblSelectPnPfile.TabIndex = 4;
            this.lblSelectPnPfile.Text = "Select PnP file";
            // 
            // lblSelectBOMfile
            // 
            this.lblSelectBOMfile.AutoSize = true;
            this.lblSelectBOMfile.Location = new System.Drawing.Point(23, 87);
            this.lblSelectBOMfile.Name = "lblSelectBOMfile";
            this.lblSelectBOMfile.Size = new System.Drawing.Size(80, 13);
            this.lblSelectBOMfile.TabIndex = 5;
            this.lblSelectBOMfile.Text = "Select BOM file";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(186, 148);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(105, 148);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // lvIncluded
            // 
            this.lvIncluded.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDesignatorsU,
            this.chManufacturerPartNumberU,
            this.chCommentU});
            this.lvIncluded.FullRowSelect = true;
            this.lvIncluded.HideSelection = false;
            this.lvIncluded.Location = new System.Drawing.Point(5, 12);
            this.lvIncluded.Name = "lvIncluded";
            this.lvIncluded.Size = new System.Drawing.Size(419, 295);
            this.lvIncluded.TabIndex = 13;
            this.lvIncluded.UseCompatibleStateImageBehavior = false;
            this.lvIncluded.View = System.Windows.Forms.View.Details;
            this.lvIncluded.ItemActivate += new System.EventHandler(this.EditReel);
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
            // gbOffsetAndPanelization
            // 
            this.gbOffsetAndPanelization.Controls.Add(this.bscDimensions);
            this.gbOffsetAndPanelization.Controls.Add(this.bscDistBetwBoards);
            this.gbOffsetAndPanelization.Controls.Add(this.bscNumberOfBoards);
            this.gbOffsetAndPanelization.Controls.Add(this.bscOrigin);
            this.gbOffsetAndPanelization.Location = new System.Drawing.Point(26, 261);
            this.gbOffsetAndPanelization.Name = "gbOffsetAndPanelization";
            this.gbOffsetAndPanelization.Size = new System.Drawing.Size(217, 243);
            this.gbOffsetAndPanelization.TabIndex = 9;
            this.gbOffsetAndPanelization.TabStop = false;
            this.gbOffsetAndPanelization.Text = "Offset and panelization";
            // 
            // bscDimensions
            // 
            this.bscDimensions.DecimalPlaces = 2;
            this.bscDimensions.Dock = System.Windows.Forms.DockStyle.Top;
            this.bscDimensions.IncrementX = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.bscDimensions.IncrementY = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.bscDimensions.Location = new System.Drawing.Point(3, 181);
            this.bscDimensions.MaximumX = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.bscDimensions.MaximumY = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.bscDimensions.Name = "bscDimensions";
            this.bscDimensions.Size = new System.Drawing.Size(211, 50);
            this.bscDimensions.TabIndex = 12;
            this.bscDimensions.Title = "Board Dimensions";
            this.bscDimensions.Unit = "mm";
            // 
            // bscDistBetwBoards
            // 
            this.bscDistBetwBoards.DecimalPlaces = 2;
            this.bscDistBetwBoards.Dock = System.Windows.Forms.DockStyle.Top;
            this.bscDistBetwBoards.IncrementX = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.bscDistBetwBoards.IncrementY = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.bscDistBetwBoards.Location = new System.Drawing.Point(3, 126);
            this.bscDistBetwBoards.MaximumX = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.bscDistBetwBoards.MaximumY = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.bscDistBetwBoards.Name = "bscDistBetwBoards";
            this.bscDistBetwBoards.Size = new System.Drawing.Size(211, 55);
            this.bscDistBetwBoards.TabIndex = 11;
            this.bscDistBetwBoards.Title = "Distance between two boards";
            this.bscDistBetwBoards.Unit = "mm";
            // 
            // bscNumberOfBoards
            // 
            this.bscNumberOfBoards.Dock = System.Windows.Forms.DockStyle.Top;
            this.bscNumberOfBoards.Location = new System.Drawing.Point(3, 71);
            this.bscNumberOfBoards.MinimumX = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bscNumberOfBoards.MinimumY = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bscNumberOfBoards.Name = "bscNumberOfBoards";
            this.bscNumberOfBoards.Size = new System.Drawing.Size(211, 55);
            this.bscNumberOfBoards.TabIndex = 10;
            this.bscNumberOfBoards.Title = "Number of boards";
            this.bscNumberOfBoards.ValueX = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bscNumberOfBoards.ValueY = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bscOrigin
            // 
            this.bscOrigin.DecimalPlaces = 2;
            this.bscOrigin.Dock = System.Windows.Forms.DockStyle.Top;
            this.bscOrigin.IncrementX = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.bscOrigin.IncrementY = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.bscOrigin.Location = new System.Drawing.Point(3, 16);
            this.bscOrigin.MinimumX = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bscOrigin.MinimumY = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.bscOrigin.Name = "bscOrigin";
            this.bscOrigin.Size = new System.Drawing.Size(211, 55);
            this.bscOrigin.TabIndex = 9;
            this.bscOrigin.Title = "Offset Origin";
            this.bscOrigin.Unit = "mm";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(5, 318);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.EditReel);
            // 
            // btnExclude
            // 
            this.btnExclude.Location = new System.Drawing.Point(91, 318);
            this.btnExclude.Name = "btnExclude";
            this.btnExclude.Size = new System.Drawing.Size(75, 23);
            this.btnExclude.TabIndex = 16;
            this.btnExclude.Text = "Exclude";
            this.btnExclude.UseVisualStyleBackColor = true;
            this.btnExclude.Click += new System.EventHandler(this.btnExclude_Click);
            // 
            // lvExcluded
            // 
            this.lvExcluded.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDesignatorsL,
            this.chManufacturerPartNumberL,
            this.chCommentL});
            this.lvExcluded.FullRowSelect = true;
            this.lvExcluded.HideSelection = false;
            this.lvExcluded.Location = new System.Drawing.Point(5, 360);
            this.lvExcluded.MultiSelect = false;
            this.lvExcluded.Name = "lvExcluded";
            this.lvExcluded.Size = new System.Drawing.Size(419, 295);
            this.lvExcluded.TabIndex = 14;
            this.lvExcluded.UseCompatibleStateImageBehavior = false;
            this.lvExcluded.View = System.Windows.Forms.View.Details;
            // 
            // chDesignatorsL
            // 
            this.chDesignatorsL.Text = "Designators";
            this.chDesignatorsL.Width = 139;
            // 
            // chManufacturerPartNumberL
            // 
            this.chManufacturerPartNumberL.Text = "Manufacturer part number";
            this.chManufacturerPartNumberL.Width = 138;
            // 
            // chCommentL
            // 
            this.chCommentL.Text = "Comment";
            this.chCommentL.Width = 138;
            // 
            // btnInclude
            // 
            this.btnInclude.Location = new System.Drawing.Point(177, 318);
            this.btnInclude.Name = "btnInclude";
            this.btnInclude.Size = new System.Drawing.Size(75, 23);
            this.btnInclude.TabIndex = 17;
            this.btnInclude.Text = "Include";
            this.btnInclude.UseVisualStyleBackColor = true;
            this.btnInclude.Click += new System.EventHandler(this.btnInclude_Click);
            // 
            // tcPhaseDisplayer
            // 
            this.tcPhaseDisplayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPhaseDisplayer.Location = new System.Drawing.Point(10, 10);
            this.tcPhaseDisplayer.Name = "tcPhaseDisplayer";
            this.tcPhaseDisplayer.SelectedIndex = 0;
            this.tcPhaseDisplayer.Size = new System.Drawing.Size(554, 574);
            this.tcPhaseDisplayer.TabIndex = 20;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(349, 318);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 18;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(19, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 21;
            this.btnExport.Text = "&Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(24, 148);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnExportAll
            // 
            this.btnExportAll.Location = new System.Drawing.Point(100, 12);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(75, 23);
            this.btnExportAll.TabIndex = 22;
            this.btnExportAll.Text = "E&xport all";
            this.btnExportAll.UseVisualStyleBackColor = true;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnLdStackConfig
            // 
            this.btnLdStackConfig.Location = new System.Drawing.Point(181, 12);
            this.btnLdStackConfig.Name = "btnLdStackConfig";
            this.btnLdStackConfig.Size = new System.Drawing.Size(139, 23);
            this.btnLdStackConfig.TabIndex = 23;
            this.btnLdStackConfig.Text = "Load stack configuration";
            this.btnLdStackConfig.UseVisualStyleBackColor = true;
            this.btnLdStackConfig.Click += new System.EventHandler(this.btnLdStackConfig_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 206);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(186, 206);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.llblVersion);
            this.pnlLeft.Controls.Add(this.btnSave);
            this.pnlLeft.Controls.Add(this.btnLoad);
            this.pnlLeft.Controls.Add(this.lblSelectPnPfile);
            this.pnlLeft.Controls.Add(this.tbxPnPfile);
            this.pnlLeft.Controls.Add(this.btnBrowsePnP);
            this.pnlLeft.Controls.Add(this.btnBrowseBOM);
            this.pnlLeft.Controls.Add(this.btnSettings);
            this.pnlLeft.Controls.Add(this.tbxBOMfile);
            this.pnlLeft.Controls.Add(this.lblSelectBOMfile);
            this.pnlLeft.Controls.Add(this.gbOffsetAndPanelization);
            this.pnlLeft.Controls.Add(this.btnHelp);
            this.pnlLeft.Controls.Add(this.btnStart);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(316, 666);
            this.pnlLeft.TabIndex = 23;
            // 
            // llblVersion
            // 
            this.llblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblVersion.AutoSize = true;
            this.llblVersion.Location = new System.Drawing.Point(3, 644);
            this.llblVersion.Name = "llblVersion";
            this.llblVersion.Size = new System.Drawing.Size(200, 13);
            this.llblVersion.TabIndex = 26;
            this.llblVersion.TabStop = true;
            this.llblVersion.Text = "Software Version: 1.0  check for updates";
            this.llblVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblVersion_LinkClicked);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.lvExcluded);
            this.pnlCenter.Controls.Add(this.btnMerge);
            this.pnlCenter.Controls.Add(this.btnEdit);
            this.pnlCenter.Controls.Add(this.btnExclude);
            this.pnlCenter.Controls.Add(this.btnGenerate);
            this.pnlCenter.Controls.Add(this.lvIncluded);
            this.pnlCenter.Controls.Add(this.btnInclude);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCenter.Location = new System.Drawing.Point(316, 0);
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(438, 666);
            this.pnlCenter.TabIndex = 24;
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(263, 318);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 19;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tcPhaseDisplayer);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(754, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Size = new System.Drawing.Size(574, 594);
            this.pnlRight.TabIndex = 25;
            // 
            // pnlExportButtons
            // 
            this.pnlExportButtons.Controls.Add(this.btnLdStackConfig);
            this.pnlExportButtons.Controls.Add(this.btnExport);
            this.pnlExportButtons.Controls.Add(this.btnExportAll);
            this.pnlExportButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlExportButtons.Enabled = false;
            this.pnlExportButtons.Location = new System.Drawing.Point(754, 594);
            this.pnlExportButtons.Name = "pnlExportButtons";
            this.pnlExportButtons.Size = new System.Drawing.Size(574, 72);
            this.pnlExportButtons.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 666);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlExportButtons);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlLeft);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pick and place software";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.gbOffsetAndPanelization.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlExportButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowsePnP;
        private System.Windows.Forms.Button btnBrowseBOM;
        private System.Windows.Forms.TextBox tbxPnPfile;
        private System.Windows.Forms.TextBox tbxBOMfile;
        private System.Windows.Forms.Label lblSelectPnPfile;
        private System.Windows.Forms.Label lblSelectBOMfile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ListView lvIncluded;
        private System.Windows.Forms.ColumnHeader chDesignatorsU;
        private System.Windows.Forms.ColumnHeader chManufacturerPartNumberU;
        private System.Windows.Forms.ColumnHeader chCommentU;
        private System.Windows.Forms.GroupBox gbOffsetAndPanelization;
        private PickAndPlaceLib.BoardSettingsControl bscOrigin;
        private PickAndPlaceLib.BoardSettingsControl bscNumberOfBoards;
        private PickAndPlaceLib.BoardSettingsControl bscDistBetwBoards;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnExclude;
        private System.Windows.Forms.ListView lvExcluded;
        private System.Windows.Forms.ColumnHeader chDesignatorsL;
        private System.Windows.Forms.ColumnHeader chManufacturerPartNumberL;
        private System.Windows.Forms.ColumnHeader chCommentL;
        private System.Windows.Forms.Button btnInclude;
        private System.Windows.Forms.TabControl tcPhaseDisplayer;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnExportAll;
        private PickAndPlaceLib.BoardSettingsControl bscDimensions;
        private System.Windows.Forms.Button btnLdStackConfig;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlExportButtons;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.LinkLabel llblVersion;
    }
}

