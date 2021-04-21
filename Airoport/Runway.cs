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

        
        int TimeInterval, CurrentTimeInterval = 0;
        Airplane tmpAirplane = null;

        public Runway(bool forTakeoff, bool forLanding, int TimeInterval)
        {
            this.forLanding = forLanding;
            this.forTakeoff = forTakeoff;
            
            this.TimeInterval = TimeInterval;
        }

        public void GetAirplane(Airplane airplane)//от аэропорта
        {
            tmpAirplane = airplane;
        }
        
        public void Clear()//самолёт освобождает полосу
        {
            tmpAirplane = null;
            CurrentTimeInterval = TimeInterval;
        }

        public bool Ready()//полоса готова к приему новых самолётов
        {
            return CurrentTimeInterval == 0 && tmpAirplane == null; 
        }
        public void Tick()
        {
            /* аэропорт всегда вызывает это
             *if (tmpAirplane != null)
             {
                 tmpAirplane.Tick();
             }
             */
            if (CurrentTimeInterval != 0)
                CurrentTimeInterval--;
        }
    }
}
