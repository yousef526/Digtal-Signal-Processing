﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class MultiplySignalByConstant : Algorithm
    {
        public Signal InputSignal { get; set; }
        public float InputConstant { get; set; }
        public Signal OutputMultipliedSignal { get; set; }

        public override void Run()
        {
            List<float> L = new List<float>();
            OutputMultipliedSignal = new Signal(L, false);
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                OutputMultipliedSignal.Samples.Add( InputSignal.Samples[i]* InputConstant);
            }

   
           
        }
    }
}
