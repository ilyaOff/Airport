using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{
    class Experiment
    {       
        int TimeStep,  CurrentTime = 0;
        //int StartTime;
       // int DelayMin, DelayMax;

        Airport airport;
        //int TimeInterval;
        //int CountRunway;
       // bool ModSepRunway;

        Random rnd;
        public Experiment(int TimeStep,int StartTime,
            int CountRunway, bool ModSepRunway,
            int DelayMin,int DelayMax, int TimeInterval,
            string fileName)
        {
            this.TimeStep = TimeStep;
            /*              
            this.StartTime = StartTime;         
            this.DelayMax = DelayMax;
            this.DelayMin = DelayMin;
            this.TimeInterval = TimeInterval;
            this.CountRunway = CountRunway;
            this.ModSepRunway = ModSepRunway;
            */

            airport = new Airport(ModSepRunway, CountRunway, TimeInterval, DelayMin, DelayMax,
                fileName, this, CurrentTime);

            rnd = new Random(0);//для отладки
        }
        public double GenerateNormalDistribution(double a, double sigm)
        {
            double res = 0;
            return res;
        }
        public void Tick()
        { 
        }
    }
}
