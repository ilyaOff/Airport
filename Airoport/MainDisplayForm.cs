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
        Size runwaySize = new Size(330, 70);
        Point runwayLocation = new Point(210, 47);
        int runwayIntervalPosition = 110;

        public MainDisplayForm()
        {
            InitializeComponent();            
        }

        private void MainDisplayForm_Load(object sender, EventArgs e)
        {
            this.Show();
            NewExperiment();
        }
 
        private void PlaseRunway(Panel p, Chart ch, int number)
        {
            p.Size = runwaySize;
            p.Left = runwayLocation.X;            
            p.Top = runwayLocation.Y + runwayIntervalPosition * number;
            p.BackColor = pRunway0.BackColor;

            ch.Size = new Size(170, 104);
            ch.Left = runwayLocation.X + runwaySize.Width + 10;
            ch.Top =  25 + runwayIntervalPosition * number;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (exp.Tick())
            {
                timer1.Enabled = false;
                System.Windows.Forms.MessageBox.Show("Моделирование завершено");
            }
            else
                NextStepDraw();
        }

        private void bNextStep_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < exp.TimeStep; i++)
            {
                if (exp.Tick())
                {
                    timer1.Enabled = false;
                    System.Windows.Forms.MessageBox.Show("Моделирование завершено");
                    break;
                }
                NextStepDraw();
            }
        }

        private void bEnd_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            while(!exp.Tick())
            {
                NextStepDraw();//для перерисовки графики и данных
            }
            System.Windows.Forms.MessageBox.Show("Моделирование завершено"); 
        }

        void NextStepDraw()
        {
            //отрисовать графику
            tbCurrentTime.Text = ToTimeFormat(exp.CurrentTime);
            //Самолёты на полосе
            DrawAirplaneOnRunway();
            //самолеты в воздушной очереди
        }
        void DrawAirplaneOnRunway()
        {
            //if(pRunways.HorizontalScroll.Value != 84 && pRunways.HorizontalScroll.Value != 0)
            tbCurrentTime.Text = pRunways.HorizontalScroll.Value.ToString();            
            Airplane pl;
            int H0 = pRunway0.Size.Height;//длина(высота) общей полосы
            int hpl, wpl, H;
            int scrolV = pRunways.VerticalScroll.Value;
            int scrolH = pRunways.HorizontalScroll.Value;
            int runwayDown = pRunway0.Location.X + pRunway0.Size.Width / 4;
            int runwayUp = pRunway0.Location.X + pRunway0.Size.Width * 3 / 4;
            for (int i = 0; i < N; i++)
            {
                pl = exp.airport.runway[i].tmpAirplane;
                hpl = planes[i].Size.Height;
                wpl = planes[i].Size.Width;
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
                                    planes[i].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                    planes[i].Size = planes[i].Image.Size;
                                    planes[i].Refresh();

                                    hpl = planes[i].Size.Height;
                                    wpl = planes[i].Size.Width;
                                    planes[i].Top = H - hpl/2 - scrolV;
                                    planes[i].Left = -scrolH + runwayLocation.X - wpl/2;                                   
                                    break;

                                case State.SittingDown://-> State.RunwayOut                                    
                                    planes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    planes[i].Size = planes[i].Image.Size;
                                    planes[i].BackColor = Color.FromArgb(255, 255, 0);
                                    planes[i].Refresh();

                                    hpl = planes[i].Size.Height;
                                    wpl = planes[i].Size.Width;
                                    planes[i].Top = H - hpl - scrolV;
                                    planes[i].Left =  runwayUp - wpl / 2;
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
                                    planes[i].Top = -scrolV + H - (H0 * (pl.CurrentTime)) / Airplane.TimeMoveOnRunway;
                                    planes[i].Left = + runwayDown - wpl / 2;
                                    planes[i].BackColor = Color.FromArgb(255, 0, 0);
                                    break;
                                case State.RunwayOut:                                    
                                    planes[i].BackColor = Color.FromArgb(255, 255, 0);

                                    planes[i].Top = -hpl - H0 - scrolV + H + (H0 * (pl.CurrentTime)) / Airplane.TimeMoveOnRunway;
                                    planes[i].Left = + runwayUp - wpl / 2;
                                    break;
                                case State.TakingOff:                                    
                                    planes[i].BackColor = Color.FromArgb(0, 255, 0);

                                    planes[i].Top = H - hpl / 2 - scrolV;
                                    planes[i].Left = -scrolH + runwayLocation.X - wpl/2
                                             + runwaySize.Width  - (runwaySize.Width * pl.CurrentTime) / pl.MoveTime;
                                    break;
                                case State.SittingDown:
                                    planes[i].BackColor = Color.FromArgb(0, 0, 0);

                                    planes[i].Top = H - hpl / 2 - scrolV;
                                    planes[i].Left = -scrolH + runwayLocation.X- wpl
                                            + (runwaySize.Width* pl.CurrentTime)/ pl.MoveTime;
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
                                planes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                planes[i].Size = planes[i].Image.Size;
                                planes[i].BackColor = Color.FromArgb(255, 0, 0);

                                wpl = planes[i].Size.Width;
                                //hpl = planes[i].Size.Height;
                                planes[i].Top = (H - H0);
                                planes[i].Left =  runwayDown - wpl / 2;
                                break;
                            case State.SittingDown:
                                planes[i].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                planes[i].Size = planes[i].Image.Size;
                                planes[i].BackColor = Color.FromArgb(0, 0, 0);

                                hpl = planes[i].Size.Height;
                                wpl = planes[i].Size.Width;
                                planes[i].Top = H - hpl / 2 - scrolV;
                                planes[i].Left = -scrolH + runwayLocation.X + runwaySize.Width - wpl;
                                break;
                        }
                        planes[i].Refresh();
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

        
        private void nUDStep_ValueChanged(object sender, EventArgs e)
        {
            exp.TimeStep = (int)nUDStep.Value;
        }

        private void bParams_Click(object sender, EventArgs e)
        {
            NewExperiment();
        }

        void NewExperiment()
        {
            timer1.Enabled = false;
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

            //очистка старых полос

            //Расстановка полос
            pRunway0.Size = new Size(200,280 + runwayIntervalPosition * (N - 2) );
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


            LVSchedue.Items.Clear();
            //заполнение таблицы расписания
            int j = 0;
            foreach (Request rec in exp.airport.schedue.requests)
            {
                LVSchedue.Items.Add("-");
                LVSchedue.Items[j].SubItems.Add(rec.AirplaneName);
                LVSchedue.Items[j].SubItems.Add(statutes[0]);
                LVSchedue.Items[j].SubItems.Add(ToTimeFormat(rec.TimeSchedue));
                j++;
            }
            timer1.Enabled = true;
        }
    }
}
