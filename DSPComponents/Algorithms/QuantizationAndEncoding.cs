using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class QuantizationAndEncoding : Algorithm
    {
        // You will have only one of (InputLevel or InputNumBits), the other property will take a negative value
        // If InputNumBits is given, you need to calculate and set InputLevel value and vice versa
        public int InputLevel { get; set; }
        public int InputNumBits { get; set; }
        public Signal InputSignal { get; set; }
        public Signal OutputQuantizedSignal { get; set; }
        public List<int> OutputIntervalIndices { get; set; }
        public List<string> OutputEncodedSignal { get; set; }
        public List<float> OutputSamplesError { get; set; }

        public override void Run()
        {
            float max_amp = InputSignal.Samples.Max();
            float min_amp = InputSignal.Samples.Min();

            if (InputLevel <= 0 && InputNumBits > 0)
            {
                InputLevel = (int)Math.Pow((double)2, (double)InputNumBits);

            }
            else if(InputNumBits <= 0 && InputLevel > 0) // InputNumBits < 0
            { 
                InputNumBits = (int)Math.Log((double)InputLevel, (double)2);
            }
            //Console.WriteLine(InputLevel);
            //Console.WriteLine(InputNumBits);
            //Console.WriteLine(max_amp);
            //Console.WriteLine(min_amp);



            OutputEncodedSignal = new List<string>();

            OutputSamplesError = new List<float>();

            OutputIntervalIndices = new List<int>();

            List<float> samples = new List<float>();
            OutputQuantizedSignal = new Signal(samples, false);



            float delta = (float)System.Math.Round((max_amp - min_amp) / InputLevel, 2);
            

            List<float> intervals = new List<float>();
            intervals.Add(min_amp);
            float sum = min_amp;

            // the intervals for input_levels which are 16 numbers
            while(sum < max_amp)
            {
                sum = (float)System.Math.Round(sum += delta,2);
                intervals.Add(sum);

            }


            // dict for getting the midpoint incides
            Dictionary<float, int> dict =new Dictionary<float, int>();
            int index = 1;

            for (int i = 0; i < intervals.Count - 1; i++)
            {
                dict.Add((intervals[i + 1] + intervals[i])/2, index);
                index++;
            }

            
            

            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                for (int j = 0; j < intervals.Count - 1; j++)
                {
                    if( intervals[j]  <= InputSignal.Samples[i] && InputSignal.Samples[i] <= intervals[j+1])
                    {
                        OutputQuantizedSignal.Samples.Add((intervals[j + 1] + intervals[j]) / 2);
                        OutputSamplesError.Add(((intervals[j + 1] + intervals[j]) / 2f) - InputSignal.Samples[i]);
                        OutputIntervalIndices.Add(dict[(intervals[j + 1] + intervals[j])/2]);
                        break;
                    }
                    
                }
            }

            //encoded signals
            for (int i = 0; i < OutputQuantizedSignal.Samples.Count; i++)
            {
                foreach (var item in dict)
                {
                    if(OutputQuantizedSignal.Samples[i] == item.Key)
                    {
                        string binary = Convert.ToString(item.Value - 1, 2);
                        binary = binary.PadLeft(InputNumBits, '0');
                        OutputEncodedSignal.Add(binary);
                        break;
                    }
                }
            }


        }
    }
}
