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
        PictureBox[] planes;
        List<PictureBox> airWaitingPlanes;
        int N;
        string[] statutes = new string[]
        {                
                "Ожидание",//начала события
                "В очереди",
                "Подготовка",//полосы
                "Взлёт",
                "Посадка",
                "Завершено",
        };
        public MainDisplayForm()
        {
            InitializeComponent();            
        }

        private void MainDisplayForm_Load(object sender, EventArgs e)
        {
            //this.Show();
            Form1 f = new Form1();
            N = 2;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                nUDStep.Value = f.nUDStep.Value;
                N = (int)f.nUDCountRunway.Value;
                pRunway0.Size += new Size(0, 110 * (N - 2) - 10);
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
                PlaseRunway(p, ch, i);
                Console.WriteLine("new " + i);
            }

            //Изображения самолетов
            airWaitingPlanes = new List<PictureBox>();
            planes = new PictureBox[N];
            for (int i = 0; i < N; i++)
            {
                planes[i] = new PictureBox();
               // planes[i].BackColor = Color.FromArgb(150,255, 0, 0);
                planes[i].Size = global::Airoport.Properties.Resources.ПассажирскийВзлёт2.Size;
                planes[i].Location = new Point(0, 0);
                planes[i].Parent = pRunways;
                planes[i].Image = global::Airoport.Properties.Resources.ПассажирскийВзлёт2;
                planes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                planes[i].TabIndex = 0;
                planes[i].TabStop = false;

                planes[i].BringToFront();
                planes[i].Visible = false;
            }

            //создание эксперимента
            exp = new Experiment((int)nUDStep.Value,
                f.dtpStartTime.Value.Hour * 60 + f.dtpStartTime.Value.Minute,
                f.cbSepRunway.Checked, N, (int)f.nUDCountLandingRunways.Value,
                (int)f.nUDDelayMin.Value, (int)f.nUDDelayMax.Value,
                (int)f.nUDTimeInterval.Value, f.tbShedule.Text);
            timer1.Enabled = true;

            //заполнение таблицы расписания
            int j = 0;
            foreach(Request rec in exp.airport.schedue.requests )
            {
                LVSchedue.Items.Add("-");
                LVSchedue.Items[j].SubItems.Add(rec.AirplaneName);
                LVSchedue.Items[j].SubItems.Add(statutes[0]);
                LVSchedue.Items[j].SubItems.Add(ToTimeFormat(rec.TimeSchedue));
                j++;
            }            

        }

        Size runwaySize = new Size(330, 70);
        Point runwayLocation = new Point(100, 47);
        int runwayIntervalPosition = 110;
        private void PlaseRunway(Panel p, Chart ch, int number)
        {
            p.Size = runwaySize;
            p.Left = runwayLocation.X;            
            p.Top = runwayLocation.Y + runwayIntervalPosition * number;
            p.BackColor = pRunway0.BackColor;

            ch.Size = new Size(170, 104);
            ch.Left =  435;
            ch.Top =  25 + runwayIntervalPosition * number;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextStep();
        }
        void NextStep()
        {
            exp.NextStep();
            //отрисовать графику
            tbCurrentTime.Text = ToTimeFormat(exp.CurrentTime);
            //Самолёты на полосе
            DrawAirplaneOnRunway();
            //самолеты в воздушной очереди
        }
        private void DrawAirplaneOnRunway()
        {            
            Airplane pl;
            int H0 = pRunway0.Size.Height;
            int hpl, H;
            for (int i = 0; i < N; i++)
            {
                pl = exp.airport.runway[i].tmpAirplane;
                hpl = planes[i].Size.Height;
                H = runwayLocation.Y + runwayIntervalPosition * i + runwaySize.Height / 2;
                if (planes[i].Visible)
                {
                    if (pl != null)
                    {
                        //двигаем самолёт по полосе, согласно его состоянию
                        switch (pl.state)
                        {
                            case State.RunwayIn:
                                /*planes[i].Left = pRunway0.Location.X + pRunway0.Size.Width / 4
                                                + planes[i].Size.Width / 2;*/
                                planes[i].Top = (-hpl + (H0 * pl.CurrentTime) / Airplane.TimeMoveOnRunway) / 2;
                                break;
                            case State.RunwayOut:
                                planes[i].Top = (H0 - hpl - (H0 * pl.CurrentTime) / Airplane.TimeMoveOnRunway) / 2;
                                break;
                            case State.TakingOff:
                                planes[i].Left += runwaySize.Width / pl.MoveTime;
                                break;
                            case State.SittingDown:
                                planes[i].Left -= runwaySize.Width / pl.MoveTime;
                                break;
                        }
                    }
                    else
                    {
                        planes[i].Visible = false;
                    }
                }
                else
                {
                    if (pl != null)
                    {
                        planes[i].Visible = true;
                        //switch (pl.Type)
                        planes[i].Image = global::Airoport.Properties.Resources.ПассажирскийВзлёт2;

                        switch (pl.state)
                        {
                            case State.RunwayIn:
                                planes[i].Size = new Size(planes[i].Image.Height, planes[i].Image.Width);
                                planes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                                hpl = planes[i].Size.Height;
                                planes[i].Top = (H0 - hpl) / 2;
                                planes[i].Left = pRunway0.Location.X + pRunway0.Size.Width / 4
                                                + planes[i].Size.Width / 2;
                                break;
                            case State.SittingDown:
                                planes[i].Size = planes[i].Image.Size;
                                planes[i].Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                                planes[i].Top = H - planes[i].Size.Height;
                                planes[i].Left = runwayLocation.X + runwaySize.Width;
                                break;
                        }
                    }
                }

            }
        }

        string ToTimeFormat(int time)
        {
            string res = "";
            if ((time / 60) < 10)
            {
                res += "0";
            }
            res += (time / 60).ToString() + ":";
            if ((time % 60) < 10)
            {
                res += "0";
            }
            res += (time % 60).ToString();
            return res;
        }

        private void bNextStep_Click(object sender, EventArgs e)
        {
            NextStep();
        }

        private void bPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled)
            {
                bPause.Text = "Прервать моделирование";
            }
            else
            {
                bPause.Text = "Продолжить моделирование";
            }
        }

        private void bEnd_Click(object sender, EventArgs e)
        {
            exp.ToEnd();
            NextStep();//для перерисовки графики и данных
        }
    }
}
