/* Михеев Константин
    Задание 4:
        Решить  задачу  с  логинами  из  урока  2,  только  логины  и  пароли  считать  из  файла  в  массив. 
        Создайте структуру Account, содержащую Login и Password.
 */
using System;
using System.IO;

namespace CSharpLevel1Lesson4Task4
{
    struct Account
    {
        string login;
        string password;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }
    }

    class Program
    {
        static Account ReadAccountInfoFromFile(string filename)
        {
            Account acc = new Account();

            if (!File.Exists(filename))
            {
                throw new Exception($"Файл {filename} не найден.");
            }

            string[] tmp = File.ReadAllLines(filename);
            if (tmp.Length < 2)
            {
                throw new Exception($"В файле должно быть 2 строки: 1-я строка - логин, 2-я - пароль.");
            }

            if (tmp[0].Trim() == "")
            {
                throw new Exception("Не указан логин.");
            }
            if (tmp[1].Trim() == "")
            {
                throw new Exception("Не указан пароль.");
            }

            acc.Login    = tmp[0];
            acc.Password = tmp[1];

            return acc;
        }

        static void Main(string[] args)
        {
            Account account = ReadAccountInfoFromFile("data.txt");

            Console.WriteLine($"Login: {account.Login}\nPassword: {account.Password}");
            Console.ReadKey();
        }
    }
}
