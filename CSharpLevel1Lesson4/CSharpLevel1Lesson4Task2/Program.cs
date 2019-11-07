/* Михеев Константин
    Задание 2:
        Реализуйте задачу 1 в виде статического класса StaticClass; 
        а)  Класс  должен  содержать  статический  метод,  который  принимает на вход массив и решает 
        задачу 1; 
        б)  *Добавьте  статический  метод для считывания массива из текстового файла. Метод должен 
        возвращать массив целых чисел; 
        в)**Добавьте обработку ситуации отсутствия файла на диске. 
 */
using System;
using System.IO;

namespace CSharpLevel1Lesson4Task2
{
    static class StaticClass
    {
        /// <summary>
        /// Создает массив размерности arrayLength и заполняет его случайными числами в интервале от -10000 до 10000.
        /// </summary>
        /// <param name="arrayLength"></param>
        /// <returns></returns>
        public static int[] CreateArray(int arrayLength)
        {
            int[] tmp = new int[arrayLength];
            Random rnd = new Random();

            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = rnd.Next(-10000, 10001);
            }

            return tmp;
        }

        /// <summary>
        /// Считывает из файла filename числовые данные и создает массив.
        /// Файла должен содержать целые числа. В первой строке содержится количество элементов массива.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static int[] CreateArrayFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new Exception($"Файл {filename} не найден.");
            }

            StreamReader reader = new StreamReader(filename);
            int arrayLength = Convert.ToInt32(reader.ReadLine());

            int[] tmp = new int[arrayLength];

            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = Convert.ToInt32(reader.ReadLine());
            }

            reader.Close();

            return tmp;
        }

        /// <summary>
        /// Находит пары элеметов в массиве tmp, в которых только один элемент делится на 3.
        /// А также расчитывает количество таких пар и записывает их в pairsCount.
        /// </summary>
        /// <param name="tmp"></param>
        /// <param name="pairsCount"></param>
        /// <returns></returns>
        public static int[,] Pairs(int[] tmp, out int pairsCount)
        {
            int length = tmp.Length;
            int[,] pairs = new int[length, 2];
            pairsCount = 0;

            for (int i = 1; i < length; i++)
            {
                if ((tmp[i - 1] % 3 == 0 && tmp[i] % 3 != 0)
                    || (tmp[i - 1] % 3 != 0 && tmp[i] % 3 == 0))
                {
                    pairs[pairsCount, 0] = i - 1;
                    pairs[pairsCount, 1] = i;
                    pairsCount++;
                }
            }

            return pairs;
        }

        /// <summary>
        /// Печатает все элементы массива tmp в одну строку.
        /// </summary>
        /// <param name="tmp"></param>
        public static void PrintAll(int[] tmp)
        {
            foreach (int i in tmp)
            {
                Console.Write($"{i} ");
            }
        }

        /// <summary>
        /// Печатает пары элементов из массива tmp. Индексы пар содержатся в массиве pair, а количество пар в pairsCount.
        /// </summary>
        /// <param name="tmp"></param>
        /// <param name="pairs"></param>
        /// <param name="pairsCount"></param>
        public static void PrintPairs(int[] tmp, int[,] pairs, int pairsCount)
        {
            for (int i = 0; i < pairsCount; i++)
            {
                Console.WriteLine($"{tmp[pairs[i, 0]],7} {tmp[pairs[i, 1]],7}");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int count;

            // массив со случайными числами
            int[] arr = StaticClass.CreateArray(30);
            int[,] pairs = StaticClass.Pairs(arr, out count);
            Console.WriteLine("Пример создания массива из 30 элементов, заполненного случайными числами.\n");
            Console.WriteLine("Печать всех элементов массива:");
            StaticClass.PrintAll(arr);
            Console.WriteLine($"\n\nКоличество пар, только с одним делящимся на 3 элементом: {count}");
            Console.WriteLine("Печать пар элементов:");
            StaticClass.PrintPairs(arr, pairs, count);
            Console.ReadKey();

            // массив из файла
            arr = StaticClass.CreateArrayFromFile("data.txt");
            pairs = StaticClass.Pairs(arr, out count);

            Console.Clear();
            Console.WriteLine("Пример создания массива из файла data.txt.\n");
            Console.WriteLine("Печать всех элементов массива:");
            StaticClass.PrintAll(arr);
            Console.WriteLine($"\n\nКоличество пар, только с одним делящимся на 3 элементом: {count}");
            Console.WriteLine("Печать пар элементов:");
            StaticClass.PrintPairs(arr, pairs, count);

            Console.ReadKey();
        }
    }
}
