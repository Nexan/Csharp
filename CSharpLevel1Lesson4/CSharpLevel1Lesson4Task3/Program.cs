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

namespace CSharpLevel1Lesson4Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            OneRangeArray.Array arr = new OneRangeArray.Array(30, 10000000, 20000000);

            Console.WriteLine("Печать всех элементов массива:");
            arr.PrintAll();
            Console.WriteLine($"\n\nСумма всех элементов массива: {arr.Sum}");
            Console.WriteLine($"Количество максимальных элементов массива: {arr.MaxCount}");
            arr.Multi(5);
            Console.WriteLine("\nПечать всех элементов массива после умножения на 2:");
            arr.PrintAll();
            Console.WriteLine($"\nКоличество максимальных элементов массива: {arr.MaxCount}");
            Dictionary<int, int> freq = arr.Frequency();
            Console.WriteLine("Частоты элементов массива:");
            foreach(var x in freq.Keys)
            {
                Console.WriteLine($"{x, 12}: {freq[x]}");
            }
            Console.ReadKey();
        }
    }
}
