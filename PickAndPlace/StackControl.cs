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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PickAndPlaceLib;

namespace PickAndPlace
{
    /// <summary>
    /// Visually represents a single stack of a pick and place machine
    /// </summary>
    public partial class StackControl : UserControl
    {
        /// <summary>
        /// Delegate for <see cref="PickAndPlace.StackControl.ReelChanged"/> events
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="oldReel">Old reel of the sender</param>
        public delegate void ReelChangedHandler(StackControl sender, Reel oldReel);
        /// <summary>
        /// Occurs when the user changes the reel of the control
        /// </summary>
        public event ReelChangedHandler ReelChanged;

        private const int minWidth = 380;
        private StackType myType = StackType.Reel08mm;
        private Reel reel_;
        private List<Reel> ptrcbxList;
        private string manufacturerPartNumber_;

        /// <summary>
        /// This is for the visual studio IDE, not to be used
        /// </summary>
        private StackControl()
        {
            InitializeComponent();
            this.cbxReels.SelectedIndexChanged += cbxAvailable_SelectedIndexChanged;
            this.cbLocked.CheckedChanged += cbLocked_CheckedChanged;
            this.nudSpeed.ValueChanged += nudSpeed_ValueChanged;
            this.cbxReels.DropDown += cbxReels_DropDown;
            this.cbxReels.Sorted = true;
        }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.StackControl"/>
        /// </summary>
        /// <param name="stackType">Stack type of the new control</param>
        public StackControl(StackType stackType, int number)
            : this()
        {
            myType = stackType;
            lblStackType.Text = number.ToString() +") " + PNPconverterTools.StackTypeToString(stackType);
        }

        /// <summary>
        /// Gets the stackType of the control
        /// </summary>
        public StackType StackType
        {
            get { return this.myType; }
        }

        /// <summary>
        /// Gets or sets the manufacturer part number of the current control
        /// </summary>
        public string ManufacturerPartNumber
        {
            get { return this.manufacturerPartNumber_; }
            set { this.manufacturerPartNumber_ = value; }
        }

        /// <summary>
        /// Maximum speed that can be set by the user
        /// </summary>
        public decimal MaxSpeed
        {
            get { return nudSpeed.Maximum; }
            set { this.nudSpeed.Maximum = value; }
        }

        /// <summary>
        /// Minimum speed that can be set by the user
        /// </summary>
        public decimal MinSpeed
        {
            get { return nudSpeed.Minimum; }
            set { this.nudSpeed.Minimum = value; }
        }

        /// <summary>
        /// Gets or sets the speed of the stackControl
        /// </summary>
        public decimal Speed
        {
            get { return this.nudSpeed.Value; }
            set
            {
                if ((this.nudSpeed.Minimum <= value) && (this.nudSpeed.Maximum >= value))
                    this.nudSpeed.Value = value;
            }
        }

        /// <summary>
        /// Gets the reel of the current control
        /// </summary>
        public Reel Reel
        {
            get { return this.reel_; }
        }

        /// <summary>
        /// Sets the reel of the current control
        /// </summary>
        /// <param name="value">Reel to be se</param>
        /// <param name="locked">Control is in the locked state (reel can't be moved to other <see cref="PickAndPlace.StackControl"/>)</param>
        public void SetReel(Reel reel, bool locked)
        {
            if (reel.Footprint.StackType == this.myType)
            {
                this.cbLocked.CheckedChanged -= cbLocked_CheckedChanged;
                this.reel_ = reel;
                this.nudSpeed.Value = reel_.Speed;
                this.cbLocked.Checked = locked;
                this.nudSpeed.Enabled = !locked;
                this.cbxReels.Enabled = !locked;
                this.cbLocked.CheckedChanged += cbLocked_CheckedChanged;
#if DEBUG
                if (reel.ReelLayer == ReelLayer.Both) this.BackColor = Color.Chocolate;
                //Visual indicator that something is wrong. Why Chocolate? I like eating Chocolate.
#endif
            }
        }

        /// <summary>
        /// Sets the reel and throw a new <see cref="PickAndPlace.StackControl.ReelChanged"/> event
        /// </summary>
        /// <param name="value">Reel to be set</param>
        public void SetReelWithUpdate(Reel value)
        {
            if (value.ManufacturerPartNumber == this.manufacturerPartNumber_)
                SetReel(value, false);
            RefreshList();
            if (ReelChanged != null) ReelChanged(this, null);
        }

