/* Михеев Константин
    Задание 2:
        Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
        а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.
        б) Использовать массив (или список) делегатов, в котором хранятся различные функции.
        в) *Переделать функцию Load, чтобы она возвращала массив считанных значений.
        Пусть она возвращает минимум через параметр (с использованием модификатора out). 
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace CSharpLevel1Lesson6Task2
{
    public delegate double Func(double x);

    class Program
    {
        /// <summary>
        /// Структура для хранения описаний функций и ссылок на них.
        /// </summary>
        struct Functions
        {
            string description;
            Func function;

            public string Description
            {
                get { return description; }
            }
            public Func Function
            {
                get { return function; }
            }

            public Functions(string description, Func function)
            {
                this.description = description;
                this.function = function;
            }
        }

        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F1(double x)
        {
            return Math.Sin(x) + Math.Cos(x);
        }

        public static void SaveFunc(string fileName, Func f, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;

            while (x <= b)
            {
                bw.Write(f(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// Возвращает массив результатов функции, а также возвращает минимальное значение функции в параметр min.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            List<double> result = new List<double>();

            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                result.Add(d);

                if (d < min)
                {
                    min = d;
                }
            }
            bw.Close();
            fs.Close();

            return result.ToArray();
        }

        /// <summary>
        /// Запускает диалог с пользователем по выбору функции и выводит минимальное значение выбранной функции.
        /// </summary>
        public static void Play()
        {
            Functions[] func =
            {
                new Functions("x^2-50x+10", F),
                new Functions("sin(x)+cos(x)", F1),
                new Functions("sin(x)", Math.Sin),
                new Functions("cos(x)", Math.Cos)
            };

            do
            {
                Console.Clear();
                Console.WriteLine("Список функций:");
                for (int i = 0; i < func.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {func[i].Description}");
                }
                Console.WriteLine("Введите номер функции.");

                int j;
                double leftBorder;
                double rightBorder;

                int.TryParse(Console.ReadLine(), out j);
                if (j < 1 || j > func.Length)
                {
                    Console.WriteLine("Введен неверный номер функции.");
                    continue;
                }
                do
                {
                    Console.WriteLine("Введите нижнюю границу интервала расчета функции.");
                    try
                    {
                        leftBorder = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Введено неверное значение.");
                    }
                } while (true);
                do
                {
                    Console.WriteLine("Введите верхнюю границу интервала расчета функции.");
                    try
                    {
                        rightBorder = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Введено неверное значение.");
                    }
                } while (true);

                SaveFunc("data.bin", func[j - 1].Function, leftBorder, rightBorder, 0.5);
                double min;
                Load("data.bin", out min);
                Console.WriteLine($"Минимальное значение функции равно {min}");

                Console.WriteLine("Для завершения нажмите ESC. Для продолжения - любую другую клавишу.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }


        static void Main(string[] args)
        {
            Play();
        }
    }
}
