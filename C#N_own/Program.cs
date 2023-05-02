using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Net net = new Net(13, 1, 1,9, 5); 
            GetData data = new GetData();



            Stopwatch stopwatch = new Stopwatch();
            List<double[]> Inputs = DataFormat.ToBinary(data.Inputs);

            Random rng = new Random();
            double a, prev = 0, max = 0, min = 1;

            //200 Rounds
            for (int q = 0; q < 200; q++)
            {
                //Shuflle
                int n = Inputs.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);

                    var value = new double[13];
                    value = Inputs[k];
                    var value2 = data.Answers[k];

                    data.Answers[k] = data.Answers[n];
                    Inputs[k] = Inputs[n];

                    Inputs[n] = value;
                    data.Answers[n] = value2;
                }

                //1 full DataSet Roll
                for (int e = 0; e < 10; e++)
                {
                   

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("<==========================>");
                    Console.WriteLine("Round - " + q + " Roll - " + e);

                    stopwatch.Start();
                    a = net.Learn(Inputs, data.Answers, 300, 250);
                    Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                    Console.WriteLine("Test Error - " + net.Test(data.InputsTest ,data.AnswersTest));

                    stopwatch.Reset();

                    if (a > prev && a > max)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        max = a;
                        // net.LR = 1;
                    }
                    else if (a > prev && a < max)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        // net.LR = 0.1;

                    }
                    else if (a < prev && a > min)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        // net.LR = 0.01;

                    }
                    else if (a < prev && a < min)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        min = a;
                       // net.LR = 0.001;

                    }
                    Console.WriteLine("error = " + a);
                    Console.WriteLine("        " + (prev - a));
                    prev = a;

                    Console.WriteLine("");

                }
                //net.Save();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Saved");
            }

            Console.ReadKey();
            
        }
    }
}
