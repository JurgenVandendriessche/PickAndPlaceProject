using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickAndPlace
{
    public partial class BoardSettingsControl : UserControl
    {
        public BoardSettingsControl()
        {
            InitializeComponent();
        }

        //Shared properties

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("custom"),
        System.ComponentModel.DefaultValue("title"),
        System.ComponentModel.Description("title shown in the upper left corner")]
        public string title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; base.Refresh(); }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
         System.ComponentModel.Category("custom"),
         System.ComponentModel.DefaultValue(""),
         System.ComponentModel.Description("Gets or sets the unit of the numbers")]
        public string unit
        {
            get { return this.nudX.unit; }
            set
            {
                this.nudX.unit = value;
                this.nudY.unit = value;
            }
        }


        [System.ComponentModel.Browsable(true),
         System.ComponentModel.Category("custom"),
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
        System.ComponentModel.Category("custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal),"0"),
        System.ComponentModel.Description("Gets or sets the value of X")]
        public decimal valueX
        {
            get { return this.nudX.Value; }
            set { this.nudX.Value = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal),"0"),
        System.ComponentModel.Description("Gets or sets the minimum value of X")]
        public decimal MinimumX
        {
            get { return this.nudX.Minimum; }
            set { this.nudX.Minimum = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "100"),
        System.ComponentModel.Description("Gets or sets the maximum value of X")]
        public decimal MaximumX
        {
            get { return this.nudX.Maximum; }
            set { this.nudX.Maximum = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal),"1"),
        System.ComponentModel.Description("Gets or sets the value to increment or decrement X when the up or down buttons are clicked")]
        public decimal IncrementX
        {
            get { return this.nudX.Increment; }
            set { this.nudX.Increment = value; }
        }

        //properties of nudY

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "0"),
        System.ComponentModel.Description("Gets or sets the value of Y")]
        public decimal valueY
        {
            get { return this.nudY.Value; }
            set { this.nudY.Value = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "0"),
        System.ComponentModel.Description("Gets or sets the minimum value of Y")]
        public decimal MinimumY
        {
            get { return this.nudY.Minimum; }
            set { this.nudY.Minimum = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "100"),
        System.ComponentModel.Description("Gets or sets the maximum value of Y")]
        public decimal MaximumY
        {
            get { return this.nudY.Maximum; }
            set { this.nudY.Maximum = value; }
        }
        /*-------------------------------------------------------------*/
        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("custom"),
        System.ComponentModel.DefaultValue(typeof(Decimal), "1"),
        System.ComponentModel.Description("Gets or sets the value to increment or decrement Y when the up or down buttons are clicked")]
        public decimal IncrementY
        {
            get { return this.nudY.Increment; }
            set { this.nudY.Increment = value; }
        }
    }
}