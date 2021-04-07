using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{
    enum Direction { Landing, Takeoff}
    class Request
    {
        int TimeSchedue, TimeEvent, TimeReal;
        string AirplaneName;
        string CompanyName;
        AirType airType;
        Direction dir;

        Airplane airplane;

        public Request(int SchedueTime, string AirplaneName, string CompanyName,
                       Direction dir, AirType airType, int EventTime)
        {
            this.TimeSchedue = SchedueTime;
            this.TimeEvent = EventTime;
            this.TimeReal = -1;

            this.CompanyName = CompanyName;
            this.AirplaneName = AirplaneName;            
            this.airType = airType;
            this.dir = dir;
        }
        public void Tick()
        { 
        
        }
    }
}
