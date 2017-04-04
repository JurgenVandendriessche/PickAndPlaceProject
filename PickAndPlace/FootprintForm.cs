using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PnpLib;

namespace PickAndPlace
{
    public partial class FootprintForm : Form
    {
        /// <summary>
        /// Footprint passed between the save event and the getFootprint function, null if user presed cancel
        /// </summary>
        private Footprint footPrint_;

        public FootprintForm()
        {
            InitializeComponent();
            cbxNozzle.DataSource = Enum.GetValues(typeof(Nozzle));

            foreach (StackType stackType_ in Enum.GetValues(typeof(StackType)))
            {
                cbxStackType.Items.Add(PNPconverterTools.stackTypeToString(stackType_));
            }
#if (DEBUG)
            tbxMPN.Text = "TEST";
#endif

            //TO DO: fill cbxKnown with predefined exampels and give the combobox a better name
        }

        /// <summary>
        /// Sets the footprint to be eddited
        /// </summary>
        /// <param name="footprint">Footprint to be eddited</param>
        public void setFootprint(Footprint footprint)
        {
            tbxMPN.Text = footprint.manufacturerPartNumber;
            nudwuHeight.Value = (decimal)footprint.Height;
            nudwuLength.Value = (decimal)footprint.Length;
            nudwuWidth.Value = (decimal)footprint.width;
            nudwuRotation.Value = footprint.rotation;
            bscOffset.valueX = (decimal)footprint.offsetStackX;
            bscOffset.valueY = (decimal)footprint.offsetStackY;
            cbxNozzle.SelectedItem = footprint.nozzle;
            cbxStackType.SelectedItem = PNPconverterTools.stackTypeToString(footprint.stacktype);
            nudwuFeedRate.Value = (decimal)footprint.feedRate;
        }
        /*-------------------------------------------------------------*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            string manufacturerPartNumber = tbxMPN.Text;
            float width = (float)nudwuWidth.Value;
            float length = (float)nudwuLength.Value;
            float height = (float)nudwuHeight.Value;
            int rotation = Convert.ToInt32(nudwuRotation.Value);
            float offsetX = (float)bscOffset.valueX;
            float offsetY = (float)bscOffset.valueY;
            float feedRate = (float)nudwuFeedRate.Value;
            StackType stackType = PNPconverterTools.stringToStackType(cbxStackType.SelectedItem.ToString());

            footPrint_ = new Footprint(manufacturerPartNumber, width, length, height, rotation, offsetX, offsetY, feedRate, (Nozzle)cbxNozzle.SelectedItem, stackType);
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
        /// Gets the footprint
        /// </summary>
        /// <returns>Generated footprint</returns>
        public Footprint getFootprint()
        {
            return footPrint_;
        }
        /*-------------------------------------------------------------*/
        private void cbxStackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStackType.SelectedItem.ToString() == PNPconverterTools.stackTypeToString(StackType.Tray18mm))
            {
                nudwuFeedRate.Value = 18;
                nudwuFeedRate.Enabled = false;
            }
            else
            {
                nudwuFeedRate.Enabled = true;
            }
        }
    }
}
