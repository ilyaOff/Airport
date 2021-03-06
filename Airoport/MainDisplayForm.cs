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
        Size runwaySize = new Size(330, 90);
        Point runwayLocation = new Point(210, 47);
        int runwayIntervalPosition = 125;
        int countDoneRequestsTakeOff = 0;
        int countDoneRequestsLanding = 0;
        int chartDelayIStart = 0;
        int startTime = 0;
        public MainDisplayForm()
        {
            InitializeComponent();
        }

        private void MainDisplayForm_Load(object sender, EventArgs e)
        {
            this.Show();
            airWaitingPlanes = new List<PictureBox>();
            NewExperiment();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (exp.NextStep() || exp.airport.schedue.requests.Count() == (countDoneRequestsTakeOff + countDoneRequestsLanding))
            {
                timer1.Enabled = false;
                NextStepDraw();
                System.Windows.Forms.MessageBox.Show("Моделирование завершено");
            }
            else
                NextStepDraw();            
        }

        private void bNextStep_Click(object sender, EventArgs e)
        {            
            if (exp.NextStep() || exp.airport.schedue.requests.Count() == (countDoneRequestsTakeOff + countDoneRequestsLanding))
            {                
                timer1.Enabled = false;
                NextStepDraw();
                System.Windows.Forms.MessageBox.Show("Моделирование завершено");
            }
            else
                NextStepDraw();            
        }

        private void bEnd_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            exp.ToEnd();
            NextStepDraw();            
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
            N = (int)f.nUDCountRunways.Value;

            startTime = f.dtpStartTime.Value.Hour * 60 + f.dtpStartTime.Value.Minute;
            //создание эксперимента
            exp = new Experiment((int)nUDStep.Value,startTime,
                f.cbSepRunway.Checked, N, (int)f.nUDCountLandingRunways.Value,
                (int)f.nUDDelayMin.Value, (int)f.nUDDelayMax.Value,
                (int)f.nUDTimeInterval.Value, f.tbShedule.Text);

            //Изменение шага моделирования
            nUDStep.Value = f.nUDStep.Value;

            //картинка полос
            pRunwayMap.VerticalScroll.Value = 0;
            pRunwayMap.HorizontalScroll.Value = 0;
            pRunway0.Size = new Size(200, 280 + runwayIntervalPosition * (N - 2));

            //полосы
            if (pRunways == null)
            {
                int max = (int)f.nUDCountRunways.Maximum;
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
                int max = (int)f.nUDCountRunways.Maximum;
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
                    chRunways[i].Series[1].BorderWidth = 3;
                    chRunways[i].Series[1].Color = Color.Blue;
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

            //Event
            foreach(Runway runway in exp.airport.runway)
            {
                runway.SuccessRequest += NewDoneRequest;
            }
            
            //Изображения самолетов
            if (planes == null)
            {
                int max = (int)f.nUDCountRunways.Maximum;
                planes = new PictureBox[max];
                for (int i = 0; i < max; i++)
                {
                    planes[i] = new PictureBox();
                    planes[i].BackColor = pRunway0.BackColor;
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

            foreach (PictureBox pb in airWaitingPlanes)
            {
                pb.Visible = false;
            }

            chAvgRunwayWork.Series[0].Points.Clear();
            chDelay.Series[0].Points.Clear();
            chDelay.Series[1].Points.Clear();
            chDelay.Series[0].Points.AddXY(0, 0);
            chDelay.Series[1].Points.AddXY(0, 0);

            chDelay.ChartAreas[0].AxisY.Maximum = 10;
            chCountRequestDone.Series[0].Points.Clear();
            chCountRequestDone.Series[1].Points.Clear();
            //заполнение таблицы расписания
            LVSchedue.Items.Clear();
            int j = 0;
            foreach (Request rec in exp.airport.schedue.requests)
            {
                LVSchedue.Items.Add("-");
                LVSchedue.Items[j].UseItemStyleForSubItems = false;
                LVSchedue.Items[j].SubItems.Add(rec.AirplaneName);
                LVSchedue.Items[j].SubItems.Add(statutes[0]);
                LVSchedue.Items[j].SubItems.Add(ToTimeFormat(rec.TimeSchedue));
                LVSchedue.Items[j].SubItems.Add(ToTimeFormat(0));
                if (rec.dir == Direction.Landing)
                    LVSchedue.Items[j].SubItems.Add("Посадка");
                else
                    LVSchedue.Items[j].SubItems.Add("Взлет");

                switch (rec.airType)
                {
                    case AirType.Cargo:
                        LVSchedue.Items[j].SubItems.Add("Грузовой");
                        break;
                    case AirType.Jet:
                        LVSchedue.Items[j].SubItems.Add("Бизнес-джет");
                        break;
                    case AirType.Passenger:
                        LVSchedue.Items[j].SubItems.Add("Пассажирский");
                        break;
                }
                LVSchedue.Items[j].SubItems.Add(rec.CompanyName);
                j++;
            }
            
            chartDelayIStart = 0;
            countDoneRequestsTakeOff = countDoneRequestsLanding = 0;
            bPause.Text = "Прервать моделирование";
            timer1.Enabled = true;
        }
        void PlaseRunway(Panel p, Chart ch, int number)
        {
            p.Size = runwaySize;
            p.Left = runwayLocation.X;
            p.Top = runwayLocation.Y + runwayIntervalPosition * number;
            p.BackColor = pRunway0.BackColor;

            ch.Size = new Size(220, 120);
            ch.Left = runwayLocation.X + runwaySize.Width + 10;
            ch.Top = 30 + runwayIntervalPosition * number;
        }

        void NextStepDraw()
        {
            //Текущее время
            tbCurrentTime.Text = ToTimeFormat( exp.CurrentTime);
            //длина очередей
            tbLandingQueueLength.Text = exp.airport.LandingQueue.Count.ToString();
            tbTakeOffQueueLength.Text = exp.airport.TakeoffQueue.Count.ToString();

            //расписание
            ShedueRefresh();

            //максимальная задержка
            int maxTakeoff = 0, maxLanding = 0;
            Airplane pl = null;
            if (exp.airport.LandingQueue.Count != 0)
            {
                pl = exp.airport.LandingQueue.Peek();
                maxLanding = Math.Max(0, pl.Timer);
            }
            if (exp.airport.TakeoffQueue.Count != 0)
            {
                pl = exp.airport.TakeoffQueue.Peek();
                maxTakeoff = Math.Max(0, pl.Timer);
            }

            tbDelay.Text = Math.Max(maxTakeoff, maxLanding).ToString();

            //график задержки 
            DrawChartDelay();

            //Самолёты на полосе
            DrawAirplaneOnRunway();
            //самолеты в воздушной очереди
            DrawAirplaneInAir();

            //Общее число заявок
            TotalDoneRequests();

            //средняя занятость полос
            chAvgRunwayWork.Series[0].Points.Clear();
            for (int i = 0; i < N; i++)
            {
                if (countDoneRequestsLanding + countDoneRequestsTakeOff == 0) break;
                chAvgRunwayWork.Series[0].Points.Add(100 * (chRunways[i].Series[0].Points.Last().YValues[0]
                    + chRunways[i].Series[1].Points.Last().YValues[0]) / (countDoneRequestsTakeOff + countDoneRequestsLanding));
            }
        }

        private void TotalDoneRequests()
        {
            int timestep;
            {
                int i = -exp.TimeStep;
                timestep = -exp.TimeStep;
                if (chCountRequestDone.Series[0].Points.Count > 0
                    && exp.CurrentTime - (int)chCountRequestDone.Series[0].Points.Last().XValue < exp.TimeStep)
                {
                    timestep = i = -(exp.CurrentTime - (int)chCountRequestDone.Series[0].Points.Last().XValue);
                }

                for (; i < 0 ; i++)
                {
                    chCountRequestDone.Series[0].Points.AddXY(exp.CurrentTime+1 + i, 0);
                    chCountRequestDone.Series[1].Points.AddXY(exp.CurrentTime+1 + i, 0);
                }
                //chCountRequestDone.Series[1].Points.Last().YValues[0]
                while (chCountRequestDone.Series[0].Points.Count > 61)
                {
                    chCountRequestDone.Series[0].Points.RemoveAt(0);
                    chCountRequestDone.Series[1].Points.RemoveAt(0);
                }
                
            }
            countDoneRequestsTakeOff = 0;
            countDoneRequestsLanding = 0;
            int countPointTakeOff = chCountRequestDone.Series[0].Points.Count;
            int countPointLanding = chCountRequestDone.Series[1].Points.Count;

            int tmpPointTakeOff ;
            int tmpPointLanding;
            double lastTakeOffValue;
            double lastLandingValue;
            for (int i = 0; i < N; i++)
            {
                tmpPointTakeOff = chRunways[i].Series[0].Points.Count-1;
                tmpPointLanding = chRunways[i].Series[1].Points.Count-1;
                for (int j =  0; j > timestep; j--)
                {
                    while(tmpPointTakeOff > 0 && chRunways[i].Series[0].Points[tmpPointTakeOff].XValue > exp.CurrentTime + j)
                    {
                        tmpPointTakeOff--;
                    }
                    //if (tmpPointTakeOff < 0) tmpPointTakeOff = 0;
                    lastTakeOffValue = chRunways[i].Series[0].Points[tmpPointTakeOff].YValues[0];
                    chCountRequestDone.Series[0].Points[countPointTakeOff-1+j].YValues[0] += lastTakeOffValue;
                }

                for (int j = 0; j > timestep; j--)
                {
                    while (tmpPointLanding > 0 && chRunways[i].Series[1].Points[tmpPointLanding].XValue > exp.CurrentTime + j)
                    {
                        tmpPointLanding--;
                    }
                    //if (tmpPointLanding < 0) tmpPointLanding = 0;
                    lastLandingValue = chRunways[i].Series[1].Points[tmpPointLanding].YValues[0];
                    chCountRequestDone.Series[1].Points[countPointLanding-1 + j].YValues[0] += lastLandingValue;
                }
                countDoneRequestsTakeOff += (int)chRunways[i].Series[0].Points.Last().YValues[0];
                countDoneRequestsLanding += (int)chRunways[i].Series[1].Points.Last().YValues[0];
            }
            chCountRequestDone.ChartAreas[0].AxisX.Minimum = Math.Max(0, exp.CurrentTime - 60);
            chCountRequestDone.ChartAreas[0].AxisX.Maximum = exp.CurrentTime;
            
            chCountRequestDone.ChartAreas[0].AxisY.Minimum = chCountRequestDone.Series[0].Points.First().YValues[0];
            chCountRequestDone.ChartAreas[0].RecalculateAxesScale();
            tbDoneRequest.Text = (countDoneRequestsTakeOff + countDoneRequestsLanding).ToString();
        }

        void DrawChartDelay()
        {            
            int k = 1;
            //когда надо сделать меньше шага
            if (exp.CurrentTime - (int)chDelay.Series[0].Points.Last().XValue < exp.TimeStep)
                k = exp.TimeStep - ( exp.CurrentTime - (int)chDelay.Series[0].Points.Last().XValue )+1;              
            for (; k <= exp.TimeStep; k++)
            {
                chDelay.Series[0].Points.AddXY(exp.CurrentTime - exp.TimeStep + k, 0);
                chDelay.Series[1].Points.AddXY(exp.CurrentTime - exp.TimeStep + k, 0);
            }
            while (chDelay.Series[1].Points.Count > 61)
            {
                chDelay.Series[1].Points.RemoveAt(0);
            }
            while (chDelay.Series[0].Points.Count > 61)
            {
                chDelay.Series[0].Points.RemoveAt(0);
            }
            
            int maxTakeoff = 0, maxLanding = 0;
            int delay, time, minTime;
            Series series;
            Request req;
            minTime = Math.Max(0, exp.CurrentTime - 60);
            for (int i = chartDelayIStart; i < exp.airport.schedue.requests.Count; i++)
            {
                req = exp.airport.schedue.requests[i];
                if (req.TimeReal != -1)
                {
                    delay = req.TimeReal - req.TimeEvent;
                    
                    if (delay == 0 || req.TimeReal < minTime)
                    {
                        chartDelayIStart++;/*обязательно только такая форма, а не i+1,
                        так как на момент выполнения расписание не отсортировано 
                        (мб появился самолёт, который только распределили на полосу*/
                        continue;
                    }
                }
                else
                {
                    delay = exp.CurrentTime - req.TimeEvent;                    
                }
                
                time = req.TimeEvent;
                //считанное время должно помещаться в границы нашего графика
                if (time >= exp.CurrentTime /*|| delay < 0*/)
                    break;

                if (req.dir == Direction.Takeoff)
                {
                    series = chDelay.Series[0];
                    maxTakeoff = Math.Max(maxTakeoff, delay);
                }
                else
                {
                    series = chDelay.Series[1];
                    maxLanding = Math.Max(maxLanding, delay);
                }
                
                 for (int j = Math.Max(1, minTime- time); j <= delay && time + j - minTime < series.Points.Count; j++)
                 {
                     series.Points[time + j  - minTime].YValues[0] = 
                         Math.Max(j, series.Points[ time + j - minTime].YValues[0]);
                 }
            }
            
            chDelay.ChartAreas[0].AxisX.Minimum = Math.Max(0, exp.CurrentTime - 60);
            chDelay.ChartAreas[0].AxisX.Maximum = exp.CurrentTime;
            chDelay.ChartAreas[0].AxisY.Maximum = Math.Max(chDelay.ChartAreas[0].AxisY.Maximum, Math.Max(maxTakeoff, maxLanding));
            chDelay.ChartAreas[0].RecalculateAxesScale();
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
                if (pl != null)
                {
                    planes[i].Visible = true;
                    switch (pl.Type)
                    {
                        case AirType.Cargo:
                            planes[i].Image = global::Airoport.Properties.Resources.Грузовой;
                            break;
                        case AirType.Jet:
                            planes[i].Image = global::Airoport.Properties.Resources.Бизнес_джет;
                            break;
                        case AirType.Passenger:
                            planes[i].Image = global::Airoport.Properties.Resources.Пассажирский;
                            break;
                    }

                    //Устанавливаем изображение самолета в нужную позицию, поворачиваем при необходимости
                    switch (pl.state)
                    {
                        case State.RunwayIn:
                            planes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            planes[i].Size = planes[i].Image.Size;
                            break;
                        case State.RunwayOut:
                            planes[i].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            planes[i].Size = planes[i].Image.Size;
                            break;
                        case State.TakingOff:                            
                            planes[i].Size = planes[i].Image.Size;
                            break;
                        case State.Landing:
                            planes[i].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            planes[i].Size = planes[i].Image.Size;
                            break;
                    }

                    hpl = planes[i].Size.Height;
                    wpl = planes[i].Size.Width;
                    //середина текущей посадочной полосы (высота)
                    H = pRunways[i].Top + pRunways[i].Size.Height / 2;
                    //двигаем самолёт по полосе, согласно его состоянию
                    switch (pl.state)
                    {
                        case State.RunwayIn:
                            planes[i].Top = H - hpl/2 - (H0 * (pl.Timer)) / Airplane.TimeMoveOnRunway;
                            planes[i].Left = runwayDown - wpl / 2;
                            break;
                        case State.RunwayOut:
                            planes[i].Top = -hpl/2 - H0 + H + (H0 * (pl.Timer)) / Airplane.TimeMoveOnRunway;
                            planes[i].Left = runwayUp - wpl / 2;
                            break;
                        case State.TakingOff:
                            planes[i].Top = H - hpl / 2;
                            planes[i].Left = pRunways[i].Left - wpl 
                                        + pRunways[i].Size.Width - (pRunways[i].Size.Width * pl.Timer) / pl.MoveTime;
                            break;
                        case State.Landing:
                            planes[i].Top = H - hpl / 2;
                            planes[i].Left = pRunways[i].Left - wpl + (pRunways[i].Size.Width * pl.Timer) / pl.MoveTime;
                            break;
                    }                    
                    planes[i].Refresh();                    
                }
                else
                {
                    //заявка обработана
                    planes[i].Visible = false;
                }
            }
        }

        void DrawAirplaneInAir()
        {
            int length = exp.airport.LandingQueue.Count();
            while (airWaitingPlanes.Count() < length)
            {
                PictureBox pb = new PictureBox
                {
                    BackColor = Color.FromArgb(0,0,0,0),
                    Parent = pAirQueue,
                    TabIndex = 0,
                    TabStop = false,
                    Visible = false
                };
                pb.SendToBack();
               
                airWaitingPlanes.Add(pb);
            }
           
            Airplane[] pl = exp.airport.LandingQueue.ToArray();
            int X = pAirQueue.Width / 2;
            int Y = pAirQueue.Height / 2;
            int R = Math.Min(pAirQueue.Height, pAirQueue.Width) *2/5;
            double tetta = 0;
            for (int i = 0; i < length; i++)
            {
                airWaitingPlanes[i].Visible = true;
                switch (pl[i].Type)
                {
                    case AirType.Cargo:
                        airWaitingPlanes[i].Image = global::Airoport.Properties.Resources.Грузовой;
                        break;
                    case AirType.Jet:
                        airWaitingPlanes[i].Image = global::Airoport.Properties.Resources.Бизнес_джет;
                        break;
                    case AirType.Passenger:
                        airWaitingPlanes[i].Image = global::Airoport.Properties.Resources.Пассажирский;
                        break;
                }
                tetta = Math.PI * (pl[i].Timer / 12.0);
                while(tetta > 2*Math.PI)
                {
                    tetta -= 2 * Math.PI;
                }
                if (tetta > Math.PI * 0.25 && tetta <= Math.PI * 0.75)
                {
                    airWaitingPlanes[i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else if (tetta > Math.PI * 0.75 && tetta <= Math.PI * 1.25)
                {
                    airWaitingPlanes[i].Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                else if (tetta > Math.PI * 1.25 && tetta <= Math.PI * 1.75)
                {
                    airWaitingPlanes[i].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }

                airWaitingPlanes[i].Size = airWaitingPlanes[i].Image.Size;
                airWaitingPlanes[i].Top = Y - airWaitingPlanes[i].Height/2 - (int)(R  * Math.Cos(tetta));
                airWaitingPlanes[i].Left = X - airWaitingPlanes[i].Width / 2 + (int)(R  * Math.Sin(tetta));
            }
            for (int i = length; i < airWaitingPlanes.Count(); i++)
            {
                airWaitingPlanes[i].Visible = false;
            }
        }
        
        void NewDoneRequest(int nRunway, Direction dir)
        {
            //Уменьшение количества точек
            //while (chRunways[nRunway].Series[0].Points.Count > 60)
            while (chRunways[nRunway].Series[0].Points[0].XValue < exp.CurrentTime - 60)
            {
                if (chRunways[nRunway].Series[0].Points.Count < 2 
                    || exp.CurrentTime - 60 < chRunways[nRunway].Series[0].Points[1].XValue)
                {
                    chRunways[nRunway].Series[0].Points[0].XValue = exp.CurrentTime - 60;
                }
                else
                {
                    chRunways[nRunway].Series[0].Points.RemoveAt(0);
                }
            }
            //while (chRunways[nRunway].Series[1].Points.Count > 60)
            while (chRunways[nRunway].Series[1].Points[0].XValue < exp.CurrentTime - 60)
            {
                if (chRunways[nRunway].Series[1].Points.Count < 2 
                    || exp.CurrentTime - 60 < chRunways[nRunway].Series[1].Points[1].XValue)
                {
                    chRunways[nRunway].Series[1].Points[0].XValue = exp.CurrentTime - 60;
                }
                else
                {
                    chRunways[nRunway].Series[1].Points.RemoveAt(0);
                }
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
            chRunways[nRunway].ChartAreas[0].AxisY.Minimum = Math.Min(chRunways[nRunway].Series[0].Points[0].YValues[0],
                chRunways[nRunway].Series[1].Points[0].YValues[0]);
            chRunways[nRunway].ChartAreas[0].AxisY.Maximum = Math.Max(chRunways[nRunway].Series[0].Points.Last().YValues[0],
                chRunways[nRunway].Series[1].Points.Last().YValues[0]);
        }

        void ShedueRefresh()
        {
            //заполнение таблицы расписания
            //LVSchedue.Items.Clear();
            int j = -1;
            foreach (Request rec in exp.airport.schedue.requests)
            {
                j++;
                if (LVSchedue.Items[j].SubItems[2].Text.Equals(statutes[5]))
                {
                    continue;
                }

                if (!LVSchedue.Items[j].SubItems[1].Text.Equals(rec.AirplaneName))
                {
                    LVSchedue.Items[j].SubItems[1].Text = rec.AirplaneName;
                    if (rec.dir == Direction.Landing)
                        LVSchedue.Items[j].SubItems[5].Text = "Посадка";
                    else
                        LVSchedue.Items[j].SubItems[5].Text = "Взлет";

                    switch (rec.airType)
                    {
                        case AirType.Cargo:
                            LVSchedue.Items[j].SubItems[6].Text = "Грузовой";
                            break;
                        case AirType.Jet:
                            LVSchedue.Items[j].SubItems[6].Text = "Бизнес-джет";
                            break;
                        case AirType.Passenger:
                            LVSchedue.Items[j].SubItems[6].Text = "Пассажирский";
                            break;
                    }
                    LVSchedue.Items[j].SubItems[7].Text = rec.CompanyName;
                }
                
                if (rec.airplane != null)
                {
                    if (rec.airplane.Runway != -1)
                    {
                        LVSchedue.Items[j].SubItems[0].Text = (rec.airplane.Runway+1).ToString();
                    }
                    
                    switch (rec.airplane.state)
                    {
                        case State.AirWaiting:
                        case State.Waiting:
                            LVSchedue.Items[j].SubItems[2].Text = statutes[1];
                            break;
                        case State.RunwayIn:
                            LVSchedue.Items[j].SubItems[2].Text = statutes[2];
                            break;
                        case State.TakingOff:
                            LVSchedue.Items[j].SubItems[2].Text = statutes[3];
                            break;
                        case State.Landing:
                            LVSchedue.Items[j].SubItems[2].Text = statutes[4];
                            break;
                        case State.Done:
                            LVSchedue.Items[j].SubItems[3].ForeColor = Color.Black;
                            LVSchedue.Items[j].SubItems[4].ForeColor = Color.Black;
                            LVSchedue.Items[j].SubItems[2].Text = statutes[5];
                             break;
                    }
                }

                if (rec.TimeReal != -1)
                {
                    if (LVSchedue.Items[j].SubItems[3].Text.Equals(ToTimeFormat(rec.TimeReal))) continue;
                    LVSchedue.Items[j].SubItems[3].ForeColor = Color.Black;
                    LVSchedue.Items[j].SubItems[4].ForeColor = Color.Black; 
                    LVSchedue.Items[j].SubItems[3].Text = ToTimeFormat(rec.TimeReal);
                    LVSchedue.Items[j].SubItems[4].Text = ToTimeFormat(rec.TimeReal - Math.Min(rec.TimeEvent, rec.TimeSchedue));
                }
                else if (exp.CurrentTime >= rec.TimeEvent)
                {
                    LVSchedue.Items[j].SubItems[3].ForeColor = Color.Red;
                    LVSchedue.Items[j].SubItems[4].ForeColor = Color.Red;
                    LVSchedue.Items[j].SubItems[3].Text = ToTimeFormat(rec.TimeEvent);
                    LVSchedue.Items[j].SubItems[4].Text = ToTimeFormat(exp.CurrentTime - Math.Min(rec.TimeEvent, rec.TimeSchedue));
                }
                else if (exp.CurrentTime > rec.TimeSchedue)
                {
                    LVSchedue.Items[j].SubItems[3].ForeColor = Color.Red;
                    LVSchedue.Items[j].SubItems[4].ForeColor = Color.Red;
                    LVSchedue.Items[j].SubItems[3].Text = ToTimeFormat(rec.TimeSchedue);
                    LVSchedue.Items[j].SubItems[4].Text = ToTimeFormat(exp.CurrentTime - rec.TimeSchedue);
                }
                else
                {
                    LVSchedue.Items[j].SubItems[3].Text = ToTimeFormat(rec.TimeSchedue);
                    LVSchedue.Items[j].SubItems[3].ForeColor = Color.Black;
                    LVSchedue.Items[j].SubItems[4].ForeColor = Color.Black;
                    LVSchedue.Items[j].SubItems[4].Text = (ToTimeFormat(0));
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
            res += ((time / 60)%24).ToString() + ":";
            if ((time % 60) < 10)
            {
                res += "0";
            }
            res += (time % 60).ToString();
            return res;
        }

    }
}
