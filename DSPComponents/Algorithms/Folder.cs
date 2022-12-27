using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Folder : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputFoldedSignal { get; set; }

        public override void Run()
        {
            bool check = true;
            List<int> index = new List<int>();

            foreach (int i in InputSignal.SamplesIndices)
                index.Add(i * -1);
            List<float> folding = Enumerable.Reverse(InputSignal.Samples).ToList();
            index.Reverse();

            if (InputSignal.Periodic == true)
                check = false;
            else
                check = true;
            OutputFoldedSignal = new Signal(folding, index, check);
        }
    }
}
