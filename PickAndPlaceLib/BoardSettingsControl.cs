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

namespace PickAndPlaceLib
{
    /// <summary>
    /// Represents two <see cref="System.Windows.Forms.NumericUpDown"/> with title and unit
    /// </summary>
    public partial class BoardSettingsControl : UserControl
    {
        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceLib.BoardSettingsControl"/>
        /// </summary>
        public BoardSettingsControl()
        {
            InitializeComponent();
        }

        //Shared properties

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Custom"),
        System.ComponentModel.DefaultValue("title"),
        System.ComponentModel.Description("title shown in the upper left corner")]
        public string Title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; base.Refresh(); }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
         System.ComponentModel.Category("Custom"),
         System.ComponentModel.DefaultValue(""),
         System.ComponentModel.Description("Gets or sets the unit of the numbers")]
        public string Unit
        {
            get { return this.lblUnitX.Text; }
            set
            {
                this.lblUnitX.Text = value;
                this.lblUnitY.Text = value;
            }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
         System.ComponentModel.Category("Custom"),
         System.ComponentModel.DefaultValue(0),
         System.ComponentModel.Description("Gets or sets the number of decimal places to display in the spin box (also known as an up-down control).")]
        public int DecimalPlaces
        {
            get { return this.nudX.DecimalPlaces; }
            set
            {
                this.nudX.DecimalPlaces = value;
                this.nudY.DecimalPlaces = value;
            }
        }

        //properties of nudX

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "0"),
        System.ComponentModel.Description("Gets or sets the value of X")]
        public decimal ValueX
        {
            get { return this.nudX.Value; }
            set { this.nudX.Value = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "0"),
        System.ComponentModel.Description("Gets or sets the minimum value of X")]
        public decimal MinimumX
        {
            get { return this.nudX.Minimum; }
            set { this.nudX.Minimum = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "100"),
        System.ComponentModel.Description("Gets or sets the maximum value of X")]
        public decimal MaximumX
        {
            get { return this.nudX.Maximum; }
            set { this.nudX.Maximum = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "1"),
        System.ComponentModel.Description("Gets or sets the value to increment or decrement X when the up or down buttons are clicked")]
        public decimal IncrementX
        {
            get { return this.nudX.Increment; }
            set { this.nudX.Increment = value; }
        }

        //properties of nudY

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "0"),
        System.ComponentModel.Description("Gets or sets the value of Y")]
        public decimal ValueY
        {
            get { return this.nudY.Value; }
            set { this.nudY.Value = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "0"),
        System.ComponentModel.Description("Gets or sets the minimum value of Y")]
        public decimal MinimumY
        {
            get { return this.nudY.Minimum; }
            set { this.nudY.Minimum = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "100"),
        System.ComponentModel.Description("Gets or sets the maximum value of Y")]
        public decimal MaximumY
        {
            get { return this.nudY.Maximum; }
            set { this.nudY.Maximum = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("Custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "1"),
        System.ComponentModel.Description("Gets or sets the value to increment or decrement Y when the up or down buttons are clicked")]
        public decimal IncrementY
        {
            get { return this.nudY.Increment; }
            set { this.nudY.Increment = value; }
        }
    }
}