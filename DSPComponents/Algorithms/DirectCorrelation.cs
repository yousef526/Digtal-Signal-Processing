using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectCorrelation : Algorithm
    {
        
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public List<float> OutputNonNormalizedCorrelation { get; set; }
        public List<float> OutputNormalizedCorrelation { get; set; }

        public override void Run()
        {
            OutputNonNormalizedCorrelation = new List<float>();
            OutputNormalizedCorrelation = new List<float>();
            
            //auto
            if(InputSignal2 == null)
            {
                List<double> list1 = new List<double>();
                List<double> list2 = new List<double>();//change always
                for (int i = 0; i < InputSignal1.Samples.Count; i++)
                {
                    list1.Add(InputSignal1.Samples[i]);
                    list2.Add(InputSignal1.Samples[i]);
                }

                double sum_normalize_list1 = 0;
                double sum_normalize_list2 = 0;
                double normalize_sum = 0;
                for (int j = 0; j < list1.Count; j++)
                {
                    sum_normalize_list1 += Math.Pow(list1[j], 2);
                    sum_normalize_list2 += Math.Pow(list2[j], 2);
                }
                normalize_sum = sum_normalize_list1 * sum_normalize_list2;
                normalize_sum = Math.Sqrt(normalize_sum);
                normalize_sum = normalize_sum / list1.Count;

                if (InputSignal1.Periodic == false) // non perdioc 
                {
                    for (int i = 0; i < InputSignal1.Samples.Count; i++)
                    {
                        double sum = 0;
                        double element = 0;
                        if (i == 0)
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count; j++)
                            {
                                sum += list1[j] * list2[j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count - 1; j++)
                            {
                                list2[j] = list2[j + 1];
                                sum += list1[j] * list2[j];
                            }
                            list2[list2.Count - 1] = element;
                            sum += list2[list2.Count - 1] * list1[list1.Count - 1];
                        }
                        OutputNonNormalizedCorrelation.Add((float)sum / list1.Count);
                        OutputNormalizedCorrelation.Add((float)(OutputNonNormalizedCorrelation[i] / normalize_sum));
                    }
                }
                else // perodic
                {
                    for (int i = 0; i < InputSignal1.Samples.Count; i++)
                    {
                        double sum = 0;
                        double element = list2[0];
                        if (i == 0)
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count; j++)
                            {
                                sum += list1[j] * list2[j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count - 1; j++)
                            {
                                list2[j] = list2[j + 1];
                                sum += list1[j] * list2[j];
                            }
                            list2[list2.Count - 1] = element;
                            sum += list2[list2.Count - 1] * list1[list1.Count - 1];
                        }
                        OutputNonNormalizedCorrelation.Add((float)sum / list1.Count);
                        OutputNormalizedCorrelation.Add((float)(OutputNonNormalizedCorrelation[i] / normalize_sum));
                    }

                }
            }
            
            //cross
            else //cross
            {
                List<double> list1 = new List<double>();
                List<double> list2 = new List<double>();//change always
                for (int i = 0; i < InputSignal1.Samples.Count; i++)
                {
                    list1.Add(InputSignal1.Samples[i]);
                    list2.Add(InputSignal2.Samples[i]);
                }

                double sum_normalize_list1 = 0;
                double sum_normalize_list2 = 0;
                double normalize_sum = 0;
                for (int j = 0; j < list1.Count; j++)
                {
                    sum_normalize_list1 += Math.Pow(list1[j], 2);
                    sum_normalize_list2 += Math.Pow(list2[j], 2);
                }
                normalize_sum = sum_normalize_list1 * sum_normalize_list2;
                normalize_sum = Math.Sqrt(normalize_sum);
                normalize_sum = normalize_sum / list1.Count;

                if (InputSignal1.Periodic == false) // non perdioc 
                {
                    for (int i = 0; i < InputSignal1.Samples.Count; i++)
                    {
                        double sum = 0;
                        double element = 0;
                        if (i == 0)
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count; j++)
                            {
                                sum += list1[j] * list2[j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count - 1; j++)
                            {
                                list2[j] = list2[j + 1];
                                sum += list1[j] * list2[j];
                            }
                            list2[list2.Count - 1] = element;
                            sum += list2[list2.Count - 1] * list1[list1.Count - 1];
                        }
                        OutputNonNormalizedCorrelation.Add((float)sum / list1.Count);
                        OutputNormalizedCorrelation.Add((float)(OutputNonNormalizedCorrelation[i] / normalize_sum));
                    }
                }
                else // perodic
                {
                    for (int i = 0; i < InputSignal1.Samples.Count; i++)
                    {
                        double sum = 0;
                        double element = list2[0];
                        if (i == 0)
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count; j++)
                            {
                                sum += list1[j] * list2[j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count - 1; j++)
                            {
                                list2[j] = list2[j + 1];
                                sum += list1[j] * list2[j];
                            }
                            list2[list2.Count - 1] = element;
                            sum += list2[list2.Count - 1] * list1[list1.Count - 1];
                        }
                        OutputNonNormalizedCorrelation.Add((float)sum / list1.Count);
                        OutputNormalizedCorrelation.Add((float)(OutputNonNormalizedCorrelation[i] / normalize_sum));
                    }

                }
            }

        }
    }
}


