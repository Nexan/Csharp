/* Михеев Константин
    Задание 6:
        Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
 */

using System;

namespace CSharpLevel1Lesson1Task6
{
    public class MyConsole
    {
        void Pause()
        {
            Console.ReadKey();
        }

        void Print(string msg)
        {
            Console.WriteLine(msg);
            Pause();
        }

        void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
            Pause();
        }

        void PrintWithClear(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
            Pause();
        }

        void PrintWithClear(string msg, int x, int y)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
            Pause();
        }
    }
}
