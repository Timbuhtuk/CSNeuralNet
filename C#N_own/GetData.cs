using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace C_N_own
{
    public class GetData
    {
        public List<double[]> Answers { get { return answers; } private set { if (value != null) { answers = value; } } }
        public List<double[]> Inputs { get { return inputs; } private set { if (value != null) { inputs = value; } } }
        public List<double[]> AnswersTest { get { return answersTest; } private set { if (value != null) { answersTest = value; } } }
        public List<double[]> InputsTest { get { return inputsTest; } private set { if (value != null) { inputsTest = value; } } }
        public List<double[]> answers; // переменная для хранения ответов к обучающей выборке датасета 
        public List<double[]> inputs; // переменная для хранения входов из обучающей выборки датасета
        public List<double[]> answersTest; // переменная для хранения ответов к тестовой выборке датасета 
        public List<double[]> inputsTest; // переменная для хранения входов из тестовой выборке датасета 

        static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; //рабочая директория




        public GetData() // конструктор заполняющий все внутрение переменные
        {
            UpdateData(ref inputs, "Data.txt");
            UpdateData(ref answers, "Answers.txt");
            UpdateData(ref inputsTest, "DataTest.txt");
            UpdateData(ref answersTest, "AnswersTest.txt");
            Inputs = DataFormat.ToBinary(Inputs); // в конструкторе данные сразу приводятся к нужному виду с помощью класса DataFormat
            InputsTest = DataFormat.ToBinary(InputsTest);
        }
        public List<List<double[]>> GetScaledWeights(Net n){
            return DataFormat.Scaling(n.Weights);
}
        public void UpdateData() {
            Answers = new List<double[]>();// инициализация листа ответов обучающей выборки
            Inputs = new List<double[]>();// инициализация листа входов обучающей выборки

            using (var sr = new StreamReader(projectDirectory+"\\Data.txt"))
            {
                while (!sr.EndOfStream)// пока документ не закончится
                {
                    // помещаем в try catch потому что переменная row может равнятся null
                    try
                    { 
                        var row = sr.ReadLine();// читаем строку
                        if(row == null)
                        {
                            Console.WriteLine("Empty row in GetData.UpdateData()"); System.Environment.Exit(0);
                        }
                        else
                        {
                            var temp = row.Replace(".", ",").Split('/');// Phyton записывает float через . а C# читает float только через , так что заменяем все точки на запятые и применяем Split по знаку разделителю (данный код падает при использовании CSV файла, я не хочу это исправлять мне лень , может потом, но это не точно)
                            var data = temp.Select(v => Convert.ToDouble(v)).ToArray();// конвертация string в double
                            Inputs.Add(data);
                        }
                        
                }
                    catch {
                        Console.WriteLine("System.FormatException: Input string was not in a correct format"); System.Environment.Exit(0);
                    }
            }
            }
            using (var sr = new StreamReader(projectDirectory + $"{Path.DirectorySeparatorChar}Answers.txt"))
            {
                // помещаем в try catch потому что переменная row может равнятся null
                while (!sr.EndOfStream)
                {
                    try { 
                        var row = sr.ReadLine();// читаем строку
                        if (row.Length == 1)// Phyton записывал 1.0 как 1 , я это не исправлял а просто добавил этот if
                        {
                            double[] a = new double[1];
                            a[0] = Convert.ToDouble(row); 
                            Answers.Add(a);
                        }
                        else if (row.Length > 1)// 
                        {
                            var temp = row.Replace(".", ",").Split('/');// Phyton записывает float через . а C# читает float только через , так что заменяем все точки на запятые и применяем Split по знаку разделителю (данный код падает при использовании CSV файла, я не хочу это исправлять мне лень , может потом, но это не точно)
                            var data = temp.Select(v => Convert.ToDouble(v)).ToArray();// конвертация string в double
                            Answers.Add(data);
                        }

                    }
                    catch
                    {
                        Console.WriteLine("System.FormatException: Input string was not in a correct format"); System.Environment.Exit(0);
                    }
                }
            }
        }// метод читающий текстовые файлы Data.txt и Answers.txt и заполняющий массивы Inputs и Answers
        private void UpdateData(ref List<double[]> list,string file)
        {
            list = new List<double[]>();
           
            using (var sr = new StreamReader(projectDirectory + $"{Path.DirectorySeparatorChar}" + file))
            {
                // помещаем в try catch потому что переменная row может равнятся null
                while (!sr.EndOfStream)
                {
                    try
                    {
                        var row = sr.ReadLine();
                        if (row.Length == 1)
                        {
                            double[] a = new double[1];
                            a[0] = Convert.ToDouble(row);
                            list.Add(a);
                        }
                        else if (row.Length > 1)// 
                        {
                            var temp = row.Replace(".", ",").Split('/');// Phyton записывает float через . а C# читает float только через , так что заменяем все точки на запятые и применяем Split по знаку разделителю (данный код падает при использовании CSV файла, я не хочу это исправлять мне лень , может потом, но это не точно)
                            var data = temp.Select(v => Convert.ToDouble(v)).ToArray();// конвертация string в double
                            list.Add(data);
                        }

                    }
                    catch
                    {
                        Console.WriteLine("System.FormatException: Input string was not in a correct format"); System.Environment.Exit(0);
                    }
                }
            }
        }// метод читающий текстовые файлы и заполняющий массивы данными из файлов
        public void UpdateDataTest()
        {
            AnswersTest = new List<double[]>();
            InputsTest = new List<double[]>();

            using (var sr = new StreamReader(projectDirectory + $"{Path.DirectorySeparatorChar}DataTest.txt"))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        var row = sr.ReadLine();
                        var temp = row.Replace(".", ",").Split('/');
                        var text = temp.Select(v => Convert.ToDouble(v)).ToList();
                        var data = text.ToArray();
                        InputsTest.Add(data);
                    }
                    catch
                    {
                        Console.WriteLine("System.FormatException: Input string was not in a correct format"); System.Environment.Exit(0);
                    }
                }
            }
            using (var sr = new StreamReader(projectDirectory + $"{Path.DirectorySeparatorChar}AnswersTest.txt"))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        var row = sr.ReadLine();
                        if (row.Length == 1)
                        {
                            double[] a = new double[1];
                            a[0] = Convert.ToDouble(row);
                            AnswersTest.Add(a);
                        }
                        else if (row.Length > 1)
                        {
                            var temp = row.Replace(".", ",").Split('/');
                            var text = temp.Select(v => Convert.ToDouble(v)).ToList();
                            var data = text.ToArray();
                            AnswersTest.Add(data);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("System.FormatException: Input string was not in a correct format"); System.Environment.Exit(0);
                    }
                }
            }
        }// токой же метод как UpdateData() 1 в 1 только файлы другие, про повторное использование кода не слышал(нужно переделать)
        public List<double> GetDataActual()
        {
            var data = new List<double>();
            using (var sr = new StreamReader(projectDirectory + $"{Path.DirectorySeparatorChar}DataActual.txt"))
            {
                try { 
                var row = sr.ReadLine().Replace(".", ",").Split('/');
                data = row.Select(v => Convert.ToDouble(v)).ToList(); }
                catch {
                    Console.WriteLine("System.FormatException: Input string was not in a correct format"); System.Environment.Exit(0);
                }
            }

            return data;
        }// метод получающий актуальные коэфициенты с сайта csgorun
    }
}
