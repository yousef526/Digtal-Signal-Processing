using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;

namespace DSPAlgorithms.Algorithms
{
    public class FastCorrelation : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public List<float> OutputNonNormalizedCorrelation { get; set; }
        public List<float> OutputNormalizedCorrelation { get; set; }

        public override void Run()
        {
            OutputNonNormalizedCorrelation = new List<float>();
            OutputNormalizedCorrelation = new List<float>();

            if (InputSignal2== null)//auto
            {
                List<Complex> list1 = new List<Complex>(); list1 = DFT(InputSignal1);

                List<Complex> list2 = list1;

                List<Complex> list3 = new List<Complex>();


                Complex hormany = new Complex();
                for (int i = 0; i < list1.Count; i++)
                {
                    hormany = Complex.Multiply(list1[i],Complex.Conjugate(list2[i]));
                    list3.Add(hormany);
                }

                List<double> list4 = IDFT(list3);
                double sum_normalize_list1 = 0;
                double sum_normalize_list2 = 0;
                double normalize_sum = 0;
                for (int j = 0; j < list1.Count; j++)
                {
                    sum_normalize_list1 += Math.Pow(InputSignal1.Samples[j], 2);
                    sum_normalize_list2 += Math.Pow(InputSignal1.Samples[j], 2);
                }
                normalize_sum = sum_normalize_list1 * sum_normalize_list2;
                normalize_sum = Math.Sqrt(normalize_sum);
                normalize_sum = normalize_sum / list4.Count;

                for (int i = 0; i < list4.Count; i++)
                {
                    
                    OutputNonNormalizedCorrelation.Add((float)list4[i]/list4.Count);
                    OutputNormalizedCorrelation.Add((float)(list4[i] / normalize_sum/list4.Count));
                    Console.WriteLine(OutputNormalizedCorrelation[i]);
                }

            }

            else//Cross correlation
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
                    hormany = Complex.Multiply(Complex.Conjugate(list1[i]), list2[i]);
                    list3.Add(hormany);
                }

                List<double> list4 = IDFT(list3);
                double sum_normalize_list1 = 0;
                double sum_normalize_list2 = 0;
                double normalize_sum = 0;
                for (int j = 0; j < list1.Count; j++)
                {
                    sum_normalize_list1 += Math.Pow(InputSignal1.Samples[j], 2);
                    sum_normalize_list2 += Math.Pow(InputSignal2.Samples[j], 2);
                }
                normalize_sum = sum_normalize_list1 * sum_normalize_list2;
                normalize_sum = Math.Sqrt(normalize_sum);
                normalize_sum = normalize_sum / list4.Count;

                for (int i = 0; i < list4.Count; i++)
                {

                    OutputNonNormalizedCorrelation.Add((float)list4[i] / list4.Count);
                    OutputNormalizedCorrelation.Add((float)(list4[i] / normalize_sum / list4.Count));
                    Console.WriteLine(OutputNormalizedCorrelation[i]);
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