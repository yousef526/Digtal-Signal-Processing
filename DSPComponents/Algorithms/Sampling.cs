﻿using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class Sampling : Algorithm
    {
        public int L { get; set; } //upsampling factor
        public int M { get; set; } //downsampling factor
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }




        public override void Run()
        {
            List<float> x = new List<float>();

            FIR f = new FIR();
            f.InputFilterType = FILTER_TYPES.LOW;
            f.InputFS = 8000;
            f.InputStopBandAttenuation = 50;
            f.InputCutOffFrequency = 1500;
            f.InputTransitionBand = 500;
            
            f.InputTimeDomainSignal = InputSignal;

            //down sampling case
            if (L == 0 && M > 0)
            {
                List<int> indcies = new List<int>();
                f.Run();
               
                for (int i = 0; i < f.OutputYn.Samples.Count; i+=M)
                {
                    x.Add(f.OutputYn.Samples[i]);
                }
                OutputSignal = new Signal(x, false);

                int start = f.OutputYn.SamplesIndices[0];
                int end =  x.Count;
                for (int i = 0; i < end; i++)
                {
                    indcies.Add(start);
                    start++;
                }
                OutputSignal.SamplesIndices = indcies;
                

            }

            //upsampling case
            else if (M == 0 && L > 0)
            {
                for (int i = 0; i < InputSignal.Samples.Count; i++)
                {
                    x.Add(InputSignal.Samples[i]);
                    if (i < InputSignal.Samples.Count - 1)
                    {
                        for (int j = 0; j < L - 1; j++)
                        {
                            x.Add(0);
                        }
                    }
                }
                f.InputTimeDomainSignal.Samples = x;
                f.Run();
                OutputSignal = new Signal(f.OutputYn.Samples, false);
                OutputSignal.SamplesIndices = f.OutputYn.SamplesIndices;
                
            }

            // two cases with each other
            else if (M > 0 && L > 0)
            {
                List<int> indcies = new List<int>();
                List<float> fraction = new List<float>();

                for (int i = 0; i < InputSignal.Samples.Count; i++)
                {
                    x.Add(InputSignal.Samples[i]);
                    if (i < InputSignal.Samples.Count - 1)
                    {
                        for (int j = 0; j < L - 1; j++)
                        {
                            x.Add(0);
                        }
                    }
                }

                f.InputTimeDomainSignal.Samples = x;
                f.Run();

                for (int i = 0; i < f.OutputYn.Samples.Count; i += M)
                {
                    fraction.Add(f.OutputYn.Samples[i]);
                }
                OutputSignal = new Signal(fraction, false);
                int start = OutputSignal.SamplesIndices[0];
                int end = fraction.Count;
                for (int i = 0; i < end; i++)
                {
                    indcies.Add(start);
                    start++;
                }
                OutputSignal.SamplesIndices = indcies;
            }
            else if(M == 0 && L == 0)
                Console.WriteLine("Error");




            



        }
    }

}