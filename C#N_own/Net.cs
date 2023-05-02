using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class Net
    {
        public List<Layer> Layers { get; private set; }
        public double LR { get; set; }
        public Net(int inputs, int outputs, double lr, params int[] hidden)
        {
            Layers = new List<Layer>(2 + hidden.Length);
            CreateInputLayer(inputs);
            CreateHiddenLayers(hidden);
            CreateOutputLayer(outputs);
            LR = lr;
        }

        private void CreateInputLayer(int inputs)
        {
            Layers.Add(new Layer(inputs, inputs, "I"));
        }
        private void CreateHiddenLayers(int[] hidden)
        {
            for (int q = 0; q < hidden.Length; q++)
            {
                Layers.Add(new Layer(Layers[q].Count, hidden[q], "H"));
            }
        }
        private void CreateOutputLayer(int outputs)
        {
            Layers.Add(new Layer(Layers[Layers.Count - 1].Count, outputs, "O"));
        }

        public Layer FeedForward(double[] input)
        {
            Layers[0].FeedForward(input.ToList());
            for (int q = 1; q <= Layers.Count - 2; q++)
            {
                var a = Layers[q - 1].Outputs;
                Layers[q].FeedForward(a);
            }
            Layers.Last().FeedForward(Layers[Layers.Count - 2].Outputs);
            return Layers.Last();
        }
        public double Test(List<double[]> inputs, List<double> answers)
        {
            var error = 0.0; 
            for(int q = 0;q<answers.Count; q++) {
                error += Math.Abs(Math.Pow((FeedForward(inputs[q]).Outputs[0] - answers[q]), 2));
            }
            return error/answers.Count;
        }
        public double Learn(List<double[]> inputs, List<double> answers, int epoch,int batch)
        {
            var counter = 0.0;
            var error = 0.0;
            for (int q = 0; q < epoch; q++) { 
                for (int e = 0; e < inputs.Count/batch; e++)
                {
                    var input = inputs.GetRange(e*batch,batch);
                    var answer = answers.GetRange(e,batch);
                    error+=BackPropagation(input, answer);
                    counter++; 
                } 
            }
            return error/counter;
        }

        private double BackPropagation(List<double[]> input, List<double> answer)
        {
            var error = 0.0;
            for(int e = 0;e<input.Count; e++) {

                var diff = FeedForward(input[e]).Outputs[0] - answer[e];
                error += Math.Pow(Math.Abs(diff), 2); 
                List<double> a = new List<double>();
                a.Add(diff);
                Layers.Last().UpdateGradients(a);
                    
                for(int q = Layers.Count - 2; q>=1; q--)
                {
                    Layers[q].UpdateGradients(Layers[q+1].GetPrevLayerErrors());
                }
            }
            foreach(Layer L in Layers)
            {
                L.UpdateWeights(LR);
            }
            return error/ input.Count;
        }
    }
}
