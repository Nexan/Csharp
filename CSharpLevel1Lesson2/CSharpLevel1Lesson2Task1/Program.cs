/* Михеев Константин
    Задание 1:
        Написать метод, возвращающий минимальное из трёх чисел.
 */
using System;

namespace CSharpLevel1Lesson2Task1
{
    class Program
    {
        static int min(int a, int b) => (a < b) ? a : b;

        static int min(int a, int b, int c) => min(a, min(b, c));

        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое целое число:");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите второе целое число:");
            int y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите третье целое число:");
            int z = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Минимальное из чисел: {x}, {y}, {z}; равно {min(x, y, z)}");
            Console.ReadKey();
        }
    }
}