        /// <summary>
        /// Changes the reel of the current control (USE ONLY DURING SWITCHING)
        /// </summary>
        /// <param name="newReel">New reel of the control</param>
        public void ChangeReel(Reel newReel)    
        {
            this.reel_ = newReel;
            //this.manufacturerPartNumber_ = newReel.footprint.manufacturerPartNumber; //Optional: mpn is only used for loading configuration
            RefreshList();
        }

        /// <summary>
        /// Sets the list reels in the combobox
        /// </summary>
        /// <param name="totalList">List of reels for the combobox</param>
        public void SetList(List<Reel> totalList)
        {
            ptrcbxList = totalList;
            if (this.cbLocked.Checked)
            {
                cbxReels.Enabled = false;
                nudSpeed.Enabled = false;
                cbLocked.Text = "locked";
                ptrcbxList.Remove(this.reel_);
            }
            RefreshList();
        }

        /// <summary>
        /// Gets a string that represents the current stackControl in a project saved file
        /// </summary>
        /// <returns>String that represents the current stackControl in a project saved file</returns>
        public string SaveStack()
        {
            string result = "Designator=";
#if DEBUG
            if (this.reel_ != null && this.reel_.Components.Count != 0)
            {
                result += this.reel_.Components[0].Designator;
                result += ",Speed=" + this.reel_.Speed.ToString();
                result += ",Locked=" + this.cbLocked.Checked.ToString();
            }
            else if (this.reel_ != null && this.reel_.Components.Count == 0)
            {
                //Empty reel should not excist
                throw new Exception("BUG: EMPTY REEL");
            }
#else
            if (this.reel_ != null)
            {
                result += this.reel_.Components[0].Designator;
                result += ",Speed=" + this.reel_.Speed.ToString();
                result += ",Locked=" + this.cbLocked.Checked.ToString();
            }
#endif
            else
            {
                result += ",Speed=,Locked=False";
            }
            result += Environment.NewLine;
            return result;
        }

        /// <summary>
        /// Refresh the list of items in the combobox
        /// </summary>
        private void RefreshList()
        {
            cbxReels.Items.Clear();
            List<Reel> displayedList = ptrcbxList.FindAll(reel => reel.Footprint.StackType == this.myType);
            cbxReels.Items.AddRange(displayedList.ToArray());
            if (this.reel_ == null) return;
            if (this.cbLocked.Checked) cbxReels.Items.Add(this.reel_);
            cbxReels.SelectedIndexChanged -= cbxAvailable_SelectedIndexChanged;
            cbxReels.SelectedItem = this.reel_;
            cbxReels.SelectedIndexChanged += cbxAvailable_SelectedIndexChanged;
            this.nudSpeed.Value = this.reel_.Speed;
        }
        /*-------------------------------------------------------------*/
        private void cbxAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reel oldReel = this.reel_;
            this.reel_ = (Reel)cbxReels.SelectedItem;
            if (ReelChanged != null) ReelChanged(this, oldReel);
            RefreshList();
        }
        /*-------------------------------------------------------------*/
        private void cbLocked_CheckedChanged(object sender, EventArgs e)
        {
            cbxReels.Enabled = !cbLocked.Checked;
            nudSpeed.Enabled = !cbLocked.Checked;
            cbLocked.Text = cbLocked.Checked ? "locked" : "unlocked"; //change the text of cbLocked
            if ((cbLocked.Checked) && (this.reel_ != null))
            {
                ptrcbxList.Remove(this.reel_);
            }
            else if (this.reel_ != null)
            {
                ptrcbxList.Add(this.reel_);
            }
            RefreshList();
        }
        /*-------------------------------------------------------------*/
        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (this.reel_ != null) reel_.Speed = (int)nudSpeed.Value;
        }
        /*-------------------------------------------------------------*/
        private void cbxReels_DropDown(object sender, EventArgs e)
        {
            RefreshList();
        }
#if DEBUG
        public override string ToString()
        {
            return this.Reel.ToString();
        }
#endif

        #region garbage

        ///// <summary>
        ///// Set the reel of the current control
        ///// </summary>
        ///// <param name="value">Reel to be set</param>
        //public void setReel(Reel value)
        //{
        //    this.setReel(value, false);
        //}

        #endregion

    }
}
