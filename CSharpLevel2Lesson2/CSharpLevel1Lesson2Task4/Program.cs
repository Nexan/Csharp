/* Михеев Константин
    Задание 4:
        Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На 
        выходе  истина,  если  прошел  авторизацию, и ложь, если не прошел (Логин: root, Password: 
        GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь 
        вводит  логин  и  пароль,  программа  пропускает  его  дальше  или  не пропускает. С помощью 
        цикла do while ограничить ввод пароля тремя попытками. 
 */
using System;

namespace CSharpLevel1Lesson2Task4
{
    class Program
    {
        static bool CheckLoginPassword(string userLogin, string userPassword)
        {
            string currentLogin = "root";
            string currentPassword = "GeekBrains";

            return (userLogin.ToLower() == currentLogin.ToLower() && userPassword == currentPassword);
        }

        static void AuthMessage(int tryCount)
        {
            Console.Clear();
            Console.WriteLine("Вы ввели неверный логин или пароль.");
            Console.WriteLine($"Попробуйте ввести логин и пароль снова. Количество оставшихся попыток: {tryCount}");
        }

        // выводит текст сообщения title на экран и ожидает ввод строки с консоли
        // если параметр passMode равен true, то делает невидимым текст для ввода пароля
        static string GetString(string title, bool passMode = false)
        {
            Console.WriteLine(title);
            ConsoleColor textColor = Console.ForegroundColor;

            if (passMode)
            {
                Console.ForegroundColor = Console.BackgroundColor;
                Console.CursorVisible   = false;
            }

            string result = Console.ReadLine();

            if (passMode)
            {
                Console.ForegroundColor = textColor;
                Console.CursorVisible = true;
            }

            return result;
        }

        // дает ввести логин и пароль tryCount раз в случае неверного ввода
        static bool Auth(int tryCount)
        {
            bool result = false;
            int i = 0;

            do
            {
                if (i > 0)
                {
                    AuthMessage(tryCount - i);
                }

                result = CheckLoginPassword(GetString("Введите логин"), GetString("Введите пароль", true));
            } while (++i < tryCount && !result);

            return result;
        }


        static void Main(string[] args)
        {
            if (!Auth(3))
            {
                Console.Clear();
                Console.WriteLine("Вы ввели неверный логин или пароль.");
                Console.WriteLine("Количество попыток ввести логин и пароль исчерпано.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Поздравляю! Вы ввели верный логин и пароль.");
            }

            Console.ReadKey();
        }
    }
}
