using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class SinCos: Algorithm
    {
        public string type { get; set; }
        public float A { get; set; }
        public float PhaseShift { get; set; }
        public float AnalogFrequency { get; set; }
        public float SamplingFrequency { get; set; }
        public List<float> samples { get; set; }
        public override void Run()
        {
            samples = new List<float>();
            float discrete_Freq = AnalogFrequency / SamplingFrequency;
            int y = samples.Count;
            float val;

            if (type == "sin")
            {
                
                for (int i = 0; i < 720; i++)
                {
                    val =  (float)(A * Math.Sin( (2 * Math.PI  * discrete_Freq)*i + PhaseShift));
                    samples.Add((float)System.Math.Round(val, 6));
                    //Console.WriteLine(val);
                }
            }

            else
            {
                //samples = new List<float>();
                for (int i = 0; i < 500; i++)
                {
                    val = (float)(A * Math.Cos((2 * Math.PI * discrete_Freq) * i + PhaseShift));
                    samples.Add((float)System.Math.Round(val, 6));
                    //Console.WriteLine(val);
                }
            }
        }
    }
}
