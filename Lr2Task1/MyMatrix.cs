using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr2Task1
{
    class MyMatrix
    {
        protected double[,] _matrix;
        public double this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }
            set
            {
                _matrix[i, j] = value;
            }
        }
        public MyMatrix(MyMatrix mat)
        {
            MyMatrix _matrix = mat;
        }

        public MyMatrix(double[,] mat)
        { _matrix = mat; }
        public MyMatrix(double[][] _matrix)
        {
            bool isrectangular = true;
            for (int i = 0; isrectangular && i < _matrix.Length; i++)
            {
                for (int j = 0; isrectangular && j < _matrix[i].Length; j++)
                {
                    if (_matrix[i].Length != _matrix[0].Length)
                    {
                        Console.WriteLine("Матрица не прямоугольная. Невозможно применить");
                        isrectangular = false;
                    }
                    this._matrix[i, j] = _matrix[i][j];
                }
            }
        }
        public MyMatrix(string[] mat)
        {
            int[] temp;
            double[,] temp2=new double[mat.Length, mat.Length];
            for (int i = 0; i < mat.Length; i++)
            {
                temp = mat[i].Split().Select(int.Parse).ToArray();
                for (int j = 0; j < temp.Length; j++)
                {
                    temp2[i, j] = temp[j];
                }
            }
            _matrix = temp2;
        }
        public MyMatrix(string ma)
        {
            string[] temp1 = ma.Split('/');
            int[] temp;
                double[,] output = new double[temp1.Length, temp1.Length];
                for (int i = 0; i < temp1.Length; i++)
                {
                    temp = temp1[i].Split().Select(int.Parse).ToArray();
                    for (int j = 0; j < temp.Length; j++)
                    {
                        output[i, j] = temp[j];
                    }
                }
                _matrix = output;
        }
        public int GetHeight()
        {
            return _matrix.GetLength(0);
        }
        public int GetWidth()
        {
            return _matrix.GetLength(1);
        }
        private int Height()
        {
            return _matrix.GetLength(0);
        }
        private int Width()
        {
            return _matrix.GetLength(1);
        }
        public static MyMatrix Sum(MyMatrix first, MyMatrix second)
        {
            double[,] array1 = new double[first.GetHeight(), first.GetWidth()];
            if (first.GetHeight() != second.GetHeight() || first.GetWidth() != second.GetWidth())
            {
                Console.WriteLine("Матрицы не одинаковые. Невозможно применить сложение");
            }
            else
            {
                for (int i = 0; i < first.GetHeight(); i++)
                {

                    for (int j = 0; j < first.GetWidth(); j++)
                    {
                        array1[i, j] = first[i, j] + second[i, j];
                    }
                }
            }
            MyMatrix resMass = new MyMatrix(array1);
            return resMass;
        }
        public static MyMatrix operator +(MyMatrix first, MyMatrix second)
        {
            return MyMatrix.Sum(first, second);
        }
        public static MyMatrix multiply(MyMatrix a, MyMatrix b)
        {
            double[,] array1 = new double[a.GetHeight(), b.GetWidth()];
            for (int i = 0; i < a.GetWidth(); i++)
            {
                for (int j = 0; j < b.GetWidth(); j++)
                {
                    for (int k = 0; k < b.GetWidth(); k++)
                    {
                        array1[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            MyMatrix resMass = new MyMatrix(array1);
            return resMass;
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            return MyMatrix.multiply(a, b);
        }
        override public String ToString()
        {
            string outp = "";

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {

                for (int j = 0; j < _matrix.GetLength(1); j++)
                {

                    outp += _matrix[i, j] + " ";
                }
                outp += Environment.NewLine;
            }
            return outp;
        }
        protected double[,] GetTransponedArray()
        {
            double[,] transposed = new double[_matrix.GetLength(0), _matrix.GetLength(1)];
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    transposed[i, j] = _matrix[j, i];
                }
            }
            return transposed;
        }
        public MyMatrix GetTransponedCopy()
        {
            MyMatrix res = new MyMatrix(GetTransponedArray());
            return res;
        }
        public void TransponeMe()
        {
            this._matrix = GetTransponedArray();
        }

    }
}
