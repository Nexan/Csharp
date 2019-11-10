/* Михеев Константин
    Задание 5:
    **Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет.
    Например: «Шариковую ручку изобрели в древнем Египте», «Да».
    Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку.
    Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ.
 */
using System;
using System.IO;

namespace CSharpLevel1Lesson5Task5
{
    public class TrueFalse
    {
        struct AskAnswers
        {
            string ask;
            string answer;

            public string Ask
            {
                get { return ask; }
            }

            public string Answer
            {
                get { return answer; }
            }

            public AskAnswers(string ask, string answer)
            {
                this.ask = ask;
                this.answer = answer.ToLower();
            }
        }

        AskAnswers[] askanswers;
        int rightAnswers = 0;
        int wrongAnswers = 0;

        public int RightAnswers
        {
            get { return rightAnswers; }
        }

        public int WrongAnswers
        {
            get { return wrongAnswers; }
        }

        public TrueFalse(string[] data)
        {
            ReadStrings(data);
        }

        public TrueFalse(string filename)
        {
            ReadStrings(ReadFile(filename));
        }

        void ReadStrings(string[] data)
        {
            int length = data.Length;
            askanswers = new AskAnswers[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                askanswers[i / 2] = new AskAnswers(data[i], data[i + 1]);
            }
        }

        string[] ReadFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new Exception($"Файл {filename} не найден.");
            }

            return File.ReadAllLines(filename);
        }

        public void Play(int count)
        {
            rightAnswers = 0;
            wrongAnswers = 0;
            int realCount = Math.Min(count, askanswers.Length);
            int[] numbersAsks = new int[realCount];
            Random rnd = new Random();

            for(int i = 0; i < numbersAsks.Length; i++)
            {
                numbersAsks[i] = -1;
            }

            Console.WriteLine($"Игра \"Верю - не верю\". Будет задано {count} вопросов, на которые надо отвечать да или нет.\nДля продолжения нажмите любую клавишу.");
            Console.ReadKey();

            for (int i = 0; i < realCount; i++)
            {
                int number;

                while(true)
                {
                    number = rnd.Next(0, askanswers.Length);
                    if(Array.IndexOf(numbersAsks, number) == -1)
                    {
                        numbersAsks[i] = number;
                        break;
                    }
                }

                Console.Clear();
                Console.WriteLine($"Вопрос {i + 1}: {askanswers[number].Ask}");
                Console.WriteLine("\nВерю?");

                string answer = Console.ReadLine().Trim();
                if (askanswers[number].Answer == answer)
                {
                    rightAnswers++;
                    Console.WriteLine("Правильно!");
                }
                else
                {
                    Console.WriteLine("Не правильно!");
                }

                Console.ReadKey();
            }

            wrongAnswers = count - rightAnswers;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            TrueFalse tf = new TrueFalse(@"..\..\data.txt");

            tf.Play(5);

            Console.Clear();
            Console.WriteLine("Игра окончена.");
            Console.WriteLine($"Правильных ответов: {tf.RightAnswers}");
            Console.WriteLine($"Неправильных ответов: {tf.WrongAnswers}");

            Console.ReadKey();
        }
    }
}
