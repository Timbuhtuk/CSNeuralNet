using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class Config
    {
        public int Inputs = 13;
        public int Outputs = 1;
        public int[] HiddenLayers = {16 , 8 , 4 };
        public double LR = 0.01;
        public double Acelleration = 0.5;
        public Config() { }
        public Config(int Inputs,int Outputs,double LR,double Acelleration,params int[] HiddenLayers) 
        {
            this.Acelleration = Acelleration;
            this.Inputs = Inputs;
            this.Outputs = Outputs;
            this.HiddenLayers = HiddenLayers;
            this.LR = LR;

        }
        public Config(GetData data, double LR, double Acelleration, params int[] HiddenLayers)
        {
            this.Acelleration = Acelleration;
            this.Inputs = data.Inputs[0].Length;
            this.Outputs = data.Answers[0].Length;
            this.HiddenLayers = HiddenLayers;
            this.LR = LR;

        }
        public Config(GetData data)
        {
            this.Inputs = data.Inputs[0].Length;
            this.Outputs = data.Answers[0].Length;
        }

    }
}
