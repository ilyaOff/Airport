using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport
{
    class Schedue
    {
        //Random rnd;
        Experiment experiment;// для генерации числа из нормального распределения
        List<Request> requests;

        public Schedue(string fileName, Experiment experiment, int StartTime)
        {
            this.experiment = experiment;
            requests = new List<Request>();
            //StartTime - для создания списка 
            //experiment.GenerateNormalDistribution();
        }
        public void Tick(int WorldTime)
        { 
            //requests[i].Tick(WorldTime)
        }
    }
}
