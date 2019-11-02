/* Михеев Константин
    Задание 2:
        Вести  вес  и  рост  человека.  Рассчитать  и  вывести  индекс  массы  тела (ИМТ) по формуле 
        I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLevel1Lesson1Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваш вес в кг: ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите ваш рост в метрах (например, 1.75 или 1,75): ");
            double height = Convert.ToDouble(Console.ReadLine());

            double weightIndex = weight / (height * height);


            Console.WriteLine($"Для веса {weight} кг и роста {height} м, индекс массы тела равен {weightIndex:F0}");

            Console.ReadKey();
        }
    }
}
