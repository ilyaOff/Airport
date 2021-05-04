using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airoport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dtpStartTime.CustomFormat = "hh:mm";
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            nUDCountRunways.Value = Math.Max(nUDCountRunways.Value, nUDCountRunways.Minimum);
            nUDCountLandingRunways.Value = Math.Min(nUDCountLandingRunways.Value, nUDCountLandingRunways.Maximum);
        }

        private void nUDCountRunway_ValueChanged(object sender, EventArgs e)
        {
            nUDCountLandingRunways.Maximum = nUDCountRunways.Value - 1;
        }

        private void cbSepRunway_CheckedChanged(object sender, EventArgs e)
        {
            nUDCountLandingRunways.Enabled = cbSepRunway.Checked;
            lSepRunway1.Enabled = cbSepRunway.Checked;
            lSepRunway2.Enabled = cbSepRunway.Checked;
            if(!cbSepRunway.Checked)
                nUDCountRunways.Minimum = 2;
        }

        private void nUDCountLandingRunways_ValueChanged(object sender, EventArgs e)
        {
            if(cbSepRunway.Checked)
                nUDCountRunways.Minimum = nUDCountLandingRunways.Value + 1;
        }
    }
}
