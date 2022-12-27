using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;

namespace DSPAlgorithms.Algorithms
{
    public class FastConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }

        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            List<float> OutputNonNormalizedCorrelation = new List<float>();
            List<float> x = new List<float>();

            //Cross correlation
            {
                Signal input1 = InputSignal1;
                Signal input2 = InputSignal2;

                if (InputSignal1.Samples.Count != InputSignal2.Samples.Count)
                {
                    int cross_length = InputSignal2.Samples.Count + InputSignal1.Samples.Count - 1;
                    for (int i = InputSignal1.Samples.Count; i < cross_length; i++)
                        input1.Samples.Add(0);
                    for (int i = InputSignal2.Samples.Count; i < cross_length; i++)
                        input2.Samples.Add(0);
                }
                List<Complex> list1 = DFT(input1);

                List<Complex> list2 = DFT(input2);

                List<Complex> list3 = new List<Complex>();


                Complex hormany;
                for (int i = 0; i < list1.Count; i++)
                {
                    hormany = Complex.Multiply(list1[i], list2[i]);
                    list3.Add(hormany);
                }

                List<double> list4 = IDFT(list3);
                OutputConvolvedSignal = new Signal(x, false);

                for (int i = 0; i < list4.Count; i++)
                {
                    OutputConvolvedSignal.Samples.Add((float)list4[i]);
                }
                 
            }

        }

        public static List<Complex> DFT(Signal InputTimeDomainSignal)
        {
            // the complex list of numbers
            List<Complex> my_numbers = new List<Complex>();
            int size_of_samples = InputTimeDomainSignal.Samples.Count;

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

            return my_numbers;
        }

        public static List<double> IDFT(List<Complex> my_numbers)
        {
            List<double> xt = new List<double>();

            int size_of_samples = my_numbers.Count;


            // two loops to calculate the orginal signal using inverse fourier transfrom
            for (int i = 0; i < size_of_samples; i++)
            {
                Complex mult = new Complex();

                for (int j = 0; j < size_of_samples; j++)
                {

                    double x = Math.Cos(i * 2 * Math.PI * j / size_of_samples);
                    double y = Math.Sin(i * 2 * Math.PI * j / size_of_samples);


                    mult += new Complex(x, y) * my_numbers[j];

                }

                mult /= size_of_samples;

                // adding to Signal.samples the real part of complex number as imagnary part is equal to zero
                xt.Add((float)mult.Real);

            }

            return xt;

        }
    }
}
