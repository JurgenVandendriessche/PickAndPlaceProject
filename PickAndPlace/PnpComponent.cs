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
    /// Class that represents an electronic component
    /// </summary>
    public class PnpComponent
    {
        private Location location_;
        private string designator_;
        private string comment_;
        private string manufacturerPartNumber_; //save project needs this

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.PnpComponent"/>, use this initializer when the manufacturer part number is unknown
        /// </summary>
        /// <param name="designator">Designator of the component</param>
        /// <param name="location">Location of the component</param>
        /// <param name="comment">Comment of the component</param>
        public PnpComponent(string designator, Location location, string comment)
            : this(designator, location, comment, "") { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.PnpComponent"/>
        /// </summary>
        /// <param name="designator">Designator of the component</param>
        /// <param name="location">Location of the component</param>
        /// <param name="comment">Comment of the component</param>
        /// <param name="manufacturerPartNumber">Manufacturer part number of the component</param>
        public PnpComponent(string designator, Location location, string comment, string manufacturerPartNumber)
        {
            this.designator_ = designator;
            this.location_ = location;
            this.comment_ = comment;
            this.manufacturerPartNumber_ = manufacturerPartNumber;
        }

        /// <summary>
        /// Gets the designator of the component
        /// </summary>
        public string Designator
        {
            get { return designator_; }
        }

        /// <summary>
        /// Gets the location of the component
        /// </summary>
        public Location Location
        {
            get { return location_; }
        }

        /// <summary>
        /// Gets the comment of the component
        /// </summary>
        public string Comment
        {
            get { return comment_; }
        }

        /// <summary>
        /// Gets or sets the manufacturer part number of the footprint
        /// </summary>
        public string ManufacturerPartNumber
        {
            get { return this.manufacturerPartNumber_; }
            set { this.manufacturerPartNumber_ = value; }
        }

#if DEBUG
        //this is only for the watch
        public override string ToString()
        {
            return this.Designator;
        }
#endif
    }
}
