/* Михеев Константин
    Задание 2:
        С  клавиатуры  вводятся  числа,  пока  не  будет  введён  0 (каждое число в новой строке). 
        Требуется  подсчитать  сумму  всех  нечётных  положительных  чисел.  Сами  числа  и  сумму 
        вывести на экран, используя tryParse.
 */
using System;

namespace CSharpLevel1Lesson3Task2
{
    class Program
    {
        static void HintText()
        {
            Console.WriteLine("Введите целые числа. Каждое число с новой строки.");
            Console.WriteLine("Для завершения ввода введите 0.");
        }

        static int OddSum()
        {
            int sum = 0, a;

            do
            {
                if (! int.TryParse(Console.ReadLine(), out a))
                {
                    continue;
                }

                if (a > 0 && a % 2 != 0)
                {
                    sum += a;
                }
            } while (a != 0);

            return sum;
        }

        static void Main(string[] args)
        {
            HintText();

            Console.WriteLine($"Сумма нечетных положительных чисел равна {OddSum()}");
            Console.ReadKey();
        }
    }
}
