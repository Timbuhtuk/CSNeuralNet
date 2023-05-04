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
        public List<double[]> DeltaWeights { get; private set; }
        public List<double[]> PrevDeltaWeights { get; private set; }

        public Layer(int prevcount,int count,string type)
        {
            PrevCount = prevcount;
            Count = count;
            Type = type;
            Weights = new List<double[]>(Count);
            PrevDeltaWeights = new List<double[]>(Count);
            DeltaWeights = new List<double[]>(Count);
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
                    PrevDeltaWeights.Add(new double[PrevCount]);
                    DeltaWeights.Add(new double[PrevCount]);
                    for (int e = 0;e<PrevCount; e++)
                    {
                        Weights[q][e]=(rnd.NextDouble()-0.5)*2;
                        PrevDeltaWeights[q][e] = 0.0;
                        DeltaWeights[q][e] = 0.0;
                    }
                }   
            }
            else {
                for (int q = 0; q < Count; q++)
                {
                    Weights.Add(new double[PrevCount]);
                    PrevDeltaWeights.Add(new double[PrevCount]);
                    DeltaWeights.Add(new double[PrevCount]);
                    for (int e = 0; e < PrevCount; e++)
                    {
                        Weights[q][e] = 1;
                        PrevDeltaWeights[q][e] = 0.0;
                        DeltaWeights[q][e] = 0.0;
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
                var a = 1 / (1 + Math.Pow(Math.E, -val*0.3));
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
            if (Type != "I")
            {
                var AP = ActivateProd(Outputs);
                for (int q = 0; q < Gradients.Count; q++)
                {
                    Gradients[q] += diffs[q] * AP[q];
                }
            }
        }
        public void UpdateWeights(double lr,int gradientsdel,double acelleration) {

            if (Type != "I") {
                for(int q = 0;q < Gradients.Count; q++)
                {
                    Gradients[q] /= gradientsdel; 
                }


                for (int q = 0;q<Weights.Count ;q++) {
                    for (int e = 0; e < Weights[q].Length; e++) {
                        DeltaWeights[q][e] = lr * Gradients[q] * Inputs[e] + PrevDeltaWeights[q][e]*acelleration; 
                        Weights[q][e] = Weights[q][e] - DeltaWeights[q][e];
                    }
                }
                PrevDeltaWeights = DeltaWeights; 

                Gradients = new List<double>();
                for (int q = 0; q < Count; q++)
                {
                    Gradients.Add(0.0);
                } 
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
        public string Save()
        {
            var result = ""; 
            for(int q = 0; q < Weights.Count; q++)
            {
                for (int e = 0; e < Weights[q].Length; e++)
                {
                    result +=Weights[q][e];
                    if (e < Weights[q].Length - 1)
                    {
                        result += "/";
                    }
                }
                if (q < Weights.Count - 1)
                {
                    result += "*";
                }
            }
            return result;
        }
        public void Load(string row)
        {
            var rowsep = row.Split('*');
            var rowsepsep = new List<string[]>();
            List<double[]> weights = new List<double[]>(); 
            foreach (string r in rowsep)
            {
                if (r.Length == 0) return;
                //if (r.Length == 1) {
                //    string[] a = { "1,0" };
                //    rowsepsep.Add(a); 
                //}
                weights.Add(r.Split('/').Select(v => Convert.ToDouble(v)).ToArray()); 
            }
            Weights = weights;
            
        }
        
    }
}
