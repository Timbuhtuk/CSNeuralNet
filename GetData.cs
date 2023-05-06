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
        public List<double[]> Answers { get; private set; }
        public List<double[]> Inputs { get; private set; }
        


        static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;


        public List<double[]> AnswersTest { get; private set; }
        public List<double[]> InputsTest { get; private set; }

        public GetData()
        {
            UpdateData();
            UpdateDataTest();
            Inputs = DataFormat.ToBinary(Inputs);
            InputsTest = DataFormat.ToBinary(InputsTest);
        }
        public void UpdateData() {
            Answers = new List<double[]>();
            Inputs = new List<double[]>();

            using (var sr = new StreamReader(projectDirectory+"\\Data.txt"))
            {
                while (!sr.EndOfStream)
                {
                    try { 
                    var row = sr.ReadLine();
                    var temp = row.Replace(".", ",").Split('/');
                    var text = temp.Select(v => Convert.ToDouble(v)).ToList();
                    var data = text.ToArray();
                    Inputs.Add(data);
                }
                catch {
                    Console.WriteLine("System.FormatException: Input string was not in a correct format"); System.Environment.Exit(0);
                    }
            }
            }
            using (var sr = new StreamReader(projectDirectory + "\\Answers.txt"))
            {
                while (!sr.EndOfStream)
                {
                    try { 
                        var row = sr.ReadLine();
                        if (row.Length == 1)
                        {
                            double[] a = new double[1];
                            a[0] = Convert.ToDouble(row); 
                            Answers.Add(a);
                        }
                        else if (row.Length > 1)
                        {
                            var temp = row.Replace(".", ",").Split('/');
                            var text = temp.Select(v => Convert.ToDouble(v)).ToList();
                            var data = text.ToArray();
                            Answers.Add(data);
                        }

                    }
                    catch
                    {
                        Console.WriteLine("System.FormatException: Input string was not in a correct format"); System.Environment.Exit(0);
                    }
                }
            }
        }
        public void UpdateDataTest()
        {
            AnswersTest = new List<double[]>();
            InputsTest = new List<double[]>();

            using (var sr = new StreamReader(projectDirectory + "\\DataTest.txt"))
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
            using (var sr = new StreamReader(projectDirectory + "\\AnswersTest.txt"))
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
        }
        public List<double> GetDataActual()
        {
            var data = new List<double>();
            using (var sr = new StreamReader(projectDirectory + "\\DataActual.txt"))
            {
                try { 
                var row = sr.ReadLine().Replace(".", ",").Split('/');
                data = row.Select(v => Convert.ToDouble(v)).ToList(); }
                catch {
                    Console.WriteLine("System.FormatException: Input string was not in a correct format"); System.Environment.Exit(0);
                }
            }

            return data;
        }
        
    }
}
