using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }

        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            List<float> list = new List<float>();
            List<int> indcies_list = new List<int>();
            OutputConvolvedSignal = new Signal(list,indcies_list, false);
            int X = InputSignal1.Samples.Count;
            int Y = InputSignal2.Samples.Count;

            int indexs = X + Y - 1;

            for (int i = 0; i < indexs; i++)
            {
                float sum = 0;
                for (int k = 0; k < Y; k++)
                {
                    if (i - k < X && i - k >= 0)
                        sum += InputSignal1.Samples[i-k] * InputSignal2.Samples[k];

                    else if (i - k >= X)
                        continue;
                    else
                        break;
                }
                OutputConvolvedSignal.Samples.Add(sum);
            }




            //to find the least index can be formed from two indices list then add it to indices list

            int smallest_index = InputSignal1.SamplesIndices[0] + InputSignal2.SamplesIndices[0];
            for (int i = smallest_index; i < indexs + smallest_index; i++)
            {
                OutputConvolvedSignal.SamplesIndices.Add(i);
            }


        }
    }
}


