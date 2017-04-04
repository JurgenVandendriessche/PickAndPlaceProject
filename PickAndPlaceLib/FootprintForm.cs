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


namespace PickAndPlaceLib
{
    /// <summary>
    /// Represents a dialog for creating or editing a <see cref="PickAndPlaceLib.Footprint"/>
    /// </summary>
    public partial class FootprintForm : Form
    {
        private Footprint footPrint_;
        private bool newFootprintMade_;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceLib.FootprintForm"/>
        /// </summary>
        public FootprintForm()
        {
            InitializeComponent();
            cbxNozzle.DataSource = Enum.GetValues(typeof(Nozzle));
            foreach (StackType stackType_ in Enum.GetValues(typeof(StackType)))
            {
                cbxStackType.Items.Add(PNPconverterTools.StackTypeToString(stackType_));
            }
            cbxStackType.SelectedIndex = 0;
            try
            {
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                source.AddRange(DatabaseOperations.GetFootprintList().ToArray());
                tbxMPN.AutoCompleteCustomSource = source;
                tbxMPN.AutoCompleteMode = AutoCompleteMode.Suggest;
                tbxMPN.AutoCompleteSource = AutoCompleteSource.CustomSource;
                tbxMPN.Leave += tbxMPN_Leave;

            }
            catch
            {
                //failed to load the database
                tbxMPN.AutoCompleteMode = AutoCompleteMode.None;
                tbxMPN.AutoCompleteSource = AutoCompleteSource.None;
            }
        }

        /// <summary>
        /// Sets the footprint to be edited by displaying its properties
        /// </summary>
        /// <param name="footprint">Footprint to be edited</param>
        public void SetFootprint(Footprint footprint)
        {
            tbxMPN.Text = footprint.ManufacturerPartNumber;
            nudHeight.Value = (decimal)footprint.Height;
            nudLength.Value = (decimal)footprint.Length;
            nudWidth.Value = (decimal)footprint.Width;
            nudRotation.Value = footprint.Rotation;
            bscOffset.ValueX = (decimal)footprint.OffsetStackX;
            bscOffset.ValueY = (decimal)footprint.OffsetStackY;
            cbxNozzle.SelectedItem = footprint.Nozzle;
            cbxStackType.SelectedItem = PNPconverterTools.StackTypeToString(footprint.StackType);
            nudFeedRate.Value = (decimal)footprint.FeedRate;
        }

        /// <summary>
        /// Gets the footprint
        /// </summary>
        /// <returns>Generated footprint</returns>
        public Footprint GetFootprint()
        {
            return footPrint_;
        }

        /// <summary>
        /// Gets the footprint
        /// </summary>
        /// <param name="newFootprintMade">Returns true if a new footprint was added to the database, false if a footprint was edited</param>
        /// <returns>Generated footprint</returns>
        public Footprint GetFootprint(out bool newFootprintMade)
        {
            newFootprintMade = newFootprintMade_;
            return footPrint_;
        }
        /*-------------------------------------------------------------*/
        private void tbxMPN_Leave(object sender, EventArgs e)
        {
            Footprint loadedFootprint = DatabaseOperations.GetFootprint(tbxMPN.Text);
            if (loadedFootprint != null) this.SetFootprint(loadedFootprint);
        }
        /*-------------------------------------------------------------*/
        private void cbxStackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStackType.SelectedItem.ToString() == PNPconverterTools.StackTypeToString(StackType.Tray18mm))
            {
                nudFeedRate.Value = 18;
                nudFeedRate.Enabled = false;
            }
            else
            {
                nudFeedRate.Enabled = true;
            }
        }
        /*-------------------------------------------------------------*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxMPN.Text))
            {
                MessageBox.Show("Please enter a valid manufacturer part number", "Error: invalid manufacturer part number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (tbxMPN.Text.Contains(','))
            {
                MessageBox.Show("manufacturer part number contains a ','" + Environment.NewLine + "this is not allowed.", "Error: Comma not allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                //Generate new footprint
                string manufacturerPartNumber = tbxMPN.Text;
                float width = (float)nudWidth.Value;
                float length = (float)nudLength.Value;
                float height = (float)nudHeight.Value;
                int rotation = Convert.ToInt32(nudRotation.Value);
                float offsetX = (float)bscOffset.ValueX;
                float offsetY = (float)bscOffset.ValueY;
                float feedRate = (float)nudFeedRate.Value;
                StackType stackType = PNPconverterTools.StringToStackType(cbxStackType.SelectedItem.ToString());
                footPrint_ = new Footprint(manufacturerPartNumber, width, length, height, rotation, offsetX, offsetY, feedRate, (Nozzle)cbxNozzle.SelectedItem, stackType);
                newFootprintMade_ = !DatabaseOperations.FootprintExists(footPrint_.ManufacturerPartNumber);
                if (newFootprintMade_)
                {
                    //new footprint
                    DatabaseOperations.AddNewFootprint(footPrint_);
                }
                else
                {
                    //change of values
                    DatabaseOperations.UpdateFootprint(footPrint_);
                }
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*-------------------------------------------------------------*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //newFootprintMade = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
