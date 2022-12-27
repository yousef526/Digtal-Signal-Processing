using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class DCT: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            List<float> list = new List<float>();
            double num_1_const = Math.Sqrt(1.0 / InputSignal.Samples.Count);
            double num_2_const = Math.Sqrt(2.0 / InputSignal.Samples.Count);
            //Console.WriteLine(num_2_const+" "+num_1_const);

            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                float sum = 0;
                for (int j = 0; j < InputSignal.Samples.Count; j++)
                {
                    double num = ((2 * j + 1) * i * Math.PI)/(2* InputSignal.Samples.Count);
                    
                    sum += InputSignal.Samples[j] * (float)Math.Cos(num);
                }
                if (i == 0) 
                {
                    list.Add(sum* (float)num_1_const);
                }
                else
                {
                    list.Add(sum* (float)num_2_const);
                }

            }

            OutputSignal = new Signal(list, false);
            


        }
    }
}
