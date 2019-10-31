/* Михеев Константин
    Задание 2:
        Написать метод подсчета количества цифр числа. 
 */
using System;

namespace CSharpLevel1Lesson2Task2
{
    class Program
    {
        static int CountOfNumbers(int number)
        {
            int count = 0;

            while (number != 0)
            {
                number /= 10;
                count++;
            }

            return count;
        }

        static string Declension(int number)
        {
            string result = "цифр";
            int num10 = number % 10;
            int num100 = number % 100;

            if (num10 == 1 && num100 != 11)
            {
                result = "цифра";
            } else
            {
                if ((num10 > 1 && num10 < 5) && (num100 < 12 || num100 > 14))
                {
                    result = "цифры";
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число:");
            int n = Convert.ToInt32(Console.ReadLine());
            int res = CountOfNumbers(n);

            Console.WriteLine($"В числе {n} содержится {res} {Declension(res)}.");
            Console.ReadKey();
        }
    }
}
