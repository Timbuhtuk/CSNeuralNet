using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class GetData
    {
        public List<double> Answers { get; private set; }
        public List<double[]> Inputs { get; private set; }

        public List<double> AnswersTest { get; private set; }
        public List<double[]> InputsTest { get; private set; }

        public GetData()
        {
            UpdateData();
            UpdateDataTest();   
        }
        public void UpdateData() {
            Answers = new List<double>();
            Inputs = new List<double[]>();

            using (var sr = new StreamReader("C:\\Users\\timpf\\source\\repos\\C#\\C#N\\C#N\\Data.txt"))
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
            using (var sr = new StreamReader("C:\\Users\\timpf\\source\\repos\\C#\\C#N\\C#N\\Answers.txt"))
            {
                while (!sr.EndOfStream)
                {
                    try { 
                    var row = sr.ReadLine();
                    Answers.Add(Convert.ToDouble(row));
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
            AnswersTest = new List<double>();
            InputsTest = new List<double[]>();

            using (var sr = new StreamReader("C:\\Users\\timpf\\source\\repos\\C#\\C#N\\C#N\\DataTest.txt"))
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
            using (var sr = new StreamReader("C:\\Users\\timpf\\source\\repos\\C#\\C#N\\C#N\\AnswersTest.txt"))
            {
                while (!sr.EndOfStream)
                {
                    try
                    {
                        var row = sr.ReadLine();
                        AnswersTest.Add(Convert.ToDouble(row));
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
            using (var sr = new StreamReader("C:\\Users\\timpf\\source\\repos\\C#\\C#N\\C#N\\DataActual.txt"))
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
