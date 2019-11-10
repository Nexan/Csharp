/* Михеев Константин
    Задание 3:
        Для  двух  строк  написать  метод,  определяющий,  является  ли  одна  строка  перестановкой другой. 
        Например: badc ​являются перестановкой ​abcd.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLevel1Lesson5Task3
{
    class Program
    {
        /// <summary>
        /// Проверяет, является ли строка str1 перестановкой str2.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        static bool IsPermutation(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            char[] a = new char[str1.Length];
            char[] b = new char[str2.Length];

            int i = 0;
            foreach (var ch in str1)
            {
                a[i++] = Convert.ToChar(ch.ToString().ToLower());
            }
            i = 0;
            foreach (var ch in str2)
            {
                b[i++] = Convert.ToChar(ch.ToString().ToLower());
            }

            Array.Sort(a);
            Array.Sort(b);
            for (i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку:");
            string s1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string s2 = Console.ReadLine();

            if (IsPermutation(s1, s2))
            {
                Console.WriteLine($"Строка {s1} является перестановкой {s2}");
            }
            else
            {
                Console.WriteLine($"Строка {s1} не является перестановкой {s2}");
            }

            Console.ReadKey();
        }
    }
}
