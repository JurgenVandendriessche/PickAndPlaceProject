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
using System.IO;
using PickAndPlaceLib;

namespace PickAndPlace
{
    /// <summary>
    /// Interface for all the Pick and place machines
    /// </summary>
    public interface IMachine
    {
        /// <summary>
        /// Gets the width of the machine
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the length of the machine
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Gets the maximum height of the components
        /// </summary>
        int MaxComponentHeight { get; }

        /// <summary>
        /// Gets the maximum speed of the machine
        /// </summary>
        int MaxSpeed { get; }

        /// <summary>
        /// Gets the minimum speed of the machine
        /// </summary>
        int MinSpeed { get; }

        /// <summary>
        /// Gets or Sets the default speed of the machine
        /// </summary>
        int DefaultSpeed { get; set; }

        /// <summary>
        /// Gets the total amount of reels
        /// </summary>
        int TotalAmountOfStacks { get; }

        /// <summary>
        /// Gets the order of stacks
        /// </summary>
        StackType[] StackConfiguration { get; }

        /// <summary>
        /// Gets the equipped nozzles
        /// </summary>
        Nozzle[] EquippedNozzles { get; }

        /// <summary>
        /// Sets the nozzle at the specific index of the machine
        /// </summary>
        /// <param name="index">Zerror based index of the nozzle</param>
        /// <param name="nozzle">Equipped nozzle</param>
        void SetNozzle(int index, Nozzle nozzle);

        /// <summary>
        /// Search for the first equipped nozzle that matches the nozzle type and returns its index, returns -1 if not found
        /// </summary>
        /// <param name="nozzle">Nozzle type to be found</param>
        /// <returns>Index of the nozzle</returns>
        int GetNozzleNumber(Nozzle nozzle);

        /// <summary>
        /// Check if a reel meets all the criteria to be placed
        /// </summary>
        /// <param name="componentReel">Reel to check</param>
        /// <returns>True if the reel can be placed</returns>
        bool ReelCanBePlaced(Reel componentReel);

        /// <summary>
        /// Compare 2 machines, returns true if they are the same type and have the same nozzles equipped, else false
        /// </summary>
        /// <param name="machine">machine to compare to</param>
        /// <returns>True if they are the same type and have the same nozzles equipped, else false</returns>
        bool IsSameMachine(IMachine machine);

        /// <summary>
        /// Exports the data to a file that can be read by the pick and place machine
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <param name="boardSettings">Settings of the board</param>
        /// <param name="phase">Stacklist with the reels to export</param>
        void ExportToFile(string path, BoardSettings boardSettings, StackList phase);

        /// <summary>
        /// Loads the configuration of the pnp machine in the pnp machine file
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <returns>string of manufacturer part numbers in the rails</returns>
        /// <exception cref="PickAndPlace.WrongMachineTypeException">Thrown when the machine's number of stacks doesn't match the length of the stackConfiguration</exception>
        string[] LoadStackConfiguration(string path);
    }

    /*Why is AtmMachine not a normal class with enums?
     * Interface allows more type's of machine's to be added in the futurere 
     * (different amount of nozzles or other way of exporting the files*/

    /// <summary>
    /// Exception that is thrown when the machine type is wrong
    /// </summary>
    public class WrongMachineTypeException : ApplicationException
    {
        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.WrongMachineTypeException"/>
        /// </summary>
        public WrongMachineTypeException()
            : base()
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.WrongMachineTypeException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public WrongMachineTypeException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.WrongMachineTypeException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        /// <param name="innerException">Inner exception of the exception</param>
        public WrongMachineTypeException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
