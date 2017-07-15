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
    /// Implements the basic functionalities for the Neoden Tm machines
    /// </summary>
    public abstract class ATmMachine : IMachine
    {
        private const int maxSpeed_ = 150;
        private const int minSpeed_ = 10;
        private const int height_ = 3;
        private const int tray18mm_ = 1;
        private int defaultSpeed_;

        private Nozzle[] equippedNozzles_;
        private readonly StackType[] stackConfiguration_;

        private readonly int width_;
        private readonly int length_;
        private readonly int totalAmountOfReels_;

        protected ATmMachine(int reels8mm_, int reels12mm_, int reels16mm_, int width, int length)
        {
            defaultSpeed_ = 100;
            this.equippedNozzles_ = new Nozzle[2] { Nozzle.XS, Nozzle.S };
            this.width_ = width;
            this.length_ = length;

            int index = 0;
            totalAmountOfReels_ = tray18mm_ + reels8mm_ + reels12mm_ + reels16mm_;
            stackConfiguration_ = new StackType[totalAmountOfReels_];
            AddStackTypes(StackType.Tray18mm, ref index, tray18mm_);
            AddStackTypes(StackType.Reel08mm, ref index, reels8mm_);
            AddStackTypes(StackType.Reel12mm, ref index, reels12mm_);
            AddStackTypes(StackType.Reel16mm, ref index, reels16mm_);
        }

        /// <summary>
        /// Used during initialisation to create the stackType of the machine
        /// </summary>
        /// <param name="stackType">Stacktype added to the stackConfiguration_</param>
        /// <param name="index">Index in the stackConfiguration_ array</param>
        /// <param name="length">Number of stacktype reel locations to be added</param>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when index exceeds the number of stacks of the machine</exception>
        private void AddStackTypes(StackType stackType, ref int index, int length)
        {
            int lastIndex = index + length;
            while (index < lastIndex)
            {
                stackConfiguration_[index] = stackType;
                index++;
            }
        }

        /// <summary>
        /// Converts an angle so the machine can understand it
        /// </summary>
        /// <param name="angle">Angle to convert</param>
        /// <returns>Converted angle</returns>
        private static int ConvertAngle(int angle)
        {
            int result = angle % 360; //Angle is now between -359 and 359
            if (Math.Abs(result) >= 180)
            {
                //Angle is an element of [-360;-180] or [180;359]
                result = -Math.Sign(result) * (360 - Math.Abs(result));
            }
            return result;
        }

        public int Width
        {
            get { return width_; }
        }

        public int Length
        {
            get { return length_; }
        }

        public int MaxComponentHeight
        {
            get { return height_; }
        }

        public int MaxSpeed
        {
            get { return maxSpeed_; }
        }

        public int MinSpeed
        {
            get { return minSpeed_; }
        }

        public int DefaultSpeed
        {
            get { return this.defaultSpeed_; }
            set { if ((value >= minSpeed_) && (value <= maxSpeed_)) this.defaultSpeed_ = value; }
        }

        public int TotalAmountOfStacks
        {
            get { return totalAmountOfReels_; }
        }

        public StackType[] StackConfiguration
        {
            get { return stackConfiguration_; }
        }

        public Nozzle[] EquippedNozzles
        {
            get { return this.equippedNozzles_; }
        }

        public void SetNozzle(int index, Nozzle nozzle)
        {
            if (index < equippedNozzles_.Count()) this.equippedNozzles_[index] = nozzle;
        }

        public int GetNozzleNumber(Nozzle nozzle)
        {
            int index = Array.FindIndex(equippedNozzles_, nozzle_ => nozzle_ == nozzle);
            if (index != -1) index++;
            return index;
        }

        public bool ReelCanBePlaced(Reel componentReel)
        {
            if ((componentReel.Footprint != null) &&
                (componentReel.Footprint.Height > 0) &&
                (componentReel.Footprint.Height <= height_) &&
                (this.GetNozzleNumber(componentReel.Footprint.Nozzle) != -1)) return true;
            return false;
        }

        public bool IsSameMachine(IMachine machine)
        {
            //I have no experiance with overriting the equils method / operators
            if (this.GetType() != machine.GetType()) return false;
            foreach (Nozzle nozzle_ in equippedNozzles_)
            {
                //Comparing the array's doesn't work (even if the order matters)
                if (machine.GetNozzleNumber(nozzle_) == -1) return false;
            }
            return this.defaultSpeed_ == machine.DefaultSpeed; //last check, speeds are the same
        }

        public void ExportToFile(string path, BoardSettings boardSettings, StackList phaseStackList)
        {
            StringBuilder sbStackOffset = new StringBuilder();
            StringBuilder sbFeederSpacing = new StringBuilder();
            StringBuilder sbComponentLocations = new StringBuilder();
            int operationNumber = 1;
            int curSpeed = -1;

            for (int index = 0; index < this.totalAmountOfReels_; index++)
            {
                //values for when there is no reel
                float offsetX = 0;
                float offsetY = 0;
                string comment = "";
                float feedSpacingReel = 0;
                Reel reelWithIntel = phaseStackList.GetReel(index);
                if (reelWithIntel != null)
                {
                    Footprint reelsFootprint = reelWithIntel.Footprint; //this makes reading the code easier
                    if (reelWithIntel.Footprint.StackType != StackType.Tray18mm)
                    {
                        offsetX = reelsFootprint.OffsetStackX;
                        offsetY = reelsFootprint.OffsetStackY;
                    }
                    else
                    {
                        offsetX = -9.4f + reelsFootprint.Width / 2 + reelsFootprint.OffsetStackX;
                        offsetY = 8.5f - reelsFootprint.Length / 2 + reelsFootprint.OffsetStackY;
                    }
                    comment = reelsFootprint.ManufacturerPartNumber;
                    feedSpacingReel = reelsFootprint.FeedRate;

                    int speedValue = reelWithIntel.Speed / 10;
                    //1) check if the speed changes
                    if (speedValue != curSpeed)
                    {
                        curSpeed = speedValue;
                        sbComponentLocations.AppendFormat("0,{0},0,0,0,0,0,0,{1}", speedValue, Environment.NewLine);
                    }
                    //set all components
                    for (int i = 0; i < reelWithIntel.Components.Count; i++)
                    {
                        PnpComponent comp = reelWithIntel.Components[i];
                        float distance;
                        int nozzleNumber = this.GetNozzleNumber(reelsFootprint.Nozzle);
                        //This should never give -1 and if it does, the machine wil give an error
                        int compRotation;
                        if (comp.Location.Layer == Layer.Top)
                        {
                            distance = comp.Location.Y;
                            compRotation = ATmMachine.ConvertAngle(comp.Location.Rotation + reelsFootprint.Rotation);
                        }
                        else
                        {
                            //botom
                            distance = boardSettings.BoardLength - comp.Location.Y;
                            compRotation = ATmMachine.ConvertAngle(180 - (comp.Location.Rotation + reelsFootprint.Rotation));
                        }
                        //%,Head,Stack,X,Y,R,H,skip,Ref,Comment,
                        sbComponentLocations.AppendFormat("{0},{1},{2},{3:0.###},{4:0.###},{5},{6:0.##},0,{7},{8}{9}",
                                               new object[] { operationNumber, nozzleNumber, index,comp.Location.X,distance,
                                                                  compRotation,reelsFootprint.Height,
                                                                  comp.Designator,reelsFootprint.ManufacturerPartNumber,Environment.NewLine});
                        operationNumber++;
                    }
                }
                //%,StackOffsetCommand,Stack,X,Y,Comment
                sbStackOffset.AppendFormat("65535,1,{0},{1},{2},{3}{4}",
                               new object[] { index, offsetX, offsetY, comment, Environment.NewLine });
                sbFeederSpacing.AppendFormat("65535,2,{0},{1},{2}", index, feedSpacingReel, Environment.NewLine);
            }
            using (StreamWriter writer = new StreamWriter(path))
            {
                //1) origin offset
                writer.WriteLine("%,OriginOffsetCommand,X,Y,,");
                writer.WriteLine("65535,0,{0:0.##},{1:0.##},", boardSettings.HorizontalOriginOffset, boardSettings.VerticalOriginOffset);
                writer.WriteLine();

                //2) stack offset
                writer.WriteLine("%,StackOffsetCommand,Stack,X,Y,Comment");
                writer.WriteLine(sbStackOffset.ToString());

                //3) Feeder spacing
                writer.WriteLine("%,FeederSpacingCommand,Stack,FeedSpacing,");
                writer.WriteLine(sbFeederSpacing.ToString());

                //4) Board setup
                writer.WriteLine("%,JointedBoardCommand,X,Y,");
                for (int i = 0; i < boardSettings.BoardsX; i++)
                {
                    for (int j = 0; j < boardSettings.BoardsY; j++)
                    {
                        if ((i != 0) || (j != 0))
                        {
                            //skip the first board
                            float Xcoord = i * (boardSettings.BoardWidth + boardSettings.DistanceX);
                            float Ycoord = j * (boardSettings.BoardLength + boardSettings.DistanceY);
                            writer.WriteLine("65535,3,{0:0.##},{1:0.##},", Xcoord, Ycoord);
                        }
                    }
                }
                writer.WriteLine();
                //5) Component locations
                writer.WriteLine("%,Head,Stack,X,Y,R,H,Skip,Ref,Comment,");
                writer.Write(sbComponentLocations.ToString());
            }
        }

        public string[] LoadStackConfiguration(string path)
        {
            string[] result = new string[totalAmountOfReels_];
            int index = 0;
            using (StreamReader xReader = new StreamReader(path))
            {
                string fileContent = xReader.ReadToEnd();
                string[] lines = fileContent.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] splitedLine = lines[i].Split(new char[] { ',' });
                    if (splitedLine[0] == "65535" && splitedLine[1] == "1")
                    {
                        result[index] = splitedLine[5];
                        index++;
                    }
                }
            }
            if (index != totalAmountOfReels_)
                throw new WrongMachineTypeException("Stack configuration and machine type of the current machien don't match" + Environment.NewLine + "Have you checked your settings?");
            return result;
        }
    }
}