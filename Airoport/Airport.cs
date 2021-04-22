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

        Runway[] runway;
        int CountRunway;
        int CountLandingRunway;
        public Schedue schedue { get; private set; }

        Queue<Airplane> TakeoffQueue;
        Queue<Airplane> LandingQueue;       

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
                    if (runway[i].Ready())
                    {
                        runway[i].SetAirplane(LandingQueue.Dequeue());
                    }
                }
                for (int i = CountLandingRunway; i < CountRunway; i++)
                {
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
