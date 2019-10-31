/* Михеев Константин
    Задание 5:
        а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс 
        массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме. 
        б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса. 
*/
using System;

namespace CSharpLevel1Lesson2Task5
{
    class Program
    {
        static double WeightIndex(double height, double weight)
        {
            return weight / (height * height);
        }

        static string WeightAlert(double weightIndex)
        {
            string result;

            if (weightIndex <= 16)
            {
                result = "У вас выраженный дефицит массы тела";
            }
            else
            {
                if (weightIndex > 16 && weightIndex <= 18.5)
                {
                    result = "У вас недостаточная масса тела";
                }
                else
                {
                    if (weightIndex > 18.5 && weightIndex < 25)
                    {
                        result = "У вас нормальная масса тела";
                    }
                    else
                    {
                        if (weightIndex >= 25 && weightIndex < 30)
                        {
                            result = "У вас избыточная масса тела (предожирение)";
                        }
                        else
                        {
                            if (weightIndex >= 30 && weightIndex < 35)
                            {
                                result = "У вас ожирение";
                            }
                            else
                            {
                                if (weightIndex >= 35 && weightIndex < 40)
                                {
                                    result = "У вас резкое ожирение";
                                }
                                else
                                {
                                    result = "У вас очень резкое ожирение";
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        static double WeightRecommendation(double height, double weight)
        {
            double weightIndex = WeightIndex(height, weight);

            if (weightIndex <= 18.5)
            {
                return 18.6 * height * height;
            }
            else
            {
                if (weightIndex >= 25)
                {
                    return 24.99 * height * height;
                }
                else
                {
                    return weight;
                }
            }
        }

        static string WeightRecommendationAlert(double height, double weight)
        {
            double recommendedWeight = WeightRecommendation(height, weight);

            if (weight < recommendedWeight)
            {
                return string.Format("Вам необходимо набарть минимум {0:f3} кг", recommendedWeight - weight);
            }
            else
            {
                if (weight > recommendedWeight)
                {
                    return string.Format("Вам необходимо сбросить минимум {0:f3} кг", weight - recommendedWeight);
                }
            }

            return "Вам ничего менять не надо";
        }


        static void Main(string[] args)
        {
            Console.Write("Введите ваш вес в кг: ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите ваш рост в метрах (например, 1.75 или 1,75): ");
            double height = Convert.ToDouble(Console.ReadLine());

            double weightIndex = WeightIndex(height, weight);

            Console.Clear();
            Console.WriteLine($"Для веса {weight} кг и роста {height} м, индекс массы тела равен {weightIndex:F0}");
            Console.WriteLine($"{WeightAlert(weightIndex)}");
            Console.WriteLine(WeightRecommendationAlert(height, weight));

            Console.ReadKey();
        }
    }
}
