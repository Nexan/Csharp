/* Михеев Константин
    Задание 5:
        а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания. 
        б) *Сделать задание, только вывод организовать в центре экрана. 
        в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLevel1Lesson1Task5
{
    class Program
    {
        static void Print(string msg, int x, int y)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            string s = "Константин Михеев, г. Екатеринбург";
            int length = s.Length;

            Console.WriteLine(s);
            Console.ReadKey();

            Console.Clear();
            Console.CursorLeft = (Console.WindowWidth - length) / 2;
            Console.CursorTop = Console.WindowHeight / 2;
            Console.WriteLine(s);
            Console.ReadKey();

            Print(s, 45, 15);
        }
    }
}
