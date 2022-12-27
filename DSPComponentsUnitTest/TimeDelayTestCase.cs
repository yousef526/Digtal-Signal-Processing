using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DSPAlgorithms.Algorithms;
using DSPAlgorithms.DataStructures;


namespace DSPComponentsUnitTest
{
    [TestClass]
    public class TimeDelayTestCase
    {
        [TestMethod]
        public void DelayTestMethod1()
        {
            TimeDelay t = new TimeDelay();                  //4123
            t.InputSignal1 = new Signal(new List<float>() {1, 2, 3, 4}, false);
            t.InputSignal2 = new Signal(new List<float>() {2, 3, 4, 1}, false);
            t.InputSamplingPeriod = (float)0.1;
            float expect_output = (float)0.3;
            t.Run();
            Assert.IsTrue(UnitTestUtitlities.Equals(expect_output,t.OutputTimeDelay));
        }
    }
}
