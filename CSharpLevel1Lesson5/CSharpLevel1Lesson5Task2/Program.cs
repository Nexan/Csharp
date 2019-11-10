/* Михеев Константин
    Задание 2:
        Разработать  статический  класс  ​Message,​ содержащий следующие статические методы для 
        обработки текста: 
        а) Вывести только те слова сообщения,  которые содержат не более n букв. 
        б) Удалить из сообщения все слова, которые заканчиваются на заданный символ. 
        в) Найти самое длинное слово сообщения. 
        г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения. 
        д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в 
        него передается массив слов и текст, в качестве результата метод возвращает сколько раз 
        каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary. 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLevel1Lesson5Task2
{
    public static class Message
    {
        /// <summary>
        /// Формирует из переданного сообщения message массив слов.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static string[] WordFromMessage(string message)
        {
            List<char> temp = new List<char>();

            foreach (var ch in message)
            {
                if (char.IsPunctuation(ch))
                {
                    temp.Add(ch);
                }
            }
            foreach (var ch in temp)
            {
                message = message.Replace(ch, ' ');
            }

            List<string> words = new List<string>();
            string[] tempWords = message.Split(' ');
            foreach (var s in tempWords)
            {
                if (s.Trim() != "")
                {
                    words.Add(s);
                }
            }

            return words.ToArray();
        }

        /// <summary>
        /// Находит в сообщении message все слова с длиной n.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<string> Words(string message, int n)
        {
            List<string> result = new List<string>();

            string[] temp = WordFromMessage(message);

            foreach(var s in temp)
            {
                if (s.Length <= n)
                {
                    result.Add(s);
                }
            }

            return result;
        }

        /// <summary>
        /// Удаляет из строки message слова, заканчивающиеся на символ endSymbol и возвращает новую строку.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="endSymbol"></param>
        /// <returns></returns>
        public static string DeleteWords(string message, char endSymbol)
        {
            int curIndex = 0;
            string result = message;

            string[] temp = WordFromMessage(message);
            
            foreach(var s in temp)
            {
                curIndex = result.IndexOf(s, curIndex);

                if (s.ToLower().EndsWith(endSymbol.ToString().ToLower()))
                {
                    result = result.Remove(curIndex, s.Length);
                }
                else
                {
                    curIndex += s.Length;
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает самую длинную строку result в сообщении message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool MaxWord(string message, out string result)
        {
            string[] temp = WordFromMessage(message);
            int length = 0;
            int index = -1;

            for (int i = 0; i < temp.Length; i++)
            {
                int l = temp[i].Length;

                if (l > length)
                {
                    index = i;
                    length = l;
                }
            }

            if (index == -1)
            {
                result = "";
                return false;
            }
            else
            {
                result = temp[index];
                return true;
            }
        }

        /// <summary>
        /// Возвращает строку, созданную из самых длинных слов строки message.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string StringFromMaxWords(string message)
        {
            string[] temp = WordFromMessage(message);
            int length = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                int l = temp[i].Length;

                if (l > length)
                {
                    length = l;
                }
            }

            StringBuilder result = new StringBuilder();
            foreach (var s in temp)
            {
                if (s.Length == length)
                {
                    result.Append(s);
                    result.Append(' ');
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Возвращает количество вхождений слов из массива keyWords в строку message.
        /// </summary>
        /// <param name="keyWords"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Dictionary<string, int> Frequency(string[] keyWords, string message)
        {
            string[] temp = WordFromMessage(message);
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var s in keyWords)
            {
                result.Add(s.ToLower(), 0);
            }
            foreach (var s in temp)
            {
                string tempString = s.ToLower();

                if (result.ContainsKey(tempString))
                {
                    result[tempString]++;
                }
            }

            return result;
        }

        public static void PrintFrequency(Dictionary<string, int> frequency)
        {
            foreach (var key in frequency.Keys)
            {
                Console.WriteLine($"{key}: {frequency[key]}");
            }
        }

        public static void PrintWords(List<string> list)
        {
            foreach(var s in list)
            {
                Console.WriteLine(s);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сообщение:");
            string s = Console.ReadLine();

            Console.WriteLine("Введите длину слова:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nСписок слов с длиной не более {n}:");
            Message.PrintWords(Message.Words(s, n));

            Console.WriteLine("\nВведите символ:");
            char ch = Convert.ToChar(Console.ReadLine());
            string tempString = Message.DeleteWords(s, ch);
            Console.WriteLine("Строка после удаления символа:");
            Console.WriteLine(tempString);

            string maxWord;
            if (Message.MaxWord(s, out maxWord))
            {
                Console.WriteLine($"\nСамое длинное слово: {maxWord}");
            }

            Console.WriteLine($"\nСтрока, составленная из самых длинных слов: {Message.StringFromMaxWords(s)}");

            Console.WriteLine("Частоты вхождения слов в строку:");
            Message.PrintFrequency(Message.Frequency(new string[] {"мама", "раму", "Рома"}, s));

            Console.ReadKey();
        }
    }
}
