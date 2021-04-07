using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{
    public enum AirType { Cargo, Passenger, Jet }
    public enum State { Waiting, RunwayIn, TakingOff,
                        AirWaiting, SittingDown, RunwayOut, Done}
    class Airplane
    {
        string Name;

        AirType type;
        State state;

        Runway tmpRunway;
        Request SummonerRequest;

        int TimeTakeOff, TimeLanding, CurrentTime;
        public Airplane(string name, AirType type, State state, Runway runway, Request request)
        {
            this.Name = name;
            this.type = type;
            this.state = state;
            tmpRunway = runway;
            SummonerRequest = request;

            switch (type)
            {
                case AirType.Cargo: TimeTakeOff = TimeLanding = 5; break;
                case AirType.Jet: TimeTakeOff = TimeLanding = 2; break;
                case AirType.Passenger: TimeTakeOff = TimeLanding = 4; break;
            }
            CurrentTime = 0;
        }

        public void Tick()
        { 
        
        }
    }
}
