/* Михеев Константин
    Задание 6:
        Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
        «Хорошим»  называется  число,  которое  делится  на  ​сумму  своих  цифр.​  Реализовать 
        подсчёт времени выполнения программы, используя структуру DateTime. 
 */
using System;

namespace CSharpLevel1Lesson2Task6
{
    class Program
    {

        // Сумма цифр числа number
        static int OwnNumbersSum(int number)
        {
            int sum = 0;

            number = Math.Abs(number);

            while (number > 0)
            {
                sum += (number % 10);
                number /= 10;
            }

            return sum;
        }

        // Количество "Хороших" чисел в интервале [1, upValue]
        static int NumbersCount(int upValue)
        {
            int count = 0;

            for (int i = 1; i <= upValue; i++)
            {
                if (i % OwnNumbersSum(i) == 0)
                {
                    count++;
                }
            }

            return count;
        }

        static void Main(string[] args)
        {
            int upValue = 1000000000;

            DateTime startTime = DateTime.Now;

            Console.WriteLine($"Количество хороших чисел в интервале [1, {upValue}]: {NumbersCount(upValue)}");

            Console.WriteLine($"Время выполнения: {DateTime.Now - startTime}");

            Console.ReadKey();
        }
    }
}
