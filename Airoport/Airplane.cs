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
        public string CompanyName { get; private set; }

        public AirType Type { get; private set; }
        public State state { get; private set; }

        Runway tmpRunway = null;
        public Request SummonerRequest { get; private set; }
        Airport airport;

        public static int TimeMoveOnRunway = 5;
        public int MoveTime { get; private set; }
        public int CurrentTime { get; private set; }
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
                case AirType.Cargo: MoveTime = 5; break;
                case AirType.Jet: MoveTime = 2; break;
                case AirType.Passenger: MoveTime = 4; break;
                default:break;
            }
            CurrentTime = 0;
        }

        public void SetRunway(Runway runway)//полосы
        {
            if (tmpRunway == null)
            {
                tmpRunway = runway;
                SummonerRequest.ServiceStarted(CurrentTime);
                if(state == State.AirWaiting)
                {
                    state = State.SittingDown;
                    CurrentTime = this.MoveTime;
                }
                else//state == State.Waiting
                {
                    state = State.RunwayIn;
                    CurrentTime = TimeMoveOnRunway;
                }
            }
            else
                System.Windows.Forms.MessageBox.Show("У самолёта " + this.Name + " уже есть полоса!", "Error");
        }
        public void GetOffRunway()
        {
            tmpRunway.Clear();
            tmpRunway = null;
            //state = State.Done;
           // SummonerRequest.ServiceDone();
        }
        public void Tick()
        {
            if (state == State.AirWaiting || state == State.Waiting)
            {
                CurrentTime++;//время ожидания в очереди
            }
            else
            {   
                if (CurrentTime == 0)//действие закончилось
                {
                    switch (state)
                    {
                        //case State.Done: case State.AirWaiting: case State.Waiting: return;
                        case State.RunwayIn:
                            state = State.TakingOff;
                            CurrentTime = MoveTime;
                            break;

                        case State.TakingOff:
                            state = State.Done;
                            this.GetOffRunway();
                            break;

                        case State.SittingDown:
                            state = State.RunwayOut;
                            CurrentTime = TimeMoveOnRunway;
                            break;

                        case State.RunwayOut:
                            state = State.Done;
                            this.GetOffRunway();
                            break;
                        default: return;
                    }
                }                
                CurrentTime--;//теперь осталось ждать столько минут                
            }            
        }
    }
}
