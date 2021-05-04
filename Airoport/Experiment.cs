using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{
    class Experiment
    {
        
        int StopTime = 24 * 60;//конец моделирования
        public int TimeStep { get; set; } = 5;
        public int CurrentTime { get; private set; } = 0;//чтобы обработать первую заявку
        //int StartTime;
       // int DelayMin, DelayMax;

        public Airport airport { get; private set; }
        //int TimeInterval;
        //int CountRunway;
       // bool ModSepRunway;

        Random rnd;
        public Experiment(int TimeStep,int StartTime,
            bool ModSepRunway, int CountRunway,  int CountLandingRunway,
            int DelayMin,int DelayMax, int TimeInterval,
            string fileName)
        {
            this.TimeStep = TimeStep;
            rnd = new Random();
            //длительность прохождения по общей полосе зависит от её длины, => от количества полос
            Airplane.TimeMoveOnRunway = (CountRunway * 5) / 2;

            airport = new Airport(ModSepRunway, CountRunway, CountLandingRunway,
                                TimeInterval, DelayMin, DelayMax,
                                fileName, rnd, CurrentTime);
        }
       
        public bool Tick()
        {            
            if (CurrentTime >= StopTime )
               // || (airport.schedue.requests.Last().TimeReal != -1
               // && CurrentTime >= airport.schedue.requests.Last().TimeReal + Airplane.TimeMoveOnRunway*2
               // && airport.TakeoffQueue.Count == 0 && airport.LandingQueue.Count == 0))            
            {
                return true;
            }
            else
            {              
                airport.Tick(CurrentTime);
                CurrentTime++;
                return false;
            }
            
        }

        public bool NextStep()
        {
            for (int i = 0; i < TimeStep; i++)
            {
                if (Tick()) return true;
            }
            return false;
        }
        public bool ToEnd()
        {
            while (CurrentTime < 24 * 60)
            {
                if (Tick()) break;
            }
            return true;
        }
    }
}
