using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickAndPlace
{
    public partial class MergeForm : Form
    {
        private Reel selectedReel_;
        private List<Reel> displayedReels;

        private MergeForm()
        {
            InitializeComponent();
        }

        public MergeForm(List<Reel> reelsToDisplay)
            : this()
        {
            displayedReels = reelsToDisplay;
            lvReels.BeginUpdate();
            foreach (Reel curReel in reelsToDisplay)
            {
                string[] reelData = curReel.GenerateListViewText();
                ListViewItem newLvItem = new ListViewItem(reelData);
                lvReels.Items.Add(newLvItem);
            }
            lvReels.EndUpdate();
        }

        /// <summary>
        /// Get the reel that was selected
        /// </summary>
        public Reel SelectedReel
        {
            get { return selectedReel_; }
        }
        /*-------------------------------------------------------------*/
        private void btnOk_Click(object sender, EventArgs e)
        {
            selectedReel_ = displayedReels.Find(reel => reel.GetDisplayString() == lvReels.SelectedItems[0].Text);
            if (selectedReel_ == null)
            {
                MessageBox.Show("Please select a reel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Warning: this change is irreversible" + Environment.NewLine + "Are you sure?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
