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
using System.Reflection;
using PickAndPlaceLib;

namespace PickAndPlace
{
    /// <summary>
    /// Represents a dialog to manage the settings of the current pick and place project
    /// </summary>
    public partial class SettingsForm : Form
    {
        IMachine machine_;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.SettingsForm"/>
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
            Type[] machineTypes = { typeof(TM220A), typeof(TM240A) }; //Add new machine types here
            cbxMachine.Items.AddRange(machineTypes);
            cbxMachine.DisplayMember = "Name";

            cbxNozzle1.DataSource = Enum.GetValues(typeof(Nozzle)); //don't set cbxNozzle1.DataSource = cbxNozzle2.DataSource:
            cbxNozzle2.DataSource = Enum.GetValues(typeof(Nozzle)); //effect: cbxNozzle1.SelectedItem = cbxNozzle2.SelectedItem (pointer) (alternative: clone());

            dgPnpFilePara.DefaultCellStyle.SelectionForeColor = dgPnpFilePara.DefaultCellStyle.ForeColor;
            dgBomFilePara.DefaultCellStyle.SelectionForeColor = dgBomFilePara.DefaultCellStyle.ForeColor;
        }

        /// <summary>
        /// Gets or sets the machine and its settings currently active
        /// </summary>
        public IMachine Machine
        {
            get { return machine_; }
            set
            {
                cbxMachine.SelectedItem = value.GetType();
                //machine with more or less nozzles (now all machines have 2 nozzles) -> foreach
                //foreach also needs to create the user controls -> create new usercontrol child class
                //for now this works fine
                cbxNozzle1.SelectedItem = value.EquippedNozzles[0];
                cbxNozzle2.SelectedItem = value.EquippedNozzles[1];
                nudSpeed.Minimum = (decimal)value.MinSpeed;
                nudSpeed.Maximum = (decimal)value.MaxSpeed;
                nudSpeed.Value = (decimal)value.DefaultSpeed;
            }
        }

        /// <summary>
        /// Gets or sets the folder displayed in the project folder textbox
        /// </summary>
        public string ProjectFolder
        {
            get { return this.tbxFolder.Text; }
            set { tbxFolder.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the project displayed in the project textbox
        /// </summary>
        public string ProjectName
        {
            get { return this.tbxProjectName.Text; }
            set { this.tbxProjectName.Text = value; }
        }

        /// <summary>
        /// Sets the displayed file parameters (headers of the files)
        /// </summary>
        /// <param name="pnpFileParameters">Headers of the pick and place file</param>
        /// <param name="bomFileParameters">Headers of the BOM</param>
        public void SetFileSettings(string[] pnpFileParameters, string[] bomFileParameters)
        {
            dgPnpFilePara.Rows.Add(new string[] { "Designator", pnpFileParameters[0] });
            dgPnpFilePara.Rows.Add(new string[] { "x coordinate", pnpFileParameters[1] });
            dgPnpFilePara.Rows.Add(new string[] { "y coordinate", pnpFileParameters[2] });
            dgPnpFilePara.Rows.Add(new string[] { "layer", pnpFileParameters[3] });
            dgPnpFilePara.Rows.Add(new string[] { "Rotation", pnpFileParameters[4] });
            dgPnpFilePara.Rows.Add(new string[] { "comment", pnpFileParameters[5] });


            dgPnpFilePara.FitHeight();
            dgPnpFilePara.ScrollBars = ScrollBars.None; //hack to hide the gray row below the table
            dgBomFilePara.Location = new Point(dgBomFilePara.Location.X, dgPnpFilePara.Location.Y + dgPnpFilePara.Height + 15);


            dgBomFilePara.Rows.Add(new string[] { "Designator", bomFileParameters[0] });
            dgBomFilePara.Rows.Add(new string[] { "manufacturer part number", bomFileParameters[1] });
            //dgBomFilePara.Height = dgBomFilePara.Rows.GetRowsHeight(DataGridViewElementStates.None) + dgBomFilePara.ColumnHeadersHeight;
            //Doesn't work with mono
            dgBomFilePara.FitHeight();
            dgBomFilePara.ScrollBars = ScrollBars.None; //Hide the gray row below the table
        }

        /// <summary>
        /// Returns the headers for the pick and place file and the BOM
        /// </summary>
        /// <param name="pnpFileParameters">Headers of the pick and place file</param>
        /// <param name="bomFileParameters">Headers of the BOM</param>
        public void GetFileSettings(out string[] pnpFileParameters, out string[] bomFileParameters)
        {
            pnpFileParameters = GetData(dgPnpFilePara);
            bomFileParameters = GetData(dgBomFilePara);
        }

        /// <summary>
        /// Returns the values from the second column of the datagridview
        /// </summary>
        /// <param name="dgData">Datagridview with data</param>
        /// <returns>Data from the datagridview</returns>
        private string[] GetData(DataGridView dgData)
        {
            int rows = dgData.Rows.Count;
            string[] result = new string[rows];
            for (int index = 0; index < rows; index++)
            {
                result[index] = dgData.Rows[index].Cells[1].Value.ToString();
            }
            return result;
        }
        /*-------------------------------------------------------------*/
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxProjectName.Text == "")
                {
                    MessageBox.Show("Project needs a name");
                    return;
                }

                machine_ = (IMachine)Activator.CreateInstance((Type)cbxMachine.SelectedItem);
                machine_.SetNozzle(0, (Nozzle)cbxNozzle1.SelectedItem);
                machine_.SetNozzle(1, (Nozzle)cbxNozzle2.SelectedItem);
                machine_.DefaultSpeed = (int)nudSpeed.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Something went wrong:" + Environment.NewLine + exc.Message);
                //Many things can go wrong with the CreateInstance method
            }
        }
        /*-------------------------------------------------------------*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /*-------------------------------------------------------------*/
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (System.IO.Directory.Exists(tbxFolder.Text)) dialog.SelectedPath = tbxFolder.Text;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) tbxFolder.Text = dialog.SelectedPath;
        }
    }
}
