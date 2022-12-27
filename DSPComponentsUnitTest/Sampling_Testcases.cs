﻿using DSPAlgorithms.Algorithms;
using DSPAlgorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DSPComponentsUnitTest
{
    [TestClass]
    public class Sampling_Testcases
    {
        [TestMethod]
        public void SamplingTestcase1()
        {
            var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
            Signal expectedOutput = new Signal(new List<float> { 0.04935597f, -0.07165951f, 0.09261586f, -0.09037347f, 0.1056597f, -0.08048439f, -0.01038062f, 0.2570988f, -0.6476495f, 1.183434f, -1.811138f, 2.587852f, -3.67504f, -21.1769f, -16.46969f, -17.59398f, -20.55852f, -18.98507f, -20.24818f, -20.01654f, -21.05973f, -19.78587f, -18.96638f, -10.35183f, -4.45535f, -3.924692f, 5.796741f, 9.796752f, 7.302893f, 9.598067f, 5.54111f, -0.4124517f, 4.775912f, 11.39121f, 13.63302f, 21.99015f, 20.56724f, 9.314501f, 19.48193f, 24.63404f, 21.58795f, 34.53657f, 34.64909f, 26.82737f, 29.04066f, 24.51504f, 18.74955f, 8.206266f, -1.329533f, -5.237903f, -15.74046f, -19.62936f, -19.41714f, -20.85766f, -19.78715f, -19.89813f, -19.64947f, -21.28601f, -25.04761f, -26.33329f, -27.26534f, -27.06245f, -26.36319f, -27.85591f, -28.58529f, -31.82818f, -30.75813f, -29.27204f, -29.58899f, -40.03488f, -56.36599f, -57.63182f, -46.79147f, -23.65371f, 32.3186f, 106.6858f, 176.9745f, 307.9948f, 399.4362f, 388.4262f, 450.7768f, 404.5267f, 259.8622f, 280.1642f, 217.0792f, 103.6807f, 66.08805f, 10.1152f, -14.43715f, -18.27871f, -13.19463f, -2.500603f, -3.558494f, -2.879193f, -1.081606f, -10.08183f, -10.98563f, -8.152247f, -6.863034f, -6.12595f, -8.491961f, -9.940888f, -10.28717f, -7.819818f, -8.08004f, -6.470641f, -3.829464f, -2.353399f, -1.160521f, 0.8812097f, 3.127196f, 6.797708f, 11.90453f, 9.354048f, 8.792031f, 11.93634f, 13.71888f, 17.26601f, 21.35648f, 20.39578f, 21.75083f, 26.89697f, 27.46476f, 30.24683f, 32.84463f, 34.2516f, 36.52111f, 38.37359f, 45.47596f, 50.01624f, 51.85755f, 56.54231f, 60.0601f, 63.42606f, 68.63049f, 72.34521f, 74.34101f, 81.74744f, 87.33677f, 91.76587f, 101.204f, 109.1841f, 117.3287f, 125.8658f, 132.6874f, 139.7631f, 145.4199f, 153.1785f, 162.8651f, 172.4458f, 180.5921f, 186.5269f, 193.642f, 199.9357f, 205.5766f, 211.6541f, 215.5418f, 218.9743f, 221.1474f, 223.5638f, 226.5074f, 222.5846f, 218.4408f, 213.2667f, 202.5092f, 190.3698f, 176.8145f, 160.6022f, 146.5698f, 134.3284f, 118.0821f, 102.6239f, 88.82956f, 72.28568f, 60.5235f, 52.668f, 39.93533f, 30.51097f, 24.19839f, 15.11352f, 10.19366f, 8.231174f, 1.808034f, -1.156303f, -2.12428f, -5.762856f, -7.683114f, -9.731377f, -10.82206f, -11.91182f, -12.51321f, -13.26749f, -12.57864f, -10.59829f, -11.92442f, -12.813f, -12.77215f, -13.42785f, -13.31241f, -11.61073f, -14.64532f, -15.18243f, -11.4569f, -14.33963f, -12.78167f, -9.07142f, -9.700857f, -9.983706f, -12.78051f, -12.97261f, -13.26825f, -16.37736f, -11.19163f, -11.00962f, -14.41286f, -10.60665f, -9.358223f, -8.02786f, -10.14929f, -11.69232f, -10.86235f, -12.1195f, -11.87808f, -11.20169f, -10.89457f, -9.682479f, -8.59687f, -9.133419f, -10.23484f, -10.96677f, -11.13336f, -10.90484f, -10.29705f, -12.74486f, -13.59673f, -11.91061f, -12.53601f, -13.23022f, -12.76825f, -17.58321f, -17.87383f, -13.13883f, -15.7782f, -15.72565f, -15.4342f, -16.39829f, -16.06658f, -16.94456f, -13.88945f, -12.89112f, -15.64625f, -13.19006f, -13.20221f, -16.37731f, -11.19818f, -11.10641f, -16.31176f, -14.42415f, -15.94966f, -18.3237f, -15.97692f, -15.33747f, -15.43796f, -15.64756f, -16.20876f, -15.44021f, -15.69856f, -15.87853f, -15.35283f, -19.13718f, -19.72441f, -18.5661f, -17.77587f, -16.86785f, -19.55585f, -15.11413f, -15.09038f, -18.54682f, -17.07476f, -18.25148f, -17.13643f, -21.24305f, -21.707f, -16.95124f, -20.49783f, -20.13661f, -18.23856f, -18.53309f, -17.50053f, -18.45804f, -17.42721f, -17.78452f, -21.09706f, -17.87813f, -18.0881f, -20.93228f, -17.85757f, -17.53209f, -17.5097f, -19.31637f, -20.48882f, -19.99447f, -20.99599f, -20.0227f, -21.3363f, -17.44957f, -18.19329f, -23.26979f, -19.53766f, -18.28884f, -17.62029f, -19.23578f, -21.22246f, -20.0913f, -20.95534f, -19.77063f, -17.24449f, -20.53739f, -22.14396f, -21.59759f, -25.09703f, -25.15101f, -24.51826f, -22.69595f, -22.15042f, -23.95347f, -21.88384f, -21.41672f, -20.90762f, -21.60015f, -22.40276f, -20.50087f, -22.84862f, -21.50564f, -17.48233f, -15.5785f, -10.58723f, -7.079284f, 2.979974f, 7.607302f, 3.462723f, 7.326469f, 2.871381f, -1.759308f, -1.138093f, 5.924126f, 15.77271f, 20.28472f, 18.49283f, 9.013181f, 15.3716f, 21.04608f, 21.73996f, 33.04908f, 32.35023f, 27.02186f, 23.54391f, 20.71675f, 21.52304f, 9.540922f, -0.4521924f, -7.588264f, -16.2973f, -19.70559f, -23.33496f, -22.56228f, -24.28526f, -28.73929f, -28.07452f, -28.28169f, -29.38569f, -29.04637f, -30.29276f, -31.45054f, -31.17222f, -32.15136f, -31.01825f, -33.8126f, -32.37807f, -30.60804f, -33.27347f, -44.86319f, -63.1749f, -63.70394f, -54.14077f, -34.67403f, 27.2518f, 109.5868f, 183.8837f, 327.7273f, 418.7548f, 400.361f, 462.822f, 414.0996f, 271.0766f, 274.9802f, 207.7301f, 102.4237f, 69.9474f, 16.90354f, -11.92867f, -19.28539f, -13.83948f, -0.1663721f, -2.486402f, -2.984578f, -7.84244f, -5.003159f, -5.28322f, -12.72328f, -8.46478f, -8.378467f, -5.987184f, -9.829319f, -8.887135f, -3.015739f, -3.095445f, -0.9958964f, -3.240629f, 4.202066f, 5.147221f, -0.9626983f, 2.670714f, 3.131384f, 5.522836f, 6.596846f, 7.110301f, 10.89087f, 8.400646f, 11.29482f, 16.96902f, 17.7699f, 18.46346f, 17.0389f, 21.07708f, 24.25544f, 25.36941f, 29.83984f, 32.05458f, 33.67095f, 37.98492f, 41.14072f, 42.91537f, 47.42059f, 50.41652f, 53.43476f, 59.47601f, 64.84911f, 69.70019f, 74.44577f, 79.53485f, 84.47791f, 93.82263f, 100.0626f, 102.4577f, 111.4445f, 119.3739f, 126.5154f, 139.0691f, 146.623f, 152.6111f, 160.1414f, 167.3691f, 179.5778f, 180.3052f, 185.8856f, 198.8851f, 197.4683f, 203.5315f, 212.4055f, 213.7003f, 214.3119f, 213.1673f, 208.976f, 205.7513f, 204.8895f, 193.0029f, 184.4701f, 177.7622f, 162.8289f, 148.1817f, 132.7057f, 116.0839f, 100.7662f, 89.4384f, 68.36008f, 54.53717f, 48.87072f, 32.03004f, 23.52691f, 19.42275f, 13.39129f, 9.248284f, 4.020923f, -2.958114f, -6.503634f, -6.269008f, -6.398891f, -5.239197f, -7.268981f, -7.031011f, -8.862441f, -12.80469f, -8.853648f, -9.845275f, -10.85663f, -15.90676f, -14.27492f, -6.027798f, -7.805318f, -9.593466f, -13.86257f, -12.52219f, -10.55183f, -11.90325f, -10.07126f, -11.79492f, -13.92783f, -10.77155f, -9.592004f, -10.12752f, -13.73212f, -15.69801f, -15.79118f, -14.32775f, -13.88546f, -18.35939f, -15.18956f, -15.99689f, -17.42459f, -16.04564f, -17.04282f, -11.1125f, -22.32763f, -22.1863f, -6.117809f, -17.42232f, -16.12787f, -9.106511f, -16.72128f, -18.72812f, -21.76285f, -20.44485f, -18.57506f, -21.60237f, -16.81057f, -17.81859f, -21.55083f, -16.7648f, -16.43765f, -15.93191f, -23.68078f, -25.92367f, -18.00949f, -20.45751f, -18.97578f, -16.17118f, -23.47157f, -24.49408f, -22.29887f, -22.19676f, -22.00154f, -25.39904f, -21.64056f, -20.26779f, -24.16133f, -20.97727f, -22.86363f, -28.63684f, -23.79326f, -24.52536f, -28.65575f, -28.63893f, -27.83693f, -26.54673f, -23.02054f, -23.39938f, -29.64081f, -25.5379f, -25.65526f, -29.09681f, -26.2238f, -26.24121f, -25.09344f, -25.57095f, -25.90328f, -25.3466f, -29.39155f, -29.86382f, -28.69549f, -24.87368f, -24.52211f, -25.79589f, -27.17282f, -24.85744f, -21.1303f, -24.78351f, -29.04574f, -35.24358f, -28.28807f, -26.40419f, -29.47357f, -31.05379f, -31.299f, -26.11055f, -26.71562f, -26.17627f, -27.92563f, -27.38708f, -31.1165f, -30.29315f, -31.22802f, -19.86283f, 3.477826f, -0.4470182f, -0.5550098f, 0.8643193f, -0.8508323f, 0.7278979f, -0.523862f, 0.3189423f, -0.1113813f, -0.01006683f, 0.06144053f, -0.01712214f}, false);

          

            Sampling s = new Sampling();
            s.L = 3;
            s.M = 2;
            s.InputSignal = sig1;
            s.Run();

            Console.WriteLine(expectedOutput.SamplesIndices[expectedOutput.SamplesIndices.Count - 1]);
            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, s.OutputSignal.Samples));
        }


        [TestMethod]
          public void SamplingTestcase2()
          {
              var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
             // Signal expectedOutput = new Signal(new List<float> { 0.04935597f, -0.01170374f, -0.07165951f, 0.03017318f, 0.09261586f, 0.01028625f, -0.09037347f, -0.1009204f, 0.1056597f, 0.2514234f, -0.08048439f, -0.3884619f, -0.01038062f, 0.5033394f, 0.2570988f, -0.5314955f, -0.6476495f, 0.4549838f, 1.183434f, -0.1227043f, -1.811138f, -0.7317978f, 2.587852f, 2.953769f, -3.67504f, -14.27808f, -21.1769f, -20.61076f, -16.46969f, -15.02389f, -17.59398f, -20.39076f, -20.55852f, -19.29831f, -18.98507f, -19.79651f, -20.24818f, -19.97093f, -20.01654f, -20.74703f, -21.05973f, -20.41021f, -19.78587f, -19.72561f, -18.96638f, -15.74135f, -10.35183f, -5.831047f, -4.45535f, -4.916727f, -3.924692f, 0.1636496f, 5.796741f, 9.532311f, 9.796752f, 8.182204f, 7.302893f, 8.225911f, 9.598067f, 8.893131f, 5.54111f, 1.582616f, -0.4124517f, 0.9018993f, 4.775912f, 8.869458f, 11.39121f, 12.36823f, 13.63302f, 17.19225f, 21.99015f, 24.04108f, 20.56724f, 13.58364f, 9.314501f, 12.12789f, 19.48193f, 24.86353f, 24.63404f, 21.51066f, 21.58795f, 27.26312f, 34.53657f, 37.58461f, 34.64909f, 29.40617f, 26.82737f, 27.82084f, 29.04066f, 27.70232f, 24.51504f, 21.45223f, 18.74955f, 14.58076f, 8.206266f, 2.077581f, -1.329533f, -2.819561f, -5.237903f, -10.11531f, -15.74046f, -19.14456f, -19.62936f, -19.17141f, -19.41714f, -20.32225f, -20.85766f, -20.42069f, -19.78715f, -19.75155f, -19.89813f, -19.78922f, -19.64947f, -20.019f, -21.28601f, -23.32856f, -25.04761f, -25.88144f, -26.33329f, -26.73975f, -27.26534f, -27.51654f, -27.06245f, -26.60818f, -26.36319f, -26.70928f, -27.85591f, -28.08212f, -28.58529f, -31.09859f, -31.82818f, -30.88552f, -30.75813f, -29.76597f, -29.27204f, -30.13208f, -29.58899f, -31.87367f, -40.03488f, -49.40691f, -56.36599f, -59.54251f, -57.63182f, -52.97031f, -46.79147f, -37.70707f, -23.65371f, -0.8285823f, 32.3186f, 70.75601f, 106.6858f, 138.5612f, 176.9745f, 234.7895f, 307.9948f, 371.43f, 399.4362f, 394.0836f, 388.4262f, 411.7095f, 450.7768f, 458.058f, 404.5267f, 318.2287f, 259.8622f, 258.2556f, 280.1642f, 271.4168f, 217.0792f, 149.1771f, 103.6807f, 83.37485f, 66.08805f, 38.9201f, 10.1152f, -8.039416f, -14.43715f, -16.6718f, -18.27871f, -17.09877f, -13.19463f, -7.607116f, -2.500603f, -2.103736f, -3.558494f, -3.219477f, -2.879193f, -1.696261f, -1.081606f, -5.360842f, -10.08183f, -11.29899f, -10.98563f, -9.731711f, -8.152247f, -7.800512f, -6.863034f, -5.646976f, -6.12595f, -7.442603f, -8.491961f, -9.265604f, -9.940888f, -10.53658f, -10.28717f, -9.006422f, -7.819818f, -7.682431f, -8.08004f, -7.776075f, -6.470641f, -4.891586f, -3.829464f, -3.159551f, -2.353399f, -1.618065f, -1.160521f, -0.3824913f, 0.8812097f, 2.121994f, 3.127196f, 4.413755f, 6.797708f, 9.979555f, 11.90453f, 11.25326f, 9.354048f, 8.248228f, 8.792031f, 10.46641f, 11.93634f, 12.74453f, 13.71888f, 15.24262f, 17.26601f, 19.69749f, 21.35648f, 21.26472f, 20.39578f, 20.25692f, 21.75083f, 24.65053f, 26.89697f, 27.30827f, 27.46476f, 28.56246f, 30.24683f, 31.96469f, 32.84463f, 33.08212f, 34.2516f, 35.88409f, 36.52111f, 36.984f, 38.37359f, 41.17031f, 45.47596f, 48.99077f, 50.01624f, 50.52748f, 51.85755f, 53.75175f, 56.54231f, 58.98487f, 60.0601f, 61.45621f, 63.42606f, 65.45661f, 68.63049f, 71.57249f, 72.34521f, 72.82303f, 74.34101f, 77.04908f, 81.74744f, 85.92457f, 87.33677f, 88.78028f, 91.76587f, 95.70077f, 101.204f, 106.2575f, 109.1841f, 112.7495f, 117.3287f, 121.309f, 125.8658f, 130.0803f, 132.6874f, 136.077f, 139.7631f, 142.0874f, 145.4199f, 149.6704f, 153.1785f, 157.7564f, 162.8651f, 167.0765f, 172.4458f, 177.7603f, 180.5921f, 183.2775f, 186.5269f, 189.4289f, 193.642f, 197.8548f, 199.9357f, 202.2947f, 205.5766f, 208.3369f, 211.6541f, 214.609f, 215.5418f, 216.8356f, 218.9743f, 220.0457f, 221.1474f, 222.6314f, 223.5638f, 225.1966f, 226.5074f, 225.0279f, 222.5846f, 220.7606f, 218.4408f, 216.1155f, 213.2667f, 208.179f, 202.5092f, 197.0877f, 190.3698f, 183.4621f, 176.8145f, 168.7348f, 160.6022f, 153.6286f, 146.5698f, 140.2247f, 134.3284f, 126.5158f, 118.0821f, 110.4933f, 102.6239f, 95.42183f, 88.82956f, 80.5874f, 72.28568f, 65.92314f, 60.5235f, 56.42628f, 52.668f, 46.5932f, 39.93533f, 34.88424f, 30.51097f, 27.12806f, 24.19839f, 19.69605f, 15.11352f, 12.19861f, 10.19366f, 9.198766f, 8.231174f, 5.287937f, 1.808034f, -0.1970852f, -1.156303f, -1.501794f, -2.12428f, -3.970449f, -5.762856f, -6.675197f, -7.683114f, -8.852155f, -9.731377f, -10.40948f, -10.82206f, -11.19851f, -11.91182f, -12.42942f, -12.51321f, -12.76803f, -13.26749f, -13.33896f, -12.57864f, -11.34011f, -10.59829f, -10.94933f, -11.92442f, -12.64554f, -12.813f, -12.75505f, -12.77215f, -12.97203f, -13.42785f, -13.75148f, -13.31241f, -12.25698f, -11.61073f, -12.46628f, -14.64532f, -16.13676f, -15.18243f, -12.77563f, -11.4569f, -12.41485f, -14.33963f, -14.74122f, -12.78167f, -10.25558f, -9.07142f, -9.228304f, -9.700857f, -9.806882f, -9.983706f, -11.12025f, -12.78051f, -13.50258f, -12.97261f, -12.42653f, -13.26825f, -15.35018f, -16.37736f, -14.50878f, -11.19163f, -9.595311f, -11.00962f, -13.59896f, -14.41286f, -12.71379f, -10.60665f, -9.698251f, -9.358223f, -8.680134f, -8.02786f, -8.455723f, -10.14929f, -11.63739f, -11.69232f, -11.01603f, -10.86235f, -11.4174f, -12.1195f, -12.30773f, -11.87808f, -11.41891f, -11.20169f, -11.04f, -10.89457f, -10.5171f, -9.682479f, -8.904288f, -8.59687f, -8.68102f, -9.133419f, -9.736618f, -10.23484f, -10.69174f, -10.96677f, -10.991f, -11.13336f, -11.26359f, -10.90484f, -10.33665f, -10.29705f, -11.18826f, -12.74486f, -13.82205f, -13.59673f, -12.65372f, -11.91061f, -11.83949f, -12.53601f, -13.29859f, -13.23022f, -12.63778f, -12.76825f, -14.60587f, -17.58321f, -19.25628f, -17.87383f, -14.86605f, -13.13883f, -13.90101f, -15.7782f, -16.53947f, -15.72565f, -15.01832f, -15.4342f, -16.18563f, -16.39829f, -16.12044f, -16.06658f, -16.6564f, -16.94456f, -15.8291f, -13.88945f, -12.60222f, -12.89112f, -14.47086f, -15.64625f, -14.97578f, -13.19006f, -12.21972f, -13.20221f, -15.41294f, -16.37731f, -14.4394f, -11.19818f, -9.642809f, -11.10641f, -14.28303f, -16.31176f, -15.7869f, -14.42415f, -14.40075f, -15.94966f, -17.79002f, -18.3237f, -17.26146f, -15.97692f, -15.41717f, -15.33747f, -15.43243f, -15.43796f, -15.37121f, -15.64756f, -16.12911f, -16.20876f, -15.88553f, -15.44021f, -15.2493f, -15.69856f, -16.20668f, -15.87853f, -15.19486f, -15.35283f, -16.89618f, -19.13718f, -20.32421f, -19.72441f, -18.76042f, -18.5661f, -18.49151f, -17.77587f, -16.80257f, -16.86785f, -18.45928f, -19.55585f, -18.04465f, -15.11413f, -13.73728f, -15.09038f, -17.55844f, -18.54682f, -17.67083f, -17.07476f, -17.73837f, -18.25148f, -17.70141f, -17.13643f, -18.31346f, -21.24305f, -23.14092f, -21.707f, -18.53998f, -16.95124f, -18.13527f, -20.49783f, -21.4026f, -20.13661f, -18.60568f, -18.23856f, -18.50238f, -18.53309f, -18.03155f, -17.50053f, -17.79777f, -18.45804f, -18.2991f, -17.42721f, -16.94839f, -17.78452f, -19.80156f, -21.09706f, -20.06826f, -17.87813f, -16.92193f, -18.0881f, -20.19256f, -20.93228f, -19.5396f, -17.85757f, -17.35209f, -17.53209f, -17.59601f, -17.5097f, -17.92316f, -19.31637f, -20.57768f, -20.48882f, -19.87748f, -19.99447f, -20.66721f, -20.99599f, -20.50265f, -20.0227f, -20.66283f, -21.3363f, -20.0356f, -17.44957f, -16.33647f, -18.19329f, -21.60553f, -23.26979f, -21.83593f, -19.53766f, -18.46992f, -18.28884f, -18.05871f, -17.62029f, -17.78198f, -19.23578f, -20.89039f, -21.22246f, -20.5768f, -20.0913f, -20.26747f, -20.95534f, -21.0693f, -19.77063f, -17.99419f, -17.24449f, -18.22907f, -20.53739f, -22.29414f, -22.14396f, -21.30604f, -21.59759f, -23.23285f, -25.09703f, -25.76838f, -25.15101f, -24.62161f, -24.51826f, -23.90773f, -22.69595f, -21.83623f, -22.15042f, -23.336f, -23.95347f, -23.16274f, -21.88384f, -21.34922f, -21.41672f, -21.31737f, -20.90762f, -20.81208f, -21.60015f, -22.58392f, -22.40276f, -21.19186f, -20.50087f, -21.30004f, -22.84862f, -23.22315f, -21.50564f, -18.98879f, -17.48233f, -16.84198f, -15.5785f, -13.17179f, -10.58723f, -8.879234f, -7.079284f, -3.044052f, 2.979974f, 7.463493f, 7.607302f, 4.907765f, 3.462723f, 5.115158f, 7.326469f, 6.501636f, 2.871381f, -0.4229239f, -1.759308f, -1.811139f, -1.138093f, 1.180951f, 5.924126f, 11.57283f, 15.77271f, 18.37951f, 20.28472f, 20.89272f, 18.49283f, 13.20905f, 9.013181f, 10.06425f, 15.3716f, 20.08306f, 21.04608f, 20.06951f, 21.73996f, 27.33931f, 33.04908f, 34.74319f, 32.35023f, 28.96031f, 27.02186f, 25.80629f, 23.54391f, 21.09183f, 20.71675f, 21.94296f, 21.52304f, 16.97076f, 9.540922f, 3.182814f, -0.4521924f, -3.392283f, -7.588264f, -12.5068f, -16.2973f, -18.28017f, -19.70559f, -21.70833f, -23.33496f, -23.40437f, -22.56228f, -22.49108f, -24.28526f, -27.06076f, -28.73929f, -28.70664f, -28.07452f, -27.87754f, -28.28169f, -29.05f, -29.38569f, -29.12724f, -29.04637f, -29.41218f, -30.29276f, -31.23165f, -31.45054f, -31.36082f, -31.17222f, -31.38664f, -32.15136f, -31.5307f, -31.01825f, -33.03969f, -33.8126f, -32.92199f, -32.37807f, -30.83907f, -30.60804f, -32.65364f, -33.27347f, -36.1791f, -44.86319f, -55.20499f, -63.1749f, -66.37371f, -63.70394f, -58.8734f, -54.14077f, -47.46108f, -34.67403f, -10.23872f, 27.2518f, 70.56076f, 109.5868f, 142.8864f, 183.8837f, 247.6106f, 327.7273f, 393.9466f, 418.7548f, 408.2467f, 400.361f, 424.1597f, 462.822f, 468.0762f, 414.0996f, 329.7382f, 271.0766f, 262.8637f, 274.9802f, 260.5914f, 207.7301f, 144.484f, 102.4237f, 84.40707f, 69.9474f, 45.37564f, 16.90354f, -3.185289f, -11.92867f, -16.0367f, -19.28539f, -18.85294f, -13.83948f, -6.136036f, -0.1663721f, -0.6160144f, -2.486402f, -1.774539f, -2.984578f, -5.999938f, -7.84244f, -8.268012f, -5.003159f, -1.968855f, -5.28322f, -10.96442f, -12.72328f, -11.04401f, -8.46478f, -7.68784f, -8.378467f, -7.549448f, -5.987184f, -6.876984f, -9.829319f, -11.25592f, -8.887135f, -4.935112f, -3.015739f, -3.260239f, -3.095445f, -1.637013f, -0.9958964f, -2.307091f, -3.240629f, -0.7859543f, 4.202066f, 7.073905f, 5.147221f, 1.017518f, -0.9626983f, 0.3744851f, 2.670714f, 3.438073f, 3.131384f, 3.772524f, 5.522836f, 6.719527f, 6.596846f, 6.185961f, 7.110301f, 9.42945f, 10.89087f, 10.00307f, 8.400646f, 8.618076f, 11.29482f, 14.85661f, 16.96902f, 17.34553f, 17.7699f, 18.54599f, 18.46346f, 17.55337f, 17.0389f, 18.15976f, 21.07708f, 23.62647f, 24.25544f, 24.37073f, 25.36941f, 27.30124f, 29.83984f, 31.6429f, 32.05458f, 32.51017f, 33.67095f, 35.37037f, 37.98492f, 40.30864f, 41.14072f, 41.74546f, 42.91537f, 44.65664f, 47.42059f, 49.7421f, 50.41652f, 51.37566f, 53.43476f, 55.97087f, 59.47601f, 62.78838f, 64.84911f, 67.20988f, 69.70019f, 71.56586f, 74.44577f, 77.67134f, 79.53485f, 81.57868f, 84.47791f, 88.20384f, 93.82263f, 98.70004f, 100.0626f, 100.6251f, 102.4577f, 105.761f, 111.4445f, 116.8304f, 119.3739f, 122.0647f, 126.5154f, 132.0544f, 139.0691f, 144.6366f, 146.623f, 148.8028f, 152.6111f, 156.2378f, 160.1414f, 163.8039f, 167.3691f, 173.529f, 179.5778f, 180.9939f, 180.3052f, 181.4514f, 185.8856f, 193.4143f, 198.8851f, 198.6607f, 197.4683f, 199.3603f, 203.5315f, 208.7501f, 212.4055f, 213.0992f, 213.7003f, 214.7509f, 214.3119f, 213.626f, 213.1673f, 211.3106f, 208.976f, 207.1644f, 205.7513f, 205.6848f, 204.8895f, 199.8999f, 193.0029f, 187.907f, 184.4701f, 181.7881f, 177.7622f, 170.5801f, 162.8289f, 156.0104f, 148.1817f, 140.0888f, 132.7057f, 124.5293f, 116.0839f, 108.2747f, 100.7662f, 94.97153f, 89.4384f, 79.945f, 68.36008f, 59.51442f, 54.53717f, 52.31906f, 48.87072f, 40.84422f, 32.03004f, 26.63518f, 23.52691f, 21.46517f, 19.42275f, 16.16889f, 13.39129f, 11.70151f, 9.248284f, 6.532002f, 4.020923f, 0.5324103f, -2.958114f, -5.173928f, -6.503634f, -6.681139f, -6.269008f, -6.478942f, -6.398891f, -5.512935f, -5.239197f, -6.08811f, -7.268981f, -7.730795f, -7.031011f, -6.789018f, -8.862441f, -11.87201f, -12.80469f, -11.01347f, -8.853648f, -8.628211f, -9.845275f, -10.56549f, -10.85663f, -12.67359f, -15.90676f, -17.23904f, -14.27492f, -9.140944f, -6.027798f, -6.248255f, -7.805318f, -8.749095f, -9.593466f, -11.62735f, -13.86257f, -14.17952f, -12.52219f, -10.81471f, -10.55183f, -11.45351f, -11.90325f, -11.077f, -10.07126f, -10.2757f, -11.79492f, -13.55045f, -13.92783f, -12.52379f, -10.77155f, -9.859552f, -9.592004f, -9.607644f, -10.12752f, -11.53824f, -13.73212f, -15.36297f, -15.69801f, -15.61561f, -15.79118f, -15.51499f, -14.32775f, -13.22842f, -13.88546f, -16.42685f, -18.35939f, -17.48323f, -15.18956f, -14.45904f, -15.99689f, -17.7229f, -17.42459f, -15.94881f, -16.04564f, -17.52537f, -17.04282f, -13.59875f, -11.1125f, -14.38626f, -22.32763f, -26.96945f, -22.1863f, -11.92334f, -6.117809f, -9.635714f, -17.42232f, -20.48789f, -16.12787f, -10.24684f, -9.106511f, -12.63703f, -16.72128f, -18.4578f, -18.72812f, -19.90653f, -21.76285f, -22.09645f, -20.44485f, -18.60633f, -18.57506f, -20.43059f, -21.60237f, -19.87599f, -16.81057f, -15.72803f, -17.81859f, -20.90417f, -21.55083f, -19.15196f, -16.7648f, -16.28726f, -16.43765f, -15.94713f, -15.93191f, -18.57007f, -23.68078f, -27.26384f, -25.92367f, -21.34984f, -18.00949f, -18.20439f, -20.45751f, -21.23483f, -18.97578f, -16.22767f, -16.17118f, -19.30762f, -23.47157f, -25.51506f, -24.49408f, -22.7874f, -22.29887f, -22.43847f, -22.19676f, -21.65861f, -22.00154f, -23.87976f, -25.39904f, -24.37802f, -21.64056f, -19.765f, -20.26779f, -22.58255f, -24.16133f, -23.13697f, -20.97727f, -20.47639f, -22.86363f, -26.74349f, -28.63684f, -26.81259f, -23.79326f, -22.85713f, -24.52536f, -27.10987f, -28.65575f, -28.77629f, -28.63893f, -28.48295f, -27.83693f, -27.17976f, -26.54673f, -25.06667f, -23.02054f, -21.95849f, -23.39938f, -27.0518f, -29.64081f, -28.54408f, -25.5379f, -24.18852f, -25.65526f, -28.21342f, -29.09681f, -27.69411f, -26.2238f, -26.05084f, -26.24f }, false);

              var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/Sampling_Up.ds");

              Sampling s = new Sampling();
              s.L = 3;
              s.M = 0;
              s.InputSignal = sig1;
              s.Run();
            Console.WriteLine(expectedOutput.SamplesIndices[expectedOutput.SamplesIndices.Count - 1]);
            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, s.OutputSignal.Samples));

          }


          [TestMethod]
          public void SamplingTestcase3()
          {
              var sig1 = UnitTestUtitlities.LoadSignal("TestingSignals/ecg400.ds");
              //Signal expectedOutput = new Signal(new List<float> { 0.04935597f, 0.03582422f, -0.02900381f, -0.04522169f, 0.05184601f, 0.1255209f, -0.001719322f, -0.2043707f, -0.09897309f, 0.2367838f, 0.2545973f, -0.2353386f, -0.4766119f, 0.08515248f, 0.6905652f, 0.1771214f, -0.8782623f, -0.699229f, 0.8781519f, 1.337329f, -0.6969886f, -2.376413f, 0.07745922f, 4.357257f, 1.594387f, -14.3014f, -38.02985f, -56.46724f, -61.89058f, -59.33875f, -58.66491f, -60.50377f, -53.94313f, -30.46261f, 2.110735f, 24.20448f, 24.79782f, 13.99615f, 11.74291f, 25.34661f, 43.34904f, 52.14274f, 53.33802f, 59.45892f, 76.21174f, 93.47478f, 97.00232f, 80.83624f, 50.23798f, 13.12294f, -23.05033f, -50.20428f, -62.09123f, -60.98201f, -57.91241f, -62.50961f, -73.13195f, -80.61875f, -81.35406f, -81.46822f, -85.93925f, -90.62701f, -93.51012f, -108.1543f, -145.0127f, -167.1735f, -81.90253f, 188.6325f, 610.7092f, 1025.794f, 1254.67f, 1222.431f, 986.7632f, 664.4578f, 352.9906f, 112.0134f, -24.85076f, -56.95606f, -28.0595f, -0.4777393f, -5.09696f, -25.39589f, -33.01688f, -25.28635f, -19.70339f, -24.35402f, -29.27894f, -24.57376f, -13.21718f, -2.901191f, 5.282397f, 14.54381f, 24.64807f, 32.35292f, 37.76895f, 44.80913f, 55.76254f, 67.96383f, 78.19691f, 86.01188f, 94.68613f, 106.4128f, 121.7119f, 139.2611f, 157.4802f, 175.3911f, 192.6524f, 209.5684f, 227.6781f, 250.1949f, 279.8622f, 315.7053f, 352.7634f, 386.6242f, 417.8995f, 450.9789f, 488.1772f, 526.7774f, 562.1622f, 592.1934f, 617.5209f, 639.1459f, 656.9662f, 669.7983f, 674.4921f, 665.373f, 637.0524f, 589.5748f, 529.3881f, 464.2987f, 398.0663f, 330.9666f, 264.5164f, 203.031f, 150.3595f, 106.7144f, 70.27243f, 40.47674f, 18.21132f, 2.89525f, -8.636391f, -19.37697f, -29.13713f, -35.47456f, -37.37148f, -36.77388f, -36.31945f, -36.82293f, -37.71358f, -38.90202f, -40.73065f, -42.20434f, -41.08448f, -36.64609f, -31.80475f, -30.81346f, -34.80519f, -40.34755f, -42.67441f, -39.94838f, -34.31832f, -29.66065f, -28.57597f, -30.9553f, -34.37061f, -35.85893f, -34.07624f, -30.36287f, -27.71854f, -28.19889f, -31.16715f, -34.10726f, -35.30453f, -35.51051f, -36.85515f, -40.19897f, -44.0612f, -46.47184f, -47.15149f, -47.27876f, -47.62642f, -47.5732f, -46.45175f, -44.55898f, -42.58434f, -40.7933f, -39.48914f, -39.80472f, -42.55517f, -46.69371f, -49.61951f, -49.65982f, -47.67558f, -45.86741f, -45.79141f, -47.77131f, -51.25396f, -54.86567f, -56.48513f, -54.81526f, -51.17987f, -48.80346f, -49.87115f, -53.52447f, -57.23749f, -59.33216f, -59.76602f, -58.79517f, -56.52802f, -53.96861f, -53.10315f, -54.85345f, -57.37621f, -57.8222f, -55.83087f, -54.15743f, -55.24473f, -58.38039f, -60.83611f, -61.27962f, -60.45955f, -59.37889f, -58.24046f, -57.41266f, -57.85674f, -59.52188f, -60.44688f, -59.37124f, -58.40195f, -61.31201f, -68.20588f, -74.01506f, -74.00559f, -69.45586f, -65.88456f, -65.72325f, -66.0248f, -64.38752f, -63.18903f, -63.94539f, -59.83867f, -41.19146f, -10.50528f, 14.17393f, 17.53741f, 6.113317f, 1.773079f, 15.77031f, 36.84317f, 48.00421f, 48.91478f, 53.46922f, 69.48209f, 87.0655f, 91.25474f, 76.23431f, 47.73796f, 13.20506f, -21.78867f, -51.28127f, -69.52331f, -76.3833f, -78.68233f, -83.07444f, -89.05907f, -92.02783f, -91.62331f, -92.58773f, -96.22176f, -97.53638f, -98.45948f, -117.2843f, -164.0148f, -194.4269f, -105.7436f, 184.8105f, 637.125f, 1076.427f, 1308.13f, 1256.082f, 993.475f, 656.4408f, 348.5555f, 118.6293f, -14.11941f, -51.91408f, -29.83974f, -2.703591f, -3.510971f, -22.61179f, -33.47702f, -28.67505f, -21.18633f, -19.72914f, -18.12501f, -9.462137f, 1.887785f, 7.569905f, 7.418962f, 8.081479f, 13.27588f, 20.78342f, 28.02861f, 35.39502f, 43.67921f, 51.4653f, 58.34773f, 65.99385f, 77.16576f, 91.00701f, 104.8783f, 117.4625f, 130.3203f, 145.6096f, 163.9472f, 184.8771f, 207.9033f, 232.586f, 258.2928f, 284.9218f, 313.7813f, 346.7285f, 383.97f, 423.3263f, 461.5267f, 496.0872f, 526.6648f, 554.8615f, 582.6595f, 609.5477f, 631.075f, 641.6963f, 639.2783f, 626.0948f, 604.458f, 572.5743f, 526.7817f, 467.1419f, 398.8662f, 327.869f, 257.4849f, 190.6473f, 132.6601f, 88.3142f, 56.71716f, 31.71901f, 8.883568f, -9.808756f, -19.83329f, -21.19793f, -20.04737f, -22.59361f, -29.32694f, -35.64504f, -37.24862f, -34.20449f, -30.38223f, -29.5808f, -32.28074f, -35.64001f, -36.65173f, -34.98153f, -33.02033f, -33.13318f, -35.87831f, -40.22409f, -44.71315f, -47.87998f, -48.67752f, -47.74734f, -47.57158f, -49.71154f, -52.12989f, -50.99457f, -45.68097f, -40.78946f, -41.95644f, -49.92365f, -59.32f, -63.58403f, -60.61681f, -54.35157f, -51.09153f, -53.93509f, -60.16642f, -63.92276f, -62.37008f, -5f }, false);
              var expectedOutput = UnitTestUtitlities.LoadSignal("TestingSignals/Sampling_Down.ds");

              

              Sampling s = new Sampling();
              s.L = 0;
              s.M = 2;
              s.InputSignal = sig1;
              s.Run();
            Console.WriteLine(expectedOutput.SamplesIndices[expectedOutput.SamplesIndices.Count - 1]);

            Assert.IsTrue(UnitTestUtitlities.SignalsSamplesAreEqual(expectedOutput.Samples, s.OutputSignal.Samples));
          }
    }
}