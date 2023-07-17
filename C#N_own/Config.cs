using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class Config
    {

        public string answers_filename = "Answers.txt";
        public string inputs_filename = "Data.txt";
        public string answerstest_filename = "AnswersTest.txt";
        public string inputstest_filename = "DataTest.txt";
        
        
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
            var sep_info = info.Split(Environment.NewLine.ToCharArray()).ToList();
            var filtered_info = new List<string>();
            foreach (string row in sep_info) {
                var val = row.Split(' ');
                if (val.Length > 1) { filtered_info.Add(val[2]); }
                
            }
            Inputs = int.Parse(filtered_info[0]);
            Outputs = int.Parse(filtered_info[1]);
            LR = double.Parse(filtered_info[2]);
            Acelleration = double.Parse(filtered_info[3]);
            answers_filename = filtered_info[4];
            inputs_filename = filtered_info[5];
            answerstest_filename = filtered_info[6];
            inputstest_filename = filtered_info[7];
            HiddenLayers = filtered_info.GetRange(8, filtered_info.Count - 8).Select(v => Convert.ToInt32(v)).ToArray(); 
        }

    }
}
