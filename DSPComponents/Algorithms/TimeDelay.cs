using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class TimeDelay:Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public float InputSamplingPeriod { get; set; }
        public float OutputTimeDelay { get; set; }

        public override void Run()
        {
            List<float> signal1 = InputSignal1.Samples;
            List<float> signal2 = InputSignal2.Samples;
            int countSignal1 = InputSignal1.Samples.Count;
            int countSignal2 = InputSignal2.Samples.Count;
            int it;
            //two signal not equal
            if (countSignal1>countSignal2)
            {
                it = countSignal1 - countSignal2;
                for(int i=0;i<it;i++)
                {
                    signal2.Add(InputSignal2.Samples[i]);
                }
            }
            if (countSignal1 < countSignal2)
            {
                it = countSignal2 - countSignal1;
                for (int i = 0; i < it; i++)
                {
                    signal1.Add(InputSignal1.Samples[i]);
                }
            }
            //calculate correlation
            List<float> tempswap=new List<float>(new float[signal1.Count]);
            List<float> corr = new List<float>();
            float sum;
            
            for (int i=0;i<signal1.Count;i++)
            {
                sum = 0;
                if(i!=0)
                {
                    for (int t = 0; t < signal2.Count; t++)
                    {
                        tempswap[t] = signal2[(t + 1) % signal2.Count];
                    }
                    signal2 = tempswap.ToList();
                }
                
                for(int j=0;j<signal1.Count;j++)
                {
                    sum += signal1[j] * signal2[j];
                    
                }
                sum /= signal1.Count;
                corr.Add(sum);
            }
            //find the max absolute value
            float max = -100,index=0;
            for(int i=0;i<corr.Count;i++)
            {
                if(max<Math.Abs(corr[i]))
                {
                    max = corr[i];
                    //save its lag (j)
                    index = i;
                }  
            }
            //Time delay= j * Ts
            OutputTimeDelay = index * InputSamplingPeriod;

        }
    }
}
