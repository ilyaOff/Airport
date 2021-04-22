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
        public string AirplaneName { get; private set; }
        public string CompanyName { get; private set; }
        public AirType airType { get; private set; }
        public Direction dir { get; private set; }
        public int TimeSchedue { get; private set; }       
        public int TimeReal { get; private set; } = -1;
        int TimeEvent;

        Airplane airplane = null;
       
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

        public void ServiceStarted(int Time)
        {
            this.TimeReal = this.TimeEvent + Time;
        }
        public void Tick(int WorldTime, Airport airport)
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
