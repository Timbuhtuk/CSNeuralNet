using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class Config
    {

        public string answers_filename = "Data.txt";
        public string inputs_filename = "Answers.txt";
        public string answerstest_filename = "DataTest.txt";
        public string inputstest_filename = "AnswersTest.txt";
        
        
        public int Inputs = 13;
        public int Outputs = 1;
        public int[] HiddenLayers = {16 , 8 , 4 };
        public double LR = 0.01;
        public double Acelleration = 0.5;
        public Config(string str) {
            StringToConfig(str);
        }
        public Config(
            int Inputs,
            int Outputs,
            double LR,
            double Acelleration,
            string answers_filename,
            string inputs_filename,
            string answerstest_filename,
            string inputstest_filename,
            params int[] HiddenLayers
            ) 
        {
            this.Acelleration = Acelleration;
            this.Inputs = Inputs;
            this.Outputs = Outputs;
            this.HiddenLayers = HiddenLayers;
            this.LR = LR;

        }

        public void StringToConfig(string info)
        {
            var sep_info = info.Split('\n').ToList();
            var filtered_info = new List<string>();
            foreach (string row in sep_info) { 
                filtered_info.Add(row.Split(' ')[2]);
            }
            Inputs = int.Parse(filtered_info[0]);
            Outputs = int.Parse(filtered_info[1]);
            LR = double.Parse(filtered_info[2]);
            Acelleration = int.Parse(filtered_info[3]);
            string answers_filename = filtered_info[4];
            string inputs_filename = filtered_info[5];
            string answerstest_filename = filtered_info[6];
            string inputstest_filename = filtered_info[7];
            HiddenLayers = sep_info.GetRange(8, sep_info.Count - 8).Select(v => Convert.ToInt32(v)).ToArray(); 
        }

    }
}
