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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PickAndPlaceLib;

namespace PickAndPlace
{
    /// <summary>
    /// Static class that contains all methods for reading and writing that are not machine specific
    /// </summary>
    public static class FileOperations
    {
        /// <summary>
        /// Determine the index of the header in the header string
        /// </summary>
        /// <param name="colNames">Column names</param>
        /// <param name="header">Header to determine position off</param>
        /// <returns>Index of the header in the array of colNames</returns>
        /// <exception cref="PickAndPlace.HeaderNotFoundException">Thrown when colNames does not contain header</exception>
        private static int IndexOfHeader(string[] colNames, string header)
        {
            int result = Array.IndexOf(colNames, header);
            if (result == -1) throw new HeaderNotFoundException(string.Format("Could not find header {0}", header));
            return result;
        }

        /// <summary>
        /// Splits the line of the Pick and Place file on "," and removes the " on the beginning and the end of the line
        /// </summary>
        /// <param name="line">Line to be split</param>
        /// <returns>Line splited by "," with the first and last " removed</returns>
        /// <exception cref="System.NullReferenceException">Thrown when line is null</exception>
        private static string[] SplitLinePNPfile(string line)
        {
            string[] result = line.Split(new string[] { "\",\"" }, StringSplitOptions.None);
            //This can throw a System.NullReferenceException (if line is null)
            //this can happen if the user selects a complete empty file (not even a single enter)
            if (result[0] != string.Empty)
                result[0] = result[0].Substring(1); //removes the first char ("XX...-> XX...)
            int lastIndex = result.Length - 1;
            if (result[lastIndex] != string.Empty)
                result[lastIndex] = result[lastIndex].Remove(result[lastIndex].Length - 1);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i].Trim();
            }
            return result;
        }

        /// <summary>
        /// Converts the string with a value in mm or mil to the floating point value in mm
        /// </summary>
        /// <param name="value">String to convert</param>
        /// <returns>Value in mm</returns>
        /// <exception cref="PickAndPlace.PnpConversionException">Thrown when the value has an unknown length unit</exception>
        private static float ConvertPnpValue(string value)
        {
            float result = 0;
            string value_;
            if (value.EndsWith("mm"))
            {
                value_ = value.Remove(value.Length - 2);//.Replace('.', ',');
            }
            else if (value.EndsWith("mil"))
            {
                value_ = value.Remove(value.Length - 3);//.Replace('.', ',');
            }
            else throw new PnpConversionException(String.Format("Unable to convert the following value: {0}{1}Only mm and mil are suported units", value, Environment.NewLine));
            result = (float)Math.Round(Convert.ToDouble(value_), 2);
            return result;
        }

        /// <summary>
        /// Reads both the pnpFile and the bom file and returns a list of reels based on the two files
        /// </summary>
        /// <param name="pnpFilePath">Path to the Pick and place file</param>
        /// <param name="pnpHeaders">Headers used to read the pnp file</param>
        /// <param name="bomFilePath">Path to the BOM file</param>
        /// <param name="bomHeaders">Headers used to read the BOM</param>
        /// <returns>List of reels that was created based on the data in the files</returns>
        /// <exception cref="PickAndPlace.FileOperationsException">Thrown when some data cannot be processed </exception>
        /// <exception cref="PickAndPlace.HeaderNotFoundException">Thrown when one of the header parameters is not found</exception>
        /// <exception cref="PickAndPlace.PnpConversionException">Thrown when the pnp file uses an unknown length unit</exception>
        public static List<Reel> ReadPickAndPlaceFiles(string pnpFilePath, string[] pnpHeaders, string bomFilePath, string[] bomHeaders)
        {
            List<Reel> result = new List<Reel>();
            List<PnpComponent> components = new List<PnpComponent>();
            using (StreamReader reader = new StreamReader(pnpFilePath, Encoding.Default))
            {
                //I had the best result with Encoding.Default and Encoding.UTF7 (µ character)
                string line = reader.ReadLine();
                string[] colNames = SplitLinePNPfile(line);

                //find location of corresponding columns
                int colDesignator = IndexOfHeader(colNames, pnpHeaders[0]);
                int colX = IndexOfHeader(colNames, pnpHeaders[1]);
                int colY = IndexOfHeader(colNames, pnpHeaders[2]);
                int colLayer = IndexOfHeader(colNames, pnpHeaders[3]);
                int colRotation = IndexOfHeader(colNames, pnpHeaders[4]);
                int colComment = IndexOfHeader(colNames, pnpHeaders[5]);
                //read the document
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    string[] parameters = SplitLinePNPfile(line);
                    //first line is empty (contains "", so string.empty doesn't work)
                    if (parameters.Length == colNames.Length)
                    {
                        float X, Y;
                        int rotation;
                        Layer layer = Layer.Top;
                        X = ConvertPnpValue(parameters[colX]);
                        Y = ConvertPnpValue(parameters[colY]);
                        rotation = (int)Convert.ToDouble(parameters[colRotation]);//.Replace('.', ','));
                        switch (parameters[colLayer])
                        {
                            case "B":
                                layer = Layer.Bottom;
                                break;
                            case "T":
                                layer = Layer.Top;
                                break;
                            default:
                                throw new FileOperationsException("Folowing line contains an unknown layer:" + Environment.NewLine + line);
                        }
                        Location loc = new Location(X, Y, rotation, layer);
                        PnpComponent comp = new PnpComponent(parameters[colDesignator], loc, parameters[colComment]);
                        components.Add(comp);
                    }
                }
            }
            using (StreamReader xReader = new StreamReader(bomFilePath))
            {
                string line = xReader.ReadLine();
                string[] colNames = line.Split(','); //unlike the pnp file, the header of the BOM has no " "," "
                int colDesignators = IndexOfHeader(colNames, bomHeaders[0]);
                int colMPN = IndexOfHeader(colNames, bomHeaders[1]);
                int checkCounter = 0;
                while (!xReader.EndOfStream)
                {
                    line = xReader.ReadLine();
                    string[] parameters = SplitLinePNPfile(line);
                    if (parameters.Length == colNames.Length)
                    {
                        string[] designators = parameters[colDesignators].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        List<PnpComponent> bomComponents = new List<PnpComponent>();
                        foreach (string designator in designators)
                        {
                            PnpComponent comp = components.Find(comp_ => comp_.Designator == designator);
                            if (comp == null) throw new FileOperationsException("folowing designator was not found in the pick and place file: " + designator);

                            comp.ManufacturerPartNumber = parameters[colMPN];
                            bomComponents.Add(comp);
                            checkCounter++;
                        }
                        Reel reel = new Reel(bomComponents);
                        result.Add(reel);
                    }
                }
                if (checkCounter != components.Count) throw new FileOperationsException("The BOM contains more components then the Pick and Place file");
            }
            return result;
        }

        /// <summary>
        /// Returns a string to save the PNPcomponents of the reels in the reelList
        /// </summary>
        /// <param name="reelList">List of all reels with the components to save</param>
        /// <param name="included">Is the reel scheduled to be placed in the stacks</param>
        /// <returns>String that represents the components in the savefile</returns>
        private static string SaveStringComponents(List<Reel> reelList, bool included)
        {
            StringBuilder sbResult = new StringBuilder();
            for (int reelIndex = 0; reelIndex < reelList.Count; reelIndex++)
            {
                List<PnpComponent> componentList = reelList[reelIndex].Components;
                for (int componentIndex = 0; componentIndex < componentList.Count; componentIndex++)
                {
                    PnpComponent component = componentList[componentIndex];
                    sbResult.AppendFormat("Designator={0},manufacturer part number={1},X={2},Y={3},Rotation={4},Layer={5},comment={6},include={7}{8}",
                             new object[] {component.Designator,component.ManufacturerPartNumber,
                                           component.Location.X,component.Location.Y,component.Location.Rotation,component.Location.Layer,
                                           component.Comment,included,Environment.NewLine});
                }
            }
            return sbResult.ToString();
        }

        /// <summary>
        /// Load a pick and place project
        /// </summary>
        /// <param name="project">Project to save</param>
        public static void SaveProject(PnpProject project)
        {
            using (StreamWriter writer = new StreamWriter(project.Path))
            {
                //part 1: project information
                writer.WriteLine("ProjectName=" + project.ProjectName);
                writer.WriteLine("ProjectFolder=" + project.ProjectFolder);
                writer.WriteLine();

                //part 2: machine information
                writer.WriteLine("#Machine information:");
                string equippedNozzles = "";
                for (int i = 0; i < project.Machine.EquippedNozzles.Length; i++)
                {
                    equippedNozzles += project.Machine.EquippedNozzles[i].ToString() + ",";
                }
                writer.WriteLine("MachineType={0},speed={1},equipped nozzles={2}{3}",
                          new object[] { project.Machine.GetType(), project.Machine.DefaultSpeed, equippedNozzles, Environment.NewLine });

                //Part 3: Offset and panelization
                writer.WriteLine("#Offset and panelization:");
                writer.WriteLine("originOffsetX={1},originOffsetY={2}{0}boardsX={3},boardsY={4}{0}distanceX={5},distanceY={6}{0}boardDimX={7},boardDimY={8}{0}",
                          new object[] {Environment.NewLine,project.BoardSettings.HorizontalOriginOffset,project.BoardSettings.VerticalOriginOffset,
                                        project.BoardSettings.BoardsX,project.BoardSettings.BoardsY,
                                        project.BoardSettings.DistanceX,project.BoardSettings.DistanceY,
                                        project.BoardSettings.BoardWidth,project.BoardSettings.BoardLength});

                //part 4: components
                writer.WriteLine("#Included components/reels:");
                writer.WriteLine(SaveStringComponents(project.IncludedReels, true));
                writer.WriteLine();
                writer.WriteLine("#Excluded components/reels:");
                writer.WriteLine(SaveStringComponents(project.ExcludedReels, false));
                writer.WriteLine();

                //part 5: stackConfiguration
                writer.WriteLine("#Stack setup(s):");
                for (int i = 0; i < project.StackListers.Count; i++)
                {
                    StackList stackList_ = project.StackListers[i];
                    writer.WriteLine("Phase=" + stackList_.PhaseNumber.ToString());
                    writer.WriteLine(stackList_.GetSaveString());
                }
            }
        }

        /// <summary>
        /// Convert the list of components in to a list of reels
        /// </summary>
        /// <param name="componentList">Components to distribute over the reels</param>
        /// <returns>List of reels with the components</returns>
        private static List<Reel> ComponentsToReels(List<PnpComponent> componentList, int speed)
        {
            List<Reel> tempReelList = new List<Reel>();
            List<Reel> result = new List<Reel>();
            while (componentList.Count != 0)
            {
                PnpComponent curComponent = componentList[0];
                List<PnpComponent> matchingComponents = componentList.FindAll(comp_ => (comp_.Comment == curComponent.Comment) && (comp_.ManufacturerPartNumber == curComponent.ManufacturerPartNumber));
                //Find all components of the same type (footprint and comment/value are the same)
                componentList.RemoveAll(comp => matchingComponents.Contains(comp));
                Reel newReel = new Reel(matchingComponents); //make a reel from the components
                newReel.Speed = speed;
                tempReelList.Add(newReel);
            }
            while (tempReelList.Count != 0)
            {
                string manufacturerPartNumber = tempReelList[0].Components[0].ManufacturerPartNumber;
                //Find all matching footprints
                List<Reel> similarReels = tempReelList.FindAll(reel => reel.Components[0].ManufacturerPartNumber == manufacturerPartNumber); //make a list of all reels who share the footprint
                tempReelList.RemoveAll(reel => similarReels.Contains(reel));
                Footprint reelFootprint = DatabaseOperations.GetFootprint(manufacturerPartNumber);
                if (reelFootprint != null)
                {
                    foreach (Reel reel in similarReels)
                    {
                        reel.Footprint = reelFootprint;
                    }
                }
                result.AddRange(similarReels);
            }
            return result;
        }

        /// <summary>
        /// Load a pick and place project from the project.path
        /// </summary>
        /// <param name="project">Project to load data to</param>
        public static void LoadProject(PnpProject project)
        {
            List<PnpComponent> includedComponents = new List<PnpComponent>();
            List<PnpComponent> excludedComponents = new List<PnpComponent>();
            //project.stackListers = new List<StackList>();
            using (StreamReader reader = new StreamReader(project.Path))
            {
                while (!reader.EndOfStream)
                {
                    string curLine = reader.ReadLine();
                    //# is a line with comment
                    if (curLine.StartsWith("#") || String.IsNullOrWhiteSpace(curLine)) continue;
                    string[] splitedLine = curLine.Split(new char[] { ',', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    switch (splitedLine[0])
                    {
                        case "ProjectName":
                            project.ProjectName = splitedLine[1];
                            break;
                        case "ProjectFolder":
                            project.ProjectFolder = splitedLine[1];
                            break;
                        case "MachineType":
                            project.Machine = (IMachine)Assembly.GetExecutingAssembly().CreateInstance(splitedLine[1]);
                            project.Machine.DefaultSpeed = Convert.ToInt32(splitedLine[3]);
                            for (int i = 5; i < splitedLine.Length; i++)
                            {
                                Nozzle nozzle = PNPconverterTools.StringToNozzle(splitedLine[i]);
                                project.Machine.SetNozzle(i - 5, nozzle);
                            }
                            break;
                        case "originOffsetX":
                            project.BoardSettings.HorizontalOriginOffset = float.Parse(splitedLine[1]);
                            project.BoardSettings.VerticalOriginOffset = float.Parse(splitedLine[3]);
                            break;
                        case "boardsX":
                            project.BoardSettings.BoardsX = Convert.ToInt32(splitedLine[1]);
                            project.BoardSettings.BoardsY = Convert.ToInt32(splitedLine[3]);
                            break;
                        case "distanceX":
                            project.BoardSettings.DistanceX = float.Parse(splitedLine[1]);
                            project.BoardSettings.DistanceY = float.Parse(splitedLine[3]);
                            break;
                        case "boardDimX":
                            project.BoardSettings.BoardWidth = float.Parse(splitedLine[1]);
                            project.BoardSettings.BoardLength = float.Parse(splitedLine[3]);
                            break;
                        case "Designator":
                            //load new component
                            string designator = splitedLine[1];
                            string manufacturerPartNumber_ = splitedLine[3];
                            float x = float.Parse(splitedLine[5]);
                            float y = float.Parse(splitedLine[7]);
                            int rotation = Convert.ToInt32(splitedLine[9]);
                            Layer layer_;
                            if (splitedLine[11] == Layer.Bottom.ToString()) layer_ = Layer.Bottom;
                            else layer_ = Layer.Top;
                            Location location_ = new Location(x, y, rotation, layer_);
                            string comment = splitedLine[13];
                            bool included = Convert.ToBoolean(splitedLine[15]);
                            PnpComponent comp = new PnpComponent(designator, location_, comment, manufacturerPartNumber_);
                            if (included) includedComponents.Add(comp);
                            else excludedComponents.Add(comp);
                            break;
                        case "Phase":
                            //last part of the file
                            string remainingLines = reader.ReadToEnd();
                            string[] remainingLinesSplited = remainingLines.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                            //1) make reels from the components:

                            project.IncludedReels = ComponentsToReels(includedComponents, project.Machine.DefaultSpeed);
                            project.ExcludedReels = ComponentsToReels(excludedComponents, project.Machine.DefaultSpeed);

                            List<Reel> completeReelList = new List<Reel>(project.IncludedReels);
                            completeReelList.AddRange(project.ExcludedReels);
                            //the completeReelList contains all reels, however these reels where not splited
                            List<Reel> topReels, bottomReels;
                            Reel.SplitReelList(completeReelList, out topReels, out bottomReels);
                            completeReelList.Clear();
                            completeReelList.AddRange(topReels);
                            completeReelList.AddRange(bottomReels);
                            //topReels and bottomReels contain all reels, also the excluded reels
                            //they will be reused later

                            //2) read each line
                            StackList newStackList = new StackList(project.Machine, Convert.ToInt32(splitedLine[1]));
                            newStackList.Name = "stackList";
                            project.StackListers.Add(newStackList);
                            int index = -1;

                            for (int i = 0; i < remainingLinesSplited.Length; i++)
                            {
                                splitedLine = remainingLinesSplited[i].Split(new char[] { '=', ',' });
                                if (splitedLine[0] != "Phase")
                                {
                                    index++; //Stacks are saved in order (starting at reel 0 -> reel n)
                                    string designator_ = splitedLine[1];
                                    if (String.IsNullOrWhiteSpace(designator_)) continue; //empty stack
                                    bool locked = Convert.ToBoolean(splitedLine[5]);
                                    //find the reel in the completeReelList
                                    Reel matchingReel = completeReelList.Find(reel => reel.GetDesignators().Contains(designator_));
                                    matchingReel.Speed = Convert.ToInt32(splitedLine[3]);
                                    newStackList.AddReel(matchingReel, locked, index);
                                    project.ReelsInStackList.Add(matchingReel);
                                }
                                else
                                {
                                    //make a new phase
                                    //Phase=X (X=phase number)
                                    newStackList = new StackList(project.Machine, Convert.ToInt32(splitedLine[1]));
                                    newStackList.Name = "stackList";
                                    project.StackListers.Add(newStackList);
                                    index = -1;
                                }
                            }
                            //Reusing topReels and bottomReels
                            Reel.SplitReelList(project.ReelsInStackList, out topReels, out bottomReels);
                            project.TopReels = topReels;
                            project.BottomReels = bottomReels;

                            break;
                        default:
                            throw new FileOperationsException(String.Format("Unable to read file: {0}{2}Problem with reading folowing line:{2}{1}", project.Path, curLine, Environment.NewLine));
                    }
                }
            }
            if (project.StackListers.Count == 0)
            {
                //no phases saved
                project.IncludedReels = ComponentsToReels(includedComponents, project.Machine.DefaultSpeed);
                project.ExcludedReels = ComponentsToReels(excludedComponents, project.Machine.DefaultSpeed);
            }
            if ((project.BoardSettings.HorizontalOriginOffset == -1f) || (project.BoardSettings.VerticalOriginOffset == -1f) ||
                (project.BoardSettings.BoardsX == -1) || (project.BoardSettings.BoardsY == -1) ||
                (project.BoardSettings.DistanceX == -1f) || (project.BoardSettings.DistanceY == -1f) ||
                (project.BoardSettings.BoardWidth == -1f) || (project.BoardSettings.BoardLength == -1f) ||
                (project.Machine == null))
            {
                throw new FileOperationsException("Not all data was found in the file");
            }

        }

        /// <summary>
        /// Save the current file parameter configuration
        /// </summary>
        /// <param name="pnpFileParameters">Parameters for reading a pick and place file</param>
        /// <param name="bomFileParameters">Parameters for reading a bom file</param>
        public static void SaveConfigFile(string[] pnpFileParameters, string[] bomFileParameters)
        {
            //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PickAndPlace", "Config.conf");
            string path = @"Config.conf";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("PNPFILEPARA=" + String.Join(",", pnpFileParameters));//http://stackoverflow.com/questions/4756565/convert-array-of-integers-to-comma-separated-string
                writer.WriteLine("BOMFILEPARA=" + String.Join(",", bomFileParameters));
            }
        }

        /// <summary>
        /// Reads a config file and return two arrays:
        /// <para>one with the parameters for reading a pick and place file and one for reading a bom file</para>
        /// </summary>
        /// <returns>2 Arrays: one for reading a pick and place file, and one for reading a bom file</returns>
        public static string[][] ReadConfigFile()
        {
            string[][] result = new string[2][];
            string path = @"Config.conf";
            using (StreamReader reader = new StreamReader(path))
            {
                string[] lines = reader.ReadToEnd().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                result[0] = lines[0].Split(new char[] { '=', ',' }).Skip(1).ToArray();
                result[1] = lines[1].Split(new char[] { '=', ',' }).Skip(1).ToArray();
            }
            return result;
        }
    }

    #region exceptions

    /// <summary>
    /// Exception that is thrown when a file operation error occurs
    /// </summary>
    public class FileOperationsException : ApplicationException
    {
        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.FileOperationsException"/>
        /// </summary>
        public FileOperationsException()
            : base()
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.FileOperationsException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public FileOperationsException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.FileOperationsException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        /// <param name="innerException">Inner exception of the exception</param>
        public FileOperationsException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    /// <summary>
    /// Exception that is thrown when a header is not found
    /// </summary>
    public class HeaderNotFoundException : FileOperationsException
    {
        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.HeaderNotFoundException"/>
        /// </summary>
        public HeaderNotFoundException()
            : base()
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.HeaderNotFoundException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public HeaderNotFoundException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.HeaderNotFoundException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        /// <param name="innerException">Inner exception of the exception</param>
        public HeaderNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    /// <summary>
    /// Exception that is thrown when a pnpConversion error occurs
    /// </summary>
    public class PnpConversionException : FileOperationsException
    {
        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.PnpConversionException"/>
        /// </summary>
        public PnpConversionException()
            : base()
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.PnpConversionException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public PnpConversionException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.PnpConversionException"/>
        /// </summary>
        /// <param name="message">Message of the exception</param>
        /// <param name="innerException">Inner exception of the exception</param>
        public PnpConversionException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    #endregion
}