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
        static Config config = new Config(13, 1, 1, 0.1, 16,8,4);
        static public void RunAsync(int Q = 100,int Batch = 1000,int epoch = 100) {

            #region params


            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; // создание переменной для хранения директории проекта     
            Stopwatch stopwatch = new Stopwatch(); // переменная таймера
            GetData data = new GetData(); // создание обьекта для чткния дат сетов


            Random rng = new Random();

            Net net = new Net(data.Inputs[0].Length, data.Answers[0].Length,0.001,0.1, 10,10);



            // Console.WriteLine(net.Load(projectDirectory + "\\Weights.txt"));


             net.Load(projectDirectory + $"{Path.DirectorySeparatorChar}Weights.txt");


            #region Pipe Fucky Wucky
            //string s = string.Format("INIT:{0} {1} {2} {3}", data.Inputs[0].Length, 10, 10, data.Answers[0].Length);
            //NamedPipe.Write(s);




            List<List<double[]>> something = data.GetScaledWeights(net);

            for (int i = 0; i < something.Count; i++)
            {
                for (int j = 0; j < something[i].Count; j++)
                {
                    Console.WriteLine(something[i][j]);
                }


            }


            #endregion

            Net net = new Net(config);


            #endregion


            double[] max = { 0 }, min = { 1 }, a = { 0 }, prev = { 0 };//вспомогательные переменные для информативного вывода в консоль

            #region Loop
            var q = 0;//счетчик итераций
            while (q<Q)//обучение идет до момента достижения порогового значения ошибки(в данном случае критерием качества взята среднеквадратичная ошибка)
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


                a = net.LearnThreding(data.Inputs, data.Answers, epoch, Batch).Result;//вызов метода обучения с параметрами:
                //массив входов обучающей выборки Inputs из класса GetData
                //массив выходов обучающей выборки Answers из класса GetData
                //кол-во эпох на итерацию 10 
                //размер батча 2000(позваляет запускать эпоху деля датасет на чати, в случае мультипоточной версии метода для каждого батча создается отдельный поток)
                Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();



                #region Console Info
                Console.WriteLine("Test Error[q] - " + net.TestWithScaledFFs(data.InputsTest, data.AnswersTest)[0]);
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
                Console.WriteLine("        " + (prev[0] - a[0]) + "\n");
                prev = a;
                //сравнение текущей итерации с предидущей

                net.Save(projectDirectory + "\\Weights.txt");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Saved");
                #endregion
            }

            #endregion

        }
        static public void RunAsyncN(int Q = 100, int Batch = 1000, int epoch = 100)
        {

            #region params




            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; // создание переменной для хранения директории проекта
            Stopwatch stopwatch = new Stopwatch(); // переменная таймера
            GetData data = new GetData(); // создание обьекта для чткния дат сетов


            Random rng = new Random();


            Net net = new Net(config);
            Console.WriteLine(net.Load(projectDirectory + $"{Path.DirectorySeparatorChar}Weights.txt"));


            List<List<double[]>> weights = data.GetScaledWeights(net);

            Console.WriteLine(weights.Count());

            //Console.WriteLine("first data portion");
            //NamedPipe.Write($"INIT:{data.GetScaledStringWeights(net)}");
            Console.WriteLine("second data portion");
            NamedPipe.Write($"WEIGHTS:{data.GetScaledStringWeights(net)}");
            Console.WriteLine("done");




            /*
            NamedPipe.Write($"INIT:{data.Inputs[0].Length} 10 10 {data.Answers[0].Length}");

            for (int i = 0; i < weights.Count(); i++)
            {

                Console.Write("{ ");

                for (int j = 0; j < weights[i].Count()  && j < 10; j++)
                {

                    Console.Write("[ ");

                    for (int k = 0; k < weights[i][j].Count() && k < 10; k++)
                    {
                        NamedPipe.Write($"WEIGHT:{i} {j} {k} {weights[i][j][k]}");
                        Console.Write(weights[i][j][k]);
                        Console.Write(", ");
                    }

                    Console.Write(" ]");

                }

                Console.WriteLine(" }");

            }
            Console.WriteLine("Client connected.");

            while (true)
            {
                Console.WriteLine("Write a message: ");
                NamedPipe.Write(Console.ReadLine());
            }
            */




            #endregion


            double[] max = { 0 }, min = { 1 }, a = { 0 }, prev = { 0 };//вспомогательные переменные для информативного вывода в консоль

            #region Loop
            var q = 0;//счетчик итераций
            while (q < Q)//обучение идет до момента достижения порогового значения ошибки(в данном случае критерием качества взята среднеквадратичная ошибка)
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

                
                q++;//вывод текущей итерации в консоль

                stopwatch.Start();//таймер измеряющий время затраченое на итерацию обучения


                a = net.LearnThreding(data.Inputs, data.Answers, epoch, Batch).Result;//вызов метода обучения с параметрами:
                                                                                      //массив входов обучающей выборки Inputs из класса GetData
                                                                                      //массив выходов обучающей выборки Answers из класса GetData
                                                                                      //кол-во эпох на итерацию 10 
                                                                                      //размер батча 2000(позваляет запускать эпоху деля датасет на чати, в случае мультипоточной версии метода для каждого батча создается отдельный поток)


                if (q % 101 == 100)
                {
                    Console.WriteLine("<==========================>");
                    Console.WriteLine("Round - " + q);
                    Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                    stopwatch.Reset();
                    #region Console Info

                    Console.WriteLine("Test Error[q] - " + net.TestWithScaledFFs(data.InputsTest, data.AnswersTest)[0]);
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
                    Console.WriteLine("        " + (prev[0] - a[0]) + "\n");
                    prev = a;
                    //сравнение текущей итерации с предидущей

                    net.Save(projectDirectory + "\\Weights.txt");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Saved");
                    #endregion

                }


                #endregion
            }
                    net.Save(projectDirectory + "\\Weights.txt");
                                    Console.WriteLine("Saved");

                Console.ReadKey();
        }
        static public void Run(int Q = 100, int Batch = 1000, int epoch = 100)
        {

            #region params

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; // создание переменной для хранения директории проекта     
            Stopwatch stopwatch = new Stopwatch(); // переменная таймера
            GetData data = new GetData(); // создание обьекта для чтения дата сетов


            Random rng = new Random();


            Net net = new Net(config);

            Console.WriteLine(net.Load(projectDirectory + $"{Path.DirectorySeparatorChar}Weights.txt"));

            #endregion
            //net.Test2(data.InputsTest, data.Answers); //прогон тестовой выборки


            double[] max = { 0 }, min = { 1 }, a = { 0 }, prev = { 0 };//вспомогательные переменные для информативного вывода в консоль

            #region Loop
            var q = 0;//счетчик итераций
            while (q<Q)//обучение идет до момента достижения порогового значения ошибки(в данном случае критерием качества взята среднеквадратичная ошибка)
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
                a = net.Learn(data.Inputs, data.Answers, epoch, Batch);//вызов метода обучения с параметрами:
                //массив входов обучающей выборки Inputs из класса GetData
                //массив выходов обучающей выборки Answers из класса GetData
                //кол-во эпох на итерацию 10 
                //размер батча 2000(позваляет запускать эпоху деля датасет на чати, в случае мультипоточной версии метода для каждого батча создается отдельный поток)
                Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();


                #region Console Info

                Console.WriteLine("Test Error[q] - " + net.TestWithScaledFFs(data.InputsTest, data.AnswersTest)[0]);
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
                Console.WriteLine("        " + (prev[0] - a[0]) + "\n");
                prev = a;
                //сравнение текущей итерации с предидущей

                net.Save(projectDirectory + "\\Weights.txt");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Saved");
                #endregion
            }

            
            #endregion

        }
        static public void ThreadsDemo() {

            #region params

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; // создание переменной для хранения директории проекта     
            Stopwatch stopwatch = new Stopwatch(); // переменная таймера
            GetData data = new GetData(); // создание обьекта для чткния дат сетов


            Random rng = new Random();


            Net net = new Net(config);
            Console.WriteLine(net.Load(projectDirectory + "\\Weights.txt"));

            Console.WriteLine(net.Load(projectDirectory + $"{Path.DirectorySeparatorChar}Weights.txt"));

            #endregion
            //net.Test2(data.InputsTest, data.Answers); //прогон тестовой выборки


            #region Threads Demo
            stopwatch.Start();
            var af = net.Learn(data.Inputs, data.Answers, 1, 1000);
            Console.WriteLine("1 Thread -> Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            var aff = net.LearnThreding(data.Inputs, data.Answers, 1, 1000).Result;
            Console.WriteLine("many Threads -> Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            #endregion
        }
        static void Main(string[] args)
        {

            RunAsync(100, 2000, 200);



            Console.ReadKey();
        }

    }


}
/*
Баги:
 - веса обновляются только при изменеии размера окна
 - при передаче WEIGHT: пробел все ламает

Как использовать:
 - чтобы инициализировать, нужно передать через NamedPipe.Write строку "INIT:<кол. нейр.> <кол. нейр.> <кол. нейр.> ..." (без угловых скобок)
 - чтобы поменять цвет веса, через NamedPipe.Write строку "WEIGHT:<номер слоя> <номер нейрона> <номер веса> <значение от 0. до 1.>"
 - пример: "WEIGHT:0 0 0 0.5" ("WEIGHT:<пробел>0 0 0 0.5" все ломает)
 - в Program.cs я уже это реализовал, но количество слоев некорректное
*/
