using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{
    enum Direction { Landing, Takeoff}//посадка, взлёт
    class Request
    {
        int TimeSchedue, TimeEvent, TimeReal = -1;
        string AirplaneName;
        string CompanyName;
        AirType airType;
        Direction dir;

        Airplane airplane = null;
        Airport airport;
        public Request(int SchedueTime, string AirplaneName, string CompanyName,
                       Direction dir, AirType airType, int EventTime)
        {
            this.TimeSchedue = SchedueTime;
            this.TimeEvent = EventTime;            

            this.CompanyName = CompanyName;
            this.AirplaneName = AirplaneName;            
            this.airType = airType;
            this.dir = dir;            
        }

        public void ServiceDone(int RealTime)
        {
            this.TimeReal = RealTime;            
        }
        public void Tick(int WorldTime)
        {
            if (airplane == null)
            {
                if (TimeEvent == WorldTime)
                {
                    airplane = new Airplane(AirplaneName, CompanyName, airType, dir, this, airport);
                }
            }
           /* будет делать аэропорт
            * else 
            {
                airplane.Tick();
            }
            */
        }
    }
}
