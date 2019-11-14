/* Михеев Константин
    Задание 1:
        Изменить программу вывода таблицы функции так, чтобы можно было передавать функции 
        типа  double  (double,  double).  Продемонстрировать  работу  на  функции  с  функцией  a*x^2  и 
        функцией a*sin(x).
 */
using System;

namespace CSharpLevel1Lesson6Task1
{
    public delegate double Fun(double a, double x);

    class Program
    {
        public static double Func1 (double a, double x)
        {
            return a * x * x;
        }

        public static double Func2 (double a, double x)
        {
            return a * Math.Sin(x);
        }

        public static void Table (Fun F, double a, double x, double b)
        {
            Console.WriteLine(" ----- X ----- Y -----");
            
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }

            Console.WriteLine(" ---------------------");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Функция a * x^2:");
            Table(Func1, 2, -5, 5);

            Console.WriteLine("Функция a * sin(x):");
            Table(Func2, 2, -5, 5);

            Console.ReadKey();
        }
    }
}
