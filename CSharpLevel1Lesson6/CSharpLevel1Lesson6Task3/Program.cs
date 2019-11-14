/* Михеев Константин
    Задание 3:
        Переделать программу Пример использования коллекций для решения следующих задач:
        а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
        б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
        в) отсортировать список по возрасту студента;
        г) *отсортировать список по курсу и возрасту студента;
        д) разработать единый метод подсчета количества студентов по различным параметрам
            выбора с помощью делегата и методов предикатов.
 */
using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpLevel1Lesson6Task3
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;

        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }

    class Program
    {
        static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {
            return String.Compare(st1.firstName, st2.firstName);          // Сравниваем две строки
        }

        /// <summary>
        /// Сравнение студентов по возрасту.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        static int AgeCompare(Student s1, Student s2)
        {
            if (s1.age == s2.age)
            {
                return 0;
            }
            if (s1.age < s2.age)
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// Сравнение студентов по курсу и возрасту.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        static int AgeCourseCompare(Student s1, Student s2)
        {
            if (s1.course < s2.course)
            {
                return -1;
            }
            if (s1.course > s2.course)
            {
                return 1;
            }

            return AgeCompare(s1, s2);
        }


        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            int studentCount5Course = 0;// количество студентов 5 курса
            int studentCount6Course = 0;// количество студентов 6 курса
            Dictionary<int, int> courseStat = new Dictionary<int, int>();// количество студентов в возрасет от 18 до 20 лет по курсам

            List<Student> list = new List<Student>();                             // Создаем список студентов
            StreamReader sr = new StreamReader("students_6.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    int course = int.Parse(s[5]);
                    int age = int.Parse(s[6]);

                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], course, age, int.Parse(s[7]), s[8]));

                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (course < 5) bakalavr++; else magistr++;

                    // Количество студентов 5-го и 6-го курсов
                    if (course == 5)
                    {
                        studentCount5Course++;
                    }
                    else
                    {
                        if (course == 6)
                        {
                            studentCount6Course++;
                        }
                    }

                    // Собираем статистику по студентам в возрасте от 18 до 20 лет по курсам
                    if (age >= 18 && age <= 20)
                    {
                        if (courseStat.ContainsKey(course))
                        {
                            courseStat[course]++;
                        }
                        else
                        {
                            courseStat[course] = 1;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();

            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine($"Студентов 5 курса: {studentCount5Course}");
            Console.WriteLine($"Студентов 6 курса: {studentCount6Course}");
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);

            Console.WriteLine("\nСписок отсортированный по фамилиям:");
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Количество студентов в возрасте от 18 до 20 лет по курсам:");
            Console.WriteLine(" Курс | Кол-во");
            foreach (var pairs in courseStat)
            {
                Console.WriteLine($" {pairs.Key,4} | {pairs.Value,4}");
            }
            Console.ReadKey();

            Console.Clear();
            // сортировка по возрасту
            list.Sort(new Comparison<Student>(AgeCompare));
            Console.WriteLine("Список студентов, отсортированный по возрасту:");
            foreach (var v in list)
            {
                Console.WriteLine($"{v.firstName,30}|{v.age,4}");
            }
            Console.ReadKey();

            Console.Clear();
            // сортировка по курсу и возрасту
            list.Sort(new Comparison<Student>(AgeCourseCompare));
            Console.WriteLine("Список студентов, отсортированный по курсу и возрасту:");
            Console.WriteLine("               ФИО            | Курс | Возраст");
            foreach (var v in list)
            {
                Console.WriteLine($"{v.firstName,30}|{v.course,4}  |{v.age,4}");
            }

            Console.ReadKey();
        }
    }
}