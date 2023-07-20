using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class Config
    {
        [JsonProperty("answers_filename")]
        public string answers_filename = "Answers.txt";
        [JsonProperty("inputs_filename")]
        public string inputs_filename = "Data.txt";
        [JsonProperty("answerstest_filename")]
        public string answerstest_filename = "AnswersTest.txt";
        [JsonProperty("inputstest_filename")]
        public string inputstest_filename = "DataTest.txt";

        [JsonProperty("inputs")]
        public int Inputs = 13;
        [JsonProperty("outputs")]
        public int Outputs = 1;
        [JsonProperty("hiddenlayers")]
        public int[] HiddenLayers = {16 , 8 , 4 };
        [JsonProperty("lr")]
        public double LR = 0.01;
        [JsonProperty("acelleration")]
        public double Acelleration = 0.5;
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

        //public void txtToConfig(string info)
        //{
        //    var sep_info = info.Split(Environment.NewLine.ToCharArray()).ToList();
        //    var filtered_info = new List<string>();
        //    foreach (string row in sep_info) {
        //        var val = row.Split(' ');
        //        if (val.Length > 1) { filtered_info.Add(val[2]); }
                
        //    }
        //    Inputs = int.Parse(filtered_info[0]);
        //    Outputs = int.Parse(filtered_info[1]);
        //    LR = double.Parse(filtered_info[2]);
        //    Acelleration = double.Parse(filtered_info[3]);
        //    answers_filename = filtered_info[4];
        //    inputs_filename = filtered_info[5];
        //    answerstest_filename = filtered_info[6];
        //    inputstest_filename = filtered_info[7];
        //    HiddenLayers = filtered_info[8].Split(',').Select(v => Convert.ToInt32(v)).ToArray(); 
        //}

    }
}
