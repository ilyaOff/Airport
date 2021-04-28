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
        PictureBox[] planes = null;
        Panel[] pRunways = null;
        Chart[] chRunways = null;
        List<PictureBox> airWaitingPlanes = null;
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
            //chDelay.Series.Add(new Series());
            NewExperiment();
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

            pRunway0.Size = new Size(200, 280 + runwayIntervalPosition * (N - 2));

            //полосы
            if (pRunways == null)
            {
                int max = (int)f.nUDCountRunway.Maximum;
                pRunways = new Panel[max];
                for (int i = 0; i < max; i++)
                {
                    pRunways[i] = new Panel
                    {
                        Parent = pRunwayMap,
                        Location = new Point(0, 0),
                        Visible = false
                        //Name = "pRunway" + (1 + i).ToString()
                    };
                }
            }
            else
            {
                for (int i = 0; i < pRunways.Length; i++)
                {
                    pRunways[i].Location = new Point(0, 0);
                    pRunways[i].Visible = false;
                }
            }
            //графики к полосам
            if (chRunways == null)
            {
                int max = (int)f.nUDCountRunway.Maximum;
                chRunways = new Chart[max];
                for (int i = 0; i < max; i++)
                {
                    chRunways[i] = new Chart
                    {
                        Parent = pRunwayMap,
                        Location = new Point(0, 0),
                        Visible = false,
                        //Name = "chRunway" + (1 + i).ToString()
                    };
                    chRunways[i].ChartAreas.Add(new ChartArea());
                    chRunways[i].Series.Add(new Series("TakeOff"));
                    chRunways[i].Series.Add(new Series("Landing"));

                    chRunways[i].Series[0].ChartType = SeriesChartType.Line;
                    chRunways[i].Series[0].BorderWidth = 3;
                    chRunways[i].Series[0].Color = Color.Red;
                    chRunways[i].Series[0].Points.AddXY(0, 0);

                    chRunways[i].Series[1].ChartType = SeriesChartType.Line;
                    chRunways[i].Series[0].BorderWidth = 3;
                    chRunways[i].Series[0].Color = Color.Blue;
                    chRunways[i].Series[1].Points.AddXY(0, 0);
                }
            }
            else
            {
                for (int i = 0; i < chRunways.Length; i++)
                {
                    chRunways[i].Location = new Point(0, 0);
                    chRunways[i].Visible = false;
                    chRunways[i].Series[0].Points.Clear();
                    chRunways[i].Series[1].Points.Clear();
                    chRunways[i].Series[0].Points.AddXY(0, 0);
                    chRunways[i].Series[1].Points.AddXY(0, 0);
                }
            }

            //Расстановка полос
            for (int i = 0; i < N; i++)
            {
                pRunways[i].Visible = true;
                chRunways[i].Visible = true;

                PlaseRunway(pRunways[i], chRunways[i], i);
            }
            //Изображения самолетов
            if (planes == null)
            {
                int max = (int)f.nUDCountRunway.Maximum;
                planes = new PictureBox[max];
                for (int i = 0; i < max; i++)
                {
                    planes[i] = new PictureBox();
                    //planes[i].BackColor = Color.FromArgb(0, 0, 0, 0);
                    planes[i].Parent = pRunwayMap;
                    planes[i].TabIndex = 0;
                    planes[i].TabStop = false;

                    planes[i].BringToFront();
                    planes[i].Visible = false;
                }
            }
            else // очистка (сокрытие) изображений самолётов
            {
                for (int i = 0; i < planes.Length; i++)
                {
                    planes[i].Location = new Point(0, 0);
                    //planes[i].BackColor = Color.FromArgb(0, 0, 0, 0);

                    planes[i].BringToFront();
                    planes[i].Visible = false;
                }
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
        void PlaseRunway(Panel p, Chart ch, int number)
        {
            p.Size = runwaySize;
            p.Left = runwayLocation.X;
            p.Top = runwayLocation.Y + runwayIntervalPosition * number;
            p.BackColor = pRunway0.BackColor;

            ch.Size = new Size(170, 104);
            ch.Left = runwayLocation.X + runwaySize.Width + 10;
            ch.Top = 25 + runwayIntervalPosition * number;
        }

        void NextStepDraw()
        {
            //Текущее время
            tbCurrentTime.Text = ToTimeFormat(exp.CurrentTime);
            //длина очередей
            tbLandingQueueLength.Text = exp.airport.LandingQueue.Count.ToString();
            tbTakeOffQueueLength.Text = exp.airport.TakeoffQueue.Count.ToString();
            //Уменьшение количества точек
            while (chDelay.Series[0].Points.Count > 60)
            {
                chDelay.Series[0].Points.RemoveAt(0);
                chDelay.Series[1].Points.RemoveAt(0);
            }
            //максимальная задержка
            int maxTakeoff = 0, maxLanding = 0;
            Airplane pl = null;
            if (exp.airport.LandingQueue.Count != 0)
            {
                pl = exp.airport.LandingQueue.Peek();
                maxLanding = Math.Max(0, pl.CurrentTime);                
            }            
            if (exp.airport.TakeoffQueue.Count != 0)
            {
                pl = exp.airport.TakeoffQueue.Peek();
                maxTakeoff = Math.Max(0, pl.CurrentTime);
            }

            chDelay.Series[1].Points.AddXY(exp.CurrentTime, maxLanding);
            chDelay.Series[0].Points.AddXY(exp.CurrentTime, maxTakeoff);
            chDelay.ChartAreas[0].AxisX.Minimum = Math.Max(0, exp.CurrentTime - 60);
            chDelay.ChartAreas[0].AxisX.Maximum = exp.CurrentTime;
            chDelay.ChartAreas[0].AxisY.Maximum = Math.Max(chDelay.ChartAreas[0].AxisY.Maximum, Math.Max(maxTakeoff, maxLanding));
            tbDelay.Text = Math.Max(maxTakeoff, maxLanding).ToString();

            //отрисовать графику
            //Самолёты на полосе
            DrawAirplaneOnRunway();
            //самолеты в воздушной очереди

            //Общее число заявок
            while(chCountRequestDone.Series[0].Points.Count > 60)
            {
                chCountRequestDone.Series[0].Points.RemoveAt(0);
                chCountRequestDone.Series[1].Points.RemoveAt(0);
            }
            int countTakeOff = 0;
            for (int i = 0; i < N; i++)
            {
                countTakeOff += (int)chRunways[i].Series[0].Points.Last().YValues[0];
            }
            int countLanding = 0;
            for (int i = 0; i < N; i++)
            {
                countLanding += (int)chRunways[i].Series[1].Points.Last().YValues[0];
            }
            chCountRequestDone.Series[0].Points.AddXY(exp.CurrentTime, countTakeOff);
            chCountRequestDone.Series[1].Points.AddXY(exp.CurrentTime, countLanding);

            chCountRequestDone.ChartAreas[0].AxisY.Minimum = chCountRequestDone.Series[0].Points.First().YValues[0];
            chCountRequestDone.ChartAreas[0].RecalculateAxesScale();
            tbDoneRequest.Text = (countTakeOff + countLanding).ToString();

            //средняя занятость полос
            chAvgRunwayWork.Series[0].Points.Clear();
            for (int i = 0; i < N; i++)
            {
                if (countLanding + countTakeOff == 0) break;
                chAvgRunwayWork.Series[0].Points.Add(100*(chRunways[i].Series[0].Points.Last().YValues[0]
                    + chRunways[i].Series[1].Points.Last().YValues[0])/(countTakeOff+countLanding));
            }

        }
        void DrawAirplaneOnRunway()
        {
            Airplane pl;
            int H0 = pRunway0.Size.Height;//длина(высота) общей полосы
            int hpl, wpl, H;
            //int scrolV = pRunwayMap.VerticalScroll.Value;
            //int scrolH = pRunwayMap.HorizontalScroll.Value;
            int runwayDown = pRunway0.Location.X + pRunway0.Size.Width / 4;
            int runwayUp = pRunway0.Location.X + pRunway0.Size.Width * 3 / 4;
            for (int i = 0; i < N; i++)
            {
                pl = exp.airport.runway[i].tmpAirplane;
                hpl = planes[i].Size.Height;
                wpl = planes[i].Size.Width;
                //середина текущей посадочной полосы (высота)
                //H = runwayLocation.Y + runwayIntervalPosition * i + runwaySize.Height / 2;
                H = pRunways[i].Top + pRunways[i].Size.Height / 2;
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
                                    //planes[i].BackColor = Color.FromArgb(0, 255, 0);
                                    planes[i].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                    planes[i].Size = planes[i].Image.Size;
                                    planes[i].Refresh();

                                    hpl = planes[i].Size.Height;
                                    wpl = planes[i].Size.Width;
                                    planes[i].Top = H - hpl / 2;
                                    planes[i].Left = pRunways[i].Left - wpl / 2;
                                    break;

                                case State.SittingDown://-> State.RunwayOut                                    
                                    planes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    planes[i].Size = planes[i].Image.Size;
                                    //planes[i].BackColor = Color.FromArgb(255, 255, 0);
                                    planes[i].Refresh();

                                    hpl = planes[i].Size.Height;
                                    wpl = planes[i].Size.Width;
                                    planes[i].Top = H - hpl;
                                    planes[i].Left = runwayUp - wpl / 2;
                                    break;
                                case State.RunwayOut:
                                    //самолёт завершил перемещение, но не перешел в состояние Done
                                    //исправление поворота картинки
                                    planes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    planes[i].Visible = false;
                                    NewDoneRequest(i, pl.SummonerRequest.dir);
                                    break;
                                case State.TakingOff:
                                    //самолёт завершил перемещение, но не перешел в состояние Done
                                    //исправление поворота картинки                                   
                                    planes[i].Visible = false;
                                    NewDoneRequest(i, pl.SummonerRequest.dir);
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
                                    planes[i].Top = H - (H0 * (pl.CurrentTime)) / Airplane.TimeMoveOnRunway;
                                    planes[i].Left = runwayDown - wpl / 2;
                                    //planes[i].BackColor = Color.FromArgb(255, 0, 0);
                                    break;
                                case State.RunwayOut:
                                    //planes[i].BackColor = Color.FromArgb(255, 255, 0);

                                    planes[i].Top = -hpl - H0 + H + (H0 * (pl.CurrentTime)) / Airplane.TimeMoveOnRunway;
                                    planes[i].Left = runwayUp - wpl / 2;
                                    break;
                                case State.TakingOff:
                                    //planes[i].BackColor = Color.FromArgb(0, 255, 0);

                                    planes[i].Top = H - hpl / 2;
                                    planes[i].Left = pRunways[i].Left - wpl / 2
                                             + pRunways[i].Size.Width - (pRunways[i].Size.Width * pl.CurrentTime) / pl.MoveTime;
                                    break;
                                case State.SittingDown:
                                   // planes[i].BackColor = Color.FromArgb(0, 0, 0);

                                    planes[i].Top = H - hpl / 2;
                                    planes[i].Left = pRunways[i].Left - wpl
                                            + (pRunways[i].Size.Width * pl.CurrentTime) / pl.MoveTime;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        //заявка обработана
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
                                //planes[i].BackColor = Color.FromArgb(255, 0, 0);

                                wpl = planes[i].Size.Width;
                                //hpl = planes[i].Size.Height;
                                planes[i].Top = (H - H0);
                                planes[i].Left = runwayDown - wpl / 2;
                                break;
                            case State.SittingDown:
                                planes[i].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                planes[i].Size = planes[i].Image.Size;
                                //planes[i].BackColor = Color.FromArgb(0, 0, 0);

                                hpl = planes[i].Size.Height;
                                wpl = planes[i].Size.Width;
                                planes[i].Top = H - hpl / 2;
                                planes[i].Left = pRunways[i].Left + pRunways[i].Size.Width - wpl;
                                break;
                        }
                        planes[i].Refresh();
                    }
                }
            }
        }

        void NewDoneRequest(int nRunway, Direction dir)
        {
            //Уменьшение количества точек
            while (chRunways[nRunway].Series[0].Points.Count > 60)
            {
                chRunways[nRunway].Series[0].Points.RemoveAt(0);
            }
            while (chRunways[nRunway].Series[1].Points.Count > 60)
            {
                chRunways[nRunway].Series[1].Points.RemoveAt(0);
            }

            if (dir == Direction.Landing)
            {
                chRunways[nRunway].Series[0].Points.AddXY(exp.CurrentTime, 
                                        chRunways[nRunway].Series[0].Points.Last().YValues[0]);
                chRunways[nRunway].Series[1].Points.AddXY(exp.CurrentTime,
                                        1 + chRunways[nRunway].Series[1].Points.Last().YValues[0]);
            }
            else
            {
                chRunways[nRunway].Series[0].Points.AddXY(exp.CurrentTime,
                                        1 + chRunways[nRunway].Series[0].Points.Last().YValues[0]);
                chRunways[nRunway].Series[1].Points.AddXY(exp.CurrentTime,
                                        chRunways[nRunway].Series[1].Points.Last().YValues[0]);
            }
            chRunways[nRunway].ChartAreas[0].AxisX.Minimum = Math.Max(0, exp.CurrentTime - 60);
            chRunways[nRunway].ChartAreas[0].AxisX.Maximum = Math.Max(10, exp.CurrentTime);
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
    }
}
