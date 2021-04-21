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
        Schedue schedue;

        Queue<Airplane> TakeoffQueue;
        Queue<Airplane> LandingQueue;

       

        public Airport( bool ModSepRunway, int CountRunway, int CountLandingRunway,
                        int TimeInterval, int DelayMin, int DelayMax,
                        string fileName, Random rnd, int StartTime)
        {
            this.ModSepRunway = ModSepRunway;
            this.CountRunway = CountRunway;
            this.CountLandingRunway = CountLandingRunway;

            schedue = new Schedue(fileName, rnd, StartTime);

            runway = new Runway[CountRunway];
            for (int i = 0; i < CountRunway; i++)
            {
                //при разделении полос первые - только на посадку,
                //вторые - только на взлёт
                runway[i] = new Runway(!ModSepRunway || i >= CountLandingRunway,
                    !ModSepRunway || i < CountLandingRunway, TimeInterval);
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
            schedue.Tick();
            for (int i = 0; i < CountRunway; i++)
            {
                runway[i].Tick();
            }
            //TakeoffQueue[i].Tick()
            //LandingQueue[i].Tick()

            
        }
    }
}
