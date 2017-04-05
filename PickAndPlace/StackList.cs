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
    /// Visually represents all the stacks of a pick and place machine
    /// </summary>
    public partial class StackList : UserControl
    {
        /// <summary>
        /// Occurs when the user changes the reel of one of the <see cref="PickAndPlace.StackControl"/> 
        /// </summary>
        public event StackControl.ReelChangedHandler updateAllListsEvent;

        private List<Reel> ptrTotalList;
        private StackControl[] stackControls;
        private ReelLayer layer_;
        private int phaseNumber_;

        private const int minWidth = 397;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.StackList"/>
        /// </summary>
        private StackList()
        {
            InitializeComponent();
            this.AutoScroll = true;
            lblPhase.Location = new Point((this.Width - lblPhase.Width) / 2, 10);
            this.layer_ = ReelLayer.Both;
            this.phaseNumber_ = -1;
            this.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.StackList"/>
        /// </summary>
        /// <param name="machineType">Machine type of the new stacklist</param>
        /// <exception cref="System.ArgumentNullException">Thrown when machineType is null</exception>
        private StackList(IMachine machineType)
            : this()
        {
            if (machineType != null)
            {
                StackType[] stackConfig = machineType.StackConfiguration;
                int stackCount = stackConfig.Length;
                stackControls = new StackControl[stackCount];
                for (int i = 0; i < stackCount; i++)
                {
                    StackControl newControl = new StackControl(stackConfig[i], i);
                    newControl.Location = new Point(0, 28 + (newControl.Height + 4) * i);
                    newControl.Name = "stackControl" + (i + 1).ToString();
                    newControl.TabIndex = i + 1;
                    newControl.MaxSpeed = machineType.MaxSpeed;
                    newControl.MinSpeed = machineType.MinSpeed;
                    newControl.Speed = machineType.DefaultSpeed;
                    newControl.ReelChanged += OnReelListChanged;
                    stackControls[i] = newControl;
                    this.Controls.Add(newControl);
                }
            }
            else
            {
                throw new ArgumentNullException("machineType");
            }
        }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.StackList"/>
        /// </summary>
        /// <param name="machineType">Machine type of the new stacklist</param>
        /// <param name="phaseNumber">Phase number of the new stacklist</param>
        /// <exception cref="System.ArgumentNullException">Thrown when machineType is null</exception>
        public StackList(IMachine machineType, int phaseNumber)
            : this(machineType)
        {
            this.phaseNumber_ = phaseNumber;
        }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.StackList"/>
        /// </summary>
        /// <param name="machineType">Machine type of the new stacklist</param>
        /// <param name="phaseNumber">Phase number of the new stacklist</param>
        /// <param name="path">Path to a file that contains a stackconfiguration for the machine</param>
        /// <param name="reelList">List displayed in the combobox</param>
        /// <exception cref="System.ArgumentNullException">Thrown when machineType is null</exception>
        public StackList(IMachine machineType, string[] stackConfiguration, List<Reel> reelList)
            : this(machineType)
        {
            for (int i = 0; i < stackControls.Length; i++)
            {
                stackControls[i].ManufacturerPartNumber = stackConfiguration[i];
                stackControls[i].SetList(reelList);
            }
            this.ptrTotalList = reelList;
        }

        /// <summary>
        /// Gets or sets the phase number
        /// </summary>
        public int PhaseNumber
        {
            get { return this.phaseNumber_; }
            set
            {
                this.phaseNumber_ = value;
                UpdateTitle();
            }
        }

        /// <summary>
        /// Gets the layer of the reels in the control
        /// </summary>
        public ReelLayer Layer
        {
            get { return this.layer_; }
        }

        /// <summary>
        /// Gets a value that indicates whether the current stacklist contains any Reels
        /// </summary>
        public bool ContainsReels
        {
            //Property: like StreamReader.EndOfStream
            get
            {
                for (int i = 0; i < stackControls.Length; i++)
                {
                    if (stackControls[i].Reel != null) return true;
                }
                return false;
            }
        }
        /*-------------------------------------------------------------*/
        private void OnReelListChanged(StackControl sender, Reel sendersOldReel)
        {
            if (updateAllListsEvent != null) updateAllListsEvent(sender, sendersOldReel);
        }
        /*-------------------------------------------------------------*/
        protected override void OnResize(EventArgs e)
        {
            if (this.Width < minWidth)
            {
                this.Width = minWidth;
            }
            if (stackControls != null)
                foreach (StackControl stackControl_ in stackControls)
                {
                    stackControl_.Width = this.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                }
            lblPhase.Location = new Point((this.Width - lblPhase.Width) / 2, 0);
            base.OnResize(e);
        }

        /// <summary>
        /// Changes the reel of one of the <see cref="PickAndPlace.StackControl"/> with the senders old reel
        /// </summary>
        /// <param name="sender">Sender who contains the new rail</param>
        /// <param name="sendersOldReel">Rail to exchange</param>
        /// <returns>True if the <see cref="PickAndPlace.StackControl"/> who contains the senders new reel is in this <see cref="PickAndPlace.StackList"/> else false</returns>
        public bool UpdateAllLists(StackControl sender, Reel sendersOldReel)
        {
            for (int i = 0; i < stackControls.Length; i++)
            {
                StackControl stackControl_ = stackControls[i];
                if ((stackControl_.Reel == sender.Reel) && (stackControl_ != sender))
                {
                    stackControl_.ChangeReel(sendersOldReel);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Update the title at the top of the control
        /// </summary>
        private void UpdateTitle()
        {
            this.lblPhase.Text = "phase " + phaseNumber_.ToString() + " | layer: " + this.layer_.ToString();
            lblPhase.Location = new Point((this.Width - lblPhase.Width) / 2, 10);
        }

        /// <summary>
        /// Sets the list of all reels that are displayed in the appropriat comboboxen
        /// </summary>
        /// <param name="reelList">Total list that is distributed over all the comboboxen</param>
        public void SetTotalList(List<Reel> reelList)
        {
            this.ptrTotalList = reelList;
            foreach (StackControl curControl in stackControls)
            {
                curControl.SetList(reelList);
            }
        }

        /// <summary>
        /// Returns the list of all the reels in the current control that aren't locked
        /// </summary>
        /// <returns>List of all the reels in the current control that aren't locked</returns>
        public List<Reel> GetTotalList()
        {
            return ptrTotalList;
        }

        /// <summary>
        /// Add a new reel to the control.
        /// <para>Returns true when the reel is added, else false</para>
        /// </summary>
        /// <param name="newReel">Reel to be added</param>
        /// <returns>True when the reel is added, else false</returns>
        public bool AddReel(Reel newReel)
        {
            return this.AddReel(newReel, false);
        }

        /// <summary>
        /// Add a new reel to the control.
        /// <para>Returns true when the reel is added, else false</para>
        /// </summary>
        /// <param name="newReel">Reel to be added</param>
        /// <param name="lockedState">State of the stackControl after adding the reel</param>
        /// <returns>True when the reel is added, else false</returns>
        public bool AddReel(Reel newReel, bool lockedState)
        {
            //find first index of stacks who can have the selected component
            int index = Array.FindIndex(stackControls, curStack => (curStack.Reel == null) && (curStack.StackType == newReel.Footprint.StackType));
            return this.AddReel(newReel, lockedState, index);
        }

        /// <summary>
        /// Add a new reel to the control, add the specific location
        /// <para>Returns true when the reel is added, else false</para>
        /// </summary>
        /// <param name="newReel">Reel to be added</param>
        /// <param name="lockedState">State of the stackControl after adding the reel</param>
        /// <param name="index">Index of the new reel</param>
        /// <returns>True when the reel is added, else false</returns>
        public bool AddReel(Reel newReel, bool lockedState, int index)
        {
            if ((index < 0) || (index > stackControls.Length)) return false;
            stackControls[index].SetReel(newReel, lockedState);
            if (this.layer_ == ReelLayer.Both)
            {
                this.layer_ = newReel.ReelLayer;
                UpdateTitle();
            }
            return true;
        }

        /// <summary>
        /// Add a new reel to the control and activate the update event
        /// <para>Returns true when the reel is added, else false</para>
        /// </summary>
        /// <param name="newReel">Reel to be aded</param>
        /// <returns>True when the reel is added, else false</returns>
        public bool AddReelWithUpdate(Reel newReel)
        {
            //find first index of stacks who can have the selected component
            int index = Array.FindIndex(stackControls, curStack => (curStack.Reel == null) &&
                                                                   (curStack.ManufacturerPartNumber == newReel.Footprint.ManufacturerPartNumber));
            if (index >= 0)
            {
                stackControls[index].SetReelWithUpdate(newReel);//Difference with the normal AddReel
                if (this.layer_ == ReelLayer.Both)
                {
                    this.layer_ = newReel.ReelLayer;
                    UpdateTitle();
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the reel at the given index, null if the index doesn't exists
        /// </summary>
        /// <param name="index">Requested index</param>
        /// <returns>Reel located in the stackControl with index, null if the index is out of range</returns>
        public Reel GetReel(int index)
        {
            if (index < stackControls.Length)
            {
                return stackControls[index].Reel;
            }
            return null;
        }

        /// <summary>
        /// Gets the string to represent the stacklist when saving the file
        /// </summary>
        /// <returns>String to represent the stackcontrol in a saved project file</returns>
        public string GetSaveString()
        {
            StringBuilder builder = new StringBuilder();
            for (int index = 0; index < stackControls.Length; index++)
            {
                builder.Append(stackControls[index].SaveStack());
            }
            return builder.ToString();
        }
    }
}