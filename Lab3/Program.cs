using System;
using System.Globalization;
using System.IO;

namespace Lab3
{
    class Solver
    {
        private double n;
        private double a = 1.0;
        private double e = Math.E;
        private double r;

        private StreamWriter _writer = new StreamWriter("output.txt");

        private double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }
        private void ReadData()
        {
            Console.WriteLine("Введите численность популяции (незараженные): ");
            n = double.Parse(Console.ReadLine());
            //Console.WriteLine("Введите число зараженных, которые вводятся в сообщество: ");
            //a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите коэффициент пропорциональности r: ");
            r = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("\n\n\n");
        }
        public void Solve()
        {
            ReadData(); // Считываем входные данные.

            double x = n;
            double dt = 0.0;
            
            while (x > 0)
            {
                x = CountSurvivors(dt);
                _writer.WriteLine("Время с начала заражения: {0:0.000}", dt);
                _writer.WriteLine("Число выживших: {0}", x);
                _writer.WriteLine("Число зараженных: {0}", n + a - x);
                _writer.WriteLine();
                dt += 0.00001;
            }
            _writer.Close();
        }

        private double CountSurvivors(double t)
        {
            double answer = Math.Floor(n * (n + a) / (n + a * Pow(e, r * t * (n + a))));
            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solver solve = new Solver();
            solve.Solve();
        }
    }
}
