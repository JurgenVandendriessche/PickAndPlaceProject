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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickAndPlaceLib;

namespace PickAndPlace
{
    /// <summary>
    /// Represents a reel with electronic components
    /// </summary>
    public class Reel
    {
        private List<PnpComponent> components_;
        private int speed_;
        private Footprint footprint_;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.Reel"/>
        /// </summary>
        /// <param name="components">Components on the reel</param>
        /// <param name="speed">Speed of the reel</param>
        public Reel(List<PnpComponent> components, int speed)
        {
            components_ = components;
            speed_ = speed;
            components_.Sort((x, y) => string.Compare(x.Designator, y.Designator));
            footprint_ = new Footprint(components[0].ManufacturerPartNumber);
        }

        /// <summary>
        /// Gets the components in the reel
        /// </summary>
        public List<PnpComponent> Components
        {
            get { return this.components_; }
        }

        /// <summary>
        /// Gets or Sets the speed of the reel
        /// </summary>
        public int Speed
        {
            get { return this.speed_; }
            set { this.speed_ = value; }
        }

        /// <summary>
        /// Gets or Sets the footprint of the components in the reel
        /// </summary>
        public Footprint Footprint
        {
            get { return this.footprint_; }
            set
            {
                this.footprint_ = value;
                SetManufacturerPartNumber(value.ManufacturerPartNumber);
            }
        }

        /// <summary>
        /// Gets the layer(s) of the components
        /// </summary>
        public ReelLayer ReelLayer
        {
            get
            {
                //check if all components on this reel are on the same layer
                bool sameLayer = components_.All(Currentcomponent => Currentcomponent.Location.Layer == components_[0].Location.Layer);
                if (sameLayer && components_[0].Location.Layer == Layer.Bottom) return ReelLayer.Bottom;
                else if (sameLayer && components_[0].Location.Layer == Layer.Top) return ReelLayer.Top;
                //if (sameLayer)
                //    return components_[0].Location.Layer == Layer.Bottom ? ReelLayer.Bottom : ReelLayer.Top;
                return ReelLayer.Both;
            }
        }

        /// <summary>
        /// Gets or sets the manufacturer part number of the components in the reel
        /// </summary>
        public string ManufacturerPartNumber
        {
            get { return this.footprint_.ManufacturerPartNumber; }
            set
            {
                this.footprint_.ManufacturerPartNumber = value;
                SetManufacturerPartNumber(value);
            }
        }

        /// <summary>
        /// Sets the manufacturer part number of the components in the list
        /// </summary>
        /// <param name="manufacturerPartNumber">new manufacturer part number</param>
        private void SetManufacturerPartNumber(string manufacturerPartNumber)
        {
            foreach (PnpComponent component in components_)
            {
                component.ManufacturerPartNumber = manufacturerPartNumber;
            }
        }

        /// <summary>
        /// Generate a string array to display in a listview
        /// </summary>
        /// <returns>String array with length of 3</returns>
        public string[] GenerateListViewText()
        {
            string[] output = new string[3];
            //Get all designators
            output[0] = this.GetDisplayString();
            output[1] = components_[0].ManufacturerPartNumber;
            output[2] = components_[0].Comment;
            return output;
        }

        /// <summary>
        /// Returns all designators in the reel
        /// </summary>
        /// <returns>All designators in the list</returns>
        public string GetDisplayString()
        {
            //Alternative:
            //return String.Join(",",GetDesignators());
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append(components_[0].Designator);
            for (int i = 1; i < components_.Count; i++)
            {
                sbResult.AppendFormat(",{0}", components_[i].Designator);
            }
            return sbResult.ToString();
        }

        /// <summary>
        /// Gets the designators of all the components in this reel
        /// </summary>
        /// <returns>Array of all designators in the reel</returns>
        public string[] GetDesignators()
        {
            string[] result = new string[components_.Count];
            for (int i = 0; i < components_.Count; i++)
            {
                result[i] = components_[i].Designator;
            }
            return result;
        }

        /// <summary>
        /// Returns a new reel that only contains the components of one layer
        /// </summary>
        /// <param name="layer">Layer of the components</param>
        /// <returns>One side Reel</returns>
        public Reel GetOneLayer(Layer layer)
        {
            List<PnpComponent> goodSide = components_.FindAll(comp => comp.Location.Layer == layer);
            //if (goodSide.Count != 0) return new Reel(goodSide, this.footprint_.manufacturerPartNumber, this.speed_);
            if (goodSide.Count != 0)
            {
                Reel reel_ = new Reel(goodSide, this.speed_);
                reel_.Footprint = this.footprint_;
                return reel_;
            }
            return null;
        }

        /// <summary>
        /// Returns a string that is used to display the reel in a combobox
        /// </summary>
        /// <returns>A string that represents the current reel in a combobox</returns>
        public override string ToString()
        {
            //this is how the reels are displayed in the combobox (stackControl.cs)
            return this.GetDisplayString() + " | " + this.components_[0].ManufacturerPartNumber;
        }

        /// <summary>
        /// Split the list in 2 lists, one with all the reels for the top layer phase(s), and one with all the reels for the bottom layer phase(s)
        /// </summary>
        /// <param name="allReels">All reels to be placed</param>
        /// <param name="topReels">Reels used in the top layer phase</param>
        /// <param name="bottomReels">Reels used in the bottom layer phase</param>
        public static void SplitReelList(List<Reel> allReels, out List<Reel> topReels, out List<Reel> bottomReels)
        {
            topReels = new List<Reel>();
            bottomReels = new List<Reel>();
            topReels = allReels.FindAll(reel => reel.ReelLayer == ReelLayer.Top);
            bottomReels = allReels.FindAll(reel => reel.ReelLayer == ReelLayer.Bottom);
            List<Reel> bothReels = allReels.FindAll(reel => reel.ReelLayer == ReelLayer.Both);
            foreach (Reel reel in bothReels)
            {
                Reel topReelPart = reel.GetOneLayer(Layer.Top);
                if (topReelPart != null) topReels.Add(topReelPart);
                Reel bottomReelPart = reel.GetOneLayer(Layer.Bottom);
                if (bottomReelPart != null) bottomReels.Add(bottomReelPart);
            }
        }
    }

    /// <summary>
    /// Layer(s) of the componets on the Reel
    /// </summary>
    public enum ReelLayer { Top, Both, Bottom }
    //This looks like the enum layer (pnpLib), however this one has a value both
}
