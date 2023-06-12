using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class FunctionalLayer : Layer
    {
        #region AcessMethods
        public int PrevCount { get; protected set; }
        public List<double> WeightedSum { get; protected set; }
        public List<double[]> Weights { get; protected set; }
        public List<double> Gradients { get; protected set; }
        public List<double[]> DeltaWeights { get; protected set; }
        public List<double[]> PrevDeltaWeights { get; protected set; }
        #endregion

        #region methods
        public FunctionalLayer(int prevcount,int count,string type) : base(count,type)
        {
            PrevCount = prevcount;
            Weights = new List<double[]>(Count);
            PrevDeltaWeights = new List<double[]>(Count);
            DeltaWeights = new List<double[]>(Count);
            Gradients = new List<double>();
            for (int q = 0; q < Count; q++) {
                Gradients.Add(0.0);
            } 
            
            InitRandom();
        }
        public override void InitRandom()
        {
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
        public override List<double> FeedForward(List<double> inputs) {

            Inputs = inputs;
            var WeightedSum = new List<double>(Count);
                for (int q = 0; q < Count; q++)
                {
                    var sum = 0.0;
                    for (int e = 0; e < PrevCount; e++)
                    {
                        sum += Weights[q][e] * inputs[e];
                    }
                    WeightedSum.Add(sum);
                }
                Outputs = Activate(WeightedSum); 

            return Outputs;
        }
        public override List<double> Activate(List<double> t) {
            var result = new List<double>();
            foreach(double val in t)
            {
                var a = 1 / (1 + Math.Pow(Math.E, -val*0.3));
                result.Add(a);
            }
            return result; 
        }
        public override List<double> ActivateProd(List<double> h) {
            List<double> result = new List<double>(Count);
            foreach (double val in h)
            {
                var a = val * (1 - val);
                result.Add(a);
            }

            return result;
        }
        public override void UpdateGradients(List<double> diffs) {

                var AP = ActivateProd(Outputs);
                for (int q = 0; q < Gradients.Count; q++)
                {
                    Gradients[q] += diffs[q] * AP[q];
                }
        }
        public override void UpdateWeights(double lr,int gradientsdel,double acelleration) {
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
        public override List<double> GetPrevLayerErrors()
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
        public override void SetWeights(List<double[]> weights)
        {
            Weights = weights;
        }
        public override string Save()
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
        public override List<double[]> Load(string row)
        {
            var rowsep = row.Split('*');
            var rowsepsep = new List<string[]>();
            List<double[]> weights = new List<double[]>(); 
            foreach (string r in rowsep)
            {
                if (r.Length == 0) return null;
                //if (r.Length == 1) {
                //    string[] a = { "1,0" };
                //    rowsepsep.Add(a); 
                //}
                weights.Add(r.Split('/').Select(v => Convert.ToDouble(v)).ToArray()); 
            }
            Weights = weights;
            return weights;
        }
        #endregion
    }
    public class Layer
    {
        public int Count { get; protected set; }
        public List<double> Outputs { get; protected set; }
        public List<double> Inputs { get; protected set; }
        public string Type { get; protected set; }
        public Layer( int count, string type) {
            Count = count;
            Type = type;
        }
        public virtual List<double> FeedForward(List<double> inputs) {
            if (inputs.Count == Count)
            {
                Inputs = inputs;
                Outputs = inputs;
                return Outputs;
            }
            else
            {
                throw new Exception("inputs.Count != Inputs.Count in InputLayer feedforward"); 
            }
            
        }


        public virtual void InitRandom()
        {
            throw new Exception("InitRandom method called for InputLayer");
        }
        public virtual List<double> Activate(List<double> t)
        {
            throw new Exception("Activate method called for InputLayer");
        }
        public virtual List<double> ActivateProd(List<double> h)
        {
            throw new Exception("ActivateProd method called for InputLayer");
        }
        public virtual void UpdateGradients(List<double> diffs)
        {
            throw new Exception("UpdateGradients method called for InputLayer");
        }
        public virtual void UpdateWeights(double lr, int gradientsdel, double acelleration)
        {
            //throw new Exception("UpdateWeights method called for InputLayer");
        }
        public virtual List<double> GetPrevLayerErrors()
        {
            throw new Exception("GetPrevLayerErrors method called for InputLayer");
        }
        public virtual void SetWeights(List<double[]> weights)
        {
            throw new Exception("SetWeights method called for InputLayer");
        }
        public override string ToString()
        {
            var result = "";
            for (int q = 0; q < Outputs.Count; q++)
            {
                result += Outputs[q];
                result += " ";
            }
            return result;
        }
        public virtual string Save()
        {
            var result = Inputs.ToString();
            result += "*";
            return result;
        }
        public virtual List<double[]> Load(string row)
        {
            return null;
        }

    }
}
