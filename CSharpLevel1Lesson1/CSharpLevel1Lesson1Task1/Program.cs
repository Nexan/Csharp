/* Михеев Константин
    Задание 1:
        Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, 
        рост, вес). В результате вся информация выводится в одну строчку: 
        а) используя  склеивание; 
        б) используя форматированный вывод; 
        в) используя вывод со знаком $. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLevel1Lesson1Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("Введите ваш возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите ваш рост в метрах (например, 1.75 или 1,75): ");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите ваш вес в кг: ");
            double weight = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine(name + " " + surname + ", возраст: " + age + ", рост: " + height + " м, вес: " + weight + " кг");
            Console.WriteLine("{0} {1}, возраст: {2}, рост: {3:F2} м, вес: {4:F3} кг", name, surname, age, height, weight);
            Console.WriteLine($"{name} {surname}, возраст: {age}, рост: {height} м, вес: {weight} кг");

            Console.ReadKey();
        }
    }
}
