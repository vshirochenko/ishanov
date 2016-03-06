using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Solver
    {
        private int T, t;
        private double k;
        private double ans;
        private double e = Math.E;

        private double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }
        private void ReadData()
        {
            Console.WriteLine("Введите период полураспада радия: ");
            T = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите время, через которое хотите узнать процент распавшихся ядер радия: ");
            t = int.Parse(Console.ReadLine());
        }
        public void Solve()
        {
            ReadData(); // Считываем входные данные.

            k = Math.Log(2.0) / T;
            for (int dt = 0; dt <= t; dt++)
            {             
                ans = (1.0 - Pow(e, -k * dt)) * 100;
                Console.WriteLine("Процент распавшихся ядер = {0:0.0000000}", ans);
            }
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
