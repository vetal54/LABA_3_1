using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr2Task1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Первая матрица с масивов строк");
            string[] temp= { "1 3 4", "5 7 8", "9 10 12"};
           MyMatrix mat = new MyMatrix(temp);
            Console.WriteLine(mat);

            Console.WriteLine("Вторая матрица с одной строчки");
            string temp2 ="10 12 15/15 8 5/17 22 9";
            MyMatrix mat2 = new MyMatrix(temp2);
            Console.WriteLine(mat2);

            Console.WriteLine("Сумма первых двух матриц");
            Console.WriteLine(mat+mat2);

            Console.WriteLine("Произведение первых двух матриц");
            Console.WriteLine(mat * mat2);

            Console.WriteLine("Транспонированная вторая матрица");
            Console.WriteLine(mat2.GetTransponedCopy());
            Console.ReadKey();
        }
    }
}
