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
    /// Location of a component
    /// </summary>
    public struct Location
    {
        private float X_;
        private float Y_;
        private int rotation_;
        private Layer layer_;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.Location"/>
        /// </summary>
        /// <param name="Xcoordinate">Horizontal coördinate</param>
        /// <param name="Ycoordinate">Vertical coördinate</param>
        /// <param name="rotation">Rotation of the component</param>
        /// <param name="layer">Layer on the PCB</param>
        public Location(float Xcoordinate, float Ycoordinate, int rotation, Layer layer)
        {
            X_ = Xcoordinate;
            Y_ = Ycoordinate;
            layer_ = layer;
            rotation_ = rotation;
        }

        /// <summary>
        /// Gets the horizontal coordinate
        /// </summary>
        public float X
        {
            get { return X_; }
        }

        /// <summary>
        /// Gets the vertical coordinate
        /// </summary>
        public float Y
        {
            get { return Y_; }
        }

        /// <summary>
        /// Gets the rotation
        /// </summary>
        public int Rotation
        {
            get { return rotation_; }
        }

        /// <summary>
        /// Gets the layer on the PCB
        /// </summary>
        public Layer Layer
        {
            get { return layer_; }
        }
    }

    /// <summary>
    /// Layers on a PCB
    /// </summary>
    public enum Layer { Top, Bottom }
}