using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;

namespace DSPAlgorithms.Algorithms
{
    public class InverseDiscreteFourierTransform : Algorithm
    {
        public Signal InputFreqDomainSignal { get; set; }
        public Signal OutputTimeDomainSignal { get; set; }
        

        public override void Run()
        {
            List<float> xt = new List<float>();
            OutputTimeDomainSignal = new Signal(xt,false);
            int size_of_samples = InputFreqDomainSignal.FrequenciesPhaseShifts.Count;

            List<Complex> my_numbers = new List<Complex>();

            // try to get real number and imaginary number
            // ampltiude*cos(phaseshift) = real_part
            // ampltiude*sin(phaseshift) = imaginary_part
            // put them in list of complex numbers
            for (int i = 0; i < size_of_samples; i++)
            {
                Complex hormany;

                double real = InputFreqDomainSignal.FrequenciesAmplitudes[i] * Math.Cos(InputFreqDomainSignal.FrequenciesPhaseShifts[i]);
                double img = InputFreqDomainSignal.FrequenciesAmplitudes[i] * Math.Sin(InputFreqDomainSignal.FrequenciesPhaseShifts[i]);
                hormany = new Complex(real, img);
                my_numbers.Add(hormany);

            }
            

            // two loops to calculate the orginal signal using inverse fourier transfrom
            for (int i = 0; i < size_of_samples; i++)
            {
                Complex mult = new Complex();
                
                for (int j = 0; j < size_of_samples; j++)
                {
                    
                    double x =  Math.Cos(i * 2 * Math.PI * j / size_of_samples);
                    double y =  Math.Sin(i * 2 * Math.PI * j / size_of_samples);
                    

                    mult += new Complex(x, y) * my_numbers[j];
                    
                }
                
                mult /= size_of_samples;

                // adding to Signal.samples the real part of complex number as imagnary part is equal to zero
                OutputTimeDomainSignal.Samples.Add((float)mult.Real);

            }

        }
    }
}











