﻿using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DSPAlgorithms.Algorithms
{
    public class PracticalTask2 : Algorithm
    {
        public String SignalPath { get; set; }
        public float Fs { get; set; }// 1000
        public float miniF { get; set; }
        public float maxF { get; set; }
        public float newFs { get; set; }// 500
        public int L { get; set; } //upsampling factor
        public int M { get; set; } //downsampling factor
        public Signal OutputFreqDomainSignal { get; set; }

        public override void Run()
        {
            Signal InputSignal = LoadSignal(SignalPath);
            String fullpath;

            List<float> sampels = new List<float>();
            OutputFreqDomainSignal = new Signal(sampels, false);
            OutputFreqDomainSignal.FrequenciesAmplitudes = new List<float>();
            OutputFreqDomainSignal.FrequenciesPhaseShifts = new List<float>();
            OutputFreqDomainSignal.Frequencies = new List<float>();


            FIR filter = new FIR();
            filter.InputTimeDomainSignal = InputSignal;
            filter.InputF1 = miniF;
            filter.InputF2 = maxF;
            filter.InputFS = Fs;
            filter.InputFilterType = FILTER_TYPES.BAND_PASS;
            filter.InputStopBandAttenuation = 50;
            filter.InputTransitionBand = 500;
            filter.Run();

            /////////____\\\\\\\\\\
            
            Signal sig1 = filter.OutputYn;
            
            fullpath = "D:/ASU.studying material/4th year/1st semster/DSP/DSPToolbox/Txt files output/Band_passFilter_Signal.ds";
            using (StreamWriter writer = new StreamWriter(fullpath))
            {
                writer.WriteLine(0);
                writer.WriteLine(0);
                writer.WriteLine(sig1.Samples.Count);
                for (int i = 0; i < sig1.Samples.Count; i++)
                {
                    writer.Write(sig1.SamplesIndices[i]);
                    writer.Write(" ");
                    writer.WriteLine(sig1.Samples[i]);
                }

            }

            if (newFs >= 2*maxF)
            {
                Sampling sample = new Sampling();
                sample.L = L;
                sample.M = M;
                sample.InputSignal = sig1;
                sample.Run();
                sig1 = sample.OutputSignal;

                // writing to file the signal after 
                fullpath = "D:/ASU.studying material/4th year/1st semster/DSP/DSPToolbox/Txt files output/FilterCoefficients_sampling.txt";
                using (StreamWriter writer = new StreamWriter(fullpath))
                {
                    writer.WriteLine(0);
                    writer.WriteLine(0);
                    writer.WriteLine(sig1.Samples.Count);
                    for (int i = 0; i < sig1.Samples.Count; i++)
                    {
                        writer.Write(sig1.SamplesIndices[i]);
                        writer.Write(" ");
                        writer.WriteLine(sig1.Samples[i]);


                    }

                }

            }
            else
                Console.WriteLine("newFs is not valid");

            DC_Component dc = new DC_Component();
            dc.InputSignal = sig1;
            dc.Run();
            sig1.Samples = dc.OutputSignal.Samples;

            // writing to file the signal after 
            fullpath = "D:/ASU.studying material/4th year/1st semster/DSP/DSPToolbox/Txt files output/DC_Component_signal.ds";
            using (StreamWriter writer = new StreamWriter(fullpath))
            {
                writer.WriteLine(0);
                writer.WriteLine(0);
                writer.WriteLine(sig1.Samples.Count);
                for (int i = 0; i < sig1.Samples.Count; i++)
                {
                    writer.Write(sig1.SamplesIndices[i]);
                    writer.Write(" ");
                    writer.WriteLine(sig1.Samples[i]);


                }

            }

            Normalizer normalizer = new Normalizer();
            normalizer.InputSignal = sig1;
            normalizer.InputMinRange = -1;
            normalizer.InputMaxRange = 1;
            normalizer.Run();
            sig1.Samples = normalizer.OutputNormalizedSignal.Samples;


            // writing to file the signal after 
            fullpath = "D:/ASU.studying material/4th year/1st semster/DSP/DSPToolbox/Txt files output/Normalized_signal.ds";
            using (StreamWriter writer = new StreamWriter(fullpath))
            {
                writer.WriteLine(0);
                writer.WriteLine(0);
                writer.WriteLine(sig1.Samples.Count);
                for (int i = 0; i < sig1.Samples.Count; i++)
                {
                    writer.Write(sig1.SamplesIndices[i]);
                    writer.Write(" ");
                    writer.WriteLine(sig1.Samples[i]);


                }

            }


            DiscreteFourierTransform dft = new DiscreteFourierTransform();
            dft.InputTimeDomainSignal = sig1;
            dft.Run();
            sig1 = dft.OutputFreqDomainSignal;
            OutputFreqDomainSignal.FrequenciesAmplitudes = sig1.FrequenciesAmplitudes;
            OutputFreqDomainSignal.FrequenciesPhaseShifts = sig1.FrequenciesPhaseShifts;
            //////////////////////////////////////////////////////////////////////
            /// remaining to do the calc of the frequecny

            
            double real = 2 * Math.PI / (sig1.FrequenciesAmplitudes.Count * (1 / newFs));
            
            
            for (int i = 0; i < sig1.FrequenciesPhaseShifts.Count; i++)
            {
                OutputFreqDomainSignal.Frequencies.Add((float)Math.Round(i * real, 1));
            }

            // writing to file the signal after
            fullpath = "D:/ASU.studying material/4th year/1st semster/DSP/DSPToolbox/Txt files output/Frequency_Domain_signal.ds";
            using (StreamWriter writer = new StreamWriter(fullpath))
            {
                writer.WriteLine(1);
                writer.WriteLine(0);
                writer.WriteLine(OutputFreqDomainSignal.Frequencies.Count);
                for (int i = 0; i < OutputFreqDomainSignal.Frequencies.Count; i++)
                {
                    writer.Write(OutputFreqDomainSignal.Frequencies[i]);
                    writer.Write(" ");
                    writer.Write(OutputFreqDomainSignal.FrequenciesAmplitudes[i]);
                    writer.Write(" ");
                    writer.WriteLine(OutputFreqDomainSignal.FrequenciesPhaseShifts[i]);


                }

            }


        }

        public Signal LoadSignal(string filePath)
        {
            Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var sr = new StreamReader(stream);

            var sigType = byte.Parse(sr.ReadLine());
            var isPeriodic = byte.Parse(sr.ReadLine());
            long N1 = long.Parse(sr.ReadLine());

            List<float> SigSamples = new List<float>(unchecked((int)N1));
            List<int> SigIndices = new List<int>(unchecked((int)N1));
            List<float> SigFreq = new List<float>(unchecked((int)N1));
            List<float> SigFreqAmp = new List<float>(unchecked((int)N1));
            List<float> SigPhaseShift = new List<float>(unchecked((int)N1));

            if (sigType == 1)
            {
                SigSamples = null;
                SigIndices = null;
            }

            for (int i = 0; i < N1; i++)
            {
                if (sigType == 0 || sigType == 2)
                {
                    var timeIndex_SampleAmplitude = sr.ReadLine().Split();
                    SigIndices.Add(int.Parse(timeIndex_SampleAmplitude[0]));
                    SigSamples.Add(float.Parse(timeIndex_SampleAmplitude[1]));
                }
                else
                {
                    var Freq_Amp_PhaseShift = sr.ReadLine().Split();
                    SigFreq.Add(float.Parse(Freq_Amp_PhaseShift[0]));
                    SigFreqAmp.Add(float.Parse(Freq_Amp_PhaseShift[1]));
                    SigPhaseShift.Add(float.Parse(Freq_Amp_PhaseShift[2]));
                }
            }

            if (!sr.EndOfStream)
            {
                long N2 = long.Parse(sr.ReadLine());

                for (int i = 0; i < N2; i++)
                {
                    var Freq_Amp_PhaseShift = sr.ReadLine().Split();
                    SigFreq.Add(float.Parse(Freq_Amp_PhaseShift[0]));
                    SigFreqAmp.Add(float.Parse(Freq_Amp_PhaseShift[1]));
                    SigPhaseShift.Add(float.Parse(Freq_Amp_PhaseShift[2]));
                }
            }

            stream.Close();
            return new Signal(SigSamples, SigIndices, isPeriodic == 1, SigFreq, SigFreqAmp, SigPhaseShift);
        }
    }
}
