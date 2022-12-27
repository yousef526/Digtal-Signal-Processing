using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;


namespace DSPAlgorithms.Algorithms
{
    public class DiscreteFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public float InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }

        public override void Run()
        {
            // initliztions
            List<float> sampels = new List<float>();
            OutputFreqDomainSignal = new Signal(sampels,false);
            OutputFreqDomainSignal.FrequenciesAmplitudes = new List<float>();
            OutputFreqDomainSignal.FrequenciesPhaseShifts = new List<float>();
            int size_of_samples = InputTimeDomainSignal.Samples.Count;
            
            // the complex list of numbers
            List<Complex> my_numbers = new List<Complex>();
            

            // two loops to change from time domian to freq domian

            //first loop to take the summation of all terms of one harmonic and deal with it as (real,imaginary)
            for (int i = 0; i < size_of_samples; i++)
            {
                Complex hormany = new Complex();

                // second loop here to sum  terms of one harmonic by calculate the real part and imaginary part
                for (int j = 0; j < size_of_samples; j++)
                {
                    double x = InputTimeDomainSignal.Samples[j] * Math.Cos(i * 2 * Math.PI * j / size_of_samples);
                    double y = InputTimeDomainSignal.Samples[j] * -Math.Sin(i * 2 * Math.PI * j / size_of_samples);
                    hormany += new Complex(x, y);
                }
                my_numbers.Add(hormany);

            }

            // calculate requirments
            for (int i = 0; i < size_of_samples; i++)
            {
                
                float num1 = (float)Math.Pow(my_numbers[i].Real,2);
                float num2 = (float)Math.Pow(my_numbers[i].Imaginary, 2);
                OutputFreqDomainSignal.FrequenciesAmplitudes.Add((float)Math.Sqrt(num1 + num2));// to get amplitude
                OutputFreqDomainSignal.FrequenciesPhaseShifts.Add((float)Math.Atan2(my_numbers[i].Imaginary , my_numbers[i].Real));// to get phase shift

            }

        }
    }
}




