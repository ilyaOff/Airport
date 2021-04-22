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
        public string Name {  get; private set; }
        public string CompanyName { get; private set; };

        public AirType Type { get; private set; };
        public State state { get; private set; };

        Runway tmpRunway = null;
        Request SummonerRequest;
        Airport airport;

        int TimeTakeOff, TimeLanding, CurrentTime;
        public Airplane(string name, string CompanyName, AirType type, 
                        Direction dir,  Request request, Airport airport)
        {
            this.Name = name;
            this.CompanyName = CompanyName;
            this.Type = type;
            this.airport = airport;

            SummonerRequest = request;
        
            
            if (dir == Direction.Landing)
            {
                this.state = State.AirWaiting;               
            }
            else //if (dir == Direction.Takeoff)
            {
                this.state = State.Waiting;               
            }
            airport.NewAirplane(this);

            switch (type)
            {
                case AirType.Cargo: TimeTakeOff = TimeLanding = 5; break;
                case AirType.Jet: TimeTakeOff = TimeLanding = 2; break;
                case AirType.Passenger: TimeTakeOff = TimeLanding = 4; break;
            }
            CurrentTime = 0;
        }
                
        public void SetRunway(Runway runway)//полосы
        {
            tmpRunway = runway;
        }
        public void GetOffRunway()
        {
            tmpRunway.Clear();
            tmpRunway = null;
        }
        public void Tick()
        { 
        
        }
    }
}
