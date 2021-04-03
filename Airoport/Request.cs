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


    }
}
