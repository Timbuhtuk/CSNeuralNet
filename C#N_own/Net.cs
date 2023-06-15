﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class Net
    {
        #region Basics
        public List<Layer> Layers { get; private set; }
        public double LR { get; set; }
        public double Acelleration { get; set; }
        public List<List<double[]>> Weights { get; private set; }
        public Net(int inputs, int outputs, double lr,double acelleration, params int[] hidden)
        {
            Layers = new List<Layer>(2 + hidden.Length);
            CreateInputLayer(inputs);
            CreateHiddenLayers(hidden);
            CreateOutputLayer(outputs);
            Weights = new List<List<double[]>>();
            LR = lr;
            Acelleration = acelleration;
        }

        private void CreateInputLayer(int inputs)
        {
            Layers.Add(new Layer(inputs, "I"));
        }
        private void CreateHiddenLayers(int[] hidden)
        {
            for (int q = 0; q < hidden.Length; q++)
            {
                Layers.Add(new FunctionalLayer(Layers[q].Count, hidden[q], "H"));
            }
        }
        private void CreateOutputLayer(int outputs)
        {
            Layers.Add(new FunctionalLayer(Layers[Layers.Count - 1].Count, outputs, "O"));
        }
        public void Save(string file) {
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        for (int q = 0; q < Layers.Count; q++)
                        {
                            writer.WriteLine(Layers[q].Save());
                        }
                    }
                }
        public string Load(string file)
        {
                    try
                    {
                        using (StreamReader reader = new StreamReader(file))
                        {
                            Weights.Clear();
                            for(int q = 0;q< Layers.Count;q++)
                            {
                                var row = reader.ReadLine();
                                if (row != null)
                                {
                                    Weights.Add(Layers[q].Load(row));
                                }
                                else { throw new Exception("Bad Save");}
                         
                            }
                            return "Loaded";
                        }
                    }
                    catch(Exception e) { Console.WriteLine(e); /*System.Environment.Exit(0);*/ }
                    return "";
                }
        #endregion

        #region Vanilla NN
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
        public double[] Learn(List<double[]> inputs, List<double[]> answers, int epoch,int batch)
                {
                    var counter = 0.0;
                    double[] error = new double[answers[0].Length];
                    for (int q = 0; q < epoch; q++) { 
                        for (int e = 0; e < inputs.Count/batch; e++)
                        {
                            var input = inputs.GetRange(e * batch,batch);
                            var answer = answers.GetRange(e * batch, batch);
                            var errorone = BackPropagation(input, answer);
                            for (int f = 0; f < answers[0].Length; f++)
                            { error[f] += errorone[f]; }
                            counter++; 
                        } 
                    }
                    for (int f = 0; f < answers[0].Length; f++)
                    { error[f] /= counter; }
                    return error;
                }
        private double[] BackPropagation(List<double[]> input, List<double[]> answer)
        {
            double[] error = new double[answer[0].Length];

            for(int e = 0;e<input.Count; e++) {

                double[] FF = FeedForward(input[e]).Outputs.ToArray(); 
                List<double> diff = new List<double>(FF.Length);

                for(int q = 0;q<FF.Length ;q++)
                {
                    diff.Add(FF[q] - answer[e][q]);
                    error[q] += Math.Pow(Math.Abs(diff[q]), 2);
                }

                Layers.Last().UpdateGradients(diff);
                    
                for(int q = Layers.Count - 2; q>=1; q--)
                {
                    Layers[q].UpdateGradients(Layers[q+1].GetPrevLayerErrors());
                }
            }
            foreach(Layer L in Layers)
            {
                L.UpdateWeights(LR,input.Count,Acelleration);
            }

            for (int f = 0; f < answer[0].Length; f++)
            { error[f] /= input.Count; }

            return error;
        }
        #endregion

        #region TestMedods
        public double[] Test(List<double[]> inputs, List<double[]> answers)
        {
            double[] error = new double[answers[0].Length];
            for (int e = 0; e < inputs.Count; e++)
            {

                double[] FF = FeedForward(inputs[e]).Outputs.ToArray();
                List<double> diff = new List<double>(FF.Length);

                for (int q = 0; q < FF.Length; q++)
                {
                    diff.Add(FF[q] - answers[e][q]);
                    error[q] += Math.Pow(Math.Abs(diff[q]), 2);
                }

                Layers.Last().UpdateGradients(diff);

                for (int q = Layers.Count - 2; q >= 1; q--)
                {
                    Layers[q].UpdateGradients(Layers[q + 1].GetPrevLayerErrors());
                }
            }
            for (int f = 0; f < answers[0].Length; f++)
            { error[f] /= answers.Count; }

            return error;
        }
        public double[] Test3(List<double[]> inputs, List<double[]> answers)
        {
            double[] error = new double[answers[0].Length];
            List<double[]> FFs = new List<double[]>();

            for (int e = 0; e < inputs.Count; e++)
            { FFs.Add(FeedForward(inputs[e]).Outputs.ToArray()); }
            FFs = DataFormat.Scaling(FFs);
            for (int e = 0; e < inputs.Count; e++)
            {
                List<double> diff = new List<double>(FFs[e].Length);
                for (int q = 0; q < FFs[e].Length; q++)
                {
                    diff.Add(FFs[e][q] - answers[e][q]);
                    error[q] += Math.Pow(Math.Abs(diff[q]), 2);
                }
            }
            
            for (int f = 0; f < answers[0].Length; f++)
            { error[f] /= inputs.Count; }
            return error;
        }
        public void Test2(List<double[]> inputs, List<double[]> answers)
        {
            for (int e = 0; e < inputs.Count; e++)
            {
                var a = FeedForward(inputs[e]).Outputs[0];
                Console.Write(a+" - "); 
                Console.WriteLine(answers[e][0]);
            }
            
        }
        #endregion

        #region Async Trash
        public async Task<double[]> LearnThreding(List<double[]> inputs, List<double[]> answers, int epoch, int batch)
        {
            var counter = 0;
            double[] error = new double[answers[0].Length];
            int threadscount = (answers.Count / batch)-1;
            List<double[]> Diffs = new List<double[]>();
            List<Task< List<double[]> >> Tasks = new List<Task<List<double[]>>>(threadscount);

            for (int q = 0; q < epoch; q++)
            {
                for(int e = 0; e < threadscount; e++)
                {
                    var input = inputs.GetRange(e * batch, batch);
                    var answer = answers.GetRange(e * batch, batch);
                    Tasks.Add(Task.Run(()=>GetDiffs(input,answer)));
                }
                //for (int e = 0; e < threadscount; e++)
                //{
                //    Tasks[q].Wait();
                //}
                for (int e = 0; e < threadscount; e++)
                {
                    Diffs.AddRange(Tasks[q].Result);
                }
                BackPropagationForAsyncLearn(Diffs);

                for (int e = 0; e < Diffs.Count; e++)
                {
                    for (int w = 0; w < answers[0].Length; w++)
                    {
                        error[w] += Math.Abs(Diffs[e][w]);
                        counter++;
                    }
                }



            }

            for (int w = 0; w < answers[0].Length; w++)
            {
                error[w] /= counter;
            }
            return error;
        }
        private List<double[]> GetDiffs(List<double[]> inputs, List<double[]> answers)
        {
            List<double[]> result = new List<double[]>(inputs.Count);
            for(int q = 0;q<inputs.Count; q++)
            {
                var FF = FeedForward(inputs[q]).Outputs;
                double[] diff = new double[FF.Count];
                for (int w = 0; w < diff.Length; w++)
                {
                    diff[w] = FF[w] - answers[q][w];
                }
                result.Add(diff);
            }
            return result;

        }
        private void BackPropagationForAsyncLearn(List<double[]> Diffs)
        {
            for (int e = 0; e < Diffs.Count; e++)
            {

                Layers.Last().UpdateGradients(Diffs[e].ToList());

                for (int q = Layers.Count - 2; q >= 1; q--)
                {
                    Layers[q].UpdateGradients(Layers[q + 1].GetPrevLayerErrors());
                }

            }
            foreach (Layer L in Layers)
            {
                L.UpdateWeights(LR, Diffs.Count, Acelleration);
            }
            
        }

        public async void SaveAsync(string file)
        {
            Task.Run(() => Save(file));
        }
        public async Task<string> LoadAsync(string file)
        {
            var result = Task.Run(() => Load(file)).Result;
            return result;
        }
        #endregion

        private double[] BackPropagation2(List<double[]> input, List<double[]> answer)
        {
            double[] error = new double[answer[0].Length];
            List<double[]> FFs = new List<double[]>();

            for (int e = 0; e < input.Count; e++)
            { FFs.Add(FeedForward(input[e]).Outputs.ToArray()); }
            FFs = DataFormat.Scaling(FFs);
            for (int e = 0; e < input.Count; e++)
            {

                List<double> diff = new List<double>(FFs[e].Length);

                for (int q = 0; q < FFs[e].Length; q++)
                {
                    diff.Add(FFs[e][q] - answer[e][q]);
                    error[q] += Math.Pow(Math.Abs(diff[q]), 2);
                }

                Layers.Last().UpdateGradients(diff);

                for (int q = Layers.Count - 2; q >= 1; q--)
                {
                    Layers[q].UpdateGradients(Layers[q + 1].GetPrevLayerErrors());
                }
            }
            foreach (Layer L in Layers)
            {
                L.UpdateWeights(LR, input.Count, Acelleration);
            }
            for (int f = 0; f < answer[0].Length; f++)
            { error[f] /= input.Count; }
            return error;
        }

        
    }
}
