using System;

namespace Brahistohrona
{
    class Solver
    {
        private double EPS = 1e-6;
        private double x, y;
        private void ReadData()
        {
            Console.WriteLine("Введите X\t: ");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите Y\t: ");
            y = double.Parse(Console.ReadLine());
        }

        public void Solve()
        {
            ReadData();
            MainProcess();
        }

        private void MainProcess()
        {
            for (double t = 0.0; t <= 1000.0; t += 1e-6)
            {
                double r = y / (1 - Math.Cos(t));
                if (IsGood(r, t))
                {
                    Console.WriteLine("r = {0}\n", r);
                    return;
                }
            }
            Console.WriteLine("Izvini...");
        }

        private bool IsGood(double r, double t)
        {
            return Math.Abs(r * (t - Math.Sin(t)) - x) < EPS;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solver solver = new Solver();
            solver.Solve();
        }
    }
}
