using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{
    class Experiment
    {       
        int TimeStep, StartTime, CurrentTime;

        int DelayMin, DelayMax;

        Airport airport;
        int TimeInterval;
        int CountRunway;
        bool ModSepRunway;

        Random rnd;
        public Experiment()
        { 
        }
        public void Tick()
        { 
        }
    }
}
