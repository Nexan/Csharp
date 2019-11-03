/* Михеев Константин
    Задание 3:
        *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
        Предусмотреть  методы  сложения,  вычитания,  умножения  и  деления  дробей.  Написать 
        программу, демонстрирующую все разработанные элементы класса. 
        * Добавить свойства типа int для доступа к числителю и знаменателю; 
        * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа; 
        **  Добавить  проверку,  чтобы  знаменатель  не  равнялся  0.  Выбрасывать  исключение 
        ArgumentException("Знаменатель не может быть равен 0"); 
        *** Добавить упрощение дробей. 
 */
using System;

namespace CSharpLevel1Lesson3Task3
{
    /// <summary>
    /// Класс, описывающий рациональное число
    /// numerator - числитель
    /// denominator - знаменатель
    /// </summary>
    public class RationalNumber
    {
        private int numerator;
        private int denominator;

        #region // Свойства класса
        public int Numerator
        {
            get { return numerator; }
            set
            {
                numerator = value;
            }
        }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                denominator = value;
            }
        }

        public double Decimal
        {
            get { return (double)numerator / denominator; }
        }
        #endregion

        #region // Конструкторы класса
        public RationalNumber()
        {
            numerator = denominator = 1;
        }

        public RationalNumber(int numerator)
        {
            this.numerator = numerator;
            denominator = 1;
        }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }
        #endregion

        #region // Действия с рациональными числами
        public RationalNumber plus (RationalNumber a)
        {
            RationalNumber result = new RationalNumber();

            result.numerator = numerator * a.denominator + a.numerator * denominator;
            result.denominator = denominator * a.denominator;

            Reduce(ref result.numerator, ref result.denominator);

            return result;
        }

        public RationalNumber sub(RationalNumber a)
        {
            RationalNumber result = new RationalNumber();

            result.numerator = numerator * a.denominator - a.numerator * denominator;
            result.denominator = denominator * a.denominator;

            Reduce(ref result.numerator, ref result.denominator);

            return result;
        }

        public RationalNumber multi(RationalNumber a)
        {
            RationalNumber result = new RationalNumber();

            result.numerator = numerator * a.numerator;
            result.denominator = denominator * a.denominator;

            Reduce(ref result.numerator, ref result.denominator);

            return result;
        }

        public RationalNumber div(RationalNumber a)
        {
            RationalNumber result = new RationalNumber();

            result.numerator = numerator * a.denominator;
            result.denominator = denominator * a.numerator;

            Reduce(ref result.numerator, ref result.denominator);

            return result;
        }

        /// <summary>
        /// Производит сокращение дроби, если это возможно
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        private void Reduce(ref int numerator, ref int denominator)
        {
            if (numerator == 0 || denominator == 1)
            {
                return;
            }
            if (numerator == denominator)
            {
                numerator = denominator = 1;
                return;
            }

            int del = 2;
            while (del <= Math.Min(numerator, denominator))
            {
                while (numerator % del == 0 && denominator % del == 0)
                {
                    numerator /= del;
                    denominator /= del;
                }

                del++;
            }
        }
        #endregion

        public override string ToString()
        {
            if (numerator == 0)
            {
                return "0";
            }
            if (denominator == 1)
            {
                return $"{numerator}";
            }

            return $"{numerator}/{denominator}";
        }
    }

    class Program
    {
        static int GetInt(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        static RationalNumber GetResult(RationalNumber a, RationalNumber b, string action)
        {
            RationalNumber result = new RationalNumber();

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
                case "/":
                    result = a.div(b);
                    break;
                default:
                    throw new Exception("Недопустимая операция над дробями.");
            }

            return result;
        }

        static void ShowDialog()
        {
            string s;

            do
            {
                Console.Clear();

                RationalNumber a = new RationalNumber(
                                            GetInt("Введите числитель первого числа:")
                                            , GetInt("Введите знаменатель первого числа:")
                                            );
                RationalNumber b = new RationalNumber(
                                            GetInt("Введите числитель второго числа:")
                                            , GetInt("Введите знаменатель второго числа:")
                                            );
                Console.WriteLine("Введите действие (+, -, *, /):");
                s = Console.ReadLine();

                RationalNumber result = GetResult(a, b, s);
                Console.WriteLine($"({a}) {s} ({b}) = {result} ({result.Decimal})");

                Console.WriteLine("Для завершения введите N и Enter");
                s = Console.ReadLine();
            } while (s.ToLower() != "n");
        }


        static void Main(string[] args)
        {
            ShowDialog();
        }
    }
}
