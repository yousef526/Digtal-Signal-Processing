using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class DC_Component: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            float val;
            double avg = 0;
            double sum = 0;

            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                sum += InputSignal.Samples[i];
            }

            avg = sum / InputSignal.Samples.Count;

            List<float> list = new List<float>();
            OutputSignal = new Signal(list, false);

            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                val = (float)((InputSignal.Samples[i] - avg ));
                
                OutputSignal.Samples.Add((float)System.Math.Round(val, 13));
            }
        }
    }
}
