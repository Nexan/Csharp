/* Михеев Константин
    Задание 3:
        а)  Дописать  класс  для  работы с одномерным массивом. Реализовать конструктор, создающий 
        массив  определенного  размера  и  заполняющий  массив  числами  от  начального  значения  с 
        заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива, метод 
        Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый 
        массив,  остается  без  изменений),  метод  Multi,  умножающий  каждый  элемент  массива  на 
        определённое число, свойство MaxCount, возвращающее количество максимальных элементов.  
        б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу 
        библиотеки 
        е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
 */
using System;
using System.Collections.Generic;

namespace OneRangeArray
{
    public class Array
    {
        int[] tmp;// массив всех элементов
        int[,] pairIndex;// массив, хранящий индексы пар
        int countOfPair;// количество пар с одним элементом, делящимся на 3, а вторым - нет
        long sum;// сумма всех элементов массива

        public int CountOfPair
        {
            get { return countOfPair; }
        }

        public long Sum
        {
            get { return sum; }
        }

        public int MaxCount 
        {
            get
            {
                int result = 0;
                if (tmp.Length == 0)
                {
                    return 0;
                }

                int max = tmp[0];
                foreach(var x in tmp)
                {
                    if (max < x)
                    {
                        max = x;
                    }
                }
                foreach (var x in tmp)
                {
                    if (max == x)
                    {
                        result++;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Конструктор, создающий массив размера length. Массив заполняется элементами, начиная с minValue
        /// с шагом step.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="minValue"></param>
        /// <param name="step"></param>
        public Array(int length, int minValue, int step)
        {
            tmp = new int[length];
            pairIndex = new int[length, 2];
            countOfPair = 0;
            sum = 0;

            int tempValue = minValue;

            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = tempValue;
                sum += tempValue;

                try
                {
                    checked
                    {
                        tempValue += step;
                    }
                }
                catch (OverflowException e)
                {

                }

                if (i > 1 && ((tmp[i - 1] % 3 == 0
                        && tmp[i] % 3 != 0) || (tmp[i - 1] % 3 != 0 && tmp[i] % 3 == 0)))
                {
                    pairIndex[countOfPair, 0] = i - 1;
                    pairIndex[countOfPair, 1] = i;
                    countOfPair++;
                }
            }
        }
        
        public Dictionary<int, int> Frequency()
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            foreach(var x in tmp)
            {
                result[x] = 0;
            }
            foreach (var x in tmp)
            {
                result[x]++;
            }

            return result;
        }

        public int[] Inverse()
        {
            int length = tmp.Length;
            int[] result = new int[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = -tmp[i];
            }

            return result;
        }

        public void Multi(int multiplicator)
        {
            int length = tmp.Length;

            for (int i = 0; i < length; i++)
            {
                try
                {
                    checked
                    {
                        int x = tmp[i] * multiplicator;
                        tmp[i] = x;
                    }
                }
                catch (OverflowException e)
                {

                }
            }
        }

        public void PrintAll()
        {
            foreach (int i in tmp)
            {
                Console.Write($"{i} ");
            }
        }

        public void PrintPairs()
        {
            for (int i = 0; i < countOfPair; i++)
            {
                Console.WriteLine($"{tmp[pairIndex[i, 0]],7} {tmp[pairIndex[i, 1]],7}");
            }
        }
    }
}
