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
            if (f.DialogResult != DialogResult.OK)
            {
                MessageBox.Show("Invalid Start", "Error");                
                return;
            }
            N = (int)f.nUDCountRunway.Value;
            //создание эксперимента
            exp = new Experiment((int)nUDStep.Value,
                f.dtpStartTime.Value.Hour * 60 + f.dtpStartTime.Value.Minute,
                f.cbSepRunway.Checked, N, (int)f.nUDCountLandingRunways.Value,
                (int)f.nUDDelayMin.Value, (int)f.nUDDelayMax.Value,
                (int)f.nUDTimeInterval.Value, f.tbShedule.Text);

            //Изменение шага моделирования
            nUDStep.Value = f.nUDStep.Value;


            //Расстановка полос
            pRunway0.Size += new Size(0, 110 * (N - 2) - 10);
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
            }

            //Изображения самолетов
            airWaitingPlanes = new List<PictureBox>();
            planes = new PictureBox[N];
            for (int i = 0; i < N; i++)
            {
                planes[i] = new PictureBox();
               // planes[i].BackColor = Color.FromArgb(150,255, 0, 0);
                //planes[i].Size = global::Airoport.Properties.Resources.ПассажирскийВзлёт2.Size;
                //planes[i].Location = new Point(0, 0);
                planes[i].Parent = pRunways;
                //planes[i].Image = global::Airoport.Properties.Resources.ПассажирскийВзлёт2;
                //planes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                planes[i].TabIndex = 0;
                planes[i].TabStop = false;

                planes[i].BringToFront();
                planes[i].Visible = false;
            }

            
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
            timer1.Enabled = true;
        }

        Size runwaySize = new Size(330, 70);
        Point runwayLocation = new Point(210, 47);
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
            exp.Tick();
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Refresh();
            NextStepDraw();
        }
        void NextStepDraw()
        {
            
            //отрисовать графику
            tbCurrentTime.Text = ToTimeFormat(exp.CurrentTime);
            //Самолёты на полосе
            DrawAirplaneOnRunway();
            //самолеты в воздушной очереди
        }
        private void DrawAirplaneOnRunway()
        {            
            Airplane pl;
            int H0 = pRunway0.Size.Height;//длина(высота) общей полосы
            int hpl, H;
            for (int i = 0; i < N; i++)
            {
                pl = exp.airport.runway[i].tmpAirplane;
                hpl = planes[i].Size.Height;
                //середина текущей посадочной полосы (высота)
                H = runwayLocation.Y + runwayIntervalPosition * i + runwaySize.Height / 2;
                if (planes[i].Visible)
                {
                    if (pl != null)
                    {
                        if (pl.CurrentTime == 0)
                        {
                            //Устанавливаем изображение самолета в нужную позицию, поворачиваем при необходимости
                            switch (pl.state)
                            {
                                case State.RunwayIn://-> State.TakeOff
                                    
                                    planes[i].BackColor = Color.FromArgb(0, 255, 0);
                                    planes[i].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);//????
                                    planes[i].Size = planes[i].Image.Size;
                                    planes[i].Refresh();

                                    hpl = planes[i].Size.Height;
                                    planes[i].Top = H - hpl / 2;
                                    planes[i].Left = runwayLocation.X - planes[i].Size.Width;
                                    break;                               
                                
                                case State.SittingDown://-> State.RunwayOut
                                    planes[i].Size = new Size(planes[i].Image.Height, planes[i].Image.Width);
                                    planes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);//????
                                    planes[i].BackColor = Color.FromArgb(255, 255, 0);
                                    planes[i].Refresh();

                                    hpl = planes[i].Size.Height;
                                    planes[i].Top = H - hpl;
                                    planes[i].Left = pRunway0.Location.X + pRunway0.Size.Width * 3 / 4
                                                    - planes[i].Size.Width / 2;
                                    break;
                                case State.RunwayOut:
                                    //самолёт завершил перемещение, но не перешел в состояние Done
                                    //исправление поворота картинки
                                    planes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    planes[i].Visible = false;
                                    break;
                                default:
                                    //самолёт завершил перемещение, но не перешел в состояние Done
                                    planes[i].Visible = false;                                    
                                    //MessageBox.Show(pl.Name + " " + pl.state.ToString());
                                    break;
                            }
                        }
                        else
                        {
                            //двигаем самолёт по полосе, согласно его состоянию
                            switch (pl.state)
                            {
                                case State.RunwayIn:
                                    /*planes[i].Left = pRunway0.Location.X + pRunway0.Size.Width / 4
                                                    + planes[i].Size.Width / 2;*/
                                    //planes[i].Top = (H0 - hpl - (H0 * pl.CurrentTime) / Airplane.TimeMoveOnRunway) / 2;
                                    planes[i].BackColor = Color.FromArgb(255, 0, 0);
                                    planes[i].Top += H0 / (2 * Airplane.TimeMoveOnRunway);
                                    break;
                                case State.RunwayOut:
                                    //planes[i].Top = (H0 - hpl + (H0 * pl.CurrentTime) / Airplane.TimeMoveOnRunway) / 2;
                                    planes[i].BackColor = Color.FromArgb(255, 255, 0);
                                    planes[i].Top -= H0 / (2 * Airplane.TimeMoveOnRunway);
                                    break;
                                case State.TakingOff:
                                    planes[i].BackColor = Color.FromArgb(0, 255, 0);
                                    planes[i].Left += runwaySize.Width / pl.MoveTime;
                                    break;
                                case State.SittingDown:
                                    planes[i].BackColor = Color.FromArgb(0, 0, 0);
                                    planes[i].Left -= runwaySize.Width / pl.MoveTime;
                                    break;
                            }
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
                                planes[i].BackColor = Color.FromArgb(255, 0, 0);
                                planes[i].Refresh();

                                hpl = planes[i].Size.Height;
                                planes[i].Top = H - H0 +hpl + H0/Airplane.TimeMoveOnRunway;// (H0 - hpl) / 2;
                                planes[i].Left = pRunway0.Location.X + pRunway0.Size.Width / 4
                                                - planes[i].Size.Width / 2;
                                break;
                            case State.SittingDown:
                                planes[i].Size = planes[i].Image.Size;
                                planes[i].BackColor = Color.FromArgb(0, 0, 0);
                                planes[i].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                planes[i].Refresh();

                                hpl = planes[i].Size.Height;
                                planes[i].Top = H - hpl / 2;
                                planes[i].Left = runwayLocation.X + runwaySize.Width - planes[i].Width;
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
            //exp.NextStep();
            //NextStepDraw();
            for (int i = 0; i < exp.TimeStep; i++)
            {
                exp.Tick();
                NextStepDraw();
            }
           
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
            timer1.Enabled = false;
            exp.ToEnd();
            NextStepDraw();//для перерисовки графики и данных
        }

        private void nUDStep_ValueChanged(object sender, EventArgs e)
        {
            exp.TimeStep = (int)nUDStep.Value;
        }
    }
}
