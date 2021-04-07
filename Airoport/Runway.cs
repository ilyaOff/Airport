using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{
    class Runway
    {
        bool forTakeoff = true;
        bool forLanding = true;

        int DelayMin, DelayMax;//отклонение от расписания
        Airplane tmpAirplane;
        public void Tick()
        { 
        
        }
    }
}
