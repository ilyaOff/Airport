using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{    
    class Airport
    {
       // int TimeInterval;      
        bool ModSepRunway;

        Runway[] runway;
        int CountRunway;
        Schedue schedue;

        Queue<Airplane> TakeoffQueue;
        Queue<Airplane> LandingQueue;

        Experiment experiment;
        //Random rnd;//А нужен ли?

        public Airport( bool ModSepRunway, int CountRunway, 
                        int TimeInterval, int DelayMin, int DelayMax,
                        string fileName, Experiment experiment, int StartTime)
        {
            //this.TimeInterval = TimeInterval;
            this.ModSepRunway = ModSepRunway;
            this.CountRunway = CountRunway;
            this.experiment = experiment;

            schedue = new Schedue(fileName, experiment, StartTime);

            runway = new Runway[CountRunway];
            for (int i = 0; i < CountRunway; i++)
            {
                //при разделении полос первая половина только на посадку,
                //вторая - только на взлёт
                runway[i] = new Runway(!ModSepRunway || i >= CountRunway / 2,
                    !ModSepRunway || i < CountRunway / 2, DelayMin, DelayMax, TimeInterval);
            }

        }
        public void NewFlyAirplane(Airplane pl)
        {
            LandingQueue.Enqueue(pl);
        }
        public void NewAirplane(Airplane pl)
        {
            TakeoffQueue.Enqueue(pl);
        }

        void DistributionRunways() // распределить полосы
        {
        }
        public void Tick()
        {
            //DistributionRunways()
            for (int i = 0; i < CountRunway; i++)
            {
                runway[i].Tick();
            }
            //TakeoffQueue[i].Tick()
            //LandingQueue[i].Tick()

            
        }
    }
}
