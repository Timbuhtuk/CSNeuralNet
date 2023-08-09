using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;

namespace C_N_own
{
    public class GetData
    {
        public List<double[]> Answers { get { return answers; } private set { if (value != null) { answers = value; } } }
        public List<double[]> Inputs { get { return inputs; } private set { if (value != null) { inputs = value; } } }
        public List<double[]> AnswersTest { get { return answersTest; } private set { if (value != null) { answersTest = value; } } }
        public List<double[]> InputsTest { get { return inputsTest; } private set { if (value != null) { inputsTest = value; } } }

        private List<double[]> answers; // переменная для хранения ответов к обучающей выборке датасета 
        private List<double[]> inputs; // переменная для хранения входов из обучающей выборки датасета
        private List<double[]> answersTest; // переменная для хранения ответов к тестовой выборке датасета 
        private List<double[]> inputsTest; // переменная для хранения входов из тестовой выборке датасета 
        public string answers_filename = "Answers.txt";
        public string inputs_filename = "Data.txt";
        public string answerstest_filename = "AnswersTest.txt";
        public string inputstest_filename = "DataTest.txt";


        static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; // рабочая директория




        public GetData(Config config) // конструктор заполняющий все внутрение переменные
        {
            this.answers_filename = config.answers_filename;
            this.inputs_filename = config.inputs_filename;
            this.answerstest_filename = config.answerstest_filename;
            this.inputstest_filename = config.inputstest_filename;

            UpdateData(ref inputs, inputs_filename);
            UpdateData(ref answers, answers_filename);
            UpdateData(ref inputsTest, inputstest_filename);
            UpdateData(ref answersTest, answerstest_filename);
            Inputs = DataFormat.ToBinary(Inputs); // в конструкторе данные сразу приводятся к нужному виду с помощью класса DataFormat
            InputsTest = DataFormat.ToBinary(InputsTest);
        }
        private List<List<double[]>> GetScaledWeights(Net n){
            return DataFormat.Scaling(n.GetWeights());
        }
        //public string GetScaledStringWeights(Net n)
        //{
        //    return DataFormat.WeightsToString(GetScaledWeights(n));
        //}
        public string GetScaledStringWeights(Net n)
        {
            return JsonConvert.SerializeObject(GetScaledWeights(n));
        }
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
