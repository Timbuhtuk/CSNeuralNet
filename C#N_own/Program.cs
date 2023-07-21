using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace C_N_own
{

    internal class Program
    {

        static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; // создание переменной для хранения директории проекта 

        static Config config = new Config(13, 1, 1, 0.1, "Data.txt", "Answers.txt", "DataTest.txt", "AnswersTest.txt", 16,8,4);


        static async public Task<double[]> GetActualCoefs(string url,int count) { 
            HttpClient httpClient = new HttpClient();
            try
            {
                List<double> coefs= new List<double>();
                var httpResponseMessage = await httpClient.GetAsync(url);
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                //Console.WriteLine(jsonResponse);
                CSGORUN CSGORUN = JsonConvert.DeserializeObject<CSGORUN>(jsonResponse);
                for (int q = 0; q < count; q++) {
                    coefs.Add(CSGORUN.data.game.history[q].crash);
                }
                return coefs.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally {
                httpClient.Dispose();

            }
        }
        static public void RunMultiThread(int Q = 100,int Batch = 1000,int epoch = 100) {

            #region params

                
            Stopwatch stopwatch = new Stopwatch(); // переменная таймера
            GetData data = new GetData(config); // создание обьекта для чткния дат сетов


            Random rng = new Random();


            Net net = new Net(config);

            Console.WriteLine(net.Load(projectDirectory + $"{Path.DirectorySeparatorChar}Weights.txt"));

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


                a = net.LearnWithThreding(data.Inputs, data.Answers, epoch, Batch).Result;//вызов метода обучения с параметрами:
                //массив входов обучающей выборки Inputs из класса GetData
                //массив выходов обучающей выборки Answers из класса GetData
                //кол-во эпох на итерацию 10 
                //размер батча 2000(позваляет запускать эпоху деля датасет на чати, в случае мультипоточной версии метода для каждого батча создается отдельный поток)
                Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();



                #region Console Info

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
        static public void RunMultiThreadN(int Q = 100, int Batch = 1000, int epoch = 100)
        {

            #region params

              
            Stopwatch stopwatch = new Stopwatch(); // переменная таймера
            GetData data = new GetData(config); // создание обьекта для чткния дат сетов


            Random rng = new Random();


            Net net = new Net(config);

            Console.WriteLine(net.Load(projectDirectory + $"{Path.DirectorySeparatorChar}Weights.txt"));

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


                a = net.LearnWithThreding(data.Inputs, data.Answers, epoch, Batch).Result;//вызов метода обучения с параметрами:
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
        static public void SimpleRun(int Q = 100, int Batch = 1000, int epoch = 100)
        {

            #region params

            
            Stopwatch stopwatch = new Stopwatch(); // переменная таймера
            GetData data = new GetData(config); // создание обьекта для чтения дата сетов


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

               
            Stopwatch stopwatch = new Stopwatch(); // переменная таймера
            GetData data = new GetData(config); // создание обьекта для чткния дат сетов


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
            var aff = net.LearnWithThreding(data.Inputs, data.Answers, 1, 1000).Result;
            Console.WriteLine("many Threads -> Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            #endregion
        }
        static void Initialization() {
            using (var sr = new StreamReader(projectDirectory + $"{Path.DirectorySeparatorChar}" + "Config.txt"))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        var str = sr.ReadToEnd();
                        config = JsonConvert.DeserializeObject<Config>(str);    

                    }
                    catch(Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                    }
                }
            }
        } // метод читает файл конфигурации и обновляет данные обьекта config
        static private void Test()
        {
            #region params


            Stopwatch stopwatch = new Stopwatch(); // переменная таймера
            GetData data = new GetData(config); // создание обьекта для чткния дат сетов


            Random rng = new Random();


            Net net = new Net(config);

            Console.WriteLine(net.Load(projectDirectory + $"{Path.DirectorySeparatorChar}Weights.txt"));

            var str = data.GetScaledStringWeights(net);
            Console.ReadKey();

            #endregion
        }
        static void Main(string[] args)
        {
            Initialization();

            GetActualCoefs("https://api.csgorun.io/current-state?montaznayaPena=null",13);
           Test();

            Console.ReadKey();
        }

    }


}
