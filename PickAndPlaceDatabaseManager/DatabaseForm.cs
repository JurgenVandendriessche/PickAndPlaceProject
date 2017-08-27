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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PickAndPlaceLib;

namespace PickAndPlaceDatabaseManager
{
    /// <summary>
    /// Form that contains all operations for managing the pick and place database
    /// </summary>
    public partial class DatabaseForm : Form
    {

        DataTable footprintTable;
        DataView tableView;
        ToolTip ttProgress;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceDatabaseManager.DatabaseForm"/>
        /// </summary>
        public DatabaseForm()
        {
            InitializeComponent();
            //http://stackoverflow.com/questions/9160059/set-up-dot-instead-of-comma-in-numeric-values
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            this.HelpRequested += ExtensionMethods.ShowHelp;
            this.WindowState = FormWindowState.Maximized;
            ttProgress = new ToolTip();
            footprintTable = new DataTable();
            tableView = new DataView(footprintTable); //Directly binding the DataTable to the DataGridView doesn't work on linux.
            //dgvFootprints.DataSource = tableView; //This did not work either (moved it to load function) 
        }

        /// <summary>
        /// Displays the <see cref="PickAndPlaceDatabaseManager.FootprintForm"/> and handles the changes to the data.
        /// </summary>
        /// <param name="footprintForm">FootprintForm to display</param>
        private void ShowFootprintForm(FootprintForm footprintForm)
        {
            try
            {
                if (footprintForm.ShowDialog() == DialogResult.Yes)
                {
                    bool newFootprintMade;
                    Footprint footprint = footprintForm.GetFootprint(out newFootprintMade);
                    //The footprintForm makes/updates the footprint in the database
                    DataRow datarow;
                    if (newFootprintMade)
                    {
                        //reloading the complete database would be waste of resorces.
                        //solution: manualy adding the new component to the datatable
                        datarow = footprintTable.NewRow();
                        datarow["manufacturerPartNumber"] = footprint.ManufacturerPartNumber;
                        footprintTable.Rows.Add(datarow);
                    }
                    else
                    {
                        //Update the edited row
                        datarow = footprintTable.Select("manufacturerPartNumber = '" + footprint.ManufacturerPartNumber + "'")[0];
                    }
                    datarow["Length"] = footprint.Length;
                    datarow["Height"] = footprint.Height;
                    datarow["width"] = footprint.Width;
                    datarow["offsetStackX"] = footprint.OffsetStackX;
                    datarow["offsetStackY"] = footprint.OffsetStackY;
                    datarow["feedRate"] = footprint.FeedRate;
                    datarow["rotation"] = footprint.Rotation;
                    datarow["nozzle"] = footprint.Nozzle;
                    datarow["stacktype"] = footprint.StackType;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Edit the selected footprint
        /// </summary>
        private void EditFootprint()
        {
            string selectedMPN = dgvFootprints.CurrentRow.Cells[0].Value.ToString();
            Footprint footprint = DatabaseOperations.GetFootprint(selectedMPN);
            FootprintForm footprintForm = new FootprintForm();
            footprintForm.SetFootprint(footprint);
            this.ShowFootprintForm(footprintForm);
        }
        /*-------------------------------------------------------------*/
        private void DatabaseForm_Load(object sender, EventArgs e)
        {
            bool succes = false;
            do
            {
                try
                {
                    DatabaseOperations.GetFootprintDataTable(footprintTable);
                    dgvFootprints.DataSource = tableView;
                    //moved to loading function, this seems to help on linux to solve a bug that results in not displaying the table.
                    succes = true;
                }
                catch (Exception exc)
                {
                    if (MessageBox.Show(exc.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                    {
                        this.Close();
                        return;
                    }
                }
            } while (!succes);
            for (int i = 0; i < dgvFootprints.Columns.Count; i++)
            {
                clbColumnsDisplay.Items.Add(dgvFootprints.Columns[i].HeaderText);
                clbColumnsDisplay.SetItemChecked(i, true);
            }
        }
        /*-------------------------------------------------------------*/
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FootprintForm footprintForm = new FootprintForm();
            this.ShowFootprintForm(footprintForm);
        }
        /*-------------------------------------------------------------*/
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditFootprint();
        }
        /*-------------------------------------------------------------*/
        private void dgvFootprints_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) EditFootprint();
        }
        /*-------------------------------------------------------------*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //First cell of the selected row contains the footprints manufacturer part number
                string selectedMPN = dgvFootprints.CurrentRow.Cells[0].Value.ToString();
                DatabaseOperations.RemoveFootprint(selectedMPN);
                DataGridViewRow selectedRow = dgvFootprints.CurrentRow;
                dgvFootprints.Rows.Remove(selectedRow);
                footprintTable.AcceptChanges(); //update the table
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*-------------------------------------------------------------*/
        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterForm filterDialog = new FilterForm();
            if (filterDialog.ShowDialog() == DialogResult.Yes)
            {
                tableView.RowFilter = filterDialog.GetFilterString();
            }
        }
        /*-------------------------------------------------------------*/
        private void btnClear_Click(object sender, EventArgs e)
        {
            tableView.RowFilter = String.Empty;
        }
        /*-------------------------------------------------------------*/
        private void clbColumnsDisplay_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string headerText = clbColumnsDisplay.Items[e.Index].ToString(); //Find wich column needs to be displayed / hide
            dgvFootprints.Columns[headerText].Visible = (e.NewValue == CheckState.Checked);// Display or hide the column
        }
        /*-------------------------------------------------------------*/
        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openDialog.Filter = "database files (*.db) | *.db| All files (*.*) | *.*";
                openDialog.Title = "select database to import...";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    //http://stackoverflow.com/questions/19768718/updating-progressbar-external-class
                    Progress<Tuple<int, int>> progress = new Progress<Tuple<int, int>>();
                    progress.ProgressChanged += UpdateProgressBar;
                    Task.Run(() => DatabaseOperations.ImportDatabase(openDialog.FileName, progress)); //Start parallel task
                }
            }
        }
        /*-------------------------------------------------------------*/
        private void UpdateProgressBar(object sender, Tuple<int, int> e)
        {
            pbTransfer.Maximum = e.Item2;
            pbTransfer.Value = e.Item1;
            double progressPct = 0;
            if (e.Item2 != 0) progressPct = e.Item1 * 100.00 / e.Item2;
            ttProgress.SetToolTip(pbTransfer, String.Format("progress: {0:N0}%", progressPct));
            if (e.Item1 == e.Item2)
            {
                //100%
                DatabaseOperations.GetFootprintDataTable(footprintTable);
            }
        }
        /*-------------------------------------------------------------*/
        private void dgvFootprints_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditFootprint();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}