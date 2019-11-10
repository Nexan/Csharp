/* Михеев Константин
    Задание 1:
        Создать  программу,  которая  будет  проверять  корректность  ввода  логина.  Корректным 
        логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита 
        или цифры, при этом цифра не может быть первой: 
        а) без использования регулярных выражений; 
        б) **с использованием регулярных выражений.
 */
using System;
using System.Text.RegularExpressions;

namespace CSharpLevel1Lesson5Task1
{
    class Program
    {
        static string GetLogin()
        {
            Console.WriteLine("Введите логин:");
            return Console.ReadLine();
        }

        static bool IsLetter(char letter)
        {
            return ((letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z'));
        }

        static bool IsNumber(char letter)
        {
            return char.IsDigit(letter);
        }

        /// <summary>
        /// Проверяет логин методами класса String.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        static bool CheckLoginNonRegEx(string login)
        {
            int length = login.Length;

            if (length < 2 || length > 10)
            {
                return false;
            }
            if (!IsLetter(login[0]))
            {
                return false;
            }

            foreach (var ch in login)
            {
                if (!(IsLetter(ch) || IsNumber(ch)))
                {
                    return false;
                }
            }

            return true;
        }

        // Проверяет логин, используя регулярные выражения.
        static bool CheckLoginRegEx(string login)
        {
            Regex regex = new Regex(@"^[A-Za-z][A-Za-z0-9]{1,9}$");

            return regex.IsMatch(login);
        }

        /// <summary>
        /// Пример работы с логином через класс String.
        /// </summary>
        static void EnterNonRegEx()
        {
            string login;

            Console.WriteLine("Пример работы с логином без регулярных выражений.");
            Console.WriteLine("Для завершения введите пустую строку.");

            do
            {
                login = GetLogin();
                if (CheckLoginNonRegEx(login))
                {
                    Console.WriteLine("Это корректный логин.");
                }
                else
                {
                    ErrorMessage();
                }

                Console.ReadKey();
                Console.Clear();
            }
            while (login.Trim() != "");
        }

        /// <summary>
        /// Пример работы с логином через регулярные выражения.
        /// </summary>
        static void EnterRegEx()
        {
            string login;

            Console.WriteLine("Пример работы с логином через регулярные выражения.");
            Console.WriteLine("Для завершения введите пустую строку.");

            do
            {
                login = GetLogin();
                if (CheckLoginRegEx(login))
                {
                    Console.WriteLine("Это корректный логин.");
                }
                else
                {
                    ErrorMessage();
                }

                Console.ReadKey();
                Console.Clear();
            }
            while (login.Trim() != "");
        }

        static void ErrorMessage()
        {
            Console.WriteLine("Логин должен содержать только латинские буквы и цифры.");
            Console.WriteLine("Его длина должна быть от 2 до 10 символов.");
            Console.WriteLine("И первый символ должен быть буквой.");
        }

        static void Main(string[] args)
        {
            EnterNonRegEx();
            EnterRegEx();
        }
    }
}
