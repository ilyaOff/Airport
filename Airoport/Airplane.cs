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
        AirType type;
        State state;
    }
}
