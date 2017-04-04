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

namespace PickAndPlace
{
    /// <summary>
    /// Class that is used to pass parameters between two functions
    /// </summary>
    public class BoardSettings
    {
        private float originX_;
        private float originY_;
        private int boardsX_;
        private int boardsY_;
        private float distanceX_;
        private float distanceY_;
        private float width_;
        private float length_;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.BoardSettings"/>
        /// </summary>
        /// <param name="originOffsetX">Horizontal origin offset</param>
        /// <param name="originOffsetY">Vertical origin offset</param>
        /// <param name="boardWidth">Width of the board</param>
        /// <param name="boardLength">Length of the board</param>
        public BoardSettings(float originOffsetX, float originOffsetY, float boardWidth, float boardLength)
        {
            originX_ = originOffsetX;
            originY_ = originOffsetY;
            boardsX_ = 1;
            boardsY_ = 1;
            distanceX_ = 0;
            distanceY_ = 0;
            width_ = boardWidth;
            length_ = boardLength;
        }

        /// <summary>
        /// Gets or sets the horizontal origin offset
        /// </summary>
        public float HorizontalOriginOffset
        {
            get { return this.originX_; }
            set { this.originX_ = value; }
        }

        /// <summary>
        /// Gets or sets the vertical origin offset
        /// </summary>
        public float VerticalOriginOffset
        {
            get { return this.originY_; }
            set { this.originY_ = value; }
        }

        /// <summary>
        /// Gets or sets the number of panelized boards in the X direction (horizontal)
        /// </summary>
        public int BoardsX
        {
            get { return this.boardsX_; }
            set { this.boardsX_ = value; }
        }

        /// <summary>
        /// Gets or sets the number of panelized boards in the Y direction (vertical)
        /// </summary>
        public int BoardsY
        {
            get { return this.boardsY_; }
            set { this.boardsY_ = value; }
        }

        /// <summary>
        /// Gets or sets the distance between the boards in the X direction (horizontal)
        /// </summary>
        public float DistanceX
        {
            get { return this.distanceX_; }
            set { this.distanceX_ = value; }
        }

        /// <summary>
        /// Gets or sets the distance between the boards in the Y direction (vertical)
        /// </summary>
        public float DistanceY
        {
            get { return this.distanceY_; }
            set { this.distanceY_ = value; }
        }

        /// <summary>
        /// Gets or sets the width of the board
        /// </summary>
        public float BoardWidth
        {
            get { return this.width_; }
            set { this.width_ = value; }
        }

        /// <summary>
        /// Gets or sets the length of the board
        /// </summary>
        public float BoardLength
        {
            get { return this.length_; }
            set { this.length_ = value; }
        }
    }
}
