using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    internal class Program
    {

        
            //List<double[]> inputs = new List<double[]>();
            //double[] a1 = { 1, 0 };
            //double[] a2 = { 0, 0 };
            //double[] a3 = { 0, 1 };
            //double[] a4 = { 1, 1 };
            //inputs.Add(a1);
            //inputs.Add(a2);
            //inputs.Add(a3);
            //inputs.Add(a4);
            //List<double> ans = new List<double>();
            //double b1 =  1 ;
            //double b2 =  0 ;
            //double b3 =  1 ;
            //double b4 =  1 ;
            //ans.Add(b1);
            //ans.Add(b2);
            //ans.Add(b3);
            //ans.Add(b4);
            //Console.WriteLine(net.Learn(inputs,ans,10000,1));
            //Console.WriteLine(net.FeedForward(a2));
            //Console.ReadKey();
        static void Main(string[] args)
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            Stopwatch stopwatch = new Stopwatch();
            GetData data = new GetData();
           
            
            Random rng = new Random();

            
            Net net = new Net(data.Inputs[0].Length, data.Answers[0].Length,0.001,0.1, 64,10);
            Console.WriteLine(net.Load(projectDirectory + $"{Path.DirectorySeparatorChar}Weights.txt"));


            net.Test2(data.InputsTest, data.Answers);
            Console.ReadKey();

            //while (net.Test(data.InputsTest, data.AnswersTest) >= 0.20)
            //{
            //    net = new Net(13, 1, 0.1, 10, 5);
            //}

            double[] max = { 0 }, min = { 1 };
            double[] a, prev = { 0 };
            //200 Rounds
            var q = 0;
            while (net.Test(data.InputsTest, data.AnswersTest)[0] >= 0.04)
            {
                //Shuflle
                int n = data.Inputs.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);

                    var value = data.Inputs[k];
                    var value2 = data.Answers[k];

                    data.Answers[k] = data.Answers[n];
                    data.Inputs[k] = data.Inputs[n];

                    data.Inputs[n] = value;
                    data.Answers[n] = value2;
                }



                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("<==========================>");
                Console.WriteLine("Round - " + q);
                q++;

                stopwatch.Start();
                a = net.Learn(data.Inputs, data.Answers, 100, 200);
                Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();
                Console.WriteLine("Test Error[q] - " + net.Test3(data.InputsTest, data.AnswersTest)[0]);
                Console.WriteLine("FeedForward[0] - " + net.FeedForward(data.InputsTest[0]).Outputs[0]);
                Console.WriteLine("FeedForward[1] - " + net.FeedForward(data.InputsTest[1]).Outputs[0]);
                Console.WriteLine("FeedForward[2] - " + net.FeedForward(data.InputsTest[2]).Outputs[0]);


                if (a[0] > prev[0] && a[0] > max[0])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    max = a;
                    // net.LR = 1;
                }
                else if (a[0] > prev[0] && a[0] < max[0])
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    // net.LR = 0.1;

                }
                else if (a[0] < prev[0] && a[0] > min[0])
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    // net.LR = 0.01;

                }
                else if (a[0] < prev[0] && a[0] < min[0])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    min = a;
                    // net.LR = 0.001;

                }
                Console.WriteLine("error = " + a[0]);
                Console.WriteLine("        " + (prev[0] - a[0]));
                prev = a;

                Console.WriteLine("");


                net.Save(projectDirectory + $"{Path.DirectorySeparatorChar}Weights.txt");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Saved");
            }

            Console.ReadKey();

        }   
    }
            
    
}
