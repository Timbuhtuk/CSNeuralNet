using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class DataFormat
    {

        static public double[] ToBinary(double[] inputs)
        {
            double[] result = new double[inputs.Length];
            for (int q = 0; q < inputs.Length; q++)
            {
                if (inputs[q] > 2)
                {
                    result[q] = 1;
                }
                else
                {
                    result[q] = 0;
                }
            }
            return result;
        }
        static public double[] ToTwo(double[] inputs)
        {
            double[] result = new double[inputs.Length];
            for (int q = 0; q < inputs.Length; q++)
            {
                if (inputs[q] > 2)
                {
                    result[q] = 2;
                }
                else
                {
                    result[q] = inputs[q];
                }
            }
            return result;
        }
       
        static public List<double[]> GetEveryX(List<double[]> a, int every, int sdvig)
        {
            var result = new List<double[]>();
            for (int q = 0; q < a.Count - every; q += every)
            {
                result.Add(a[q + sdvig]);
            }
            return result;
        }
        static public List<double> GetEveryX(List<double> a, int every, int sdvig)
        {
            var result = new List<double>();
            for (int q = 0; q < a.Count - every; q += every)
            {
                result.Add(a[q + sdvig]);
            }
            return result;
        }
        static public List<double[]> ToBinary(List<double[]> inputs)
        {
            List<double[]> result = new List<double[]>();
            for (int q = 0; q < inputs.Count; q++)
            {
                result.Add(ToBinary(inputs[q]));
            }
            return result;
        }
        static public List<double[]> ToTwo(List<double[]> inputs)
        {
            List<double[]> result = new List<double[]>();
            for (int q = 0; q < inputs.Count; q++)
            {
                result.Add(ToTwo(inputs[q]));
            }
            return result;
        }
        static public List<double[]> Scaling(List<double[]> inputs)
        {
            var result = new List<double[]>();
            for (int q = 0; q < inputs.Count; q++)
            {
                result.Add(inputs[q]);
            }
            for (int column = 0; column < inputs[0].Length; column++)
            {
                var min = inputs[0][0];
                var max = inputs[0][0];
                for (int row = 0; row < inputs.Count; row++)
                {
                    var item = inputs[row][column];
                    if (item < min)
                    {
                        min = item;
                    }
                    if (item > max)
                    {
                        max = item;
                    }
                }
                var divider = (max - min);
                for (int row = 0; row < inputs.Count; row++)
                {
                    result[row][column] = (inputs[row][column] - min) / divider;
                }

            }
            return result;
        }
        static public double[] Scaling(double[] inputs)
        {
            var result = new double[inputs.Length];
            for (int q = 0; q < inputs.Length; q++)
            {
                result[q] = inputs[q];
            }

            var min = inputs[0];
            var max = inputs[0];
            for (int row = 0; row < inputs.Length; row++)
            {
                var item = inputs[row];
                if (item < min)
                {
                    min = item;
                }
                if (item > max)
                {
                    max = item;
                }
            }
            var divider = (max - min);
            for (int row = 0; row < inputs.Length; row++)
            {
                result[row] = (inputs[row] - min) / divider;
            }


            return result;
        }

    }
}
