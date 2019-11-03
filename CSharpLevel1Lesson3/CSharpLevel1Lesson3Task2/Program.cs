/* Михеев Константин
    Задание 2:
        а) С  клавиатуры  вводятся  числа,  пока  не  будет  введён  0 (каждое число в новой строке). 
        Требуется  подсчитать  сумму  всех  нечётных  положительных  чисел.  Сами  числа  и  сумму 
        вывести на экран, используя tryParse.
        б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
        При возникновении ошибки вывести сообщение. Напишите соответствующую функцию;
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

        // вариант с TryParse
        // При срабатывании TryParse заканчиваем ввод чисел и выводим результат
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

        // вариант с исключениеями
        // При срабатывании исключения продолжаем ввод чисел до тех пор пока не введен 0.
        static int OddSumTry()
        {
            int sum = 0, a = 0;
            bool b = true;

            do
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine($"Необходимо ввести число в диапазоне от {int.MinValue} до {int.MinValue}");
                    continue;
                }

                if (a > 0 && a % 2 != 0)
                {
                    sum += a;
                }
                if (a == 0)
                {
                    b = false;
                }
            } while (b || a != 0);

            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Вариант с TryParse");
            HintText();

            Console.WriteLine($"Сумма нечетных положительных чисел равна {OddSum()}");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Вариант с исключениями");
            HintText();

            Console.WriteLine($"Сумма нечетных положительных чисел равна {OddSumTry()}");
            Console.ReadKey();
        }
    }
}
