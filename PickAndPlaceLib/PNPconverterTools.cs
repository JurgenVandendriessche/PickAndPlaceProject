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
    /// All known nozzles
    /// </summary>
    public enum Nozzle { XS, S, M, ML }

    /// <summary>
    /// All known StackTypes
    /// </summary>
    public enum StackType { Reel08mm, Reel12mm, Reel16mm, Tray18mm }

    /// <summary>
    /// Static class that contains all convertion methods related to the PickAndPlaceLib enums
    /// </summary>
    public static class PNPconverterTools
    {

        private const string REEL_08_MM = "Reel: 8mm";
        private const string REEL_12_MM = "Reel: 12mm";
        private const string REEL_16_MM = "Reel: 16mm";
        private const string TRAY_18_MM = "Tray: 18mm";

        /// <summary>
        /// Returns the "names" of the stacktypes used to list the stacktypes
        /// </summary>
        /// <param name="stackType">Stacktype to convert</param>
        /// <returns>"Name" of the stacktype</returns>
        /// <exception cref="System.NotImplementedException">Thrown when the enum is not updated with a new stackType</exception>
        public static string StackTypeToString(StackType stackType)
        {
            string result;
            switch (stackType)
            {
                case StackType.Reel08mm:
                    result = REEL_08_MM;
                    break;
                case StackType.Reel12mm:
                    result = REEL_12_MM;
                    break;
                case StackType.Reel16mm:
                    result = REEL_16_MM;
                    break;
                case StackType.Tray18mm:
                    result = TRAY_18_MM;
                    break;
                default:
                    throw new NotImplementedException();
            }
            return result;
        }

        /// <summary>
        /// Converts the string to the stackType
        /// </summary>
        /// <param name="stackName">"Name" of the stacktype or the string value of a stackType</param>
        /// <returns>A <see cref="PickAndPlaceLib.StackType"/> that is equivalent to the stackName</returns>
        /// <exception cref="PickAndPlaceLib.UnknownStackTypeException">Thrown when the stackName is not a valid stackType</exception>
        public static StackType StringToStackType(string stackName)
        {
            StackType result;
            switch (stackName)
            {
                case REEL_08_MM:
                case "Reel08mm":
                    result = StackType.Reel08mm;
                    break;
                case REEL_12_MM:
                case "Reel12mm":
                    result = StackType.Reel12mm;
                    break;
                case REEL_16_MM:
                case "Reel16mm":
                    result = StackType.Reel16mm;
                    break;
                case TRAY_18_MM:
                case "Tray18mm":
                    result = StackType.Tray18mm;
                    break;
                default:
                    throw new UnknownStackTypeException("Unknown StackType name: " + stackName);
            }
            return result;
        }

        /// <summary>
        /// Converts the string to the Nozzle type
        /// </summary>
        /// <param name="nozzleName">String value of the nozzle (= Nozzle.toString())</param>
        /// <returns>A <see cref="PickAndPlaceLib.Nozzle"/> that is equivalent to the nozzleName</returns>
        /// <exception cref="PickAndPlaceLib.UnknownNozzleException">Thrown when the nozzleName is not a valid Nozzle</exception>
        public static Nozzle StringToNozzle(string nozzleName)
        {
            Nozzle result;
            switch (nozzleName)
            {
                case "XS":
                    result = Nozzle.XS;
                    break;
                case "S":
                    result = Nozzle.S;
                    break;
                case "M":
                    result = Nozzle.M;
                    break;
                case "ML":
                    result = Nozzle.ML;
                    break;
                default:
                    throw new UnknownNozzleException("Unknown Nozzle name: " + nozzleName);
            }
            return result;
        }
    }

    /// <summary>
    /// The exception that is thrown when the Nozzle is unknown
    /// </summary>
    public class UnknownNozzleException : ApplicationException
    {
        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceLib.UnknownNozzleException"/>
        /// </summary>
        public UnknownNozzleException()
            : base()
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceLib.UnknownNozzleException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public UnknownNozzleException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceLib.UnknownNozzleException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        /// <param name="innerException">Inner exception of the exception</param>
        public UnknownNozzleException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    /// <summary>
    /// The exception that is thrown when the StackType is unknown
    /// </summary>
    public class UnknownStackTypeException : ApplicationException
    {
        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceLib.UnknownStackTypeException"/>
        /// </summary>
        public UnknownStackTypeException()
            : base()
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceLib.UnknownStackTypeException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public UnknownStackTypeException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlaceLib.UnknownStackTypeException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        /// <param name="innerException">Inner exception of the exception</param>
        public UnknownStackTypeException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

}
