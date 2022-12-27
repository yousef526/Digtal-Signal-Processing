using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;


namespace DSPAlgorithms.Algorithms
{
    public class AccumulationSum : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            List<float> list = new List<float>();
            OutputSignal = new Signal(list, false);

            OutputSignal.Samples.Add(InputSignal.Samples[0]);

            for (int i = 1; i < InputSignal.Samples.Count; i++)
            {
                float sum = 0;
                for (int j = i; j >= 0; j--)
                {
                    sum += InputSignal.Samples[j];
                }
                OutputSignal.Samples.Add(sum);
            }
            
        }
    }
}
