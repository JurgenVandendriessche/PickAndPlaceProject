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
    /// Represents a Neoden TM220A pick and place machine
    /// </summary>
    public class TM220A : ATmMachine
    {
        private const int width_ = 220;
        private const int length_ = 200;

        private const int reels8mm_ = 12;
        private const int reels12mm_ = 2;
        private const int reels16mm_ = 1;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.ATmMachine"/> with the settings of a <see cref="PickAndPlace.TM220A"/>
        /// </summary>
        public TM220A()
            : base(reels8mm_, reels12mm_, reels16mm_, width_, length_) { }
    }
}
