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
            int C = Convert.ToInt32(Console.ReadLine());
            double F = C * 9 / 5 + 32;
            Console.WriteLine(F);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                Thread.Sleep(2000);
            }
            Console.WriteLine("Загрузка завершена");

            Console.WriteLine("Введите первое число:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите третье число:");
            int c = Convert.ToInt32(Console.ReadLine());
            double d = (a + b + c) / 3;
            Console.WriteLine("Среднее арифметическое: " + d);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
                Thread.Sleep(2000);
            }
            Console.WriteLine("Загрузка завершена");

            Console.WriteLine("Введите первое число:");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int x = Convert.ToInt32(Console.ReadLine());

            int A = z + x;
            int B = z - x;
            int Z = z * x;
            int D = z / x;
            Console.WriteLine("Сумма: " + A);
            Console.WriteLine("Разность: " + B);
            Console.WriteLine("Произведение: " + Z);
            Console.WriteLine("Частное (деление нацело): " + D);
        }
    }
}