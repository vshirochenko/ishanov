using System;

namespace Lab1
{
    class Solver
    {
        private double k = 1e-5; // Аэродинамический коэффициент.
        private double g = 9.81; // Ускорение свободного падения.
        private double v0 = 100.0; // Начальная скорость.
        private double Eps = 1e-5; // Точность вычислений.
        private double m = 1.0; // Фиктивная масса ракеты.

        /// <summary>
        /// Вычисление мгновенной скорости.
        /// </summary>
        /// <param name="t">время</param>
        /// <param name="C">константа</param>
        /// <returns></returns>
        private double Speed(double t, double C)
        {
            return Math.Sqrt(g / k) * Math.Atan(Math.Sqrt(k * g) * (C - t));
        }

        /// <summary>
        /// Вычисление пройденный путь.
        /// </summary>
        /// <param name="t">время</param>
        /// <param name="C">константа</param>
        /// <returns></returns>
        private double Distance(double t, double C)
        {
            return 1.0 / k * Math.Log(
                                Math.Abs(
                                    Math.Cos(
                                        Math.Sqrt(k * g) * (C - t))));
        }

        /// <summary>
        /// Основной блок - решение задачи.
        /// </summary>
        public void Solve()
        {
            double C, s0; // C - для скорости, s0 - для расстояния.
            C = 1.0 / Math.Sqrt(k * g) * Math.Atan(v0 * Math.Sqrt(k / g));
            s0 = -1.0 / k * Math.Log(
                                Math.Abs(
                                    Math.Cos(
                                        Math.Sqrt(k * g) * C)));
            double t = 0.0; // Текущее время.
            double v = v0; // Мгновенная скорость.
            double s; // Текущая высота подъема ракеты.

            while (v > Eps)
            {
                t += 0.1; // Шаг по времени.
                v = Speed(t, C);
                s = Distance(t, C) + s0;
                Console.WriteLine("Время = {0:0.000}\tСкорость = {1:0.000}\tВысота = {2:0.000}\n", t, v, s);
                //Thread.Sleep(500);
            }

            double tmax = C; // Время подъема до максимальной отметки.
            double smax = s0; // Максимальная высота, на которую может подняться ракета.

            Console.WriteLine("\n\nВремя полета до максимальной высоты = {0}", tmax);
            Console.WriteLine("Максимальная высота = {0}", smax);
        }
    }

    class Program
    {
        static void Main()
        {
            Solver solve = new Solver();
            solve.Solve();
        }
    }
}
