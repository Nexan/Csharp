/* Михеев Константин
    Задание 4:
        На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней 
        школы.  В  первой  строке  сообщается  количество  учеников  N,  которое  не  меньше  10,  но  не 
        превосходит 100, каждая из следующих N строк имеет следующий формат: 
        <Фамилия> <Имя> <оценки>, 
        где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не 
        более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по 
        пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. 
        Пример входной строки: 
        Иванов Петр 4 5 3 
        Требуется  написать  как  можно  более  эффективную  программу,  которая  будет  выводить  на  экран 
        фамилии  и  имена  трёх  худших  по  среднему баллу учеников. Если среди остальных есть ученики, 
        набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена. 
 */
using System;
using System.IO;

namespace CSharpLevel1Lesson5Task4
{
    struct Data
    {
        public string name;
        public string surname;
        public int value1;
        public int value2;
        public int value3;
        public double average;
    }

    class Program
    {
        /// <summary>
        /// Парсит строку s в структуру Data.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static Data StringToData(string s)
        {
            Data result = new Data();
            string[] temp = s.Split(' ');

            result.name     = temp[0];
            result.surname  = temp[1];
            result.value1 = Convert.ToInt32(temp[2]);
            result.value2 = Convert.ToInt32(temp[3]);
            result.value3 = Convert.ToInt32(temp[4]);
            result.average = (result.value1 + result.value2 + result.value3) / 3.0;

            return result;
        }

        /// <summary>
        /// Из массива строк получает массив структур Data.
        /// </summary>
        /// <param name="sa"></param>
        /// <returns></returns>
        static Data[] GetData(string[] sa)
        {
            Data[] result = new Data[sa.Length];

            for (int i = 0; i < sa.Length; i++)
            {
                result[i] = StringToData(sa[i]);

                for (int j = i; j > 0; j--)
                {
                    if (result[j - 1].average <= result[j].average)
                    {
                        break;
                    }
                    Data t = result[j - 1];
                    result[j - 1] = result[j];
                    result[j] = t;
                }
            }

            return result;
        }

        /// <summary>
        /// Получает массив Data самых худших студентов. В count задается количество худших средних баллов.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static Data[] GetBadStudents(Data[] data, int count)
        {
            Data[] result = new Data[data.Length];
            int i = 0, j = 0, k = 0;
            
            while (j < data.Length)
            {
                if (i++ == count)
                {
                    break;
                }
                result[k++] = data[j++];
                while (j < data.Length && data[j].average == data[j - 1].average)
                {
                    result[k++] = data[j++];
                }
            }

            return result;
        }

        static string[] ReadDataFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new Exception($"Файл {filename} не найден.");
            }

            return File.ReadAllLines(filename);
        }

        static void PrintData(Data[] data)
        {
            Console.WriteLine("{0,20}|{1,15}|{2,10}|{3,20}", "Фамилия", "Имя", "Оценки", "Средний балл");

            foreach (var d in data)
            {
                if (d.average == 0)
                {
                    continue;
                }
                Console.WriteLine($"{d.name,20}|{d.surname,15}|{d.value1,2}{d.value2,2}{d.value3,2}    |{d.average,20}");
            }
        }


        static void Main(string[] args)
        {
            Data[] temp = GetData(ReadDataFromFile("data.txt"));
            Console.WriteLine("Все результаты:");
            PrintData(temp);

            Console.WriteLine("\nХудшие студенты:");
            Data[] badStudents = GetBadStudents(temp, 3);
            PrintData(badStudents);

            Console.ReadKey();
        }
    }
}
