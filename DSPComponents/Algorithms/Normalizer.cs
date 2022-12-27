using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Normalizer : Algorithm
    {
        public Signal InputSignal { get; set; }
        public float InputMinRange { get; set; }
        public float InputMaxRange { get; set; }
        public Signal OutputNormalizedSignal { get; set; }

        public override void Run()
        {
            float max = InputSignal.Samples.Max();
            float min = InputSignal.Samples.Min();

            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                InputSignal.Samples[i] =
                    (((InputMaxRange - InputMinRange)* (InputSignal.Samples[i] - min))/ (max - min)) + InputMinRange ;
            }

            OutputNormalizedSignal = InputSignal;
        }
    }
}
