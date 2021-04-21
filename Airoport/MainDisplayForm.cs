using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Airoport
{
    public partial class MainDisplayForm : Form
    {
        Experiment exp;
        public MainDisplayForm()
        {
            InitializeComponent();            
        }

        private void MainDisplayForm_Load(object sender, EventArgs e)
        {
            //this.Show();
            Form1 f = new Form1();
            int N = 2;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                nUDStep.Value = f.nUDStep.Value;
                N = (int)f.nUDCountRunway.Value;
                pRunway0.Size += new Size(0, 110*(N-2)-10);
            }
            //Расстановка полос
            for (int i = 0; i < N; i++)
            {
                Panel p = new Panel
                {
                    Parent = pRunways
                };
                Chart ch = new Chart
                {
                    Parent = pRunways
                };
                PlaseRunway(p, ch, 0, i);
                Console.WriteLine("new " + i);
            }


            exp = new Experiment((int)nUDStep.Value,
                f.dtpStartTime.Value.Hour * 60 + f.dtpStartTime.Value.Minute,
                f.cbSepRunway.Checked, N, (int)f.nUDCountLandingRunways.Value,
                (int)f.nUDDelayMin.Value, (int)f.nUDDelayMax.Value,
                (int)f.nUDTimeInterval.Value, f.tbShedule.Text);
            timer1.Enabled = true;

            //LVSchedue.Items.Add();
            

        }
        private void PlaseRunway(Panel p, Chart ch, int x, int y)
        {
            p.Size = new Size(330, 70);
            p.Left = 100 + x;
            p.Top =  47 + 110*y;
            p.BackColor = pRunway0.BackColor;

            ch.Size = new Size(170, 104);
            ch.Left =  435 + x;
            ch.Top =  25 + 110*y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            exp.NextStep();
            //отрисовать графику
        }
    }
}
