using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    abstract class DataFormat
    {

        static public double[] ToBinary(double[] inputs) // метод приводит значения массива к 1 если те больше 2, и к 0 если меньше
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
        static public double[] ToOne(double[] inputs) // метод загоняет значения массива в рамки от 0 до 1(без мат формул)
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
                    result[q] = inputs[q] - 1;
                }
            }
            return result;
        }
        static public double[] Scaling(double[] inputs)
        {
            //тут все очень просто, вот формула:
            //   x - min
            // -----------
            //  min - max
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
        }// метод загоняет значения массива в рамки от 0 до 1(с мат формулами)
        static public List<double[]> Scaling(List<double[]> inputs)
        {
            List<double[]> result = new List<double[]>(inputs.Count);
            for(int q = 0; q < inputs.Count; q++)
            {
                result.Add(Scaling(inputs[q]));
                
            }

            return result;
        }// метод загоняет значения массива в рамки от 0 до 1(с мат формулами)
        static public List<List<double[]>> Scaling(List<List<double[]>> inputs)
        {
            var result = new List<List<double[]>>();
            for(int q = 0; q < inputs.Count; q++)
            {
                result.Add(Scaling(inputs[q]));
            }
            return result;


        }// метод загоняет значения массива в рамки от 0 до 1(с мат формулами)
        static public List<double[]> GetEveryX(List<double[]> a, int every, int sdvig)
        {
            var result = new List<double[]>();
            for (int q = 0; q < a.Count - every; q += every)
            {
                result.Add(a[q + sdvig]);
            }
            return result;
        }//кандидат на удаление песполезен, перкдадывает с пустого в порожне
        static public List<double> GetEveryX(List<double> a, int every, int sdvig)
        {
            var result = new List<double>();
            for (int q = 0; q < a.Count - every; q += every)
            {
                result.Add(a[q + sdvig]);
            }
            return result;
        }//кандидат на удаление песполезен, перкдадывает с пустого в порожне
        static public List<double[]> ToBinary(List<double[]> inputs)// перегрузка ToBinary() для работы с  List<double[]>
        {
            List<double[]> result = new List<double[]>();
            for (int q = 0; q < inputs.Count; q++)
            {
                result.Add(ToBinary(inputs[q]));
            }
            return result;
        }
        static public List<double[]> ToOne(List<double[]> inputs)
        {
            List<double[]> result = new List<double[]>();
            for (int q = 0; q < inputs.Count; q++)
            {
                result.Add(ToOne(inputs[q]));
            }
            return result;
        }// перегрузка ToOne() для работы с  List<double[]>
        

    }
}
