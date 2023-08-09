//Copyright(c) 2023, Rudenko Artur, Pankovskyi Timofii
//All rights reserved.

//This source code is licensed under the BSD-style license found in the
//LICENSE file in the root directory of this source tree. 

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
        public int inputs = 13;
        [JsonProperty("outputs")]
        public int outputs = 1;
        [JsonProperty("hiddenlayers")]
        public int[] hiddenlayers = {16 , 8 , 4 };
        [JsonProperty("lr")]
        public double lr = 0.01;
        [JsonProperty("acelleration")]
        public double acelleration = 0.5;
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
            this.acelleration = Acelleration;
            this.inputs = Inputs;
            this.outputs = Outputs;
            this.hiddenlayers = HiddenLayers;
            this.lr = LR;
            this.answers_filename = answers_filename;
            this.inputs_filename = inputs_filename;
            this.answerstest_filename = answerstest_filename;
            this.inputstest_filename = inputstest_filename;

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
