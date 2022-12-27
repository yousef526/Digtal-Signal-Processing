using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.IO;

namespace DSPAlgorithms.Algorithms
{
    public class FIR : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public FILTER_TYPES InputFilterType { get; set; }
        public float InputFS { get; set; }
        public float? InputCutOffFrequency { get; set; }
        public float? InputF1 { get; set; }
        public float? InputF2 { get; set; }
        public float InputStopBandAttenuation { get; set; }
        public float InputTransitionBand { get; set; }
        public Signal OutputHn { get; set; }
        public Signal OutputYn { get; set; }

        public override void Run()
        {
            float transation_norm = InputTransitionBand / InputFS;
            int N;

            List<float> Hn = new List<float>();
            List<int> index = new List<int>();
            List<float> coff = new List<float>();
            List<float> Wn = new List<float>();
            N = windowing_type(Wn, transation_norm);
            Hn = coefficient_window(InputFilterType, index, N);

            for (int i = 0; i < N; i++)
            {
                coff.Add((Wn[i] * Hn[i]));
            }
            OutputHn = new Signal(coff, index, false);


            // writing to file the signal after 
            String fullpath = "D:/ASU.studying material/4th year/1st semster/DSP/DSPToolbox/Txt files output/FilterCoefficients.ds";
            using (StreamWriter writer = new StreamWriter(fullpath))
            {
                writer.WriteLine(0);
                writer.WriteLine(0);
                writer.WriteLine(OutputHn.Samples.Count);
                for (int i = 0; i < OutputHn.Samples.Count; i++)
                {
                    writer.Write(OutputHn.SamplesIndices[i]);
                    writer.Write(" ");
                    writer.WriteLine(OutputHn.Samples[i]);


                }

            }


            DirectConvolution con = new DirectConvolution();
            con.InputSignal1 = InputTimeDomainSignal;
            con.InputSignal2 = OutputHn;
            con.Run();
            OutputYn = con.OutputConvolvedSignal;
        }
        private List<float> coefficient_window(FILTER_TYPES filter, List<int> index, int N)
        {
            List<float> res = new List<float>();
            if (filter == FILTER_TYPES.LOW)
            {
                float f_low = (float)((InputCutOffFrequency + (InputTransitionBand / 2)) / InputFS);
                for (int i = -(N / 2); i <= N / 2; i++)
                {
                    if (i == 0)
                    {
                        res.Add(2 * f_low);
                    }
                    else
                        res.Add((float)(2 * f_low * Math.Sin(i * 2 * Math.PI * f_low) / (i * 2 * Math.PI * f_low)));
                    index.Add(i);
                }
            }
            else if (filter == FILTER_TYPES.HIGH)
            {
                float f_high = (float)((InputCutOffFrequency - (InputTransitionBand / 2)) / InputFS);
                for (int i = -(N / 2); i <= N / 2; i++)
                {
                    if (i == 0)
                    {
                        res.Add(1 - 2 * f_high);
                    }
                    else
                        res.Add((float)(-2 * f_high * Math.Sin(i * 2 * Math.PI * f_high) / (i * 2 * Math.PI * f_high)));
                    index.Add(i);
                }
            }
            else if (filter == FILTER_TYPES.BAND_PASS)
            {
                float f1 = (((float)InputF1 - (InputTransitionBand / 2)) / InputFS);
                float f2 = (((float)InputF2 + (InputTransitionBand / 2)) / InputFS);
                for (int i = -(N / 2); i <= N / 2; i++)
                {
                    if (i == 0)
                    {
                        res.Add((2 * (f2 - f1)));
                    }
                    else
                        res.Add((float)(2 * f2 * Math.Sin((i * 2 * Math.PI * f2)) / (i * 2 * Math.PI * f2) - 2 * f1 * Math.Sin((double)(i * 2 * Math.PI * f1)) / (i * 2 * Math.PI * f1)));
                    index.Add(i);
                }
            }
            else if (filter == FILTER_TYPES.BAND_STOP)
            {
                float f1 = (float)((InputF1 + (InputTransitionBand / 2)) / InputFS);
                float f2 = (float)((InputF2 - (InputTransitionBand / 2)) / InputFS);
                for (int i = -(N / 2); i <= N / 2; i++)
                {
                    if (i == 0)
                    {
                        res.Add((1 - 2 * (f2 - f1)));
                    }
                    else
                        res.Add((float)(-2 * f2 * Math.Sin((i * 2 * Math.PI * f2)) / (i * 2 * Math.PI * f2) + 2 * f1 * Math.Sin((double)(i * 2 * Math.PI * f1)) / (i * 2 * Math.PI * f1)));
                    index.Add(i);
                }
            }
            return res;

        }
        private int windowing_type(List<float> window, float transation)
        {
            int N = 0;
            int n;
            if (InputStopBandAttenuation <= 21)
            {
                N = (int)Math.Ceiling(0.9 / transation);
                if (N % 2 == 0)
                    N++;

                for (int i = -(N / 2); i <= (N / 2); i++)
                {
                    window.Add(1);

                }
            }
            else if (InputStopBandAttenuation > 21 && InputStopBandAttenuation <= 44)
            {
                N = (int)Math.Ceiling(3.1 / transation);
                if (N % 2 == 0)
                    N++;
                for (int i = -(N / 2); i <= (N / 2); i++)
                {
                    window.Add((float)(0.5 + 0.5 * Math.Cos((2 * Math.PI * i) / N)));

                }
            }
            else if (InputStopBandAttenuation > 44 && InputStopBandAttenuation <= 53)
            {
                N = (int)Math.Ceiling(3.3 / transation);
                if (N % 2 == 0)
                    N++;
                for (int i = -(N / 2); i <= (N / 2); i++)
                {
                    window.Add((float)(0.54 + 0.46 * Math.Cos((2 * Math.PI * i) / N)));

                }
            }
            else if (InputStopBandAttenuation > 53 && InputStopBandAttenuation <= 74)
            {
                N = (int)Math.Ceiling(5.5 / transation);
                if (N % 2 == 0)
                    N++;

                for (int i = -(N / 2); i <= (N / 2); i++)
                {
                    window.Add((float)(0.42 + 0.5 * Math.Cos((2 * Math.PI * i) / (N - 1)) + 0.08 * Math.Cos((4 * Math.PI * i) / (N - 1))));
                }
            }

            return N;


        }

    }
}