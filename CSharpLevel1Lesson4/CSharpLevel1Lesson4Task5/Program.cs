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
using TwoRangeArray;

namespace CSharpLevel1Lesson4Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Чтение массива из файла data1.txt");
            Array2D arr = new Array2D("data1.txt");
            arr.Print();
            Console.WriteLine($"Минимальный элемент массива равен {arr.Min}");
            Console.WriteLine($"Максимальный элемент массива равен {arr.Max}");
            Console.WriteLine($"Сумма всех элементов массива равна {arr.Sum()}");
            Console.WriteLine($"Сумма всех элементов массива больших 2 равна {arr.Sum(2)}");
            int rowind, colind;
            arr.IndexOfMaxElement(out rowind, out colind);
            Console.WriteLine($"Индекс максимального элемента массива {rowind}, {colind}");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Чтение массива из файла data2.txt. В файле больше строк, чем указано в первой строке.");
            arr = new Array2D("data2.txt");
            arr.Print();
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Чтение массива из файла data3.txt. В файле меньше строк, чем указано в первой строке. Оставшиеся строки заполняются нулями.");
            arr = new Array2D("data3.txt");
            arr.Print();
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Попытка прочитать из несуществующего файла.");
            try
            {
                arr = new Array2D("data.txt");
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Попытка прочитать из файла data4.txt. В одной из строк больше значений, чем заявленное количество колонок.");
            try
            {
                arr = new Array2D("data4.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

            Console.Clear();
            arr = new Array2D(4, 5);
            arr.WriteToFile("result.txt");
            Console.WriteLine("Создан массив размером 4 на 5 и записан в файл result.txt.");
            Console.ReadKey();
        }
    }
}
