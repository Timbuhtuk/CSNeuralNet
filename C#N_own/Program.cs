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
        static void Main(string[] args)
        {
            #region params

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; // создание переменной для хранения директории проекта     
            Stopwatch stopwatch = new Stopwatch(); // переменная таймера
            GetData data = new GetData(); // создание обьекта для чткния дат сетов


            Random rng = new Random();

            
            Net net = new Net(data.Inputs[0].Length, data.Answers[0].Length,0.001,0.1, 64,10);
            Console.WriteLine(net.Load(projectDirectory + "\\Weights.txt"));

            Console.WriteLine(net.Load(projectDirectory + $"{Path.DirectorySeparatorChar}Weights.txt"));

            #endregion

            //net.Test2(data.InputsTest, data.Answers); //прогон тестовой выборки


            #region Threads Demo
            //stopwatch.Start();
            //var af = net.Learn(data.Inputs, data.Answers, 2, 2000);
            //Console.WriteLine("1 Thread -> Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            //stopwatch.Restart();
            //var aff = net.LearnThreding(data.Inputs, data.Answers, 2, 2000).Result;
            //Console.WriteLine("many Threads -> Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            //stopwatch.Reset();
            #endregion


            double[] max = { 0 }, min = { 1 },a = { 0 }, prev = { 0 };//вспомогательные переменные для информативного вывода в консоль

            #region Loop
            var q = 0;//сыетчик итераций
            while (net.Test(data.InputsTest, data.AnswersTest)[0] >= 0.04)//обучение идет до момента достижения порогового значения ошибки(в данном случае критерием качества взята среднеквадратичная ошибка)
            {
                # region Shuflle 

                //int n = data.Inputs.Count;
                //while (n > 1)
                //{
                //    n--;
                //    int k = rng.Next(n + 1);

                //    var value = data.Inputs[k];
                //    var value2 = data.Answers[k];

                //    data.Answers[k] = data.Answers[n];
                //    data.Inputs[k] = data.Inputs[n];

                //    data.Inputs[n] = value;
                //    data.Answers[n] = value2;
                //}
                #endregion //алгоритм перемешивания выборки(если есть неоходимость)


                Console.ForegroundColor = ConsoleColor.White;//окрашивание текста в консоли белым

                Console.WriteLine("<==========================>");
                Console.WriteLine("Round - " + q);
                q++;//вывод текущей итерации в консоль

                stopwatch.Start();//таймер измеряющий время затраченое на итерацию обучения
                a = net.LearnThreding(data.Inputs, data.Answers, 10, 2000).Result;//вызов метода обучения с параметрами:
                //массив входов обучающей выборки Inputs из класса GetData
                //массив выходов обучающей выборки Answers из класса GetData
                //кол-во эпох на итерацию 10 
                //размер батча 2000(позваляет запускать эпоху деля датасет на чати, в случае мультипоточной версии метода для каждого батча создается отдельный поток)
                Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();




                Console.WriteLine("Test Error[q] - " + net.Test3(data.InputsTest, data.AnswersTest)[0]);
                Console.WriteLine("FeedForward[0] - " + net.FeedForward(data.InputsTest[0]).Outputs[0] + " - expected: " + data.AnswersTest[0][0]);
                Console.WriteLine("FeedForward[1] - " + net.FeedForward(data.InputsTest[1]).Outputs[0] + " - expected: " + data.AnswersTest[1][0]);
                Console.WriteLine("FeedForward[2] - " + net.FeedForward(data.InputsTest[2]).Outputs[0] + " - expected: " + data.AnswersTest[2][0]);
                //тесты повышающие информативность вывода в консоли

                #region Console color
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
                #endregion 
                //окрашивание текста в консоли в зависимости от успехов обучения

                Console.WriteLine("error = " + a[0]);
                Console.WriteLine("        " + (prev[0] - a[0])+"\n");
                prev = a;
                //сравнение текущей итерации с предидущей

                net.Save(projectDirectory + "\\Weights.txt");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Saved");
            }

            Console.ReadKey();
            #endregion
        }
        
    }


}
