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
    /// Class that is used to pass parameters between functions
    /// </summary>
    public class PnpProject
    {
        private string path_;
        private string projectName_;
        private string projectFolder_;
        private IMachine machine_;
        private BoardSettings boardSettings_;
        private List<Reel> includedReels_;
        private List<Reel> excludedReels_;
        private List<Reel> reelsInStackList_;
        private List<StackList> stackListers_;
        private List<Reel> topReels_;
        private List<Reel> bottomReels_;

        /// <summary>
        /// Initializes a new <see cref="PickAndPlace.PnpProject"/>
        /// </summary>
        /// <param name="path">Path to file</param>
        public PnpProject(string path)
        {
            path_ = path;
            boardSettings_ = new BoardSettings(0f, 0f, 0f, 0f);
            includedReels_ = new List<Reel>();
            excludedReels_ = new List<Reel>();
            reelsInStackList_ = new List<Reel>();
            stackListers_ = new List<StackList>();
            //topReels and bottomReels are not initialized: they are only used when loading
        }

        /// <summary>
        /// Gets the path to the file
        /// </summary>
        public string Path
        {
            get { return path_; }
        }

        /// <summary>
        /// Gets or sets the project name
        /// </summary>
        public string ProjectName
        {
            get { return projectName_; }
            set { this.projectName_ = value; }
        }

        /// <summary>
        /// Gets or sets the project folder
        /// </summary>
        public string ProjectFolder
        {
            get { return projectFolder_; }
            set { this.projectFolder_ = value; }
        }

        /// <summary>
        /// Gets or sets the machine type
        /// </summary>
        public IMachine Machine
        {
            get { return this.machine_; }
            set { this.machine_ = value; }
        }

        /// <summary>
        /// Gets or sets the settings of the board
        /// </summary>
        public BoardSettings BoardSettings
        {
            get { return this.boardSettings_; }
            set { this.boardSettings_ = value; }
        }

        /// <summary>
        /// Gets or sets the reels that are plant to place
        /// </summary>
        public List<Reel> IncludedReels
        {
            get { return this.includedReels_; }
            set { this.includedReels_ = value; }
        }

        /// <summary>
        /// Gets or sets the reels that are not going to be placed
        /// </summary>
        public List<Reel> ExcludedReels
        {
            get { return this.excludedReels_; }
            set { this.excludedReels_ = value; }
        }

        /// <summary>
        /// Gets or sets the reels that are currently placed
        /// </summary>
        public List<Reel> ReelsInStackList
        {
            get { return this.reelsInStackList_; }
            set { this.reelsInStackList_ = value; }
        }

        /// <summary>
        /// Gets or sets the stacklisters of the project
        /// </summary>
        public List<StackList> StackListers
        {
            get { return this.stackListers_; }
            set { this.stackListers_ = value; }
        }

        /// <summary>
        /// Gets or sets the top reels of the stacklisters
        /// </summary>
        public List<Reel> TopReels
        {
            get { return this.topReels_; }
            set { this.topReels_ = value; }
        }

        /// <summary>
        /// Gets or sets the bottom reels of the stacklisters
        /// </summary>
        public List<Reel> BottomReels
        {
            get { return this.bottomReels_; }
            set { this.bottomReels_ = value; }
        }
    }
}
