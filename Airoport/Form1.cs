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
            MainDisplayForm f = new MainDisplayForm();
            f.nUDStep.Value = nUDStep.Value;
            f.ShowDialog();
            
        }
    }
}
