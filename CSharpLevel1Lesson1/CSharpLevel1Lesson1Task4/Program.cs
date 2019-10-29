/* Михеев Константин
    Задание 4:
        Написать программу обмена значениями двух переменных: 
        а) с использованием третьей переменной; 
        б) *без использования третьей переменной. 


    Для чисел a и b выбрал тип int, т.к. боюсь что при выборе вещественного типа возможна потеря точности при
    вычислениях в способе б
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLevel1Lesson1Task4
{
    class Program
    {
        static void Print1 (int a, int b)
        {
            int c = a;
            a = b;
            b = c;

            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
        }

        static void Print2(int a, int b)
        {
            a = a - b;
            b = b + a;
            a = b - a;

            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
        }


        static void Main(string[] args)
        {
            Console.Write("Введите число a: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите число b: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Вариант а:");
            Print1(a, b);
            Console.WriteLine();

            Console.WriteLine("Вариант б:");
            Print2(a, b);

            Console.ReadKey();
        }
    }
}
