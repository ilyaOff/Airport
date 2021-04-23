using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{    
    class Airport
    {
        bool ModSepRunway;

        public Runway[] runway { get; private set; }
        int CountRunway;
        int CountLandingRunway;
        public Schedue schedue { get; private set; }

        public Queue<Airplane> TakeoffQueue { get; private set; }
        public Queue<Airplane> LandingQueue { get; private set; }       

        public Airport( bool ModSepRunway, int CountRunway, int CountLandingRunway,
                        int TimeInterval, int DelayMin, int DelayMax,
                        string fileName, Random rnd, int StartTime)
        {
            this.ModSepRunway = ModSepRunway;
            this.CountRunway = CountRunway;
            this.CountLandingRunway = CountLandingRunway;

            schedue = new Schedue(fileName, rnd, StartTime, DelayMin, DelayMax);

            runway = new Runway[CountRunway];
            for (int i = 0; i < CountRunway; i++)
            {
                //при разделении полос первые - только на посадку,
                //вторые - только на взлёт
                runway[i] = new Runway(!ModSepRunway || i >= CountLandingRunway,
                    !ModSepRunway || i < CountLandingRunway, TimeInterval);
            }
            TakeoffQueue = new Queue<Airplane>();
            LandingQueue = new Queue<Airplane>();
        }
       
        public void NewAirplane(Airplane pl)
        {
            if (pl.state == State.AirWaiting)
            {
                LandingQueue.Enqueue(pl);
            }
            else if (pl.state == State.Waiting)
            {
                TakeoffQueue.Enqueue(pl);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Состояние самолета " + pl.Name + " " + pl.state.ToString(), "Error");
            }
        }

        void DistributionRunways() // распределить полосы
        {
            if (ModSepRunway)
            {
                
                for (int i = 0; i < CountLandingRunway; i++)
                {
                    if (LandingQueue.Count == 0) break;
                    if (runway[i].Ready())
                    {
                        runway[i].SetAirplane(LandingQueue.Dequeue());
                    }
                }
                for (int i = CountLandingRunway; i < CountRunway; i++)
                {
                    if (TakeoffQueue.Count == 0) break;
                    if (runway[i].Ready())
                    {
                        runway[i].SetAirplane(TakeoffQueue.Dequeue());
                    }
                }
            }
            else
            { 
            
            }

        }
        public void Tick(int WorldTime)
        {            
            schedue.Tick(WorldTime, this);
            for (int i = 0; i < CountRunway; i++)
            {
                runway[i].Tick();
            }
            DistributionRunways();
            foreach (Airplane pl in TakeoffQueue)
            {
                pl.Tick();
            }
            foreach (Airplane pl in LandingQueue)
            {
                pl.Tick();
            }
        }
    }
}
