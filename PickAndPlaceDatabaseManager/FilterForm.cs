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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickAndPlaceDatabaseManager
{
    /// <summary>
    /// Represents a dialog for creating a filter string for a <see cref="System.Data.DataView"/>
    /// </summary>
    public partial class FilterForm : Form
    {
        private string filterString_;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceDatabaseManager.FilterForm"/>
        /// </summary>
        public FilterForm()
        {
            InitializeComponent();
        }
        /*-------------------------------------------------------------*/
        private void btnFilter_Click(object sender, EventArgs e)
        {
            StringBuilder strBuilder = new StringBuilder();
            //filterString_ = filterControl1.GetFilterString();
            string filterTerm1 = filterControl1.GetFilterString();
            string filterTerm2 = filterControl2.GetFilterString();
            string filterTerm3 = filterControl3.GetFilterString();
            if (filterTerm1 != null)
            {
                strBuilder.Append(filterTerm1);
                if (filterTerm2 != null || filterTerm3 != null)
                {
                    strBuilder.Append(" AND ");
                }
            }
            if (filterTerm2 != null)
            {
                strBuilder.Append(filterTerm2);
                if (filterTerm3 != null)
                {
                    strBuilder.Append(" AND ");
                }
            }
            if (filterTerm3 != null)
            {
                strBuilder.Append(filterTerm3);
                //filterString_ += " AND " + filterTerm3;
            }
            filterString_ = strBuilder.ToString();
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        /*-------------------------------------------------------------*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Gets the string to filter a <see cref="System.Data.DataView"/>
        /// </summary>
        /// <returns>String that can be used to filter a <see cref="System.Data.DataView"/></returns>
        public string GetFilterString()
        {
            return this.filterString_;
        }
    }
}