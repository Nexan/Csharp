/* Михеев Константин
    Задание 7:
        a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b). 
        б) *Разработать рекурсивный метод, который считает сумму чисел от a до b. 
 */
using System;

namespace CSharpLevel1Lesson2Task7
{
    class Program
    {
        static void Print(int a, int b)
        {
            if (a > b)
            {
                return;
            }

            Console.WriteLine(a);
            Print(a + 1, b);
        }

        static int Sum(int a, int b)
        {
            if (a > b)
            {
                return 0;
            }

            return a + Sum(a + 1, b);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Введите число a:");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите число b:");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Печать чисел в интервале [{a}, {b}]:");
            Print(a, b);
            Console.WriteLine($"Сумма чисел в интервале [{a}, {b}]: {Sum(a, b)}");

            Console.ReadKey();
        }
    }
}
