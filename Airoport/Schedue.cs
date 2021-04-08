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

        //для генерации числа из нормального распределения и для значения мирового времени
        Experiment experiment;

        List<Request> requests;

        public Schedue(string fileName, Experiment experiment, int StartTime)
        {
            this.experiment = experiment;
            requests = new List<Request>();
            //StartTime - для создания списка 
            //experiment.GenerateNormalDistribution();
        }
        public void Tick()
        {
            //requests[i].Tick(experiment.CurrentTime)
        }
    }
}
