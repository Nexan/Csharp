/* Михеев Константин
    Задание 5:
        *а)  Реализовать  библиотеку  с  классом  для  работы  с  двумерным  массивом.  Реализовать 
        конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают 
        сумму  всех  элементов  массива,  сумму  всех  элементов  массива  больше  заданного,  свойство, 
        возвращающее  минимальный  элемент  массива,  свойство,  возвращающее  максимальный 
        элемент  массива,  метод,  возвращающий  номер  максимального  элемента  массива  (через 
        параметры, используя модификатор ref или out). 
        **б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные 
        в файл. 
        **в) Обработать возможные исключительные ситуации при работе с файлами. 
 */
using System;
using System.IO;

namespace TwoRangeArray
{
    public class Array2D
    {
        int[,] tmp;
        int rowsCount, colsCount;
        int min, max;

        #region // Свойства
        public int Min
        {
            get { return min; }
        }

        public int Max
        {
            get { return max; }
        }
        #endregion

        #region // Вспомогательные методы
        /// <summary>
        /// Заполняет массив случайными числами из диапазона int.MinValue - int.MaxValue.
        /// </summary>
        private void FillArray()
        {
            tmp = new int[rowsCount, colsCount];
            int minValue = int.MinValue;
            int maxValue = int.MaxValue;
            int min = maxValue;
            int max = minValue;

            Random rnd = new Random();

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    int a = rnd.Next(minValue, maxValue);
                    tmp[i, j] = a;
                    if (a < min)
                    {
                        min = a;
                    }
                    if (a > max)
                    {
                        max = a;
                    }
                }
            }
        }

        /// <summary>
        /// Считывает из строки значения, разделенные пробелами, преображует их в целые числа и записывает в массив.
        /// В параметр count передается ожидаемое количество целых чисел. Если переданное в строке количество чисел не равно count, выбрасывается исключение.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private int[] GetIntFromString(string s, int count)
        {
            string[] tempArray = s.Split(' ');

            if (tempArray.Length != count)
            {
                throw new Exception($"В переданной строке должно быть {count} значений, получено {tempArray.Length} значений.");
            }

            int[] result = new int[count];

            for(int i = 0; i < count; i++)
            {
                result[i] = Convert.ToInt32(tempArray[i]);
            }

            return result;
        }

        /// <summary>
        /// Выводит двумерный массив на экран.
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    Console.Write($"{tmp[i, j],12}");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Записывает в файл filename массив.
        /// </summary>
        /// <param name="filename"></param>
        public void WriteToFile(string filename)
        {
            string[] tempArray = new string[rowsCount + 1];
            tempArray[0] = $"{rowsCount} {colsCount}";

            for (int i = 0; i < rowsCount; i++)
            {
                string delimiter = "", res = "";

                for (int j = 0; j < colsCount; j++)
                {
                    res += $"{delimiter}{tmp[i, j]}";
                    delimiter = " ";
                }

                tempArray[i + 1] = res;
            }

            File.WriteAllLines(filename, tempArray);
        }
        #endregion

        #region // Конструкторы
        /// <summary>
        /// Создает массив с количеством строк rowsCount и количеством колонок colsCount.
        /// </summary>
        /// <param name="rowsCount"></param>
        /// <param name="colsCount"></param>
        public Array2D(int rowsCount, int colsCount)
        {
            this.rowsCount = rowsCount;
            this.colsCount = colsCount;

            FillArray();
        }

        /// <summary>
        /// Создает и заполняет квадратный массив случайными числами.
        /// </summary>
        /// <param name="length"></param>
        public Array2D(int length)
        {
            rowsCount = length;
            colsCount = length;

            FillArray();
        }

        /// <summary>
        /// Считывает массив из файла. В первой строке через пробел указываются сначала количество строк массива,
        /// а затем количество колонок массива.
        /// Каждая следуюущая строка соответствует одной строке массива. Значения в строке разделяются пробелами.
        /// Количество значений в строке должно соответствовать указанному в первой строке количеству колонок массива.
        /// Количество строк может быть как меньше, так и больше указанного количества строк массива.
        /// </summary>
        /// <param name="filename"></param>
        public Array2D(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new Exception($"Файл {filename} не найден.");
            }
            
            string[] allStrings = File.ReadAllLines(filename);
            if (allStrings.Length == 0)
            {
                tmp = new int[0, 0];
                return;
            }

            int[] tempArray = GetIntFromString(allStrings[0], 2);
            rowsCount = tempArray[0];
            colsCount = tempArray[1];
            tmp = new int[rowsCount, colsCount];
            min = int.MaxValue;
            max = int.MinValue;

            for (int i = 0; i < rowsCount; i++)
            {
                if (i + 1 >= allStrings.Length)
                {
                    return;
                }

                tempArray = GetIntFromString(allStrings[i + 1], colsCount);
                for (int j = 0; j < colsCount; j++)
                {
                    int a = tempArray[j];
                    tmp[i, j] = a;
                    if (a < min)
                    {
                        min = a;
                    }
                    if (a > max)
                    {
                        max = a;
                    }
                }
            }
        }
        #endregion

        #region // Методы определения суммы всех элементов и индекса максимального элемента
        /// <summary>
        /// Сумма всех элементов массива.
        /// </summary>
        /// <returns></returns>
        public long Sum()
        {
            long sum = 0;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    sum += tmp[i, j];
                }
            }

            return sum;
        }

        /// <summary>
        ///  Сумма всех элементов массива больше minValue.
        /// </summary>
        /// <param name="minValue"></param>
        /// <returns></returns>
        public long Sum(int minValue)
        {
            long sum = 0;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    int a = tmp[i, j];
                    if (a > minValue)
                    {
                        sum += a;
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// Индекс элемента массива, равного максимальному.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        public void IndexOfMaxElement(out int rowIndex, out int colIndex)
        {
            rowIndex = -1;
            colIndex = -1;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    int a = tmp[i, j];
                    if (a == max)
                    {
                        rowIndex = i;
                        colIndex = j;
                        return;
                    }
                }
            }
        }
        #endregion
    }
}
