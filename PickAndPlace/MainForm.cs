﻿/*  Copyright (C) 2017  Jurgen Vandendriessche

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PickAndPlaceLib;

using System.Diagnostics;
using System.Reflection;

namespace PickAndPlace
{
    /// <summary>
    /// Represents the main form of the project
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// List of all reels in lvIncluded
        /// </summary>
        private List<Reel> reelsToPlace;
        /// <summary>
        /// List of all reels in lvExcluded
        /// </summary>
        private List<Reel> excludedReels;
        /// <summary>
        /// Machine configuration
        /// </summary>
        private IMachine pnpMachine;
        /// <summary>
        /// List of all stackLists
        /// </summary>
        private List<StackList> stacklisters;
        //Settings:
        private string[] pnpFileParameters;
        private string[] bomFileParameters;
        private string folder;
        private string projectName;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.MainForm"/>
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.HelpRequested += ExtensionMethods.ShowHelp; //this works because the HelpEventArgs is a child class of the EventArgs class
            this.btnHelp.Click += ExtensionMethods.ShowHelp;

            //http://stackoverflow.com/questions/9160059/set-up-dot-instead-of-comma-in-numeric-values
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            try
            {
                string[][] configArrays = FileOperations.ReadConfigFile();
                pnpFileParameters = configArrays[0];
                bomFileParameters = configArrays[1];
            }
            catch
            {
                pnpFileParameters = new string[] { "Designator", "Ref X", "Ref Y", "Layer", "Rotation", "Comment" };
                bomFileParameters = new string[] { "Designator", "Manufacturer Part Number" };
            }

            reelsToPlace = new List<Reel>();
            excludedReels = new List<Reel>();
            stacklisters = new List<StackList>();
            //pnpMachine = new TM220A();
            ChangeMachineType(new TM220A());
            projectName = "newPNPproject";
            folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //
            //lvComponents
            //
            ImageList listViewImages = new ImageList();
            listViewImages.Images.Add(Properties.Resources.nok);
            listViewImages.Images.Add(Properties.Resources.ok);
            lvIncluded.SmallImageList = listViewImages;
            lvIncluded.Sorting = SortOrder.Ascending;
            lvExcluded.Sorting = SortOrder.Ascending;

            ImageList imageList = new ImageList();
            Bitmap topImage = new Bitmap(50, 50);
            Graphics paperTop = Graphics.FromImage(topImage);
            paperTop.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            paperTop.Clear(Color.Red);

            Bitmap bottomImage = new Bitmap(50, 50);
            Graphics paperBottom = Graphics.FromImage(bottomImage);
            paperBottom.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            paperBottom.Clear(Color.Blue);

            imageList.Images.Add(ReelLayer.Top.ToString(), topImage);
            imageList.Images.Add(ReelLayer.Bottom.ToString(), bottomImage);
            tcPhaseDisplayer.ImageList = imageList;

            //
            //Version number 
            //
            //Source:
            //https://stackoverflow.com/questions/6493715/how-to-get-current-the-product-version-in-c
            Assembly assembly = Assembly.GetExecutingAssembly();
            string versionText = String.Format("Software version: {0}  ", AssemblyName.GetAssemblyName(assembly.Location).Version);
            llblVersion.LinkArea = new LinkArea(versionText.Length, 30);
            llblVersion.Links[0].LinkData = "http://pickandplacejurgen.weebly.com/#wsite-content";
            llblVersion.Text = versionText + "check for updates";


        }
        /*-------------------------------------------------------------*/
        private void btnBrowsePnP_Click(object sender, EventArgs e)
        {
            string targetStream = tbxPnPfile.Text; //tbxPnPfile.text is a propertie, ref not allowed on properties
            BrowseDialog(ref targetStream, "Select Pick and Place file...");
            tbxPnPfile.Text = targetStream;
        }
        /*-------------------------------------------------------------*/
        private void btnBrowseBOM_Click(object sender, EventArgs e)
        {
            string targetStream = tbxBOMfile.Text;
            BrowseDialog(ref targetStream, " Select BOM file...");
            tbxBOMfile.Text = targetStream;
        }

        /// <summary>
        /// Open a Browsedialog for csv files
        /// </summary>
        /// <param name="targetStream">Full path to the csv file</param>
        /// <param name="title">Title of the browse dialog</param>
        private void BrowseDialog(ref string targetStream, string title)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "csv files (.CSV)|*.csv|Text Files (.txt)|*.txt|All Files (*.*)|*.*";
                if (Directory.Exists(targetStream) || (String.IsNullOrEmpty(targetStream))) openDialog.InitialDirectory = targetStream;
                //targetstream doesn't contain a file name or is empty (Path.GetDirectoryName throws an exception when the string is empty)
                else openDialog.InitialDirectory = Path.GetDirectoryName(targetStream);
                //targetstream contains a file name
                openDialog.Title = title;
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    targetStream = openDialog.FileName;
                }
            }
        }

        /// <summary>
        /// Clear all stacklists, and disable the buttens
        /// </summary>
        private void ClearPhases()
        {
            //Events can prevent the garbage collector from removing the object
            //leaving event = (possible) memory leak
            foreach (StackList stackList_ in stacklisters)
            {
                stackList_.updateAllListsEvent -= UpdateAllListsEvent;
            }
            tcPhaseDisplayer.TabPages.Clear();
            stacklisters.Clear();
            this.pnlExportButtons.Enabled = false;
        }
        /*-------------------------------------------------------------*/
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                reelsToPlace.Clear();
                excludedReels.Clear();
                ClearPhases();
                List<Reel> tempReelList = FileOperations.ReadPickAndPlaceFiles(tbxPnPfile.Text, pnpFileParameters, tbxBOMfile.Text, bomFileParameters, pnpMachine.DefaultSpeed);
                while (tempReelList.Count != 0)
                {
                    Footprint reelFootprint = tempReelList[0].Footprint;
                    //Find all matching footprints
                    List<Reel> similarReels = tempReelList.FindAll(reel => reel.ManufacturerPartNumber == reelFootprint.ManufacturerPartNumber); //make a list of all reels who share the footprint
                    tempReelList.RemoveAll(reel => similarReels.Contains(reel)); //remove all the reels from the tempReelList
                    reelFootprint = DatabaseOperations.GetFootprint(reelFootprint.ManufacturerPartNumber);
                    if (reelFootprint != null)
                    {
                        foreach (Reel reel in similarReels)
                        {
                            reel.Footprint = reelFootprint;
                        }
                    }
                    if (pnpMachine.ReelCanBePlaced(similarReels[0])) reelsToPlace.AddRange(similarReels); //reel can be placed -> included list
                    else excludedReels.AddRange(similarReels); //reel can't be placed -> excludedList
                }
            }
            catch (Exception exc)
            {
                reelsToPlace.Clear();
                excludedReels.Clear();
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateListView();
            }
        }

        /// <summary>
        /// Update the listviews on the form
        /// </summary>
        private void UpdateListView()
        {
            GenerateListViewItems(lvIncluded, reelsToPlace);
            GenerateListViewItems(lvExcluded, excludedReels);
        }

        /// <summary>
        /// Fills the ListView with the items from the reelList
        /// </summary>
        /// <param name="lvUpdated">ListView that needs to be filled</param>
        /// <param name="reelList">List with reels to display in the ListView</param>
        private void GenerateListViewItems(ListView lvUpdated, List<Reel> reelList)
        {
            lvUpdated.BeginUpdate();
            lvUpdated.Items.Clear();
            foreach (Reel curReel in reelList)
            {
                string[] reelData = curReel.GenerateListViewText();
                ListViewItem newLvItem = new ListViewItem(reelData);
                newLvItem.ImageIndex = Convert.ToInt32(pnpMachine.ReelCanBePlaced(curReel));
                lvUpdated.Items.Add(newLvItem);
            }
            lvUpdated.EndUpdate();
        }

        /// <summary>
        /// Edit the settings of the selected reel in the lvIncluded ListView
        /// </summary>
        private void EditReel(object sender, EventArgs e)
        {
            if (lvIncluded.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a reel", "no reel selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Find the reel in reelsToPlace
            ListViewItem selectedItem = lvIncluded.SelectedItems[0];
            Reel selectedReel = reelsToPlace.Find(curReel => curReel.GetDisplayString() == selectedItem.Text);
#if DEBUG
            //this only happens when the listview isn't updated when the reelsToPlace list is changed (the reel is in the excludedReels list)
            if (selectedReel == null)
            {
                MessageBox.Show("This error is the result of a bug," + Environment.NewLine + "You shouldn't see this" + Environment.NewLine + "have a nice day, for safety reasens the program wil automaticly close", "critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
#endif
            FootprintForm dialog = new FootprintForm();
            dialog.SetFootprint(selectedReel.Footprint);
            if (dialog.ShowDialog() == DialogResult.Yes)
            {
                StackType oldStackType = selectedReel.Footprint.StackType;
                Footprint footprint = dialog.GetFootprint();
                bool couldBePlaced = pnpMachine.ReelCanBePlaced(selectedReel);
                //Changing MPN = creating/changing footprint, changing reels with the original MPN makes it impossible to break the "connection"
                //between reels with the same MPN
                //however, all reels with the same new MPN need to be updated
                selectedReel.Footprint = footprint; //If the manufacturer part number changes, it needs to be updated
                List<Reel> similarReels = reelsToPlace.FindAll(reel => reel.ManufacturerPartNumber == footprint.ManufacturerPartNumber);
                similarReels.AddRange(excludedReels.FindAll(reel => reel.ManufacturerPartNumber == footprint.ManufacturerPartNumber));
                foreach (Reel reel in similarReels)
                {
                    reel.Footprint = footprint;
                }
                //BUG: a splitted reel is not in the list
                //if ((stacklisters.Count != 0) &&
                //    (couldBePlaced != pnpMachine.ReelCanBeplaced(selectedReel) || (footprint.StackType != oldStackType)))
                //{
                //    //IF the stacks are fild AND
                //    //the ReelCanBePlaced state is changed OR the StackType has changed
                //    //then should the stacks be updated
                //    AssignReels(false);
                //}
                if (stacklisters.Count != 0)
                {
                    AssignReels(false);
                }
                GenerateListViewItems(lvIncluded, reelsToPlace);
            }
        }
        /*-------------------------------------------------------------*/
        private void btnExclude_Click(object sender, EventArgs e)
        {
            MoveReelToOtherListView(lvIncluded, lvExcluded, reelsToPlace, excludedReels);
        }
        /*-------------------------------------------------------------*/
        private void btnInclude_Click(object sender, EventArgs e)
        {
            MoveReelToOtherListView(lvExcluded, lvIncluded, excludedReels, reelsToPlace);
        }

        /// <summary>
        /// Move a reel from one list to the other
        /// </summary>
        /// <param name="lvOrigin">Listview with the selected reel</param>
        /// <param name="originList">List that currently contains the reel</param>
        /// <param name="destinationList">Target list</param>
        private void MoveReelToOtherListView(ListView lvOrigin, ListView lvDestination, List<Reel> originList, List<Reel> destinationList)
        {
            if (lvOrigin.Items.Count == 0)
            {
                return;
            }
            if (lvOrigin.SelectedItems.Count == 0)
            {
                lvOrigin.Items[0].Selected = true;
            }
            ListViewItem selectedLvItem = lvOrigin.SelectedItems[0];
            int indexInReel = originList.FindIndex(curReel => curReel.GetDisplayString() == selectedLvItem.Text);
            Reel reelToMove = originList[indexInReel];

            destinationList.Add(reelToMove);
            originList.Remove(reelToMove);

            //move the listview item:
            lvOrigin.Items.Remove(selectedLvItem);
            lvDestination.Items.Add(selectedLvItem);
            selectedLvItem.ImageIndex = Convert.ToInt32(pnpMachine.ReelCanBePlaced(reelToMove));
        }
        /*-------------------------------------------------------------*/
        private void btnMerge_Click(object sender, EventArgs e)
        {
            //Find all selected reels
            List<Reel> selectedReels = new List<Reel>();
            foreach (ListViewItem selectedItem in lvIncluded.SelectedItems)
            {
                Reel selectedReel = reelsToPlace.Find(curReel => curReel.GetDisplayString() == selectedItem.Text);
                selectedReels.Add(selectedReel);
            }
            //Check if multiple reesl are selected
            if (selectedReels.Count <= 1)
            {
                MessageBox.Show("Please select more the none reel to merge", "warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Ask wich settings to keep
            MergeForm mergeForm = new MergeForm(selectedReels);
            if (mergeForm.ShowDialog() == DialogResult.OK)
            {
                Reel mergedReel = new Reel(selectedReels, mergeForm.SelectedReel); //new merged reel
                //remove the old reels
                foreach (Reel reelToRemove in selectedReels)
                {
                    reelsToPlace.Remove(reelToRemove);
                }
                reelsToPlace.Add(mergedReel);
                GenerateListViewItems(lvIncluded, reelsToPlace); //only the included list must be updated
                if (stacklisters.Count != 0) AssignReels(false);
            }

        }
        /*-------------------------------------------------------------*/
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            AssignReels(true);
        }

        /// <summary>
        /// Checks all reels and fill the stacks automatic with the good reels
        /// </summary>
        /// <param name="showWarnings">True if warnings are shown, else false</param>
        private void AssignReels(bool showWarnings)
        {
            //1) Filter the reels
            List<Reel> acceptedReels = new List<Reel>();
            acceptedReels = reelsToPlace.FindAll(curReel => pnpMachine.ReelCanBePlaced(curReel));
            if (showWarnings)
            {
                //Show warnings to the user
                if (acceptedReels.Count == 0)
                {
                    MessageBox.Show("No reels accepted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int numberRejected = reelsToPlace.Count - acceptedReels.Count;
                //Not all components are accepted
                if ((numberRejected != 0) &&
                    (MessageBox.Show(numberRejected.ToString() + " rejected" + Environment.NewLine + "Do you want to continue?",
                     "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)) return;
            }
            //2) clear the old tabPages
            ClearPhases();

            //3) split the list: top and bottom
            List<Reel> topReels, bottomReels;

            Reel.SplitReelList(acceptedReels, out topReels, out bottomReels);
            FillStackListers(topReels);
            FillStackListers(bottomReels);


            int index = 0;
            while (index < stacklisters.Count)
            {
                if (stacklisters[index].Layer == ReelLayer.Top)
                {
                    stacklisters[index].SetTotalList(topReels);
                }
                else if (stacklisters[index].Layer == ReelLayer.Bottom)
                {
                    stacklisters[index].SetTotalList(bottomReels);
                }
                else if (!stacklisters[index].ContainsReels)
                {
                    //Stacklayer == both -> empty stacklist
                    //if, for some reasen (reasen = bug), the layer is both and it contains reels, it should not be removed
                    StackList removedStackList = stacklisters[index]; //need pointer to control for dispose
                    removedStackList.updateAllListsEvent -= UpdateAllListsEvent;
                    stacklisters.RemoveAt(index);
                    removedStackList.Dispose();
                    continue;
                }
                GenerateTabPage(stacklisters[index]);
                index++; //index > 0 
            }
            if (index != 0)
            {
                this.pnlExportButtons.Enabled = true;
            }
        }

        /// <summary>
        /// Create stackList controls and fills them with the reels, one layer only
        /// </summary>
        /// <param name="reelsToFill">Reels to fill in the stackControls</param>
        private void FillStackListers(List<Reel> reelsToFill)
        {
            if (reelsToFill.Count == 0) return;
            GenerateNewPhase();
            int reelIndex = 0;

            //foreach (Reel goodReel in reelsToFill)
            while (reelIndex < reelsToFill.Count)
            {
                Reel goodReel = reelsToFill[reelIndex];
                List<StackList> matchingStackListers = stacklisters.FindAll(stacklister => ((stacklister.Layer == ReelLayer.Both) || (stacklister.Layer == goodReel.ReelLayer)));
                if (matchingStackListers.Count == 0)
                {
                    matchingStackListers.Add(GenerateNewPhase());
                }
                int index = 0;
                bool succes = false;
                do
                {
                    succes = matchingStackListers[index].AddReel(goodReel);
                    index++; //go to next (in case it failed)
                    if ((index == matchingStackListers.Count) && (!succes))
                    {
                        StackList newStackControl = GenerateNewPhase();
                        if (!newStackControl.AddReel(goodReel))
                        {
                            //this reel can't be added
                            //newStackControl.updateAllListsEvent -= updateAllListsEvent;
                            //stacklisters.Remove(newStackControl);
                            //newStackControl.Dispose();
                            reelIndex--; //go to previous : otherwise a reel could be skipped
                            reelsToFill.Remove(goodReel);
                        }
                        succes = true;
                    }
                } while (!succes);
                reelIndex++;
            }
        }

        /// <summary>
        /// Initializes and configure a new TabPage for the tcPhaseDisplayer
        /// </summary>
        /// <returns>New TabPage for the tcPhaseDisplayer</returns>
        private void GenerateTabPage(StackList newControl)
        {
            TabPage newPage = new TabPage();
            int phase = newControl.PhaseNumber;
            newPage.Padding = new System.Windows.Forms.Padding(0);
            newPage.Name = "tpPhase" + phase.ToString();
            newPage.Text = "phase " + phase.ToString();
            newPage.UseVisualStyleBackColor = true;
            newPage.Controls.Add(newControl);
            tcPhaseDisplayer.Controls.Add(newPage); //This must happen BEFORE the imagekey is changed
            newPage.ImageKey = newControl.Layer.ToString();
        }

        /// <summary>
        /// Generates a new phase
        /// </summary>
        /// <returns>Returns the associated stacklist user control</returns>
        private StackList GenerateNewPhase()
        {
            StackList newControl = new StackList(pnpMachine, stacklisters.Count + 1);
            newControl.Name = "stackList";
            newControl.updateAllListsEvent += UpdateAllListsEvent;
            stacklisters.Add(newControl);
            return newControl;
        }

        /// <summary>
        /// Handler for the updateAllListEvent, this event occurs when one of the comboboxes of the stackcontrols is changed,
        /// When that happens the sendersOldReel and the senders new reel change position
        /// </summary>
        /// <param name="sender">Stackcontrol who started the update event</param>
        /// <param name="sendersOldReel">The old reel of the stackControl</param>
        private void UpdateAllListsEvent(StackControl sender, Reel sendersOldReel)
        {
            foreach (StackList stackList_ in stacklisters)
            {
                if (stackList_.UpdateAllLists(sender, sendersOldReel)) return; //If the change has happend return, no need to check the ohters
            }
        }
        /*-------------------------------------------------------------*/
        private void btnLdStackConfig_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openDialog = new OpenFileDialog())
                {
                    openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    openDialog.Filter = "csv files (.CSV)|*.csv|Text Files (.txt)|*.txt|All Files (*.*)|*.*";
                    openDialog.Title = "Please select a pnp machine file...";
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        //HOW IT WORKS:
                        //1)get the reel list of the displayed layer
                        StackList oldStackList = (StackList)tcPhaseDisplayer.SelectedTab.Controls["stackList"];
                        List<Reel> stackReelList = oldStackList.GetTotalList();

                        //2) Make a new phase
                        string[] stackConfig = pnpMachine.LoadStackConfiguration(openDialog.FileName);
                        //StackList newStackList = new StackList(pnpMachine, openDialog.FileName, stackReelList);
                        StackList newStackList = new StackList(pnpMachine, stackConfig, stackReelList);
                        newStackList.Name = "stackList";
                        newStackList.updateAllListsEvent += UpdateAllListsEvent;
                        stacklisters.Add(newStackList);

                        //3) Try to add all components to the new stackList
                        foreach (Reel stackReel in stackReelList)
                        {
                            newStackList.AddReelWithUpdate(stackReel);
                        }
                        //4) 
                        int phaseCounter = 0;
                        tcPhaseDisplayer.TabPages.Clear();
                        stacklisters = stacklisters.OrderBy(stacklist_ => stacklist_.Layer).ToList();
                        //http://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object

                        while (phaseCounter < stacklisters.Count)
                        {
                            StackList curStackList = stacklisters[phaseCounter];
                            if (curStackList.ContainsReels)
                            {
                                phaseCounter++;
                                curStackList.PhaseNumber = phaseCounter;
                                GenerateTabPage(curStackList);
                            }
                            else
                            {
                                curStackList.updateAllListsEvent -= UpdateAllListsEvent;
                                stacklisters.Remove(curStackList);
                                curStackList.Dispose();
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save specific phase at the given location
        /// </summary>
        /// <param name="path">The complete file path to write to</param>
        /// <param name="phase">Phase to save</param>
        private void ExportData(string path, StackList phase)
        {
            float originOffsetX = (float)bscOrigin.ValueX;
            float originOffsetY = (float)bscOrigin.ValueY;
            float boardWidth = (float)bscDimensions.ValueX;
            float boardLength = (float)bscDimensions.ValueY;
            BoardSettings boardSettings = new BoardSettings(originOffsetX, originOffsetY, boardWidth, boardLength);
            boardSettings.BoardsX = Convert.ToInt32(bscNumberOfBoards.ValueX);
            boardSettings.BoardsY = Convert.ToInt32(bscNumberOfBoards.ValueY);
            boardSettings.DistanceX = (float)bscDistBetwBoards.ValueX;
            boardSettings.DistanceY = (float)bscDistBetwBoards.ValueY;
            pnpMachine.ExportToFile(path, boardSettings, phase);
        }
        /*-------------------------------------------------------------*/
        private void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = Path.Combine(folder, projectName + ".csv");
            StackList stackListToExport = (StackList)tcPhaseDisplayer.SelectedTab.Controls["stackList"];
            try
            {
                ExportData(fileName, stackListToExport);
                MessageBox.Show("File has been successfully exported");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*-------------------------------------------------------------*/
        private void btnExportAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tcPhaseDisplayer.TabCount; i++)
                {
                    string phase = tcPhaseDisplayer.TabPages[i].Text.Replace(' ', '_');
                    string fileName = Path.Combine(folder, projectName + "_" + phase + ".csv");
                    StackList stackListToExport = (StackList)tcPhaseDisplayer.TabPages[i].Controls["stackList"];
                    ExportData(fileName, stackListToExport);
                    //ExportData(fileName, stacklisters[i]);
                }
                MessageBox.Show("Files have been successfully exported", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + Environment.NewLine + "Some files may have been exported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Update the boards settings controls and the speed of the reels
        /// </summary>
        private void ChangeMachineType()
        {
            bscDimensions.MaximumX = pnpMachine.Width;
            bscDimensions.MaximumY = pnpMachine.Length;
            bscDistBetwBoards.MaximumX = pnpMachine.Width;
            bscDistBetwBoards.MaximumY = pnpMachine.Length;
            bscOrigin.MaximumX = pnpMachine.Width;
            bscOrigin.MinimumX = -pnpMachine.Width;
            bscOrigin.MaximumY = pnpMachine.Length;
            bscOrigin.MinimumY = -pnpMachine.Length;

            UpdateListView(); //update icons: perhaps some components cannot be placed anymore
            if (stacklisters.Count != 0) AssignReels(false);
            //Stacks need to be refild, user should not get the warning "Do you want to continue?"
        }

        /// <summary>
        /// Update the boards settings controls and the speed of the reels
        /// </summary>
        /// <param name="newMachine">New machine that replaces pnpMachine</param>
        private void ChangeMachineType(IMachine newMachine)
        {
            pnpMachine = newMachine;
            ChangeMachineType();
        }
        /*-------------------------------------------------------------*/
        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();

            settingsForm.Machine = pnpMachine;
            settingsForm.ProjectFolder = folder;
            settingsForm.ProjectName = projectName;
            settingsForm.SetFileSettings(pnpFileParameters, bomFileParameters);

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                folder = settingsForm.ProjectFolder;
                projectName = settingsForm.ProjectName;
                settingsForm.GetFileSettings(out pnpFileParameters, out bomFileParameters);

                IMachine oldPnpMachine = pnpMachine;
                pnpMachine = settingsForm.Machine;
                if (!pnpMachine.IsSameMachine(oldPnpMachine))
                {
                    //refill the lists and if necessary, the stacklisters too
                    foreach (Reel reel_ in reelsToPlace)
                    {
                        reel_.Speed = pnpMachine.DefaultSpeed;
                    }
                    foreach (Reel reel_ in excludedReels)
                    {
                        reel_.Speed = pnpMachine.DefaultSpeed;
                    }
                    ChangeMachineType();
                    //UpdateListView(); (this is included in ChangeMachineType)
                }
            }
        }
        /*-------------------------------------------------------------*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Project files|*.PrjPnp|CSV files|*.csv|Text Files|*.txt|All Files|*.*";
                saveDialog.Title = "Save project";
                saveDialog.FileName = projectName;
                saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    PnpProject project = new PnpProject(saveDialog.FileName);
                    project.Machine = pnpMachine;
                    project.ProjectName = projectName;
                    project.ProjectFolder = folder;
                    project.HorizontalOriginOffset = (float)bscOrigin.ValueX;
                    project.VerticalOriginOffset = (float)bscOrigin.ValueY;
                    project.BoardsX = (int)bscNumberOfBoards.ValueX;
                    project.BoardsY = (int)bscNumberOfBoards.ValueX;
                    project.DistanceX = (float)bscDistBetwBoards.ValueX;
                    project.DistanceY = (float)bscDistBetwBoards.ValueY;
                    project.BoardWidth = (float)bscDimensions.ValueX;
                    project.BoardLength = (float)bscDimensions.ValueY;
                    project.IncludedReels = reelsToPlace;
                    project.ExcludedReels = excludedReels;
                    project.StackListers = stacklisters;
                    FileOperations.SaveProject(project);
                }
            }
        }
        /*-------------------------------------------------------------*/
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openDialog = new OpenFileDialog())
                {
                    openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    openDialog.Filter = "Project files|*.PrjPnp|CSV files|*.csv|Text Files|*.txt|All Files|*.*";
                    openDialog.Title = "Please select a pick and place project file...";
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        PnpProject project = new PnpProject(openDialog.FileName);
                        FileOperations.LoadProject(project);
                        ClearPhases();
                        projectName = project.ProjectName;
                        folder = project.ProjectFolder;
                        bscOrigin.ValueX = (decimal)project.HorizontalOriginOffset;
                        bscOrigin.ValueY = (decimal)project.VerticalOriginOffset;
                        bscNumberOfBoards.ValueX = (decimal)project.BoardsX;
                        bscNumberOfBoards.ValueY = (decimal)project.BoardsY;
                        bscDistBetwBoards.ValueX = (decimal)project.DistanceX;
                        bscDistBetwBoards.ValueY = (decimal)project.DistanceY;
                        bscDimensions.ValueX = (decimal)project.BoardWidth;
                        bscDimensions.ValueY = (decimal)project.BoardLength;
                        reelsToPlace = project.IncludedReels;
                        excludedReels = project.ExcludedReels;
                        //stacklisters = project.StackListers;
                        //pnpMachine = project.Machine;
                        ChangeMachineType(project.Machine);
                        stacklisters = project.StackListers;
                        //UpdateListView(); (included in change machinetype)
                        if (stacklisters.Count != 0)
                        {
                            for (int i = 0; i < stacklisters.Count; i++)
                            {
                                stacklisters[i].updateAllListsEvent += UpdateAllListsEvent;
                                GenerateTabPage(stacklisters[i]);
                                if (stacklisters[i].Layer == ReelLayer.Top)
                                {
                                    stacklisters[i].SetTotalList(project.TopReels);
                                }
                                else
                                {
                                    stacklisters[i].SetTotalList(project.BottomReels);
                                }
                            }
                            this.pnlExportButtons.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*-------------------------------------------------------------*/
        private void llblVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(llblVersion.Links[0].LinkData as string);
        }
        /*-------------------------------------------------------------*/
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                FileOperations.SaveConfigFile(pnpFileParameters, bomFileParameters);
            }
            catch
            {
                MessageBox.Show("Unable to save your configuration," + Environment.NewLine +
                    "Is the config file used by another program?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
/*Part of the GUI designs were inspired by the PnPconverter C# project of ing. Yannick Verbelen */
