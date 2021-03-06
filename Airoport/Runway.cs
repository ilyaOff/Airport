using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{
    class Runway
    {
        public bool forTakeoff { get; private set; } = true;
        public bool forLanding { get; private set; } = true;

        
        int TimeInterval, CurrentTimeInterval = 0;//минимальное время между взлетами/посадками 
        public Airplane tmpAirplane { get; private set; } = null;
        public delegate void newDoneRequest(int numberRunway, Direction dir);
        public event newDoneRequest SuccessRequest;
        public Runway(bool forTakeoff, bool forLanding, int TimeInterval)
        {
            this.forLanding = forLanding;
            this.forTakeoff = forTakeoff;
            
            this.TimeInterval = TimeInterval;
        }

        public void SetAirplane(Airplane airplane, int i)//от аэропорта
        {
            if (tmpAirplane != null)
            {
                System.Windows.Forms.MessageBox.Show("!!!!!", "Error");
            }
            tmpAirplane = airplane;
            tmpAirplane.SetRunway(i);
        }
        
        public void Clear()//самолёт освобождает полосу
        {
            if (SuccessRequest != null) 
                SuccessRequest(tmpAirplane.Runway, tmpAirplane.SummonerRequest.dir);
            tmpAirplane = null;
            CurrentTimeInterval = TimeInterval;
        }

        public bool Ready()//полоса готова к приему новых самолётов
        {
            return CurrentTimeInterval == 0 && tmpAirplane == null; 
        }
        public void Tick()
        {
            if (CurrentTimeInterval != 0)
                CurrentTimeInterval--;

            if (tmpAirplane != null)
            {
                 tmpAirplane.Tick();
                if (tmpAirplane.state == State.Done) Clear();
            }
             
            
        }
    }
}
