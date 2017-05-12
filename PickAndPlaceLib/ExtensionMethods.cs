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
    /// Static class that contains all extension methods used in the PickAndPlace solution project
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Changes the height of the <see cref="System.Windows.Forms.DataGridview"/> dataGridview
        /// </summary>
        /// <param name="dataGridView"><see cref="System.Windows.Forms.DataGridView"/> whose height will be changed</param>
        public static void FitHeight(this System.Windows.Forms.DataGridView dataGridView)
        {
            int height = dataGridView.ColumnHeadersHeight;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                height += dataGridView.Rows[i].Height;
            }
            dataGridView.Height = height;
        }

        /// <summary>
        /// Check if a propertyInfo is numerical or not
        /// </summary>
        /// <param name="propInfo">PropertyInfo to check</param>
        /// <returns>True if propInfo is a numeric type else false</returns>
        public static bool IsNumericType(this System.Reflection.PropertyInfo propInfo)
        {
            // http://stackoverflow.com/questions/1749966/c-sharp-how-to-determine-whether-a-type-is-a-number
            if (propInfo.PropertyType.BaseType.Name == "Enum") return false;
            //Enums have TypeCode Int32
            switch (Type.GetTypeCode(propInfo.PropertyType))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Open the help documents
        /// </summary>
        public static void ShowHelp(object sender, EventArgs e)
        {
            //This is not a real extension method, however, it is used as an event handlers in multiple forms. "It extends the event handlers"
            string locationManual = System.IO.Path.Combine("Website", "Home.html");
            System.Diagnostics.Process.Start(locationManual);
        }
    }
}
