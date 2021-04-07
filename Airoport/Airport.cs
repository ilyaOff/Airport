using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{    
    class Airport
    {
        int TimeInterval;      
        bool ModSepRunway;

        Runway[] runway;
        Schedue schedue;

        Queue<Airplane> TakeoffQueue;
        Queue<Airplane> LandingQueue;

        Random rnd;//А нужен ли?
        public void Tick()
        { 
        }
    }
}
