using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class Layer
    {
        public int PrevCount { get; private set; }
        public int Count { get; private set; }
        public List<double> WeightedSum { get; private set; }
        public List<double[]> Weights { get; private set; }
        public List<double> Outputs { get; private set; }
        public List<double> Inputs { get; private set; }
        public string Type { get; private set; }
        public List<double> Gradients { get; private set; }

        public Layer(int prevcount,int count,string type)
        {
            PrevCount = prevcount;
            Count = count;
            Type = type;
            Weights = new List<double[]>(Count);
            Gradients = new List<double>();
            for (int q = 0; q < Count; q++) {
                Gradients.Add(0.0);
            } 
            
            InitRandom();
        }
        public void InitRandom()
        {
            if (Type != "I") {
                Random rnd = new Random();
                for(int q = 0; q < Count; q++)
                {
                    Weights.Add(new double[PrevCount]);
                    for (int e = 0;e<PrevCount; e++)
                    {
                        Weights[q][e]=rnd.NextDouble()-0.5;
                    }
                }   
            }
            else {
                for (int q = 0; q < Count; q++)
                {
                    Weights.Add(new double[PrevCount]);
                    for (int e = 0; e < PrevCount; e++)
                    {
                        Weights[q][e] = 1;
                    }
                }
            }

            
        }
        public List<double> FeedForward(List<double> inputs) {

            Inputs = inputs;
                WeightedSum = new List<double>(Count);
            if(Type == "I") {
                
                for (int q = 0; q < Count; q++)
                {
                    WeightedSum.Add(inputs[q]);
                }
                Outputs = WeightedSum; }
            else {
                for (int q = 0; q < Count; q++)
                {
                    var sum = 0.0;
                    for (int e = 0; e < PrevCount; e++)
                    {
                        sum += Weights[q][e] * inputs[e];
                    }
                    WeightedSum.Add(sum);
                }
                Outputs = Activate(WeightedSum); }

            return Outputs;
        }
        public List<double> Activate(List<double> t) {
            var result = new List<double>();
            foreach(double val in t)
            {
                var a = 1 / (1 + Math.Pow(Math.E, -val));
                result.Add(a);
            }
            return result; 
        }
        public List<double> ActivateProd(List<double> h) {
            List<double> result = new List<double>(Count);
            foreach (double val in h)
            {
                var a = val * (1 - val);
                result.Add(a);
            }

            return result;
        }
        public void UpdateGradients(List<double> diffs) {
            for (int q = 0; q < Gradients.Count; q++)
            {
                var AP = ActivateProd(Outputs);
                Gradients[q] += diffs[q] * AP[q];
            }
        }
        public void UpdateWeights(double lr,int gradientsdel) {

            for(int q = 0;q < Gradients.Count; q++)
            {
                Gradients[q] /= gradientsdel;
            }

            for (int q = 0;q<Weights.Count ;q++) {
                for (int e = 0; e < Weights[q].Length; e++) {
                    Weights[q][e] = Weights[q][e] - lr*Gradients[q]*Inputs[e];
                }
            }

            Gradients = new List<double>();
            for (int q = 0; q < Count; q++)
            {
                Gradients.Add(0.0);
            }
        }
        public List<double> GetPrevLayerErrors()
        {
            var result = new List<double>(PrevCount);
            for(int q = 0;q<PrevCount; q++)
            {
                var error = 0.0;
                for(int e =0;e<Count; e++)
                {
                    error += Weights[e][q] * Gradients[e]; 
                }
                result.Add(error);
            }
            return result; 
        }
        public void SetWeights(List<double[]> weights)
        {
            Weights = weights;
        }
        public override string ToString()
        {
            var result = "";
            for (int q = 0;q<Outputs.Count ;q++)
            {
                result += Outputs[q];
                result += " ";
            }
            return result;
        }
    }
}
