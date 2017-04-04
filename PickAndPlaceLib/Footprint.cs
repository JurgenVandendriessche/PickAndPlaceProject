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

namespace PickAndPlaceLib
{
    /// <summary>
    /// Represents a footprint of an electronic component
    /// </summary>
    public class Footprint
    {
        private string manufacturerPartNumber_; //Primary key
        private float width_; //x-axis
        private float length_; //y-axis
        private float height_; //z-axis
        private int rotation_; //angle in stack
        private float offsetStackX_;
        private float offsetStackY_;
        private float feedRate_;
        private Nozzle nozzle_;
        private StackType stackType_;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceLib.Footprint"/>
        /// </summary>
        /// <param name="manufacturerPartNumber">manufacturer part number of the new footprint</param>
        public Footprint(string manufacturerPartNumber)
            : this(manufacturerPartNumber, 0, 0, 0, 0, 0, 0, 0, Nozzle.XS, StackType.Reel08mm) { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceLib.Footprint"/>
        /// </summary>
        /// <param name="manufacturerPartNumber">manufacturer part number of the new footprint</param>
        /// <param name="width">width of the new footprint</param>
        /// <param name="length">length of the new footprint</param>
        /// <param name="height">height of the new footprint</param>
        /// <param name="rotation">rotation of the new footprint</param>
        /// <param name="offsetStackX">horizontal stack offset of the new footprint</param>
        /// <param name="offsetStackY">vertical stack offset of the new footprint</param>
        /// <param name="feedRate">feedrate of the new footprint</param>
        /// <param name="nozzle">nozzle of the new footprint</param>
        /// <param name="stackType">stack type of the new footprint</param>
        internal Footprint(string manufacturerPartNumber, float width, float length, float height, int rotation,
            float offsetStackX, float offsetStackY, float feedRate, Nozzle nozzle, StackType stackType)
        {
            manufacturerPartNumber_ = manufacturerPartNumber;
            width_ = width;
            length_ = length;
            height_ = height;
            rotation_ = rotation;
            offsetStackX_ = offsetStackX;
            offsetStackY_ = offsetStackY;
            feedRate_ = feedRate;
            nozzle_ = nozzle;
            stackType_ = stackType;
        }

        /// <summary>
        /// Gets the manufacturer part number of the footprint
        /// </summary>
        public string ManufacturerPartNumber
        {
            get { return this.manufacturerPartNumber_; }
            set { this.manufacturerPartNumber_ = value; }
        }

        /// <summary>
        /// Gets or Sets the width of the the footprint
        /// </summary>
        public float Width
        {
            get { return this.width_; }
            set { this.width_ = value; }
        }

        /// <summary>
        /// Gets or Sets the Length of the the footprint
        /// </summary>
        public float Length
        {
            get { return this.length_; }
            set { this.length_ = value; }
        }

        /// <summary>
        /// Gets or Sets the Height of the the footprint
        /// </summary>
        public float Height
        {
            get { return this.height_; }
            set { this.height_ = value; }
        }

        /// <summary>
        /// Gets or Sets the rotation of the the footprint
        /// </summary>
        public int Rotation
        {
            get { return this.rotation_; }
            set { this.rotation_ = value; }
        }

        /// <summary>
        /// Gets or Sets the horizontal offset of the footprint
        /// </summary>
        public float OffsetStackX
        {
            get { return this.offsetStackX_; }
            set { this.offsetStackX_ = value; }
        }

        /// <summary>
        /// Gets or Sets the vertical offset of the footprint
        /// </summary>
        public float OffsetStackY
        {
            get { return this.offsetStackY_; }
            set { this.offsetStackY_ = value; }
        }

        /// <summary>
        /// Gets or Sets the feed rate of the footprint
        /// </summary>
        public float FeedRate
        {
            get { return this.feedRate_; }
            set { this.feedRate_ = value; }
        }

        /// <summary>
        /// Get or Sets the nozzle type for the footprint
        /// </summary>
        public Nozzle Nozzle
        {
            get { return this.nozzle_; }
            set { this.nozzle_ = value; }
        }

        /// <summary>
        /// Get or Sets the stackType of the footprint
        /// </summary>
        public StackType StackType
        {
            get { return this.stackType_; }
            set { this.stackType_ = value; }
        }

        #region garbage

        ///// <summary>
        ///// Initializes a new <see cref="PickAndPlaceLib.Footprint"/>
        ///// </summary>
        //private Footprint():this("")
        //{
        //    manufacturerPartNumber_ = "";
        //    width_ = 0;
        //    length_ = 0;
        //    height_ = 0;
        //    rotation_ = 0;
        //    offsetStackX_ = 0;
        //    offsetStackY_ = 0;
        //    feedRate_ = 0;
        //    nozzle_ = Nozzle.XS;
        //    stackType_ = StackType.Reel08mm;
        //}

        #endregion
    }

}
