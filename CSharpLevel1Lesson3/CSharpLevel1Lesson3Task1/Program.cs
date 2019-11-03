/* Михеев Константин
    Задание 1:
        а)  Дописать  структуру  Complex,  добавив  метод  вычитания  комплексных  чисел. 
        Продемонстрировать работу структуры. 
        б)  Дописать  класс  Complex,  добавив  методы  вычитания  и  произведения  чисел. Проверить 
        работу класса. 
        в) Добавить диалог с использованием switch демонстрирующий работу класса. 
 */
using System;

namespace CSharpLevel1Lesson3Task1
{

    namespace StructComplex
    {
        struct Complex
        {
            public double im;
            public double re;

            public Complex plus(Complex x)
            {
                Complex y;
                y.im = im + x.im;
                y.re = re + x.re;

                return y;
            }

            public Complex sub(Complex x)
            {
                Complex y;
                y.im = im - x.im;
                y.re = re - x.re;

                return y;
            }

            public Complex multi(Complex x)
            {
                Complex y;
                y.im = re * x.im + im * x.re;
                y.re = re * x.re - im * x.im;

                return y;
            }

            public override string ToString()
            {
                if (re == 0 && im == 0)
                {
                    return "0";
                }
                if (im == 0)
                {
                    return $"{re}";
                }
                if (re == 0)
                {
                    return $"{im}i";
                }
                if (im < 0)
                {
                    return $"{re}{im}i";
                }
                return $"{re}+{im}i";
            }
        }
    }

    namespace ClassComplex
    {
        class Complex
        {
            double im;
            double re;

            public double Re
            {
                get { return re; }
                set
                {
                    re = value;
                }
            }

            public double Im
            {
                get { return im; }
                set
                {
                    im = value;
                }
            }

            public Complex()
            {
                re = 0;
                im = 0;
            }

            public Complex(double re, double im)
            {
                this.re = re;
                this.im = im;
            }

            public Complex plus(Complex x)
            {
                Complex y = new Complex();
                y.im = im + x.im;
                y.re = re + x.re;

                return y;
            }

            public Complex sub(Complex x)
            {
                Complex y = new Complex();
                y.im = im - x.im;
                y.re = re - x.re;

                return y;
            }

            public Complex multi(Complex x)
            {
                Complex y = new Complex();
                y.im = re * x.im + im * x.re;
                y.re = re * x.re - im * x.im;

                return y;
            }

            public override string ToString()
            {
                if (re == 0 && im == 0)
                {
                    return "0";
                }
                if (im == 0)
                {
                    return $"{re}";
                }
                if (re == 0)
                {
                    return $"{im}i";
                }
                if (im < 0)
                {
                    return $"{re}{im}i";
                }
                return $"{re}+{im}i";
            }
        }
    }

    class Program
    {
        static double GetDouble(string message)
        {
            Console.WriteLine(message);
            return Convert.ToDouble(Console.ReadLine());
        }

        static ClassComplex.Complex GetResult(ClassComplex.Complex a, ClassComplex.Complex b, string action)
        {
            ClassComplex.Complex result = new ClassComplex.Complex();

            switch (action)
            {
                case "+":
                    result = a.plus(b);
                    break;
                case "-":
                    result = a.sub(b);
                    break;
                case "*":
                    result = a.multi(b);
                    break;
            }

            return result;
        }

        static void ShowDialog()
        {
            string s;

            do
            {
                Console.Clear();

                ClassComplex.Complex a = new ClassComplex.Complex(
                                            GetDouble("Введите вещественную часть первого числа:")
                                            , GetDouble("Введите мнимую часть первого числа:")
                                            );
                ClassComplex.Complex b = new ClassComplex.Complex(
                                            GetDouble("Введите вещественную часть второго числа:")
                                            , GetDouble("Введите мнимую часть второго числа:")
                                            );
                Console.WriteLine("Введите действие (+, -, *):");
                s = Console.ReadLine();

                Console.WriteLine($"({a}) {s} ({b}) = {GetResult(a, b, s)}");

                Console.WriteLine("Для завершения введите N и Enter");
                s = Console.ReadLine();
            } while (s.ToLower() != "n");
        }


        static void Main(string[] args)
        {
            // структура Complex
            Console.WriteLine("Работа с комплексными числами, описанными структурой:");
            StructComplex.Complex a, b;
            a.re = 5;
            a.im = 10;
            b.re = 10;
            b.im = 5;

            Console.WriteLine($"({a}) + ({b}) = {a.plus(b)}");
            Console.WriteLine($"({a}) - ({b}) = {a.sub(b)}");
            Console.WriteLine($"({a}) * ({b}) = {a.multi(b)}");
            Console.ReadKey();

            // класс Complex
            Console.WriteLine("\nРабота с комплексными числами, описанными классом:");
            ClassComplex.Complex x = new ClassComplex.Complex(5, 10);
            ClassComplex.Complex y = new ClassComplex.Complex(10, 5);

            Console.WriteLine($"({x}) + ({y}) = {x.plus(y)}");
            Console.WriteLine($"({x}) - ({y}) = {x.sub(y)}");
            Console.WriteLine($"({x}) * ({y}) = {x.multi(y)}");
            Console.ReadKey();

            // диалог
            ShowDialog();
        }
    }
}
