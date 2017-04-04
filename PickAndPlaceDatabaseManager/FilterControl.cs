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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PickAndPlaceLib;


namespace PickAndPlaceDatabaseManager
{
    /// <summary>
    /// Represents an user control for creating a filter string
    /// </summary>
    public partial class FilterControl : UserControl
    {
        private string[] stringConditions = { "equals", "contains", "starts with", "ends with" };
        private string[] numberConditions = { "=", "<=", "<", ">=", ">", };

        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceDatabaseManager.FilterControl"/>
        /// </summary>
        public FilterControl()
        {
            InitializeComponent();
            PropertyInfo[] footprintProperties = typeof(Footprint).GetProperties();
            cbxProperty.Items.AddRange(footprintProperties);
            cbxProperty.DisplayMember = "Name";
            cbxProperty.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets the filter string from this control
        /// </summary>
        /// <returns>String to filter a <see cref="System.Data.DataView"/></returns>
        public string GetFilterString()
        {
            //http://www.csharp-examples.net/dataview-rowfilter/
            if (string.IsNullOrWhiteSpace(tbxValue.Text))
            {
                return null;
            }

            PropertyInfo selectedProp = cbxProperty.SelectedItem as PropertyInfo;
            string result = selectedProp.Name + " ";
            if (selectedProp.IsNumericType())
            {
                //numeric is no problem
                result += cbxCondition.SelectedItem.ToString() + " '" + tbxValue.Text + "'";
            }
            else
            {
                switch (cbxCondition.SelectedItem.ToString())
                {
                    case ("equals"):
                        result += "= '" + tbxValue.Text + "'";
                        break;
                    case ("contains"):
                        result += "LIKE '*" + tbxValue.Text + "*'";
                        break;
                    case ("starts with"):
                        result += "LIKE '*" + tbxValue.Text + "'";
                        break;
                    case ("ends with"):
                        result += "LIKE '" + tbxValue.Text + "*'";
                        break;
                }
            }
            return result;
        }
        /*-------------------------------------------------------------*/
        private void cbxProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            PropertyInfo selectedProperty = cbxProperty.SelectedItem as PropertyInfo;
            cbxCondition.Items.Clear();
            if (selectedProperty.IsNumericType())
            {
                cbxCondition.Items.AddRange(numberConditions);
            }
            else
            {
                cbxCondition.Items.AddRange(stringConditions);
            }
            cbxCondition.SelectedIndex = 0;
        }
    }
}
