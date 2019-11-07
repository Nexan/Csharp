/* Михеев Константин
    Задание 1:
        Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые 
        значения  от  –10  000  до  10  000  включительно.  Заполнить  случайными  числами.  Написать 
        программу, позволяющую найти и вывести количество пар элементов массива, в которых только 
        одно  число  делится  на  3.  В  данной  задаче  под  парой  подразумевается  два  подряд  идущих 
        элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.  
 */
using System;

namespace CSharpLevel1Lesson4Task1
{
    class Program
    {
        static int arrayLength = 20;

        static int[] CreateArray()
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
        /// Находит пары элеметов в массиве tmp, в которых только один элемент делится на 3.
        /// А также расчитывает количество таких пар и записывает их в pairsCount.
        /// </summary>
        /// <param name="tmp"></param>
        /// <param name="pairsCount"></param>
        /// <returns></returns>
        static int[,] Pairs(int[] tmp, out int pairsCount)
        {
            int[,] pairs = new int[arrayLength, 2];
            pairsCount = 0;

            for (int i = 1; i < arrayLength; i++)
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
        static void PrintAll(int[] tmp)
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
        static void PrintPairs(int[] tmp, int[,] pairs, int pairsCount)
        {
            for (int i = 0; i < pairsCount; i++)
            {
                Console.WriteLine($"{tmp[pairs[i, 0]],7} {tmp[pairs[i, 1]],7}");
            }
        }


        static void Main(string[] args)
        {
            int count;
            int[] arr = CreateArray();
            int[,] pairs = Pairs(arr, out count);

            Console.WriteLine("Печать всех элементов массива:");
            PrintAll(arr);
            Console.WriteLine($"\n\nКоличество пар, только с одним делящимся на 3 элементом: {count}");
            Console.WriteLine("Печать пар элементов:");
            PrintPairs(arr, pairs, count);

            Console.ReadKey();
        }
    }
}
