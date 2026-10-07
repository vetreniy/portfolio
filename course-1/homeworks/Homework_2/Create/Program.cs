using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = { "Загрузка.", "Загрузка..", "Загрузка..." };

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                Thread.Sleep(2000);
            }
            
            Console.WriteLine("Загрузка завершена");

            Console.WriteLine("Введите температуру в Градусах Цельсия: ");
            double C = Convert.ToInt32(Console.ReadLine());
            double F = C * 9 / 5 + 32;
            Console.WriteLine(F);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                Thread.Sleep(2000);
            }
            Console.WriteLine("Загрузка завершена");

            Console.WriteLine("Введите первое число:");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            double b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите третье число:");
            double c = Convert.ToInt32(Console.ReadLine());
            double d = (a + b + c) / 3;
            Console.WriteLine("Среднее арифметическое: " + d);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                Thread.Sleep(2000);
            }
            Console.WriteLine("Загрузка завершена");

            Console.WriteLine("Введите первое число:");
            double z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            double x = Convert.ToInt32(Console.ReadLine());

            double A = z + x;
            double B = z - x;
            double Z = z * x;
            double D = z / x;
            Console.WriteLine("Сумма: " + A);
            Console.WriteLine("Разность: " + B);
            Console.WriteLine("Произведение: " + Z);
            Console.WriteLine("Частное: " + D);
        }
    }
}