/* Михеев Константин
    Задание 3:
        С  клавиатуры  вводятся  числа,  пока  не  будет  введен  0.  Подсчитать  сумму  всех  нечетных 
        положительных чисел. 
 */

using System;

namespace CSharpLevel1Lesson2Task3
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
            int sum = 0, a = 0;

            do
            {
                a = Convert.ToInt32(Console.ReadLine());
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
